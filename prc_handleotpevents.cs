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
   public class prc_handleotpevents : GXProcedure
   {
      public prc_handleotpevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_handleotpevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventName ,
                           string aP1_JsonIN ,
                           out string aP2_JsonOUT )
      {
         this.AV2EventName = aP0_EventName;
         this.AV3JsonIN = aP1_JsonIN;
         this.AV4JsonOUT = "" ;
         initialize();
         ExecuteImpl();
         aP2_JsonOUT=this.AV4JsonOUT;
      }

      public string executeUdp( string aP0_EventName ,
                                string aP1_JsonIN )
      {
         execute(aP0_EventName, aP1_JsonIN, out aP2_JsonOUT);
         return AV4JsonOUT ;
      }

      public void executeSubmit( string aP0_EventName ,
                                 string aP1_JsonIN ,
                                 out string aP2_JsonOUT )
      {
         this.AV2EventName = aP0_EventName;
         this.AV3JsonIN = aP1_JsonIN;
         this.AV4JsonOUT = "" ;
         SubmitImpl();
         aP2_JsonOUT=this.AV4JsonOUT;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2EventName,(string)AV3JsonIN,(string)AV4JsonOUT} ;
         ClassLoader.Execute("aprc_handleotpevents","GeneXus.Programs","aprc_handleotpevents", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4JsonOUT = (string)(args[2]) ;
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
         AV4JsonOUT = "";
         /* GeneXus formulas. */
      }

      private string AV3JsonIN ;
      private string AV4JsonOUT ;
      private string AV2EventName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP2_JsonOUT ;
   }

}
