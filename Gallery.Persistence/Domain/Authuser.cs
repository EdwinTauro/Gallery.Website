using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Persistence.Domain
{
    public class Authuser
    {
        public virtual int Id { get; set; }
        public virtual string Wasp { get; set; }
        public virtual bool Eval { get; set; }
        public virtual Account Account { get; set; }
    }
}
