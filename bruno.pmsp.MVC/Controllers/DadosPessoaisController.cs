using System;
using System.Net;
using bruno.pmsp.domain.Contracts;
using bruno.pmsp.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace bruno.pmsp.MVC.Controllers
{
    public class DadosPessoaisController : Controller
    {
        private IBaseRepository<Servidor> _servidorRepository;
        private IBaseRepository<Endereco> _enderecoRepository;

        public DadosPessoaisController(IBaseRepository<Servidor> servidorRepository, IBaseRepository<Endereco> enderecoRepository)
        {
            _servidorRepository = servidorRepository;
            _enderecoRepository = enderecoRepository;
        }
        
        [HttpGet]
        public IActionResult Index(int Id)
        {
            var dados = _servidorRepository.BuscarPorId(Id, new string[]{"Telefones", "Endereco", "Vinculos"});
            return View(dados);
        }

        [HttpPost]
        public IActionResult Index([FromBody] Servidor servidor)
        {
            if(servidor == null) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(JsonConvert.SerializeObject(new {message = "Erro ao atualizar dados, O servidor não existe na base de dados."}));
            }
                
            try 
            {
                servidor.AtualizadoEm = DateTime.Now;
                servidor.QtdAtualizacoes = servidor.QtdAtualizacoes + 1;
                servidor.AtualizadoPor = servidor.NomeCompleto;

                servidor.Telefones.AtualizadoEm = DateTime.Now; 
                servidor.Telefones.QtdAtualizacoes = servidor.Telefones.QtdAtualizacoes + 1;
                servidor.Telefones.AtualizadoPor = servidor.NomeCompleto;

                _servidorRepository.Atualizar(servidor);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(JsonConvert.SerializeObject(new {message ="Dados Atualizados Com sucesso."}));
            } 
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(JsonConvert.SerializeObject(new {message ="Erro ao atualizar. " + ex.Message}));
            }
            
        }   
    }
}