using ModelsLayer;

namespace Tests.ReimbursementApp
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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
    }
}