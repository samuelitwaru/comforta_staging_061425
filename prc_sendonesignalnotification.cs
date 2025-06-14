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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_sendonesignalnotification : GXProcedure
   {
      public prc_sendonesignalnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendonesignalnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxSimpleCollection<string> aP0_DeviceTokenCollection ,
                           string aP1_title ,
                           string aP2_message ,
                           SdtSDT_OneSignalCustomData aP3_NotificationMetadata ,
                           bool aP4_isSilentNotification ,
                           out string aP5_OutMessage ,
                           out bool aP6_IsSuccessful )
      {
         this.AV10DeviceTokenCollection = aP0_DeviceTokenCollection;
         this.AV26title = aP1_title;
         this.AV23message = aP2_message;
         this.AV24NotificationMetadata = aP3_NotificationMetadata;
         this.AV27isSilentNotification = aP4_isSilentNotification;
         this.AV25OutMessage = "" ;
         this.AV22IsSuccessful = false ;
         initialize();
         ExecuteImpl();
         aP5_OutMessage=this.AV25OutMessage;
         aP6_IsSuccessful=this.AV22IsSuccessful;
      }

      public bool executeUdp( GxSimpleCollection<string> aP0_DeviceTokenCollection ,
                              string aP1_title ,
                              string aP2_message ,
                              SdtSDT_OneSignalCustomData aP3_NotificationMetadata ,
                              bool aP4_isSilentNotification ,
                              out string aP5_OutMessage )
      {
         execute(aP0_DeviceTokenCollection, aP1_title, aP2_message, aP3_NotificationMetadata, aP4_isSilentNotification, out aP5_OutMessage, out aP6_IsSuccessful);
         return AV22IsSuccessful ;
      }

      public void executeSubmit( GxSimpleCollection<string> aP0_DeviceTokenCollection ,
                                 string aP1_title ,
                                 string aP2_message ,
                                 SdtSDT_OneSignalCustomData aP3_NotificationMetadata ,
                                 bool aP4_isSilentNotification ,
                                 out string aP5_OutMessage ,
                                 out bool aP6_IsSuccessful )
      {
         this.AV10DeviceTokenCollection = aP0_DeviceTokenCollection;
         this.AV26title = aP1_title;
         this.AV23message = aP2_message;
         this.AV24NotificationMetadata = aP3_NotificationMetadata;
         this.AV27isSilentNotification = aP4_isSilentNotification;
         this.AV25OutMessage = "" ;
         this.AV22IsSuccessful = false ;
         SubmitImpl();
         aP5_OutMessage=this.AV25OutMessage;
         aP6_IsSuccessful=this.AV22IsSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11HttpClient.Host = "onesignal.com";
         AV11HttpClient.BaseURL = "/api/v1";
         AV11HttpClient.Secure = 1;
         AV11HttpClient.AddHeader("Authorization", "Basic MzcxMmQwYzYtNjUyYi00OTk2LWFjZmQtY2Y1MDIyNjU4NWQ1");
         AV11HttpClient.AddHeader("Content-Type", "application/json");
         AV15SDT_OneSignalCustomBody = new SdtSDT_OneSignalCustomBody(context);
         AV15SDT_OneSignalCustomBody.gxTpr_App_id = "04453574-cfee-45bc-adef-888ecdaa0707";
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV10DeviceTokenCollection.Count )
         {
            AV9DeviceToken = AV10DeviceTokenCollection.GetString(AV28GXV1);
            AV15SDT_OneSignalCustomBody.gxTpr_Include_player_ids.Add(AV9DeviceToken, 0);
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         AV15SDT_OneSignalCustomBody.gxTpr_Headings.gxTpr_En = AV26title;
         if ( AV27isSilentNotification )
         {
            AV15SDT_OneSignalCustomBody.gxTpr_Content_available = true;
         }
         else
         {
            AV15SDT_OneSignalCustomBody.gxTpr_Contents.gxTpr_En = AV23message;
         }
         AV15SDT_OneSignalCustomBody.gxTpr_Data = AV24NotificationMetadata;
         AV8body = AV15SDT_OneSignalCustomBody.ToJSonString(false, true);
         AV11HttpClient.AddString(AV8body);
         AV11HttpClient.Execute(context.GetMessage( "POST", ""), "notifications");
         if ( AV11HttpClient.StatusCode == 200 )
         {
            AV22IsSuccessful = true;
            AV25OutMessage = "Notification Sent Successfully";
         }
         else
         {
            AV22IsSuccessful = false;
            AV25OutMessage = AV11HttpClient.ToString();
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
         AV25OutMessage = "";
         AV11HttpClient = new GxHttpClient( context);
         AV15SDT_OneSignalCustomBody = new SdtSDT_OneSignalCustomBody(context);
         AV9DeviceToken = "";
         AV8body = "";
         /* GeneXus formulas. */
      }

      private int AV28GXV1 ;
      private string AV9DeviceToken ;
      private bool AV27isSilentNotification ;
      private bool AV22IsSuccessful ;
      private string AV25OutMessage ;
      private string AV8body ;
      private string AV26title ;
      private string AV23message ;
      private GxHttpClient AV11HttpClient ;
      private GxSimpleCollection<string> AV10DeviceTokenCollection ;
      private SdtSDT_OneSignalCustomData AV24NotificationMetadata ;
      private SdtSDT_OneSignalCustomBody AV15SDT_OneSignalCustomBody ;
      private string aP5_OutMessage ;
      private bool aP6_IsSuccessful ;
   }

}
