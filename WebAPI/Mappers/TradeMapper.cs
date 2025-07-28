using MyStack.Money.Contracts;
using MyStack.Money.Domain;

namespace WebAPI.Mappers
{
    public static class TradeMapper
    {
        // Convierte una entidad a DTO de lectura
        public static TradeReadDto ToReadDto(Trade trade)
        {
            return new TradeReadDto
            {
                Id = trade.Id,
                Date = trade.Date,
                Type = trade.Type.ToString(),
                Ticker = trade.Ticker ?? "",
                Name = trade.Name ?? "",
                InstrumentType = trade.InstrumentType.ToString(),
                Currency = trade.Currency.ToString(),
                Quantity = trade.Quantity,
                UnitPrice = trade.UnitPrice,
                Fee = trade.Fee,
                Notes = trade.Notes,
                TotalAmount = trade.TotalAmount
            };
        }

        // Convierte un DTO de escritura a una nueva entidad
        public static Trade FromWriteDto(TradeWriteDto dto)
        {
            return new Trade
            {
                Date = dto.Date,
                Type = Enum.Parse<TradeType>(dto.Type, ignoreCase: true),
                Ticker = dto.Ticker,
                Name = dto.Name,
                InstrumentType = Enum.Parse<InstrumentType>(dto.InstrumentType, ignoreCase: true),
                Currency = Enum.Parse<Currency>(dto.Currency, ignoreCase: true),
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                Fee = dto.Fee,
                Notes = dto.Notes
            };
        }

        // Actualiza una entidad existente con un DTO de escritura
        public static void UpdateEntityFromDto(Trade trade, TradeWriteDto dto)
        {
            trade.Date = dto.Date;
            trade.Type = Enum.Parse<TradeType>(dto.Type, ignoreCase: true);
            trade.Ticker = dto.Ticker;
            trade.Name = dto.Name;
            trade.InstrumentType = Enum.Parse<InstrumentType>(dto.InstrumentType, ignoreCase: true);
            trade.Currency = Enum.Parse<Currency>(dto.Currency, ignoreCase: true);
            trade.Quantity = dto.Quantity;
            trade.UnitPrice = dto.UnitPrice;
            trade.Fee = dto.Fee;
            trade.Notes = dto.Notes;
        }
    }
}
