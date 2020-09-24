using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentTask.INFRATRUCTURE.Services.Abstract
{
    public interface IUserService
    {
        bool Authenticate(string userName, string password);
    }
}
