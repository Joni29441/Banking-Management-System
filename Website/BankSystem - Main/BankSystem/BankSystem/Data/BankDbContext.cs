using System.Data.Entity;

namespace BankSystem.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext() : base("Data Source=.;User ID=JON;Password=joni1; Database=BankSystem; ")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configure model and relationships here
        }
    }

}