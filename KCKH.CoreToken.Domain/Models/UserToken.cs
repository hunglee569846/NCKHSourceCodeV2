using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.CoreToken.Domain.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        public string GuidId { get; set; }
        public DateTime? ExpiredTime { get; set; }
    }
}
