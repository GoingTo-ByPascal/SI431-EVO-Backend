using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Services.Communications
{
    public class ProfileResponse : BaseResponse<Profile>
    {
        public Profile Profile { get; private set; }

        public ProfileResponse(string message) : base(message) { }

        public ProfileResponse(Profile profile) : base(profile) { }
    }
}