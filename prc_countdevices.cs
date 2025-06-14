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
   public class prc_countdevices : GXProcedure
   {
      public prc_countdevices( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_countdevices( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_DeviceCount )
      {
         this.AV8DeviceCount = 0 ;
         initialize();
         ExecuteImpl();
         aP0_DeviceCount=this.AV8DeviceCount;
      }

      public short executeUdp( )
      {
         execute(out aP0_DeviceCount);
         return AV8DeviceCount ;
      }

      public void executeSubmit( out short aP0_DeviceCount )
      {
         this.AV8DeviceCount = 0 ;
         SubmitImpl();
         aP0_DeviceCount=this.AV8DeviceCount;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8DeviceCount = 0;
         /* Using cursor P00EN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A337DeviceUserId = P00EN2_A337DeviceUserId[0];
            A333DeviceId = P00EN2_A333DeviceId[0];
            AV9DeviceUserId = StringUtil.StrToGuid( A337DeviceUserId);
            AV12Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            /* Using cursor P00EN4 */
            pr_default.execute(1, new Object[] {AV9DeviceUserId, AV12Udparg1});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P00EN4_A11OrganisationId[0];
               A29LocationId = P00EN4_A29LocationId[0];
               A62ResidentId = P00EN4_A62ResidentId[0];
               A40000GXC1 = P00EN4_A40000GXC1[0];
               n40000GXC1 = P00EN4_n40000GXC1[0];
               A40000GXC1 = P00EN4_A40000GXC1[0];
               n40000GXC1 = P00EN4_n40000GXC1[0];
               AV8DeviceCount = (short)(A40000GXC1);
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
         P00EN2_A337DeviceUserId = new string[] {""} ;
         P00EN2_A333DeviceId = new string[] {""} ;
         A337DeviceUserId = "";
         A333DeviceId = "";
         AV9DeviceUserId = Guid.Empty;
         AV12Udparg1 = Guid.Empty;
         P00EN4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00EN4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00EN4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00EN4_A40000GXC1 = new int[1] ;
         P00EN4_n40000GXC1 = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_countdevices__default(),
            new Object[][] {
                new Object[] {
               P00EN2_A337DeviceUserId, P00EN2_A333DeviceId
               }
               , new Object[] {
               P00EN4_A11OrganisationId, P00EN4_A29LocationId, P00EN4_A62ResidentId, P00EN4_A40000GXC1, P00EN4_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8DeviceCount ;
      private int A40000GXC1 ;
      private string A333DeviceId ;
      private bool n40000GXC1 ;
      private string A337DeviceUserId ;
      private Guid AV9DeviceUserId ;
      private Guid AV12Udparg1 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00EN2_A337DeviceUserId ;
      private string[] P00EN2_A333DeviceId ;
      private Guid[] P00EN4_A11OrganisationId ;
      private Guid[] P00EN4_A29LocationId ;
      private Guid[] P00EN4_A62ResidentId ;
      private int[] P00EN4_A40000GXC1 ;
      private bool[] P00EN4_n40000GXC1 ;
      private short aP0_DeviceCount ;
   }

   public class prc_countdevices__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EN2;
          prmP00EN2 = new Object[] {
          };
          Object[] prmP00EN4;
          prmP00EN4 = new Object[] {
          new ParDef("AV9DeviceUserId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EN2", "SELECT DeviceUserId, DeviceId FROM Trn_Device ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EN4", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, COALESCE( T2.GXC1, 0) AS GXC1 FROM (Trn_Resident T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, LocationId, OrganisationId FROM Trn_Resident WHERE T1.LocationId = LocationId and T1.OrganisationId = OrganisationId GROUP BY LocationId, OrganisationId ) T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.ResidentId = :AV9DeviceUserId and T1.LocationId = :AV12Udparg1 ORDER BY T1.ResidentId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EN4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
                return;
             case 1 :
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
