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
   public class wwp_sendmentionnotification : GXProcedure
   {
      public wwp_sendmentionnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendmentionnotification( IGxContext context )
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
                           string aP3_pWWPNotificationDefinitionIcon ,
                           string aP4_pWWPNotificationDefinitionTitle ,
                           string aP5_pWWPNotificationDefinitionShortDescription ,
                           string aP6_pWWPNotificationDefinitionLongDescription ,
                           string aP7_pWWPNotificationDefinitionLink ,
                           string aP8_WWPNotificationMetadata ,
                           string aP9_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV25WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV20WWPEntityName = aP1_WWPEntityName;
         this.AV30WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV8pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV12pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV11pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV10pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV9pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV29WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV31MentionWWPUserExtendedIdCollectionJson = aP9_MentionWWPUserExtendedIdCollectionJson;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_pWWPNotificationDefinitionIcon ,
                                 string aP4_pWWPNotificationDefinitionTitle ,
                                 string aP5_pWWPNotificationDefinitionShortDescription ,
                                 string aP6_pWWPNotificationDefinitionLongDescription ,
                                 string aP7_pWWPNotificationDefinitionLink ,
                                 string aP8_WWPNotificationMetadata ,
                                 string aP9_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV25WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV20WWPEntityName = aP1_WWPEntityName;
         this.AV30WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV8pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV12pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV11pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV10pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV9pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV29WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV31MentionWWPUserExtendedIdCollectionJson = aP9_MentionWWPUserExtendedIdCollectionJson;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV20WWPEntityName);
         /* Using cursor P003V2 */
         pr_default.execute(0, new Object[] {AV33Udparg1, AV25WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A125WWPEntityId = P003V2_A125WWPEntityId[0];
            A164WWPNotificationDefinitionName = P003V2_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P003V2_A128WWPNotificationDefinitionId[0];
            A167WWPNotificationDefinitionIcon = P003V2_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = P003V2_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = P003V2_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = P003V2_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = P003V2_A171WWPNotificationDefinitionLink[0];
            AV22WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8pWWPNotificationDefinitionIcon)) )
            {
               AV21WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
            }
            else
            {
               AV21WWPNotificationDefinitionIcon = AV8pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12pWWPNotificationDefinitionTitle)) )
            {
               AV27WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
            }
            else
            {
               AV27WWPNotificationDefinitionTitle = AV12pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11pWWPNotificationDefinitionShortDescription)) )
            {
               AV26WWPNotificationDefinitionShortDescription = A169WWPNotificationDefinitionShort;
            }
            else
            {
               AV26WWPNotificationDefinitionShortDescription = AV11pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10pWWPNotificationDefinitionLongDescription)) )
            {
               AV24WWPNotificationDefinitionLongDescription = A170WWPNotificationDefinitionLongD;
            }
            else
            {
               AV24WWPNotificationDefinitionLongDescription = AV10pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9pWWPNotificationDefinitionLink)) )
            {
               AV23WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
            }
            else
            {
               AV23WWPNotificationDefinitionLink = AV9pWWPNotificationDefinitionLink;
            }
            AV18MentionsWWPUserExtendedIdCollection.FromJSonString(AV31MentionWWPUserExtendedIdCollectionJson, null);
            AV34GXV1 = 1;
            while ( AV34GXV1 <= AV18MentionsWWPUserExtendedIdCollection.Count )
            {
               AV13WWPUserExtendedId = AV18MentionsWWPUserExtendedIdCollection.GetString(AV34GXV1);
               new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV13WWPUserExtendedId,  AV22WWPNotificationDefinitionId,  AV27WWPNotificationDefinitionTitle,  AV26WWPNotificationDefinitionShortDescription,  AV24WWPNotificationDefinitionLongDescription, ref  AV23WWPNotificationDefinitionLink,  AV29WWPNotificationMetadata,  AV21WWPNotificationDefinitionIcon,  true) ;
               AV34GXV1 = (int)(AV34GXV1+1);
            }
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
         P003V2_A125WWPEntityId = new long[1] ;
         P003V2_A164WWPNotificationDefinitionName = new string[] {""} ;
         P003V2_A128WWPNotificationDefinitionId = new long[1] ;
         P003V2_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         P003V2_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         P003V2_A169WWPNotificationDefinitionShort = new string[] {""} ;
         P003V2_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         P003V2_A171WWPNotificationDefinitionLink = new string[] {""} ;
         A164WWPNotificationDefinitionName = "";
         A167WWPNotificationDefinitionIcon = "";
         A168WWPNotificationDefinitionTitle = "";
         A169WWPNotificationDefinitionShort = "";
         A170WWPNotificationDefinitionLongD = "";
         A171WWPNotificationDefinitionLink = "";
         AV21WWPNotificationDefinitionIcon = "";
         AV27WWPNotificationDefinitionTitle = "";
         AV26WWPNotificationDefinitionShortDescription = "";
         AV24WWPNotificationDefinitionLongDescription = "";
         AV23WWPNotificationDefinitionLink = "";
         AV18MentionsWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV13WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendmentionnotification__default(),
            new Object[][] {
                new Object[] {
               P003V2_A125WWPEntityId, P003V2_A164WWPNotificationDefinitionName, P003V2_A128WWPNotificationDefinitionId, P003V2_A167WWPNotificationDefinitionIcon, P003V2_A168WWPNotificationDefinitionTitle, P003V2_A169WWPNotificationDefinitionShort, P003V2_A170WWPNotificationDefinitionLongD, P003V2_A171WWPNotificationDefinitionLink
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV34GXV1 ;
      private long AV33Udparg1 ;
      private long A125WWPEntityId ;
      private long A128WWPNotificationDefinitionId ;
      private long AV22WWPNotificationDefinitionId ;
      private string AV13WWPUserExtendedId ;
      private string AV29WWPNotificationMetadata ;
      private string AV31MentionWWPUserExtendedIdCollectionJson ;
      private string AV25WWPNotificationDefinitionName ;
      private string AV20WWPEntityName ;
      private string AV30WWPSubscriptionEntityRecordId ;
      private string AV8pWWPNotificationDefinitionIcon ;
      private string AV12pWWPNotificationDefinitionTitle ;
      private string AV11pWWPNotificationDefinitionShortDescription ;
      private string AV10pWWPNotificationDefinitionLongDescription ;
      private string AV9pWWPNotificationDefinitionLink ;
      private string A164WWPNotificationDefinitionName ;
      private string A167WWPNotificationDefinitionIcon ;
      private string A168WWPNotificationDefinitionTitle ;
      private string A169WWPNotificationDefinitionShort ;
      private string A170WWPNotificationDefinitionLongD ;
      private string A171WWPNotificationDefinitionLink ;
      private string AV21WWPNotificationDefinitionIcon ;
      private string AV27WWPNotificationDefinitionTitle ;
      private string AV26WWPNotificationDefinitionShortDescription ;
      private string AV24WWPNotificationDefinitionLongDescription ;
      private string AV23WWPNotificationDefinitionLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003V2_A125WWPEntityId ;
      private string[] P003V2_A164WWPNotificationDefinitionName ;
      private long[] P003V2_A128WWPNotificationDefinitionId ;
      private string[] P003V2_A167WWPNotificationDefinitionIcon ;
      private string[] P003V2_A168WWPNotificationDefinitionTitle ;
      private string[] P003V2_A169WWPNotificationDefinitionShort ;
      private string[] P003V2_A170WWPNotificationDefinitionLongD ;
      private string[] P003V2_A171WWPNotificationDefinitionLink ;
      private GxSimpleCollection<string> AV18MentionsWWPUserExtendedIdCollection ;
   }

   public class wwp_sendmentionnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003V2;
          prmP003V2 = new Object[] {
          new ParDef("AV33Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV25WWPNotificationDefinitionName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003V2", "SELECT WWPEntityId, WWPNotificationDefinitionName, WWPNotificationDefinitionId, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV33Udparg1) AND (WWPNotificationDefinitionName = ( :AV25WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
