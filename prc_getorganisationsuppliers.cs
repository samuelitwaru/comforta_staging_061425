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
   public class prc_getorganisationsuppliers : GXProcedure
   {
      public prc_getorganisationsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getorganisationsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           out GXBCCollection<SdtTrn_SupplierGen> aP1_BC_Trn_GenSuppliers )
      {
         this.AV14OrganisationId = aP0_OrganisationId;
         this.AV26BC_Trn_GenSuppliers = new GXBCCollection<SdtTrn_SupplierGen>( context, "Trn_SupplierGen", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_BC_Trn_GenSuppliers=this.AV26BC_Trn_GenSuppliers;
      }

      public GXBCCollection<SdtTrn_SupplierGen> executeUdp( Guid aP0_OrganisationId )
      {
         execute(aP0_OrganisationId, out aP1_BC_Trn_GenSuppliers);
         return AV26BC_Trn_GenSuppliers ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 out GXBCCollection<SdtTrn_SupplierGen> aP1_BC_Trn_GenSuppliers )
      {
         this.AV14OrganisationId = aP0_OrganisationId;
         this.AV26BC_Trn_GenSuppliers = new GXBCCollection<SdtTrn_SupplierGen>( context, "Trn_SupplierGen", "Comforta_version2") ;
         SubmitImpl();
         aP1_BC_Trn_GenSuppliers=this.AV26BC_Trn_GenSuppliers;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00F82 */
         pr_default.execute(0, new Object[] {AV14OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = P00F82_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = P00F82_n602SG_LocationSupplierOrganisatio[0];
            A601SG_OrganisationSupplierId = P00F82_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = P00F82_n601SG_OrganisationSupplierId[0];
            A42SupplierGenId = P00F82_A42SupplierGenId[0];
            AV27BC_Trn_GenSupplier = new SdtTrn_SupplierGen(context);
            AV27BC_Trn_GenSupplier.Load(A42SupplierGenId);
            AV26BC_Trn_GenSuppliers.Add(AV27BC_Trn_GenSupplier, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26BC_Trn_GenSuppliers.Sort("SupplierGenCompanyName");
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
         AV26BC_Trn_GenSuppliers = new GXBCCollection<SdtTrn_SupplierGen>( context, "Trn_SupplierGen", "Comforta_version2");
         P00F82_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         P00F82_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         P00F82_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         P00F82_n601SG_OrganisationSupplierId = new bool[] {false} ;
         P00F82_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A601SG_OrganisationSupplierId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV27BC_Trn_GenSupplier = new SdtTrn_SupplierGen(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getorganisationsuppliers__default(),
            new Object[][] {
                new Object[] {
               P00F82_A602SG_LocationSupplierOrganisatio, P00F82_n602SG_LocationSupplierOrganisatio, P00F82_A601SG_OrganisationSupplierId, P00F82_n601SG_OrganisationSupplierId, P00F82_A42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n601SG_OrganisationSupplierId ;
      private Guid AV14OrganisationId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A601SG_OrganisationSupplierId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtTrn_SupplierGen> AV26BC_Trn_GenSuppliers ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00F82_A602SG_LocationSupplierOrganisatio ;
      private bool[] P00F82_n602SG_LocationSupplierOrganisatio ;
      private Guid[] P00F82_A601SG_OrganisationSupplierId ;
      private bool[] P00F82_n601SG_OrganisationSupplierId ;
      private Guid[] P00F82_A42SupplierGenId ;
      private SdtTrn_SupplierGen AV27BC_Trn_GenSupplier ;
      private GXBCCollection<SdtTrn_SupplierGen> aP1_BC_Trn_GenSuppliers ;
   }

   public class prc_getorganisationsuppliers__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F82;
          prmP00F82 = new Object[] {
          new ParDef("AV14OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F82", "SELECT SG_LocationSupplierOrganisatio, SG_OrganisationSupplierId, SupplierGenId FROM Trn_SupplierGen WHERE SG_OrganisationSupplierId = :AV14OrganisationId or SG_LocationSupplierOrganisatio = :AV14OrganisationId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F82,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
