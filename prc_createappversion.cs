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
   public class prc_createappversion : GXProcedure
   {
      public prc_createappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AppVersionName ,
                           bool aP1_IsActive ,
                           out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                           out SdtSDT_Error aP3_SDT_Error ,
                           Guid aP4_LocationId ,
                           Guid aP5_OrganisationId )
      {
         this.AV22AppVersionName = aP0_AppVersionName;
         this.AV23IsActive = aP1_IsActive;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         this.AV10LocationId = aP4_LocationId;
         this.AV13OrganisationId = aP5_OrganisationId;
         initialize();
         ExecuteImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      public void executeSubmit( string aP0_AppVersionName ,
                                 bool aP1_IsActive ,
                                 out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                                 out SdtSDT_Error aP3_SDT_Error ,
                                 Guid aP4_LocationId ,
                                 Guid aP5_OrganisationId )
      {
         this.AV22AppVersionName = aP0_AppVersionName;
         this.AV23IsActive = aP1_IsActive;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         this.AV10LocationId = aP4_LocationId;
         this.AV13OrganisationId = aP5_OrganisationId;
         SubmitImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         if ( (Guid.Empty==AV10LocationId) )
         {
            GXt_guid1 = AV10LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV10LocationId = GXt_guid1;
         }
         if ( (Guid.Empty==AV13OrganisationId) )
         {
            GXt_guid1 = AV13OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV13OrganisationId = GXt_guid1;
         }
         AV11BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
         AV11BC_Trn_AppVersion.gxTpr_Appversionname = AV22AppVersionName;
         AV11BC_Trn_AppVersion.gxTpr_Locationid = AV10LocationId;
         AV11BC_Trn_AppVersion.gxTpr_Organisationid = AV13OrganisationId;
         AV11BC_Trn_AppVersion.gxTpr_Isactive = AV23IsActive;
         GXt_guid1 = Guid.Empty;
         new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
         AV11BC_Trn_AppVersion.gxTpr_Trn_themeid = GXt_guid1;
         /* Execute user subroutine: 'SAVEAPPVERSION' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         new prc_initmodulepages(context ).execute(  AV11BC_Trn_AppVersion.gxTpr_Appversionid, out  AV25BC_MyActivityPage, out  AV24BC_CalendarPage, out  AV26BC_MapsPage) ;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV25BC_MyActivityPage, 0);
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV24BC_CalendarPage, 0);
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV26BC_MapsPage, 0);
         /* Execute user subroutine: 'SAVEAPPVERSION' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11BC_Trn_AppVersion.Save();
         GXt_SdtTrn_AppVersion_Page2 = AV18BC_HomePage;
         new prc_inithomepage(context ).execute(  AV11BC_Trn_AppVersion.gxTpr_Appversionid, out  GXt_SdtTrn_AppVersion_Page2) ;
         AV18BC_HomePage = GXt_SdtTrn_AppVersion_Page2;
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV18BC_HomePage, 0);
         /* Execute user subroutine: 'SAVEAPPVERSION' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         new prc_activateappversion(context ).execute(  AV11BC_Trn_AppVersion.gxTpr_Appversionid, out  AV8SDT_AppVersion, out  AV9SDT_Error,  AV10LocationId) ;
         cleanup();
      }

      protected void S111( )
      {
         /* 'SAVEAPPVERSION' Routine */
         returnInSub = false;
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createappversion",pr_default);
         }
         else
         {
            AV28GXV2 = 1;
            AV27GXV1 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV28GXV2 <= AV27GXV1.Count )
            {
               AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV27GXV1.Item(AV28GXV2));
               GX_msglist.addItem(AV21Message.gxTpr_Description);
               returnInSub = true;
               if (true) return;
               AV28GXV2 = (int)(AV28GXV2+1);
            }
            AV11BC_Trn_AppVersion.Delete();
            context.CommitDataStores("prc_createappversion",pr_default);
         }
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
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         GXt_guid1 = Guid.Empty;
         AV25BC_MyActivityPage = new SdtTrn_AppVersion_Page(context);
         AV24BC_CalendarPage = new SdtTrn_AppVersion_Page(context);
         AV26BC_MapsPage = new SdtTrn_AppVersion_Page(context);
         AV18BC_HomePage = new SdtTrn_AppVersion_Page(context);
         GXt_SdtTrn_AppVersion_Page2 = new SdtTrn_AppVersion_Page(context);
         AV27GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createappversion__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV28GXV2 ;
      private bool AV23IsActive ;
      private bool returnInSub ;
      private string AV22AppVersionName ;
      private Guid AV10LocationId ;
      private Guid AV13OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV25BC_MyActivityPage ;
      private SdtTrn_AppVersion_Page AV24BC_CalendarPage ;
      private SdtTrn_AppVersion_Page AV26BC_MapsPage ;
      private SdtTrn_AppVersion_Page AV18BC_HomePage ;
      private SdtTrn_AppVersion_Page GXt_SdtTrn_AppVersion_Page2 ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private SdtSDT_AppVersion aP2_SDT_AppVersion ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createappversion__default : DataStoreHelperBase, IDataStoreHelper
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
