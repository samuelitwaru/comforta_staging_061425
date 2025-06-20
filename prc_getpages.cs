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
   public class prc_getpages : GXProcedure
   {
      public prc_getpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_getpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV2SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV3Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageCollection=this.AV2SDT_PageCollection;
         aP1_Error=this.AV3Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection )
      {
         execute(out aP0_SDT_PageCollection, out aP1_Error);
         return AV3Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV2SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV3Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageCollection=this.AV2SDT_PageCollection;
         aP1_Error=this.AV3Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBaseCollection<SdtSDT_Page>)AV2SDT_PageCollection,(SdtSDT_Error)AV3Error} ;
         ClassLoader.Execute("aprc_getpages","GeneXus.Programs","aprc_getpages", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2SDT_PageCollection = (GXBaseCollection<SdtSDT_Page>)(args[0]) ;
            AV3Error = (SdtSDT_Error)(args[1]) ;
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
         AV2SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV3Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Page> AV2SDT_PageCollection ;
      private SdtSDT_Error AV3Error ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      private SdtSDT_Error aP1_Error ;
   }

}
