using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario();
            usuario.usuario = "pueba";
            usuario.password = "pueba";

            //usamos un try y catch 
            try
            {
                AdminSesion.Inicio(usuario);

                //accedemos a el manejador de sesion
                AdminSesion u = AdminSesion.GetInstance;
                //salida de secion 
                AdminSesion.Fin();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

}
