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
   public class prc_cleaninfocontent : GXProcedure
   {
      public prc_cleaninfocontent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_cleaninfocontent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDT_InfoContent aP0_SDT_InfoContent ,
                           out SdtSDT_InfoContent aP1_New_SDT_InfoContent )
      {
         this.AV8SDT_InfoContent = aP0_SDT_InfoContent;
         this.AV17New_SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         initialize();
         ExecuteImpl();
         aP1_New_SDT_InfoContent=this.AV17New_SDT_InfoContent;
      }

      public SdtSDT_InfoContent executeUdp( SdtSDT_InfoContent aP0_SDT_InfoContent )
      {
         execute(aP0_SDT_InfoContent, out aP1_New_SDT_InfoContent);
         return AV17New_SDT_InfoContent ;
      }

      public void executeSubmit( SdtSDT_InfoContent aP0_SDT_InfoContent ,
                                 out SdtSDT_InfoContent aP1_New_SDT_InfoContent )
      {
         this.AV8SDT_InfoContent = aP0_SDT_InfoContent;
         this.AV17New_SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         SubmitImpl();
         aP1_New_SDT_InfoContent=this.AV17New_SDT_InfoContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13IconNameCollection.FromJSonString("['Key','Monitor','Shower','Food','Wellbeing','Wash','Reception','Calendar','indo']", null);
         AV14NewIconNameCollection.FromJSonString("['key','tv','shower','food','heart','laundry','reception','agenda','information']", null);
         AV17New_SDT_InfoContent.FromJSonString(AV8SDT_InfoContent.ToJSonString(false, true), null);
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV17New_SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV9InfoContent = ((SdtSDT_InfoContent_InfoContentItem)AV17New_SDT_InfoContent.gxTpr_Infocontent.Item(AV18GXV1));
            new prc_logtoserver(context ).execute(  context.GetMessage( "row: ", "")+AV9InfoContent.ToJSonString(false, true)) ;
            if ( StringUtil.StrCmp(AV9InfoContent.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV9InfoContent.gxTpr_Infotype = "TileGrid";
            }
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV17New_SDT_InfoContent = AV8SDT_InfoContent;
         new prc_logtoserver(context ).execute(  context.GetMessage( "&New_SDT_InfoContent >> ", "")+AV17New_SDT_InfoContent.ToJSonString(false, true)) ;
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
         AV17New_SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV13IconNameCollection = new GxSimpleCollection<string>();
         AV14NewIconNameCollection = new GxSimpleCollection<string>();
         AV9InfoContent = new SdtSDT_InfoContent_InfoContentItem(context);
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private SdtSDT_InfoContent AV8SDT_InfoContent ;
      private SdtSDT_InfoContent AV17New_SDT_InfoContent ;
      private GxSimpleCollection<string> AV13IconNameCollection ;
      private GxSimpleCollection<string> AV14NewIconNameCollection ;
      private SdtSDT_InfoContent_InfoContentItem AV9InfoContent ;
      private SdtSDT_InfoContent aP1_New_SDT_InfoContent ;
   }

}
