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
   public class uwwp_getloggeduserid : GXProcedure
   {
      public uwwp_getloggeduserid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uwwp_getloggeduserid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_WWPUserExtendedId )
      {
         this.AV8WWPUserExtendedId = "" ;
         initialize();
         ExecuteImpl();
         aP0_WWPUserExtendedId=this.AV8WWPUserExtendedId;
      }

      public string executeUdp( )
      {
         execute(out aP0_WWPUserExtendedId);
         return AV8WWPUserExtendedId ;
      }

      public void executeSubmit( out string aP0_WWPUserExtendedId )
      {
         this.AV8WWPUserExtendedId = "" ;
         SubmitImpl();
         aP0_WWPUserExtendedId=this.AV8WWPUserExtendedId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8WWPUserExtendedId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9WebSession.Get(context.GetMessage( "WebViewResidentId", "")))) )
         {
            AV8WWPUserExtendedId = AV9WebSession.Get(context.GetMessage( "WebViewResidentId", ""));
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV8WWPUserExtendedId = "";
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV8WWPUserExtendedId ;
      private IGxSession AV9WebSession ;
      private string aP0_WWPUserExtendedId ;
   }

}
