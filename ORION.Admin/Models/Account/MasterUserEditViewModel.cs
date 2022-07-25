using System.ComponentModel.DataAnnotations;
using ORION.DataAccess.Models;

namespace ORION.Admin.Models.Account
{
    public class MasterUserEditViewModel
    {
        [Required(ErrorMessage = "Must type into user name")]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum lengnt is 3")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Must type into password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public MasterUserEditViewModel() { }

        public MasterUserEditViewModel(MasterUser appUser)
        {
            UserName = appUser.UserName;
            Password = appUser.PasswordHash;
        }
    }
}
