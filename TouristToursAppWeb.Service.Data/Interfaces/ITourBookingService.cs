using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface ITourBookingService
    {
       
        Task MakeBooking(TourBokingFormViewModel bokingFormViewModel,string currentUserId);
    }
}
