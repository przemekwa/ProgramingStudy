using ProgramingStudy.Job;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProgramingStudyTests.Job
{
    public class PZLStructureTests
    {
        [Fact]
        public void AllGood()
        {
            var pzl = new PZLStructure();

            var list = new List<string>
            {
                "imie;nazwisko;stanowisko;przelozony;jednostkanadrzedna;email;login;NrDostawcy;NrOsobowy;kontoPLN;kontoEUR",
                "STANISŁAW;ABRAMOWICZ;Prezes;1;Firma;aaa@o2.pl;1;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Członek;1;Dział Lotny;aaa@o2.pl;2;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Manager;2;Dział Lotny;aaa@o2.pl;3;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Szef;3;Dział Lotny;aaa@o2.pl;4;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Pracownik;4;Dział Lotny;aaa@o2.pl;5;980001;3,9102E+25"
            };

            var fileName = "PZLStructureTestFile.csv";

            File.WriteAllLines(fileName, list);
            
            var result = pzl.GetRootNode(fileName);

            File.WriteAllText("test", TreeNode.BuildString(result));

            Assert.Equal("Zarząd\r\n Nieprzypisani\r\n Firma\r\n  Prezes\r\n   Dział Lotny\r\n    Członek\r\n     Manager\r\n      Szef\r\n       Pracownik\r\n", 
                File.ReadAllText("test"));
        }

    }
}
