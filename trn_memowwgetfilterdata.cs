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
   public class trn_memowwgetfilterdata : GXProcedure
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
            return "trn_memoww_Services_Execute" ;
         }

      }

      public trn_memowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memowwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MEMOTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADMEMOTITLEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("Trn_MemoWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_MemoWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("Trn_MemoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOTITLE") == 0 )
            {
               AV13TFMemoTitle = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOTITLE_SEL") == 0 )
            {
               AV14TFMemoTitle_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOSTARTDATETIME") == 0 )
            {
               AV15TFMemoStartDateTime = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFMemoStartDateTime_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOENDDATETIME") == 0 )
            {
               AV17TFMemoEndDateTime = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV18TFMemoEndDateTime_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMODURATION") == 0 )
            {
               AV19TFMemoDuration = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV20TFMemoDuration_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOREMOVEDATE") == 0 )
            {
               AV21TFMemoRemoveDate = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV22TFMemoRemoveDate_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEMOCREATEDAT") == 0 )
            {
               AV46TFMemoCreatedAt = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV47TFMemoCreatedAt_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMEMOTITLEOPTIONS' Routine */
         returnInSub = false;
         AV13TFMemoTitle = AV23SearchTxt;
         AV14TFMemoTitle_Sel = "";
         AV50Trn_memowwds_1_filterfulltext = AV45FilterFullText;
         AV51Trn_memowwds_2_tfmemotitle = AV13TFMemoTitle;
         AV52Trn_memowwds_3_tfmemotitle_sel = AV14TFMemoTitle_Sel;
         AV53Trn_memowwds_4_tfmemostartdatetime = AV15TFMemoStartDateTime;
         AV54Trn_memowwds_5_tfmemostartdatetime_to = AV16TFMemoStartDateTime_To;
         AV55Trn_memowwds_6_tfmemoenddatetime = AV17TFMemoEndDateTime;
         AV56Trn_memowwds_7_tfmemoenddatetime_to = AV18TFMemoEndDateTime_To;
         AV57Trn_memowwds_8_tfmemoduration = AV19TFMemoDuration;
         AV58Trn_memowwds_9_tfmemoduration_to = AV20TFMemoDuration_To;
         AV59Trn_memowwds_10_tfmemoremovedate = AV21TFMemoRemoveDate;
         AV60Trn_memowwds_11_tfmemoremovedate_to = AV22TFMemoRemoveDate_To;
         AV61Trn_memowwds_12_tfmemocreatedat = AV46TFMemoCreatedAt;
         AV62Trn_memowwds_13_tfmemocreatedat_to = AV47TFMemoCreatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Trn_memowwds_1_filterfulltext ,
                                              AV52Trn_memowwds_3_tfmemotitle_sel ,
                                              AV51Trn_memowwds_2_tfmemotitle ,
                                              AV53Trn_memowwds_4_tfmemostartdatetime ,
                                              AV54Trn_memowwds_5_tfmemostartdatetime_to ,
                                              AV55Trn_memowwds_6_tfmemoenddatetime ,
                                              AV56Trn_memowwds_7_tfmemoenddatetime_to ,
                                              AV57Trn_memowwds_8_tfmemoduration ,
                                              AV58Trn_memowwds_9_tfmemoduration_to ,
                                              AV59Trn_memowwds_10_tfmemoremovedate ,
                                              AV60Trn_memowwds_11_tfmemoremovedate_to ,
                                              AV61Trn_memowwds_12_tfmemocreatedat ,
                                              AV62Trn_memowwds_13_tfmemocreatedat_to ,
                                              A550MemoTitle ,
                                              A563MemoDuration ,
                                              A561MemoStartDateTime ,
                                              A562MemoEndDateTime ,
                                              A564MemoRemoveDate ,
                                              A647MemoCreatedAt } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV50Trn_memowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_memowwds_1_filterfulltext), "%", "");
         lV50Trn_memowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_memowwds_1_filterfulltext), "%", "");
         lV51Trn_memowwds_2_tfmemotitle = StringUtil.Concat( StringUtil.RTrim( AV51Trn_memowwds_2_tfmemotitle), "%", "");
         /* Using cursor P00CJ2 */
         pr_default.execute(0, new Object[] {lV50Trn_memowwds_1_filterfulltext, lV50Trn_memowwds_1_filterfulltext, lV51Trn_memowwds_2_tfmemotitle, AV52Trn_memowwds_3_tfmemotitle_sel, AV53Trn_memowwds_4_tfmemostartdatetime, AV54Trn_memowwds_5_tfmemostartdatetime_to, AV55Trn_memowwds_6_tfmemoenddatetime, AV56Trn_memowwds_7_tfmemoenddatetime_to, AV57Trn_memowwds_8_tfmemoduration, AV58Trn_memowwds_9_tfmemoduration_to, AV59Trn_memowwds_10_tfmemoremovedate, AV60Trn_memowwds_11_tfmemoremovedate_to, AV61Trn_memowwds_12_tfmemocreatedat, AV62Trn_memowwds_13_tfmemocreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCJ2 = false;
            A550MemoTitle = P00CJ2_A550MemoTitle[0];
            A647MemoCreatedAt = P00CJ2_A647MemoCreatedAt[0];
            n647MemoCreatedAt = P00CJ2_n647MemoCreatedAt[0];
            A564MemoRemoveDate = P00CJ2_A564MemoRemoveDate[0];
            n564MemoRemoveDate = P00CJ2_n564MemoRemoveDate[0];
            A563MemoDuration = P00CJ2_A563MemoDuration[0];
            n563MemoDuration = P00CJ2_n563MemoDuration[0];
            A562MemoEndDateTime = P00CJ2_A562MemoEndDateTime[0];
            n562MemoEndDateTime = P00CJ2_n562MemoEndDateTime[0];
            A561MemoStartDateTime = P00CJ2_A561MemoStartDateTime[0];
            n561MemoStartDateTime = P00CJ2_n561MemoStartDateTime[0];
            A549MemoId = P00CJ2_A549MemoId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CJ2_A550MemoTitle[0], A550MemoTitle) == 0 ) )
            {
               BRKCJ2 = false;
               A549MemoId = P00CJ2_A549MemoId[0];
               AV33count = (long)(AV33count+1);
               BRKCJ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A550MemoTitle)) ? "<#Empty#>" : A550MemoTitle);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRKCJ2 )
            {
               BRKCJ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV37GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFMemoTitle = "";
         AV14TFMemoTitle_Sel = "";
         AV15TFMemoStartDateTime = (DateTime)(DateTime.MinValue);
         AV16TFMemoStartDateTime_To = (DateTime)(DateTime.MinValue);
         AV17TFMemoEndDateTime = (DateTime)(DateTime.MinValue);
         AV18TFMemoEndDateTime_To = (DateTime)(DateTime.MinValue);
         AV21TFMemoRemoveDate = DateTime.MinValue;
         AV22TFMemoRemoveDate_To = DateTime.MinValue;
         AV46TFMemoCreatedAt = DateTimeUtil.ResetTime( context.localUtil.CToD( "", DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) ;
         AV47TFMemoCreatedAt_To = DateTimeUtil.ResetTime( context.localUtil.CToD( "", DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) ;
         AV50Trn_memowwds_1_filterfulltext = "";
         AV51Trn_memowwds_2_tfmemotitle = "";
         AV52Trn_memowwds_3_tfmemotitle_sel = "";
         AV53Trn_memowwds_4_tfmemostartdatetime = (DateTime)(DateTime.MinValue);
         AV54Trn_memowwds_5_tfmemostartdatetime_to = (DateTime)(DateTime.MinValue);
         AV55Trn_memowwds_6_tfmemoenddatetime = (DateTime)(DateTime.MinValue);
         AV56Trn_memowwds_7_tfmemoenddatetime_to = (DateTime)(DateTime.MinValue);
         AV59Trn_memowwds_10_tfmemoremovedate = DateTime.MinValue;
         AV60Trn_memowwds_11_tfmemoremovedate_to = DateTime.MinValue;
         AV61Trn_memowwds_12_tfmemocreatedat = (DateTime)(DateTime.MinValue);
         AV62Trn_memowwds_13_tfmemocreatedat_to = (DateTime)(DateTime.MinValue);
         lV50Trn_memowwds_1_filterfulltext = "";
         lV51Trn_memowwds_2_tfmemotitle = "";
         A550MemoTitle = "";
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A564MemoRemoveDate = DateTime.MinValue;
         A647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         P00CJ2_A550MemoTitle = new string[] {""} ;
         P00CJ2_A647MemoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CJ2_n647MemoCreatedAt = new bool[] {false} ;
         P00CJ2_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00CJ2_n564MemoRemoveDate = new bool[] {false} ;
         P00CJ2_A563MemoDuration = new decimal[1] ;
         P00CJ2_n563MemoDuration = new bool[] {false} ;
         P00CJ2_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00CJ2_n562MemoEndDateTime = new bool[] {false} ;
         P00CJ2_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00CJ2_n561MemoStartDateTime = new bool[] {false} ;
         P00CJ2_A549MemoId = new Guid[] {Guid.Empty} ;
         A549MemoId = Guid.Empty;
         AV28Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CJ2_A550MemoTitle, P00CJ2_A647MemoCreatedAt, P00CJ2_n647MemoCreatedAt, P00CJ2_A564MemoRemoveDate, P00CJ2_n564MemoRemoveDate, P00CJ2_A563MemoDuration, P00CJ2_n563MemoDuration, P00CJ2_A562MemoEndDateTime, P00CJ2_n562MemoEndDateTime, P00CJ2_A561MemoStartDateTime,
               P00CJ2_n561MemoStartDateTime, P00CJ2_A549MemoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV48GXV1 ;
      private long AV33count ;
      private decimal AV19TFMemoDuration ;
      private decimal AV20TFMemoDuration_To ;
      private decimal AV57Trn_memowwds_8_tfmemoduration ;
      private decimal AV58Trn_memowwds_9_tfmemoduration_to ;
      private decimal A563MemoDuration ;
      private DateTime AV15TFMemoStartDateTime ;
      private DateTime AV16TFMemoStartDateTime_To ;
      private DateTime AV17TFMemoEndDateTime ;
      private DateTime AV18TFMemoEndDateTime_To ;
      private DateTime AV46TFMemoCreatedAt ;
      private DateTime AV47TFMemoCreatedAt_To ;
      private DateTime AV53Trn_memowwds_4_tfmemostartdatetime ;
      private DateTime AV54Trn_memowwds_5_tfmemostartdatetime_to ;
      private DateTime AV55Trn_memowwds_6_tfmemoenddatetime ;
      private DateTime AV56Trn_memowwds_7_tfmemoenddatetime_to ;
      private DateTime AV61Trn_memowwds_12_tfmemocreatedat ;
      private DateTime AV62Trn_memowwds_13_tfmemocreatedat_to ;
      private DateTime A561MemoStartDateTime ;
      private DateTime A562MemoEndDateTime ;
      private DateTime A647MemoCreatedAt ;
      private DateTime AV21TFMemoRemoveDate ;
      private DateTime AV22TFMemoRemoveDate_To ;
      private DateTime AV59Trn_memowwds_10_tfmemoremovedate ;
      private DateTime AV60Trn_memowwds_11_tfmemoremovedate_to ;
      private DateTime A564MemoRemoveDate ;
      private bool returnInSub ;
      private bool BRKCJ2 ;
      private bool n647MemoCreatedAt ;
      private bool n564MemoRemoveDate ;
      private bool n563MemoDuration ;
      private bool n562MemoEndDateTime ;
      private bool n561MemoStartDateTime ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV13TFMemoTitle ;
      private string AV14TFMemoTitle_Sel ;
      private string AV50Trn_memowwds_1_filterfulltext ;
      private string AV51Trn_memowwds_2_tfmemotitle ;
      private string AV52Trn_memowwds_3_tfmemotitle_sel ;
      private string lV50Trn_memowwds_1_filterfulltext ;
      private string lV51Trn_memowwds_2_tfmemotitle ;
      private string A550MemoTitle ;
      private string AV28Option ;
      private Guid A549MemoId ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV36GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00CJ2_A550MemoTitle ;
      private DateTime[] P00CJ2_A647MemoCreatedAt ;
      private bool[] P00CJ2_n647MemoCreatedAt ;
      private DateTime[] P00CJ2_A564MemoRemoveDate ;
      private bool[] P00CJ2_n564MemoRemoveDate ;
      private decimal[] P00CJ2_A563MemoDuration ;
      private bool[] P00CJ2_n563MemoDuration ;
      private DateTime[] P00CJ2_A562MemoEndDateTime ;
      private bool[] P00CJ2_n562MemoEndDateTime ;
      private DateTime[] P00CJ2_A561MemoStartDateTime ;
      private bool[] P00CJ2_n561MemoStartDateTime ;
      private Guid[] P00CJ2_A549MemoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_memowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CJ2( IGxContext context ,
                                             string AV50Trn_memowwds_1_filterfulltext ,
                                             string AV52Trn_memowwds_3_tfmemotitle_sel ,
                                             string AV51Trn_memowwds_2_tfmemotitle ,
                                             DateTime AV53Trn_memowwds_4_tfmemostartdatetime ,
                                             DateTime AV54Trn_memowwds_5_tfmemostartdatetime_to ,
                                             DateTime AV55Trn_memowwds_6_tfmemoenddatetime ,
                                             DateTime AV56Trn_memowwds_7_tfmemoenddatetime_to ,
                                             decimal AV57Trn_memowwds_8_tfmemoduration ,
                                             decimal AV58Trn_memowwds_9_tfmemoduration_to ,
                                             DateTime AV59Trn_memowwds_10_tfmemoremovedate ,
                                             DateTime AV60Trn_memowwds_11_tfmemoremovedate_to ,
                                             DateTime AV61Trn_memowwds_12_tfmemocreatedat ,
                                             DateTime AV62Trn_memowwds_13_tfmemocreatedat_to ,
                                             string A550MemoTitle ,
                                             decimal A563MemoDuration ,
                                             DateTime A561MemoStartDateTime ,
                                             DateTime A562MemoEndDateTime ,
                                             DateTime A564MemoRemoveDate ,
                                             DateTime A647MemoCreatedAt )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MemoTitle, MemoCreatedAt, MemoRemoveDate, MemoDuration, MemoEndDateTime, MemoStartDateTime, MemoId FROM Trn_Memo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_memowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(MemoTitle) like '%' || LOWER(:lV50Trn_memowwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(MemoDuration,'90.999'), 2) like '%' || :lV50Trn_memowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_memowwds_3_tfmemotitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_memowwds_2_tfmemotitle)) ) )
         {
            AddWhere(sWhereString, "(MemoTitle like :lV51Trn_memowwds_2_tfmemotitle)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_memowwds_3_tfmemotitle_sel)) && ! ( StringUtil.StrCmp(AV52Trn_memowwds_3_tfmemotitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MemoTitle = ( :AV52Trn_memowwds_3_tfmemotitle_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_memowwds_3_tfmemotitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MemoTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV53Trn_memowwds_4_tfmemostartdatetime) )
         {
            AddWhere(sWhereString, "(MemoStartDateTime >= :AV53Trn_memowwds_4_tfmemostartdatetime)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Trn_memowwds_5_tfmemostartdatetime_to) )
         {
            AddWhere(sWhereString, "(MemoStartDateTime <= :AV54Trn_memowwds_5_tfmemostartdatetime_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Trn_memowwds_6_tfmemoenddatetime) )
         {
            AddWhere(sWhereString, "(MemoEndDateTime >= :AV55Trn_memowwds_6_tfmemoenddatetime)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Trn_memowwds_7_tfmemoenddatetime_to) )
         {
            AddWhere(sWhereString, "(MemoEndDateTime <= :AV56Trn_memowwds_7_tfmemoenddatetime_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Trn_memowwds_8_tfmemoduration) )
         {
            AddWhere(sWhereString, "(MemoDuration >= :AV57Trn_memowwds_8_tfmemoduration)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Trn_memowwds_9_tfmemoduration_to) )
         {
            AddWhere(sWhereString, "(MemoDuration <= :AV58Trn_memowwds_9_tfmemoduration_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Trn_memowwds_10_tfmemoremovedate) )
         {
            AddWhere(sWhereString, "(MemoRemoveDate >= :AV59Trn_memowwds_10_tfmemoremovedate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Trn_memowwds_11_tfmemoremovedate_to) )
         {
            AddWhere(sWhereString, "(MemoRemoveDate <= :AV60Trn_memowwds_11_tfmemoremovedate_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Trn_memowwds_12_tfmemocreatedat) )
         {
            AddWhere(sWhereString, "(MemoCreatedAt >= :AV61Trn_memowwds_12_tfmemocreatedat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Trn_memowwds_13_tfmemocreatedat_to) )
         {
            AddWhere(sWhereString, "(MemoCreatedAt <= :AV62Trn_memowwds_13_tfmemocreatedat_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MemoTitle";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00CJ2;
          prmP00CJ2 = new Object[] {
          new ParDef("lV50Trn_memowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_memowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_memowwds_2_tfmemotitle",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_memowwds_3_tfmemotitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_memowwds_4_tfmemostartdatetime",GXType.DateTime,8,5) ,
          new ParDef("AV54Trn_memowwds_5_tfmemostartdatetime_to",GXType.DateTime,8,5) ,
          new ParDef("AV55Trn_memowwds_6_tfmemoenddatetime",GXType.DateTime,8,5) ,
          new ParDef("AV56Trn_memowwds_7_tfmemoenddatetime_to",GXType.DateTime,8,5) ,
          new ParDef("AV57Trn_memowwds_8_tfmemoduration",GXType.Number,6,3) ,
          new ParDef("AV58Trn_memowwds_9_tfmemoduration_to",GXType.Number,6,3) ,
          new ParDef("AV59Trn_memowwds_10_tfmemoremovedate",GXType.Date,8,0) ,
          new ParDef("AV60Trn_memowwds_11_tfmemoremovedate_to",GXType.Date,8,0) ,
          new ParDef("AV61Trn_memowwds_12_tfmemocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV62Trn_memowwds_13_tfmemocreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00CJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CJ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
