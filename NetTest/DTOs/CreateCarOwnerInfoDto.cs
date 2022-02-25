using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetTest.DTOs
{
    public class CreateCarOwnerInfoDto
    {
        [Required]
         public string FirstName { get; set; }
         [Required]
        public string LastName { get; set; }
        [Required]
         public string Address { get; set; }
         [Required]
        public string Lga { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string VehicleMaker { get; set; }
        [Required]
        public string VehicleModel { get; set; }
        [Required]
        public IFormFile VehicleDocUrl { get; set; }
        [Required]
        public IFormFile PurchaseReceiptUrl { get; set; }
    }
}