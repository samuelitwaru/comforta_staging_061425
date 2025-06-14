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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_dynamicformapi : GXProcedure
   {
      public prc_dynamicformapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_dynamicformapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_DynamicFormLink )
      {
         this.AV8DynamicFormLink = "" ;
         initialize();
         ExecuteImpl();
         aP0_DynamicFormLink=this.AV8DynamicFormLink;
      }

      public string executeUdp( )
      {
         execute(out aP0_DynamicFormLink);
         return AV8DynamicFormLink ;
      }

      public void executeSubmit( out string aP0_DynamicFormLink )
      {
         this.AV8DynamicFormLink = "" ;
         SubmitImpl();
         aP0_DynamicFormLink=this.AV8DynamicFormLink;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8DynamicFormLink = context.GetMessage( "https://staging.comforta.yukon.software/wp_residentdynamicform.aspx", "");
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
         AV8DynamicFormLink = "";
         /* GeneXus formulas. */
      }

      private string AV8DynamicFormLink ;
      private string aP0_DynamicFormLink ;
   }

}
