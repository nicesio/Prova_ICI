using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data
{
  public class ContextoPrincipal : DbContext
  {
    const string CONNECTION_STRING = @"Server=(localdb)\mssqllocaldb;Database=provacandidato;Trusted_Connection=True;";
    public ContextoPrincipal() : base(CONNECTION_STRING) {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Cidade> Cidades { get; set; }

    public DbSet<ClienteObservacao> ClienteObservacoes { get; set; }
  }
}
