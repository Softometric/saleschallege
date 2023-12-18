using Application.Common.Enums;

namespace Application.Common.Models.CustomerDto
{
    public class CustomerRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? StreetNumber { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public SexEnum? Gender { get; set; }
    }

    public class CustomerModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
}
