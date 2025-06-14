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
   public class prc_agendareventdelete : GXProcedure
   {
      public prc_agendareventdelete( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_agendareventdelete( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AgendaCalendarId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AgendaCalendarId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P008T2 */
         pr_default.execute(0, new Object[] {AV8AgendaCalendarId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P008T3 */
         pr_default.execute(1, new Object[] {AV8AgendaCalendarId});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
         /* End optimized DELETE. */
         context.CommitDataStores("prc_agendareventdelete",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_agendareventdelete",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_agendareventdelete__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_agendareventdelete__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendareventdelete__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8AgendaCalendarId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_agendareventdelete__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_agendareventdelete__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_agendareventdelete__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new UpdateCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP008T2;
       prmP008T2 = new Object[] {
       new ParDef("AV8AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP008T3;
       prmP008T3 = new Object[] {
       new ParDef("AV8AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008T2", "DELETE FROM Trn_AgendaEventGroup  WHERE AgendaCalendarId = :AV8AgendaCalendarId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008T2)
          ,new CursorDef("P008T3", "DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AV8AgendaCalendarId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008T3)
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
