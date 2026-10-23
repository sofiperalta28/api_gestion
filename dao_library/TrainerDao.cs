using System.Collections.Generic;
using System.Linq;
using entity_library; 

namespace dao_library
{
    public class TrainerDao
    {
        public Trainer? GetTrainer(Trainer trainer)
        {
            return MockDatabase.Trainers.FirstOrDefault(t => t.Id == trainer.Id);
        }
    
        public Trainer? PostTrainer(Trainer trainer)
        {
            if (trainer != null)
            {
                trainer.Id = MockDatabase.Trainers.Count + 1;
                MockDatabase.Trainers.Add(trainer);
                return trainer; 
            }
            return null;
        }
       
        public Trainer? PutTrainer(Trainer trainer)
        {
            var existingTrainer = MockDatabase.Trainers.Find(t => t.Id == trainer.Id);
            if (existingTrainer != null)
            {
                existingTrainer.Name = trainer.Name;
                existingTrainer.Dni = trainer.Dni;
                existingTrainer.Age = trainer.Age;
            }
            return null;
        }

        public List<Trainer> GetTrainers()
        {
            return MockDatabase.Trainers;
        }
      
        public bool DeleteTrainer(Trainer trainer)
        {
            var existingTrainer = MockDatabase.Trainers.Find(t => t.Id == trainer.Id);
            if (existingTrainer != null)
            {
                MockDatabase.Trainers.Remove(existingTrainer);
                return true; 
            }
            return false; 
        }
    }
}
