namespace backEnd.Controllers.Resources
{
    public class StudentAddressResource
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? StreetId { get; set; }
        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }  
             
    }
}