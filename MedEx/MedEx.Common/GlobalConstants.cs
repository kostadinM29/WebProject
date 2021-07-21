namespace MedEx.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "MedEx";

        public const string AdministratorRoleName = "Administrator";

        public const string DoctorRoleName = "Doctor";

        public const int AppliedDoctorItemsPerPageCount = 6;

        public const int VerifiedDoctorItemsPerPageCount = 6;

        public const int DoctorRatingsPerPageCount = 6;

        public static class AccountsSeeding
        {
            public const string AdminGuid = "2a048ae6-70d8-4924-9f43-6d1c44bd1df3";

            public const string AdminUserName = "admin@admin.com";

            public const string AdminPassword = "admin@admin.com";

            public const string AdminPasswordHash = "AQAAAAEAACcQAAAAELUqq4vrK6SuHtrNFff0oVWqVWUXOoHagukgSlZppUUMtnIt2lW6xRvuZVGJ98U1+w=="; // admin@admin.com

            public const string AdminEmail = "admin@admin.com";
        }

        public static class ErrorMessages
        {
            public const string Title = "Title must be between 5 and 60 characters.";

            public const string Content = "Content must be between 700 and 3500 characters.";

            public const string Author = "Author name must be between 2 and 40 characters.";

            public const string Name = "Name must be between 2 and 40 characters.";

            public const string Description = "Description must be between 50 and 700 characters.";

            public const string Address = "Address must be between 5 and 100 characters.";

            public const string Image = "Please select a JPG, JPEG or PNG image smaller than 1MB.";

            public const string DateTime = "Please select a valid DATE and TIME from the datepicker calendar on the left.";

            public const string Rating = "Please choose a valid number of stars from 1 to 5.";
        }

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd/MM/yyyy";

            public const string TimeFormat = "h:mmtt";

            public const string DateTimeFormat = "dd/MM/yyyy h:mmtt";
        }
    }
}
