using Core.Entity;
using Core.Repository.Interfaces;

namespace Infrastructure.Repository.Class
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
