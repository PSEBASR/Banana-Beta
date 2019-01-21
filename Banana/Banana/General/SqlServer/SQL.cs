using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace SQL
{
    
    public static class SQL
    {
        public static string CadenaSql()
        {
            XDocument xmlConfig = XDocument.Load(new Banana.Funciones.Funciones().Path() + "/General/ServerConfiguracion.xml", LoadOptions.None);
            XElement RaizServer = xmlConfig.Element("Servers");
            IEnumerable<XElement> Lenguaje = RaizServer.Descendants("SqlConfig");

            foreach (XElement Idioma in Lenguaje)
            {
                return Idioma.Element("Cadena").Value;
            }
            return "null";
        }

        public static SqlConnection cnn = new SqlConnection(CadenaSql());
        public static string Open()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            return "";
        }
        public static string Close()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "";
        }
    }

   
}