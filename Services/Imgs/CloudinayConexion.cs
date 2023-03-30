using CEN.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Imgs
{
    public static class CloudinayConexion
    {
        public static int SubirArchivo(IFormFile Imagen, string Nombre)
        {
            int respuesta = 0;
            var cloudinary = new Cloudinary(new Account(Constants.Cloud, Constants.Api_key, Constants.Api_secret));
            using (var stream = Imagen.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(Imagen.FileName, stream),
                    PublicId = Nombre
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    respuesta = 1;
                }
            }
            return respuesta;
        }
        public static int EliminarArchivo(string nombreImg)
        {
            int respuesta = 0;
            Account account = new Account(Constants.Cloud, Constants.Api_key, Constants.Api_secret);
            Cloudinary cloudinary = new Cloudinary(account);
            var destroyParams = new DeletionParams(nombreImg);
            DeletionResult result = cloudinary.Destroy(destroyParams);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                respuesta = 1;
            }
            return respuesta;
        }
    }
}
