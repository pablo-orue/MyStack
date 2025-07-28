using Microsoft.AspNetCore.Mvc;
using MyStack.Money.Contracts;
using MyStack.Money.Service;
using WebAPI.Mappers;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        // GET: api/trade
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trades = await _tradeService.GetAllAsync();
            var dtoList = trades.Select(TradeMapper.ToReadDto);
            return Ok(dtoList);
        }

        // GET: api/trade/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trade = await _tradeService.GetByIdAsync(id);
            if (trade is null)
                return NotFound();

            var dto = TradeMapper.ToReadDto(trade);
            return Ok(dto);
        }

        // POST: api/trade
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TradeWriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trade = TradeMapper.FromWriteDto(dto);
            var created = await _tradeService.CreateAsync(trade);
            var resultDto = TradeMapper.ToReadDto(created);

            return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/trade/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TradeWriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _tradeService.GetByIdAsync(id);
            if (existing is null)
                return NotFound();

            TradeMapper.UpdateEntityFromDto(existing, dto);
            var success = await _tradeService.UpdateAsync(existing);

            return success ? NoContent() : StatusCode(500, "Error al actualizar el registro.");
        }

        // DELETE: api/trade/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tradeService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
