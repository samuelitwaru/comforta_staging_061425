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
   public class aprc_getpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_getpages().MainImpl(args); ;
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

      public aprc_getpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV18Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageCollection=this.AV9SDT_PageCollection;
         aP1_Error=this.AV18Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection )
      {
         execute(out aP0_SDT_PageCollection, out aP1_Error);
         return AV18Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV18Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageCollection=this.AV9SDT_PageCollection;
         aP1_Error=this.AV18Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV15LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV15LocationId = GXt_guid1;
         GXt_guid1 = AV16OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV16OrganisationId = GXt_guid1;
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV18Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV18Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P008M2 */
            pr_default.execute(0, new Object[] {AV15LocationId, AV16OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A29LocationId = P008M2_A29LocationId[0];
               A11OrganisationId = P008M2_A11OrganisationId[0];
               A392Trn_PageId = P008M2_A392Trn_PageId[0];
               A397Trn_PageName = P008M2_A397Trn_PageName[0];
               A420PageJsonContent = P008M2_A420PageJsonContent[0];
               n420PageJsonContent = P008M2_n420PageJsonContent[0];
               A421PageGJSHtml = P008M2_A421PageGJSHtml[0];
               n421PageGJSHtml = P008M2_n421PageGJSHtml[0];
               A422PageGJSJson = P008M2_A422PageGJSJson[0];
               n422PageGJSJson = P008M2_n422PageGJSJson[0];
               A429PageIsContentPage = P008M2_A429PageIsContentPage[0];
               n429PageIsContentPage = P008M2_n429PageIsContentPage[0];
               A423PageIsPublished = P008M2_A423PageIsPublished[0];
               n423PageIsPublished = P008M2_n423PageIsPublished[0];
               A492PageIsPredefined = P008M2_A492PageIsPredefined[0];
               A502PageIsDynamicForm = P008M2_A502PageIsDynamicForm[0];
               A505PageIsWebLinkPage = P008M2_A505PageIsWebLinkPage[0];
               A424PageChildren = P008M2_A424PageChildren[0];
               n424PageChildren = P008M2_n424PageChildren[0];
               AV8SDT_Page = new SdtSDT_Page(context);
               AV8SDT_Page.gxTpr_Pageid = A392Trn_PageId;
               AV8SDT_Page.gxTpr_Pagename = A397Trn_PageName;
               AV8SDT_Page.gxTpr_Pagejsoncontent = A420PageJsonContent;
               AV8SDT_Page.gxTpr_Pagegjshtml = A421PageGJSHtml;
               AV8SDT_Page.gxTpr_Pagegjsjson = A422PageGJSJson;
               AV8SDT_Page.gxTpr_Pageiscontentpage = A429PageIsContentPage;
               AV8SDT_Page.gxTpr_Pageispublished = A423PageIsPublished;
               AV8SDT_Page.gxTpr_Pageispredefined = A492PageIsPredefined;
               AV8SDT_Page.gxTpr_Pageisdynamicform = A502PageIsDynamicForm;
               AV8SDT_Page.gxTpr_Pageisweblinkpage = A505PageIsWebLinkPage;
               AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A424PageChildren, null);
               /* Using cursor P008M3 */
               pr_default.execute(1, new Object[] {A392Trn_PageId, A11OrganisationId, A29LocationId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A366LocationDynamicFormId = P008M3_A366LocationDynamicFormId[0];
                  A206WWPFormId = P008M3_A206WWPFormId[0];
                  AV8SDT_Page.gxTpr_Wwpformid = A206WWPFormId;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV18Error = new SdtSDT_Error(context);
         AV15LocationId = Guid.Empty;
         AV16OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P008M2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008M2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008M2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P008M2_A397Trn_PageName = new string[] {""} ;
         P008M2_A420PageJsonContent = new string[] {""} ;
         P008M2_n420PageJsonContent = new bool[] {false} ;
         P008M2_A421PageGJSHtml = new string[] {""} ;
         P008M2_n421PageGJSHtml = new bool[] {false} ;
         P008M2_A422PageGJSJson = new string[] {""} ;
         P008M2_n422PageGJSJson = new bool[] {false} ;
         P008M2_A429PageIsContentPage = new bool[] {false} ;
         P008M2_n429PageIsContentPage = new bool[] {false} ;
         P008M2_A423PageIsPublished = new bool[] {false} ;
         P008M2_n423PageIsPublished = new bool[] {false} ;
         P008M2_A492PageIsPredefined = new bool[] {false} ;
         P008M2_A502PageIsDynamicForm = new bool[] {false} ;
         P008M2_A505PageIsWebLinkPage = new bool[] {false} ;
         P008M2_A424PageChildren = new string[] {""} ;
         P008M2_n424PageChildren = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         AV8SDT_Page = new SdtSDT_Page(context);
         P008M3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008M3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008M3_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P008M3_A206WWPFormId = new short[1] ;
         A366LocationDynamicFormId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getpages__default(),
            new Object[][] {
                new Object[] {
               P008M2_A29LocationId, P008M2_A11OrganisationId, P008M2_A392Trn_PageId, P008M2_A397Trn_PageName, P008M2_A420PageJsonContent, P008M2_n420PageJsonContent, P008M2_A421PageGJSHtml, P008M2_n421PageGJSHtml, P008M2_A422PageGJSJson, P008M2_n422PageGJSJson,
               P008M2_A429PageIsContentPage, P008M2_n429PageIsContentPage, P008M2_A423PageIsPublished, P008M2_n423PageIsPublished, P008M2_A492PageIsPredefined, P008M2_A502PageIsDynamicForm, P008M2_A505PageIsWebLinkPage, P008M2_A424PageChildren, P008M2_n424PageChildren
               }
               , new Object[] {
               P008M3_A11OrganisationId, P008M3_A29LocationId, P008M3_A366LocationDynamicFormId, P008M3_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool A492PageIsPredefined ;
      private bool A502PageIsDynamicForm ;
      private bool A505PageIsWebLinkPage ;
      private bool n424PageChildren ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string A397Trn_PageName ;
      private Guid AV15LocationId ;
      private Guid AV16OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A392Trn_PageId ;
      private Guid A366LocationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Page> AV9SDT_PageCollection ;
      private SdtSDT_Error AV18Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008M2_A29LocationId ;
      private Guid[] P008M2_A11OrganisationId ;
      private Guid[] P008M2_A392Trn_PageId ;
      private string[] P008M2_A397Trn_PageName ;
      private string[] P008M2_A420PageJsonContent ;
      private bool[] P008M2_n420PageJsonContent ;
      private string[] P008M2_A421PageGJSHtml ;
      private bool[] P008M2_n421PageGJSHtml ;
      private string[] P008M2_A422PageGJSJson ;
      private bool[] P008M2_n422PageGJSJson ;
      private bool[] P008M2_A429PageIsContentPage ;
      private bool[] P008M2_n429PageIsContentPage ;
      private bool[] P008M2_A423PageIsPublished ;
      private bool[] P008M2_n423PageIsPublished ;
      private bool[] P008M2_A492PageIsPredefined ;
      private bool[] P008M2_A502PageIsDynamicForm ;
      private bool[] P008M2_A505PageIsWebLinkPage ;
      private string[] P008M2_A424PageChildren ;
      private bool[] P008M2_n424PageChildren ;
      private SdtSDT_Page AV8SDT_Page ;
      private Guid[] P008M3_A11OrganisationId ;
      private Guid[] P008M3_A29LocationId ;
      private Guid[] P008M3_A366LocationDynamicFormId ;
      private short[] P008M3_A206WWPFormId ;
      private GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      private SdtSDT_Error aP1_Error ;
   }

   public class aprc_getpages__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008M2;
          prmP008M2 = new Object[] {
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008M3;
          prmP008M3 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008M2", "SELECT LocationId, OrganisationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageIsPredefined, PageIsDynamicForm, PageIsWebLinkPage, PageChildren FROM Trn_Page WHERE (LocationId = :AV15LocationId) AND (OrganisationId = :AV16OrganisationId) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008M3", "SELECT OrganisationId, LocationId, LocationDynamicFormId, WWPFormId FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :Trn_PageId and OrganisationId = :OrganisationId and LocationId = :LocationId ORDER BY LocationDynamicFormId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M3,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((bool[]) buf[10])[0] = rslt.getBool(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((bool[]) buf[16])[0] = rslt.getBool(12);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
