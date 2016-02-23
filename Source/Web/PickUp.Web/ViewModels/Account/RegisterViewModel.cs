namespace PickUp.Web.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Are you a driver")]
        public bool IsDriver { get; set; }

        [Display(Name = "Brand")]
        public string CarBrand { get; set; }

        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Registration number")]
        public string CarRegistrationNumber { get; set; }

        [Display(Name = "Year")]
        public int? CarYear { get; set; }

        [Display(Name = "Color")]
        public string CarColor { get; set; }
    }
}
