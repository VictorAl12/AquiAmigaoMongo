﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Model
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
    }
}
