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
        /// Get all requests.
        /// Get all requests of a specified type
        /// </summary>
        /// <returns></returns>
        [HttpGet("RequestsAsync")]//get all requests .
        [HttpGet("RequestsAsync/{type}")]//get a specific request
        //[HttpGet("RequestsAsync/{id?}")]//get all of a type of request
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
                List<UpdatedRequestDto> requestList = await this._businessLayer.RequestsByIdAsync(flag, id);
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
            UpdatedRequestDto r = await this._businessLayer.RequestById(id);
            return Ok(r);
        }

        [HttpPut("UpdateRequestAsync")]
        public async Task<ActionResult<UpdatedRequestDto>> JimmyAsync(ApprovalDto approval)
        {
            if (ModelState.IsValid)
            {
                //send the ApprovalDto to the business layer
                UpdatedRequestDto approvedRequest = await this._businessLayer.UpdateRequestAsync(approval);
                return Ok(approvedRequest);
            }
            else return Conflict(approval); //StatusCode(StatusCodes.Status409Conflict);
        }





    }
}
