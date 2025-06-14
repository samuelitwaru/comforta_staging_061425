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
   public class SdtQRCodeLibrary : GxUserType, IGxExternalObject
   {
      public SdtQRCodeLibrary( )
      {
         /* Constructor for serialization */
      }

      public SdtQRCodeLibrary( IGxContext context )
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

      public string generateqrcode( string gxTp_inputString )
      {
         string returngenerateqrcode;
         if ( QRCodeLibrary_externalReference == null )
         {
            QRCodeLibrary_externalReference = new QRCodeLibrary.QRCodeLibrary();
         }
         returngenerateqrcode = "";
         returngenerateqrcode = (string)(QRCodeLibrary_externalReference.GenerateQRCode(gxTp_inputString));
         return returngenerateqrcode ;
      }

      public Object ExternalInstance
      {
         get {
            if ( QRCodeLibrary_externalReference == null )
            {
               QRCodeLibrary_externalReference = new QRCodeLibrary.QRCodeLibrary();
            }
            return QRCodeLibrary_externalReference ;
         }

         set {
            QRCodeLibrary_externalReference = (QRCodeLibrary.QRCodeLibrary)(value);
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

      protected QRCodeLibrary.QRCodeLibrary QRCodeLibrary_externalReference=null ;
   }

}
