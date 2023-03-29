using CEN.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Imgs
{
    public static class CloudinayConexion
    {
        public static void Conexion(IFormFile Imagen)
        {
            var cloudinary = new Cloudinary(new Account(Constants.Cloud, Constants.Api_key, Constants.Api_secret));

            using (var stream = Imagen.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(Imagen.FileName, stream),
                    PublicId = Imagen.FileName
                };
                cloudinary.Upload(uploadParams);
            }

            //// Upload
            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription("Nombre", Imagen),
            //    PublicId = "MENSAJE PRUEBA"
            //};

            //var uploadResult = cloudinary.Upload(uploadParams);

            //Transformation
            //cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(100).Height(150).Crop("fill")).BuildUrl("olympic_flag");
            //cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(100).Height(150).Crop("fill")).BuildUrl("olympic_flag");
        }
    }
}
