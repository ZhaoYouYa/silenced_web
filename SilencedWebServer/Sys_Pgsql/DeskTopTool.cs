
using System.ComponentModel.DataAnnotations;
namespace Sys_Pgsql
{
	public class dpt_choice
	{

		/// <summary>
		/// 主键Id
		/// </summary>

		[Key]
		public int Id { get; set; }
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// 好的选择
		/// </summary>
		public int GoodChoice { get; set; }
		/// <summary>
		/// 坏的选择
		/// </summary>
		public int BadChoice { get; set; }
	}

	public class dpt_note
	{
		[Key]
		public DateTime Date { get; set; }
		public string? Content { get; set; }
	}
}