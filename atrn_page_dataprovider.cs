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
   public class atrn_page_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_page_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_Page> aP0_Gxm1rootcol = new GXBCCollection<SdtTrn_Page>()  ;
         execute(out aP0_Gxm1rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public atrn_page_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_page_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_Page> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtTrn_Page>( context, "Trn_Page", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<SdtTrn_Page> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_Page> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtTrn_Page>( context, "Trn_Page", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Page> Gxm1rootcol ;
      private GXBCCollection<SdtTrn_Page> aP0_Gxm1rootcol ;
   }

}
