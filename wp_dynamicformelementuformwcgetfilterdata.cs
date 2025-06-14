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
   public class wp_dynamicformelementuformwcgetfilterdata : GXProcedure
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
            return "wp_dynamicform_Services_Execute" ;
         }

      }

      public wp_dynamicformelementuformwcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_dynamicformelementuformwcgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV32Session.Get("WP_DynamicFormElementUFormWCGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WP_DynamicFormElementUFormWCGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WP_DynamicFormElementUFormWCGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV11TFWWPFormTitle = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV12TFWWPFormTitle_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV15TFWWPFormDate = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFWWPFormDate_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV17TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV19TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV46WWPFormType = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV47WWPFormIsForDynamicValidations = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormTitle = AV21SearchTxt;
         AV12TFWWPFormTitle_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A206WWPFormId ,
                                              AV48GeneralDynamicFormids ,
                                              AV12TFWWPFormTitle_Sel ,
                                              AV11TFWWPFormTitle ,
                                              AV15TFWWPFormDate ,
                                              AV16TFWWPFormDate_To ,
                                              AV17TFWWPFormVersionNumber ,
                                              AV18TFWWPFormVersionNumber_To ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV43FilterFullText ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV19TFWWPFormLatestVersionNumber ,
                                              AV20TFWWPFormLatestVersionNumber_To ,
                                              AV46WWPFormType ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV11TFWWPFormTitle), "%", "");
         /* Using cursor P00DI2 */
         pr_default.execute(0, new Object[] {AV46WWPFormType, lV11TFWWPFormTitle, AV12TFWWPFormTitle_Sel, AV15TFWWPFormDate, AV16TFWWPFormDate_To, AV17TFWWPFormVersionNumber, AV18TFWWPFormVersionNumber_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDI2 = false;
            A240WWPFormType = P00DI2_A240WWPFormType[0];
            A209WWPFormTitle = P00DI2_A209WWPFormTitle[0];
            A231WWPFormDate = P00DI2_A231WWPFormDate[0];
            A207WWPFormVersionNumber = P00DI2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P00DI2_A206WWPFormId[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV19TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV19TFWWPFormLatestVersionNumber ) ) )
               {
                  if ( (0==AV20TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV20TFWWPFormLatestVersionNumber_To ) ) )
                  {
                     AV31count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( P00DI2_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00DI2_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
                     {
                        BRKDI2 = false;
                        A207WWPFormVersionNumber = P00DI2_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00DI2_A206WWPFormId[0];
                        if ( (AV48GeneralDynamicFormids.IndexOf(A206WWPFormId)>0) )
                        {
                           AV31count = (long)(AV31count+1);
                        }
                        BRKDI2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV22SkipItems) )
                     {
                        AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
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
                  }
               }
            }
            if ( ! BRKDI2 )
            {
               BRKDI2 = true;
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
         AV11TFWWPFormTitle = "";
         AV12TFWWPFormTitle_Sel = "";
         AV15TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV16TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         lV11TFWWPFormTitle = "";
         AV48GeneralDynamicFormids = new GxSimpleCollection<short>();
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         P00DI2_A240WWPFormType = new short[1] ;
         P00DI2_A209WWPFormTitle = new string[] {""} ;
         P00DI2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00DI2_A207WWPFormVersionNumber = new short[1] ;
         P00DI2_A206WWPFormId = new short[1] ;
         AV26Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformelementuformwcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DI2_A240WWPFormType, P00DI2_A209WWPFormTitle, P00DI2_A231WWPFormDate, P00DI2_A207WWPFormVersionNumber, P00DI2_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV17TFWWPFormVersionNumber ;
      private short AV18TFWWPFormVersionNumber_To ;
      private short AV19TFWWPFormLatestVersionNumber ;
      private short AV20TFWWPFormLatestVersionNumber_To ;
      private short AV46WWPFormType ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A240WWPFormType ;
      private short GXt_int1 ;
      private int AV51GXV1 ;
      private long AV31count ;
      private DateTime AV15TFWWPFormDate ;
      private DateTime AV16TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV47WWPFormIsForDynamicValidations ;
      private bool BRKDI2 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV11TFWWPFormTitle ;
      private string AV12TFWWPFormTitle_Sel ;
      private string lV11TFWWPFormTitle ;
      private string A209WWPFormTitle ;
      private string AV26Option ;
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
      private GxSimpleCollection<short> AV48GeneralDynamicFormids ;
      private IDataStoreProvider pr_default ;
      private short[] P00DI2_A240WWPFormType ;
      private string[] P00DI2_A209WWPFormTitle ;
      private DateTime[] P00DI2_A231WWPFormDate ;
      private short[] P00DI2_A207WWPFormVersionNumber ;
      private short[] P00DI2_A206WWPFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_dynamicformelementuformwcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DI2( IGxContext context ,
                                             short A206WWPFormId ,
                                             GxSimpleCollection<short> AV48GeneralDynamicFormids ,
                                             string AV12TFWWPFormTitle_Sel ,
                                             string AV11TFWWPFormTitle ,
                                             DateTime AV15TFWWPFormDate ,
                                             DateTime AV16TFWWPFormDate_To ,
                                             short AV17TFWWPFormVersionNumber ,
                                             short AV18TFWWPFormVersionNumber_To ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             string AV43FilterFullText ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV19TFWWPFormLatestVersionNumber ,
                                             short AV20TFWWPFormLatestVersionNumber_To ,
                                             short AV46WWPFormType ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPFormType, WWPFormTitle, WWPFormDate, WWPFormVersionNumber, WWPFormId FROM WWP_Form";
         AddWhere(sWhereString, "(WWPFormType = :AV46WWPFormType)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48GeneralDynamicFormids, "WWPFormId IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle like :lV11TFWWPFormTitle)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV12TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle = ( :AV12TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV15TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(WWPFormDate >= :AV15TFWWPFormDate)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV16TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(WWPFormDate <= :AV16TFWWPFormDate_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV17TFWWPFormVersionNumber) )
         {
            AddWhere(sWhereString, "(WWPFormVersionNumber >= :AV17TFWWPFormVersionNumber)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV18TFWWPFormVersionNumber_To) )
         {
            AddWhere(sWhereString, "(WWPFormVersionNumber <= :AV18TFWWPFormVersionNumber_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormType, WWPFormTitle";
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
               case 0 :
                     return conditional_P00DI2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmP00DI2;
          prmP00DI2 = new Object[] {
          new ParDef("AV46WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV11TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV12TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV15TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV16TFWWPFormDate_To",GXType.DateTime,8,5) ,
          new ParDef("AV17TFWWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV18TFWWPFormVersionNumber_To",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
