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
   public class wp_organisationagbsuppliersgetfilterdata : GXProcedure
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
            return "wp_organisationagbsuppliers_Services_Execute" ;
         }

      }

      public wp_organisationagbsuppliersgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationagbsuppliersgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBEMAILOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("WP_OrganisationAGBSuppliersGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WP_OrganisationAGBSuppliersGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WP_OrganisationAGBSuppliersGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV47TFSupplierAgbNameOperator = AV35GridStateFilterValue.gxTpr_Operator;
               if ( AV47TFSupplierAgbNameOperator == 0 )
               {
                  AV11TFSupplierAgbName = AV35GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV12TFSupplierAgbName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV13TFSupplierAgbTypeName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV14TFSupplierAgbTypeName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME") == 0 )
            {
               AV15TFSupplierAgbContactName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME_SEL") == 0 )
            {
               AV16TFSupplierAgbContactName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE") == 0 )
            {
               AV17TFSupplierAgbPhone = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE_SEL") == 0 )
            {
               AV18TFSupplierAgbPhone_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL") == 0 )
            {
               AV19TFSupplierAgbEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL_SEL") == 0 )
            {
               AV20TFSupplierAgbEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERAGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFSupplierAgbName = AV21SearchTxt;
         AV47TFSupplierAgbNameOperator = 0;
         AV12TFSupplierAgbName_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = AV43FilterFullText;
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV11TFSupplierAgbName;
         AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV47TFSupplierAgbNameOperator;
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV12TFSupplierAgbName_Sel;
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV15TFSupplierAgbContactName;
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV16TFSupplierAgbContactName_Sel;
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV17TFSupplierAgbPhone;
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV18TFSupplierAgbPhone_Sel;
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV19TFSupplierAgbEmail;
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV20TFSupplierAgbEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV48isSelected } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor P007X2 */
         pr_default.execute(0, new Object[] {lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV48isSelected, lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7X2 = false;
            A255SupplierAgbTypeId = P007X2_A255SupplierAgbTypeId[0];
            A51SupplierAgbName = P007X2_A51SupplierAgbName[0];
            A57SupplierAgbEmail = P007X2_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P007X2_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P007X2_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P007X2_A256SupplierAgbTypeName[0];
            A49SupplierAgbId = P007X2_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P007X2_A256SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007X2_A51SupplierAgbName[0], A51SupplierAgbName) == 0 ) )
            {
               BRK7X2 = false;
               A49SupplierAgbId = P007X2_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK7X2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) ? "<#Empty#>" : A51SupplierAgbName);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK7X2 )
            {
               BRK7X2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIERAGBTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplierAgbTypeName = AV21SearchTxt;
         AV14TFSupplierAgbTypeName_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = AV43FilterFullText;
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV11TFSupplierAgbName;
         AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV47TFSupplierAgbNameOperator;
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV12TFSupplierAgbName_Sel;
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV15TFSupplierAgbContactName;
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV16TFSupplierAgbContactName_Sel;
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV17TFSupplierAgbPhone;
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV18TFSupplierAgbPhone_Sel;
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV19TFSupplierAgbEmail;
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV20TFSupplierAgbEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV48isSelected } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor P007X3 */
         pr_default.execute(1, new Object[] {lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV48isSelected, lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7X4 = false;
            A255SupplierAgbTypeId = P007X3_A255SupplierAgbTypeId[0];
            A57SupplierAgbEmail = P007X3_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P007X3_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P007X3_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P007X3_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P007X3_A51SupplierAgbName[0];
            A49SupplierAgbId = P007X3_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P007X3_A256SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P007X3_A255SupplierAgbTypeId[0] == A255SupplierAgbTypeId ) )
            {
               BRK7X4 = false;
               A49SupplierAgbId = P007X3_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK7X4 = true;
               pr_default.readNext(1);
            }
            AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A256SupplierAgbTypeName)) ? "<#Empty#>" : A256SupplierAgbTypeName);
            AV25InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV25InsertIndex = (int)(AV25InsertIndex+1);
            }
            AV27Options.Add(AV26Option, AV25InsertIndex);
            AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
            if ( AV27Options.Count == AV22SkipItems + 11 )
            {
               AV27Options.RemoveItem(AV27Options.Count);
               AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
            }
            if ( ! BRK7X4 )
            {
               BRK7X4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplierAgbContactName = AV21SearchTxt;
         AV16TFSupplierAgbContactName_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = AV43FilterFullText;
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV11TFSupplierAgbName;
         AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV47TFSupplierAgbNameOperator;
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV12TFSupplierAgbName_Sel;
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV15TFSupplierAgbContactName;
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV16TFSupplierAgbContactName_Sel;
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV17TFSupplierAgbPhone;
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV18TFSupplierAgbPhone_Sel;
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV19TFSupplierAgbEmail;
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV20TFSupplierAgbEmail_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV48isSelected } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor P007X4 */
         pr_default.execute(2, new Object[] {lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV48isSelected, lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7X6 = false;
            A255SupplierAgbTypeId = P007X4_A255SupplierAgbTypeId[0];
            A55SupplierAgbContactName = P007X4_A55SupplierAgbContactName[0];
            A57SupplierAgbEmail = P007X4_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P007X4_A56SupplierAgbPhone[0];
            A256SupplierAgbTypeName = P007X4_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P007X4_A51SupplierAgbName[0];
            A49SupplierAgbId = P007X4_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P007X4_A256SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007X4_A55SupplierAgbContactName[0], A55SupplierAgbContactName) == 0 ) )
            {
               BRK7X6 = false;
               A49SupplierAgbId = P007X4_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK7X6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A55SupplierAgbContactName)) ? "<#Empty#>" : A55SupplierAgbContactName);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK7X6 )
            {
               BRK7X6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERAGBPHONEOPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplierAgbPhone = AV21SearchTxt;
         AV18TFSupplierAgbPhone_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = AV43FilterFullText;
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV11TFSupplierAgbName;
         AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV47TFSupplierAgbNameOperator;
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV12TFSupplierAgbName_Sel;
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV15TFSupplierAgbContactName;
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV16TFSupplierAgbContactName_Sel;
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV17TFSupplierAgbPhone;
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV18TFSupplierAgbPhone_Sel;
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV19TFSupplierAgbEmail;
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV20TFSupplierAgbEmail_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV48isSelected } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor P007X5 */
         pr_default.execute(3, new Object[] {lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV48isSelected, lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7X8 = false;
            A255SupplierAgbTypeId = P007X5_A255SupplierAgbTypeId[0];
            A56SupplierAgbPhone = P007X5_A56SupplierAgbPhone[0];
            A57SupplierAgbEmail = P007X5_A57SupplierAgbEmail[0];
            A55SupplierAgbContactName = P007X5_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P007X5_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P007X5_A51SupplierAgbName[0];
            A49SupplierAgbId = P007X5_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P007X5_A256SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007X5_A56SupplierAgbPhone[0], A56SupplierAgbPhone) == 0 ) )
            {
               BRK7X8 = false;
               A49SupplierAgbId = P007X5_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK7X8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A56SupplierAgbPhone)) ? "<#Empty#>" : A56SupplierAgbPhone);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK7X8 )
            {
               BRK7X8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIERAGBEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplierAgbEmail = AV21SearchTxt;
         AV20TFSupplierAgbEmail_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = AV43FilterFullText;
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = AV11TFSupplierAgbName;
         AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator = AV47TFSupplierAgbNameOperator;
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = AV12TFSupplierAgbName_Sel;
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = AV15TFSupplierAgbContactName;
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = AV16TFSupplierAgbContactName_Sel;
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = AV17TFSupplierAgbPhone;
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = AV18TFSupplierAgbPhone_Sel;
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = AV19TFSupplierAgbEmail;
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = AV20TFSupplierAgbEmail_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                              AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                              AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                              AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                              AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                              AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                              AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                              AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                              AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                              AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                              AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                              AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              AV48isSelected } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext), "%", "");
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname), "%", "");
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename), "%", "");
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname), "%", "");
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone), 20, "%");
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail), "%", "");
         /* Using cursor P007X6 */
         pr_default.execute(4, new Object[] {lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV52Wp_organisationagbsuppliersds_1_filterfulltext, lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname, AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, AV48isSelected, lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename, AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname, AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone, AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail, AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7X10 = false;
            A255SupplierAgbTypeId = P007X6_A255SupplierAgbTypeId[0];
            A57SupplierAgbEmail = P007X6_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P007X6_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P007X6_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P007X6_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P007X6_A51SupplierAgbName[0];
            A49SupplierAgbId = P007X6_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P007X6_A256SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P007X6_A57SupplierAgbEmail[0], A57SupplierAgbEmail) == 0 ) )
            {
               BRK7X10 = false;
               A49SupplierAgbId = P007X6_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK7X10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A57SupplierAgbEmail)) ? "<#Empty#>" : A57SupplierAgbEmail);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK7X10 )
            {
               BRK7X10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV35GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV11TFSupplierAgbName = "";
         AV12TFSupplierAgbName_Sel = "";
         AV13TFSupplierAgbTypeName = "";
         AV14TFSupplierAgbTypeName_Sel = "";
         AV15TFSupplierAgbContactName = "";
         AV16TFSupplierAgbContactName_Sel = "";
         AV17TFSupplierAgbPhone = "";
         AV18TFSupplierAgbPhone_Sel = "";
         AV19TFSupplierAgbEmail = "";
         AV20TFSupplierAgbEmail_Sel = "";
         AV52Wp_organisationagbsuppliersds_1_filterfulltext = "";
         AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = "";
         AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel = "";
         AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = "";
         AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel = "";
         AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = "";
         AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel = "";
         AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = "";
         AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel = "";
         AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = "";
         AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel = "";
         lV52Wp_organisationagbsuppliersds_1_filterfulltext = "";
         lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname = "";
         lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename = "";
         lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname = "";
         lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone = "";
         lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail = "";
         A51SupplierAgbName = "";
         A256SupplierAgbTypeName = "";
         A55SupplierAgbContactName = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         P007X2_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P007X2_A51SupplierAgbName = new string[] {""} ;
         P007X2_A57SupplierAgbEmail = new string[] {""} ;
         P007X2_A56SupplierAgbPhone = new string[] {""} ;
         P007X2_A55SupplierAgbContactName = new string[] {""} ;
         P007X2_A256SupplierAgbTypeName = new string[] {""} ;
         P007X2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         A255SupplierAgbTypeId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         AV26Option = "";
         P007X3_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P007X3_A57SupplierAgbEmail = new string[] {""} ;
         P007X3_A56SupplierAgbPhone = new string[] {""} ;
         P007X3_A55SupplierAgbContactName = new string[] {""} ;
         P007X3_A256SupplierAgbTypeName = new string[] {""} ;
         P007X3_A51SupplierAgbName = new string[] {""} ;
         P007X3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P007X4_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P007X4_A55SupplierAgbContactName = new string[] {""} ;
         P007X4_A57SupplierAgbEmail = new string[] {""} ;
         P007X4_A56SupplierAgbPhone = new string[] {""} ;
         P007X4_A256SupplierAgbTypeName = new string[] {""} ;
         P007X4_A51SupplierAgbName = new string[] {""} ;
         P007X4_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P007X5_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P007X5_A56SupplierAgbPhone = new string[] {""} ;
         P007X5_A57SupplierAgbEmail = new string[] {""} ;
         P007X5_A55SupplierAgbContactName = new string[] {""} ;
         P007X5_A256SupplierAgbTypeName = new string[] {""} ;
         P007X5_A51SupplierAgbName = new string[] {""} ;
         P007X5_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P007X6_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P007X6_A57SupplierAgbEmail = new string[] {""} ;
         P007X6_A56SupplierAgbPhone = new string[] {""} ;
         P007X6_A55SupplierAgbContactName = new string[] {""} ;
         P007X6_A256SupplierAgbTypeName = new string[] {""} ;
         P007X6_A51SupplierAgbName = new string[] {""} ;
         P007X6_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationagbsuppliersgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007X2_A255SupplierAgbTypeId, P007X2_A51SupplierAgbName, P007X2_A57SupplierAgbEmail, P007X2_A56SupplierAgbPhone, P007X2_A55SupplierAgbContactName, P007X2_A256SupplierAgbTypeName, P007X2_A49SupplierAgbId
               }
               , new Object[] {
               P007X3_A255SupplierAgbTypeId, P007X3_A57SupplierAgbEmail, P007X3_A56SupplierAgbPhone, P007X3_A55SupplierAgbContactName, P007X3_A256SupplierAgbTypeName, P007X3_A51SupplierAgbName, P007X3_A49SupplierAgbId
               }
               , new Object[] {
               P007X4_A255SupplierAgbTypeId, P007X4_A55SupplierAgbContactName, P007X4_A57SupplierAgbEmail, P007X4_A56SupplierAgbPhone, P007X4_A256SupplierAgbTypeName, P007X4_A51SupplierAgbName, P007X4_A49SupplierAgbId
               }
               , new Object[] {
               P007X5_A255SupplierAgbTypeId, P007X5_A56SupplierAgbPhone, P007X5_A57SupplierAgbEmail, P007X5_A55SupplierAgbContactName, P007X5_A256SupplierAgbTypeName, P007X5_A51SupplierAgbName, P007X5_A49SupplierAgbId
               }
               , new Object[] {
               P007X6_A255SupplierAgbTypeId, P007X6_A57SupplierAgbEmail, P007X6_A56SupplierAgbPhone, P007X6_A55SupplierAgbContactName, P007X6_A256SupplierAgbTypeName, P007X6_A51SupplierAgbName, P007X6_A49SupplierAgbId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV47TFSupplierAgbNameOperator ;
      private short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ;
      private int AV50GXV1 ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private string AV17TFSupplierAgbPhone ;
      private string AV18TFSupplierAgbPhone_Sel ;
      private string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ;
      private string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ;
      private string lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ;
      private string A56SupplierAgbPhone ;
      private bool returnInSub ;
      private bool AV48isSelected ;
      private bool BRK7X2 ;
      private bool BRK7X4 ;
      private bool BRK7X6 ;
      private bool BRK7X8 ;
      private bool BRK7X10 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV11TFSupplierAgbName ;
      private string AV12TFSupplierAgbName_Sel ;
      private string AV13TFSupplierAgbTypeName ;
      private string AV14TFSupplierAgbTypeName_Sel ;
      private string AV15TFSupplierAgbContactName ;
      private string AV16TFSupplierAgbContactName_Sel ;
      private string AV19TFSupplierAgbEmail ;
      private string AV20TFSupplierAgbEmail_Sel ;
      private string AV52Wp_organisationagbsuppliersds_1_filterfulltext ;
      private string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ;
      private string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ;
      private string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ;
      private string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ;
      private string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ;
      private string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ;
      private string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ;
      private string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ;
      private string lV52Wp_organisationagbsuppliersds_1_filterfulltext ;
      private string lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ;
      private string lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ;
      private string lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ;
      private string lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ;
      private string A51SupplierAgbName ;
      private string A256SupplierAgbTypeName ;
      private string A55SupplierAgbContactName ;
      private string A57SupplierAgbEmail ;
      private string AV26Option ;
      private Guid A255SupplierAgbTypeId ;
      private Guid A49SupplierAgbId ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV34GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007X2_A255SupplierAgbTypeId ;
      private string[] P007X2_A51SupplierAgbName ;
      private string[] P007X2_A57SupplierAgbEmail ;
      private string[] P007X2_A56SupplierAgbPhone ;
      private string[] P007X2_A55SupplierAgbContactName ;
      private string[] P007X2_A256SupplierAgbTypeName ;
      private Guid[] P007X2_A49SupplierAgbId ;
      private Guid[] P007X3_A255SupplierAgbTypeId ;
      private string[] P007X3_A57SupplierAgbEmail ;
      private string[] P007X3_A56SupplierAgbPhone ;
      private string[] P007X3_A55SupplierAgbContactName ;
      private string[] P007X3_A256SupplierAgbTypeName ;
      private string[] P007X3_A51SupplierAgbName ;
      private Guid[] P007X3_A49SupplierAgbId ;
      private Guid[] P007X4_A255SupplierAgbTypeId ;
      private string[] P007X4_A55SupplierAgbContactName ;
      private string[] P007X4_A57SupplierAgbEmail ;
      private string[] P007X4_A56SupplierAgbPhone ;
      private string[] P007X4_A256SupplierAgbTypeName ;
      private string[] P007X4_A51SupplierAgbName ;
      private Guid[] P007X4_A49SupplierAgbId ;
      private Guid[] P007X5_A255SupplierAgbTypeId ;
      private string[] P007X5_A56SupplierAgbPhone ;
      private string[] P007X5_A57SupplierAgbEmail ;
      private string[] P007X5_A55SupplierAgbContactName ;
      private string[] P007X5_A256SupplierAgbTypeName ;
      private string[] P007X5_A51SupplierAgbName ;
      private Guid[] P007X5_A49SupplierAgbId ;
      private Guid[] P007X6_A255SupplierAgbTypeId ;
      private string[] P007X6_A57SupplierAgbEmail ;
      private string[] P007X6_A56SupplierAgbPhone ;
      private string[] P007X6_A55SupplierAgbContactName ;
      private string[] P007X6_A256SupplierAgbTypeName ;
      private string[] P007X6_A51SupplierAgbName ;
      private Guid[] P007X6_A49SupplierAgbId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_organisationagbsuppliersgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007X2( IGxContext context ,
                                             string AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                             string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                             string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                             short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                             string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                             string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                             string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                             string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                             string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                             string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                             string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                             string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             bool AV48isSelected )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbName, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV48isSelected = TRUE)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007X3( IGxContext context ,
                                             string AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                             string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                             string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                             short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                             string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                             string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                             string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                             string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                             string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                             string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                             string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                             string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             bool AV48isSelected )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV48isSelected = TRUE)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007X4( IGxContext context ,
                                             string AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                             string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                             string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                             short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                             string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                             string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                             string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                             string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                             string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                             string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                             string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                             string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             bool AV48isSelected )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbContactName, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV48isSelected = TRUE)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007X5( IGxContext context ,
                                             string AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                             string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                             string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                             short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                             string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                             string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                             string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                             string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                             string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                             string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                             string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                             string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             bool AV48isSelected )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbPhone, T1.SupplierAgbEmail, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV48isSelected = TRUE)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P007X6( IGxContext context ,
                                             string AV52Wp_organisationagbsuppliersds_1_filterfulltext ,
                                             string AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel ,
                                             string AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname ,
                                             short AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator ,
                                             string AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel ,
                                             string AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename ,
                                             string AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel ,
                                             string AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname ,
                                             string AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel ,
                                             string AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone ,
                                             string AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel ,
                                             string AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             bool AV48isSelected )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[16];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationagbsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV52Wp_organisationagbsuppliersds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( AV54Wp_organisationagbsuppliersds_3_tfsupplieragbnameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV48isSelected = TRUE)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbEmail";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_P007X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] );
               case 2 :
                     return conditional_P007X4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] );
               case 3 :
                     return conditional_P007X5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] );
               case 4 :
                     return conditional_P007X6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP007X2;
          prmP007X2 = new Object[] {
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV48isSelected",GXType.Boolean,4,0) ,
          new ParDef("lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
          new ParDef("lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007X3;
          prmP007X3 = new Object[] {
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV48isSelected",GXType.Boolean,4,0) ,
          new ParDef("lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
          new ParDef("lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007X4;
          prmP007X4 = new Object[] {
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV48isSelected",GXType.Boolean,4,0) ,
          new ParDef("lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
          new ParDef("lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007X5;
          prmP007X5 = new Object[] {
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV48isSelected",GXType.Boolean,4,0) ,
          new ParDef("lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
          new ParDef("lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007X6;
          prmP007X6 = new Object[] {
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wp_organisationagbsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationagbsuppliersds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationagbsuppliersds_4_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV48isSelected",GXType.Boolean,4,0) ,
          new ParDef("lV56Wp_organisationagbsuppliersds_5_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV57Wp_organisationagbsuppliersds_6_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Wp_organisationagbsuppliersds_7_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV59Wp_organisationagbsuppliersds_8_tfsupplieragbcontactname_se",GXType.VarChar,100,0) ,
          new ParDef("lV60Wp_organisationagbsuppliersds_9_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV61Wp_organisationagbsuppliersds_10_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV62Wp_organisationagbsuppliersds_11_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV63Wp_organisationagbsuppliersds_12_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007X4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007X5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007X6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
