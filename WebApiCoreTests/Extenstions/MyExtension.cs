namespace WebApiCoreTests.Extenstions
{
    public static class MyExtension
    {
        public static void AddMyExtension(this IServiceCollection services, Action<MyExtensionsOptions>? options)
        {
            var opt = new MyExtensionsOptions
            {
                Age = 38
            };


            options.Invoke(opt);

            services.Configure(options);

        }
    }


    public class MyExtensionsOptions
    {
        public int Age { get; set; }
        public string Prefix { get; set; }
    }
}
