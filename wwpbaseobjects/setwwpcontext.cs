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
namespace GeneXus.Programs.wwpbaseobjects {
   public class setwwpcontext : GXProcedure
   {
      public setwwpcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public setwwpcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         this.AV8Context = aP0_Context;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         this.AV8Context = aP0_Context;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Session.Set("wwpcontext", AV8Context.ToXml(false, true, "", ""));
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
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8Context ;
   }

}
