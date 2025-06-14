using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtUrlChecker : GxUserType, IGxExternalObject
   {
      public SdtUrlChecker( )
      {
         /* Constructor for serialization */
      }

      public SdtUrlChecker( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public GXExternalCollection<SdtUrlStatus> checkurls( GXExternalCollection<SdtUrlCheckItem> gxTp_urlItems )
      {
         GXExternalCollection<SdtUrlStatus> returncheckurls;
         if ( UrlChecker_externalReference == null )
         {
            UrlChecker_externalReference = new UrlValidator.UrlChecker();
         }
         returncheckurls = new GXExternalCollection<SdtUrlStatus>( context, "SdtUrlStatus", "GeneXus.Programs");
         System.Collections.Generic.List< UrlValidator.UrlStatus> externalParm0;
         System.Collections.Generic.List< UrlValidator.UrlCheckItem> externalParm1;
         externalParm1 = (System.Collections.Generic.List< UrlValidator.UrlCheckItem>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< UrlValidator.UrlCheckItem>), gxTp_urlItems.ExternalInstance);
         externalParm0 = UrlChecker_externalReference.CheckUrls(externalParm1);
         returncheckurls.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< UrlValidator.UrlStatus>), externalParm0);
         return returncheckurls ;
      }

      public SdtSummary getsummary( )
      {
         SdtSummary returngetsummary;
         if ( UrlChecker_externalReference == null )
         {
            UrlChecker_externalReference = new UrlValidator.UrlChecker();
         }
         returngetsummary = new SdtSummary(context);
         UrlValidator.Summary externalParm0;
         externalParm0 = UrlChecker_externalReference.GetSummary();
         returngetsummary.ExternalInstance = externalParm0;
         return returngetsummary ;
      }

      public Object ExternalInstance
      {
         get {
            if ( UrlChecker_externalReference == null )
            {
               UrlChecker_externalReference = new UrlValidator.UrlChecker();
            }
            return UrlChecker_externalReference ;
         }

         set {
            UrlChecker_externalReference = (UrlValidator.UrlChecker)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected UrlValidator.UrlChecker UrlChecker_externalReference=null ;
   }

}
