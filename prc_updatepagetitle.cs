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
   public class prc_updatepagetitle : GXProcedure
   {
      public prc_updatepagetitle( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatepagetitle( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV9PageId = aP1_PageId;
         this.AV14PageName = aP2_PageName;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_PageId ,
                                      string aP2_PageName )
      {
         execute(aP0_AppVersionId, aP1_PageId, aP2_PageName, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV9PageId = aP1_PageId;
         this.AV14PageName = aP2_PageName;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
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
         new prc_logtofile(context ).execute(  context.GetMessage( "I am here at page title update", "")) ;
         AV15GXLvl8 = 0;
         /* Using cursor P00DD2 */
         pr_default.execute(0, new Object[] {AV10AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00DD2_A523AppVersionId[0];
            AV15GXLvl8 = 1;
            AV16GXLvl10 = 0;
            /* Using cursor P00DD3 */
            pr_default.execute(1, new Object[] {A523AppVersionId, AV9PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               GXTDD3 = 0;
               A516PageId = P00DD3_A516PageId[0];
               A517PageName = P00DD3_A517PageName[0];
               AV16GXLvl10 = 1;
               A517PageName = AV14PageName;
               GXTDD3 = 1;
               /* Using cursor P00DD4 */
               pr_default.execute(2, new Object[] {A517PageName, A523AppVersionId, A516PageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               if ( GXTDD3 == 1 )
               {
                  context.CommitDataStores("prc_updatepagetitle",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV16GXLvl10 == 0 )
            {
               AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
               AV8SDT_Error.gxTpr_Message = context.GetMessage( "Version Not Found", "");
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV15GXLvl8 == 0 )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Version Not Found", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updatepagetitle",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_Error = new SdtSDT_Error(context);
         P00DD2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00DD3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DD3_A516PageId = new Guid[] {Guid.Empty} ;
         P00DD3_A517PageName = new string[] {""} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepagetitle__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepagetitle__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepagetitle__default(),
            new Object[][] {
                new Object[] {
               P00DD2_A523AppVersionId
               }
               , new Object[] {
               P00DD3_A523AppVersionId, P00DD3_A516PageId, P00DD3_A517PageName
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl8 ;
      private short AV16GXLvl10 ;
      private short GXTDD3 ;
      private string AV14PageName ;
      private string A517PageName ;
      private Guid AV10AppVersionId ;
      private Guid AV9PageId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DD2_A523AppVersionId ;
      private Guid[] P00DD3_A523AppVersionId ;
      private Guid[] P00DD3_A516PageId ;
      private string[] P00DD3_A517PageName ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatepagetitle__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatepagetitle__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatepagetitle__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00DD2;
       prmP00DD2 = new Object[] {
       new ParDef("AV10AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00DD3;
       prmP00DD3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV9PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00DD4;
       prmP00DD4 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00DD2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV10AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00DD3", "SELECT AppVersionId, PageId, PageName FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV9PageId ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00DD4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DD4)
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
    }
 }

}

}
