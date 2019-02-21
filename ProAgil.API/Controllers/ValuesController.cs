using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values

        private List<Evento> _list;
        private readonly DataContext context;

        public ValuesController (DataContext context) {

            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get () 
        {

            try {
                var results = await this.context.Eventos.ToListAsync ();
                return Ok (results);
            } catch (System.Exception ex) {

                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var evento = await this.context.Eventos.FirstOrDefaultAsync (x => x.EventoId == id);
            try {
                return Ok (evento);
            } catch (System.Exception ex) {

                return BadRequest(ex.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}