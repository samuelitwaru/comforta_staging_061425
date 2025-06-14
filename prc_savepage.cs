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
   public class prc_savepage : GXProcedure
   {
      public prc_savepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_savepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           string aP1_PageJsonContent ,
                           string aP2_PageGJSHtml ,
                           string aP3_PageGJSJson ,
                           SdtSDT_Page aP4_SDT_Page ,
                           ref string aP5_Reponse )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3PageJsonContent = aP1_PageJsonContent;
         this.AV4PageGJSHtml = aP2_PageGJSHtml;
         this.AV5PageGJSJson = aP3_PageGJSJson;
         this.AV6SDT_Page = aP4_SDT_Page;
         this.AV7Reponse = aP5_Reponse;
         initialize();
         ExecuteImpl();
         aP5_Reponse=this.AV7Reponse;
      }

      public string executeUdp( Guid aP0_PageId ,
                                string aP1_PageJsonContent ,
                                string aP2_PageGJSHtml ,
                                string aP3_PageGJSJson ,
                                SdtSDT_Page aP4_SDT_Page )
      {
         execute(aP0_PageId, aP1_PageJsonContent, aP2_PageGJSHtml, aP3_PageGJSJson, aP4_SDT_Page, ref aP5_Reponse);
         return AV7Reponse ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 ref string aP5_Reponse )
      {
         this.AV2PageId = aP0_PageId;
         this.AV3PageJsonContent = aP1_PageJsonContent;
         this.AV4PageGJSHtml = aP2_PageGJSHtml;
         this.AV5PageGJSJson = aP3_PageGJSJson;
         this.AV6SDT_Page = aP4_SDT_Page;
         this.AV7Reponse = aP5_Reponse;
         SubmitImpl();
         aP5_Reponse=this.AV7Reponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2PageId,(string)AV3PageJsonContent,(string)AV4PageGJSHtml,(string)AV5PageGJSJson,(SdtSDT_Page)AV6SDT_Page,(string)AV7Reponse} ;
         ClassLoader.Execute("aprc_savepage","GeneXus.Programs","aprc_savepage", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV7Reponse = (string)(args[5]) ;
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
         /* GeneXus formulas. */
      }

      private string AV3PageJsonContent ;
      private string AV4PageGJSHtml ;
      private string AV5PageGJSJson ;
      private string AV7Reponse ;
      private Guid AV2PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV6SDT_Page ;
      private string aP5_Reponse ;
      private Object[] args ;
   }

}
