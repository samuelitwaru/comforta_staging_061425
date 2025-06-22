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
namespace GeneXus.Programs {
   public class prc_deleteformnotifications : GXProcedure
   {
      public prc_deleteformnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deleteformnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPFormReferenceName )
      {
         this.AV8WWPFormId = aP0_WWPFormId;
         this.AV9WWPFormReferenceName = aP1_WWPFormReferenceName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 string aP1_WWPFormReferenceName )
      {
         this.AV8WWPFormId = aP0_WWPFormId;
         this.AV9WWPFormReferenceName = aP1_WWPFormReferenceName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! (0==AV8WWPFormId) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9WWPFormReferenceName)) )
         {
            /* Using cursor P00GU2 */
            pr_default.execute(0, new Object[] {AV10ReferenceSearchKey});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127WWPNotificationId = P00GU2_A127WWPNotificationId[0];
               n127WWPNotificationId = P00GU2_n127WWPNotificationId[0];
               A184WWPNotificationLink = P00GU2_A184WWPNotificationLink[0];
               A129WWPNotificationCreated = P00GU2_A129WWPNotificationCreated[0];
               /* Optimized DELETE. */
               /* Using cursor P00GU3 */
               pr_default.execute(1, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
               /* End optimized DELETE. */
               /* Optimized DELETE. */
               /* Using cursor P00GU4 */
               pr_default.execute(2, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
               /* End optimized DELETE. */
               /* Optimized DELETE. */
               /* Using cursor P00GU5 */
               pr_default.execute(3, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
               /* End optimized DELETE. */
               /* Using cursor P00GU6 */
               pr_default.execute(4, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
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
         AV10ReferenceSearchKey = "";
         P00GU2_A127WWPNotificationId = new long[1] ;
         P00GU2_n127WWPNotificationId = new bool[] {false} ;
         P00GU2_A184WWPNotificationLink = new string[] {""} ;
         P00GU2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A184WWPNotificationLink = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deleteformnotifications__default(),
            new Object[][] {
                new Object[] {
               P00GU2_A127WWPNotificationId, P00GU2_A184WWPNotificationLink, P00GU2_A129WWPNotificationCreated
               }
               , new Object[] {
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

      private short AV8WWPFormId ;
      private long A127WWPNotificationId ;
      private DateTime A129WWPNotificationCreated ;
      private bool n127WWPNotificationId ;
      private string AV9WWPFormReferenceName ;
      private string AV10ReferenceSearchKey ;
      private string A184WWPNotificationLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GU2_A127WWPNotificationId ;
      private bool[] P00GU2_n127WWPNotificationId ;
      private string[] P00GU2_A184WWPNotificationLink ;
      private DateTime[] P00GU2_A129WWPNotificationCreated ;
   }

   public class prc_deleteformnotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GU2;
          prmP00GU2 = new Object[] {
          new ParDef("AV10ReferenceSearchKey",GXType.VarChar,100,0)
          };
          Object[] prmP00GU3;
          prmP00GU3 = new Object[] {
          new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmP00GU4;
          prmP00GU4 = new Object[] {
          new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmP00GU5;
          prmP00GU5 = new Object[] {
          new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmP00GU6;
          prmP00GU6 = new Object[] {
          new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00GU2", "SELECT WWPNotificationId, WWPNotificationLink, WWPNotificationCreated FROM WWP_Notification WHERE POSITION(RTRIM(:AV10ReferenceSearchKey) IN WWPNotificationLink) >= 1 ORDER BY WWPNotificationCreated DESC  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GU2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GU3", "DELETE FROM WWP_WebNotification  WHERE WWPNotificationId = :WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GU3)
             ,new CursorDef("P00GU4", "DELETE FROM WWP_SMS  WHERE WWPNotificationId = :WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GU4)
             ,new CursorDef("P00GU5", "DELETE FROM WWP_Mail  WHERE WWPNotificationId = :WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GU5)
             ,new CursorDef("P00GU6", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GU6)
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                return;
       }
    }

 }

}
