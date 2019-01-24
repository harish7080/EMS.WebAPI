using System.Data.Entity;
using EMS.Entity;
namespace EMS.Data
{
    public class EMSContext :DbContext
    {
        private const string ContextName = "EMSContext";

        public EMSContext()
            : base("name=" + ContextName)
        {
            Database.SetInitializer<EMSContext>(null);
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguage { get; set; }
        public DbSet<File> File { get; set; }
    }
}
