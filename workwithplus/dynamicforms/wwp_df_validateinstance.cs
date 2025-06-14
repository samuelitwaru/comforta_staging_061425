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
   public class wwp_df_validateinstance : GXProcedure
   {
      public wwp_df_validateinstance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_validateinstance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           bool aP1_ReturnOnlyFormErrors ,
                           out bool aP2_HasErrors ,
                           out string aP3_ErrorIds ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages )
      {
         this.AV18WWPFormInstance = aP0_WWPFormInstance;
         this.AV16ReturnOnlyFormErrors = aP1_ReturnOnlyFormErrors;
         this.AV11HasErrors = false ;
         this.AV12ErrorIds = "" ;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP2_HasErrors=this.AV11HasErrors;
         aP3_ErrorIds=this.AV12ErrorIds;
         aP4_Messages=this.AV15Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                             bool aP1_ReturnOnlyFormErrors ,
                                                                             out bool aP2_HasErrors ,
                                                                             out string aP3_ErrorIds )
      {
         execute(aP0_WWPFormInstance, aP1_ReturnOnlyFormErrors, out aP2_HasErrors, out aP3_ErrorIds, out aP4_Messages);
         return AV15Messages ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 bool aP1_ReturnOnlyFormErrors ,
                                 out bool aP2_HasErrors ,
                                 out string aP3_ErrorIds ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages )
      {
         this.AV18WWPFormInstance = aP0_WWPFormInstance;
         this.AV16ReturnOnlyFormErrors = aP1_ReturnOnlyFormErrors;
         this.AV11HasErrors = false ;
         this.AV12ErrorIds = "" ;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP2_HasErrors=this.AV11HasErrors;
         aP3_ErrorIds=this.AV12ErrorIds;
         aP4_Messages=this.AV15Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV18WWPFormInstance.gxTpr_Wwpforminstanceid) )
         {
            AV10HasDeletedElements = false;
         }
         else
         {
            AV10HasDeletedElements = StringUtil.Contains( AV18WWPFormInstance.ToJSonString(true, true), "\"Mode\":\"DLT\"");
         }
         GXt_objcol_svchar1 = AV13HiddenContainers;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_calculatehiddencontainers(context ).execute(  AV18WWPFormInstance, out  GXt_objcol_svchar1) ;
         AV13HiddenContainers = GXt_objcol_svchar1;
         AV11HasErrors = false;
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV18WWPFormInstance.gxTpr_Element.Count )
         {
            AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV18WWPFormInstance.gxTpr_Element.Item(AV20GXV1));
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateelement(context ).execute(  AV18WWPFormInstance,  AV19WWPFormInstanceElement.ToJSonString(true, true),  AV10HasDeletedElements, ref  AV13HiddenContainers, out  AV8ElementHasErrors, out  AV9ElementMessages) ;
            if ( AV8ElementHasErrors )
            {
               AV11HasErrors = true;
               if ( AV16ReturnOnlyFormErrors )
               {
                  AV12ErrorIds += StringUtil.Trim( StringUtil.Str( (decimal)(AV19WWPFormInstanceElement.gxTpr_Wwpformelementid), 4, 0)) + "." + StringUtil.Trim( StringUtil.Str( (decimal)(AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid), 4, 0)) + "|";
               }
               else
               {
                  AV21GXV2 = 1;
                  while ( AV21GXV2 <= AV9ElementMessages.Count )
                  {
                     AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV9ElementMessages.Item(AV21GXV2));
                     AV15Messages.Add(AV14Message, 0);
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
               }
            }
            AV20GXV1 = (int)(AV20GXV1+1);
         }
         if ( AV16ReturnOnlyFormErrors && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ErrorIds)) )
         {
            AV12ErrorIds = "|" + AV12ErrorIds;
            AV11HasErrors = true;
         }
         if ( ! AV11HasErrors )
         {
            AV17Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
            AV17Validations.FromJSonString(AV18WWPFormInstance.gxTpr_Wwpformvalidations, null);
            if ( AV17Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV18WWPFormInstance,  0,  "",  AV17Validations, out  AV15Messages) ;
               if ( AV15Messages.Count > 0 )
               {
                  AV11HasErrors = true;
               }
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
         AV12ErrorIds = "";
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13HiddenContainers = new GxSimpleCollection<string>();
         GXt_objcol_svchar1 = new GxSimpleCollection<string>();
         AV19WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV9ElementMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV17Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private bool AV16ReturnOnlyFormErrors ;
      private bool AV11HasErrors ;
      private bool AV10HasDeletedElements ;
      private bool AV8ElementHasErrors ;
      private string AV12ErrorIds ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV18WWPFormInstance ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GxSimpleCollection<string> AV13HiddenContainers ;
      private GxSimpleCollection<string> GXt_objcol_svchar1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV19WWPFormInstanceElement ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ElementMessages ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV17Validations ;
      private bool aP2_HasErrors ;
      private string aP3_ErrorIds ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages ;
   }

}
