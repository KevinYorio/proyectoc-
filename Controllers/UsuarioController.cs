using SistemaGestionBusiness;
using SistemaGestionEntities.models;
using System.Collections.Generic;

namespace Sistemadegestion.Controllers
{
    public static class UsuarioController
    {
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioBusiness.ObtenerUsuario(id);
        }

        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioBusiness.CrearUsuario(usuario);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioBusiness.ListarUsuarios();
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioBusiness.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(int id)
        {
            UsuarioBusiness.EliminarUsuario(id);
        }
    }
}
