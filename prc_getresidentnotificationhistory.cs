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
   public class prc_getresidentnotificationhistory : GXProcedure
   {
      public prc_getresidentnotificationhistory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentnotificationhistory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           short aP1_PageSize ,
                           short aP2_PageNumber ,
                           out string aP3_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV16PageSize = aP1_PageSize;
         this.AV15PageNumber = aP2_PageNumber;
         this.AV11result = "" ;
         initialize();
         ExecuteImpl();
         aP3_result=this.AV11result;
      }

      public string executeUdp( string aP0_ResidentGUID ,
                                short aP1_PageSize ,
                                short aP2_PageNumber )
      {
         execute(aP0_ResidentGUID, aP1_PageSize, aP2_PageNumber, out aP3_result);
         return AV11result ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 short aP1_PageSize ,
                                 short aP2_PageNumber ,
                                 out string aP3_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV16PageSize = aP1_PageSize;
         this.AV15PageNumber = aP2_PageNumber;
         this.AV11result = "" ;
         SubmitImpl();
         aP3_result=this.AV11result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009A2 */
         pr_default.execute(0, new Object[] {AV8ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P009A2_A71ResidentGUID[0];
            A11OrganisationId = P009A2_A11OrganisationId[0];
            A29LocationId = P009A2_A29LocationId[0];
            A62ResidentId = P009A2_A62ResidentId[0];
            AV13Trn_Resident.Load(A62ResidentId, A29LocationId, A11OrganisationId);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P009A4 */
         pr_default.execute(1, new Object[] {AV13Trn_Resident.gxTpr_Residentid});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P009A4_A40000GXC1[0];
            n40000GXC1 = P009A4_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         if ( ( AV16PageSize < 1 ) || ( AV15PageNumber < 1 ) )
         {
            AV18RecordsToSkip = 0;
            AV17RecordsPerPage = 100;
            AV23defaultPageNumber = 1;
         }
         else
         {
            AV17RecordsPerPage = AV16PageSize;
            AV23defaultPageNumber = AV15PageNumber;
            AV18RecordsToSkip = (short)(AV16PageSize*(AV15PageNumber-1));
         }
         if ( AV13Trn_Resident.Success() )
         {
            AV12SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version21");
            AV19SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
            AV22TotalRecords = A40000GXC1;
            GXPagingFrom3 = AV18RecordsToSkip;
            GXPagingTo3 = AV17RecordsPerPage;
            /* Using cursor P009A5 */
            pr_default.execute(2, new Object[] {AV13Trn_Resident.gxTpr_Residentid, GXPagingFrom3, GXPagingTo3});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A62ResidentId = P009A5_A62ResidentId[0];
               A486AppNotificationId = P009A5_A486AppNotificationId[0];
               A487AppNotificationTitle = P009A5_A487AppNotificationTitle[0];
               A490AppNotificationTopic = P009A5_A490AppNotificationTopic[0];
               A498AppNotificationMetadata = P009A5_A498AppNotificationMetadata[0];
               n498AppNotificationMetadata = P009A5_n498AppNotificationMetadata[0];
               A488AppNotificationDescription = P009A5_A488AppNotificationDescription[0];
               A489AppNotificationDate = P009A5_A489AppNotificationDate[0];
               A485ResidentNotificationId = P009A5_A485ResidentNotificationId[0];
               A487AppNotificationTitle = P009A5_A487AppNotificationTitle[0];
               A490AppNotificationTopic = P009A5_A490AppNotificationTopic[0];
               A498AppNotificationMetadata = P009A5_A498AppNotificationMetadata[0];
               n498AppNotificationMetadata = P009A5_n498AppNotificationMetadata[0];
               A488AppNotificationDescription = P009A5_A488AppNotificationDescription[0];
               A489AppNotificationDate = P009A5_A489AppNotificationDate[0];
               AV10ResidentNotificationItem = new SdtSDT_ResidentNotification(context);
               AV10ResidentNotificationItem.gxTpr_Notificationdate = A489AppNotificationDate;
               AV10ResidentNotificationItem.gxTpr_Notificationid = A486AppNotificationId;
               AV10ResidentNotificationItem.gxTpr_Notificationtitle = A487AppNotificationTitle;
               AV10ResidentNotificationItem.gxTpr_Notificationtopic = A490AppNotificationTopic;
               if ( AV14SDT_OneSignalCustomData.FromJSonString(A498AppNotificationMetadata, null) )
               {
                  AV10ResidentNotificationItem.gxTpr_Notificationmetadata = AV14SDT_OneSignalCustomData;
               }
               AV10ResidentNotificationItem.gxTpr_Notificationdescription = A488AppNotificationDescription;
               AV12SDT_ResidentNotification.Add(AV10ResidentNotificationItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV20TotalPages = (int)((AV22TotalRecords+AV17RecordsPerPage-1)/ (decimal)(AV17RecordsPerPage));
            AV19SDT_ApiListResponse.gxTpr_Numberofpages = (short)(AV20TotalPages);
            AV19SDT_ApiListResponse.gxTpr_Pagenumber = AV23defaultPageNumber;
            AV19SDT_ApiListResponse.gxTpr_Pagesize = AV17RecordsPerPage;
            AV19SDT_ApiListResponse.gxTpr_Notificationhistory = AV12SDT_ResidentNotification;
         }
         AV11result = AV19SDT_ApiListResponse.ToJSonString(false, true);
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV11result = "";
         P009A2_A71ResidentGUID = new string[] {""} ;
         P009A2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009A2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009A2_A62ResidentId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV13Trn_Resident = new SdtTrn_Resident(context);
         P009A4_A40000GXC1 = new int[1] ;
         P009A4_n40000GXC1 = new bool[] {false} ;
         AV12SDT_ResidentNotification = new GXBaseCollection<SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "Comforta_version21");
         AV19SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         P009A5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009A5_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         P009A5_A487AppNotificationTitle = new string[] {""} ;
         P009A5_A490AppNotificationTopic = new string[] {""} ;
         P009A5_A498AppNotificationMetadata = new string[] {""} ;
         P009A5_n498AppNotificationMetadata = new bool[] {false} ;
         P009A5_A488AppNotificationDescription = new string[] {""} ;
         P009A5_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         P009A5_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         A486AppNotificationId = Guid.Empty;
         A487AppNotificationTitle = "";
         A490AppNotificationTopic = "";
         A498AppNotificationMetadata = "";
         A488AppNotificationDescription = "";
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A485ResidentNotificationId = Guid.Empty;
         AV10ResidentNotificationItem = new SdtSDT_ResidentNotification(context);
         AV14SDT_OneSignalCustomData = new SdtSDT_OneSignalCustomData(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentnotificationhistory__default(),
            new Object[][] {
                new Object[] {
               P009A2_A71ResidentGUID, P009A2_A11OrganisationId, P009A2_A29LocationId, P009A2_A62ResidentId
               }
               , new Object[] {
               P009A4_A40000GXC1, P009A4_n40000GXC1
               }
               , new Object[] {
               P009A5_A62ResidentId, P009A5_A486AppNotificationId, P009A5_A487AppNotificationTitle, P009A5_A490AppNotificationTopic, P009A5_A498AppNotificationMetadata, P009A5_n498AppNotificationMetadata, P009A5_A488AppNotificationDescription, P009A5_A489AppNotificationDate, P009A5_A485ResidentNotificationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16PageSize ;
      private short AV15PageNumber ;
      private short AV18RecordsToSkip ;
      private short AV17RecordsPerPage ;
      private short AV23defaultPageNumber ;
      private int A40000GXC1 ;
      private int AV22TotalRecords ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int AV20TotalPages ;
      private DateTime A489AppNotificationDate ;
      private bool n40000GXC1 ;
      private bool n498AppNotificationMetadata ;
      private string AV11result ;
      private string A498AppNotificationMetadata ;
      private string AV8ResidentGUID ;
      private string A71ResidentGUID ;
      private string A487AppNotificationTitle ;
      private string A490AppNotificationTopic ;
      private string A488AppNotificationDescription ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A486AppNotificationId ;
      private Guid A485ResidentNotificationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009A2_A71ResidentGUID ;
      private Guid[] P009A2_A11OrganisationId ;
      private Guid[] P009A2_A29LocationId ;
      private Guid[] P009A2_A62ResidentId ;
      private SdtTrn_Resident AV13Trn_Resident ;
      private int[] P009A4_A40000GXC1 ;
      private bool[] P009A4_n40000GXC1 ;
      private GXBaseCollection<SdtSDT_ResidentNotification> AV12SDT_ResidentNotification ;
      private SdtSDT_ApiListResponse AV19SDT_ApiListResponse ;
      private Guid[] P009A5_A62ResidentId ;
      private Guid[] P009A5_A486AppNotificationId ;
      private string[] P009A5_A487AppNotificationTitle ;
      private string[] P009A5_A490AppNotificationTopic ;
      private string[] P009A5_A498AppNotificationMetadata ;
      private bool[] P009A5_n498AppNotificationMetadata ;
      private string[] P009A5_A488AppNotificationDescription ;
      private DateTime[] P009A5_A489AppNotificationDate ;
      private Guid[] P009A5_A485ResidentNotificationId ;
      private SdtSDT_ResidentNotification AV10ResidentNotificationItem ;
      private SdtSDT_OneSignalCustomData AV14SDT_OneSignalCustomData ;
      private string aP3_result ;
   }

   public class prc_getresidentnotificationhistory__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009A2;
          prmP009A2 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60)
          };
          Object[] prmP009A4;
          prmP009A4 = new Object[] {
          new ParDef("AV13Trn_Resident__Residentid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009A5;
          prmP009A5 = new Object[] {
          new ParDef("AV13Trn_Resident__Residentid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009A2", "SELECT ResidentGUID, OrganisationId, LocationId, ResidentId FROM Trn_Resident WHERE ResidentGUID = ( RTRIM(LTRIM(:AV8ResidentGUID))) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P009A4", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Trn_ResidentNotification WHERE ResidentId = :AV13Trn_Resident__Residentid ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009A5", "SELECT T1.ResidentId, T1.AppNotificationId, T2.AppNotificationTitle, T2.AppNotificationTopic, T2.AppNotificationMetadata, T2.AppNotificationDescription, T2.AppNotificationDate, T1.ResidentNotificationId FROM (Trn_ResidentNotification T1 INNER JOIN Trn_AppNotification T2 ON T2.AppNotificationId = T1.AppNotificationId) WHERE T1.ResidentId = :AV13Trn_Resident__Residentid ORDER BY T2.AppNotificationDate DESC, T1.ResidentNotificationId  OFFSET :GXPagingFrom3 LIMIT CASE WHEN :GXPagingTo3 > 0 THEN :GXPagingTo3 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
