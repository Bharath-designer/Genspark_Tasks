using System.ComponentModel.DataAnnotations;

namespace PizzaHutClone.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 
        public byte[] HashedPassword { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public string Status { get; set; }
        public string Roles { get; set; }
        public Customer Customer { get; set; }
    }
}
