using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Entities.Concrete
{
    public class Cari:ITable
    {

        public Cari()
        {
            Fislers = new List<Fis>();
            CariAdreslers = new List<CariAdres>();

            CariCeps = new List<CariCep>();
            CariEMails = new List<CariEMail>();
            CariFaxes = new List<CariFax>();
            CariTelefons = new List<CariTelefon>();
            CariWebSites = new List<CariWebSite>();
        }

        public int Id { get; set; }
        public string IsletmeAdi { get; set; }
        public string IsletmeYetkilisi { get; set; }
        public bool Aktif { get; set; }

        public string Aciklama { get; set; }

        public virtual List<Fis> Fislers { get; set; }
        public virtual List<CariAdres> CariAdreslers { get; set; }
        public virtual CariVd CariVd { get; set; }



        public virtual List<CariCep> CariCeps { get; set; }
        public virtual List<CariEMail> CariEMails { get; set; }
        public virtual List<CariFax> CariFaxes { get; set; }
        public virtual List<CariTelefon> CariTelefons { get; set; }
        public virtual List<CariWebSite> CariWebSites { get; set; }

    }
}
