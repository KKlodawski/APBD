using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace Zadanie5.DTOs
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        public int IdWarehouse { get; set; } 
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be higher than 0")]
        public int Amount { get; set; }
        [DisallowNull]
        public string CreatedAt { get; set; }
        
    }
}
