using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = Solution.DO.Objects;
using Solution.BS;
using Solution.DAL.EF;


namespace Solution.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public FuncionariosController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Funcionarios>>> GetFuncionarios()
        {
            return new Funcionarios(_context).GetAll().ToList();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Funcionarios>> GetFuncionarios(string id)
        {
            var funcionarios = new Funcionarios(_context).GetOneById(id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return funcionarios;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(string id, data.Funcionarios funcionarios)
        {
            if (id != funcionarios.IdFuncionario.ToString())
            {
                return BadRequest();
            }

            // _context.Entry(cuentas).State = EntityState.Modified;

            try
            {
                new Funcionarios(_context).Updated(funcionarios);
            }
            catch (Exception ee)
            {
                throw ee;
            }

            return NoContent();
        }

            // POST: api/Funcionarios
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
        public async Task<ActionResult<data.Funcionarios>> PostFuncionarios(data.Funcionarios funcionarios)
        {
            new Funcionarios(_context).Insert(funcionarios);
            return CreatedAtAction("GetCuentas", new { id = funcionarios.IdFuncionario }, funcionarios);

        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Funcionarios>> DeleteFuncionarios(string id)
        {
            var funcionarios = new Funcionarios(_context).GetOneById(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            new Funcionarios(_context).Delete(funcionarios);
            await _context.SaveChangesAsync();

            return funcionarios;
        }

        //private bool FuncionarioExists(string id)
        //{
        //    return _context.Funcionario.Any(e => e.IdFuncionario == id);
        //}
    }
}
