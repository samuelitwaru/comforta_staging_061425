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
   public class prc_uploadmedia : GXProcedure
   {
      public prc_uploadmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_uploadmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MediaName ,
                           string aP1_MediaImageData ,
                           int aP2_MediaSize ,
                           string aP3_MediaType ,
                           out SdtTrn_Media aP4_BC_Trn_Media ,
                           out SdtSDT_Error aP5_Error )
      {
         this.AV2MediaName = aP0_MediaName;
         this.AV3MediaImageData = aP1_MediaImageData;
         this.AV4MediaSize = aP2_MediaSize;
         this.AV5MediaType = aP3_MediaType;
         this.AV6BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV7Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_BC_Trn_Media=this.AV6BC_Trn_Media;
         aP5_Error=this.AV7Error;
      }

      public SdtSDT_Error executeUdp( string aP0_MediaName ,
                                      string aP1_MediaImageData ,
                                      int aP2_MediaSize ,
                                      string aP3_MediaType ,
                                      out SdtTrn_Media aP4_BC_Trn_Media )
      {
         execute(aP0_MediaName, aP1_MediaImageData, aP2_MediaSize, aP3_MediaType, out aP4_BC_Trn_Media, out aP5_Error);
         return AV7Error ;
      }

      public void executeSubmit( string aP0_MediaName ,
                                 string aP1_MediaImageData ,
                                 int aP2_MediaSize ,
                                 string aP3_MediaType ,
                                 out SdtTrn_Media aP4_BC_Trn_Media ,
                                 out SdtSDT_Error aP5_Error )
      {
         this.AV2MediaName = aP0_MediaName;
         this.AV3MediaImageData = aP1_MediaImageData;
         this.AV4MediaSize = aP2_MediaSize;
         this.AV5MediaType = aP3_MediaType;
         this.AV6BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV7Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_BC_Trn_Media=this.AV6BC_Trn_Media;
         aP5_Error=this.AV7Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2MediaName,(string)AV3MediaImageData,(int)AV4MediaSize,(string)AV5MediaType,(SdtTrn_Media)AV6BC_Trn_Media,(SdtSDT_Error)AV7Error} ;
         ClassLoader.Execute("aprc_uploadmedia","GeneXus.Programs","aprc_uploadmedia", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV6BC_Trn_Media = (SdtTrn_Media)(args[4]) ;
            AV7Error = (SdtSDT_Error)(args[5]) ;
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
         AV6BC_Trn_Media = new SdtTrn_Media(context);
         AV7Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private int AV4MediaSize ;
      private string AV5MediaType ;
      private string AV3MediaImageData ;
      private string AV2MediaName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Media AV6BC_Trn_Media ;
      private SdtSDT_Error AV7Error ;
      private Object[] args ;
      private SdtTrn_Media aP4_BC_Trn_Media ;
      private SdtSDT_Error aP5_Error ;
   }

}
