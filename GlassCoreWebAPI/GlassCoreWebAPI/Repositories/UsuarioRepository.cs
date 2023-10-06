using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;

namespace GlassCoreWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GlassCoreContext _glassCoreContext;

        public UsuarioRepository(GlassCoreContext glassCoreContext)
        {
            _glassCoreContext = glassCoreContext;
        }
    
        public int CheckUserID()
        {
            var lastUser = _glassCoreContext.Usuarios.OrderByDescending(e => e.IdUsuario).FirstOrDefault();

            if(lastUser != null)
            {
                return lastUser.IdUsuario;
            }
            return 0;
        }
    }
}
