using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace MSAMISBackend {
    public class SQLConnector {

     
        public static bool IsSQLDeployed () {
           string value =  ConfigurationManager.AppSettings["IsSQLDeployed"] + "";
            if (!Boolean.Parse(value)) {
                return false;
            } else {
                return true;
            }
        }


    }
}
