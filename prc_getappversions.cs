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
   public class prc_getappversions : GXProcedure
   {
      public prc_getappversions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getappversions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ,
                           ref SdtSDT_Error aP1_SDT_Error )
      {
         this.AV8SDT_AppVersionCollection = aP0_SDT_AppVersionCollection;
         this.AV11SDT_Error = aP1_SDT_Error;
         initialize();
         ExecuteImpl();
         aP0_SDT_AppVersionCollection=this.AV8SDT_AppVersionCollection;
         aP1_SDT_Error=this.AV11SDT_Error;
      }

      public SdtSDT_Error executeUdp( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection )
      {
         execute(ref aP0_SDT_AppVersionCollection, ref aP1_SDT_Error);
         return AV11SDT_Error ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ,
                                 ref SdtSDT_Error aP1_SDT_Error )
      {
         this.AV8SDT_AppVersionCollection = aP0_SDT_AppVersionCollection;
         this.AV11SDT_Error = aP1_SDT_Error;
         SubmitImpl();
         aP0_SDT_AppVersionCollection=this.AV8SDT_AppVersionCollection;
         aP1_SDT_Error=this.AV11SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV11SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV11SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV19Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00BE2 */
         pr_default.execute(0, new Object[] {AV19Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00BE2_A29LocationId[0];
            n29LocationId = P00BE2_n29LocationId[0];
            A620IsVersionDeleted = P00BE2_A620IsVersionDeleted[0];
            A523AppVersionId = P00BE2_A523AppVersionId[0];
            A524AppVersionName = P00BE2_A524AppVersionName[0];
            AV10BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
            AV10BC_Trn_AppVersion.Load(A523AppVersionId);
            new prc_loadappversionsdt(context ).execute(  AV10BC_Trn_AppVersion, out  AV9SDT_AppVersion) ;
            AV8SDT_AppVersionCollection.Add(AV9SDT_AppVersion, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV19Udparg1 = Guid.Empty;
         P00BE2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BE2_n29LocationId = new bool[] {false} ;
         P00BE2_A620IsVersionDeleted = new bool[] {false} ;
         P00BE2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BE2_A524AppVersionName = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         A524AppVersionName = "";
         AV10BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getappversions__default(),
            new Object[][] {
                new Object[] {
               P00BE2_A29LocationId, P00BE2_n29LocationId, P00BE2_A620IsVersionDeleted, P00BE2_A523AppVersionId, P00BE2_A524AppVersionName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private bool A620IsVersionDeleted ;
      private string A524AppVersionName ;
      private Guid AV19Udparg1 ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AppVersion> AV8SDT_AppVersionCollection ;
      private GXBaseCollection<SdtSDT_AppVersion> aP0_SDT_AppVersionCollection ;
      private SdtSDT_Error AV11SDT_Error ;
      private SdtSDT_Error aP1_SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BE2_A29LocationId ;
      private bool[] P00BE2_n29LocationId ;
      private bool[] P00BE2_A620IsVersionDeleted ;
      private Guid[] P00BE2_A523AppVersionId ;
      private string[] P00BE2_A524AppVersionName ;
      private SdtTrn_AppVersion AV10BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
   }

   public class prc_getappversions__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BE2;
          prmP00BE2 = new Object[] {
          new ParDef("AV19Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BE2", "SELECT LocationId, IsVersionDeleted, AppVersionId, AppVersionName FROM Trn_AppVersion WHERE (LocationId = :AV19Udparg1) AND (IsVersionDeleted = FALSE) ORDER BY AppVersionName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BE2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
