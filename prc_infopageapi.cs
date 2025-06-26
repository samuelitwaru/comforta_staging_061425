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
   public class prc_infopageapi : GXProcedure
   {
      public prc_infopageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_infopageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           string aP3_UserId ,
                           out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         this.AV12PageId = aP0_PageId;
         this.AV9LocationId = aP1_LocationId;
         this.AV11OrganisationId = aP2_OrganisationId;
         this.AV13UserId = aP3_UserId;
         this.AV8SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_InfoPage=this.AV8SDT_InfoPage;
      }

      public SdtSDT_InfoPage executeUdp( Guid aP0_PageId ,
                                         Guid aP1_LocationId ,
                                         Guid aP2_OrganisationId ,
                                         string aP3_UserId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_UserId, out aP4_SDT_InfoPage);
         return AV8SDT_InfoPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_UserId ,
                                 out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         this.AV12PageId = aP0_PageId;
         this.AV9LocationId = aP1_LocationId;
         this.AV11OrganisationId = aP2_OrganisationId;
         this.AV13UserId = aP3_UserId;
         this.AV8SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         SubmitImpl();
         aP4_SDT_InfoPage=this.AV8SDT_InfoPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00G32 */
         pr_default.execute(0, new Object[] {AV13UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00G32_A71ResidentGUID[0];
            A599ResidentLanguage = P00G32_A599ResidentLanguage[0];
            A62ResidentId = P00G32_A62ResidentId[0];
            A29LocationId = P00G32_A29LocationId[0];
            n29LocationId = P00G32_n29LocationId[0];
            A11OrganisationId = P00G32_A11OrganisationId[0];
            n11OrganisationId = P00G32_n11OrganisationId[0];
            AV20ResidentLanguage = A599ResidentLanguage;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00G33 */
         pr_default.execute(1, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00G33_A29LocationId[0];
            n29LocationId = P00G33_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00G33_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00G33_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00G33_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00G33_n584ActiveAppVersionId[0];
            A11OrganisationId = P00G33_A11OrganisationId[0];
            n11OrganisationId = P00G33_n11OrganisationId[0];
            AV10AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV10AppVersionId) )
            {
               AV10AppVersionId = A584ActiveAppVersionId;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00G34 */
         pr_default.execute(2, new Object[] {AV9LocationId, AV11OrganisationId, AV10AppVersionId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A523AppVersionId = P00G34_A523AppVersionId[0];
            A11OrganisationId = P00G34_A11OrganisationId[0];
            n11OrganisationId = P00G34_n11OrganisationId[0];
            A29LocationId = P00G34_A29LocationId[0];
            n29LocationId = P00G34_n29LocationId[0];
            A273Trn_ThemeId = P00G34_A273Trn_ThemeId[0];
            AV15ThemeId = A273Trn_ThemeId;
            if ( (Guid.Empty==AV15ThemeId) )
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
            /* Using cursor P00G35 */
            pr_default.execute(3, new Object[] {A523AppVersionId, AV12PageId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A516PageId = P00G35_A516PageId[0];
               A536PagePublishedStructure = P00G35_A536PagePublishedStructure[0];
               A517PageName = P00G35_A517PageName[0];
               AV8SDT_InfoPage = new SdtSDT_InfoPage(context);
               GXt_char1 = AV19PagePublishedStructure;
               new prc_getdynamictranslation(context ).execute(  A516PageId,  AV20ResidentLanguage,  A536PagePublishedStructure, out  GXt_char1) ;
               AV19PagePublishedStructure = GXt_char1;
               AV8SDT_InfoPage.FromJSonString(AV19PagePublishedStructure, null);
               AV8SDT_InfoPage.gxTpr_Pageid = A516PageId;
               AV8SDT_InfoPage.gxTpr_Pagename = A517PageName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV8SDT_InfoPage.gxTpr_Infocontent.Count )
         {
            AV14InfoContent = ((SdtSDT_InfoPage_InfoContentItem)AV8SDT_InfoPage.gxTpr_Infocontent.Item(AV28GXV1));
            if ( StringUtil.StrCmp(AV14InfoContent.gxTpr_Infotype, "Images") == 0 )
            {
               AV14InfoContent.gxTpr_Infotype = "Image";
               AV21Images = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV29GXV2 = 1;
               while ( AV29GXV2 <= AV14InfoContent.gxTpr_Images.Count )
               {
                  AV23InfoImageString = ((string)AV14InfoContent.gxTpr_Images.Item(AV29GXV2));
                  AV22InfoImage = new SdtSDT_InfoImage_SDT_InfoImageItem(context);
                  AV22InfoImage.FromJSonString(AV23InfoImageString, null);
                  AV21Images.Add(AV22InfoImage.gxTpr_Infoimagevalue, 0);
                  AV29GXV2 = (int)(AV29GXV2+1);
               }
               AV14InfoContent.gxTpr_Images = AV21Images;
            }
            else if ( StringUtil.StrCmp(AV14InfoContent.gxTpr_Infotype, "Cta") == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon)) )
               {
                  AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctatype;
               }
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV15ThemeId,  AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctacolor, out  GXt_char1) ;
               AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctacolor = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor))) || ( StringUtil.StrCmp(StringUtil.Trim( AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorOne", "")) == 0 ) )
               {
                  AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = context.GetMessage( "ctaColor1", "");
               }
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV15ThemeId,  AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor, out  GXt_char1) ;
               AV14InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV14InfoContent.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV30GXV3 = 1;
               while ( AV30GXV3 <= AV14InfoContent.gxTpr_Tiles.Count )
               {
                  AV17SDT_InfoTile = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV14InfoContent.gxTpr_Tiles.Item(AV30GXV3));
                  GXt_char1 = "";
                  new prc_getthemecolorbyname(context ).execute(  AV15ThemeId,  AV17SDT_InfoTile.gxTpr_Bgcolor, out  GXt_char1) ;
                  AV17SDT_InfoTile.gxTpr_Bgcolor = GXt_char1;
                  AV17SDT_InfoTile.gxTpr_Size = (decimal)(((AV17SDT_InfoTile.gxTpr_Size==Convert.ToDecimal(0)) ? 80 : (short)(Math.Round(AV17SDT_InfoTile.gxTpr_Size, 18, MidpointRounding.ToEven))));
                  AV17SDT_InfoTile.gxTpr_Size = (decimal)(AV17SDT_InfoTile.gxTpr_Size/ (decimal)(80));
                  if ( StringUtil.StrCmp(AV17SDT_InfoTile.gxTpr_Action.gxTpr_Objecttype, "DynamicForm") == 0 )
                  {
                     /* Using cursor P00G36 */
                     pr_default.execute(4, new Object[] {AV17SDT_InfoTile.gxTpr_Action.gxTpr_Formid, AV17SDT_InfoTile.gxTpr_Action.gxTpr_Objectid});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A206WWPFormId = P00G36_A206WWPFormId[0];
                        A208WWPFormReferenceName = P00G36_A208WWPFormReferenceName[0];
                        A207WWPFormVersionNumber = P00G36_A207WWPFormVersionNumber[0];
                        AV17SDT_InfoTile.gxTpr_Action.gxTpr_Objecturl = A367CallToActionUrl;
                        GXt_char1 = "";
                        GXt_char2 = context.GetMessage( "Form", "");
                        new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char1) ;
                        AV17SDT_InfoTile.gxTpr_Action.gxTpr_Objecturl = GXt_char1;
                        pr_default.readNext(4);
                     }
                     pr_default.close(4);
                  }
                  AV30GXV3 = (int)(AV30GXV3+1);
               }
            }
            else
            {
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETTHEMEID' Routine */
         returnInSub = false;
         GXt_guid3 = AV15ThemeId;
         new prc_getdefaulttheme(context ).execute( out  GXt_guid3) ;
         AV15ThemeId = GXt_guid3;
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
         AV8SDT_InfoPage = new SdtSDT_InfoPage(context);
         P00G32_A71ResidentGUID = new string[] {""} ;
         P00G32_A599ResidentLanguage = new string[] {""} ;
         P00G32_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00G32_A29LocationId = new Guid[] {Guid.Empty} ;
         P00G32_n29LocationId = new bool[] {false} ;
         P00G32_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00G32_n11OrganisationId = new bool[] {false} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20ResidentLanguage = "";
         P00G33_A29LocationId = new Guid[] {Guid.Empty} ;
         P00G33_n29LocationId = new bool[] {false} ;
         P00G33_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00G33_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00G33_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00G33_n584ActiveAppVersionId = new bool[] {false} ;
         P00G33_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00G33_n11OrganisationId = new bool[] {false} ;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         AV10AppVersionId = Guid.Empty;
         P00G34_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G34_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00G34_n11OrganisationId = new bool[] {false} ;
         P00G34_A29LocationId = new Guid[] {Guid.Empty} ;
         P00G34_n29LocationId = new bool[] {false} ;
         P00G34_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         AV15ThemeId = Guid.Empty;
         P00G35_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G35_A516PageId = new Guid[] {Guid.Empty} ;
         P00G35_A536PagePublishedStructure = new string[] {""} ;
         P00G35_A517PageName = new string[] {""} ;
         A516PageId = Guid.Empty;
         A536PagePublishedStructure = "";
         A517PageName = "";
         AV19PagePublishedStructure = "";
         AV14InfoContent = new SdtSDT_InfoPage_InfoContentItem(context);
         AV21Images = new GxSimpleCollection<string>();
         AV23InfoImageString = "";
         AV22InfoImage = new SdtSDT_InfoImage_SDT_InfoImageItem(context);
         AV17SDT_InfoTile = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         P00G36_A206WWPFormId = new short[1] ;
         P00G36_A208WWPFormReferenceName = new string[] {""} ;
         P00G36_A207WWPFormVersionNumber = new short[1] ;
         A208WWPFormReferenceName = "";
         A367CallToActionUrl = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_guid3 = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_infopageapi__default(),
            new Object[][] {
                new Object[] {
               P00G32_A71ResidentGUID, P00G32_A599ResidentLanguage, P00G32_A62ResidentId, P00G32_A29LocationId, P00G32_A11OrganisationId
               }
               , new Object[] {
               P00G33_A29LocationId, P00G33_A598PublishedActiveAppVersionId, P00G33_n598PublishedActiveAppVersionId, P00G33_A584ActiveAppVersionId, P00G33_n584ActiveAppVersionId, P00G33_A11OrganisationId
               }
               , new Object[] {
               P00G34_A523AppVersionId, P00G34_A11OrganisationId, P00G34_n11OrganisationId, P00G34_A29LocationId, P00G34_n29LocationId, P00G34_A273Trn_ThemeId
               }
               , new Object[] {
               P00G35_A523AppVersionId, P00G35_A516PageId, P00G35_A536PagePublishedStructure, P00G35_A517PageName
               }
               , new Object[] {
               P00G36_A206WWPFormId, P00G36_A208WWPFormReferenceName, P00G36_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV28GXV1 ;
      private int AV29GXV2 ;
      private int AV30GXV3 ;
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
      private string AV19PagePublishedStructure ;
      private string AV23InfoImageString ;
      private string AV13UserId ;
      private string A71ResidentGUID ;
      private string A517PageName ;
      private string A208WWPFormReferenceName ;
      private string A367CallToActionUrl ;
      private Guid AV12PageId ;
      private Guid AV9LocationId ;
      private Guid AV11OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid AV10AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV15ThemeId ;
      private Guid A516PageId ;
      private Guid GXt_guid3 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_InfoPage AV8SDT_InfoPage ;
      private IDataStoreProvider pr_default ;
      private string[] P00G32_A71ResidentGUID ;
      private string[] P00G32_A599ResidentLanguage ;
      private Guid[] P00G32_A62ResidentId ;
      private Guid[] P00G32_A29LocationId ;
      private bool[] P00G32_n29LocationId ;
      private Guid[] P00G32_A11OrganisationId ;
      private bool[] P00G32_n11OrganisationId ;
      private Guid[] P00G33_A29LocationId ;
      private bool[] P00G33_n29LocationId ;
      private Guid[] P00G33_A598PublishedActiveAppVersionId ;
      private bool[] P00G33_n598PublishedActiveAppVersionId ;
      private Guid[] P00G33_A584ActiveAppVersionId ;
      private bool[] P00G33_n584ActiveAppVersionId ;
      private Guid[] P00G33_A11OrganisationId ;
      private bool[] P00G33_n11OrganisationId ;
      private Guid[] P00G34_A523AppVersionId ;
      private Guid[] P00G34_A11OrganisationId ;
      private bool[] P00G34_n11OrganisationId ;
      private Guid[] P00G34_A29LocationId ;
      private bool[] P00G34_n29LocationId ;
      private Guid[] P00G34_A273Trn_ThemeId ;
      private Guid[] P00G35_A523AppVersionId ;
      private Guid[] P00G35_A516PageId ;
      private string[] P00G35_A536PagePublishedStructure ;
      private string[] P00G35_A517PageName ;
      private SdtSDT_InfoPage_InfoContentItem AV14InfoContent ;
      private GxSimpleCollection<string> AV21Images ;
      private SdtSDT_InfoImage_SDT_InfoImageItem AV22InfoImage ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV17SDT_InfoTile ;
      private short[] P00G36_A206WWPFormId ;
      private string[] P00G36_A208WWPFormReferenceName ;
      private short[] P00G36_A207WWPFormVersionNumber ;
      private SdtSDT_InfoPage aP4_SDT_InfoPage ;
   }

   public class prc_infopageapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00G32;
          prmP00G32 = new Object[] {
          new ParDef("AV13UserId",GXType.VarChar,40,0)
          };
          Object[] prmP00G33;
          prmP00G33 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00G34;
          prmP00G34 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00G35;
          prmP00G35 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00G36;
          prmP00G36 = new Object[] {
          new ParDef("AV17SDT__2Action_2Formid",GXType.Int16,4,0) ,
          new ParDef("AV17SDT__1Action_1Objectid",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G32", "SELECT ResidentGUID, ResidentLanguage, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV13UserId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G32,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G33", "SELECT LocationId, PublishedActiveAppVersionId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV9LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G33,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G34", "SELECT AppVersionId, OrganisationId, LocationId, Trn_ThemeId FROM Trn_AppVersion WHERE (LocationId = :AV9LocationId and OrganisationId = :AV11OrganisationId) AND (AppVersionId = :AV10AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G34,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G35", "SELECT AppVersionId, PageId, PagePublishedStructure, PageName FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV12PageId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00G36", "SELECT WWPFormId, WWPFormReferenceName, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV17SDT__2Action_2Formid or WWPFormId = TO_NUMBER(0 || :AV17SDT__1Action_1Objectid,'9999999999999999999999999999.99999999999999') ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G36,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
