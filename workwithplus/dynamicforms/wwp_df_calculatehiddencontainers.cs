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
   public class wwp_df_calculatehiddencontainers : GXProcedure
   {
      public wwp_df_calculatehiddencontainers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_calculatehiddencontainers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           out GxSimpleCollection<string> aP1_HiddenContainers )
      {
         this.AV18WWPFormInstance = aP0_WWPFormInstance;
         this.AV14HiddenContainers = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_HiddenContainers=this.AV14HiddenContainers;
      }

      public GxSimpleCollection<string> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance )
      {
         execute(aP0_WWPFormInstance, out aP1_HiddenContainers);
         return AV14HiddenContainers ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 out GxSimpleCollection<string> aP1_HiddenContainers )
      {
         this.AV18WWPFormInstance = aP0_WWPFormInstance;
         this.AV14HiddenContainers = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_HiddenContainers=this.AV14HiddenContainers;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ContainerElements.Add(2, 0);
         AV10ContainerElements.Add(3, 0);
         AV10ContainerElements.Add(5, 0);
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV18WWPFormInstance.gxTpr_Element.Count )
         {
            AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV18WWPFormInstance.gxTpr_Element.Item(AV21GXV1));
            if ( ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementparentid > 0 ) && ( AV10ContainerElements.IndexOf(AV19WWPFormInstanceElement.gxTpr_Wwpformelementparenttype) != 0 ) )
            {
               if ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementparenttype == 3 )
               {
                  AV11ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV19WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.Str( (decimal)(0), 1, 0), "", "", "", "", "", "", "");
               }
               else
               {
                  AV11ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV19WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.LTrimStr( (decimal)(AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid), 4, 0), "", "", "", "", "", "", "");
               }
               if ( ( AV17VisibleContainers.IndexOf(AV11ContainerKey) == 0 ) && ( AV14HiddenContainers.IndexOf(AV11ContainerKey) == 0 ) )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementparent(context ).execute(  AV18WWPFormInstance.gxTpr_Wwpformid,  AV18WWPFormInstance.gxTpr_Wwpformversionnumber,  AV19WWPFormInstanceElement.gxTpr_Wwpformelementparentid, out  AV20WWPFormElementMetadata, out  AV12ContainerParentElementId, out  AV13ContainerParentElementType) ;
                  AV15Properties.FromJSonString(AV20WWPFormElementMetadata, null);
                  AV16VisibleCondition.FromJSonString(AV15Properties.Get("VisibleCondition"), null);
                  GXt_boolean1 = AV8IsVisible;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility_withparent(context ).execute(  AV18WWPFormInstance,  AV19WWPFormInstanceElement.gxTpr_Wwpformelementparentid,  AV19WWPFormInstanceElement.gxTpr_Wwpformelementparenttype,  AV12ContainerParentElementId,  AV13ContainerParentElementType,  AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV16VisibleCondition, ref  AV14HiddenContainers, out  GXt_boolean1) ;
                  AV8IsVisible = GXt_boolean1;
                  if ( AV8IsVisible )
                  {
                     AV17VisibleContainers.Add(AV11ContainerKey, 0);
                  }
                  else
                  {
                     AV14HiddenContainers.Add(AV11ContainerKey, 0);
                  }
               }
            }
            AV21GXV1 = (int)(AV21GXV1+1);
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
         AV14HiddenContainers = new GxSimpleCollection<string>();
         AV10ContainerElements = new GxSimpleCollection<short>();
         AV19WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV11ContainerKey = "";
         AV17VisibleContainers = new GxSimpleCollection<string>();
         AV20WWPFormElementMetadata = "";
         AV15Properties = new GXProperties();
         AV16VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         /* GeneXus formulas. */
      }

      private short AV12ContainerParentElementId ;
      private short AV13ContainerParentElementType ;
      private int AV21GXV1 ;
      private bool AV8IsVisible ;
      private bool GXt_boolean1 ;
      private string AV20WWPFormElementMetadata ;
      private string AV11ContainerKey ;
      private GXProperties AV15Properties ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV18WWPFormInstance ;
      private GxSimpleCollection<string> AV14HiddenContainers ;
      private GxSimpleCollection<short> AV10ContainerElements ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV19WWPFormInstanceElement ;
      private GxSimpleCollection<string> AV17VisibleContainers ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV16VisibleCondition ;
      private GxSimpleCollection<string> aP1_HiddenContainers ;
   }

}
