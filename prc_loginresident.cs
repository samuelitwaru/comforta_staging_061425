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
namespace GeneXus.Programs {
   public class prc_loginresident : GXProcedure
   {
      public prc_loginresident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loginresident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_secretKey ,
                           out string aP1_response )
      {
         this.AV13secretKey = aP0_secretKey;
         this.AV16response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV16response;
      }

      public string executeUdp( string aP0_secretKey )
      {
         execute(aP0_secretKey, out aP1_response);
         return AV16response ;
      }

      public void executeSubmit( string aP0_secretKey ,
                                 out string aP1_response )
      {
         this.AV13secretKey = aP0_secretKey;
         this.AV16response = "" ;
         SubmitImpl();
         aP1_response=this.AV16response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV9clientId = AV21GAMApplication.gxTpr_Clientid;
         AV8baseUrl = AV21GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV14url = AV8baseUrl + context.GetMessage( "oauth/access_token", "");
         new prc_decodeqrcode(context ).execute(  AV13secretKey, out  AV15username, out  AV12password) ;
         AV10httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV10httpclient.AddVariable(context.GetMessage( "client_id", ""), AV9clientId);
         AV10httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "password", ""));
         AV10httpclient.AddVariable(context.GetMessage( "scope", ""), context.GetMessage( "gam_user_data", ""));
         AV10httpclient.AddVariable(context.GetMessage( "username", ""), AV15username);
         AV10httpclient.AddVariable(context.GetMessage( "password", ""), AV12password);
         AV10httpclient.Execute(context.GetMessage( "POST", ""), AV14url);
         AV17result = AV10httpclient.ToString();
         if ( AV10httpclient.StatusCode != 200 )
         {
            AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
            AV19ErrorResponse.gxTpr_Message = AV10httpclient.ErrDescription;
            AV19ErrorResponse.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(AV10httpclient.StatusCode), 10, 2));
            AV18LoginResponse.gxTpr_Error = AV19ErrorResponse;
            AV16response = AV18LoginResponse.ToJSonString(false, true);
            new prc_logtofile(context ).execute(  context.GetMessage( "Error: ", "")+AV19ErrorResponse.ToJSonString(false, true)) ;
         }
         else
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "API Result: ", "")+AV17result) ;
            AV18LoginResponse.FromJSonString(AV17result, null);
            AV16response = AV18LoginResponse.ToJSonString(false, true);
         }
         cleanup();
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
         AV16response = "";
         AV21GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV9clientId = "";
         AV8baseUrl = "";
         AV14url = "";
         AV15username = "";
         AV12password = "";
         AV10httpclient = new GxHttpClient( context);
         AV17result = "";
         AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
         AV18LoginResponse = new SdtSDT_LoginResidentResponse(context);
         /* GeneXus formulas. */
      }

      private string AV13secretKey ;
      private string AV16response ;
      private string AV17result ;
      private string AV9clientId ;
      private string AV8baseUrl ;
      private string AV14url ;
      private string AV15username ;
      private string AV12password ;
      private GxHttpClient AV10httpclient ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV21GAMApplication ;
      private SdtSDT_ErrorResponse AV19ErrorResponse ;
      private SdtSDT_LoginResidentResponse AV18LoginResponse ;
      private string aP1_response ;
   }

}
