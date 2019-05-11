using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Morais.Core.Util.Constantes
{
    public class ConstantesSistema
    {
        public static string MONGODBCONEXAO = ConfigurationManager.AppSettings["MongoDBConnectionString"];
        public static string MONGODBDATABASE = ConfigurationManager.AppSettings["MongoDBBase"];
    }
}