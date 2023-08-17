using System;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(User user);
    Task<bool> SaveAllAsync();
    Task<PagedList<User>> GetUsersAsync(UserParams userParams);
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
}

