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
   public class dp_toolboxlanguages : GXProcedure
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

      public dp_toolboxlanguages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_toolboxlanguages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem>( context, "SDT_LanguageOptionsItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem>( context, "SDT_LanguageOptionsItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdt_languageoptions = new SdtSDT_LanguageOptions_SDT_LanguageOptionsItem(context);
         Gxm2rootcol.Add(Gxm1sdt_languageoptions, 0);
         Gxm1sdt_languageoptions.gxTpr_Value = "en";
         Gxm1sdt_languageoptions.gxTpr_Label = context.GetMessage( "English", "");
         Gxm1sdt_languageoptions = new SdtSDT_LanguageOptions_SDT_LanguageOptionsItem(context);
         Gxm2rootcol.Add(Gxm1sdt_languageoptions, 0);
         Gxm1sdt_languageoptions.gxTpr_Value = "nl";
         Gxm1sdt_languageoptions.gxTpr_Label = context.GetMessage( "Nederlands", "");
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
         Gxm1sdt_languageoptions = new SdtSDT_LanguageOptions_SDT_LanguageOptionsItem(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem> Gxm2rootcol ;
      private SdtSDT_LanguageOptions_SDT_LanguageOptionsItem Gxm1sdt_languageoptions ;
      private GXBaseCollection<SdtSDT_LanguageOptions_SDT_LanguageOptionsItem> aP0_Gxm2rootcol ;
   }

}
