using ModelsLayer;

namespace BusinessLayer
{
    public interface IReimbursementBusinessLayer
    {
        Task<UpdatedRequestDto> RequestByIdAsync(Guid id);
        Task<List<Request>> RequestsAsync(int type);
        Task<List<UpdatedRequestDto>> RequestsByEmpAndType(Guid id, int type);
        Task<List<UpdatedRequestDto>> RequestsByIdAsync(int flag, Guid id);
        Task<UpdatedRequestDto> UpdateRequestAsync(ApprovalDto approvalDto);
    }
}