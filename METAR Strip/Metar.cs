using System;
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

            
            //Connect();
            //return "METAR EPKT 210230Z 14006KT 3900 BR FEW005 SCT008 OVC022 M01 / M01 Q1026=";
        }

        
      
    }
}
