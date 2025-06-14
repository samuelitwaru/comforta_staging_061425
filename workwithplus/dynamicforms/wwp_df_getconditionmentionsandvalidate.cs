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
   public class wwp_df_getconditionmentionsandvalidate : GXProcedure
   {
      public wwp_df_getconditionmentionsandvalidate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getconditionmentionsandvalidate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           string aP1_Text ,
                           bool aP2_IsValidation ,
                           bool aP3_TestExecuteCondition ,
                           string aP4_WWPFormElementReferenceId ,
                           short aP5_WWPFormElementDataType ,
                           ref GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> aP6_AllReferenceIds ,
                           out GxSimpleCollection<string> aP7_VarCharList ,
                           out string aP8_ConditionError )
      {
         this.AV22WWPForm = aP0_WWPForm;
         this.AV19Text = aP1_Text;
         this.AV13IsValidation = aP2_IsValidation;
         this.AV18TestExecuteCondition = aP3_TestExecuteCondition;
         this.AV23WWPFormElementReferenceId = aP4_WWPFormElementReferenceId;
         this.AV28WWPFormElementDataType = aP5_WWPFormElementDataType;
         this.AV8AllReferenceIds = aP6_AllReferenceIds;
         this.AV21VarCharList = new GxSimpleCollection<string>() ;
         this.AV9ConditionError = "" ;
         initialize();
         ExecuteImpl();
         aP6_AllReferenceIds=this.AV8AllReferenceIds;
         aP7_VarCharList=this.AV21VarCharList;
         aP8_ConditionError=this.AV9ConditionError;
      }

      public string executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                string aP1_Text ,
                                bool aP2_IsValidation ,
                                bool aP3_TestExecuteCondition ,
                                string aP4_WWPFormElementReferenceId ,
                                short aP5_WWPFormElementDataType ,
                                ref GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> aP6_AllReferenceIds ,
                                out GxSimpleCollection<string> aP7_VarCharList )
      {
         execute(aP0_WWPForm, aP1_Text, aP2_IsValidation, aP3_TestExecuteCondition, aP4_WWPFormElementReferenceId, aP5_WWPFormElementDataType, ref aP6_AllReferenceIds, out aP7_VarCharList, out aP8_ConditionError);
         return AV9ConditionError ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 string aP1_Text ,
                                 bool aP2_IsValidation ,
                                 bool aP3_TestExecuteCondition ,
                                 string aP4_WWPFormElementReferenceId ,
                                 short aP5_WWPFormElementDataType ,
                                 ref GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> aP6_AllReferenceIds ,
                                 out GxSimpleCollection<string> aP7_VarCharList ,
                                 out string aP8_ConditionError )
      {
         this.AV22WWPForm = aP0_WWPForm;
         this.AV19Text = aP1_Text;
         this.AV13IsValidation = aP2_IsValidation;
         this.AV18TestExecuteCondition = aP3_TestExecuteCondition;
         this.AV23WWPFormElementReferenceId = aP4_WWPFormElementReferenceId;
         this.AV28WWPFormElementDataType = aP5_WWPFormElementDataType;
         this.AV8AllReferenceIds = aP6_AllReferenceIds;
         this.AV21VarCharList = new GxSimpleCollection<string>() ;
         this.AV9ConditionError = "" ;
         SubmitImpl();
         aP6_AllReferenceIds=this.AV8AllReferenceIds;
         aP7_VarCharList=this.AV21VarCharList;
         aP8_ConditionError=this.AV9ConditionError;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21VarCharList = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV19Text))) )
         {
            AV30TextCleaned = StringUtil.StringReplace( AV19Text, "'", "[']");
            AV30TextCleaned = StringUtil.StringReplace( AV30TextCleaned, "\"", "'");
            AV30TextCleaned = StringUtil.StringReplace( AV30TextCleaned, "\\'", "\"");
            AV30TextCleaned = StringUtil.StringReplace( AV30TextCleaned, "[']", "'");
            AV30TextCleaned = GxRegex.Replace(AV30TextCleaned,"'.+'","''");
            AV17RegExMatchColl = GxRegex.Matches(AV30TextCleaned,"&\\w+");
            AV24WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV17RegExMatchColl.Count )
            {
               AV16RegExMatch = ((GxRegexMatch)AV17RegExMatchColl.Item(AV33GXV1));
               AV20VarCharAux = StringUtil.Substring( StringUtil.Lower( StringUtil.Trim( AV16RegExMatch.Value)), 2, -1);
               if ( ( ! AV13IsValidation || ( StringUtil.StrCmp(AV20VarCharAux, "value") != 0 ) ) && ( AV21VarCharList.IndexOf(AV20VarCharAux) == 0 ) )
               {
                  /* Execute user subroutine: 'EXIST REFERENCE ID' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  if ( AV14ReferencedIdFound )
                  {
                     if ( AV18TestExecuteCondition )
                     {
                        AV26Element_WWPFormElementReferenceId = AV20VarCharAux;
                        AV29ElementFound = false;
                        AV34GXV2 = 1;
                        while ( AV34GXV2 <= AV22WWPForm.gxTpr_Element.Count )
                        {
                           AV12Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV22WWPForm.gxTpr_Element.Item(AV34GXV2));
                           if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV12Element.gxTpr_Wwpformelementreferenceid)), StringUtil.Trim( StringUtil.Lower( AV26Element_WWPFormElementReferenceId))) == 0 )
                           {
                              AV27Element_WWPFormElementDataType = AV12Element.gxTpr_Wwpformelementdatatype;
                              AV29ElementFound = true;
                           }
                           AV34GXV2 = (int)(AV34GXV2+1);
                        }
                        if ( ! AV29ElementFound && StringUtil.EndsWith( StringUtil.Lower( AV20VarCharAux), "_repetitions") )
                        {
                           AV27Element_WWPFormElementDataType = 3;
                        }
                        else
                        {
                           if ( AV22WWPForm.gxTpr_Wwpformtype == 1 )
                           {
                              AV31SectionReferencedElements.FromJSonString(AV22WWPForm.gxTpr_Wwpformsectionrefelements, null);
                              AV32Property = AV31SectionReferencedElements.GetFirst();
                              while ( ! AV31SectionReferencedElements.Eof() )
                              {
                                 if ( StringUtil.StrCmp(AV26Element_WWPFormElementReferenceId, StringUtil.Trim( StringUtil.Lower( AV32Property.Key))) == 0 )
                                 {
                                    AV27Element_WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( AV32Property.Value, "."), 18, MidpointRounding.ToEven));
                                    AV29ElementFound = true;
                                    if (true) break;
                                 }
                                 AV32Property = AV31SectionReferencedElements.GetNext();
                              }
                           }
                        }
                        /* Execute user subroutine: 'CREATE INSTANCE ELEMENT' */
                        S121 ();
                        if ( returnInSub )
                        {
                           cleanup();
                           if (true) return;
                        }
                        AV24WWPFormInstance.gxTpr_Element.Add(AV25WWPFormInstanceElement, 0);
                     }
                     AV21VarCharList.Add(AV20VarCharAux, 0);
                  }
                  else
                  {
                     AV9ConditionError = StringUtil.Format( context.GetMessage( "WWP_DF_InvalidReferencedControl", ""), StringUtil.Trim( AV16RegExMatch.Value), "", "", "", "", "", "", "", "");
                     if (true) break;
                  }
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ConditionError)) && AV18TestExecuteCondition )
            {
               AV10ConditionExpression.gxTpr_Expression = AV19Text;
               AV10ConditionExpression.gxTpr_Mentionedfields = AV21VarCharList;
               if ( AV13IsValidation )
               {
                  AV26Element_WWPFormElementReferenceId = "value";
                  AV27Element_WWPFormElementDataType = AV28WWPFormElementDataType;
                  /* Execute user subroutine: 'CREATE INSTANCE ELEMENT' */
                  S121 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  AV24WWPFormInstance.gxTpr_Element.Add(AV25WWPFormInstanceElement, 0);
                  AV10ConditionExpression.gxTpr_Mentionedfields.Add("value", 0);
               }
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluatecondition(context ).execute(  AV24WWPFormInstance,  AV10ConditionExpression,  true,  0,  "", out  AV11ConditionResult, out  AV9ConditionError) ;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EXIST REFERENCE ID' Routine */
         returnInSub = false;
         AV14ReferencedIdFound = false;
         if ( StringUtil.StrCmp(AV20VarCharAux, AV23WWPFormElementReferenceId) != 0 )
         {
            AV35GXV3 = 1;
            while ( AV35GXV3 <= AV8AllReferenceIds.Count )
            {
               AV15ReferenceId = ((WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem)AV8AllReferenceIds.Item(AV35GXV3));
               if ( StringUtil.StrCmp(AV15ReferenceId.gxTpr_Id, AV20VarCharAux) == 0 )
               {
                  AV14ReferencedIdFound = true;
                  if (true) break;
               }
               AV35GXV3 = (int)(AV35GXV3+1);
            }
         }
      }

      protected void S121( )
      {
         /* 'CREATE INSTANCE ELEMENT' Routine */
         returnInSub = false;
         AV25WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV25WWPFormInstanceElement.FromJSonString(StringUtil.Format( "{\"WWPFormElementReferenceId\":\"%1\",\"WWPFormElementDataType\":%2,\"WWPFormInstanceElemDate\":\"1879-03-14\",\"WWPFormInstanceElemDateTime\":\"1962-02-06T00:00:00\",\"WWPFormInstanceElemNumeric\":1}", AV26Element_WWPFormElementReferenceId, StringUtil.LTrimStr( (decimal)(AV27Element_WWPFormElementDataType), 2, 0), "", "", "", "", "", "", ""), null);
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
         AV21VarCharList = new GxSimpleCollection<string>();
         AV9ConditionError = "";
         AV30TextCleaned = "";
         AV17RegExMatchColl = new GxUnknownObjectCollection();
         AV24WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV16RegExMatch = new GxRegexMatch();
         AV20VarCharAux = "";
         AV26Element_WWPFormElementReferenceId = "";
         AV12Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV31SectionReferencedElements = new GXProperties();
         AV32Property = new GxKeyValuePair();
         AV25WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV10ConditionExpression = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV15ReferenceId = new WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem(context);
         /* GeneXus formulas. */
      }

      private short AV28WWPFormElementDataType ;
      private short AV27Element_WWPFormElementDataType ;
      private int AV33GXV1 ;
      private int AV34GXV2 ;
      private int AV35GXV3 ;
      private bool AV13IsValidation ;
      private bool AV18TestExecuteCondition ;
      private bool returnInSub ;
      private bool AV14ReferencedIdFound ;
      private bool AV29ElementFound ;
      private bool AV11ConditionResult ;
      private string AV19Text ;
      private string AV23WWPFormElementReferenceId ;
      private string AV9ConditionError ;
      private string AV30TextCleaned ;
      private string AV20VarCharAux ;
      private string AV26Element_WWPFormElementReferenceId ;
      private GXProperties AV31SectionReferencedElements ;
      private GxKeyValuePair AV32Property ;
      private GxRegexMatch AV16RegExMatch ;
      private GxUnknownObjectCollection AV17RegExMatchColl ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV22WWPForm ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> AV8AllReferenceIds ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> aP6_AllReferenceIds ;
      private GxSimpleCollection<string> AV21VarCharList ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV24WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV12Element ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV25WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV10ConditionExpression ;
      private WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem AV15ReferenceId ;
      private GxSimpleCollection<string> aP7_VarCharList ;
      private string aP8_ConditionError ;
   }

}
