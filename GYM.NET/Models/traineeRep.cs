namespace GYM.NET.Models
{
    public class traineeRep
    {
        public bool alreadyExist(Trainee obj)
        {
            if (obj == null) return false;
            MyDbContext db = new MyDbContext();
            var data = db.Trainees.Where(x => x.Username == obj.Username).ToList();
            if (data.Count == 0)
                return false;
            return true;
        }
        public bool insertTrainee(Trainee obj)
        {
            if (obj == null)
                return false;
            try
            {

                MyDbContext db = new MyDbContext();
                var x = db.Trainees.Add(obj);
                Console.WriteLine(x.ToString());
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool traineeVarification(Trainee obj)
        {
            if (obj == null) return false;
            try
            {
                MyDbContext db = new MyDbContext();
                var data = db.Trainees.Where(x => x.Username == obj.Username && x.Password == obj.Password).ToList();
                if (data.Count == 0)
                    return false;
                return true;
            }
            catch { return false; }
        }
    }
}
