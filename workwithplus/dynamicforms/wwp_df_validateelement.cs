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
   public class wwp_df_validateelement : GXProcedure
   {
      public wwp_df_validateelement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_validateelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           string aP1_WWPFormInstanceElementJson ,
                           bool aP2_HasDeletedElements ,
                           ref GxSimpleCollection<string> aP3_HiddenContainers ,
                           out bool aP4_HasErrors ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV25WWPFormInstance = aP0_WWPFormInstance;
         this.AV27WWPFormInstanceElementJson = aP1_WWPFormInstanceElementJson;
         this.AV11HasDeletedElements = aP2_HasDeletedElements;
         this.AV13HiddenContainers = aP3_HiddenContainers;
         this.AV12HasErrors = false ;
         this.AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP3_HiddenContainers=this.AV13HiddenContainers;
         aP4_HasErrors=this.AV12HasErrors;
         aP5_Messages=this.AV17Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                             string aP1_WWPFormInstanceElementJson ,
                                                                             bool aP2_HasDeletedElements ,
                                                                             ref GxSimpleCollection<string> aP3_HiddenContainers ,
                                                                             out bool aP4_HasErrors )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementJson, aP2_HasDeletedElements, ref aP3_HiddenContainers, out aP4_HasErrors, out aP5_Messages);
         return AV17Messages ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 string aP1_WWPFormInstanceElementJson ,
                                 bool aP2_HasDeletedElements ,
                                 ref GxSimpleCollection<string> aP3_HiddenContainers ,
                                 out bool aP4_HasErrors ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV25WWPFormInstance = aP0_WWPFormInstance;
         this.AV27WWPFormInstanceElementJson = aP1_WWPFormInstanceElementJson;
         this.AV11HasDeletedElements = aP2_HasDeletedElements;
         this.AV13HiddenContainers = aP3_HiddenContainers;
         this.AV12HasErrors = false ;
         this.AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP3_HiddenContainers=this.AV13HiddenContainers;
         aP4_HasErrors=this.AV12HasErrors;
         aP5_Messages=this.AV17Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12HasErrors = false;
         AV26WWPFormInstanceElement.FromJSonString(AV27WWPFormInstanceElementJson, null);
         if ( ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementtype == 1 ) && ( ! AV11HasDeletedElements || ! StringUtil.Contains( AV26WWPFormInstanceElement.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
         {
            if ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementparentid > 0 )
            {
               if ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementparenttype == 3 )
               {
                  AV8ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.Str( (decimal)(0), 1, 0), "", "", "", "", "", "", "");
               }
               else
               {
                  AV8ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid), 4, 0), "", "", "", "", "", "", "");
               }
               AV14IsParentVisible = (bool)((AV13HiddenContainers.IndexOf(AV8ContainerKey)==0));
            }
            if ( AV14IsParentVisible )
            {
               AV18Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
               AV19VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
               AV15IsRequired = false;
               if ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 1 )
               {
                  AV20WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
                  AV20WWP_DF_BooleanMetadata.FromJSonString(AV26WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV18Validations = AV20WWP_DF_BooleanMetadata.gxTpr_Validations;
                  AV19VisibleCondition = AV20WWP_DF_BooleanMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 2 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 6 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 7 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 8 ) )
               {
                  AV21WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
                  AV21WWP_DF_CharMetadata.FromJSonString(AV26WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV15IsRequired = AV21WWP_DF_CharMetadata.gxTpr_Isrequired;
                  AV18Validations = AV21WWP_DF_CharMetadata.gxTpr_Validations;
                  AV19VisibleCondition = AV21WWP_DF_CharMetadata.gxTpr_Visiblecondition;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar)) && ( ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 7 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 8 ) ) )
                  {
                     if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV25WWPFormInstance,  AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV19VisibleCondition) )
                     {
                        new WorkWithPlus.workwithplus_dynamicforms.wwp_df_validatetextvalue(context ).execute(  AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype,  StringUtil.Trim( AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar), out  AV10ErrorMessage, out  AV28IsValid) ;
                        if ( ! AV28IsValid )
                        {
                           AV12HasErrors = true;
                           AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
                           AV16Message.gxTpr_Description = AV10ErrorMessage;
                           AV17Messages.Add(AV16Message, 0);
                           AV18Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
                        }
                     }
                     else
                     {
                        AV15IsRequired = false;
                        AV18Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
                     }
                     AV19VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
                  }
               }
               else if ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 3 )
               {
                  AV24WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
                  AV24WWP_DF_NumericMetadata.FromJSonString(AV26WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV15IsRequired = AV24WWP_DF_NumericMetadata.gxTpr_Isrequired;
                  AV18Validations = AV24WWP_DF_NumericMetadata.gxTpr_Validations;
                  AV19VisibleCondition = AV24WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 4 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 5 ) )
               {
                  AV22WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
                  AV22WWP_DF_DateMetadata.FromJSonString(AV26WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV15IsRequired = AV22WWP_DF_DateMetadata.gxTpr_Isrequired;
                  AV18Validations = AV22WWP_DF_DateMetadata.gxTpr_Validations;
                  AV19VisibleCondition = AV22WWP_DF_DateMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 9 ) || ( AV26WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 10 ) )
               {
                  AV23WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
                  AV23WWP_DF_ImageMetadata.FromJSonString(AV26WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV15IsRequired = AV23WWP_DF_ImageMetadata.gxTpr_Isrequired;
                  AV18Validations = AV23WWP_DF_ImageMetadata.gxTpr_Validations;
                  AV19VisibleCondition = AV23WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
               }
               if ( ( AV15IsRequired || ( AV18Validations.Count > 0 ) ) && new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV25WWPFormInstance,  AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV19VisibleCondition) )
               {
                  GXt_char1 = AV9ElementValue;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getvalueforvalidation(context ).execute(  AV27WWPFormInstanceElementJson, out  GXt_char1) ;
                  AV9ElementValue = GXt_char1;
                  if ( AV15IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV9ElementValue), "''") == 0 ) )
                  {
                     AV12HasErrors = true;
                     AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
                     AV16Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV26WWPFormInstanceElement.gxTpr_Wwpformelementtitle, "", "", "", "", "", "", "", "");
                     AV17Messages.Add(AV16Message, 0);
                  }
                  else
                  {
                     if ( AV18Validations.Count > 0 )
                     {
                        new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV25WWPFormInstance,  AV26WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV9ElementValue,  AV18Validations, out  AV17Messages) ;
                        if ( AV17Messages.Count > 0 )
                        {
                           AV12HasErrors = true;
                        }
                     }
                  }
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
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV26WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV8ContainerKey = "";
         AV18Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version21");
         AV19VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV20WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV21WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV10ErrorMessage = "";
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV24WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV22WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV23WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV9ElementValue = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private bool AV11HasDeletedElements ;
      private bool AV12HasErrors ;
      private bool AV14IsParentVisible ;
      private bool AV15IsRequired ;
      private bool AV28IsValid ;
      private string AV27WWPFormInstanceElementJson ;
      private string AV8ContainerKey ;
      private string AV10ErrorMessage ;
      private string AV9ElementValue ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV25WWPFormInstance ;
      private GxSimpleCollection<string> AV13HiddenContainers ;
      private GxSimpleCollection<string> aP3_HiddenContainers ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV26WWPFormInstanceElement ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV18Validations ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV19VisibleCondition ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV20WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV21WWP_DF_CharMetadata ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV24WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV22WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV23WWP_DF_ImageMetadata ;
      private bool aP4_HasErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
   }

}
