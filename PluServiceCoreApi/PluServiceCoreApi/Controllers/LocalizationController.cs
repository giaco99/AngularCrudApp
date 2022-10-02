using ApiBusiness.Csv;
using Microsoft.AspNetCore.Mvc;

namespace PluServiceCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly LocalizationCsvHelper _localizationCsvHelper;
        public LocalizationController()
        {
            _localizationCsvHelper = new LocalizationCsvHelper("Files/localization.csv");
        }

        [HttpGet]
        public IEnumerable<string> GetAllPersons()
        {
            return _localizationCsvHelper.GetDistinctProvince();
        }

        [HttpGet]
        [Route("{province}")]
        public IEnumerable<string> GetPersonById([FromRoute] string province)
        {
            return _localizationCsvHelper.GetDistinctMunicipalityInProvince(province);
        }
    }
}
