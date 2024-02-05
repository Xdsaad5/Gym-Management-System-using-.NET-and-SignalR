using System.Collections.Specialized;

namespace GYM.NET.Models
{
	public class trainerRep
	{
		public bool alreadyExist(Trainer obj)
		{
			if (obj == null) return false;
			MyDbContext db = new MyDbContext();
			var data = db.Trainers.Where(x => x.Email == obj.Email).ToList();
			if (data.Count == 0)
				return false;
			return true;
		}

		public bool insertTrainer(Trainer obj)
		{
			if (obj == null)
				return false;
			try
			{
				MyDbContext db = new MyDbContext();
				var x = db.Trainers.Add(obj);
				db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
		public bool trainerVarification(Trainer obj)
		{
			if (obj == null) return false;
			try
			{
				MyDbContext db = new MyDbContext();
				var data = db.Trainers.Where(x => x.Email == obj.Email && x.Password == obj.Password).ToList();
				if (data.Count == 0)
					return false;
				return true;
			}
			catch { return false; }
		}
		public bool insertTrainerImages(TrainerImage obj)
		{
			try
			{
				MyDbContext db = new MyDbContext();
				var data = db.TrainerImages.Add(obj);
				db.SaveChanges();
				return true;
			}
			catch { return false; }
		}
		public bool insertTrainerVideo(TrainerVideo obj)
		{
			try
			{
				MyDbContext db = new MyDbContext();
				var data = db.TrainerVideos.Add(obj);
				db.SaveChanges();
				return true;
			}
			catch { return false; }
		}

        public List<Trainer> getTrainers()
        {
  
                MyDbContext db = new MyDbContext();
                List<Trainer> data = db.Trainers.ToList();
                return data;
       
        }

        public List<TrainerVideo> getTrainersVideos()
        {

            MyDbContext db = new MyDbContext();
            return (List<TrainerVideo>)db.TrainerVideos.ToList();


        }

    }
}
