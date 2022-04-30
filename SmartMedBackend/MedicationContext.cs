using BackEndSmartMed.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndSmartMed
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class MedicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MedicationContext(DbContextOptions<MedicationContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Gets or sets the medication items.
        /// </summary>
        /// <value>
        /// The medication items.
        /// </value>
        public DbSet<Medication> MedicationItems { get; set; }
    }
}
