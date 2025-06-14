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
   public class prc_activateappversion : GXProcedure
   {
      public prc_activateappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_activateappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                           out SdtSDT_Error aP2_SDT_Error ,
                           Guid aP3_LocationId )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         this.AV11LocationId = aP3_LocationId;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                                 out SdtSDT_Error aP2_SDT_Error ,
                                 Guid aP3_LocationId )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         this.AV11LocationId = aP3_LocationId;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         if ( (Guid.Empty==AV11LocationId) )
         {
            GXt_guid1 = AV11LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV11LocationId = GXt_guid1;
         }
         /* Execute user subroutine: 'UPDATELOCATIONACTIVEAPPVERSIONID' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00C92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC92 = 0;
            A535IsActive = P00C92_A535IsActive[0];
            A29LocationId = P00C92_A29LocationId[0];
            n29LocationId = P00C92_n29LocationId[0];
            A523AppVersionId = P00C92_A523AppVersionId[0];
            A535IsActive = false;
            if ( ( ( A523AppVersionId == AV10AppVersionId ) ) && ( ( A29LocationId == AV11LocationId ) ) )
            {
               A535IsActive = true;
               AV12BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
               AV12BC_Trn_AppVersion.Load(A523AppVersionId);
               new prc_loadappversionsdt(context ).execute(  AV12BC_Trn_AppVersion, out  AV8SDT_AppVersion) ;
            }
            GXTC92 = 1;
            /* Using cursor P00C93 */
            pr_default.execute(1, new Object[] {A535IsActive, A523AppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTC92 == 1 )
            {
               context.CommitDataStores("prc_activateappversion",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'UPDATELOCATIONACTIVEAPPVERSIONID' Routine */
         returnInSub = false;
         /* Using cursor P00C94 */
         pr_default.execute(2, new Object[] {AV11LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            GXTC93 = 0;
            A29LocationId = P00C94_A29LocationId[0];
            n29LocationId = P00C94_n29LocationId[0];
            A584ActiveAppVersionId = P00C94_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00C94_n584ActiveAppVersionId[0];
            A11OrganisationId = P00C94_A11OrganisationId[0];
            A584ActiveAppVersionId = AV10AppVersionId;
            n584ActiveAppVersionId = false;
            GXTC93 = 1;
            /* Using cursor P00C95 */
            pr_default.execute(3, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId, n29LocationId, A29LocationId, A11OrganisationId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
            if ( GXTC93 == 1 )
            {
               context.CommitDataStores("prc_activateappversion",pr_default);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_activateappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         GXt_guid1 = Guid.Empty;
         P00C92_A535IsActive = new bool[] {false} ;
         P00C92_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C92_n29LocationId = new bool[] {false} ;
         P00C92_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         AV12BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00C94_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C94_n29LocationId = new bool[] {false} ;
         P00C94_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00C94_n584ActiveAppVersionId = new bool[] {false} ;
         P00C94_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__default(),
            new Object[][] {
                new Object[] {
               P00C92_A535IsActive, P00C92_A29LocationId, P00C92_n29LocationId, P00C92_A523AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               P00C94_A29LocationId, P00C94_A584ActiveAppVersionId, P00C94_n584ActiveAppVersionId, P00C94_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC92 ;
      private short GXTC93 ;
      private bool returnInSub ;
      private bool A535IsActive ;
      private bool n29LocationId ;
      private bool n584ActiveAppVersionId ;
      private Guid AV10AppVersionId ;
      private Guid AV11LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private IDataStoreProvider pr_default ;
      private bool[] P00C92_A535IsActive ;
      private Guid[] P00C92_A29LocationId ;
      private bool[] P00C92_n29LocationId ;
      private Guid[] P00C92_A523AppVersionId ;
      private SdtTrn_AppVersion AV12BC_Trn_AppVersion ;
      private Guid[] P00C94_A29LocationId ;
      private bool[] P00C94_n29LocationId ;
      private Guid[] P00C94_A584ActiveAppVersionId ;
      private bool[] P00C94_n584ActiveAppVersionId ;
      private Guid[] P00C94_A11OrganisationId ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_activateappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_activateappversion__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_activateappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new UpdateCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00C92;
       prmP00C92 = new Object[] {
       };
       Object[] prmP00C93;
       prmP00C93 = new Object[] {
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C94;
       prmP00C94 = new Object[] {
       new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C95;
       prmP00C95 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00C92", "SELECT IsActive, LocationId, AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C92,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C93", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET IsActive=:IsActive  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C93)
          ,new CursorDef("P00C94", "SELECT LocationId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV11LocationId ORDER BY LocationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C94,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C95", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ActiveAppVersionId=:ActiveAppVersionId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C95)
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
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
