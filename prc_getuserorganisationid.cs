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
   public class prc_getuserorganisationid : GXProcedure
   {
      public prc_getuserorganisationid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserorganisationid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_OrganisationId )
      {
         this.AV11OrganisationId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP0_OrganisationId=this.AV11OrganisationId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_OrganisationId);
         return AV11OrganisationId ;
      }

      public void executeSubmit( out Guid aP0_OrganisationId )
      {
         this.AV11OrganisationId = Guid.Empty ;
         SubmitImpl();
         aP0_OrganisationId=this.AV11OrganisationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV10GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV10GAMUser = GXt_SdtGAMUser1;
         if ( AV10GAMUser.checkrole("Organisation Manager") )
         {
            /* Using cursor P005R2 */
            pr_default.execute(0, new Object[] {AV10GAMUser.gxTpr_Email, AV10GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = P005R2_A25ManagerEmail[0];
               A28ManagerGAMGUID = P005R2_A28ManagerGAMGUID[0];
               A11OrganisationId = P005R2_A11OrganisationId[0];
               A21ManagerId = P005R2_A21ManagerId[0];
               AV11OrganisationId = A11OrganisationId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV10GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P005R3 */
            pr_default.execute(1, new Object[] {AV10GAMUser.gxTpr_Email, AV10GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P005R3_A11OrganisationId[0];
               A93ReceptionistEmail = P005R3_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P005R3_A95ReceptionistGAMGUID[0];
               A29LocationId = P005R3_A29LocationId[0];
               A89ReceptionistId = P005R3_A89ReceptionistId[0];
               AV12LocationId = A29LocationId;
               /* Using cursor P005R4 */
               pr_default.execute(2, new Object[] {AV12LocationId, A11OrganisationId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A29LocationId = P005R4_A29LocationId[0];
                  AV11OrganisationId = A11OrganisationId;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV11OrganisationId = Guid.Empty;
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P005R2_A25ManagerEmail = new string[] {""} ;
         P005R2_A28ManagerGAMGUID = new string[] {""} ;
         P005R2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005R2_A21ManagerId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         P005R3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005R3_A93ReceptionistEmail = new string[] {""} ;
         P005R3_A95ReceptionistGAMGUID = new string[] {""} ;
         P005R3_A29LocationId = new Guid[] {Guid.Empty} ;
         P005R3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         P005R4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005R4_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getuserorganisationid__default(),
            new Object[][] {
                new Object[] {
               P005R2_A25ManagerEmail, P005R2_A28ManagerGAMGUID, P005R2_A11OrganisationId, P005R2_A21ManagerId
               }
               , new Object[] {
               P005R3_A11OrganisationId, P005R3_A93ReceptionistEmail, P005R3_A95ReceptionistGAMGUID, P005R3_A29LocationId, P005R3_A89ReceptionistId
               }
               , new Object[] {
               P005R4_A11OrganisationId, P005R4_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private Guid AV11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid AV12LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private IDataStoreProvider pr_default ;
      private string[] P005R2_A25ManagerEmail ;
      private string[] P005R2_A28ManagerGAMGUID ;
      private Guid[] P005R2_A11OrganisationId ;
      private Guid[] P005R2_A21ManagerId ;
      private Guid[] P005R3_A11OrganisationId ;
      private string[] P005R3_A93ReceptionistEmail ;
      private string[] P005R3_A95ReceptionistGAMGUID ;
      private Guid[] P005R3_A29LocationId ;
      private Guid[] P005R3_A89ReceptionistId ;
      private Guid[] P005R4_A11OrganisationId ;
      private Guid[] P005R4_A29LocationId ;
      private Guid aP0_OrganisationId ;
   }

   public class prc_getuserorganisationid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005R2;
          prmP005R2 = new Object[] {
          new ParDef("AV10GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV10GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP005R3;
          prmP005R3 = new Object[] {
          new ParDef("AV10GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV10GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP005R4;
          prmP005R4 = new Object[] {
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005R2", "SELECT ManagerEmail, ManagerGAMGUID, OrganisationId, ManagerId FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV10GAMUser__Email)) AND (ManagerGAMGUID = ( :AV10GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005R3", "SELECT OrganisationId, ReceptionistEmail, ReceptionistGAMGUID, LocationId, ReceptionistId FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV10GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV10GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005R4", "SELECT OrganisationId, LocationId FROM Trn_Location WHERE LocationId = :AV12LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
