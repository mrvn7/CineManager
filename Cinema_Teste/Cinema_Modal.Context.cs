namespace Cinema_Teste
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaEntities : DbContext
    {
        public CinemaEntities()
            : base("name=CinemaEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Filme> Filme { get; set; }
    }
}
