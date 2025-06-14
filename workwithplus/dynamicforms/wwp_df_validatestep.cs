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
   public class wwp_df_validatestep : GXProcedure
   {
      public wwp_df_validatestep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_validatestep( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_Step_WWPFormElementId ,
                           bool aP2_ReturnOnlyFormErrors ,
                           out bool aP3_HasErrors ,
                           out string aP4_ErrorIds ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV22WWPFormInstance = aP0_WWPFormInstance;
         this.AV18Step_WWPFormElementId = aP1_Step_WWPFormElementId;
         this.AV17ReturnOnlyFormErrors = aP2_ReturnOnlyFormErrors;
         this.AV12HasErrors = false ;
         this.AV11ErrorIds = "" ;
         this.AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP3_HasErrors=this.AV12HasErrors;
         aP4_ErrorIds=this.AV11ErrorIds;
         aP5_Messages=this.AV16Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                             short aP1_Step_WWPFormElementId ,
                                                                             bool aP2_ReturnOnlyFormErrors ,
                                                                             out bool aP3_HasErrors ,
                                                                             out string aP4_ErrorIds )
      {
         execute(aP0_WWPFormInstance, aP1_Step_WWPFormElementId, aP2_ReturnOnlyFormErrors, out aP3_HasErrors, out aP4_ErrorIds, out aP5_Messages);
         return AV16Messages ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_Step_WWPFormElementId ,
                                 bool aP2_ReturnOnlyFormErrors ,
                                 out bool aP3_HasErrors ,
                                 out string aP4_ErrorIds ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV22WWPFormInstance = aP0_WWPFormInstance;
         this.AV18Step_WWPFormElementId = aP1_Step_WWPFormElementId;
         this.AV17ReturnOnlyFormErrors = aP2_ReturnOnlyFormErrors;
         this.AV12HasErrors = false ;
         this.AV11ErrorIds = "" ;
         this.AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP3_HasErrors=this.AV12HasErrors;
         aP4_ErrorIds=this.AV11ErrorIds;
         aP5_Messages=this.AV16Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P004Q2 */
         pr_default.execute(0, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV18Step_WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A217WWPFormElementType = P004Q2_A217WWPFormElementType[0];
            A210WWPFormElementId = P004Q2_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = P004Q2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004Q2_A206WWPFormId[0];
            A236WWPFormElementMetadata = P004Q2_A236WWPFormElementMetadata[0];
            AV20WWP_DF_StepMetadata.FromJSonString(A236WWPFormElementMetadata, null);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV22WWPFormInstance,  0,  AV20WWP_DF_StepMetadata.gxTpr_Visiblecondition) )
         {
            if ( (0==AV22WWPFormInstance.gxTpr_Wwpforminstanceid) )
            {
               AV10HasDeletedElements = false;
            }
            else
            {
               AV10HasDeletedElements = StringUtil.Contains( AV22WWPFormInstance.ToJSonString(true, true), "\"Mode\":\"DLT\"");
            }
            /* Execute user subroutine: 'GET ALL STEP ELEMENTS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV12HasErrors = false;
            AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV22WWPFormInstance.gxTpr_Element.Count )
            {
               AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV25GXV1));
               if ( AV19StepElements.IndexOf(AV23WWPFormInstanceElement.gxTpr_Wwpformelementid) >= 1 )
               {
                  if ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementtype != 5 )
                  {
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateelement(context ).execute(  AV22WWPFormInstance,  AV23WWPFormInstanceElement.ToJSonString(true, true),  AV10HasDeletedElements, ref  AV13HiddenContainers, out  AV8ElementHasErrors, out  AV9ElementMessages) ;
                     if ( AV8ElementHasErrors )
                     {
                        AV12HasErrors = true;
                        if ( AV17ReturnOnlyFormErrors )
                        {
                           AV11ErrorIds += StringUtil.Trim( StringUtil.Str( (decimal)(AV23WWPFormInstanceElement.gxTpr_Wwpformelementid), 4, 0)) + "." + StringUtil.Trim( StringUtil.Str( (decimal)(AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid), 4, 0)) + "|";
                        }
                        else
                        {
                           AV26GXV2 = 1;
                           while ( AV26GXV2 <= AV9ElementMessages.Count )
                           {
                              AV15Message = ((GeneXus.Utils.SdtMessages_Message)AV9ElementMessages.Item(AV26GXV2));
                              AV16Messages.Add(AV15Message, 0);
                              AV26GXV2 = (int)(AV26GXV2+1);
                           }
                        }
                     }
                  }
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
            if ( AV17ReturnOnlyFormErrors && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ErrorIds)) )
            {
               AV11ErrorIds = "|" + AV11ErrorIds;
               AV12HasErrors = true;
            }
            if ( ! AV12HasErrors )
            {
               if ( AV20WWP_DF_StepMetadata.gxTpr_Validations.Count > 0 )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV22WWPFormInstance,  0,  "",  AV20WWP_DF_StepMetadata.gxTpr_Validations, out  AV16Messages) ;
                  if ( AV16Messages.Count > 0 )
                  {
                     AV12HasErrors = true;
                  }
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GET ALL STEP ELEMENTS' Routine */
         returnInSub = false;
         AV19StepElements = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV19StepElements.Add(AV18Step_WWPFormElementId, 0);
         AV14i = 1;
         while ( AV14i <= AV19StepElements.Count )
         {
            AV21WWPFormElementId = (short)(AV19StepElements.GetNumeric(AV14i));
            /* Using cursor P004Q3 */
            pr_default.execute(1, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV21WWPFormElementId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A211WWPFormElementParentId = P004Q3_A211WWPFormElementParentId[0];
               n211WWPFormElementParentId = P004Q3_n211WWPFormElementParentId[0];
               A207WWPFormVersionNumber = P004Q3_A207WWPFormVersionNumber[0];
               A206WWPFormId = P004Q3_A206WWPFormId[0];
               A210WWPFormElementId = P004Q3_A210WWPFormElementId[0];
               AV19StepElements.Add(A210WWPFormElementId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV14i = (short)(AV14i+1);
         }
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
         AV11ErrorIds = "";
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P004Q2_A217WWPFormElementType = new short[1] ;
         P004Q2_A210WWPFormElementId = new short[1] ;
         P004Q2_A207WWPFormVersionNumber = new short[1] ;
         P004Q2_A206WWPFormId = new short[1] ;
         P004Q2_A236WWPFormElementMetadata = new string[] {""} ;
         A236WWPFormElementMetadata = "";
         AV20WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV23WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV19StepElements = new GxSimpleCollection<short>();
         AV13HiddenContainers = new GxSimpleCollection<string>();
         AV9ElementMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         P004Q3_A211WWPFormElementParentId = new short[1] ;
         P004Q3_n211WWPFormElementParentId = new bool[] {false} ;
         P004Q3_A207WWPFormVersionNumber = new short[1] ;
         P004Q3_A206WWPFormId = new short[1] ;
         P004Q3_A210WWPFormElementId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validatestep__default(),
            new Object[][] {
                new Object[] {
               P004Q2_A217WWPFormElementType, P004Q2_A210WWPFormElementId, P004Q2_A207WWPFormVersionNumber, P004Q2_A206WWPFormId, P004Q2_A236WWPFormElementMetadata
               }
               , new Object[] {
               P004Q3_A211WWPFormElementParentId, P004Q3_n211WWPFormElementParentId, P004Q3_A207WWPFormVersionNumber, P004Q3_A206WWPFormId, P004Q3_A210WWPFormElementId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18Step_WWPFormElementId ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short AV14i ;
      private short AV21WWPFormElementId ;
      private short A211WWPFormElementParentId ;
      private int AV25GXV1 ;
      private int AV26GXV2 ;
      private bool AV17ReturnOnlyFormErrors ;
      private bool AV12HasErrors ;
      private bool AV10HasDeletedElements ;
      private bool returnInSub ;
      private bool AV8ElementHasErrors ;
      private bool n211WWPFormElementParentId ;
      private string A236WWPFormElementMetadata ;
      private string AV11ErrorIds ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV22WWPFormInstance ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private IDataStoreProvider pr_default ;
      private short[] P004Q2_A217WWPFormElementType ;
      private short[] P004Q2_A210WWPFormElementId ;
      private short[] P004Q2_A207WWPFormVersionNumber ;
      private short[] P004Q2_A206WWPFormId ;
      private string[] P004Q2_A236WWPFormElementMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV20WWP_DF_StepMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV23WWPFormInstanceElement ;
      private GxSimpleCollection<short> AV19StepElements ;
      private GxSimpleCollection<string> AV13HiddenContainers ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ElementMessages ;
      private GeneXus.Utils.SdtMessages_Message AV15Message ;
      private short[] P004Q3_A211WWPFormElementParentId ;
      private bool[] P004Q3_n211WWPFormElementParentId ;
      private short[] P004Q3_A207WWPFormVersionNumber ;
      private short[] P004Q3_A206WWPFormId ;
      private short[] P004Q3_A210WWPFormElementId ;
      private bool aP3_HasErrors ;
      private string aP4_ErrorIds ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
   }

   public class wwp_df_validatestep__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004Q2;
          prmP004Q2 = new Object[] {
          new ParDef("AV22WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV18Step_WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmP004Q3;
          prmP004Q3 = new Object[] {
          new ParDef("AV22WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV21WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Q2", "SELECT WWPFormElementType, WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementMetadata FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_2Wwpformid and WWPFormVersionNumber = :AV22WWPF_1Wwpformversionnumbe and WWPFormElementId = :AV18Step_WWPFormElementId) AND (WWPFormElementType = 5) ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004Q3", "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :AV22WWPF_2Wwpformid and WWPFormVersionNumber = :AV22WWPF_1Wwpformversionnumbe and WWPFormElementParentId = :AV21WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementParentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
