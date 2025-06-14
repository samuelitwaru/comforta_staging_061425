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
   public class trn_environmentvariablewwgetfilterdata : GXProcedure
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
            return "trn_environmentvariableww_Services_Execute" ;
         }

      }

      public trn_environmentvariablewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_environmentvariablewwgetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_ENVIRONMENTVARIABLEKEY") == 0 )
         {
            /* Execute user subroutine: 'LOADENVIRONMENTVARIABLEKEYOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_ENVIRONMENTVARIABLEVALUE") == 0 )
         {
            /* Execute user subroutine: 'LOADENVIRONMENTVARIABLEVALUEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("Trn_EnvironmentVariableWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_EnvironmentVariableWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Trn_EnvironmentVariableWWGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFENVIRONMENTVARIABLEKEY") == 0 )
            {
               AV12TFEnvironmentVariableKey = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFENVIRONMENTVARIABLEKEY_SEL") == 0 )
            {
               AV13TFEnvironmentVariableKey_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFENVIRONMENTVARIABLEVALUE") == 0 )
            {
               AV14TFEnvironmentVariableValue = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFENVIRONMENTVARIABLEVALUE_SEL") == 0 )
            {
               AV15TFEnvironmentVariableValue_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADENVIRONMENTVARIABLEKEYOPTIONS' Routine */
         returnInSub = false;
         AV12TFEnvironmentVariableKey = AV16SearchTxt;
         AV13TFEnvironmentVariableKey_Sel = "";
         AV41Trn_environmentvariablewwds_1_filterfulltext = AV38FilterFullText;
         AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = AV12TFEnvironmentVariableKey;
         AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel = AV13TFEnvironmentVariableKey_Sel;
         AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = AV14TFEnvironmentVariableValue;
         AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel = AV15TFEnvironmentVariableValue_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Trn_environmentvariablewwds_1_filterfulltext ,
                                              AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel ,
                                              AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ,
                                              AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel ,
                                              AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ,
                                              A633EnvironmentVariableKey ,
                                              A634EnvironmentVariableValue } ,
                                              new int[]{
                                              }
         });
         lV41Trn_environmentvariablewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext), "%", "");
         lV41Trn_environmentvariablewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext), "%", "");
         lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = StringUtil.Concat( StringUtil.RTrim( AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey), "%", "");
         lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = StringUtil.Concat( StringUtil.RTrim( AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue), "%", "");
         /* Using cursor P00GJ2 */
         pr_default.execute(0, new Object[] {lV41Trn_environmentvariablewwds_1_filterfulltext, lV41Trn_environmentvariablewwds_1_filterfulltext, lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey, AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue, AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKGJ2 = false;
            A633EnvironmentVariableKey = P00GJ2_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = P00GJ2_A634EnvironmentVariableValue[0];
            A632EnvironmentVariableId = P00GJ2_A632EnvironmentVariableId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00GJ2_A633EnvironmentVariableKey[0], A633EnvironmentVariableKey) == 0 ) )
            {
               BRKGJ2 = false;
               A632EnvironmentVariableId = P00GJ2_A632EnvironmentVariableId[0];
               AV26count = (long)(AV26count+1);
               BRKGJ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A633EnvironmentVariableKey)) ? "<#Empty#>" : A633EnvironmentVariableKey);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRKGJ2 )
            {
               BRKGJ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADENVIRONMENTVARIABLEVALUEOPTIONS' Routine */
         returnInSub = false;
         AV14TFEnvironmentVariableValue = AV16SearchTxt;
         AV15TFEnvironmentVariableValue_Sel = "";
         AV41Trn_environmentvariablewwds_1_filterfulltext = AV38FilterFullText;
         AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = AV12TFEnvironmentVariableKey;
         AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel = AV13TFEnvironmentVariableKey_Sel;
         AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = AV14TFEnvironmentVariableValue;
         AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel = AV15TFEnvironmentVariableValue_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41Trn_environmentvariablewwds_1_filterfulltext ,
                                              AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel ,
                                              AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ,
                                              AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel ,
                                              AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ,
                                              A633EnvironmentVariableKey ,
                                              A634EnvironmentVariableValue } ,
                                              new int[]{
                                              }
         });
         lV41Trn_environmentvariablewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext), "%", "");
         lV41Trn_environmentvariablewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext), "%", "");
         lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = StringUtil.Concat( StringUtil.RTrim( AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey), "%", "");
         lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = StringUtil.Concat( StringUtil.RTrim( AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue), "%", "");
         /* Using cursor P00GJ3 */
         pr_default.execute(1, new Object[] {lV41Trn_environmentvariablewwds_1_filterfulltext, lV41Trn_environmentvariablewwds_1_filterfulltext, lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey, AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue, AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKGJ4 = false;
            A634EnvironmentVariableValue = P00GJ3_A634EnvironmentVariableValue[0];
            A633EnvironmentVariableKey = P00GJ3_A633EnvironmentVariableKey[0];
            A632EnvironmentVariableId = P00GJ3_A632EnvironmentVariableId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00GJ3_A634EnvironmentVariableValue[0], A634EnvironmentVariableValue) == 0 ) )
            {
               BRKGJ4 = false;
               A632EnvironmentVariableId = P00GJ3_A632EnvironmentVariableId[0];
               AV26count = (long)(AV26count+1);
               BRKGJ4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A634EnvironmentVariableValue)) ? "<#Empty#>" : A634EnvironmentVariableValue);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRKGJ4 )
            {
               BRKGJ4 = true;
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV30GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV12TFEnvironmentVariableKey = "";
         AV13TFEnvironmentVariableKey_Sel = "";
         AV14TFEnvironmentVariableValue = "";
         AV15TFEnvironmentVariableValue_Sel = "";
         AV41Trn_environmentvariablewwds_1_filterfulltext = "";
         AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = "";
         AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel = "";
         AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = "";
         AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel = "";
         lV41Trn_environmentvariablewwds_1_filterfulltext = "";
         lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey = "";
         lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue = "";
         A633EnvironmentVariableKey = "";
         A634EnvironmentVariableValue = "";
         P00GJ2_A633EnvironmentVariableKey = new string[] {""} ;
         P00GJ2_A634EnvironmentVariableValue = new string[] {""} ;
         P00GJ2_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         A632EnvironmentVariableId = Guid.Empty;
         AV21Option = "";
         P00GJ3_A634EnvironmentVariableValue = new string[] {""} ;
         P00GJ3_A633EnvironmentVariableKey = new string[] {""} ;
         P00GJ3_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariablewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00GJ2_A633EnvironmentVariableKey, P00GJ2_A634EnvironmentVariableValue, P00GJ2_A632EnvironmentVariableId
               }
               , new Object[] {
               P00GJ3_A634EnvironmentVariableValue, P00GJ3_A633EnvironmentVariableKey, P00GJ3_A632EnvironmentVariableId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private int AV39GXV1 ;
      private long AV26count ;
      private bool returnInSub ;
      private bool BRKGJ2 ;
      private bool BRKGJ4 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string A634EnvironmentVariableValue ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV12TFEnvironmentVariableKey ;
      private string AV13TFEnvironmentVariableKey_Sel ;
      private string AV14TFEnvironmentVariableValue ;
      private string AV15TFEnvironmentVariableValue_Sel ;
      private string AV41Trn_environmentvariablewwds_1_filterfulltext ;
      private string AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ;
      private string AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel ;
      private string AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ;
      private string AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel ;
      private string lV41Trn_environmentvariablewwds_1_filterfulltext ;
      private string lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ;
      private string lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ;
      private string A633EnvironmentVariableKey ;
      private string AV21Option ;
      private Guid A632EnvironmentVariableId ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV29GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00GJ2_A633EnvironmentVariableKey ;
      private string[] P00GJ2_A634EnvironmentVariableValue ;
      private Guid[] P00GJ2_A632EnvironmentVariableId ;
      private string[] P00GJ3_A634EnvironmentVariableValue ;
      private string[] P00GJ3_A633EnvironmentVariableKey ;
      private Guid[] P00GJ3_A632EnvironmentVariableId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_environmentvariablewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GJ2( IGxContext context ,
                                             string AV41Trn_environmentvariablewwds_1_filterfulltext ,
                                             string AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel ,
                                             string AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ,
                                             string AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel ,
                                             string AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ,
                                             string A633EnvironmentVariableKey ,
                                             string A634EnvironmentVariableValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT EnvironmentVariableKey, EnvironmentVariableValue, EnvironmentVariableId FROM Trn_EnvironmentVariable";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(EnvironmentVariableKey) like '%' || LOWER(:lV41Trn_environmentvariablewwds_1_filterfulltext)) or ( LOWER(EnvironmentVariableValue) like '%' || LOWER(:lV41Trn_environmentvariablewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey)) ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableKey like :lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel)) && ! ( StringUtil.StrCmp(AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableKey = ( :AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EnvironmentVariableKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue)) ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableValue like :lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel)) && ! ( StringUtil.StrCmp(AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableValue = ( :AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_se))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EnvironmentVariableValue))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EnvironmentVariableKey";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00GJ3( IGxContext context ,
                                             string AV41Trn_environmentvariablewwds_1_filterfulltext ,
                                             string AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel ,
                                             string AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey ,
                                             string AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel ,
                                             string AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue ,
                                             string A633EnvironmentVariableKey ,
                                             string A634EnvironmentVariableValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EnvironmentVariableValue, EnvironmentVariableKey, EnvironmentVariableId FROM Trn_EnvironmentVariable";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_environmentvariablewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(EnvironmentVariableKey) like '%' || LOWER(:lV41Trn_environmentvariablewwds_1_filterfulltext)) or ( LOWER(EnvironmentVariableValue) like '%' || LOWER(:lV41Trn_environmentvariablewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey)) ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableKey like :lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel)) && ! ( StringUtil.StrCmp(AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableKey = ( :AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EnvironmentVariableKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue)) ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableValue like :lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel)) && ! ( StringUtil.StrCmp(AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(EnvironmentVariableValue = ( :AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_se))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EnvironmentVariableValue))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EnvironmentVariableValue";
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
                     return conditional_P00GJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P00GJ3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00GJ2;
          prmP00GJ2 = new Object[] {
          new ParDef("lV41Trn_environmentvariablewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_environmentvariablewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey",GXType.VarChar,400,0) ,
          new ParDef("AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel",GXType.VarChar,400,0) ,
          new ParDef("lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue",GXType.VarChar,200,0) ,
          new ParDef("AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_se",GXType.VarChar,200,0)
          };
          Object[] prmP00GJ3;
          prmP00GJ3 = new Object[] {
          new ParDef("lV41Trn_environmentvariablewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_environmentvariablewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_environmentvariablewwds_2_tfenvironmentvariablekey",GXType.VarChar,400,0) ,
          new ParDef("AV43Trn_environmentvariablewwds_3_tfenvironmentvariablekey_sel",GXType.VarChar,400,0) ,
          new ParDef("lV44Trn_environmentvariablewwds_4_tfenvironmentvariablevalue",GXType.VarChar,200,0) ,
          new ParDef("AV45Trn_environmentvariablewwds_5_tfenvironmentvariablevalue_se",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ3,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
