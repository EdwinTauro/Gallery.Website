using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using NHibernate;
using Gallery.Persistence.Domain;

namespace Gallery.Persistence.Tests
{
    [TestFixture]
    public class FirstSolutionNHibernateFixture
    {

        [Test]
        public void TestMethod()
        {


            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Member).Assembly);
            new SchemaExport(cfg).Execute(false, false, false);


        }
    }


    [TestFixture]
    public class AccountRepository_Fixture
    {

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;


        //[TestFixtureSetUp]
        //public void TestFixtureSetUp()
        //{
        //    _configuration = new Configuration();
        //    _configuration.Configure();
        //    _configuration.AddAssembly("FirstSolutionNHibernate");
        //    _sessionFactory = _configuration.BuildSessionFactory();

        //}

        [Test]
        public void Can_add_new_account()
        {
            var member = new Member { Username = "Apple", Password = "Fruits" };
            //IMemberRepository repository = new MemberRepository();
            //repository.Add(member);


            Configuration config = new Configuration();
            config.Configure();
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();


            ITransaction tx = session.BeginTransaction();
            session.Save(member);
            tx.Commit();

            session.Close();


        }

        [Test]
        public void CanFetchAccounts()
        {
            Configuration config = new Configuration();
            config.Configure();
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();

            IQuery q = session.GetNamedQuery("CheckValidMember");
            q.SetString("username", "Apple");
            q.SetString("password", "fruits");
            var member = q.List();


            Assert.NotNull(member);
        }

    }


}

