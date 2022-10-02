using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PluServiceCoreApi.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string BirthPlace { get; set; }

        public string Province { get; set; }
        
        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public string TaxCode { get; set; }
    }
}
