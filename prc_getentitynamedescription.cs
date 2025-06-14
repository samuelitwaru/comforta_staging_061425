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
   public class prc_getentitynamedescription : GXProcedure
   {
      public prc_getentitynamedescription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getentitynamedescription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_EntityName )
      {
         this.AV8EntityName = aP0_EntityName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_EntityName )
      {
         this.AV8EntityName = aP0_EntityName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV8EntityName, context.GetMessage( "Trn_ProductService", "")) == 0 )
         {
            AV9EntityNameDescription = context.GetMessage( "the product/service", "");
         }
         else if ( StringUtil.StrCmp(AV8EntityName, context.GetMessage( "Trn_Receptionist", "")) == 0 )
         {
            AV9EntityNameDescription = context.GetMessage( "the receptionist", "");
         }
         else if ( StringUtil.StrCmp(AV8EntityName, context.GetMessage( "Trn_Resident", "")) == 0 )
         {
            AV9EntityNameDescription = context.GetMessage( "the resident", "");
         }
         else
         {
            AV9EntityNameDescription = AV8EntityName;
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
         AV9EntityNameDescription = "";
         /* GeneXus formulas. */
      }

      private string AV8EntityName ;
      private string AV9EntityNameDescription ;
   }

}
