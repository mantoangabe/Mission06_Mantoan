using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Mantoan.Models;
//New Db for Mission 07
public partial class Movie
{
    public int MovieId { get; set; }

    public int? CategoryId { get; set; }

    public string Title { get; set; } = null!;
    [Range(1888, 3000, ErrorMessage = "Release Year must be 1888 or later.")]


    public int Year { get; set; }

    public string? Director { get; set; }

    public string? Rating { get; set; }
    
    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    public bool CopiedToPlex { get; set; }

    public string? Notes { get; set; }

    public virtual Category? Category { get; set; } //To link to other table; found this was easier than the [ForeignKey("CategoryId"] Method
}
