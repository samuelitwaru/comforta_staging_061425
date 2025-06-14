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
   public class wwp_df_getelementparent : GXProcedure
   {
      public wwp_df_getelementparent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getelementparent( IGxContext context )
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
                           out string aP3_WWPFormElementMetadata ,
                           out short aP4_WWPFormElementParentId ,
                           out short aP5_WWPFormElementParentType )
      {
         this.AV12WWPFormId = aP0_WWPFormId;
         this.AV13WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV9WWPFormElementId = aP2_WWPFormElementId;
         this.AV8WWPFormElementMetadata = "" ;
         this.AV10WWPFormElementParentId = 0 ;
         this.AV11WWPFormElementParentType = 0 ;
         initialize();
         ExecuteImpl();
         aP3_WWPFormElementMetadata=this.AV8WWPFormElementMetadata;
         aP4_WWPFormElementParentId=this.AV10WWPFormElementParentId;
         aP5_WWPFormElementParentType=this.AV11WWPFormElementParentType;
      }

      public short executeUdp( short aP0_WWPFormId ,
                               short aP1_WWPFormVersionNumber ,
                               short aP2_WWPFormElementId ,
                               out string aP3_WWPFormElementMetadata ,
                               out short aP4_WWPFormElementParentId )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, aP2_WWPFormElementId, out aP3_WWPFormElementMetadata, out aP4_WWPFormElementParentId, out aP5_WWPFormElementParentType);
         return AV11WWPFormElementParentType ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 short aP2_WWPFormElementId ,
                                 out string aP3_WWPFormElementMetadata ,
                                 out short aP4_WWPFormElementParentId ,
                                 out short aP5_WWPFormElementParentType )
      {
         this.AV12WWPFormId = aP0_WWPFormId;
         this.AV13WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV9WWPFormElementId = aP2_WWPFormElementId;
         this.AV8WWPFormElementMetadata = "" ;
         this.AV10WWPFormElementParentId = 0 ;
         this.AV11WWPFormElementParentType = 0 ;
         SubmitImpl();
         aP3_WWPFormElementMetadata=this.AV8WWPFormElementMetadata;
         aP4_WWPFormElementParentId=this.AV10WWPFormElementParentId;
         aP5_WWPFormElementParentType=this.AV11WWPFormElementParentType;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00522 */
         pr_default.execute(0, new Object[] {AV12WWPFormId, AV13WWPFormVersionNumber, AV9WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = P00522_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = P00522_A207WWPFormVersionNumber[0];
            A206WWPFormId = P00522_A206WWPFormId[0];
            A211WWPFormElementParentId = P00522_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = P00522_n211WWPFormElementParentId[0];
            A230WWPFormElementParentType = P00522_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = P00522_A236WWPFormElementMetadata[0];
            A230WWPFormElementParentType = P00522_A230WWPFormElementParentType[0];
            AV10WWPFormElementParentId = A211WWPFormElementParentId;
            AV11WWPFormElementParentType = A230WWPFormElementParentType;
            AV8WWPFormElementMetadata = A236WWPFormElementMetadata;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV8WWPFormElementMetadata = "";
         P00522_A210WWPFormElementId = new short[1] ;
         P00522_A207WWPFormVersionNumber = new short[1] ;
         P00522_A206WWPFormId = new short[1] ;
         P00522_A211WWPFormElementParentId = new short[1] ;
         P00522_n211WWPFormElementParentId = new bool[] {false} ;
         P00522_A230WWPFormElementParentType = new short[1] ;
         P00522_A236WWPFormElementMetadata = new string[] {""} ;
         A236WWPFormElementMetadata = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementparent__default(),
            new Object[][] {
                new Object[] {
               P00522_A210WWPFormElementId, P00522_A207WWPFormVersionNumber, P00522_A206WWPFormId, P00522_A211WWPFormElementParentId, P00522_n211WWPFormElementParentId, P00522_A230WWPFormElementParentType, P00522_A236WWPFormElementMetadata
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12WWPFormId ;
      private short AV13WWPFormVersionNumber ;
      private short AV9WWPFormElementId ;
      private short AV10WWPFormElementParentId ;
      private short AV11WWPFormElementParentType ;
      private short A210WWPFormElementId ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A211WWPFormElementParentId ;
      private short A230WWPFormElementParentType ;
      private bool n211WWPFormElementParentId ;
      private string AV8WWPFormElementMetadata ;
      private string A236WWPFormElementMetadata ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00522_A210WWPFormElementId ;
      private short[] P00522_A207WWPFormVersionNumber ;
      private short[] P00522_A206WWPFormId ;
      private short[] P00522_A211WWPFormElementParentId ;
      private bool[] P00522_n211WWPFormElementParentId ;
      private short[] P00522_A230WWPFormElementParentType ;
      private string[] P00522_A236WWPFormElementMetadata ;
      private string aP3_WWPFormElementMetadata ;
      private short aP4_WWPFormElementParentId ;
      private short aP5_WWPFormElementParentType ;
   }

   public class wwp_df_getelementparent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00522;
          prmP00522 = new Object[] {
          new ParDef("AV12WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV13WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV9WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00522", "SELECT T1.WWPFormElementId, T1.WWPFormVersionNumber, T1.WWPFormId, T1.WWPFormElementParentId AS WWPFormElementParentId, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :AV12WWPFormId and T1.WWPFormVersionNumber = :AV13WWPFormVersionNumber and T1.WWPFormElementId = :AV9WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00522,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                return;
       }
    }

 }

}
