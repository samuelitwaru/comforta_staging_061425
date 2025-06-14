using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class aprc_savepage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_savepage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_savepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_savepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           string aP1_PageJsonContent ,
                           string aP2_PageGJSHtml ,
                           string aP3_PageGJSJson ,
                           SdtSDT_Page aP4_SDT_Page ,
                           ref string aP5_Reponse )
      {
         this.AV16PageId = aP0_PageId;
         this.AV17PageJsonContent = aP1_PageJsonContent;
         this.AV14PageGJSHtml = aP2_PageGJSHtml;
         this.AV15PageGJSJson = aP3_PageGJSJson;
         this.AV8SDT_Page = aP4_SDT_Page;
         this.AV18Reponse = aP5_Reponse;
         initialize();
         ExecuteImpl();
         aP5_Reponse=this.AV18Reponse;
      }

      public string executeUdp( Guid aP0_PageId ,
                                string aP1_PageJsonContent ,
                                string aP2_PageGJSHtml ,
                                string aP3_PageGJSJson ,
                                SdtSDT_Page aP4_SDT_Page )
      {
         execute(aP0_PageId, aP1_PageJsonContent, aP2_PageGJSHtml, aP3_PageGJSJson, aP4_SDT_Page, ref aP5_Reponse);
         return AV18Reponse ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 ref string aP5_Reponse )
      {
         this.AV16PageId = aP0_PageId;
         this.AV17PageJsonContent = aP1_PageJsonContent;
         this.AV14PageGJSHtml = aP2_PageGJSHtml;
         this.AV15PageGJSJson = aP3_PageGJSJson;
         this.AV8SDT_Page = aP4_SDT_Page;
         this.AV18Reponse = aP5_Reponse;
         SubmitImpl();
         aP5_Reponse=this.AV18Reponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV19UserName, ref  AV20LocationId, ref  AV21OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV19UserName))) )
         {
            cleanup();
            if (true) return;
         }
         /*
            INSERT RECORD ON TABLE Trn_Page

         */
         A392Trn_PageId = AV8SDT_Page.gxTpr_Pageid;
         A397Trn_PageName = AV8SDT_Page.gxTpr_Pagename;
         A420PageJsonContent = AV17PageJsonContent;
         n420PageJsonContent = false;
         A421PageGJSHtml = AV14PageGJSHtml;
         n421PageGJSHtml = false;
         A422PageGJSJson = AV15PageGJSJson;
         n422PageGJSJson = false;
         A423PageIsPublished = false;
         n423PageIsPublished = false;
         A429PageIsContentPage = true;
         n429PageIsContentPage = false;
         A492PageIsPredefined = false;
         A502PageIsDynamicForm = false;
         /* Using cursor P008F2 */
         pr_default.execute(0, new Object[] {A392Trn_PageId, A29LocationId, A397Trn_PageName, n420PageJsonContent, A420PageJsonContent, n421PageGJSHtml, A421PageGJSHtml, n422PageGJSJson, A422PageGJSJson, n423PageIsPublished, A423PageIsPublished, A492PageIsPredefined, n429PageIsContentPage, A429PageIsContentPage, A502PageIsDynamicForm});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         cleanup();
         if (true) return;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV19UserName = "";
         AV20LocationId = Guid.Empty;
         AV21OrganisationId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A29LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_savepage__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS88 ;
      private string Gx_emsg ;
      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool A492PageIsPredefined ;
      private bool A502PageIsDynamicForm ;
      private string AV17PageJsonContent ;
      private string AV14PageGJSHtml ;
      private string AV15PageGJSJson ;
      private string AV18Reponse ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string AV19UserName ;
      private string A397Trn_PageName ;
      private Guid AV16PageId ;
      private Guid AV20LocationId ;
      private Guid AV21OrganisationId ;
      private Guid A392Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private string aP5_Reponse ;
      private IDataStoreProvider pr_default ;
   }

   public class aprc_savepage__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008F2;
          prmP008F2 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PageIsPredefined",GXType.Boolean,4,0) ,
          new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PageIsDynamicForm",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008F2", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, LocationId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId) VALUES(:Trn_PageId, :LocationId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageIsPredefined, :PageIsContentPage, :PageIsDynamicForm, FALSE, '', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008F2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
