using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Data.Models;

public class Team
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    public CountryEnum CountryCode { get; set; }

    [Required]
    public string Name { get; set; }
}
