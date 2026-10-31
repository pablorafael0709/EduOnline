using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ApiServices _apiServices;

        // Construtor
        public ApiController()
        {
            // Instância simples para estudo (sem injeção de dependência complexa por enquanto)
            _apiServices = new ApiServices();
        }

        // GET: api/api
        [HttpGet]
        public ActionResult<List<ApiModels>> GetAll()
        {
            var items = _apiServices.GetAll();
            return Ok(items);
        }

        // GET: api/api/1
        [HttpGet("{id}")]
        public ActionResult<ApiModels> GetById(int id)
        {
            var item = _apiServices.GetById(id);
            if (item == null)
            {
                return NotFound(new { message = "Item não encontrado." });
            }
            return Ok(item);
        }

        // POST: api/api
        [HttpPost]
        public ActionResult<ApiModels> Create([FromBody] ApiModels newItem)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            var createdItem = _apiServices.Create(newItem);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/api/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ApiModels updatedItem)
        {
            var success = _apiServices.Update(id, updatedItem);
            if (!success)
            {
                return NotFound(new { message = "Item não encontrado para atualização." });
            }

            return NoContent();
        }

        // DELETE: api/api/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _apiServices.Delete(id);
            if (!success)
            {
                return NotFound(new { message = "Item não encontrado para remoção." });
            }

            return NoContent();
        }
    }
}