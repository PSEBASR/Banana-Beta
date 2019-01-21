using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace Banana.Funciones
{
    public class Funciones
    {
        public  string Path()
        {
            return  "http://" + HttpContext.Current.Request.Url.Host+ ":" + HttpContext.Current.Request.Url.Port;
        }
        public string Idioma()
        {
            XDocument xmlConfig = XDocument.Load(new Banana.Funciones.Funciones().Path() + "/General/ServerConfiguracion.xml", LoadOptions.None);
            XElement RaizServer = xmlConfig.Element("Servers");
            IEnumerable<XElement> Lenguaje = RaizServer.Descendants("Configuracion");

            foreach (XElement Idioma in Lenguaje)
            {
                return Idioma.Element("Idioma").Value;
            }
            return "ES";
        }
        public string TranslateText(string varTexto, string idiomaZona)
        {
            string nombreIdioma = "";
            string frase = "";
            string varLocal = "";
            XDocument xmlIdioma = XDocument.Load(new Banana.Funciones.Funciones().Path() + "/Plugins/Idiomas.xml", LoadOptions.None);
            XElement RaizIdioma = xmlIdioma.Element("IdiomasP");
            IEnumerable<XElement> Idiomas = RaizIdioma.Descendants("Idioma");
            foreach (XElement Idioma in Idiomas)
            {
                nombreIdioma = Idioma.Element("Region").Value;
                varLocal = Idioma.Element("Var").Value;
                if (nombreIdioma == idiomaZona)
                {
                    if (varTexto == varLocal)
                    {
                        frase = Idioma.Element("Frase").Value;
                        return frase;
                    }
                    return varTexto;
                }
            }
            return varTexto;
          
        }
    }
}