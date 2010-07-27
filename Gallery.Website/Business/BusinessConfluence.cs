using Gallery.Website.Models;
using Gallery.Persistence.Domain;

namespace Gallery.Website.Business
{
    public class BusinessConfluence : IBusinessConfluence
    {
        private IMemberRepository MemberRepository;

        public BusinessConfluence(IMemberRepository memberRepository)
        {
            MemberRepository = memberRepository;
        }

        //bool IBusinessConfluence.RegisterMember(RegisterModel registerationDetails)
        //{
        //    return MemberRepository.Add(registerationDetails.UserName, registerationDetails.Password,
        //        registerationDetails.Email);
        //}
    }
}