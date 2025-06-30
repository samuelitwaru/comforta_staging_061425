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
   public class dp_locationresident : GXProcedure
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

      public dp_locationresident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_locationresident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem>( context, "SDT_ResidentAddressBookItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem>( context, "SDT_ResidentAddressBookItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Udparg3 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P000O2 */
         pr_default.execute(0, new Object[] {AV8Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P000O2_A29LocationId[0];
            A62ResidentId = P000O2_A62ResidentId[0];
            A11OrganisationId = P000O2_A11OrganisationId[0];
            A64ResidentGivenName = P000O2_A64ResidentGivenName[0];
            A65ResidentLastName = P000O2_A65ResidentLastName[0];
            Gxm1sdt_residentaddressbook = new SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentaddressbook, 0);
            Gxm1sdt_residentaddressbook.gxTpr_Residentid = A62ResidentId;
            Gxm1sdt_residentaddressbook.gxTpr_Locationid = A29LocationId;
            Gxm1sdt_residentaddressbook.gxTpr_Organisationid = A11OrganisationId;
            Gxm1sdt_residentaddressbook.gxTpr_Residentgivenname = A64ResidentGivenName;
            Gxm1sdt_residentaddressbook.gxTpr_Residentlastname = A65ResidentLastName;
            Gxm1sdt_residentaddressbook.gxTpr_Residentfullname = A64ResidentGivenName+" "+A65ResidentLastName;
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
         P000O2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000O2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P000O2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000O2_A64ResidentGivenName = new string[] {""} ;
         P000O2_A65ResidentLastName = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         Gxm1sdt_residentaddressbook = new SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_locationresident__default(),
            new Object[][] {
                new Object[] {
               P000O2_A29LocationId, P000O2_A62ResidentId, P000O2_A11OrganisationId, P000O2_A64ResidentGivenName, P000O2_A65ResidentLastName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private Guid AV8Udparg3 ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000O2_A29LocationId ;
      private Guid[] P000O2_A62ResidentId ;
      private Guid[] P000O2_A11OrganisationId ;
      private string[] P000O2_A64ResidentGivenName ;
      private string[] P000O2_A65ResidentLastName ;
      private SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem Gxm1sdt_residentaddressbook ;
      private GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> aP0_Gxm2rootcol ;
   }

   public class dp_locationresident__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000O2;
          prmP000O2 = new Object[] {
          new ParDef("AV8Udparg3",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000O2", "SELECT LocationId, ResidentId, OrganisationId, ResidentGivenName, ResidentLastName FROM Trn_Resident WHERE LocationId = :AV8Udparg3 ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
