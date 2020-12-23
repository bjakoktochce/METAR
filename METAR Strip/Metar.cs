﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

using System.Net.Http;



namespace Metar_Strip
{
    public class Metar
    {
        public static String GetCurrentMetar()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load("https://aviationweather-cprk.ncep.noaa.gov/metar/data?ids=epkt&format=raw&date=&hours=0");

            HtmlAgilityPack.HtmlNode t = document.DocumentNode.SelectSingleNode("//code");

           

            return t.InnerText;

            
           
        }

        
      
    }
}
