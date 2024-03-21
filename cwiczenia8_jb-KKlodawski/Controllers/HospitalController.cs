using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie8.DTO;
using Zadanie8.models;

namespace Zadanie8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly S24777Context _context;

        public HospitalController(S24777Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("doctor/get")]
        public ActionResult getDoc()
        {
            if (!_context.Doctors.Any())
                return BadRequest("There are no doctors!");
            else
            {
               return Ok(_context.Doctors
                           .Select(e => new Doctors
                           {
                               FirstName = e.FirstName,
                               LastName = e.LastName,
                               Email = e.Email
                           })
                       ); 
            }
            
        }

        [HttpPost]
        [Route("doctor/add")]
        public ActionResult addDoc([FromBody] Doctors doctor)
        {
            _context.Add(new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
            _context.SaveChanges();
            return Ok("Doctor added successfully");
        }

        [HttpPost]
        [Route("doctor/modify")]
        public ActionResult modifyDoc([FromHeader] int idDoctor,[FromBody] Doctors doctor)
        {
            if (!_context.Doctors.Any(e => e.IdDoctor == idDoctor))
                return BadRequest("Doctor with given id doesn't exists!");
            else
            {
                var doc = _context.Doctors.FirstOrDefault(e => e.IdDoctor == idDoctor);
                doc.Email = doctor.Email;
                doc.FirstName = doctor.FirstName;
                doc.LastName = doctor.LastName;
                _context.Doctors.Update(doc);
                _context.SaveChanges();
                return Ok($"Doctor {doc.IdDoctor} has been modified!");
            }

            
        }

        [HttpDelete]
        [Route("doctor/delete")]
        public ActionResult deleteDoc([FromHeader] int idDoctor)
        {
            if (!_context.Doctors.Any(e => e.IdDoctor == idDoctor))
                return BadRequest("Doctor with given id doesn't exists!");
            else
            {
                _context.Remove(_context.Doctors.FirstOrDefault(e => e.IdDoctor == idDoctor));
                _context.SaveChanges();
                return Ok($"Doctor {idDoctor} has been removed!");
            }
            
        }

        [HttpPost]
        [Route("prescription/get")]
        public ActionResult getRec([FromBody] PresFind data)
        {
            if (!_context.Doctors.Any(e => e.FirstName == data.DoctorFirstName && e.LastName == data.DoctorLastName ))
                return BadRequest("Given doctor doesn't exists!");
            else if (!_context.Patients.Any(e => e.FirstName == data.PatientFirstName && e.Lastname == data.PatientLastName))
                return BadRequest("Given patient doesn't exists!");
            else
            {
                foreach(string s in data.Medicament) Console.WriteLine(s);
                var pres = _context.Prescriptions
                    .Include(e => e.Doctor)
                    .Include(e => e.Patient)
                    .Include(e => e.PrescriptionMedicaments)
                    .ThenInclude(ee => ee.IdMedicamentNavigation)
                    .FirstOrDefault(e =>
                        e.Doctor.FirstName == data.DoctorFirstName && e.Doctor.LastName == data.DoctorLastName &&
                        e.Patient.FirstName == data.PatientFirstName && e.Patient.Lastname == data.PatientFirstName &&
                        e.PrescriptionMedicaments.All(ee => data.Medicament.Contains(ee.IdMedicamentNavigation.Name)));
                if (pres != null)
                {
                     var presf = new Presciptions { IdPresscription = pres.IdPresscription, Date = pres.Date, DateDue = pres.DateDue }; 
                     return Ok(presf); 
                }
                else
                    return NotFound("Prescription not found!");
                
            }
            
        }
        
    }
}