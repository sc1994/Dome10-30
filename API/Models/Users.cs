namespace API.Models
{
    public class Users
    {
        public int UID { get; set; } = 0;
        public string UName { get; set; } = string.Empty;
        public string UPhone { get; set; } = string.Empty;
        public int USex { get; set; } = 0;
        public string UPassword { get; set; } = string.Empty;
        public string UEmail { get; set; } = string.Empty;
    }
}