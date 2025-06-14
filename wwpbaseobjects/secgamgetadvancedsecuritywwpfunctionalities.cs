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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secgamgetadvancedsecuritywwpfunctionalities : GXProcedure
   {
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

      public secgamgetadvancedsecuritywwpfunctionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgamgetadvancedsecuritywwpfunctionalities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad> executeUdp( )
      {
         execute(out aP0_Gxm3rootcol);
         return Gxm3rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "Comforta_version21") ;
         SubmitImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: Sub1subgroup_1 */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* Sub1subgroup_1 Routine */
         returnInSub = false;
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Block";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_manager_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_organisation_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_location_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_edit";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Edit";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_copy";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_delete";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Delete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_filledforms";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Filled forms";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_filloutform";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "fill out form";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_copytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_directcopytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_supplierdynamicform_insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_productservice_Insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_resident_Delete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_resident_Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionistview_Execute";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Update";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Edit";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "trn_receptionist_Delete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_edit";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Edit";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_copy";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_delete";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Delete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_filledforms";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Filled forms";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_filloutform";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "fill out form";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_locationdynamicform_insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_uupdate";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Update";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_udelete";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "GX_BtnDelete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_uexport";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "WWP_DF_ExportForm";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_ufill";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "WWP_DF_FillOutAForm";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_ufilledoutform";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "WWP_DF_ViewFilledOutForms";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_ucopy";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "WWP_DF_CopyForm";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_copytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_directcopytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_uinsert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "uform_uimport";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "WWP_DF_ImportForm";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_edit";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Edit";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_copy";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_delete";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Delete";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_filledforms";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Filled forms";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_filloutform";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "fill out form";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_copytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_directcopytolocation";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Copy To Location";
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         Gxm3rootcol.Add(Gxm2secgamfunctionalitiestoload, 0);
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitykey = "wp_organisationdynamicform_insert";
         Gxm2secgamfunctionalitiestoload.gxTpr_Secgamfunctionalitydsc = "Insert";
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
         Gxm2secgamfunctionalitiestoload = new WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad> Gxm3rootcol ;
      private WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad Gxm2secgamfunctionalitiestoload ;
      private GXBaseCollection<WorkWithPlus.workwithplus_commongam.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm3rootcol ;
   }

}
