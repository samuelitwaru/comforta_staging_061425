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
   public class prc_gettrashitems : GXProcedure
   {
      public prc_gettrashitems( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_gettrashitems( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_TrashItem> aP0_SDT_TrashItems ,
                           out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV9SDT_TrashItems = new GXBaseCollection<SdtSDT_TrashItem>( context, "SDT_TrashItem", "Comforta_version21") ;
         this.AV15SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_TrashItems=this.AV9SDT_TrashItems;
         aP1_SDT_Error=this.AV15SDT_Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_TrashItem> aP0_SDT_TrashItems )
      {
         execute(out aP0_SDT_TrashItems, out aP1_SDT_Error);
         return AV15SDT_Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_TrashItem> aP0_SDT_TrashItems ,
                                 out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV9SDT_TrashItems = new GXBaseCollection<SdtSDT_TrashItem>( context, "SDT_TrashItem", "Comforta_version21") ;
         this.AV15SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_TrashItems=this.AV9SDT_TrashItems;
         aP1_SDT_Error=this.AV15SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV15SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV15SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         /* Using cursor P00G82 */
         pr_default.execute(0, new Object[] {AV12LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A620IsVersionDeleted = P00G82_A620IsVersionDeleted[0];
            A29LocationId = P00G82_A29LocationId[0];
            n29LocationId = P00G82_n29LocationId[0];
            A523AppVersionId = P00G82_A523AppVersionId[0];
            A622VersionDeletedAt = P00G82_A622VersionDeletedAt[0];
            n622VersionDeletedAt = P00G82_n622VersionDeletedAt[0];
            AV8TrashItem = new SdtSDT_TrashItem(context);
            AV8TrashItem.gxTpr_Type = "Version";
            AV10BC_Trn_AppVersion.Load(A523AppVersionId);
            new prc_loadappversionsdt(context ).execute(  AV10BC_Trn_AppVersion, out  AV11SDT_AppVersion) ;
            AV8TrashItem.gxTpr_Version = AV11SDT_AppVersion;
            AV8TrashItem.gxTpr_Deletedat = A622VersionDeletedAt;
            AV8TrashItem.gxTpr_Trashid = A523AppVersionId;
            AV9SDT_TrashItems.Add(AV8TrashItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00G83 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A523AppVersionId = P00G83_A523AppVersionId[0];
            A535IsActive = P00G83_A535IsActive[0];
            /* Using cursor P00G84 */
            pr_default.execute(2, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A621IsPageDeleted = P00G84_A621IsPageDeleted[0];
               A516PageId = P00G84_A516PageId[0];
               A517PageName = P00G84_A517PageName[0];
               A525PageType = P00G84_A525PageType[0];
               A518PageStructure = P00G84_A518PageStructure[0];
               A623PageDeletedAt = P00G84_A623PageDeletedAt[0];
               n623PageDeletedAt = P00G84_n623PageDeletedAt[0];
               AV8TrashItem = new SdtSDT_TrashItem(context);
               AV8TrashItem.gxTpr_Type = "Page";
               AV14SDT_AppVersionPage = new SdtSDT_AppVersionPage(context);
               AV14SDT_AppVersionPage.gxTpr_Pageid = A516PageId;
               AV14SDT_AppVersionPage.gxTpr_Pagename = A517PageName;
               AV14SDT_AppVersionPage.gxTpr_Pagetype = A525PageType;
               AV14SDT_AppVersionPage.gxTpr_Pagestructure = A518PageStructure;
               AV8TrashItem.gxTpr_Page = AV14SDT_AppVersionPage;
               AV8TrashItem.gxTpr_Deletedat = A623PageDeletedAt;
               AV8TrashItem.gxTpr_Trashid = A516PageId;
               AV9SDT_TrashItems.Add(AV8TrashItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV9SDT_TrashItems = new GXBaseCollection<SdtSDT_TrashItem>( context, "SDT_TrashItem", "Comforta_version21");
         AV15SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00G82_A620IsVersionDeleted = new bool[] {false} ;
         P00G82_A29LocationId = new Guid[] {Guid.Empty} ;
         P00G82_n29LocationId = new bool[] {false} ;
         P00G82_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G82_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         P00G82_n622VersionDeletedAt = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         AV8TrashItem = new SdtSDT_TrashItem(context);
         AV10BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV11SDT_AppVersion = new SdtSDT_AppVersion(context);
         P00G83_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G83_A535IsActive = new bool[] {false} ;
         P00G84_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G84_A621IsPageDeleted = new bool[] {false} ;
         P00G84_A516PageId = new Guid[] {Guid.Empty} ;
         P00G84_A517PageName = new string[] {""} ;
         P00G84_A525PageType = new string[] {""} ;
         P00G84_A518PageStructure = new string[] {""} ;
         P00G84_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         P00G84_n623PageDeletedAt = new bool[] {false} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         A525PageType = "";
         A518PageStructure = "";
         A623PageDeletedAt = (DateTime)(DateTime.MinValue);
         AV14SDT_AppVersionPage = new SdtSDT_AppVersionPage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_gettrashitems__default(),
            new Object[][] {
                new Object[] {
               P00G82_A620IsVersionDeleted, P00G82_A29LocationId, P00G82_n29LocationId, P00G82_A523AppVersionId, P00G82_A622VersionDeletedAt, P00G82_n622VersionDeletedAt
               }
               , new Object[] {
               P00G83_A523AppVersionId, P00G83_A535IsActive
               }
               , new Object[] {
               P00G84_A523AppVersionId, P00G84_A621IsPageDeleted, P00G84_A516PageId, P00G84_A517PageName, P00G84_A525PageType, P00G84_A518PageStructure, P00G84_A623PageDeletedAt, P00G84_n623PageDeletedAt
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A622VersionDeletedAt ;
      private DateTime A623PageDeletedAt ;
      private bool A620IsVersionDeleted ;
      private bool n29LocationId ;
      private bool n622VersionDeletedAt ;
      private bool A535IsActive ;
      private bool A621IsPageDeleted ;
      private bool n623PageDeletedAt ;
      private string A518PageStructure ;
      private string A517PageName ;
      private string A525PageType ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_TrashItem> AV9SDT_TrashItems ;
      private SdtSDT_Error AV15SDT_Error ;
      private IDataStoreProvider pr_default ;
      private bool[] P00G82_A620IsVersionDeleted ;
      private Guid[] P00G82_A29LocationId ;
      private bool[] P00G82_n29LocationId ;
      private Guid[] P00G82_A523AppVersionId ;
      private DateTime[] P00G82_A622VersionDeletedAt ;
      private bool[] P00G82_n622VersionDeletedAt ;
      private SdtSDT_TrashItem AV8TrashItem ;
      private SdtTrn_AppVersion AV10BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV11SDT_AppVersion ;
      private Guid[] P00G83_A523AppVersionId ;
      private bool[] P00G83_A535IsActive ;
      private Guid[] P00G84_A523AppVersionId ;
      private bool[] P00G84_A621IsPageDeleted ;
      private Guid[] P00G84_A516PageId ;
      private string[] P00G84_A517PageName ;
      private string[] P00G84_A525PageType ;
      private string[] P00G84_A518PageStructure ;
      private DateTime[] P00G84_A623PageDeletedAt ;
      private bool[] P00G84_n623PageDeletedAt ;
      private SdtSDT_AppVersionPage AV14SDT_AppVersionPage ;
      private GXBaseCollection<SdtSDT_TrashItem> aP0_SDT_TrashItems ;
      private SdtSDT_Error aP1_SDT_Error ;
   }

   public class prc_gettrashitems__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00G82;
          prmP00G82 = new Object[] {
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00G83;
          prmP00G83 = new Object[] {
          };
          Object[] prmP00G84;
          prmP00G84 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G82", "SELECT IsVersionDeleted, LocationId, AppVersionId, VersionDeletedAt FROM Trn_AppVersion WHERE (LocationId = :AV12LocationId) AND (IsVersionDeleted = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G83", "SELECT AppVersionId, IsActive FROM Trn_AppVersion WHERE IsActive = TRUE ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G83,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G84", "SELECT AppVersionId, IsPageDeleted, PageId, PageName, PageType, PageStructure, PageDeletedAt FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (IsPageDeleted = TRUE) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G84,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
