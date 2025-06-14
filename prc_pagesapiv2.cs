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
   public class prc_pagesapiv2 : GXProcedure
   {
      public prc_pagesapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pagesapiv2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           string aP2_UserId ,
                           out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV16SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP3_SDT_MobilePageCollection=this.AV16SDT_MobilePageCollection;
      }

      public GXBaseCollection<SdtSDT_MobilePage> executeUdp( Guid aP0_LocationId ,
                                                             Guid aP1_OrganisationId ,
                                                             string aP2_UserId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_UserId, out aP3_SDT_MobilePageCollection);
         return AV16SDT_MobilePageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 string aP2_UserId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV16SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         SubmitImpl();
         aP3_SDT_MobilePageCollection=this.AV16SDT_MobilePageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SDT_PageCollection.Clear();
         /* Using cursor P00DX2 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00DX2_A29LocationId[0];
            n29LocationId = P00DX2_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00DX2_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00DX2_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00DX2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00DX2_n584ActiveAppVersionId[0];
            A11OrganisationId = P00DX2_A11OrganisationId[0];
            n11OrganisationId = P00DX2_n11OrganisationId[0];
            AV18AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV18AppVersionId) )
            {
               AV18AppVersionId = A584ActiveAppVersionId;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( (Guid.Empty==AV18AppVersionId) )
         {
            /* Using cursor P00DX3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A29LocationId = P00DX3_A29LocationId[0];
               n29LocationId = P00DX3_n29LocationId[0];
               A11OrganisationId = P00DX3_A11OrganisationId[0];
               n11OrganisationId = P00DX3_n11OrganisationId[0];
               A584ActiveAppVersionId = P00DX3_A584ActiveAppVersionId[0];
               n584ActiveAppVersionId = P00DX3_n584ActiveAppVersionId[0];
               A523AppVersionId = P00DX3_A523AppVersionId[0];
               A584ActiveAppVersionId = P00DX3_A584ActiveAppVersionId[0];
               n584ActiveAppVersionId = P00DX3_n584ActiveAppVersionId[0];
               AV18AppVersionId = A584ActiveAppVersionId;
               /* Execute user subroutine: 'GETAPPVERSION' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         else
         {
            /* Execute user subroutine: 'GETAPPVERSION' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         new prc_logtoserver(context ).execute(  AV16SDT_MobilePageCollection.ToJSonString(false)) ;
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETAPPVERSION' Routine */
         returnInSub = false;
         /* Using cursor P00DX4 */
         pr_default.execute(2, new Object[] {AV8LocationId, AV9OrganisationId, AV18AppVersionId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A523AppVersionId = P00DX4_A523AppVersionId[0];
            A11OrganisationId = P00DX4_A11OrganisationId[0];
            n11OrganisationId = P00DX4_n11OrganisationId[0];
            A29LocationId = P00DX4_A29LocationId[0];
            n29LocationId = P00DX4_n29LocationId[0];
            /* Using cursor P00DX5 */
            pr_default.execute(3, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A525PageType = P00DX5_A525PageType[0];
               A536PagePublishedStructure = P00DX5_A536PagePublishedStructure[0];
               A516PageId = P00DX5_A516PageId[0];
               A517PageName = P00DX5_A517PageName[0];
               AV14SDT_MenuPage.FromJSonString(A536PagePublishedStructure, null);
               GXt_SdtSDT_MobilePage1 = AV15SDT_MobilePage;
               new prc_convertnewtooldmenustructure(context ).execute(  AV14SDT_MenuPage,  A516PageId,  A517PageName,  AV8LocationId, out  GXt_SdtSDT_MobilePage1) ;
               AV15SDT_MobilePage = GXt_SdtSDT_MobilePage1;
               AV16SDT_MobilePageCollection.Add(AV15SDT_MobilePage, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV16SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21");
         AV11SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version21");
         P00DX2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DX2_n29LocationId = new bool[] {false} ;
         P00DX2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DX2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00DX2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DX2_n584ActiveAppVersionId = new bool[] {false} ;
         P00DX2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DX2_n11OrganisationId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV18AppVersionId = Guid.Empty;
         P00DX3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DX3_n29LocationId = new bool[] {false} ;
         P00DX3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DX3_n11OrganisationId = new bool[] {false} ;
         P00DX3_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DX3_n584ActiveAppVersionId = new bool[] {false} ;
         P00DX3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00DX4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DX4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DX4_n11OrganisationId = new bool[] {false} ;
         P00DX4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DX4_n29LocationId = new bool[] {false} ;
         P00DX5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DX5_A525PageType = new string[] {""} ;
         P00DX5_A536PagePublishedStructure = new string[] {""} ;
         P00DX5_A516PageId = new Guid[] {Guid.Empty} ;
         P00DX5_A517PageName = new string[] {""} ;
         A525PageType = "";
         A536PagePublishedStructure = "";
         A516PageId = Guid.Empty;
         A517PageName = "";
         AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV15SDT_MobilePage = new SdtSDT_MobilePage(context);
         GXt_SdtSDT_MobilePage1 = new SdtSDT_MobilePage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pagesapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DX2_A29LocationId, P00DX2_A598PublishedActiveAppVersionId, P00DX2_n598PublishedActiveAppVersionId, P00DX2_A584ActiveAppVersionId, P00DX2_n584ActiveAppVersionId, P00DX2_A11OrganisationId
               }
               , new Object[] {
               P00DX3_A29LocationId, P00DX3_n29LocationId, P00DX3_A11OrganisationId, P00DX3_n11OrganisationId, P00DX3_A584ActiveAppVersionId, P00DX3_n584ActiveAppVersionId, P00DX3_A523AppVersionId
               }
               , new Object[] {
               P00DX4_A523AppVersionId, P00DX4_A11OrganisationId, P00DX4_n11OrganisationId, P00DX4_A29LocationId, P00DX4_n29LocationId
               }
               , new Object[] {
               P00DX5_A523AppVersionId, P00DX5_A525PageType, P00DX5_A536PagePublishedStructure, P00DX5_A516PageId, P00DX5_A517PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private bool n11OrganisationId ;
      private bool returnInSub ;
      private string A536PagePublishedStructure ;
      private string AV10UserId ;
      private string A525PageType ;
      private string A517PageName ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A29LocationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A11OrganisationId ;
      private Guid AV18AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MobilePage> AV16SDT_MobilePageCollection ;
      private GXBaseCollection<SdtSDT_Page> AV11SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DX2_A29LocationId ;
      private bool[] P00DX2_n29LocationId ;
      private Guid[] P00DX2_A598PublishedActiveAppVersionId ;
      private bool[] P00DX2_n598PublishedActiveAppVersionId ;
      private Guid[] P00DX2_A584ActiveAppVersionId ;
      private bool[] P00DX2_n584ActiveAppVersionId ;
      private Guid[] P00DX2_A11OrganisationId ;
      private bool[] P00DX2_n11OrganisationId ;
      private Guid[] P00DX3_A29LocationId ;
      private bool[] P00DX3_n29LocationId ;
      private Guid[] P00DX3_A11OrganisationId ;
      private bool[] P00DX3_n11OrganisationId ;
      private Guid[] P00DX3_A584ActiveAppVersionId ;
      private bool[] P00DX3_n584ActiveAppVersionId ;
      private Guid[] P00DX3_A523AppVersionId ;
      private Guid[] P00DX4_A523AppVersionId ;
      private Guid[] P00DX4_A11OrganisationId ;
      private bool[] P00DX4_n11OrganisationId ;
      private Guid[] P00DX4_A29LocationId ;
      private bool[] P00DX4_n29LocationId ;
      private Guid[] P00DX5_A523AppVersionId ;
      private string[] P00DX5_A525PageType ;
      private string[] P00DX5_A536PagePublishedStructure ;
      private Guid[] P00DX5_A516PageId ;
      private string[] P00DX5_A517PageName ;
      private SdtSDT_MenuPage AV14SDT_MenuPage ;
      private SdtSDT_MobilePage AV15SDT_MobilePage ;
      private SdtSDT_MobilePage GXt_SdtSDT_MobilePage1 ;
      private GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection ;
   }

   public class prc_pagesapiv2__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DX2;
          prmP00DX2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DX3;
          prmP00DX3 = new Object[] {
          };
          Object[] prmP00DX4;
          prmP00DX4 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DX5;
          prmP00DX5 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DX2", "SELECT LocationId, PublishedActiveAppVersionId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DX2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DX3", "SELECT T1.LocationId, T1.OrganisationId, T2.ActiveAppVersionId, T1.AppVersionId FROM (Trn_AppVersion T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) ORDER BY T1.AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DX3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00DX4", "SELECT AppVersionId, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId) AND (AppVersionId = :AV18AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DX4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DX5", "SELECT AppVersionId, PageType, PagePublishedStructure, PageId, PageName FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (( PageType = ( 'Menu')) or ( PageType = ( 'MyCare')) or ( PageType = ( 'MyLiving')) or ( PageType = ( 'MyService'))) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DX5,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
