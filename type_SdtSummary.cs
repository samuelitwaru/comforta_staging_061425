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
   public class SdtSummary : GxUserType, IGxExternalObject
   {
      public SdtSummary( )
      {
         /* Constructor for serialization */
      }

      public SdtSummary( IGxContext context )
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

      public int gxTpr_Totalurls
      {
         get {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            return Summary_externalReference.TotalUrls ;
         }

         set {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            Summary_externalReference.TotalUrls = value;
            SetDirty("Totalurls");
         }

      }

      public int gxTpr_Totalsuccess
      {
         get {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            return Summary_externalReference.TotalSuccess ;
         }

         set {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            Summary_externalReference.TotalSuccess = value;
            SetDirty("Totalsuccess");
         }

      }

      public int gxTpr_Totalfailed
      {
         get {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            return Summary_externalReference.TotalFailed ;
         }

         set {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            Summary_externalReference.TotalFailed = value;
            SetDirty("Totalfailed");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Summary_externalReference == null )
            {
               Summary_externalReference = new UrlValidator.Summary();
            }
            return Summary_externalReference ;
         }

         set {
            Summary_externalReference = (UrlValidator.Summary)(value);
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

      protected UrlValidator.Summary Summary_externalReference=null ;
   }

}
