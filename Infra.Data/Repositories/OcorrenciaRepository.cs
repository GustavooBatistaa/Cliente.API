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
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public OcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllAsync()
        {
            return await _context.Ocorrencias.Include(o => o.ResponsavelAbertura)
                                             .Include(o => o.ResponsavelOcorrencia)
                                             .ToListAsync();
        }

        public async Task<Ocorrencia> GetByIdAsync(int id)
        {
            return await _context.Ocorrencias.Include(o => o.ResponsavelAbertura)
                                             .Include(o => o.ResponsavelOcorrencia)
                                             .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Update(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ocorrencia = await GetByIdAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencias.Remove(ocorrencia);
                await _context.SaveChangesAsync();
            }
        }
    }

}
