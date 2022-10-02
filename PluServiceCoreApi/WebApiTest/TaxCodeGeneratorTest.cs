using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBusiness.Helpers;

namespace ApiBusinessUnitTest
{
    internal class TaxCodeGeneratorTest
    {
        private readonly TaxCodeGenerator _taxCodeGenerator;

        public TaxCodeGeneratorTest()
        {
            _taxCodeGenerator = new TaxCodeGenerator();
        }

        //nel csv ci sono dei dati fake tipo sud sardegna non so perchè
        [Test]
        public void TestGenerateTaxCode()
        {
            var code = _taxCodeGenerator.GenerateTaxCode(
                "emanuele",
                "giacomi",
                "m",
                "05/08/1999",
                "Fano",
                "PU",
                0);

            Assert.AreEqual("GCMMNL99M05D488W",code);
        }
    }
}
