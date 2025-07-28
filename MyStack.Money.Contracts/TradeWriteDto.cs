using System.ComponentModel.DataAnnotations;

namespace MyStack.Money.Contracts
{
    public class TradeWriteDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Type { get; set; } = ""; 

        [Required]
        [MaxLength(20)]
        public string Ticker { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [MaxLength(30)]
        public string InstrumentType { get; set; } = "";

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "";

        [Required]
        [Range(0.00000001, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [Range(0.00001, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Fee { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
