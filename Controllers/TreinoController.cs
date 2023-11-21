using ControleExercicios.Context;
using Microsoft.AspNetCore.Mvc;

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

        private bool TreinoExists(Guid id)
        {
            return(_context.Treinos?.Any(treino => treino.ID == id)).GetValueOrDefault();
        }
    }
}