using RecruitmentTask.INFRATRUCTURE.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask.INFRATRUCTURE.Services.Concrete
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User
            {
                UserName = "Admin",
                Password = "admin"
            }
        };

        public bool Authenticate(string userName, string password)
        {
            var user = this.users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();

            return user is null ? false : true;
        }
    }
}
