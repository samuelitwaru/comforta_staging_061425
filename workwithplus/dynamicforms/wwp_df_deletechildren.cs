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
   public class wwp_df_deletechildren : GXProcedure
   {
      public wwp_df_deletechildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_deletechildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           short aP1_WWPFormVersionNumber ,
                           short aP2_WWPFormElementId ,
                           ref GxSimpleCollection<short> aP3_WWPFormElementIdToDelete )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9WWPFormElementIdToDelete = aP3_WWPFormElementIdToDelete;
         initialize();
         ExecuteImpl();
         aP3_WWPFormElementIdToDelete=this.AV9WWPFormElementIdToDelete;
      }

      public GxSimpleCollection<short> executeUdp( short aP0_WWPFormId ,
                                                   short aP1_WWPFormVersionNumber ,
                                                   short aP2_WWPFormElementId )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, aP2_WWPFormElementId, ref aP3_WWPFormElementIdToDelete);
         return AV9WWPFormElementIdToDelete ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 short aP2_WWPFormElementId ,
                                 ref GxSimpleCollection<short> aP3_WWPFormElementIdToDelete )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9WWPFormElementIdToDelete = aP3_WWPFormElementIdToDelete;
         SubmitImpl();
         aP3_WWPFormElementIdToDelete=this.AV9WWPFormElementIdToDelete;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8WWPFormElementId ,
                                              A211WWPFormElementParentId ,
                                              A206WWPFormId ,
                                              AV10WWPFormId ,
                                              A207WWPFormVersionNumber ,
                                              AV11WWPFormVersionNumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P004K2 */
         pr_default.execute(0, new Object[] {AV10WWPFormId, AV11WWPFormVersionNumber, AV8WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A211WWPFormElementParentId = P004K2_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = P004K2_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = P004K2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004K2_A206WWPFormId[0];
            A217WWPFormElementType = P004K2_A217WWPFormElementType[0];
            A210WWPFormElementId = P004K2_A210WWPFormElementId[0];
            A212WWPFormElementOrderIndex = P004K2_A212WWPFormElementOrderIndex[0];
            if ( A217WWPFormElementType == 1 )
            {
               AV9WWPFormElementIdToDelete.Add(A210WWPFormElementId, 0);
            }
            else
            {
               if ( ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 5 ) )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deletechildren(context ).execute(  AV10WWPFormId,  AV11WWPFormVersionNumber,  A210WWPFormElementId, ref  AV9WWPFormElementIdToDelete) ;
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
         P004K2_A211WWPFormElementParentId = new short[1] ;
         P004K2_n211WWPFormElementParentId = new bool[] {false} ;
         P004K2_A207WWPFormVersionNumber = new short[1] ;
         P004K2_A206WWPFormId = new short[1] ;
         P004K2_A217WWPFormElementType = new short[1] ;
         P004K2_A210WWPFormElementId = new short[1] ;
         P004K2_A212WWPFormElementOrderIndex = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deletechildren__default(),
            new Object[][] {
                new Object[] {
               P004K2_A211WWPFormElementParentId, P004K2_n211WWPFormElementParentId, P004K2_A207WWPFormVersionNumber, P004K2_A206WWPFormId, P004K2_A217WWPFormElementType, P004K2_A210WWPFormElementId, P004K2_A212WWPFormElementOrderIndex
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPFormId ;
      private short AV11WWPFormVersionNumber ;
      private short AV8WWPFormElementId ;
      private short A211WWPFormElementParentId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short A212WWPFormElementOrderIndex ;
      private bool n211WWPFormElementParentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV9WWPFormElementIdToDelete ;
      private GxSimpleCollection<short> aP3_WWPFormElementIdToDelete ;
      private IDataStoreProvider pr_default ;
      private short[] P004K2_A211WWPFormElementParentId ;
      private bool[] P004K2_n211WWPFormElementParentId ;
      private short[] P004K2_A207WWPFormVersionNumber ;
      private short[] P004K2_A206WWPFormId ;
      private short[] P004K2_A217WWPFormElementType ;
      private short[] P004K2_A210WWPFormElementId ;
      private short[] P004K2_A212WWPFormElementOrderIndex ;
   }

   public class wwp_df_deletechildren__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004K2( IGxContext context ,
                                             short AV8WWPFormElementId ,
                                             short A211WWPFormElementParentId ,
                                             short A206WWPFormId ,
                                             short AV10WWPFormId ,
                                             short A207WWPFormVersionNumber ,
                                             short AV11WWPFormVersionNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementId, WWPFormElementOrderIndex FROM WWP_FormElement";
         AddWhere(sWhereString, "(WWPFormId = :AV10WWPFormId)");
         AddWhere(sWhereString, "(WWPFormVersionNumber = :AV11WWPFormVersionNumber)");
         if ( AV8WWPFormElementId > 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId = :AV8WWPFormElementId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV8WWPFormElementId == 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId IS NULL)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormElementOrderIndex DESC";
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
                     return conditional_P004K2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
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
          Object[] prmP004K2;
          prmP004K2 = new Object[] {
          new ParDef("AV10WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV11WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV8WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004K2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
