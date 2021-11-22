

internal class Lambda : IStudyTest
{
    public void Study()
    {
        Func<string> test = () => "Przemek";
        var test2 = () => "Przemek";
    }
}


