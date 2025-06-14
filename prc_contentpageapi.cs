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
   public class prc_contentpageapi : GXProcedure
   {
      public prc_contentpageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_contentpageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           out SdtSDT_ContentPageV1 aP3_SDT_ContentPage )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3LocationId = aP1_LocationId;
         this.AV4OrganisationId = aP2_OrganisationId;
         this.AV5SDT_ContentPage = new SdtSDT_ContentPageV1(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_ContentPage=this.AV5SDT_ContentPage;
      }

      public SdtSDT_ContentPageV1 executeUdp( Guid aP0_PageId ,
                                              Guid aP1_LocationId ,
                                              Guid aP2_OrganisationId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, out aP3_SDT_ContentPage);
         return AV5SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_ContentPageV1 aP3_SDT_ContentPage )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3LocationId = aP1_LocationId;
         this.AV4OrganisationId = aP2_OrganisationId;
         this.AV5SDT_ContentPage = new SdtSDT_ContentPageV1(context) ;
         SubmitImpl();
         aP3_SDT_ContentPage=this.AV5SDT_ContentPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2PageId,(Guid)AV3LocationId,(Guid)AV4OrganisationId,(SdtSDT_ContentPageV1)AV5SDT_ContentPage} ;
         ClassLoader.Execute("aprc_contentpageapi","GeneXus.Programs","aprc_contentpageapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5SDT_ContentPage = (SdtSDT_ContentPageV1)(args[3]) ;
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
      }

      public override void initialize( )
      {
         AV5SDT_ContentPage = new SdtSDT_ContentPageV1(context);
         /* GeneXus formulas. */
      }

      private Guid AV2PageId ;
      private Guid AV3LocationId ;
      private Guid AV4OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPageV1 AV5SDT_ContentPage ;
      private Object[] args ;
      private SdtSDT_ContentPageV1 aP3_SDT_ContentPage ;
   }

}
