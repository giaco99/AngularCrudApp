using ApiBusiness.Models;

namespace ApiBusiness.Csv
{
    public class LocalizationCsvHelper
    {
        private readonly string _csvFilePath;

        private readonly List<LocalizationDto> _localizationList;
        public LocalizationCsvHelper(string filepath)
        {
            _csvFilePath = filepath;
            _localizationList = ReadCsvFile();
        }
        
        public IEnumerable<string> GetDistinctProvince()
        {
            return _localizationList.DistinctBy(x => x.Province).ToList().Select(o => o.Province).ToList();
        }

        public IEnumerable<string> GetDistinctMunicipalityInProvince(string province)
        {
            return _localizationList.Where(x => x.Province.Equals(province))
                .Select(o => o.Municipality).ToList();
        }

        private List<LocalizationDto> ReadCsvFile()
        {
            var dtoList = new List<LocalizationDto>();
            var lines = File.ReadAllLines(_csvFilePath).ToList();
            lines.ForEach(x =>
                dtoList.Add(new LocalizationDto()
                {
                    Region = x.Split(";")[0],
                    Province = x.Split(";")[1],
                    Municipality = x.Split(";")[2]
                }));

            return dtoList;
        }
    }
}
