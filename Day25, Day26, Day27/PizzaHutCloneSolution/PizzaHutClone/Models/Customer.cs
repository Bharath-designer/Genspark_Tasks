using System.ComponentModel.DataAnnotations;

namespace PizzaHutClone.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } 
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; } 


    }
}
