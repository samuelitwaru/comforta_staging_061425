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
   public class wwp_df_evaluateelementvisibility : GXProcedure
   {
      public wwp_df_evaluateelementvisibility( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_evaluateelementvisibility( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_WWPFormInstanceElementId ,
                           WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP2_VisibleCondition ,
                           out bool aP3_IsVisible )
      {
         this.AV12WWPFormInstance = aP0_WWPFormInstance;
         this.AV13WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV11VisibleCondition = aP2_VisibleCondition;
         this.AV10IsVisible = false ;
         initialize();
         ExecuteImpl();
         aP3_IsVisible=this.AV10IsVisible;
      }

      public bool executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                              short aP1_WWPFormInstanceElementId ,
                              WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP2_VisibleCondition )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementId, aP2_VisibleCondition, out aP3_IsVisible);
         return AV10IsVisible ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_WWPFormInstanceElementId ,
                                 WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP2_VisibleCondition ,
                                 out bool aP3_IsVisible )
      {
         this.AV12WWPFormInstance = aP0_WWPFormInstance;
         this.AV13WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV11VisibleCondition = aP2_VisibleCondition;
         this.AV10IsVisible = false ;
         SubmitImpl();
         aP3_IsVisible=this.AV10IsVisible;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsVisible = true;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11VisibleCondition.gxTpr_Expression))) )
         {
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluatecondition(context ).execute(  AV12WWPFormInstance,  AV11VisibleCondition,  false,  AV13WWPFormInstanceElementId,  "", out  AV9ConditionResult, out  AV8ConditionError) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ConditionError)) )
            {
               AV10IsVisible = AV9ConditionResult;
            }
            else
            {
               AV10IsVisible = true;
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
         AV8ConditionError = "";
         /* GeneXus formulas. */
      }

      private short AV13WWPFormInstanceElementId ;
      private bool AV10IsVisible ;
      private bool AV9ConditionResult ;
      private string AV8ConditionError ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV12WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV11VisibleCondition ;
      private bool aP3_IsVisible ;
   }

}
