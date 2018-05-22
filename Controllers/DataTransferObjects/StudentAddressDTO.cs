namespace backEnd.Controllers.DataTransferObjects
{
    public class StudentAddressDTO
    {

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? StreetId { get; set; }
        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }

        public StreetDTO Street { get; set; }
        public BarangayDTO Barangay { get; set; }
        public MunicipalityDTO Municipality { get; set; }
        public ProvinceDTO Province { get; set; }
    }
}