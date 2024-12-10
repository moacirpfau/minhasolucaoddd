using Microsoft.AspNetCore.Mvc;
using MinhaSolucaoDDD.Application.Services;
using MinhaSolucaoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaSolucaoDDD.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _produtoService.GetAllProdutosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Produto> Get(Guid id)
        {
            return await _produtoService.GetProdutoByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            await _produtoService.AddProdutoAsync(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            await _produtoService.UpdateProdutoAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _produtoService.DeleteProdutoAsync(id);
            return NoContent();
        }
    }
}
