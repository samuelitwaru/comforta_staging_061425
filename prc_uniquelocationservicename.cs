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
   public class prc_uniquelocationservicename : GXProcedure
   {
      public prc_uniquelocationservicename( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_uniquelocationservicename( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductServiceName ,
                           Guid aP1_LocationId ,
                           Guid aP2_ProductServiceId ,
                           out bool aP3_ServiceNameExists )
      {
         this.AV9ProductServiceName = aP0_ProductServiceName;
         this.AV8LocationId = aP1_LocationId;
         this.AV11ProductServiceId = aP2_ProductServiceId;
         this.AV10ServiceNameExists = false ;
         initialize();
         ExecuteImpl();
         aP3_ServiceNameExists=this.AV10ServiceNameExists;
      }

      public bool executeUdp( string aP0_ProductServiceName ,
                              Guid aP1_LocationId ,
                              Guid aP2_ProductServiceId )
      {
         execute(aP0_ProductServiceName, aP1_LocationId, aP2_ProductServiceId, out aP3_ServiceNameExists);
         return AV10ServiceNameExists ;
      }

      public void executeSubmit( string aP0_ProductServiceName ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_ProductServiceId ,
                                 out bool aP3_ServiceNameExists )
      {
         this.AV9ProductServiceName = aP0_ProductServiceName;
         this.AV8LocationId = aP1_LocationId;
         this.AV11ProductServiceId = aP2_ProductServiceId;
         this.AV10ServiceNameExists = false ;
         SubmitImpl();
         aP3_ServiceNameExists=this.AV10ServiceNameExists;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ServiceNameExists = false;
         AV12GXLvl2 = 0;
         /* Using cursor P00AW2 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV11ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A58ProductServiceId = P00AW2_A58ProductServiceId[0];
            A29LocationId = P00AW2_A29LocationId[0];
            A59ProductServiceName = P00AW2_A59ProductServiceName[0];
            A11OrganisationId = P00AW2_A11OrganisationId[0];
            AV12GXLvl2 = 1;
            if ( StringUtil.StrCmp(A59ProductServiceName, AV9ProductServiceName) == 0 )
            {
               AV10ServiceNameExists = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV12GXLvl2 == 0 )
         {
            AV10ServiceNameExists = false;
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
         P00AW2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00AW2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AW2_A59ProductServiceName = new string[] {""} ;
         P00AW2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A59ProductServiceName = "";
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_uniquelocationservicename__default(),
            new Object[][] {
                new Object[] {
               P00AW2_A58ProductServiceId, P00AW2_A29LocationId, P00AW2_A59ProductServiceName, P00AW2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12GXLvl2 ;
      private bool AV10ServiceNameExists ;
      private string AV9ProductServiceName ;
      private string A59ProductServiceName ;
      private Guid AV8LocationId ;
      private Guid AV11ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AW2_A58ProductServiceId ;
      private Guid[] P00AW2_A29LocationId ;
      private string[] P00AW2_A59ProductServiceName ;
      private Guid[] P00AW2_A11OrganisationId ;
      private bool aP3_ServiceNameExists ;
   }

   public class prc_uniquelocationservicename__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AW2;
          prmP00AW2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AW2", "SELECT ProductServiceId, LocationId, ProductServiceName, OrganisationId FROM Trn_ProductService WHERE (LocationId = :AV8LocationId) AND (Not ProductServiceId = :AV11ProductServiceId) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
