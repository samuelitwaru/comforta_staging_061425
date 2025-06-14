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
   public class trn_templatewwgetfilterdata : GXProcedure
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
            return "trn_templateww_Services_Execute" ;
         }

      }

      public trn_templatewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_templatewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRN_TEMPLATENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_TEMPLATENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRN_TEMPLATEMEDIA") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_TEMPLATEMEDIAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRN_TEMPLATECONTENT") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_TEMPLATECONTENTOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("Trn_TemplateWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_TemplateWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Trn_TemplateWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATENAME") == 0 )
            {
               AV11TFTrn_TemplateName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATENAME_SEL") == 0 )
            {
               AV12TFTrn_TemplateName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATEMEDIA") == 0 )
            {
               AV13TFTrn_TemplateMedia = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATEMEDIA_SEL") == 0 )
            {
               AV14TFTrn_TemplateMedia_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATECONTENT") == 0 )
            {
               AV15TFTrn_TemplateContent = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_TEMPLATECONTENT_SEL") == 0 )
            {
               AV16TFTrn_TemplateContent_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_TEMPLATENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_TemplateName = AV17SearchTxt;
         AV12TFTrn_TemplateName_Sel = "";
         AV42Trn_templatewwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_templatewwds_2_tftrn_templatename = AV11TFTrn_TemplateName;
         AV44Trn_templatewwds_3_tftrn_templatename_sel = AV12TFTrn_TemplateName_Sel;
         AV45Trn_templatewwds_4_tftrn_templatemedia = AV13TFTrn_TemplateMedia;
         AV46Trn_templatewwds_5_tftrn_templatemedia_sel = AV14TFTrn_TemplateMedia_Sel;
         AV47Trn_templatewwds_6_tftrn_templatecontent = AV15TFTrn_TemplateContent;
         AV48Trn_templatewwds_7_tftrn_templatecontent_sel = AV16TFTrn_TemplateContent_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Trn_templatewwds_1_filterfulltext ,
                                              AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                              AV43Trn_templatewwds_2_tftrn_templatename ,
                                              AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                              AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                              AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                              AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                              A300Trn_TemplateName ,
                                              A301Trn_TemplateMedia ,
                                              A302Trn_TemplateContent } ,
                                              new int[]{
                                              }
         });
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV43Trn_templatewwds_2_tftrn_templatename = StringUtil.Concat( StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename), "%", "");
         lV45Trn_templatewwds_4_tftrn_templatemedia = StringUtil.Concat( StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia), "%", "");
         lV47Trn_templatewwds_6_tftrn_templatecontent = StringUtil.Concat( StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent), "%", "");
         /* Using cursor P006P2 */
         pr_default.execute(0, new Object[] {lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV43Trn_templatewwds_2_tftrn_templatename, AV44Trn_templatewwds_3_tftrn_templatename_sel, lV45Trn_templatewwds_4_tftrn_templatemedia, AV46Trn_templatewwds_5_tftrn_templatemedia_sel, lV47Trn_templatewwds_6_tftrn_templatecontent, AV48Trn_templatewwds_7_tftrn_templatecontent_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6P2 = false;
            A300Trn_TemplateName = P006P2_A300Trn_TemplateName[0];
            A302Trn_TemplateContent = P006P2_A302Trn_TemplateContent[0];
            A301Trn_TemplateMedia = P006P2_A301Trn_TemplateMedia[0];
            A299Trn_TemplateId = P006P2_A299Trn_TemplateId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006P2_A300Trn_TemplateName[0], A300Trn_TemplateName) == 0 ) )
            {
               BRK6P2 = false;
               A299Trn_TemplateId = P006P2_A299Trn_TemplateId[0];
               AV27count = (long)(AV27count+1);
               BRK6P2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A300Trn_TemplateName)) ? "<#Empty#>" : A300Trn_TemplateName);
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
            if ( ! BRK6P2 )
            {
               BRK6P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRN_TEMPLATEMEDIAOPTIONS' Routine */
         returnInSub = false;
         AV13TFTrn_TemplateMedia = AV17SearchTxt;
         AV14TFTrn_TemplateMedia_Sel = "";
         AV42Trn_templatewwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_templatewwds_2_tftrn_templatename = AV11TFTrn_TemplateName;
         AV44Trn_templatewwds_3_tftrn_templatename_sel = AV12TFTrn_TemplateName_Sel;
         AV45Trn_templatewwds_4_tftrn_templatemedia = AV13TFTrn_TemplateMedia;
         AV46Trn_templatewwds_5_tftrn_templatemedia_sel = AV14TFTrn_TemplateMedia_Sel;
         AV47Trn_templatewwds_6_tftrn_templatecontent = AV15TFTrn_TemplateContent;
         AV48Trn_templatewwds_7_tftrn_templatecontent_sel = AV16TFTrn_TemplateContent_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Trn_templatewwds_1_filterfulltext ,
                                              AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                              AV43Trn_templatewwds_2_tftrn_templatename ,
                                              AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                              AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                              AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                              AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                              A300Trn_TemplateName ,
                                              A301Trn_TemplateMedia ,
                                              A302Trn_TemplateContent } ,
                                              new int[]{
                                              }
         });
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV43Trn_templatewwds_2_tftrn_templatename = StringUtil.Concat( StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename), "%", "");
         lV45Trn_templatewwds_4_tftrn_templatemedia = StringUtil.Concat( StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia), "%", "");
         lV47Trn_templatewwds_6_tftrn_templatecontent = StringUtil.Concat( StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent), "%", "");
         /* Using cursor P006P3 */
         pr_default.execute(1, new Object[] {lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV43Trn_templatewwds_2_tftrn_templatename, AV44Trn_templatewwds_3_tftrn_templatename_sel, lV45Trn_templatewwds_4_tftrn_templatemedia, AV46Trn_templatewwds_5_tftrn_templatemedia_sel, lV47Trn_templatewwds_6_tftrn_templatecontent, AV48Trn_templatewwds_7_tftrn_templatecontent_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6P4 = false;
            A301Trn_TemplateMedia = P006P3_A301Trn_TemplateMedia[0];
            A302Trn_TemplateContent = P006P3_A302Trn_TemplateContent[0];
            A300Trn_TemplateName = P006P3_A300Trn_TemplateName[0];
            A299Trn_TemplateId = P006P3_A299Trn_TemplateId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006P3_A301Trn_TemplateMedia[0], A301Trn_TemplateMedia) == 0 ) )
            {
               BRK6P4 = false;
               A299Trn_TemplateId = P006P3_A299Trn_TemplateId[0];
               AV27count = (long)(AV27count+1);
               BRK6P4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A301Trn_TemplateMedia)) ? "<#Empty#>" : A301Trn_TemplateMedia);
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
            if ( ! BRK6P4 )
            {
               BRK6P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTRN_TEMPLATECONTENTOPTIONS' Routine */
         returnInSub = false;
         AV15TFTrn_TemplateContent = AV17SearchTxt;
         AV16TFTrn_TemplateContent_Sel = "";
         AV42Trn_templatewwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_templatewwds_2_tftrn_templatename = AV11TFTrn_TemplateName;
         AV44Trn_templatewwds_3_tftrn_templatename_sel = AV12TFTrn_TemplateName_Sel;
         AV45Trn_templatewwds_4_tftrn_templatemedia = AV13TFTrn_TemplateMedia;
         AV46Trn_templatewwds_5_tftrn_templatemedia_sel = AV14TFTrn_TemplateMedia_Sel;
         AV47Trn_templatewwds_6_tftrn_templatecontent = AV15TFTrn_TemplateContent;
         AV48Trn_templatewwds_7_tftrn_templatecontent_sel = AV16TFTrn_TemplateContent_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV42Trn_templatewwds_1_filterfulltext ,
                                              AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                              AV43Trn_templatewwds_2_tftrn_templatename ,
                                              AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                              AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                              AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                              AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                              A300Trn_TemplateName ,
                                              A301Trn_TemplateMedia ,
                                              A302Trn_TemplateContent } ,
                                              new int[]{
                                              }
         });
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV42Trn_templatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext), "%", "");
         lV43Trn_templatewwds_2_tftrn_templatename = StringUtil.Concat( StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename), "%", "");
         lV45Trn_templatewwds_4_tftrn_templatemedia = StringUtil.Concat( StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia), "%", "");
         lV47Trn_templatewwds_6_tftrn_templatecontent = StringUtil.Concat( StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent), "%", "");
         /* Using cursor P006P4 */
         pr_default.execute(2, new Object[] {lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV42Trn_templatewwds_1_filterfulltext, lV43Trn_templatewwds_2_tftrn_templatename, AV44Trn_templatewwds_3_tftrn_templatename_sel, lV45Trn_templatewwds_4_tftrn_templatemedia, AV46Trn_templatewwds_5_tftrn_templatemedia_sel, lV47Trn_templatewwds_6_tftrn_templatecontent, AV48Trn_templatewwds_7_tftrn_templatecontent_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6P6 = false;
            A302Trn_TemplateContent = P006P4_A302Trn_TemplateContent[0];
            A301Trn_TemplateMedia = P006P4_A301Trn_TemplateMedia[0];
            A300Trn_TemplateName = P006P4_A300Trn_TemplateName[0];
            A299Trn_TemplateId = P006P4_A299Trn_TemplateId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006P4_A302Trn_TemplateContent[0], A302Trn_TemplateContent) == 0 ) )
            {
               BRK6P6 = false;
               A299Trn_TemplateId = P006P4_A299Trn_TemplateId[0];
               AV27count = (long)(AV27count+1);
               BRK6P6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A302Trn_TemplateContent)) ? "<#Empty#>" : A302Trn_TemplateContent);
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
            if ( ! BRK6P6 )
            {
               BRK6P6 = true;
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
         AV11TFTrn_TemplateName = "";
         AV12TFTrn_TemplateName_Sel = "";
         AV13TFTrn_TemplateMedia = "";
         AV14TFTrn_TemplateMedia_Sel = "";
         AV15TFTrn_TemplateContent = "";
         AV16TFTrn_TemplateContent_Sel = "";
         AV42Trn_templatewwds_1_filterfulltext = "";
         AV43Trn_templatewwds_2_tftrn_templatename = "";
         AV44Trn_templatewwds_3_tftrn_templatename_sel = "";
         AV45Trn_templatewwds_4_tftrn_templatemedia = "";
         AV46Trn_templatewwds_5_tftrn_templatemedia_sel = "";
         AV47Trn_templatewwds_6_tftrn_templatecontent = "";
         AV48Trn_templatewwds_7_tftrn_templatecontent_sel = "";
         lV42Trn_templatewwds_1_filterfulltext = "";
         lV43Trn_templatewwds_2_tftrn_templatename = "";
         lV45Trn_templatewwds_4_tftrn_templatemedia = "";
         lV47Trn_templatewwds_6_tftrn_templatecontent = "";
         A300Trn_TemplateName = "";
         A301Trn_TemplateMedia = "";
         A302Trn_TemplateContent = "";
         P006P2_A300Trn_TemplateName = new string[] {""} ;
         P006P2_A302Trn_TemplateContent = new string[] {""} ;
         P006P2_A301Trn_TemplateMedia = new string[] {""} ;
         P006P2_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         A299Trn_TemplateId = Guid.Empty;
         AV22Option = "";
         P006P3_A301Trn_TemplateMedia = new string[] {""} ;
         P006P3_A302Trn_TemplateContent = new string[] {""} ;
         P006P3_A300Trn_TemplateName = new string[] {""} ;
         P006P3_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         P006P4_A302Trn_TemplateContent = new string[] {""} ;
         P006P4_A301Trn_TemplateMedia = new string[] {""} ;
         P006P4_A300Trn_TemplateName = new string[] {""} ;
         P006P4_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_templatewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006P2_A300Trn_TemplateName, P006P2_A302Trn_TemplateContent, P006P2_A301Trn_TemplateMedia, P006P2_A299Trn_TemplateId
               }
               , new Object[] {
               P006P3_A301Trn_TemplateMedia, P006P3_A302Trn_TemplateContent, P006P3_A300Trn_TemplateName, P006P3_A299Trn_TemplateId
               }
               , new Object[] {
               P006P4_A302Trn_TemplateContent, P006P4_A301Trn_TemplateMedia, P006P4_A300Trn_TemplateName, P006P4_A299Trn_TemplateId
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
      private bool BRK6P2 ;
      private bool BRK6P4 ;
      private bool BRK6P6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string A302Trn_TemplateContent ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFTrn_TemplateName ;
      private string AV12TFTrn_TemplateName_Sel ;
      private string AV13TFTrn_TemplateMedia ;
      private string AV14TFTrn_TemplateMedia_Sel ;
      private string AV15TFTrn_TemplateContent ;
      private string AV16TFTrn_TemplateContent_Sel ;
      private string AV42Trn_templatewwds_1_filterfulltext ;
      private string AV43Trn_templatewwds_2_tftrn_templatename ;
      private string AV44Trn_templatewwds_3_tftrn_templatename_sel ;
      private string AV45Trn_templatewwds_4_tftrn_templatemedia ;
      private string AV46Trn_templatewwds_5_tftrn_templatemedia_sel ;
      private string AV47Trn_templatewwds_6_tftrn_templatecontent ;
      private string AV48Trn_templatewwds_7_tftrn_templatecontent_sel ;
      private string lV42Trn_templatewwds_1_filterfulltext ;
      private string lV43Trn_templatewwds_2_tftrn_templatename ;
      private string lV45Trn_templatewwds_4_tftrn_templatemedia ;
      private string lV47Trn_templatewwds_6_tftrn_templatecontent ;
      private string A300Trn_TemplateName ;
      private string A301Trn_TemplateMedia ;
      private string AV22Option ;
      private Guid A299Trn_TemplateId ;
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
      private string[] P006P2_A300Trn_TemplateName ;
      private string[] P006P2_A302Trn_TemplateContent ;
      private string[] P006P2_A301Trn_TemplateMedia ;
      private Guid[] P006P2_A299Trn_TemplateId ;
      private string[] P006P3_A301Trn_TemplateMedia ;
      private string[] P006P3_A302Trn_TemplateContent ;
      private string[] P006P3_A300Trn_TemplateName ;
      private Guid[] P006P3_A299Trn_TemplateId ;
      private string[] P006P4_A302Trn_TemplateContent ;
      private string[] P006P4_A301Trn_TemplateMedia ;
      private string[] P006P4_A300Trn_TemplateName ;
      private Guid[] P006P4_A299Trn_TemplateId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_templatewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006P2( IGxContext context ,
                                             string AV42Trn_templatewwds_1_filterfulltext ,
                                             string AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                             string AV43Trn_templatewwds_2_tftrn_templatename ,
                                             string AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                             string AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                             string AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                             string AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                             string A300Trn_TemplateName ,
                                             string A301Trn_TemplateMedia ,
                                             string A302Trn_TemplateContent )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_TemplateName, Trn_TemplateContent, Trn_TemplateMedia, Trn_TemplateId FROM Trn_Template";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(Trn_TemplateName) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateMedia) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateContent) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName like :lV43Trn_templatewwds_2_tftrn_templatename)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ! ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName = ( :AV44Trn_templatewwds_3_tftrn_templatename_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia like :lV45Trn_templatewwds_4_tftrn_templatemedia)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ! ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia = ( :AV46Trn_templatewwds_5_tftrn_templatemedia_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateMedia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent like :lV47Trn_templatewwds_6_tftrn_templatecontent)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ! ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent = ( :AV48Trn_templatewwds_7_tftrn_templatecontent_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateContent))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_TemplateName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006P3( IGxContext context ,
                                             string AV42Trn_templatewwds_1_filterfulltext ,
                                             string AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                             string AV43Trn_templatewwds_2_tftrn_templatename ,
                                             string AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                             string AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                             string AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                             string AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                             string A300Trn_TemplateName ,
                                             string A301Trn_TemplateMedia ,
                                             string A302Trn_TemplateContent )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Trn_TemplateMedia, Trn_TemplateContent, Trn_TemplateName, Trn_TemplateId FROM Trn_Template";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(Trn_TemplateName) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateMedia) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateContent) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName like :lV43Trn_templatewwds_2_tftrn_templatename)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ! ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName = ( :AV44Trn_templatewwds_3_tftrn_templatename_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia like :lV45Trn_templatewwds_4_tftrn_templatemedia)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ! ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia = ( :AV46Trn_templatewwds_5_tftrn_templatemedia_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateMedia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent like :lV47Trn_templatewwds_6_tftrn_templatecontent)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ! ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent = ( :AV48Trn_templatewwds_7_tftrn_templatecontent_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateContent))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_TemplateMedia";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006P4( IGxContext context ,
                                             string AV42Trn_templatewwds_1_filterfulltext ,
                                             string AV44Trn_templatewwds_3_tftrn_templatename_sel ,
                                             string AV43Trn_templatewwds_2_tftrn_templatename ,
                                             string AV46Trn_templatewwds_5_tftrn_templatemedia_sel ,
                                             string AV45Trn_templatewwds_4_tftrn_templatemedia ,
                                             string AV48Trn_templatewwds_7_tftrn_templatecontent_sel ,
                                             string AV47Trn_templatewwds_6_tftrn_templatecontent ,
                                             string A300Trn_TemplateName ,
                                             string A301Trn_TemplateMedia ,
                                             string A302Trn_TemplateContent )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT Trn_TemplateContent, Trn_TemplateMedia, Trn_TemplateName, Trn_TemplateId FROM Trn_Template";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_templatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(Trn_TemplateName) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateMedia) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)) or ( LOWER(Trn_TemplateContent) like '%' || LOWER(:lV42Trn_templatewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_templatewwds_2_tftrn_templatename)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName like :lV43Trn_templatewwds_2_tftrn_templatename)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_templatewwds_3_tftrn_templatename_sel)) && ! ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateName = ( :AV44Trn_templatewwds_3_tftrn_templatename_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_templatewwds_3_tftrn_templatename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_templatewwds_4_tftrn_templatemedia)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia like :lV45Trn_templatewwds_4_tftrn_templatemedia)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_templatewwds_5_tftrn_templatemedia_sel)) && ! ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateMedia = ( :AV46Trn_templatewwds_5_tftrn_templatemedia_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_templatewwds_5_tftrn_templatemedia_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateMedia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_templatewwds_6_tftrn_templatecontent)) ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent like :lV47Trn_templatewwds_6_tftrn_templatecontent)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_templatewwds_7_tftrn_templatecontent_sel)) && ! ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_TemplateContent = ( :AV48Trn_templatewwds_7_tftrn_templatecontent_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_templatewwds_7_tftrn_templatecontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_TemplateContent))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_TemplateContent";
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
                     return conditional_P006P2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 1 :
                     return conditional_P006P3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 2 :
                     return conditional_P006P4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP006P2;
          prmP006P2 = new Object[] {
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_templatewwds_2_tftrn_templatename",GXType.VarChar,100,0) ,
          new ParDef("AV44Trn_templatewwds_3_tftrn_templatename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_templatewwds_4_tftrn_templatemedia",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_templatewwds_5_tftrn_templatemedia_sel",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_templatewwds_6_tftrn_templatecontent",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_templatewwds_7_tftrn_templatecontent_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006P3;
          prmP006P3 = new Object[] {
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_templatewwds_2_tftrn_templatename",GXType.VarChar,100,0) ,
          new ParDef("AV44Trn_templatewwds_3_tftrn_templatename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_templatewwds_4_tftrn_templatemedia",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_templatewwds_5_tftrn_templatemedia_sel",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_templatewwds_6_tftrn_templatecontent",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_templatewwds_7_tftrn_templatecontent_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006P4;
          prmP006P4 = new Object[] {
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_templatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_templatewwds_2_tftrn_templatename",GXType.VarChar,100,0) ,
          new ParDef("AV44Trn_templatewwds_3_tftrn_templatename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_templatewwds_4_tftrn_templatemedia",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_templatewwds_5_tftrn_templatemedia_sel",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_templatewwds_6_tftrn_templatecontent",GXType.VarChar,200,0) ,
          new ParDef("AV48Trn_templatewwds_7_tftrn_templatecontent_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006P4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P4,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
