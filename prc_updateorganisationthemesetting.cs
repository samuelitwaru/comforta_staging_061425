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
   public class prc_updateorganisationthemesetting : GXProcedure
   {
      public prc_updateorganisationthemesetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateorganisationthemesetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_OrganisationId ,
                           ref string aP1_OrganisationBrandTheme ,
                           ref string aP2_OrganisationCtaTheme ,
                           ref bool aP3_OrganisationHasOwnBrand )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationBrandTheme = aP1_OrganisationBrandTheme;
         this.AV10OrganisationCtaTheme = aP2_OrganisationCtaTheme;
         this.AV29OrganisationHasOwnBrand = aP3_OrganisationHasOwnBrand;
         initialize();
         ExecuteImpl();
         aP0_OrganisationId=this.AV8OrganisationId;
         aP1_OrganisationBrandTheme=this.AV9OrganisationBrandTheme;
         aP2_OrganisationCtaTheme=this.AV10OrganisationCtaTheme;
         aP3_OrganisationHasOwnBrand=this.AV29OrganisationHasOwnBrand;
      }

      public bool executeUdp( ref Guid aP0_OrganisationId ,
                              ref string aP1_OrganisationBrandTheme ,
                              ref string aP2_OrganisationCtaTheme )
      {
         execute(ref aP0_OrganisationId, ref aP1_OrganisationBrandTheme, ref aP2_OrganisationCtaTheme, ref aP3_OrganisationHasOwnBrand);
         return AV29OrganisationHasOwnBrand ;
      }

      public void executeSubmit( ref Guid aP0_OrganisationId ,
                                 ref string aP1_OrganisationBrandTheme ,
                                 ref string aP2_OrganisationCtaTheme ,
                                 ref bool aP3_OrganisationHasOwnBrand )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV9OrganisationBrandTheme = aP1_OrganisationBrandTheme;
         this.AV10OrganisationCtaTheme = aP2_OrganisationCtaTheme;
         this.AV29OrganisationHasOwnBrand = aP3_OrganisationHasOwnBrand;
         SubmitImpl();
         aP0_OrganisationId=this.AV8OrganisationId;
         aP1_OrganisationBrandTheme=this.AV9OrganisationBrandTheme;
         aP2_OrganisationCtaTheme=this.AV10OrganisationCtaTheme;
         aP3_OrganisationHasOwnBrand=this.AV29OrganisationHasOwnBrand;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Dictionary.fromjson( AV9OrganisationBrandTheme);
         AV12ColorNameCollection = AV11Dictionary.gxTpr_Keys;
         AV13ColorCodeCollection = AV11Dictionary.gxTpr_Values;
         AV23CtaDictionary.fromjson( AV10OrganisationCtaTheme);
         AV24CtaColorNameCollection = AV23CtaDictionary.gxTpr_Keys;
         AV25CtaColorCodeCollection = AV23CtaDictionary.gxTpr_Values;
         /* Using cursor P00C42 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A274Trn_ThemeName = P00C42_A274Trn_ThemeName[0];
            A273Trn_ThemeId = P00C42_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C42_n273Trn_ThemeId[0];
            AV17BC_Trn_Theme = new SdtTrn_Theme(context);
            AV26Modern_Trn_Theme.Load(A273Trn_ThemeId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV29OrganisationHasOwnBrand )
         {
            /* Using cursor P00C43 */
            pr_default.execute(1, new Object[] {AV8OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P00C43_A11OrganisationId[0];
               A273Trn_ThemeId = P00C43_A273Trn_ThemeId[0];
               n273Trn_ThemeId = P00C43_n273Trn_ThemeId[0];
               A100OrganisationSettingid = P00C43_A100OrganisationSettingid[0];
               AV30OrganisationThemeId = A273Trn_ThemeId;
               new prc_logtoserver(context ).execute(  "    "+AV30OrganisationThemeId.ToString()) ;
               AV33GXLvl22 = 0;
               /* Using cursor P00C44 */
               pr_default.execute(2, new Object[] {AV30OrganisationThemeId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A273Trn_ThemeId = P00C44_A273Trn_ThemeId[0];
                  n273Trn_ThemeId = P00C44_n273Trn_ThemeId[0];
                  A274Trn_ThemeName = P00C44_A274Trn_ThemeName[0];
                  A281Trn_ThemeFontFamily = P00C44_A281Trn_ThemeFontFamily[0];
                  A405Trn_ThemeFontSize = P00C44_A405Trn_ThemeFontSize[0];
                  AV33GXLvl22 = 1;
                  A274Trn_ThemeName = "Brand Theme";
                  A281Trn_ThemeFontFamily = AV26Modern_Trn_Theme.gxTpr_Trn_themefontfamily;
                  A405Trn_ThemeFontSize = AV26Modern_Trn_Theme.gxTpr_Trn_themefontsize;
                  /* Optimized DELETE. */
                  /* Using cursor P00C45 */
                  pr_default.execute(3, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                  /* End optimized DELETE. */
                  AV35GXV1 = 1;
                  while ( AV35GXV1 <= AV12ColorNameCollection.Count )
                  {
                     AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV35GXV1));
                     AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
                     AV15Index = (short)(AV12ColorNameCollection.IndexOf(AV14ColorSDTName));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeColor

                     */
                     A276ColorName = AV19ColorName;
                     A277ColorCode = ((string)AV13ColorCodeCollection.Item(AV15Index));
                     A275ColorId = Guid.NewGuid( );
                     /* Using cursor P00C46 */
                     pr_default.execute(4, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId, A276ColorName, A277ColorCode});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(4) == 1) )
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
                     AV35GXV1 = (int)(AV35GXV1+1);
                  }
                  /* Optimized DELETE. */
                  /* Using cursor P00C47 */
                  pr_default.execute(5, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                  /* End optimized DELETE. */
                  AV37GXV2 = 1;
                  while ( AV37GXV2 <= AV24CtaColorNameCollection.Count )
                  {
                     AV19ColorName = ((string)AV24CtaColorNameCollection.Item(AV37GXV2));
                     AV15Index = (short)(AV24CtaColorNameCollection.IndexOf(AV19ColorName));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeCtaColor

                     */
                     A539CtaColorName = AV19ColorName;
                     A540CtaColorCode = ((string)AV25CtaColorCodeCollection.Item(AV15Index));
                     A538CtaColorId = Guid.NewGuid( );
                     /* Using cursor P00C48 */
                     pr_default.execute(6, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId, A539CtaColorName, A540CtaColorCode});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
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
                     AV37GXV2 = (int)(AV37GXV2+1);
                  }
                  /* Optimized DELETE. */
                  /* Using cursor P00C49 */
                  pr_default.execute(7, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                  /* End optimized DELETE. */
                  AV39GXV3 = 1;
                  while ( AV39GXV3 <= AV26Modern_Trn_Theme.gxTpr_Icon.Count )
                  {
                     AV28Icon = ((SdtTrn_Theme_Icon)AV26Modern_Trn_Theme.gxTpr_Icon.Item(AV39GXV3));
                     /*
                        INSERT RECORD ON TABLE Trn_ThemeIcon

                     */
                     A283IconName = AV28Icon.gxTpr_Iconname;
                     A284IconSVG = AV28Icon.gxTpr_Iconsvg;
                     A443IconCategory = AV28Icon.gxTpr_Iconcategory;
                     A282IconId = Guid.NewGuid( );
                     /* Using cursor P00C410 */
                     pr_default.execute(8, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId, A283IconName, A284IconSVG, A443IconCategory});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
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
                     AV39GXV3 = (int)(AV39GXV3+1);
                  }
                  /* Using cursor P00C411 */
                  pr_default.execute(9, new Object[] {A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, n273Trn_ThemeId, A273Trn_ThemeId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               if ( AV33GXLvl22 == 0 )
               {
                  /* Execute user subroutine: 'CREATENEWTHEME' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     cleanup();
                     if (true) return;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWTHEME' Routine */
         returnInSub = false;
         /* Using cursor P00C412 */
         pr_default.execute(10, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(10) != 101) )
         {
            GXTC411 = 0;
            A11OrganisationId = P00C412_A11OrganisationId[0];
            A273Trn_ThemeId = P00C412_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00C412_n273Trn_ThemeId[0];
            A100OrganisationSettingid = P00C412_A100OrganisationSettingid[0];
            AV17BC_Trn_Theme.gxTpr_Trn_themeid = AV8OrganisationId;
            AV17BC_Trn_Theme.gxTpr_Trn_themename = "Brand Theme";
            AV17BC_Trn_Theme.gxTpr_Trn_themefontfamily = AV26Modern_Trn_Theme.gxTpr_Trn_themefontfamily;
            AV17BC_Trn_Theme.gxTpr_Trn_themefontsize = AV26Modern_Trn_Theme.gxTpr_Trn_themefontsize;
            AV17BC_Trn_Theme.gxTpr_Color.Clear();
            AV41GXV4 = 1;
            while ( AV41GXV4 <= AV24CtaColorNameCollection.Count )
            {
               AV19ColorName = ((string)AV24CtaColorNameCollection.Item(AV41GXV4));
               AV27CtaColor = new SdtTrn_Theme_CtaColor(context);
               AV27CtaColor.gxTpr_Ctacolorid = Guid.NewGuid( );
               AV27CtaColor.gxTpr_Ctacolorname = AV19ColorName;
               AV27CtaColor.gxTpr_Ctacolorcode = ((string)AV25CtaColorCodeCollection.Item(AV24CtaColorNameCollection.IndexOf(AV19ColorName)));
               AV17BC_Trn_Theme.gxTpr_Ctacolor.Add(AV27CtaColor, 0);
               AV41GXV4 = (int)(AV41GXV4+1);
            }
            AV42GXV5 = 1;
            while ( AV42GXV5 <= AV12ColorNameCollection.Count )
            {
               AV14ColorSDTName = ((string)AV12ColorNameCollection.Item(AV42GXV5));
               AV19ColorName = StringUtil.StringReplace( AV14ColorSDTName, context.GetMessage( "Value", ""), "");
               AV20Color = new SdtTrn_Theme_Color(context);
               AV20Color.gxTpr_Colorid = Guid.NewGuid( );
               AV20Color.gxTpr_Colorname = AV19ColorName;
               AV20Color.gxTpr_Colorcode = ((string)AV13ColorCodeCollection.Item(AV12ColorNameCollection.IndexOf(AV14ColorSDTName)));
               AV17BC_Trn_Theme.gxTpr_Color.Add(AV20Color, 0);
               AV42GXV5 = (int)(AV42GXV5+1);
            }
            AV17BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
            AV17BC_Trn_Theme.Save();
            if ( AV17BC_Trn_Theme.Success() )
            {
               A273Trn_ThemeId = AV17BC_Trn_Theme.gxTpr_Trn_themeid;
               n273Trn_ThemeId = false;
               GXTC411 = 1;
            }
            else
            {
               AV44GXV7 = 1;
               AV43GXV6 = AV17BC_Trn_Theme.GetMessages();
               while ( AV44GXV7 <= AV43GXV6.Count )
               {
                  AV22ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV43GXV6.Item(AV44GXV7));
                  GX_msglist.addItem(AV22ErrorMessage.gxTpr_Description);
                  AV44GXV7 = (int)(AV44GXV7+1);
               }
            }
            /* Using cursor P00C413 */
            pr_default.execute(11, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A100OrganisationSettingid, A11OrganisationId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
            if ( GXTC411 == 1 )
            {
               context.CommitDataStores("prc_updateorganisationthemesetting",pr_default);
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateorganisationthemesetting",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Dictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV12ColorNameCollection = new GxSimpleCollection<string>();
         AV13ColorCodeCollection = new GxSimpleCollection<string>();
         AV23CtaDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV24CtaColorNameCollection = new GxSimpleCollection<string>();
         AV25CtaColorCodeCollection = new GxSimpleCollection<string>();
         P00C42_A274Trn_ThemeName = new string[] {""} ;
         P00C42_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C42_n273Trn_ThemeId = new bool[] {false} ;
         A274Trn_ThemeName = "";
         A273Trn_ThemeId = Guid.Empty;
         AV17BC_Trn_Theme = new SdtTrn_Theme(context);
         AV26Modern_Trn_Theme = new SdtTrn_Theme(context);
         P00C43_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C43_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C43_n273Trn_ThemeId = new bool[] {false} ;
         P00C43_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         AV30OrganisationThemeId = Guid.Empty;
         P00C44_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C44_n273Trn_ThemeId = new bool[] {false} ;
         P00C44_A274Trn_ThemeName = new string[] {""} ;
         P00C44_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00C44_A405Trn_ThemeFontSize = new short[1] ;
         A281Trn_ThemeFontFamily = "";
         AV14ColorSDTName = "";
         AV19ColorName = "";
         A276ColorName = "";
         A277ColorCode = "";
         A275ColorId = Guid.Empty;
         Gx_emsg = "";
         A539CtaColorName = "";
         A540CtaColorCode = "";
         A538CtaColorId = Guid.Empty;
         AV28Icon = new SdtTrn_Theme_Icon(context);
         A283IconName = "";
         A284IconSVG = "";
         A443IconCategory = "";
         A282IconId = Guid.Empty;
         P00C412_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C412_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C412_n273Trn_ThemeId = new bool[] {false} ;
         P00C412_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         AV27CtaColor = new SdtTrn_Theme_CtaColor(context);
         AV20Color = new SdtTrn_Theme_Color(context);
         AV43GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateorganisationthemesetting__default(),
            new Object[][] {
                new Object[] {
               P00C42_A274Trn_ThemeName, P00C42_A273Trn_ThemeId
               }
               , new Object[] {
               P00C43_A11OrganisationId, P00C43_A273Trn_ThemeId, P00C43_n273Trn_ThemeId, P00C43_A100OrganisationSettingid
               }
               , new Object[] {
               P00C44_A273Trn_ThemeId, P00C44_A274Trn_ThemeName, P00C44_A281Trn_ThemeFontFamily, P00C44_A405Trn_ThemeFontSize
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
               P00C412_A11OrganisationId, P00C412_A273Trn_ThemeId, P00C412_n273Trn_ThemeId, P00C412_A100OrganisationSettingid
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV33GXLvl22 ;
      private short A405Trn_ThemeFontSize ;
      private short AV15Index ;
      private short GXTC411 ;
      private int AV35GXV1 ;
      private int GX_INS53 ;
      private int AV37GXV2 ;
      private int GX_INS97 ;
      private int AV39GXV3 ;
      private int GX_INS82 ;
      private int AV41GXV4 ;
      private int AV42GXV5 ;
      private int AV44GXV7 ;
      private string Gx_emsg ;
      private bool AV29OrganisationHasOwnBrand ;
      private bool n273Trn_ThemeId ;
      private bool returnInSub ;
      private string AV9OrganisationBrandTheme ;
      private string AV10OrganisationCtaTheme ;
      private string A284IconSVG ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string AV14ColorSDTName ;
      private string AV19ColorName ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private string A539CtaColorName ;
      private string A540CtaColorCode ;
      private string A283IconName ;
      private string A443IconCategory ;
      private Guid AV8OrganisationId ;
      private Guid A273Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private Guid AV30OrganisationThemeId ;
      private Guid A275ColorId ;
      private Guid A538CtaColorId ;
      private Guid A282IconId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_OrganisationId ;
      private string aP1_OrganisationBrandTheme ;
      private string aP2_OrganisationCtaTheme ;
      private bool aP3_OrganisationHasOwnBrand ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV11Dictionary ;
      private GxSimpleCollection<string> AV12ColorNameCollection ;
      private GxSimpleCollection<string> AV13ColorCodeCollection ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV23CtaDictionary ;
      private GxSimpleCollection<string> AV24CtaColorNameCollection ;
      private GxSimpleCollection<string> AV25CtaColorCodeCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00C42_A274Trn_ThemeName ;
      private Guid[] P00C42_A273Trn_ThemeId ;
      private bool[] P00C42_n273Trn_ThemeId ;
      private SdtTrn_Theme AV17BC_Trn_Theme ;
      private SdtTrn_Theme AV26Modern_Trn_Theme ;
      private Guid[] P00C43_A11OrganisationId ;
      private Guid[] P00C43_A273Trn_ThemeId ;
      private bool[] P00C43_n273Trn_ThemeId ;
      private Guid[] P00C43_A100OrganisationSettingid ;
      private Guid[] P00C44_A273Trn_ThemeId ;
      private bool[] P00C44_n273Trn_ThemeId ;
      private string[] P00C44_A274Trn_ThemeName ;
      private string[] P00C44_A281Trn_ThemeFontFamily ;
      private short[] P00C44_A405Trn_ThemeFontSize ;
      private SdtTrn_Theme_Icon AV28Icon ;
      private Guid[] P00C412_A11OrganisationId ;
      private Guid[] P00C412_A273Trn_ThemeId ;
      private bool[] P00C412_n273Trn_ThemeId ;
      private Guid[] P00C412_A100OrganisationSettingid ;
      private SdtTrn_Theme_CtaColor AV27CtaColor ;
      private SdtTrn_Theme_Color AV20Color ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV43GXV6 ;
      private GeneXus.Utils.SdtMessages_Message AV22ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateorganisationthemesetting__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateorganisationthemesetting__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateorganisationthemesetting__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new UpdateCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new UpdateCursor(def[11])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00C42;
       prmP00C42 = new Object[] {
       };
       Object[] prmP00C43;
       prmP00C43 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C44;
       prmP00C44 = new Object[] {
       new ParDef("AV30OrganisationThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C45;
       prmP00C45 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00C46;
       prmP00C46 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00C47;
       prmP00C47 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00C48;
       prmP00C48 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmP00C49;
       prmP00C49 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00C410;
       prmP00C410 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0)
       };
       Object[] prmP00C411;
       prmP00C411 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00C412;
       prmP00C412 = new Object[] {
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C413;
       prmP00C413 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00C42", "SELECT Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeName = ( 'Modern') ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C42,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C43", "SELECT OrganisationId, Trn_ThemeId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C43,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C44", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Trn_ThemeId = :AV30OrganisationThemeId ORDER BY Trn_ThemeId  FOR UPDATE OF Trn_Theme",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C44,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00C45", "DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C45)
          ,new CursorDef("P00C46", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00C46)
          ,new CursorDef("P00C47", "DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C47)
          ,new CursorDef("P00C48", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00C48)
          ,new CursorDef("P00C49", "DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C49)
          ,new CursorDef("P00C410", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconName, IconSVG, IconCategory) VALUES(:Trn_ThemeId, :IconId, :IconName, :IconSVG, :IconCategory);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00C410)
          ,new CursorDef("P00C411", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C411)
          ,new CursorDef("P00C412", "SELECT OrganisationId, Trn_ThemeId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV8OrganisationId ORDER BY OrganisationId  FOR UPDATE OF Trn_OrganisationSetting",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C412,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C413", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationSetting SET Trn_ThemeId=:Trn_ThemeId  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C413)
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
