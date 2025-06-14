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
   public class prc_initlocationpagesv2 : GXProcedure
   {
      public prc_initlocationpagesv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initlocationpagesv2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV14OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV14OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15BC_Trn_Location.Load(AV8LocationId, AV14OrganisationId);
         AV32GXLvl4 = 0;
         /* Using cursor P00B82 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00B82_A29LocationId[0];
            n29LocationId = P00B82_n29LocationId[0];
            A523AppVersionId = P00B82_A523AppVersionId[0];
            AV32GXLvl4 = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV32GXLvl4 == 0 )
         {
            AV30AppVersionName = context.GetMessage( "Version 1", "");
            AV31IsActive = true;
            new prc_createappversion(context ).execute(  AV30AppVersionName,  AV31IsActive, out  AV28SDT_AppVersion, out  AV29SDT_Error,  AV8LocationId,  AV14OrganisationId) ;
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
         AV15BC_Trn_Location = new SdtTrn_Location(context);
         P00B82_A29LocationId = new Guid[] {Guid.Empty} ;
         P00B82_n29LocationId = new bool[] {false} ;
         P00B82_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         AV30AppVersionName = "";
         AV28SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV29SDT_Error = new SdtSDT_Error(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpagesv2__default(),
            new Object[][] {
                new Object[] {
               P00B82_A29LocationId, P00B82_n29LocationId, P00B82_A523AppVersionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32GXLvl4 ;
      private bool n29LocationId ;
      private bool AV31IsActive ;
      private string AV30AppVersionName ;
      private Guid AV8LocationId ;
      private Guid AV14OrganisationId ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Location AV15BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00B82_A29LocationId ;
      private bool[] P00B82_n29LocationId ;
      private Guid[] P00B82_A523AppVersionId ;
      private SdtSDT_AppVersion AV28SDT_AppVersion ;
      private SdtSDT_Error AV29SDT_Error ;
   }

   public class prc_initlocationpagesv2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B82;
          prmP00B82 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B82", "SELECT LocationId, AppVersionId FROM Trn_AppVersion WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B82,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
