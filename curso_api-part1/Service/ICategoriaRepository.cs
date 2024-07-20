using curso_api_part1.Model;

namespace curso_api_part1.Service;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAll();
    Task<IEnumerable<Categoria>> GetAllProdutoCategoria();
    Task<Categoria> GetById(int id);
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria> Update(Categoria categoria);
    Task <Categoria> Delete(int id);
}
