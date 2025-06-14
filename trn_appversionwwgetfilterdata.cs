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
   public class trn_appversionwwgetfilterdata : GXProcedure
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
            return "trn_appversionww_Services_Execute" ;
         }

      }

      public trn_appversionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversionwwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_APPVERSIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAPPVERSIONNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("Trn_AppVersionWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_AppVersionWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("Trn_AppVersionWWGridState"), null, "", "");
         }
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV37GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFAPPVERSIONNAME") == 0 )
            {
               AV11TFAppVersionName = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFAPPVERSIONNAME_SEL") == 0 )
            {
               AV12TFAppVersionName_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFISACTIVE_SEL") == 0 )
            {
               AV13TFIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAPPVERSIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFAppVersionName = AV14SearchTxt;
         AV12TFAppVersionName_Sel = "";
         AV39Trn_appversionwwds_1_filterfulltext = AV36FilterFullText;
         AV40Trn_appversionwwds_2_tfappversionname = AV11TFAppVersionName;
         AV41Trn_appversionwwds_3_tfappversionname_sel = AV12TFAppVersionName_Sel;
         AV42Trn_appversionwwds_4_tfisactive_sel = AV13TFIsActive_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39Trn_appversionwwds_1_filterfulltext ,
                                              AV41Trn_appversionwwds_3_tfappversionname_sel ,
                                              AV40Trn_appversionwwds_2_tfappversionname ,
                                              AV42Trn_appversionwwds_4_tfisactive_sel ,
                                              A524AppVersionName ,
                                              A535IsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV39Trn_appversionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Trn_appversionwwds_1_filterfulltext), "%", "");
         lV40Trn_appversionwwds_2_tfappversionname = StringUtil.Concat( StringUtil.RTrim( AV40Trn_appversionwwds_2_tfappversionname), "%", "");
         /* Using cursor P00DQ2 */
         pr_default.execute(0, new Object[] {lV39Trn_appversionwwds_1_filterfulltext, lV40Trn_appversionwwds_2_tfappversionname, AV41Trn_appversionwwds_3_tfappversionname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDQ2 = false;
            A524AppVersionName = P00DQ2_A524AppVersionName[0];
            A535IsActive = P00DQ2_A535IsActive[0];
            A523AppVersionId = P00DQ2_A523AppVersionId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DQ2_A524AppVersionName[0], A524AppVersionName) == 0 ) )
            {
               BRKDQ2 = false;
               A523AppVersionId = P00DQ2_A523AppVersionId[0];
               AV24count = (long)(AV24count+1);
               BRKDQ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A524AppVersionName)) ? "<#Empty#>" : A524AppVersionName);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRKDQ2 )
            {
               BRKDQ2 = true;
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV28GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV11TFAppVersionName = "";
         AV12TFAppVersionName_Sel = "";
         AV39Trn_appversionwwds_1_filterfulltext = "";
         AV40Trn_appversionwwds_2_tfappversionname = "";
         AV41Trn_appversionwwds_3_tfappversionname_sel = "";
         lV39Trn_appversionwwds_1_filterfulltext = "";
         lV40Trn_appversionwwds_2_tfappversionname = "";
         A524AppVersionName = "";
         P00DQ2_A524AppVersionName = new string[] {""} ;
         P00DQ2_A535IsActive = new bool[] {false} ;
         P00DQ2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DQ2_A524AppVersionName, P00DQ2_A535IsActive, P00DQ2_A523AppVersionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV13TFIsActive_Sel ;
      private short AV42Trn_appversionwwds_4_tfisactive_sel ;
      private int AV37GXV1 ;
      private long AV24count ;
      private bool returnInSub ;
      private bool A535IsActive ;
      private bool BRKDQ2 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV11TFAppVersionName ;
      private string AV12TFAppVersionName_Sel ;
      private string AV39Trn_appversionwwds_1_filterfulltext ;
      private string AV40Trn_appversionwwds_2_tfappversionname ;
      private string AV41Trn_appversionwwds_3_tfappversionname_sel ;
      private string lV39Trn_appversionwwds_1_filterfulltext ;
      private string lV40Trn_appversionwwds_2_tfappversionname ;
      private string A524AppVersionName ;
      private string AV19Option ;
      private Guid A523AppVersionId ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV27GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00DQ2_A524AppVersionName ;
      private bool[] P00DQ2_A535IsActive ;
      private Guid[] P00DQ2_A523AppVersionId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_appversionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DQ2( IGxContext context ,
                                             string AV39Trn_appversionwwds_1_filterfulltext ,
                                             string AV41Trn_appversionwwds_3_tfappversionname_sel ,
                                             string AV40Trn_appversionwwds_2_tfappversionname ,
                                             short AV42Trn_appversionwwds_4_tfisactive_sel ,
                                             string A524AppVersionName ,
                                             bool A535IsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT AppVersionName, IsActive, AppVersionId FROM Trn_AppVersion";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Trn_appversionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AppVersionName) like '%' || LOWER(:lV39Trn_appversionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_appversionwwds_3_tfappversionname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_appversionwwds_2_tfappversionname)) ) )
         {
            AddWhere(sWhereString, "(AppVersionName like :lV40Trn_appversionwwds_2_tfappversionname)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_appversionwwds_3_tfappversionname_sel)) && ! ( StringUtil.StrCmp(AV41Trn_appversionwwds_3_tfappversionname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AppVersionName = ( :AV41Trn_appversionwwds_3_tfappversionname_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV41Trn_appversionwwds_3_tfappversionname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AppVersionName))=0))");
         }
         if ( AV42Trn_appversionwwds_4_tfisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(IsActive = TRUE)");
         }
         if ( AV42Trn_appversionwwds_4_tfisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(IsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AppVersionName";
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
                     return conditional_P00DQ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP00DQ2;
          prmP00DQ2 = new Object[] {
          new ParDef("lV39Trn_appversionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_appversionwwds_2_tfappversionname",GXType.VarChar,100,0) ,
          new ParDef("AV41Trn_appversionwwds_3_tfappversionname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
