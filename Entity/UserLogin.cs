using System;
using System.Collections.Generic;

namespace Vue3_Service.Entity
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpireTime { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
