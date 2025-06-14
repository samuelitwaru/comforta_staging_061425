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
   public class prc_applicationdesign : GXProcedure
   {
      public prc_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Trn_PageName ,
                           out SdtSDT_Page aP1_SDT_Page ,
                           out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV2Trn_PageName = aP0_Trn_PageName;
         this.AV3SDT_Page = new SdtSDT_Page(context) ;
         this.AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV3SDT_Page;
         aP2_SDT_PageCollection=this.AV4SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_Page> executeUdp( string aP0_Trn_PageName ,
                                                       out SdtSDT_Page aP1_SDT_Page )
      {
         execute(aP0_Trn_PageName, out aP1_SDT_Page, out aP2_SDT_PageCollection);
         return AV4SDT_PageCollection ;
      }

      public void executeSubmit( string aP0_Trn_PageName ,
                                 out SdtSDT_Page aP1_SDT_Page ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV2Trn_PageName = aP0_Trn_PageName;
         this.AV3SDT_Page = new SdtSDT_Page(context) ;
         this.AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version21") ;
         SubmitImpl();
         aP1_SDT_Page=this.AV3SDT_Page;
         aP2_SDT_PageCollection=this.AV4SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2Trn_PageName,(SdtSDT_Page)AV3SDT_Page,(GXBaseCollection<SdtSDT_Page>)AV4SDT_PageCollection} ;
         ClassLoader.Execute("aprc_applicationdesign","GeneXus.Programs","aprc_applicationdesign", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3SDT_Page = (SdtSDT_Page)(args[1]) ;
            AV4SDT_PageCollection = (GXBaseCollection<SdtSDT_Page>)(args[2]) ;
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
         AV3SDT_Page = new SdtSDT_Page(context);
         AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version21");
         /* GeneXus formulas. */
      }

      private string AV2Trn_PageName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV3SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> AV4SDT_PageCollection ;
      private Object[] args ;
      private SdtSDT_Page aP1_SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
   }

}
