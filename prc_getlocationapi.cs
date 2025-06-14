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
   public class prc_getlocationapi : GXProcedure
   {
      public prc_getlocationapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtTrn_Location aP0_BC_Trn_Location ,
                           out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV9BC_Trn_Location = new SdtTrn_Location(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_BC_Trn_Location=this.AV9BC_Trn_Location;
         aP1_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( out SdtTrn_Location aP0_BC_Trn_Location )
      {
         execute(out aP0_BC_Trn_Location, out aP1_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( out SdtTrn_Location aP0_BC_Trn_Location ,
                                 out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV9BC_Trn_Location = new SdtTrn_Location(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_BC_Trn_Location=this.AV9BC_Trn_Location;
         aP1_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV17OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV17OrganisationId = GXt_guid1;
         GXt_guid1 = AV14LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV14LocationId = GXt_guid1;
         AV9BC_Trn_Location.Load(AV14LocationId, AV17OrganisationId);
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
         AV9BC_Trn_Location = new SdtTrn_Location(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV17OrganisationId = Guid.Empty;
         AV14LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         /* GeneXus formulas. */
      }

      private Guid AV17OrganisationId ;
      private Guid AV14LocationId ;
      private Guid GXt_guid1 ;
      private SdtTrn_Location AV9BC_Trn_Location ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_Location aP0_BC_Trn_Location ;
      private SdtSDT_Error aP1_SDT_Error ;
   }

}
