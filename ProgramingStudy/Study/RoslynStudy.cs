using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class RoslynStudy : IStudyTest
    {
        private const string scriptPath = "script.cs";

        public void Study()
        {
            if (!File.Exists(scriptPath))
            {
                throw new Exception("No file");
            }

            var sourceCode = File.ReadAllText(scriptPath);

            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(sourceCode));

            var assemblyPath = Path.ChangeExtension(Path.GetTempFileName(), "exe");

            var compilation = CSharpCompilation.Create(Path.GetFileName(assemblyPath))
                .WithOptions(new CSharpCompilationOptions(OutputKind.ConsoleApplication))
                .AddReferences(
                    MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location)
                    )
                .AddSyntaxTrees(syntaxTree);

            var result = compilation.Emit(assemblyPath);

            if (result.Success)
            {
                Process.Start(assemblyPath);
            }
            else
            {
                Debug.Write(string.Join(
                    Environment.NewLine,
                    result.Diagnostics.Select(diagnostic => diagnostic.ToString())
                ));
            }


        }
    }
}
