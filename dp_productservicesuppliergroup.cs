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
   public class dp_productservicesuppliergroup : GXProcedure
   {
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

      public dp_productservicesuppliergroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_productservicesuppliergroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem>( context, "SDT_ProductServiceSupplierGroupItem", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem>( context, "SDT_ProductServiceSupplierGroupItem", "Comforta_version21") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdt_productservicesuppliergroup = new SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem(context);
         Gxm2rootcol.Add(Gxm1sdt_productservicesuppliergroup, 0);
         Gxm1sdt_productservicesuppliergroup.gxTpr_Sdt_productservicesuppliergroupid = "Supplier";
         Gxm1sdt_productservicesuppliergroup.gxTpr_Sdt_productservicesuppliergroupname = "Supplier";
         AV8Udparg3 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P000P2 */
         pr_default.execute(0, new Object[] {AV8Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P000P2_A11OrganisationId[0];
            A29LocationId = P000P2_A29LocationId[0];
            A31LocationName = P000P2_A31LocationName[0];
            Gxm1sdt_productservicesuppliergroup = new SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem(context);
            Gxm2rootcol.Add(Gxm1sdt_productservicesuppliergroup, 0);
            Gxm1sdt_productservicesuppliergroup.gxTpr_Sdt_productservicesuppliergroupid = A29LocationId.ToString();
            Gxm1sdt_productservicesuppliergroup.gxTpr_Sdt_productservicesuppliergroupname = A31LocationName;
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
         Gxm1sdt_productservicesuppliergroup = new SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem(context);
         AV8Udparg3 = Guid.Empty;
         P000P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000P2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000P2_A31LocationName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A31LocationName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_productservicesuppliergroup__default(),
            new Object[][] {
                new Object[] {
               P000P2_A11OrganisationId, P000P2_A29LocationId, P000P2_A31LocationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A31LocationName ;
      private Guid AV8Udparg3 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> Gxm2rootcol ;
      private SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem Gxm1sdt_productservicesuppliergroup ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000P2_A11OrganisationId ;
      private Guid[] P000P2_A29LocationId ;
      private string[] P000P2_A31LocationName ;
      private GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> aP0_Gxm2rootcol ;
   }

   public class dp_productservicesuppliergroup__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000P2;
          prmP000P2 = new Object[] {
          new ParDef("AV8Udparg3",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000P2", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location WHERE OrganisationId = :AV8Udparg3 ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
