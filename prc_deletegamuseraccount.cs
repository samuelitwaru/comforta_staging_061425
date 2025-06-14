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
   public class prc_deletegamuseraccount : GXProcedure
   {
      public prc_deletegamuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletegamuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGAMGUID ,
                           out string aP1_GAMErrorResponse )
      {
         this.AV10UserGAMGUID = aP0_UserGAMGUID;
         this.AV11GAMErrorResponse = "" ;
         initialize();
         ExecuteImpl();
         aP1_GAMErrorResponse=this.AV11GAMErrorResponse;
      }

      public string executeUdp( string aP0_UserGAMGUID )
      {
         execute(aP0_UserGAMGUID, out aP1_GAMErrorResponse);
         return AV11GAMErrorResponse ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 out string aP1_GAMErrorResponse )
      {
         this.AV10UserGAMGUID = aP0_UserGAMGUID;
         this.AV11GAMErrorResponse = "" ;
         SubmitImpl();
         aP1_GAMErrorResponse=this.AV11GAMErrorResponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMUser.load( AV10UserGAMGUID);
         if ( AV9GAMUser.success() )
         {
            if ( AV9GAMUser.physicaldelete(out  AV8GAMErrorCollection) )
            {
               context.CommitDataStores("prc_deletegamuseraccount",pr_default);
            }
            else
            {
               GXt_char1 = AV11GAMErrorResponse;
               new prc_geterrorstringfromcollection(context ).execute(  AV8GAMErrorCollection, out  GXt_char1) ;
               AV11GAMErrorResponse = GXt_char1;
            }
         }
         else
         {
            AV8GAMErrorCollection = AV9GAMUser.geterrors();
            GXt_char1 = AV11GAMErrorResponse;
            new prc_geterrorstringfromcollection(context ).execute(  AV8GAMErrorCollection, out  GXt_char1) ;
            AV11GAMErrorResponse = GXt_char1;
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
         AV11GAMErrorResponse = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletegamuseraccount__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletegamuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletegamuseraccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV11GAMErrorResponse ;
      private string AV10UserGAMGUID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private IDataStoreProvider pr_default ;
      private string aP1_GAMErrorResponse ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletegamuseraccount__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletegamuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletegamuseraccount__default : DataStoreHelperBase, IDataStoreHelper
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
