using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Helpers
{
    public static class Constants
    {
        public const string JSON_FILTER = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

        internal static string[] OPCIONES_REGISTRO = 
        {
            "Alumno",
            "Profesor",
        };


        public const string BASE_URL = "https://localhost:8081/api/";
        public const string ALUMNO_PATH = "Alumno/";
        public const string PROFESOR_PATH = "Profesor/";

        public const string DICATADOR_URL = "Dicatador/";
        public const string LOGIN_PATH = "users/login";
        public const string REGISTER_PATH = "users/register";

    }
}
