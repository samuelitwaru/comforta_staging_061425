using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainpagetype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainpagetype ()
      {
         domain["Menu"] = "Menu";
         domain["Content"] = "Content";
         domain["WebLink"] = "Web Link";
         domain["DynamicForm"] = "Dynamic Form";
         domain["Calendar"] = "Calendar";
         domain["MyActivity"] = "My Activity";
         domain["Map"] = "Map";
         domain["Reception"] = "Reception";
         domain["Location"] = "Location";
         domain["MyCare"] = "My Care";
         domain["MyLiving"] = "My Living";
         domain["MyService"] = "My Service";
         domain["Information"] = "Information";
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
            domainMap["Menu"] = "Menu";
            domainMap["Content"] = "Content";
            domainMap["WebLink"] = "WebLink";
            domainMap["DynamicForm"] = "DynamicForm";
            domainMap["Calendar"] = "Calendar";
            domainMap["MyActivity"] = "MyActivity";
            domainMap["Map"] = "Map";
            domainMap["Reception"] = "Reception";
            domainMap["Location"] = "Location";
            domainMap["MyCare"] = "MyCare";
            domainMap["MyLiving"] = "MyLiving";
            domainMap["MyService"] = "MyService";
            domainMap["Information"] = "Information";
         }
         return (string)domainMap[key] ;
      }

   }

}
