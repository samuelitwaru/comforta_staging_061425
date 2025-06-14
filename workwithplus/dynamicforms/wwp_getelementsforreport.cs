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
   public class wwp_getelementsforreport : GXProcedure
   {
      public wwp_getelementsforreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getelementsforreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_WWPFormInstanceElementId ,
                           short aP2_WWPFormElementParentId ,
                           bool aP3_EvaluateVisibilities ,
                           ref GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements )
      {
         this.AV21WWPFormInstance = aP0_WWPFormInstance;
         this.AV22WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV19WWPFormElementParentId = aP2_WWPFormElementParentId;
         this.AV23EvaluateVisibilities = aP3_EvaluateVisibilities;
         this.AV20WWPFormElements = aP4_WWPFormElements;
         initialize();
         ExecuteImpl();
         aP4_WWPFormElements=this.AV20WWPFormElements;
      }

      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                                                             short aP1_WWPFormInstanceElementId ,
                                                                                                             short aP2_WWPFormElementParentId ,
                                                                                                             bool aP3_EvaluateVisibilities )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementId, aP2_WWPFormElementParentId, aP3_EvaluateVisibilities, ref aP4_WWPFormElements);
         return AV20WWPFormElements ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_WWPFormInstanceElementId ,
                                 short aP2_WWPFormElementParentId ,
                                 bool aP3_EvaluateVisibilities ,
                                 ref GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements )
      {
         this.AV21WWPFormInstance = aP0_WWPFormInstance;
         this.AV22WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV19WWPFormElementParentId = aP2_WWPFormElementParentId;
         this.AV23EvaluateVisibilities = aP3_EvaluateVisibilities;
         this.AV20WWPFormElements = aP4_WWPFormElements;
         SubmitImpl();
         aP4_WWPFormElements=this.AV20WWPFormElements;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19WWPFormElementParentId ,
                                              A211WWPFormElementParentId ,
                                              A218WWPFormElementDataType ,
                                              A238WWPFormElementExcludeFromExpor ,
                                              A206WWPFormId ,
                                              AV21WWPFormInstance.gxTpr_Wwpformid ,
                                              A207WWPFormVersionNumber ,
                                              AV21WWPFormInstance.gxTpr_Wwpformversionnumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P004Y2 */
         pr_default.execute(0, new Object[] {AV21WWPFormInstance.gxTpr_Wwpformid, AV21WWPFormInstance.gxTpr_Wwpformversionnumber, AV19WWPFormElementParentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238WWPFormElementExcludeFromExpor = P004Y2_A238WWPFormElementExcludeFromExpor[0];
            A218WWPFormElementDataType = P004Y2_A218WWPFormElementDataType[0];
            A211WWPFormElementParentId = P004Y2_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = P004Y2_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = P004Y2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004Y2_A206WWPFormId[0];
            A217WWPFormElementType = P004Y2_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = P004Y2_A236WWPFormElementMetadata[0];
            A210WWPFormElementId = P004Y2_A210WWPFormElementId[0];
            A237WWPFormElementCaption = P004Y2_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = P004Y2_A229WWPFormElementTitle[0];
            A212WWPFormElementOrderIndex = P004Y2_A212WWPFormElementOrderIndex[0];
            AV8VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
            AV24IncludeElement = true;
            if ( A217WWPFormElementType == 1 )
            {
               if ( A218WWPFormElementDataType == 1 )
               {
                  AV9WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
                  AV9WWP_DF_BooleanMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV9WWP_DF_BooleanMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( A218WWPFormElementDataType == 2 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) )
               {
                  AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
                  AV10WWP_DF_CharMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                  {
                     AV24IncludeElement = false;
                  }
                  else
                  {
                     AV8VisibleCondition = AV10WWP_DF_CharMetadata.gxTpr_Visiblecondition;
                  }
               }
               else if ( A218WWPFormElementDataType == 3 )
               {
                  AV16WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
                  AV16WWP_DF_NumericMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV16WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( A218WWPFormElementDataType == 4 ) || ( A218WWPFormElementDataType == 5 ) )
               {
                  AV11WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
                  AV11WWP_DF_DateMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV11WWP_DF_DateMetadata.gxTpr_Visiblecondition;
               }
               else if ( A218WWPFormElementDataType == 10 )
               {
                  AV13WWP_DF_ImageMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV13WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
               }
            }
            else if ( A217WWPFormElementType == 2 )
            {
               AV12WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
               AV12WWP_DF_GroupMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV8VisibleCondition = AV12WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
            }
            else if ( A217WWPFormElementType == 3 )
            {
               AV15WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
               AV15WWP_DF_MultipleMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV8VisibleCondition = AV15WWP_DF_MultipleMetadata.gxTpr_Visiblecondition;
            }
            else if ( A217WWPFormElementType == 4 )
            {
               AV14WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
               AV14WWP_DF_LabelMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV8VisibleCondition = AV14WWP_DF_LabelMetadata.gxTpr_Visiblecondition;
            }
            else if ( A217WWPFormElementType == 5 )
            {
               AV17WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
               AV17WWP_DF_StepMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV8VisibleCondition = AV17WWP_DF_StepMetadata.gxTpr_Visiblecondition;
            }
            if ( AV24IncludeElement && ( ! AV23EvaluateVisibilities || new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV21WWPFormInstance,  AV22WWPFormInstanceElementId,  AV8VisibleCondition) ) )
            {
               if ( ( A217WWPFormElementType != 2 ) || ( AV12WWP_DF_GroupMetadata.gxTpr_Style == 2 ) )
               {
                  AV18WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
                  AV18WWPFormElement.gxTpr_Wwpformelementid = A210WWPFormElementId;
                  AV18WWPFormElement.gxTpr_Wwpformelementcaption = A237WWPFormElementCaption;
                  AV18WWPFormElement.gxTpr_Wwpformelementdatatype = A218WWPFormElementDataType;
                  AV18WWPFormElement.gxTpr_Wwpformelementmetadata = A236WWPFormElementMetadata;
                  AV18WWPFormElement.gxTpr_Wwpformelementtitle = A229WWPFormElementTitle;
                  AV18WWPFormElement.gxTpr_Wwpformelementtype = A217WWPFormElementType;
                  AV18WWPFormElement.gxTpr_Wwpformelementparentid = A211WWPFormElementParentId;
                  AV20WWPFormElements.Add(AV18WWPFormElement, 0);
               }
               if ( ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 5 ) )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport(context ).execute(  AV21WWPFormInstance,  AV22WWPFormInstanceElementId,  A210WWPFormElementId,  AV23EvaluateVisibilities, ref  AV20WWPFormElements) ;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P004Y2_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         P004Y2_A218WWPFormElementDataType = new short[1] ;
         P004Y2_A211WWPFormElementParentId = new short[1] ;
         P004Y2_n211WWPFormElementParentId = new bool[] {false} ;
         P004Y2_A207WWPFormVersionNumber = new short[1] ;
         P004Y2_A206WWPFormId = new short[1] ;
         P004Y2_A217WWPFormElementType = new short[1] ;
         P004Y2_A236WWPFormElementMetadata = new string[] {""} ;
         P004Y2_A210WWPFormElementId = new short[1] ;
         P004Y2_A237WWPFormElementCaption = new short[1] ;
         P004Y2_A229WWPFormElementTitle = new string[] {""} ;
         P004Y2_A212WWPFormElementOrderIndex = new short[1] ;
         A236WWPFormElementMetadata = "";
         A229WWPFormElementTitle = "";
         AV8VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV9WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV16WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV11WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV13WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV12WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV15WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV14WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         AV17WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV18WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport__default(),
            new Object[][] {
                new Object[] {
               P004Y2_A238WWPFormElementExcludeFromExpor, P004Y2_A218WWPFormElementDataType, P004Y2_A211WWPFormElementParentId, P004Y2_n211WWPFormElementParentId, P004Y2_A207WWPFormVersionNumber, P004Y2_A206WWPFormId, P004Y2_A217WWPFormElementType, P004Y2_A236WWPFormElementMetadata, P004Y2_A210WWPFormElementId, P004Y2_A237WWPFormElementCaption,
               P004Y2_A229WWPFormElementTitle, P004Y2_A212WWPFormElementOrderIndex
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22WWPFormInstanceElementId ;
      private short AV19WWPFormElementParentId ;
      private short AV21WWPFormInstance_gxTpr_Wwpformid ;
      private short AV21WWPFormInstance_gxTpr_Wwpformversionnumber ;
      private short A211WWPFormElementParentId ;
      private short A218WWPFormElementDataType ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short A237WWPFormElementCaption ;
      private short A212WWPFormElementOrderIndex ;
      private bool AV23EvaluateVisibilities ;
      private bool A238WWPFormElementExcludeFromExpor ;
      private bool n211WWPFormElementParentId ;
      private bool AV24IncludeElement ;
      private string A236WWPFormElementMetadata ;
      private string A229WWPFormElementTitle ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV21WWPFormInstance ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> AV20WWPFormElements ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements ;
      private IDataStoreProvider pr_default ;
      private bool[] P004Y2_A238WWPFormElementExcludeFromExpor ;
      private short[] P004Y2_A218WWPFormElementDataType ;
      private short[] P004Y2_A211WWPFormElementParentId ;
      private bool[] P004Y2_n211WWPFormElementParentId ;
      private short[] P004Y2_A207WWPFormVersionNumber ;
      private short[] P004Y2_A206WWPFormId ;
      private short[] P004Y2_A217WWPFormElementType ;
      private string[] P004Y2_A236WWPFormElementMetadata ;
      private short[] P004Y2_A210WWPFormElementId ;
      private short[] P004Y2_A237WWPFormElementCaption ;
      private string[] P004Y2_A229WWPFormElementTitle ;
      private short[] P004Y2_A212WWPFormElementOrderIndex ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV8VisibleCondition ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV9WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV10WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV16WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV11WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV13WWP_DF_ImageMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV12WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV15WWP_DF_MultipleMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV14WWP_DF_LabelMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV17WWP_DF_StepMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18WWPFormElement ;
   }

   public class wwp_getelementsforreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Y2( IGxContext context ,
                                             short AV19WWPFormElementParentId ,
                                             short A211WWPFormElementParentId ,
                                             short A218WWPFormElementDataType ,
                                             bool A238WWPFormElementExcludeFromExpor ,
                                             short A206WWPFormId ,
                                             short AV21WWPFormInstance_gxTpr_Wwpformid ,
                                             short A207WWPFormVersionNumber ,
                                             short AV21WWPFormInstance_gxTpr_Wwpformversionnumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormElementExcludeFromExpor, WWPFormElementDataType, WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementMetadata, WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementOrderIndex FROM WWP_FormElement";
         AddWhere(sWhereString, "(WWPFormElementDataType <> 9)");
         AddWhere(sWhereString, "(WWPFormElementDataType <> 6)");
         AddWhere(sWhereString, "(Not WWPFormElementExcludeFromExpor)");
         AddWhere(sWhereString, "(WWPFormId = :AV21WWPF_1Wwpformid)");
         AddWhere(sWhereString, "(WWPFormVersionNumber = :AV21WWPF_2Wwpformversionnumbe)");
         if ( AV19WWPFormElementParentId > 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId = :AV19WWPFormElementParentId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV19WWPFormElementParentId == 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId IS NULL)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormElementOrderIndex";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004Y2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004Y2;
          prmP004Y2 = new Object[] {
          new ParDef("AV21WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV21WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV19WWPFormElementParentId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                return;
       }
    }

 }

}
