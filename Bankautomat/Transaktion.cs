using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat
{
    internal class Transaktion
    {
     public int Id { get; set; }
     public int KundenId { get; set; }
     public Kunde Kunde { get; set; }
     public DateTime Datum { get; set; }
     public decimal Menge { get; set; }
     public string TransaktionsTyp { get; set; }
    }
}
