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
   public class prc_contentpagesapi : GXProcedure
   {
      public prc_contentpagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_contentpagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_ContentPageCollection=this.AV4SDT_ContentPageCollection;
      }

      public GXBaseCollection<SdtSDT_ContentPage> executeUdp( Guid aP0_LocationId ,
                                                              Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_ContentPageCollection);
         return AV4SDT_ContentPageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         SubmitImpl();
         aP2_SDT_ContentPageCollection=this.AV4SDT_ContentPageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2LocationId,(Guid)AV3OrganisationId,(GXBaseCollection<SdtSDT_ContentPage>)AV4SDT_ContentPageCollection} ;
         ClassLoader.Execute("aprc_contentpagesapi","GeneXus.Programs","aprc_contentpagesapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4SDT_ContentPageCollection = (GXBaseCollection<SdtSDT_ContentPage>)(args[2]) ;
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
         AV4SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21");
         /* GeneXus formulas. */
      }

      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ContentPage> AV4SDT_ContentPageCollection ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
   }

}
