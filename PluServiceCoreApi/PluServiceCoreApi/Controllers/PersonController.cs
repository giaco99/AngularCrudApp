using ApiBusiness.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PluServiceCoreApi.Data;
using PluServiceCoreApi.Models;

namespace PluServiceCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _context;

        private readonly TaxCodeGenerator _taxCodeGenerator;

        public PersonController(PersonDbContext context)
        {
            _context = context;
            _taxCodeGenerator = new TaxCodeGenerator();
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            var personList =  await _context.Persons.ToListAsync();
            return personList;
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x=>x.Id.Equals(id));
            return person == null ? NotFound() : Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                person.TaxCode = _taxCodeGenerator.GenerateTaxCode(
                    person.Name,
                    person.Surname,
                    person.Gender.Substring(0,1),
                    person.BirthDate,
                    person.BirthPlace,
                    person.Province,
                    0);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonById","Person", new { id = person.Id }, person);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePerson([FromRoute]Guid id, Person updatedPerson)
        {
            if (!id.Equals(updatedPerson.Id)) return BadRequest();

            var sourcePerson = await _context.Persons.FindAsync(id);
            if (sourcePerson == null)
                return NotFound();

            sourcePerson.Name = updatedPerson.Name;
            sourcePerson.Surname = updatedPerson.Surname;
            sourcePerson.BirthDate = updatedPerson.BirthDate;
            sourcePerson.BirthPlace = updatedPerson.BirthPlace;
            sourcePerson.Province = updatedPerson.Province;
            sourcePerson.Gender = updatedPerson.Gender;

            try
            {
                sourcePerson.TaxCode = _taxCodeGenerator.GenerateTaxCode(
                    sourcePerson.Name,
                    sourcePerson.Surname,
                    sourcePerson.Gender.Substring(0, 1),
                    sourcePerson.BirthDate,
                    sourcePerson.BirthPlace,
                    sourcePerson.Province,
                    0);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            //altro modo funzionante ..
            //_context.Entry(updatedPerson).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(sourcePerson);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            var personToDelete = await _context.Persons.FindAsync(id);
            if (personToDelete == null)
                return NotFound();

            _context.Persons.Remove(personToDelete);
            await _context.SaveChangesAsync();

            return Ok(personToDelete);
        }
    }
}
