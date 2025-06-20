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
   public class prc_deletecroppedmedia : GXProcedure
   {
      public prc_deletecroppedmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecroppedmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CroppedOriginalMediaId ,
                           out string aP1_response ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV15CroppedOriginalMediaId = aP0_CroppedOriginalMediaId;
         this.AV9response = "" ;
         this.AV13Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV9response;
         aP2_Error=this.AV13Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_CroppedOriginalMediaId ,
                                      out string aP1_response )
      {
         execute(aP0_CroppedOriginalMediaId, out aP1_response, out aP2_Error);
         return AV13Error ;
      }

      public void executeSubmit( Guid aP0_CroppedOriginalMediaId ,
                                 out string aP1_response ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV15CroppedOriginalMediaId = aP0_CroppedOriginalMediaId;
         this.AV9response = "" ;
         this.AV13Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_response=this.AV9response;
         aP2_Error=this.AV13Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV13Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV13Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV9response = context.GetMessage( "failure", "");
            /* Using cursor P00GR2 */
            pr_default.execute(0, new Object[] {AV15CroppedOriginalMediaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               GXTGR2 = 0;
               A413MediaId = P00GR2_A413MediaId[0];
               A645CroppedMediaName = P00GR2_A645CroppedMediaName[0];
               A644CroppedMediaId = P00GR2_A644CroppedMediaId[0];
               /* Using cursor P00GR3 */
               pr_default.execute(1, new Object[] {A644CroppedMediaId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_CroppedMedia");
               GXTGR2 = 1;
               AV9response = context.GetMessage( "success", "");
               AV8File.Source = context.GetMessage( "media/cropped/", "")+A645CroppedMediaName;
               if ( AV8File.Exists() )
               {
                  AV8File.Delete();
               }
               if ( GXTGR2 == 1 )
               {
                  context.CommitDataStores("prc_deletecroppedmedia",pr_default);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecroppedmedia",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9response = "";
         AV13Error = new SdtSDT_Error(context);
         P00GR2_A413MediaId = new Guid[] {Guid.Empty} ;
         P00GR2_A645CroppedMediaName = new string[] {""} ;
         P00GR2_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         A413MediaId = Guid.Empty;
         A645CroppedMediaName = "";
         A644CroppedMediaId = Guid.Empty;
         AV8File = new GxFile(context.GetPhysicalPath());
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecroppedmedia__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecroppedmedia__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecroppedmedia__default(),
            new Object[][] {
                new Object[] {
               P00GR2_A413MediaId, P00GR2_A645CroppedMediaName, P00GR2_A644CroppedMediaId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTGR2 ;
      private string AV9response ;
      private string A645CroppedMediaName ;
      private Guid AV15CroppedOriginalMediaId ;
      private Guid A413MediaId ;
      private Guid A644CroppedMediaId ;
      private GxFile AV8File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV13Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GR2_A413MediaId ;
      private string[] P00GR2_A645CroppedMediaName ;
      private Guid[] P00GR2_A644CroppedMediaId ;
      private string aP1_response ;
      private SdtSDT_Error aP2_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecroppedmedia__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecroppedmedia__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecroppedmedia__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00GR2;
       prmP00GR2 = new Object[] {
       new ParDef("AV15CroppedOriginalMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GR3;
       prmP00GR3 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GR2", "SELECT MediaId, CroppedMediaName, CroppedMediaId FROM Trn_CroppedMedia WHERE MediaId = :AV15CroppedOriginalMediaId ORDER BY MediaId  FOR UPDATE OF Trn_CroppedMedia",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GR2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00GR3", "SAVEPOINT gxupdate;DELETE FROM Trn_CroppedMedia  WHERE CroppedMediaId = :CroppedMediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GR3)
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
