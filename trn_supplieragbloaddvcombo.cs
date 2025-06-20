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
   public class trn_supplieragbloaddvcombo : GXProcedure
   {
      public trn_supplieragbloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_SupplierAgbId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierAgbId = aP2_SupplierAgbId;
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
                                                                                                  Guid aP2_SupplierAgbId ,
                                                                                                  out string aP3_SelectedValue ,
                                                                                                  out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_SupplierAgbId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_SupplierAgbId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierAgbId = aP2_SupplierAgbId;
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
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierAGBAddressCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBADDRESSCOUNTRY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgbTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBTYPEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgbPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBPHONECODE' */
            S131 ();
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
         /* 'LOADCOMBOITEMS_SUPPLIERAGBADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV33GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV32GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV32GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV33GXV2 <= AV32GXV1.Count )
         {
            AV30SupplierAGBAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV32GXV1.Item(AV33GXV2));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV30SupplierAGBAddressCountry_DPItem.gxTpr_Countryname;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV30SupplierAGBAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV29ComboTitles.Add(AV30SupplierAGBAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV33GXV2 = (int)(AV33GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006A2 */
            pr_default.execute(0, new Object[] {AV20SupplierAgbId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A49SupplierAgbId = P006A2_A49SupplierAgbId[0];
               A306SupplierAGBAddressCountry = P006A2_A306SupplierAGBAddressCountry[0];
               AV22SelectedValue = A306SupplierAGBAddressCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV35GXV3 = 1;
               while ( AV35GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV35GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV35GXV3 = (int)(AV35GXV3+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERAGBTYPEID' Routine */
         returnInSub = false;
         /* Using cursor P006A3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A255SupplierAgbTypeId = P006A3_A255SupplierAgbTypeId[0];
            A256SupplierAgbTypeName = P006A3_A256SupplierAgbTypeName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A255SupplierAgbTypeId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A256SupplierAgbTypeName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P006A4 */
            pr_default.execute(2, new Object[] {AV20SupplierAgbId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49SupplierAgbId = P006A4_A49SupplierAgbId[0];
               A255SupplierAgbTypeId = P006A4_A255SupplierAgbTypeId[0];
               AV22SelectedValue = ((Guid.Empty==A255SupplierAgbTypeId) ? "" : StringUtil.Trim( A255SupplierAgbTypeId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERAGBPHONECODE' Routine */
         returnInSub = false;
         AV39GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV38GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV38GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV39GXV5 <= AV38GXV4.Count )
         {
            AV31SupplierAgbPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV38GXV4.Item(AV39GXV5));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV31SupplierAgbPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV31SupplierAgbPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV29ComboTitles.Add(AV31SupplierAgbPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV39GXV5 = (int)(AV39GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006A5 */
            pr_default.execute(3, new Object[] {AV20SupplierAgbId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49SupplierAgbId = P006A5_A49SupplierAgbId[0];
               A349SupplierAgbPhoneCode = P006A5_A349SupplierAgbPhoneCode[0];
               AV22SelectedValue = A349SupplierAgbPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV41GXV6 = 1;
               while ( AV41GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV41GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV41GXV6 = (int)(AV41GXV6+1);
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
         AV32GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV30SupplierAGBAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV29ComboTitles = new GxSimpleCollection<string>();
         P006A2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006A2_A306SupplierAGBAddressCountry = new string[] {""} ;
         A49SupplierAgbId = Guid.Empty;
         A306SupplierAGBAddressCountry = "";
         P006A3_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P006A3_A256SupplierAgbTypeName = new string[] {""} ;
         A255SupplierAgbTypeId = Guid.Empty;
         A256SupplierAgbTypeName = "";
         P006A4_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006A4_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         AV38GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV31SupplierAgbPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P006A5_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006A5_A349SupplierAgbPhoneCode = new string[] {""} ;
         A349SupplierAgbPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006A2_A49SupplierAgbId, P006A2_A306SupplierAGBAddressCountry
               }
               , new Object[] {
               P006A3_A255SupplierAgbTypeId, P006A3_A256SupplierAgbTypeName
               }
               , new Object[] {
               P006A4_A49SupplierAgbId, P006A4_A255SupplierAgbTypeId
               }
               , new Object[] {
               P006A5_A49SupplierAgbId, P006A5_A349SupplierAgbPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV33GXV2 ;
      private int AV35GXV3 ;
      private int AV39GXV5 ;
      private int AV41GXV6 ;
      private string AV18TrnMode ;
      private bool returnInSub ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string A306SupplierAGBAddressCountry ;
      private string A256SupplierAgbTypeName ;
      private string A349SupplierAgbPhoneCode ;
      private Guid AV20SupplierAgbId ;
      private Guid A49SupplierAgbId ;
      private Guid A255SupplierAgbTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV32GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV30SupplierAGBAddressCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GxSimpleCollection<string> AV29ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006A2_A49SupplierAgbId ;
      private string[] P006A2_A306SupplierAGBAddressCountry ;
      private Guid[] P006A3_A255SupplierAgbTypeId ;
      private string[] P006A3_A256SupplierAgbTypeName ;
      private Guid[] P006A4_A49SupplierAgbId ;
      private Guid[] P006A4_A255SupplierAgbTypeId ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV38GXV4 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV31SupplierAgbPhoneCode_DPItem ;
      private Guid[] P006A5_A49SupplierAgbId ;
      private string[] P006A5_A349SupplierAgbPhoneCode ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class trn_supplieragbloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("AV20SupplierAgbId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A3;
          prmP006A3 = new Object[] {
          };
          Object[] prmP006A4;
          prmP006A4 = new Object[] {
          new ParDef("AV20SupplierAgbId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A5;
          prmP006A5 = new Object[] {
          new ParDef("AV20SupplierAgbId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "SELECT SupplierAgbId, SupplierAGBAddressCountry FROM Trn_SupplierAGB WHERE SupplierAgbId = :AV20SupplierAgbId ORDER BY SupplierAgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A3", "SELECT SupplierAgbTypeId, SupplierAgbTypeName FROM Trn_SupplierAgbType ORDER BY SupplierAgbTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A4", "SELECT SupplierAgbId, SupplierAgbTypeId FROM Trn_SupplierAGB WHERE SupplierAgbId = :AV20SupplierAgbId ORDER BY SupplierAgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A5", "SELECT SupplierAgbId, SupplierAgbPhoneCode FROM Trn_SupplierAGB WHERE SupplierAgbId = :AV20SupplierAgbId ORDER BY SupplierAgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A5,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
