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
   public class wwp_df_saveforminstance : GXProcedure
   {
      public wwp_df_saveforminstance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_saveforminstance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_SessionId ,
                           GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP1_WWPFormInstance )
      {
         this.AV10SessionId = aP0_SessionId;
         this.AV9WWPFormInstance = aP1_WWPFormInstance;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_SessionId ,
                                 GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP1_WWPFormInstance )
      {
         this.AV10SessionId = aP0_SessionId;
         this.AV9WWPFormInstance = aP1_WWPFormInstance;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11WWPFormInstanceJson = AV9WWPFormInstance.ToJSonString(true, true);
         AV8WebSession.Set(StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV10SessionId), 6, 0)), "", "", "", "", "", "", "", ""), AV11WWPFormInstanceJson);
         if ( AV9WWPFormInstance.gxTpr_Wwpformresume != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  StringUtil.Format( "WWP_DF_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV10SessionId), 6, 0)), "", "", "", "", "", "", "", ""),  AV11WWPFormInstanceJson) ;
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
         AV11WWPFormInstanceJson = "";
         AV8WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV10SessionId ;
      private string AV11WWPFormInstanceJson ;
      private IGxSession AV8WebSession ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV9WWPFormInstance ;
   }

}
