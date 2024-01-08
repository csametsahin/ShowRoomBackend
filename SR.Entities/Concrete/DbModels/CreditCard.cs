using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Entities.Concrete.BaseEntities;

namespace SR.Entities.Concrete.DbModels
{
    public class CreditCard : BaseEntity
    {
        [Required]
        [MaxLength(16)] // Assuming a 16-digit credit card number
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string CardHolderName { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(3)] // Assuming a 3-digit CVV
        public string CVV { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        // Navigation property for the user
        public virtual User User { get; set; }
    }
}
