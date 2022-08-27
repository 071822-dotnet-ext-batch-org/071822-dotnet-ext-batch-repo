using ModelsLayer;

namespace RepositoryAccessLayer
{
    public interface IReimbursementRepoLayer
    {
        Task<bool> IsManagerAsync(Guid employeeID);
        Task<List<Request>> RequestsAsync();
        Task<List<Request>> RequestsAsync(int type);
        Task<List<UpdatedRequestDto>> RequestsByEmpIdAsync(Guid id);
        Task<UpdatedRequestDto> UpdateRequestAsync(Guid requestId, int status);
    }
}