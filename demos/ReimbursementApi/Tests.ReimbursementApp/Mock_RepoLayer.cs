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
        public async Task<bool> IsManagerAsync(Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Request>> RequestsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Request>> RequestsAsync(int type)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UpdatedRequestDto>> RequestsByEmpAndType(Guid id, int type)
        {
            throw new NotImplementedException();
        }

        public Task<List<global::ModelsLayer.UpdatedRequestDto>> RequestsByEmpIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// creates a fake UpdatedRequestDto and returns it
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<UpdatedRequestDto> UpdatedRequestByIdAsync(Guid requestId)
        {
            throw new NotImplementedException();
            //  UpdatedRequestDto dto = new UpdatedRequestDto
            // {
            //     Details = "this is a mock"
            // };
            // return dto;
        }

        public async Task<UpdatedRequestDto> UpdateRequestAsync(Guid requestId, int status)
        {
            throw new NotImplementedException();
        }
    }
}