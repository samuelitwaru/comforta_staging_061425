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
   public class prc_validateinfostructure : GXProcedure
   {
      public prc_validateinfostructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_validateinfostructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PageStructure ,
                           out SdtSDT_InfoContent aP1_SDT_InfoContent )
      {
         this.AV11PageStructure = aP0_PageStructure;
         this.AV10SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_InfoContent=this.AV10SDT_InfoContent;
      }

      public SdtSDT_InfoContent executeUdp( string aP0_PageStructure )
      {
         execute(aP0_PageStructure, out aP1_SDT_InfoContent);
         return AV10SDT_InfoContent ;
      }

      public void executeSubmit( string aP0_PageStructure ,
                                 out SdtSDT_InfoContent aP1_SDT_InfoContent )
      {
         this.AV11PageStructure = aP0_PageStructure;
         this.AV10SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         SubmitImpl();
         aP1_SDT_InfoContent=this.AV10SDT_InfoContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SDT_InfoContent.FromJSonString(AV11PageStructure, null);
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV10SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV9InfoContent = ((SdtSDT_InfoContent_InfoContentItem)AV10SDT_InfoContent.gxTpr_Infocontent.Item(AV12GXV1));
            if ( StringUtil.StrCmp(AV9InfoContent.gxTpr_Infotype, "Cta") == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon)) )
               {
                  AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctatype;
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor))) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorOne", "")) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorTwo", "")) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorThree", "")) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorFour", "")) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorFive", "")) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor), context.GetMessage( "CtaColorSix", "")) == 0 ) )
               {
                  AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = context.GetMessage( "ctaColor1", "");
               }
            }
            else
            {
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV10SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV9InfoContent = new SdtSDT_InfoContent_InfoContentItem(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV11PageStructure ;
      private SdtSDT_InfoContent AV10SDT_InfoContent ;
      private SdtSDT_InfoContent_InfoContentItem AV9InfoContent ;
      private SdtSDT_InfoContent aP1_SDT_InfoContent ;
   }

}
