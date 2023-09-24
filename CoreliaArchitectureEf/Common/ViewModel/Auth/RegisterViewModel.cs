using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.Auth
{
    public class RegisterViewModel
    {
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(128)]
        public string Email { get; set; }
        [Required, StringLength(256)]
        public string Password { get; set; }
    }
}
