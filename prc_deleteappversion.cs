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
   public class prc_deleteappversion : GXProcedure
   {
      public prc_deleteappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deleteappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out string aP1_result ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV17result = "" ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_result=this.AV17result;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      out string aP1_result )
      {
         execute(aP0_AppVersionId, out aP1_result, out aP2_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out string aP1_result ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV17result = "" ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_result=this.AV17result;
         aP2_SDT_Error=this.AV9SDT_Error;
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
         GXt_guid1 = AV11LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV11LocationId = GXt_guid1;
         /* Using cursor P00EG2 */
         pr_default.execute(0, new Object[] {AV11LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00EG2_A29LocationId[0];
            n29LocationId = P00EG2_n29LocationId[0];
            A584ActiveAppVersionId = P00EG2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00EG2_n584ActiveAppVersionId[0];
            A11OrganisationId = P00EG2_A11OrganisationId[0];
            AV18ActiveAppVersionId = A584ActiveAppVersionId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV18ActiveAppVersionId == AV10AppVersionId )
         {
            AV17result = context.GetMessage( "Failed", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00EG3 */
         pr_default.execute(1, new Object[] {AV10AppVersionId, AV11LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00EG3_A29LocationId[0];
            n29LocationId = P00EG3_n29LocationId[0];
            A523AppVersionId = P00EG3_A523AppVersionId[0];
            A620IsVersionDeleted = P00EG3_A620IsVersionDeleted[0];
            A622VersionDeletedAt = P00EG3_A622VersionDeletedAt[0];
            n622VersionDeletedAt = P00EG3_n622VersionDeletedAt[0];
            A620IsVersionDeleted = true;
            A622VersionDeletedAt = DateTimeUtil.Now( context);
            n622VersionDeletedAt = false;
            AV17result = context.GetMessage( "OK", "");
            /* Using cursor P00EG4 */
            pr_default.execute(2, new Object[] {A620IsVersionDeleted, n622VersionDeletedAt, A622VersionDeletedAt, A523AppVersionId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deleteappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV17result = "";
         AV9SDT_Error = new SdtSDT_Error(context);
         AV11LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00EG2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00EG2_n29LocationId = new bool[] {false} ;
         P00EG2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00EG2_n584ActiveAppVersionId = new bool[] {false} ;
         P00EG2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV18ActiveAppVersionId = Guid.Empty;
         P00EG3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00EG3_n29LocationId = new bool[] {false} ;
         P00EG3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00EG3_A620IsVersionDeleted = new bool[] {false} ;
         P00EG3_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         P00EG3_n622VersionDeletedAt = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deleteappversion__default(),
            new Object[][] {
                new Object[] {
               P00EG2_A29LocationId, P00EG2_A584ActiveAppVersionId, P00EG2_n584ActiveAppVersionId, P00EG2_A11OrganisationId
               }
               , new Object[] {
               P00EG3_A29LocationId, P00EG3_n29LocationId, P00EG3_A523AppVersionId, P00EG3_A620IsVersionDeleted, P00EG3_A622VersionDeletedAt, P00EG3_n622VersionDeletedAt
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A622VersionDeletedAt ;
      private bool n29LocationId ;
      private bool n584ActiveAppVersionId ;
      private bool A620IsVersionDeleted ;
      private bool n622VersionDeletedAt ;
      private string AV17result ;
      private Guid AV10AppVersionId ;
      private Guid AV11LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A11OrganisationId ;
      private Guid AV18ActiveAppVersionId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV9SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EG2_A29LocationId ;
      private bool[] P00EG2_n29LocationId ;
      private Guid[] P00EG2_A584ActiveAppVersionId ;
      private bool[] P00EG2_n584ActiveAppVersionId ;
      private Guid[] P00EG2_A11OrganisationId ;
      private Guid[] P00EG3_A29LocationId ;
      private bool[] P00EG3_n29LocationId ;
      private Guid[] P00EG3_A523AppVersionId ;
      private bool[] P00EG3_A620IsVersionDeleted ;
      private DateTime[] P00EG3_A622VersionDeletedAt ;
      private bool[] P00EG3_n622VersionDeletedAt ;
      private string aP1_result ;
      private SdtSDT_Error aP2_SDT_Error ;
   }

   public class prc_deleteappversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EG2;
          prmP00EG2 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EG3;
          prmP00EG3 = new Object[] {
          new ParDef("AV10AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EG4;
          prmP00EG4 = new Object[] {
          new ParDef("IsVersionDeleted",GXType.Boolean,4,0) ,
          new ParDef("VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EG2", "SELECT LocationId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV11LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EG3", "SELECT LocationId, AppVersionId, IsVersionDeleted, VersionDeletedAt FROM Trn_AppVersion WHERE (AppVersionId = :AV10AppVersionId) AND (LocationId = :AV11LocationId) ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EG3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00EG4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET IsVersionDeleted=:IsVersionDeleted, VersionDeletedAt=:VersionDeletedAt  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00EG4)
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
