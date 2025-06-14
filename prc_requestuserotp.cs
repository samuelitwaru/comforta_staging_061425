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
   public class prc_requestuserotp : GXProcedure
   {
      public prc_requestuserotp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_requestuserotp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_username ,
                           out string aP1_response )
      {
         this.AV22username = aP0_username;
         this.AV18response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV18response;
      }

      public string executeUdp( string aP0_username )
      {
         execute(aP0_username, out aP1_response);
         return AV18response ;
      }

      public void executeSubmit( string aP0_username ,
                                 out string aP1_response )
      {
         this.AV22username = aP0_username;
         this.AV18response = "" ;
         SubmitImpl();
         aP1_response=this.AV18response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV10clientId = AV13GAMApplication.gxTpr_Clientid;
         AV9client_secret = AV13GAMApplication.gxTpr_Clientsecret;
         if ( StringUtil.StrCmp(AV15HttpRequest.ServerHost, context.GetMessage( "localhost", "")) == 0 )
         {
            AV8baseUrl = context.GetMessage( "http://localhost:8082/Comforta_version2DevelopmentNETPostgreSQL", "");
         }
         else
         {
            AV8baseUrl = context.GetMessage( "https://staging.comforta.yukon.software", "");
         }
         AV21url = AV8baseUrl + context.GetMessage( "/oauth/gam/v2.0/access_token", "");
         AV14httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV14httpclient.AddVariable(context.GetMessage( "client_id", ""), AV10clientId);
         AV14httpclient.AddVariable(context.GetMessage( "client_secret", ""), AV9client_secret);
         AV14httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "password", ""));
         AV14httpclient.AddVariable(context.GetMessage( "username", ""), AV22username);
         AV14httpclient.AddVariable(context.GetMessage( "authentication_type_name", ""), context.GetMessage( "otp", ""));
         AV14httpclient.AddVariable(context.GetMessage( "otp_step", ""), "1");
         AV14httpclient.Execute(context.GetMessage( "POST", ""), AV21url);
         AV18response = AV14httpclient.ToString();
         if ( AV14httpclient.StatusCode != 200 )
         {
         }
         else
         {
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
         AV18response = "";
         AV13GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV10clientId = "";
         AV9client_secret = "";
         AV15HttpRequest = new GxHttpRequest( context);
         AV8baseUrl = "";
         AV21url = "";
         AV14httpclient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private string AV18response ;
      private string AV22username ;
      private string AV10clientId ;
      private string AV9client_secret ;
      private string AV8baseUrl ;
      private string AV21url ;
      private GxHttpClient AV14httpclient ;
      private GxHttpRequest AV15HttpRequest ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV13GAMApplication ;
      private string aP1_response ;
   }

}
