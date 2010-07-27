using Gallery.Persistence.Domain;
using NUnit.Framework;

namespace Gallery.Persistence.Tests
{
    [TestFixture]
    public class GalleryMemberFixture
    {

        [Test]
        public void CanAddMemeber()
        {
            object providerUserKey;
            IMemberRepository repository = new MemberRepository();
            repository.Add("edwin", "edwin", "edwin@gmail.com", out providerUserKey);

        }

        [Test]
        public void CanCheckValidMember()
        {
            IMemberRepository repository = new MemberRepository();
            var returnvalue = repository.IsValidUser("edwin", "edwin");
        }



    }

    
}
