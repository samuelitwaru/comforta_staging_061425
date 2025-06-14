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
   public class prc_deletetrash : GXProcedure
   {
      public prc_deletetrash( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletetrash( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Type ,
                           Guid aP1_ItemId ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV16Type = aP0_Type;
         this.AV17ItemId = aP1_ItemId;
         this.AV15SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Error=this.AV15SDT_Error;
      }

      public SdtSDT_Error executeUdp( string aP0_Type ,
                                      Guid aP1_ItemId )
      {
         execute(aP0_Type, aP1_ItemId, out aP2_SDT_Error);
         return AV15SDT_Error ;
      }

      public void executeSubmit( string aP0_Type ,
                                 Guid aP1_ItemId ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV16Type = aP0_Type;
         this.AV17ItemId = aP1_ItemId;
         this.AV15SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Error=this.AV15SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV15SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV15SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         if ( StringUtil.StrCmp(AV16Type, context.GetMessage( "Page", "")) == 0 )
         {
            /* Using cursor P00G92 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A523AppVersionId = P00G92_A523AppVersionId[0];
               A535IsActive = P00G92_A535IsActive[0];
               /* Using cursor P00G93 */
               pr_default.execute(1, new Object[] {A523AppVersionId, AV17ItemId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTG93 = 0;
                  A516PageId = P00G93_A516PageId[0];
                  A621IsPageDeleted = P00G93_A621IsPageDeleted[0];
                  /* Using cursor P00G94 */
                  pr_default.execute(2, new Object[] {A523AppVersionId, A516PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  GXTG93 = 1;
                  if ( GXTG93 == 1 )
                  {
                     context.CommitDataStores("prc_deletetrash",pr_default);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            if ( StringUtil.StrCmp(AV16Type, context.GetMessage( "Version", "")) == 0 )
            {
               /* Using cursor P00G95 */
               pr_default.execute(3, new Object[] {AV17ItemId, AV12LocationId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A523AppVersionId = P00G95_A523AppVersionId[0];
                  A29LocationId = P00G95_A29LocationId[0];
                  n29LocationId = P00G95_n29LocationId[0];
                  /* Optimized DELETE. */
                  /* Using cursor P00G96 */
                  pr_default.execute(4, new Object[] {A523AppVersionId});
                  pr_default.close(4);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  /* End optimized DELETE. */
                  /* Using cursor P00G97 */
                  pr_default.execute(5, new Object[] {A523AppVersionId});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletetrash",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV15SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00G92_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G92_A535IsActive = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         P00G93_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G93_A516PageId = new Guid[] {Guid.Empty} ;
         P00G93_A621IsPageDeleted = new bool[] {false} ;
         A516PageId = Guid.Empty;
         P00G95_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00G95_A29LocationId = new Guid[] {Guid.Empty} ;
         P00G95_n29LocationId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletetrash__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletetrash__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletetrash__default(),
            new Object[][] {
                new Object[] {
               P00G92_A523AppVersionId, P00G92_A535IsActive
               }
               , new Object[] {
               P00G93_A523AppVersionId, P00G93_A516PageId, P00G93_A621IsPageDeleted
               }
               , new Object[] {
               }
               , new Object[] {
               P00G95_A523AppVersionId, P00G95_A29LocationId, P00G95_n29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTG93 ;
      private bool A535IsActive ;
      private bool A621IsPageDeleted ;
      private bool n29LocationId ;
      private string AV16Type ;
      private Guid AV17ItemId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV15SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00G92_A523AppVersionId ;
      private bool[] P00G92_A535IsActive ;
      private Guid[] P00G93_A523AppVersionId ;
      private Guid[] P00G93_A516PageId ;
      private bool[] P00G93_A621IsPageDeleted ;
      private Guid[] P00G95_A523AppVersionId ;
      private Guid[] P00G95_A29LocationId ;
      private bool[] P00G95_n29LocationId ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletetrash__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletetrash__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletetrash__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00G92;
       prmP00G92 = new Object[] {
       };
       Object[] prmP00G93;
       prmP00G93 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV17ItemId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00G94;
       prmP00G94 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00G95;
       prmP00G95 = new Object[] {
       new ParDef("AV17ItemId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00G96;
       prmP00G96 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00G97;
       prmP00G97 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00G92", "SELECT AppVersionId, IsActive FROM Trn_AppVersion WHERE IsActive = TRUE ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G92,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00G93", "SELECT AppVersionId, PageId, IsPageDeleted FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId and PageId = :AV17ItemId) AND (IsPageDeleted = TRUE) ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G93,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00G94", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G94)
          ,new CursorDef("P00G95", "SELECT AppVersionId, LocationId FROM Trn_AppVersion WHERE (AppVersionId = :AV17ItemId) AND (LocationId = :AV12LocationId) ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G95,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00G96", "DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G96)
          ,new CursorDef("P00G97", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G97)
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
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
    }
 }

}

}
