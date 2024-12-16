using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat
{
     public class Kunde
    {
     public int Id { get; set; }
     public string AccountNummer { get; set; }
     public string PIN { get; set; }
     public decimal Kontostand { get; set; }
    }
}
