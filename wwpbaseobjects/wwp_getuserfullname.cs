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
   public class wwp_getuserfullname : GXProcedure
   {
      public wwp_getuserfullname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getuserfullname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out string aP1_WWPUserExtendedFullName )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9WWPUserExtendedFullName = "" ;
         initialize();
         ExecuteImpl();
         aP1_WWPUserExtendedFullName=this.AV9WWPUserExtendedFullName;
      }

      public string executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_WWPUserExtendedFullName);
         return AV9WWPUserExtendedFullName ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out string aP1_WWPUserExtendedFullName )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9WWPUserExtendedFullName = "" ;
         SubmitImpl();
         aP1_WWPUserExtendedFullName=this.AV9WWPUserExtendedFullName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8WWP_UserExtended.Load(AV10WWPUserExtendedId);
         AV9WWPUserExtendedFullName = AV8WWP_UserExtended.gxTpr_Wwpuserextendedfullname;
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
         AV9WWPUserExtendedFullName = "";
         AV8WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         /* GeneXus formulas. */
      }

      private string AV10WWPUserExtendedId ;
      private string AV9WWPUserExtendedFullName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV8WWP_UserExtended ;
      private string aP1_WWPUserExtendedFullName ;
   }

}
