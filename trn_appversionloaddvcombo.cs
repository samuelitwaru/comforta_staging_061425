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
   public class trn_appversionloaddvcombo : GXProcedure
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
            return "trn_appversion_Services_Execute" ;
         }

      }

      public trn_appversionloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversionloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_AppVersionId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AppVersionId = aP3_AppVersionId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_AppVersionId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AppVersionId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_AppVersionId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19AppVersionId = aP3_AppVersionId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV20SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? AV20SearchTxtParms : StringUtil.Substring( AV20SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "Trn_ThemeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TRN_THEMEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_TRN_THEMEID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A274Trn_ThemeName } ,
                                                 new int[]{
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00H52 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A274Trn_ThemeName = P00H52_A274Trn_ThemeName[0];
               A273Trn_ThemeId = P00H52_A273Trn_ThemeId[0];
               AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( A273Trn_ThemeId.ToString());
               AV15Combo_DataItem.gxTpr_Title = A274Trn_ThemeName;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00H53 */
                  pr_default.execute(1, new Object[] {AV19AppVersionId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A523AppVersionId = P00H53_A523AppVersionId[0];
                     A273Trn_ThemeId = P00H53_A273Trn_ThemeId[0];
                     A274Trn_ThemeName = P00H53_A274Trn_ThemeName[0];
                     A274Trn_ThemeName = P00H53_A274Trn_ThemeName[0];
                     AV21SelectedValue = ((Guid.Empty==A273Trn_ThemeId) ? "" : StringUtil.Trim( A273Trn_ThemeId.ToString()));
                     AV22SelectedText = A274Trn_ThemeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27Trn_ThemeId = StringUtil.StrToGuid( AV13SearchTxt);
                  /* Using cursor P00H54 */
                  pr_default.execute(2, new Object[] {AV27Trn_ThemeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A273Trn_ThemeId = P00H54_A273Trn_ThemeId[0];
                     A274Trn_ThemeName = P00H54_A274Trn_ThemeName[0];
                     AV22SelectedText = A274Trn_ThemeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
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
         AV21SelectedValue = "";
         AV22SelectedText = "";
         AV23Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         lV13SearchTxt = "";
         A274Trn_ThemeName = "";
         P00H52_A274Trn_ThemeName = new string[] {""} ;
         P00H52_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00H53_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00H53_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00H53_A274Trn_ThemeName = new string[] {""} ;
         A523AppVersionId = Guid.Empty;
         AV27Trn_ThemeId = Guid.Empty;
         P00H54_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00H54_A274Trn_ThemeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversionloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00H52_A274Trn_ThemeName, P00H52_A273Trn_ThemeId
               }
               , new Object[] {
               P00H53_A523AppVersionId, P00H53_A273Trn_ThemeId, P00H53_A274Trn_ThemeName
               }
               , new Object[] {
               P00H54_A273Trn_ThemeId, P00H54_A274Trn_ThemeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A274Trn_ThemeName ;
      private Guid AV19AppVersionId ;
      private Guid A273Trn_ThemeId ;
      private Guid A523AppVersionId ;
      private Guid AV27Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00H52_A274Trn_ThemeName ;
      private Guid[] P00H52_A273Trn_ThemeId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private Guid[] P00H53_A523AppVersionId ;
      private Guid[] P00H53_A273Trn_ThemeId ;
      private string[] P00H53_A274Trn_ThemeName ;
      private Guid[] P00H54_A273Trn_ThemeId ;
      private string[] P00H54_A274Trn_ThemeName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_appversionloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00H52( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A274Trn_ThemeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Trn_ThemeName, Trn_ThemeId";
         sFromString = " FROM Trn_Theme";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY Trn_ThemeName, Trn_ThemeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P00H52(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00H53;
          prmP00H53 = new Object[] {
          new ParDef("AV19AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H54;
          prmP00H54 = new Object[] {
          new ParDef("AV27Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H52;
          prmP00H52 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H52,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H53", "SELECT T1.AppVersionId, T1.Trn_ThemeId, T2.Trn_ThemeName FROM (Trn_AppVersion T1 INNER JOIN Trn_Theme T2 ON T2.Trn_ThemeId = T1.Trn_ThemeId) WHERE T1.AppVersionId = :AV19AppVersionId ORDER BY T1.AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H53,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H54", "SELECT Trn_ThemeId, Trn_ThemeName FROM Trn_Theme WHERE Trn_ThemeId = :AV27Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H54,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
