using Application.DTO_s;
using Domain.Entities;
using Infra.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IClienteService
    {
        void Criar(ClienteInsertDto cliente);
        IEnumerable<Cliente> BuscarClientes(string nome, string codigo);
        public ClienteResponse BuscarTodosClientes();
    }

    

}
