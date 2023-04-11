using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EShopCart.Models
{
    public class Promotions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }


    }
}
