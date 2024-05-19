using System.ComponentModel.DataAnnotations;
using PizzaHutClone.Models.DTOs;

namespace PizzaHutClone.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double PriceInRupees { get; set; }
        public bool InStock { get; set; }
        public int SellerId { get; set; }
        public Customer Customer { get; set; }
    }
}
