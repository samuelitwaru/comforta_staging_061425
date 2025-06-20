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
   public class prc_addappversionpagetodynamictransalation2 : GXProcedure
   {
      public prc_addappversionpagetodynamictransalation2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addappversionpagetodynamictransalation2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDT_InfoPageTranslation> aP0_SDT_InfoPageTranslationCollection )
      {
         this.AV35SDT_InfoPageTranslationCollection = aP0_SDT_InfoPageTranslationCollection;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_InfoPageTranslation> aP0_SDT_InfoPageTranslationCollection )
      {
         this.AV35SDT_InfoPageTranslationCollection = aP0_SDT_InfoPageTranslationCollection;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Language = context.GetLanguage( );
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV12LanguageCode = "en";
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV12LanguageCode = "nl";
         }
         new prc_logtoserver(context ).execute(  context.GetMessage( " data recieved", "")+AV14SDT_TrnAttributesCollection.ToJSonString(false)) ;
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV35SDT_InfoPageTranslationCollection.Count )
         {
            AV34SDT_InfoPageTranslation = ((SdtSDT_InfoPageTranslation)AV35SDT_InfoPageTranslationCollection.Item(AV57GXV1));
            AV21SDT_InfoContent = new SdtSDT_InfoContent(context);
            AV21SDT_InfoContent.FromJSonString(AV34SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure, null);
            AV58GXLvl18 = 0;
            /* Using cursor P00GH2 */
            pr_default.execute(0, new Object[] {AV34SDT_InfoPageTranslation.gxTpr_Pageid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A580DynamicTranslationPrimaryKey = P00GH2_A580DynamicTranslationPrimaryKey[0];
               A582DynamicTranslationEnglish = P00GH2_A582DynamicTranslationEnglish[0];
               A583DynamicTranslationDutch = P00GH2_A583DynamicTranslationDutch[0];
               A578DynamicTranslationId = P00GH2_A578DynamicTranslationId[0];
               AV58GXLvl18 = 1;
               AV38SDT_InfoContentEnglish = new SdtSDT_InfoContent(context);
               AV39SDT_InfoContentDutch = new SdtSDT_InfoContent(context);
               AV54SDT_InfoContentItemFinal = new SdtSDT_InfoContent(context);
               AV38SDT_InfoContentEnglish.FromJSonString(A582DynamicTranslationEnglish, null);
               AV39SDT_InfoContentDutch.FromJSonString(A583DynamicTranslationDutch, null);
               if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
               {
                  A582DynamicTranslationEnglish = AV34SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure;
                  AV59GXV2 = 1;
                  while ( AV59GXV2 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                  {
                     AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV59GXV2));
                     AV40oldInfoIds.Add(AV42SDT_InfoContentItemEnglish.gxTpr_Infoid, 0);
                     AV59GXV2 = (int)(AV59GXV2+1);
                  }
                  AV60GXV3 = 1;
                  while ( AV60GXV3 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV60GXV3));
                     AV41newInfoIds.Add(AV22SDT_InfoContentItem.gxTpr_Infoid, 0);
                     AV60GXV3 = (int)(AV60GXV3+1);
                  }
                  AV61GXV4 = 1;
                  while ( AV61GXV4 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV61GXV4));
                     if ( (AV40oldInfoIds.IndexOf(AV22SDT_InfoContentItem.gxTpr_Infoid)>0) )
                     {
                        AV62GXV5 = 1;
                        while ( AV62GXV5 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                        {
                           AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV62GXV5));
                           if ( StringUtil.StrCmp(AV42SDT_InfoContentItemEnglish.gxTpr_Infoid, AV22SDT_InfoContentItem.gxTpr_Infoid) == 0 )
                           {
                              AV63GXV6 = 1;
                              while ( AV63GXV6 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                              {
                                 AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV63GXV6));
                                 if ( StringUtil.StrCmp(AV42SDT_InfoContentItemEnglish.gxTpr_Infoid, AV43SDT_InfoContentItemDutch.gxTpr_Infoid) == 0 )
                                 {
                                    if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                                    {
                                       if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infovalue, AV42SDT_InfoContentItemEnglish.gxTpr_Infovalue) == 0 ) )
                                       {
                                          GXt_char1 = "";
                                          new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                                          AV43SDT_InfoContentItemDutch.gxTpr_Infovalue = GXt_char1;
                                       }
                                    }
                                    else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                                    {
                                       AV64GXV7 = 1;
                                       while ( AV64GXV7 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                       {
                                          AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV64GXV7));
                                          AV46existingtiles.Add(AV45SDT_InfoTileItemEnglish.gxTpr_Id, 0);
                                          AV64GXV7 = (int)(AV64GXV7+1);
                                       }
                                       AV65GXV8 = 1;
                                       while ( AV65GXV8 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV65GXV8));
                                          AV49newtiles.Add(AV24SDT_InfoTileItem.gxTpr_Id, 0);
                                          AV65GXV8 = (int)(AV65GXV8+1);
                                       }
                                       AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
                                       AV66GXV9 = 1;
                                       while ( AV66GXV9 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV66GXV9));
                                          if ( (AV46existingtiles.IndexOf(AV24SDT_InfoTileItem.gxTpr_Id)>0) )
                                          {
                                             AV67GXV10 = 1;
                                             while ( AV67GXV10 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                             {
                                                AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV67GXV10));
                                                if ( StringUtil.StrCmp(AV45SDT_InfoTileItemEnglish.gxTpr_Id, AV24SDT_InfoTileItem.gxTpr_Id) == 0 )
                                                {
                                                   AV68GXV11 = 1;
                                                   while ( AV68GXV11 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                                   {
                                                      AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV68GXV11));
                                                      if ( StringUtil.StrCmp(AV44SDT_InfoTileItemDutch.gxTpr_Id, AV45SDT_InfoTileItemEnglish.gxTpr_Id) == 0 )
                                                      {
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Action = AV24SDT_InfoTileItem.gxTpr_Action;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Align = AV24SDT_InfoTileItem.gxTpr_Align;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Bgcolor = AV24SDT_InfoTileItem.gxTpr_Bgcolor;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Bgimageurl = AV24SDT_InfoTileItem.gxTpr_Bgimageurl;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Color = AV24SDT_InfoTileItem.gxTpr_Color;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Icon = AV24SDT_InfoTileItem.gxTpr_Icon;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Name = AV24SDT_InfoTileItem.gxTpr_Name;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Opacity = AV24SDT_InfoTileItem.gxTpr_Opacity;
                                                         AV44SDT_InfoTileItemDutch.gxTpr_Size = AV24SDT_InfoTileItem.gxTpr_Size;
                                                         if ( ! ( StringUtil.StrCmp(AV45SDT_InfoTileItemEnglish.gxTpr_Text, AV24SDT_InfoTileItem.gxTpr_Text) == 0 ) )
                                                         {
                                                            GXt_char1 = "";
                                                            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                            AV44SDT_InfoTileItemDutch.gxTpr_Text = GXt_char1;
                                                            new prc_logtofile(context ).execute(  context.GetMessage( "translated tile ", "")+AV44SDT_InfoTileItemDutch.gxTpr_Text) ;
                                                         }
                                                      }
                                                      AV68GXV11 = (int)(AV68GXV11+1);
                                                   }
                                                }
                                                AV67GXV10 = (int)(AV67GXV10+1);
                                             }
                                          }
                                          else
                                          {
                                             GXt_char1 = "";
                                             new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                             AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                             AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Add(AV24SDT_InfoTileItem, 0);
                                          }
                                          AV66GXV9 = (int)(AV66GXV9+1);
                                       }
                                       AV69GXV12 = 1;
                                       while ( AV69GXV12 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                       {
                                          AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV69GXV12));
                                          if ( ! (AV49newtiles.IndexOf(AV45SDT_InfoTileItemEnglish.gxTpr_Id)>0) )
                                          {
                                             AV70GXV13 = 1;
                                             while ( AV70GXV13 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                             {
                                                AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV70GXV13));
                                                if ( StringUtil.StrCmp(AV44SDT_InfoTileItemDutch.gxTpr_Id, AV45SDT_InfoTileItemEnglish.gxTpr_Id) == 0 )
                                                {
                                                   AV51indextileToRemove = (short)(AV43SDT_InfoContentItemDutch.gxTpr_Tiles.IndexOf(AV44SDT_InfoTileItemDutch));
                                                   AV43SDT_InfoContentItemDutch.gxTpr_Tiles.RemoveItem(AV51indextileToRemove);
                                                }
                                                AV70GXV13 = (int)(AV70GXV13+1);
                                             }
                                          }
                                          AV69GXV12 = (int)(AV69GXV12+1);
                                       }
                                       AV71GXV14 = 1;
                                       while ( AV71GXV14 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV71GXV14));
                                          AV56indextilenew = (short)(AV22SDT_InfoContentItem.gxTpr_Tiles.IndexOf(AV24SDT_InfoTileItem));
                                          AV72GXV15 = 1;
                                          while ( AV72GXV15 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                          {
                                             AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV72GXV15));
                                             if ( StringUtil.StrCmp(AV24SDT_InfoTileItem.gxTpr_Id, AV44SDT_InfoTileItemDutch.gxTpr_Id) == 0 )
                                             {
                                                AV55SDT_InfoTileItemFinal.gxTpr_Tiles.Add(AV44SDT_InfoTileItemDutch, AV56indextilenew);
                                             }
                                             AV72GXV15 = (int)(AV72GXV15+1);
                                          }
                                          AV71GXV14 = (int)(AV71GXV14+1);
                                       }
                                       AV43SDT_InfoContentItemDutch.gxTpr_Tiles = AV55SDT_InfoTileItemFinal.gxTpr_Tiles;
                                    }
                                    else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                                    {
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Action = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Action;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctaaction = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaaction;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabgcolor;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctabuttontype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttontype;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctacolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctacolor;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctaid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaid;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected;
                                       AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctatype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctatype;
                                       if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctalabel) == 0 ) )
                                       {
                                          GXt_char1 = "";
                                          new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                                          AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                                       }
                                    }
                                    else
                                    {
                                       AV43SDT_InfoContentItemDutch = AV22SDT_InfoContentItem;
                                    }
                                 }
                                 AV63GXV6 = (int)(AV63GXV6+1);
                              }
                           }
                           AV62GXV5 = (int)(AV62GXV5+1);
                        }
                     }
                     else
                     {
                        if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                        {
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                           AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
                        }
                        else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                        {
                           AV73GXV16 = 1;
                           while ( AV73GXV16 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                           {
                              AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV73GXV16));
                              GXt_char1 = "";
                              new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                              AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                              AV73GXV16 = (int)(AV73GXV16+1);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                        {
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                           AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                        }
                        else
                        {
                        }
                        AV39SDT_InfoContentDutch.gxTpr_Infocontent.Add(AV22SDT_InfoContentItem, 0);
                     }
                     AV61GXV4 = (int)(AV61GXV4+1);
                  }
                  AV74GXV17 = 1;
                  while ( AV74GXV17 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                  {
                     AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV74GXV17));
                     if ( ! (AV41newInfoIds.IndexOf(AV42SDT_InfoContentItemEnglish.gxTpr_Infoid)>0) )
                     {
                        AV75GXV18 = 1;
                        while ( AV75GXV18 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                        {
                           AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV75GXV18));
                           if ( StringUtil.StrCmp(AV43SDT_InfoContentItemDutch.gxTpr_Infoid, AV42SDT_InfoContentItemEnglish.gxTpr_Infoid) == 0 )
                           {
                              AV48indexToRemove = (short)(AV39SDT_InfoContentDutch.gxTpr_Infocontent.IndexOf(AV43SDT_InfoContentItemDutch));
                              AV39SDT_InfoContentDutch.gxTpr_Infocontent.RemoveItem(AV48indexToRemove);
                           }
                           AV75GXV18 = (int)(AV75GXV18+1);
                        }
                     }
                     AV74GXV17 = (int)(AV74GXV17+1);
                  }
                  new prc_logtofile(context ).execute(  context.GetMessage( "-----------befor------------", "")) ;
                  new prc_logtofile(context ).execute(  AV39SDT_InfoContentDutch.ToJSonString(false, true)) ;
                  AV76GXV19 = 1;
                  while ( AV76GXV19 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV76GXV19));
                     AV52indexrow = (short)(AV21SDT_InfoContent.gxTpr_Infocontent.IndexOf(AV22SDT_InfoContentItem));
                     AV77GXV20 = 1;
                     while ( AV77GXV20 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                     {
                        AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV77GXV20));
                        if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infoid, AV43SDT_InfoContentItemDutch.gxTpr_Infoid) == 0 )
                        {
                           new prc_logtofile(context ).execute(  context.GetMessage( "match", "")) ;
                           AV54SDT_InfoContentItemFinal.gxTpr_Infocontent.Add(AV43SDT_InfoContentItemDutch, AV52indexrow);
                           new prc_logtofile(context ).execute(  AV43SDT_InfoContentItemDutch.gxTpr_Infovalue+context.GetMessage( "is set on ", "")+StringUtil.Str( (decimal)(AV52indexrow), 4, 0)) ;
                        }
                        AV77GXV20 = (int)(AV77GXV20+1);
                     }
                     AV76GXV19 = (int)(AV76GXV19+1);
                  }
                  A583DynamicTranslationDutch = AV54SDT_InfoContentItemFinal.ToJSonString(false, true);
                  new prc_logtofile(context ).execute(  context.GetMessage( "-----------new------------", "")) ;
                  new prc_logtofile(context ).execute(  AV21SDT_InfoContent.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "----------old-------------", "")) ;
                  new prc_logtofile(context ).execute(  AV38SDT_InfoContentEnglish.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "---------translated--------------", "")) ;
                  new prc_logtofile(context ).execute(  AV39SDT_InfoContentDutch.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "--------final-------------", "")) ;
                  new prc_logtofile(context ).execute(  AV54SDT_InfoContentItemFinal.ToJSonString(false, true)) ;
               }
               else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
               {
                  A583DynamicTranslationDutch = AV34SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure;
                  AV78GXV21 = 1;
                  while ( AV78GXV21 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                  {
                     AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV78GXV21));
                     AV40oldInfoIds.Add(AV43SDT_InfoContentItemDutch.gxTpr_Infoid, 0);
                     AV78GXV21 = (int)(AV78GXV21+1);
                  }
                  AV79GXV22 = 1;
                  while ( AV79GXV22 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV79GXV22));
                     AV41newInfoIds.Add(AV22SDT_InfoContentItem.gxTpr_Infoid, 0);
                     AV79GXV22 = (int)(AV79GXV22+1);
                  }
                  AV80GXV23 = 1;
                  while ( AV80GXV23 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV80GXV23));
                     if ( (AV40oldInfoIds.IndexOf(AV22SDT_InfoContentItem.gxTpr_Infoid)>0) )
                     {
                        AV81GXV24 = 1;
                        while ( AV81GXV24 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                        {
                           AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV81GXV24));
                           if ( StringUtil.StrCmp(AV43SDT_InfoContentItemDutch.gxTpr_Infoid, AV22SDT_InfoContentItem.gxTpr_Infoid) == 0 )
                           {
                              AV82GXV25 = 1;
                              while ( AV82GXV25 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                              {
                                 AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV82GXV25));
                                 if ( StringUtil.StrCmp(AV43SDT_InfoContentItemDutch.gxTpr_Infoid, AV42SDT_InfoContentItemEnglish.gxTpr_Infoid) == 0 )
                                 {
                                    if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                                    {
                                       if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infovalue, AV43SDT_InfoContentItemDutch.gxTpr_Infovalue) == 0 ) )
                                       {
                                          GXt_char1 = "";
                                          new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                                          AV42SDT_InfoContentItemEnglish.gxTpr_Infovalue = GXt_char1;
                                       }
                                    }
                                    else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                                    {
                                       AV83GXV26 = 1;
                                       while ( AV83GXV26 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                       {
                                          AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV83GXV26));
                                          AV46existingtiles.Add(AV44SDT_InfoTileItemDutch.gxTpr_Id, 0);
                                          AV83GXV26 = (int)(AV83GXV26+1);
                                       }
                                       AV84GXV27 = 1;
                                       while ( AV84GXV27 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV84GXV27));
                                          AV49newtiles.Add(AV24SDT_InfoTileItem.gxTpr_Id, 0);
                                          AV84GXV27 = (int)(AV84GXV27+1);
                                       }
                                       AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
                                       AV85GXV28 = 1;
                                       while ( AV85GXV28 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV85GXV28));
                                          if ( (AV46existingtiles.IndexOf(AV24SDT_InfoTileItem.gxTpr_Id)>0) )
                                          {
                                             AV86GXV29 = 1;
                                             while ( AV86GXV29 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                             {
                                                AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV86GXV29));
                                                if ( StringUtil.StrCmp(AV44SDT_InfoTileItemDutch.gxTpr_Id, AV24SDT_InfoTileItem.gxTpr_Id) == 0 )
                                                {
                                                   AV87GXV30 = 1;
                                                   while ( AV87GXV30 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                                   {
                                                      AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV87GXV30));
                                                      if ( StringUtil.StrCmp(AV45SDT_InfoTileItemEnglish.gxTpr_Id, AV44SDT_InfoTileItemDutch.gxTpr_Id) == 0 )
                                                      {
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Action = AV24SDT_InfoTileItem.gxTpr_Action;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Align = AV24SDT_InfoTileItem.gxTpr_Align;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Bgcolor = AV24SDT_InfoTileItem.gxTpr_Bgcolor;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Bgimageurl = AV24SDT_InfoTileItem.gxTpr_Bgimageurl;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Color = AV24SDT_InfoTileItem.gxTpr_Color;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Icon = AV24SDT_InfoTileItem.gxTpr_Icon;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Name = AV24SDT_InfoTileItem.gxTpr_Name;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Opacity = AV24SDT_InfoTileItem.gxTpr_Opacity;
                                                         AV45SDT_InfoTileItemEnglish.gxTpr_Size = AV24SDT_InfoTileItem.gxTpr_Size;
                                                         if ( ! ( StringUtil.StrCmp(AV44SDT_InfoTileItemDutch.gxTpr_Text, AV24SDT_InfoTileItem.gxTpr_Text) == 0 ) )
                                                         {
                                                            GXt_char1 = "";
                                                            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                                            AV45SDT_InfoTileItemEnglish.gxTpr_Text = GXt_char1;
                                                            new prc_logtofile(context ).execute(  context.GetMessage( "translated tile ", "")+AV45SDT_InfoTileItemEnglish.gxTpr_Text) ;
                                                         }
                                                      }
                                                      AV87GXV30 = (int)(AV87GXV30+1);
                                                   }
                                                }
                                                AV86GXV29 = (int)(AV86GXV29+1);
                                             }
                                          }
                                          else
                                          {
                                             GXt_char1 = "";
                                             new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                                             AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                                             AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Add(AV24SDT_InfoTileItem, 0);
                                          }
                                          AV85GXV28 = (int)(AV85GXV28+1);
                                       }
                                       AV88GXV31 = 1;
                                       while ( AV88GXV31 <= AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Count )
                                       {
                                          AV44SDT_InfoTileItemDutch = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV43SDT_InfoContentItemDutch.gxTpr_Tiles.Item(AV88GXV31));
                                          if ( ! (AV49newtiles.IndexOf(AV44SDT_InfoTileItemDutch.gxTpr_Id)>0) )
                                          {
                                             AV89GXV32 = 1;
                                             while ( AV89GXV32 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                             {
                                                AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV89GXV32));
                                                if ( StringUtil.StrCmp(AV45SDT_InfoTileItemEnglish.gxTpr_Id, AV44SDT_InfoTileItemDutch.gxTpr_Id) == 0 )
                                                {
                                                   AV51indextileToRemove = (short)(AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.IndexOf(AV45SDT_InfoTileItemEnglish));
                                                   AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.RemoveItem(AV51indextileToRemove);
                                                }
                                                AV89GXV32 = (int)(AV89GXV32+1);
                                             }
                                          }
                                          AV88GXV31 = (int)(AV88GXV31+1);
                                       }
                                       AV90GXV33 = 1;
                                       while ( AV90GXV33 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                                       {
                                          AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV90GXV33));
                                          AV56indextilenew = (short)(AV22SDT_InfoContentItem.gxTpr_Tiles.IndexOf(AV24SDT_InfoTileItem));
                                          AV91GXV34 = 1;
                                          while ( AV91GXV34 <= AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Count )
                                          {
                                             AV45SDT_InfoTileItemEnglish = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV42SDT_InfoContentItemEnglish.gxTpr_Tiles.Item(AV91GXV34));
                                             if ( StringUtil.StrCmp(AV24SDT_InfoTileItem.gxTpr_Id, AV45SDT_InfoTileItemEnglish.gxTpr_Id) == 0 )
                                             {
                                                AV55SDT_InfoTileItemFinal.gxTpr_Tiles.Add(AV45SDT_InfoTileItemEnglish, AV56indextilenew);
                                             }
                                             AV91GXV34 = (int)(AV91GXV34+1);
                                          }
                                          AV90GXV33 = (int)(AV90GXV33+1);
                                       }
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Tiles = AV55SDT_InfoTileItemFinal.gxTpr_Tiles;
                                    }
                                    else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                                    {
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Action = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Action;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctaaction = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaaction;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabgcolor;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttonimgurl;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctabuttontype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctabuttontype;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctacolor = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctacolor;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaconnectedsupplierid;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctaid = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctaid;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctasupplierisconnected;
                                       AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctatype = AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctatype;
                                       if ( ! ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, AV43SDT_InfoContentItemDutch.gxTpr_Ctaattributes.gxTpr_Ctalabel) == 0 ) )
                                       {
                                          GXt_char1 = "";
                                          new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                                          AV42SDT_InfoContentItemEnglish.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                                       }
                                    }
                                    else
                                    {
                                       AV42SDT_InfoContentItemEnglish = AV22SDT_InfoContentItem;
                                    }
                                 }
                                 AV82GXV25 = (int)(AV82GXV25+1);
                              }
                           }
                           AV81GXV24 = (int)(AV81GXV24+1);
                        }
                     }
                     else
                     {
                        if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                        {
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                           AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
                        }
                        else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                        {
                           AV92GXV35 = 1;
                           while ( AV92GXV35 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                           {
                              AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV92GXV35));
                              GXt_char1 = "";
                              new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                              AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                              AV92GXV35 = (int)(AV92GXV35+1);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                        {
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                           AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                        }
                        else
                        {
                        }
                        AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Add(AV22SDT_InfoContentItem, 0);
                     }
                     AV80GXV23 = (int)(AV80GXV23+1);
                  }
                  AV93GXV36 = 1;
                  while ( AV93GXV36 <= AV39SDT_InfoContentDutch.gxTpr_Infocontent.Count )
                  {
                     AV43SDT_InfoContentItemDutch = ((SdtSDT_InfoContent_InfoContentItem)AV39SDT_InfoContentDutch.gxTpr_Infocontent.Item(AV93GXV36));
                     if ( ! (AV41newInfoIds.IndexOf(AV43SDT_InfoContentItemDutch.gxTpr_Infoid)>0) )
                     {
                        AV94GXV37 = 1;
                        while ( AV94GXV37 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                        {
                           AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV94GXV37));
                           if ( StringUtil.StrCmp(AV42SDT_InfoContentItemEnglish.gxTpr_Infoid, AV43SDT_InfoContentItemDutch.gxTpr_Infoid) == 0 )
                           {
                              AV48indexToRemove = (short)(AV38SDT_InfoContentEnglish.gxTpr_Infocontent.IndexOf(AV42SDT_InfoContentItemEnglish));
                              AV38SDT_InfoContentEnglish.gxTpr_Infocontent.RemoveItem(AV48indexToRemove);
                           }
                           AV94GXV37 = (int)(AV94GXV37+1);
                        }
                     }
                     AV93GXV36 = (int)(AV93GXV36+1);
                  }
                  new prc_logtofile(context ).execute(  context.GetMessage( "-----------befor------------", "")) ;
                  new prc_logtofile(context ).execute(  AV38SDT_InfoContentEnglish.ToJSonString(false, true)) ;
                  AV95GXV38 = 1;
                  while ( AV95GXV38 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV95GXV38));
                     AV52indexrow = (short)(AV21SDT_InfoContent.gxTpr_Infocontent.IndexOf(AV22SDT_InfoContentItem));
                     AV96GXV39 = 1;
                     while ( AV96GXV39 <= AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Count )
                     {
                        AV42SDT_InfoContentItemEnglish = ((SdtSDT_InfoContent_InfoContentItem)AV38SDT_InfoContentEnglish.gxTpr_Infocontent.Item(AV96GXV39));
                        if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infoid, AV42SDT_InfoContentItemEnglish.gxTpr_Infoid) == 0 )
                        {
                           new prc_logtofile(context ).execute(  context.GetMessage( "match", "")) ;
                           AV54SDT_InfoContentItemFinal.gxTpr_Infocontent.Add(AV42SDT_InfoContentItemEnglish, AV52indexrow);
                           new prc_logtofile(context ).execute(  AV42SDT_InfoContentItemEnglish.gxTpr_Infovalue+context.GetMessage( "is set on ", "")+StringUtil.Str( (decimal)(AV52indexrow), 4, 0)) ;
                        }
                        AV96GXV39 = (int)(AV96GXV39+1);
                     }
                     AV95GXV38 = (int)(AV95GXV38+1);
                  }
                  A582DynamicTranslationEnglish = AV54SDT_InfoContentItemFinal.ToJSonString(false, true);
                  new prc_logtofile(context ).execute(  context.GetMessage( "-----------new------------", "")) ;
                  new prc_logtofile(context ).execute(  AV21SDT_InfoContent.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "----------old-------------", "")) ;
                  new prc_logtofile(context ).execute(  AV39SDT_InfoContentDutch.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "---------translated--------------", "")) ;
                  new prc_logtofile(context ).execute(  AV38SDT_InfoContentEnglish.ToJSonString(false, true)) ;
                  new prc_logtofile(context ).execute(  context.GetMessage( "--------final-------------", "")) ;
                  new prc_logtofile(context ).execute(  AV54SDT_InfoContentItemFinal.ToJSonString(false, true)) ;
               }
               /* Using cursor P00GH3 */
               pr_default.execute(1, new Object[] {A582DynamicTranslationEnglish, A583DynamicTranslationDutch, A578DynamicTranslationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV58GXLvl18 == 0 )
            {
               if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
               {
                  AV19DynamicTranslationEnglish = AV34SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure;
                  AV97GXV40 = 1;
                  while ( AV97GXV40 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV97GXV40));
                     new prc_logtofile(context ).execute(  AV22SDT_InfoContentItem.gxTpr_Infotype) ;
                     if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                     {
                        GXt_char1 = "";
                        new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                        AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
                     }
                     else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                     {
                        AV98GXV41 = 1;
                        while ( AV98GXV41 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                        {
                           AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV98GXV41));
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                           AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                           new prc_logtofile(context ).execute(  context.GetMessage( "Tile ", "")+AV24SDT_InfoTileItem.gxTpr_Text) ;
                           AV98GXV41 = (int)(AV98GXV41+1);
                        }
                     }
                     else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                     {
                        GXt_char1 = "";
                        new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                        AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                        new prc_logtofile(context ).execute(  context.GetMessage( "cta ", "")+AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel) ;
                     }
                     else
                     {
                        new prc_logtofile(context ).execute(  context.GetMessage( "Non translatable", "")) ;
                     }
                     AV97GXV40 = (int)(AV97GXV40+1);
                  }
                  AV20DynamicTranslationDutch = AV21SDT_InfoContent.ToJSonString(false, true);
               }
               else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
               {
                  AV20DynamicTranslationDutch = AV34SDT_InfoPageTranslation.gxTpr_Pagepublishedstructure;
                  AV99GXV42 = 1;
                  while ( AV99GXV42 <= AV21SDT_InfoContent.gxTpr_Infocontent.Count )
                  {
                     AV22SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV21SDT_InfoContent.gxTpr_Infocontent.Item(AV99GXV42));
                     new prc_logtofile(context ).execute(  AV22SDT_InfoContentItem.gxTpr_Infotype) ;
                     if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Description") == 0 )
                     {
                        GXt_char1 = "";
                        new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Infovalue, out  GXt_char1) ;
                        AV22SDT_InfoContentItem.gxTpr_Infovalue = GXt_char1;
                     }
                     else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "TileRow") == 0 )
                     {
                        AV100GXV43 = 1;
                        while ( AV100GXV43 <= AV22SDT_InfoContentItem.gxTpr_Tiles.Count )
                        {
                           AV24SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV22SDT_InfoContentItem.gxTpr_Tiles.Item(AV100GXV43));
                           GXt_char1 = "";
                           new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV24SDT_InfoTileItem.gxTpr_Text, out  GXt_char1) ;
                           AV24SDT_InfoTileItem.gxTpr_Text = GXt_char1;
                           new prc_logtofile(context ).execute(  context.GetMessage( "Tile ", "")+AV24SDT_InfoTileItem.gxTpr_Text) ;
                           AV100GXV43 = (int)(AV100GXV43+1);
                        }
                     }
                     else if ( StringUtil.StrCmp(AV22SDT_InfoContentItem.gxTpr_Infotype, "Cta") == 0 )
                     {
                        GXt_char1 = "";
                        new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel, out  GXt_char1) ;
                        AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel = GXt_char1;
                        new prc_logtofile(context ).execute(  context.GetMessage( "cta ", "")+AV22SDT_InfoContentItem.gxTpr_Ctaattributes.gxTpr_Ctalabel) ;
                     }
                     else
                     {
                        new prc_logtofile(context ).execute(  context.GetMessage( "Non translatable", "")) ;
                     }
                     AV99GXV42 = (int)(AV99GXV42+1);
                  }
                  AV19DynamicTranslationEnglish = AV21SDT_InfoContent.ToJSonString(false, true);
               }
               /*
                  INSERT RECORD ON TABLE Trn_DynamicTranslation

               */
               A580DynamicTranslationPrimaryKey = AV34SDT_InfoPageTranslation.gxTpr_Pageid;
               A582DynamicTranslationEnglish = AV19DynamicTranslationEnglish;
               A583DynamicTranslationDutch = AV20DynamicTranslationDutch;
               A578DynamicTranslationId = Guid.NewGuid( );
               /* Using cursor P00GH4 */
               pr_default.execute(2, new Object[] {A578DynamicTranslationId, A580DynamicTranslationPrimaryKey, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
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
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         context.CommitDataStores("prc_addappversionpagetodynamictransalation2",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addappversionpagetodynamictransalation2",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Language = "";
         AV12LanguageCode = "";
         AV14SDT_TrnAttributesCollection = new GXBaseCollection<SdtSDT_TrnAttributes>( context, "SDT_TrnAttributes", "Comforta_version2");
         AV34SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
         AV21SDT_InfoContent = new SdtSDT_InfoContent(context);
         P00GH2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00GH2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00GH2_A583DynamicTranslationDutch = new string[] {""} ;
         P00GH2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         A578DynamicTranslationId = Guid.Empty;
         AV38SDT_InfoContentEnglish = new SdtSDT_InfoContent(context);
         AV39SDT_InfoContentDutch = new SdtSDT_InfoContent(context);
         AV54SDT_InfoContentItemFinal = new SdtSDT_InfoContent(context);
         AV42SDT_InfoContentItemEnglish = new SdtSDT_InfoContent_InfoContentItem(context);
         AV40oldInfoIds = new GxSimpleCollection<string>();
         AV22SDT_InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
         AV41newInfoIds = new GxSimpleCollection<string>();
         AV43SDT_InfoContentItemDutch = new SdtSDT_InfoContent_InfoContentItem(context);
         AV45SDT_InfoTileItemEnglish = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV46existingtiles = new GxSimpleCollection<string>();
         AV24SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV49newtiles = new GxSimpleCollection<string>();
         AV55SDT_InfoTileItemFinal = new SdtSDT_InfoContent_InfoContentItem(context);
         AV44SDT_InfoTileItemDutch = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         AV19DynamicTranslationEnglish = "";
         AV20DynamicTranslationDutch = "";
         GXt_char1 = "";
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagetodynamictransalation2__default(),
            new Object[][] {
                new Object[] {
               P00GH2_A580DynamicTranslationPrimaryKey, P00GH2_A582DynamicTranslationEnglish, P00GH2_A583DynamicTranslationDutch, P00GH2_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV58GXLvl18 ;
      private short AV51indextileToRemove ;
      private short AV56indextilenew ;
      private short AV48indexToRemove ;
      private short AV52indexrow ;
      private int AV57GXV1 ;
      private int AV59GXV2 ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private int AV62GXV5 ;
      private int AV63GXV6 ;
      private int AV64GXV7 ;
      private int AV65GXV8 ;
      private int AV66GXV9 ;
      private int AV67GXV10 ;
      private int AV68GXV11 ;
      private int AV69GXV12 ;
      private int AV70GXV13 ;
      private int AV71GXV14 ;
      private int AV72GXV15 ;
      private int AV73GXV16 ;
      private int AV74GXV17 ;
      private int AV75GXV18 ;
      private int AV76GXV19 ;
      private int AV77GXV20 ;
      private int AV78GXV21 ;
      private int AV79GXV22 ;
      private int AV80GXV23 ;
      private int AV81GXV24 ;
      private int AV82GXV25 ;
      private int AV83GXV26 ;
      private int AV84GXV27 ;
      private int AV85GXV28 ;
      private int AV86GXV29 ;
      private int AV87GXV30 ;
      private int AV88GXV31 ;
      private int AV89GXV32 ;
      private int AV90GXV33 ;
      private int AV91GXV34 ;
      private int AV92GXV35 ;
      private int AV93GXV36 ;
      private int AV94GXV37 ;
      private int AV95GXV38 ;
      private int AV96GXV39 ;
      private int AV97GXV40 ;
      private int AV98GXV41 ;
      private int AV99GXV42 ;
      private int AV100GXV43 ;
      private int GX_INS101 ;
      private string AV12LanguageCode ;
      private string GXt_char1 ;
      private string Gx_emsg ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV19DynamicTranslationEnglish ;
      private string AV20DynamicTranslationDutch ;
      private string AV9Language ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> AV35SDT_InfoPageTranslationCollection ;
      private GXBaseCollection<SdtSDT_TrnAttributes> AV14SDT_TrnAttributesCollection ;
      private SdtSDT_InfoPageTranslation AV34SDT_InfoPageTranslation ;
      private SdtSDT_InfoContent AV21SDT_InfoContent ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GH2_A580DynamicTranslationPrimaryKey ;
      private string[] P00GH2_A582DynamicTranslationEnglish ;
      private string[] P00GH2_A583DynamicTranslationDutch ;
      private Guid[] P00GH2_A578DynamicTranslationId ;
      private SdtSDT_InfoContent AV38SDT_InfoContentEnglish ;
      private SdtSDT_InfoContent AV39SDT_InfoContentDutch ;
      private SdtSDT_InfoContent AV54SDT_InfoContentItemFinal ;
      private SdtSDT_InfoContent_InfoContentItem AV42SDT_InfoContentItemEnglish ;
      private GxSimpleCollection<string> AV40oldInfoIds ;
      private SdtSDT_InfoContent_InfoContentItem AV22SDT_InfoContentItem ;
      private GxSimpleCollection<string> AV41newInfoIds ;
      private SdtSDT_InfoContent_InfoContentItem AV43SDT_InfoContentItemDutch ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV45SDT_InfoTileItemEnglish ;
      private GxSimpleCollection<string> AV46existingtiles ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV24SDT_InfoTileItem ;
      private GxSimpleCollection<string> AV49newtiles ;
      private SdtSDT_InfoContent_InfoContentItem AV55SDT_InfoTileItemFinal ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV44SDT_InfoTileItemDutch ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_addappversionpagetodynamictransalation2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_addappversionpagetodynamictransalation2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_addappversionpagetodynamictransalation2__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00GH2;
       prmP00GH2 = new Object[] {
       new ParDef("AV34SDT__1Pageid",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GH3;
       prmP00GH3 = new Object[] {
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GH4;
       prmP00GH4 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GH2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV34SDT__1Pageid ORDER BY DynamicTranslationId  FOR UPDATE OF Trn_DynamicTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GH2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00GH3", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GH3)
          ,new CursorDef("P00GH4", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationTrnName, DynamicTranslationAttributeNam) VALUES(:DynamicTranslationId, :DynamicTranslationPrimaryKey, :DynamicTranslationEnglish, :DynamicTranslationDutch, '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00GH4)
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
