using System;
using System.Collections.Generic;

namespace GYM.NET;

public partial class TrainerVideo
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? VideoUrl { get; set; }

    public virtual Trainer EmailNavigation { get; set; } = null!;
}
