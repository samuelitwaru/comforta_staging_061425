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
   public class prc_generateqrcodeimage : GXProcedure
   {
      public prc_generateqrcodeimage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_generateqrcodeimage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ResidentGUID ,
                           out string aP1_QRCodeImage )
      {
         this.AV21ResidentGUID = aP0_ResidentGUID;
         this.AV20QRCodeImage = "" ;
         initialize();
         ExecuteImpl();
         aP1_QRCodeImage=this.AV20QRCodeImage;
      }

      public string executeUdp( string aP0_ResidentGUID )
      {
         execute(aP0_ResidentGUID, out aP1_QRCodeImage);
         return AV20QRCodeImage ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 out string aP1_QRCodeImage )
      {
         this.AV21ResidentGUID = aP0_ResidentGUID;
         this.AV20QRCodeImage = "" ;
         SubmitImpl();
         aP1_QRCodeImage=this.AV20QRCodeImage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Key = context.GetMessage( "76a2173be6393254e72ffa4d6df1030a3d2f94a3bb6d4a6e69a2cda0e056cb13", "");
         AV18Nonce = context.GetMessage( "10dd993308d37a15b55f64a0e763f353", "");
         AV19pwd = Guid.NewGuid( ).ToString();
         AV8Email = "";
         AV14GAMUser.load( AV21ResidentGUID);
         AV19pwd = AV14GAMUser.gxTpr_Postcode;
         AV8Email = AV14GAMUser.gxTpr_Email;
         AV10EncryptedEmail = Encrypt64( AV8Email, AV16Key);
         AV11EncryptedPassword = Encrypt64( AV19pwd, AV16Key);
         AV9EncryptedContent = "{\"user\": \"" + AV10EncryptedEmail + context.GetMessage( "\", \"code\": \"", "") + AV11EncryptedPassword + "\"}";
         AV12FinalEncryption = AV22SymmetricBlockCipher.doaeadencrypt("AES", "AEAD_EAX", AV16Key, 128, AV18Nonce, AV9EncryptedContent);
         AV20QRCodeImage = AV15GenerateQRCode.generateqrcode(AV12FinalEncryption);
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
         AV20QRCodeImage = "";
         AV16Key = "";
         AV18Nonce = "";
         AV19pwd = "";
         AV8Email = "";
         AV14GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10EncryptedEmail = "";
         AV11EncryptedPassword = "";
         AV9EncryptedContent = "";
         AV12FinalEncryption = "";
         AV22SymmetricBlockCipher = new GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher(context);
         AV15GenerateQRCode = new SdtQRCodeLibrary(context);
         /* GeneXus formulas. */
      }

      private string AV9EncryptedContent ;
      private string AV12FinalEncryption ;
      private string AV21ResidentGUID ;
      private string AV16Key ;
      private string AV18Nonce ;
      private string AV19pwd ;
      private string AV8Email ;
      private string AV10EncryptedEmail ;
      private string AV11EncryptedPassword ;
      private string AV20QRCodeImage ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GAMUser ;
      private GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher AV22SymmetricBlockCipher ;
      private SdtQRCodeLibrary AV15GenerateQRCode ;
      private string aP1_QRCodeImage ;
   }

}
