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
   public class prc_blockuser : GXProcedure
   {
      public prc_blockuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_blockuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGUID ,
                           out bool aP1_IsBlocked ,
                           out GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP2_ErrorMessages )
      {
         this.AV10UserGUID = aP0_UserGUID;
         this.AV13IsBlocked = false ;
         this.AV12ErrorMessages = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs") ;
         initialize();
         ExecuteImpl();
         aP1_IsBlocked=this.AV13IsBlocked;
         aP2_ErrorMessages=this.AV12ErrorMessages;
      }

      public GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> executeUdp( string aP0_UserGUID ,
                                                                                            out bool aP1_IsBlocked )
      {
         execute(aP0_UserGUID, out aP1_IsBlocked, out aP2_ErrorMessages);
         return AV12ErrorMessages ;
      }

      public void executeSubmit( string aP0_UserGUID ,
                                 out bool aP1_IsBlocked ,
                                 out GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP2_ErrorMessages )
      {
         this.AV10UserGUID = aP0_UserGUID;
         this.AV13IsBlocked = false ;
         this.AV12ErrorMessages = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs") ;
         SubmitImpl();
         aP1_IsBlocked=this.AV13IsBlocked;
         aP2_ErrorMessages=this.AV12ErrorMessages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMUser.load( AV10UserGUID);
         AV13IsBlocked = AV9GAMUser.blockaccess(false, true, out  AV12ErrorMessages);
         if ( AV13IsBlocked )
         {
            context.CommitDataStores("prc_blockuser",pr_default);
         }
         else
         {
            context.RollbackDataStores("prc_blockuser",pr_default);
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
         AV12ErrorMessages = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_blockuser__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_blockuser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_blockuser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10UserGUID ;
      private bool AV13IsBlocked ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12ErrorMessages ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private bool aP1_IsBlocked ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP2_ErrorMessages ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_blockuser__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_blockuser__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_blockuser__default : DataStoreHelperBase, IDataStoreHelper
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
