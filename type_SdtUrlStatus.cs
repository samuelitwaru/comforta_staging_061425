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
   public class SdtUrlStatus : GxUserType, IGxExternalObject
   {
      public SdtUrlStatus( )
      {
         /* Constructor for serialization */
      }

      public SdtUrlStatus( IGxContext context )
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

      public string gxTpr_Url
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference.Url ;
         }

         set {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            UrlStatus_externalReference.Url = value;
            SetDirty("Url");
         }

      }

      public string gxTpr_Affectedtype
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference.AffectedType ;
         }

         set {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            UrlStatus_externalReference.AffectedType = value;
            SetDirty("Affectedtype");
         }

      }

      public string gxTpr_Affectedname
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference.AffectedName ;
         }

         set {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            UrlStatus_externalReference.AffectedName = value;
            SetDirty("Affectedname");
         }

      }

      public int gxTpr_Statuscode
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference.StatusCode ;
         }

         set {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            UrlStatus_externalReference.StatusCode = value;
            SetDirty("Statuscode");
         }

      }

      public string gxTpr_Message
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference.Message ;
         }

         set {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            UrlStatus_externalReference.Message = value;
            SetDirty("Message");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( UrlStatus_externalReference == null )
            {
               UrlStatus_externalReference = new UrlValidator.UrlStatus();
            }
            return UrlStatus_externalReference ;
         }

         set {
            UrlStatus_externalReference = (UrlValidator.UrlStatus)(value);
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

      protected UrlValidator.UrlStatus UrlStatus_externalReference=null ;
   }

}
