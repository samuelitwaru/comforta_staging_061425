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
   public class SdtUrlCheckItem : GxUserType, IGxExternalObject
   {
      public SdtUrlCheckItem( )
      {
         /* Constructor for serialization */
      }

      public SdtUrlCheckItem( IGxContext context )
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
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            return UrlCheckItem_externalReference.Url ;
         }

         set {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            UrlCheckItem_externalReference.Url = value;
            SetDirty("Url");
         }

      }

      public string gxTpr_Affectedtype
      {
         get {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            return UrlCheckItem_externalReference.AffectedType ;
         }

         set {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            UrlCheckItem_externalReference.AffectedType = value;
            SetDirty("Affectedtype");
         }

      }

      public string gxTpr_Affectedname
      {
         get {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            return UrlCheckItem_externalReference.AffectedName ;
         }

         set {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            UrlCheckItem_externalReference.AffectedName = value;
            SetDirty("Affectedname");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( UrlCheckItem_externalReference == null )
            {
               UrlCheckItem_externalReference = new UrlValidator.UrlCheckItem();
            }
            return UrlCheckItem_externalReference ;
         }

         set {
            UrlCheckItem_externalReference = (UrlValidator.UrlCheckItem)(value);
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

      protected UrlValidator.UrlCheckItem UrlCheckItem_externalReference=null ;
   }

}
