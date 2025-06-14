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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_sendmail : GXProcedure
   {
      public wwp_sendmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MailId ,
                           ref GeneXus.Mail.GXSMTPSession aP1_SMTPSession ,
                           out short aP2_SendStatus )
      {
         this.AV14MailId = aP0_MailId;
         this.AV18SMTPSession = aP1_SMTPSession;
         this.AV17SendStatus = 0 ;
         initialize();
         ExecuteImpl();
         aP1_SMTPSession=this.AV18SMTPSession;
         aP2_SendStatus=this.AV17SendStatus;
      }

      public short executeUdp( long aP0_MailId ,
                               ref GeneXus.Mail.GXSMTPSession aP1_SMTPSession )
      {
         execute(aP0_MailId, ref aP1_SMTPSession, out aP2_SendStatus);
         return AV17SendStatus ;
      }

      public void executeSubmit( long aP0_MailId ,
                                 ref GeneXus.Mail.GXSMTPSession aP1_SMTPSession ,
                                 out short aP2_SendStatus )
      {
         this.AV14MailId = aP0_MailId;
         this.AV18SMTPSession = aP1_SMTPSession;
         this.AV17SendStatus = 0 ;
         SubmitImpl();
         aP1_SMTPSession=this.AV18SMTPSession;
         aP2_SendStatus=this.AV17SendStatus;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17SendStatus = -1;
         AV13Mail.Load(AV14MailId);
         if ( AV13Mail.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail not found with id: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail not found with id: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsenderaddress)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsendername)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Sender address/name cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Sender address/name cannot be empty: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Sender address/name cannot be empty") ;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsubject)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbody)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail subject/body cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail subject/body cannot be empty: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail subject/body cannot be empty") ;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailto)) && String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailcc)) && String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbcc)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail recipient cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail recipient cannot be empty: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail recipient cannot be empty") ;
            cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV20ToAddressList;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailto, out  GXt_objcol_vchar1) ;
         AV20ToAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailto)) && ( AV20ToAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail recipient is not valid address list: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail To is invalid") ;
            cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV11CCAddressList;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailcc, out  GXt_objcol_vchar1) ;
         AV11CCAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailcc)) && ( AV11CCAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail recipient is not valid address list: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail CC is invalid") ;
            cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV10BCCAddressList;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailbcc, out  GXt_objcol_vchar1) ;
         AV10BCCAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbcc)) && ( AV10BCCAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new prc_logtofile(context ).execute(  context.GetMessage( "Mail recipient is not valid address list: ", "")+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail BCC is invalid") ;
            cleanup();
            if (true) return;
         }
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV13Mail.gxTpr_Attachments.Count )
         {
            AV9Attachment = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)AV13Mail.gxTpr_Attachments.Item(AV22GXV1));
            AV12FileExists = (bool)(((context.FileExists( AV9Attachment.gxTpr_Wwpmailattachmentfile)==1)));
            if ( ! AV12FileExists )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  "Attachment is not a valid file: "+AV9Attachment.gxTpr_Wwpmailattachmentfile) ;
               new prc_logtofile(context ).execute(  context.GetMessage( "Attachment is not a valid file: ", "")+AV9Attachment.gxTpr_Wwpmailattachmentfile) ;
               new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Attachment invalid") ;
               cleanup();
               if (true) return;
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV15MailMessage.From.Address = AV13Mail.gxTpr_Wwpmailsenderaddress;
         AV15MailMessage.From.Name = AV13Mail.gxTpr_Wwpmailsendername;
         AV15MailMessage.Subject = AV13Mail.gxTpr_Wwpmailsubject;
         AV15MailMessage.HTMLText = AV13Mail.gxTpr_Wwpmailbody;
         AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV16MailRecipient.Address = AV13Mail.gxTpr_Wwpmailsenderaddress;
         AV16MailRecipient.Name = AV13Mail.gxTpr_Wwpmailsendername;
         AV18SMTPSession.Sender = AV16MailRecipient;
         AV23GXV2 = 1;
         while ( AV23GXV2 <= AV20ToAddressList.Count )
         {
            AV8Address = ((string)AV20ToAddressList.Item(AV23GXV2));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.To.Add(AV16MailRecipient);
            AV23GXV2 = (int)(AV23GXV2+1);
         }
         AV24GXV3 = 1;
         while ( AV24GXV3 <= AV11CCAddressList.Count )
         {
            AV8Address = ((string)AV11CCAddressList.Item(AV24GXV3));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.CC.Add(AV16MailRecipient);
            AV24GXV3 = (int)(AV24GXV3+1);
         }
         AV25GXV4 = 1;
         while ( AV25GXV4 <= AV10BCCAddressList.Count )
         {
            AV8Address = ((string)AV10BCCAddressList.Item(AV25GXV4));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.BCC.Add(AV16MailRecipient);
            AV25GXV4 = (int)(AV25GXV4+1);
         }
         AV26GXV5 = 1;
         while ( AV26GXV5 <= AV13Mail.gxTpr_Attachments.Count )
         {
            AV9Attachment = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)AV13Mail.gxTpr_Attachments.Item(AV26GXV5));
            AV15MailMessage.Attachments.Add(AV9Attachment.gxTpr_Wwpmailattachmentfile);
            AV26GXV5 = (int)(AV26GXV5+1);
         }
         AV17SendStatus = AV18SMTPSession.Send(AV15MailMessage);
         GXt_char2 = AV19StatusMessage;
         new WorkWithPlus.workwithplus_notificationscommon.wwp_getstatuscodemessage(context ).execute(  AV17SendStatus, out  GXt_char2) ;
         AV19StatusMessage = GXt_char2;
         if ( AV17SendStatus != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV21Pgmname,  StringUtil.Format( "Error sending mail with id: %1 - Code: %2 - %3", StringUtil.Str( (decimal)(AV14MailId), 10, 0), StringUtil.Trim( StringUtil.Str( (decimal)(AV17SendStatus), 4, 0)), AV19StatusMessage, "", "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  StringUtil.Format( "Code: %1 - Message: %2", StringUtil.Trim( StringUtil.Str( (decimal)(AV17SendStatus), 4, 0)), AV19StatusMessage, "", "", "", "", "", "", "")) ;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  2,  "OK") ;
         context.CommitDataStores("wwpbaseobjects.mail.wwp_sendmail",pr_default);
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
         AV13Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV21Pgmname = "";
         AV20ToAddressList = new GxSimpleCollection<string>();
         AV11CCAddressList = new GxSimpleCollection<string>();
         AV10BCCAddressList = new GxSimpleCollection<string>();
         GXt_objcol_vchar1 = new GxSimpleCollection<string>();
         AV9Attachment = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV8Address = "";
         AV19StatusMessage = "";
         GXt_char2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail__default(),
            new Object[][] {
            }
         );
         AV21Pgmname = "WWPBaseObjects.Mail.WWP_SendMail";
         /* GeneXus formulas. */
         AV21Pgmname = "WWPBaseObjects.Mail.WWP_SendMail";
      }

      private short AV17SendStatus ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private int AV24GXV3 ;
      private int AV25GXV4 ;
      private int AV26GXV5 ;
      private long AV14MailId ;
      private string AV21Pgmname ;
      private string GXt_char2 ;
      private bool AV12FileExists ;
      private string AV8Address ;
      private string AV19StatusMessage ;
      private GeneXus.Mail.GXMailMessage AV15MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV16MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV18SMTPSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Mail.GXSMTPSession aP1_SMTPSession ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail AV13Mail ;
      private GxSimpleCollection<string> AV20ToAddressList ;
      private GxSimpleCollection<string> AV11CCAddressList ;
      private GxSimpleCollection<string> AV10BCCAddressList ;
      private GxSimpleCollection<string> GXt_objcol_vchar1 ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments AV9Attachment ;
      private IDataStoreProvider pr_default ;
      private short aP2_SendStatus ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sendmail__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wwp_sendmail__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class wwp_sendmail__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
