using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_df_dynamicsuggest_wcloaddvcombo : GXProcedure
   {
      public wwp_df_dynamicsuggest_wcloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_dynamicsuggest_wcloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_SessionId ,
                           short aP2_Cond_WWPFormElementId ,
                           string aP3_SearchTxtParms ,
                           out string aP4_Combo_DataJson )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14Cond_SessionId = aP1_Cond_SessionId;
         this.AV15Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV19SearchTxtParms = aP3_SearchTxtParms;
         this.AV12Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP4_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_SessionId ,
                                short aP2_Cond_WWPFormElementId ,
                                string aP3_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_SessionId, aP2_Cond_WWPFormElementId, aP3_SearchTxtParms, out aP4_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_SessionId ,
                                 short aP2_Cond_WWPFormElementId ,
                                 string aP3_SearchTxtParms ,
                                 out string aP4_Combo_DataJson )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14Cond_SessionId = aP1_Cond_SessionId;
         this.AV15Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV19SearchTxtParms = aP3_SearchTxtParms;
         this.AV12Combo_DataJson = "" ;
         SubmitImpl();
         aP4_Combo_DataJson=this.AV12Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV21WWPContext) ;
         AV16MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV19SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms)) ? "" : StringUtil.Substring( AV19SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV17PageIndex*AV16MaxItems);
         if ( StringUtil.StrCmp(AV13ComboName, "Data") == 0 )
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
         AV24HTTPClient.AddHeader("Authorization", "OAuth "+AV9Token);
         AV24HTTPClient.AddHeader("Content-type", "application/json");
         AV23BaseUrl = StringUtil.StringReplace( AV25HTTPRequest.BaseURL, "//", "");
         AV23BaseUrl = StringUtil.Substring( AV23BaseUrl, StringUtil.StringSearch( AV23BaseUrl, "/", 1)+1, -1);
         AV23BaseUrl = StringUtil.Substring( AV23BaseUrl, 1, StringUtil.StringSearch( AV23BaseUrl, "/", 1));
         AV24HTTPClient.Host = AV25HTTPRequest.ServerHost;
         AV24HTTPClient.Port = AV25HTTPRequest.ServerPort;
         AV24HTTPClient.Secure = AV25HTTPRequest.Secure;
         AV24HTTPClient.BaseURL = AV23BaseUrl+"rest";
         AV29ServiceName = StringUtil.Lower( AV30WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice);
         AV29ServiceName = StringUtil.Upper( StringUtil.Substring( AV29ServiceName, 1, 1)) + StringUtil.Substring( AV29ServiceName, 2, -1);
         AV27Request = StringUtil.Format( context.GetMessage( "%1?Sessionid=%2&Wwpformelementid=%3&MaxItems=%4&PageIndex=%5&SearchTxt=%6", ""), AV29ServiceName, StringUtil.LTrimStr( (decimal)(AV14Cond_SessionId), 4, 0), StringUtil.LTrimStr( (decimal)(AV15Cond_WWPFormElementId), 4, 0), StringUtil.LTrimStr( (decimal)(AV16MaxItems), 6, 0), StringUtil.LTrimStr( (decimal)(AV17PageIndex), 4, 0), AV18SearchTxt, "", "", "");
         AV24HTTPClient.Execute("POST", AV27Request);
         if ( AV24HTTPClient.StatusCode == 200 )
         {
            AV28result = AV24HTTPClient.ToString();
            AV26i = (short)(StringUtil.StringSearch( AV28result, ":", 1));
            if ( AV26i > 0 )
            {
               AV28result = "{\"Result\"" + StringUtil.Substring( AV28result, AV26i, -1);
               AV22SDTResult.FromJSonString(AV28result, null);
               AV28result = AV22SDTResult.gxTpr_Result;
            }
            AV11Combo_Data.FromJSonString(AV28result, null);
            new WorkWithPlus.workwithplus_web.wwp_extendedcombopagedata(context ).execute( ref  AV11Combo_Data,  AV20SkipItems,  AV16MaxItems) ;
            AV11Combo_Data.Sort("Title");
            AV12Combo_DataJson = AV11Combo_Data.ToJSonString(false);
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
         AV12Combo_DataJson = "";
         AV21WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18SearchTxt = "";
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9Token = "";
         AV24HTTPClient = new GxHttpClient( context);
         AV23BaseUrl = "";
         AV25HTTPRequest = new GxHttpRequest( context);
         AV29ServiceName = "";
         AV30WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV27Request = "";
         AV28result = "";
         AV22SDTResult = new WorkWithPlus.workwithplus_web.SdtWWP_SDTResult(context);
         AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* GeneXus formulas. */
      }

      private short AV14Cond_SessionId ;
      private short AV15Cond_WWPFormElementId ;
      private short AV17PageIndex ;
      private short AV20SkipItems ;
      private short AV26i ;
      private int AV16MaxItems ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV13ComboName ;
      private string AV19SearchTxtParms ;
      private string AV18SearchTxt ;
      private string AV9Token ;
      private string AV23BaseUrl ;
      private string AV29ServiceName ;
      private string AV27Request ;
      private string AV28result ;
      private GxHttpClient AV24HTTPClient ;
      private GxHttpRequest AV25HTTPRequest ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV21WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV8GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrors ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV30WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_web.SdtWWP_SDTResult AV22SDTResult ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private string aP4_Combo_DataJson ;
   }

}
