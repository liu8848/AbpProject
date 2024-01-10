using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace AbpProject.Domain.Entities;

[Table("test")]
public class TestModel:Entity<int>
{
    [Column("desc",TypeName = "varchar(10)")]
    public string Desc { get; set; }
}