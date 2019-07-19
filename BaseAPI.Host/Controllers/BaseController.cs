using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BaseAPI.BusinessServices.Interface;

namespace BaseAPI.Host.Controllers
{
    [RoutePrefix("API/Base")]
    public class BaseController : ApiController
    {
        private readonly IBaseService _baseService;

        public BaseController(IBaseService baseService) {

            _baseService = baseService;
        }

        [Route("GetBaseTest")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetBaseTest() {
            var result = _baseService.GetBaseTestResult();
            return Ok(result);
        }

    }
}
