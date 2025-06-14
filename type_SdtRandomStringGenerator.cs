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
   public class SdtRandomStringGenerator : GxUserType, IGxExternalObject
   {
      public SdtRandomStringGenerator( )
      {
         /* Constructor for serialization */
      }

      public SdtRandomStringGenerator( IGxContext context )
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

      public string generate( int gxTp_length )
      {
         string returngenerate;
         returngenerate = "";
         returngenerate = (string)(RandomStringGenerator.RandomStringGenerator.Generate(gxTp_length));
         return returngenerate ;
      }

      public Object ExternalInstance
      {
         get {
            if ( RandomStringGenerator_externalReference == null )
            {
               RandomStringGenerator_externalReference = new RandomStringGenerator.RandomStringGenerator();
            }
            return RandomStringGenerator_externalReference ;
         }

         set {
            RandomStringGenerator_externalReference = (RandomStringGenerator.RandomStringGenerator)(value);
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

      protected RandomStringGenerator.RandomStringGenerator RandomStringGenerator_externalReference=null ;
   }

}
