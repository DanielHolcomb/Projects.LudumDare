using Projects.LudumDare.Models;

namespace Projects.LudumDare.Services.Interfaces
{
    public interface ILudumDareService
    {
        public Task<UserProfileResponse?> GetUserProfile(string username);
    }
}
