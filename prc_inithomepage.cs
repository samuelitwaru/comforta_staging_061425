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
   public class prc_inithomepage : GXProcedure
   {
      public prc_inithomepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_inithomepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtTrn_AppVersion_Page aP1_BC_HomePage )
      {
         this.AV25AppVersionId = aP0_AppVersionId;
         this.AV13BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP1_BC_HomePage=this.AV13BC_HomePage;
      }

      public SdtTrn_AppVersion_Page executeUdp( Guid aP0_AppVersionId )
      {
         execute(aP0_AppVersionId, out aP1_BC_HomePage);
         return AV13BC_HomePage ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtTrn_AppVersion_Page aP1_BC_HomePage )
      {
         this.AV25AppVersionId = aP0_AppVersionId;
         this.AV13BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP1_BC_HomePage=this.AV13BC_HomePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BC2 */
         pr_default.execute(0, new Object[] {AV25AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00BC2_A523AppVersionId[0];
            A29LocationId = P00BC2_A29LocationId[0];
            n29LocationId = P00BC2_n29LocationId[0];
            A11OrganisationId = P00BC2_A11OrganisationId[0];
            n11OrganisationId = P00BC2_n11OrganisationId[0];
            AV21LocationId = A29LocationId;
            AV22OrganisationId = A11OrganisationId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV17GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV18baseUrl = AV17GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV23BC_Trn_Location.Load(AV21LocationId, AV22OrganisationId);
         AV13BC_HomePage.gxTpr_Pageid = Guid.NewGuid( );
         AV13BC_HomePage.gxTpr_Pagename = "Home";
         AV13BC_HomePage.gxTpr_Ispredefined = true;
         AV13BC_HomePage.gxTpr_Pagetype = "Information";
         AV27SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV13BC_HomePage.gxTpr_Pagestructure = AV27SDT_InfoContent.ToJSonString(false, true);
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
         AV13BC_HomePage = new SdtTrn_AppVersion_Page(context);
         P00BC2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BC2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BC2_n29LocationId = new bool[] {false} ;
         P00BC2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BC2_n11OrganisationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV21LocationId = Guid.Empty;
         AV22OrganisationId = Guid.Empty;
         AV17GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV18baseUrl = "";
         AV23BC_Trn_Location = new SdtTrn_Location(context);
         AV27SDT_InfoContent = new SdtSDT_InfoContent(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_inithomepage__default(),
            new Object[][] {
                new Object[] {
               P00BC2_A523AppVersionId, P00BC2_A29LocationId, P00BC2_n29LocationId, P00BC2_A11OrganisationId, P00BC2_n11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private string AV18baseUrl ;
      private Guid AV25AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV21LocationId ;
      private Guid AV22OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion_Page AV13BC_HomePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BC2_A523AppVersionId ;
      private Guid[] P00BC2_A29LocationId ;
      private bool[] P00BC2_n29LocationId ;
      private Guid[] P00BC2_A11OrganisationId ;
      private bool[] P00BC2_n11OrganisationId ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV17GAMApplication ;
      private SdtTrn_Location AV23BC_Trn_Location ;
      private SdtSDT_InfoContent AV27SDT_InfoContent ;
      private SdtTrn_AppVersion_Page aP1_BC_HomePage ;
   }

   public class prc_inithomepage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BC2;
          prmP00BC2 = new Object[] {
          new ParDef("AV25AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BC2", "SELECT AppVersionId, LocationId, OrganisationId FROM Trn_AppVersion WHERE AppVersionId = :AV25AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BC2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
