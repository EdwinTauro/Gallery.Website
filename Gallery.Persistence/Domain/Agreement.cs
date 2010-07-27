using System;
using System.Collections.Generic;
using NHibernate;

namespace Gallery.Persistence.Domain
{
    public interface IAgreementRepository
    {
        void Add(Agreement agreement);
        Agreement GetByWaspName(string wasp);
        ICollection<Agreement> GetAll();
    }

    public class AgreementRepository : IAgreementRepository
    {

        #region IAgreementRepository Members




        ICollection<Agreement> IAgreementRepository.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (ICollection<Agreement>)session.Get<Agreement>(1);
            }
        }

        void IAgreementRepository.Add(Agreement agreement)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(agreement);
                transaction.Commit();
            }
        }

        Agreement IAgreementRepository.GetByWaspName(string wasp)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Agreement agreement = session.CreateCriteria(typeof(Agreement))
                //    .Add(Expression.Le("StartDate",DateTime.Today))
                //    .Add(Expression.Ge("EndDate", DateTime.Today))
                //    //.Add(Expression.Lt("StartDate", DateTime.Today))
                //    //.Add(Expression.Gt("EndDate", DateTime.Today))
                //    .UniqueResult<Agreement>();




                Agreement agreement = session.GetNamedQuery("GetLatestAgreementByWasp")
                    .SetParameter("wasp", wasp)
                    .UniqueResult<Agreement>();

                return agreement;
            }
        }

        #endregion
    }

    public class Agreement
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int ClickLimit { get; set; }
        public virtual Boolean Eval { get; set; }
        public virtual Account Account { get; set; }

    }
}
