using System;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void ShouldReturnRoomBookingResponseWithRequestValues ()
        {
            // Arrange
            var request = new RoomBookingRequest
            {
                FullName = "Max Mustermann",
                Email = "test@test.com",
                Date = new DateTime(2022, 10, 18)
            };

            var processor = new RoomBookingRequestProcessor();

            // Act
            RoomBookingResult result = processor.BookRoom(request);

            // Assert
            // Assert.NotNull (result); // Standard Assert
            // Assert.Equal(request.FullName, result.FullName);
            // Assert.Equal(request.Email, result.Email);
            // Assert.Equal(request.Date, result.Date);

            result.ShouldNotBeNull(); // Assert mit Shouldly
            result.FullName.ShouldBe(request.FullName);
            result.Email.ShouldBe(request.Email);
            result.Date.ShouldBe(request.Date);

        }
    }
}

