using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ApiBarras.Controllers
{
    public class CodigoBarrasController : ApiController
    {
        [HttpGet]
        [Route("Barcode")]
        public IHttpActionResult GetImage(string Convenio,string NumeroFactura,long Valor,string FechaLimite)
        {

            var modelo=new Models.CodigoBarras();

            modelo.NumeroConvenio = Convenio;
            modelo.NumeroFactura = NumeroFactura;
            modelo.ValorPagar = Valor;
            modelo.FechaLimite = FechaLimite;

            var stream = modelo.ImagenCodigo;

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentLength = stream.Length;

            return ResponseMessage(response);
        }
        [HttpGet]
        [Route("Barcode")]
        public IHttpActionResult GetImage()
        {

            var modelo = new Models.CodigoBarras();

            modelo.NumeroConvenio = "3000";
            modelo.NumeroFactura = "20";
            modelo.ValorPagar = 50000;
            modelo.FechaLimite = "20190101";

            var stream = modelo.ImagenCodigo;

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentLength = stream.Length;

            return ResponseMessage(response);
        }
    }
}
