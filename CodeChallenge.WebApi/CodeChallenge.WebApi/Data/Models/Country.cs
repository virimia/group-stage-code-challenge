using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.WebApi.Data.Models;

public class Country
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    public CountryEnum CountryId { get; set; }

    [Required]
    public string Name { get; set; }
}
