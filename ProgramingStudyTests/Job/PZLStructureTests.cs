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

            var fileNameOut = "test";

            File.WriteAllText(fileNameOut, TreeNode.BuildString(result));

            Assert.Equal("Zarząd\r\n Nieprzypisani\r\n Firma\r\n  Prezes\r\n   Dział Lotny\r\n    Członek\r\n     Manager\r\n      Szef\r\n       Pracownik\r\n", 
                File.ReadAllText(fileNameOut));

            File.Delete(fileNameOut);
            File.Delete(fileName);

        }


         [Fact]
        public void AllGood_2_Person_One_Position()
        {
            var pzl = new PZLStructure();

            var list = new List<string>
            {
                "imie;nazwisko;stanowisko;przelozony;jednostkanadrzedna;email;login;NrDostawcy;NrOsobowy;kontoPLN;kontoEUR",
                "STANISŁAW;ABRAMOWICZ;Prezes;1;Firma;aaa@o2.pl;1;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Członek;1;Dział Lotny;aaa@o2.pl;2;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Manager;2;Dział Lotny;aaa@o2.pl;3;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Szef;3;Dział Lotny;aaa@o2.pl;4;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Pracownik;4;Dział Lotny;aaa@o2.pl;5;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Pracownik;4;Dział Lotny;aaa@o2.pl;6;980001;3,9102E+25"
            };

            var fileName = "PZLStructureTestFile_1.csv";

            File.WriteAllLines(fileName, list);
            
            var result = pzl.GetRootNode(fileName);

             var fileNameOut = "test_1";

            File.WriteAllText(fileNameOut, TreeNode.BuildString(result));

            Assert.Equal("Zarząd\r\n Nieprzypisani\r\n Firma\r\n  Prezes\r\n   Dział Lotny\r\n    Członek\r\n     Manager\r\n      Szef\r\n       Pracownik\r\n", 
                File.ReadAllText(fileNameOut));

             File.Delete(fileNameOut);
             File.Delete(fileName);
        }

           [Fact]
        public void AllGood_2_Bosses_With_Employee()
        {
            var pzl = new PZLStructure();

            var list = new List<string>
            {
                "imie;nazwisko;stanowisko;przelozony;jednostkanadrzedna;email;login;NrDostawcy;NrOsobowy;kontoPLN;kontoEUR",
                "STANISŁAW;ABRAMOWICZ;Prezes;1;Firma;aaa@o2.pl;1;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Członek;1;Dział Lotny;aaa@o2.pl;2;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Manager;2;Dział Lotny;aaa@o2.pl;3;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Szef;3;Dział Pracowników;aaa@o2.pl;4;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Szef równożędny;3;Dział Pracowników;aaa@o2.pl;7;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Pracwonik równożegfny;7;Dział Pracowników;aaa@o2.pl;8;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Pracownik;4;Dział Pracowników;aaa@o2.pl;5;980001;3,9102E+25",
                "STANISŁAW;ABRAMOWICZ;Starszy Pracownik;4;Dział Pracowników;aaa@o2.pl;6;980001;3,9102E+25",
             
            };

            var fileName = "PZLStructureTestFile_3.csv";

            File.WriteAllLines(fileName, list);
            
            var result = pzl.GetRootNode(fileName);

             var fileNameOut = "test_3";

            File.WriteAllText(fileNameOut, TreeNode.BuildString(result));


            var d =  File.ReadAllText(fileNameOut);

            Assert.Equal("Zarząd\r\n Nieprzypisani\r\n Firma\r\n  Prezes\r\n   Dział Lotny\r\n    Członek\r\n     Manager\r\n      Dział Pracowników\r\n       Szef\r\n        Pracownik\r\n        Starszy Pracownik\r\n       Szef równożędny\r\n        Pracwonik równożegfny\r\n", 
                File.ReadAllText(fileNameOut));

             File.Delete(fileNameOut);
             File.Delete(fileName);
        }

    }
}
