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
   public class prc_logoutuser : GXProcedure
   {
      public prc_logoutuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_logoutuser( IGxContext context )
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
         GXt_char1 = AV11UserId;
         new prc_getloggedinuserid(context ).execute( out  GXt_char1) ;
         AV11UserId = GXt_char1;
         /* Using cursor P00GI2 */
         pr_default.execute(0, new Object[] {AV11UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A630ToolBoxLastUpdateReceptionistI = P00GI2_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00GI2_n630ToolBoxLastUpdateReceptionistI[0];
            A11OrganisationId = P00GI2_A11OrganisationId[0];
            A29LocationId = P00GI2_A29LocationId[0];
            A89ReceptionistId = P00GI2_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = P00GI2_A95ReceptionistGAMGUID[0];
            A630ToolBoxLastUpdateReceptionistI = P00GI2_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00GI2_n630ToolBoxLastUpdateReceptionistI[0];
            /* Using cursor P00GI3 */
            pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A630ToolBoxLastUpdateReceptionistI = P00GI3_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = P00GI3_n630ToolBoxLastUpdateReceptionistI[0];
               new prc_updatetoolboxstatus(context ).execute(  false) ;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8isOk = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logout(out  AV10GAMErrorCollection);
         AV9WebSession.Clear();
         CallWebObject(formatLink("ulogin.aspx") );
         context.wjLocDisableFrm = 1;
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
         AV11UserId = "";
         GXt_char1 = "";
         P00GI2_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00GI2_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00GI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GI2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GI2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00GI2_A95ReceptionistGAMGUID = new string[] {""} ;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A95ReceptionistGAMGUID = "";
         P00GI3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GI3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GI3_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00GI3_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9WebSession = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_logoutuser__default(),
            new Object[][] {
                new Object[] {
               P00GI2_A630ToolBoxLastUpdateReceptionistI, P00GI2_n630ToolBoxLastUpdateReceptionistI, P00GI2_A11OrganisationId, P00GI2_A29LocationId, P00GI2_A89ReceptionistId, P00GI2_A95ReceptionistGAMGUID
               }
               , new Object[] {
               P00GI3_A29LocationId, P00GI3_A11OrganisationId, P00GI3_A630ToolBoxLastUpdateReceptionistI, P00GI3_n630ToolBoxLastUpdateReceptionistI
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool AV8isOk ;
      private string AV11UserId ;
      private string A95ReceptionistGAMGUID ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private IGxSession AV9WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GI2_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00GI2_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] P00GI2_A11OrganisationId ;
      private Guid[] P00GI2_A29LocationId ;
      private Guid[] P00GI2_A89ReceptionistId ;
      private string[] P00GI2_A95ReceptionistGAMGUID ;
      private Guid[] P00GI3_A29LocationId ;
      private Guid[] P00GI3_A11OrganisationId ;
      private Guid[] P00GI3_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00GI3_n630ToolBoxLastUpdateReceptionistI ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
   }

   public class prc_logoutuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GI2;
          prmP00GI2 = new Object[] {
          new ParDef("AV11UserId",GXType.VarChar,100,0)
          };
          Object[] prmP00GI3;
          prmP00GI3 = new Object[] {
          new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GI2", "SELECT T2.ToolBoxLastUpdateReceptionistI, T1.OrganisationId, T1.LocationId, T1.ReceptionistId, T1.ReceptionistGAMGUID FROM (Trn_Receptionist T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.ReceptionistGAMGUID = ( :AV11UserId) ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GI3", "SELECT LocationId, OrganisationId, ToolBoxLastUpdateReceptionistI FROM Trn_Location WHERE ToolBoxLastUpdateReceptionistI = :ReceptionistId and OrganisationId = :OrganisationId and LocationId = :LocationId ORDER BY ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GI3,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
