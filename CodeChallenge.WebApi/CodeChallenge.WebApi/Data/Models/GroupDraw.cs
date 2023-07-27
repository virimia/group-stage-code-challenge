using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Data.Models;

public class GroupDraw
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string DrawMaster { get; set; }

    public ICollection<Group> Groups { get; set; }
}
