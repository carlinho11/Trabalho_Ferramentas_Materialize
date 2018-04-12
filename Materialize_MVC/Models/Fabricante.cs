using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho4_MVC.Models
{
    public class Fabricante
    {
        public long FabricanteID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}