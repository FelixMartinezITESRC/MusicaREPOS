using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicaApi.Data;
using MusicaApi.Models;
using MusicaApi.Repositories;

namespace MusicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly Sistem21MusicaContext context;
        private readonly Repository<Canciones> cancionesRepository;
        public MusicaController(Sistem21MusicaContext context)
        {
            this.context = context;
            cancionesRepository = new Repository<Canciones>(context);
        }

        [HttpGet("buscar")]
        public IActionResult Get()
        {
            var canciones = cancionesRepository.GetAll();
            return Ok(canciones);
        }

        [HttpPost("insertar")]
        public IActionResult Post(Canciones c)
        {
            if (c == null)
            {
                return BadRequest("La canción.");
            }

            if (string.IsNullOrWhiteSpace(c.Autor))
            {
                return BadRequest("Especifíque el autor.");
            }

            if (string.IsNullOrWhiteSpace(c.Titulo))
            {
                return BadRequest("Especifíque el titulo.");
            }

            if (string.IsNullOrWhiteSpace(c.Duracion))
            {
                return BadRequest("Especifíque la duración.");
            }

            if (cancionesRepository.GetAll().Any(x => x.Titulo == c.Titulo && x.Autor == c.Autor))
            {
                return BadRequest("Esa canción ya existe.");
            }

            cancionesRepository.Insert(c);
            return Ok("Insertado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(Canciones c)
        {
            Canciones? canciones = cancionesRepository.Get(c.Id);

            if (canciones == null)
            {
                NotFound("No se encontro la canción");
            }
            if (string.IsNullOrWhiteSpace(c.Autor))
            {
                return BadRequest("Especifíque el autor.");
            }

            if (string.IsNullOrWhiteSpace(c.Titulo))
            {
                return BadRequest("Especifíque el titulo.");
            }

            if (string.IsNullOrWhiteSpace(c.Duracion))
            {
                return BadRequest("Especifíque la duración.");
            }

            if (cancionesRepository.GetAll().Any(x => x.Titulo == c.Titulo && x.Autor == c.Autor) && c.Id != 0)
            {
                return BadRequest("Esa canción ya existe.");
            }

            if (canciones != null)
            {
                canciones.Titulo = c.Titulo;
                canciones.Autor = c.Autor;
                canciones.Duracion = c.Duracion;
                cancionesRepository.Update(canciones);
            }
            return Ok("Actualizado correctamente.");
        }

        [HttpDelete("eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var cancion = cancionesRepository.Get(id);
            if (cancion == null)
            {
                return NotFound("No se encontro la canción");
            }

            cancionesRepository.Delete(cancion);
            return Ok();

        }
    }
}
