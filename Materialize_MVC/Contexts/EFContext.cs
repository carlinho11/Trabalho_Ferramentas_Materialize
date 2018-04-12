using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho4_MVC.Models;
using System.Data.Entity;

namespace Trabalho4_MVC.Contexts
{
    public class EFContext : DbContext //estende de DbContext
    {

        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        } /*este construtor estende ao contrutor da classe base.
        O argumento refere-se ao nome da connection string definida no arquivo Web.config */

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
