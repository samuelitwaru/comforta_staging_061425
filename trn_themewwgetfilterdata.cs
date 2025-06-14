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
   public class trn_themewwgetfilterdata : GXProcedure
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
            return "trn_themeww_Services_Execute" ;
         }

      }

      public trn_themewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_themewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRN_THEMENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_THEMENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRN_THEMEFONTFAMILY") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_THEMEFONTFAMILYOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("Trn_ThemeWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_ThemeWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Trn_ThemeWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_THEMENAME") == 0 )
            {
               AV11TFTrn_ThemeName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_THEMENAME_SEL") == 0 )
            {
               AV12TFTrn_ThemeName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_THEMEFONTFAMILY") == 0 )
            {
               AV13TFTrn_ThemeFontFamily = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_THEMEFONTFAMILY_SEL") == 0 )
            {
               AV14TFTrn_ThemeFontFamily_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRN_THEMEFONTSIZE") == 0 )
            {
               AV15TFTrn_ThemeFontSize = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFTrn_ThemeFontSize_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_THEMENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_ThemeName = AV17SearchTxt;
         AV12TFTrn_ThemeName_Sel = "";
         AV42Trn_themewwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_themewwds_2_tftrn_themename = AV11TFTrn_ThemeName;
         AV44Trn_themewwds_3_tftrn_themename_sel = AV12TFTrn_ThemeName_Sel;
         AV45Trn_themewwds_4_tftrn_themefontfamily = AV13TFTrn_ThemeFontFamily;
         AV46Trn_themewwds_5_tftrn_themefontfamily_sel = AV14TFTrn_ThemeFontFamily_Sel;
         AV47Trn_themewwds_6_tftrn_themefontsize = AV15TFTrn_ThemeFontSize;
         AV48Trn_themewwds_7_tftrn_themefontsize_to = AV16TFTrn_ThemeFontSize_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Trn_themewwds_1_filterfulltext ,
                                              AV44Trn_themewwds_3_tftrn_themename_sel ,
                                              AV43Trn_themewwds_2_tftrn_themename ,
                                              AV46Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                              AV45Trn_themewwds_4_tftrn_themefontfamily ,
                                              AV47Trn_themewwds_6_tftrn_themefontsize ,
                                              AV48Trn_themewwds_7_tftrn_themefontsize_to ,
                                              A274Trn_ThemeName ,
                                              A281Trn_ThemeFontFamily ,
                                              A405Trn_ThemeFontSize } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV43Trn_themewwds_2_tftrn_themename = StringUtil.Concat( StringUtil.RTrim( AV43Trn_themewwds_2_tftrn_themename), "%", "");
         lV45Trn_themewwds_4_tftrn_themefontfamily = StringUtil.Concat( StringUtil.RTrim( AV45Trn_themewwds_4_tftrn_themefontfamily), "%", "");
         /* Using cursor P00812 */
         pr_default.execute(0, new Object[] {lV42Trn_themewwds_1_filterfulltext, lV42Trn_themewwds_1_filterfulltext, lV42Trn_themewwds_1_filterfulltext, lV43Trn_themewwds_2_tftrn_themename, AV44Trn_themewwds_3_tftrn_themename_sel, lV45Trn_themewwds_4_tftrn_themefontfamily, AV46Trn_themewwds_5_tftrn_themefontfamily_sel, AV47Trn_themewwds_6_tftrn_themefontsize, AV48Trn_themewwds_7_tftrn_themefontsize_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK812 = false;
            A274Trn_ThemeName = P00812_A274Trn_ThemeName[0];
            A405Trn_ThemeFontSize = P00812_A405Trn_ThemeFontSize[0];
            A281Trn_ThemeFontFamily = P00812_A281Trn_ThemeFontFamily[0];
            A273Trn_ThemeId = P00812_A273Trn_ThemeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00812_A274Trn_ThemeName[0], A274Trn_ThemeName) == 0 ) )
            {
               BRK812 = false;
               A273Trn_ThemeId = P00812_A273Trn_ThemeId[0];
               AV27count = (long)(AV27count+1);
               BRK812 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A274Trn_ThemeName)) ? "<#Empty#>" : A274Trn_ThemeName);
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
            if ( ! BRK812 )
            {
               BRK812 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRN_THEMEFONTFAMILYOPTIONS' Routine */
         returnInSub = false;
         AV13TFTrn_ThemeFontFamily = AV17SearchTxt;
         AV14TFTrn_ThemeFontFamily_Sel = "";
         AV42Trn_themewwds_1_filterfulltext = AV39FilterFullText;
         AV43Trn_themewwds_2_tftrn_themename = AV11TFTrn_ThemeName;
         AV44Trn_themewwds_3_tftrn_themename_sel = AV12TFTrn_ThemeName_Sel;
         AV45Trn_themewwds_4_tftrn_themefontfamily = AV13TFTrn_ThemeFontFamily;
         AV46Trn_themewwds_5_tftrn_themefontfamily_sel = AV14TFTrn_ThemeFontFamily_Sel;
         AV47Trn_themewwds_6_tftrn_themefontsize = AV15TFTrn_ThemeFontSize;
         AV48Trn_themewwds_7_tftrn_themefontsize_to = AV16TFTrn_ThemeFontSize_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Trn_themewwds_1_filterfulltext ,
                                              AV44Trn_themewwds_3_tftrn_themename_sel ,
                                              AV43Trn_themewwds_2_tftrn_themename ,
                                              AV46Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                              AV45Trn_themewwds_4_tftrn_themefontfamily ,
                                              AV47Trn_themewwds_6_tftrn_themefontsize ,
                                              AV48Trn_themewwds_7_tftrn_themefontsize_to ,
                                              A274Trn_ThemeName ,
                                              A281Trn_ThemeFontFamily ,
                                              A405Trn_ThemeFontSize } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV42Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext), "%", "");
         lV43Trn_themewwds_2_tftrn_themename = StringUtil.Concat( StringUtil.RTrim( AV43Trn_themewwds_2_tftrn_themename), "%", "");
         lV45Trn_themewwds_4_tftrn_themefontfamily = StringUtil.Concat( StringUtil.RTrim( AV45Trn_themewwds_4_tftrn_themefontfamily), "%", "");
         /* Using cursor P00813 */
         pr_default.execute(1, new Object[] {lV42Trn_themewwds_1_filterfulltext, lV42Trn_themewwds_1_filterfulltext, lV42Trn_themewwds_1_filterfulltext, lV43Trn_themewwds_2_tftrn_themename, AV44Trn_themewwds_3_tftrn_themename_sel, lV45Trn_themewwds_4_tftrn_themefontfamily, AV46Trn_themewwds_5_tftrn_themefontfamily_sel, AV47Trn_themewwds_6_tftrn_themefontsize, AV48Trn_themewwds_7_tftrn_themefontsize_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK814 = false;
            A281Trn_ThemeFontFamily = P00813_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = P00813_A405Trn_ThemeFontSize[0];
            A274Trn_ThemeName = P00813_A274Trn_ThemeName[0];
            A273Trn_ThemeId = P00813_A273Trn_ThemeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00813_A281Trn_ThemeFontFamily[0], A281Trn_ThemeFontFamily) == 0 ) )
            {
               BRK814 = false;
               A273Trn_ThemeId = P00813_A273Trn_ThemeId[0];
               AV27count = (long)(AV27count+1);
               BRK814 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A281Trn_ThemeFontFamily)) ? "<#Empty#>" : A281Trn_ThemeFontFamily);
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
            if ( ! BRK814 )
            {
               BRK814 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV11TFTrn_ThemeName = "";
         AV12TFTrn_ThemeName_Sel = "";
         AV13TFTrn_ThemeFontFamily = "";
         AV14TFTrn_ThemeFontFamily_Sel = "";
         AV42Trn_themewwds_1_filterfulltext = "";
         AV43Trn_themewwds_2_tftrn_themename = "";
         AV44Trn_themewwds_3_tftrn_themename_sel = "";
         AV45Trn_themewwds_4_tftrn_themefontfamily = "";
         AV46Trn_themewwds_5_tftrn_themefontfamily_sel = "";
         lV42Trn_themewwds_1_filterfulltext = "";
         lV43Trn_themewwds_2_tftrn_themename = "";
         lV45Trn_themewwds_4_tftrn_themefontfamily = "";
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         P00812_A274Trn_ThemeName = new string[] {""} ;
         P00812_A405Trn_ThemeFontSize = new short[1] ;
         P00812_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00812_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         AV22Option = "";
         P00813_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00813_A405Trn_ThemeFontSize = new short[1] ;
         P00813_A274Trn_ThemeName = new string[] {""} ;
         P00813_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_themewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00812_A274Trn_ThemeName, P00812_A405Trn_ThemeFontSize, P00812_A281Trn_ThemeFontFamily, P00812_A273Trn_ThemeId
               }
               , new Object[] {
               P00813_A281Trn_ThemeFontFamily, P00813_A405Trn_ThemeFontSize, P00813_A274Trn_ThemeName, P00813_A273Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV15TFTrn_ThemeFontSize ;
      private short AV16TFTrn_ThemeFontSize_To ;
      private short AV47Trn_themewwds_6_tftrn_themefontsize ;
      private short AV48Trn_themewwds_7_tftrn_themefontsize_to ;
      private short A405Trn_ThemeFontSize ;
      private int AV40GXV1 ;
      private long AV27count ;
      private bool returnInSub ;
      private bool BRK812 ;
      private bool BRK814 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFTrn_ThemeName ;
      private string AV12TFTrn_ThemeName_Sel ;
      private string AV13TFTrn_ThemeFontFamily ;
      private string AV14TFTrn_ThemeFontFamily_Sel ;
      private string AV42Trn_themewwds_1_filterfulltext ;
      private string AV43Trn_themewwds_2_tftrn_themename ;
      private string AV44Trn_themewwds_3_tftrn_themename_sel ;
      private string AV45Trn_themewwds_4_tftrn_themefontfamily ;
      private string AV46Trn_themewwds_5_tftrn_themefontfamily_sel ;
      private string lV42Trn_themewwds_1_filterfulltext ;
      private string lV43Trn_themewwds_2_tftrn_themename ;
      private string lV45Trn_themewwds_4_tftrn_themefontfamily ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string AV22Option ;
      private Guid A273Trn_ThemeId ;
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
      private string[] P00812_A274Trn_ThemeName ;
      private short[] P00812_A405Trn_ThemeFontSize ;
      private string[] P00812_A281Trn_ThemeFontFamily ;
      private Guid[] P00812_A273Trn_ThemeId ;
      private string[] P00813_A281Trn_ThemeFontFamily ;
      private short[] P00813_A405Trn_ThemeFontSize ;
      private string[] P00813_A274Trn_ThemeName ;
      private Guid[] P00813_A273Trn_ThemeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_themewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00812( IGxContext context ,
                                             string AV42Trn_themewwds_1_filterfulltext ,
                                             string AV44Trn_themewwds_3_tftrn_themename_sel ,
                                             string AV43Trn_themewwds_2_tftrn_themename ,
                                             string AV46Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                             string AV45Trn_themewwds_4_tftrn_themefontfamily ,
                                             short AV47Trn_themewwds_6_tftrn_themefontsize ,
                                             short AV48Trn_themewwds_7_tftrn_themefontsize_to ,
                                             string A274Trn_ThemeName ,
                                             string A281Trn_ThemeFontFamily ,
                                             short A405Trn_ThemeFontSize )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_ThemeName, Trn_ThemeFontSize, Trn_ThemeFontFamily, Trn_ThemeId FROM Trn_Theme";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(Trn_ThemeName) like '%' || LOWER(:lV42Trn_themewwds_1_filterfulltext)) or ( LOWER(Trn_ThemeFontFamily) like '%' || LOWER(:lV42Trn_themewwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(Trn_ThemeFontSize,'9999'), 2) like '%' || :lV42Trn_themewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_3_tftrn_themename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_themewwds_2_tftrn_themename)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName like :lV43Trn_themewwds_2_tftrn_themename)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_3_tftrn_themename_sel)) && ! ( StringUtil.StrCmp(AV44Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName = ( :AV44Trn_themewwds_3_tftrn_themename_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_themewwds_5_tftrn_themefontfamily_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_themewwds_4_tftrn_themefontfamily)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily like :lV45Trn_themewwds_4_tftrn_themefontfamily)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_themewwds_5_tftrn_themefontfamily_sel)) && ! ( StringUtil.StrCmp(AV46Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily = ( :AV46Trn_themewwds_5_tftrn_themefontfamily_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeFontFamily))=0))");
         }
         if ( ! (0==AV47Trn_themewwds_6_tftrn_themefontsize) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontSize >= :AV47Trn_themewwds_6_tftrn_themefontsize)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV48Trn_themewwds_7_tftrn_themefontsize_to) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontSize <= :AV48Trn_themewwds_7_tftrn_themefontsize_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_ThemeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00813( IGxContext context ,
                                             string AV42Trn_themewwds_1_filterfulltext ,
                                             string AV44Trn_themewwds_3_tftrn_themename_sel ,
                                             string AV43Trn_themewwds_2_tftrn_themename ,
                                             string AV46Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                             string AV45Trn_themewwds_4_tftrn_themefontfamily ,
                                             short AV47Trn_themewwds_6_tftrn_themefontsize ,
                                             short AV48Trn_themewwds_7_tftrn_themefontsize_to ,
                                             string A274Trn_ThemeName ,
                                             string A281Trn_ThemeFontFamily ,
                                             short A405Trn_ThemeFontSize )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Trn_ThemeFontFamily, Trn_ThemeFontSize, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(Trn_ThemeName) like '%' || LOWER(:lV42Trn_themewwds_1_filterfulltext)) or ( LOWER(Trn_ThemeFontFamily) like '%' || LOWER(:lV42Trn_themewwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(Trn_ThemeFontSize,'9999'), 2) like '%' || :lV42Trn_themewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_3_tftrn_themename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_themewwds_2_tftrn_themename)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName like :lV43Trn_themewwds_2_tftrn_themename)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_3_tftrn_themename_sel)) && ! ( StringUtil.StrCmp(AV44Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName = ( :AV44Trn_themewwds_3_tftrn_themename_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_themewwds_5_tftrn_themefontfamily_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_themewwds_4_tftrn_themefontfamily)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily like :lV45Trn_themewwds_4_tftrn_themefontfamily)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_themewwds_5_tftrn_themefontfamily_sel)) && ! ( StringUtil.StrCmp(AV46Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily = ( :AV46Trn_themewwds_5_tftrn_themefontfamily_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeFontFamily))=0))");
         }
         if ( ! (0==AV47Trn_themewwds_6_tftrn_themefontsize) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontSize >= :AV47Trn_themewwds_6_tftrn_themefontsize)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV48Trn_themewwds_7_tftrn_themefontsize_to) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontSize <= :AV48Trn_themewwds_7_tftrn_themefontsize_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_ThemeFontFamily";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00812(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
               case 1 :
                     return conditional_P00813(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00812;
          prmP00812 = new Object[] {
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_themewwds_2_tftrn_themename",GXType.VarChar,100,0) ,
          new ParDef("AV44Trn_themewwds_3_tftrn_themename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_themewwds_4_tftrn_themefontfamily",GXType.VarChar,40,0) ,
          new ParDef("AV46Trn_themewwds_5_tftrn_themefontfamily_sel",GXType.VarChar,40,0) ,
          new ParDef("AV47Trn_themewwds_6_tftrn_themefontsize",GXType.Int16,4,0) ,
          new ParDef("AV48Trn_themewwds_7_tftrn_themefontsize_to",GXType.Int16,4,0)
          };
          Object[] prmP00813;
          prmP00813 = new Object[] {
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_themewwds_2_tftrn_themename",GXType.VarChar,100,0) ,
          new ParDef("AV44Trn_themewwds_3_tftrn_themename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_themewwds_4_tftrn_themefontfamily",GXType.VarChar,40,0) ,
          new ParDef("AV46Trn_themewwds_5_tftrn_themefontfamily_sel",GXType.VarChar,40,0) ,
          new ParDef("AV47Trn_themewwds_6_tftrn_themefontsize",GXType.Int16,4,0) ,
          new ParDef("AV48Trn_themewwds_7_tftrn_themefontsize_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00812", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00812,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00813", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00813,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
