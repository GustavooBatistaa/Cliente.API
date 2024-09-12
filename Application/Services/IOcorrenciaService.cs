using Application.DTO_s;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOcorrenciaService
    {
        public  Task<IEnumerable<OcorrenciaDto>> GetAllAsync();
        

        public  Task<OcorrenciaDto> GetByIdAsync(int id);
       
        public  Task AddAsync(OcorrenciaDto dto);
       

        public  Task UpdateAsync(OcorrenciaDto dto);
       

        public  Task DeleteAsync(int id);
       
    }
}

