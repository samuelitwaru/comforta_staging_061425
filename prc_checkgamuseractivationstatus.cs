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
   public class prc_checkgamuseractivationstatus : GXProcedure
   {
      public prc_checkgamuseractivationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checkgamuseractivationstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ManagerGAMGUID ,
                           out bool aP1_IsGAMActive )
      {
         this.AV8ManagerGAMGUID = aP0_ManagerGAMGUID;
         this.AV9IsGAMActive = false ;
         initialize();
         ExecuteImpl();
         aP1_IsGAMActive=this.AV9IsGAMActive;
      }

      public bool executeUdp( string aP0_ManagerGAMGUID )
      {
         execute(aP0_ManagerGAMGUID, out aP1_IsGAMActive);
         return AV9IsGAMActive ;
      }

      public void executeSubmit( string aP0_ManagerGAMGUID ,
                                 out bool aP1_IsGAMActive )
      {
         this.AV8ManagerGAMGUID = aP0_ManagerGAMGUID;
         this.AV9IsGAMActive = false ;
         SubmitImpl();
         aP1_IsGAMActive=this.AV9IsGAMActive;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GAMUser.load( AV8ManagerGAMGUID);
         AV9IsGAMActive = AV10GAMUser.gxTpr_Isactive;
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

      private bool AV9IsGAMActive ;
      private string AV8ManagerGAMGUID ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private bool aP1_IsGAMActive ;
   }

}
