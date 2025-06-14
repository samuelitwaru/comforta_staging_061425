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
   public class prc_checkresidentpackageavailable : GXProcedure
   {
      public prc_checkresidentpackageavailable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checkresidentpackageavailable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_PackageAvailable )
      {
         this.AV8PackageAvailable = false ;
         initialize();
         ExecuteImpl();
         aP0_PackageAvailable=this.AV8PackageAvailable;
      }

      public bool executeUdp( )
      {
         execute(out aP0_PackageAvailable);
         return AV8PackageAvailable ;
      }

      public void executeSubmit( out bool aP0_PackageAvailable )
      {
         this.AV8PackageAvailable = false ;
         SubmitImpl();
         aP0_PackageAvailable=this.AV8PackageAvailable;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ResidentCount = (short)(Convert.ToInt16(false));
         AV11Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00F73 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A527ResidentPackageId = P00F73_A527ResidentPackageId[0];
            n527ResidentPackageId = P00F73_n527ResidentPackageId[0];
            A529SG_OrganisationId = P00F73_A529SG_OrganisationId[0];
            A528SG_LocationId = P00F73_A528SG_LocationId[0];
            A40000GXC1 = P00F73_A40000GXC1[0];
            n40000GXC1 = P00F73_n40000GXC1[0];
            A40000GXC1 = P00F73_A40000GXC1[0];
            n40000GXC1 = P00F73_n40000GXC1[0];
            AV9ResidentCount = (short)(A40000GXC1);
            if ( AV9ResidentCount > 0 )
            {
               AV8PackageAvailable = true;
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
         AV11Udparg1 = Guid.Empty;
         P00F73_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00F73_n527ResidentPackageId = new bool[] {false} ;
         P00F73_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00F73_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00F73_A40000GXC1 = new int[1] ;
         P00F73_n40000GXC1 = new bool[] {false} ;
         A527ResidentPackageId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_checkresidentpackageavailable__default(),
            new Object[][] {
                new Object[] {
               P00F73_A527ResidentPackageId, P00F73_A529SG_OrganisationId, P00F73_A528SG_LocationId, P00F73_A40000GXC1, P00F73_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9ResidentCount ;
      private int A40000GXC1 ;
      private bool AV8PackageAvailable ;
      private bool n527ResidentPackageId ;
      private bool n40000GXC1 ;
      private Guid AV11Udparg1 ;
      private Guid A527ResidentPackageId ;
      private Guid A529SG_OrganisationId ;
      private Guid A528SG_LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00F73_A527ResidentPackageId ;
      private bool[] P00F73_n527ResidentPackageId ;
      private Guid[] P00F73_A529SG_OrganisationId ;
      private Guid[] P00F73_A528SG_LocationId ;
      private int[] P00F73_A40000GXC1 ;
      private bool[] P00F73_n40000GXC1 ;
      private bool aP0_PackageAvailable ;
   }

   public class prc_checkresidentpackageavailable__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F73;
          prmP00F73 = new Object[] {
          new ParDef("AV11Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F73", "SELECT T1.ResidentPackageId, T1.SG_OrganisationId, T1.SG_LocationId, COALESCE( T2.GXC1, 0) AS GXC1 FROM (Trn_ResidentPackage T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, ResidentPackageId, LocationId, OrganisationId FROM Trn_Resident WHERE T1.ResidentPackageId = ResidentPackageId and T1.SG_LocationId = LocationId and T1.SG_OrganisationId = OrganisationId GROUP BY ResidentPackageId, LocationId, OrganisationId ) T2 ON T2.ResidentPackageId = T1.ResidentPackageId AND T2.LocationId = T1.SG_LocationId AND T2.OrganisationId = T1.SG_OrganisationId) WHERE T1.SG_LocationId = :AV11Udparg1 ORDER BY T1.SG_LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F73,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
