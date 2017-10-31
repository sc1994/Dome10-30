namespace API.Models
{
    public class UserParameter : Users
    {
        public string Md5 { get; set; } = string.Empty;

        public static readonly string UserCookie = "UserCookie";
    }
}