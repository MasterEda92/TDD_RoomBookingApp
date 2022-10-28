using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Moq;
using RoomBookingApp.Core.Domain;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;
        private RoomBookingRequest _request;
        private Mock<IRoomBookingService> _roomBookingServiceMock;

        public RoomBookingRequestProcessorTest()
        {
            // Arrange
            
            _request = new RoomBookingRequest
            {
                FullName = "Max Mustermann",
                Email = "test@test.com",
                Date = new DateTime(2022, 10, 18)
            };

            _roomBookingServiceMock = new Mock<IRoomBookingService>();
            _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);

        }

        [Fact]
        public void ShouldReturnRoomBookingResponseWithRequestValues ()
        {
            // Arrange
            

            // Act
            RoomBookingResult result = _processor.BookRoom(_request);

            // Assert

            // Standard System Assert
            // Assert.NotNull (result);
            // Assert.Equal(request.FullName, result.FullName);
            // Assert.Equal(request.Email, result.Email);
            // Assert.Equal(request.Date, result.Date);

            // Shouldly
            result.ShouldNotBeNull();
            result.FullName.ShouldBe(_request.FullName);
            result.Email.ShouldBe(_request.Email);
            result.Date.ShouldBe(_request.Date);

        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request ()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));

            exception.ParamName.ShouldBe("bookingRequest");
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            // Arrange
            RoomBooking savedBooking = null;
            _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
                {
                    savedBooking = booking;
                });

            // Act
            _processor.BookRoom(_request);

            // Assert

            // Verify the Save Method was called once
            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once);

            savedBooking.ShouldNotBeNull();
            savedBooking.FullName.ShouldBe(_request.FullName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.Date.ShouldBe(_request.Date);
        }
    }
}

