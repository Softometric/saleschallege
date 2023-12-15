using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.AuthModel
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ChangePasswordRequest
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class PasswordResetResponse
    {
        public string PasswordResetToken { get; set; }
    }
    public class ResetPasswordRequest
    {
        public string Username { get; set; }
        public string PasswordResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
