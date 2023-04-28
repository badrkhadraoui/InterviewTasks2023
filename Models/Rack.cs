using System;
using System.Collections.Generic;

namespace InterviewTasks2023.Models;

public partial class Rack
{
    public int? Code { get; set; }

    public int RackId { get; set; }

    public virtual ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}
