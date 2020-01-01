using System;
using EHRS.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace EHRS.IdentityServer.Entities
{
    public class AspNetUsers
    {
        [Key] 
        public string Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string MobileNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AreaId { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public DateTime CreatedDate { get; set; }


        
    }
}