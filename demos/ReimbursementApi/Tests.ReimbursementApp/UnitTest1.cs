using ModelsLayer;

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
            Employee dto = new Employee(guid, "firstName", "lastName", true, "email", "passWord");

            // Assert
            Assert.Equal(dto.EmployeeID, guid);
        }
    }
}