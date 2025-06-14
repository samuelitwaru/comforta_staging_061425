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
   public class gam_gettextpasswordrequirement : GXProcedure
   {
      public gam_gettextpasswordrequirement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gam_gettextpasswordrequirement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_TextHTML )
      {
         this.AV15TextHTML = "" ;
         initialize();
         ExecuteImpl();
         aP0_TextHTML=this.AV15TextHTML;
      }

      public string executeUdp( )
      {
         execute(out aP0_TextHTML);
         return AV15TextHTML ;
      }

      public void executeSubmit( out string aP0_TextHTML )
      {
         this.AV15TextHTML = "" ;
         SubmitImpl();
         aP0_TextHTML=this.AV15TextHTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15TextHTML = "";
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV9GAMErrorCollection);
         if ( (0==AV10GAMSession.gxTpr_Securitypolicy.gxTpr_Id) )
         {
            AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            AV13SecurityPolicyId = AV12GAMRepository.gxTpr_Defaultsecuritypolicyid;
         }
         else
         {
            AV13SecurityPolicyId = AV10GAMSession.gxTpr_Securitypolicy.gxTpr_Id;
         }
         if ( ! (0==AV13SecurityPolicyId) )
         {
            AV11GAMSecurityPolicy.load( AV13SecurityPolicyId);
            AV8aText.Clear();
            if ( AV11GAMSecurityPolicy.success() )
            {
               if ( AV11GAMSecurityPolicy.gxTpr_Minimumlengthpassword > 0 )
               {
                  AV14Text = StringUtil.Format( context.GetMessage( "GAM_Passwordmustbeatleast1characterslong", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumlengthpassword), 2, 0)), "", "", "", "", "", "", "", "");
                  AV8aText.Add(AV14Text, 0);
               }
               if ( AV11GAMSecurityPolicy.gxTpr_Minimumuppercasecharacterspassword > 0 )
               {
                  if ( AV11GAMSecurityPolicy.gxTpr_Minimumuppercasecharacterspassword == 1 )
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbeanuppercaseletter", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumuppercasecharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  else
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbeuppercaseletters", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumuppercasecharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  AV8aText.Add(AV14Text, 0);
               }
               if ( AV11GAMSecurityPolicy.gxTpr_Minimumnumericcharacterspassword > 0 )
               {
                  if ( AV11GAMSecurityPolicy.gxTpr_Minimumnumericcharacterspassword == 1 )
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbeanumber", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumnumericcharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  else
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbenumbers", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumnumericcharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  AV8aText.Add(AV14Text, 0);
               }
               if ( AV11GAMSecurityPolicy.gxTpr_Minimumspecialcharacterspassword > 0 )
               {
                  if ( AV11GAMSecurityPolicy.gxTpr_Minimumspecialcharacterspassword == 1 )
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbeaspecialcharacter", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumspecialcharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  else
                  {
                     AV14Text = StringUtil.Format( context.GetMessage( "GAM_Atleast1mustbespecialcharacters", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11GAMSecurityPolicy.gxTpr_Minimumspecialcharacterspassword), 2, 0)), "", "", "", "", "", "", "", "");
                  }
                  AV8aText.Add(AV14Text, 0);
               }
            }
            if ( AV8aText.Count > 0 )
            {
               AV15TextHTML = "<ul style=\"list-style-type: none; margin: 0; padding: 0; margin-top: -13px;\">";
               AV16GXV1 = 1;
               while ( AV16GXV1 <= AV8aText.Count )
               {
                  AV14Text = ((string)AV8aText.Item(AV16GXV1));
                  AV15TextHTML += StringUtil.Format( "<li>%1</li>", StringUtil.Trim( AV14Text), "", "", "", "", "", "", "", "");
                  AV16GXV1 = (int)(AV16GXV1+1);
               }
               AV15TextHTML += "</ul>";
            }
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
         AV15TextHTML = "";
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11GAMSecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV8aText = new GxSimpleCollection<string>();
         AV14Text = "";
         /* GeneXus formulas. */
      }

      private int AV13SecurityPolicyId ;
      private int AV16GXV1 ;
      private string AV15TextHTML ;
      private string AV14Text ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV10GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV12GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV11GAMSecurityPolicy ;
      private GxSimpleCollection<string> AV8aText ;
      private string aP0_TextHTML ;
   }

}
