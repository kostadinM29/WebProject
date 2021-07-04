namespace MedEx.Web.ViewModels.Administration.Dashboard
{
    public class AllDoctorsViewModel
    {
        public string FullName { get; set; }

        public string PictureUrl { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public int? Experience { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Biography { get; set; }

        public string Town { get; set; }

        public string Specialization { get; set; }

        public bool HasApplied { get; set; }

        public bool IsValidated { get; set; }
    }
}
