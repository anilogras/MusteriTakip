using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
    public class CariCep:ITable
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public string Cep { get; set; }
        public Cari Cari { get; set; }
    }
}
