namespace RaceDay_MVC.Models
{
    public class RegisterDto
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Comfirmpassword { get; set; } // Note the spelling from your API!
        public string PhoneNUmber { get; set; }
        public string role { get; set; } // "Organiser" or "Participant"
    }
}