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
   public class prc_updateappversion : GXProcedure
   {
      public prc_updateappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_AppVersionName ,
                           out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV10AppVersionName = aP1_AppVersionName;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_AppVersion=this.AV9SDT_AppVersion;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_AppVersionName ,
                                      out SdtSDT_AppVersion aP2_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, aP1_AppVersionName, out aP2_SDT_AppVersion, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_AppVersionName ,
                                 out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV11AppVersionId = aP0_AppVersionId;
         this.AV10AppVersionName = aP1_AppVersionName;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_AppVersion=this.AV9SDT_AppVersion;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         /* Using cursor P00C82 */
         pr_default.execute(0, new Object[] {AV11AppVersionId, AV12LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC82 = 0;
            A29LocationId = P00C82_A29LocationId[0];
            n29LocationId = P00C82_n29LocationId[0];
            A523AppVersionId = P00C82_A523AppVersionId[0];
            A524AppVersionName = P00C82_A524AppVersionName[0];
            A524AppVersionName = AV10AppVersionName;
            GXTC82 = 1;
            AV13BC_Trn_AppVersion.Load(A523AppVersionId);
            new prc_loadappversionsdt(context ).execute(  AV13BC_Trn_AppVersion, out  AV9SDT_AppVersion) ;
            /* Using cursor P00C83 */
            pr_default.execute(1, new Object[] {A524AppVersionName, A523AppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTC82 == 1 )
            {
               context.CommitDataStores("prc_updateappversion",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00C82_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C82_n29LocationId = new bool[] {false} ;
         P00C82_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00C82_A524AppVersionName = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         A524AppVersionName = "";
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateappversion__default(),
            new Object[][] {
                new Object[] {
               P00C82_A29LocationId, P00C82_n29LocationId, P00C82_A523AppVersionId, P00C82_A524AppVersionName
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC82 ;
      private bool n29LocationId ;
      private string AV10AppVersionName ;
      private string A524AppVersionName ;
      private Guid AV11AppVersionId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C82_A29LocationId ;
      private bool[] P00C82_n29LocationId ;
      private Guid[] P00C82_A523AppVersionId ;
      private string[] P00C82_A524AppVersionName ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private SdtSDT_AppVersion aP2_SDT_AppVersion ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00C82;
       prmP00C82 = new Object[] {
       new ParDef("AV11AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C83;
       prmP00C83 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00C82", "SELECT LocationId, AppVersionId, AppVersionName FROM Trn_AppVersion WHERE (AppVersionId = :AV11AppVersionId) AND (LocationId = :AV12LocationId) ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C82,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00C83", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C83)
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
             ((string[]) buf[3])[0] = rslt.getVarchar(3);
             return;
    }
 }

}

}
