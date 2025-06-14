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
   public class prc_createdynamicformpage : GXProcedure
   {
      public prc_createdynamicformpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_createdynamicformpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_FormId ,
                           string aP1_PageName ,
                           out SdtSDT_Page aP2_SDT_Page ,
                           out SdtSDT_Error aP3_Error )
      {
         this.AV2FormId = aP0_FormId;
         this.AV3PageName = aP1_PageName;
         this.AV4SDT_Page = new SdtSDT_Page(context) ;
         this.AV5Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Page=this.AV4SDT_Page;
         aP3_Error=this.AV5Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_FormId ,
                                      string aP1_PageName ,
                                      out SdtSDT_Page aP2_SDT_Page )
      {
         execute(aP0_FormId, aP1_PageName, out aP2_SDT_Page, out aP3_Error);
         return AV5Error ;
      }

      public void executeSubmit( Guid aP0_FormId ,
                                 string aP1_PageName ,
                                 out SdtSDT_Page aP2_SDT_Page ,
                                 out SdtSDT_Error aP3_Error )
      {
         this.AV2FormId = aP0_FormId;
         this.AV3PageName = aP1_PageName;
         this.AV4SDT_Page = new SdtSDT_Page(context) ;
         this.AV5Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Page=this.AV4SDT_Page;
         aP3_Error=this.AV5Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2FormId,(string)AV3PageName,(SdtSDT_Page)AV4SDT_Page,(SdtSDT_Error)AV5Error} ;
         ClassLoader.Execute("aprc_createdynamicformpage","GeneXus.Programs","aprc_createdynamicformpage", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV4SDT_Page = (SdtSDT_Page)(args[2]) ;
            AV5Error = (SdtSDT_Error)(args[3]) ;
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
         AV4SDT_Page = new SdtSDT_Page(context);
         AV5Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private string AV3PageName ;
      private Guid AV2FormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV4SDT_Page ;
      private SdtSDT_Error AV5Error ;
      private Object[] args ;
      private SdtSDT_Page aP2_SDT_Page ;
      private SdtSDT_Error aP3_Error ;
   }

}
