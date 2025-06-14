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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_updateeventdate : GXProcedure
   {
      public wwp_calendar_updateeventdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_updateeventdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item aP0_EventToUpdate )
      {
         this.AV9EventToUpdate = aP0_EventToUpdate;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item aP0_EventToUpdate )
      {
         this.AV9EventToUpdate = aP0_EventToUpdate;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         /* GeneXus formulas. */
      }

      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV9EventToUpdate ;
   }

}
