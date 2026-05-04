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


        public Usuario? ObterPorEmail(string email)
        {

            // Como existe o campo situação é necessário buscar por e-mail e pela situação Ativo.

            var usuario = _repository.ObterTodos()
                .Where(ent => ent.Situacao == "Ativo" && ent.Email == email)
                .FirstOrDefault();

            return usuario;
        }

        public Usuario? ObterPorId(int id)
        {

            // Como existe o campo situação é necessário buscar por id e pela situação Ativo.

            var usuario = _repository.ObterTodos()
                .Where(ent => ent.Situacao == "Ativo" && ent.Id == id)
                .FirstOrDefault();

            return usuario;
        }

        public List<Usuario> ObterTodos()
        {
            var listausuario = _repository.ObterTodos()
                .Where(ent => ent.Situacao == "Ativo")
                .ToList();

            return listausuario;
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