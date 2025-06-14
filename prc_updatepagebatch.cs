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
   public class prc_updatepagebatch : GXProcedure
   {
      public prc_updatepagebatch( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatepagebatch( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                           ref bool aP1_IsNotifyResidents ,
                           out string aP2_Response ,
                           out SdtSDT_Error aP3_Error )
      {
         this.AV25PagesList = aP0_PagesList;
         this.AV11IsNotifyResidents = aP1_IsNotifyResidents;
         this.AV27Response = "" ;
         this.AV10Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_PagesList=this.AV25PagesList;
         aP1_IsNotifyResidents=this.AV11IsNotifyResidents;
         aP2_Response=this.AV27Response;
         aP3_Error=this.AV10Error;
      }

      public SdtSDT_Error executeUdp( ref GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                      ref bool aP1_IsNotifyResidents ,
                                      out string aP2_Response )
      {
         execute(ref aP0_PagesList, ref aP1_IsNotifyResidents, out aP2_Response, out aP3_Error);
         return AV10Error ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                 ref bool aP1_IsNotifyResidents ,
                                 out string aP2_Response ,
                                 out SdtSDT_Error aP3_Error )
      {
         this.AV25PagesList = aP0_PagesList;
         this.AV11IsNotifyResidents = aP1_IsNotifyResidents;
         this.AV27Response = "" ;
         this.AV10Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_PagesList=this.AV25PagesList;
         aP1_IsNotifyResidents=this.AV11IsNotifyResidents;
         aP2_Response=this.AV27Response;
         aP3_Error=this.AV10Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV10Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV10Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV30GXV1 = 1;
            while ( AV30GXV1 <= AV25PagesList.Count )
            {
               AV28SDT_Page = ((SdtSDT_PublishPage)AV25PagesList.Item(AV30GXV1));
               AV9BC_Trn_Page.Load(AV28SDT_Page.gxTpr_Pageid, new prc_getuserlocationid(context).executeUdp( ));
               if ( ! (Guid.Empty==AV9BC_Trn_Page.gxTpr_Trn_pageid) )
               {
                  if ( AV9BC_Trn_Page.gxTpr_Pageisdynamicform || AV9BC_Trn_Page.gxTpr_Pageisweblinkpage )
                  {
                     AV9BC_Trn_Page.gxTpr_Pagegjsjson = "";
                  }
                  else
                  {
                     AV9BC_Trn_Page.gxTpr_Pagegjsjson = AV28SDT_Page.gxTpr_Pagegjsjson;
                  }
                  if ( AV28SDT_Page.gxTpr_Pageispublished )
                  {
                     AV9BC_Trn_Page.gxTpr_Pagejsoncontent = AV28SDT_Page.gxTpr_Pagejsoncontent;
                     AV9BC_Trn_Page.gxTpr_Pageispublished = AV28SDT_Page.gxTpr_Pageispublished;
                  }
                  AV9BC_Trn_Page.gxTpr_Pagegjshtml = AV28SDT_Page.gxTpr_Pagegjshtml;
                  AV9BC_Trn_Page.Save();
                  AV15MetadataToolboxDetails = new SdtSDT_OneSignalCustomData_toolboxDetailsItem(context);
                  AV15MetadataToolboxDetails.gxTpr_Pageid = AV28SDT_Page.gxTpr_Pageid;
                  AV15MetadataToolboxDetails.gxTpr_Pagename = AV28SDT_Page.gxTpr_Pagename;
                  AV14Metadata.gxTpr_Toolboxdetails.Add(AV15MetadataToolboxDetails, 0);
               }
               else
               {
                  AV27Response = context.GetMessage( "Page Not Found", "");
               }
               AV30GXV1 = (int)(AV30GXV1+1);
            }
            if ( AV9BC_Trn_Page.Success() )
            {
               AV27Response = context.GetMessage( "Pages Save Successfully", "");
               if ( AV11IsNotifyResidents )
               {
                  AV8Title = context.GetMessage( "New Updates Available", "");
                  AV16NotificationMessage = context.GetMessage( "The latest updates have been published and are now live! Open the app to explore the changes", "");
                  AV14Metadata.gxTpr_Notificationcategory = "Toolbox";
                  new prc_sendresidentnotification(context ).execute(  AV8Title,  AV16NotificationMessage,  "Toolbox",  AV14Metadata,  AV26ResidentIdCollectionEmpty) ;
               }
            }
            else
            {
               AV32GXV3 = 1;
               AV31GXV2 = AV9BC_Trn_Page.GetMessages();
               while ( AV32GXV3 <= AV31GXV2.Count )
               {
                  AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV31GXV2.Item(AV32GXV3));
                  AV10Error.gxTpr_Message = AV13Message.gxTpr_Description;
                  new prc_logtofile(context ).execute(  AV13Message.gxTpr_Description) ;
                  AV32GXV3 = (int)(AV32GXV3+1);
               }
            }
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
         AV27Response = "";
         AV10Error = new SdtSDT_Error(context);
         AV28SDT_Page = new SdtSDT_PublishPage(context);
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         AV15MetadataToolboxDetails = new SdtSDT_OneSignalCustomData_toolboxDetailsItem(context);
         AV14Metadata = new SdtSDT_OneSignalCustomData(context);
         AV8Title = "";
         AV16NotificationMessage = "";
         AV26ResidentIdCollectionEmpty = new GxSimpleCollection<Guid>();
         AV31GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV30GXV1 ;
      private int AV32GXV3 ;
      private bool AV11IsNotifyResidents ;
      private string AV27Response ;
      private string AV8Title ;
      private string AV16NotificationMessage ;
      private GXBaseCollection<SdtSDT_PublishPage> AV25PagesList ;
      private GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ;
      private bool aP1_IsNotifyResidents ;
      private SdtSDT_Error AV10Error ;
      private SdtSDT_PublishPage AV28SDT_Page ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private SdtSDT_OneSignalCustomData_toolboxDetailsItem AV15MetadataToolboxDetails ;
      private SdtSDT_OneSignalCustomData AV14Metadata ;
      private GxSimpleCollection<Guid> AV26ResidentIdCollectionEmpty ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private string aP2_Response ;
      private SdtSDT_Error aP3_Error ;
   }

}
