using MinhaSolucaoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaSolucaoDDD.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(Guid id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Guid id);
    }
}
