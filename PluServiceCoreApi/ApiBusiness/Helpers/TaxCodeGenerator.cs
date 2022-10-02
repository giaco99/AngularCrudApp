using mrk.fiscalcode;

namespace ApiBusiness.Helpers
{
    public class TaxCodeGenerator
    {
        //il sesso corrisponde ad m o f
        //province sarebbe il codice della provincia
        //omocodiacode se qualcuno ha il nostro stesso nome ed è nato lo stesso giorno , default 0

        public string GenerateTaxCode(
            string name,
            string surname,
            string gender,
            string birthDate,
            string municipality,
            string province,
            int omocodiaCode)
        {
           
            return new CodiceFiscale(surname, name, gender, Convert.ToDateTime(birthDate), municipality, province, omocodiaCode).Codice;
        }
    }
}
