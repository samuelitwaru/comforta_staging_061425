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
   public class prc_deletemedia : GXProcedure
   {
      public prc_deletemedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletemedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MediaId ,
                           out string aP1_response )
      {
         this.AV8MediaId = aP0_MediaId;
         this.AV10response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV10response;
      }

      public string executeUdp( Guid aP0_MediaId )
      {
         execute(aP0_MediaId, out aP1_response);
         return AV10response ;
      }

      public void executeSubmit( Guid aP0_MediaId ,
                                 out string aP1_response )
      {
         this.AV8MediaId = aP0_MediaId;
         this.AV10response = "" ;
         SubmitImpl();
         aP1_response=this.AV10response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV14Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV14Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV10response = context.GetMessage( "failure", "");
            /* Using cursor P009L2 */
            pr_default.execute(0, new Object[] {AV8MediaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               GXT9L2 = 0;
               A413MediaId = P009L2_A413MediaId[0];
               A414MediaName = P009L2_A414MediaName[0];
               /* Using cursor P009L3 */
               pr_default.execute(1, new Object[] {A413MediaId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
               GXT9L2 = 1;
               AV10response = context.GetMessage( "success", "");
               AV9File.Source = context.GetMessage( "media/", "")+A414MediaName;
               if ( AV9File.Exists() )
               {
                  AV9File.Delete();
               }
               if ( GXT9L2 == 1 )
               {
                  context.CommitDataStores("prc_deletemedia",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletemedia",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10response = "";
         AV14Error = new SdtSDT_Error(context);
         P009L2_A413MediaId = new Guid[] {Guid.Empty} ;
         P009L2_A414MediaName = new string[] {""} ;
         A413MediaId = Guid.Empty;
         A414MediaName = "";
         AV9File = new GxFile(context.GetPhysicalPath());
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletemedia__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletemedia__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletemedia__default(),
            new Object[][] {
                new Object[] {
               P009L2_A413MediaId, P009L2_A414MediaName
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXT9L2 ;
      private string AV10response ;
      private string A414MediaName ;
      private Guid AV8MediaId ;
      private Guid A413MediaId ;
      private GxFile AV9File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV14Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009L2_A413MediaId ;
      private string[] P009L2_A414MediaName ;
      private string aP1_response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletemedia__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletemedia__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletemedia__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP009L2;
       prmP009L2 = new Object[] {
       new ParDef("AV8MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP009L3;
       prmP009L3 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P009L2", "SELECT MediaId, MediaName FROM Trn_Media WHERE MediaId = :AV8MediaId ORDER BY MediaId  FOR UPDATE OF Trn_Media",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P009L3", "SAVEPOINT gxupdate;DELETE FROM Trn_Media  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009L3)
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
             return;
    }
 }

}

}
