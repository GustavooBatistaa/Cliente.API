using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class ClienteResponse
    {
        public string Message { get; set; }
        public IEnumerable<Cliente> Data { get; set; }
    }

}
