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
        /// Get all the pending requests
        /// </summary>
        /// <returns></returns>
        [HttpGet("RequestsAsync")]//get all requests .
        [HttpGet("RequestsAsync/{type}")]//get all of a type of request
        //[HttpGet("RequestsAsync/{id}/{type?}")]// get all or a specific type and employee. You'll have to figure out how to structure the query so that the optional values are indeed optional
        //[HttpGet("RequestsAsync/{id}")]// get all of a specific employees requests
        public async Task<ActionResult<List<Request>>> RequestsAsync(int type, Guid? id)
        {
            List<Request> requestList = await this._businessLayer.RequestsAsync(type);
            return Ok(requestList);//returns 200            
            //return null;
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
