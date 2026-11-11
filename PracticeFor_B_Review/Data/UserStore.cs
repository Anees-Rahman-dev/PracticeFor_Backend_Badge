using B_Review_Application.DTO.Auth;
using B_Review_Domain.Entities;

namespace PracticeFor_B_Review.Data
{
    public class UserStore
    {
        public List<UserForAuth> Users { get; set; } = new List<UserForAuth>();
    }
}
