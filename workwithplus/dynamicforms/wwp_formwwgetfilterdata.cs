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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formwwgetfilterdata : GXProcedure
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
            return "wwp_formww_Services_Execute" ;
         }

      }

      public wwp_formwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV11TFWWPFormReferenceName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV12TFWWPFormReferenceName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV13TFWWPFormTitle = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV14TFWWPFormTitle_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV15TFWWPFormDate = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFWWPFormDate_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV40WWPFormType = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV41WWPFormIsForDynamicValidations = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormReferenceName = AV17SearchTxt;
         AV12TFWWPFormReferenceName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV12TFWWPFormReferenceName_Sel ,
                                              AV11TFWWPFormReferenceName ,
                                              AV14TFWWPFormTitle_Sel ,
                                              AV13TFWWPFormTitle ,
                                              AV15TFWWPFormDate ,
                                              AV16TFWWPFormDate_To ,
                                              AV40WWPFormType ,
                                              AV41WWPFormIsForDynamicValidations ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A242WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A207WWPFormVersionNumber ,
                                              A219WWPFormLatestVersionNumber ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV11TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV11TFWWPFormReferenceName), "%", "");
         lV13TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV13TFWWPFormTitle), "%", "");
         /* Using cursor P008V3 */
         pr_default.execute(0, new Object[] {AV40WWPFormType, lV39FilterFullText, lV39FilterFullText, lV11TFWWPFormReferenceName, AV12TFWWPFormReferenceName_Sel, lV13TFWWPFormTitle, AV14TFWWPFormTitle_Sel, AV15TFWWPFormDate, AV16TFWWPFormDate_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8V2 = false;
            A240WWPFormType = P008V3_A240WWPFormType[0];
            A208WWPFormReferenceName = P008V3_A208WWPFormReferenceName[0];
            A242WWPFormIsForDynamicValidations = P008V3_A242WWPFormIsForDynamicValidations[0];
            A207WWPFormVersionNumber = P008V3_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P008V3_A231WWPFormDate[0];
            A209WWPFormTitle = P008V3_A209WWPFormTitle[0];
            A40000GXC1 = P008V3_A40000GXC1[0];
            n40000GXC1 = P008V3_n40000GXC1[0];
            A206WWPFormId = P008V3_A206WWPFormId[0];
            A40000GXC1 = P008V3_A40000GXC1[0];
            n40000GXC1 = P008V3_n40000GXC1[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P008V3_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P008V3_A208WWPFormReferenceName[0], A208WWPFormReferenceName) == 0 ) )
               {
                  BRK8V2 = false;
                  A207WWPFormVersionNumber = P008V3_A207WWPFormVersionNumber[0];
                  A206WWPFormId = P008V3_A206WWPFormId[0];
                  AV27count = (long)(AV27count+1);
                  BRK8V2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
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
            }
            if ( ! BRK8V2 )
            {
               BRK8V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV13TFWWPFormTitle = AV17SearchTxt;
         AV14TFWWPFormTitle_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV12TFWWPFormReferenceName_Sel ,
                                              AV11TFWWPFormReferenceName ,
                                              AV14TFWWPFormTitle_Sel ,
                                              AV13TFWWPFormTitle ,
                                              AV15TFWWPFormDate ,
                                              AV16TFWWPFormDate_To ,
                                              AV40WWPFormType ,
                                              AV41WWPFormIsForDynamicValidations ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A242WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A207WWPFormVersionNumber ,
                                              A219WWPFormLatestVersionNumber ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV11TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV11TFWWPFormReferenceName), "%", "");
         lV13TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV13TFWWPFormTitle), "%", "");
         /* Using cursor P008V5 */
         pr_default.execute(1, new Object[] {AV40WWPFormType, lV39FilterFullText, lV39FilterFullText, lV11TFWWPFormReferenceName, AV12TFWWPFormReferenceName_Sel, lV13TFWWPFormTitle, AV14TFWWPFormTitle_Sel, AV15TFWWPFormDate, AV16TFWWPFormDate_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8V4 = false;
            A240WWPFormType = P008V5_A240WWPFormType[0];
            A209WWPFormTitle = P008V5_A209WWPFormTitle[0];
            A242WWPFormIsForDynamicValidations = P008V5_A242WWPFormIsForDynamicValidations[0];
            A207WWPFormVersionNumber = P008V5_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P008V5_A231WWPFormDate[0];
            A208WWPFormReferenceName = P008V5_A208WWPFormReferenceName[0];
            A40000GXC1 = P008V5_A40000GXC1[0];
            n40000GXC1 = P008V5_n40000GXC1[0];
            A206WWPFormId = P008V5_A206WWPFormId[0];
            A40000GXC1 = P008V5_A40000GXC1[0];
            n40000GXC1 = P008V5_n40000GXC1[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P008V5_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P008V5_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
               {
                  BRK8V4 = false;
                  A207WWPFormVersionNumber = P008V5_A207WWPFormVersionNumber[0];
                  A206WWPFormId = P008V5_A206WWPFormId[0];
                  AV27count = (long)(AV27count+1);
                  BRK8V4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
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
            }
            if ( ! BRK8V4 )
            {
               BRK8V4 = true;
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
         AV11TFWWPFormReferenceName = "";
         AV12TFWWPFormReferenceName_Sel = "";
         AV13TFWWPFormTitle = "";
         AV14TFWWPFormTitle_Sel = "";
         AV15TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV16TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         lV39FilterFullText = "";
         lV11TFWWPFormReferenceName = "";
         lV13TFWWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         P008V3_A240WWPFormType = new short[1] ;
         P008V3_A208WWPFormReferenceName = new string[] {""} ;
         P008V3_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         P008V3_A207WWPFormVersionNumber = new short[1] ;
         P008V3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P008V3_A209WWPFormTitle = new string[] {""} ;
         P008V3_A40000GXC1 = new int[1] ;
         P008V3_n40000GXC1 = new bool[] {false} ;
         P008V3_A206WWPFormId = new short[1] ;
         AV22Option = "";
         P008V5_A240WWPFormType = new short[1] ;
         P008V5_A209WWPFormTitle = new string[] {""} ;
         P008V5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         P008V5_A207WWPFormVersionNumber = new short[1] ;
         P008V5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P008V5_A208WWPFormReferenceName = new string[] {""} ;
         P008V5_A40000GXC1 = new int[1] ;
         P008V5_n40000GXC1 = new bool[] {false} ;
         P008V5_A206WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008V3_A240WWPFormType, P008V3_A208WWPFormReferenceName, P008V3_A242WWPFormIsForDynamicValidations, P008V3_A207WWPFormVersionNumber, P008V3_A231WWPFormDate, P008V3_A209WWPFormTitle, P008V3_A40000GXC1, P008V3_n40000GXC1, P008V3_A206WWPFormId
               }
               , new Object[] {
               P008V5_A240WWPFormType, P008V5_A209WWPFormTitle, P008V5_A242WWPFormIsForDynamicValidations, P008V5_A207WWPFormVersionNumber, P008V5_A231WWPFormDate, P008V5_A208WWPFormReferenceName, P008V5_A40000GXC1, P008V5_n40000GXC1, P008V5_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV40WWPFormType ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short GXt_int1 ;
      private int AV42GXV1 ;
      private int A40000GXC1 ;
      private long AV27count ;
      private DateTime AV15TFWWPFormDate ;
      private DateTime AV16TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV41WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool BRK8V2 ;
      private bool n40000GXC1 ;
      private bool BRK8V4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFWWPFormReferenceName ;
      private string AV12TFWWPFormReferenceName_Sel ;
      private string AV13TFWWPFormTitle ;
      private string AV14TFWWPFormTitle_Sel ;
      private string lV39FilterFullText ;
      private string lV11TFWWPFormReferenceName ;
      private string lV13TFWWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV22Option ;
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
      private short[] P008V3_A240WWPFormType ;
      private string[] P008V3_A208WWPFormReferenceName ;
      private bool[] P008V3_A242WWPFormIsForDynamicValidations ;
      private short[] P008V3_A207WWPFormVersionNumber ;
      private DateTime[] P008V3_A231WWPFormDate ;
      private string[] P008V3_A209WWPFormTitle ;
      private int[] P008V3_A40000GXC1 ;
      private bool[] P008V3_n40000GXC1 ;
      private short[] P008V3_A206WWPFormId ;
      private short[] P008V5_A240WWPFormType ;
      private string[] P008V5_A209WWPFormTitle ;
      private bool[] P008V5_A242WWPFormIsForDynamicValidations ;
      private short[] P008V5_A207WWPFormVersionNumber ;
      private DateTime[] P008V5_A231WWPFormDate ;
      private string[] P008V5_A208WWPFormReferenceName ;
      private int[] P008V5_A40000GXC1 ;
      private bool[] P008V5_n40000GXC1 ;
      private short[] P008V5_A206WWPFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wwp_formwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008V3( IGxContext context ,
                                             string AV39FilterFullText ,
                                             string AV12TFWWPFormReferenceName_Sel ,
                                             string AV11TFWWPFormReferenceName ,
                                             string AV14TFWWPFormTitle_Sel ,
                                             string AV13TFWWPFormTitle ,
                                             DateTime AV15TFWWPFormDate ,
                                             DateTime AV16TFWWPFormDate_To ,
                                             short AV40WWPFormType ,
                                             bool AV41WWPFormIsForDynamicValidations ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             bool A242WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A207WWPFormVersionNumber ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormReferenceName, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormDate, T1.WWPFormTitle, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV40WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.WWPFormReferenceName) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(T1.WWPFormTitle) like '%' || LOWER(:lV39FilterFullText)))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV11TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV12TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV13TFWWPFormTitle)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV14TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV15TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate >= :AV15TFWWPFormDate)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV16TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate <= :AV16TFWWPFormDate_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( AV40WWPFormType == 1 ) && AV41WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV40WWPFormType == 1 ) && ! AV41WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P008V5( IGxContext context ,
                                             string AV39FilterFullText ,
                                             string AV12TFWWPFormReferenceName_Sel ,
                                             string AV11TFWWPFormReferenceName ,
                                             string AV14TFWWPFormTitle_Sel ,
                                             string AV13TFWWPFormTitle ,
                                             DateTime AV15TFWWPFormDate ,
                                             DateTime AV16TFWWPFormDate_To ,
                                             short AV40WWPFormType ,
                                             bool AV41WWPFormIsForDynamicValidations ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             bool A242WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A207WWPFormVersionNumber ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormDate, T1.WWPFormReferenceName, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV40WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.WWPFormReferenceName) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(T1.WWPFormTitle) like '%' || LOWER(:lV39FilterFullText)))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV11TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV12TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV13TFWWPFormTitle)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV14TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV15TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate >= :AV15TFWWPFormDate)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV16TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate <= :AV16TFWWPFormDate_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( AV40WWPFormType == 1 ) && AV41WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV40WWPFormType == 1 ) && ! AV41WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (bool)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 1 :
                     return conditional_P008V5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (bool)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmP008V3;
          prmP008V3 = new Object[] {
          new ParDef("AV40WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV15TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV16TFWWPFormDate_To",GXType.DateTime,8,5)
          };
          Object[] prmP008V5;
          prmP008V5 = new Object[] {
          new ParDef("AV40WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV15TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV16TFWWPFormDate_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P008V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
