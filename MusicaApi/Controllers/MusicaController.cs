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

        [HttpGet]
        public IActionResult Get()
        {
            var canciones = cancionesRepository.GetAll();
            return Ok(canciones);
        }


        [HttpPost]
        public IActionResult Post(Canciones c)
        {
            return Ok();
        }

    }
}
