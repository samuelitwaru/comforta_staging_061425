using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomainappnotificationcategory
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainappnotificationcategory ()
      {
         domain["Form"] = "Form";
         domain["Agenda"] = "Agenda";
         domain["Toolbox"] = "Toolbox";
         domain["Discussion"] = "Discussion";
         domain["General"] = "General";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Form"] = "Form";
            domainMap["Agenda"] = "Agenda";
            domainMap["Toolbox"] = "Toolbox";
            domainMap["Discussion"] = "Discussion";
            domainMap["General"] = "General";
         }
         return (string)domainMap[key] ;
      }

   }

}
