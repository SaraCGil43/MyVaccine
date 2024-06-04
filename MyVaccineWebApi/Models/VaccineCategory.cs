namespace MyVaccineWebApi.Models
{
    public class VaccineCategory : BaseTable
    {
        public int VaccineCategoryId { get; set; }
        public string Name { get; set; }
        public List<Vaccine> Vaccines { get; set; }
    }
}
