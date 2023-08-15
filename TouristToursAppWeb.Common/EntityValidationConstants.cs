using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int CategoryNameMinLength = 1;
            public const int ContegoryNameMaxLength = 50;
        }

        public static class Tour
        {
            public const int TourTitleMaxLength = 250;
            public const int TourTitleMinLength = 5;

            public const int DuarationMaxLength = 40;
            public const int DuarationMinLength = 3;

            public const int ImportInformationMaxLenght = 500;
            public const int ImportInformationMinLenght = 2;

            public const string PricePerPersonMax = "100000";
            public const string PricePerPersonMin = "1";

        }

        public static class UserGuide
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;

            public const int LegalFirmNameMaxLength = 80;
            public const int LegalFirmNameMinLength = 2;

            public const int CRNLenghtMax = 8;
            public const int CRNLenghtMin = 8;

            public const int VATNumberMaxLength = 15;
            public const int VATNumberMinLength = 4;

            public const int AboutMaxLength = 5000;


            public const int RegisteredAddressMaxLength = 25;
            public const int RegisteredAddressMinLength = 3;
        }

        public static class Location
        {
            public const int LocationPlaceMinLength = 2;
            public const int LocationPlaceMaxLength = 100;

        }

        public static class TourBooking
        {
            public const int countOfPeopleMax = 50;
            public static int countOfPeopleMin = 1;



        }
    }
}
