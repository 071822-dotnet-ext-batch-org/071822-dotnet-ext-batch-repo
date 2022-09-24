using ModelsLayer;
using RepositoryAccessLayer;

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
        public async Task<UpdatedRequestDto?> RequestByIdAsync(Guid id)
        {
            UpdatedRequestDto? r = await this._repoLayer.UpdatedRequestByIdAsync(id);
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
        public async Task<List<UpdatedRequestDto?>> RequestsByIdAsync(int flag, Guid id)
        {
            // TODO figure out how to get a request when the flag is 0.. it returns a single request!
            //branch here to call the correct repo methods
            // if (flag == 0)
            // {
            //     //request ID
            // }
            // else// the flag was 1
            // {
            // employee ID
            List<UpdatedRequestDto?> list = await this._repoLayer.RequestsByEmpIdAsync(id);
            return list;
            //}
            // throw new NotImplementedException();
        }

        public async Task<UpdatedRequestDto?> UpdateRequestAsync(ApprovalDto approvalDto)
        {
            if (await this._repoLayer.IsManagerAsync(approvalDto.EmployeeID))
            {
                UpdatedRequestDto? approvedRequest = await this._repoLayer.UpdateRequestAsync(approvalDto.RequestID, approvalDto.Status);
                return approvedRequest;
            }
            else return null;
        }

        /// <summary>
        /// This method varifies if a username and password combination is already in the db.
        /// If so, returns null
        /// if not, wil insert the new user, with a unique identifier into the Db.
        /// </summary>
        /// <param name="ep"></param>
        /// <returns></returns>
        public async Task<EmployeePublic?> RegisterAsync(EmployeeRegisterDto ep)
        {
            // check if the user is already in the Db.
            bool exists = await this._repoLayer.UserNamePassWordExists(ep.Email, ep.password);
            if (exists)
            {
                return null;
            }
            else
            {
                //insert the user into the Db with a new Guid.
                Guid guid = Guid.NewGuid();
                EmployeePublic? ep1 = await this._repoLayer.InsertNewEmployee(guid, ep);
                return ep1;

            }

        }

    }//EoC
}//EoN