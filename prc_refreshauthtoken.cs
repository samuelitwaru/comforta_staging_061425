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
   public class prc_refreshauthtoken : GXProcedure
   {
      public prc_refreshauthtoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_refreshauthtoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_refreshToken ,
                           out string aP1_response )
      {
         this.AV21refreshToken = aP0_refreshToken;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV14response;
      }

      public string executeUdp( string aP0_refreshToken )
      {
         execute(aP0_refreshToken, out aP1_response);
         return AV14response ;
      }

      public void executeSubmit( string aP0_refreshToken ,
                                 out string aP1_response )
      {
         this.AV21refreshToken = aP0_refreshToken;
         this.AV14response = "" ;
         SubmitImpl();
         aP1_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9clientId = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getclientid();
         if ( StringUtil.StrCmp(AV11HttpRequest.ServerHost, context.GetMessage( "localhost", "")) == 0 )
         {
            AV8baseUrl = context.GetMessage( "http://localhost:8082/Comforta_version2DevelopmentNETPostgreSQL", "");
         }
         else
         {
            AV8baseUrl = context.GetMessage( "https://staging.comforta.yukon.software", "");
         }
         AV17url = AV8baseUrl + context.GetMessage( "/oauth/access_token", "");
         AV10httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV10httpclient.AddVariable(context.GetMessage( "client_id", ""), AV9clientId);
         AV10httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "refresh_token", ""));
         AV10httpclient.AddVariable(context.GetMessage( "scope", ""), context.GetMessage( "gam_user_data+gam_user_additional_data+gam_session_initial_prop+gam_user_roles", ""));
         AV10httpclient.AddVariable(context.GetMessage( "refresh_token", ""), AV21refreshToken);
         AV10httpclient.Execute(context.GetMessage( "POST", ""), AV17url);
         AV15result = AV10httpclient.ToString();
         if ( AV10httpclient.StatusCode != 200 )
         {
            AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
            AV19ErrorResponse.gxTpr_Message = AV10httpclient.ErrDescription;
            AV19ErrorResponse.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(AV10httpclient.StatusCode), 10, 2));
            AV12LoginResponse.gxTpr_Error = AV19ErrorResponse;
            AV14response = AV12LoginResponse.ToJSonString(false, true);
            new prc_logtofile(context ).execute(  context.GetMessage( "Error: ", "")+AV19ErrorResponse.ToJSonString(false, true)) ;
         }
         else
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "API Result: ", "")+AV15result) ;
            AV12LoginResponse.FromJSonString(AV15result, null);
            AV14response = AV12LoginResponse.ToJSonString(false, true);
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
         AV14response = "";
         AV9clientId = "";
         AV11HttpRequest = new GxHttpRequest( context);
         AV8baseUrl = "";
         AV17url = "";
         AV10httpclient = new GxHttpClient( context);
         AV15result = "";
         AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
         AV12LoginResponse = new SdtSDT_LoginResidentResponse(context);
         /* GeneXus formulas. */
      }

      private string AV21refreshToken ;
      private string AV14response ;
      private string AV15result ;
      private string AV9clientId ;
      private string AV8baseUrl ;
      private string AV17url ;
      private GxHttpClient AV10httpclient ;
      private GxHttpRequest AV11HttpRequest ;
      private SdtSDT_ErrorResponse AV19ErrorResponse ;
      private SdtSDT_LoginResidentResponse AV12LoginResponse ;
      private string aP1_response ;
   }

}
