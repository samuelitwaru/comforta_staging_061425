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
   public class prc_checkgamuserblockedstatus : GXProcedure
   {
      public prc_checkgamuserblockedstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checkgamuserblockedstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ManagerGAMGUID ,
                           out bool aP1_IsGAMAccountBlocked )
      {
         this.AV8ManagerGAMGUID = aP0_ManagerGAMGUID;
         this.AV12IsGAMAccountBlocked = false ;
         initialize();
         ExecuteImpl();
         aP1_IsGAMAccountBlocked=this.AV12IsGAMAccountBlocked;
      }

      public bool executeUdp( string aP0_ManagerGAMGUID )
      {
         execute(aP0_ManagerGAMGUID, out aP1_IsGAMAccountBlocked);
         return AV12IsGAMAccountBlocked ;
      }

      public void executeSubmit( string aP0_ManagerGAMGUID ,
                                 out bool aP1_IsGAMAccountBlocked )
      {
         this.AV8ManagerGAMGUID = aP0_ManagerGAMGUID;
         this.AV12IsGAMAccountBlocked = false ;
         SubmitImpl();
         aP1_IsGAMAccountBlocked=this.AV12IsGAMAccountBlocked;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GAMUser.load( AV8ManagerGAMGUID);
         AV12IsGAMAccountBlocked = AV10GAMUser.gxTpr_Isblocked;
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
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
      }

      private bool AV12IsGAMAccountBlocked ;
      private string AV8ManagerGAMGUID ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private bool aP1_IsGAMAccountBlocked ;
   }

}
