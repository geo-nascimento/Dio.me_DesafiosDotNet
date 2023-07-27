using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorsDeTarefas.Data;
using GerenciadorsDeTarefas.Models;
using GerenciadorsDeTarefas.Repository;
using System.Globalization;

namespace GerenciadorsDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        //Injeção de dependência com a classe TarefasRepository
        private readonly ITarefasRepository _db;

        public TarefasController(ITarefasRepository db)
        {
            _db = db;
        }

        [HttpGet("/ObterTarefas")]
        public IActionResult ObterTarefas()
        {
            var lista = _db.ObterTodas();

            return Ok(lista);
        }

        [HttpGet("/ObterPorId/{id}")]
        public IActionResult ObterPoId(int id)
        {
            var tarefa = _db.ObterTarefa(id);
            if (tarefa is null)
            {
                return NotFound("Tarefa não encontrada");
            }

            return Ok(tarefa);
        }

        [HttpGet("/ObterPorData/{data}")]
        public IActionResult ObterPorData(DateTime data)
        {
            var list = _db.ObterTodas();
            var listData = list.Where(x => x.Data.Date == data.Date).ToList();

            return Ok(listData);
        }

        [HttpGet("/ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var list = _db.ObterTodas();
            var listTitulo = list.Where(x => x.Titulo == titulo);

            return Ok(listTitulo);
        }

        [HttpGet("/ObterPorStatus/{status}")]
        public IActionResult ObterPorStatus(string status)
        {
            var listStatus = _db.ObterTodas().Where(x => x.Status == status).ToList();
            if (listStatus is null)
            {
                return NotFound();
            }
            return Ok(listStatus);
        }

        [HttpPost]
        public IActionResult CriarTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            
            _db.CriarTarefa(tarefa);
            return Ok(tarefa);
        }

        [HttpPut("/AtualizarTarefa/{id}")]
        public IActionResult AtualizarTarefa([FromBody] Tarefa tarefa, int id)
        {
            var atualizar = _db.ObterTarefa(id);

            if (atualizar is null)
            {
                return NotFound("Tarefa não encontrada");
            }
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            atualizar.Titulo = tarefa.Titulo;
            atualizar.Descricao = tarefa.Descricao;
            atualizar.Data = tarefa.Data;
            atualizar.Status = tarefa.Status;

            _db.AtualizarTarefa(atualizar);
            return Ok(atualizar);

        }

        [HttpDelete("/DeletarTarefa/{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            _db.DeletarTarefa(id);
            return Ok();
        }
    }
}
