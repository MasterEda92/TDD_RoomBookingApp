using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _service;

        public RoomBookingRequestProcessor(IRoomBookingService service)
        {
            this._service = service;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest ?bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            _service.Save(new RoomBooking
            {
                FullName = bookingRequest.FullName,
                Email = bookingRequest.Email,
                Date = bookingRequest.Date
            });

            return new RoomBookingResult
            {
                FullName = bookingRequest.FullName,
                Email = bookingRequest.Email,
                Date = bookingRequest.Date
            };
        }
    }
}