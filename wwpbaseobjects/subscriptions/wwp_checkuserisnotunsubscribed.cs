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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_checkuserisnotunsubscribed : GXProcedure
   {
      public wwp_checkuserisnotunsubscribed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_checkuserisnotunsubscribed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPNotificationDefinitionId ,
                           ref long aP1_WWPSubscriptionId ,
                           ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         initialize();
         ExecuteImpl();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      public bool executeUdp( long aP0_WWPNotificationDefinitionId ,
                              ref long aP1_WWPSubscriptionId )
      {
         execute(aP0_WWPNotificationDefinitionId, ref aP1_WWPSubscriptionId, ref aP2_IncludeNotification);
         return AV8IncludeNotification ;
      }

      public void executeSubmit( long aP0_WWPNotificationDefinitionId ,
                                 ref long aP1_WWPSubscriptionId ,
                                 ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         SubmitImpl();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Udparg1 = new uwwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P00342 */
         pr_default.execute(0, new Object[] {AV12Udparg1, AV9WWPNotificationDefinitionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A132WWPSubscriptionSubscribed = P00342_A132WWPSubscriptionSubscribed[0];
            A112WWPUserExtendedId = P00342_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P00342_n112WWPUserExtendedId[0];
            A128WWPNotificationDefinitionId = P00342_A128WWPNotificationDefinitionId[0];
            A130WWPSubscriptionId = P00342_A130WWPSubscriptionId[0];
            AV8IncludeNotification = false;
            AV10WWPSubscriptionId = A130WWPSubscriptionId;
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
         AV12Udparg1 = "";
         P00342_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         P00342_A112WWPUserExtendedId = new string[] {""} ;
         P00342_n112WWPUserExtendedId = new bool[] {false} ;
         P00342_A128WWPNotificationDefinitionId = new long[1] ;
         P00342_A130WWPSubscriptionId = new long[1] ;
         A112WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed__default(),
            new Object[][] {
                new Object[] {
               P00342_A132WWPSubscriptionSubscribed, P00342_A112WWPUserExtendedId, P00342_n112WWPUserExtendedId, P00342_A128WWPNotificationDefinitionId, P00342_A130WWPSubscriptionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9WWPNotificationDefinitionId ;
      private long AV10WWPSubscriptionId ;
      private long A128WWPNotificationDefinitionId ;
      private long A130WWPSubscriptionId ;
      private string AV12Udparg1 ;
      private string A112WWPUserExtendedId ;
      private bool AV8IncludeNotification ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n112WWPUserExtendedId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private bool aP2_IncludeNotification ;
      private IDataStoreProvider pr_default ;
      private bool[] P00342_A132WWPSubscriptionSubscribed ;
      private string[] P00342_A112WWPUserExtendedId ;
      private bool[] P00342_n112WWPUserExtendedId ;
      private long[] P00342_A128WWPNotificationDefinitionId ;
      private long[] P00342_A130WWPSubscriptionId ;
   }

   public class wwp_checkuserisnotunsubscribed__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00342;
          prmP00342 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Char,40,0) ,
          new ParDef("AV9WWPNotificationDefinitionId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00342", "SELECT WWPSubscriptionSubscribed, WWPUserExtendedId, WWPNotificationDefinitionId, WWPSubscriptionId FROM WWP_Subscription WHERE (WWPUserExtendedId = ( :AV12Udparg1)) AND (WWPNotificationDefinitionId = :AV9WWPNotificationDefinitionId) AND (WWPSubscriptionSubscribed = FALSE) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00342,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
