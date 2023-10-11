using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;

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

        public Usuario Update(ModificarUsuarioDTO usuarioDTO)
        {
            var usuario = _glassCoreContext.Usuarios.SingleOrDefault(u => u.IdUsuario == usuarioDTO.IdUsuario);

            if (usuario == null)
            {
                throw new InvalidOperationException("No existe");
            }
            if(usuarioDTO.NombreUsuario != null)
            {
                usuario.NombreUsuario = usuarioDTO.NombreUsuario;
            }
            if(usuarioDTO.ApellidoUsuario != null)
            {
                usuario.ApellidoUsuario = usuarioDTO.ApellidoUsuario;
            }
            if(usuarioDTO.Email != null)
            {
                usuario.Email = usuarioDTO.Email;
            }
            if(usuarioDTO.Estado != null)
            {
                usuario.Estado = usuarioDTO.Estado;
            }


            _glassCoreContext.Usuarios.Update(usuario);
            _glassCoreContext.SaveChanges();
            return usuario;
        }
    }
}
