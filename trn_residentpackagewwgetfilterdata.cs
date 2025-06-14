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
   public class trn_residentpackagewwgetfilterdata : GXProcedure
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
            return "trn_residentpackageww_Services_Execute" ;
         }

      }

      public trn_residentpackagewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentpackagewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_RESIDENTPACKAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPACKAGENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_RESIDENTPACKAGEMODULES") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPACKAGEMODULESOPTIONS' */
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
         if ( StringUtil.StrCmp(AV27Session.Get("Trn_ResidentPackageWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_ResidentPackageWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Trn_ResidentPackageWWGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFRESIDENTPACKAGENAME") == 0 )
            {
               AV11TFResidentPackageName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFRESIDENTPACKAGENAME_SEL") == 0 )
            {
               AV12TFResidentPackageName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFRESIDENTPACKAGEMODULES") == 0 )
            {
               AV13TFResidentPackageModules = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFRESIDENTPACKAGEMODULES_SEL") == 0 )
            {
               AV14TFResidentPackageModules_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFRESIDENTPACKAGEDEFAULT_SEL") == 0 )
            {
               AV15TFResidentPackageDefault_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTPACKAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFResidentPackageName = AV16SearchTxt;
         AV12TFResidentPackageName_Sel = "";
         AV41Trn_residentpackagewwds_1_filterfulltext = AV38FilterFullText;
         AV42Trn_residentpackagewwds_2_tfresidentpackagename = AV11TFResidentPackageName;
         AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel = AV12TFResidentPackageName_Sel;
         AV44Trn_residentpackagewwds_4_tfresidentpackagemodules = AV13TFResidentPackageModules;
         AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel = AV14TFResidentPackageModules_Sel;
         AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel = AV15TFResidentPackageDefault_Sel;
         AV47Udparg7 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Trn_residentpackagewwds_1_filterfulltext ,
                                              AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel ,
                                              AV42Trn_residentpackagewwds_2_tfresidentpackagename ,
                                              AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel ,
                                              AV44Trn_residentpackagewwds_4_tfresidentpackagemodules ,
                                              AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel ,
                                              A531ResidentPackageName ,
                                              A532ResidentPackageModules ,
                                              A533ResidentPackageDefault ,
                                              A528SG_LocationId ,
                                              AV47Udparg7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Trn_residentpackagewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext), "%", "");
         lV41Trn_residentpackagewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext), "%", "");
         lV42Trn_residentpackagewwds_2_tfresidentpackagename = StringUtil.Concat( StringUtil.RTrim( AV42Trn_residentpackagewwds_2_tfresidentpackagename), "%", "");
         lV44Trn_residentpackagewwds_4_tfresidentpackagemodules = StringUtil.Concat( StringUtil.RTrim( AV44Trn_residentpackagewwds_4_tfresidentpackagemodules), "%", "");
         /* Using cursor P00B52 */
         pr_default.execute(0, new Object[] {AV47Udparg7, lV41Trn_residentpackagewwds_1_filterfulltext, lV41Trn_residentpackagewwds_1_filterfulltext, lV42Trn_residentpackagewwds_2_tfresidentpackagename, AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, lV44Trn_residentpackagewwds_4_tfresidentpackagemodules, AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKB52 = false;
            A528SG_LocationId = P00B52_A528SG_LocationId[0];
            A531ResidentPackageName = P00B52_A531ResidentPackageName[0];
            A533ResidentPackageDefault = P00B52_A533ResidentPackageDefault[0];
            A532ResidentPackageModules = P00B52_A532ResidentPackageModules[0];
            A527ResidentPackageId = P00B52_A527ResidentPackageId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B52_A531ResidentPackageName[0], A531ResidentPackageName) == 0 ) )
            {
               BRKB52 = false;
               A527ResidentPackageId = P00B52_A527ResidentPackageId[0];
               AV26count = (long)(AV26count+1);
               BRKB52 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A531ResidentPackageName)) ? "<#Empty#>" : A531ResidentPackageName);
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
            if ( ! BRKB52 )
            {
               BRKB52 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTPACKAGEMODULESOPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentPackageModules = AV16SearchTxt;
         AV14TFResidentPackageModules_Sel = "";
         AV41Trn_residentpackagewwds_1_filterfulltext = AV38FilterFullText;
         AV42Trn_residentpackagewwds_2_tfresidentpackagename = AV11TFResidentPackageName;
         AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel = AV12TFResidentPackageName_Sel;
         AV44Trn_residentpackagewwds_4_tfresidentpackagemodules = AV13TFResidentPackageModules;
         AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel = AV14TFResidentPackageModules_Sel;
         AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel = AV15TFResidentPackageDefault_Sel;
         AV47Udparg7 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41Trn_residentpackagewwds_1_filterfulltext ,
                                              AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel ,
                                              AV42Trn_residentpackagewwds_2_tfresidentpackagename ,
                                              AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel ,
                                              AV44Trn_residentpackagewwds_4_tfresidentpackagemodules ,
                                              AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel ,
                                              A531ResidentPackageName ,
                                              A532ResidentPackageModules ,
                                              A533ResidentPackageDefault ,
                                              A528SG_LocationId ,
                                              AV47Udparg7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Trn_residentpackagewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext), "%", "");
         lV41Trn_residentpackagewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext), "%", "");
         lV42Trn_residentpackagewwds_2_tfresidentpackagename = StringUtil.Concat( StringUtil.RTrim( AV42Trn_residentpackagewwds_2_tfresidentpackagename), "%", "");
         lV44Trn_residentpackagewwds_4_tfresidentpackagemodules = StringUtil.Concat( StringUtil.RTrim( AV44Trn_residentpackagewwds_4_tfresidentpackagemodules), "%", "");
         /* Using cursor P00B53 */
         pr_default.execute(1, new Object[] {AV47Udparg7, lV41Trn_residentpackagewwds_1_filterfulltext, lV41Trn_residentpackagewwds_1_filterfulltext, lV42Trn_residentpackagewwds_2_tfresidentpackagename, AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, lV44Trn_residentpackagewwds_4_tfresidentpackagemodules, AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKB54 = false;
            A528SG_LocationId = P00B53_A528SG_LocationId[0];
            A532ResidentPackageModules = P00B53_A532ResidentPackageModules[0];
            A533ResidentPackageDefault = P00B53_A533ResidentPackageDefault[0];
            A531ResidentPackageName = P00B53_A531ResidentPackageName[0];
            A527ResidentPackageId = P00B53_A527ResidentPackageId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00B53_A532ResidentPackageModules[0], A532ResidentPackageModules) == 0 ) )
            {
               BRKB54 = false;
               A527ResidentPackageId = P00B53_A527ResidentPackageId[0];
               AV26count = (long)(AV26count+1);
               BRKB54 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A532ResidentPackageModules)) ? "<#Empty#>" : A532ResidentPackageModules);
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
            if ( ! BRKB54 )
            {
               BRKB54 = true;
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
         AV11TFResidentPackageName = "";
         AV12TFResidentPackageName_Sel = "";
         AV13TFResidentPackageModules = "";
         AV14TFResidentPackageModules_Sel = "";
         AV41Trn_residentpackagewwds_1_filterfulltext = "";
         AV42Trn_residentpackagewwds_2_tfresidentpackagename = "";
         AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel = "";
         AV44Trn_residentpackagewwds_4_tfresidentpackagemodules = "";
         AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel = "";
         AV47Udparg7 = Guid.Empty;
         lV41Trn_residentpackagewwds_1_filterfulltext = "";
         lV42Trn_residentpackagewwds_2_tfresidentpackagename = "";
         lV44Trn_residentpackagewwds_4_tfresidentpackagemodules = "";
         A531ResidentPackageName = "";
         A532ResidentPackageModules = "";
         A528SG_LocationId = Guid.Empty;
         P00B52_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00B52_A531ResidentPackageName = new string[] {""} ;
         P00B52_A533ResidentPackageDefault = new bool[] {false} ;
         P00B52_A532ResidentPackageModules = new string[] {""} ;
         P00B52_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         A527ResidentPackageId = Guid.Empty;
         AV21Option = "";
         P00B53_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00B53_A532ResidentPackageModules = new string[] {""} ;
         P00B53_A533ResidentPackageDefault = new bool[] {false} ;
         P00B53_A531ResidentPackageName = new string[] {""} ;
         P00B53_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackagewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00B52_A528SG_LocationId, P00B52_A531ResidentPackageName, P00B52_A533ResidentPackageDefault, P00B52_A532ResidentPackageModules, P00B52_A527ResidentPackageId
               }
               , new Object[] {
               P00B53_A528SG_LocationId, P00B53_A532ResidentPackageModules, P00B53_A533ResidentPackageDefault, P00B53_A531ResidentPackageName, P00B53_A527ResidentPackageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV15TFResidentPackageDefault_Sel ;
      private short AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel ;
      private int AV39GXV1 ;
      private long AV26count ;
      private bool returnInSub ;
      private bool A533ResidentPackageDefault ;
      private bool BRKB52 ;
      private bool BRKB54 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string A532ResidentPackageModules ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV11TFResidentPackageName ;
      private string AV12TFResidentPackageName_Sel ;
      private string AV13TFResidentPackageModules ;
      private string AV14TFResidentPackageModules_Sel ;
      private string AV41Trn_residentpackagewwds_1_filterfulltext ;
      private string AV42Trn_residentpackagewwds_2_tfresidentpackagename ;
      private string AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel ;
      private string AV44Trn_residentpackagewwds_4_tfresidentpackagemodules ;
      private string AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel ;
      private string lV41Trn_residentpackagewwds_1_filterfulltext ;
      private string lV42Trn_residentpackagewwds_2_tfresidentpackagename ;
      private string lV44Trn_residentpackagewwds_4_tfresidentpackagemodules ;
      private string A531ResidentPackageName ;
      private string AV21Option ;
      private Guid AV47Udparg7 ;
      private Guid A528SG_LocationId ;
      private Guid A527ResidentPackageId ;
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
      private Guid[] P00B52_A528SG_LocationId ;
      private string[] P00B52_A531ResidentPackageName ;
      private bool[] P00B52_A533ResidentPackageDefault ;
      private string[] P00B52_A532ResidentPackageModules ;
      private Guid[] P00B52_A527ResidentPackageId ;
      private Guid[] P00B53_A528SG_LocationId ;
      private string[] P00B53_A532ResidentPackageModules ;
      private bool[] P00B53_A533ResidentPackageDefault ;
      private string[] P00B53_A531ResidentPackageName ;
      private Guid[] P00B53_A527ResidentPackageId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_residentpackagewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B52( IGxContext context ,
                                             string AV41Trn_residentpackagewwds_1_filterfulltext ,
                                             string AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel ,
                                             string AV42Trn_residentpackagewwds_2_tfresidentpackagename ,
                                             string AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel ,
                                             string AV44Trn_residentpackagewwds_4_tfresidentpackagemodules ,
                                             short AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel ,
                                             string A531ResidentPackageName ,
                                             string A532ResidentPackageModules ,
                                             bool A533ResidentPackageDefault ,
                                             Guid A528SG_LocationId ,
                                             Guid AV47Udparg7 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SG_LocationId, ResidentPackageName, ResidentPackageDefault, ResidentPackageModules, ResidentPackageId FROM Trn_ResidentPackage";
         AddWhere(sWhereString, "(SG_LocationId = :AV47Udparg7)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(ResidentPackageName) like '%' || LOWER(:lV41Trn_residentpackagewwds_1_filterfulltext)) or ( LOWER(ResidentPackageModules) like '%' || LOWER(:lV41Trn_residentpackagewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_residentpackagewwds_2_tfresidentpackagename)) ) )
         {
            AddWhere(sWhereString, "(ResidentPackageName like :lV42Trn_residentpackagewwds_2_tfresidentpackagename)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel)) && ! ( StringUtil.StrCmp(AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ResidentPackageName = ( :AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ResidentPackageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_residentpackagewwds_4_tfresidentpackagemodules)) ) )
         {
            AddWhere(sWhereString, "(ResidentPackageModules like :lV44Trn_residentpackagewwds_4_tfresidentpackagemodules)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel)) && ! ( StringUtil.StrCmp(AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ResidentPackageModules = ( :AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ResidentPackageModules))=0))");
         }
         if ( AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel == 1 )
         {
            AddWhere(sWhereString, "(ResidentPackageDefault = TRUE)");
         }
         if ( AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel == 2 )
         {
            AddWhere(sWhereString, "(ResidentPackageDefault = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResidentPackageName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00B53( IGxContext context ,
                                             string AV41Trn_residentpackagewwds_1_filterfulltext ,
                                             string AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel ,
                                             string AV42Trn_residentpackagewwds_2_tfresidentpackagename ,
                                             string AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel ,
                                             string AV44Trn_residentpackagewwds_4_tfresidentpackagemodules ,
                                             short AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel ,
                                             string A531ResidentPackageName ,
                                             string A532ResidentPackageModules ,
                                             bool A533ResidentPackageDefault ,
                                             Guid A528SG_LocationId ,
                                             Guid AV47Udparg7 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SG_LocationId, ResidentPackageModules, ResidentPackageDefault, ResidentPackageName, ResidentPackageId FROM Trn_ResidentPackage";
         AddWhere(sWhereString, "(SG_LocationId = :AV47Udparg7)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_residentpackagewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(ResidentPackageName) like '%' || LOWER(:lV41Trn_residentpackagewwds_1_filterfulltext)) or ( LOWER(ResidentPackageModules) like '%' || LOWER(:lV41Trn_residentpackagewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_residentpackagewwds_2_tfresidentpackagename)) ) )
         {
            AddWhere(sWhereString, "(ResidentPackageName like :lV42Trn_residentpackagewwds_2_tfresidentpackagename)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel)) && ! ( StringUtil.StrCmp(AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ResidentPackageName = ( :AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ResidentPackageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_residentpackagewwds_4_tfresidentpackagemodules)) ) )
         {
            AddWhere(sWhereString, "(ResidentPackageModules like :lV44Trn_residentpackagewwds_4_tfresidentpackagemodules)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel)) && ! ( StringUtil.StrCmp(AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ResidentPackageModules = ( :AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ResidentPackageModules))=0))");
         }
         if ( AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel == 1 )
         {
            AddWhere(sWhereString, "(ResidentPackageDefault = TRUE)");
         }
         if ( AV46Trn_residentpackagewwds_6_tfresidentpackagedefault_sel == 2 )
         {
            AddWhere(sWhereString, "(ResidentPackageDefault = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResidentPackageModules";
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
                     return conditional_P00B52(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (Guid)dynConstraints[9] , (Guid)dynConstraints[10] );
               case 1 :
                     return conditional_P00B53(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (Guid)dynConstraints[9] , (Guid)dynConstraints[10] );
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
          Object[] prmP00B52;
          prmP00B52 = new Object[] {
          new ParDef("AV47Udparg7",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV41Trn_residentpackagewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_residentpackagewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_residentpackagewwds_2_tfresidentpackagename",GXType.VarChar,100,0) ,
          new ParDef("AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_residentpackagewwds_4_tfresidentpackagemodules",GXType.VarChar,200,0) ,
          new ParDef("AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00B53;
          prmP00B53 = new Object[] {
          new ParDef("AV47Udparg7",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV41Trn_residentpackagewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_residentpackagewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trn_residentpackagewwds_2_tfresidentpackagename",GXType.VarChar,100,0) ,
          new ParDef("AV43Trn_residentpackagewwds_3_tfresidentpackagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_residentpackagewwds_4_tfresidentpackagemodules",GXType.VarChar,200,0) ,
          new ParDef("AV45Trn_residentpackagewwds_5_tfresidentpackagemodules_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B53", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B53,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
