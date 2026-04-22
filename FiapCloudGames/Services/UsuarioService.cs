using Core.Entity;
using Core.Entity.Input;
using Core.Repository.Interfaces;
using FiapCloudGames.Core.Tests.Validators;

namespace FiapCloudGames.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioValidator _validator;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
            _validator = new UsuarioValidator();
        }

        public void CriarUsuario(UsuarioInput input)
        {
            if (!_validator.EmailValido(input.Email))
                throw new Exception("Email inválido");

            if (!_validator.SenhaValida(input.Senha))
                throw new Exception("Senha fraca");

            var usuario = new Usuario
            {
                Nome = input.Nome,
                Email = input.Email,
                Senha = input.Senha,
                Situacao = "Ativo"
            };

            _repository.Cadastrar(usuario);
        }
    }
}