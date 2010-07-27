using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Persistence.Domain
{

    public class Activity
    {
        public virtual int Id { get; set; }
        public virtual string Action { get; set; }
        public virtual int Clicks { get; set; }
        public virtual Authuser Authuser { get; set; }
        public virtual Agreement Agreement { get; set; }
    }
}
