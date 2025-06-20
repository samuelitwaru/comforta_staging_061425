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
   public class trn_suppliergenloaddvcombo : GXProcedure
   {
      public trn_suppliergenloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergenloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_SupplierGenId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierGenId = aP2_SupplierGenId;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_SelectedText=this.AV23SelectedText;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_SupplierGenId ,
                                                                                                  out string aP3_SelectedValue ,
                                                                                                  out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_SupplierGenId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_SupplierGenId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierGenId = aP2_SupplierGenId;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_SelectedText=this.AV23SelectedText;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenAddressCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENADDRESSCOUNTRY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENTYPEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenLandlineCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENLANDLINECODE' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENPHONECODE' */
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
         /* 'LOADCOMBOITEMS_SUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV34GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV33GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV33GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV34GXV2 <= AV33GXV1.Count )
         {
            AV30SupplierGenAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV33GXV1.Item(AV34GXV2));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryname;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV29ComboTitles.Add(AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00682 */
            pr_default.execute(0, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A42SupplierGenId = P00682_A42SupplierGenId[0];
               A309SupplierGenAddressCountry = P00682_A309SupplierGenAddressCountry[0];
               AV22SelectedValue = A309SupplierGenAddressCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV36GXV3 = 1;
               while ( AV36GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV36GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV36GXV3 = (int)(AV36GXV3+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         /* Using cursor P00683 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A253SupplierGenTypeId = P00683_A253SupplierGenTypeId[0];
            A254SupplierGenTypeName = P00683_A254SupplierGenTypeName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A253SupplierGenTypeId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A254SupplierGenTypeName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P00684 */
            pr_default.execute(2, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A42SupplierGenId = P00684_A42SupplierGenId[0];
               A253SupplierGenTypeId = P00684_A253SupplierGenTypeId[0];
               AV22SelectedValue = ((Guid.Empty==A253SupplierGenTypeId) ? "" : StringUtil.Trim( A253SupplierGenTypeId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENLANDLINECODE' Routine */
         returnInSub = false;
         AV40GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV39GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV39GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV40GXV5 <= AV39GXV4.Count )
         {
            AV32SupplierGenLandlineCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV39GXV4.Item(AV40GXV5));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV32SupplierGenLandlineCode_DPItem.gxTpr_Countrydialcode;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV32SupplierGenLandlineCode_DPItem.gxTpr_Countrydialcode, 0);
            AV29ComboTitles.Add(AV32SupplierGenLandlineCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV40GXV5 = (int)(AV40GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00685 */
            pr_default.execute(3, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A42SupplierGenId = P00685_A42SupplierGenId[0];
               A605SupplierGenLandlineCode = P00685_A605SupplierGenLandlineCode[0];
               AV22SelectedValue = A605SupplierGenLandlineCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV42GXV6 = 1;
               while ( AV42GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV42GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV42GXV6 = (int)(AV42GXV6+1);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENPHONECODE' Routine */
         returnInSub = false;
         AV44GXV8 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV43GXV7;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV43GXV7 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV44GXV8 <= AV43GXV7.Count )
         {
            AV31SupplierGenPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV43GXV7.Item(AV44GXV8));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV31SupplierGenPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV31SupplierGenPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV29ComboTitles.Add(AV31SupplierGenPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV44GXV8 = (int)(AV44GXV8+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00686 */
            pr_default.execute(4, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A42SupplierGenId = P00686_A42SupplierGenId[0];
               A353SupplierGenPhoneCode = P00686_A353SupplierGenPhoneCode[0];
               AV22SelectedValue = A353SupplierGenPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV46GXV9 = 1;
               while ( AV46GXV9 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV46GXV9));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV46GXV9 = (int)(AV46GXV9+1);
               }
            }
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
         AV23SelectedText = "";
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV30SupplierGenAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV29ComboTitles = new GxSimpleCollection<string>();
         P00682_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00682_A309SupplierGenAddressCountry = new string[] {""} ;
         A42SupplierGenId = Guid.Empty;
         A309SupplierGenAddressCountry = "";
         P00683_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P00683_A254SupplierGenTypeName = new string[] {""} ;
         A253SupplierGenTypeId = Guid.Empty;
         A254SupplierGenTypeName = "";
         P00684_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00684_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         AV39GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV32SupplierGenLandlineCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P00685_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00685_A605SupplierGenLandlineCode = new string[] {""} ;
         A605SupplierGenLandlineCode = "";
         AV43GXV7 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV31SupplierGenPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P00686_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00686_A353SupplierGenPhoneCode = new string[] {""} ;
         A353SupplierGenPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergenloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00682_A42SupplierGenId, P00682_A309SupplierGenAddressCountry
               }
               , new Object[] {
               P00683_A253SupplierGenTypeId, P00683_A254SupplierGenTypeName
               }
               , new Object[] {
               P00684_A42SupplierGenId, P00684_A253SupplierGenTypeId
               }
               , new Object[] {
               P00685_A42SupplierGenId, P00685_A605SupplierGenLandlineCode
               }
               , new Object[] {
               P00686_A42SupplierGenId, P00686_A353SupplierGenPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV34GXV2 ;
      private int AV36GXV3 ;
      private int AV40GXV5 ;
      private int AV42GXV6 ;
      private int AV44GXV8 ;
      private int AV46GXV9 ;
      private string AV18TrnMode ;
      private bool returnInSub ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string A309SupplierGenAddressCountry ;
      private string A254SupplierGenTypeName ;
      private string A605SupplierGenLandlineCode ;
      private string A353SupplierGenPhoneCode ;
      private Guid AV20SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid A253SupplierGenTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV33GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV30SupplierGenAddressCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GxSimpleCollection<string> AV29ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00682_A42SupplierGenId ;
      private string[] P00682_A309SupplierGenAddressCountry ;
      private Guid[] P00683_A253SupplierGenTypeId ;
      private string[] P00683_A254SupplierGenTypeName ;
      private Guid[] P00684_A42SupplierGenId ;
      private Guid[] P00684_A253SupplierGenTypeId ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV39GXV4 ;
      private SdtSDT_Country_SDT_CountryItem AV32SupplierGenLandlineCode_DPItem ;
      private Guid[] P00685_A42SupplierGenId ;
      private string[] P00685_A605SupplierGenLandlineCode ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV43GXV7 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV31SupplierGenPhoneCode_DPItem ;
      private Guid[] P00686_A42SupplierGenId ;
      private string[] P00686_A353SupplierGenPhoneCode ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class trn_suppliergenloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00682;
          prmP00682 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00683;
          prmP00683 = new Object[] {
          };
          Object[] prmP00684;
          prmP00684 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00685;
          prmP00685 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00686;
          prmP00686 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00682", "SELECT SupplierGenId, SupplierGenAddressCountry FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00682,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00683", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType ORDER BY SupplierGenTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00683,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00684", "SELECT SupplierGenId, SupplierGenTypeId FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00684,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00685", "SELECT SupplierGenId, SupplierGenLandlineCode FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00685,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00686", "SELECT SupplierGenId, SupplierGenPhoneCode FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00686,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
