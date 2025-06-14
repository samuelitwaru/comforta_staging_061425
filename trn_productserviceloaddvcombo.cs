using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class trn_productserviceloaddvcombo : GXProcedure
   {
      public trn_productserviceloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productserviceloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ProductServiceId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId ,
                           out string aP5_SelectedValue ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV31LocationId = aP3_LocationId;
         this.AV30OrganisationId = aP4_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_ProductServiceId ,
                                                                                                  Guid aP3_LocationId ,
                                                                                                  Guid aP4_OrganisationId ,
                                                                                                  out string aP5_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProductServiceId, aP3_LocationId, aP4_OrganisationId, out aP5_SelectedValue, out aP6_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ProductServiceId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId ,
                                 out string aP5_SelectedValue ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV31LocationId = aP3_LocationId;
         this.AV30OrganisationId = aP4_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_guid1 = AV33PreferredAgbSuppliers;
         new prc_getpreferredagbsuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV33PreferredAgbSuppliers = GXt_objcol_guid1;
         GXt_objcol_guid1 = AV34PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV34PreferredGenSuppliers = GXt_objcol_guid1;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgb_Id") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGB_ID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgbId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGen_Id") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGEN_ID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENID' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERAGB_ID' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV33PreferredAgbSuppliers } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P006X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49SupplierAgbId = P006X2_A49SupplierAgbId[0];
            n49SupplierAgbId = P006X2_n49SupplierAgbId[0];
            A51SupplierAgbName = P006X2_A51SupplierAgbName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV33PreferredAgbSuppliers ,
                                              A11OrganisationId ,
                                              AV30OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P006X3 */
         pr_default.execute(1, new Object[] {AV30OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P006X3_A11OrganisationId[0];
            A49SupplierAgbId = P006X3_A49SupplierAgbId[0];
            n49SupplierAgbId = P006X3_n49SupplierAgbId[0];
            A51SupplierAgbName = P006X3_A51SupplierAgbName[0];
            A58ProductServiceId = P006X3_A58ProductServiceId[0];
            A29LocationId = P006X3_A29LocationId[0];
            A51SupplierAgbName = P006X3_A51SupplierAgbName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006X4 */
            pr_default.execute(2, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A11OrganisationId = P006X4_A11OrganisationId[0];
               A29LocationId = P006X4_A29LocationId[0];
               A58ProductServiceId = P006X4_A58ProductServiceId[0];
               A49SupplierAgbId = P006X4_A49SupplierAgbId[0];
               n49SupplierAgbId = P006X4_n49SupplierAgbId[0];
               AV22SelectedValue = ((Guid.Empty==A49SupplierAgbId) ? "" : StringUtil.Trim( A49SupplierAgbId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGEN_ID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A42SupplierGenId ,
                                              AV34PreferredGenSuppliers } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P006X5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A42SupplierGenId = P006X5_A42SupplierGenId[0];
            n42SupplierGenId = P006X5_n42SupplierGenId[0];
            A44SupplierGenCompanyName = P006X5_A44SupplierGenCompanyName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENID' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A42SupplierGenId ,
                                              AV34PreferredGenSuppliers ,
                                              A11OrganisationId ,
                                              AV30OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P006X6 */
         pr_default.execute(4, new Object[] {AV30OrganisationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = P006X6_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = P006X6_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = P006X6_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = P006X6_n603SG_LocationSupplierLocationId[0];
            A630ToolBoxLastUpdateReceptionistI = P006X6_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P006X6_n630ToolBoxLastUpdateReceptionistI[0];
            A89ReceptionistId = P006X6_A89ReceptionistId[0];
            A29LocationId = P006X6_A29LocationId[0];
            A42SupplierGenId = P006X6_A42SupplierGenId[0];
            n42SupplierGenId = P006X6_n42SupplierGenId[0];
            A44SupplierGenCompanyName = P006X6_A44SupplierGenCompanyName[0];
            A630ToolBoxLastUpdateReceptionistI = P006X6_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P006X6_n630ToolBoxLastUpdateReceptionistI[0];
            /* Using cursor P006X7 */
            pr_default.execute(5, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(5);
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         pr_default.close(5);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006X8 */
            pr_default.execute(6, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A11OrganisationId = P006X8_A11OrganisationId[0];
               A29LocationId = P006X8_A29LocationId[0];
               A58ProductServiceId = P006X8_A58ProductServiceId[0];
               A42SupplierGenId = P006X8_A42SupplierGenId[0];
               n42SupplierGenId = P006X8_n42SupplierGenId[0];
               AV22SelectedValue = ((Guid.Empty==A42SupplierGenId) ? "" : StringUtil.Trim( A42SupplierGenId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
         }
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
         AV22SelectedValue = "";
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV34PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A49SupplierAgbId = Guid.Empty;
         P006X2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006X2_n49SupplierAgbId = new bool[] {false} ;
         P006X2_A51SupplierAgbName = new string[] {""} ;
         A51SupplierAgbName = "";
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         A11OrganisationId = Guid.Empty;
         P006X3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006X3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006X3_n49SupplierAgbId = new bool[] {false} ;
         P006X3_A51SupplierAgbName = new string[] {""} ;
         P006X3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006X3_A29LocationId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P006X4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006X4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006X4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006X4_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006X4_n49SupplierAgbId = new bool[] {false} ;
         A42SupplierGenId = Guid.Empty;
         P006X5_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006X5_n42SupplierGenId = new bool[] {false} ;
         P006X5_A44SupplierGenCompanyName = new string[] {""} ;
         A44SupplierGenCompanyName = "";
         P006X6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006X6_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         P006X6_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         P006X6_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         P006X6_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         P006X6_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P006X6_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P006X6_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006X6_A29LocationId = new Guid[] {Guid.Empty} ;
         P006X6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006X6_n42SupplierGenId = new bool[] {false} ;
         P006X6_A44SupplierGenCompanyName = new string[] {""} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         P006X7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006X8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006X8_A29LocationId = new Guid[] {Guid.Empty} ;
         P006X8_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006X8_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006X8_n42SupplierGenId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006X2_A49SupplierAgbId, P006X2_A51SupplierAgbName
               }
               , new Object[] {
               P006X3_A11OrganisationId, P006X3_A49SupplierAgbId, P006X3_n49SupplierAgbId, P006X3_A51SupplierAgbName, P006X3_A58ProductServiceId, P006X3_A29LocationId
               }
               , new Object[] {
               P006X4_A11OrganisationId, P006X4_A29LocationId, P006X4_A58ProductServiceId, P006X4_A49SupplierAgbId, P006X4_n49SupplierAgbId
               }
               , new Object[] {
               P006X5_A42SupplierGenId, P006X5_A44SupplierGenCompanyName
               }
               , new Object[] {
               P006X6_A11OrganisationId, P006X6_A602SG_LocationSupplierOrganisatio, P006X6_n602SG_LocationSupplierOrganisatio, P006X6_A603SG_LocationSupplierLocationId, P006X6_n603SG_LocationSupplierLocationId, P006X6_A630ToolBoxLastUpdateReceptionistI, P006X6_n630ToolBoxLastUpdateReceptionistI, P006X6_A89ReceptionistId, P006X6_A29LocationId, P006X6_A42SupplierGenId,
               P006X6_A44SupplierGenCompanyName
               }
               , new Object[] {
               P006X7_A11OrganisationId
               }
               , new Object[] {
               P006X8_A11OrganisationId, P006X8_A29LocationId, P006X8_A58ProductServiceId, P006X8_A42SupplierGenId, P006X8_n42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18TrnMode ;
      private bool returnInSub ;
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private Guid AV20ProductServiceId ;
      private Guid AV31LocationId ;
      private Guid AV30OrganisationId ;
      private Guid A49SupplierAgbId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A42SupplierGenId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GxSimpleCollection<Guid> AV33PreferredAgbSuppliers ;
      private GxSimpleCollection<Guid> AV34PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006X2_A49SupplierAgbId ;
      private bool[] P006X2_n49SupplierAgbId ;
      private string[] P006X2_A51SupplierAgbName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private Guid[] P006X3_A11OrganisationId ;
      private Guid[] P006X3_A49SupplierAgbId ;
      private bool[] P006X3_n49SupplierAgbId ;
      private string[] P006X3_A51SupplierAgbName ;
      private Guid[] P006X3_A58ProductServiceId ;
      private Guid[] P006X3_A29LocationId ;
      private Guid[] P006X4_A11OrganisationId ;
      private Guid[] P006X4_A29LocationId ;
      private Guid[] P006X4_A58ProductServiceId ;
      private Guid[] P006X4_A49SupplierAgbId ;
      private bool[] P006X4_n49SupplierAgbId ;
      private Guid[] P006X5_A42SupplierGenId ;
      private bool[] P006X5_n42SupplierGenId ;
      private string[] P006X5_A44SupplierGenCompanyName ;
      private Guid[] P006X6_A11OrganisationId ;
      private Guid[] P006X6_A602SG_LocationSupplierOrganisatio ;
      private bool[] P006X6_n602SG_LocationSupplierOrganisatio ;
      private Guid[] P006X6_A603SG_LocationSupplierLocationId ;
      private bool[] P006X6_n603SG_LocationSupplierLocationId ;
      private Guid[] P006X6_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P006X6_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] P006X6_A89ReceptionistId ;
      private Guid[] P006X6_A29LocationId ;
      private Guid[] P006X6_A42SupplierGenId ;
      private bool[] P006X6_n42SupplierGenId ;
      private string[] P006X6_A44SupplierGenCompanyName ;
      private Guid[] P006X7_A11OrganisationId ;
      private Guid[] P006X8_A11OrganisationId ;
      private Guid[] P006X8_A29LocationId ;
      private Guid[] P006X8_A58ProductServiceId ;
      private Guid[] P006X8_A42SupplierGenId ;
      private bool[] P006X8_n42SupplierGenId ;
      private string aP5_SelectedValue ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data ;
   }

   public class trn_productserviceloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006X2( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV33PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006X3( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV33PreferredAgbSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV30OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationId, T1.SupplierAgbId, T2.SupplierAgbName, T1.ProductServiceId, T1.LocationId FROM (Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId)";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33PreferredAgbSuppliers, "T1.SupplierAgbId IN (", ")")+")");
         AddWhere(sWhereString, "(T1.OrganisationId = :AV30OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.SupplierAgbName";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006X5( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV34PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV34PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006X6( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV34PreferredGenSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV30OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[1];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SupplierGenCompanyName FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId)";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV34PreferredGenSuppliers, "T1.SupplierGenId IN (", ")")+")");
         AddWhere(sWhereString, "(T3.OrganisationId = :AV30OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006X2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 1 :
                     return conditional_P006X3(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 3 :
                     return conditional_P006X5(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 4 :
                     return conditional_P006X6(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006X4;
          prmP006X4 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006X7;
          prmP006X7 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP006X8;
          prmP006X8 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006X2;
          prmP006X2 = new Object[] {
          };
          Object[] prmP006X3;
          prmP006X3 = new Object[] {
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006X5;
          prmP006X5 = new Object[] {
          };
          Object[] prmP006X6;
          prmP006X6 = new Object[] {
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006X4", "SELECT OrganisationId, LocationId, ProductServiceId, SupplierAgbId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId and LocationId = :AV31LocationId and OrganisationId = :AV30OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006X5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006X6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006X7", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006X8", "SELECT OrganisationId, LocationId, ProductServiceId, SupplierGenId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId and LocationId = :AV31LocationId and OrganisationId = :AV30OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X8,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
