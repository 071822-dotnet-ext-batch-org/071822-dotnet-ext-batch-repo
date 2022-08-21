﻿using ModelsLayer;
using System.Data.SqlClient;

namespace RepositoryAccessLayer
{
    public class ReimbursementRepoLayer
    {
        public async Task<List<Request>> RequestsAsync(int type)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Request WHERE Status = @type", conn1))
            {
                command.Parameters.AddWithValue("@type", type);// add dynamic data like this to protect against SQL Injection.
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Request> rList = new List<Request>();
                while(ret.Read())
                {
                    Request r = new Request((Guid)ret[0], (Guid)ret[1],ret.GetString(2), ret.GetDecimal(3),ret.GetInt32(4));
                    rList.Add(r);                    
                }
                conn1.Close();
                return rList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UpdatedRequestDto> UpdateRequestAsync(Guid requestId, int status)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE Request SET Status = @status WHERE RequestID = @id", conn1))
            {
                command.Parameters.AddWithValue("@id", requestId);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("status",status);
                conn1.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret == 1)
                {
                    conn1.Close();
                    /*The cunundrum we have here is
                     * 1) we create 2 new methods to get the request by 
                     * ID AND get the employee by id. These are methods that would be useful and reusable.
                     * BUT 
                     * 2) Mark does not want to do 80% fo the project for his Associates. 
                     * They need to exercise their brains      
                     * */

                    // call the UpdatedRequestById(). this method will use a join to return the Employees name
                    // along with the relevant details and return a DTO so that the FE can display the updated data to the user.
                    UpdatedRequestDto urbi = await this.UpdatedRequestByIdAsync(requestId);
                    return urbi;
                }
                conn1.Close();
                return null;
            }
        }

        private async Task<UpdatedRequestDto> UpdatedRequestByIdAsync(Guid requestId)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT RequestID, FirstName, LastName, Status FROM [dbo].[Employees]" +
                $" LEFT JOIN Request ON EmployeeID = FK_EmployeeId WHERE RequestID = @requestId", conn1))
            {
                command.Parameters.AddWithValue("@requestId", requestId);// add dynamic data like this to protect against SQL Injection.
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    UpdatedRequestDto r = new UpdatedRequestDto(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3));
                    conn1.Close();
                    return r;
                }
                conn1.Close();
                return null;
            }
        }

        public async Task<bool> IsManagerAsync(Guid employeeID)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT IsManager FROM Employees WHERE EmployeeID = @id", conn1))
            {
                command.Parameters.AddWithValue("@id", employeeID);// add dynamic data like this to protect against SQL Injection.
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read() && ret.GetBoolean(0))
                {
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                return false;
            }
        }
    }
}