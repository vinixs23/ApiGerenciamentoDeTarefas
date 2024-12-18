using AutoMapper;
using ApiGerenciamentoDeTarefas.Models;
using ApiGerenciamentoDeTarefas.Dtos;
using ApiGerenciamentoDeTarefas.Repository;
using GerenciadorTarefas.Dtos;

namespace ApiGerenciamentoDeTarefas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TarefaReadDto>> GetAllAsync()
        {
            var tarefas = await _repository.GetAllAsync();
            return _mapper.Map<List<TarefaReadDto>>(tarefas);
        }

        public async Task<TarefaReadDto> GetByIdAsync(int id)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            return _mapper.Map<TarefaReadDto>(tarefa);
        }

        public async Task<TarefaReadDto> CreateAsync(TarefaCreateDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            tarefa.DataCriacao = DateTime.UtcNow.Date;
            tarefa.HoraCriacao = DateTime.UtcNow.TimeOfDay;
            await _repository.AddAsync(tarefa);
            return _mapper.Map<TarefaReadDto>(tarefa);
        }

        public async Task<bool> UpdateAsync(int id, TarefaUpdateDto tarefaDto)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            if (tarefa == null) throw new KeyNotFoundException("Tarefa não encontrada.");

            _mapper.Map(tarefaDto, tarefa);
            tarefa.DataAlteracao = DateTime.UtcNow.Date;
            tarefa.HoraAlteracao = DateTime.UtcNow.TimeOfDay;

            return await _repository.UpdateAsync(tarefa);
        }
        
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
