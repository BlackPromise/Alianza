using System.Collections.Generic;

namespace Prueba.Servicios
{
    public class Client : IClient
    {
        public List<Modelos.M_Clients> ObtenerTodos()
        {
            return new Logica.L_Clients().ObtenerTodos();
        }

        public Modelos.M_Clients ObtenerUno(string SharedKey)
        {
            return new Logica.L_Clients().ObtenerUno(SharedKey);
        }

        public bool Guardar(Modelos.M_Clients Client)
        {
            return new Logica.L_Clients().Guardar(Client);
        }

        public bool Eliminar(string SharedKey)
        {
            return new Logica.L_Clients().Eliminar(SharedKey);
        }

        public bool Actualizar(Modelos.M_Clients Client)
        {
            return new Logica.L_Clients().Actualizar(Client);
        }
    }
}
