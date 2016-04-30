using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Customers
    {
        [Key]
        public string CustomerID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public AddressDetails AddressDetails { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public Customers()
        {
            this.AddressDetails = new AddressDetails();
        }
    }
}
