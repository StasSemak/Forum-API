using BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Intefraces
{
    public interface IAccountService
    {
        Task RegisterAsync(UserDto user);
        Task<UserDto> LoginAsync(string email, string password);

        Task<UserDto> GetUserAsync(string id);
    }
}
