using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;

namespace GlassCoreWebAPI.Interface
{
    public interface IUsuarioRepository
    {
        int CheckUserID();

        Usuario Update(ModificarUsuarioDTO modificarUsuarioDTO);
    }
}
