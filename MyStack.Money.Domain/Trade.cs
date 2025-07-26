using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStack.Money.Domain
{
    public class Trade
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TradeType Type { get; set; }  // 0 = Buy, 1 = Sell

        [Required]
        [MaxLength(20)]
        public string? Ticker { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(30)]
        public InstrumentType InstrumentType { get; set; }

        [Required]
        [MaxLength(10)]
        public Currency Currency { get; set; }

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

        [NotMapped]
        public decimal TotalAmount =>
            Type == TradeType.Buy
                ? (Quantity * UnitPrice) + Fee
                : (Quantity * UnitPrice) - Fee;
    }
}
