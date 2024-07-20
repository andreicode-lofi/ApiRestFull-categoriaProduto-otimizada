using curso_api_part1.Data;
using curso_api_part1.Model;
using Microsoft.EntityFrameworkCore;

namespace curso_api_part1.Service.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _appDbContext;

    public ProdutoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task <IEnumerable<Produtos>> GetAll()
    {                                             //Take para filtrar a consulta e retornar um nomero expecifico
        var produtos = await _appDbContext.Produtos.Take(10).AsTracking().ToListAsync();
                                               //.AsTracking() vamos usar para otimizar a consulta
                                               //Só posso usar em consulta get, 
                                               //Ele sempre retornar uma nova consulta, deixando o armaenamento cache limpo
        if (produtos is null)
        {
            return null;
        }

        return produtos;
    }

    public async Task<Produtos> GetById(int id)
    {
        var produto =  _appDbContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if(produto is null)
        {
            return null;
        }

        return produto;
    }

    public async Task<Produtos> Create(Produtos produto)
    {
        _appDbContext.Produtos.Add(produto);
        await _appDbContext.SaveChangesAsync();

        return produto;
       
    }

    public async Task<Produtos> Update(Produtos produtos)
    {
        //var produto = await GetById(produtos.ProdutoId);

        //Entry(produto) diz ao Entity Framework que você quer trabalhar com o estado desse objeto.
        //State = EntityState.Modified: Marca o objeto como "modificado", 
        //indicando que ele precisa ser atualizado no banco de dados quando você chamar SaveChanges().
        _appDbContext.Entry(produtos).State = EntityState.Modified;

        await _appDbContext.SaveChangesAsync();

        return produtos;
    }

    public async Task<Produtos> Delete(int id)
    {
        var produto = await GetById(id);

        _appDbContext.Produtos.Remove(produto);
                    
        await _appDbContext.SaveChangesAsync();

        return produto;
    }
}
