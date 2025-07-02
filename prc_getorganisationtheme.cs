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
   public class prc_getorganisationtheme : GXProcedure
   {
      public prc_getorganisationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getorganisationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           Guid aP1_LocationId ,
                           out GXBaseCollection<SdtSDT_Icon> aP2_SDT_IconCollection ,
                           out GXBCCollection<SdtTrn_Theme> aP3_BC_Trn_ThemeCollection )
      {
         this.AV16OrganisationId = aP0_OrganisationId;
         this.AV26LocationId = aP1_LocationId;
         this.AV30SDT_IconCollection = new GXBaseCollection<SdtSDT_Icon>( context, "SDT_Icon", "Comforta_version2") ;
         this.AV23BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_IconCollection=this.AV30SDT_IconCollection;
         aP3_BC_Trn_ThemeCollection=this.AV23BC_Trn_ThemeCollection;
      }

      public GXBCCollection<SdtTrn_Theme> executeUdp( Guid aP0_OrganisationId ,
                                                      Guid aP1_LocationId ,
                                                      out GXBaseCollection<SdtSDT_Icon> aP2_SDT_IconCollection )
      {
         execute(aP0_OrganisationId, aP1_LocationId, out aP2_SDT_IconCollection, out aP3_BC_Trn_ThemeCollection);
         return AV23BC_Trn_ThemeCollection ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 Guid aP1_LocationId ,
                                 out GXBaseCollection<SdtSDT_Icon> aP2_SDT_IconCollection ,
                                 out GXBCCollection<SdtTrn_Theme> aP3_BC_Trn_ThemeCollection )
      {
         this.AV16OrganisationId = aP0_OrganisationId;
         this.AV26LocationId = aP1_LocationId;
         this.AV30SDT_IconCollection = new GXBaseCollection<SdtSDT_Icon>( context, "SDT_Icon", "Comforta_version2") ;
         this.AV23BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_IconCollection=this.AV30SDT_IconCollection;
         aP3_BC_Trn_ThemeCollection=this.AV23BC_Trn_ThemeCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Language = context.GetLanguage( );
         /* Using cursor P00C32 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A649Trn_IconId = P00C32_A649Trn_IconId[0];
            A657IconDisplayName = P00C32_A657IconDisplayName[0];
            A651IconEnglishName = P00C32_A651IconEnglishName[0];
            A655IconEnglishTags = P00C32_A655IconEnglishTags[0];
            A652IconDutchName = P00C32_A652IconDutchName[0];
            A656IconDutchTags = P00C32_A656IconDutchTags[0];
            A653Trn_IconSVG = P00C32_A653Trn_IconSVG[0];
            A654Trn_IconCategory = P00C32_A654Trn_IconCategory[0];
            AV29SDT_Icon = new SdtSDT_Icon(context);
            AV29SDT_Icon.gxTpr_Iconid = A649Trn_IconId;
            AV29SDT_Icon.gxTpr_Iconcodename = A657IconDisplayName;
            if ( StringUtil.StrCmp(AV31Language, context.GetMessage( "English", "")) == 0 )
            {
               AV29SDT_Icon.gxTpr_Iconname = A651IconEnglishName;
               AV29SDT_Icon.gxTpr_Icontags = A655IconEnglishTags;
            }
            else
            {
               AV29SDT_Icon.gxTpr_Iconname = A652IconDutchName;
               AV29SDT_Icon.gxTpr_Icontags = A656IconDutchTags;
            }
            AV29SDT_Icon.gxTpr_Iconsvg = A653Trn_IconSVG;
            AV29SDT_Icon.gxTpr_Iconcategory = A654Trn_IconCategory;
            AV30SDT_IconCollection.Add(AV29SDT_Icon, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00C33 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A576ThemeIsPredefined = P00C33_A576ThemeIsPredefined[0];
            A274Trn_ThemeName = P00C33_A274Trn_ThemeName[0];
            A273Trn_ThemeId = P00C33_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C33_n273Trn_ThemeId[0];
            AV22BC_Trn_Theme = new SdtTrn_Theme(context);
            AV22BC_Trn_Theme.Load(A273Trn_ThemeId);
            AV22BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
            AV28Icons.FromJSonString(AV30SDT_IconCollection.ToJSonString(false), null);
            AV22BC_Trn_Theme.gxTpr_Icon = AV28Icons;
            AV23BC_Trn_ThemeCollection.Add(AV22BC_Trn_Theme, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00C34 */
         pr_default.execute(2, new Object[] {AV26LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A584ActiveAppVersionId = P00C34_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00C34_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = P00C34_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00C34_n598PublishedActiveAppVersionId[0];
            A577LocationThemeId = P00C34_A577LocationThemeId[0];
            n577LocationThemeId = P00C34_n577LocationThemeId[0];
            A573LocationHasOwnBrand = P00C34_A573LocationHasOwnBrand[0];
            A29LocationId = P00C34_A29LocationId[0];
            A11OrganisationId = P00C34_A11OrganisationId[0];
            /* Using cursor P00C35 */
            pr_default.execute(3, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = P00C35_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C35_n273Trn_ThemeId[0];
            pr_default.close(3);
            /* Using cursor P00C36 */
            pr_default.execute(4, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = P00C36_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C36_n273Trn_ThemeId[0];
            pr_default.close(4);
            /* Using cursor P00C37 */
            pr_default.execute(5, new Object[] {n577LocationThemeId, A577LocationThemeId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A273Trn_ThemeId = P00C37_A273Trn_ThemeId[0];
               n273Trn_ThemeId = P00C37_n273Trn_ThemeId[0];
               AV22BC_Trn_Theme = new SdtTrn_Theme(context);
               AV22BC_Trn_Theme.Load(A577LocationThemeId);
               AV22BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
               AV22BC_Trn_Theme.gxTpr_Icon = AV28Icons;
               AV23BC_Trn_ThemeCollection.Add(AV22BC_Trn_Theme, 0);
               /* Execute user subroutine: 'FINISH' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(5);
                  cleanup();
                  if (true) return;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         pr_default.close(4);
         /* Using cursor P00C38 */
         pr_default.execute(6, new Object[] {AV16OrganisationId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A537OrganisationHasOwnBrand = P00C38_A537OrganisationHasOwnBrand[0];
            A11OrganisationId = P00C38_A11OrganisationId[0];
            A273Trn_ThemeId = P00C38_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C38_n273Trn_ThemeId[0];
            A100OrganisationSettingid = P00C38_A100OrganisationSettingid[0];
            new prc_logtoserver(context ).execute(  context.GetMessage( "Organisation Setting Theme >>> ", "")+A273Trn_ThemeId.ToString()) ;
            if ( ! (Guid.Empty==A273Trn_ThemeId) )
            {
               AV22BC_Trn_Theme = new SdtTrn_Theme(context);
               AV22BC_Trn_Theme.Load(A273Trn_ThemeId);
               AV22BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
               AV22BC_Trn_Theme.gxTpr_Icon = AV28Icons;
               AV23BC_Trn_ThemeCollection.Add(AV22BC_Trn_Theme, 0);
               /* Execute user subroutine: 'FINISH' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(6);
                  cleanup();
                  if (true) return;
               }
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         cleanup();
      }

      protected void S111( )
      {
         /* 'FINISH' Routine */
         returnInSub = false;
         AV23BC_Trn_ThemeCollection.Sort("Trn_ThemeName");
         returnInSub = true;
         if (true) return;
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
         pr_default.close(3);
      }

      public override void initialize( )
      {
         AV30SDT_IconCollection = new GXBaseCollection<SdtSDT_Icon>( context, "SDT_Icon", "Comforta_version2");
         AV23BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV31Language = "";
         P00C32_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         P00C32_A657IconDisplayName = new string[] {""} ;
         P00C32_A651IconEnglishName = new string[] {""} ;
         P00C32_A655IconEnglishTags = new string[] {""} ;
         P00C32_A652IconDutchName = new string[] {""} ;
         P00C32_A656IconDutchTags = new string[] {""} ;
         P00C32_A653Trn_IconSVG = new string[] {""} ;
         P00C32_A654Trn_IconCategory = new string[] {""} ;
         A649Trn_IconId = Guid.Empty;
         A657IconDisplayName = "";
         A651IconEnglishName = "";
         A655IconEnglishTags = "";
         A652IconDutchName = "";
         A656IconDutchTags = "";
         A653Trn_IconSVG = "";
         A654Trn_IconCategory = "";
         AV29SDT_Icon = new SdtSDT_Icon(context);
         P00C33_A576ThemeIsPredefined = new bool[] {false} ;
         P00C33_A274Trn_ThemeName = new string[] {""} ;
         P00C33_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C33_n273Trn_ThemeId = new bool[] {false} ;
         A274Trn_ThemeName = "";
         A273Trn_ThemeId = Guid.Empty;
         AV22BC_Trn_Theme = new SdtTrn_Theme(context);
         AV28Icons = new GXBCLevelCollection<SdtTrn_Theme_Icon>( context, "Trn_Theme.Icon", "Comforta_version2");
         P00C34_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00C34_n584ActiveAppVersionId = new bool[] {false} ;
         P00C34_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00C34_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00C34_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         P00C34_n577LocationThemeId = new bool[] {false} ;
         P00C34_A573LocationHasOwnBrand = new bool[] {false} ;
         P00C34_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C34_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A577LocationThemeId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00C35_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C35_n273Trn_ThemeId = new bool[] {false} ;
         P00C36_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C36_n273Trn_ThemeId = new bool[] {false} ;
         P00C37_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C37_n273Trn_ThemeId = new bool[] {false} ;
         P00C38_A537OrganisationHasOwnBrand = new bool[] {false} ;
         P00C38_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C38_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C38_n273Trn_ThemeId = new bool[] {false} ;
         P00C38_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A100OrganisationSettingid = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getorganisationtheme__default(),
            new Object[][] {
                new Object[] {
               P00C32_A649Trn_IconId, P00C32_A657IconDisplayName, P00C32_A651IconEnglishName, P00C32_A655IconEnglishTags, P00C32_A652IconDutchName, P00C32_A656IconDutchTags, P00C32_A653Trn_IconSVG, P00C32_A654Trn_IconCategory
               }
               , new Object[] {
               P00C33_A576ThemeIsPredefined, P00C33_A274Trn_ThemeName, P00C33_A273Trn_ThemeId
               }
               , new Object[] {
               P00C34_A584ActiveAppVersionId, P00C34_n584ActiveAppVersionId, P00C34_A598PublishedActiveAppVersionId, P00C34_n598PublishedActiveAppVersionId, P00C34_A577LocationThemeId, P00C34_n577LocationThemeId, P00C34_A573LocationHasOwnBrand, P00C34_A29LocationId, P00C34_A11OrganisationId
               }
               , new Object[] {
               P00C35_A273Trn_ThemeId
               }
               , new Object[] {
               P00C36_A273Trn_ThemeId
               }
               , new Object[] {
               P00C37_A273Trn_ThemeId
               }
               , new Object[] {
               P00C38_A537OrganisationHasOwnBrand, P00C38_A11OrganisationId, P00C38_A273Trn_ThemeId, P00C38_n273Trn_ThemeId, P00C38_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A576ThemeIsPredefined ;
      private bool n273Trn_ThemeId ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n577LocationThemeId ;
      private bool A573LocationHasOwnBrand ;
      private bool returnInSub ;
      private bool A537OrganisationHasOwnBrand ;
      private string AV31Language ;
      private string A655IconEnglishTags ;
      private string A656IconDutchTags ;
      private string A653Trn_IconSVG ;
      private string A657IconDisplayName ;
      private string A651IconEnglishName ;
      private string A652IconDutchName ;
      private string A654Trn_IconCategory ;
      private string A274Trn_ThemeName ;
      private Guid AV16OrganisationId ;
      private Guid AV26LocationId ;
      private Guid A649Trn_IconId ;
      private Guid A273Trn_ThemeId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A577LocationThemeId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Icon> AV30SDT_IconCollection ;
      private GXBCCollection<SdtTrn_Theme> AV23BC_Trn_ThemeCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C32_A649Trn_IconId ;
      private string[] P00C32_A657IconDisplayName ;
      private string[] P00C32_A651IconEnglishName ;
      private string[] P00C32_A655IconEnglishTags ;
      private string[] P00C32_A652IconDutchName ;
      private string[] P00C32_A656IconDutchTags ;
      private string[] P00C32_A653Trn_IconSVG ;
      private string[] P00C32_A654Trn_IconCategory ;
      private SdtSDT_Icon AV29SDT_Icon ;
      private bool[] P00C33_A576ThemeIsPredefined ;
      private string[] P00C33_A274Trn_ThemeName ;
      private Guid[] P00C33_A273Trn_ThemeId ;
      private bool[] P00C33_n273Trn_ThemeId ;
      private SdtTrn_Theme AV22BC_Trn_Theme ;
      private GXBCLevelCollection<SdtTrn_Theme_Icon> AV28Icons ;
      private Guid[] P00C34_A584ActiveAppVersionId ;
      private bool[] P00C34_n584ActiveAppVersionId ;
      private Guid[] P00C34_A598PublishedActiveAppVersionId ;
      private bool[] P00C34_n598PublishedActiveAppVersionId ;
      private Guid[] P00C34_A577LocationThemeId ;
      private bool[] P00C34_n577LocationThemeId ;
      private bool[] P00C34_A573LocationHasOwnBrand ;
      private Guid[] P00C34_A29LocationId ;
      private Guid[] P00C34_A11OrganisationId ;
      private Guid[] P00C35_A273Trn_ThemeId ;
      private bool[] P00C35_n273Trn_ThemeId ;
      private Guid[] P00C36_A273Trn_ThemeId ;
      private bool[] P00C36_n273Trn_ThemeId ;
      private Guid[] P00C37_A273Trn_ThemeId ;
      private bool[] P00C37_n273Trn_ThemeId ;
      private bool[] P00C38_A537OrganisationHasOwnBrand ;
      private Guid[] P00C38_A11OrganisationId ;
      private Guid[] P00C38_A273Trn_ThemeId ;
      private bool[] P00C38_n273Trn_ThemeId ;
      private Guid[] P00C38_A100OrganisationSettingid ;
      private GXBaseCollection<SdtSDT_Icon> aP2_SDT_IconCollection ;
      private GXBCCollection<SdtTrn_Theme> aP3_BC_Trn_ThemeCollection ;
   }

   public class prc_getorganisationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C32;
          prmP00C32 = new Object[] {
          };
          Object[] prmP00C33;
          prmP00C33 = new Object[] {
          };
          Object[] prmP00C34;
          prmP00C34 = new Object[] {
          new ParDef("AV26LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00C35;
          prmP00C35 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00C36;
          prmP00C36 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00C37;
          prmP00C37 = new Object[] {
          new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00C38;
          prmP00C38 = new Object[] {
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C32", "SELECT Trn_IconId, IconDisplayName, IconEnglishName, IconEnglishTags, IconDutchName, IconDutchTags, Trn_IconSVG, Trn_IconCategory FROM Trn_Icon ORDER BY Trn_IconId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C32,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C33", "SELECT ThemeIsPredefined, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE (Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(Trn_ThemeName))))=0)) AND (ThemeIsPredefined = TRUE) ORDER BY Trn_ThemeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C33,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C34", "SELECT ActiveAppVersionId, PublishedActiveAppVersionId, LocationThemeId, LocationHasOwnBrand, LocationId, OrganisationId FROM Trn_Location WHERE (LocationId = :AV26LocationId) AND (LocationHasOwnBrand = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C34,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C35", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C36", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C37", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :LocationThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C38", "SELECT OrganisationHasOwnBrand, OrganisationId, Trn_ThemeId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE (OrganisationId = :AV16OrganisationId) AND (OrganisationHasOwnBrand = TRUE) ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C38,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 6 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
