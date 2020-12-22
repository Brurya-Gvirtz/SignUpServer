using BarberShop.DAL;
using SignUpProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignUpProject.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticaionController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage SignUpCustomer([FromBody]User data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (UserRepository.IsUserExists(data.Email))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "user already exist");
            User user = UserRepository.AddUser(data);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}