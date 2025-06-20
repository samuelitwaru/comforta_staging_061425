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
   public class prc_listpages : GXProcedure
   {
      public prc_listpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_listpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV2SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV3Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageStructureCollection=this.AV2SDT_PageStructureCollection;
         aP1_Error=this.AV3Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection )
      {
         execute(out aP0_SDT_PageStructureCollection, out aP1_Error);
         return AV3Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV2SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV3Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageStructureCollection=this.AV2SDT_PageStructureCollection;
         aP1_Error=this.AV3Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBaseCollection<SdtSDT_PageStructure>)AV2SDT_PageStructureCollection,(SdtSDT_Error)AV3Error} ;
         ClassLoader.Execute("aprc_listpages","GeneXus.Programs","aprc_listpages", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2SDT_PageStructureCollection = (GXBaseCollection<SdtSDT_PageStructure>)(args[0]) ;
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
         AV2SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV3Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV2SDT_PageStructureCollection ;
      private SdtSDT_Error AV3Error ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      private SdtSDT_Error aP1_Error ;
   }

}
