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
   public class aprc_initializegamroles : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_initializegamroles().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_initializegamroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_initializegamroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12RoleNames = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV13RolesString = context.GetMessage( "Root Admin, Comforta Admin,Organisation Manager,Receptionist,Resident", "");
         AV12RoleNames = (GxSimpleCollection<string>)(GxRegex.Split(AV13RolesString,","));
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV12RoleNames.Count )
         {
            AV11RoleName = ((string)AV12RoleNames.Item(AV14GXV1));
            AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
            AV10GAMRole.gxTpr_Name = AV11RoleName;
            AV10GAMRole.gxTpr_Description = AV11RoleName;
            AV10GAMRole.save();
            if ( AV10GAMRole.success() )
            {
               context.CommitDataStores("prc_initializegamroles",pr_default);
            }
            else
            {
               context.RollbackDataStores("prc_initializegamroles",pr_default);
            }
            AV14GXV1 = (int)(AV14GXV1+1);
         }
         AV9GAMRepository.save();
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
         AV12RoleNames = new GxSimpleCollection<string>();
         AV13RolesString = "";
         AV11RoleName = "";
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV9GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_initializegamroles__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_initializegamroles__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_initializegamroles__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV14GXV1 ;
      private string AV13RolesString ;
      private string AV11RoleName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12RoleNames ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV9GAMRepository ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_initializegamroles__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_initializegamroles__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_initializegamroles__default : DataStoreHelperBase, IDataStoreHelper
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
