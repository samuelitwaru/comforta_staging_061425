using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prc_convertnewtooldcontentstructure : GXProcedure
   {
      public prc_convertnewtooldcontentstructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertnewtooldcontentstructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDT_ContentPage aP0_SDT_ContentPage ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           out SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 )
      {
         this.AV10SDT_ContentPage = aP0_SDT_ContentPage;
         this.AV16PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV11SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_ContentPageV1=this.AV11SDT_ContentPageV1;
      }

      public SdtSDT_ContentPageV1 executeUdp( SdtSDT_ContentPage aP0_SDT_ContentPage ,
                                              Guid aP1_PageId ,
                                              string aP2_PageName )
      {
         execute(aP0_SDT_ContentPage, aP1_PageId, aP2_PageName, out aP3_SDT_ContentPageV1);
         return AV11SDT_ContentPageV1 ;
      }

      public void executeSubmit( SdtSDT_ContentPage aP0_SDT_ContentPage ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 out SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 )
      {
         this.AV10SDT_ContentPage = aP0_SDT_ContentPage;
         this.AV16PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV11SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context) ;
         SubmitImpl();
         aP3_SDT_ContentPageV1=this.AV11SDT_ContentPageV1;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SDT_ContentPageV1.FromJSonString(AV10SDT_ContentPage.ToJSonString(false, true), null);
         AV11SDT_ContentPageV1.gxTpr_Pageid = AV16PageId;
         AV11SDT_ContentPageV1.gxTpr_Pagename = AV15PageName;
         AV11SDT_ContentPageV1.gxTpr_Cta.Clear();
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV10SDT_ContentPage.gxTpr_Cta.Count )
         {
            AV13CtaItem = ((SdtSDT_ContentPage_CtaItem)AV10SDT_ContentPage.gxTpr_Cta.Item(AV20GXV1));
            AV14CtaItemV1 = new SdtSDT_ContentPageV1_CtaItem(context);
            AV14CtaItemV1.gxTpr_Ctaid = StringUtil.StrToGuid( AV13CtaItem.gxTpr_Ctaid);
            AV14CtaItemV1.gxTpr_Ctatype = AV13CtaItem.gxTpr_Ctatype;
            AV14CtaItemV1.gxTpr_Ctalabel = AV13CtaItem.gxTpr_Ctalabel;
            AV14CtaItemV1.gxTpr_Ctaaction = AV13CtaItem.gxTpr_Ctaaction;
            AV14CtaItemV1.gxTpr_Ctabgcolor = AV13CtaItem.gxTpr_Ctabgcolor;
            if ( StringUtil.StrCmp(AV13CtaItem.gxTpr_Ctabuttontype, "Icon") == 0 )
            {
               AV14CtaItemV1.gxTpr_Isimagebutton = true;
            }
            else if ( StringUtil.StrCmp(AV13CtaItem.gxTpr_Ctabuttontype, "Round") == 0 )
            {
               AV14CtaItemV1.gxTpr_Isimagebutton = false;
               AV14CtaItemV1.gxTpr_Isfullwidth = false;
            }
            else if ( StringUtil.StrCmp(AV13CtaItem.gxTpr_Ctabuttontype, "FullWidth") == 0 )
            {
               AV14CtaItemV1.gxTpr_Isfullwidth = true;
            }
            else
            {
               AV14CtaItemV1.gxTpr_Isimagebutton = false;
               AV14CtaItemV1.gxTpr_Isfullwidth = false;
            }
            AV11SDT_ContentPageV1.gxTpr_Cta.Add(AV14CtaItemV1, 0);
            AV20GXV1 = (int)(AV20GXV1+1);
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

      public override void initialize( )
      {
         AV11SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
         AV13CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV14CtaItemV1 = new SdtSDT_ContentPageV1_CtaItem(context);
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private string AV15PageName ;
      private Guid AV16PageId ;
      private SdtSDT_ContentPage AV10SDT_ContentPage ;
      private SdtSDT_ContentPageV1 AV11SDT_ContentPageV1 ;
      private SdtSDT_ContentPage_CtaItem AV13CtaItem ;
      private SdtSDT_ContentPageV1_CtaItem AV14CtaItemV1 ;
      private SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 ;
   }

}
