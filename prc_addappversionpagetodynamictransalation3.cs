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
   public class prc_addappversionpagetodynamictransalation3 : GXProcedure
   {
      public prc_addappversionpagetodynamictransalation3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addappversionpagetodynamictransalation3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDT_InfoPageTranslation> aP0_SDT_InfoPageTranslationCollection ,
                           ref string aP1_LanguageFrom ,
                           ref string aP2_languageTo )
      {
         this.AV35SDT_InfoPageTranslationCollection = aP0_SDT_InfoPageTranslationCollection;
         this.AV57LanguageFrom = aP1_LanguageFrom;
         this.AV58languageTo = aP2_languageTo;
         initialize();
         ExecuteImpl();
         aP1_LanguageFrom=this.AV57LanguageFrom;
         aP2_languageTo=this.AV58languageTo;
      }

      public string executeUdp( GXBaseCollection<SdtSDT_InfoPageTranslation> aP0_SDT_InfoPageTranslationCollection ,
                                ref string aP1_LanguageFrom )
      {
         execute(aP0_SDT_InfoPageTranslationCollection, ref aP1_LanguageFrom, ref aP2_languageTo);
         return AV58languageTo ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_InfoPageTranslation> aP0_SDT_InfoPageTranslationCollection ,
                                 ref string aP1_LanguageFrom ,
                                 ref string aP2_languageTo )
      {
         this.AV35SDT_InfoPageTranslationCollection = aP0_SDT_InfoPageTranslationCollection;
         this.AV57LanguageFrom = aP1_LanguageFrom;
         this.AV58languageTo = aP2_languageTo;
         SubmitImpl();
         aP1_LanguageFrom=this.AV57LanguageFrom;
         aP2_languageTo=this.AV58languageTo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV35SDT_InfoPageTranslationCollection.Count )
         {
            AV34SDT_InfoPageTranslation = ((SdtSDT_InfoPageTranslation)AV35SDT_InfoPageTranslationCollection.Item(AV63GXV1));
            AV21SDT_InfoContent = new SdtSDT_InfoContent(context);
            AV21SDT_InfoContent.FromJSonString(AV34SDT_InfoPageTranslation.gxTpr_Pagestructure, null);
            AV64GXLvl7 = 0;
            /* Using cursor P00GV2 */
            pr_default.execute(0, new Object[] {AV34SDT_InfoPageTranslation.gxTpr_Pageid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A580DynamicTranslationPrimaryKey = P00GV2_A580DynamicTranslationPrimaryKey[0];
               A582DynamicTranslationEnglish = P00GV2_A582DynamicTranslationEnglish[0];
               A583DynamicTranslationDutch = P00GV2_A583DynamicTranslationDutch[0];
               A578DynamicTranslationId = P00GV2_A578DynamicTranslationId[0];
               AV64GXLvl7 = 1;
               AV38SDT_InfoContentEnglish = new SdtSDT_InfoContent(context);
               AV39SDT_InfoContentDutch = new SdtSDT_InfoContent(context);
               AV54SDT_InfoContentItemFinal = new SdtSDT_InfoContent(context);
               AV38SDT_InfoContentEnglish.FromJSonString(A582DynamicTranslationEnglish, null);
               AV39SDT_InfoContentDutch.FromJSonString(A583DynamicTranslationDutch, null);
               if ( StringUtil.StrCmp(AV57LanguageFrom, "en") == 0 )
               {
                  A582DynamicTranslationEnglish = AV34SDT_InfoPageTranslation.gxTpr_Pagestructure;
                  AV26SDT_InfoContentOld = AV38SDT_InfoContentEnglish;
               }
               else if ( StringUtil.StrCmp(AV57LanguageFrom, "nl") == 0 )
               {
                  A583DynamicTranslationDutch = AV34SDT_InfoPageTranslation.gxTpr_Pagestructure;
                  AV26SDT_InfoContentOld = AV39SDT_InfoContentDutch;
               }
               if ( StringUtil.StrCmp(AV58languageTo, "en") == 0 )
               {
                  AV60SDT_InfoContentTranslate = AV38SDT_InfoContentEnglish;
                  /* Execute user subroutine: 'TRANSLATEEXISTINGPAGEUPDATE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A582DynamicTranslationEnglish = AV54SDT_InfoContentItemFinal.ToJSonString(false, true);
               }
               else if ( StringUtil.StrCmp(AV58languageTo, "nl") == 0 )
               {
                  AV60SDT_InfoContentTranslate = AV39SDT_InfoContentDutch;
                  /* Execute user subroutine: 'TRANSLATEEXISTINGPAGEUPDATE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A583DynamicTranslationDutch = AV54SDT_InfoContentItemFinal.ToJSonString(false, true);
               }
               /* Using cursor P00GV3 */
               pr_default.execute(1, new Object[] {A582DynamicTranslationEnglish, A583DynamicTranslationDutch, A578DynamicTranslationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV64GXLvl7 == 0 )
            {
               if ( StringUtil.StrCmp(AV57LanguageFrom, "en") == 0 )
               {
                  AV19DynamicTranslationEnglish = AV34SDT_InfoPageTranslation.gxTpr_Pagestructure;
               }
               else if ( StringUtil.StrCmp(AV57LanguageFrom, "nl") == 0 )
               {
                  AV20DynamicTranslationDutch = AV34SDT_InfoPageTranslation.gxTpr_Pagestructure;
               }
               /* Execute user subroutine: 'TRANSLATENEWPAGE' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( StringUtil.StrCmp(AV58languageTo, "en") == 0 )
               {
                  AV19DynamicTranslationEnglish = AV21SDT_InfoContent.ToJSonString(false, true);
               }
               else if ( StringUtil.StrCmp(AV58languageTo, "nl") == 0 )
               {
                  AV20DynamicTranslationDutch = AV21SDT_InfoContent.ToJSonString(false, true);
               }
               /*
                  INSERT RECORD ON TABLE Trn_DynamicTranslation

               */
               A580DynamicTranslationPrimaryKey = AV34SDT_InfoPageTranslation.gxTpr_Pageid;
               A582DynamicTranslationEnglish = AV19DynamicTranslationEnglish;
               A583DynamicTranslationDutch = AV20DynamicTranslationDutch;
               A581DynamicTranslationAttributeNam = AV34SDT_InfoPageTranslation.gxTpr_Pageattributetype;
               A578DynamicTranslationId = Guid.NewGuid( );
               /* Using cursor P00GV4 */
               pr_default.execute(2, new Object[] {A578DynamicTranslationId, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               if ( (pr_default.getStatus(2) == 1) )
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
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         context.CommitDataStores("prc_addappversionpagetodynamictransalation3",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'TRANSLATENEWPAGE' Routine */
         returnInSub = false;
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV65GXV2));
            if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
            {
               GXt_char1 = "";
               new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
               AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV66GXV3 = 1;
               while ( AV66GXV3 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
               {
                  AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV66GXV3));
                  GXt_char1 = "";
                  new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                  AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                  AV66GXV3 = (int)(AV66GXV3+1);
               }
            }
            else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
            {
               GXt_char1 = "";
               new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
               AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
            }
            else
            {
               new prc_logtofile(context ).execute(  context.GetMessage( "Non translatable", "")) ;
            }
            AV65GXV2 = (int)(AV65GXV2+1);
         }
      }

      protected void S121( )
      {
         /* 'TRANSLATEEXISTINGPAGEUPDATE' Routine */
         returnInSub = false;
         AV67GXV4 = 1;
         while ( AV67GXV4 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
         {
            AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV67GXV4));
            AV40oldInfoIds.Add(AV59SDT_InfoContentItemOld.gxTpr_Infoid, 0);
            AV67GXV4 = (int)(AV67GXV4+1);
         }
         AV68GXV5 = 1;
         while ( AV68GXV5 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV68GXV5));
            AV41newInfoIds.Add(AV22SDT_InfoContentItem.gxTpr_Infoid, 0);
            AV68GXV5 = (int)(AV68GXV5+1);
         }
         AV69GXV6 = 1;
         while ( AV69GXV6 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV69GXV6));
            if ( (AV40oldInfoIds.IndexOf(AV22SDT_InfoContentItem.gxTpr_Infoid)>0) )
            {
               AV70GXV7 = 1;
               while ( AV70GXV7 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
               {
                  AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV70GXV7));
                  if ( StringUtil.StrCmp(AV59SDT_InfoContentItemOld.gxTpr_Infoid, AV22SDT_InfoContentItem.gxTpr_Infoid) == 0 )
                  {
                     AV71GXV8 = 1;
                     while ( AV71GXV8 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
                     {
                        AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV71GXV8));
                        if ( StringUtil.StrCmp(AV59SDT_InfoContentItemOld.gxTpr_Infoid, AV61SDT_InfoContentItemTranslate.gxTpr_Infoid) == 0 )
                        {
                           if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                           {
                              if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infovalue, AV59SDT_InfoContentItemOld.gxTpr_Infovalue) == 0 ) )
                              {
                                 GXt_char1 = "";
                                 new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                                 AV61SDT_InfoContentItemTranslate.gxTpr_Infovalue = GXt_char1;
                              }
                           }
                           else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                           {
                              AV72GXV9 = 1;
                              while ( AV72GXV9 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                              {
                                 AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV72GXV9));
                                 AV46existingtiles.Add(AV28SDT_InfoTileItemOld.gxTpr_Id, 0);
                                 AV72GXV9 = (int)(AV72GXV9+1);
                              }
                              AV73GXV10 = 1;
                              while ( AV73GXV10 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV73GXV10));
                                 AV49newtiles.Add(AV24SDT_InfoTileItem.gxTpr_Id, 0);
                                 AV73GXV10 = (int)(AV73GXV10+1);
                              }
                              AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
                              AV74GXV11 = 1;
                              while ( AV74GXV11 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV74GXV11));
                                 if ( (AV46existingtiles.IndexOf(AV24SDT_InfoTileItem.gxTpr_Id)>0) )
                                 {
                                    AV75GXV12 = 1;
                                    while ( AV75GXV12 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                                    {
                                       AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV75GXV12));
                                       if ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Id, AV24SDT_InfoTileItem.gxTpr_Id) == 0 )
                                       {
                                          AV76GXV13 = 1;
                                          while ( AV76GXV13 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                          {
                                             AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV76GXV13));
                                             if ( StringUtil.StrCmp(AV62SDT_InfoTileItemTranslate.gxTpr_Id, AV28SDT_InfoTileItemOld.gxTpr_Id) == 0 )
                                             {
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Action = AV24SDT_InfoTileItem.gxTpr_Action;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Align = AV24SDT_InfoTileItem.gxTpr_Align;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Bgcolor = AV24SDT_InfoTileItem.gxTpr_Bgcolor;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Bgimageurl = AV24SDT_InfoTileItem.gxTpr_Bgimageurl;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Color = AV24SDT_InfoTileItem.gxTpr_Color;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Icon = AV24SDT_InfoTileItem.gxTpr_Icon;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Name = AV24SDT_InfoTileItem.gxTpr_Name;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Opacity = AV24SDT_InfoTileItem.gxTpr_Opacity;
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Size = AV24SDT_InfoTileItem.gxTpr_Size;
                                                if ( ! ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Text, AV24SDT_InfoTileItem.gxTpr_Text) == 0 ) )
                                                {
                                                   GXt_char1 = "";
                                                   new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                   AV62SDT_InfoTileItemTranslate.gxTpr_Text = GXt_char1;
                                                }
                                             }
                                             AV76GXV13 = (int)(AV76GXV13+1);
                                          }
                                       }
                                       AV75GXV12 = (int)(AV75GXV12+1);
                                    }
                                 }
                                 else
                                 {
                                    GXt_char1 = "";
                                    new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                    AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                    AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Add(AV24SDT_InfoTileItem, 0);
                                 }
                                 AV74GXV11 = (int)(AV74GXV11+1);
                              }
                              AV77GXV14 = 1;
                              while ( AV77GXV14 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                              {
                                 AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV77GXV14));
                                 if ( ! (AV49newtiles.IndexOf(AV28SDT_InfoTileItemOld.gxTpr_Id)>0) )
                                 {
                                    AV78GXV15 = 1;
                                    while ( AV78GXV15 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                    {
                                       AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV78GXV15));
                                       if ( StringUtil.StrCmp(AV62SDT_InfoTileItemTranslate.gxTpr_Id, AV28SDT_InfoTileItemOld.gxTpr_Id) == 0 )
                                       {
                                          AV51indextileToRemove = (short)(AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.IndexOf(AV62SDT_InfoTileItemTranslate));
                                          AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.RemoveItem(AV51indextileToRemove);
                                       }
                                       AV78GXV15 = (int)(AV78GXV15+1);
                                    }
                                 }
                                 AV77GXV14 = (int)(AV77GXV14+1);
                              }
                              AV79GXV16 = 1;
                              while ( AV79GXV16 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV79GXV16));
                                 AV56indextilenew = (short)(AV22SDT_InfoContentItem.gxTpr_Tiles.IndexOf(AV24SDT_InfoTileItem));
                                 AV80GXV17 = 1;
                                 while ( AV80GXV17 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                 {
                                    AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV80GXV17));
                                    if ( StringUtil.StrCmp(AV24SDT_InfoTileItem.gxTpr_Id, AV62SDT_InfoTileItemTranslate.gxTpr_Id) == 0 )
                                    {
                                       AV55SDT_InfoTileItemFinal.gxTpr_Tiles.Add(AV62SDT_InfoTileItemTranslate, AV56indextilenew);
                                    }
                                    AV80GXV17 = (int)(AV80GXV17+1);
                                 }
                                 AV79GXV16 = (int)(AV79GXV16+1);
                              }
                              AV61SDT_InfoContentItemTranslate.gxTpr_Tiles = AV55SDT_InfoTileItemFinal.gxTpr_Tiles;
                           }
                           else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                           {
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Action = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Action;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctaaction = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaaction;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabgcolor;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctabuttontype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttontype;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctacolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctacolor;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctaid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaid;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected;
                              AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctatype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctatype;
                              if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, AV59SDT_InfoContentItemOld.gxTpr_Ctaattributes.gxTpr_Ctalabel) == 0 ) )
                              {
                                 GXt_char1 = "";
                                 new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                                 AV61SDT_InfoContentItemTranslate.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                              }
                           }
                           else
                           {
                              AV61SDT_InfoContentItemTranslate = AV22SDT_InfoContentItem;
                           }
                        }
                        AV71GXV8 = (int)(AV71GXV8+1);
                     }
                  }
                  AV70GXV7 = (int)(AV70GXV7+1);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
               {
                  GXt_char1 = "";
                  new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                  AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
               }
               else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
               {
                  AV81GXV18 = 1;
                  while ( AV81GXV18 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                  {
                     AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV81GXV18));
                     GXt_char1 = "";
                     new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                     AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                     AV81GXV18 = (int)(AV81GXV18+1);
                  }
               }
               else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
               {
                  GXt_char1 = "";
                  new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
               }
               else
               {
               }
               AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Add(AV22SDT_InfoContentItem, 0);
            }
            AV69GXV6 = (int)(AV69GXV6+1);
         }
         AV82GXV19 = 1;
         while ( AV82GXV19 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
         {
            AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV82GXV19));
            if ( ! (AV41newInfoIds.IndexOf(AV59SDT_InfoContentItemOld.gxTpr_Infoid)>0) )
            {
               AV83GXV20 = 1;
               while ( AV83GXV20 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
               {
                  AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV83GXV20));
                  if ( StringUtil.StrCmp(AV61SDT_InfoContentItemTranslate.gxTpr_Infoid, AV59SDT_InfoContentItemOld.gxTpr_Infoid) == 0 )
                  {
                     AV48indexToRemove = (short)(AV60SDT_InfoContentTranslate.gxTpr_Infocontent.IndexOf(AV61SDT_InfoContentItemTranslate));
                     AV60SDT_InfoContentTranslate.gxTpr_Infocontent.RemoveItem(AV48indexToRemove);
                  }
                  AV83GXV20 = (int)(AV83GXV20+1);
               }
            }
            AV82GXV19 = (int)(AV82GXV19+1);
         }
         AV84GXV21 = 1;
         while ( AV84GXV21 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV84GXV21));
            AV52indexrow = (short)(AV21SDT_InfoContent.gxTpr_Infocontent.IndexOf(AV22SDT_InfoContentItem));
            AV85GXV22 = 1;
            while ( AV85GXV22 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
            {
               AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV85GXV22));
               if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infoid, AV61SDT_InfoContentItemTranslate.gxTpr_Infoid) == 0 )
               {
                  AV54SDT_InfoContentItemFinal.gxTpr_Infocontent.Add(AV61SDT_InfoContentItemTranslate, AV52indexrow);
               }
               AV85GXV22 = (int)(AV85GXV22+1);
            }
            AV84GXV21 = (int)(AV84GXV21+1);
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addappversionpagetodynamictransalation3",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV34SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
         AV21SDT_InfoContent = new SdtSDT_InfoContent(context);
         P00GV2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00GV2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00GV2_A583DynamicTranslationDutch = new string[] {""} ;
         P00GV2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         A578DynamicTranslationId = Guid.Empty;
         AV38SDT_InfoContentEnglish = new SdtSDT_InfoContent(context);
         AV39SDT_InfoContentDutch = new SdtSDT_InfoContent(context);
         AV54SDT_InfoContentItemFinal = new SdtSDT_InfoContent(context);
         AV26SDT_InfoContentOld = new SdtSDT_InfoContent(context);
         AV60SDT_InfoContentTranslate = new SdtSDT_InfoContent(context);
         AV19DynamicTranslationEnglish = "";
         AV20DynamicTranslationDutch = "";
         A581DynamicTranslationAttributeNam = "";
         Gx_emsg = "";
         AV22SDT_InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
         AV24SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV59SDT_InfoContentItemOld = new SdtSDT_InfoContent_InfoContentItem(context);
         AV40oldInfoIds = new GxSimpleCollection<string>();
         AV41newInfoIds = new GxSimpleCollection<string>();
         AV61SDT_InfoContentItemTranslate = new SdtSDT_InfoContent_InfoContentItem(context);
         AV28SDT_InfoTileItemOld = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV46existingtiles = new GxSimpleCollection<string>();
         AV49newtiles = new GxSimpleCollection<string>();
         AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
         AV62SDT_InfoTileItemTranslate = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation3__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation3__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation3__default(),
            new Object[][] {
                new Object[] {
               P00GV2_A580DynamicTranslationPrimaryKey, P00GV2_A582DynamicTranslationEnglish, P00GV2_A583DynamicTranslationDutch, P00GV2_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV64GXLvl7 ;
      private short AV51indextileToRemove ;
      private short AV56indextilenew ;
      private short AV48indexToRemove ;
      private short AV52indexrow ;
      private int AV63GXV1 ;
      private int GX_INS101 ;
      private int AV65GXV2 ;
      private int AV66GXV3 ;
      private int AV67GXV4 ;
      private int AV68GXV5 ;
      private int AV69GXV6 ;
      private int AV70GXV7 ;
      private int AV71GXV8 ;
      private int AV72GXV9 ;
      private int AV73GXV10 ;
      private int AV74GXV11 ;
      private int AV75GXV12 ;
      private int AV76GXV13 ;
      private int AV77GXV14 ;
      private int AV78GXV15 ;
      private int AV79GXV16 ;
      private int AV80GXV17 ;
      private int AV81GXV18 ;
      private int AV82GXV19 ;
      private int AV83GXV20 ;
      private int AV84GXV21 ;
      private int AV85GXV22 ;
      private string AV57LanguageFrom ;
      private string AV58languageTo ;
      private string Gx_emsg ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV19DynamicTranslationEnglish ;
      private string AV20DynamicTranslationDutch ;
      private string A581DynamicTranslationAttributeNam ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> AV35SDT_InfoPageTranslationCollection ;
      private string aP1_LanguageFrom ;
      private string aP2_languageTo ;
      private SdtSDT_InfoPageTranslation AV34SDT_InfoPageTranslation ;
      private SdtSDT_InfoContent AV21SDT_InfoContent ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GV2_A580DynamicTranslationPrimaryKey ;
      private string[] P00GV2_A582DynamicTranslationEnglish ;
      private string[] P00GV2_A583DynamicTranslationDutch ;
      private Guid[] P00GV2_A578DynamicTranslationId ;
      private SdtSDT_InfoContent AV38SDT_InfoContentEnglish ;
      private SdtSDT_InfoContent AV39SDT_InfoContentDutch ;
      private SdtSDT_InfoContent AV54SDT_InfoContentItemFinal ;
      private SdtSDT_InfoContent AV26SDT_InfoContentOld ;
      private SdtSDT_InfoContent AV60SDT_InfoContentTranslate ;
      private SdtSDT_InfoContent_InfoContentItem AV22SDT_InfoContentItem ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV24SDT_InfoTileItem ;
      private SdtSDT_InfoContent_InfoContentItem AV59SDT_InfoContentItemOld ;
      private GxSimpleCollection<string> AV40oldInfoIds ;
      private GxSimpleCollection<string> AV41newInfoIds ;
      private SdtSDT_InfoContent_InfoContentItem AV61SDT_InfoContentItemTranslate ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV28SDT_InfoTileItemOld ;
      private GxSimpleCollection<string> AV46existingtiles ;
      private GxSimpleCollection<string> AV49newtiles ;
      private SdtSDT_InfoContent_InfoContentItem AV55SDT_InfoTileItemFinal ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV62SDT_InfoTileItemTranslate ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_addappversionpagetodynamictransalation3__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_addappversionpagetodynamictransalation3__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_addappversionpagetodynamictransalation3__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00GV2;
       prmP00GV2 = new Object[] {
       new ParDef("AV34SDT__1Pageid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GV3;
       prmP00GV3 = new Object[] {
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GV4;
       prmP00GV4 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GV2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV34SDT__1Pageid ORDER BY DynamicTranslationId  FOR UPDATE OF Trn_DynamicTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GV2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00GV3", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GV3)
          ,new CursorDef("P00GV4", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationTrnName) VALUES(:DynamicTranslationId, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00GV4)
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
    }
 }

}

}
