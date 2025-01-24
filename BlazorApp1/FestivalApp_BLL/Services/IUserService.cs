﻿using System.Threading.Tasks;

namespace FestivalApp_BLL.Services
{
    public interface IUserService
    {
        Task<object> ValidateUser(string email, string password);
        Task<bool> RegisterUser(string name, string email, string password, bool isArtist);
    }
}