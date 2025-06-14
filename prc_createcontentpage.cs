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
   public class prc_createcontentpage : GXProcedure
   {
      public prc_createcontentpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_createcontentpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           out string aP1_Response ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3Response = "" ;
         this.AV4Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV3Response;
         aP2_Error=this.AV4Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_PageId ,
                                      out string aP1_Response )
      {
         execute(aP0_PageId, out aP1_Response, out aP2_Error);
         return AV4Error ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 out string aP1_Response ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3Response = "" ;
         this.AV4Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Response=this.AV3Response;
         aP2_Error=this.AV4Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2PageId,(string)AV3Response,(SdtSDT_Error)AV4Error} ;
         ClassLoader.Execute("aprc_createcontentpage","GeneXus.Programs","aprc_createcontentpage", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3Response = (string)(args[1]) ;
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
         AV3Response = "";
         AV4Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private string AV3Response ;
      private Guid AV2PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV4Error ;
      private Object[] args ;
      private string aP1_Response ;
      private SdtSDT_Error aP2_Error ;
   }

}
