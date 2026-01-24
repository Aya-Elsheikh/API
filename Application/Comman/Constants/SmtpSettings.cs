namespace Application.Comman.Constants
{
    public class SmtpSettings
    {
        public string Host { get; set; } = string.Empty;       // مثال: smtp.gmail.com
        public int Port { get; set; } = 587;                  // غالبًا 587 للTLS
        public string Username { get; set; } = string.Empty;  // الإيميل اللي هيبعت منه
        public string Password { get; set; } = string.Empty;  // الباسورد أو App Password
        public bool EnableSsl { get; set; } = true;
        public string FromEmail { get; set; } = string.Empty; // نفس الـ Username غالبًا
        public string FromName { get; set; } = "MyApp";       // الاسم الظاهر للمستلم
    }

}
