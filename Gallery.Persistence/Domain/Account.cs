using System;
using NHibernate;
using System.Collections.Generic;

namespace Gallery.Persistence.Domain
{
    public interface IAccountRepository
    {

        void Add(Account account);

        void Update(Account account);

        void Remove(Account account);

        Account GetById(int accountId);

        Account GetByWaspName(string wasp);

        ICollection<Account> GetByCategory(string category);

    }


    public class AccountRepository : IAccountRepository
    {

        public void Add(Account account)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(account);
                transaction.Commit();
            }
        }



        public void Update(Account account)
        {

            throw new NotImplementedException();

        }



        public void Remove(Account account)
        {

            throw new NotImplementedException();

        }



        public Account GetById(int accountId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Account>(accountId);
                
            }
        }



        public Account GetByWaspName(string wasp)
        {

            throw new NotImplementedException();

        }



        public ICollection<Account> GetByCategory(string category)
        {

            throw new NotImplementedException();

        }

    }


    public class Account
    {
        public virtual int Id { get; set; }
        public virtual String Wasp { get; set; }
        public virtual String Company { get; set; }
        public virtual String Contact { get; set; }
        public virtual String Email { get; set; }
    }
}