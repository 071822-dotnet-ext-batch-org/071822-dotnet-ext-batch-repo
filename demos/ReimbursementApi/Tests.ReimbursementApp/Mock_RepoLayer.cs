using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepositoryAccessLayer;

namespace Tests.ReimbursementApp
{
    public class Mock_RepoLayer : IReimbursementRepoLayer
    {
        public Task<EmployeePublic> InsertNewEmployee(Guid guid, EmployeeRegisterDto ep)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsManagerAsync(Guid employeeID)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<List<Request>> RequestsAsync()
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<List<Request>> RequestsAsync(int type)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<List<UpdatedRequestDto>> RequestsByEmpAndType(Guid id, int type)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<List<UpdatedRequestDto>> RequestsByEmpIdAsync(Guid id)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        /// <summary>
        /// creates a fake UpdatedRequestDto and returns it
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<UpdatedRequestDto> UpdatedRequestByIdAsync(Guid requestId)
        {
            // throw new NotImplementedException();
            await Task.Delay(100);
            UpdatedRequestDto dto = new UpdatedRequestDto(requestId, "Mark", "Moore", "It's Mark Moore", 4);
            return dto;
        }

        public async Task<UpdatedRequestDto> UpdateRequestAsync(Guid requestId, int status)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public Task<bool> UserNamePassWordExists(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}