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
   public class prc_getresidentidfromguid : GXProcedure
   {
      public prc_getresidentidfromguid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentidfromguid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           out Guid aP1_ResidentId )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV9ResidentId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP1_ResidentId=this.AV9ResidentId;
      }

      public Guid executeUdp( string aP0_ResidentGUID )
      {
         execute(aP0_ResidentGUID, out aP1_ResidentId);
         return AV9ResidentId ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 out Guid aP1_ResidentId )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV9ResidentId = Guid.Empty ;
         SubmitImpl();
         aP1_ResidentId=this.AV9ResidentId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl3 = 0;
         /* Using cursor P00992 */
         pr_default.execute(0, new Object[] {AV8ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00992_A71ResidentGUID[0];
            A62ResidentId = P00992_A62ResidentId[0];
            A29LocationId = P00992_A29LocationId[0];
            A11OrganisationId = P00992_A11OrganisationId[0];
            AV10GXLvl3 = 1;
            AV9ResidentId = A62ResidentId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl3 == 0 )
         {
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
         AV9ResidentId = Guid.Empty;
         P00992_A71ResidentGUID = new string[] {""} ;
         P00992_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00992_A29LocationId = new Guid[] {Guid.Empty} ;
         P00992_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentidfromguid__default(),
            new Object[][] {
                new Object[] {
               P00992_A71ResidentGUID, P00992_A62ResidentId, P00992_A29LocationId, P00992_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl3 ;
      private string AV8ResidentGUID ;
      private string A71ResidentGUID ;
      private Guid AV9ResidentId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00992_A71ResidentGUID ;
      private Guid[] P00992_A62ResidentId ;
      private Guid[] P00992_A29LocationId ;
      private Guid[] P00992_A11OrganisationId ;
      private Guid aP1_ResidentId ;
   }

   public class prc_getresidentidfromguid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00992;
          prmP00992 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00992", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( RTRIM(LTRIM(:AV8ResidentGUID))) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00992,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
