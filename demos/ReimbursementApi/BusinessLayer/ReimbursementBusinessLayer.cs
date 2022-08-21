using ModelsLayer;
using RepositoryAccessLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class ReimbursementBusinessLayer
    {

        private readonly ReimbursementRepoLayer _repoLayer;
        public ReimbursementBusinessLayer()
        {
            this._repoLayer = new ReimbursementRepoLayer();
        }

        public async Task<List<Request>> RequestsAsync(int type)
        {
            List<Request> list = await this._repoLayer.RequestsAsync(type);
            return list;
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
    }
}