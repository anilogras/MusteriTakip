﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.KullaniciDtos
{
    public class KullaniciLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
