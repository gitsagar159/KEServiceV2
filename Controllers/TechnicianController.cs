using KEServiceV2.Models;
using KEServiceV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace KEServiceV2.Controllers
{
    public class TechnicianController : ApiController
    {
        private APIResponce apiresponce;

        [HttpPost]
        public IHttpActionResult Tech_login(Tech_LoginRQ objTechLoginRQ)
        {
            int success = 1;

            TechnicianService objTechnicianService = new TechnicianService();
            
            var response = objTechnicianService.Tech_login(objTechLoginRQ);

            success = response.user_data.otherdata != null ? 1 : 0;
            
            return Ok(new { success, user_data = response.user_data });
        }

        [HttpPost]
        public IHttpActionResult Techman_JobList(Techman_JobListRQ objTechmanJobListRQ)
        {

            apiresponce = new APIResponce();
            int success = 1;

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Techman_JobList(objTechmanJobListRQ);

            success = response != null ? 1 : 0;
            
            //return new JsonResult(apiresponce);
            return Ok(new { success, records = response });
        }

        [HttpPost]
        public IHttpActionResult Jobdone_Verify(Jobdone_VerifyRQ objJobDoneVerifyRQ)
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.JobDone_Verify(objJobDoneVerifyRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg });
        }

        [HttpPost]
        public IHttpActionResult Ke_Company_List(Company_ListRQ objCompanyListRQ)
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Company_List(objCompanyListRQ);

            return Ok(new { success = response.success, records = response });
        }


        [HttpPost]
        public IHttpActionResult Version()
        {
            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.VersionDetail();

            return Ok(new { success = response.success, success_msg = response.success_msg, records = response.records });
        }


        [HttpPost]
        public IHttpActionResult Job_Start(Job_StartRQ objJobStartRQ)
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Job_Start(objJobStartRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg, records = response.records });
        }

        [HttpPost]
        public IHttpActionResult Technician_Job_Done(Job_DoneRQ objJob_DoneRQ)
        {
            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Technician_Job_Done(objJob_DoneRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg});
        }

        [HttpPost]
        public IHttpActionResult Add_Exis_Productspsr(Add_Exis_ProductRQ objAddExisProductRQ)
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Add_Exis_Productspsr(objAddExisProductRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg});
        }

        [HttpPost]
        public IHttpActionResult Add_Avail_Productspsr(Add_Avail_ProductRQ objAddAvailProductRQ)
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Add_Avail_ProductSprs(objAddAvailProductRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg });
        }

        [HttpPost]
        public IHttpActionResult Main_Service_List()
        {

            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Service_List();

            return Ok(new { success = response.success, data = response.data });
        }

        [HttpPost]
        public IHttpActionResult Exchange_Service_Addprs(Exchange_ServiceRQ objExchangeServiceRQ)
        {
            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Exchange_Service(objExchangeServiceRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg });
        }

        [HttpPost]
        public IHttpActionResult Installation_Img(Installation_ImgRQ objInstallationImgRQ)
        {
            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Installation_Img(objInstallationImgRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg });
        }

        [HttpPost]
        public IHttpActionResult Add_Expense(Add_ExpenseRQ objAddExpenseRQ)
        {
            TechnicianService objTechnicianService = new TechnicianService();

            var response = objTechnicianService.Add_Expense(objAddExpenseRQ);

            return Ok(new { success = response.success, success_msg = response.success_msg });
        }


    }
}
