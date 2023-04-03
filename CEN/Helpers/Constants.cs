using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Helpers
{
    public static class Constants
    {
        //DATA BASE
        public static string? Server_name { get; set; }
        public static string? Database_name { get; set; }
        public static string? User_name { get; set; }
        public static string? User_pass { get; set; }
        public static string? Cadena_conexion { get; set; }
        //ENCRIPTACION CLAVES
        public static string? Clave_encriptacion { get; set; }
        //CLOUDINARY
        public static string? Cloud { get; set; }
        public static string? Api_key { get; set; }
        public static string? Api_secret { get; set; }
        public static string? Base_url_cloud { get; set; }
        public static string? Dimensions { get; set; }
        //JWT
        public static string? Key { get; set; }
        public static string? Issuer { get; set; }
        public static string? Audience { get; set; }
        public static string? Subject { get; set; }
        public static double Expire { get; set; }
    }
}
