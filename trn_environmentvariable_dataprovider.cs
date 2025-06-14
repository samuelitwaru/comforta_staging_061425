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
   public class trn_environmentvariable_dataprovider : GXProcedure
   {
      public trn_environmentvariable_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public trn_environmentvariable_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtTrn_EnvironmentVariable> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtTrn_EnvironmentVariable>( context, "Trn_EnvironmentVariable", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtTrn_EnvironmentVariable> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_EnvironmentVariable> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtTrn_EnvironmentVariable>( context, "Trn_EnvironmentVariable", "Comforta_version21") ;
         SubmitImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBCCollection<SdtTrn_EnvironmentVariable>)AV2ReturnValue} ;
         ClassLoader.Execute("atrn_environmentvariable_dataprovider","GeneXus.Programs","atrn_environmentvariable_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtTrn_EnvironmentVariable>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<SdtTrn_EnvironmentVariable>( context, "Trn_EnvironmentVariable", "Comforta_version21");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtTrn_EnvironmentVariable> AV2ReturnValue ;
      private Object[] args ;
      private GXBCCollection<SdtTrn_EnvironmentVariable> aP0_ReturnValue ;
   }

}
