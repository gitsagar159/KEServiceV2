using KEServiceV2.Models;
using KEServiceV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace KEServiceV2.Controllers
{
    public class PersonController : ApiController
    {

        private APIResponce apiresponce;

        [HttpGet]
        public IHttpActionResult GetPersonData()
        {
            apiresponce = new APIResponce();

            PersonService objPersonService = new PersonService();

            var response = objPersonService.GetPersonList();

            if (response == null)
            {
                apiresponce.StatusCode = (int)HttpStatusCode.BadRequest;
                apiresponce.Data = response;
            }
            else
            {
                apiresponce.StatusCode = (int)HttpStatusCode.OK;
                apiresponce.Data = response;
            }

            //return new JsonResult(apiresponce);
            return Ok(new { results = apiresponce });
        }

        [HttpPost]
        public IHttpActionResult GetPersonById(PersonModel model)
        {
            apiresponce = new APIResponce();
            PersonService objPersonService = new PersonService();

            var response = objPersonService.GetPersonDataById(model.Oid);

            if (response == null)
            {
                apiresponce.StatusCode = (int)HttpStatusCode.BadRequest;
                apiresponce.Data = response;
            }
            else
            {
                apiresponce.StatusCode = (int)HttpStatusCode.OK;
                apiresponce.Data = response;
            }

            //return Ok(response);
            return Ok(new { results = apiresponce });
        }
    }
}
