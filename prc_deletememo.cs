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
   public class prc_deletememo : GXProcedure
   {
      public prc_deletememo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletememo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV10Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Error=this.AV10Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_MemoId )
      {
         execute(aP0_MemoId, out aP1_Error);
         return AV10Error ;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV10Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Error=this.AV10Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Trn_Memo.Load(AV8MemoId);
         AV9Trn_Memo.Delete();
         if ( AV9Trn_Memo.Success() )
         {
            context.CommitDataStores("prc_deletememo",pr_default);
         }
         else
         {
            AV10Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV10Error.gxTpr_Message = context.GetMessage( "Failed to delete memo", "");
            context.RollbackDataStores("prc_deletememo",pr_default);
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
         AV10Error = new SdtSDT_Error(context);
         AV9Trn_Memo = new SdtTrn_Memo(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletememo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletememo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletememo__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8MemoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV10Error ;
      private SdtTrn_Memo AV9Trn_Memo ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_Error aP1_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletememo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletememo__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletememo__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
