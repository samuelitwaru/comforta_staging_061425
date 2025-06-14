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
   public class aprc_pagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_pagesapi().MainImpl(args); ;
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

      public aprc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           string aP2_UserId ,
                           out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection )
      {
         this.AV16LocationId = aP0_LocationId;
         this.AV17OrganisationId = aP1_OrganisationId;
         this.AV18UserId = aP2_UserId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP3_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_MobilePage> executeUdp( Guid aP0_LocationId ,
                                                             Guid aP1_OrganisationId ,
                                                             string aP2_UserId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_UserId, out aP3_SDT_PageCollection);
         return AV9SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 string aP2_UserId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection )
      {
         this.AV16LocationId = aP0_LocationId;
         this.AV17OrganisationId = aP1_OrganisationId;
         this.AV18UserId = aP2_UserId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21") ;
         SubmitImpl();
         aP3_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_PageCollection.Clear();
         /* Using cursor P008D2 */
         pr_default.execute(0, new Object[] {AV16LocationId, AV17OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A429PageIsContentPage = P008D2_A429PageIsContentPage[0];
            n429PageIsContentPage = P008D2_n429PageIsContentPage[0];
            A11OrganisationId = P008D2_A11OrganisationId[0];
            A29LocationId = P008D2_A29LocationId[0];
            A420PageJsonContent = P008D2_A420PageJsonContent[0];
            n420PageJsonContent = P008D2_n420PageJsonContent[0];
            A392Trn_PageId = P008D2_A392Trn_PageId[0];
            AV8SDT_Page = new SdtSDT_MobilePage(context);
            AV8SDT_Page.FromJSonString(A420PageJsonContent, null);
            if ( StringUtil.StrCmp(AV8SDT_Page.gxTpr_Pagename, context.GetMessage( "Home", "")) == 0 )
            {
               AV9SDT_PageCollection.Add(AV19Filtered_SDT_MobilePage, 0);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8SDT_Page.gxTpr_Pagename))) )
               {
                  AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
               }
            }
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version21");
         P008D2_A429PageIsContentPage = new bool[] {false} ;
         P008D2_n429PageIsContentPage = new bool[] {false} ;
         P008D2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008D2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008D2_A420PageJsonContent = new string[] {""} ;
         P008D2_n420PageJsonContent = new bool[] {false} ;
         P008D2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A420PageJsonContent = "";
         A392Trn_PageId = Guid.Empty;
         AV8SDT_Page = new SdtSDT_MobilePage(context);
         AV19Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_pagesapi__default(),
            new Object[][] {
                new Object[] {
               P008D2_A429PageIsContentPage, P008D2_n429PageIsContentPage, P008D2_A11OrganisationId, P008D2_A29LocationId, P008D2_A420PageJsonContent, P008D2_n420PageJsonContent, P008D2_A392Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool n420PageJsonContent ;
      private string A420PageJsonContent ;
      private string AV18UserId ;
      private Guid AV16LocationId ;
      private Guid AV17OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MobilePage> AV9SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] P008D2_A429PageIsContentPage ;
      private bool[] P008D2_n429PageIsContentPage ;
      private Guid[] P008D2_A11OrganisationId ;
      private Guid[] P008D2_A29LocationId ;
      private string[] P008D2_A420PageJsonContent ;
      private bool[] P008D2_n420PageJsonContent ;
      private Guid[] P008D2_A392Trn_PageId ;
      private SdtSDT_MobilePage AV8SDT_Page ;
      private SdtSDT_MobilePage AV19Filtered_SDT_MobilePage ;
      private GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_PageCollection ;
   }

   public class aprc_pagesapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008D2;
          prmP008D2 = new Object[] {
          new ParDef("AV16LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008D2", "SELECT PageIsContentPage, OrganisationId, LocationId, PageJsonContent, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV16LocationId) AND (OrganisationId = :AV17OrganisationId) AND (PageIsContentPage = FALSE) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
