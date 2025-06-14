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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_contentpagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_contentpagesapi().MainImpl(args); ;
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

      public aprc_contentpagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_contentpagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV20LocationId = aP0_LocationId;
         this.AV19OrganisationId = aP1_OrganisationId;
         this.AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_ContentPageCollection=this.AV17SDT_ContentPageCollection;
      }

      public GXBaseCollection<SdtSDT_ContentPage> executeUdp( Guid aP0_LocationId ,
                                                              Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_ContentPageCollection);
         return AV17SDT_ContentPageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV20LocationId = aP0_LocationId;
         this.AV19OrganisationId = aP1_OrganisationId;
         this.AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         SubmitImpl();
         aP2_SDT_ContentPageCollection=this.AV17SDT_ContentPageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008P2 */
         pr_default.execute(0, new Object[] {AV20LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A429PageIsContentPage = P008P2_A429PageIsContentPage[0];
            n429PageIsContentPage = P008P2_n429PageIsContentPage[0];
            A11OrganisationId = P008P2_A11OrganisationId[0];
            A29LocationId = P008P2_A29LocationId[0];
            A392Trn_PageId = P008P2_A392Trn_PageId[0];
            A397Trn_PageName = P008P2_A397Trn_PageName[0];
            A420PageJsonContent = P008P2_A420PageJsonContent[0];
            n420PageJsonContent = P008P2_n420PageJsonContent[0];
            AV23SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
            AV23SDT_ContentPageV1.gxTpr_Pageid = A392Trn_PageId;
            AV23SDT_ContentPageV1.gxTpr_Pagename = A397Trn_PageName;
            AV23SDT_ContentPageV1.FromJSonString(A420PageJsonContent, null);
            AV24SDT_ContentPageV1Collection.Add(AV23SDT_ContentPageV1, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21");
         P008P2_A429PageIsContentPage = new bool[] {false} ;
         P008P2_n429PageIsContentPage = new bool[] {false} ;
         P008P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008P2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008P2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P008P2_A397Trn_PageName = new string[] {""} ;
         P008P2_A420PageJsonContent = new string[] {""} ;
         P008P2_n420PageJsonContent = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         AV23SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
         AV24SDT_ContentPageV1Collection = new GXBaseCollection<SdtSDT_ContentPageV1>( context, "SDT_ContentPageV1", "Comforta_version21");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_contentpagesapi__default(),
            new Object[][] {
                new Object[] {
               P008P2_A429PageIsContentPage, P008P2_n429PageIsContentPage, P008P2_A11OrganisationId, P008P2_A29LocationId, P008P2_A392Trn_PageId, P008P2_A397Trn_PageName, P008P2_A420PageJsonContent, P008P2_n420PageJsonContent
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool n420PageJsonContent ;
      private string A420PageJsonContent ;
      private string A397Trn_PageName ;
      private Guid AV20LocationId ;
      private Guid AV19OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ContentPage> AV17SDT_ContentPageCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] P008P2_A429PageIsContentPage ;
      private bool[] P008P2_n429PageIsContentPage ;
      private Guid[] P008P2_A11OrganisationId ;
      private Guid[] P008P2_A29LocationId ;
      private Guid[] P008P2_A392Trn_PageId ;
      private string[] P008P2_A397Trn_PageName ;
      private string[] P008P2_A420PageJsonContent ;
      private bool[] P008P2_n420PageJsonContent ;
      private SdtSDT_ContentPageV1 AV23SDT_ContentPageV1 ;
      private GXBaseCollection<SdtSDT_ContentPageV1> AV24SDT_ContentPageV1Collection ;
      private GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
   }

   public class aprc_contentpagesapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008P2;
          prmP008P2 = new Object[] {
          new ParDef("AV20LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008P2", "SELECT PageIsContentPage, OrganisationId, LocationId, Trn_PageId, Trn_PageName, PageJsonContent FROM Trn_Page WHERE (LocationId = :AV20LocationId) AND (OrganisationId = :AV19OrganisationId) AND (PageIsContentPage = TRUE) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
