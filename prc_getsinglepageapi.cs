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
   public class prc_getsinglepageapi : GXProcedure
   {
      public prc_getsinglepageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getsinglepageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_pageId ,
                           out SdtSDT_Page aP1_SDT_Page ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
         aP2_Error=this.AV19Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_pageId ,
                                      out SdtSDT_Page aP1_SDT_Page )
      {
         execute(aP0_pageId, out aP1_SDT_Page, out aP2_Error);
         return AV19Error ;
      }

      public void executeSubmit( Guid aP0_pageId ,
                                 out SdtSDT_Page aP1_SDT_Page ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
         aP2_Error=this.AV19Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV19Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV19Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P00912 */
            pr_default.execute(0, new Object[] {AV15pageId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A392Trn_PageId = P00912_A392Trn_PageId[0];
               A397Trn_PageName = P00912_A397Trn_PageName[0];
               A420PageJsonContent = P00912_A420PageJsonContent[0];
               n420PageJsonContent = P00912_n420PageJsonContent[0];
               A421PageGJSHtml = P00912_A421PageGJSHtml[0];
               n421PageGJSHtml = P00912_n421PageGJSHtml[0];
               A422PageGJSJson = P00912_A422PageGJSJson[0];
               n422PageGJSJson = P00912_n422PageGJSJson[0];
               A429PageIsContentPage = P00912_A429PageIsContentPage[0];
               n429PageIsContentPage = P00912_n429PageIsContentPage[0];
               A423PageIsPublished = P00912_A423PageIsPublished[0];
               n423PageIsPublished = P00912_n423PageIsPublished[0];
               A424PageChildren = P00912_A424PageChildren[0];
               n424PageChildren = P00912_n424PageChildren[0];
               A29LocationId = P00912_A29LocationId[0];
               AV8SDT_Page = new SdtSDT_Page(context);
               AV8SDT_Page.gxTpr_Pageid = A392Trn_PageId;
               AV8SDT_Page.gxTpr_Pagename = A397Trn_PageName;
               AV8SDT_Page.gxTpr_Pagejsoncontent = A420PageJsonContent;
               AV8SDT_Page.gxTpr_Pagegjshtml = A421PageGJSHtml;
               AV8SDT_Page.gxTpr_Pagegjsjson = A422PageGJSJson;
               AV8SDT_Page.gxTpr_Pageiscontentpage = A429PageIsContentPage;
               AV8SDT_Page.gxTpr_Pageispublished = A423PageIsPublished;
               AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A424PageChildren, null);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new prc_logtofile(context ).execute(  context.GetMessage( "Checking here: ", "")+AV15pageId.ToString()) ;
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
         AV8SDT_Page = new SdtSDT_Page(context);
         AV19Error = new SdtSDT_Error(context);
         P00912_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00912_A397Trn_PageName = new string[] {""} ;
         P00912_A420PageJsonContent = new string[] {""} ;
         P00912_n420PageJsonContent = new bool[] {false} ;
         P00912_A421PageGJSHtml = new string[] {""} ;
         P00912_n421PageGJSHtml = new bool[] {false} ;
         P00912_A422PageGJSJson = new string[] {""} ;
         P00912_n422PageGJSJson = new bool[] {false} ;
         P00912_A429PageIsContentPage = new bool[] {false} ;
         P00912_n429PageIsContentPage = new bool[] {false} ;
         P00912_A423PageIsPublished = new bool[] {false} ;
         P00912_n423PageIsPublished = new bool[] {false} ;
         P00912_A424PageChildren = new string[] {""} ;
         P00912_n424PageChildren = new bool[] {false} ;
         P00912_A29LocationId = new Guid[] {Guid.Empty} ;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         A29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getsinglepageapi__default(),
            new Object[][] {
                new Object[] {
               P00912_A392Trn_PageId, P00912_A397Trn_PageName, P00912_A420PageJsonContent, P00912_n420PageJsonContent, P00912_A421PageGJSHtml, P00912_n421PageGJSHtml, P00912_A422PageGJSJson, P00912_n422PageGJSJson, P00912_A429PageIsContentPage, P00912_n429PageIsContentPage,
               P00912_A423PageIsPublished, P00912_n423PageIsPublished, P00912_A424PageChildren, P00912_n424PageChildren, P00912_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool n424PageChildren ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string A397Trn_PageName ;
      private Guid AV15pageId ;
      private Guid A392Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtSDT_Error AV19Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00912_A392Trn_PageId ;
      private string[] P00912_A397Trn_PageName ;
      private string[] P00912_A420PageJsonContent ;
      private bool[] P00912_n420PageJsonContent ;
      private string[] P00912_A421PageGJSHtml ;
      private bool[] P00912_n421PageGJSHtml ;
      private string[] P00912_A422PageGJSJson ;
      private bool[] P00912_n422PageGJSJson ;
      private bool[] P00912_A429PageIsContentPage ;
      private bool[] P00912_n429PageIsContentPage ;
      private bool[] P00912_A423PageIsPublished ;
      private bool[] P00912_n423PageIsPublished ;
      private string[] P00912_A424PageChildren ;
      private bool[] P00912_n424PageChildren ;
      private Guid[] P00912_A29LocationId ;
      private SdtSDT_Page aP1_SDT_Page ;
      private SdtSDT_Error aP2_Error ;
   }

   public class prc_getsinglepageapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00912;
          prmP00912 = new Object[] {
          new ParDef("AV15pageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00912", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageChildren, LocationId FROM Trn_Page WHERE Trn_PageId = :AV15pageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00912,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
