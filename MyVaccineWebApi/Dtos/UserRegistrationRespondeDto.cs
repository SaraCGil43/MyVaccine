namespace MyVaccineWebApi.Dtos
{
    public class UserRegistrationRespondeDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsSuccess { get; set; }

    }
}
