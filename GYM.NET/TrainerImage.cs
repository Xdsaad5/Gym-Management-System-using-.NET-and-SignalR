using System;
using System.Collections.Generic;

namespace GYM.NET;

public partial class TrainerImage
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual Trainer EmailNavigation { get; set; } = null!;
}
