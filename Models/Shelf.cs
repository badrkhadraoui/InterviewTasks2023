using System;
using System.Collections.Generic;

namespace InterviewTasks2023.Models;

public partial class Shelf
{
    public int? Code { get; set; }

    public int ShelfId { get; set; }

    public int? RackId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Rack? Rack { get; set; }
}
