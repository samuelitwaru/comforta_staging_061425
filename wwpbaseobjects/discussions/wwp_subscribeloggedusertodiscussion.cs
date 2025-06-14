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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_subscribeloggedusertodiscussion : GXProcedure
   {
      public wwp_subscribeloggedusertodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscribeloggedusertodiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXLvl1 = 0;
         AV15Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV12WWPEntityName);
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {AV15Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128WWPNotificationDefinitionId = P003Y2_A128WWPNotificationDefinitionId[0];
            A125WWPEntityId = P003Y2_A125WWPEntityId[0];
            A164WWPNotificationDefinitionName = P003Y2_A164WWPNotificationDefinitionName[0];
            AV14GXLvl1 = 1;
            AV16GXLvl5 = 0;
            AV17Udparg2 = new uwwp_getloggeduserid(context).executeUdp( );
            /* Optimized UPDATE. */
            /* Using cursor P003Y3 */
            pr_default.execute(1, new Object[] {AV17Udparg2, A128WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV16GXLvl5 = 1;
            }
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
            /* End optimized UPDATE. */
            if ( AV16GXLvl5 == 0 )
            {
               AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
               GXt_char1 = "";
               new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV10WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               AV10WWPSubscription.Save();
               if ( AV10WWPSubscription.Success() )
               {
                  context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            GXt_int2 = AV13WWPEntityId;
            new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV12WWPEntityName, out  GXt_int2) ;
            AV13WWPEntityId = GXt_int2;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV18Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P003Y2_A128WWPNotificationDefinitionId = new long[1] ;
         P003Y2_A125WWPEntityId = new long[1] ;
         P003Y2_A164WWPNotificationDefinitionName = new string[] {""} ;
         A164WWPNotificationDefinitionName = "";
         AV17Udparg2 = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         AV18Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A128WWPNotificationDefinitionId, P003Y2_A125WWPEntityId, P003Y2_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV18Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
         /* GeneXus formulas. */
         AV18Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
      }

      private short AV14GXLvl1 ;
      private short AV16GXLvl5 ;
      private long AV15Udparg1 ;
      private long A128WWPNotificationDefinitionId ;
      private long A125WWPEntityId ;
      private long AV13WWPEntityId ;
      private long GXt_int2 ;
      private string AV17Udparg2 ;
      private string GXt_char1 ;
      private string AV18Pgmname ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV12WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A164WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003Y2_A128WWPNotificationDefinitionId ;
      private long[] P003Y2_A125WWPEntityId ;
      private string[] P003Y2_A164WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscribeloggedusertodiscussion__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wwp_subscribeloggedusertodiscussion__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class wwp_subscribeloggedusertodiscussion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP003Y2;
       prmP003Y2 = new Object[] {
       new ParDef("AV15Udparg1",GXType.Int64,10,0) ,
       new ParDef("AV8WWPNotificationDefinitionName",GXType.VarChar,100,0)
       };
       Object[] prmP003Y3;
       prmP003Y3 = new Object[] {
       new ParDef("AV17Udparg2",GXType.Char,40,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("AV9WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
       };
       def= new CursorDef[] {
           new CursorDef("P003Y2", "SELECT WWPNotificationDefinitionId, WWPEntityId, WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV15Udparg1) AND (WWPNotificationDefinitionName = ( :AV8WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P003Y3", "UPDATE WWP_Subscription SET WWPSubscriptionSubscribed=TRUE  WHERE (WWPUserExtendedId = ( :AV17Udparg2)) AND (WWPNotificationDefinitionId = :WWPNotificationDefinitionId) AND (WWPSubscriptionEntityRecordId = ( :AV9WWPSubscriptionEntityRecordId))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Y3)
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
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
    }
 }

}

}
