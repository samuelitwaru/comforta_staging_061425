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
   public class trn_organisationloaddvcombo : GXProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_organisation_Services_Execute" ;
         }

      }

      public trn_organisationloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_OrganisationId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20OrganisationId = aP3_OrganisationId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_OrganisationId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_OrganisationId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_OrganisationId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20OrganisationId = aP3_OrganisationId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "OrganisationAddressCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONADDRESSCOUNTRY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "OrganisationTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONTYPEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "OrganisationPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONPHONECODE' */
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
         /* 'LOADCOMBOITEMS_ORGANISATIONADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV34GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV33GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV33GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV34GXV2 <= AV33GXV1.Count )
         {
            AV31OrganisationAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV33GXV1.Item(AV34GXV2));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV31OrganisationAddressCountry_DPItem.gxTpr_Countryname;
            AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV30ComboTitles.Add(AV31OrganisationAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV30ComboTitles.Add(AV31OrganisationAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV30ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P005W2 */
            pr_default.execute(0, new Object[] {AV20OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P005W2_A11OrganisationId[0];
               A303OrganisationAddressCountry = P005W2_A303OrganisationAddressCountry[0];
               AV22SelectedValue = A303OrganisationAddressCountry;
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
                     AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV30ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV30ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV36GXV3 = (int)(AV36GXV3+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_ORGANISATIONTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom3 = AV12SkipItems;
            GXPagingTo3 = AV11MaxItems;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A20OrganisationTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P005W3 */
            pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A20OrganisationTypeName = P005W3_A20OrganisationTypeName[0];
               A19OrganisationTypeId = P005W3_A19OrganisationTypeId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A19OrganisationTypeId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A20OrganisationTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P005W4 */
                  pr_default.execute(2, new Object[] {AV20OrganisationId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A11OrganisationId = P005W4_A11OrganisationId[0];
                     A19OrganisationTypeId = P005W4_A19OrganisationTypeId[0];
                     A20OrganisationTypeName = P005W4_A20OrganisationTypeName[0];
                     A20OrganisationTypeName = P005W4_A20OrganisationTypeName[0];
                     AV22SelectedValue = ((Guid.Empty==A19OrganisationTypeId) ? "" : StringUtil.Trim( A19OrganisationTypeId.ToString()));
                     AV23SelectedText = A20OrganisationTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
               else
               {
                  AV28OrganisationTypeId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P005W5 */
                  pr_default.execute(3, new Object[] {AV28OrganisationTypeId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A19OrganisationTypeId = P005W5_A19OrganisationTypeId[0];
                     A20OrganisationTypeName = P005W5_A20OrganisationTypeName[0];
                     AV23SelectedText = A20OrganisationTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_ORGANISATIONPHONECODE' Routine */
         returnInSub = false;
         AV41GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV40GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV40GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV41GXV5 <= AV40GXV4.Count )
         {
            AV32OrganisationPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV40GXV4.Item(AV41GXV5));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV32OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV30ComboTitles.Add(AV32OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV30ComboTitles.Add(AV32OrganisationPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV30ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV41GXV5 = (int)(AV41GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P005W6 */
            pr_default.execute(4, new Object[] {AV20OrganisationId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A11OrganisationId = P005W6_A11OrganisationId[0];
               A361OrganisationPhoneCode = P005W6_A361OrganisationPhoneCode[0];
               AV22SelectedValue = A361OrganisationPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV43GXV6 = 1;
               while ( AV43GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV43GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV30ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV30ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV43GXV6 = (int)(AV43GXV6+1);
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
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV33GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV31OrganisationAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV30ComboTitles = new GxSimpleCollection<string>();
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005W2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005W2_A303OrganisationAddressCountry = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A303OrganisationAddressCountry = "";
         lV14SearchTxt = "";
         A20OrganisationTypeName = "";
         P005W3_A20OrganisationTypeName = new string[] {""} ;
         P005W3_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         A19OrganisationTypeId = Guid.Empty;
         P005W4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005W4_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005W4_A20OrganisationTypeName = new string[] {""} ;
         AV28OrganisationTypeId = Guid.Empty;
         P005W5_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005W5_A20OrganisationTypeName = new string[] {""} ;
         AV40GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV32OrganisationPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P005W6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005W6_A361OrganisationPhoneCode = new string[] {""} ;
         A361OrganisationPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005W2_A11OrganisationId, P005W2_A303OrganisationAddressCountry
               }
               , new Object[] {
               P005W3_A20OrganisationTypeName, P005W3_A19OrganisationTypeId
               }
               , new Object[] {
               P005W4_A11OrganisationId, P005W4_A19OrganisationTypeId, P005W4_A20OrganisationTypeName
               }
               , new Object[] {
               P005W5_A19OrganisationTypeId, P005W5_A20OrganisationTypeName
               }
               , new Object[] {
               P005W6_A11OrganisationId, P005W6_A361OrganisationPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int AV34GXV2 ;
      private int AV36GXV3 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int AV41GXV5 ;
      private int AV43GXV6 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string A303OrganisationAddressCountry ;
      private string lV14SearchTxt ;
      private string A20OrganisationTypeName ;
      private string A361OrganisationPhoneCode ;
      private Guid AV20OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private Guid AV28OrganisationTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV33GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV31OrganisationAddressCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GxSimpleCollection<string> AV30ComboTitles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005W2_A11OrganisationId ;
      private string[] P005W2_A303OrganisationAddressCountry ;
      private string[] P005W3_A20OrganisationTypeName ;
      private Guid[] P005W3_A19OrganisationTypeId ;
      private Guid[] P005W4_A11OrganisationId ;
      private Guid[] P005W4_A19OrganisationTypeId ;
      private string[] P005W4_A20OrganisationTypeName ;
      private Guid[] P005W5_A19OrganisationTypeId ;
      private string[] P005W5_A20OrganisationTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV40GXV4 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV32OrganisationPhoneCode_DPItem ;
      private Guid[] P005W6_A11OrganisationId ;
      private string[] P005W6_A361OrganisationPhoneCode ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_organisationloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A20OrganisationTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationTypeName, OrganisationTypeId";
         sFromString = " FROM Trn_OrganisationType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(OrganisationTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString += " ORDER BY OrganisationTypeName, OrganisationTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P005W3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005W4;
          prmP005W4 = new Object[] {
          new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005W5;
          prmP005W5 = new Object[] {
          new ParDef("AV28OrganisationTypeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005W6;
          prmP005W6 = new Object[] {
          new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005W3;
          prmP005W3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "SELECT OrganisationId, OrganisationAddressCountry FROM Trn_Organisation WHERE OrganisationId = :AV20OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005W4", "SELECT T1.OrganisationId, T1.OrganisationTypeId, T2.OrganisationTypeName FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId) WHERE T1.OrganisationId = :AV20OrganisationId ORDER BY T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005W5", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :AV28OrganisationTypeId ORDER BY OrganisationTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005W6", "SELECT OrganisationId, OrganisationPhoneCode FROM Trn_Organisation WHERE OrganisationId = :AV20OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
