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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationdefinitionbyname : GXProcedure
   {
      public wwp_getnotificationdefinitionbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationdefinitionbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           long aP1_WWPEntityId ,
                           out long aP2_WWPNotificationDefinitionId )
      {
         this.AV10WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV8WWPEntityId = aP1_WWPEntityId;
         this.AV9WWPNotificationDefinitionId = 0 ;
         initialize();
         ExecuteImpl();
         aP2_WWPNotificationDefinitionId=this.AV9WWPNotificationDefinitionId;
      }

      public long executeUdp( string aP0_WWPNotificationDefinitionName ,
                              long aP1_WWPEntityId )
      {
         execute(aP0_WWPNotificationDefinitionName, aP1_WWPEntityId, out aP2_WWPNotificationDefinitionId);
         return AV9WWPNotificationDefinitionId ;
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 long aP1_WWPEntityId ,
                                 out long aP2_WWPNotificationDefinitionId )
      {
         this.AV10WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV8WWPEntityId = aP1_WWPEntityId;
         this.AV9WWPNotificationDefinitionId = 0 ;
         SubmitImpl();
         aP2_WWPNotificationDefinitionId=this.AV9WWPNotificationDefinitionId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WWPNotificationDefinitionId = 0;
         /* Using cursor P00332 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A125WWPEntityId = P00332_A125WWPEntityId[0];
            A164WWPNotificationDefinitionName = P00332_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P00332_A128WWPNotificationDefinitionId[0];
            AV9WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00332_A125WWPEntityId = new long[1] ;
         P00332_A164WWPNotificationDefinitionName = new string[] {""} ;
         P00332_A128WWPNotificationDefinitionId = new long[1] ;
         A164WWPNotificationDefinitionName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationdefinitionbyname__default(),
            new Object[][] {
                new Object[] {
               P00332_A125WWPEntityId, P00332_A164WWPNotificationDefinitionName, P00332_A128WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPEntityId ;
      private long AV9WWPNotificationDefinitionId ;
      private long A125WWPEntityId ;
      private long A128WWPNotificationDefinitionId ;
      private string AV10WWPNotificationDefinitionName ;
      private string A164WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00332_A125WWPEntityId ;
      private string[] P00332_A164WWPNotificationDefinitionName ;
      private long[] P00332_A128WWPNotificationDefinitionId ;
      private long aP2_WWPNotificationDefinitionId ;
   }

   public class wwp_getnotificationdefinitionbyname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00332;
          prmP00332 = new Object[] {
          new ParDef("AV8WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("AV10WWPNotificationDefinitionName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00332", "SELECT WWPEntityId, WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV8WWPEntityId) AND (WWPNotificationDefinitionName = ( :AV10WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00332,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
