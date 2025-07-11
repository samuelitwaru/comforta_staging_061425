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
   public class prc_convertpageid : GXProcedure
   {
      public prc_convertpageid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertpageid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_OldId ,
                           Guid aP1_NewId ,
                           ref SdtTrn_AppVersion aP2_Trn_AppVersion )
      {
         this.AV11OldId = aP0_OldId;
         this.AV12NewId = aP1_NewId;
         this.AV13Trn_AppVersion = aP2_Trn_AppVersion;
         initialize();
         ExecuteImpl();
         aP2_Trn_AppVersion=this.AV13Trn_AppVersion;
      }

      public SdtTrn_AppVersion executeUdp( Guid aP0_OldId ,
                                           Guid aP1_NewId )
      {
         execute(aP0_OldId, aP1_NewId, ref aP2_Trn_AppVersion);
         return AV13Trn_AppVersion ;
      }

      public void executeSubmit( Guid aP0_OldId ,
                                 Guid aP1_NewId ,
                                 ref SdtTrn_AppVersion aP2_Trn_AppVersion )
      {
         this.AV11OldId = aP0_OldId;
         this.AV12NewId = aP1_NewId;
         this.AV13Trn_AppVersion = aP2_Trn_AppVersion;
         SubmitImpl();
         aP2_Trn_AppVersion=this.AV13Trn_AppVersion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV13Trn_AppVersion.gxTpr_Page.Count )
         {
            AV8TrnAppVersionPage = ((SdtTrn_AppVersion_Page)AV13Trn_AppVersion.gxTpr_Page.Item(AV16GXV1));
            if ( StringUtil.StrCmp(AV8TrnAppVersionPage.gxTpr_Pagetype, "Information") == 0 )
            {
               AV9SDT_InfoContent = new SdtSDT_InfoContent(context);
               AV9SDT_InfoContent.FromJSonString(AV8TrnAppVersionPage.gxTpr_Pagestructure, null);
               AV17GXV2 = 1;
               while ( AV17GXV2 <= AV9SDT_InfoContent.gxTpr_Infocontent.Count )
               {
                  AV14SDT_InfoContentItem = ((SdtSDT_InfoContent_InfoContentItem)AV9SDT_InfoContent.gxTpr_Infocontent.Item(AV17GXV2));
                  if ( StringUtil.StrCmp(AV14SDT_InfoContentItem.gxTpr_Infotype, "TileGrid") == 0 )
                  {
                     AV18GXV3 = 1;
                     while ( AV18GXV3 <= AV14SDT_InfoContentItem.gxTpr_Columns.Count )
                     {
                        AV15column = ((SdtSDT_InfoContent_InfoContentItem_ColumnsItem)AV14SDT_InfoContentItem.gxTpr_Columns.Item(AV18GXV3));
                        AV19GXV4 = 1;
                        while ( AV19GXV4 <= AV15column.gxTpr_Tiles.Count )
                        {
                           AV10SDT_InfoTileItem = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV15column.gxTpr_Tiles.Item(AV19GXV4));
                           if ( StringUtil.StrCmp(AV10SDT_InfoTileItem.gxTpr_Action.gxTpr_Objectid, AV11OldId.ToString()) == 0 )
                           {
                              AV10SDT_InfoTileItem.gxTpr_Action.gxTpr_Objectid = AV12NewId.ToString();
                           }
                           AV19GXV4 = (int)(AV19GXV4+1);
                        }
                        AV18GXV3 = (int)(AV18GXV3+1);
                     }
                  }
                  AV17GXV2 = (int)(AV17GXV2+1);
               }
               AV8TrnAppVersionPage.gxTpr_Pagestructure = AV9SDT_InfoContent.ToJSonString(false, true);
            }
            AV16GXV1 = (int)(AV16GXV1+1);
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
         AV8TrnAppVersionPage = new SdtTrn_AppVersion_Page(context);
         AV9SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV14SDT_InfoContentItem = new SdtSDT_InfoContent_InfoContentItem(context);
         AV15column = new SdtSDT_InfoContent_InfoContentItem_ColumnsItem(context);
         AV10SDT_InfoTileItem = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         /* GeneXus formulas. */
      }

      private int AV16GXV1 ;
      private int AV17GXV2 ;
      private int AV18GXV3 ;
      private int AV19GXV4 ;
      private Guid AV11OldId ;
      private Guid AV12NewId ;
      private SdtTrn_AppVersion AV13Trn_AppVersion ;
      private SdtTrn_AppVersion aP2_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV8TrnAppVersionPage ;
      private SdtSDT_InfoContent AV9SDT_InfoContent ;
      private SdtSDT_InfoContent_InfoContentItem AV14SDT_InfoContentItem ;
      private SdtSDT_InfoContent_InfoContentItem_ColumnsItem AV15column ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV10SDT_InfoTileItem ;
   }

}
