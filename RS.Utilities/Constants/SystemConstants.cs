using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "RSDb";
        public const string CartSession = "CartSession";
        public static string BACK_END_NAMED_CLIENT = "Back_End_Named_Client";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 5;
            public const int NumberOfLatestProducts = 5;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
