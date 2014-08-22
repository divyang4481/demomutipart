using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DivyangDemo.Models;
using Newtonsoft.Json;

namespace DivyangDemo.Controllers
{
    /// <summary>
    /// /http://shazwazza.com/post/uploading-files-and-json-data-in-the-same-request-with-angular-js/
    /// </summary>
    public class DemoController : ApiController
    {
        // GET api/demo
        public async Task<string> Upload()
        {

            var responseResultObject = new UploadResult
            {
                IsSuccess = false,
                Message = "Unknown"

            };

            //try
            //{
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var root = HttpContext.Current.Server.MapPath("~/App_Data/Temp/FileUploads");
                Directory.CreateDirectory(root);
                var provider = new MultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                if (result.FormData["model"] == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                var model = result.FormData["model"];
                //TODO: Do something with the json model which is currently a string



                //get the files
                foreach (var file in result.FileData)
                {
                    //TODO: Do something with each uploaded file
                }

            //}
            //catch (Exception exception)
            //{

            //    responseResultObject.Message = exception.Message;
            //}




                var resultfial = JsonConvert.SerializeObject(responseResultObject);
                return resultfial;

          //return  Request.CreateResponse(HttpStatusCode.OK, "Done");
          //return      Request.CreateResponse<UploadResult>(HttpStatusCode.OK, responseResultObject);
            
        }
    }
}
