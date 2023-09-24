using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.Auth
{
    public class AddRoleViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
