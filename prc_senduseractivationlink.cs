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
   public class prc_senduseractivationlink : GXProcedure
   {
      public prc_senduseractivationlink( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_senduseractivationlink( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGAMGUID ,
                           string aP1_ActivactionKey ,
                           string aP2_baseUrl ,
                           ref bool aP3_isSuccessful ,
                           ref string aP4_ErrDescription ,
                           ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrors )
      {
         this.AV18UserGAMGUID = aP0_UserGAMGUID;
         this.AV9ActivactionKey = aP1_ActivactionKey;
         this.AV23baseUrl = aP2_baseUrl;
         this.AV14isSuccessful = aP3_isSuccessful;
         this.AV26ErrDescription = aP4_ErrDescription;
         this.AV11GAMErrors = aP5_GAMErrors;
         initialize();
         ExecuteImpl();
         aP3_isSuccessful=this.AV14isSuccessful;
         aP4_ErrDescription=this.AV26ErrDescription;
         aP5_GAMErrors=this.AV11GAMErrors;
      }

      public GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> executeUdp( string aP0_UserGAMGUID ,
                                                                                            string aP1_ActivactionKey ,
                                                                                            string aP2_baseUrl ,
                                                                                            ref bool aP3_isSuccessful ,
                                                                                            ref string aP4_ErrDescription )
      {
         execute(aP0_UserGAMGUID, aP1_ActivactionKey, aP2_baseUrl, ref aP3_isSuccessful, ref aP4_ErrDescription, ref aP5_GAMErrors);
         return AV11GAMErrors ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 string aP1_ActivactionKey ,
                                 string aP2_baseUrl ,
                                 ref bool aP3_isSuccessful ,
                                 ref string aP4_ErrDescription ,
                                 ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrors )
      {
         this.AV18UserGAMGUID = aP0_UserGAMGUID;
         this.AV9ActivactionKey = aP1_ActivactionKey;
         this.AV23baseUrl = aP2_baseUrl;
         this.AV14isSuccessful = aP3_isSuccessful;
         this.AV26ErrDescription = aP4_ErrDescription;
         this.AV11GAMErrors = aP5_GAMErrors;
         SubmitImpl();
         aP3_isSuccessful=this.AV14isSuccessful;
         aP4_ErrDescription=this.AV26ErrDescription;
         aP5_GAMErrors=this.AV11GAMErrors;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV16Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV12GAMUser.load( AV18UserGAMGUID);
            if ( AV12GAMUser.success() )
            {
               AV41GAMUserLanguage = AV12GAMUser.gxTpr_Language;
               GXt_char1 = AV42ResidentLanguage;
               new prc_getresidentlanguagefromguid(context ).execute(  AV18UserGAMGUID, out  GXt_char1) ;
               AV42ResidentLanguage = GXt_char1;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41GAMUserLanguage)) )
               {
                  AV28language = AV41GAMUserLanguage;
               }
               else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResidentLanguage)) )
               {
                  if ( StringUtil.StrCmp(AV42ResidentLanguage, "nl") == 0 )
                  {
                     AV28language = "Dutch";
                  }
                  else if ( StringUtil.StrCmp(AV42ResidentLanguage, "en") == 0 )
                  {
                     AV28language = "English";
                  }
                  else
                  {
                     AV28language = "Dutch";
                  }
               }
               else
               {
                  AV28language = "Dutch";
               }
               AV19Username = AV12GAMUser.gxTpr_Firstname + " " + AV12GAMUser.gxTpr_Lastname;
               if ( AV11GAMErrors.Count == 0 )
               {
                  AV39MailTemplate.Load("MailActivation");
                  if ( AV39MailTemplate.Success() )
                  {
                     AV40MailTemplateBody = AV39MailTemplate.gxTpr_Wwpmailtemplatebody;
                  }
                  AV17SMTPSession.Host = context.GetMessage( "comforta.yukon.software", "");
                  AV17SMTPSession.Port = 465;
                  AV17SMTPSession.Secure = 1;
                  AV17SMTPSession.Authentication = 0;
                  AV17SMTPSession.AuthenticationMethod = "";
                  AV17SMTPSession.UserName = context.GetMessage( "no-reply@comforta.yukon.software", "");
                  AV17SMTPSession.Password = context.GetMessage( "2uSFuxkquz", "");
                  AV17SMTPSession.Sender.Address = context.GetMessage( "no-reply@comforta.yukon.software", "");
                  AV17SMTPSession.Sender.Name = "Comforta Software";
                  AV8MailRecipient.Address = AV12GAMUser.gxTpr_Email;
                  AV8MailRecipient.Name = AV19Username;
                  AV38BaseUrl_Link = "" + AV23baseUrl + context.GetMessage( "WP_UserActivation.aspx?ActivationKey=", "") + AV9ActivactionKey + context.GetMessage( "&GamGuid=", "") + AV12GAMUser.gxTpr_Guid;
                  if ( StringUtil.StrCmp(AV28language, "English") == 0 )
                  {
                     AV15MailMessage.Subject = "Welcome to Comforta";
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40MailTemplateBody)) )
                     {
                        AV15MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+context.GetMessage( "<div style=\"background-color: #222F54; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear ", "")+AV19Username+context.GetMessage( ",</p><p>Welcome to Comforta Software! We are thrilled to have you on board.</p><p>To get started, we need to verify your email address. Please click the button below to activate your account:</p>", "")+context.GetMessage( "</b></p><a href=\"", "")+AV38BaseUrl_Link+context.GetMessage( "\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #222F54; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Verify Email</a>", "")+context.GetMessage( "<p>Please note that the link expires in 36 hours.</p>", "")+context.GetMessage( "<p>Once you have activated your account and set a password, you will gain access to the platform.</p>", "")+context.GetMessage( "<br><p>Many thanks and kind regards,</p><p>Comforta Software</p></div></div>", "");
                     }
                     else
                     {
                        AV31Dear_Username = "Dear " + AV19Username;
                        AV32Welcome_Message = "Welcome to Comforta Software! We are thrilled to have you on board.";
                        AV33Instruction_Message = "To get started, we need to verify your email address. Please click the button below to activate your account:";
                        AV37Button_Text = "Verify Email";
                        AV34Expiration_Message = "Please note that the link expires in 36 hours.";
                        AV35FollowUp_Message = "Once you have activated your account and set a password, you will gain access to the platform.";
                        AV36Footer_Message = "Many thanks and kind regards";
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[DEAR_USERNAME]", AV31Dear_Username);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[WELCOME_MESSAGE]", AV32Welcome_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[INSTRUCTION_MESSAGE]", AV33Instruction_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[BUTTON_TEXT]", AV37Button_Text);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[EXPIRATION_MESSAGE]", AV34Expiration_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[FOLLOWUP_INSTRUCTION]", AV35FollowUp_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[FOOTER_MESSAGE]", AV36Footer_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[LINK]", AV38BaseUrl_Link);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[BASE_URL]", AV23baseUrl);
                        AV15MailMessage.HTMLText = AV40MailTemplateBody;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28language, "Dutch") == 0 )
                  {
                     AV15MailMessage.Subject = "Welkom bij Comforta";
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40MailTemplateBody)) )
                     {
                        AV15MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+context.GetMessage( "<div style=\"background-color: #222F54; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Comforta Software</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Beste ", "")+AV19Username+context.GetMessage( ",</p><p>Welkom bij Comforta Software! We kijken ernaar uit om u van dienst te zijn.</p><p>Om te beginnen verifiëren we uw e-mailadres. Klik op de knop hieronder om uw account te activeren:</p>", "")+context.GetMessage( "</b></p><a href=\"", "")+AV38BaseUrl_Link+context.GetMessage( "\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #222F54; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Email verifiëren</a>", "")+context.GetMessage( "<p>Houd er rekening mee dat de link over 36 uur verloopt.</p>", "")+context.GetMessage( "<p>Zodra u uw account heeft geactiveerd en een wachtwoord heeft ingesteld, krijgt u toegang tot het platform.</p>", "")+context.GetMessage( "<br><p>Hartelijk dank en groeten,</p><p>Comforta Software</p></div></div>", "");
                     }
                     else
                     {
                        AV31Dear_Username = "Beste " + AV19Username;
                        AV32Welcome_Message = "Welkom bij Comforta Software! We kijken ernaar uit om u van dienst te zijn.";
                        AV33Instruction_Message = "Om te beginnen verifiëren we uw e-mailadres. Klik op de knop hieronder om uw account te activeren:";
                        AV37Button_Text = "Email verifiëren";
                        AV34Expiration_Message = "Houd er rekening mee dat de link over 36 uur verloopt.";
                        AV35FollowUp_Message = "Zodra u uw account heeft geactiveerd en een wachtwoord heeft ingesteld, krijgt u toegang tot het platform.";
                        AV36Footer_Message = "Hartelijk dank en groeten";
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[DEAR_USERNAME]", AV31Dear_Username);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[WELCOME_MESSAGE]", AV32Welcome_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[INSTRUCTION_MESSAGE]", AV33Instruction_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[BUTTON_TEXT]", AV37Button_Text);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[EXPIRATION_MESSAGE]", AV34Expiration_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[FOLLOWUP_INSTRUCTION]", AV35FollowUp_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[FOOTER_MESSAGE]", AV36Footer_Message);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[LINK]", AV38BaseUrl_Link);
                        AV40MailTemplateBody = StringUtil.StringReplace( AV40MailTemplateBody, "[BASE_URL]", AV23baseUrl);
                        AV15MailMessage.HTMLText = AV40MailTemplateBody;
                     }
                  }
                  AV15MailMessage.To.Add(AV8MailRecipient);
                  AV17SMTPSession.Login();
                  AV17SMTPSession.Send(AV15MailMessage);
                  if ( ( AV17SMTPSession.ErrCode < 1 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV17SMTPSession.ErrDescription), context.GetMessage( "OK", "")) == 0 ) )
                  {
                     AV17SMTPSession.Logout();
                     AV14isSuccessful = true;
                  }
                  else
                  {
                     AV26ErrDescription = context.GetMessage( "Sending activation email failed - ", "") + StringUtil.Str( (decimal)(AV17SMTPSession.ErrCode), 10, 2) + " " + AV17SMTPSession.ErrDescription;
                     AV14isSuccessful = false;
                  }
               }
               else
               {
                  AV26ErrDescription = context.GetMessage( "Sending activation email failed - ", "");
                  AV43GXV1 = 1;
                  while ( AV43GXV1 <= AV11GAMErrors.Count )
                  {
                     AV25GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrors.Item(AV43GXV1));
                     AV26ErrDescription += AV25GAMErrorItem.gxTpr_Message + " ";
                     AV43GXV1 = (int)(AV43GXV1+1);
                  }
                  AV14isSuccessful = false;
               }
            }
            else
            {
               AV26ErrDescription = context.GetMessage( "Failed to load user", "");
               AV14isSuccessful = false;
            }
         }
         else
         {
            AV26ErrDescription = context.GetMessage( "Unknown user activation method - ", "") + AV16Repository.gxTpr_Useractivationmethod + " - " + "U";
            AV14isSuccessful = false;
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
         AV16Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV41GAMUserLanguage = "";
         AV42ResidentLanguage = "";
         GXt_char1 = "";
         AV28language = "";
         AV19Username = "";
         AV39MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         AV40MailTemplateBody = "";
         AV17SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV8MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV38BaseUrl_Link = "";
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV31Dear_Username = "";
         AV32Welcome_Message = "";
         AV33Instruction_Message = "";
         AV37Button_Text = "";
         AV34Expiration_Message = "";
         AV35FollowUp_Message = "";
         AV36Footer_Message = "";
         AV25GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV43GXV1 ;
      private string AV9ActivactionKey ;
      private string AV26ErrDescription ;
      private string AV42ResidentLanguage ;
      private string GXt_char1 ;
      private bool AV14isSuccessful ;
      private string AV40MailTemplateBody ;
      private string AV18UserGAMGUID ;
      private string AV23baseUrl ;
      private string AV41GAMUserLanguage ;
      private string AV28language ;
      private string AV19Username ;
      private string AV38BaseUrl_Link ;
      private string AV31Dear_Username ;
      private string AV32Welcome_Message ;
      private string AV33Instruction_Message ;
      private string AV37Button_Text ;
      private string AV34Expiration_Message ;
      private string AV35FollowUp_Message ;
      private string AV36Footer_Message ;
      private GeneXus.Mail.GXMailMessage AV15MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV8MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV17SMTPSession ;
      private bool aP3_isSuccessful ;
      private string aP4_ErrDescription ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV16Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate AV39MailTemplate ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV25GAMErrorItem ;
   }

}
