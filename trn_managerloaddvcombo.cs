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
   public class trn_managerloaddvcombo : GXProcedure
   {
      public trn_managerloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_managerloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ManagerId ,
                           Guid aP3_OrganisationId ,
                           out string aP4_SelectedValue ,
                           out string aP5_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ManagerId = aP2_ManagerId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17SelectedValue = "" ;
         this.AV18SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP4_SelectedValue=this.AV17SelectedValue;
         aP5_SelectedText=this.AV18SelectedText;
         aP6_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_ManagerId ,
                                                                                                  Guid aP3_OrganisationId ,
                                                                                                  out string aP4_SelectedValue ,
                                                                                                  out string aP5_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ManagerId, aP3_OrganisationId, out aP4_SelectedValue, out aP5_SelectedText, out aP6_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ManagerId ,
                                 Guid aP3_OrganisationId ,
                                 out string aP4_SelectedValue ,
                                 out string aP5_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ManagerId = aP2_ManagerId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17SelectedValue = "" ;
         this.AV18SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP4_SelectedValue=this.AV17SelectedValue;
         aP5_SelectedText=this.AV18SelectedText;
         aP6_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "ManagerPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MANAGERPHONECODE' */
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
         /* 'LOADCOMBOITEMS_MANAGERPHONECODE' Routine */
         returnInSub = false;
         AV24GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV23GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV23GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV24GXV2 <= AV23GXV1.Count )
         {
            AV22ManagerPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV23GXV1.Item(AV24GXV2));
            AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV22ManagerPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV21ComboTitles.Add(AV22ManagerPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV21ComboTitles.Add(AV22ManagerPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV12Combo_DataItem.gxTpr_Title = AV21ComboTitles.ToJSonString(false);
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV24GXV2 = (int)(AV24GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P007C2 */
            pr_default.execute(0, new Object[] {AV15ManagerId, AV16OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P007C2_A11OrganisationId[0];
               A21ManagerId = P007C2_A21ManagerId[0];
               A357ManagerPhoneCode = P007C2_A357ManagerPhoneCode[0];
               AV17SelectedValue = A357ManagerPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV26GXV3 = 1;
               while ( AV26GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV26GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV17SelectedValue) == 0 )
                  {
                     AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV21ComboTitles.FromJSonString(AV12Combo_DataItem.gxTpr_Title, null);
                     AV18SelectedText = ((string)AV21ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV26GXV3 = (int)(AV26GXV3+1);
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
         AV17SelectedValue = "";
         AV18SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV22ManagerPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV21ComboTitles = new GxSimpleCollection<string>();
         P007C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007C2_A21ManagerId = new Guid[] {Guid.Empty} ;
         P007C2_A357ManagerPhoneCode = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         A357ManagerPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_managerloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007C2_A11OrganisationId, P007C2_A21ManagerId, P007C2_A357ManagerPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV2 ;
      private int AV26GXV3 ;
      private string AV14TrnMode ;
      private bool returnInSub ;
      private string AV13ComboName ;
      private string AV17SelectedValue ;
      private string AV18SelectedText ;
      private string A357ManagerPhoneCode ;
      private Guid AV15ManagerId ;
      private Guid AV16OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV23GXV1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV22ManagerPhoneCode_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GxSimpleCollection<string> AV21ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007C2_A11OrganisationId ;
      private Guid[] P007C2_A21ManagerId ;
      private string[] P007C2_A357ManagerPhoneCode ;
      private string aP4_SelectedValue ;
      private string aP5_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP6_Combo_Data ;
   }

   public class trn_managerloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007C2;
          prmP007C2 = new Object[] {
          new ParDef("AV15ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007C2", "SELECT OrganisationId, ManagerId, ManagerPhoneCode FROM Trn_Manager WHERE ManagerId = :AV15ManagerId and OrganisationId = :AV16OrganisationId ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
