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
   public class prc_uploadlogo : GXProcedure
   {
      public prc_uploadlogo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_uploadlogo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_LogoUrl ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV2LogoUrl = aP0_LogoUrl;
         this.AV3Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Error=this.AV3Error;
      }

      public SdtSDT_Error executeUdp( string aP0_LogoUrl )
      {
         execute(aP0_LogoUrl, out aP1_Error);
         return AV3Error ;
      }

      public void executeSubmit( string aP0_LogoUrl ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV2LogoUrl = aP0_LogoUrl;
         this.AV3Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Error=this.AV3Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2LogoUrl,(SdtSDT_Error)AV3Error} ;
         ClassLoader.Execute("aprc_uploadlogo","GeneXus.Programs","aprc_uploadlogo", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
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
         AV3Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private string AV2LogoUrl ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV3Error ;
      private Object[] args ;
      private SdtSDT_Error aP1_Error ;
   }

}
