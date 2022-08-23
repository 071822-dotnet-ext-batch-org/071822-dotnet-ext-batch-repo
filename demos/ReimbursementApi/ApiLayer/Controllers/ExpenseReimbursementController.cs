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
        private readonly ReimbursementBusinessLayer _businessLayer;
        public ExpenseReimbursementController()
        {
            this._businessLayer = new ReimbursementBusinessLayer();
        }

        /// <summary>
        /// Get all requests. 
        /// Get a specific request
        /// Get all requests of a specified type
        /// </summary>
        /// <returns></returns>
        [HttpGet("RequestsAsync")]//get all requests .
        [HttpGet("RequestsAsync/{id}")]//get a specific request
        [HttpGet("RequestsAsync/{type}")]//get all of a type of request
        public async Task<ActionResult<List<Request>>> RequestsAsync(Guid? id, int type = -1)
        {
            //get all the Requests OR get all of a specific type
            if (id == null)
            {
                List<Request> requestList = await this._businessLayer.RequestsAsync(type);// this method gets a request by type of request
                return Ok(requestList);//returns 200            
            }
            else if (type == -1)
            {
                //TODO
                // create a path to get all the requests o a specific type
                List<Request> requestList = await this._businessLayer.RequestsAsync(type);
                return Ok(requestList);//returns 200            
            }
            return null;
        }

        /// <summary>
        /// Get all requests of a specific user
        /// Get all requests of a user and and by type of request
        /// </summary>
        /// <returns></returns>
        // [HttpGet("RequestsAsync/{id}")]//get all of a type of request of an employee
        // [HttpGet("RequestsAsync/{id}/{type}")]// get all of a specific type and employee.
        // public async Task<ActionResult<List<Request>>> RequestsAsync(Guid id, int type = -1)
        // {
        //     //TODO
        //     List<Request> requestList = await this._businessLayer.RequestsAsync(type);
        //     return Ok(requestList);//returns 200            
        //     //return null;
        // }


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
