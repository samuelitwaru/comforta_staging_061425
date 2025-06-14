using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class wwp_df_evaluatecondition : GXProcedure
   {
      public wwp_df_evaluatecondition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_evaluatecondition( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                           bool aP2_TestingCondition ,
                           short aP3_WWPFormInstanceElementId ,
                           string aP4_ThisElementValue ,
                           out bool aP5_ConditionResult ,
                           out string aP6_ErrorMessage )
      {
         this.AV31WWPFormInstance = aP0_WWPFormInstance;
         this.AV28VisibleCondition = aP1_VisibleCondition;
         this.AV26TestingCondition = aP2_TestingCondition;
         this.AV34WWPFormInstanceElementId = aP3_WWPFormInstanceElementId;
         this.AV27ThisElementValue = aP4_ThisElementValue;
         this.AV13ConditionResult = false ;
         this.AV16ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP5_ConditionResult=this.AV13ConditionResult;
         aP6_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                                bool aP2_TestingCondition ,
                                short aP3_WWPFormInstanceElementId ,
                                string aP4_ThisElementValue ,
                                out bool aP5_ConditionResult )
      {
         execute(aP0_WWPFormInstance, aP1_VisibleCondition, aP2_TestingCondition, aP3_WWPFormInstanceElementId, aP4_ThisElementValue, out aP5_ConditionResult, out aP6_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                                 bool aP2_TestingCondition ,
                                 short aP3_WWPFormInstanceElementId ,
                                 string aP4_ThisElementValue ,
                                 out bool aP5_ConditionResult ,
                                 out string aP6_ErrorMessage )
      {
         this.AV31WWPFormInstance = aP0_WWPFormInstance;
         this.AV28VisibleCondition = aP1_VisibleCondition;
         this.AV26TestingCondition = aP2_TestingCondition;
         this.AV34WWPFormInstanceElementId = aP3_WWPFormInstanceElementId;
         this.AV27ThisElementValue = aP4_ThisElementValue;
         this.AV13ConditionResult = false ;
         this.AV16ErrorMessage = "" ;
         SubmitImpl();
         aP5_ConditionResult=this.AV13ConditionResult;
         aP6_ErrorMessage=this.AV16ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9AllElementsFound = true;
         AV12CleanedExpression = AV28VisibleCondition.gxTpr_Expression;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV28VisibleCondition.gxTpr_Mentionedfields.Count )
         {
            AV19FieldName = ((string)AV28VisibleCondition.gxTpr_Mentionedfields.Item(AV39GXV1));
            if ( ( ( StringUtil.StrCmp(StringUtil.Lower( AV19FieldName), "value") != 0 ) || AV26TestingCondition ) && ( StringUtil.StrCmp(StringUtil.Lower( AV19FieldName), "today") != 0 ) )
            {
               /* Execute user subroutine: 'GET ELEMENT BY FIELDNAME' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)) )
               {
                  GXt_char1 = AV15ElementValue;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getvalueforvalidation(context ).execute(  AV32WWPFormInstanceElement.ToJSonString(true, true), out  GXt_char1) ;
                  AV15ElementValue = GXt_char1;
                  AV32WWPFormInstanceElement.FromJSonString(AV38WWPFormInstanceElementJson, null);
               }
               else
               {
                  AV11ChildWWPFormElementId = 0;
                  if ( StringUtil.EndsWith( StringUtil.Lower( AV19FieldName), "_repetitions") )
                  {
                     AV20FieldNameToSearch = StringUtil.Substring( StringUtil.Lower( AV19FieldName), 1, StringUtil.Len( AV19FieldName)-12);
                     AV30WWPFormElementId = 0;
                     /* Using cursor P00492 */
                     pr_default.execute(0, new Object[] {AV31WWPFormInstance.gxTpr_Wwpformid, AV31WWPFormInstance.gxTpr_Wwpformversionnumber, AV20FieldNameToSearch});
                     while ( (pr_default.getStatus(0) != 101) )
                     {
                        A217WWPFormElementType = P00492_A217WWPFormElementType[0];
                        A213WWPFormElementReferenceId = P00492_A213WWPFormElementReferenceId[0];
                        A207WWPFormVersionNumber = P00492_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00492_A206WWPFormId[0];
                        A210WWPFormElementId = P00492_A210WWPFormElementId[0];
                        AV30WWPFormElementId = A210WWPFormElementId;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                        pr_default.readNext(0);
                     }
                     pr_default.close(0);
                     if ( ! (0==AV30WWPFormElementId) )
                     {
                        AV11ChildWWPFormElementId = AV30WWPFormElementId;
                        new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV31WWPFormInstance.gxTpr_Wwpformid,  AV31WWPFormInstance.gxTpr_Wwpformversionnumber, ref  AV11ChildWWPFormElementId) ;
                        if ( ! (0==AV11ChildWWPFormElementId) )
                        {
                           AV10ChildrenCount = 0;
                           AV21HasDeletedElements = (bool)((!(0==AV31WWPFormInstance.gxTpr_Wwpforminstanceid)));
                           AV41GXV2 = 1;
                           while ( AV41GXV2 <= AV31WWPFormInstance.gxTpr_Element.Count )
                           {
                              AV14Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV31WWPFormInstance.gxTpr_Element.Item(AV41GXV2));
                              if ( ( AV14Element.gxTpr_Wwpformelementid == AV11ChildWWPFormElementId ) && ( ! AV21HasDeletedElements || ! StringUtil.Contains( AV14Element.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
                              {
                                 AV10ChildrenCount = (short)(AV10ChildrenCount+1);
                              }
                              AV41GXV2 = (int)(AV41GXV2+1);
                           }
                           AV15ElementValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ChildrenCount), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     /* Using cursor P00493 */
                     pr_default.execute(1, new Object[] {AV31WWPFormInstance.gxTpr_Wwpformid, AV31WWPFormInstance.gxTpr_Wwpformversionnumber});
                     while ( (pr_default.getStatus(1) != 101) )
                     {
                        A207WWPFormVersionNumber = P00493_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00493_A206WWPFormId[0];
                        A240WWPFormType = P00493_A240WWPFormType[0];
                        AV36WWPFormType = A240WWPFormType;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(1);
                     if ( AV36WWPFormType == 1 )
                     {
                        AV8Properties.FromJSonString(AV31WWPFormInstance.gxTpr_Wwpforminstancerecordkey, null);
                        AV25SectionReferencedElements.FromJSonString(AV8Properties.Get("SectionReferencedElements"), null);
                        AV15ElementValue = AV25SectionReferencedElements.Get(AV19FieldName);
                        AV22IsElementTrnAttribute = true;
                     }
                  }
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)) || ! (0==AV11ChildWWPFormElementId) || AV22IsElementTrnAttribute )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ElementValue)) )
                  {
                     /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
                     S121 ();
                     if ( returnInSub )
                     {
                        cleanup();
                        if (true) return;
                     }
                  }
               }
               else
               {
                  AV16ErrorMessage = StringUtil.Format( context.GetMessage( "WWP_DF_ReferencedControlNotFound", ""), AV19FieldName, "", "", "", "", "", "", "", "");
                  AV9AllElementsFound = false;
                  if (true) break;
               }
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         if ( AV9AllElementsFound )
         {
            AV19FieldName = "Today";
            GXt_int2 = 0;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getdatenumber(context ).execute(  Gx_date, out  GXt_int2) ;
            AV15ElementValue = StringUtil.Trim( StringUtil.Str( (decimal)(GXt_int2), 10, 0));
            /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27ThisElementValue))) )
            {
               AV19FieldName = "Value";
               AV15ElementValue = AV27ThisElementValue;
               /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "(", " (");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "<>", "!=");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "'", "[']");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "\"", "'");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "\\'", "\"");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "[']", "'");
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0));
            AV29WWPDateSumCall = formatLink("workwithplus_dynamicforms.wwp_df_datesum") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV29WWPDateSumCall = StringUtil.Substring( AV29WWPDateSumCall, 1, StringUtil.StringSearch( AV29WWPDateSumCall, "?", 1)-1);
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, "DateSum (", AV29WWPDateSumCall+"(");
            AV12CleanedExpression = StringUtil.StringReplace( AV12CleanedExpression, " iif (", " iif(");
            AV18ExpressionEvaluator.Expression = StringUtil.Format( "iif((%1), 1, 0)", AV12CleanedExpression, "", "", "", "", "", "", "", "");
            /* User Code */
             try{
            AV24Result = (decimal)(AV18ExpressionEvaluator.Evaluate());
            /* User Code */
             }catch(Exception exc){
            /* User Code */
             AV23IsException = true;
            /* User Code */
             AV17ExceptionMessage = exc.Message;
            /* User Code */
             }
            if ( ( AV18ExpressionEvaluator.ErrCode == 0 ) && ! AV23IsException )
            {
               AV13ConditionResult = ((AV24Result==Convert.ToDecimal(1)) ? true : false);
            }
            else
            {
               AV16ErrorMessage = (AV23IsException ? AV17ExceptionMessage : StringUtil.Trim( AV18ExpressionEvaluator.ErrDescription));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ErrorMessage)) )
               {
                  AV16ErrorMessage = context.GetMessage( "WWP_DF_UnknownError", "");
               }
               else
               {
                  if ( StringUtil.StrCmp(AV16ErrorMessage, "Failed to load type: GeneXus.Programs.iif") == 0 )
                  {
                     AV16ErrorMessage = context.GetMessage( "WWP_DF_IncludeSpaceForIIF", "");
                  }
                  else if ( StringUtil.Contains( AV16ErrorMessage, "'iif((") && StringUtil.Contains( AV16ErrorMessage, "), 1, 0)'") )
                  {
                     AV16ErrorMessage = StringUtil.StringReplace( AV16ErrorMessage, "'iif((", "'");
                     AV16ErrorMessage = StringUtil.StringReplace( AV16ErrorMessage, "), 1, 0)'", "'");
                  }
               }
               if ( AV23IsException || StringUtil.Contains( StringUtil.Lower( AV16ErrorMessage), "supported") || StringUtil.Contains( StringUtil.Lower( AV16ErrorMessage), "evaluate expression") )
               {
                  new GeneXus.Core.genexus.common.SdtLog(context).error(AV16ErrorMessage, AV44Pgmname) ;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GET ELEMENT BY FIELDNAME' Routine */
         returnInSub = false;
         AV32WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV45GXV3 = 1;
         while ( AV45GXV3 <= AV31WWPFormInstance.gxTpr_Element.Count )
         {
            AV33WWPFormInstanceElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV31WWPFormInstance.gxTpr_Element.Item(AV45GXV3));
            if ( ( StringUtil.StrCmp(StringUtil.Lower( AV33WWPFormInstanceElementAux.gxTpr_Wwpformelementreferenceid), StringUtil.Lower( AV19FieldName)) == 0 ) && ( AV34WWPFormInstanceElementId == AV33WWPFormInstanceElementAux.gxTpr_Wwpforminstanceelementid ) )
            {
               AV32WWPFormInstanceElement = AV33WWPFormInstanceElementAux;
               if (true) break;
            }
            AV45GXV3 = (int)(AV45GXV3+1);
         }
      }

      protected void S121( )
      {
         /* 'ASSINGEXPRESIONVARIABLE' Routine */
         returnInSub = false;
         AV18ExpressionEvaluator.Variables.Set(AV19FieldName, AV15ElementValue);
         AV37AmpReplacerExp = StringUtil.Format( "(?i:&%1)", AV19FieldName, "", "", "", "", "", "", "", "");
         AV12CleanedExpression = GxRegex.Replace(AV12CleanedExpression,AV37AmpReplacerExp,AV19FieldName);
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
         AV16ErrorMessage = "";
         AV12CleanedExpression = "";
         AV19FieldName = "";
         AV32WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV15ElementValue = "";
         GXt_char1 = "";
         AV38WWPFormInstanceElementJson = "";
         AV20FieldNameToSearch = "";
         P00492_A217WWPFormElementType = new short[1] ;
         P00492_A213WWPFormElementReferenceId = new string[] {""} ;
         P00492_A207WWPFormVersionNumber = new short[1] ;
         P00492_A206WWPFormId = new short[1] ;
         P00492_A210WWPFormElementId = new short[1] ;
         A213WWPFormElementReferenceId = "";
         AV14Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         P00493_A207WWPFormVersionNumber = new short[1] ;
         P00493_A206WWPFormId = new short[1] ;
         P00493_A240WWPFormType = new short[1] ;
         AV8Properties = new GXProperties();
         AV25SectionReferencedElements = new GXProperties();
         Gx_date = DateTime.MinValue;
         AV29WWPDateSumCall = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ExpressionEvaluator = new ExpressionEvaluator(context);
         AV17ExceptionMessage = "";
         AV44Pgmname = "";
         AV33WWPFormInstanceElementAux = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV37AmpReplacerExp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluatecondition__default(),
            new Object[][] {
                new Object[] {
               P00492_A217WWPFormElementType, P00492_A213WWPFormElementReferenceId, P00492_A207WWPFormVersionNumber, P00492_A206WWPFormId, P00492_A210WWPFormElementId
               }
               , new Object[] {
               P00493_A207WWPFormVersionNumber, P00493_A206WWPFormId, P00493_A240WWPFormType
               }
            }
         );
         AV44Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_EvaluateCondition";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV44Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_EvaluateCondition";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV34WWPFormInstanceElementId ;
      private short AV11ChildWWPFormElementId ;
      private short AV30WWPFormElementId ;
      private short A217WWPFormElementType ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A210WWPFormElementId ;
      private short AV10ChildrenCount ;
      private short A240WWPFormType ;
      private short AV36WWPFormType ;
      private int AV39GXV1 ;
      private int AV41GXV2 ;
      private int GXt_int2 ;
      private int AV45GXV3 ;
      private decimal AV24Result ;
      private string GXt_char1 ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV44Pgmname ;
      private DateTime Gx_date ;
      private bool AV26TestingCondition ;
      private bool AV13ConditionResult ;
      private bool AV9AllElementsFound ;
      private bool returnInSub ;
      private bool AV21HasDeletedElements ;
      private bool AV22IsElementTrnAttribute ;
      private bool AV23IsException ;
      private string AV27ThisElementValue ;
      private string AV16ErrorMessage ;
      private string AV12CleanedExpression ;
      private string AV19FieldName ;
      private string AV15ElementValue ;
      private string AV38WWPFormInstanceElementJson ;
      private string AV20FieldNameToSearch ;
      private string A213WWPFormElementReferenceId ;
      private string AV29WWPDateSumCall ;
      private string AV17ExceptionMessage ;
      private string AV37AmpReplacerExp ;
      private GXProperties AV8Properties ;
      private GXProperties AV25SectionReferencedElements ;
      private ExpressionEvaluator AV18ExpressionEvaluator ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV31WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV28VisibleCondition ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV32WWPFormInstanceElement ;
      private IDataStoreProvider pr_default ;
      private short[] P00492_A217WWPFormElementType ;
      private string[] P00492_A213WWPFormElementReferenceId ;
      private short[] P00492_A207WWPFormVersionNumber ;
      private short[] P00492_A206WWPFormId ;
      private short[] P00492_A210WWPFormElementId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV14Element ;
      private short[] P00493_A207WWPFormVersionNumber ;
      private short[] P00493_A206WWPFormId ;
      private short[] P00493_A240WWPFormType ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV33WWPFormInstanceElementAux ;
      private bool aP5_ConditionResult ;
      private string aP6_ErrorMessage ;
   }

   public class wwp_df_evaluatecondition__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00492;
          prmP00492 = new Object[] {
          new ParDef("AV31WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV31WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV20FieldNameToSearch",GXType.VarChar,40,0)
          };
          Object[] prmP00493;
          prmP00493 = new Object[] {
          new ParDef("AV31WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV31WWPF_1Wwpformversionnumbe",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00492", "SELECT WWPFormElementType, WWPFormElementReferenceId, WWPFormVersionNumber, WWPFormId, WWPFormElementId FROM WWP_FormElement WHERE (WWPFormId = :AV31WWPF_2Wwpformid and WWPFormVersionNumber = :AV31WWPF_1Wwpformversionnumbe) AND (LOWER(WWPFormElementReferenceId) = ( :AV20FieldNameToSearch)) AND (WWPFormElementType = 3) ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00492,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00493", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormType FROM WWP_Form WHERE WWPFormId = :AV31WWPF_2Wwpformid and WWPFormVersionNumber = :AV31WWPF_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00493,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
