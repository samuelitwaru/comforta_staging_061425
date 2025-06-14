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
   public class wwp_df_isinsidegrouporstep : GXProcedure
   {
      public wwp_df_isinsidegrouporstep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_isinsidegrouporstep( IGxContext context )
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
                           out bool aP3_IsInsideGroup )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9IsInsideGroup = false ;
         initialize();
         ExecuteImpl();
         aP3_IsInsideGroup=this.AV9IsInsideGroup;
      }

      public bool executeUdp( short aP0_WWPFormId ,
                              short aP1_WWPFormVersionNumber ,
                              short aP2_WWPFormElementId )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, aP2_WWPFormElementId, out aP3_IsInsideGroup);
         return AV9IsInsideGroup ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 short aP2_WWPFormElementId ,
                                 out bool aP3_IsInsideGroup )
      {
         this.AV10WWPFormId = aP0_WWPFormId;
         this.AV11WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV8WWPFormElementId = aP2_WWPFormElementId;
         this.AV9IsInsideGroup = false ;
         SubmitImpl();
         aP3_IsInsideGroup=this.AV9IsInsideGroup;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsInsideGroup = false;
         /* Using cursor P004M2 */
         pr_default.execute(0, new Object[] {AV10WWPFormId, AV11WWPFormVersionNumber, AV8WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = P004M2_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = P004M2_A207WWPFormVersionNumber[0];
            A206WWPFormId = P004M2_A206WWPFormId[0];
            A217WWPFormElementType = P004M2_A217WWPFormElementType[0];
            A211WWPFormElementParentId = P004M2_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = P004M2_n211WWPFormElementParentId[0];
            if ( ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 5 ) )
            {
               AV9IsInsideGroup = true;
            }
            else
            {
               if ( A217WWPFormElementType == 3 )
               {
                  GXt_boolean1 = AV9IsInsideGroup;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_isinsidegrouporstep(context ).execute(  AV10WWPFormId,  AV11WWPFormVersionNumber,  A211WWPFormElementParentId, out  GXt_boolean1) ;
                  AV9IsInsideGroup = (bool)(AV9IsInsideGroup||GXt_boolean1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         P004M2_A210WWPFormElementId = new short[1] ;
         P004M2_A207WWPFormVersionNumber = new short[1] ;
         P004M2_A206WWPFormId = new short[1] ;
         P004M2_A217WWPFormElementType = new short[1] ;
         P004M2_A211WWPFormElementParentId = new short[1] ;
         P004M2_n211WWPFormElementParentId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_isinsidegrouporstep__default(),
            new Object[][] {
                new Object[] {
               P004M2_A210WWPFormElementId, P004M2_A207WWPFormVersionNumber, P004M2_A206WWPFormId, P004M2_A217WWPFormElementType, P004M2_A211WWPFormElementParentId, P004M2_n211WWPFormElementParentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPFormId ;
      private short AV11WWPFormVersionNumber ;
      private short AV8WWPFormElementId ;
      private short A210WWPFormElementId ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A217WWPFormElementType ;
      private short A211WWPFormElementParentId ;
      private bool AV9IsInsideGroup ;
      private bool n211WWPFormElementParentId ;
      private bool GXt_boolean1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004M2_A210WWPFormElementId ;
      private short[] P004M2_A207WWPFormVersionNumber ;
      private short[] P004M2_A206WWPFormId ;
      private short[] P004M2_A217WWPFormElementType ;
      private short[] P004M2_A211WWPFormElementParentId ;
      private bool[] P004M2_n211WWPFormElementParentId ;
      private bool aP3_IsInsideGroup ;
   }

   public class wwp_df_isinsidegrouporstep__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          new ParDef("AV10WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV11WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV8WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :AV10WWPFormId and WWPFormVersionNumber = :AV11WWPFormVersionNumber and WWPFormElementId = :AV8WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
