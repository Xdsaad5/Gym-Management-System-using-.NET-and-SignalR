using System;
using System.Collections.Generic;

namespace GYM.NET;

public partial class Trainee
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Age { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string? AssignedTrainer { get; set; }

    public virtual Trainer? AssignedTrainerNavigation { get; set; }
}
