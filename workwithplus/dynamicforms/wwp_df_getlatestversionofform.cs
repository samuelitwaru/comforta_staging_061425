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
   public class wwp_df_getlatestversionofform : GXProcedure
   {
      public wwp_df_getlatestversionofform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getlatestversionofform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           out short aP1_WWPFormVersionNumber )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV8WWPFormVersionNumber = 0 ;
         initialize();
         ExecuteImpl();
         aP1_WWPFormVersionNumber=this.AV8WWPFormVersionNumber;
      }

      public short executeUdp( short aP0_WWPFormId )
      {
         execute(aP0_WWPFormId, out aP1_WWPFormVersionNumber);
         return AV8WWPFormVersionNumber ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 out short aP1_WWPFormVersionNumber )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV8WWPFormVersionNumber = 0 ;
         SubmitImpl();
         aP1_WWPFormVersionNumber=this.AV8WWPFormVersionNumber;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00423 */
         pr_default.execute(0, new Object[] {AV9WWPFormId});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00423_A40000GXC1[0];
            n40000GXC1 = P00423_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV8WWPFormVersionNumber = A40000GXC1;
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
         P00423_A40000GXC1 = new short[1] ;
         P00423_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform__default(),
            new Object[][] {
                new Object[] {
               P00423_A40000GXC1, P00423_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9WWPFormId ;
      private short AV8WWPFormVersionNumber ;
      private short A40000GXC1 ;
      private bool n40000GXC1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00423_A40000GXC1 ;
      private bool[] P00423_n40000GXC1 ;
      private short aP1_WWPFormVersionNumber ;
   }

   public class wwp_df_getlatestversionofform__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00423;
          prmP00423 = new Object[] {
          new ParDef("AV9WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00423", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT MAX(WWPFormVersionNumber) AS GXC1 FROM WWP_Form WHERE WWPFormId = :AV9WWPFormId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00423,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
