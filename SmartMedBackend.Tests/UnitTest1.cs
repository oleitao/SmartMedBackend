using BackEndSmartMed.Controllers;
using BackEndSmartMed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BackEndSmartMed.Tests
{
    public class UnitTest1
    {
        #region Constants

        const string CONNECTION_STRING = "Data Source=DESKTOP-SHSQU9Q;Integrated Security=True";

        const string ADDED_MEDICATION = "Added Medication1";
        const int EDITED_MEDICATION = 1000;

        #endregion

        #region IsolatedTests
        [Fact]
        public async Task GetMedication()
        {
            var dbContext = DbContextMocker.GetMedicationContext(nameof(GetMedication));
            var controller = new MedicationController(dbContext);

            var result = controller.Get();
            Assert.True(result.Count() > 0);

            dbContext.Dispose();
        }

        [Fact]
        public async Task AddMedication()
        {
            var dbContext = DbContextMocker.GetMedicationContext(nameof(AddMedication));
            var controller = new MedicationController(dbContext);

            controller.Post(new Medication { Name= ADDED_MEDICATION, Quantity=1, CreationDate=DateTime.Now });

            Assert.True(controller.Get().Where(x => x.Name.Equals(ADDED_MEDICATION)).FirstOrDefault() != null);

            dbContext.Dispose();
        }

        [Fact]
        public async Task EditMedication()
        {
            var dbContext = DbContextMocker.GetMedicationContext(nameof(EditMedication));
            var controller = new MedicationController(dbContext);

            var item = controller.Get().FirstOrDefault();
            item.Quantity = EDITED_MEDICATION;

            controller.Put(item.Id, item);
            
            Assert.True(controller.Get().Where(x => x.Id.Equals(item.Id)).FirstOrDefault().Quantity.Equals(EDITED_MEDICATION));

            dbContext.Dispose();
        }

        [Fact]
        public async Task DeleteMedication()
        {
            var dbContext = DbContextMocker.GetMedicationContext(nameof(DeleteMedication));
            var controller = new MedicationController(dbContext);

            var item = controller.Get().FirstOrDefault();
            controller.Delete(item.Id);

            Assert.False(controller.Get().Where(x => x.Id.Equals(item.Id)).Count() > 0);

            dbContext.Dispose();
        }

        #endregion

        #region DatabaseTests

        [Fact]
        public async Task GetMedicationDatabase()
        {
            MedicationContext dbContext = DBContext();

            var controller = new MedicationController(dbContext);

            var result = controller.Get();
            Assert.True(result.Count() > 0);

            dbContext.Dispose();

        }

        [Fact]
        public async Task AddMedicationDatabase()
        {
            MedicationContext dbContext = DBContext();
            var controller = new MedicationController(dbContext);

            controller.Post(new Medication { Name = ADDED_MEDICATION, Quantity = 1, CreationDate = DateTime.Now });

            Assert.True(controller.Get().Where(x => x.Name.Equals(ADDED_MEDICATION)).FirstOrDefault() != null);

            dbContext.Dispose();
        }

        [Fact]
        public async Task EditMedicationDatabase()
        {
            MedicationContext dbContext = DBContext();
            var controller = new MedicationController(dbContext);

            var item = controller.Get().FirstOrDefault();
            item.Quantity = EDITED_MEDICATION;

            controller.Put(item.Id, item);

            Assert.True(controller.Get().Where(x => x.Id.Equals(item.Id)).FirstOrDefault().Quantity.Equals(EDITED_MEDICATION));

            dbContext.Dispose();
        }

        [Fact]
        public async Task DeleteMedicationDatabase()
        {
            MedicationContext dbContext = DBContext();
            var controller = new MedicationController(dbContext);

            var item = controller.Get().FirstOrDefault();
            controller.Delete(item.Id);

            Assert.False(controller.Get().Where(x => x.Id.Equals(item.Id)).Count() > 0);

            dbContext.Dispose();
        }

        #endregion

        private MedicationContext DBContext()
        {
            var options = new DbContextOptionsBuilder<MedicationContext>()
                .UseSqlServer(CONNECTION_STRING)
                .Options;

            return new MedicationContext(options);
        }
    }
}
