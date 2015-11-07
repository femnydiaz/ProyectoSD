using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        ///     Método para verificar el login de un usuario
        /// </summary>
        /// <param name="user">Usuario a validar</param>
        /// <param name="pass">Contraseña del usuario a validar</param>
        /// <returns>True si el login es válido, False si no lo es</returns>
        public bool login(string user, string pass)
        {
            PedidosEntities pe = new PedidosEntities();
            var usLog = (from reg in pe.usuario
                         where reg.idUsuario == user && reg.password == pass
                         select reg).FirstOrDefault();
            if (usLog != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
