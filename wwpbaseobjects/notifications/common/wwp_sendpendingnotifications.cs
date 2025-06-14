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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_sendpendingnotifications : GXProcedure
   {
      public wwp_sendpendingnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendpendingnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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
         /* Execute user subroutine: 'SENDPENDINGSMS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGWEBNOTIFICATIONS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGMOBILENOTIFICATIONS' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGMAILS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'SENDPENDINGMAILS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMTPParametersSDT1 = AV8SMTPParametersSDT;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_getsmtpparameters(context ).execute( out  GXt_SdtWWP_SMTPParametersSDT1) ;
         AV8SMTPParametersSDT = GXt_SdtWWP_SMTPParametersSDT1;
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9SmtpSession.Host = AV8SMTPParametersSDT.gxTpr_Host;
         AV9SmtpSession.Port = AV8SMTPParametersSDT.gxTpr_Port;
         AV9SmtpSession.UserName = AV8SMTPParametersSDT.gxTpr_Username;
         AV9SmtpSession.Password = AV8SMTPParametersSDT.gxTpr_Password;
         AV9SmtpSession.Authentication = AV8SMTPParametersSDT.gxTpr_Authentication;
         AV9SmtpSession.Secure = AV8SMTPParametersSDT.gxTpr_Secure;
         AV9SmtpSession.Timeout = AV8SMTPParametersSDT.gxTpr_Timeout;
         AV14StatusCode = AV9SmtpSession.Login();
         if ( AV14StatusCode != 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Error during SMTP Login: ", "")+AV9SmtpSession.ErrDescription) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "Error during SMTP Login: "+AV9SmtpSession.ErrDescription) ;
         }
         else
         {
            /* Using cursor P003M2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A196WWPMailCreated = P003M2_A196WWPMailCreated[0];
               A186WWPMailStatus = P003M2_A186WWPMailStatus[0];
               A185WWPMailId = P003M2_A185WWPMailId[0];
               GXt_int2 = AV14StatusCode;
               new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail(context ).execute(  A185WWPMailId, ref  AV9SmtpSession, out  GXt_int2) ;
               AV14StatusCode = GXt_int2;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV9SmtpSession.Logout();
         }
      }

      protected void S121( )
      {
         /* 'SENDPENDINGSMS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMSParametersSDT3 = AV10SMSParametersSDT;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_getsmsparameters(context ).execute( out  GXt_SdtWWP_SMSParametersSDT3) ;
         AV10SMSParametersSDT = GXt_SdtWWP_SMSParametersSDT3;
         /* Using cursor P003M3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A139WWPSMSStatus = P003M3_A139WWPSMSStatus[0];
            A138WWPSMSId = P003M3_A138WWPSMSId[0];
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_sendsms(context ).execute(  A138WWPSMSId,  AV10SMSParametersSDT, out  AV12Success, out  AV13SendSMSResultSDT) ;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'SENDPENDINGWEBNOTIFICATIONS' Routine */
         returnInSub = false;
         /* Using cursor P003M4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A159WWPWebNotificationStatus = P003M4_A159WWPWebNotificationStatus[0];
            A152WWPWebNotificationId = P003M4_A152WWPWebNotificationId[0];
            GXt_int2 = AV11SendStatus;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification(context ).execute(  A152WWPWebNotificationId, out  GXt_int2) ;
            AV11SendStatus = GXt_int2;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S141( )
      {
         /* 'SENDPENDINGMOBILENOTIFICATIONS' Routine */
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
         AV8SMTPParametersSDT = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMTPParametersSDT(context);
         GXt_SdtWWP_SMTPParametersSDT1 = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMTPParametersSDT(context);
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV15Pgmname = "";
         P003M2_A196WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         P003M2_A186WWPMailStatus = new short[1] ;
         P003M2_A185WWPMailId = new long[1] ;
         A196WWPMailCreated = (DateTime)(DateTime.MinValue);
         AV10SMSParametersSDT = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMSParametersSDT(context);
         GXt_SdtWWP_SMSParametersSDT3 = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMSParametersSDT(context);
         P003M3_A139WWPSMSStatus = new short[1] ;
         P003M3_A138WWPSMSId = new long[1] ;
         AV13SendSMSResultSDT = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SendSMSResultSDT(context);
         P003M4_A159WWPWebNotificationStatus = new short[1] ;
         P003M4_A152WWPWebNotificationId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications__default(),
            new Object[][] {
                new Object[] {
               P003M2_A196WWPMailCreated, P003M2_A186WWPMailStatus, P003M2_A185WWPMailId
               }
               , new Object[] {
               P003M3_A139WWPSMSStatus, P003M3_A138WWPSMSId
               }
               , new Object[] {
               P003M4_A159WWPWebNotificationStatus, P003M4_A152WWPWebNotificationId
               }
            }
         );
         AV15Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
         /* GeneXus formulas. */
         AV15Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
      }

      private short AV14StatusCode ;
      private short A186WWPMailStatus ;
      private short A139WWPSMSStatus ;
      private short A159WWPWebNotificationStatus ;
      private short AV11SendStatus ;
      private short GXt_int2 ;
      private long A185WWPMailId ;
      private long A138WWPSMSId ;
      private long A152WWPWebNotificationId ;
      private string AV15Pgmname ;
      private DateTime A196WWPMailCreated ;
      private bool returnInSub ;
      private bool AV12Success ;
      private GeneXus.Mail.GXSMTPSession AV9SmtpSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMTPParametersSDT AV8SMTPParametersSDT ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMTPParametersSDT GXt_SdtWWP_SMTPParametersSDT1 ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P003M2_A196WWPMailCreated ;
      private short[] P003M2_A186WWPMailStatus ;
      private long[] P003M2_A185WWPMailId ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMSParametersSDT AV10SMSParametersSDT ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SMSParametersSDT GXt_SdtWWP_SMSParametersSDT3 ;
      private short[] P003M3_A139WWPSMSStatus ;
      private long[] P003M3_A138WWPSMSId ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SendSMSResultSDT AV13SendSMSResultSDT ;
      private short[] P003M4_A159WWPWebNotificationStatus ;
      private long[] P003M4_A152WWPWebNotificationId ;
   }

   public class wwp_sendpendingnotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP003M2;
          prmP003M2 = new Object[] {
          };
          Object[] prmP003M3;
          prmP003M3 = new Object[] {
          };
          Object[] prmP003M4;
          prmP003M4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003M2", "SELECT WWPMailCreated, WWPMailStatus, WWPMailId FROM WWP_Mail WHERE ((WWPMailCreated + CAST (86400 * CAST(( 1) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) > timezone('UTC', NOW())) AND (WWPMailStatus = 1) ORDER BY WWPMailId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003M3", "SELECT WWPSMSStatus, WWPSMSId FROM WWP_SMS WHERE WWPSMSStatus = 1 ORDER BY WWPSMSId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003M4", "SELECT WWPWebNotificationStatus, WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationStatus = 1 ORDER BY WWPWebNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M4,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
