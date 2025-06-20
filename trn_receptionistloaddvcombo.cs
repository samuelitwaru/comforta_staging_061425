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
   public class trn_receptionistloaddvcombo : GXProcedure
   {
      public trn_receptionistloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionistloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ReceptionistId ,
                           Guid aP3_OrganisationId ,
                           Guid aP4_LocationId ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ReceptionistId = aP2_ReceptionistId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17LocationId = aP4_LocationId;
         this.AV18SelectedValue = "" ;
         this.AV19SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV18SelectedValue;
         aP6_SelectedText=this.AV19SelectedText;
         aP7_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_ReceptionistId ,
                                                                                                  Guid aP3_OrganisationId ,
                                                                                                  Guid aP4_LocationId ,
                                                                                                  out string aP5_SelectedValue ,
                                                                                                  out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ReceptionistId, aP3_OrganisationId, aP4_LocationId, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ReceptionistId ,
                                 Guid aP3_OrganisationId ,
                                 Guid aP4_LocationId ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ReceptionistId = aP2_ReceptionistId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17LocationId = aP4_LocationId;
         this.AV18SelectedValue = "" ;
         this.AV19SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP5_SelectedValue=this.AV18SelectedValue;
         aP6_SelectedText=this.AV19SelectedText;
         aP7_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "ReceptionistPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RECEPTIONISTPHONECODE' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_RECEPTIONISTPHONECODE' Routine */
         returnInSub = false;
         AV26GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV25GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV25GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV26GXV2 <= AV25GXV1.Count )
         {
            AV24ReceptionistPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV25GXV1.Item(AV26GXV2));
            AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV24ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV22ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV22ComboTitles.Add(AV24ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV22ComboTitles.Add(AV24ReceptionistPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV12Combo_DataItem.gxTpr_Title = AV22ComboTitles.ToJSonString(false);
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV26GXV2 = (int)(AV26GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P007B2 */
            pr_default.execute(0, new Object[] {AV15ReceptionistId, AV16OrganisationId, AV17LocationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A29LocationId = P007B2_A29LocationId[0];
               A11OrganisationId = P007B2_A11OrganisationId[0];
               A89ReceptionistId = P007B2_A89ReceptionistId[0];
               A345ReceptionistPhoneCode = P007B2_A345ReceptionistPhoneCode[0];
               AV18SelectedValue = A345ReceptionistPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV28GXV3 = 1;
               while ( AV28GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV28GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV18SelectedValue) == 0 )
                  {
                     AV22ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV22ComboTitles.FromJSonString(AV12Combo_DataItem.gxTpr_Title, null);
                     AV19SelectedText = ((string)AV22ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV28GXV3 = (int)(AV28GXV3+1);
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
         AV18SelectedValue = "";
         AV19SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV24ReceptionistPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV22ComboTitles = new GxSimpleCollection<string>();
         P007B2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P007B2_A345ReceptionistPhoneCode = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A345ReceptionistPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007B2_A29LocationId, P007B2_A11OrganisationId, P007B2_A89ReceptionistId, P007B2_A345ReceptionistPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV26GXV2 ;
      private int AV28GXV3 ;
      private string AV14TrnMode ;
      private bool returnInSub ;
      private string AV13ComboName ;
      private string AV18SelectedValue ;
      private string AV19SelectedText ;
      private string A345ReceptionistPhoneCode ;
      private Guid AV15ReceptionistId ;
      private Guid AV16OrganisationId ;
      private Guid AV17LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV25GXV1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV24ReceptionistPhoneCode_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GxSimpleCollection<string> AV22ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007B2_A29LocationId ;
      private Guid[] P007B2_A11OrganisationId ;
      private Guid[] P007B2_A89ReceptionistId ;
      private string[] P007B2_A345ReceptionistPhoneCode ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data ;
   }

   public class trn_receptionistloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("AV15ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV17LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "SELECT LocationId, OrganisationId, ReceptionistId, ReceptionistPhoneCode FROM Trn_Receptionist WHERE ReceptionistId = :AV15ReceptionistId and OrganisationId = :AV16OrganisationId and LocationId = :AV17LocationId ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
