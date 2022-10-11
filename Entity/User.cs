using System;
using System.Collections.Generic;

namespace Vue3_Service.Entity
{
    public partial class User
    {
        public User()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? CreateTime { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
