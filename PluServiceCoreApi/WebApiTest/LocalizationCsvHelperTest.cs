using ApiBusiness.Csv;


namespace ApiBusinessUnitTest
{
    public class Tests
    {
        private readonly LocalizationCsvHelper _localizationCsvHelper;

        public Tests()
        {
            _localizationCsvHelper = new LocalizationCsvHelper("Files/localization.csv");
        }

        //nel csv ci sono dei dati fake tipo sud sardegna non so perchè
        [Test]
        public void TestGetDistinctProvincesMethod()
        {
            var provinces = _localizationCsvHelper.GetDistinctProvince();
            Assert.AreEqual(provinces.Count(),107);
        }

        [Test]
        public void TestGetDistinctMunicipalitiesInProvinceMethod()
        {
            var municipalities = _localizationCsvHelper.GetDistinctMunicipalityInProvince("AN");
            Assert.AreEqual(municipalities.Count(), 47);
        }
    }
}