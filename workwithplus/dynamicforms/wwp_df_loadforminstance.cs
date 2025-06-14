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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_loadforminstance : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_df_loadforminstance_Services_Execute" ;
         }

      }

      public wwp_df_loadforminstance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_loadforminstance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_SessionId ,
                           out GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP1_WWPFormInstance )
      {
         this.AV10SessionId = aP0_SessionId;
         this.AV9WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context) ;
         initialize();
         ExecuteImpl();
         aP1_WWPFormInstance=this.AV9WWPFormInstance;
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance executeUdp( int aP0_SessionId )
      {
         execute(aP0_SessionId, out aP1_WWPFormInstance);
         return AV9WWPFormInstance ;
      }

      public void executeSubmit( int aP0_SessionId ,
                                 out GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP1_WWPFormInstance )
      {
         this.AV10SessionId = aP0_SessionId;
         this.AV9WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context) ;
         SubmitImpl();
         aP1_WWPFormInstance=this.AV9WWPFormInstance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WWPFormInstance.FromJSonString(AV8WebSession.Get(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV10SessionId), 6, 0)), "", "", "", "", "", "", "", "")), null);
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         AV9WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV8WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV10SessionId ;
      private IGxSession AV8WebSession ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV9WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP1_WWPFormInstance ;
   }

}
