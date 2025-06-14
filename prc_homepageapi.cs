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
   public class prc_homepageapi : GXProcedure
   {
      public prc_homepageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_homepageapi( IGxContext context )
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
                           out SdtSDT_InfoPage aP3_SDT_InfoPage )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV11SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_InfoPage=this.AV11SDT_InfoPage;
      }

      public SdtSDT_InfoPage executeUdp( Guid aP0_LocationId ,
                                         Guid aP1_OrganisationId ,
                                         string aP2_UserId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_UserId, out aP3_SDT_InfoPage);
         return AV11SDT_InfoPage ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 string aP2_UserId ,
                                 out SdtSDT_InfoPage aP3_SDT_InfoPage )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV11SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         SubmitImpl();
         aP3_SDT_InfoPage=this.AV11SDT_InfoPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GB2 */
         pr_default.execute(0, new Object[] {AV10UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00GB2_A71ResidentGUID[0];
            A599ResidentLanguage = P00GB2_A599ResidentLanguage[0];
            A62ResidentId = P00GB2_A62ResidentId[0];
            A29LocationId = P00GB2_A29LocationId[0];
            n29LocationId = P00GB2_n29LocationId[0];
            A11OrganisationId = P00GB2_A11OrganisationId[0];
            n11OrganisationId = P00GB2_n11OrganisationId[0];
            AV20ResidentLanguage = A599ResidentLanguage;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00GB3 */
         pr_default.execute(1, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00GB3_A29LocationId[0];
            n29LocationId = P00GB3_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00GB3_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00GB3_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00GB3_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00GB3_n584ActiveAppVersionId[0];
            A11OrganisationId = P00GB3_A11OrganisationId[0];
            n11OrganisationId = P00GB3_n11OrganisationId[0];
            AV12AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV12AppVersionId) )
            {
               AV12AppVersionId = A584ActiveAppVersionId;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00GB4 */
         pr_default.execute(2, new Object[] {AV8LocationId, AV9OrganisationId, AV12AppVersionId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A523AppVersionId = P00GB4_A523AppVersionId[0];
            A11OrganisationId = P00GB4_A11OrganisationId[0];
            n11OrganisationId = P00GB4_n11OrganisationId[0];
            A29LocationId = P00GB4_A29LocationId[0];
            n29LocationId = P00GB4_n29LocationId[0];
            A273Trn_ThemeId = P00GB4_A273Trn_ThemeId[0];
            AV14ThemeId = A273Trn_ThemeId;
            if ( (Guid.Empty==AV14ThemeId) )
            {
               /* Execute user subroutine: 'GETTHEMEID' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
            }
            /* Using cursor P00GB5 */
            pr_default.execute(3, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A517PageName = P00GB5_A517PageName[0];
               A516PageId = P00GB5_A516PageId[0];
               A536PagePublishedStructure = P00GB5_A536PagePublishedStructure[0];
               AV11SDT_InfoPage = new SdtSDT_InfoPage(context);
               GXt_char1 = AV21PagePublishedStructure;
               new prc_getdynamictranslation(context ).execute(  A516PageId,  AV20ResidentLanguage,  A536PagePublishedStructure, out  GXt_char1) ;
               AV21PagePublishedStructure = GXt_char1;
               AV11SDT_InfoPage.FromJSonString(AV21PagePublishedStructure, null);
               AV11SDT_InfoPage.gxTpr_Pageid = A516PageId;
               AV11SDT_InfoPage.gxTpr_Pagename = A517PageName;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV11SDT_InfoPage.gxTpr_Infocontent.Count )
         {
            AV13InfoContent = ((SdtSDT_InfoPage_InfoContentItem)AV11SDT_InfoPage.gxTpr_Infocontent.Item(AV26GXV1));
            if ( StringUtil.StrCmp(AV13InfoContent.gxTpr_Infotype, "Images") == 0 )
            {
               AV13InfoContent.gxTpr_Infotype = "Image";
               AV19Images = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV27GXV2 = 1;
               while ( AV27GXV2 <= AV13InfoContent.gxTpr_Images.Count )
               {
                  AV18InfoImageString = ((string)AV13InfoContent.gxTpr_Images.Item(AV27GXV2));
                  AV17InfoImage = new SdtSDT_InfoImage_SDT_InfoImageItem(context);
                  AV17InfoImage.FromJSonString(AV18InfoImageString, null);
                  AV19Images.Add(AV17InfoImage.gxTpr_Infoimagevalue, 0);
                  AV27GXV2 = (int)(AV27GXV2+1);
               }
               AV13InfoContent.gxTpr_Images = AV19Images;
            }
            else if ( StringUtil.StrCmp(AV13InfoContent.gxTpr_Infotype, "Cta") == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon)) )
               {
                  AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctatype;
               }
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV14ThemeId,  AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctacolor, out  GXt_char1) ;
               AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctacolor = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor))) )
               {
                  AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = context.GetMessage( "ctaColor1", "");
               }
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV14ThemeId,  AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor, out  GXt_char1) ;
               AV13InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV13InfoContent.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV28GXV3 = 1;
               while ( AV28GXV3 <= AV13InfoContent.gxTpr_Tiles.Count )
               {
                  AV15SDT_InfoTile = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV13InfoContent.gxTpr_Tiles.Item(AV28GXV3));
                  GXt_char1 = "";
                  new prc_getthemecolorbyname(context ).execute(  AV14ThemeId,  AV15SDT_InfoTile.gxTpr_Bgcolor, out  GXt_char1) ;
                  AV15SDT_InfoTile.gxTpr_Bgcolor = GXt_char1;
                  AV15SDT_InfoTile.gxTpr_Size = (decimal)(((AV15SDT_InfoTile.gxTpr_Size==Convert.ToDecimal(0)) ? 80 : (short)(Math.Round(AV15SDT_InfoTile.gxTpr_Size, 18, MidpointRounding.ToEven))));
                  AV15SDT_InfoTile.gxTpr_Size = (decimal)(AV15SDT_InfoTile.gxTpr_Size/ (decimal)(80));
                  if ( StringUtil.StrCmp(AV15SDT_InfoTile.gxTpr_Action.gxTpr_Objecttype, "DynamicForm") == 0 )
                  {
                     /* Using cursor P00GB6 */
                     pr_default.execute(4, new Object[] {AV15SDT_InfoTile.gxTpr_Action.gxTpr_Formid, AV15SDT_InfoTile.gxTpr_Action.gxTpr_Objectid});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A206WWPFormId = P00GB6_A206WWPFormId[0];
                        A208WWPFormReferenceName = P00GB6_A208WWPFormReferenceName[0];
                        A207WWPFormVersionNumber = P00GB6_A207WWPFormVersionNumber[0];
                        AV15SDT_InfoTile.gxTpr_Action.gxTpr_Objecturl = A367CallToActionUrl;
                        GXt_char1 = "";
                        GXt_char2 = context.GetMessage( "Form", "");
                        new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char1) ;
                        AV15SDT_InfoTile.gxTpr_Action.gxTpr_Objecturl = GXt_char1;
                        pr_default.readNext(4);
                     }
                     pr_default.close(4);
                  }
                  AV28GXV3 = (int)(AV28GXV3+1);
               }
            }
            else
            {
            }
            AV26GXV1 = (int)(AV26GXV1+1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETTHEMEID' Routine */
         returnInSub = false;
         GXt_guid3 = AV14ThemeId;
         new prc_getdefaulttheme(context ).execute( out  GXt_guid3) ;
         AV14ThemeId = GXt_guid3;
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
         AV11SDT_InfoPage = new SdtSDT_InfoPage(context);
         P00GB2_A71ResidentGUID = new string[] {""} ;
         P00GB2_A599ResidentLanguage = new string[] {""} ;
         P00GB2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00GB2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GB2_n29LocationId = new bool[] {false} ;
         P00GB2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GB2_n11OrganisationId = new bool[] {false} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20ResidentLanguage = "";
         P00GB3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GB3_n29LocationId = new bool[] {false} ;
         P00GB3_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00GB3_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00GB3_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00GB3_n584ActiveAppVersionId = new bool[] {false} ;
         P00GB3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GB3_n11OrganisationId = new bool[] {false} ;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         AV12AppVersionId = Guid.Empty;
         P00GB4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GB4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GB4_n11OrganisationId = new bool[] {false} ;
         P00GB4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GB4_n29LocationId = new bool[] {false} ;
         P00GB4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         AV14ThemeId = Guid.Empty;
         P00GB5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GB5_A517PageName = new string[] {""} ;
         P00GB5_A516PageId = new Guid[] {Guid.Empty} ;
         P00GB5_A536PagePublishedStructure = new string[] {""} ;
         A517PageName = "";
         A516PageId = Guid.Empty;
         A536PagePublishedStructure = "";
         AV21PagePublishedStructure = "";
         AV13InfoContent = new SdtSDT_InfoPage_InfoContentItem(context);
         AV19Images = new GxSimpleCollection<string>();
         AV18InfoImageString = "";
         AV17InfoImage = new SdtSDT_InfoImage_SDT_InfoImageItem(context);
         AV15SDT_InfoTile = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         P00GB6_A206WWPFormId = new short[1] ;
         P00GB6_A208WWPFormReferenceName = new string[] {""} ;
         P00GB6_A207WWPFormVersionNumber = new short[1] ;
         A208WWPFormReferenceName = "";
         A367CallToActionUrl = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_guid3 = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_homepageapi__default(),
            new Object[][] {
                new Object[] {
               P00GB2_A71ResidentGUID, P00GB2_A599ResidentLanguage, P00GB2_A62ResidentId, P00GB2_A29LocationId, P00GB2_A11OrganisationId
               }
               , new Object[] {
               P00GB3_A29LocationId, P00GB3_A598PublishedActiveAppVersionId, P00GB3_n598PublishedActiveAppVersionId, P00GB3_A584ActiveAppVersionId, P00GB3_n584ActiveAppVersionId, P00GB3_A11OrganisationId
               }
               , new Object[] {
               P00GB4_A523AppVersionId, P00GB4_A11OrganisationId, P00GB4_n11OrganisationId, P00GB4_A29LocationId, P00GB4_n29LocationId, P00GB4_A273Trn_ThemeId
               }
               , new Object[] {
               P00GB5_A523AppVersionId, P00GB5_A517PageName, P00GB5_A516PageId, P00GB5_A536PagePublishedStructure
               }
               , new Object[] {
               P00GB6_A206WWPFormId, P00GB6_A208WWPFormReferenceName, P00GB6_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV26GXV1 ;
      private int AV27GXV2 ;
      private int AV28GXV3 ;
      private string A599ResidentLanguage ;
      private string AV20ResidentLanguage ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private bool returnInSub ;
      private string A536PagePublishedStructure ;
      private string AV21PagePublishedStructure ;
      private string AV18InfoImageString ;
      private string AV10UserId ;
      private string A71ResidentGUID ;
      private string A517PageName ;
      private string A208WWPFormReferenceName ;
      private string A367CallToActionUrl ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid AV12AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV14ThemeId ;
      private Guid A516PageId ;
      private Guid GXt_guid3 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_InfoPage AV11SDT_InfoPage ;
      private IDataStoreProvider pr_default ;
      private string[] P00GB2_A71ResidentGUID ;
      private string[] P00GB2_A599ResidentLanguage ;
      private Guid[] P00GB2_A62ResidentId ;
      private Guid[] P00GB2_A29LocationId ;
      private bool[] P00GB2_n29LocationId ;
      private Guid[] P00GB2_A11OrganisationId ;
      private bool[] P00GB2_n11OrganisationId ;
      private Guid[] P00GB3_A29LocationId ;
      private bool[] P00GB3_n29LocationId ;
      private Guid[] P00GB3_A598PublishedActiveAppVersionId ;
      private bool[] P00GB3_n598PublishedActiveAppVersionId ;
      private Guid[] P00GB3_A584ActiveAppVersionId ;
      private bool[] P00GB3_n584ActiveAppVersionId ;
      private Guid[] P00GB3_A11OrganisationId ;
      private bool[] P00GB3_n11OrganisationId ;
      private Guid[] P00GB4_A523AppVersionId ;
      private Guid[] P00GB4_A11OrganisationId ;
      private bool[] P00GB4_n11OrganisationId ;
      private Guid[] P00GB4_A29LocationId ;
      private bool[] P00GB4_n29LocationId ;
      private Guid[] P00GB4_A273Trn_ThemeId ;
      private Guid[] P00GB5_A523AppVersionId ;
      private string[] P00GB5_A517PageName ;
      private Guid[] P00GB5_A516PageId ;
      private string[] P00GB5_A536PagePublishedStructure ;
      private SdtSDT_InfoPage_InfoContentItem AV13InfoContent ;
      private GxSimpleCollection<string> AV19Images ;
      private SdtSDT_InfoImage_SDT_InfoImageItem AV17InfoImage ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV15SDT_InfoTile ;
      private short[] P00GB6_A206WWPFormId ;
      private string[] P00GB6_A208WWPFormReferenceName ;
      private short[] P00GB6_A207WWPFormVersionNumber ;
      private SdtSDT_InfoPage aP3_SDT_InfoPage ;
   }

   public class prc_homepageapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GB2;
          prmP00GB2 = new Object[] {
          new ParDef("AV10UserId",GXType.VarChar,100,0)
          };
          Object[] prmP00GB3;
          prmP00GB3 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GB4;
          prmP00GB4 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GB5;
          prmP00GB5 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GB6;
          prmP00GB6 = new Object[] {
          new ParDef("AV15SDT__2Action_2Formid",GXType.Int16,4,0) ,
          new ParDef("AV15SDT__1Action_1Objectid",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GB2", "SELECT ResidentGUID, ResidentLanguage, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV10UserId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GB3", "SELECT LocationId, PublishedActiveAppVersionId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GB4", "SELECT AppVersionId, OrganisationId, LocationId, Trn_ThemeId FROM Trn_AppVersion WHERE (LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId) AND (AppVersionId = :AV12AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GB5", "SELECT AppVersionId, PageName, PageId, PagePublishedStructure FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (LOWER(PageName) = ( 'home')) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GB6", "SELECT WWPFormId, WWPFormReferenceName, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV15SDT__2Action_2Formid or WWPFormId = TO_NUMBER(0 || :AV15SDT__1Action_1Objectid,'9999999999999999999999999999.99999999999999') ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
