namespace MedEx.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "MedEx";

        public const string AdministratorRoleName = "Administrator";

        public const string DoctorRoleName = "Doctor";

        public const string PatientRoleName = "Patient";

        public const int AppliedDoctorItemsPerPageCount = 6;

        public const int VerifiedDoctorItemsPerPageCount = 6;

        public const int DoctorRatingsPerPageCount = 6;

        public static class AccountsSeeding
        {
            public const string Password = "12345678";

            public const string AdminEmail = "admin@admin.com";

            public const string DoctorEmail = "doctor@doctor.com";

            public const string UserEmail = "user@user.com";

            public const string PatientEmail = "patient@patient.com";
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
