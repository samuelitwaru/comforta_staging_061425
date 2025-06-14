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
   public class wwp_changenotificationstatus : GXProcedure
   {
      public wwp_changenotificationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_changenotificationstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_setnotificationreadunreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadUnreadById Constructor */
         /* Using cursor P003Q2 */
         pr_default.execute(0, new Object[] {AV8WWPNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127WWPNotificationId = P003Q2_A127WWPNotificationId[0];
            A187WWPNotificationIsRead = P003Q2_A187WWPNotificationIsRead[0];
            if ( A187WWPNotificationIsRead )
            {
               A187WWPNotificationIsRead = false;
            }
            else
            {
               A187WWPNotificationIsRead = true;
            }
            /* Using cursor P003Q3 */
            pr_default.execute(1, new Object[] {A187WWPNotificationIsRead, A127WWPNotificationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         ExecuteImpl();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         cleanup();
      }

      public void gxep_setnotificationreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadById Constructor */
         /* Optimized UPDATE. */
         /* Using cursor P003Q4 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         ExecuteImpl();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         cleanup();
      }

      public void gxep_setallnotificationsofloggeduserread( )
      {
         initialize();
         /* SetAllNotificationsOfLoggedUserRead Constructor */
         AV12Udparg1 = new uwwp_getloggeduserid(context).executeUdp( );
         /* Optimized UPDATE. */
         /* Using cursor P003Q5 */
         pr_default.execute(3, new Object[] {AV12Udparg1});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         ExecuteImpl();
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_changenotificationstatus",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P003Q2_A127WWPNotificationId = new long[1] ;
         P003Q2_A187WWPNotificationIsRead = new bool[] {false} ;
         AV12Udparg1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus__default(),
            new Object[][] {
                new Object[] {
               P003Q2_A127WWPNotificationId, P003Q2_A187WWPNotificationIsRead
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPNotificationId ;
      private long A127WWPNotificationId ;
      private string AV12Udparg1 ;
      private bool A187WWPNotificationIsRead ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] P003Q2_A127WWPNotificationId ;
      private bool[] P003Q2_A187WWPNotificationIsRead ;
   }

   public class wwp_changenotificationstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003Q2;
          prmP003Q2 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP003Q3;
          prmP003Q3 = new Object[] {
          new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
          new ParDef("WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP003Q4;
          prmP003Q4 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP003Q5;
          prmP003Q5 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Q2", "SELECT WWPNotificationId, WWPNotificationIsRead FROM WWP_Notification WHERE WWPNotificationId = :AV8WWPNotificationId ORDER BY WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Q2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P003Q3", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationIsRead=:WWPNotificationIsRead  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Q3)
             ,new CursorDef("P003Q4", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPNotificationId = :AV8WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Q4)
             ,new CursorDef("P003Q5", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPUserExtendedId = ( :AV12Udparg1)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Q5)
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
                return;
       }
    }

 }

}
