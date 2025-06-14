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
   public class wwp_df_executeelementvalidations : GXProcedure
   {
      public wwp_df_executeelementvalidations( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_executeelementvalidations( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_WWPFormInstanceElementId ,
                           string aP2_ThisElementValue ,
                           GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> aP3_Validations ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages )
      {
         this.AV15WWPFormInstance = aP0_WWPFormInstance;
         this.AV16WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV12ThisElementValue = aP2_ThisElementValue;
         this.AV14Validations = aP3_Validations;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP4_Messages=this.AV11Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                             short aP1_WWPFormInstanceElementId ,
                                                                             string aP2_ThisElementValue ,
                                                                             GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> aP3_Validations )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementId, aP2_ThisElementValue, aP3_Validations, out aP4_Messages);
         return AV11Messages ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_WWPFormInstanceElementId ,
                                 string aP2_ThisElementValue ,
                                 GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> aP3_Validations ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages )
      {
         this.AV15WWPFormInstance = aP0_WWPFormInstance;
         this.AV16WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV12ThisElementValue = aP2_ThisElementValue;
         this.AV14Validations = aP3_Validations;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP4_Messages=this.AV11Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV14Validations.Count )
         {
            AV13Validation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV14Validations.Item(AV17GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13Validation.gxTpr_Condition.gxTpr_Expression))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13Validation.gxTpr_Message))) )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluatecondition(context ).execute(  AV15WWPFormInstance,  AV13Validation.gxTpr_Condition,  false,  AV16WWPFormInstanceElementId,  AV12ThisElementValue, out  AV9ConditionResult, out  AV8ConditionError) ;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ConditionError)) || ! AV9ConditionResult )
               {
                  AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
                  AV10Message.gxTpr_Description = AV13Validation.gxTpr_Message;
                  AV10Message.gxTpr_Type = (short)((AV13Validation.gxTpr_Iserror ? 1 : 0));
                  AV11Messages.Add(AV10Message, 0);
               }
            }
            AV17GXV1 = (int)(AV17GXV1+1);
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
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         AV8ConditionError = "";
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private short AV16WWPFormInstanceElementId ;
      private int AV17GXV1 ;
      private bool AV9ConditionResult ;
      private string AV12ThisElementValue ;
      private string AV8ConditionError ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV15WWPFormInstance ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV14Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV13Validation ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP4_Messages ;
   }

}
