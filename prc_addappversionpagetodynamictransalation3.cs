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
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV35SDT_InfoPageTranslationCollection.Count )
         {
            AV34SDT_InfoPageTranslation = ((SdtSDT_InfoPageTranslation)AV35SDT_InfoPageTranslationCollection.Item(AV76GXV1));
            AV21SDT_InfoContent = new SdtSDT_InfoContent(context);
            AV21SDT_InfoContent.FromJSonString(AV34SDT_InfoPageTranslation.gxTpr_Pagestructure, null);
            AV77GXLvl7 = 0;
            /* Using cursor P00GV2 */
            pr_default.execute(0, new Object[] {AV34SDT_InfoPageTranslation.gxTpr_Pageid, AV34SDT_InfoPageTranslation.gxTpr_Pageattributetype});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A581DynamicTranslationAttributeNam = P00GV2_A581DynamicTranslationAttributeNam[0];
               A580DynamicTranslationPrimaryKey = P00GV2_A580DynamicTranslationPrimaryKey[0];
               A582DynamicTranslationEnglish = P00GV2_A582DynamicTranslationEnglish[0];
               A583DynamicTranslationDutch = P00GV2_A583DynamicTranslationDutch[0];
               A578DynamicTranslationId = P00GV2_A578DynamicTranslationId[0];
               AV77GXLvl7 = 1;
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
            if ( AV77GXLvl7 == 0 )
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
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         context.CommitDataStores("prc_addappversionpagetodynamictransalation3",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'TRANSLATENEWPAGE' Routine */
         returnInSub = false;
         AV78GXV2 = 1;
         while ( AV78GXV2 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV78GXV2));
            if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
            {
               GXt_char1 = "";
               new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
               AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV79GXV3 = 1;
               while ( AV79GXV3 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
               {
                  AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV79GXV3));
                  GXt_char1 = "";
                  new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                  AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                  AV79GXV3 = (int)(AV79GXV3+1);
               }
            }
            else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileGrid") == 0 )
            {
               AV80GXV4 = 1;
               while ( AV80GXV4 <= AV22SDT_InfoContentItem.gxTpr_Columns.Count )
               {
                  AV63Column = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV22SDT_InfoContentItem.gxTpr_Columns.Item(AV80GXV4));
                  AV81GXV5 = 1;
                  while ( AV81GXV5 <= AV63Column.gxTpr_Tiles.Count )
                  {
                     AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV81GXV5));
                     GXt_char1 = "";
                     new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                     AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                     AV81GXV5 = (int)(AV81GXV5+1);
                  }
                  AV80GXV4 = (int)(AV80GXV4+1);
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
            AV78GXV2 = (int)(AV78GXV2+1);
         }
      }

      protected void S121( )
      {
         /* 'TRANSLATEEXISTINGPAGEUPDATE' Routine */
         returnInSub = false;
         AV82GXV6 = 1;
         while ( AV82GXV6 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
         {
            AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV82GXV6));
            AV40oldInfoIds.Add(AV59SDT_InfoContentItemOld.gxTpr_Infoid, 0);
            AV82GXV6 = (int)(AV82GXV6+1);
         }
         AV83GXV7 = 1;
         while ( AV83GXV7 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV83GXV7));
            AV41newInfoIds.Add(AV22SDT_InfoContentItem.gxTpr_Infoid, 0);
            AV83GXV7 = (int)(AV83GXV7+1);
         }
         AV84GXV8 = 1;
         while ( AV84GXV8 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV84GXV8));
            if ( (AV40oldInfoIds.IndexOf(AV22SDT_InfoContentItem.gxTpr_Infoid)>0) )
            {
               AV85GXV9 = 1;
               while ( AV85GXV9 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
               {
                  AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV85GXV9));
                  if ( StringUtil.StrCmp(AV59SDT_InfoContentItemOld.gxTpr_Infoid, AV22SDT_InfoContentItem.gxTpr_Infoid) == 0 )
                  {
                     AV86GXV10 = 1;
                     while ( AV86GXV10 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
                     {
                        AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV86GXV10));
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
                              AV87GXV11 = 1;
                              while ( AV87GXV11 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                              {
                                 AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV87GXV11));
                                 AV46existingtiles.Add(AV28SDT_InfoTileItemOld.gxTpr_Id, 0);
                                 AV87GXV11 = (int)(AV87GXV11+1);
                              }
                              AV88GXV12 = 1;
                              while ( AV88GXV12 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV88GXV12));
                                 AV49newtiles.Add(AV24SDT_InfoTileItem.gxTpr_Id, 0);
                                 AV88GXV12 = (int)(AV88GXV12+1);
                              }
                              AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
                              AV89GXV13 = 1;
                              while ( AV89GXV13 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV89GXV13));
                                 if ( (AV46existingtiles.IndexOf(AV24SDT_InfoTileItem.gxTpr_Id)>0) )
                                 {
                                    AV90GXV14 = 1;
                                    while ( AV90GXV14 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                                    {
                                       AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV90GXV14));
                                       if ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Id, AV24SDT_InfoTileItem.gxTpr_Id) == 0 )
                                       {
                                          AV91GXV15 = 1;
                                          while ( AV91GXV15 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                          {
                                             AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV91GXV15));
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
                                                AV62SDT_InfoTileItemTranslate.gxTpr_Height = AV24SDT_InfoTileItem.gxTpr_Height;
                                                if ( ! ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Text, AV24SDT_InfoTileItem.gxTpr_Text) == 0 ) )
                                                {
                                                   GXt_char1 = "";
                                                   new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                   AV62SDT_InfoTileItemTranslate.gxTpr_Text = GXt_char1;
                                                }
                                             }
                                             AV91GXV15 = (int)(AV91GXV15+1);
                                          }
                                       }
                                       AV90GXV14 = (int)(AV90GXV14+1);
                                    }
                                 }
                                 else
                                 {
                                    GXt_char1 = "";
                                    new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                    AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                    AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Add(AV24SDT_InfoTileItem, 0);
                                 }
                                 AV89GXV13 = (int)(AV89GXV13+1);
                              }
                              AV92GXV16 = 1;
                              while ( AV92GXV16 <= AV59SDT_InfoContentItemOld.gxTpr_Tiles.Count )
                              {
                                 AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV59SDT_InfoContentItemOld.gxTpr_Tiles.Item(AV92GXV16));
                                 if ( ! (AV49newtiles.IndexOf(AV28SDT_InfoTileItemOld.gxTpr_Id)>0) )
                                 {
                                    AV93GXV17 = 1;
                                    while ( AV93GXV17 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                    {
                                       AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV93GXV17));
                                       if ( StringUtil.StrCmp(AV62SDT_InfoTileItemTranslate.gxTpr_Id, AV28SDT_InfoTileItemOld.gxTpr_Id) == 0 )
                                       {
                                          AV51indextileToRemove = (short)(AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.IndexOf(AV62SDT_InfoTileItemTranslate));
                                          AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.RemoveItem(AV51indextileToRemove);
                                       }
                                       AV93GXV17 = (int)(AV93GXV17+1);
                                    }
                                 }
                                 AV92GXV16 = (int)(AV92GXV16+1);
                              }
                              AV94GXV18 = 1;
                              while ( AV94GXV18 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                              {
                                 AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV94GXV18));
                                 AV56indextilenew = (short)(AV22SDT_InfoContentItem.gxTpr_Tiles.IndexOf(AV24SDT_InfoTileItem));
                                 AV95GXV19 = 1;
                                 while ( AV95GXV19 <= AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Count )
                                 {
                                    AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV61SDT_InfoContentItemTranslate.gxTpr_Tiles.Item(AV95GXV19));
                                    if ( StringUtil.StrCmp(AV24SDT_InfoTileItem.gxTpr_Id, AV62SDT_InfoTileItemTranslate.gxTpr_Id) == 0 )
                                    {
                                       AV55SDT_InfoTileItemFinal.gxTpr_Tiles.Add(AV62SDT_InfoTileItemTranslate, AV56indextilenew);
                                    }
                                    AV95GXV19 = (int)(AV95GXV19+1);
                                 }
                                 AV94GXV18 = (int)(AV94GXV18+1);
                              }
                              AV61SDT_InfoContentItemTranslate.gxTpr_Tiles = AV55SDT_InfoTileItemFinal.gxTpr_Tiles;
                           }
                           else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileGrid") == 0 )
                           {
                              AV65existingColumn = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                              AV66newColumns = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                              AV96GXV20 = 1;
                              while ( AV96GXV20 <= AV59SDT_InfoContentItemOld.gxTpr_Columns.Count )
                              {
                                 AV64ColumnOld = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV59SDT_InfoContentItemOld.gxTpr_Columns.Item(AV96GXV20));
                                 AV65existingColumn.Add(AV64ColumnOld.gxTpr_Colid, 0);
                                 AV96GXV20 = (int)(AV96GXV20+1);
                              }
                              AV97GXV21 = 1;
                              while ( AV97GXV21 <= AV22SDT_InfoContentItem.gxTpr_Columns.Count )
                              {
                                 AV67ColumnNew = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV22SDT_InfoContentItem.gxTpr_Columns.Item(AV97GXV21));
                                 AV66newColumns.Add(AV67ColumnNew.gxTpr_Colid, 0);
                                 AV97GXV21 = (int)(AV97GXV21+1);
                              }
                              AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
                              AV98GXV22 = 1;
                              while ( AV98GXV22 <= AV22SDT_InfoContentItem.gxTpr_Columns.Count )
                              {
                                 AV63Column = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV22SDT_InfoContentItem.gxTpr_Columns.Item(AV98GXV22));
                                 if ( (AV65existingColumn.IndexOf(AV63Column.gxTpr_Colid)>0) )
                                 {
                                    AV99GXV23 = 1;
                                    while ( AV99GXV23 <= AV59SDT_InfoContentItemOld.gxTpr_Columns.Count )
                                    {
                                       AV73OldColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV59SDT_InfoContentItemOld.gxTpr_Columns.Item(AV99GXV23));
                                       if ( StringUtil.StrCmp(AV73OldColumn.gxTpr_Colid, AV63Column.gxTpr_Colid) == 0 )
                                       {
                                          AV46existingtiles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                                          AV49newtiles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                                          AV100GXV24 = 1;
                                          while ( AV100GXV24 <= AV73OldColumn.gxTpr_Tiles.Count )
                                          {
                                             AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV73OldColumn.gxTpr_Tiles.Item(AV100GXV24));
                                             AV46existingtiles.Add(AV28SDT_InfoTileItemOld.gxTpr_Id, 0);
                                             AV100GXV24 = (int)(AV100GXV24+1);
                                          }
                                          AV101GXV25 = 1;
                                          while ( AV101GXV25 <= AV63Column.gxTpr_Tiles.Count )
                                          {
                                             AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV101GXV25));
                                             AV49newtiles.Add(AV24SDT_InfoTileItem.gxTpr_Id, 0);
                                             AV101GXV25 = (int)(AV101GXV25+1);
                                          }
                                          AV102GXV26 = 1;
                                          while ( AV102GXV26 <= AV63Column.gxTpr_Tiles.Count )
                                          {
                                             AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV102GXV26));
                                             if ( (AV46existingtiles.IndexOf(AV24SDT_InfoTileItem.gxTpr_Id)>0) )
                                             {
                                                AV103GXV27 = 1;
                                                while ( AV103GXV27 <= AV73OldColumn.gxTpr_Tiles.Count )
                                                {
                                                   AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV73OldColumn.gxTpr_Tiles.Item(AV103GXV27));
                                                   if ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Id, AV24SDT_InfoTileItem.gxTpr_Id) == 0 )
                                                   {
                                                      AV104GXV28 = 1;
                                                      while ( AV104GXV28 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                                      {
                                                         AV74TranslateColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV104GXV28));
                                                         if ( StringUtil.StrCmp(AV74TranslateColumn.gxTpr_Colid, AV73OldColumn.gxTpr_Colid) == 0 )
                                                         {
                                                            AV105GXV29 = 1;
                                                            while ( AV105GXV29 <= AV74TranslateColumn.gxTpr_Tiles.Count )
                                                            {
                                                               AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV74TranslateColumn.gxTpr_Tiles.Item(AV105GXV29));
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
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Height = AV24SDT_InfoTileItem.gxTpr_Height;
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Bgposition = AV24SDT_InfoTileItem.gxTpr_Bgposition;
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Bgsize = AV24SDT_InfoTileItem.gxTpr_Bgsize;
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Left = AV24SDT_InfoTileItem.gxTpr_Left;
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Originalimageurl = AV24SDT_InfoTileItem.gxTpr_Originalimageurl;
                                                                  AV62SDT_InfoTileItemTranslate.gxTpr_Top = AV24SDT_InfoTileItem.gxTpr_Top;
                                                                  if ( ! ( StringUtil.StrCmp(AV28SDT_InfoTileItemOld.gxTpr_Text, AV24SDT_InfoTileItem.gxTpr_Text) == 0 ) )
                                                                  {
                                                                     GXt_char1 = "";
                                                                     new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                                     AV62SDT_InfoTileItemTranslate.gxTpr_Text = GXt_char1;
                                                                  }
                                                               }
                                                               AV105GXV29 = (int)(AV105GXV29+1);
                                                            }
                                                         }
                                                         AV104GXV28 = (int)(AV104GXV28+1);
                                                      }
                                                   }
                                                   AV103GXV27 = (int)(AV103GXV27+1);
                                                }
                                             }
                                             else
                                             {
                                                AV106GXV30 = 1;
                                                while ( AV106GXV30 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                                {
                                                   AV74TranslateColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV106GXV30));
                                                   if ( StringUtil.StrCmp(AV74TranslateColumn.gxTpr_Colid, AV63Column.gxTpr_Colid) == 0 )
                                                   {
                                                      GXt_char1 = "";
                                                      new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                      AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                                      AV74TranslateColumn.gxTpr_Tiles.Add(AV24SDT_InfoTileItem, 0);
                                                   }
                                                   AV106GXV30 = (int)(AV106GXV30+1);
                                                }
                                             }
                                             AV102GXV26 = (int)(AV102GXV26+1);
                                          }
                                          AV107GXV31 = 1;
                                          while ( AV107GXV31 <= AV73OldColumn.gxTpr_Tiles.Count )
                                          {
                                             AV28SDT_InfoTileItemOld = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV73OldColumn.gxTpr_Tiles.Item(AV107GXV31));
                                             if ( ! (AV49newtiles.IndexOf(AV28SDT_InfoTileItemOld.gxTpr_Id)>0) )
                                             {
                                                AV108GXV32 = 1;
                                                while ( AV108GXV32 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                                {
                                                   AV74TranslateColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV108GXV32));
                                                   if ( StringUtil.StrCmp(AV74TranslateColumn.gxTpr_Colid, AV73OldColumn.gxTpr_Colid) == 0 )
                                                   {
                                                      AV109GXV33 = 1;
                                                      while ( AV109GXV33 <= AV74TranslateColumn.gxTpr_Tiles.Count )
                                                      {
                                                         AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV74TranslateColumn.gxTpr_Tiles.Item(AV109GXV33));
                                                         if ( StringUtil.StrCmp(AV62SDT_InfoTileItemTranslate.gxTpr_Id, AV28SDT_InfoTileItemOld.gxTpr_Id) == 0 )
                                                         {
                                                            AV51indextileToRemove = (short)(AV74TranslateColumn.gxTpr_Tiles.IndexOf(AV62SDT_InfoTileItemTranslate));
                                                            AV74TranslateColumn.gxTpr_Tiles.RemoveItem(AV51indextileToRemove);
                                                         }
                                                         AV109GXV33 = (int)(AV109GXV33+1);
                                                      }
                                                   }
                                                   AV108GXV32 = (int)(AV108GXV32+1);
                                                }
                                             }
                                             AV107GXV31 = (int)(AV107GXV31+1);
                                          }
                                          AV75FinalColumn = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
                                          AV110GXV34 = 1;
                                          while ( AV110GXV34 <= AV63Column.gxTpr_Tiles.Count )
                                          {
                                             AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV110GXV34));
                                             AV56indextilenew = (short)(AV63Column.gxTpr_Tiles.IndexOf(AV24SDT_InfoTileItem));
                                             AV111GXV35 = 1;
                                             while ( AV111GXV35 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                             {
                                                AV74TranslateColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV111GXV35));
                                                if ( StringUtil.StrCmp(AV74TranslateColumn.gxTpr_Colid, AV63Column.gxTpr_Colid) == 0 )
                                                {
                                                   AV112GXV36 = 1;
                                                   while ( AV112GXV36 <= AV74TranslateColumn.gxTpr_Tiles.Count )
                                                   {
                                                      AV62SDT_InfoTileItemTranslate = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV74TranslateColumn.gxTpr_Tiles.Item(AV112GXV36));
                                                      if ( StringUtil.StrCmp(AV24SDT_InfoTileItem.gxTpr_Id, AV62SDT_InfoTileItemTranslate.gxTpr_Id) == 0 )
                                                      {
                                                         AV75FinalColumn.gxTpr_Tiles.Add(AV62SDT_InfoTileItemTranslate, AV56indextilenew);
                                                      }
                                                      AV112GXV36 = (int)(AV112GXV36+1);
                                                   }
                                                }
                                                AV111GXV35 = (int)(AV111GXV35+1);
                                             }
                                             AV110GXV34 = (int)(AV110GXV34+1);
                                          }
                                          AV113GXV37 = 1;
                                          while ( AV113GXV37 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                          {
                                             AV74TranslateColumn = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV113GXV37));
                                             if ( StringUtil.StrCmp(AV74TranslateColumn.gxTpr_Colid, AV63Column.gxTpr_Colid) == 0 )
                                             {
                                                AV74TranslateColumn.gxTpr_Tiles = AV75FinalColumn.gxTpr_Tiles;
                                             }
                                             AV113GXV37 = (int)(AV113GXV37+1);
                                          }
                                       }
                                       AV99GXV23 = (int)(AV99GXV23+1);
                                    }
                                 }
                                 else
                                 {
                                    new prc_logtofile(context ).execute(  context.GetMessage( "new column", "")) ;
                                    AV114GXV38 = 1;
                                    while ( AV114GXV38 <= AV63Column.gxTpr_Tiles.Count )
                                    {
                                       AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV114GXV38));
                                       GXt_char1 = "";
                                       new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                       AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                       AV114GXV38 = (int)(AV114GXV38+1);
                                    }
                                    AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Add(AV63Column, 0);
                                 }
                                 AV98GXV22 = (int)(AV98GXV22+1);
                              }
                              AV115GXV39 = 1;
                              while ( AV115GXV39 <= AV59SDT_InfoContentItemOld.gxTpr_Columns.Count )
                              {
                                 AV64ColumnOld = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV59SDT_InfoContentItemOld.gxTpr_Columns.Item(AV115GXV39));
                                 if ( ! (AV66newColumns.IndexOf(AV64ColumnOld.gxTpr_Colid)>0) )
                                 {
                                    new prc_logtofile(context ).execute(  context.GetMessage( "Delete column", "")) ;
                                    AV116GXV40 = 1;
                                    while ( AV116GXV40 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                    {
                                       AV69ColumnTranslate = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV116GXV40));
                                       if ( StringUtil.StrCmp(AV69ColumnTranslate.gxTpr_Colid, AV64ColumnOld.gxTpr_Colid) == 0 )
                                       {
                                          AV70indexColumnToRemove = (short)(AV61SDT_InfoContentItemTranslate.gxTpr_Columns.IndexOf(AV69ColumnTranslate));
                                          new prc_logtofile(context ).execute(  context.GetMessage( "found you at index ", "")+StringUtil.Str( (decimal)(AV70indexColumnToRemove), 4, 0)) ;
                                          AV61SDT_InfoContentItemTranslate.gxTpr_Columns.RemoveItem(AV70indexColumnToRemove);
                                       }
                                       AV116GXV40 = (int)(AV116GXV40+1);
                                    }
                                 }
                                 AV115GXV39 = (int)(AV115GXV39+1);
                              }
                              AV117GXV41 = 1;
                              while ( AV117GXV41 <= AV22SDT_InfoContentItem.gxTpr_Columns.Count )
                              {
                                 AV63Column = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV22SDT_InfoContentItem.gxTpr_Columns.Item(AV117GXV41));
                                 AV72indexColumnew = (short)(AV22SDT_InfoContentItem.gxTpr_Columns.IndexOf(AV63Column));
                                 AV118GXV42 = 1;
                                 while ( AV118GXV42 <= AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Count )
                                 {
                                    AV69ColumnTranslate = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV61SDT_InfoContentItemTranslate.gxTpr_Columns.Item(AV118GXV42));
                                    if ( StringUtil.StrCmp(AV63Column.gxTpr_Colid, AV69ColumnTranslate.gxTpr_Colid) == 0 )
                                    {
                                       AV55SDT_InfoTileItemFinal.gxTpr_Columns.Add(AV69ColumnTranslate, AV72indexColumnew);
                                    }
                                    AV118GXV42 = (int)(AV118GXV42+1);
                                 }
                                 AV117GXV41 = (int)(AV117GXV41+1);
                              }
                              AV61SDT_InfoContentItemTranslate.gxTpr_Columns = AV55SDT_InfoTileItemFinal.gxTpr_Columns;
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
                        AV86GXV10 = (int)(AV86GXV10+1);
                     }
                  }
                  AV85GXV9 = (int)(AV85GXV9+1);
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
                  AV119GXV43 = 1;
                  while ( AV119GXV43 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                  {
                     AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV119GXV43));
                     GXt_char1 = "";
                     new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                     AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                     AV119GXV43 = (int)(AV119GXV43+1);
                  }
               }
               else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileGrid") == 0 )
               {
                  AV120GXV44 = 1;
                  while ( AV120GXV44 <= AV22SDT_InfoContentItem.gxTpr_Columns.Count )
                  {
                     AV63Column = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV22SDT_InfoContentItem.gxTpr_Columns.Item(AV120GXV44));
                     AV121GXV45 = 1;
                     while ( AV121GXV45 <= AV63Column.gxTpr_Tiles.Count )
                     {
                        AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV63Column.gxTpr_Tiles.Item(AV121GXV45));
                        GXt_char1 = "";
                        new prc_translatelanguage(context ).execute(  AV57LanguageFrom,  AV58languageTo,  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                        AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                        AV121GXV45 = (int)(AV121GXV45+1);
                     }
                     AV120GXV44 = (int)(AV120GXV44+1);
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
            AV84GXV8 = (int)(AV84GXV8+1);
         }
         AV122GXV46 = 1;
         while ( AV122GXV46 <= AV26SDT_InfoContentOld.gxTpr_Infocontent.Count )
         {
            AV59SDT_InfoContentItemOld = ((SdtSDT_InfoContent_InfoContentItem)AV26SDT_InfoContentOld.gxTpr_Infocontent.Item(AV122GXV46));
            if ( ! (AV41newInfoIds.IndexOf(AV59SDT_InfoContentItemOld.gxTpr_Infoid)>0) )
            {
               AV123GXV47 = 1;
               while ( AV123GXV47 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
               {
                  AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV123GXV47));
                  if ( StringUtil.StrCmp(AV61SDT_InfoContentItemTranslate.gxTpr_Infoid, AV59SDT_InfoContentItemOld.gxTpr_Infoid) == 0 )
                  {
                     AV48indexToRemove = (short)(AV60SDT_InfoContentTranslate.gxTpr_Infocontent.IndexOf(AV61SDT_InfoContentItemTranslate));
                     AV60SDT_InfoContentTranslate.gxTpr_Infocontent.RemoveItem(AV48indexToRemove);
                  }
                  AV123GXV47 = (int)(AV123GXV47+1);
               }
            }
            AV122GXV46 = (int)(AV122GXV46+1);
         }
         AV124GXV48 = 1;
         while ( AV124GXV48 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV124GXV48));
            AV52indexrow = (short)(AV21SDT_InfoContent.gxTpr_Infocontent.IndexOf(AV22SDT_InfoContentItem));
            AV125GXV49 = 1;
            while ( AV125GXV49 <= AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Count )
            {
               AV61SDT_InfoContentItemTranslate = ((SdtSDT_InfoContent_InfoContentItem)AV60SDT_InfoContentTranslate.gxTpr_Infocontent.Item(AV125GXV49));
               if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infoid, AV61SDT_InfoContentItemTranslate.gxTpr_Infoid) == 0 )
               {
                  AV54SDT_InfoContentItemFinal.gxTpr_Infocontent.Add(AV61SDT_InfoContentItemTranslate, AV52indexrow);
               }
               AV125GXV49 = (int)(AV125GXV49+1);
            }
            AV124GXV48 = (int)(AV124GXV48+1);
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
         P00GV2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00GV2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00GV2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00GV2_A583DynamicTranslationDutch = new string[] {""} ;
         P00GV2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A581DynamicTranslationAttributeNam = "";
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
         Gx_emsg = "";
         AV22SDT_InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
         AV24SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV63Column = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV59SDT_InfoContentItemOld = new SdtSDT_InfoContent_InfoContentItem(context);
         AV40oldInfoIds = new GxSimpleCollection<string>();
         AV41newInfoIds = new GxSimpleCollection<string>();
         AV61SDT_InfoContentItemTranslate = new SdtSDT_InfoContent_InfoContentItem(context);
         AV28SDT_InfoTileItemOld = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV46existingtiles = new GxSimpleCollection<string>();
         AV49newtiles = new GxSimpleCollection<string>();
         AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
         AV62SDT_InfoTileItemTranslate = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV65existingColumn = new GxSimpleCollection<string>();
         AV66newColumns = new GxSimpleCollection<string>();
         AV64ColumnOld = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV67ColumnNew = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV73OldColumn = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV74TranslateColumn = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV75FinalColumn = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV69ColumnTranslate = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
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
               P00GV2_A581DynamicTranslationAttributeNam, P00GV2_A580DynamicTranslationPrimaryKey, P00GV2_A582DynamicTranslationEnglish, P00GV2_A583DynamicTranslationDutch, P00GV2_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV77GXLvl7 ;
      private short AV51indextileToRemove ;
      private short AV56indextilenew ;
      private short AV70indexColumnToRemove ;
      private short AV72indexColumnew ;
      private short AV48indexToRemove ;
      private short AV52indexrow ;
      private int AV76GXV1 ;
      private int GX_INS101 ;
      private int AV78GXV2 ;
      private int AV79GXV3 ;
      private int AV80GXV4 ;
      private int AV81GXV5 ;
      private int AV82GXV6 ;
      private int AV83GXV7 ;
      private int AV84GXV8 ;
      private int AV85GXV9 ;
      private int AV86GXV10 ;
      private int AV87GXV11 ;
      private int AV88GXV12 ;
      private int AV89GXV13 ;
      private int AV90GXV14 ;
      private int AV91GXV15 ;
      private int AV92GXV16 ;
      private int AV93GXV17 ;
      private int AV94GXV18 ;
      private int AV95GXV19 ;
      private int AV96GXV20 ;
      private int AV97GXV21 ;
      private int AV98GXV22 ;
      private int AV99GXV23 ;
      private int AV100GXV24 ;
      private int AV101GXV25 ;
      private int AV102GXV26 ;
      private int AV103GXV27 ;
      private int AV104GXV28 ;
      private int AV105GXV29 ;
      private int AV106GXV30 ;
      private int AV107GXV31 ;
      private int AV108GXV32 ;
      private int AV109GXV33 ;
      private int AV110GXV34 ;
      private int AV111GXV35 ;
      private int AV112GXV36 ;
      private int AV113GXV37 ;
      private int AV114GXV38 ;
      private int AV115GXV39 ;
      private int AV116GXV40 ;
      private int AV117GXV41 ;
      private int AV118GXV42 ;
      private int AV119GXV43 ;
      private int AV120GXV44 ;
      private int AV121GXV45 ;
      private int AV122GXV46 ;
      private int AV123GXV47 ;
      private int AV124GXV48 ;
      private int AV125GXV49 ;
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
      private string[] P00GV2_A581DynamicTranslationAttributeNam ;
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
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV63Column ;
      private SdtSDT_InfoContent_InfoContentItem AV59SDT_InfoContentItemOld ;
      private GxSimpleCollection<string> AV40oldInfoIds ;
      private GxSimpleCollection<string> AV41newInfoIds ;
      private SdtSDT_InfoContent_InfoContentItem AV61SDT_InfoContentItemTranslate ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV28SDT_InfoTileItemOld ;
      private GxSimpleCollection<string> AV46existingtiles ;
      private GxSimpleCollection<string> AV49newtiles ;
      private SdtSDT_InfoContent_InfoContentItem AV55SDT_InfoTileItemFinal ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV62SDT_InfoTileItemTranslate ;
      private GxSimpleCollection<string> AV65existingColumn ;
      private GxSimpleCollection<string> AV66newColumns ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV64ColumnOld ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV67ColumnNew ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV73OldColumn ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV74TranslateColumn ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV75FinalColumn ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV69ColumnTranslate ;
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
       new ParDef("AV34SDT__1Pageid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV34SDT__2Pageattributetype",GXType.VarChar,40,0)
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
           new CursorDef("P00GV2", "SELECT DynamicTranslationAttributeNam, DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE (DynamicTranslationPrimaryKey = :AV34SDT__1Pageid) AND (DynamicTranslationAttributeNam = ( :AV34SDT__2Pageattributetype)) ORDER BY DynamicTranslationPrimaryKey  FOR UPDATE OF Trn_DynamicTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GV2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00GV3", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GV3)
          ,new CursorDef("P00GV4", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationTrnName, DynamicTranslationEnglishPubli, DynamicTranslationDutchPublish) VALUES(:DynamicTranslationId, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch, '', '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00GV4)
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
