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
   public class prc_getnameinitials : GXProcedure
   {
      public prc_getnameinitials( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getnameinitials( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_GivenName ,
                           string aP1_LastName ,
                           out string aP2_Initials )
      {
         this.AV8GivenName = aP0_GivenName;
         this.AV9LastName = aP1_LastName;
         this.AV10Initials = "" ;
         initialize();
         ExecuteImpl();
         aP2_Initials=this.AV10Initials;
      }

      public string executeUdp( string aP0_GivenName ,
                                string aP1_LastName )
      {
         execute(aP0_GivenName, aP1_LastName, out aP2_Initials);
         return AV10Initials ;
      }

      public void executeSubmit( string aP0_GivenName ,
                                 string aP1_LastName ,
                                 out string aP2_Initials )
      {
         this.AV8GivenName = aP0_GivenName;
         this.AV9LastName = aP1_LastName;
         this.AV10Initials = "" ;
         SubmitImpl();
         aP2_Initials=this.AV10Initials;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Initials = StringUtil.CharAt( AV8GivenName, 1) + "" + StringUtil.CharAt( AV9LastName, 1);
         StringUtil.Upper( AV10Initials) ;
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
         AV10Initials = "";
         /* GeneXus formulas. */
      }

      private string AV10Initials ;
      private string AV8GivenName ;
      private string AV9LastName ;
      private string aP2_Initials ;
   }

}
