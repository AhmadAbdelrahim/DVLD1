﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD1.Global_Classes
{
    public class clsFormat
    {
        public static string DateToShort(DateTime dt1)
        {
            return dt1.ToString("dd/MMM/yyyy");
        }
    }
}
