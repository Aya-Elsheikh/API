using MediatR;
using Newtonsoft.Json.Linq;
using System.Text;
public class GetPopulationsQuery : IRequest<List<PopulationData>>
{
}

public class GetPopulationsQueryHandler : IRequestHandler<GetPopulationsQuery, List<PopulationData>>
{
    public async Task<List<PopulationData>> Handle(GetPopulationsQuery request, CancellationToken cancellationToken)
    {
        var url = "https://geostat.dsc.gov.ae/geostat/WebService/ServiceMap.asmx";
        var soapBody = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GET_V_DATA_POPULATION xmlns=""http://tempuri.org/"" />
  </soap:Body>
</soap:Envelope>";

        using var client = new HttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Content = new StringContent(soapBody, Encoding.UTF8, "text/xml");
        requestMessage.Headers.Add("SOAPAction", "http://tempuri.org/GET_V_DATA_POPULATION");

        var response = await client.SendAsync(requestMessage, cancellationToken);
        var content = await response.Content.ReadAsStringAsync();

        Console.WriteLine(content); 

        var startTag = "<GET_V_DATA_POPULATIONResult>";
        var endTag = "</GET_V_DATA_POPULATIONResult>";

        var start = content.IndexOf(startTag);
        var end = content.IndexOf(endTag);

        if (start == -1 || end == -1 || end <= start)
        {
            throw new Exception("Cannot find <GET_V_DATA_POPULATIONResult> in response. Check if SOAP request worked correctly.");
        }

        start += startTag.Length;
        var jsonString = content[start..end];

        var json = JObject.Parse(jsonString);
        var features = json["features"];
        var populationList = new List<PopulationData>();

        foreach (var feature in features)
        {
            var props = feature["properties"];
            var data = new PopulationData
            {
                CalendarYear = props["CALENDAR_YEAR"]?.ToString(),
                SectorName = props["SECTOR_NAME"]?.ToString(),
                CommunityName = props["COMMUNITY_NAME"]?.ToString(),

                EmiratiMale = int.Parse(props["EMIRATIE_MALE"]?.ToString() ?? "0"),
                EmiratiFemale = int.Parse(props["EMIRATIE_FEMALE"]?.ToString() ?? "0"),
                SumEmirati = int.Parse(props["SUM_EMIRATI"]?.ToString() ?? "0"),

                NonEmiratiMale = int.Parse(props["NON_EMIRATI_MALE"]?.ToString() ?? "0"),
                NonEmiratiFemale = int.Parse(props["NON_EMIRATI_FEMALE"]?.ToString() ?? "0"),
                SumNonEmirati = int.Parse(props["SUM_NON_EMIRATI"]?.ToString() ?? "0"),

                EmployeeResidentMale = int.Parse(props["EMPLOYEE_RESIDENT_MALE"]?.ToString() ?? "0"),
                EmployeeResidentFemale = int.Parse(props["EMPLOYEE_RESIDENT_FEMALE"]?.ToString() ?? "0"),
                SumEmployeeResident = int.Parse(props["SUM_EMPLOYEE_RESIDENT"]?.ToString() ?? "0"),

                WorkerResidentMale = int.Parse(props["WORKER_RESIDENT_MALE"]?.ToString() ?? "0"),
                WorkerResidentFemale = int.Parse(props["WORKER_RESIDENT_FEMALE"]?.ToString() ?? "0"),
                SumWorkerResident = int.Parse(props["SUM_WORKER_RESIDENT"]?.ToString() ?? "0"),

                Male = int.Parse(props["MALE"]?.ToString() ?? "0"),
                Female = int.Parse(props["FEMALE"]?.ToString() ?? "0"),
                TotalPopulation = int.Parse(props["TOTAL_POPULATION"]?.ToString() ?? "0")
            };
            populationList.Add(data);
        }

        return populationList;
    }
}

public class PopulationData
{
    public string CalendarYear { get; set; }
    public string SectorName { get; set; }
    public string CommunityName { get; set; }

    public int EmiratiMale { get; set; }
    public int EmiratiFemale { get; set; }
    public int SumEmirati { get; set; }

    public int NonEmiratiMale { get; set; }
    public int NonEmiratiFemale { get; set; }
    public int SumNonEmirati { get; set; }

    public int EmployeeResidentMale { get; set; }
    public int EmployeeResidentFemale { get; set; }
    public int SumEmployeeResident { get; set; }

    public int WorkerResidentMale { get; set; }
    public int WorkerResidentFemale { get; set; }
    public int SumWorkerResident { get; set; }

    public int Male { get; set; }
    public int Female { get; set; }
    public int TotalPopulation { get; set; }
}