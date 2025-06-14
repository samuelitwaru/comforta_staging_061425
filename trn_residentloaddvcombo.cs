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
   public class trn_residentloaddvcombo : GXProcedure
   {
      public trn_residentloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ResidentId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ResidentId = aP2_ResidentId;
         this.AV21LocationId = aP3_LocationId;
         this.AV22OrganisationId = aP4_OrganisationId;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV24SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_ResidentId ,
                                                                                                  Guid aP3_LocationId ,
                                                                                                  Guid aP4_OrganisationId ,
                                                                                                  out string aP5_SelectedValue ,
                                                                                                  out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ResidentId, aP3_LocationId, aP4_OrganisationId, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ResidentId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ResidentId = aP2_ResidentId;
         this.AV21LocationId = aP3_LocationId;
         this.AV22OrganisationId = aP4_OrganisationId;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP5_SelectedValue=this.AV24SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "ResidentTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTTYPEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentPackageId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTPACKAGEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTCOUNTRY' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentHomePhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTHOMEPHONECODE' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTPHONECODE' */
            S151 ();
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
         /* 'LOADCOMBOITEMS_RESIDENTTYPEID' Routine */
         returnInSub = false;
         /* Using cursor P006Q2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A96ResidentTypeId = P006Q2_A96ResidentTypeId[0];
            n96ResidentTypeId = P006Q2_n96ResidentTypeId[0];
            A97ResidentTypeName = P006Q2_A97ResidentTypeName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P006Q3 */
            pr_default.execute(1, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P006Q3_A11OrganisationId[0];
               A29LocationId = P006Q3_A29LocationId[0];
               A62ResidentId = P006Q3_A62ResidentId[0];
               A96ResidentTypeId = P006Q3_A96ResidentTypeId[0];
               n96ResidentTypeId = P006Q3_n96ResidentTypeId[0];
               AV24SelectedValue = ((Guid.Empty==A96ResidentTypeId) ? "" : StringUtil.Trim( A96ResidentTypeId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTPACKAGEID' Routine */
         returnInSub = false;
         AV52Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P006Q4 */
         pr_default.execute(2, new Object[] {AV52Udparg1});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A528SG_LocationId = P006Q4_A528SG_LocationId[0];
            A527ResidentPackageId = P006Q4_A527ResidentPackageId[0];
            n527ResidentPackageId = P006Q4_n527ResidentPackageId[0];
            A531ResidentPackageName = P006Q4_A531ResidentPackageName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A527ResidentPackageId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A531ResidentPackageName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006Q5 */
            pr_default.execute(3, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A11OrganisationId = P006Q5_A11OrganisationId[0];
               A29LocationId = P006Q5_A29LocationId[0];
               A62ResidentId = P006Q5_A62ResidentId[0];
               A527ResidentPackageId = P006Q5_A527ResidentPackageId[0];
               n527ResidentPackageId = P006Q5_n527ResidentPackageId[0];
               AV24SelectedValue = ((Guid.Empty==A527ResidentPackageId) ? "" : StringUtil.Trim( A527ResidentPackageId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV55GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV54GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV54GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV55GXV2 <= AV54GXV1.Count )
         {
            AV39ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV54GXV1.Item(AV55GXV2));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV39ResidentCountry_DPItem.gxTpr_Countryname;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV55GXV2 = (int)(AV55GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006Q6 */
            pr_default.execute(4, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A11OrganisationId = P006Q6_A11OrganisationId[0];
               A29LocationId = P006Q6_A29LocationId[0];
               A62ResidentId = P006Q6_A62ResidentId[0];
               A312ResidentCountry = P006Q6_A312ResidentCountry[0];
               AV24SelectedValue = A312ResidentCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV57GXV3 = 1;
               while ( AV57GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV57GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV57GXV3 = (int)(AV57GXV3+1);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         AV59GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV58GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV58GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV59GXV5 <= AV58GXV4.Count )
         {
            AV41ResidentHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV58GXV4.Item(AV59GXV5));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV59GXV5 = (int)(AV59GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006Q7 */
            pr_default.execute(5, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A11OrganisationId = P006Q7_A11OrganisationId[0];
               A29LocationId = P006Q7_A29LocationId[0];
               A62ResidentId = P006Q7_A62ResidentId[0];
               A431ResidentHomePhoneCode = P006Q7_A431ResidentHomePhoneCode[0];
               AV24SelectedValue = A431ResidentHomePhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV61GXV6 = 1;
               while ( AV61GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV61GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV61GXV6 = (int)(AV61GXV6+1);
               }
            }
         }
      }

      protected void S151( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV63GXV8 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV62GXV7;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV62GXV7 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV63GXV8 <= AV62GXV7.Count )
         {
            AV40ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV62GXV7.Item(AV63GXV8));
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV63GXV8 = (int)(AV63GXV8+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006Q8 */
            pr_default.execute(6, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A11OrganisationId = P006Q8_A11OrganisationId[0];
               A29LocationId = P006Q8_A29LocationId[0];
               A62ResidentId = P006Q8_A62ResidentId[0];
               A347ResidentPhoneCode = P006Q8_A347ResidentPhoneCode[0];
               AV24SelectedValue = A347ResidentPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV65GXV9 = 1;
               while ( AV65GXV9 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV65GXV9));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV65GXV9 = (int)(AV65GXV9+1);
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
         AV24SelectedValue = "";
         AV25SelectedText = "";
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P006Q2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006Q2_n96ResidentTypeId = new bool[] {false} ;
         P006Q2_A97ResidentTypeName = new string[] {""} ;
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         P006Q3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006Q3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006Q3_n96ResidentTypeId = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV52Udparg1 = Guid.Empty;
         P006Q4_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P006Q4_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P006Q4_n527ResidentPackageId = new bool[] {false} ;
         P006Q4_A531ResidentPackageName = new string[] {""} ;
         A528SG_LocationId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         A531ResidentPackageName = "";
         P006Q5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q5_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006Q5_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P006Q5_n527ResidentPackageId = new bool[] {false} ;
         AV54GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV39ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV38ComboTitles = new GxSimpleCollection<string>();
         P006Q6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q6_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006Q6_A312ResidentCountry = new string[] {""} ;
         A312ResidentCountry = "";
         AV58GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV41ResidentHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P006Q7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q7_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q7_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006Q7_A431ResidentHomePhoneCode = new string[] {""} ;
         A431ResidentHomePhoneCode = "";
         AV62GXV7 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV40ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P006Q8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q8_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q8_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006Q8_A347ResidentPhoneCode = new string[] {""} ;
         A347ResidentPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A96ResidentTypeId, P006Q2_A97ResidentTypeName
               }
               , new Object[] {
               P006Q3_A11OrganisationId, P006Q3_A29LocationId, P006Q3_A62ResidentId, P006Q3_A96ResidentTypeId, P006Q3_n96ResidentTypeId
               }
               , new Object[] {
               P006Q4_A528SG_LocationId, P006Q4_A527ResidentPackageId, P006Q4_A531ResidentPackageName
               }
               , new Object[] {
               P006Q5_A11OrganisationId, P006Q5_A29LocationId, P006Q5_A62ResidentId, P006Q5_A527ResidentPackageId, P006Q5_n527ResidentPackageId
               }
               , new Object[] {
               P006Q6_A11OrganisationId, P006Q6_A29LocationId, P006Q6_A62ResidentId, P006Q6_A312ResidentCountry
               }
               , new Object[] {
               P006Q7_A11OrganisationId, P006Q7_A29LocationId, P006Q7_A62ResidentId, P006Q7_A431ResidentHomePhoneCode
               }
               , new Object[] {
               P006Q8_A11OrganisationId, P006Q8_A29LocationId, P006Q8_A62ResidentId, P006Q8_A347ResidentPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV55GXV2 ;
      private int AV57GXV3 ;
      private int AV59GXV5 ;
      private int AV61GXV6 ;
      private int AV63GXV8 ;
      private int AV65GXV9 ;
      private string AV18TrnMode ;
      private bool returnInSub ;
      private bool n96ResidentTypeId ;
      private bool n527ResidentPackageId ;
      private string AV17ComboName ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string A97ResidentTypeName ;
      private string A531ResidentPackageName ;
      private string A312ResidentCountry ;
      private string A431ResidentHomePhoneCode ;
      private string A347ResidentPhoneCode ;
      private Guid AV20ResidentId ;
      private Guid AV21LocationId ;
      private Guid AV22OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid AV52Udparg1 ;
      private Guid A528SG_LocationId ;
      private Guid A527ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Q2_A96ResidentTypeId ;
      private bool[] P006Q2_n96ResidentTypeId ;
      private string[] P006Q2_A97ResidentTypeName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private Guid[] P006Q3_A11OrganisationId ;
      private Guid[] P006Q3_A29LocationId ;
      private Guid[] P006Q3_A62ResidentId ;
      private Guid[] P006Q3_A96ResidentTypeId ;
      private bool[] P006Q3_n96ResidentTypeId ;
      private Guid[] P006Q4_A528SG_LocationId ;
      private Guid[] P006Q4_A527ResidentPackageId ;
      private bool[] P006Q4_n527ResidentPackageId ;
      private string[] P006Q4_A531ResidentPackageName ;
      private Guid[] P006Q5_A11OrganisationId ;
      private Guid[] P006Q5_A29LocationId ;
      private Guid[] P006Q5_A62ResidentId ;
      private Guid[] P006Q5_A527ResidentPackageId ;
      private bool[] P006Q5_n527ResidentPackageId ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV54GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV39ResidentCountry_DPItem ;
      private GxSimpleCollection<string> AV38ComboTitles ;
      private Guid[] P006Q6_A11OrganisationId ;
      private Guid[] P006Q6_A29LocationId ;
      private Guid[] P006Q6_A62ResidentId ;
      private string[] P006Q6_A312ResidentCountry ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV58GXV4 ;
      private SdtSDT_Country_SDT_CountryItem AV41ResidentHomePhoneCode_DPItem ;
      private Guid[] P006Q7_A11OrganisationId ;
      private Guid[] P006Q7_A29LocationId ;
      private Guid[] P006Q7_A62ResidentId ;
      private string[] P006Q7_A431ResidentHomePhoneCode ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV62GXV7 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV40ResidentPhoneCode_DPItem ;
      private Guid[] P006Q8_A11OrganisationId ;
      private Guid[] P006Q8_A29LocationId ;
      private Guid[] P006Q8_A62ResidentId ;
      private string[] P006Q8_A347ResidentPhoneCode ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP7_Combo_Data ;
   }

   public class trn_residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          };
          Object[] prmP006Q3;
          prmP006Q3 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006Q4;
          prmP006Q4 = new Object[] {
          new ParDef("AV52Udparg1",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006Q5;
          prmP006Q5 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006Q6;
          prmP006Q6 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006Q7;
          prmP006Q7 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006Q8;
          prmP006Q8 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006Q3", "SELECT OrganisationId, LocationId, ResidentId, ResidentTypeId FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Q4", "SELECT SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE SG_LocationId = :AV52Udparg1 ORDER BY ResidentPackageName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006Q5", "SELECT OrganisationId, LocationId, ResidentId, ResidentPackageId FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Q6", "SELECT OrganisationId, LocationId, ResidentId, ResidentCountry FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Q7", "SELECT OrganisationId, LocationId, ResidentId, ResidentHomePhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Q8", "SELECT OrganisationId, LocationId, ResidentId, ResidentPhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q8,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
