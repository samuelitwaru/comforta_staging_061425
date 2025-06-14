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
   public class prc_organizationsettingid : GXProcedure
   {
      public prc_organizationsettingid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_organizationsettingid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_OrganisationSettingId )
      {
         this.AV9OrganisationSettingId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP0_OrganisationSettingId=this.AV9OrganisationSettingId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_OrganisationSettingId);
         return AV9OrganisationSettingId ;
      }

      public void executeSubmit( out Guid aP0_OrganisationSettingId )
      {
         this.AV9OrganisationSettingId = Guid.Empty ;
         SubmitImpl();
         aP0_OrganisationSettingId=this.AV9OrganisationSettingId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P006Z2 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P006Z2_A11OrganisationId[0];
            A100OrganisationSettingid = P006Z2_A100OrganisationSettingid[0];
            AV9OrganisationSettingId = A100OrganisationSettingid;
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
         AV9OrganisationSettingId = Guid.Empty;
         AV11Udparg1 = Guid.Empty;
         P006Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Z2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_organizationsettingid__default(),
            new Object[][] {
                new Object[] {
               P006Z2_A11OrganisationId, P006Z2_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV9OrganisationSettingId ;
      private Guid AV11Udparg1 ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Z2_A11OrganisationId ;
      private Guid[] P006Z2_A100OrganisationSettingid ;
      private Guid aP0_OrganisationSettingId ;
   }

   public class prc_organizationsettingid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006Z2;
          prmP006Z2 = new Object[] {
          new ParDef("AV11Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Z2", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV11Udparg1 ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z2,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
