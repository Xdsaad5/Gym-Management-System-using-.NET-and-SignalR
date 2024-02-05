using System;
using System.Collections.Generic;

namespace GYM.NET;

public partial class Trainer
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Speciality { get; set; }

    public string? Experience { get; set; }

    public string? ParticipatedInAnyCompetition { get; set; }

    public int ConsultFee { get; set; }

    public string MobileNumber { get; set; } = null!;

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();

    public virtual ICollection<TrainerImage> TrainerImages { get; set; } = new List<TrainerImage>();

    public virtual ICollection<TrainerVideo> TrainerVideos { get; set; } = new List<TrainerVideo>();
}
