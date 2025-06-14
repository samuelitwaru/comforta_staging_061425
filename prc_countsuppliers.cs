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
   public class prc_countsuppliers : GXProcedure
   {
      public prc_countsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_countsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_SupplierCount )
      {
         this.AV12SupplierCount = 0 ;
         initialize();
         ExecuteImpl();
         aP0_SupplierCount=this.AV12SupplierCount;
      }

      public short executeUdp( )
      {
         execute(out aP0_SupplierCount);
         return AV12SupplierCount ;
      }

      public void executeSubmit( out short aP0_SupplierCount )
      {
         this.AV12SupplierCount = 0 ;
         SubmitImpl();
         aP0_SupplierCount=this.AV12SupplierCount;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12SupplierCount = 0;
         AV14Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P00ES3 */
         pr_default.execute(0, new Object[] {AV14Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = P00ES3_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = P00ES3_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = P00ES3_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = P00ES3_n603SG_LocationSupplierLocationId[0];
            A630ToolBoxLastUpdateReceptionistI = P00ES3_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00ES3_n630ToolBoxLastUpdateReceptionistI[0];
            A89ReceptionistId = P00ES3_A89ReceptionistId[0];
            A29LocationId = P00ES3_A29LocationId[0];
            A42SupplierGenId = P00ES3_A42SupplierGenId[0];
            n42SupplierGenId = P00ES3_n42SupplierGenId[0];
            A601SG_OrganisationSupplierId = P00ES3_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = P00ES3_n601SG_OrganisationSupplierId[0];
            A40000GXC1 = P00ES3_A40000GXC1[0];
            n40000GXC1 = P00ES3_n40000GXC1[0];
            A630ToolBoxLastUpdateReceptionistI = P00ES3_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00ES3_n630ToolBoxLastUpdateReceptionistI[0];
            A40000GXC1 = P00ES3_A40000GXC1[0];
            n40000GXC1 = P00ES3_n40000GXC1[0];
            /* Using cursor P00ES4 */
            pr_default.execute(1, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(1);
            AV12SupplierCount = (short)(A40000GXC1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(1);
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
         AV14Udparg1 = Guid.Empty;
         P00ES3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00ES3_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         P00ES3_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         P00ES3_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         P00ES3_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         P00ES3_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00ES3_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00ES3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00ES3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00ES3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00ES3_n42SupplierGenId = new bool[] {false} ;
         P00ES3_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         P00ES3_n601SG_OrganisationSupplierId = new bool[] {false} ;
         P00ES3_A40000GXC1 = new int[1] ;
         P00ES3_n40000GXC1 = new bool[] {false} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A601SG_OrganisationSupplierId = Guid.Empty;
         P00ES4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_countsuppliers__default(),
            new Object[][] {
                new Object[] {
               P00ES3_A11OrganisationId, P00ES3_A602SG_LocationSupplierOrganisatio, P00ES3_n602SG_LocationSupplierOrganisatio, P00ES3_A603SG_LocationSupplierLocationId, P00ES3_n603SG_LocationSupplierLocationId, P00ES3_A630ToolBoxLastUpdateReceptionistI, P00ES3_n630ToolBoxLastUpdateReceptionistI, P00ES3_A89ReceptionistId, P00ES3_A29LocationId, P00ES3_A42SupplierGenId,
               P00ES3_A601SG_OrganisationSupplierId, P00ES3_n601SG_OrganisationSupplierId, P00ES3_A40000GXC1, P00ES3_n40000GXC1
               }
               , new Object[] {
               P00ES4_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12SupplierCount ;
      private int A40000GXC1 ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n42SupplierGenId ;
      private bool n601SG_OrganisationSupplierId ;
      private bool n40000GXC1 ;
      private Guid AV14Udparg1 ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A89ReceptionistId ;
      private Guid A29LocationId ;
      private Guid A42SupplierGenId ;
      private Guid A601SG_OrganisationSupplierId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00ES3_A11OrganisationId ;
      private Guid[] P00ES3_A602SG_LocationSupplierOrganisatio ;
      private bool[] P00ES3_n602SG_LocationSupplierOrganisatio ;
      private Guid[] P00ES3_A603SG_LocationSupplierLocationId ;
      private bool[] P00ES3_n603SG_LocationSupplierLocationId ;
      private Guid[] P00ES3_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00ES3_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] P00ES3_A89ReceptionistId ;
      private Guid[] P00ES3_A29LocationId ;
      private Guid[] P00ES3_A42SupplierGenId ;
      private bool[] P00ES3_n42SupplierGenId ;
      private Guid[] P00ES3_A601SG_OrganisationSupplierId ;
      private bool[] P00ES3_n601SG_OrganisationSupplierId ;
      private int[] P00ES3_A40000GXC1 ;
      private bool[] P00ES3_n40000GXC1 ;
      private Guid[] P00ES4_A11OrganisationId ;
      private short aP0_SupplierCount ;
   }

   public class prc_countsuppliers__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ES3;
          prmP00ES3 = new Object[] {
          new ParDef("AV14Udparg1",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00ES4;
          prmP00ES4 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00ES3", "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SG_OrganisationSupplierId, COALESCE( T4.GXC1, 0) AS GXC1 FROM (((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, SupplierGenId, LocationId, OrganisationId FROM Trn_ProductService WHERE T1.SupplierGenId = SupplierGenId and T1.SG_LocationSupplierLocationId = LocationId and T1.SG_OrganisationSupplierId = OrganisationId GROUP BY SupplierGenId, LocationId, OrganisationId ) T4 ON T4.SupplierGenId = T1.SupplierGenId AND T4.LocationId = T1.SG_LocationSupplierLocationId AND T4.OrganisationId = T1.SG_OrganisationSupplierId) WHERE T3.OrganisationId = :AV14Udparg1 ORDER BY T1.SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ES4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES4,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((Guid[]) buf[10])[0] = rslt.getGuid(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
