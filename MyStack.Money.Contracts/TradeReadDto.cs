using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.Money.Contracts
{
    public class TradeReadDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = "";
        public string Ticker { get; set; } = "";
        public string Name { get; set; } = "";
        public string InstrumentType { get; set; } = "";
        public string Currency { get; set; } = "";
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Fee { get; set; }
        public string? Notes { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
