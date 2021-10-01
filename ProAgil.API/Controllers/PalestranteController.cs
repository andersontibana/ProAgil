using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repo;
        public PalestranteController(IProAgilRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet("{PalestranteId}")]
        public async Task<IActionResult> Get(int PalestranteId)
        {
            try{
                var results = await _repo.GetPalestranteAsync(PalestranteId, true);
                return Ok(results);
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }
        
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try{
                var results = await _repo.GetAllPalestrantesAsyncByName(name, true);
                return Ok(results);
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }
        
        }

    }
}