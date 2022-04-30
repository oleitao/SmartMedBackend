using BackEndSmartMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndSmartMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        /// <summary>
        /// The company context
        /// </summary>
        private MedicationContext _companyContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationController"/> class.
        /// </summary>
        /// <param name="companyContext">The company context.</param>
        public MedicationController(MedicationContext companyContext)
        {
            _companyContext = companyContext;
        }

        // GET: api/<MedicationController>
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Medication> Get()
        {
            return _companyContext.MedicationItems;
        }

        // GET api/<MedicationController>/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Medication Get(int id)
        {
            return _companyContext.MedicationItems.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<MedicationController>
        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] Medication value)
        {
            _companyContext.MedicationItems.Add(value);
            _companyContext.SaveChanges();
        }

        // PUT api/<MedicationController>/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Medication value)
        {
            var medication = _companyContext.MedicationItems.FirstOrDefault(s => s.Id == id);
            if (medication != null)
            {
                value.Id = medication.Id;
                _companyContext.Entry<Medication>(medication).CurrentValues.SetValues(value);
                _companyContext.SaveChanges();
            }
        }

        // DELETE api/<MedicationController>/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var medication = _companyContext.MedicationItems.FirstOrDefault(s => s.Id == id);
            if (medication != null)
            {
                _companyContext.MedicationItems.Remove(medication);
                _companyContext.SaveChanges();
            }
        }
    }
}
