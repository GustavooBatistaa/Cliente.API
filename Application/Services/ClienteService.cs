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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Criar(Cliente cliente)
        {
            if (cliente is null)
            {
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
            }


            _clienteRepository.Add(cliente);
        }

        public IEnumerable<Cliente> BuscarClientes(string nome, string codigo)
        {
            var dados = _clienteRepository.Search(nome, codigo);

            if (dados is null || !dados.Any())
            {
                throw new InvalidOperationException("Nenhum cliente encontrado com os critérios fornecidos.");
            }

            return dados;
        }
        public ClienteResponse BuscarTodosClientes()
        {
            var dados = _clienteRepository.GetAll();

           
            if (dados == null || !dados.Any())
            {
                return new ClienteResponse
                {
                    Message = "Nenhum cliente encontrado com os critérios fornecidos.",
                    Data = new List<Cliente>()
                };
            }

           
            return new ClienteResponse
            {
                Message = "Clientes encontrados com sucesso.",
                Data = dados
            };
        }

    }
}
