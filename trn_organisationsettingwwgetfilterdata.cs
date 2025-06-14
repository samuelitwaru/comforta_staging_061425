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
   public class trn_organisationsettingwwgetfilterdata : GXProcedure
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
            return "trn_organisationsettingww_Services_Execute" ;
         }

      }

      public trn_organisationsettingwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationsettingwwgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_ORGANISATIONSETTINGBASECOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONSETTINGBASECOLOROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_ORGANISATIONSETTINGFONTSIZE") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONSETTINGFONTSIZEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_ORGANISATIONSETTINGLANGUAGE") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONSETTINGLANGUAGEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("Trn_OrganisationSettingWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_OrganisationSettingWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Trn_OrganisationSettingWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGBASECOLOR") == 0 )
            {
               AV11TFOrganisationSettingBaseColor = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGBASECOLOR_SEL") == 0 )
            {
               AV12TFOrganisationSettingBaseColor_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGFONTSIZE") == 0 )
            {
               AV13TFOrganisationSettingFontSize = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGFONTSIZE_SEL") == 0 )
            {
               AV14TFOrganisationSettingFontSize_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGLANGUAGE") == 0 )
            {
               AV15TFOrganisationSettingLanguage = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFORGANISATIONSETTINGLANGUAGE_SEL") == 0 )
            {
               AV16TFOrganisationSettingLanguage_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADORGANISATIONSETTINGBASECOLOROPTIONS' Routine */
         returnInSub = false;
         AV11TFOrganisationSettingBaseColor = AV17SearchTxt;
         AV12TFOrganisationSettingBaseColor_Sel = "";
         AV42Trn_organisationsettingwwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = AV11TFOrganisationSettingBaseColor;
         AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel = AV12TFOrganisationSettingBaseColor_Sel;
         AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = AV13TFOrganisationSettingFontSize;
         AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel = AV14TFOrganisationSettingFontSize_Sel;
         AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = AV15TFOrganisationSettingLanguage;
         AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel = AV16TFOrganisationSettingLanguage_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                              AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                              AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                              AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                              AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                              AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                              AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                              A103OrganisationSettingBaseColor ,
                                              A104OrganisationSettingFontSize ,
                                              A105OrganisationSettingLanguage } ,
                                              new int[]{
                                              }
         });
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = StringUtil.Concat( StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor), "%", "");
         lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = StringUtil.Concat( StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize), "%", "");
         lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = StringUtil.Concat( StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage), "%", "");
         /* Using cursor P005Z2 */
         pr_default.execute(0, new Object[] {lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor, AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize, AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage, AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5Z2 = false;
            A103OrganisationSettingBaseColor = P005Z2_A103OrganisationSettingBaseColor[0];
            A105OrganisationSettingLanguage = P005Z2_A105OrganisationSettingLanguage[0];
            A104OrganisationSettingFontSize = P005Z2_A104OrganisationSettingFontSize[0];
            A100OrganisationSettingid = P005Z2_A100OrganisationSettingid[0];
            A11OrganisationId = P005Z2_A11OrganisationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005Z2_A103OrganisationSettingBaseColor[0], A103OrganisationSettingBaseColor) == 0 ) )
            {
               BRK5Z2 = false;
               A100OrganisationSettingid = P005Z2_A100OrganisationSettingid[0];
               A11OrganisationId = P005Z2_A11OrganisationId[0];
               AV27count = (long)(AV27count+1);
               BRK5Z2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103OrganisationSettingBaseColor)) ? "<#Empty#>" : A103OrganisationSettingBaseColor);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5Z2 )
            {
               BRK5Z2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADORGANISATIONSETTINGFONTSIZEOPTIONS' Routine */
         returnInSub = false;
         AV13TFOrganisationSettingFontSize = AV17SearchTxt;
         AV14TFOrganisationSettingFontSize_Sel = "";
         AV42Trn_organisationsettingwwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = AV11TFOrganisationSettingBaseColor;
         AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel = AV12TFOrganisationSettingBaseColor_Sel;
         AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = AV13TFOrganisationSettingFontSize;
         AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel = AV14TFOrganisationSettingFontSize_Sel;
         AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = AV15TFOrganisationSettingLanguage;
         AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel = AV16TFOrganisationSettingLanguage_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                              AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                              AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                              AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                              AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                              AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                              AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                              A103OrganisationSettingBaseColor ,
                                              A104OrganisationSettingFontSize ,
                                              A105OrganisationSettingLanguage } ,
                                              new int[]{
                                              }
         });
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = StringUtil.Concat( StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor), "%", "");
         lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = StringUtil.Concat( StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize), "%", "");
         lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = StringUtil.Concat( StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage), "%", "");
         /* Using cursor P005Z3 */
         pr_default.execute(1, new Object[] {lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor, AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize, AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage, AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5Z4 = false;
            A104OrganisationSettingFontSize = P005Z3_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = P005Z3_A105OrganisationSettingLanguage[0];
            A103OrganisationSettingBaseColor = P005Z3_A103OrganisationSettingBaseColor[0];
            A100OrganisationSettingid = P005Z3_A100OrganisationSettingid[0];
            A11OrganisationId = P005Z3_A11OrganisationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005Z3_A104OrganisationSettingFontSize[0], A104OrganisationSettingFontSize) == 0 ) )
            {
               BRK5Z4 = false;
               A100OrganisationSettingid = P005Z3_A100OrganisationSettingid[0];
               A11OrganisationId = P005Z3_A11OrganisationId[0];
               AV27count = (long)(AV27count+1);
               BRK5Z4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A104OrganisationSettingFontSize)) ? "<#Empty#>" : A104OrganisationSettingFontSize);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5Z4 )
            {
               BRK5Z4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADORGANISATIONSETTINGLANGUAGEOPTIONS' Routine */
         returnInSub = false;
         AV15TFOrganisationSettingLanguage = AV17SearchTxt;
         AV16TFOrganisationSettingLanguage_Sel = "";
         AV42Trn_organisationsettingwwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = AV11TFOrganisationSettingBaseColor;
         AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel = AV12TFOrganisationSettingBaseColor_Sel;
         AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = AV13TFOrganisationSettingFontSize;
         AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel = AV14TFOrganisationSettingFontSize_Sel;
         AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = AV15TFOrganisationSettingLanguage;
         AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel = AV16TFOrganisationSettingLanguage_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                              AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                              AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                              AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                              AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                              AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                              AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                              A103OrganisationSettingBaseColor ,
                                              A104OrganisationSettingFontSize ,
                                              A105OrganisationSettingLanguage } ,
                                              new int[]{
                                              }
         });
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV42Trn_organisationsettingwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext), "%", "");
         lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = StringUtil.Concat( StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor), "%", "");
         lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = StringUtil.Concat( StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize), "%", "");
         lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = StringUtil.Concat( StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage), "%", "");
         /* Using cursor P005Z4 */
         pr_default.execute(2, new Object[] {lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV42Trn_organisationsettingwwds_1_filterfulltext, lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor, AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize, AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage, AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5Z6 = false;
            A105OrganisationSettingLanguage = P005Z4_A105OrganisationSettingLanguage[0];
            A104OrganisationSettingFontSize = P005Z4_A104OrganisationSettingFontSize[0];
            A103OrganisationSettingBaseColor = P005Z4_A103OrganisationSettingBaseColor[0];
            A100OrganisationSettingid = P005Z4_A100OrganisationSettingid[0];
            A11OrganisationId = P005Z4_A11OrganisationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005Z4_A105OrganisationSettingLanguage[0], A105OrganisationSettingLanguage) == 0 ) )
            {
               BRK5Z6 = false;
               A100OrganisationSettingid = P005Z4_A100OrganisationSettingid[0];
               A11OrganisationId = P005Z4_A11OrganisationId[0];
               AV27count = (long)(AV27count+1);
               BRK5Z6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A105OrganisationSettingLanguage)) ? "<#Empty#>" : A105OrganisationSettingLanguage);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK5Z6 )
            {
               BRK5Z6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV31GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV11TFOrganisationSettingBaseColor = "";
         AV12TFOrganisationSettingBaseColor_Sel = "";
         AV13TFOrganisationSettingFontSize = "";
         AV14TFOrganisationSettingFontSize_Sel = "";
         AV15TFOrganisationSettingLanguage = "";
         AV16TFOrganisationSettingLanguage_Sel = "";
         AV42Trn_organisationsettingwwds_1_filterfulltext = "";
         AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = "";
         AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel = "";
         AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = "";
         AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel = "";
         AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = "";
         AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel = "";
         lV42Trn_organisationsettingwwds_1_filterfulltext = "";
         lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor = "";
         lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize = "";
         lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage = "";
         A103OrganisationSettingBaseColor = "";
         A104OrganisationSettingFontSize = "";
         A105OrganisationSettingLanguage = "";
         P005Z2_A103OrganisationSettingBaseColor = new string[] {""} ;
         P005Z2_A105OrganisationSettingLanguage = new string[] {""} ;
         P005Z2_A104OrganisationSettingFontSize = new string[] {""} ;
         P005Z2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P005Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A100OrganisationSettingid = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV22Option = "";
         P005Z3_A104OrganisationSettingFontSize = new string[] {""} ;
         P005Z3_A105OrganisationSettingLanguage = new string[] {""} ;
         P005Z3_A103OrganisationSettingBaseColor = new string[] {""} ;
         P005Z3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P005Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005Z4_A105OrganisationSettingLanguage = new string[] {""} ;
         P005Z4_A104OrganisationSettingFontSize = new string[] {""} ;
         P005Z4_A103OrganisationSettingBaseColor = new string[] {""} ;
         P005Z4_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P005Z4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsettingwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005Z2_A103OrganisationSettingBaseColor, P005Z2_A105OrganisationSettingLanguage, P005Z2_A104OrganisationSettingFontSize, P005Z2_A100OrganisationSettingid, P005Z2_A11OrganisationId
               }
               , new Object[] {
               P005Z3_A104OrganisationSettingFontSize, P005Z3_A105OrganisationSettingLanguage, P005Z3_A103OrganisationSettingBaseColor, P005Z3_A100OrganisationSettingid, P005Z3_A11OrganisationId
               }
               , new Object[] {
               P005Z4_A105OrganisationSettingLanguage, P005Z4_A104OrganisationSettingFontSize, P005Z4_A103OrganisationSettingBaseColor, P005Z4_A100OrganisationSettingid, P005Z4_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV40GXV1 ;
      private long AV27count ;
      private bool returnInSub ;
      private bool BRK5Z2 ;
      private bool BRK5Z4 ;
      private bool BRK5Z6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string A105OrganisationSettingLanguage ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFOrganisationSettingBaseColor ;
      private string AV12TFOrganisationSettingBaseColor_Sel ;
      private string AV13TFOrganisationSettingFontSize ;
      private string AV14TFOrganisationSettingFontSize_Sel ;
      private string AV15TFOrganisationSettingLanguage ;
      private string AV16TFOrganisationSettingLanguage_Sel ;
      private string AV42Trn_organisationsettingwwds_1_filterfulltext ;
      private string AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ;
      private string AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ;
      private string AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ;
      private string AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ;
      private string AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ;
      private string AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ;
      private string lV42Trn_organisationsettingwwds_1_filterfulltext ;
      private string lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ;
      private string lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ;
      private string lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ;
      private string A103OrganisationSettingBaseColor ;
      private string A104OrganisationSettingFontSize ;
      private string AV22Option ;
      private Guid A100OrganisationSettingid ;
      private Guid A11OrganisationId ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV30GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P005Z2_A103OrganisationSettingBaseColor ;
      private string[] P005Z2_A105OrganisationSettingLanguage ;
      private string[] P005Z2_A104OrganisationSettingFontSize ;
      private Guid[] P005Z2_A100OrganisationSettingid ;
      private Guid[] P005Z2_A11OrganisationId ;
      private string[] P005Z3_A104OrganisationSettingFontSize ;
      private string[] P005Z3_A105OrganisationSettingLanguage ;
      private string[] P005Z3_A103OrganisationSettingBaseColor ;
      private Guid[] P005Z3_A100OrganisationSettingid ;
      private Guid[] P005Z3_A11OrganisationId ;
      private string[] P005Z4_A105OrganisationSettingLanguage ;
      private string[] P005Z4_A104OrganisationSettingFontSize ;
      private string[] P005Z4_A103OrganisationSettingBaseColor ;
      private Guid[] P005Z4_A100OrganisationSettingid ;
      private Guid[] P005Z4_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_organisationsettingwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Z2( IGxContext context ,
                                             string AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                             string AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                             string AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                             string AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                             string AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                             string AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                             string AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                             string A103OrganisationSettingBaseColor ,
                                             string A104OrganisationSettingFontSize ,
                                             string A105OrganisationSettingLanguage )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationSettingBaseColor, OrganisationSettingLanguage, OrganisationSettingFontSize, OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(OrganisationSettingBaseColor) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingFontSize) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingLanguage) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor like :lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ! ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor = ( :AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize like :lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ! ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize = ( :AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingFontSize))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage like :lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ! ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage = ( :AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingLanguage))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationSettingBaseColor";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005Z3( IGxContext context ,
                                             string AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                             string AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                             string AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                             string AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                             string AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                             string AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                             string AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                             string A103OrganisationSettingBaseColor ,
                                             string A104OrganisationSettingFontSize ,
                                             string A105OrganisationSettingLanguage )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationSettingBaseColor, OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(OrganisationSettingBaseColor) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingFontSize) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingLanguage) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor like :lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ! ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor = ( :AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize like :lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ! ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize = ( :AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingFontSize))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage like :lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ! ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage = ( :AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingLanguage))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationSettingFontSize";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005Z4( IGxContext context ,
                                             string AV42Trn_organisationsettingwwds_1_filterfulltext ,
                                             string AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel ,
                                             string AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor ,
                                             string AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel ,
                                             string AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize ,
                                             string AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel ,
                                             string AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage ,
                                             string A103OrganisationSettingBaseColor ,
                                             string A104OrganisationSettingFontSize ,
                                             string A105OrganisationSettingLanguage )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationSettingLanguage, OrganisationSettingFontSize, OrganisationSettingBaseColor, OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_organisationsettingwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(OrganisationSettingBaseColor) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingFontSize) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)) or ( LOWER(OrganisationSettingLanguage) like '%' || LOWER(:lV42Trn_organisationsettingwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolor)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor like :lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel)) && ! ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingBaseColor = ( :AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize like :lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel)) && ! ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingFontSize = ( :AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingFontSize))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)) ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage like :lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel)) && ! ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(OrganisationSettingLanguage = ( :AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from OrganisationSettingLanguage))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationSettingLanguage";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 1 :
                     return conditional_P005Z3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 2 :
                     return conditional_P005Z4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005Z2;
          prmP005Z2 = new Object[] {
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage",GXType.VarChar,200,0)
          };
          Object[] prmP005Z3;
          prmP005Z3 = new Object[] {
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage",GXType.VarChar,200,0)
          };
          Object[] prmP005Z4;
          prmP005Z4 = new Object[] {
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_organisationsettingwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_organisationsettingwwds_2_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV44Trn_organisationsettingwwds_3_tforganisationsettingbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV45Trn_organisationsettingwwds_4_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV46Trn_organisationsettingwwds_5_tforganisationsettingfontsize",GXType.VarChar,40,0) ,
          new ParDef("lV47Trn_organisationsettingwwds_6_tforganisationsettinglanguage",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_organisationsettingwwds_7_tforganisationsettinglanguage",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Z4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
