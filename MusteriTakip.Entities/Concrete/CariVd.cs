using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
    public class CariVd:ITable
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public string Unvan { get; set; }
        public string VDNo { get; set; }
        public string VdDairesi { get; set; }
        public virtual Cari Cari { get; set; }
    }
}
