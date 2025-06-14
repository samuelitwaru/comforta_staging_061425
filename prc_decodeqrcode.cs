using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_decodeqrcode : GXProcedure
   {
      public prc_decodeqrcode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_decodeqrcode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ScannedCode ,
                           out string aP1_Email ,
                           out string aP2_Password )
      {
         this.AV15ScannedCode = aP0_ScannedCode;
         this.AV10Email = "" ;
         this.AV13Password = "" ;
         initialize();
         ExecuteImpl();
         aP1_Email=this.AV10Email;
         aP2_Password=this.AV13Password;
      }

      public string executeUdp( string aP0_ScannedCode ,
                                out string aP1_Email )
      {
         execute(aP0_ScannedCode, out aP1_Email, out aP2_Password);
         return AV13Password ;
      }

      public void executeSubmit( string aP0_ScannedCode ,
                                 out string aP1_Email ,
                                 out string aP2_Password )
      {
         this.AV15ScannedCode = aP0_ScannedCode;
         this.AV10Email = "" ;
         this.AV13Password = "" ;
         SubmitImpl();
         aP1_Email=this.AV10Email;
         aP2_Password=this.AV13Password;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Key = context.GetMessage( "76a2173be6393254e72ffa4d6df1030a3d2f94a3bb6d4a6e69a2cda0e056cb13", "");
         AV12Nonce = context.GetMessage( "10dd993308d37a15b55f64a0e763f353", "");
         AV9Decrypted = AV16SymmetricBlockCipher.doaeaddecrypt("AES", "AEAD_EAX", AV11Key, 128, AV12Nonce, AV15ScannedCode);
         AV14Properties.FromJSonString(AV9Decrypted, null);
         AV17User = AV14Properties.Get("user");
         AV8Code = AV14Properties.Get("code");
         AV10Email = Decrypt64( AV17User, AV11Key);
         AV13Password = Decrypt64( AV8Code, AV11Key);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Email = "";
         AV13Password = "";
         AV11Key = "";
         AV12Nonce = "";
         AV9Decrypted = "";
         AV16SymmetricBlockCipher = new GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher(context);
         AV14Properties = new GXProperties();
         AV17User = "";
         AV8Code = "";
         /* GeneXus formulas. */
      }

      private string AV13Password ;
      private string AV15ScannedCode ;
      private string AV9Decrypted ;
      private string AV10Email ;
      private string AV11Key ;
      private string AV12Nonce ;
      private string AV17User ;
      private string AV8Code ;
      private GXProperties AV14Properties ;
      private GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher AV16SymmetricBlockCipher ;
      private string aP1_Email ;
      private string aP2_Password ;
   }

}
