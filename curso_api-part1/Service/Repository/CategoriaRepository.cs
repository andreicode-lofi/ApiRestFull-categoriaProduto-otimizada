using curso_api_part1.Data;
using curso_api_part1.Model;
using Microsoft.EntityFrameworkCore;

namespace curso_api_part1.Service.Repository;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoriaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Categoria>> GetAll()
    {                                                 //Take para filtrar a consulta e retornar um nomero expecifico
        var categorias = await _appDbContext.Categorias.Take(10).AsTracking().ToListAsync();
                                                                //.AsTracking() vamos usar para otimizar a consulta
                                                                //Só posso usar em consulta get, 
                                                                //Ele sempre retornar uma nova consulta, deixando o armaenamento cache limpo

        return categorias;

    }

    public async Task<IEnumerable<Categoria>> GetAllProdutoCategoria()
    {
        var categoria = await _appDbContext.Categorias
            .Include(p => p.Produtos)
            .ToListAsync();

        return categoria;
    }

    public async Task<Categoria> GetById(int id)
    {
        var categorias = _appDbContext.Categorias.FirstOrDefault(c => c.CategoriaId == id);

        if(categorias == null)
        {
            return null;
        }

        return categorias;
    }


    public async Task<Categoria> Create(Categoria categoria)
    {
        _appDbContext.Categorias.Add(categoria);
        await _appDbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> Update(Categoria categoria)
    {
        _appDbContext.Entry(categoria).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> Delete(int id)
    {
        var categoria = await GetById(id);

        _appDbContext.Categorias.Remove(categoria);
        await _appDbContext.SaveChangesAsync();
        return categoria;

    }
}

    

   

   

 
