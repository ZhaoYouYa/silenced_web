using Microsoft.EntityFrameworkCore;
namespace Sys_Pgsql
{
	public class PgContext:DbContext
	{
		//public PgContext(DbContextOptions<PgContext> options) : base(options)
		//{
		//}
		public PgContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<PgContext>();		
			OnConfiguring(optionsBuilder);
		}
		public PgContext(string connectionstring)
		{
			_connection_string = connectionstring;
			var optionsBuilder = new DbContextOptionsBuilder<PgContext>();
			OnConfiguring(optionsBuilder);

		}
		private static string _connection_string = "Host=212.129.223.183;Port=5433;Username=postgres;Password=Yuanmo520...;Database=Silenced;";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_connection_string);

		}

		public DbSet<dpt_choice>? dpt_choice{ get; set; }
		public DbSet<dpt_note>? dpt_note { get; set; }

	}
}
