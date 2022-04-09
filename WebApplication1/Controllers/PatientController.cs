using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class PatientController : ApiController
    {
        DBController dBController = new DBController();


        public IHttpActionResult GetPatient(int ID)
        {
            dBController.GetPatients();
            patient p = null;
            foreach (patient x in GeneralController.patients)
            {
                if (ID == x.Id)
                {
                    p = x;
                    break;
                }
            }
            if (p is null)
            {
                return Conflict();
            }
            else
            {
                return Ok(p);
            }
            
        }

        public IHttpActionResult Post([FromBody] patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                if (GeneralController.patients.Any(x => x.nationalID == patient.nationalID))
                {
                    return Conflict();
                }
                else
                {
                    GeneralController.patients.Add(patient);
                    GeneralController.done();
                    return Ok(patient);
                }
            }
            return BadRequest("not valid");
        }
        [Route("api/patient/records")]
        public IHttpActionResult Post([FromBody] record record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                GeneralController.records.Add(record);
                GeneralController.doneRecords();
                return Ok(record);
                
            }
            return BadRequest("not valid");
        }
    }
}
