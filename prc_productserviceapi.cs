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
   public class prc_productserviceapi : GXProcedure
   {
      public prc_productserviceapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_productserviceapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           out SdtSDT_ProductService aP1_SDT_ProductService ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV2ProductServiceId = aP0_ProductServiceId;
         this.AV3SDT_ProductService = new SdtSDT_ProductService(context) ;
         this.AV4Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_ProductService=this.AV3SDT_ProductService;
         aP2_Error=this.AV4Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_ProductServiceId ,
                                      out SdtSDT_ProductService aP1_SDT_ProductService )
      {
         execute(aP0_ProductServiceId, out aP1_SDT_ProductService, out aP2_Error);
         return AV4Error ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 out SdtSDT_ProductService aP1_SDT_ProductService ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV2ProductServiceId = aP0_ProductServiceId;
         this.AV3SDT_ProductService = new SdtSDT_ProductService(context) ;
         this.AV4Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_ProductService=this.AV3SDT_ProductService;
         aP2_Error=this.AV4Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2ProductServiceId,(SdtSDT_ProductService)AV3SDT_ProductService,(SdtSDT_Error)AV4Error} ;
         ClassLoader.Execute("aprc_productserviceapi","GeneXus.Programs","aprc_productserviceapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3SDT_ProductService = (SdtSDT_ProductService)(args[1]) ;
            AV4Error = (SdtSDT_Error)(args[2]) ;
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
         AV3SDT_ProductService = new SdtSDT_ProductService(context);
         AV4Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private Guid AV2ProductServiceId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ProductService AV3SDT_ProductService ;
      private SdtSDT_Error AV4Error ;
      private Object[] args ;
      private SdtSDT_ProductService aP1_SDT_ProductService ;
      private SdtSDT_Error aP2_Error ;
   }

}
