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
   public class aprc_contentpagesapiv2 : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_contentpagesapiv2().MainImpl(args); ;
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

      public aprc_contentpagesapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_contentpagesapiv2( IGxContext context )
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
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV15SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_ContentPageCollection=this.AV15SDT_ContentPageCollection;
      }

      public GXBaseCollection<SdtSDT_ContentPage> executeUdp( Guid aP0_LocationId ,
                                                              Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_ContentPageCollection);
         return AV15SDT_ContentPageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV15SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21") ;
         SubmitImpl();
         aP2_SDT_ContentPageCollection=this.AV15SDT_ContentPageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DY2 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00DY2_A523AppVersionId[0];
            A535IsActive = P00DY2_A535IsActive[0];
            A11OrganisationId = P00DY2_A11OrganisationId[0];
            n11OrganisationId = P00DY2_n11OrganisationId[0];
            A29LocationId = P00DY2_A29LocationId[0];
            n29LocationId = P00DY2_n29LocationId[0];
            /* Using cursor P00DY3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A525PageType = P00DY3_A525PageType[0];
               A536PagePublishedStructure = P00DY3_A536PagePublishedStructure[0];
               A516PageId = P00DY3_A516PageId[0];
               A517PageName = P00DY3_A517PageName[0];
               AV14SDT_ContentPage.FromJSonString(A536PagePublishedStructure, null);
               GXt_SdtSDT_ContentPageV11 = AV23SDT_ContentPageV1;
               new prc_convertnewtooldcontentstructure(context ).execute(  AV14SDT_ContentPage,  A516PageId,  A517PageName, out  GXt_SdtSDT_ContentPageV11) ;
               AV23SDT_ContentPageV1 = GXt_SdtSDT_ContentPageV11;
               AV24SDT_ContentPageV1Collection.Add(AV23SDT_ContentPageV1, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV15SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version21");
         P00DY2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DY2_A535IsActive = new bool[] {false} ;
         P00DY2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DY2_n11OrganisationId = new bool[] {false} ;
         P00DY2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DY2_n29LocationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00DY3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DY3_A525PageType = new string[] {""} ;
         P00DY3_A536PagePublishedStructure = new string[] {""} ;
         P00DY3_A516PageId = new Guid[] {Guid.Empty} ;
         P00DY3_A517PageName = new string[] {""} ;
         A525PageType = "";
         A536PagePublishedStructure = "";
         A516PageId = Guid.Empty;
         A517PageName = "";
         AV14SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV23SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
         GXt_SdtSDT_ContentPageV11 = new SdtSDT_ContentPageV1(context);
         AV24SDT_ContentPageV1Collection = new GXBaseCollection<SdtSDT_ContentPageV1>( context, "SDT_ContentPageV1", "Comforta_version21");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_contentpagesapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DY2_A523AppVersionId, P00DY2_A535IsActive, P00DY2_A11OrganisationId, P00DY2_n11OrganisationId, P00DY2_A29LocationId, P00DY2_n29LocationId
               }
               , new Object[] {
               P00DY3_A523AppVersionId, P00DY3_A525PageType, P00DY3_A536PagePublishedStructure, P00DY3_A516PageId, P00DY3_A517PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A535IsActive ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private string A536PagePublishedStructure ;
      private string A525PageType ;
      private string A517PageName ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ContentPage> AV15SDT_ContentPageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DY2_A523AppVersionId ;
      private bool[] P00DY2_A535IsActive ;
      private Guid[] P00DY2_A11OrganisationId ;
      private bool[] P00DY2_n11OrganisationId ;
      private Guid[] P00DY2_A29LocationId ;
      private bool[] P00DY2_n29LocationId ;
      private Guid[] P00DY3_A523AppVersionId ;
      private string[] P00DY3_A525PageType ;
      private string[] P00DY3_A536PagePublishedStructure ;
      private Guid[] P00DY3_A516PageId ;
      private string[] P00DY3_A517PageName ;
      private SdtSDT_ContentPage AV14SDT_ContentPage ;
      private SdtSDT_ContentPageV1 AV23SDT_ContentPageV1 ;
      private SdtSDT_ContentPageV1 GXt_SdtSDT_ContentPageV11 ;
      private GXBaseCollection<SdtSDT_ContentPageV1> AV24SDT_ContentPageV1Collection ;
      private GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
   }

   public class aprc_contentpagesapiv2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DY2;
          prmP00DY2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DY3;
          prmP00DY3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DY2", "SELECT AppVersionId, IsActive, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId) AND (IsActive = TRUE) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DY3", "SELECT AppVersionId, PageType, PagePublishedStructure, PageId, PageName FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (( PageType = ( 'Content')) or ( PageType = ( 'Reception')) or ( PageType = ( 'Location'))) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DY3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
