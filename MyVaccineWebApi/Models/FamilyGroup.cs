namespace MyVaccineWebApi.Models
{
    public class FamilyGroup : BaseTable
    {
        public int FamilyGroupId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
