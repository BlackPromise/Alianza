using System.Collections.Generic;
using System.ServiceModel;

namespace Prueba.Servicios
{
    [ServiceContract]
    public interface IClient
    {

        [OperationContract]
        List<Modelos.M_Clients> ObtenerTodos();

        [OperationContract]
        Modelos.M_Clients ObtenerUno(string SharedKey);

        [OperationContract]
        bool Guardar(Modelos.M_Clients Client);

        [OperationContract]
        bool Eliminar(string SharedKey);

        [OperationContract]
        bool Actualizar(Modelos.M_Clients Client);
    }

}
