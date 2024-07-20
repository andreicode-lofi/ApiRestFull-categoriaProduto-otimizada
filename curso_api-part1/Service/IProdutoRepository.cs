﻿using curso_api_part1.Model;

namespace curso_api_part1.Service;

public interface IProdutoRepository
{
    Task <IEnumerable<Produtos>>GetAll();
    Task<Produtos> GetById(int id);
    Task<Produtos> Create(Produtos produto);
    Task<Produtos> Update(Produtos produtos);
    Task<Produtos> Delete(int id);
}
