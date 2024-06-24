namespace PatientPortal.Database
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    public static class DataSeeder
    {
        //Seed Method
        
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Patients.Any())
            {
                var random = new Random();
                var patients = new List<Patient>();
                for (int i = 0; i < 10; i++)
                {
                    patients.Add(new Patient()
                    {
                        Id = i + 1,
                        Name = $"Patient {i + 1}",
                        Age = random.Next(1, 100)
                    });
                }

                //Using Transaction is required
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Patients] ON");
                        context.Patients.AddRange(patients);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Patients] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
                
            }
        }

    }
}
