using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie7.DTO;
using Zadanie7.Models;

namespace Zadanie7.Controllers
{
    [ApiController]
    public class tripsController : ControllerBase
    {
        private readonly S24777Context _context;

        public tripsController(S24777Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult get()
        {
            return Ok(_context.Trips
                .Include(e => e.ClientTrips)
                .ThenInclude(e => e.IdClientNavigation)
                .Select(e => new Trips
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Contries = e.IdCountries.Select(ee => new Countries {Name = ee.Name}).ToList(),
                    Clients = e.ClientTrips.Select(ee => new Clients {FirstName = ee.IdClientNavigation.FirstName, LastName = ee.IdClientNavigation.LastName})
                })
                .OrderByDescending(e => e.DateFrom)
                .ToList());
        }

        [HttpDelete]
        [Route("api/clients/{idClient}")]
        public ActionResult delete(int idClient)
        {
            if (_context.Clients.Any(e => e.IdClient == idClient))
            {
                Console.Write(_context.ClientTrips.Any(e => e.IdClient == idClient));
                if (_context.ClientTrips.Any(e => e.IdClient == idClient))
                {
                    return BadRequest("Client does have trips!");
                }
                else
                {
                    _context.Clients.Remove(_context.Clients.FirstOrDefault(e => e.IdClient == idClient));
                    _context.SaveChanges();
                    return Ok();
                }
            }
            else return BadRequest("Client doesn't exists!");
        }

        [HttpPost]
        [Route("api/trips/clients")]
        public ActionResult assign([FromBody] BodyClient bodyClient)
        {
            if (!_context.Clients.Any(e => e.Pesel == bodyClient.Pesel))
            {
                _context.Add(
                    new Client
                    {
                        FirstName = bodyClient.FirstName,
                        LastName = bodyClient.LastName,
                        Email = bodyClient.Email,
                        Telephone = bodyClient.Telephone,
                        Pesel = bodyClient.Pesel
                    });
                _context.SaveChanges();
            }

            var clnt = _context.Clients.Where(e => e.Pesel == bodyClient.Pesel).FirstOrDefault();
            if (_context.ClientTrips.Any(e => e.IdClient == clnt.IdClient && e.IdTrip == bodyClient.IdTrip)) 
                return BadRequest("Client is already assigned to this trip!");
            if (!_context.Trips.Any(e => e.IdTrip == bodyClient.IdTrip)) 
                return BadRequest("Trip doesn't exists!");
            DateTime? dt;
            if (bodyClient.paymentDate == "") dt = null;
            else
            {
                DateTime.TryParseExact(bodyClient.paymentDate, "M/d/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime pdt);
                dt = pdt;
            }
            _context.ClientTrips.Add(new ClientTrip
            {
                IdClient = clnt.IdClient,
                IdTrip = bodyClient.IdTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = dt
            });
            _context.SaveChanges();
            return Ok();
        }
    }
}
