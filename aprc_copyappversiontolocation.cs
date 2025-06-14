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
   public class aprc_copyappversiontolocation : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_copyappversiontolocation().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_AppVersionId = new Guid()  ;
         Guid aP1_LocationId = new Guid()  ;
         if ( 0 < args.Length )
         {
            aP0_AppVersionId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_AppVersionId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_LocationId=((Guid)(StringUtil.StrToGuid( (string)(args[1]))));
         }
         else
         {
            aP1_LocationId=Guid.Empty;
         }
         execute(aP0_AppVersionId, aP1_LocationId);
         return GX.GXRuntime.ExitCode ;
      }

      public aprc_copyappversiontolocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_copyappversiontolocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_LocationId )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV10LocationId = aP1_LocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_LocationId )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV10LocationId = aP1_LocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Trn_AppVersion.Load(AV23AppVersionId);
         AV11BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
         AV11BC_Trn_AppVersion.gxTpr_Isactive = false;
         GXt_guid1 = Guid.Empty;
         new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
         AV11BC_Trn_AppVersion.gxTpr_Trn_themeid = GXt_guid1;
         /* Using cursor P00GN2 */
         pr_default.execute(0, new Object[] {AV23AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00GN2_A523AppVersionId[0];
            A524AppVersionName = P00GN2_A524AppVersionName[0];
            AV11BC_Trn_AppVersion.gxTpr_Appversionname = A524AppVersionName;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00GN3 */
         pr_default.execute(1, new Object[] {AV10LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00GN3_A29LocationId[0];
            A11OrganisationId = P00GN3_A11OrganisationId[0];
            AV11BC_Trn_AppVersion.gxTpr_Locationid = A29LocationId;
            AV11BC_Trn_AppVersion.gxTpr_Organisationid = A11OrganisationId;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV24Trn_AppVersion.gxTpr_Page.Count )
         {
            AV25TrnAppVersionPage = ((SdtTrn_AppVersion_Page)AV24Trn_AppVersion.gxTpr_Page.Item(AV28GXV1));
            AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV25TrnAppVersionPage, 0);
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_copyappversiontolocation",pr_default);
         }
         else
         {
            AV30GXV3 = 1;
            AV29GXV2 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV30GXV3 <= AV29GXV2.Count )
            {
               AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV29GXV2.Item(AV30GXV3));
               new prc_logtofile(context ).execute(  context.GetMessage( "&Message.Description", "")+AV21Message.gxTpr_Description) ;
               AV30GXV3 = (int)(AV30GXV3+1);
            }
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
         AV24Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         GXt_guid1 = Guid.Empty;
         P00GN2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GN2_A524AppVersionName = new string[] {""} ;
         A523AppVersionId = Guid.Empty;
         A524AppVersionName = "";
         P00GN3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GN3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV25TrnAppVersionPage = new SdtTrn_AppVersion_Page(context);
         AV29GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_copyappversiontolocation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_copyappversiontolocation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_copyappversiontolocation__default(),
            new Object[][] {
                new Object[] {
               P00GN2_A523AppVersionId, P00GN2_A524AppVersionName
               }
               , new Object[] {
               P00GN3_A29LocationId, P00GN3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV28GXV1 ;
      private int AV30GXV3 ;
      private string A524AppVersionName ;
      private Guid AV23AppVersionId ;
      private Guid AV10LocationId ;
      private Guid GXt_guid1 ;
      private Guid A523AppVersionId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion AV24Trn_AppVersion ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GN2_A523AppVersionId ;
      private string[] P00GN2_A524AppVersionName ;
      private Guid[] P00GN3_A29LocationId ;
      private Guid[] P00GN3_A11OrganisationId ;
      private SdtTrn_AppVersion_Page AV25TrnAppVersionPage ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV29GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_copyappversiontolocation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_copyappversiontolocation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_copyappversiontolocation__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00GN2;
       prmP00GN2 = new Object[] {
       new ParDef("AV23AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00GN3;
       prmP00GN3 = new Object[] {
       new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00GN2", "SELECT AppVersionId, AppVersionName FROM Trn_AppVersion WHERE AppVersionId = :AV23AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN2,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("P00GN3", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN3,100, GxCacheFrequency.OFF ,false,false )
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
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
