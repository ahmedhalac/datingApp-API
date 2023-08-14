using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public string Id { get; set; }

    public string Url { get; set; }

    public bool isMain { get; set; }

    public string PublicId { get; set; }

    //foreign key, connection with Users table
    public int UserId { get; set; }

    public User User { get; set; }
}