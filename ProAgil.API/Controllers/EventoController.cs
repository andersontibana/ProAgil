using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.Dtos;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;
        private readonly IMapper _mapper;

        public EventoController(IProAgilRepository repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var eventos = await _repo.GetAllEventoAsync(true);
                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok(results);
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }
        
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try{
                var evento = await _repo.GetAllEventoAsyncById(EventoId, true);
                var results = _mapper.Map<EventoDto>(evento);
                return Ok(results);
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }
        
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try{
                var results = await _repo.GetAllEventoAsyncByTema(tema, true);
                return Ok(results);
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }
        
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try{
                var evento = _mapper.Map<Evento>(model);
                _repo.Add(evento);
                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }

            return BadRequest();
        
        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, EventoDto model)
        {
            try{
                var evento = await _repo.GetAllEventoAsyncById(EventoId, false);
                if(evento == null) return NotFound();
                _mapper.Map(model, evento);

                _repo.Update(evento);
                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }

            return BadRequest();
        
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try{
                var evento = await _repo.GetAllEventoAsyncById(EventoId, false);
                if(evento == null) return NotFound();

                _repo.Delete(evento);
                if(await _repo.SaveChangesAsync()){
                    return Ok();
                }
            }
            catch(System.Exception){
                return this.StatusCode(500, "Banco de dados falhou.");
            }

            return BadRequest();
        
        }
    }

}