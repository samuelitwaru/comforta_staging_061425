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
   public class prc_loginresident2 : GXProcedure
   {
      public prc_loginresident2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loginresident2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_username ,
                           string aP1_password ,
                           out string aP2_response )
      {
         this.AV18username = aP0_username;
         this.AV13password = aP1_password;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV14response;
      }

      public string executeUdp( string aP0_username ,
                                string aP1_password )
      {
         execute(aP0_username, aP1_password, out aP2_response);
         return AV14response ;
      }

      public void executeSubmit( string aP0_username ,
                                 string aP1_password ,
                                 out string aP2_response )
      {
         this.AV18username = aP0_username;
         this.AV13password = aP1_password;
         this.AV14response = "" ;
         SubmitImpl();
         aP2_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV9clientId = AV21GAMApplication.gxTpr_Clientid;
         AV8baseUrl = AV21GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV17url = AV8baseUrl + context.GetMessage( "oauth/access_token", "");
         AV10httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV10httpclient.AddVariable(context.GetMessage( "client_id", ""), AV9clientId);
         AV10httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "password", ""));
         AV10httpclient.AddVariable(context.GetMessage( "scope", ""), context.GetMessage( "gam_user_data", ""));
         AV10httpclient.AddVariable(context.GetMessage( "username", ""), AV18username);
         AV10httpclient.AddVariable(context.GetMessage( "password", ""), AV13password);
         AV10httpclient.Execute(context.GetMessage( "POST", ""), AV17url);
         AV15result = AV10httpclient.ToString();
         if ( AV10httpclient.StatusCode != 200 )
         {
            AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
            AV19ErrorResponse.gxTpr_Message = AV10httpclient.ErrDescription;
            AV19ErrorResponse.gxTpr_Code = StringUtil.Trim( StringUtil.Str( (decimal)(AV10httpclient.StatusCode), 10, 2));
            AV12LoginResponse.gxTpr_Error = AV19ErrorResponse;
            AV14response = AV12LoginResponse.ToJSonString(false, true);
         }
         else
         {
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
         AV21GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV9clientId = "";
         AV8baseUrl = "";
         AV17url = "";
         AV10httpclient = new GxHttpClient( context);
         AV15result = "";
         AV19ErrorResponse = new SdtSDT_ErrorResponse(context);
         AV12LoginResponse = new SdtSDT_LoginResidentResponse(context);
         /* GeneXus formulas. */
      }

      private string AV14response ;
      private string AV15result ;
      private string AV18username ;
      private string AV13password ;
      private string AV9clientId ;
      private string AV8baseUrl ;
      private string AV17url ;
      private GxHttpClient AV10httpclient ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV21GAMApplication ;
      private SdtSDT_ErrorResponse AV19ErrorResponse ;
      private SdtSDT_LoginResidentResponse AV12LoginResponse ;
      private string aP2_response ;
   }

}
