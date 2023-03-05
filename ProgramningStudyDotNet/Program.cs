

//Top-level statments from c# 9 in .NET 5 in VS 2019

Console.WriteLine("Blog programisty .NET");

var assembly = typeof(IStudyTest).Assembly;

var type = assembly
    .GetTypes()
    .Select(p =>
    new
    {
        Attribute = p.CustomAttributes.Where(s => s.AttributeType == typeof(ExecuteAttribute)),
        Type = p
    })
    .Where(s => s.Attribute.Any())
    .OrderByDescending(s => ((ExecuteAttribute)Attribute.GetCustomAttribute(s.Type, typeof(ExecuteAttribute))).ExecuteDateTime)
    .First();

var studyTest = (IStudyTest)Activator.CreateInstance(type.Type);

studyTest.Study();