using MediatR;
using PuppeteerSharp;
using System.Globalization;

namespace Application.RealEstate.Queries
{
    public record GetAveragePricePerSqFtQueryAPI(double Latitude, double Longitude) : IRequest<double?>;

    public class GetAveragePricePerSqFtQueryAPIHandler : IRequestHandler<GetAveragePricePerSqFtQueryAPI, double?>
    {
        public async Task<double?> Handle(GetAveragePricePerSqFtQueryAPI request, CancellationToken cancellationToken)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync(); 


            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true, 
            });

            var page = await browser.NewPageAsync();

            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");

            string url = $"https://www.propertyfinder.ae/en/rent/apartments-for-rent/dubai.html?latitude={request.Latitude}&longitude={request.Longitude}";

            await page.GoToAsync(url);

            await page.WaitForSelectorAsync(".card-price");

            var prices = await page.EvaluateExpressionAsync<string[]>(
                @"Array.from(document.querySelectorAll('.card-price')).map(x => x.innerText.replace('AED','').replace(',','').trim())"
            );

            var sizes = await page.EvaluateExpressionAsync<string[]>(
                @"Array.from(document.querySelectorAll('.card-size')).map(x => x.innerText.replace('sq.ft','').replace(',','').trim())"
            );

            await browser.CloseAsync();

            var valid = prices.Zip(sizes, (p, s) =>
            {
                bool isPrice = double.TryParse(p, NumberStyles.Any, CultureInfo.InvariantCulture, out double priceVal);
                bool isSize = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double sizeVal);
                return (priceVal, sizeVal, isValid: isPrice && isSize && priceVal > 0 && sizeVal > 0);
            })
            .Where(x => x.isValid)
            .ToArray();

            if (!valid.Any()) return null;

            double avgPricePerSqft = valid.Average(x => x.priceVal / x.sizeVal);
            return avgPricePerSqft;
        }
    }
}
