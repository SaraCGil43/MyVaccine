namespace MyVaccineWebApi.Models
{
    public class Vaccine
    {
        public int VaccineId { get; set; }
        public int Name { get; set; }
        public List<VaccineCategory> Categories { get; set; }
        public bool RequiresBooster { get; set; }

    }
}
