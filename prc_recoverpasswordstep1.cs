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
   public class prc_recoverpasswordstep1 : GXProcedure
   {
      public prc_recoverpasswordstep1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_recoverpasswordstep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Username ,
                           out string aP1_response )
      {
         this.AV8Username = aP0_Username;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV14response;
      }

      public string executeUdp( string aP0_Username )
      {
         execute(aP0_Username, out aP1_response);
         return AV14response ;
      }

      public void executeSubmit( string aP0_Username ,
                                 out string aP1_response )
      {
         this.AV8Username = aP0_Username;
         this.AV14response = "" ;
         SubmitImpl();
         aP1_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV10UserAuthTypeName, AV8Username, out  AV11GAMErrorCollection);
         if ( AV11GAMErrorCollection.Count == 0 )
         {
            new prc_sendpasswordresetlink(context ).execute(  AV9User.gxTpr_Guid, out  AV12IsSuccess) ;
            if ( AV12IsSuccess )
            {
               AV13result = new SdtSDT_RecoverPasswordStep1(context);
               AV13result.gxTpr_Success_message = context.GetMessage( "An email was sent with instructions to change your password", "");
            }
            else
            {
               AV13result = new SdtSDT_RecoverPasswordStep1(context);
               AV13result.gxTpr_Error.gxTpr_Message = context.GetMessage( "Something went wrong, please try again", "");
            }
         }
         else
         {
            AV13result = new SdtSDT_RecoverPasswordStep1(context);
            AV13result.gxTpr_Error.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrorCollection.Item(1)).gxTpr_Code), 12, 0));
            AV13result.gxTpr_Error.gxTpr_Message = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrorCollection.Item(1)).gxTpr_Message;
         }
         AV14response = AV13result.ToJSonString(false, true);
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
         AV14response = "";
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10UserAuthTypeName = "";
         AV11GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13result = new SdtSDT_RecoverPasswordStep1(context);
         /* GeneXus formulas. */
      }

      private string AV10UserAuthTypeName ;
      private bool AV12IsSuccess ;
      private string AV14response ;
      private string AV8Username ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9User ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrorCollection ;
      private SdtSDT_RecoverPasswordStep1 AV13result ;
      private string aP1_response ;
   }

}
