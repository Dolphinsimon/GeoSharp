using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GeoSharp.SqLiteImpl
{
    //public class SQLiteDb
    //{
    //    string _path;
    //    public SQLiteDb(string path)
    //    {
    //        _path = path;
    //    }

    //     public void Create()
    //    {
    //        using (SQLiteConnection db = new SQLiteConnection(_path))
    //        {

    //        }
    //    }
    //}
    public partial class GeoSharpSQLiteEntities : DbContext
    {
        public GeoSharpSQLiteEntities()
            : base("name=GeoSharpSQLiteEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<ISO3166_2_156> ISO3166_2_156 { get; set; }
        public virtual DbSet<ISO3166> ISO3166Set { get; set; }
        public virtual DbSet<ISO3166_1_ALPHA_2> ISO3166_1_ALPHA_2 { get; set; }
        public virtual DbSet<ISO3166_1_ALPHA_3> ISO3166_1_ALPHA_3 { get; set; }
        public virtual DbSet<ISO3166_1_NUMERIC> ISO3166_1_NUMERIC { get; set; }
        public virtual DbSet<ISO3166_2> ISO3166_2 { get; set; }
        public virtual DbSet<ISO3166_3> ISO3166_3 { get; set; }
    }
}
