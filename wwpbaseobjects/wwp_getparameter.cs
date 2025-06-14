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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getparameter : GXProcedure
   {
      public wwp_getparameter( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getparameter( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_text( string aP0_ParameterName ,
                             ref string aP1_TextParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV15TextParameter = aP1_TextParameter;
         initialize();
         /* Text Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Host") == 0 )
         {
            AV15TextParameter = "comforta.yukon.software";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Username") == 0 )
         {
            AV15TextParameter = "no-reply@comforta.yukon.software";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Password") == 0 )
         {
            AV15TextParameter = "2uSFuxkquz";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ServicePlanId") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_Token") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ApplicationKey") == 0 )
         {
            AV15TextParameter = "dddddddd-dddd-dddd-dddd-dddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ApplicationSecret") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddd==";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_DefaultSender") == 0 )
         {
            AV15TextParameter = "+111111111111";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Sender_Name") == 0 )
         {
            AV15TextParameter = "Comforta Software";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Sender_Address") == 0 )
         {
            AV15TextParameter = "no-reply@comforta.yukon.software";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Notification_BaseURL") == 0 )
         {
            AV15TextParameter = AV12HTTPRequest.BaseURL;
         }
         ExecuteImpl();
         aP1_TextParameter=this.AV15TextParameter;
         cleanup();
      }

      public void gxep_integer( string aP0_ParameterName ,
                                ref long aP1_IntegerParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV13IntegerParameter = aP1_IntegerParameter;
         initialize();
         /* Integer Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Port") == 0 )
         {
            AV13IntegerParameter = 465;
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Timeout") == 0 )
         {
            AV13IntegerParameter = 60;
         }
         ExecuteImpl();
         aP1_IntegerParameter=this.AV13IntegerParameter;
         cleanup();
      }

      public void gxep_decimal( string aP0_ParameterName ,
                                ref decimal aP1_DecimalParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV11DecimalParameter = aP1_DecimalParameter;
         initialize();
         /* Decimal Constructor */
         ExecuteImpl();
         aP1_DecimalParameter=this.AV11DecimalParameter;
         cleanup();
      }

      public void gxep_boolean( string aP0_ParameterName ,
                                ref bool aP1_BooleanParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV8BooleanParameter = aP1_BooleanParameter;
         initialize();
         /* Boolean Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Authentication") == 0 )
         {
            AV8BooleanParameter = true;
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Secure") == 0 )
         {
            /* User Code */
             AV8BooleanParameter = true;
         }
         ExecuteImpl();
         aP1_BooleanParameter=this.AV8BooleanParameter;
         cleanup();
      }

      public void gxep_date( string aP0_ParameterName ,
                             ref DateTime aP1_DateParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV9DateParameter = aP1_DateParameter;
         initialize();
         /* Date Constructor */
         ExecuteImpl();
         aP1_DateParameter=this.AV9DateParameter;
         cleanup();
      }

      public void gxep_datetime( string aP0_ParameterName ,
                                 ref DateTime aP1_DateTimeParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV10DateTimeParameter = aP1_DateTimeParameter;
         initialize();
         /* DateTime Constructor */
         ExecuteImpl();
         aP1_DateTimeParameter=this.AV10DateTimeParameter;
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
         AV12HTTPRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private long AV13IntegerParameter ;
      private decimal AV11DecimalParameter ;
      private DateTime AV10DateTimeParameter ;
      private DateTime AV9DateParameter ;
      private bool AV8BooleanParameter ;
      private string AV15TextParameter ;
      private string AV14ParameterName ;
      private GxHttpRequest AV12HTTPRequest ;
      private string aP1_TextParameter ;
      private long aP1_IntegerParameter ;
      private decimal aP1_DecimalParameter ;
      private bool aP1_BooleanParameter ;
      private DateTime aP1_DateParameter ;
      private DateTime aP1_DateTimeParameter ;
   }

}
