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
namespace GeneXus.Programs.wwpbaseobjects {
   public class awwp_impactmetadata : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new wwpbaseobjects.awwp_impactmetadata().MainImpl(args); ;
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

      public awwp_impactmetadata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_impactmetadata( IGxContext context )
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
         context.StatusMessage( "- - - Impacting WorkWithPlus Metadata Started - - -" );
         /* Execute user subroutine: 'GAM METADATA FOR WORKWITHPLUS FOR WEB' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATE USER EXTENDED USERS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'NOTIFICATIONS METADATA' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CONDITIONAL FORMATTING METADATA' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'COMMIT DATA' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         context.StatusMessage( "- - - Impacting WorkWithPlus Metadata Ended - - -" );
         cleanup();
      }

      protected void S111( )
      {
         /* 'GAM METADATA FOR WORKWITHPLUS FOR WEB' Routine */
         returnInSub = false;
         context.StatusMessage( "Updating GAM functionality keys used in WorkWithPlus for Web objects..." );
         new GeneXus.Programs.wwpbaseobjects.secgamupdatepermissions(context ).execute( ) ;
      }

      protected void S121( )
      {
         /* 'UPDATE USER EXTENDED USERS' Routine */
         returnInSub = false;
         context.StatusMessage( "Creating Event for Sync Users..." );
         new WorkWithPlus.workwithplus_webgam.wwp_createevents(context ).execute(  "") ;
         context.StatusMessage( "Creating unexistant GAM Users in WWP_UserExtended table..." );
         AV11GAMUserCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusers(ref  AV9GAMUserFilter, out  AV8GAMErrorCollection);
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV11GAMUserCollection.Count )
         {
            AV10GAMUser = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV11GAMUserCollection.Item(AV13GXV1));
            if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV10GAMUser.gxTpr_Guid) )
            {
               context.StatusMessage( StringUtil.Format( "Creating User Extended %1...", AV10GAMUser.gxTpr_Guid, "", "", "", "", "", "", "", "") );
               new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "INS",  AV10GAMUser, out  AV12Messages) ;
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         context.CommitDataStores("wwpbaseobjects.wwp_impactmetadata",pr_default);
      }

      protected void S131( )
      {
         /* 'NOTIFICATIONS METADATA' Routine */
         returnInSub = false;
         context.StatusMessage( "Updating Metadata for Notifications..." );
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_updatenotificationdefinitions(context ).execute( ) ;
      }

      protected void S141( )
      {
         /* 'CONDITIONAL FORMATTING METADATA' Routine */
         returnInSub = false;
         context.StatusMessage( "Updating Metadata for Conditional Formatting..." );
         new GeneXus.Programs.workwithplus.wwp_updateapplicationparameters(context ).execute( ) ;
      }

      protected void S151( )
      {
         /* 'COMMIT DATA' Routine */
         returnInSub = false;
         context.CommitDataStores("wwpbaseobjects.wwp_impactmetadata",pr_default);
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
         AV11GAMUserCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV9GAMUserFilter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.awwp_impactmetadata__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.awwp_impactmetadata__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.awwp_impactmetadata__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV11GAMUserCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV9GAMUserFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class awwp_impactmetadata__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class awwp_impactmetadata__gam : DataStoreHelperBase, IDataStoreHelper
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

public class awwp_impactmetadata__default : DataStoreHelperBase, IDataStoreHelper
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
