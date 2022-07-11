using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.CardManagement.Module.Models
{
    public class Card
    {
        [Key]
        public Guid Guid { get; set; }
        public long Number { get; set; }
        public double Balance { get; set; }

    }
}
