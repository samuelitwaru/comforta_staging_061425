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
   public class prc_restoretrash : GXProcedure
   {
      public prc_restoretrash( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_restoretrash( IGxContext context )
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
            /* Using cursor P00GA2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A523AppVersionId = P00GA2_A523AppVersionId[0];
               A535IsActive = P00GA2_A535IsActive[0];
               /* Using cursor P00GA3 */
               pr_default.execute(1, new Object[] {A523AppVersionId, AV17ItemId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTGA3 = 0;
                  A516PageId = P00GA3_A516PageId[0];
                  A621IsPageDeleted = P00GA3_A621IsPageDeleted[0];
                  A621IsPageDeleted = false;
                  GXTGA3 = 1;
                  /* Using cursor P00GA4 */
                  pr_default.execute(2, new Object[] {A621IsPageDeleted, A523AppVersionId, A516PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( GXTGA3 == 1 )
                  {
                     context.CommitDataStores("prc_restoretrash",pr_default);
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
               /* Optimized UPDATE. */
               /* Using cursor P00GA5 */
               pr_default.execute(3, new Object[] {AV17ItemId, AV12LocationId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
               /* End optimized UPDATE. */
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_restoretrash",pr_default);
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
         P00GA2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GA2_A535IsActive = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         P00GA3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GA3_A516PageId = new Guid[] {Guid.Empty} ;
         P00GA3_A621IsPageDeleted = new bool[] {false} ;
         A516PageId = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_restoretrash__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_restoretrash__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_restoretrash__default(),
            new Object[][] {
                new Object[] {
               P00GA2_A523AppVersionId, P00GA2_A535IsActive
               }
               , new Object[] {
               P00GA3_A523AppVersionId, P00GA3_A516PageId, P00GA3_A621IsPageDeleted
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTGA3 ;
      private bool A535IsActive ;
      private bool A621IsPageDeleted ;
      private string AV16Type ;
      private Guid AV17ItemId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV15SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GA2_A523AppVersionId ;
      private bool[] P00GA2_A535IsActive ;
      private Guid[] P00GA3_A523AppVersionId ;
      private Guid[] P00GA3_A516PageId ;
      private bool[] P00GA3_A621IsPageDeleted ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_restoretrash__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_restoretrash__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_restoretrash__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new UpdateCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00GA2;
       prmP00GA2 = new Object[] {
       };
       Object[] prmP00GA3;
       prmP00GA3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV17ItemId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GA4;
       prmP00GA4 = new Object[] {
       new ParDef("IsPageDeleted",GXType.Boolean,4,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GA5;
       prmP00GA5 = new Object[] {
       new ParDef("AV17ItemId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GA2", "SELECT AppVersionId, IsActive FROM Trn_AppVersion WHERE IsActive = TRUE ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00GA3", "SELECT AppVersionId, PageId, IsPageDeleted FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId and PageId = :AV17ItemId) AND (IsPageDeleted = TRUE) ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00GA4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET IsPageDeleted=:IsPageDeleted  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GA4)
          ,new CursorDef("P00GA5", "UPDATE Trn_AppVersion SET IsVersionDeleted=FALSE  WHERE (AppVersionId = :AV17ItemId) AND (LocationId = :AV12LocationId)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GA5)
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
    }
 }

}

}
