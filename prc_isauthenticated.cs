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
   public class prc_isauthenticated : GXProcedure
   {
      public prc_isauthenticated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_isauthenticated( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_isLoggedIn )
      {
         this.AV11isLoggedIn = false ;
         initialize();
         ExecuteImpl();
         aP0_isLoggedIn=this.AV11isLoggedIn;
      }

      public bool executeUdp( )
      {
         execute(out aP0_isLoggedIn);
         return AV11isLoggedIn ;
      }

      public void executeSubmit( out bool aP0_isLoggedIn )
      {
         this.AV11isLoggedIn = false ;
         SubmitImpl();
         aP0_isLoggedIn=this.AV11isLoggedIn;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8isSessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV9GAMSession, out  AV10GAMErrors);
         if ( AV9GAMSession.gxTpr_Isanonymous )
         {
            AV11isLoggedIn = false;
         }
         else
         {
            AV11isLoggedIn = true;
         }
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
         AV9GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
      }

      private bool AV11isLoggedIn ;
      private bool AV8isSessionValid ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV9GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrors ;
      private bool aP0_isLoggedIn ;
   }

}
