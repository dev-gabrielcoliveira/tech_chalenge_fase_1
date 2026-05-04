using Core.Entity;
using Core.Entity.Input;
using Core.Repository.Interfaces;
using FiapCloudGames.Services;
using Infrastructure.Repository.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{

    /// <summary>
    /// Responsável por gerenciar os usuários da plataforma.
    /// </summary>
    /// <remarks>
    /// Permite criar, atualizar, remover e autenticar usuários.
    /// </remarks>
    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController: ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, UsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _logger = logger;
        }

        /// <summary>
        /// Busca todos usuários.
        /// </summary>
        /// <returns>Listagem de todos usuários ativo do sistema.</returns>
        /// <response code="200">Lista de usuários obtida com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpGet]
        [Authorize(Policy = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioService.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Buscando usuário específico.
        /// </summary>
        /// <returns>Dados de um usuário específico.</returns>
        /// <response code="200">Dados do usuário obtido com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("{id:int}")]
        [Authorize(Policy = "AdministradorOuUsuario")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var usuario = _usuarioService.ObterPorId(id);

                if(usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="request">Dados do usuário a ser criado.</param>
        /// <returns>Usuário criado.</returns>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        public IActionResult Post([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                _usuarioService.CriarUsuario(usuarioInput);
                _logger.LogInformation("Usuário {Email} foi criado", usuarioInput.Email);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { erro = e.Message });
            }
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="request">Novos dados do usuário.</param>
        /// <returns>Usuário atualizado.</returns>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpPut]
        [Authorize(Policy = "Administrador")]
        public IActionResult Update([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                var usuario = _usuarioRepository.ObterPorId(usuarioInput.Id);

                usuario.Nome = usuarioInput.Nome;
                usuario.Senha = usuarioInput.Senha;

                _usuarioRepository.Alterar(usuario);
                _logger.LogInformation("Usuário {Email} foi alterado", usuarioInput.Email);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        /// <summary>
        /// Remove um usuário do sistema.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>Confirmação da remoção.</returns>
        /// <response code="200">Usuário removido com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpPatch("{id:int}")]
        [Authorize(Policy = "Administrador")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {

                var usuario = _usuarioService.ObterPorId(id);

                // Se o usuário for null já está Removido então não tem porque remover de novo.
                if (usuario == null)
                    return NotFound();

                // Exclusão lógica só altera a situação para removido
                usuario.Situacao = "Removido";
                _usuarioRepository.Alterar(usuario);
                _logger.LogInformation("Usuário {Email} foi removido", usuario.Email);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
