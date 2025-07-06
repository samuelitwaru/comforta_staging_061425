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
   public class dp_residentaccessgroups : GXProcedure
   {
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

      public dp_residentaccessgroups( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_residentaccessgroups( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem>( context, "SDT_ResidentPackageItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem>( context, "SDT_ResidentPackageItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Udparg3 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P000Z2 */
         pr_default.execute(0, new Object[] {AV8Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A528SG_LocationId = P000Z2_A528SG_LocationId[0];
            A527ResidentPackageId = P000Z2_A527ResidentPackageId[0];
            A531ResidentPackageName = P000Z2_A531ResidentPackageName[0];
            Gxm1sdt_residentpackage = new SdtSDT_ResidentPackage_SDT_ResidentPackageItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentpackage, 0);
            Gxm1sdt_residentpackage.gxTpr_Residentpackageid = A527ResidentPackageId;
            Gxm1sdt_residentpackage.gxTpr_Residentpackagename = A531ResidentPackageName;
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
         AV8Udparg3 = Guid.Empty;
         P000Z2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P000Z2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P000Z2_A531ResidentPackageName = new string[] {""} ;
         A528SG_LocationId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         A531ResidentPackageName = "";
         Gxm1sdt_residentpackage = new SdtSDT_ResidentPackage_SDT_ResidentPackageItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_residentaccessgroups__default(),
            new Object[][] {
                new Object[] {
               P000Z2_A528SG_LocationId, P000Z2_A527ResidentPackageId, P000Z2_A531ResidentPackageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A531ResidentPackageName ;
      private Guid AV8Udparg3 ;
      private Guid A528SG_LocationId ;
      private Guid A527ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000Z2_A528SG_LocationId ;
      private Guid[] P000Z2_A527ResidentPackageId ;
      private string[] P000Z2_A531ResidentPackageName ;
      private SdtSDT_ResidentPackage_SDT_ResidentPackageItem Gxm1sdt_residentpackage ;
      private GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> aP0_Gxm2rootcol ;
   }

   public class dp_residentaccessgroups__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000Z2;
          prmP000Z2 = new Object[] {
          new ParDef("AV8Udparg3",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Z2", "SELECT SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE SG_LocationId = :AV8Udparg3 ORDER BY SG_LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Z2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
