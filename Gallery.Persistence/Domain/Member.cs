using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Persistence.Domain
{
    public class Member
    {
        public virtual String Id { get; private set; }
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual String Email { get; set; }
    }
}
