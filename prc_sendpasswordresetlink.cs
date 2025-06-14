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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_sendpasswordresetlink : GXProcedure
   {
      public prc_sendpasswordresetlink( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendpasswordresetlink( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGAMGUID ,
                           out bool aP1_isSuccessful )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV19isSuccessful = false ;
         initialize();
         ExecuteImpl();
         aP1_isSuccessful=this.AV19isSuccessful;
      }

      public bool executeUdp( string aP0_UserGAMGUID )
      {
         execute(aP0_UserGAMGUID, out aP1_isSuccessful);
         return AV19isSuccessful ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 out bool aP1_isSuccessful )
      {
         this.AV23UserGAMGUID = aP0_UserGAMGUID;
         this.AV19isSuccessful = false ;
         SubmitImpl();
         aP1_isSuccessful=this.AV19isSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15GAMUser.load( AV23UserGAMGUID);
         AV39GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV11baseUrl = AV39GAMApplication.gxTpr_Environment.gxTpr_Url;
         if ( AV15GAMUser.success() )
         {
            AV40GAMUserLanguage = AV15GAMUser.gxTpr_Language;
            GXt_char1 = AV41ResidentLanguage;
            new prc_getresidentlanguagefromguid(context ).execute(  AV23UserGAMGUID, out  GXt_char1) ;
            AV41ResidentLanguage = GXt_char1;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40GAMUserLanguage)) )
            {
               AV43Language = AV40GAMUserLanguage;
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41ResidentLanguage)) )
            {
               if ( StringUtil.StrCmp(AV41ResidentLanguage, "nl") == 0 )
               {
                  AV43Language = "Dutch";
               }
               else if ( StringUtil.StrCmp(AV41ResidentLanguage, "en") == 0 )
               {
                  AV43Language = "English";
               }
               else
               {
                  AV43Language = "Dutch";
               }
            }
            else
            {
               AV43Language = "Dutch";
            }
            new prc_logtofile(context ).execute(  AV43Language) ;
            AV28KeyToChangePassword = AV15GAMUser.recoverpasswordbykey(out  AV30GAMErrorCollection);
            GXt_char1 = AV27LinkURL;
            new gam_buildappurl(context ).execute(  formatLink("urecoverpasswordstep2.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(AV23UserGAMGUID)),GXUtil.UrlEncode(StringUtil.RTrim(AV28KeyToChangePassword))}, new string[] {"UserGAMGUID","KeyToChangePassword"}) , out  GXt_char1) ;
            AV27LinkURL = GXt_char1;
            AV24Username = AV15GAMUser.gxTpr_Firstname + " " + AV15GAMUser.gxTpr_Lastname;
            if ( AV30GAMErrorCollection.Count == 0 )
            {
               AV31MailTemplate.Load("MailActivation");
               if ( AV31MailTemplate.Success() )
               {
                  AV32MailTemplateBody = AV31MailTemplate.gxTpr_Wwpmailtemplatebody;
               }
               AV22SMTPSession.Host = context.GetMessage( "comforta.yukon.software", "");
               AV22SMTPSession.Port = 465;
               AV22SMTPSession.Secure = 1;
               AV22SMTPSession.Authentication = 0;
               AV22SMTPSession.AuthenticationMethod = "";
               AV22SMTPSession.UserName = context.GetMessage( "no-reply@comforta.yukon.software", "");
               AV22SMTPSession.Password = context.GetMessage( "2uSFuxkquz", "");
               AV22SMTPSession.Sender.Address = context.GetMessage( "no-reply@comforta.yukon.software", "");
               AV22SMTPSession.Sender.Name = "Comforta Software";
               AV9MailRecipient.Address = AV15GAMUser.gxTpr_Email;
               AV9MailRecipient.Name = AV24Username;
               if ( StringUtil.StrCmp(AV43Language, "English") == 0 )
               {
                  AV20MailMessage.Subject = "Password reset";
               }
               else if ( StringUtil.StrCmp(AV43Language, "Dutch") == 0 )
               {
                  AV20MailMessage.Subject = "Wachtwoord opnieuw instellen";
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32MailTemplateBody)) )
               {
                  if ( StringUtil.StrCmp(AV43Language, "English") == 0 )
                  {
                     AV20MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+context.GetMessage( "<div style=\"background-color: #222F54; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear ", "")+AV24Username+context.GetMessage( ",</p><p>You are recieving this email because you requested for password reset.</p><p>Please click the button below to reset your password:</p>", "")+context.GetMessage( "</b></p><a href=\"", "")+AV27LinkURL+context.GetMessage( "\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #222F54; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Reset Password</a>", "")+context.GetMessage( "<p>Please note that the link expires in 2 hours.</p>", "")+context.GetMessage( "</div></div>", "");
                  }
                  else if ( StringUtil.StrCmp(AV43Language, "Dutch") == 0 )
                  {
                     AV20MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+context.GetMessage( "<div style=\"background-color: #222F54; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Beste ", "")+AV24Username+context.GetMessage( ",</p><p>Je ontvangt deze e-mail omdat je een wachtwoordreset hebt aangevraagd.</p><p>Klik op de onderstaande knop om je wachtwoord opnieuw in te stellen:</p>", "")+context.GetMessage( "</b></p><a href=\"", "")+AV27LinkURL+context.GetMessage( "\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #222F54; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Wachtwoord Resetten</a>", "")+context.GetMessage( "<p>Houd er rekening mee dat de link over 2 uur verloopt.</p>", "")+context.GetMessage( "</div></div>", "");
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV43Language, "English") == 0 )
                  {
                     AV34Dear_Username = "Dear " + AV24Username;
                     AV44Welcome_message = "You are recieving this email because you requested for a password reset.";
                     AV38Instruction_Message = "Please click the button below to reset your password:";
                     AV33Button_Text = "Reset Password";
                     AV35Expiration_Message = "Please note that the link expires in 2 hours.";
                     AV36FollowUp_Message = "Once you have reset your password, you can login into the platform once again.";
                     AV37Footer_Message = "All the best!";
                  }
                  else if ( StringUtil.StrCmp(AV43Language, "Dutch") == 0 )
                  {
                     AV34Dear_Username = "Beste " + AV24Username;
                     AV44Welcome_message = "Je ontvangt deze e-mail omdat je een wachtwoordreset hebt aangevraagd.";
                     AV38Instruction_Message = "Klik op de onderstaande knop om je wachtwoord opnieuw in te stellen:";
                     AV33Button_Text = "Wachtwoord Resetten";
                     AV35Expiration_Message = "Houd er rekening mee dat de link over 2 uur verloopt.";
                     AV36FollowUp_Message = "Zodra je je wachtwoord hebt gereset, kun je opnieuw inloggen op het platform.";
                     AV37Footer_Message = "Het allerbeste!";
                  }
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[DEAR_USERNAME]", AV34Dear_Username);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[WELCOME_MESSAGE]", AV44Welcome_message);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[INSTRUCTION_MESSAGE]", AV38Instruction_Message);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[BUTTON_TEXT]", AV33Button_Text);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[EXPIRATION_MESSAGE]", AV35Expiration_Message);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[FOLLOWUP_INSTRUCTION]", AV36FollowUp_Message);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[FOOTER_MESSAGE]", AV37Footer_Message);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[LINK]", AV27LinkURL);
                  AV32MailTemplateBody = StringUtil.StringReplace( AV32MailTemplateBody, "[BASE_URL]", AV11baseUrl);
                  AV20MailMessage.HTMLText = AV32MailTemplateBody;
               }
               AV20MailMessage.To.Add(AV9MailRecipient);
               AV22SMTPSession.Login();
               AV22SMTPSession.Send(AV20MailMessage);
               if ( ( AV22SMTPSession.ErrCode < 1 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV22SMTPSession.ErrDescription), context.GetMessage( "OK", "")) == 0 ) )
               {
                  AV22SMTPSession.Logout();
                  AV19isSuccessful = true;
               }
               else
               {
                  AV12ErrDescription = context.GetMessage( "Sending password reset email failed - ", "") + StringUtil.Str( (decimal)(AV22SMTPSession.ErrCode), 10, 2) + " " + AV22SMTPSession.ErrDescription;
                  AV19isSuccessful = false;
               }
            }
            else
            {
               AV45GXV1 = 1;
               while ( AV45GXV1 <= AV30GAMErrorCollection.Count )
               {
                  AV8GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30GAMErrorCollection.Item(AV45GXV1));
                  AV12ErrDescription += AV8GAMErrorItem.gxTpr_Message + " ";
                  AV45GXV1 = (int)(AV45GXV1+1);
               }
               AV19isSuccessful = false;
            }
         }
         else
         {
            AV12ErrDescription = context.GetMessage( "Failed to load user", "");
            AV19isSuccessful = false;
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
         AV15GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV39GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV11baseUrl = "";
         AV40GAMUserLanguage = "";
         AV41ResidentLanguage = "";
         AV43Language = "";
         AV28KeyToChangePassword = "";
         AV30GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV27LinkURL = "";
         GXt_char1 = "";
         AV24Username = "";
         AV31MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         AV32MailTemplateBody = "";
         AV22SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV20MailMessage = new GeneXus.Mail.GXMailMessage();
         AV34Dear_Username = "";
         AV44Welcome_message = "";
         AV38Instruction_Message = "";
         AV33Button_Text = "";
         AV35Expiration_Message = "";
         AV36FollowUp_Message = "";
         AV37Footer_Message = "";
         AV12ErrDescription = "";
         AV8GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV45GXV1 ;
      private string AV41ResidentLanguage ;
      private string AV28KeyToChangePassword ;
      private string GXt_char1 ;
      private string AV44Welcome_message ;
      private string AV12ErrDescription ;
      private bool AV19isSuccessful ;
      private string AV32MailTemplateBody ;
      private string AV23UserGAMGUID ;
      private string AV11baseUrl ;
      private string AV40GAMUserLanguage ;
      private string AV43Language ;
      private string AV27LinkURL ;
      private string AV24Username ;
      private string AV34Dear_Username ;
      private string AV38Instruction_Message ;
      private string AV33Button_Text ;
      private string AV35Expiration_Message ;
      private string AV36FollowUp_Message ;
      private string AV37Footer_Message ;
      private GeneXus.Mail.GXMailMessage AV20MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV9MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV22SMTPSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV15GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV39GAMApplication ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30GAMErrorCollection ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate AV31MailTemplate ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMErrorItem ;
      private bool aP1_isSuccessful ;
   }

}
