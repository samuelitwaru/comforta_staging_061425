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
   public class wwp_createandnotifydiscussionmessage : GXProcedure
   {
      public wwp_createandnotifydiscussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createandnotifydiscussionmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPEntityId ,
                           long aP1_WWPDiscussionMessageThreadId ,
                           string aP2_WWPDiscussionMessageEntityRecordId ,
                           string aP3_Message ,
                           string aP4_MentionWWPUserExtendedIdCollectionJson ,
                           string aP5_SessionValue ,
                           string aP6_NotificationTitle ,
                           string aP7_WWPSubscriptionEntityRecordDescription ,
                           string aP8_WWPNotificationLink ,
                           out bool aP9_DiscussionMessageCreated )
      {
         this.AV18WWPEntityId = aP0_WWPEntityId;
         this.AV17WWPDiscussionMessageThreadId = aP1_WWPDiscussionMessageThreadId;
         this.AV16WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV14Message = aP3_Message;
         this.AV13MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         this.AV15SessionValue = aP5_SessionValue;
         this.AV19NotificationTitle = aP6_NotificationTitle;
         this.AV21WWPSubscriptionEntityRecordDescription = aP7_WWPSubscriptionEntityRecordDescription;
         this.AV20WWPNotificationLink = aP8_WWPNotificationLink;
         this.AV11DiscussionMessageCreated = false ;
         initialize();
         ExecuteImpl();
         aP9_DiscussionMessageCreated=this.AV11DiscussionMessageCreated;
      }

      public bool executeUdp( long aP0_WWPEntityId ,
                              long aP1_WWPDiscussionMessageThreadId ,
                              string aP2_WWPDiscussionMessageEntityRecordId ,
                              string aP3_Message ,
                              string aP4_MentionWWPUserExtendedIdCollectionJson ,
                              string aP5_SessionValue ,
                              string aP6_NotificationTitle ,
                              string aP7_WWPSubscriptionEntityRecordDescription ,
                              string aP8_WWPNotificationLink )
      {
         execute(aP0_WWPEntityId, aP1_WWPDiscussionMessageThreadId, aP2_WWPDiscussionMessageEntityRecordId, aP3_Message, aP4_MentionWWPUserExtendedIdCollectionJson, aP5_SessionValue, aP6_NotificationTitle, aP7_WWPSubscriptionEntityRecordDescription, aP8_WWPNotificationLink, out aP9_DiscussionMessageCreated);
         return AV11DiscussionMessageCreated ;
      }

      public void executeSubmit( long aP0_WWPEntityId ,
                                 long aP1_WWPDiscussionMessageThreadId ,
                                 string aP2_WWPDiscussionMessageEntityRecordId ,
                                 string aP3_Message ,
                                 string aP4_MentionWWPUserExtendedIdCollectionJson ,
                                 string aP5_SessionValue ,
                                 string aP6_NotificationTitle ,
                                 string aP7_WWPSubscriptionEntityRecordDescription ,
                                 string aP8_WWPNotificationLink ,
                                 out bool aP9_DiscussionMessageCreated )
      {
         this.AV18WWPEntityId = aP0_WWPEntityId;
         this.AV17WWPDiscussionMessageThreadId = aP1_WWPDiscussionMessageThreadId;
         this.AV16WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV14Message = aP3_Message;
         this.AV13MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         this.AV15SessionValue = aP5_SessionValue;
         this.AV19NotificationTitle = aP6_NotificationTitle;
         this.AV21WWPSubscriptionEntityRecordDescription = aP7_WWPSubscriptionEntityRecordDescription;
         this.AV20WWPNotificationLink = aP8_WWPNotificationLink;
         this.AV11DiscussionMessageCreated = false ;
         SubmitImpl();
         aP9_DiscussionMessageCreated=this.AV11DiscussionMessageCreated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WWPDiscussionMessage = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         AV9WWPDiscussionMessage.gxTpr_Wwpentityid = AV18WWPEntityId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessageentityrecordid = AV16WWPDiscussionMessageEntityRecordId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessagethreadid = AV17WWPDiscussionMessageThreadId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessagemessage = AV14Message;
         AV9WWPDiscussionMessage.Save();
         if ( AV9WWPDiscussionMessage.Success() )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13MentionWWPUserExtendedIdCollectionJson)) )
            {
               AV12MentionWWPUserExtendedIdCollection.FromJSonString(AV13MentionWWPUserExtendedIdCollectionJson, null);
               AV8ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV12MentionWWPUserExtendedIdCollection.Count )
               {
                  AV22WWPUserExtendedId = AV12MentionWWPUserExtendedIdCollection.GetString(AV29GXV1);
                  AV10WWPDiscussionMessageMention = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
                  AV10WWPDiscussionMessageMention.gxTpr_Wwpdiscussionmessageid = AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessageid;
                  AV10WWPDiscussionMessageMention.gxTpr_Wwpdiscussionmentionuserid = AV22WWPUserExtendedId;
                  AV10WWPDiscussionMessageMention.Save();
                  AV8ExcludedWWPUserExtendedIdCollection.Add(StringUtil.Trim( AV22WWPUserExtendedId), 0);
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
            }
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage",pr_default);
            AV25GAMUser.load( AV9WWPDiscussionMessage.gxTpr_Wwpuserextendedid);
            if ( AV25GAMUser.success() )
            {
               if ( AV25GAMUser.checkrole("Receptionist") )
               {
                  GXt_char1 = AV26RoleName;
                  new prc_getorganisationdefinition(context ).execute(  "Receptionist", out  GXt_char1) ;
                  AV26RoleName = GXt_char1;
               }
               else
               {
                  GXt_char1 = AV26RoleName;
                  new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char1) ;
                  AV26RoleName = GXt_char1;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RoleName)) )
               {
                  AV27UserFullName = AV26RoleName + ": " + AV9WWPDiscussionMessage.gxTpr_Wwpuserextendedfullname;
               }
               else
               {
                  AV27UserFullName = AV9WWPDiscussionMessage.gxTpr_Wwpuserextendedfullname;
               }
            }
            new GeneXus.Programs.wwpbaseobjects.discussions.wwp_notifydiscussionmessage(context ).execute(  AV27UserFullName,  AV9WWPDiscussionMessage.gxTpr_Wwpentityname,  AV16WWPDiscussionMessageEntityRecordId,  AV8ExcludedWWPUserExtendedIdCollection.ToJSonString(false),  AV15SessionValue,  AV19NotificationTitle,  AV21WWPSubscriptionEntityRecordDescription,  AV20WWPNotificationLink) ;
            AV11DiscussionMessageCreated = true;
         }
         else
         {
            AV31GXV3 = 1;
            AV30GXV2 = AV9WWPDiscussionMessage.GetMessages();
            while ( AV31GXV3 <= AV30GXV2.Count )
            {
               AV28ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV30GXV2.Item(AV31GXV3));
               new prc_logtoserver(context ).execute(  context.GetMessage( "Failed: ", "")+AV28ErrorMessage.gxTpr_Description) ;
               AV31GXV3 = (int)(AV31GXV3+1);
            }
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
         AV9WWPDiscussionMessage = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         AV12MentionWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV8ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV22WWPUserExtendedId = "";
         AV10WWPDiscussionMessageMention = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
         AV25GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV26RoleName = "";
         GXt_char1 = "";
         AV27UserFullName = "";
         AV30GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV28ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV29GXV1 ;
      private int AV31GXV3 ;
      private long AV18WWPEntityId ;
      private long AV17WWPDiscussionMessageThreadId ;
      private string AV22WWPUserExtendedId ;
      private string GXt_char1 ;
      private bool AV11DiscussionMessageCreated ;
      private string AV13MentionWWPUserExtendedIdCollectionJson ;
      private string AV16WWPDiscussionMessageEntityRecordId ;
      private string AV14Message ;
      private string AV15SessionValue ;
      private string AV19NotificationTitle ;
      private string AV21WWPSubscriptionEntityRecordDescription ;
      private string AV20WWPNotificationLink ;
      private string AV26RoleName ;
      private string AV27UserFullName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage AV9WWPDiscussionMessage ;
      private GxSimpleCollection<string> AV12MentionWWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> AV8ExcludedWWPUserExtendedIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention AV10WWPDiscussionMessageMention ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV25GAMUser ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV30GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV28ErrorMessage ;
      private bool aP9_DiscussionMessageCreated ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_createandnotifydiscussionmessage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createandnotifydiscussionmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_createandnotifydiscussionmessage__default : DataStoreHelperBase, IDataStoreHelper
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
