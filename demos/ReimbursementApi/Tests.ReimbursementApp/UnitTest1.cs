using ModelsLayer;
using BusinessLayer;

namespace Tests.ReimbursementApp
{
    public class UnitTest1
    {
        [Fact]
        public void ApprovalDtoCreatedCorrectly()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act
            ApprovalDto dto = new ApprovalDto
            {
                EmployeeID = guid,
                RequestID = guid,
                Status = 10
            };

            // Assert
            Assert.Equal(dto.EmployeeID, guid);
        }

        [Fact]
        public void EmployeeCreatedCorrectly()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act
            Employee dto = new Employee(guid, "firstName", "lastName", true, "email", "password");

            // Assert
            Assert.Equal(dto.EmployeeID, guid);
        }

        [Fact]
        public async Task RequestByIdReturnsUpdatedRequestDto()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            //create the instance of the business layer
            ReimbursementBusinessLayer bl = new ReimbursementBusinessLayer(new Mock_RepoLayer());

            // Act
            // Employee dto = new Employee(guid, "firstName", "lastName", true, "email", "password");
            UpdatedRequestDto result = await bl.RequestByIdAsync(guid);

            // Assert
            Assert.Equal(result.RequestId, guid);
        }


    }//EoC
}//EoN