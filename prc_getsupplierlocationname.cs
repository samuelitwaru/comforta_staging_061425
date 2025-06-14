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
   public class prc_getsupplierlocationname : GXProcedure
   {
      public prc_getsupplierlocationname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getsupplierlocationname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductServiceGroup ,
                           out string aP1_SupplierLocation )
      {
         this.AV8ProductServiceGroup = aP0_ProductServiceGroup;
         this.AV9SupplierLocation = "" ;
         initialize();
         ExecuteImpl();
         aP1_SupplierLocation=this.AV9SupplierLocation;
      }

      public string executeUdp( string aP0_ProductServiceGroup )
      {
         execute(aP0_ProductServiceGroup, out aP1_SupplierLocation);
         return AV9SupplierLocation ;
      }

      public void executeSubmit( string aP0_ProductServiceGroup ,
                                 out string aP1_SupplierLocation )
      {
         this.AV8ProductServiceGroup = aP0_ProductServiceGroup;
         this.AV9SupplierLocation = "" ;
         SubmitImpl();
         aP1_SupplierLocation=this.AV9SupplierLocation;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         /* Using cursor P009S2 */
         pr_default.execute(0, new Object[] {AV8ProductServiceGroup});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P009S2_A29LocationId[0];
            A31LocationName = P009S2_A31LocationName[0];
            A11OrganisationId = P009S2_A11OrganisationId[0];
            AV10GXLvl1 = 1;
            AV9SupplierLocation = A31LocationName;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV9SupplierLocation = "";
         }
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
         AV9SupplierLocation = "";
         P009S2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009S2_A31LocationName = new string[] {""} ;
         P009S2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getsupplierlocationname__default(),
            new Object[][] {
                new Object[] {
               P009S2_A29LocationId, P009S2_A31LocationName, P009S2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private string AV8ProductServiceGroup ;
      private string AV9SupplierLocation ;
      private string A31LocationName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009S2_A29LocationId ;
      private string[] P009S2_A31LocationName ;
      private Guid[] P009S2_A11OrganisationId ;
      private string aP1_SupplierLocation ;
   }

   public class prc_getsupplierlocationname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009S2;
          prmP009S2 = new Object[] {
          new ParDef("AV8ProductServiceGroup",GXType.VarChar,400,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009S2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location WHERE LocationId = CASE WHEN (:AV8ProductServiceGroup ~ ('[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}')) THEN RTRIM(:AV8ProductServiceGroup) ELSE '00000000-0000-0000-0000-000000000000' END ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
