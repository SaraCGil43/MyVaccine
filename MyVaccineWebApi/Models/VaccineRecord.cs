﻿namespace MyVaccineWebApi.Models
{
    public class VaccineRecord
    {
        public int VaccineRecordId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DependentId { get; set; }
        public Dependent Dependent { get; set; }
        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public string DateAdministered { get; set; }
        public string AdministeredLocation { get; set; }
        public string AdministeredBy { get; set; }
    }
}
