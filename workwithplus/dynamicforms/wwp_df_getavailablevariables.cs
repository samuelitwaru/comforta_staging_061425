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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_getavailablevariables : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_df_getavailablevariables_Services_Execute" ;
         }

      }

      public wwp_df_getavailablevariables( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getavailablevariables( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_SessionId ,
                           bool aP1_IncludeCurrentElement ,
                           short aP2_CurrentElementId ,
                           short aP3_MaxOptions ,
                           string aP4_SearchTxt ,
                           out string aP5_OptionsJson )
      {
         this.AV20SessionId = aP0_SessionId;
         this.AV13IncludeCurrentElement = aP1_IncludeCurrentElement;
         this.AV9CurrentElementId = aP2_CurrentElementId;
         this.AV14MaxOptions = aP3_MaxOptions;
         this.AV19SearchTxt = aP4_SearchTxt;
         this.AV17OptionsJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_OptionsJson=this.AV17OptionsJson;
      }

      public string executeUdp( short aP0_SessionId ,
                                bool aP1_IncludeCurrentElement ,
                                short aP2_CurrentElementId ,
                                short aP3_MaxOptions ,
                                string aP4_SearchTxt )
      {
         execute(aP0_SessionId, aP1_IncludeCurrentElement, aP2_CurrentElementId, aP3_MaxOptions, aP4_SearchTxt, out aP5_OptionsJson);
         return AV17OptionsJson ;
      }

      public void executeSubmit( short aP0_SessionId ,
                                 bool aP1_IncludeCurrentElement ,
                                 short aP2_CurrentElementId ,
                                 short aP3_MaxOptions ,
                                 string aP4_SearchTxt ,
                                 out string aP5_OptionsJson )
      {
         this.AV20SessionId = aP0_SessionId;
         this.AV13IncludeCurrentElement = aP1_IncludeCurrentElement;
         this.AV9CurrentElementId = aP2_CurrentElementId;
         this.AV14MaxOptions = aP3_MaxOptions;
         this.AV19SearchTxt = aP4_SearchTxt;
         this.AV17OptionsJson = "" ;
         SubmitImpl();
         aP5_OptionsJson=this.AV17OptionsJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Options = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         GXt_SdtWWP_Form1 = AV21WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV20SessionId, out  GXt_SdtWWP_Form1) ;
         AV21WWPForm = GXt_SdtWWP_Form1;
         GXt_int2 = AV10CurrentElementMultipleDataId;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getparentmultipledataid(context ).execute( ref  AV21WWPForm,  AV9CurrentElementId, out  GXt_int2) ;
         AV10CurrentElementMultipleDataId = GXt_int2;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV21WWPForm.gxTpr_Element.Count )
         {
            AV11Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV21WWPForm.gxTpr_Element.Item(AV23GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Element.gxTpr_Wwpformelementreferenceid)) && ( AV11Element.gxTpr_Wwpformelementid != AV9CurrentElementId ) && ( String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxt)) || StringUtil.Contains( StringUtil.Lower( AV11Element.gxTpr_Wwpformelementreferenceid), StringUtil.Lower( AV19SearchTxt)) ) )
            {
               GXt_int2 = AV12ElementMultipleDataId;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getparentmultipledataid(context ).execute( ref  AV21WWPForm,  AV11Element.gxTpr_Wwpformelementid, out  GXt_int2) ;
               AV12ElementMultipleDataId = GXt_int2;
               if ( (0==AV12ElementMultipleDataId) || ( AV12ElementMultipleDataId == AV10CurrentElementMultipleDataId ) )
               {
                  AV15Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
                  AV15Option.gxTpr_Id = AV11Element.gxTpr_Wwpformelementreferenceid+((AV11Element.gxTpr_Wwpformelementtype==3) ? "_Repetitions" : "");
                  AV15Option.gxTpr_Displayname = AV15Option.gxTpr_Id;
                  AV15Option.gxTpr_Text.Add(AV15Option.gxTpr_Id, 0);
                  AV16Options.Add(AV15Option, 0);
               }
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         if ( AV21WWPForm.gxTpr_Wwpformtype == 1 )
         {
            AV18SectionReferencedElements.FromJSonString(AV21WWPForm.gxTpr_Wwpformsectionrefelements, null);
            AV8Property = AV18SectionReferencedElements.GetFirst();
            while ( ! AV18SectionReferencedElements.Eof() )
            {
               AV15Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
               AV15Option.gxTpr_Id = AV8Property.Key;
               AV15Option.gxTpr_Displayname = AV15Option.gxTpr_Id;
               AV15Option.gxTpr_Text.Add(AV15Option.gxTpr_Id, 0);
               AV16Options.Add(AV15Option, 0);
               AV8Property = AV18SectionReferencedElements.GetNext();
            }
         }
         AV15Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
         AV15Option.gxTpr_Id = "Today";
         AV15Option.gxTpr_Displayname = AV15Option.gxTpr_Id;
         AV15Option.gxTpr_Text.Add(AV15Option.gxTpr_Id, 0);
         AV16Options.Add(AV15Option, 0);
         if ( AV13IncludeCurrentElement )
         {
            AV15Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
            AV15Option.gxTpr_Id = "Value";
            AV15Option.gxTpr_Displayname = AV15Option.gxTpr_Id;
            AV15Option.gxTpr_Text.Add(AV15Option.gxTpr_Id, 0);
            AV16Options.Add(AV15Option, 0);
         }
         AV16Options.Sort("DisplayName");
         while ( AV16Options.Count > AV14MaxOptions )
         {
            AV16Options.RemoveItem(AV16Options.Count);
         }
         AV17OptionsJson = AV16Options.ToJSonString(false);
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
         AV17OptionsJson = "";
         AV16Options = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         AV21WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV11Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV15Option = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
         AV18SectionReferencedElements = new GXProperties();
         AV8Property = new GxKeyValuePair();
         /* GeneXus formulas. */
      }

      private short AV20SessionId ;
      private short AV9CurrentElementId ;
      private short AV14MaxOptions ;
      private short AV10CurrentElementMultipleDataId ;
      private short AV12ElementMultipleDataId ;
      private short GXt_int2 ;
      private int AV23GXV1 ;
      private bool AV13IncludeCurrentElement ;
      private string AV17OptionsJson ;
      private string AV19SearchTxt ;
      private GXProperties AV18SectionReferencedElements ;
      private GxKeyValuePair AV8Property ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> AV16Options ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV21WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV11Element ;
      private WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem AV15Option ;
      private string aP5_OptionsJson ;
   }

}
