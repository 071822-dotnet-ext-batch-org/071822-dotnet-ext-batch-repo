using ModelsLayer;
using RepositoryAccessLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class ReimbursementBusinessLayer : IReimbursementBusinessLayer
    {
        private readonly IReimbursementRepoLayer _repoLayer;
        public ReimbursementBusinessLayer(IReimbursementRepoLayer irrl)
        {
            this._repoLayer = irrl;
        }

        /// <summary>
        /// This method takes a Guid representing a specific request.
        /// If the id is found, a the request data is returned
        /// If not, returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UpdatedRequestDto> RequestById(Guid id)
        {
            UpdatedRequestDto r = await this._repoLayer.UpdatedRequestByIdAsync(id);
            return r;
        }

        /// <summary>
        /// This method gets a request by type of request or all requests if type == -1
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<Request>> RequestsAsync(int type)
        {
            if (type != -1)
            {
                List<Request> list = await this._repoLayer.RequestsAsync(type);
                return list;
            }
            else
            {
                List<Request> list = await this._repoLayer.RequestsAsync();
                return list;
            }
        }

        public async Task<List<UpdatedRequestDto>> RequestsByEmpAndType(Guid id, int type)
        {
            // call a method that returns all the rrequests by a certain employeeID
            List<UpdatedRequestDto> r = await this._repoLayer.RequestsByEmpAndType(id, type);
            return r;
        }

        /// <summary>
        /// Get all requests by a certain employee ID.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<UpdatedRequestDto>> RequestsByIdAsync(int flag, Guid id)
        {
            // TODO figure out how to get a request whent he flag is 0.. it returns a single request!
            //branch here to call the correct repo methods
            // if (flag == 0)
            // {
            //     //request ID
            // }
            // else// the flag was 1
            // {
            // employee ID
            List<UpdatedRequestDto> list = await this._repoLayer.RequestsByEmpIdAsync(id);
            return list;
            //}
            // throw new NotImplementedException();
        }

        public async Task<UpdatedRequestDto> UpdateRequestAsync(ApprovalDto approvalDto)
        {
            if (await this._repoLayer.IsManagerAsync(approvalDto.EmployeeID))
            {
                UpdatedRequestDto approvedRequest = await this._repoLayer.UpdateRequestAsync(approvalDto.RequestID, approvalDto.Status);
                return approvedRequest;
            }
            else return null;
        }

    }//EoC
}//EoN