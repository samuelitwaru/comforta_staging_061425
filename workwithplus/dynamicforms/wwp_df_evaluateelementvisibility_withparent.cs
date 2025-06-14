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
   public class wwp_df_evaluateelementvisibility_withparent : GXProcedure
   {
      public wwp_df_evaluateelementvisibility_withparent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_evaluateelementvisibility_withparent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_WWPFormElementId ,
                           short aP2_WWPFormElementType ,
                           short aP3_WWPFormElementParentId ,
                           short aP4_WWPFormElementParentType ,
                           short aP5_WWPFormInstanceElementId ,
                           WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP6_VisibleCondition ,
                           ref GxSimpleCollection<string> aP7_HiddenContainers ,
                           out bool aP8_IsVisible )
      {
         this.AV12WWPFormInstance = aP0_WWPFormInstance;
         this.AV8WWPFormElementId = aP1_WWPFormElementId;
         this.AV11WWPFormElementType = aP2_WWPFormElementType;
         this.AV9WWPFormElementParentId = aP3_WWPFormElementParentId;
         this.AV10WWPFormElementParentType = aP4_WWPFormElementParentType;
         this.AV18WWPFormInstanceElementId = aP5_WWPFormInstanceElementId;
         this.AV19VisibleCondition = aP6_VisibleCondition;
         this.AV16HiddenContainers = aP7_HiddenContainers;
         this.AV17IsVisible = false ;
         initialize();
         ExecuteImpl();
         aP7_HiddenContainers=this.AV16HiddenContainers;
         aP8_IsVisible=this.AV17IsVisible;
      }

      public bool executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                              short aP1_WWPFormElementId ,
                              short aP2_WWPFormElementType ,
                              short aP3_WWPFormElementParentId ,
                              short aP4_WWPFormElementParentType ,
                              short aP5_WWPFormInstanceElementId ,
                              WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP6_VisibleCondition ,
                              ref GxSimpleCollection<string> aP7_HiddenContainers )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormElementId, aP2_WWPFormElementType, aP3_WWPFormElementParentId, aP4_WWPFormElementParentType, aP5_WWPFormInstanceElementId, aP6_VisibleCondition, ref aP7_HiddenContainers, out aP8_IsVisible);
         return AV17IsVisible ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_WWPFormElementId ,
                                 short aP2_WWPFormElementType ,
                                 short aP3_WWPFormElementParentId ,
                                 short aP4_WWPFormElementParentType ,
                                 short aP5_WWPFormInstanceElementId ,
                                 WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP6_VisibleCondition ,
                                 ref GxSimpleCollection<string> aP7_HiddenContainers ,
                                 out bool aP8_IsVisible )
      {
         this.AV12WWPFormInstance = aP0_WWPFormInstance;
         this.AV8WWPFormElementId = aP1_WWPFormElementId;
         this.AV11WWPFormElementType = aP2_WWPFormElementType;
         this.AV9WWPFormElementParentId = aP3_WWPFormElementParentId;
         this.AV10WWPFormElementParentType = aP4_WWPFormElementParentType;
         this.AV18WWPFormInstanceElementId = aP5_WWPFormInstanceElementId;
         this.AV19VisibleCondition = aP6_VisibleCondition;
         this.AV16HiddenContainers = aP7_HiddenContainers;
         this.AV17IsVisible = false ;
         SubmitImpl();
         aP7_HiddenContainers=this.AV16HiddenContainers;
         aP8_IsVisible=this.AV17IsVisible;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13ContainerElements.Add(2, 0);
         AV13ContainerElements.Add(3, 0);
         AV13ContainerElements.Add(5, 0);
         AV14CurrentItemId = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV8WWPFormElementId), 4, 0), StringUtil.LTrimStr( (decimal)(AV18WWPFormInstanceElementId), 4, 0), "", "", "", "", "", "", "");
         if ( AV10WWPFormElementParentType == 3 )
         {
            AV15CurrentParentId = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementParentId), 4, 0), StringUtil.Str( (decimal)(0), 1, 0), "", "", "", "", "", "", "");
         }
         else
         {
            AV15CurrentParentId = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV9WWPFormElementParentId), 4, 0), StringUtil.LTrimStr( (decimal)(AV18WWPFormInstanceElementId), 4, 0), "", "", "", "", "", "", "");
         }
         GXt_boolean1 = AV17IsVisible;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context ).execute(  AV12WWPFormInstance,  AV18WWPFormInstanceElementId,  AV19VisibleCondition, out  GXt_boolean1) ;
         AV17IsVisible = (bool)((AV16HiddenContainers.IndexOf(AV14CurrentItemId)==0)&&(AV16HiddenContainers.IndexOf(AV15CurrentParentId)==0)&&GXt_boolean1);
         if ( ! AV17IsVisible && ! (0==AV8WWPFormElementId) && ( AV13ContainerElements.IndexOf(AV11WWPFormElementType) != 0 ) && ( AV16HiddenContainers.IndexOf(AV14CurrentItemId) == 0 ) )
         {
            AV16HiddenContainers.Add(AV14CurrentItemId, 0);
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
         AV13ContainerElements = new GxSimpleCollection<short>();
         AV14CurrentItemId = "";
         AV15CurrentParentId = "";
         /* GeneXus formulas. */
      }

      private short AV8WWPFormElementId ;
      private short AV11WWPFormElementType ;
      private short AV9WWPFormElementParentId ;
      private short AV10WWPFormElementParentType ;
      private short AV18WWPFormInstanceElementId ;
      private bool AV17IsVisible ;
      private bool GXt_boolean1 ;
      private string AV14CurrentItemId ;
      private string AV15CurrentParentId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV12WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV19VisibleCondition ;
      private GxSimpleCollection<string> AV16HiddenContainers ;
      private GxSimpleCollection<string> aP7_HiddenContainers ;
      private GxSimpleCollection<short> AV13ContainerElements ;
      private bool aP8_IsVisible ;
   }

}
