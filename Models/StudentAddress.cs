namespace backEnd.Models
{
    public class StudentAddress
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? StreetId { get; set; }
        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }

        public Student Student { get; set; }
        public Street Street { get; set; }
        public Barangay Barangay { get; set; }
        public Municipality Municipality { get; set; }
        public Province Province { get; set; }

    }
}