namespace QueryableProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueryableCustom<string> provider = new FakeQueryableCustom<string>("", null);
            int result = provider.Where(x => x.Contains("substring"))
                .OrderBy(s => s != "some string")
                .Count();
        }
    }
}
