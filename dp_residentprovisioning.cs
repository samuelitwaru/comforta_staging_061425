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
   public class dp_residentprovisioning : GXProcedure
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

      public dp_residentprovisioning( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_residentprovisioning( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV6LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV6LocationId = GXt_guid1;
         /* Using cursor P000S2 */
         pr_default.execute(0, new Object[] {AV6LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A570LocationHasMyCare = P000S2_A570LocationHasMyCare[0];
            A29LocationId = P000S2_A29LocationId[0];
            A11OrganisationId = P000S2_A11OrganisationId[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisiondescription = context.GetMessage( "My Care", "");
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisionvalue = "My Care";
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P000S3 */
         pr_default.execute(1, new Object[] {AV6LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A572LocationHasMyLiving = P000S3_A572LocationHasMyLiving[0];
            A29LocationId = P000S3_A29LocationId[0];
            A11OrganisationId = P000S3_A11OrganisationId[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisiondescription = context.GetMessage( "My Living", "");
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisionvalue = "My Living";
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P000S4 */
         pr_default.execute(2, new Object[] {AV6LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A571LocationHasMyServices = P000S4_A571LocationHasMyServices[0];
            A29LocationId = P000S4_A29LocationId[0];
            A11OrganisationId = P000S4_A11OrganisationId[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisiondescription = context.GetMessage( "My Services", "");
            Gxm1sdt_residentprovisioning.gxTpr_Residentprovisionvalue = "My Services";
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV6LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P000S2_A570LocationHasMyCare = new bool[] {false} ;
         P000S2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000S2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
         P000S3_A572LocationHasMyLiving = new bool[] {false} ;
         P000S3_A29LocationId = new Guid[] {Guid.Empty} ;
         P000S3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000S4_A571LocationHasMyServices = new bool[] {false} ;
         P000S4_A29LocationId = new Guid[] {Guid.Empty} ;
         P000S4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_residentprovisioning__default(),
            new Object[][] {
                new Object[] {
               P000S2_A570LocationHasMyCare, P000S2_A29LocationId, P000S2_A11OrganisationId
               }
               , new Object[] {
               P000S3_A572LocationHasMyLiving, P000S3_A29LocationId, P000S3_A11OrganisationId
               }
               , new Object[] {
               P000S4_A571LocationHasMyServices, P000S4_A29LocationId, P000S4_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A570LocationHasMyCare ;
      private bool A572LocationHasMyLiving ;
      private bool A571LocationHasMyServices ;
      private Guid AV6LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P000S2_A570LocationHasMyCare ;
      private Guid[] P000S2_A29LocationId ;
      private Guid[] P000S2_A11OrganisationId ;
      private SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem Gxm1sdt_residentprovisioning ;
      private bool[] P000S3_A572LocationHasMyLiving ;
      private Guid[] P000S3_A29LocationId ;
      private Guid[] P000S3_A11OrganisationId ;
      private bool[] P000S4_A571LocationHasMyServices ;
      private Guid[] P000S4_A29LocationId ;
      private Guid[] P000S4_A11OrganisationId ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP0_Gxm2rootcol ;
   }

   public class dp_residentprovisioning__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000S2;
          prmP000S2 = new Object[] {
          new ParDef("AV6LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000S3;
          prmP000S3 = new Object[] {
          new ParDef("AV6LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000S4;
          prmP000S4 = new Object[] {
          new ParDef("AV6LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000S2", "SELECT LocationHasMyCare, LocationId, OrganisationId FROM Trn_Location WHERE (LocationId = :AV6LocationId) AND (LocationHasMyCare = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000S2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000S3", "SELECT LocationHasMyLiving, LocationId, OrganisationId FROM Trn_Location WHERE (LocationId = :AV6LocationId) AND (LocationHasMyLiving = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000S3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000S4", "SELECT LocationHasMyServices, LocationId, OrganisationId FROM Trn_Location WHERE (LocationId = :AV6LocationId) AND (LocationHasMyServices = TRUE) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000S4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
