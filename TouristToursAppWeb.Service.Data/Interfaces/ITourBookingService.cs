using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface ITourBookingService
    {
       
        Task MakeBooking(TourBokingFormViewModel bokingFormViewModel,string currentUserId);

        Task<List<TourBookedViewModel>> GetBookedTours(string tourId);

        void ChangeStatus(string bookId);
    }
}
