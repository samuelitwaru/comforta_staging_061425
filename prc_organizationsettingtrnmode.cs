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
   public class prc_organizationsettingtrnmode : GXProcedure
   {
      public prc_organizationsettingtrnmode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_organizationsettingtrnmode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_TrnMode )
      {
         this.AV8TrnMode = "" ;
         initialize();
         ExecuteImpl();
         aP0_TrnMode=this.AV8TrnMode;
      }

      public string executeUdp( )
      {
         execute(out aP0_TrnMode);
         return AV8TrnMode ;
      }

      public void executeSubmit( out string aP0_TrnMode )
      {
         this.AV8TrnMode = "" ;
         SubmitImpl();
         aP0_TrnMode=this.AV8TrnMode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         AV11Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P006Y2 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P006Y2_A11OrganisationId[0];
            A100OrganisationSettingid = P006Y2_A100OrganisationSettingid[0];
            AV10GXLvl1 = 1;
            AV8TrnMode = "UPD";
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV8TrnMode = "INS";
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
         AV8TrnMode = "";
         AV11Udparg1 = Guid.Empty;
         P006Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Y2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_organizationsettingtrnmode__default(),
            new Object[][] {
                new Object[] {
               P006Y2_A11OrganisationId, P006Y2_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private string AV8TrnMode ;
      private Guid AV11Udparg1 ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Y2_A11OrganisationId ;
      private Guid[] P006Y2_A100OrganisationSettingid ;
      private string aP0_TrnMode ;
   }

   public class prc_organizationsettingtrnmode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006Y2;
          prmP006Y2 = new Object[] {
          new ParDef("AV11Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Y2", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV11Udparg1 ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y2,100, GxCacheFrequency.OFF ,false,false )
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
