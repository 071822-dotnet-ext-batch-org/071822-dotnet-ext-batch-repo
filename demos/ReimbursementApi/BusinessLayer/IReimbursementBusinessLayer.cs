using ModelsLayer;

namespace BusinessLayer
{
    public interface IReimbursementBusinessLayer
    {
        Task<List<Request>> RequestsAsync(int type);
        Task<List<Request>> RequestsByEmpAndId(Guid id, int type);
        Task<List<UpdatedRequestDto>> RequestsByIdAsync(int flag, Guid id);
        Task<UpdatedRequestDto> UpdateRequestAsync(ApprovalDto approvalDto);
    }
}