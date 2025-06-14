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
   public class prc_createpagetile : GXProcedure
   {
      public prc_createpagetile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createpagetile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TileName ,
                           string aP1_TileColor ,
                           string aP2_Align ,
                           string aP3_Icon ,
                           short aP4_Opacity ,
                           string aP5_BGColor ,
                           string aP6_BGImageUrl ,
                           string aP7_ActionObjectId ,
                           string aP8_ActionObjectType ,
                           string aP9_ActionObjectUrl ,
                           out SdtSDT_MenuPage_RowsItem_TilesItem aP10_TilesItem )
      {
         this.AV9TileName = aP0_TileName;
         this.AV16TileColor = aP1_TileColor;
         this.AV14Align = aP2_Align;
         this.AV18Icon = aP3_Icon;
         this.AV15Opacity = aP4_Opacity;
         this.AV17BGColor = aP5_BGColor;
         this.AV10BGImageUrl = aP6_BGImageUrl;
         this.AV12ActionObjectId = aP7_ActionObjectId;
         this.AV13ActionObjectType = aP8_ActionObjectType;
         this.AV11ActionObjectUrl = aP9_ActionObjectUrl;
         this.AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context) ;
         initialize();
         ExecuteImpl();
         aP10_TilesItem=this.AV8TilesItem;
      }

      public SdtSDT_MenuPage_RowsItem_TilesItem executeUdp( string aP0_TileName ,
                                                            string aP1_TileColor ,
                                                            string aP2_Align ,
                                                            string aP3_Icon ,
                                                            short aP4_Opacity ,
                                                            string aP5_BGColor ,
                                                            string aP6_BGImageUrl ,
                                                            string aP7_ActionObjectId ,
                                                            string aP8_ActionObjectType ,
                                                            string aP9_ActionObjectUrl )
      {
         execute(aP0_TileName, aP1_TileColor, aP2_Align, aP3_Icon, aP4_Opacity, aP5_BGColor, aP6_BGImageUrl, aP7_ActionObjectId, aP8_ActionObjectType, aP9_ActionObjectUrl, out aP10_TilesItem);
         return AV8TilesItem ;
      }

      public void executeSubmit( string aP0_TileName ,
                                 string aP1_TileColor ,
                                 string aP2_Align ,
                                 string aP3_Icon ,
                                 short aP4_Opacity ,
                                 string aP5_BGColor ,
                                 string aP6_BGImageUrl ,
                                 string aP7_ActionObjectId ,
                                 string aP8_ActionObjectType ,
                                 string aP9_ActionObjectUrl ,
                                 out SdtSDT_MenuPage_RowsItem_TilesItem aP10_TilesItem )
      {
         this.AV9TileName = aP0_TileName;
         this.AV16TileColor = aP1_TileColor;
         this.AV14Align = aP2_Align;
         this.AV18Icon = aP3_Icon;
         this.AV15Opacity = aP4_Opacity;
         this.AV17BGColor = aP5_BGColor;
         this.AV10BGImageUrl = aP6_BGImageUrl;
         this.AV12ActionObjectId = aP7_ActionObjectId;
         this.AV13ActionObjectType = aP8_ActionObjectType;
         this.AV11ActionObjectUrl = aP9_ActionObjectUrl;
         this.AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context) ;
         SubmitImpl();
         aP10_TilesItem=this.AV8TilesItem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV8TilesItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         AV8TilesItem.gxTpr_Name = AV9TileName;
         AV8TilesItem.gxTpr_Text = AV9TileName;
         AV8TilesItem.gxTpr_Color = AV16TileColor;
         AV8TilesItem.gxTpr_Align = AV14Align;
         AV8TilesItem.gxTpr_Icon = AV18Icon;
         AV8TilesItem.gxTpr_Bgcolor = AV17BGColor;
         AV8TilesItem.gxTpr_Bgimageurl = AV10BGImageUrl;
         AV8TilesItem.gxTpr_Opacity = AV15Opacity;
         AV8TilesItem.gxTpr_Permissions = new();
         AV8TilesItem.gxTpr_Action.gxTpr_Objectid = AV12ActionObjectId;
         AV8TilesItem.gxTpr_Action.gxTpr_Objecttype = AV13ActionObjectType;
         AV8TilesItem.gxTpr_Action.gxTpr_Objecturl = AV11ActionObjectUrl;
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
         AV8TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private short AV15Opacity ;
      private string AV9TileName ;
      private string AV16TileColor ;
      private string AV14Align ;
      private string AV18Icon ;
      private string AV17BGColor ;
      private string AV10BGImageUrl ;
      private string AV12ActionObjectId ;
      private string AV13ActionObjectType ;
      private string AV11ActionObjectUrl ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV8TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem aP10_TilesItem ;
   }

}
