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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_uploadlogo : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_uploadlogo().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_uploadlogo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_uploadlogo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_LogoUrl ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV29LogoUrl = aP0_LogoUrl;
         this.AV25Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Error=this.AV25Error;
      }

      public SdtSDT_Error executeUdp( string aP0_LogoUrl )
      {
         execute(aP0_LogoUrl, out aP1_Error);
         return AV25Error ;
      }

      public void executeSubmit( string aP0_LogoUrl ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV29LogoUrl = aP0_LogoUrl;
         this.AV25Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Error=this.AV25Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV25Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV25Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            GXt_guid1 = AV22LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV22LocationId = GXt_guid1;
            GXt_guid1 = AV23OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV23OrganisationId = GXt_guid1;
            AV28Trn_Location.Load(AV22LocationId, AV23OrganisationId);
            AV28Trn_Location.gxTpr_Toolboxdefaultlogo = AV29LogoUrl;
            AV28Trn_Location.Save();
            AV9response = context.GetMessage( "Saved successfully", "");
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
         AV25Error = new SdtSDT_Error(context);
         AV22LocationId = Guid.Empty;
         AV23OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV28Trn_Location = new SdtTrn_Location(context);
         AV9response = "";
         /* GeneXus formulas. */
      }

      private string AV9response ;
      private string AV29LogoUrl ;
      private Guid AV22LocationId ;
      private Guid AV23OrganisationId ;
      private Guid GXt_guid1 ;
      private SdtSDT_Error AV25Error ;
      private SdtTrn_Location AV28Trn_Location ;
      private SdtSDT_Error aP1_Error ;
   }

}
