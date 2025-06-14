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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_dynamiccombobox_wcloaddvcombo : GXProcedure
   {
      public wwp_df_dynamiccombobox_wcloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_dynamiccombobox_wcloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_SessionId ,
                           short aP2_Cond_WWPFormElementId ,
                           string aP3_SearchTxtParms ,
                           out string aP4_Combo_DataJson )
      {
         this.AV18ComboName = aP0_ComboName;
         this.AV19Cond_SessionId = aP1_Cond_SessionId;
         this.AV20Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV31SearchTxtParms = aP3_SearchTxtParms;
         this.AV17Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP4_Combo_DataJson=this.AV17Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_SessionId ,
                                short aP2_Cond_WWPFormElementId ,
                                string aP3_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_SessionId, aP2_Cond_WWPFormElementId, aP3_SearchTxtParms, out aP4_Combo_DataJson);
         return AV17Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_SessionId ,
                                 short aP2_Cond_WWPFormElementId ,
                                 string aP3_SearchTxtParms ,
                                 out string aP4_Combo_DataJson )
      {
         this.AV18ComboName = aP0_ComboName;
         this.AV19Cond_SessionId = aP1_Cond_SessionId;
         this.AV20Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV31SearchTxtParms = aP3_SearchTxtParms;
         this.AV17Combo_DataJson = "" ;
         SubmitImpl();
         aP4_Combo_DataJson=this.AV17Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWP_FormInstance1 = AV13WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV19Cond_SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV13WWPFormInstance = GXt_SdtWWP_FormInstance1;
         AV21Cond_WWPFormId = AV13WWPFormInstance.gxTpr_Wwpformid;
         AV22Cond_WWPFormVersionNumber = AV13WWPFormInstance.gxTpr_Wwpformversionnumber;
         /* Using cursor P004R2 */
         pr_default.execute(0, new Object[] {AV21Cond_WWPFormId, AV22Cond_WWPFormVersionNumber, AV20Cond_WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = P004R2_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = P004R2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004R2_A206WWPFormId[0];
            A236WWPFormElementMetadata = P004R2_A236WWPFormElementMetadata[0];
            AV35WWP_DF_CharMetadata.FromJSonString(A236WWPFormElementMetadata, null);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV36WWPContext) ;
         AV27MaxItems = 10;
         AV28PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV30SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV28PageIndex*AV27MaxItems);
         if ( StringUtil.StrCmp(AV18ComboName, "Data") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DATA' */
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
         /* 'LOADCOMBOITEMS_DATA' Routine */
         returnInSub = false;
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV10GAMErrors);
         AV9Token = AV8GAMSession.gxTpr_Token;
         AV23HTTPClient.AddHeader("Authorization", "OAuth "+AV9Token);
         AV23HTTPClient.AddHeader("Content-type", "application/json");
         AV14BaseUrl = StringUtil.StringReplace( AV24HTTPRequest.BaseURL, "//", "");
         AV14BaseUrl = StringUtil.Substring( AV14BaseUrl, StringUtil.StringSearch( AV14BaseUrl, "/", 1)+1, -1);
         AV14BaseUrl = StringUtil.Substring( AV14BaseUrl, 1, StringUtil.StringSearch( AV14BaseUrl, "/", 1));
         AV23HTTPClient.Host = AV24HTTPRequest.ServerHost;
         AV23HTTPClient.Port = AV24HTTPRequest.ServerPort;
         AV23HTTPClient.Secure = AV24HTTPRequest.Secure;
         AV23HTTPClient.BaseURL = AV14BaseUrl+"rest";
         AV33ServiceName = StringUtil.Lower( AV35WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice);
         AV33ServiceName = StringUtil.Upper( StringUtil.Substring( AV33ServiceName, 1, 1)) + StringUtil.Substring( AV33ServiceName, 2, -1);
         AV11Properties.Set("WWPFormInstanceJson", AV13WWPFormInstance.ToJSonString(true, true));
         AV11Properties.Set("SessionId", StringUtil.Str( (decimal)(AV19Cond_SessionId), 4, 0));
         AV11Properties.Set("WWPFormElementId", StringUtil.Str( (decimal)(AV20Cond_WWPFormElementId), 4, 0));
         AV11Properties.Set("MaxItems", StringUtil.Str( (decimal)(AV27MaxItems), 6, 0));
         AV11Properties.Set("PageIndex", StringUtil.Str( (decimal)(AV28PageIndex), 4, 0));
         AV11Properties.Set("SearchTxt", AV30SearchTxt);
         AV23HTTPClient.AddString(AV11Properties.ToJSonString());
         AV23HTTPClient.Execute("POST", AV33ServiceName);
         if ( AV23HTTPClient.StatusCode == 200 )
         {
            AV29Result = AV23HTTPClient.ToString();
            AV25i = (short)(StringUtil.StringSearch( AV29Result, ":", 1));
            if ( AV25i > 0 )
            {
               AV29Result = "{\"Result\"" + StringUtil.Substring( AV29Result, AV25i, -1);
               AV12SDTResult.FromJSonString(AV29Result, null);
               AV29Result = AV12SDTResult.gxTpr_Result;
            }
            AV15Combo_Data.FromJSonString(AV29Result, null);
            new WorkWithPlus.workwithplus_web.wwp_extendedcombopagedata(context ).execute( ref  AV15Combo_Data,  AV34SkipItems,  AV27MaxItems) ;
            AV17Combo_DataJson = AV15Combo_Data.ToJSonString(false);
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
         AV17Combo_DataJson = "";
         AV13WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         P004R2_A210WWPFormElementId = new short[1] ;
         P004R2_A207WWPFormVersionNumber = new short[1] ;
         P004R2_A206WWPFormId = new short[1] ;
         P004R2_A236WWPFormElementMetadata = new string[] {""} ;
         A236WWPFormElementMetadata = "";
         AV35WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV36WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30SearchTxt = "";
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9Token = "";
         AV23HTTPClient = new GxHttpClient( context);
         AV14BaseUrl = "";
         AV24HTTPRequest = new GxHttpRequest( context);
         AV33ServiceName = "";
         AV11Properties = new GXProperties();
         AV29Result = "";
         AV12SDTResult = new WorkWithPlus.workwithplus_web.SdtWWP_SDTResult(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_dynamiccombobox_wcloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004R2_A210WWPFormElementId, P004R2_A207WWPFormVersionNumber, P004R2_A206WWPFormId, P004R2_A236WWPFormElementMetadata
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19Cond_SessionId ;
      private short AV20Cond_WWPFormElementId ;
      private short AV21Cond_WWPFormId ;
      private short AV22Cond_WWPFormVersionNumber ;
      private short A210WWPFormElementId ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short AV28PageIndex ;
      private short AV34SkipItems ;
      private short AV25i ;
      private int AV27MaxItems ;
      private bool returnInSub ;
      private string AV17Combo_DataJson ;
      private string A236WWPFormElementMetadata ;
      private string AV18ComboName ;
      private string AV31SearchTxtParms ;
      private string AV30SearchTxt ;
      private string AV9Token ;
      private string AV14BaseUrl ;
      private string AV33ServiceName ;
      private string AV29Result ;
      private GxHttpClient AV23HTTPClient ;
      private GxHttpRequest AV24HTTPRequest ;
      private GXProperties AV11Properties ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV13WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private IDataStoreProvider pr_default ;
      private short[] P004R2_A210WWPFormElementId ;
      private short[] P004R2_A207WWPFormVersionNumber ;
      private short[] P004R2_A206WWPFormId ;
      private string[] P004R2_A236WWPFormElementMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV35WWP_DF_CharMetadata ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV36WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV8GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtWWP_SDTResult AV12SDTResult ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP4_Combo_DataJson ;
   }

   public class wwp_df_dynamiccombobox_wcloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP004R2;
          prmP004R2 = new Object[] {
          new ParDef("AV21Cond_WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV22Cond_WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV20Cond_WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004R2", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV21Cond_WWPFormId and WWPFormVersionNumber = :AV22Cond_WWPFormVersionNumber and WWPFormElementId = :AV20Cond_WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
