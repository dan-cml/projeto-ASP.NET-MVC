using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos___ASP.NET_MVC.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}