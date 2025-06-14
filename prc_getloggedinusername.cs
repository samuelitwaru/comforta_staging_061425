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
   public class prc_getloggedinusername : GXProcedure
   {
      public prc_getloggedinusername( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getloggedinusername( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_userName )
      {
         this.AV9userName = "" ;
         initialize();
         ExecuteImpl();
         aP0_userName=this.AV9userName;
      }

      public string executeUdp( )
      {
         execute(out aP0_userName);
         return AV9userName ;
      }

      public void executeSubmit( out string aP0_userName )
      {
         this.AV9userName = "" ;
         SubmitImpl();
         aP0_userName=this.AV9userName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV8GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV8GAMUser = GXt_SdtGAMUser1;
         AV9userName = AV8GAMUser.gxTpr_Name;
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
         AV9userName = "";
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
      }

      private string AV9userName ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private string aP0_userName ;
   }

}
