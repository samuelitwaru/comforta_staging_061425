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
   public class prc_updatelocationthemesetting : GXProcedure
   {
      public prc_updatelocationthemesetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationthemesetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_LocationId ,
                           ref string aP1_LocationBrandTheme ,
                           ref string aP2_LocationCtaTheme ,
                           ref bool aP3_LocationHasOwnBrand )
      {
         this.AV10LocationId = aP0_LocationId;
         this.AV9LocationBrandTheme = aP1_LocationBrandTheme;
         this.AV8LocationCtaTheme = aP2_LocationCtaTheme;
         this.AV11LocationHasOwnBrand = aP3_LocationHasOwnBrand;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV10LocationId;
         aP1_LocationBrandTheme=this.AV9LocationBrandTheme;
         aP2_LocationCtaTheme=this.AV8LocationCtaTheme;
         aP3_LocationHasOwnBrand=this.AV11LocationHasOwnBrand;
      }

      public bool executeUdp( ref Guid aP0_LocationId ,
                              ref string aP1_LocationBrandTheme ,
                              ref string aP2_LocationCtaTheme )
      {
         execute(ref aP0_LocationId, ref aP1_LocationBrandTheme, ref aP2_LocationCtaTheme, ref aP3_LocationHasOwnBrand);
         return AV11LocationHasOwnBrand ;
      }

      public void executeSubmit( ref Guid aP0_LocationId ,
                                 ref string aP1_LocationBrandTheme ,
                                 ref string aP2_LocationCtaTheme ,
                                 ref bool aP3_LocationHasOwnBrand )
      {
         this.AV10LocationId = aP0_LocationId;
         this.AV9LocationBrandTheme = aP1_LocationBrandTheme;
         this.AV8LocationCtaTheme = aP2_LocationCtaTheme;
         this.AV11LocationHasOwnBrand = aP3_LocationHasOwnBrand;
         SubmitImpl();
         aP0_LocationId=this.AV10LocationId;
         aP1_LocationBrandTheme=this.AV9LocationBrandTheme;
         aP2_LocationCtaTheme=this.AV8LocationCtaTheme;
         aP3_LocationHasOwnBrand=this.AV11LocationHasOwnBrand;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A274Trn_ThemeName = P00D92_A274Trn_ThemeName[0];
            A273Trn_ThemeId = P00D92_A273Trn_ThemeId[0];
            AV23BC_Trn_Theme = new SdtTrn_Theme(context);
            AV20Modern_Trn_Theme.Load(A273Trn_ThemeId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11LocationHasOwnBrand )
         {
            AV12Dictionary.fromjson( AV9LocationBrandTheme);
            AV13ColorNameCollection = AV12Dictionary.gxTpr_Keys;
            AV14ColorCodeCollection = AV12Dictionary.gxTpr_Values;
            AV17CtaDictionary.fromjson( AV8LocationCtaTheme);
            AV15CtaColorNameCollection = AV17CtaDictionary.gxTpr_Keys;
            AV16CtaColorCodeCollection = AV17CtaDictionary.gxTpr_Values;
            /* Using cursor P00D93 */
            pr_default.execute(1, new Object[] {AV10LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A584ActiveAppVersionId = P00D93_A584ActiveAppVersionId[0];
               n584ActiveAppVersionId = P00D93_n584ActiveAppVersionId[0];
               A598PublishedActiveAppVersionId = P00D93_A598PublishedActiveAppVersionId[0];
               n598PublishedActiveAppVersionId = P00D93_n598PublishedActiveAppVersionId[0];
               A577LocationThemeId = P00D93_A577LocationThemeId[0];
               n577LocationThemeId = P00D93_n577LocationThemeId[0];
               A29LocationId = P00D93_A29LocationId[0];
               A11OrganisationId = P00D93_A11OrganisationId[0];
               /* Using cursor P00D94 */
               pr_default.execute(2, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
               A273Trn_ThemeId = P00D94_A273Trn_ThemeId[0];
               pr_default.close(2);
               /* Using cursor P00D95 */
               pr_default.execute(3, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
               A273Trn_ThemeId = P00D95_A273Trn_ThemeId[0];
               pr_default.close(3);
               AV31GXLvl19 = 0;
               /* Using cursor P00D96 */
               pr_default.execute(4, new Object[] {n577LocationThemeId, A577LocationThemeId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A273Trn_ThemeId = P00D96_A273Trn_ThemeId[0];
                  A274Trn_ThemeName = P00D96_A274Trn_ThemeName[0];
                  A281Trn_ThemeFontFamily = P00D96_A281Trn_ThemeFontFamily[0];
                  A405Trn_ThemeFontSize = P00D96_A405Trn_ThemeFontSize[0];
                  AV31GXLvl19 = 1;
                  A274Trn_ThemeName = "Brand Theme";
                  A281Trn_ThemeFontFamily = AV20Modern_Trn_Theme.gxTpr_Trn_themefontfamily;
                  A405Trn_ThemeFontSize = AV20Modern_Trn_Theme.gxTpr_Trn_themefontsize;
                  /* Optimized DELETE. */
                  /* Using cursor P00D97 */
                  pr_default.execute(5, new Object[] {A273Trn_ThemeId});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                  /* End optimized DELETE. */
                  AV33GXV1 = 1;
                  while ( AV33GXV1 <= AV13ColorNameCollection.Count )
                  {
                     AV18ColorSDTName = ((string)AV13ColorNameCollection.Item(AV33GXV1));
                     AV19ColorName = StringUtil.StringReplace( AV18ColorSDTName, context.GetMessage( "Value", ""), "");
                     AV22Index = (short)(AV13ColorNameCollection.IndexOf(AV18ColorSDTName));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeColor

                     */
                     A276ColorName = AV19ColorName;
                     A277ColorCode = ((string)AV14ColorCodeCollection.Item(AV22Index));
                     A275ColorId = Guid.NewGuid( );
                     /* Using cursor P00D98 */
                     pr_default.execute(6, new Object[] {A273Trn_ThemeId, A275ColorId, A276ColorName, A277ColorCode});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                     AV33GXV1 = (int)(AV33GXV1+1);
                  }
                  /* Optimized DELETE. */
                  /* Using cursor P00D99 */
                  pr_default.execute(7, new Object[] {A273Trn_ThemeId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                  /* End optimized DELETE. */
                  AV35GXV2 = 1;
                  while ( AV35GXV2 <= AV15CtaColorNameCollection.Count )
                  {
                     AV19ColorName = ((string)AV15CtaColorNameCollection.Item(AV35GXV2));
                     AV22Index = (short)(AV15CtaColorNameCollection.IndexOf(AV19ColorName));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeCtaColor

                     */
                     A539CtaColorName = AV19ColorName;
                     A540CtaColorCode = ((string)AV16CtaColorCodeCollection.Item(AV22Index));
                     A538CtaColorId = Guid.NewGuid( );
                     /* Using cursor P00D910 */
                     pr_default.execute(8, new Object[] {A273Trn_ThemeId, A538CtaColorId, A539CtaColorName, A540CtaColorCode});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                     AV35GXV2 = (int)(AV35GXV2+1);
                  }
                  /* Optimized DELETE. */
                  /* Using cursor P00D911 */
                  pr_default.execute(9, new Object[] {A273Trn_ThemeId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                  /* End optimized DELETE. */
                  AV37GXV3 = 1;
                  while ( AV37GXV3 <= AV20Modern_Trn_Theme.gxTpr_Icon.Count )
                  {
                     AV21Icon = ((SdtTrn_Theme_Icon)AV20Modern_Trn_Theme.gxTpr_Icon.Item(AV37GXV3));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeIcon

                     */
                     A283IconName = AV21Icon.gxTpr_Iconname;
                     A284IconSVG = AV21Icon.gxTpr_Iconsvg;
                     A443IconCategory = AV21Icon.gxTpr_Iconcategory;
                     A282IconId = Guid.NewGuid( );
                     /* Using cursor P00D912 */
                     pr_default.execute(10, new Object[] {A273Trn_ThemeId, A282IconId, A283IconName, A284IconSVG, A443IconCategory});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                     AV37GXV3 = (int)(AV37GXV3+1);
                  }
                  /* Using cursor P00D913 */
                  pr_default.execute(11, new Object[] {A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, A273Trn_ThemeId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               if ( AV31GXLvl19 == 0 )
               {
                  /* Execute user subroutine: 'CREATENEWTHEME' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     pr_default.close(3);
                     pr_default.close(2);
                     cleanup();
                     if (true) return;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.close(3);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWTHEME' Routine */
         returnInSub = false;
         /* Using cursor P00D914 */
         pr_default.execute(12, new Object[] {AV10LocationId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            GXTD911 = 0;
            A29LocationId = P00D914_A29LocationId[0];
            A577LocationThemeId = P00D914_A577LocationThemeId[0];
            n577LocationThemeId = P00D914_n577LocationThemeId[0];
            A11OrganisationId = P00D914_A11OrganisationId[0];
            AV23BC_Trn_Theme.gxTpr_Trn_themeid = AV10LocationId;
            AV23BC_Trn_Theme.gxTpr_Trn_themename = "Brand Theme";
            AV23BC_Trn_Theme.gxTpr_Trn_themefontfamily = AV20Modern_Trn_Theme.gxTpr_Trn_themefontfamily;
            AV23BC_Trn_Theme.gxTpr_Trn_themefontsize = AV20Modern_Trn_Theme.gxTpr_Trn_themefontsize;
            AV23BC_Trn_Theme.gxTpr_Color.Clear();
            AV39GXV4 = 1;
            while ( AV39GXV4 <= AV15CtaColorNameCollection.Count )
            {
               AV19ColorName = ((string)AV15CtaColorNameCollection.Item(AV39GXV4));
               AV26CtaColor = new SdtTrn_Theme_CtaColor(context);
               AV26CtaColor.gxTpr_Ctacolorid = Guid.NewGuid( );
               AV26CtaColor.gxTpr_Ctacolorname = AV19ColorName;
               AV26CtaColor.gxTpr_Ctacolorcode = ((string)AV16CtaColorCodeCollection.Item(AV15CtaColorNameCollection.IndexOf(AV19ColorName)));
               AV23BC_Trn_Theme.gxTpr_Ctacolor.Add(AV26CtaColor, 0);
               AV39GXV4 = (int)(AV39GXV4+1);
            }
            AV40GXV5 = 1;
            while ( AV40GXV5 <= AV13ColorNameCollection.Count )
            {
               AV18ColorSDTName = ((string)AV13ColorNameCollection.Item(AV40GXV5));
               AV19ColorName = StringUtil.StringReplace( AV18ColorSDTName, context.GetMessage( "Value", ""), "");
               AV27Color = new SdtTrn_Theme_Color(context);
               AV27Color.gxTpr_Colorid = Guid.NewGuid( );
               AV27Color.gxTpr_Colorname = AV19ColorName;
               AV27Color.gxTpr_Colorcode = ((string)AV14ColorCodeCollection.Item(AV13ColorNameCollection.IndexOf(AV18ColorSDTName)));
               AV23BC_Trn_Theme.gxTpr_Color.Add(AV27Color, 0);
               AV40GXV5 = (int)(AV40GXV5+1);
            }
            AV23BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
            AV23BC_Trn_Theme.Save();
            if ( AV23BC_Trn_Theme.Success() )
            {
               A577LocationThemeId = AV23BC_Trn_Theme.gxTpr_Trn_themeid;
               n577LocationThemeId = false;
               GXTD911 = 1;
            }
            else
            {
               AV42GXV7 = 1;
               AV41GXV6 = AV23BC_Trn_Theme.GetMessages();
               while ( AV42GXV7 <= AV41GXV6.Count )
               {
                  AV24ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV41GXV6.Item(AV42GXV7));
                  GX_msglist.addItem(AV24ErrorMessage.gxTpr_Description);
                  AV42GXV7 = (int)(AV42GXV7+1);
               }
            }
            /* Using cursor P00D915 */
            pr_default.execute(13, new Object[] {n577LocationThemeId, A577LocationThemeId, A29LocationId, A11OrganisationId});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
            if ( GXTD911 == 1 )
            {
               context.CommitDataStores("prc_updatelocationthemesetting",pr_default);
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updatelocationthemesetting",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected override void CloseCursors( )
      {
         pr_default.close(2);
      }

      public override void initialize( )
      {
         P00D92_A274Trn_ThemeName = new string[] {""} ;
         P00D92_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A274Trn_ThemeName = "";
         A273Trn_ThemeId = Guid.Empty;
         AV23BC_Trn_Theme = new SdtTrn_Theme(context);
         AV20Modern_Trn_Theme = new SdtTrn_Theme(context);
         AV12Dictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV13ColorNameCollection = new GxSimpleCollection<string>();
         AV14ColorCodeCollection = new GxSimpleCollection<string>();
         AV17CtaDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV15CtaColorNameCollection = new GxSimpleCollection<string>();
         AV16CtaColorCodeCollection = new GxSimpleCollection<string>();
         P00D93_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00D93_n584ActiveAppVersionId = new bool[] {false} ;
         P00D93_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00D93_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00D93_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         P00D93_n577LocationThemeId = new bool[] {false} ;
         P00D93_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D93_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A577LocationThemeId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00D94_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00D95_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00D96_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00D96_A274Trn_ThemeName = new string[] {""} ;
         P00D96_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00D96_A405Trn_ThemeFontSize = new short[1] ;
         A281Trn_ThemeFontFamily = "";
         AV18ColorSDTName = "";
         AV19ColorName = "";
         A276ColorName = "";
         A277ColorCode = "";
         A275ColorId = Guid.Empty;
         Gx_emsg = "";
         A539CtaColorName = "";
         A540CtaColorCode = "";
         A538CtaColorId = Guid.Empty;
         AV21Icon = new SdtTrn_Theme_Icon(context);
         A283IconName = "";
         A284IconSVG = "";
         A443IconCategory = "";
         A282IconId = Guid.Empty;
         P00D914_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D914_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         P00D914_n577LocationThemeId = new bool[] {false} ;
         P00D914_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV26CtaColor = new SdtTrn_Theme_CtaColor(context);
         AV27Color = new SdtTrn_Theme_Color(context);
         AV41GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV24ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationthemesetting__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationthemesetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationthemesetting__default(),
            new Object[][] {
                new Object[] {
               P00D92_A274Trn_ThemeName, P00D92_A273Trn_ThemeId
               }
               , new Object[] {
               P00D93_A584ActiveAppVersionId, P00D93_n584ActiveAppVersionId, P00D93_A598PublishedActiveAppVersionId, P00D93_n598PublishedActiveAppVersionId, P00D93_A577LocationThemeId, P00D93_n577LocationThemeId, P00D93_A29LocationId, P00D93_A11OrganisationId
               }
               , new Object[] {
               P00D94_A273Trn_ThemeId
               }
               , new Object[] {
               P00D95_A273Trn_ThemeId
               }
               , new Object[] {
               P00D96_A273Trn_ThemeId, P00D96_A274Trn_ThemeName, P00D96_A281Trn_ThemeFontFamily, P00D96_A405Trn_ThemeFontSize
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00D914_A29LocationId, P00D914_A577LocationThemeId, P00D914_n577LocationThemeId, P00D914_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31GXLvl19 ;
      private short A405Trn_ThemeFontSize ;
      private short AV22Index ;
      private short GXTD911 ;
      private int AV33GXV1 ;
      private int GX_INS53 ;
      private int AV35GXV2 ;
      private int GX_INS97 ;
      private int AV37GXV3 ;
      private int GX_INS82 ;
      private int AV39GXV4 ;
      private int AV40GXV5 ;
      private int AV42GXV7 ;
      private string Gx_emsg ;
      private bool AV11LocationHasOwnBrand ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n577LocationThemeId ;
      private bool returnInSub ;
      private string AV9LocationBrandTheme ;
      private string AV8LocationCtaTheme ;
      private string A284IconSVG ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string AV18ColorSDTName ;
      private string AV19ColorName ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private string A539CtaColorName ;
      private string A540CtaColorCode ;
      private string A283IconName ;
      private string A443IconCategory ;
      private Guid AV10LocationId ;
      private Guid A273Trn_ThemeId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A577LocationThemeId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A275ColorId ;
      private Guid A538CtaColorId ;
      private Guid A282IconId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_LocationId ;
      private string aP1_LocationBrandTheme ;
      private string aP2_LocationCtaTheme ;
      private bool aP3_LocationHasOwnBrand ;
      private IDataStoreProvider pr_default ;
      private string[] P00D92_A274Trn_ThemeName ;
      private Guid[] P00D92_A273Trn_ThemeId ;
      private SdtTrn_Theme AV23BC_Trn_Theme ;
      private SdtTrn_Theme AV20Modern_Trn_Theme ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV12Dictionary ;
      private GxSimpleCollection<string> AV13ColorNameCollection ;
      private GxSimpleCollection<string> AV14ColorCodeCollection ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV17CtaDictionary ;
      private GxSimpleCollection<string> AV15CtaColorNameCollection ;
      private GxSimpleCollection<string> AV16CtaColorCodeCollection ;
      private Guid[] P00D93_A584ActiveAppVersionId ;
      private bool[] P00D93_n584ActiveAppVersionId ;
      private Guid[] P00D93_A598PublishedActiveAppVersionId ;
      private bool[] P00D93_n598PublishedActiveAppVersionId ;
      private Guid[] P00D93_A577LocationThemeId ;
      private bool[] P00D93_n577LocationThemeId ;
      private Guid[] P00D93_A29LocationId ;
      private Guid[] P00D93_A11OrganisationId ;
      private Guid[] P00D94_A273Trn_ThemeId ;
      private Guid[] P00D95_A273Trn_ThemeId ;
      private Guid[] P00D96_A273Trn_ThemeId ;
      private string[] P00D96_A274Trn_ThemeName ;
      private string[] P00D96_A281Trn_ThemeFontFamily ;
      private short[] P00D96_A405Trn_ThemeFontSize ;
      private SdtTrn_Theme_Icon AV21Icon ;
      private Guid[] P00D914_A29LocationId ;
      private Guid[] P00D914_A577LocationThemeId ;
      private bool[] P00D914_n577LocationThemeId ;
      private Guid[] P00D914_A11OrganisationId ;
      private SdtTrn_Theme_CtaColor AV26CtaColor ;
      private SdtTrn_Theme_Color AV27Color ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV41GXV6 ;
      private GeneXus.Utils.SdtMessages_Message AV24ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatelocationthemesetting__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatelocationthemesetting__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatelocationthemesetting__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new UpdateCursor(def[13])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00D92;
       prmP00D92 = new Object[] {
       };
       Object[] prmP00D93;
       prmP00D93 = new Object[] {
       new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D94;
       prmP00D94 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00D95;
       prmP00D95 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00D96;
       prmP00D96 = new Object[] {
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00D97;
       prmP00D97 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D98;
       prmP00D98 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00D99;
       prmP00D99 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D910;
       prmP00D910 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00D911;
       prmP00D911 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D912;
       prmP00D912 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0)
       };
       Object[] prmP00D913;
       prmP00D913 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D914;
       prmP00D914 = new Object[] {
       new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00D915;
       prmP00D915 = new Object[] {
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00D92", "SELECT Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeName = ( 'Modern') ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D92,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00D93", "SELECT ActiveAppVersionId, PublishedActiveAppVersionId, LocationThemeId, LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D93,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00D94", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D94,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00D95", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D95,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00D96", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Trn_ThemeId = :LocationThemeId ORDER BY Trn_ThemeId  FOR UPDATE OF Trn_Theme",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D96,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00D97", "DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D97)
          ,new CursorDef("P00D98", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00D98)
          ,new CursorDef("P00D99", "DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D99)
          ,new CursorDef("P00D910", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00D910)
          ,new CursorDef("P00D911", "DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D911)
          ,new CursorDef("P00D912", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconName, IconSVG, IconCategory, IconTags) VALUES(:Trn_ThemeId, :IconId, :IconName, :IconSVG, :IconCategory, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00D912)
          ,new CursorDef("P00D913", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D913)
          ,new CursorDef("P00D914", "SELECT LocationId, LocationThemeId, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D914,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00D915", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationThemeId=:LocationThemeId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D915)
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((bool[]) buf[3])[0] = rslt.wasNull(2);
             ((Guid[]) buf[4])[0] = rslt.getGuid(3);
             ((bool[]) buf[5])[0] = rslt.wasNull(3);
             ((Guid[]) buf[6])[0] = rslt.getGuid(4);
             ((Guid[]) buf[7])[0] = rslt.getGuid(5);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
