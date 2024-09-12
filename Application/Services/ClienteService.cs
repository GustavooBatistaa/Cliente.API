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

        public void Criar(ClienteInsertDto cliente)
        {
            if (cliente is null)
            {
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
            }

            var clientes = _clienteRepository.GetAll();

            // Verifica se o CPF já está em uso
            if (clientes.Any(c => c.CPF == cliente.CPF))
            {
                throw new InvalidOperationException("Este CPF já está em uso.");
            }

            // Verifica se o Email já está em uso
            if (clientes.Any(c => c.Email == cliente.Email))
            {
                throw new InvalidOperationException("Este Email já está em uso.");
            }

            var clienteModel = new Cliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                CPF = cliente.CPF,
                Endereco = new Endereco
                {
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    Rua = cliente.Endereco.Rua,
                }
            };

            _clienteRepository.Add(clienteModel);
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
