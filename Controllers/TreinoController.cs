using ControleExercicios.Context;
using Microsoft.AspNetCore.Mvc;
using ControleExercicios.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleExercicios.Controller
{
    [Route("FichaTreino")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly TreinoContext? _context;

        public TreinoController(TreinoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treino>>> GetTreino()
        {
            if(_context.Treinos == null)
            {
                return NotFound();
            }

            return await _context.Treinos.ToListAsync();
        }

        private bool TreinoExists(Guid id)
        {
            return(_context.Treinos?.Any(treino => treino.ID == id)).GetValueOrDefault();
        }
    }
}