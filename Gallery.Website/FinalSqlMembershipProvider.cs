using System.Web.Security;
using Gallery.Persistence.Domain;
using System;

namespace Gallery.Website.Provider
{
    public class FinalSqlMembershipProvider : SqlMembershipProvider
    {
        private IMemberRepository membershipRepository = new MemberRepository();

        public override bool ValidateUser(string username, string password)
        {
            return membershipRepository.IsValidUser(username, password);

            //return base.ValidateUser(username, password);
        }


        public override MembershipUser CreateUser(string username, string password, string email, 
            string passwordQuestion, string passwordAnswer, bool isApproved, 
            object providerUserKey, out MembershipCreateStatus status)
        {

            bool created = false;
            MembershipUser membershipUser = null;

            try
            {
                created = membershipRepository.Add(username, password, email, out providerUserKey);

                membershipUser = new MembershipUser(this.Name, username, providerUserKey,
                    email, null, null, true, true, 
                    DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);

                if (created)
                {
                    status = MembershipCreateStatus.Success;
                }
                else
                {
                    status = MembershipCreateStatus.UserRejected;
                }

            }
            catch (Exception)
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }
            

            return membershipUser;
        }
    }
}