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
   public class prc_countlocationresidents : GXProcedure
   {
      public prc_countlocationresidents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_countlocationresidents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_LocationResidentsCount )
      {
         this.AV10LocationResidentsCount = 0 ;
         initialize();
         ExecuteImpl();
         aP0_LocationResidentsCount=this.AV10LocationResidentsCount;
      }

      public short executeUdp( )
      {
         execute(out aP0_LocationResidentsCount);
         return AV10LocationResidentsCount ;
      }

      public void executeSubmit( out short aP0_LocationResidentsCount )
      {
         this.AV10LocationResidentsCount = 0 ;
         SubmitImpl();
         aP0_LocationResidentsCount=this.AV10LocationResidentsCount;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10LocationResidentsCount = 0;
         AV12Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00EP3 */
         pr_default.execute(0, new Object[] {AV12Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00EP3_A11OrganisationId[0];
            A29LocationId = P00EP3_A29LocationId[0];
            A40000GXC1 = P00EP3_A40000GXC1[0];
            n40000GXC1 = P00EP3_n40000GXC1[0];
            A62ResidentId = P00EP3_A62ResidentId[0];
            A40000GXC1 = P00EP3_A40000GXC1[0];
            n40000GXC1 = P00EP3_n40000GXC1[0];
            AV10LocationResidentsCount = (short)(A40000GXC1);
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
         AV12Udparg1 = Guid.Empty;
         P00EP3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00EP3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00EP3_A40000GXC1 = new int[1] ;
         P00EP3_n40000GXC1 = new bool[] {false} ;
         P00EP3_A62ResidentId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_countlocationresidents__default(),
            new Object[][] {
                new Object[] {
               P00EP3_A11OrganisationId, P00EP3_A29LocationId, P00EP3_A40000GXC1, P00EP3_n40000GXC1, P00EP3_A62ResidentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10LocationResidentsCount ;
      private int A40000GXC1 ;
      private bool n40000GXC1 ;
      private Guid AV12Udparg1 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EP3_A11OrganisationId ;
      private Guid[] P00EP3_A29LocationId ;
      private int[] P00EP3_A40000GXC1 ;
      private bool[] P00EP3_n40000GXC1 ;
      private Guid[] P00EP3_A62ResidentId ;
      private short aP0_LocationResidentsCount ;
   }

   public class prc_countlocationresidents__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EP3;
          prmP00EP3 = new Object[] {
          new ParDef("AV12Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EP3", "SELECT T1.OrganisationId, T1.LocationId, COALESCE( T2.GXC1, 0) AS GXC1, T1.ResidentId FROM (Trn_Resident T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, LocationId, OrganisationId FROM Trn_Resident WHERE T1.LocationId = LocationId and T1.OrganisationId = OrganisationId GROUP BY LocationId, OrganisationId ) T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.LocationId = :AV12Udparg1 ORDER BY T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
