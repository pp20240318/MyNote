using SqlSugar;

namespace MyNote.Model
{
   // [SugarTable("Student", "学生", IsDisabledUpdateAll = false)]//IsDisabledUpdateAll表示不更新这个表
    public class Student : ModelBase
    {
        //数据是自增需要加上IsIdentity 
        //数据库是主键需要加上IsPrimaryKey 
        //注意：要完全和数据库一致2个属性
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        //[SugarColumn(OldColumnName = "Name4")]
        public string? Name { get; set; }
    }
}
