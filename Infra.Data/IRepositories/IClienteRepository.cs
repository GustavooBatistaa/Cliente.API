using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.IRepositories
{
    public interface IClienteRepository
    {
        public void Add(Cliente cliente);
        public IEnumerable<Cliente> Search(string nome, string codigo);
        public IEnumerable<Cliente> GetAll();
        public  Task<Cliente> GetByIdAsync(int id);
    }
}
