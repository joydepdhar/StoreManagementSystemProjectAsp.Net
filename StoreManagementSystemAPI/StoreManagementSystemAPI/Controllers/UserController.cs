using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagementSystemAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("API/AddUser")]
        public HttpResponseMessage AddUser(UserDTO C)
        {
            try
            {
                var data = UserService.AddUser(C);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Data" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("API/ViewAllUser")]
        public HttpResponseMessage ViewUser()
        {
            try
            {
                var data = UserService.ViewUser();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("API/ViewAllUser/{Id}")]
        public HttpResponseMessage ViewUser(int id)
        {
            try
            {
                var data = UserService.ViewUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("API/User/delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var res = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
