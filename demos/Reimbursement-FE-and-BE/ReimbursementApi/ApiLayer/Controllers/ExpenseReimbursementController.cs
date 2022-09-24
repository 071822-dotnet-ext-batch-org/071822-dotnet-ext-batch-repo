using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReimbursementController : ControllerBase
    {
        private readonly IReimbursementBusinessLayer _businessLayer;
        public ExpenseReimbursementController(IReimbursementBusinessLayer rbl)
        {
            this._businessLayer = rbl;
        }

        /// <summary>
        /// Accepts a EmployeeRegisterDto as an argument and passes the object to the Business Layer
        /// Returns an 201-employeePublic object if successful
        /// if not successful, returns 302 - Found to indicate that there is already a user in the Db with that username/password combo.
        /// </summary>
        /// <param name="ep"></param>
        /// <returns></returns>
        [HttpPost("registerasync")]
        public async Task<ActionResult<EmployeePublic>> RegisterAsync(EmployeeRegisterDto ep)
        {
            // Call the business layer method ot register the new user. 
            // Make sure the users email/password combo is not already in the system.
            if (ModelState.IsValid)
            {
                EmployeePublic? ep1 = await this._businessLayer.RegisterAsync(ep);
                if (ep1 != null)
                {
                    return Created("https://www.localhost:7402/ExpenseReimbursement/TODO", ep1);
                }
                else
                {
                    return BadRequest("That user already exists in the DataBase.");
                }
            }
            else
            {
                return BadRequest("The model was not validated");
            }
        }


        /// <summary>
        /// Get all requests.
        /// Get all requests of a specified type
        /// </summary>
        /// <returns></returns>
        // The 2 attributes below are examples of 'Attribute Routing'
        [HttpGet("RequestsAsync")]//get all requests .
        [HttpGet("RequestsAsync/{type}")]//get a specific request
        // '[HttpPost]' is an example of a conventional routing attribute. In conventional routing, the name of hte method is used for the routing.
        public async Task<ActionResult<List<Request>>> RequestsAsync(int type = -1)
        {
            List<Request> requestList = await this._businessLayer.RequestsAsync(type);// this method gets a request by type of request
            return Ok(requestList);
        }

        /// <summary>
        /// Get all requests of a specific user
        /// Get all requests of a user and and by type of request
        /// </summary>
        /// <returns></returns>
        [HttpGet("RequestsAsync/{flag}/{id}")]//if the flag is 0, get request by requestID, if 1, get request by employeeID
        [HttpGet("RequestsAsync/{flag}/{id}/{type}")]// if flag is 2, get requests by type and EmployeeID.
        public async Task<ActionResult<List<UpdatedRequestDto>>> RequestsAsync(int flag, Guid id, int type = -1)
        {
            // TODO create a new action method to fetch a request by it's id.

            if (flag == 1)
            {
                List<UpdatedRequestDto?> requestList = await this._businessLayer.RequestsByIdAsync(flag, id);
                return Ok(requestList);//returns 200
            }
            else
            {
                //the flag is other than 0 or 1, get all requests of a specific type  by the employee
                List<UpdatedRequestDto> requestList = await this._businessLayer.RequestsByEmpAndType(id, type);
                return Ok(requestList);
            }
        }

        [HttpGet("Request")]
        public async Task<ActionResult<UpdatedRequestDto>> RequestById(Guid id)
        {
            UpdatedRequestDto? r = await this._businessLayer.RequestByIdAsync(id);
            return Ok(r);
        }

        [HttpPut("UpdateRequestAsync")]
        public async Task<ActionResult<UpdatedRequestDto>> JimmyAsync(ApprovalDto approval)
        {
            if (ModelState.IsValid)
            {
                //send the ApprovalDto to the business layer
                UpdatedRequestDto? approvedRequest = await this._businessLayer.UpdateRequestAsync(approval);
                return Ok(approvedRequest);
            }
            else return Conflict(approval); //StatusCode(StatusCodes.Status409Conflict);
        }





    }//EoC
}//EoN
