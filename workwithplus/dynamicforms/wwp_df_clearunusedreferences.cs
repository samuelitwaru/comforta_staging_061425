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
   public class wwp_df_clearunusedreferences : GXProcedure
   {
      public wwp_df_clearunusedreferences( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_clearunusedreferences( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance )
      {
         this.AV8WWPFormInstance = aP0_WWPFormInstance;
         initialize();
         ExecuteImpl();
         aP0_WWPFormInstance=this.AV8WWPFormInstance;
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance executeUdp( )
      {
         execute(ref aP0_WWPFormInstance);
         return AV8WWPFormInstance ;
      }

      public void executeSubmit( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance )
      {
         this.AV8WWPFormInstance = aP0_WWPFormInstance;
         SubmitImpl();
         aP0_WWPFormInstance=this.AV8WWPFormInstance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WWPForm.Load(AV8WWPFormInstance.gxTpr_Wwpformid, AV8WWPFormInstance.gxTpr_Wwpformversionnumber);
         AV11WWPFormJson = StringUtil.Lower( AV9WWPForm.ToJSonString(true, true));
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8WWPFormInstance.gxTpr_Element.Count )
         {
            AV10WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV8WWPFormInstance.gxTpr_Element.Item(AV12GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid))) && ! StringUtil.Contains( AV11WWPFormJson, "\\\""+StringUtil.Lower( StringUtil.Trim( AV10WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid))+"\\\"") && ( ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementtype != 1 ) || ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype != 3 ) || ! StringUtil.Contains( AV11WWPFormJson, "\\\"elementid\\\":"+StringUtil.Trim( StringUtil.Str( (decimal)(AV10WWPFormInstanceElement.gxTpr_Wwpformelementid), 4, 0))) ) )
            {
               AV10WWPFormInstanceElement.FromJSonString(StringUtil.StringReplace( StringUtil.StringReplace( AV10WWPFormInstanceElement.ToJSonString(true, true), "\"WWPFormElementReferenceId\":\""+AV10WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid+"\"", "\"WWPFormElementReferenceId\":\"\""), "\"WWPFormElementReferenceId_Z\":\""+AV10WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid+"\"", "\"WWPFormElementReferenceId_Z\":\"\""), null);
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV9WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV11WWPFormJson = "";
         AV10WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV11WWPFormJson ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV8WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV9WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV10WWPFormInstanceElement ;
   }

}
