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
   public class prc_logtoserver : GXProcedure
   {
      public prc_logtoserver( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_logtoserver( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Message )
      {
         this.AV8Message = aP0_Message;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_Message )
      {
         this.AV8Message = aP0_Message;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9File.Source = context.GetMessage( "Logs.txt", "");
         AV9File.Open("");
         AV9File.WriteLine(AV8Message);
         AV9File.Close();
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
         AV9File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private string AV8Message ;
      private GxFile AV9File ;
   }

}
