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
    public class FisOzellik : ITable
    {

        public int Id { get; set; }

        public int FisId { get; set; }

        private double? fiyat;

        public string Tanim { get; set; }

        public int? Adet { get; set; }

        public string Aciklama { get; set; }

        public string Olcu { get; set; }

        public double? Fiyat
        {
            get
            {
                return fiyat;
            }
            set
            {
                if(value > 0)
                {
                    fiyat = value;
                }
                else
                {
                    fiyat = null;
                }
            }
        }

        public int? KDV { get; set; }

        public int Durum { get; set; }

        public virtual Fis Fis { get; set; }
    }
}
