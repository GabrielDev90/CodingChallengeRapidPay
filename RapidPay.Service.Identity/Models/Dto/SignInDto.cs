using System.ComponentModel.DataAnnotations;

namespace RapidPay.Service.Identity.Models.Dto
{
    public class SignInDto
    {
        [Required] 
        public string UserName { get; set; }
            
        [Required] 
        public string Password { get; set; }
    }
}
