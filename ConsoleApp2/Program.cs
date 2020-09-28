using System.Threading.Tasks;
using Clinique.EntityFramework.Seed;
using Clinique.EntityFramework;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CliniqueDbContextFactory cliniqueDbContextFactory = new CliniqueDbContextFactory();

            Clinique.EntityFramework.Seed.SeedData seedData = new SeedData(cliniqueDbContextFactory);
            seedData.InsertData();
            Thread.Sleep(4000);
            seedData.InsertData2();
            Thread.Sleep(4000);
            seedData.InsertData3();
            Thread.Sleep(4000);
            seedData.InsertData4();
            Thread.Sleep(4000);
            seedData.InsertData5();
        }
    }
}
