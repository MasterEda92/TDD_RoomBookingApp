using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;

        public RoomBookingRequestProcessorTest()
        {
            _processor = new RoomBookingRequestProcessor();
        }

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

            // Act
            RoomBookingResult result = _processor.BookRoom(request);

            // Assert

            // Standard System Assert
            // Assert.NotNull (result);
            // Assert.Equal(request.FullName, result.FullName);
            // Assert.Equal(request.Email, result.Email);
            // Assert.Equal(request.Date, result.Date);

            // Shouldly
            result.ShouldNotBeNull();
            result.FullName.ShouldBe(request.FullName);
            result.Email.ShouldBe(request.Email);
            result.Date.ShouldBe(request.Date);

        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request ()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));

            exception.ParamName.ShouldBe("bookingRequest");
        }
    }
}

