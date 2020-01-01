using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using EHRS.Shared;

namespace EHRS.Web.Shared.Models
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must include name.")]
        [Display(Name = "Name")]
        [RegularExpression(ValidationConstants.RegEx.Alphabets, ErrorMessage = "Invalid name, should contain only alphabets.")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must include email.")]
        [RegularExpression(ValidationConstants.RegEx.Email, ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must include mobile no.")]
        [Display(Name = "Mobile No")]
        [RegularExpression(ValidationConstants.RegEx.MobileNumber, ErrorMessage = "Invalid mobile number.")]
        public string MobileNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ValidationConstants.Account.PasswordMinimumLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets first name
        /// </summary>
        public string FirstName
        {
            get
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    Name = Regex.Replace(Name, @"\s+", " ");
                    return Name.Split(' ').First();
                }
                return "";
            }
        }

        /// <summary>
        /// Gets the Last Name
        /// </summary>
        public string LastName
        {
            get
            {
                if (!string.IsNullOrEmpty(Name) && Name.Contains(" "))
                {
                    Name = Regex.Replace(Name, @"\s+", " ");
                    return Name.Split(' ').Last();
                }
                return "";
            }
        }
    }
}
