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
   public class wwp_getrolename : GXProcedure
   {
      public wwp_getrolename( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getrolename( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPSubscriptionRoleId ,
                           out string aP1_RoleName )
      {
         this.AV8WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9RoleName = "" ;
         initialize();
         ExecuteImpl();
         aP1_RoleName=this.AV9RoleName;
      }

      public string executeUdp( string aP0_WWPSubscriptionRoleId )
      {
         execute(aP0_WWPSubscriptionRoleId, out aP1_RoleName);
         return AV9RoleName ;
      }

      public void executeSubmit( string aP0_WWPSubscriptionRoleId ,
                                 out string aP1_RoleName )
      {
         this.AV8WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9RoleName = "" ;
         SubmitImpl();
         aP1_RoleName=this.AV9RoleName;
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
         AV9RoleName = "";
         /* GeneXus formulas. */
      }

      private string AV8WWPSubscriptionRoleId ;
      private string AV9RoleName ;
      private string aP1_RoleName ;
   }

}
