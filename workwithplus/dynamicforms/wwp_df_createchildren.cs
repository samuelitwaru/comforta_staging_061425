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
   public class wwp_df_createchildren : GXProcedure
   {
      public wwp_df_createchildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_createchildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormInstanceElementId ,
                           short aP1_WWPFormElementId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP2_WWPFormInstance )
      {
         this.AV9WWPFormInstanceElementId = aP0_WWPFormInstanceElementId;
         this.AV10WWPFormElementId = aP1_WWPFormElementId;
         this.AV8WWPFormInstance = aP2_WWPFormInstance;
         initialize();
         ExecuteImpl();
         aP2_WWPFormInstance=this.AV8WWPFormInstance;
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance executeUdp( short aP0_WWPFormInstanceElementId ,
                                                                                        short aP1_WWPFormElementId )
      {
         execute(aP0_WWPFormInstanceElementId, aP1_WWPFormElementId, ref aP2_WWPFormInstance);
         return AV8WWPFormInstance ;
      }

      public void executeSubmit( short aP0_WWPFormInstanceElementId ,
                                 short aP1_WWPFormElementId ,
                                 ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP2_WWPFormInstance )
      {
         this.AV9WWPFormInstanceElementId = aP0_WWPFormInstanceElementId;
         this.AV10WWPFormElementId = aP1_WWPFormElementId;
         this.AV8WWPFormInstance = aP2_WWPFormInstance;
         SubmitImpl();
         aP2_WWPFormInstance=this.AV8WWPFormInstance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10WWPFormElementId ,
                                              A211WWPFormElementParentId ,
                                              A206WWPFormId ,
                                              AV8WWPFormInstance.gxTpr_Wwpformid ,
                                              A207WWPFormVersionNumber ,
                                              AV8WWPFormInstance.gxTpr_Wwpformversionnumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P004J2 */
         pr_default.execute(0, new Object[] {AV8WWPFormInstance.gxTpr_Wwpformid, AV8WWPFormInstance.gxTpr_Wwpformversionnumber, AV10WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A211WWPFormElementParentId = P004J2_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = P004J2_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = P004J2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004J2_A206WWPFormId[0];
            A217WWPFormElementType = P004J2_A217WWPFormElementType[0];
            A210WWPFormElementId = P004J2_A210WWPFormElementId[0];
            A218WWPFormElementDataType = P004J2_A218WWPFormElementDataType[0];
            A236WWPFormElementMetadata = P004J2_A236WWPFormElementMetadata[0];
            A212WWPFormElementOrderIndex = P004J2_A212WWPFormElementOrderIndex[0];
            if ( A217WWPFormElementType == 1 )
            {
               AV11WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
               AV11WWPFormInstanceElement.gxTpr_Wwpformelementid = A210WWPFormElementId;
               AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid = AV9WWPFormInstanceElementId;
               if ( ( A218WWPFormElementDataType == 2 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) || ( A218WWPFormElementDataType == 6 ) )
               {
                  AV12WWP_DF_CharMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = AV12WWP_DF_CharMetadata.gxTpr_Defaultvalue;
               }
               else if ( A218WWPFormElementDataType == 1 )
               {
                  AV13WWP_DF_BooleanMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelemboolean = AV13WWP_DF_BooleanMetadata.gxTpr_Defaultvalue;
               }
               else if ( A218WWPFormElementDataType == 3 )
               {
                  AV14WWP_DF_NumericMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric = AV14WWP_DF_NumericMetadata.gxTpr_Defaultvalue;
               }
               else if ( A218WWPFormElementDataType == 4 )
               {
                  AV15WWP_DF_DateMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  if ( AV15WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday )
                  {
                     AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelemdate = Gx_date;
                  }
               }
               else if ( A218WWPFormElementDataType == 5 )
               {
                  AV15WWP_DF_DateMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  if ( AV15WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday )
                  {
                     AV11WWPFormInstanceElement.gxTpr_Wwpforminstanceelemdatetime = DateTimeUtil.Now( context);
                  }
               }
               AV8WWPFormInstance.gxTpr_Element.Add(AV11WWPFormInstanceElement, 0);
            }
            else if ( ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 5 ) )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV9WWPFormInstanceElementId,  A210WWPFormElementId, ref  AV8WWPFormInstance) ;
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
         P004J2_A211WWPFormElementParentId = new short[1] ;
         P004J2_n211WWPFormElementParentId = new bool[] {false} ;
         P004J2_A207WWPFormVersionNumber = new short[1] ;
         P004J2_A206WWPFormId = new short[1] ;
         P004J2_A217WWPFormElementType = new short[1] ;
         P004J2_A210WWPFormElementId = new short[1] ;
         P004J2_A218WWPFormElementDataType = new short[1] ;
         P004J2_A236WWPFormElementMetadata = new string[] {""} ;
         P004J2_A212WWPFormElementOrderIndex = new short[1] ;
         A236WWPFormElementMetadata = "";
         AV11WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV12WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV13WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV14WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV15WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren__default(),
            new Object[][] {
                new Object[] {
               P004J2_A211WWPFormElementParentId, P004J2_n211WWPFormElementParentId, P004J2_A207WWPFormVersionNumber, P004J2_A206WWPFormId, P004J2_A217WWPFormElementType, P004J2_A210WWPFormElementId, P004J2_A218WWPFormElementDataType, P004J2_A236WWPFormElementMetadata, P004J2_A212WWPFormElementOrderIndex
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV9WWPFormInstanceElementId ;
      private short AV10WWPFormElementId ;
      private short AV8WWPFormInstance_gxTpr_Wwpformid ;
      private short AV8WWPFormInstance_gxTpr_Wwpformversionnumber ;
      private short A211WWPFormElementParentId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short A218WWPFormElementDataType ;
      private short A212WWPFormElementOrderIndex ;
      private DateTime Gx_date ;
      private bool n211WWPFormElementParentId ;
      private string A236WWPFormElementMetadata ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV8WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP2_WWPFormInstance ;
      private IDataStoreProvider pr_default ;
      private short[] P004J2_A211WWPFormElementParentId ;
      private bool[] P004J2_n211WWPFormElementParentId ;
      private short[] P004J2_A207WWPFormVersionNumber ;
      private short[] P004J2_A206WWPFormId ;
      private short[] P004J2_A217WWPFormElementType ;
      private short[] P004J2_A210WWPFormElementId ;
      private short[] P004J2_A218WWPFormElementDataType ;
      private string[] P004J2_A236WWPFormElementMetadata ;
      private short[] P004J2_A212WWPFormElementOrderIndex ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV11WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV12WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV13WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV14WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV15WWP_DF_DateMetadata ;
   }

   public class wwp_df_createchildren__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004J2( IGxContext context ,
                                             short AV10WWPFormElementId ,
                                             short A211WWPFormElementParentId ,
                                             short A206WWPFormId ,
                                             short AV8WWPFormInstance_gxTpr_Wwpformid ,
                                             short A207WWPFormVersionNumber ,
                                             short AV8WWPFormInstance_gxTpr_Wwpformversionnumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementId, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementOrderIndex FROM WWP_FormElement";
         AddWhere(sWhereString, "(WWPFormId = :AV8WWPFormInstance__Wwpformid)");
         AddWhere(sWhereString, "(WWPFormVersionNumber = :AV8WWPFo_1Wwpformversionnumbe)");
         if ( AV10WWPFormElementId > 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId = :AV10WWPFormElementId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV10WWPFormElementId == 0 )
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
                     return conditional_P004J2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
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
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          new ParDef("AV8WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV8WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV10WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
