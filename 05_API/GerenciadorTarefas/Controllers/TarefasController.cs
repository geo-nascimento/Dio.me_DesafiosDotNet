using AutoMapper;
using GerenciadorTarefas.Enums;
using GerenciadorTarefas.Models;
using GerenciadorTarefas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controller;
[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefasRepositoy _db;
    private readonly IMapper _mapper;

    public TarefasController(ITarefasRepositoy db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet("ObterTodos")]
    public async Task<IActionResult> ObterTarefas()
    {
        var tarefas = await _db.GetAllAsync();
        var tarefasResult = _mapper.Map<IEnumerable<TarefaDTO>>(tarefas);

        if (!tarefasResult.Any())
        {
            return NotFound("Não Foram encontradas tarefas registradas");
        }

        return Ok(tarefasResult);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var tarefa = await _db.GetTarefaByIdAsync(id);
        var tarefaResult = _mapper.Map<TarefaDTO>(tarefa);

        if (tarefaResult is null)
        {
            return NotFound("Tarefa não encontrada");
        }

        return Ok(tarefaResult);
    }

    [HttpGet("ObterPorTitulo/{titulo}")]
    public async Task<IActionResult> ObterTarefaPorTitulo(string titulo)
    {
        var tarefa = await _db.GetTarefaByTitleAsync(titulo);
        var tarefaResult = _mapper.Map<TarefaDTO>(tarefa);

        if (tarefaResult is null)
        {
            return NotFound("Tarefa não encontrada");
        }

        return Ok(tarefaResult);
    }

    [HttpGet("ObterPorStatus/{status}")]
    public async Task<IActionResult> ObterTarefaPorStatus(string status)
    {
        try
        {
            var statusEnum = (Status)Enum.Parse(typeof(Status), status);

            var tarefas = await _db.GetTarefaByStatusAsync(statusEnum);
            var tarefaResult = _mapper.Map<IEnumerable<TarefaDTO>>(tarefas);

            if (!tarefaResult.Any())
            {
                return NotFound("Tarefa não encontrada");
            }

            return Ok(tarefaResult);

        }
        catch (ArgumentException)
        {
            return BadRequest("Parâmetro de entrada inválido");
        }
    }

    [HttpGet("ObterPorData/{data}")]
    public async Task<IActionResult> ObterTarefaPorData(string data)
    {
        var date = DateTime.Parse(data);

        var tarefa = await _db.GetTarefaByDateAsync(date);

        if (tarefa is null)
        {
            return NotFound();
        }

        var tarefaDto = _mapper.Map<TarefaDTO>(tarefa);

        return Ok(tarefaDto);
    }

    [HttpPost]
    public IActionResult CriarTarefa(TarefaDTO tarefaDto)
    {
        try
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            _db.PostTarefa(tarefa);

            var created = _mapper.Map<Tarefa>(tarefa);

            return Created($"tarefas/{created.TarefaId}", created);
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
        catch (ArgumentOutOfRangeException d)
        {
            return BadRequest(d.Message);
        }

    }

    [HttpPut("Atualizar/{id:int}")]
    public IActionResult AtualizarTarefa(int id, TarefaDTO tarefaDto)
    {
        var tarefa = _db.GetTarefaById(id);

        if (tarefa is null)
        {
            return NotFound();
        }

        _mapper.Map(tarefaDto, tarefa);
        _db.PutTarefa(tarefa);

        return Created($"tarefas/{tarefaDto.TarefaId}", tarefaDto);
    }

    [HttpDelete("{id:int}")]
    public IActionResult RemoverTarefa(int id)
    {
        var tarefa = _db.GetTarefaById(id);
        if (tarefa is null)
        {
            return NotFound();
        }

        _db.DeleteTarefa(tarefa);

        return Ok();
    }
}
