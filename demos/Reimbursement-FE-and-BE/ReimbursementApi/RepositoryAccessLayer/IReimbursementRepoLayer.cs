using ModelsLayer;

namespace RepositoryAccessLayer
{
    public interface IReimbursementRepoLayer
    {
        Task<bool> IsManagerAsync(Guid employeeID);
        Task<UpdatedRequestDto?> UpdatedRequestByIdAsync(Guid requestId);
        Task<List<Request>> RequestsAsync();
        Task<List<Request>> RequestsAsync(int type);
        Task<List<UpdatedRequestDto?>> RequestsByEmpIdAsync(Guid id);
        Task<UpdatedRequestDto?> UpdateRequestAsync(Guid requestId, int status);
        Task<List<UpdatedRequestDto>> RequestsByEmpAndType(Guid id, int type);
        Task<bool> UserNamePassWordExists(string email, string password);
        Task<EmployeePublic?> InsertNewEmployee(Guid guid, EmployeeRegisterDto ep);
    }
}