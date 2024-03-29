﻿using Ecopetrol.Api.Services.Model;
using System.Threading.Tasks;

namespace Ecopetrol.Api.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(string id);

        Task<User> GetAsync(string id);
    }
}
