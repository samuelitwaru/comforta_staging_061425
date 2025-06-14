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
   public class wwp_userupdatesubscription : GXProcedure
   {
      public wwp_userupdatesubscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userupdatesubscription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_Subscribe ,
                           ref long aP1_WWPSubscriptionId ,
                           long aP2_WWPNotificationDefinitionId ,
                           string aP3_WWPSubscriptionEntityRecordId ,
                           string aP4_WWPSubscriptionEntityRecordDescription )
      {
         this.AV12Subscribe = aP0_Subscribe;
         this.AV8WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionEntityRecordId = aP3_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP4_WWPSubscriptionEntityRecordDescription;
         initialize();
         ExecuteImpl();
         aP1_WWPSubscriptionId=this.AV8WWPSubscriptionId;
      }

      public void executeSubmit( bool aP0_Subscribe ,
                                 ref long aP1_WWPSubscriptionId ,
                                 long aP2_WWPNotificationDefinitionId ,
                                 string aP3_WWPSubscriptionEntityRecordId ,
                                 string aP4_WWPSubscriptionEntityRecordDescription )
      {
         this.AV12Subscribe = aP0_Subscribe;
         this.AV8WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionEntityRecordId = aP3_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP4_WWPSubscriptionEntityRecordDescription;
         SubmitImpl();
         aP1_WWPSubscriptionId=this.AV8WWPSubscriptionId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV12Subscribe )
         {
            AV13WWPSubscription.Load(AV8WWPSubscriptionId);
            if ( AV13WWPSubscription.Success() )
            {
               AV13WWPSubscription.Delete();
               AV8WWPSubscriptionId = 0;
            }
            else
            {
               AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV13WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV10WWPSubscriptionEntityRecordId;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               GXt_char1 = "";
               new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV13WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV13WWPSubscription.Save();
               AV8WWPSubscriptionId = AV13WWPSubscription.gxTpr_Wwpsubscriptionid;
            }
         }
         else
         {
            if ( AV8WWPSubscriptionId == 0 )
            {
               /* Execute user subroutine: 'CREATESUBSCRIPTIONNOTSUBSCRIBED' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV13WWPSubscription.Load(AV8WWPSubscriptionId);
               if ( StringUtil.StrCmp(AV13WWPSubscription.gxTpr_Wwpuserextendedid, new uwwp_getloggeduserid(context).executeUdp( )) == 0 )
               {
                  AV13WWPSubscription.Delete();
               }
               else
               {
                  /* Execute user subroutine: 'CREATESUBSCRIPTIONNOTSUBSCRIBED' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
            }
         }
         if ( AV13WWPSubscription.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_userupdatesubscription",pr_default);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATESUBSCRIPTIONNOTSUBSCRIBED' Routine */
         returnInSub = false;
         AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV13WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV10WWPSubscriptionEntityRecordId;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = false;
         GXt_char1 = "";
         new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         AV13WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
         AV13WWPSubscription.Save();
         AV8WWPSubscriptionId = AV13WWPSubscription.gxTpr_Wwpsubscriptionid;
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
         AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPSubscriptionId ;
      private long AV9WWPNotificationDefinitionId ;
      private string GXt_char1 ;
      private bool AV12Subscribe ;
      private bool returnInSub ;
      private string AV10WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV13WWPSubscription ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userupdatesubscription__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userupdatesubscription__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_userupdatesubscription__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
