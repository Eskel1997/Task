using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentTask.INFRATRUCTURE.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public long Id { get; set; }
        public DeleteCompanyCommand(long id)
        {
            Id = id;
        }
    }
}
