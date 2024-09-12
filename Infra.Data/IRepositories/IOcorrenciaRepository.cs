using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.IRepositories
{
    public interface IOcorrenciaRepository
    {
        public  Task<IEnumerable<Ocorrencia>> GetAllAsync();


        public  Task<Ocorrencia> GetByIdAsync(int id);


        public  Task AddAsync(Ocorrencia ocorrencia);


        public  Task UpdateAsync(Ocorrencia ocorrencia);


        public  Task DeleteAsync(int id);
    }
}
