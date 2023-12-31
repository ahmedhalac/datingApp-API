﻿using System.ComponentModel.DataAnnotations.Schema;
using API.Extensions;

namespace API.Entities;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string KnownAs { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public string Gender { get; set; }

    public string Introduction { get; set; }

    public string LookingFor { get; set; }

    public string Interests { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    //1 -> n. 1 to many relathionship User table with Photo
    public List<Photo> Photos { get; set; } = new();

    // Likes given by this user
    public List<UserLike> LikedByUsers { get; set; }
    // Likes received by this user
    public List<UserLike> LikedUsers { get; set; }

    public int GetAge()
    {
        return DateOfBirth.CalculateAge();
    }

}

