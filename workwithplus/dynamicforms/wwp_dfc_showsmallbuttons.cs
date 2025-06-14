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
   public class wwp_dfc_showsmallbuttons : GXProcedure
   {
      public wwp_dfc_showsmallbuttons( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_dfc_showsmallbuttons( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           short aP1_WWPFormElementParentId ,
                           bool aP2_IsContainerElement ,
                           out bool aP3_IsInsideGridMultiple ,
                           out bool aP4_ShowSmallButtons )
      {
         this.AV13WWPForm = aP0_WWPForm;
         this.AV15WWPFormElementParentId = aP1_WWPFormElementParentId;
         this.AV19IsContainerElement = aP2_IsContainerElement;
         this.AV9IsInsideGridMultiple = false ;
         this.AV11ShowSmallButtons = false ;
         initialize();
         ExecuteImpl();
         aP0_WWPForm=this.AV13WWPForm;
         aP3_IsInsideGridMultiple=this.AV9IsInsideGridMultiple;
         aP4_ShowSmallButtons=this.AV11ShowSmallButtons;
      }

      public bool executeUdp( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                              short aP1_WWPFormElementParentId ,
                              bool aP2_IsContainerElement ,
                              out bool aP3_IsInsideGridMultiple )
      {
         execute(ref aP0_WWPForm, aP1_WWPFormElementParentId, aP2_IsContainerElement, out aP3_IsInsideGridMultiple, out aP4_ShowSmallButtons);
         return AV11ShowSmallButtons ;
      }

      public void executeSubmit( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 short aP1_WWPFormElementParentId ,
                                 bool aP2_IsContainerElement ,
                                 out bool aP3_IsInsideGridMultiple ,
                                 out bool aP4_ShowSmallButtons )
      {
         this.AV13WWPForm = aP0_WWPForm;
         this.AV15WWPFormElementParentId = aP1_WWPFormElementParentId;
         this.AV19IsContainerElement = aP2_IsContainerElement;
         this.AV9IsInsideGridMultiple = false ;
         this.AV11ShowSmallButtons = false ;
         SubmitImpl();
         aP0_WWPForm=this.AV13WWPForm;
         aP3_IsInsideGridMultiple=this.AV9IsInsideGridMultiple;
         aP4_ShowSmallButtons=this.AV11ShowSmallButtons;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17Columns = 1;
         AV14WWPFormElementId = AV15WWPFormElementParentId;
         while ( ! AV11ShowSmallButtons && ! (0==AV14WWPFormElementId) )
         {
            GXt_SdtWWP_Form_Element1 = AV10ParentElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV13WWPForm,  AV14WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV10ParentElement = GXt_SdtWWP_Form_Element1;
            AV18ElementColumns = 1;
            if ( AV10ParentElement.gxTpr_Wwpformelementtype == 2 )
            {
               AV12WWP_DF_GroupMetadata.FromJSonString(AV10ParentElement.gxTpr_Wwpformelementmetadata, null);
               AV18ElementColumns = AV12WWP_DF_GroupMetadata.gxTpr_Columns;
            }
            else if ( AV10ParentElement.gxTpr_Wwpformelementtype == 3 )
            {
               AV8WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV10ParentElement.gxTpr_Wwpformelementmetadata, null);
               if ( AV8WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype == 2 )
               {
                  AV9IsInsideGridMultiple = true;
                  AV11ShowSmallButtons = true;
               }
               else
               {
                  AV18ElementColumns = AV8WWP_DF_ElementsRepeaterMetadata.gxTpr_Columns;
               }
            }
            else if ( AV10ParentElement.gxTpr_Wwpformelementtype == 5 )
            {
               AV16WWP_DF_StepMetadata.FromJSonString(AV10ParentElement.gxTpr_Wwpformelementmetadata, null);
               AV18ElementColumns = AV16WWP_DF_StepMetadata.gxTpr_Columns;
            }
            if ( AV18ElementColumns > 1 )
            {
               AV17Columns = (short)(AV17Columns+AV18ElementColumns-1);
               if ( AV19IsContainerElement || ( AV17Columns > 2 ) )
               {
                  AV11ShowSmallButtons = true;
               }
            }
            AV14WWPFormElementId = AV10ParentElement.gxTpr_Wwpformelementparentid;
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
         AV10ParentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV12WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV8WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV16WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         /* GeneXus formulas. */
      }

      private short AV15WWPFormElementParentId ;
      private short AV17Columns ;
      private short AV14WWPFormElementId ;
      private short AV18ElementColumns ;
      private bool AV19IsContainerElement ;
      private bool AV9IsInsideGridMultiple ;
      private bool AV11ShowSmallButtons ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV13WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV10ParentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV12WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV8WWP_DF_ElementsRepeaterMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV16WWP_DF_StepMetadata ;
      private bool aP3_IsInsideGridMultiple ;
      private bool aP4_ShowSmallButtons ;
   }

}
