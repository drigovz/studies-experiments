using Api.Infra.Data.Context;

namespace Api.Infra.Data.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Database.EnsureCreated())
                    context.Database.EnsureCreated();
            }
        }
    }
}
