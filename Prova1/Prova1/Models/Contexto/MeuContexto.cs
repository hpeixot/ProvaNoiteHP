using System.Data.Entity;

namespace Web.Models.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<Prova1.Models.Personagens> Personagens { get; set; }
    }
}