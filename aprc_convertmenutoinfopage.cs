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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_convertmenutoinfopage : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_convertmenutoinfopage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_convertmenutoinfopage( IGxContext context )
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
         /* Using cursor P00G62 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00G62_A523AppVersionId[0];
            AV17Count = 0;
            /* Using cursor P00G63 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A525PageType = P00G63_A525PageType[0];
               A518PageStructure = P00G63_A518PageStructure[0];
               A517PageName = P00G63_A517PageName[0];
               A516PageId = P00G63_A516PageId[0];
               A525PageType = "Information";
               AV10SDT_InfoContent = new SdtSDT_InfoContent(context);
               AV13SDT_MenuPage.FromJSonString(A518PageStructure, null);
               AV20GXV1 = 1;
               while ( AV20GXV1 <= AV13SDT_MenuPage.gxTpr_Rows.Count )
               {
                  AV9RowItem = ((SdtSDT_MenuPage_RowsItem)AV13SDT_MenuPage.gxTpr_Rows.Item(AV20GXV1));
                  AV8InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
                  AV8InfoContentItem.gxTpr_Infoid = new SdtRandomStringGenerator(context).generate(15);
                  AV8InfoContentItem.gxTpr_Infotype = "TileRow";
                  AV12SDT_InfoTile = new GXBaseCollection<SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTileItem", "Comforta_version21");
                  AV21GXV2 = 1;
                  while ( AV21GXV2 <= AV9RowItem.gxTpr_Tiles.Count )
                  {
                     AV14TileItem = ((SdtSDT_MenuPage_RowsItem_TilesItem)AV9RowItem.gxTpr_Tiles.Item(AV21GXV2));
                     AV16SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
                     AV16SDT_InfoTileItem.FromJSonString(AV14TileItem.ToJSonString(false, true), null);
                     AV12SDT_InfoTile.Add(AV16SDT_InfoTileItem, 0);
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
                  AV8InfoContentItem.gxTpr_Tiles = AV12SDT_InfoTile;
                  AV10SDT_InfoContent.gxTpr_Infocontent.Add(AV8InfoContentItem, 0);
                  AV20GXV1 = (int)(AV20GXV1+1);
               }
               new prc_logtoserver(context ).execute(  "		"+AV10SDT_InfoContent.ToJSonString(false, true)) ;
               AV15HttpResponse.AddString(context.GetMessage( "converted : ", "")+A517PageName+StringUtil.NewLine( ));
               A518PageStructure = AV10SDT_InfoContent.ToJSonString(false, true);
               /* Using cursor P00G64 */
               pr_default.execute(2, new Object[] {A525PageType, A518PageStructure, A523AppVersionId, A516PageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15HttpResponse.AddString(context.GetMessage( "converted : ", "")+StringUtil.Str( (decimal)(AV17Count), 4, 0)+context.GetMessage( " Pages", ""));
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_convertmenutoinfopage",pr_default);
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P00G62_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00G63_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G63_A525PageType = new string[] {""} ;
         P00G63_A518PageStructure = new string[] {""} ;
         P00G63_A517PageName = new string[] {""} ;
         P00G63_A516PageId = new Guid[] {Guid.Empty} ;
         A525PageType = "";
         A518PageStructure = "";
         A517PageName = "";
         A516PageId = Guid.Empty;
         AV10SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV13SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV9RowItem = new SdtSDT_MenuPage_RowsItem(context);
         AV8InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
         AV12SDT_InfoTile = new GXBaseCollection<SdtSDT_InfoTile_SDT_InfoTileItem>( context, "SDT_InfoTileItem", "Comforta_version21");
         AV14TileItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV16SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV15HttpResponse = new GxHttpResponse( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_convertmenutoinfopage__default(),
            new Object[][] {
                new Object[] {
               P00G62_A523AppVersionId
               }
               , new Object[] {
               P00G63_A523AppVersionId, P00G63_A525PageType, P00G63_A518PageStructure, P00G63_A517PageName, P00G63_A516PageId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV17Count ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private string A518PageStructure ;
      private string A525PageType ;
      private string A517PageName ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private GxHttpResponse AV15HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00G62_A523AppVersionId ;
      private Guid[] P00G63_A523AppVersionId ;
      private string[] P00G63_A525PageType ;
      private string[] P00G63_A518PageStructure ;
      private string[] P00G63_A517PageName ;
      private Guid[] P00G63_A516PageId ;
      private SdtSDT_InfoContent AV10SDT_InfoContent ;
      private SdtSDT_MenuPage AV13SDT_MenuPage ;
      private SdtSDT_MenuPage_RowsItem AV9RowItem ;
      private SdtSDT_InfoContent_InfoContentItem AV8InfoContentItem ;
      private GXBaseCollection<SdtSDT_InfoTile_SDT_InfoTileItem> AV12SDT_InfoTile ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV14TileItem ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV16SDT_InfoTileItem ;
   }

   public class aprc_convertmenutoinfopage__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00G62;
          prmP00G62 = new Object[] {
          };
          Object[] prmP00G63;
          prmP00G63 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00G64;
          prmP00G64 = new Object[] {
          new ParDef("PageType",GXType.VarChar,40,0) ,
          new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G62", "SELECT AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G63", "SELECT AppVersionId, PageType, PageStructure, PageName, PageId FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (PageType = ( 'Menu') or PageType = ( 'MyLiving') or PageType = ( 'MyCare') or PageType = ( 'MyService')) ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G64", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageType=:PageType, PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G64)
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
