using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.CardManagement.Module.Models
{
    public class Payment
    {
        [Key]
        public float Amount { get; set; }
        public DateTime PaymentData { get; set; }
    }
}
