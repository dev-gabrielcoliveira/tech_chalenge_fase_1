using Core.Entity;
using FiapCloudGames.Core.Tests.Validators;
using TechTalk.SpecFlow;

namespace FiapCloudGames.BDD.Tests.Steps
{
    [Binding]
    public class UsuarioSteps
    {
        private Usuario _usuario;
        private Boolean _resultado;
        private readonly UsuarioValidator _validator = new UsuarioValidator();

        [Given(@"que eu insiro um usuário com email inválido")]
        public void DadoEmailInvalido()
        {
            _usuario = new Usuario { Nome = "João", Email = "emailinvalido", Senha = "Senha@123", Situacao = "Ativo" };
        }

        [Given(@"que eu insiro um usuário com senha inválida")]
        public void DadoSenhaInvalida()
        {
            _usuario = new Usuario { Nome = "João", Email = "joao@email.com", Senha = "senhaFraca", Situacao = "Ativo" };
        }

        [When(@"eu realizo o cadastro")]
        public void QuandoCadastro()
        {
            // Valida email e senha com as regras do Core
            _resultado = _validator.EmailValido(_usuario.Email) &&
                         _validator.SenhaValida(_usuario.Senha);
        }

        [Then(@"o sistema deve rejeitar o usuário")]
        public void EntaoRejeitaUsuario()
        {
            Assert.False(_resultado);
        }

        [Given(@"que eu insiro um objeto usuário com dados válidos")]
        public void DadoUsuarioValido()
        {
            _usuario = new Usuario{Nome = "João", Email = "joao@email.com", Senha = "Senha@123", Situacao = "Ativo" };
        }

        [Then(@"o sistema deve aceitar o usuário")]
        public void EntaoAceitaUsuario()
        {
            Assert.True(_resultado);
        }


    }
}
