using Microsoft.EntityFrameworkCore;

namespace BackEndSmartMed.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbContextMocker
    {
        /// <summary>
        /// Gets the medication context.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns></returns>
        public static MedicationContext GetMedicationContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<MedicationContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new MedicationContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
