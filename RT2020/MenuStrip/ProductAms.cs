﻿using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.MenuStrip
{
    public static class ProductAms
    {
        public static MenuItem GetLoyatyAms()
        {
            MenuItem result = new MenuItem();

            result = AmsBase.FillAms("Product");

            return result;
        }
    }
}