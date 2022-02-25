using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetTest.DTOs
{
    public class CreateFuellingStationInfoDto
    {
        [Required]
        public string OwnersName { get; set; }
        [Required]
        public  IFormFile DepotReceiptUrl { get; set; }
        [Required]
        public  IFormFile BusinessDocUrl { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Lga { get; set; }
        [Required]
        public string State { get; set; }
        
    }
}