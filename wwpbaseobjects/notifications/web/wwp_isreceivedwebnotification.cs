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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_isreceivedwebnotification : GXProcedure
   {
      public wwp_isreceivedwebnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_isreceivedwebnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WebNotificationId ,
                           out bool aP1_IsRecived )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         this.AV9IsRecived = false ;
         initialize();
         ExecuteImpl();
         aP1_IsRecived=this.AV9IsRecived;
      }

      public bool executeUdp( long aP0_WebNotificationId )
      {
         execute(aP0_WebNotificationId, out aP1_IsRecived);
         return AV9IsRecived ;
      }

      public void executeSubmit( long aP0_WebNotificationId ,
                                 out bool aP1_IsRecived )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         this.AV9IsRecived = false ;
         SubmitImpl();
         aP1_IsRecived=this.AV9IsRecived;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsRecived = false;
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {AV8WebNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A152WWPWebNotificationId = P003I2_A152WWPWebNotificationId[0];
            A162WWPWebNotificationReceived = P003I2_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = P003I2_n162WWPWebNotificationReceived[0];
            if ( A162WWPWebNotificationReceived )
            {
               AV9IsRecived = true;
            }
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
         P003I2_A152WWPWebNotificationId = new long[1] ;
         P003I2_A162WWPWebNotificationReceived = new bool[] {false} ;
         P003I2_n162WWPWebNotificationReceived = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification__default(),
            new Object[][] {
                new Object[] {
               P003I2_A152WWPWebNotificationId, P003I2_A162WWPWebNotificationReceived, P003I2_n162WWPWebNotificationReceived
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WebNotificationId ;
      private long A152WWPWebNotificationId ;
      private bool AV9IsRecived ;
      private bool A162WWPWebNotificationReceived ;
      private bool n162WWPWebNotificationReceived ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003I2_A152WWPWebNotificationId ;
      private bool[] P003I2_A162WWPWebNotificationReceived ;
      private bool[] P003I2_n162WWPWebNotificationReceived ;
      private bool aP1_IsRecived ;
   }

   public class wwp_isreceivedwebnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003I2;
          prmP003I2 = new Object[] {
          new ParDef("AV8WebNotificationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003I2", "SELECT WWPWebNotificationId, WWPWebNotificationReceived FROM WWP_WebNotification WHERE WWPWebNotificationId = :AV8WebNotificationId ORDER BY WWPWebNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
