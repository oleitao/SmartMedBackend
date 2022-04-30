using BackEndSmartMed.Models;
using System;
using System.Linq;

namespace BackEndSmartMed.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public static class InitialData
    {
        /// <summary>
        /// Seeds the specified database context.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public static void Seed(this MedicationContext dbContext)
        {
            if (!dbContext.MedicationItems.Any())
            {
                dbContext.MedicationItems.Add(new Medication
                {
                    Name = "medication1",
                    Quantity = 1,
                    CreationDate = DateTime.Now
                });

                dbContext.MedicationItems.Add(new Medication
                {
                    Name = "medication2",
                    Quantity = 10,
                    CreationDate = DateTime.Now
                });

                dbContext.SaveChanges();
            }
        }
    }
}
