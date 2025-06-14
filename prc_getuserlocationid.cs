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
   public class prc_getuserlocationid : GXProcedure
   {
      public prc_getuserlocationid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserlocationid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_LocationId )
      {
         this.AV8LocationId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV8LocationId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_LocationId);
         return AV8LocationId ;
      }

      public void executeSubmit( out Guid aP0_LocationId )
      {
         this.AV8LocationId = Guid.Empty ;
         SubmitImpl();
         aP0_LocationId=this.AV8LocationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV9GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV9GAMUser = GXt_SdtGAMUser1;
         if ( AV9GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P005S2 */
            pr_default.execute(0, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A93ReceptionistEmail = P005S2_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P005S2_A95ReceptionistGAMGUID[0];
               A29LocationId = P005S2_A29LocationId[0];
               A89ReceptionistId = P005S2_A89ReceptionistId[0];
               A11OrganisationId = P005S2_A11OrganisationId[0];
               AV8LocationId = A29LocationId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV8LocationId = Guid.Empty;
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P005S2_A93ReceptionistEmail = new string[] {""} ;
         P005S2_A95ReceptionistGAMGUID = new string[] {""} ;
         P005S2_A29LocationId = new Guid[] {Guid.Empty} ;
         P005S2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P005S2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getuserlocationid__default(),
            new Object[][] {
                new Object[] {
               P005S2_A93ReceptionistEmail, P005S2_A95ReceptionistGAMGUID, P005S2_A29LocationId, P005S2_A89ReceptionistId, P005S2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private Guid AV8LocationId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private IDataStoreProvider pr_default ;
      private string[] P005S2_A93ReceptionistEmail ;
      private string[] P005S2_A95ReceptionistGAMGUID ;
      private Guid[] P005S2_A29LocationId ;
      private Guid[] P005S2_A89ReceptionistId ;
      private Guid[] P005S2_A11OrganisationId ;
      private Guid aP0_LocationId ;
   }

   public class prc_getuserlocationid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "SELECT ReceptionistEmail, ReceptionistGAMGUID, LocationId, ReceptionistId, OrganisationId FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV9GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
