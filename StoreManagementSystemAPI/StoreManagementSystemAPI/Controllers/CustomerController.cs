using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagementSystemAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("API/ViewProduct")]
        public HttpResponseMessage ViewProduct()
        {
            try
            {
                var data = ProductService.ViewProduct();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("API/ViewProduct/{Id}")]
        public HttpResponseMessage ViewProduct(int Id)
        {
            try
            {
                var data = ProductService.ViewProduct(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
