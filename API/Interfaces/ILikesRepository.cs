﻿using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface ILikesRepository
{
    Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
    Task<User> GetUserWithLikes(int userId);
    Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
    
}
