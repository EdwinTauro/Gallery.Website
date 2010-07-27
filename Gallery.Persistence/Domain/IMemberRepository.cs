using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Persistence.Domain
{
    public interface IMemberRepository
    {
        bool Add(string userName, string password, string email, out object providerUserKey);

        bool IsValidUser(string userName, string password);
    }
}
