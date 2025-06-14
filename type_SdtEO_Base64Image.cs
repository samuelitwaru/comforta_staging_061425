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
   public class SdtEO_Base64Image : GxUserType, IGxExternalObject
   {
      public SdtEO_Base64Image( )
      {
         /* Constructor for serialization */
      }

      public SdtEO_Base64Image( IGxContext context )
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

      public void main( object gxTp_args )
      {
         Base64Image.Base64Image.Main((System.String[])(gxTp_args)) ;
         return  ;
      }

      public void saveimage( string gxTp_Base64String ,
                             string gxTp_filePath )
      {
         Base64Image.Base64Image.SaveImage(gxTp_Base64String, gxTp_filePath) ;
         return  ;
      }

      public Object ExternalInstance
      {
         get {
            if ( EO_Base64Image_externalReference == null )
            {
               EO_Base64Image_externalReference = new Base64Image.Base64Image();
            }
            return EO_Base64Image_externalReference ;
         }

         set {
            EO_Base64Image_externalReference = (Base64Image.Base64Image)(value);
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

      protected Base64Image.Base64Image EO_Base64Image_externalReference=null ;
   }

}
