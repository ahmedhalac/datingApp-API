using System;
namespace API.Entities;

public class UserLike
{
    public User SourceUser{ get; set; } 

    public int SourceUserId { get; set; } // The user who is liking

    public User TargetUser { get; set; }

    public int TargetUserId { get; set; } // The user who is being liked
}

