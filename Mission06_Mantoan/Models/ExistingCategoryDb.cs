using System.ComponentModel.DataAnnotations;

namespace Mission06_Mantoan.Models;

public class ExistingCategory
{
    [Key]
    [Required]
    public int CategoryId {get; set;}
    public string CategoryName {get; set;}
    public List<ExistingMovie> ExistingMovies {get; set;}
}