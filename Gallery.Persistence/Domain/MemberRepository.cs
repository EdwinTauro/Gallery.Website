using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Gallery.Persistence.Domain
{
    public class MemberRepository : IMemberRepository
    {
        bool IMemberRepository.Add(string userName, string password, string email, out object providerUserKey)
        {
            

            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                providerUserKey = session.Save(new Member { Username = userName, Password = password, Email = email });
                transaction.Commit();

                return true;
            }
        }


        bool IMemberRepository.IsValidUser(string userName, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.GetNamedQuery("Gallery.Persistence.Domain.CheckValidMember");
                query.SetString("username", userName);
                query.SetString("password", password);
                var result = query.UniqueResult();

                return (result != null);
            }
        }
    }
}
