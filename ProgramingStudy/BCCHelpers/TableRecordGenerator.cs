using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.BCCHelpers
{
    internal class TableRecordGenerator : IStudyTest
    {
        public static class BlatChangesPurchasePrice
        {
            public const string TableName = "BlatChangesPurchasePrice";

            public const string ArticleName = "articleName";
            public const string ArticleNumber = "articleNumber";
            public const string Ekli = "EKLI";
            public const string Ekrk = "EKRK";
            public const string DayFinalPrice = "dayFinalPrice";
            public const string EkkzWawi = "EKKZ_WAWI";
            public const string DateFromWawi = "dateFrom_WAWI";
            public const string DateToWawi = "dateTo_WAWI";
            public const string EkliWawi = "EKLI_WAWI";
            public const string EkrkWawi = "EKRK_WAWI";
            public const string DateInputPrice = "dateInputPrice";
        }

        public void Study()
        {
            this.Generate();
        }

        private void Generate()
        {

            var className = $"TableRecord{nameof(BlatChangesPurchasePrice)}";
            var constClassName = nameof(BlatChangesPurchasePrice);


            using (var sw = new StreamWriter($"{className}.cs"))
            {

                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using System.Data.Common;");
                sw.WriteLine("using SelgrosPG.Common;");
                sw.WriteLine("using SelgrosPG.DAL.ORM.FieldDefinitions;");
                sw.WriteLine("using SelgrosPG.DAL.ORM.FieldValues;");
                sw.WriteLine("namespace SelgrosPG.DAL.ORM.TableRecords");
                sw.WriteLine("{");
                sw.WriteLine("[Serializable]");
                sw.WriteLine($"public sealed class {className}: TableRecord");
                sw.WriteLine("{");
                sw.WriteLine($"public {className}(Guid? logicalSystem) : base(logicalSystem)");
                sw.WriteLine("{");
                sw.WriteLine("}");
                sw.WriteLine();
                sw.WriteLine("public override string TableRecordId");
                sw.WriteLine("{");
                sw.WriteLine($" get  {{  return      \"{{{Guid.NewGuid().ToString()}}}\"  ;}}   ");
                sw.WriteLine(" }");
                sw.WriteLine();
                sw.WriteLine(" public override string TableName");
                sw.WriteLine(" {");
                sw.WriteLine($"  get {{ return Consts.TableRecord.{constClassName}.TableName; }}");
                sw.WriteLine(" }");
                sw.WriteLine();
                sw.WriteLine(" public override string MainValue");
                sw.WriteLine("{");
                sw.WriteLine($" get {{ return this[Consts.TableRecord.{constClassName}.IdColumnName].Value as string; }}");
                sw.WriteLine("}");
                sw.WriteLine();


                sw.WriteLine("protected override string IdColumnName");
                sw.WriteLine("{");
                sw.WriteLine($" get {{ return this[Consts.TableRecord.{constClassName}.IdColumnName].Value as string; }}");
                sw.WriteLine("}");
                sw.WriteLine();


                sw.WriteLine(" private static readonly List<FieldDefinition> FieldsDefinitionStatic;");
                sw.WriteLine(" private static readonly List<TableRelation> RelationsStatic;");
                sw.WriteLine();
                sw.WriteLine($" static {className}()");
                sw.WriteLine("  {");

                sw.WriteLine("FieldsDefinitionStatic = new List<FieldDefinition>");
                sw.WriteLine("\t\t\t{");

                foreach (var item in typeof(BlatChangesPurchasePrice).GetFields())
                {
                    sw.WriteLine($"\t\t\t\tnew FieldDefinitionText(Consts.TableRecord.{constClassName}.{item.Name}),");
                }

                sw.WriteLine("\t\t\t};");
                sw.WriteLine();
                sw.WriteLine("   RelationsStatic = new List<TableRelation>();");


                sw.WriteLine(" }");
                sw.WriteLine("public override IEnumerable<FieldDefinition> FieldsDefinition");
                sw.WriteLine("{");
                sw.WriteLine(" get { return FieldsDefinitionStatic; }");
                sw.WriteLine("}");
                sw.WriteLine();


                sw.WriteLine("protected override IEnumerable<TableRelation> Relations");
                sw.WriteLine(" {");
                sw.WriteLine(" get { return RelationsStatic; }");
                sw.WriteLine("}");
                sw.WriteLine();



                sw.WriteLine(" protected override bool HasIsDeletedColumn");
                sw.WriteLine("{");
                sw.WriteLine("  get { return false; }");
                sw.WriteLine("}");
                sw.WriteLine();

                sw.WriteLine("internal override bool HasLogicalSystemColumn");
                sw.WriteLine(" {");
                sw.WriteLine("   get { return false; }");
                sw.WriteLine(" }");
                sw.WriteLine();


                sw.WriteLine(" protected override bool HasTimeStampColumn");
                sw.WriteLine(" {");
                sw.WriteLine("get { return false; }");
                sw.WriteLine("}");
                sw.WriteLine();

                sw.WriteLine("   public override bool SaveModificationHistory");
                sw.WriteLine("{");
                sw.WriteLine(" get { return false; }");
                sw.WriteLine("}");

                foreach (var item in typeof(BlatChangesPurchasePrice).GetFields().Where(f => f.Name != "TableName"))
                {
                    sw.WriteLine();
                    sw.WriteLine($" public FieldValueText {item.Name}");
                    sw.WriteLine("  {");
                    sw.WriteLine(" get");
                    sw.WriteLine(" {");
                    sw.WriteLine($"return this[Consts.TableRecord.{constClassName}.{item.Name}] as FieldValueText;");
                    sw.WriteLine("}");
                    sw.WriteLine(" set");
                    sw.WriteLine(" {");
                    sw.WriteLine($"this[Consts.TableRecord.{constClassName}.{item.Name}] = value;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                }







                sw.WriteLine("}");
                sw.WriteLine("}");


            }
        }
    }
}
