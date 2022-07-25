using Domain.Persons;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IPersonService
    {
        Task<BaseResponse> CreateUser(string name, int personrole, decimal salary, DateTime dateStartWorking);

        Task<BaseResponse> GetUser(string name);

        Task<BaseResponse> Delete(string name);

        Task<BaseResponse> Update(string name, string newName);
    }
}
