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
   public class prc_convertnewtooldmenustructure : GXProcedure
   {
      public prc_convertnewtooldmenustructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertnewtooldmenustructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           Guid aP3_LocationId ,
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV16PageId = aP1_PageId;
         this.AV17PageName = aP2_PageName;
         this.AV18LocationId = aP3_LocationId;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV9SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                           Guid aP1_PageId ,
                                           string aP2_PageName ,
                                           Guid aP3_LocationId )
      {
         execute(aP0_SDT_MenuPage, aP1_PageId, aP2_PageName, aP3_LocationId, out aP4_SDT_MobilePage);
         return AV9SDT_MobilePage ;
      }

      public void executeSubmit( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 Guid aP3_LocationId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV16PageId = aP1_PageId;
         this.AV17PageName = aP2_PageName;
         this.AV18LocationId = aP3_LocationId;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV9SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV9SDT_MobilePage.gxTpr_Pageid = AV16PageId;
         AV9SDT_MobilePage.gxTpr_Pagename = AV17PageName;
         /* Using cursor P00DU2 */
         pr_default.execute(0, new Object[] {AV18LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A584ActiveAppVersionId = P00DU2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00DU2_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = P00DU2_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00DU2_n598PublishedActiveAppVersionId[0];
            A29LocationId = P00DU2_A29LocationId[0];
            A11OrganisationId = P00DU2_A11OrganisationId[0];
            /* Using cursor P00DU3 */
            pr_default.execute(1, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = P00DU3_A273Trn_ThemeId[0];
            pr_default.close(1);
            /* Using cursor P00DU4 */
            pr_default.execute(2, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = P00DU4_A273Trn_ThemeId[0];
            pr_default.close(2);
            AV21OrganisationId = A11OrganisationId;
            AV19ThemeId = A273Trn_ThemeId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(2);
         new prc_logtoserver(context ).execute(  AV9SDT_MobilePage.ToJSonString(false, true)) ;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV8SDT_MenuPage.gxTpr_Rows.Count )
         {
            AV12RowsItem = ((SdtSDT_MenuPage_RowsItem)AV8SDT_MenuPage.gxTpr_Rows.Item(AV23GXV1));
            AV10SDT_Row = new SdtSDT_Row(context);
            AV24GXV2 = 1;
            while ( AV24GXV2 <= AV12RowsItem.gxTpr_Tiles.Count )
            {
               AV14TilesItem = ((SdtSDT_MenuPage_RowsItem_TilesItem)AV12RowsItem.gxTpr_Tiles.Item(AV24GXV2));
               AV15SDT_Col = new SdtSDT_Col(context);
               AV11SDT_Tile = new SdtSDT_Tile(context);
               AV11SDT_Tile.gxTpr_Tileid = AV14TilesItem.gxTpr_Id;
               AV11SDT_Tile.gxTpr_Tilename = AV14TilesItem.gxTpr_Name;
               AV11SDT_Tile.gxTpr_Tiletext = AV14TilesItem.gxTpr_Text;
               AV11SDT_Tile.gxTpr_Tilecolor = AV14TilesItem.gxTpr_Color;
               AV11SDT_Tile.gxTpr_Tilealignment = AV14TilesItem.gxTpr_Align;
               AV11SDT_Tile.gxTpr_Tileicon = AV14TilesItem.gxTpr_Icon;
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV19ThemeId,  AV14TilesItem.gxTpr_Bgcolor, out  GXt_char1) ;
               AV11SDT_Tile.gxTpr_Tilebgcolor = GXt_char1;
               AV11SDT_Tile.gxTpr_Tilebgimageurl = AV14TilesItem.gxTpr_Bgimageurl;
               AV11SDT_Tile.gxTpr_Tilebgimageopacity = AV14TilesItem.gxTpr_Opacity;
               if ( AV14TilesItem.gxTpr_Size == 0 )
               {
                  AV14TilesItem.gxTpr_Size = 80;
               }
               AV11SDT_Tile.gxTpr_Tilesize = (decimal)(AV14TilesItem.gxTpr_Size/ (decimal)(80));
               AV11SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = AV14TilesItem.gxTpr_Action.gxTpr_Objecttype;
               AV11SDT_Tile.gxTpr_Tileaction.gxTpr_Objectid = AV14TilesItem.gxTpr_Action.gxTpr_Objectid;
               AV11SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl = AV14TilesItem.gxTpr_Action.gxTpr_Objecturl;
               if ( StringUtil.StrCmp(AV14TilesItem.gxTpr_Action.gxTpr_Objecttype, "DynamicForm") == 0 )
               {
                  new prc_logtoserver(context ).execute(  context.GetMessage( "Found form: ", "")+AV14TilesItem.gxTpr_Action.gxTpr_Objectid) ;
                  /* Using cursor P00DU5 */
                  pr_default.execute(3, new Object[] {AV14TilesItem.gxTpr_Action.gxTpr_Objectid});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A206WWPFormId = P00DU5_A206WWPFormId[0];
                     A208WWPFormReferenceName = P00DU5_A208WWPFormReferenceName[0];
                     A207WWPFormVersionNumber = P00DU5_A207WWPFormVersionNumber[0];
                     AV11SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl = A367CallToActionUrl;
                     GXt_char1 = "";
                     GXt_char2 = context.GetMessage( "Form", "");
                     new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char1) ;
                     AV11SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl = GXt_char1;
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
               }
               AV15SDT_Col.gxTpr_Tile = AV11SDT_Tile;
               AV10SDT_Row.gxTpr_Col.Add(AV15SDT_Col, 0);
               new prc_logtoserver(context ).execute(  "		"+AV11SDT_Tile.ToJSonString(false, true)) ;
               AV24GXV2 = (int)(AV24GXV2+1);
            }
            AV9SDT_MobilePage.gxTpr_Row.Add(AV10SDT_Row, 0);
            AV23GXV1 = (int)(AV23GXV1+1);
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV9SDT_MobilePage = new SdtSDT_MobilePage(context);
         P00DU2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DU2_n584ActiveAppVersionId = new bool[] {false} ;
         P00DU2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DU2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00DU2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DU2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00DU3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         P00DU4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         AV21OrganisationId = Guid.Empty;
         AV19ThemeId = Guid.Empty;
         AV12RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV14TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV15SDT_Col = new SdtSDT_Col(context);
         AV11SDT_Tile = new SdtSDT_Tile(context);
         P00DU5_A206WWPFormId = new short[1] ;
         P00DU5_A208WWPFormReferenceName = new string[] {""} ;
         P00DU5_A207WWPFormVersionNumber = new short[1] ;
         A208WWPFormReferenceName = "";
         A367CallToActionUrl = "";
         GXt_char1 = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_convertnewtooldmenustructure__default(),
            new Object[][] {
                new Object[] {
               P00DU2_A584ActiveAppVersionId, P00DU2_n584ActiveAppVersionId, P00DU2_A598PublishedActiveAppVersionId, P00DU2_n598PublishedActiveAppVersionId, P00DU2_A29LocationId, P00DU2_A11OrganisationId
               }
               , new Object[] {
               P00DU3_A273Trn_ThemeId
               }
               , new Object[] {
               P00DU4_A273Trn_ThemeId
               }
               , new Object[] {
               P00DU5_A206WWPFormId, P00DU5_A208WWPFormReferenceName, P00DU5_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private string AV17PageName ;
      private string A208WWPFormReferenceName ;
      private string A367CallToActionUrl ;
      private Guid AV16PageId ;
      private Guid AV18LocationId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV21OrganisationId ;
      private Guid AV19ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MenuPage AV8SDT_MenuPage ;
      private SdtSDT_MobilePage AV9SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DU2_A584ActiveAppVersionId ;
      private bool[] P00DU2_n584ActiveAppVersionId ;
      private Guid[] P00DU2_A598PublishedActiveAppVersionId ;
      private bool[] P00DU2_n598PublishedActiveAppVersionId ;
      private Guid[] P00DU2_A29LocationId ;
      private Guid[] P00DU2_A11OrganisationId ;
      private Guid[] P00DU3_A273Trn_ThemeId ;
      private Guid[] P00DU4_A273Trn_ThemeId ;
      private SdtSDT_MenuPage_RowsItem AV12RowsItem ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV14TilesItem ;
      private SdtSDT_Col AV15SDT_Col ;
      private SdtSDT_Tile AV11SDT_Tile ;
      private short[] P00DU5_A206WWPFormId ;
      private string[] P00DU5_A208WWPFormReferenceName ;
      private short[] P00DU5_A207WWPFormVersionNumber ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_convertnewtooldmenustructure__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DU2;
          prmP00DU2 = new Object[] {
          new ParDef("AV18LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DU3;
          prmP00DU3 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00DU4;
          prmP00DU4 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00DU5;
          prmP00DU5 = new Object[] {
          new ParDef("AV14Tile_1Action_1Objectid",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DU2", "SELECT ActiveAppVersionId, PublishedActiveAppVersionId, LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :AV18LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DU3", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DU3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DU4", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DU4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DU5", "SELECT WWPFormId, WWPFormReferenceName, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = TO_NUMBER(0 || :AV14Tile_1Action_1Objectid,'9999999999999999999999999999.99999999999999') ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DU5,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
