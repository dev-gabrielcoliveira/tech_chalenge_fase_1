using Core.Entity;
using Core.Entity.Input;
using Core.Repository.Interfaces;
using FiapCloudGames.Services;
using Infrastructure.Repository.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController: ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, UsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_usuarioRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Post([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                _usuarioService.CriarUsuario(usuarioInput);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { erro = e.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        public IActionResult Update([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                var usuario = _usuarioRepository.ObterPorId(usuarioInput.Id);

                usuario.Nome = usuarioInput.Nome;
                usuario.Senha = usuarioInput.Senha;

                _usuarioRepository.Alterar(usuario);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {

                var usuario = _usuarioRepository.ObterPorId(id);

                // Exclusão lógica só altera a situação para removido
                usuario.Situacao = "Removido";

                _usuarioRepository.Alterar(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
