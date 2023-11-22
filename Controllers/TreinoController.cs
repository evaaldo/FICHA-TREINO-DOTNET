using ControleExercicios.Context;
using Microsoft.AspNetCore.Mvc;
using ControleExercicios.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Treino>> GetTreino(Guid id)
        {
            if(_context.Treinos == null)
            {
                return NotFound();
            }

            var treino = await _context.Treinos.FindAsync(id);

            if(treino == null)
            {
                return NotFound();
            }

            return treino;
        }

        [HttpPost]
        public async Task<ActionResult<Treino>> PostTreino(Guid id, Treino treino)
        {
            if(_context.Treinos == null)
            {
                return Problem("Os treinos estão vazios!");;
            }

            _context.Treinos.Add(treino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreino", new { id = treino.ID }, treino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreino(Guid id, Treino treino)
        {
            if(id != treino.ID)
            {
                return BadRequest();
            }

            _context.Treinos.Entry(treino).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DBConcurrencyException)
            {
                if(!TreinoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TreinoExists(Guid id)
        {
            return(_context.Treinos?.Any(treino => treino.ID == id)).GetValueOrDefault();
        }
    }
}