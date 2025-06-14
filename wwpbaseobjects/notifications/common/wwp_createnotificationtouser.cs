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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_createnotificationtouser : GXProcedure
   {
      public wwp_createnotificationtouser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createnotificationtouser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           long aP1_WWPNotificationDefinitionId ,
                           string aP2_WWPNotificationDefinitionTitle ,
                           string aP3_WWPNotificationDefinitionShortDescription ,
                           string aP4_WWPNotificationDefinitionLongDescription ,
                           ref string aP5_WWPNotificationDefinitionLink ,
                           string aP6_WWPNotificationMetadata ,
                           string aP7_WWPNotificationDefinitionIcon ,
                           bool aP8_IsDiscussionNotification )
      {
         this.AV16WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV17WWPNotificationDefinitionId = aP1_WWPNotificationDefinitionId;
         this.AV11WWPNotificationDefinitionTitle = aP2_WWPNotificationDefinitionTitle;
         this.AV12WWPNotificationDefinitionShortDescription = aP3_WWPNotificationDefinitionShortDescription;
         this.AV13WWPNotificationDefinitionLongDescription = aP4_WWPNotificationDefinitionLongDescription;
         this.AV14WWPNotificationDefinitionLink = aP5_WWPNotificationDefinitionLink;
         this.AV15WWPNotificationMetadata = aP6_WWPNotificationMetadata;
         this.AV10WWPNotificationDefinitionIcon = aP7_WWPNotificationDefinitionIcon;
         this.AV25IsDiscussionNotification = aP8_IsDiscussionNotification;
         initialize();
         ExecuteImpl();
         aP5_WWPNotificationDefinitionLink=this.AV14WWPNotificationDefinitionLink;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 long aP1_WWPNotificationDefinitionId ,
                                 string aP2_WWPNotificationDefinitionTitle ,
                                 string aP3_WWPNotificationDefinitionShortDescription ,
                                 string aP4_WWPNotificationDefinitionLongDescription ,
                                 ref string aP5_WWPNotificationDefinitionLink ,
                                 string aP6_WWPNotificationMetadata ,
                                 string aP7_WWPNotificationDefinitionIcon ,
                                 bool aP8_IsDiscussionNotification )
      {
         this.AV16WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV17WWPNotificationDefinitionId = aP1_WWPNotificationDefinitionId;
         this.AV11WWPNotificationDefinitionTitle = aP2_WWPNotificationDefinitionTitle;
         this.AV12WWPNotificationDefinitionShortDescription = aP3_WWPNotificationDefinitionShortDescription;
         this.AV13WWPNotificationDefinitionLongDescription = aP4_WWPNotificationDefinitionLongDescription;
         this.AV14WWPNotificationDefinitionLink = aP5_WWPNotificationDefinitionLink;
         this.AV15WWPNotificationMetadata = aP6_WWPNotificationMetadata;
         this.AV10WWPNotificationDefinitionIcon = aP7_WWPNotificationDefinitionIcon;
         this.AV25IsDiscussionNotification = aP8_IsDiscussionNotification;
         SubmitImpl();
         aP5_WWPNotificationDefinitionLink=this.AV14WWPNotificationDefinitionLink;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P003L2 */
         pr_default.execute(0, new Object[] {AV16WWPUserExtendedId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112WWPUserExtendedId = P003L2_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P003L2_n112WWPUserExtendedId[0];
            A116WWPUserExtendedEmaiNotif = P003L2_A116WWPUserExtendedEmaiNotif[0];
            A114WWPUserExtendedEmail = P003L2_A114WWPUserExtendedEmail[0];
            A119WWPUserExtendedDesktopNotif = P003L2_A119WWPUserExtendedDesktopNotif[0];
            A118WWPUserExtendedMobileNotif = P003L2_A118WWPUserExtendedMobileNotif[0];
            A117WWPUserExtendedSMSNotif = P003L2_A117WWPUserExtendedSMSNotif[0];
            A120WWPUserExtendedPhone = P003L2_A120WWPUserExtendedPhone[0];
            AV23WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            AV23WWP_Notification.gxTpr_Wwpuserextendedid = AV16WWPUserExtendedId;
            AV23WWP_Notification.gxTpr_Wwpnotificationdefinitionid = AV17WWPNotificationDefinitionId;
            AV23WWP_Notification.gxTpr_Wwpnotificationtitle = AV11WWPNotificationDefinitionTitle;
            AV23WWP_Notification.gxTpr_Wwpnotificationshortdescription = AV12WWPNotificationDefinitionShortDescription;
            AV23WWP_Notification.gxTpr_Wwpnotificationicon = AV10WWPNotificationDefinitionIcon;
            new WorkWithPlus.workwithplus_notificationscommon.wwp_cleannotificationurl(context ).execute( ref  AV14WWPNotificationDefinitionLink) ;
            AV23WWP_Notification.gxTpr_Wwpnotificationlink = AV14WWPNotificationDefinitionLink;
            AV23WWP_Notification.gxTpr_Wwpnotificationmetadata = AV15WWPNotificationMetadata;
            AV23WWP_Notification.Save();
            AV18WWPNotificationID = AV23WWP_Notification.gxTpr_Wwpnotificationid;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+GXUtil.UrlEncode(StringUtil.LTrimStr(AV18WWPNotificationID,10,0));
            AV30SmsAndMailUrl = formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new WorkWithPlus.workwithplus_notificationscommon.wwp_cleannotificationurl(context ).execute( ref  AV30SmsAndMailUrl) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  context.GetMessage( "Notification_BaseURL", ""), ref  AV26Notification_BaseUrl) ;
            AV30SmsAndMailUrl = StringUtil.Format( "%1%2", AV26Notification_BaseUrl, AV30SmsAndMailUrl, "", "", "", "", "", "", "");
            if ( A116WWPUserExtendedEmaiNotif && ( StringUtil.Contains( AV12WWPNotificationDefinitionShortDescription, context.GetMessage( "Meldingen Helmweg", "")) || StringUtil.Contains( AV12WWPNotificationDefinitionShortDescription, context.GetMessage( "eTicket", "")) || StringUtil.Contains( AV12WWPNotificationDefinitionShortDescription, context.GetMessage( "E-Ticket", "")) ) && StringUtil.Contains( AV11WWPNotificationDefinitionTitle, context.GetMessage( "New Form Response", "")) )
            {
               AV28WWPUserExtendedEmail = A114WWPUserExtendedEmail;
               /* Execute user subroutine: 'CREATEMAIL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            if ( AV25IsDiscussionNotification || A119WWPUserExtendedDesktopNotif )
            {
               /* Execute user subroutine: 'CREATEDESKTOPNOTIFICATION' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            if ( A118WWPUserExtendedMobileNotif )
            {
               /* Execute user subroutine: 'CREATEMOBILENOTIFICATION' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            if ( A117WWPUserExtendedSMSNotif )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A120WWPUserExtendedPhone)) )
               {
                  AV29WWPUserExtendedPhone = A120WWPUserExtendedPhone;
                  /* Execute user subroutine: 'CREATESMS' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATEMAIL' Routine */
         returnInSub = false;
         AV19Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV19Mail.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
         AV24MailTemplate.Load("MailNotification");
         if ( AV24MailTemplate.Success() )
         {
            AV19Mail.gxTpr_Wwpmailsendername = AV24MailTemplate.gxTpr_Wwpmailtemplatesendername;
            AV19Mail.gxTpr_Wwpmailsenderaddress = AV24MailTemplate.gxTpr_Wwpmailtemplatesenderaddress;
            AV22MailBody = AV24MailTemplate.gxTpr_Wwpmailtemplatebody;
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Name", ref  AV8SenderName) ;
            AV19Mail.gxTpr_Wwpmailsendername = AV8SenderName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Address", ref  AV9SenderAddress) ;
            AV19Mail.gxTpr_Wwpmailsenderaddress = AV9SenderAddress;
            AV22MailBody = AV13WWPNotificationDefinitionLongDescription;
         }
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[SHORT_DESCRIPTION]", AV12WWPNotificationDefinitionShortDescription);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[LONG_DESCRIPTION]", AV13WWPNotificationDefinitionLongDescription);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[TITLE]", AV11WWPNotificationDefinitionTitle);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[LINK]", AV30SmsAndMailUrl);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[BASE_URL]", AV26Notification_BaseUrl);
         AV19Mail.gxTpr_Wwpmailbody = AV22MailBody;
         AV19Mail.gxTpr_Wwpmailto = AV28WWPUserExtendedEmail;
         AV19Mail.gxTpr_Wwpmailsubject = context.GetMessage( "Comforta - ", "")+AV11WWPNotificationDefinitionTitle;
         AV19Mail.Save();
      }

      protected void S121( )
      {
         /* 'CREATEDESKTOPNOTIFICATION' Routine */
         returnInSub = false;
         /* Using cursor P003L3 */
         pr_default.execute(1, new Object[] {AV16WWPUserExtendedId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A112WWPUserExtendedId = P003L3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P003L3_n112WWPUserExtendedId[0];
            A153WWPWebClientId = P003L3_A153WWPWebClientId[0];
            AV20WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            AV20WebNotification.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
            AV20WebNotification.gxTpr_Wwpwebnotificationclientid = A153WWPWebClientId;
            AV20WebNotification.gxTpr_Wwpwebnotificationtitle = AV11WWPNotificationDefinitionTitle;
            AV20WebNotification.gxTpr_Wwpwebnotificationicon = AV10WWPNotificationDefinitionIcon;
            AV20WebNotification.gxTpr_Wwpwebnotificationtext = AV12WWPNotificationDefinitionShortDescription;
            AV20WebNotification.Save();
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'CREATESMS' Routine */
         returnInSub = false;
         AV21SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV21SMS.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
         AV21SMS.gxTpr_Wwpsmsmessage = AV12WWPNotificationDefinitionShortDescription;
         AV21SMS.gxTpr_Wwpsmsrecipientnumbers = AV29WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_DefaultSender", ref  AV31TextParameter) ;
         AV21SMS.gxTpr_Wwpsmssendernumber = AV31TextParameter;
         AV21SMS.Save();
      }

      protected void S141( )
      {
         /* 'CREATEMOBILENOTIFICATION' Routine */
         returnInSub = false;
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
         P003L2_A112WWPUserExtendedId = new string[] {""} ;
         P003L2_n112WWPUserExtendedId = new bool[] {false} ;
         P003L2_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         P003L2_A114WWPUserExtendedEmail = new string[] {""} ;
         P003L2_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         P003L2_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         P003L2_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         P003L2_A120WWPUserExtendedPhone = new string[] {""} ;
         A112WWPUserExtendedId = "";
         A114WWPUserExtendedEmail = "";
         A120WWPUserExtendedPhone = "";
         AV23WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
         AV30SmsAndMailUrl = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26Notification_BaseUrl = "";
         AV28WWPUserExtendedEmail = "";
         AV29WWPUserExtendedPhone = "";
         AV19Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV24MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         AV22MailBody = "";
         AV8SenderName = "";
         AV9SenderAddress = "";
         P003L3_A112WWPUserExtendedId = new string[] {""} ;
         P003L3_n112WWPUserExtendedId = new bool[] {false} ;
         P003L3_A153WWPWebClientId = new string[] {""} ;
         A153WWPWebClientId = "";
         AV20WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV21SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV31TextParameter = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser__default(),
            new Object[][] {
                new Object[] {
               P003L2_A112WWPUserExtendedId, P003L2_A116WWPUserExtendedEmaiNotif, P003L2_A114WWPUserExtendedEmail, P003L2_A119WWPUserExtendedDesktopNotif, P003L2_A118WWPUserExtendedMobileNotif, P003L2_A117WWPUserExtendedSMSNotif, P003L2_A120WWPUserExtendedPhone
               }
               , new Object[] {
               P003L3_A112WWPUserExtendedId, P003L3_n112WWPUserExtendedId, P003L3_A153WWPWebClientId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV17WWPNotificationDefinitionId ;
      private long AV18WWPNotificationID ;
      private string AV16WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string A120WWPUserExtendedPhone ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV29WWPUserExtendedPhone ;
      private string A153WWPWebClientId ;
      private bool AV25IsDiscussionNotification ;
      private bool n112WWPUserExtendedId ;
      private bool A116WWPUserExtendedEmaiNotif ;
      private bool A119WWPUserExtendedDesktopNotif ;
      private bool A118WWPUserExtendedMobileNotif ;
      private bool A117WWPUserExtendedSMSNotif ;
      private bool returnInSub ;
      private string AV15WWPNotificationMetadata ;
      private string AV22MailBody ;
      private string AV11WWPNotificationDefinitionTitle ;
      private string AV12WWPNotificationDefinitionShortDescription ;
      private string AV13WWPNotificationDefinitionLongDescription ;
      private string AV14WWPNotificationDefinitionLink ;
      private string AV10WWPNotificationDefinitionIcon ;
      private string A114WWPUserExtendedEmail ;
      private string AV30SmsAndMailUrl ;
      private string AV26Notification_BaseUrl ;
      private string AV28WWPUserExtendedEmail ;
      private string AV8SenderName ;
      private string AV9SenderAddress ;
      private string AV31TextParameter ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP5_WWPNotificationDefinitionLink ;
      private IDataStoreProvider pr_default ;
      private string[] P003L2_A112WWPUserExtendedId ;
      private bool[] P003L2_n112WWPUserExtendedId ;
      private bool[] P003L2_A116WWPUserExtendedEmaiNotif ;
      private string[] P003L2_A114WWPUserExtendedEmail ;
      private bool[] P003L2_A119WWPUserExtendedDesktopNotif ;
      private bool[] P003L2_A118WWPUserExtendedMobileNotif ;
      private bool[] P003L2_A117WWPUserExtendedSMSNotif ;
      private string[] P003L2_A120WWPUserExtendedPhone ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification AV23WWP_Notification ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail AV19Mail ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate AV24MailTemplate ;
      private string[] P003L3_A112WWPUserExtendedId ;
      private bool[] P003L3_n112WWPUserExtendedId ;
      private string[] P003L3_A153WWPWebClientId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV20WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS AV21SMS ;
   }

   public class wwp_createnotificationtouser__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003L2;
          prmP003L2 = new Object[] {
          new ParDef("AV16WWPUserExtendedId",GXType.Char,40,0)
          };
          Object[] prmP003L3;
          prmP003L3 = new Object[] {
          new ParDef("AV16WWPUserExtendedId",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003L2", "SELECT WWPUserExtendedId, WWPUserExtendedEmaiNotif, WWPUserExtendedEmail, WWPUserExtendedDesktopNotif, WWPUserExtendedMobileNotif, WWPUserExtendedSMSNotif, WWPUserExtendedPhone FROM WWP_UserExtended WHERE WWPUserExtendedId = ( :AV16WWPUserExtendedId) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P003L3", "SELECT WWPUserExtendedId, WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = ( :AV16WWPUserExtendedId) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
