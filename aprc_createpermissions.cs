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
   public class aprc_createpermissions : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createpermissions().MainImpl(args); ;
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

      public aprc_createpermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createpermissions( IGxContext context )
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
         AV8RoleNameCollection.Add(context.GetMessage( "Resident", ""), 0);
         AV17GAMUser = AV10GAMRepository.getuserbylogin(context.GetMessage( "local", ""), context.GetMessage( "admin", ""), out  AV11GAMErrorCollection);
         AV18GAMPermissionFilter.gxTpr_Applicationid = 2;
         AV22GAMPermissionCollection = AV17GAMUser.getallpermissions(AV18GAMPermissionFilter, out  AV11GAMErrorCollection);
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV8RoleNameCollection.Count )
         {
            AV12RoleName = ((string)AV8RoleNameCollection.Item(AV24GXV1));
            AV13PermNameCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV14PermFile.Source = context.GetMessage( "perms/", "")+AV12RoleName+context.GetMessage( ".json", "");
            AV16PermJSON = AV14PermFile.ReadAllText("");
            AV13PermNameCollection.FromJSonString(AV16PermJSON, null);
            AV9GAMRole = AV9GAMRole.getbyname(AV12RoleName, out  AV11GAMErrorCollection);
            new prc_logtofile(context ).execute(  ">>> "+AV9GAMRole.gxTpr_Name) ;
            AV25GXV2 = 1;
            while ( AV25GXV2 <= AV22GAMPermissionCollection.Count )
            {
               AV19GAMPermission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV22GAMPermissionCollection.Item(AV25GXV2));
               AV20Name = StringUtil.Trim( AV19GAMPermission.gxTpr_Name);
               if ( (AV13PermNameCollection.IndexOf(StringUtil.RTrim( AV20Name))>0) )
               {
                  AV23isok = AV9GAMRole.addpermission(AV19GAMPermission, out  AV11GAMErrorCollection);
                  if ( AV23isok )
                  {
                     new prc_logtofile(context ).execute(  "          >>> "+AV20Name) ;
                     context.CommitDataStores("prc_createpermissions",pr_default);
                  }
               }
               AV25GXV2 = (int)(AV25GXV2+1);
            }
            AV24GXV1 = (int)(AV24GXV1+1);
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
         AV8RoleNameCollection = new GxSimpleCollection<string>();
         AV17GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV18GAMPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV22GAMPermissionCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV12RoleName = "";
         AV13PermNameCollection = new GxSimpleCollection<string>();
         AV14PermFile = new GxFile(context.GetPhysicalPath());
         AV16PermJSON = "";
         AV9GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV19GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV20Name = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV1 ;
      private int AV25GXV2 ;
      private bool AV23isok ;
      private string AV16PermJSON ;
      private string AV12RoleName ;
      private string AV20Name ;
      private GxFile AV14PermFile ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV8RoleNameCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV10GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV18GAMPermissionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV22GAMPermissionCollection ;
      private GxSimpleCollection<string> AV13PermNameCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV9GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV19GAMPermission ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createpermissions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_createpermissions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createpermissions__default : DataStoreHelperBase, IDataStoreHelper
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
