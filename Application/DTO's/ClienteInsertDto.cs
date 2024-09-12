using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class ClienteInsertDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoDto Endereco { get; set; }
    }


    public class EnderecoDto
    {

        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
