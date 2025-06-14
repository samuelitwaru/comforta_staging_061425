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
   public class SdtTranslator : GxUserType, IGxExternalObject
   {
      public SdtTranslator( )
      {
         /* Constructor for serialization */
      }

      public SdtTranslator( IGxContext context )
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

      public string translatetext( string gxTp_text ,
                                   string gxTp_sourceLanguageCode ,
                                   string gxTp_targetLanguageCode )
      {
         string returntranslatetext;
         if ( Translator_externalReference == null )
         {
            Translator_externalReference = new AmazonTextTranslate.Translator();
         }
         returntranslatetext = "";
         returntranslatetext = (string)(Translator_externalReference.TranslateText(gxTp_text, gxTp_sourceLanguageCode, gxTp_targetLanguageCode));
         return returntranslatetext ;
      }

      public string gxTpr_Accesskey
      {
         get {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            return Translator_externalReference.AccessKey ;
         }

         set {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            Translator_externalReference.AccessKey = value;
            SetDirty("Accesskey");
         }

      }

      public string gxTpr_Secretkey
      {
         get {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            return Translator_externalReference.SecretKey ;
         }

         set {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            Translator_externalReference.SecretKey = value;
            SetDirty("Secretkey");
         }

      }

      public string gxTpr_Regionname
      {
         get {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            return Translator_externalReference.RegionName ;
         }

         set {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            Translator_externalReference.RegionName = value;
            SetDirty("Regionname");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Translator_externalReference == null )
            {
               Translator_externalReference = new AmazonTextTranslate.Translator();
            }
            return Translator_externalReference ;
         }

         set {
            Translator_externalReference = (AmazonTextTranslate.Translator)(value);
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

      protected AmazonTextTranslate.Translator Translator_externalReference=null ;
   }

}
