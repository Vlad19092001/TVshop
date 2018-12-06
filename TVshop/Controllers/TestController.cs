using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TVshop.Controllers
{
    public class TestController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string Id = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write(Id);
        }
    }
}