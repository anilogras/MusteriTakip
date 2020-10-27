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
    public class Fis : ITable
    {
        public Fis()
        {
            FisOzelliks = new List<FisOzellik>();
        }

        public int Id { get; set; }
        public int CariId { get; set; }
        public int UserId { get; set; }
        public double OnOdeme { get; set; }
        public string FisNot { get; set; }
        public bool Faturalandir { get; set; }
        public string FisKullanicisi { get; set; }
        public bool Silindimi { get; set; }
        public DateTime KayitTarihi { get; set; }

        public virtual List<FisOzellik> FisOzelliks { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual User User { get; set; }
    }
}
