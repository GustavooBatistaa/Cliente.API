using Application.DTO_s;
using Domain.Entities;
using Infra.Data.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IClienteRepository _clienteRepository;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository, IClienteRepository clienteRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<OcorrenciaDto>> GetAllAsync()
        {
            var ocorrencias = await _ocorrenciaRepository.GetAllAsync();
            return ocorrencias.Select(o => new OcorrenciaDto
            {
                Id = o.Id,
                DataAbertura = o.DataAbertura,
                DataOcorrencia = o.DataOcorrencia,
                Descricao = o.Descricao,
                ResponsavelAberturaId = o.ResponsavelAbertura.Id,
                ResponsavelOcorrenciaId = o.ResponsavelOcorrencia.Id,
                Conclusao = o.Conclusao
            });
        }

        public async Task<OcorrenciaDto> GetByIdAsync(int id)
        {
            var ocorrencia = await _ocorrenciaRepository.GetByIdAsync(id);
            if (ocorrencia == null) return null;

            return new OcorrenciaDto
            {
                Id = ocorrencia.Id,
                DataAbertura = ocorrencia.DataAbertura,
                DataOcorrencia = ocorrencia.DataOcorrencia,
                Descricao = ocorrencia.Descricao,
                ResponsavelAberturaId = ocorrencia.ResponsavelAbertura.Id,
                ResponsavelOcorrenciaId = ocorrencia.ResponsavelOcorrencia.Id,
                Conclusao = ocorrencia.Conclusao
            };
        }

        public async Task AddAsync(OcorrenciaDto dto)
        {
            var responsavelAbertura = await _clienteRepository.GetByIdAsync(dto.ResponsavelAberturaId);
            var responsavelOcorrencia = await _clienteRepository.GetByIdAsync(dto.ResponsavelOcorrenciaId);

            if (responsavelAbertura == null || responsavelOcorrencia == null)
            {
                throw new InvalidOperationException("Um ou mais clientes não foram encontrados.");
            }

            var ocorrencia = new Ocorrencia
            {
                DataAbertura = dto.DataAbertura,
                DataOcorrencia = dto.DataOcorrencia,
                Descricao = dto.Descricao,
                ResponsavelAbertura = responsavelAbertura,
                ResponsavelOcorrencia = responsavelOcorrencia,
                Conclusao = dto.Conclusao
            };

            await _ocorrenciaRepository.AddAsync(ocorrencia);
        }

        public async Task UpdateAsync(OcorrenciaDto dto)
        {
            var ocorrencia = await _ocorrenciaRepository.GetByIdAsync(dto.Id);
            if (ocorrencia == null) return;

            var responsavelAbertura = await _clienteRepository.GetByIdAsync(dto.ResponsavelAberturaId);
            var responsavelOcorrencia = await _clienteRepository.GetByIdAsync(dto.ResponsavelOcorrenciaId);

            if (responsavelAbertura == null || responsavelOcorrencia == null)
            {
                throw new InvalidOperationException("Um ou mais clientes não foram encontrados.");
            }

            ocorrencia.DataAbertura = dto.DataAbertura;
            ocorrencia.DataOcorrencia = dto.DataOcorrencia;
            ocorrencia.Descricao = dto.Descricao;
            ocorrencia.ResponsavelAbertura = responsavelAbertura;
            ocorrencia.ResponsavelOcorrencia = responsavelOcorrencia;
            ocorrencia.Conclusao = dto.Conclusao;

            await _ocorrenciaRepository.UpdateAsync(ocorrencia);
        }

        public async Task DeleteAsync(int id)
        {
            await _ocorrenciaRepository.DeleteAsync(id);
        }
    }
}
