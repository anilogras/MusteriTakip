using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.ReturnTypes
{
    public class BaseResult
    {
        public BaseResult()
        {
            Success = true;
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
