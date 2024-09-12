using Domain.Entities;
using Infra.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> Search(string nome, string codigo)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome) || c.Id.ToString() == codigo)
                 .Include(c => c.Endereco)
                .ToList();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Where(c => c.Id == id)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync();
        }


        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes
                .Include(c => c.Endereco)
                .ToList();
        }
    }

}
