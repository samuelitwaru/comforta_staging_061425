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
   public class prc_appdebug : GXProcedure
   {
      public prc_appdebug( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_appdebug( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                           out SdtSDT_AppDebugResults aP1_DebugResults ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV17PageUrlList = aP0_PageUrlList;
         this.AV11DebugResults = new SdtSDT_AppDebugResults(context) ;
         this.AV12Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_DebugResults=this.AV11DebugResults;
         aP2_Error=this.AV12Error;
      }

      public SdtSDT_Error executeUdp( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                                      out SdtSDT_AppDebugResults aP1_DebugResults )
      {
         execute(aP0_PageUrlList, out aP1_DebugResults, out aP2_Error);
         return AV12Error ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                                 out SdtSDT_AppDebugResults aP1_DebugResults ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV17PageUrlList = aP0_PageUrlList;
         this.AV11DebugResults = new SdtSDT_AppDebugResults(context) ;
         this.AV12Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_DebugResults=this.AV11DebugResults;
         aP2_Error=this.AV12Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV17PageUrlList.Count )
         {
            AV15pageUrl = ((SdtSDT_PageUrl)AV17PageUrlList.Item(AV26GXV1));
            AV14PageItem = new SdtSDT_AppDebugResults_PagesItem(context);
            AV14PageItem.gxTpr_Page = AV15pageUrl.gxTpr_Page;
            AV21UrlCheckItems.Clear();
            AV27GXV2 = 1;
            while ( AV27GXV2 <= AV15pageUrl.gxTpr_Urls.Count )
            {
               AV16pageUrlItem = ((SdtSDT_PageUrl_UrlsItem)AV15pageUrl.gxTpr_Urls.Item(AV27GXV2));
               AV9urlCheckItem = new SdtUrlCheckItem(context);
               AV9urlCheckItem.gxTpr_Url = AV16pageUrlItem.gxTpr_Url;
               AV9urlCheckItem.gxTpr_Affectedtype = AV16pageUrlItem.gxTpr_Affectedtype;
               AV9urlCheckItem.gxTpr_Affectedname = AV16pageUrlItem.gxTpr_Affectedname;
               AV21UrlCheckItems.Add(AV9urlCheckItem, 0);
               AV27GXV2 = (int)(AV27GXV2+1);
            }
            AV25UrlStatuses = AV8UrlChecker.checkurls(AV21UrlCheckItems);
            AV19Summary = AV8UrlChecker.getsummary();
            AV11DebugResults.gxTpr_Summary.gxTpr_Totalurls = (decimal)(AV11DebugResults.gxTpr_Summary.gxTpr_Totalurls+(AV19Summary.gxTpr_Totalurls));
            AV11DebugResults.gxTpr_Summary.gxTpr_Successcount = (decimal)(AV11DebugResults.gxTpr_Summary.gxTpr_Successcount+(AV19Summary.gxTpr_Totalsuccess));
            AV11DebugResults.gxTpr_Summary.gxTpr_Failurecount = (decimal)(AV11DebugResults.gxTpr_Summary.gxTpr_Failurecount+(AV19Summary.gxTpr_Totalfailed));
            AV28GXV3 = 1;
            while ( AV28GXV3 <= AV25UrlStatuses.Count )
            {
               AV24UrlStatus = ((SdtUrlStatus)AV25UrlStatuses.Item(AV28GXV3));
               AV23UrlListItem = new SdtSDT_AppDebugResults_PagesItem_UrlListItem(context);
               AV23UrlListItem.gxTpr_Url = AV24UrlStatus.gxTpr_Url;
               AV23UrlListItem.gxTpr_Statuscode = StringUtil.Trim( StringUtil.Str( (decimal)(AV24UrlStatus.gxTpr_Statuscode), 9, 0));
               AV23UrlListItem.gxTpr_Statusmessage = AV24UrlStatus.gxTpr_Message;
               AV23UrlListItem.gxTpr_Affectedtype = AV24UrlStatus.gxTpr_Affectedtype;
               AV23UrlListItem.gxTpr_Affectedname = AV24UrlStatus.gxTpr_Affectedname;
               AV14PageItem.gxTpr_Urllist.Add(AV23UrlListItem, 0);
               AV28GXV3 = (int)(AV28GXV3+1);
            }
            AV11DebugResults.gxTpr_Pages.Add(AV14PageItem, 0);
            AV26GXV1 = (int)(AV26GXV1+1);
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
         AV11DebugResults = new SdtSDT_AppDebugResults(context);
         AV12Error = new SdtSDT_Error(context);
         AV15pageUrl = new SdtSDT_PageUrl(context);
         AV14PageItem = new SdtSDT_AppDebugResults_PagesItem(context);
         AV21UrlCheckItems = new GXExternalCollection<SdtUrlCheckItem>( context, "SdtUrlCheckItem", "GeneXus.Programs");
         AV16pageUrlItem = new SdtSDT_PageUrl_UrlsItem(context);
         AV9urlCheckItem = new SdtUrlCheckItem(context);
         AV25UrlStatuses = new GXExternalCollection<SdtUrlStatus>( context, "SdtUrlStatus", "GeneXus.Programs");
         AV8UrlChecker = new SdtUrlChecker(context);
         AV19Summary = new SdtSummary(context);
         AV24UrlStatus = new SdtUrlStatus(context);
         AV23UrlListItem = new SdtSDT_AppDebugResults_PagesItem_UrlListItem(context);
         /* GeneXus formulas. */
      }

      private int AV26GXV1 ;
      private int AV27GXV2 ;
      private int AV28GXV3 ;
      private GXBaseCollection<SdtSDT_PageUrl> AV17PageUrlList ;
      private SdtSDT_AppDebugResults AV11DebugResults ;
      private SdtSDT_Error AV12Error ;
      private SdtSDT_PageUrl AV15pageUrl ;
      private SdtSDT_AppDebugResults_PagesItem AV14PageItem ;
      private GXExternalCollection<SdtUrlCheckItem> AV21UrlCheckItems ;
      private SdtSDT_PageUrl_UrlsItem AV16pageUrlItem ;
      private SdtUrlCheckItem AV9urlCheckItem ;
      private GXExternalCollection<SdtUrlStatus> AV25UrlStatuses ;
      private SdtUrlChecker AV8UrlChecker ;
      private SdtSummary AV19Summary ;
      private SdtUrlStatus AV24UrlStatus ;
      private SdtSDT_AppDebugResults_PagesItem_UrlListItem AV23UrlListItem ;
      private SdtSDT_AppDebugResults aP1_DebugResults ;
      private SdtSDT_Error aP2_Error ;
   }

}
