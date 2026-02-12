using System.ComponentModel.DataAnnotations;

namespace Mission06_Mantoan.Models;

public class ExistingMovie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    public int CategoryId { get; set; } //Foreign Key
    public string Title { get; set; }
    public int Year { get; set; }
    public string ?  Director { get; set; }
    public string?  Rating { get; set; }
    public bool Edited {get; set;}
    public string ?  LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    public string ?  Notes { get; set; }
    public ExistingCategory Category { get; set; } //Reference
}