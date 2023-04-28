using System;
using System.Collections.Generic;

namespace InterviewTasks2023.Models;

public partial class Book
{
    public int Code { get; set; }

    public string? BookName { get; set; }

    public string? Author { get; set; }

    public bool? IsAvailable { get; set; }

    public decimal? Price { get; set; }

    public int? ShelfId { get; set; }

    public virtual Shelf? Shelf { get; set; }
     
    public List<Book> ShowallBook { get; set; } 
}
