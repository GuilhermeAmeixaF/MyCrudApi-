using MyCrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyCrudApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context; //AppDbContext (tipo da variavel)  _context (e a variavel)

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }




    // GET: api/Produtos (Listar todos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {

        return await _context.Produtos.ToListAsync();

    }

    // GET: api/Produtos/5 (Buscar um por ID)

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)

    {

        var produto = await _context.Produtos.FindAsync(id);


        if (produto == null)

        {

            return NotFound();

        }


        return produto;
    }


    // PUT: api/Produtos/5 (Atualizar)

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Produto produto)

    {

        if (id != produto.Id)

        {

            return BadRequest();

        }


        _context.Entry(produto).State = EntityState.Modified;


        try

        {

            await _context.SaveChangesAsync();


        }


        catch (DbUpdateConcurrencyException)

        {

            if (!ProdutoExists(id))

            {

                return NotFound();

            }


            else

            {

                throw;

            }

        }


    return NoContent(); // 204 - Sucesso sem conteudo
    }


    // POST: api/Produtos (Criar novo)
    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)

    {

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();


        // RETORNA 201 CREATED COM A LOCALIZACAO DO NOVO RECURSO
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);


    }


    // DELETE: api/Produtos/5 (Excluir)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)

    {

        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)

        {

            return NotFound();

        }


        _context.Produtos.Remove(produto);

        await _context.SaveChangesAsync();


        return NoContent();
    }

    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Id == id);
    }
}
