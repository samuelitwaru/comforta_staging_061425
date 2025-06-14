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
   public class prc_subscriberesidenttodiscussion : GXProcedure
   {
      public prc_subscriberesidenttodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_subscriberesidenttodiscussion( IGxContext context )
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
                           string aP3_WWPSubscriptionEntityRecordDescription ,
                           string aP4_ResidentGUID )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV14WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         this.AV16ResidentGUID = aP4_ResidentGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription ,
                                 string aP4_ResidentGUID )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV14WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         this.AV16ResidentGUID = aP4_ResidentGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  context.GetMessage( "Call to Subscribe Resident User ", "")+AV16ResidentGUID) ;
         AV17GXLvl2 = 0;
         AV18Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV14WWPEntityName);
         /* Using cursor P009R2 */
         pr_default.execute(0, new Object[] {AV18Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128WWPNotificationDefinitionId = P009R2_A128WWPNotificationDefinitionId[0];
            A125WWPEntityId = P009R2_A125WWPEntityId[0];
            A164WWPNotificationDefinitionName = P009R2_A164WWPNotificationDefinitionName[0];
            AV17GXLvl2 = 1;
            AV19GXLvl5 = 0;
            /* Optimized UPDATE. */
            /* Using cursor P009R3 */
            pr_default.execute(1, new Object[] {AV16ResidentGUID, A128WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV19GXLvl5 = 1;
            }
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
            /* End optimized UPDATE. */
            if ( AV19GXLvl5 == 0 )
            {
               AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
               AV10WWPSubscription.gxTpr_Wwpuserextendedid = AV16ResidentGUID;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               AV10WWPSubscription.Save();
               if ( ! AV10WWPSubscription.Success() )
               {
                  new prc_logtofile(context ).execute(  context.GetMessage( "Subscribe Resident User ", "")+AV10WWPSubscription.GetMessages().ToJSonString(false)) ;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV17GXLvl2 == 0 )
         {
            new prc_logtofile(context ).execute(  AV20Pgmname) ;
         }
         context.CommitDataStores("prc_subscriberesidenttodiscussion",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_subscriberesidenttodiscussion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P009R2_A128WWPNotificationDefinitionId = new long[1] ;
         P009R2_A125WWPEntityId = new long[1] ;
         P009R2_A164WWPNotificationDefinitionName = new string[] {""} ;
         A164WWPNotificationDefinitionName = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV20Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_subscriberesidenttodiscussion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_subscriberesidenttodiscussion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_subscriberesidenttodiscussion__default(),
            new Object[][] {
                new Object[] {
               P009R2_A128WWPNotificationDefinitionId, P009R2_A125WWPEntityId, P009R2_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV20Pgmname = "Prc_SubscribeResidentToDiscussion";
         /* GeneXus formulas. */
         AV20Pgmname = "Prc_SubscribeResidentToDiscussion";
      }

      private short AV17GXLvl2 ;
      private short AV19GXLvl5 ;
      private long AV18Udparg1 ;
      private long A128WWPNotificationDefinitionId ;
      private long A125WWPEntityId ;
      private string AV20Pgmname ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV14WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string AV16ResidentGUID ;
      private string A164WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009R2_A128WWPNotificationDefinitionId ;
      private long[] P009R2_A125WWPEntityId ;
      private string[] P009R2_A164WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_subscriberesidenttodiscussion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_subscriberesidenttodiscussion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_subscriberesidenttodiscussion__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP009R2;
       prmP009R2 = new Object[] {
       new ParDef("AV18Udparg1",GXType.Int64,10,0) ,
       new ParDef("AV8WWPNotificationDefinitionName",GXType.VarChar,100,0)
       };
       Object[] prmP009R3;
       prmP009R3 = new Object[] {
       new ParDef("AV16ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("AV9WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
       };
       def= new CursorDef[] {
           new CursorDef("P009R2", "SELECT WWPNotificationDefinitionId, WWPEntityId, WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV18Udparg1) AND (WWPNotificationDefinitionName = ( :AV8WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P009R3", "UPDATE WWP_Subscription SET WWPSubscriptionSubscribed=TRUE  WHERE (WWPUserExtendedId = ( :AV16ResidentGUID)) AND (WWPNotificationDefinitionId = :WWPNotificationDefinitionId) AND (WWPSubscriptionEntityRecordId = ( :AV9WWPSubscriptionEntityRecordId))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009R3)
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
