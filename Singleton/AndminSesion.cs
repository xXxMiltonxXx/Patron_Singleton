using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //clase que administra la secion
    public class AdminSesion

    {
        //variable estatica 
        private static AdminSesion _sesion;
        //ingresamos un atributo de tipo usuario
        //permite vincular la secion con el usuario
        //cada vez que acceda a la sesion se accede a estas instancias públicas
        public Usuario persona { get; set; }
        //definimos la fecha de la sesion
        public DateTime FechaIni { get; set; }


        //Operacion estatica 
        //permite acceder a la instancia
        public static AdminSesion GetInstance
        {
            //que es lo que queremos que susceda
            get
            {
                if (_sesion == null) throw new Exception("Sesion no iniciada");
                return _sesion;
            }


        }
        //contorl de bloque para entorno multilinea
        private static object _bloqueo = new object();

        //funciones
        //punto de acceso
        public static void Inicio(Usuario usuari)
        {
            //bloquea un fragmento de codigo
            //para que se ejecite completo
            lock (_bloqueo)
            {
                //revisa si la sesion es nula

                if (_sesion == null)
                {
                    //si es nula crea otra sesion
                    _sesion = new AdminSesion();
                    _sesion.persona = usuari;
                    _sesion.FechaIni = DateTime.Now;
                }
                else
                {
                    //sino
                    throw new Exception("sesion ya iniciada");
                }

            }


        }
        public static void Fin()
        {
            lock (_bloqueo)
            {
                //si la seson no es null
                if (_sesion != null)
                {
                    //la elimina 
                    _sesion = null;
                }
                //Sino da error
                else
                {
                    throw new Exception("No ha inicadio sesion");

                }

            }


        }

        //Constructor 
        private AdminSesion()
        {

        }
    }
}




    
