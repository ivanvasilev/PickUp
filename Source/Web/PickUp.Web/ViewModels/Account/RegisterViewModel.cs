namespace PickUp.Web.ViewModels.Account
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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
        [Range(1900, 2016)]
        public int CarYear { get; set; }

        [Display(Name = "Color")]
        public string CarColor { get; set; }
    }
}
