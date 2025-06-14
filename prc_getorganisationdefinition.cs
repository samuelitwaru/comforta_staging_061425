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
   public class prc_getorganisationdefinition : GXProcedure
   {
      public prc_getorganisationdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getorganisationdefinition( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_DefinitionKey ,
                           out string aP1_DefinitionValue )
      {
         this.AV8DefinitionKey = aP0_DefinitionKey;
         this.AV9DefinitionValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_DefinitionValue=this.AV9DefinitionValue;
      }

      public string executeUdp( string aP0_DefinitionKey )
      {
         execute(aP0_DefinitionKey, out aP1_DefinitionValue);
         return AV9DefinitionValue ;
      }

      public void executeSubmit( string aP0_DefinitionKey ,
                                 out string aP1_DefinitionValue )
      {
         this.AV8DefinitionKey = aP0_DefinitionKey;
         this.AV9DefinitionValue = "" ;
         SubmitImpl();
         aP1_DefinitionValue=this.AV9DefinitionValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV13language = context.GetLanguage( );
         AV12Trn_OrganisationSetting.Load(AV10WWPContext.gxTpr_Organisationsettingid, AV10WWPContext.gxTpr_Organisationid);
         if ( AV11SDT_OrganisationDefinitions.FromJSonString(AV12Trn_OrganisationSetting.gxTpr_Organisationdefinitions, null) )
         {
            if ( StringUtil.StrCmp(AV8DefinitionKey, "Receptionist") == 0 )
            {
               if ( StringUtil.StrCmp(AV13language, "Dutch") == 0 )
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Singular;
               }
               else
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Singular;
               }
            }
            else if ( StringUtil.StrCmp(AV8DefinitionKey, "Receptionists") == 0 )
            {
               if ( StringUtil.StrCmp(AV13language, "Dutch") == 0 )
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Plural;
               }
               else
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Plural;
               }
            }
            else if ( StringUtil.StrCmp(AV8DefinitionKey, "Resident") == 0 )
            {
               if ( StringUtil.StrCmp(AV13language, "Dutch") == 0 )
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Singular;
               }
               else
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Singular;
               }
            }
            else if ( StringUtil.StrCmp(AV8DefinitionKey, "Residents") == 0 )
            {
               if ( StringUtil.StrCmp(AV13language, "Dutch") == 0 )
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Plural;
               }
               else
               {
                  AV9DefinitionValue = AV11SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Plural;
               }
            }
            else
            {
               AV9DefinitionValue = AV8DefinitionKey;
            }
         }
         else
         {
            AV9DefinitionValue = AV8DefinitionKey;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DefinitionValue)) )
         {
            AV9DefinitionValue = AV8DefinitionKey;
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
         AV9DefinitionValue = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13language = "";
         AV12Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
         AV11SDT_OrganisationDefinitions = new SdtSDT_OrganisationDefinitions(context);
         /* GeneXus formulas. */
      }

      private string AV13language ;
      private string AV8DefinitionKey ;
      private string AV9DefinitionValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private SdtTrn_OrganisationSetting AV12Trn_OrganisationSetting ;
      private SdtSDT_OrganisationDefinitions AV11SDT_OrganisationDefinitions ;
      private string aP1_DefinitionValue ;
   }

}
