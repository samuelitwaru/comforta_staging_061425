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
   public class prc_pagesapi : GXProcedure
   {
      public prc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           string aP2_UserId ,
                           out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4UserId = aP2_UserId;
         this.AV5SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP3_SDT_PageCollection=this.AV5SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_MobilePage> executeUdp( Guid aP0_LocationId ,
                                                             Guid aP1_OrganisationId ,
                                                             string aP2_UserId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_UserId, out aP3_SDT_PageCollection);
         return AV5SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 string aP2_UserId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4UserId = aP2_UserId;
         this.AV5SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         SubmitImpl();
         aP3_SDT_PageCollection=this.AV5SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2LocationId,(Guid)AV3OrganisationId,(string)AV4UserId,(GXBaseCollection<SdtSDT_MobilePage>)AV5SDT_PageCollection} ;
         ClassLoader.Execute("aprc_pagesapi","GeneXus.Programs","aprc_pagesapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5SDT_PageCollection = (GXBaseCollection<SdtSDT_MobilePage>)(args[3]) ;
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
         AV5SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21");
         /* GeneXus formulas. */
      }

      private string AV4UserId ;
      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MobilePage> AV5SDT_PageCollection ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection ;
   }

}
