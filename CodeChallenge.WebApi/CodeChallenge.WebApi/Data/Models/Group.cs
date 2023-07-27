using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Data.Models;

public class Group
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    public Guid GroupDrawId { get; set; }
    public GroupDraw GroupDraw { get; set; }

    [Required]
    public string Composition { get; set; }
}
