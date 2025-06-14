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
   public class wwp_getloggeduserroles : GXProcedure
   {
      public wwp_getloggeduserroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getloggeduserroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV12WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP0_WWPSubscriptionRoleIdCollection=this.AV12WWPSubscriptionRoleIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( )
      {
         execute(out aP0_WWPSubscriptionRoleIdCollection);
         return AV12WWPSubscriptionRoleIdCollection ;
      }

      public void executeSubmit( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV12WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP0_WWPSubscriptionRoleIdCollection=this.AV12WWPSubscriptionRoleIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV9GAMRoleCollection = AV8GAMUser.getroles(out  AV11GAMErrorCollection);
         AV12WWPSubscriptionRoleIdCollection.Clear();
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV9GAMRoleCollection.Count )
         {
            AV10GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV9GAMRoleCollection.Item(AV13GXV1));
            AV12WWPSubscriptionRoleIdCollection.Add(AV10GAMRole.gxTpr_Guid, 0);
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV12WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMRoleCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV11GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private GxSimpleCollection<string> AV12WWPSubscriptionRoleIdCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV9GAMRoleCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection ;
   }

}
