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
   public class prc_modulepageapi : GXProcedure
   {
      public prc_modulepageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_modulepageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           string aP3_UserId ,
                           out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         this.AV10PageId = aP0_PageId;
         this.AV11LocationId = aP1_LocationId;
         this.AV12OrganisationId = aP2_OrganisationId;
         this.AV9UserId = aP3_UserId;
         this.AV8SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_InfoPage=this.AV8SDT_InfoPage;
      }

      public SdtSDT_InfoPage executeUdp( Guid aP0_PageId ,
                                         Guid aP1_LocationId ,
                                         Guid aP2_OrganisationId ,
                                         string aP3_UserId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_UserId, out aP4_SDT_InfoPage);
         return AV8SDT_InfoPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_UserId ,
                                 out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         this.AV10PageId = aP0_PageId;
         this.AV11LocationId = aP1_LocationId;
         this.AV12OrganisationId = aP2_OrganisationId;
         this.AV9UserId = aP3_UserId;
         this.AV8SDT_InfoPage = new SdtSDT_InfoPage(context) ;
         SubmitImpl();
         aP4_SDT_InfoPage=this.AV8SDT_InfoPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GO2 */
         pr_default.execute(0, new Object[] {AV9UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00GO2_A71ResidentGUID[0];
            A599ResidentLanguage = P00GO2_A599ResidentLanguage[0];
            A62ResidentId = P00GO2_A62ResidentId[0];
            A29LocationId = P00GO2_A29LocationId[0];
            n29LocationId = P00GO2_n29LocationId[0];
            A11OrganisationId = P00GO2_A11OrganisationId[0];
            n11OrganisationId = P00GO2_n11OrganisationId[0];
            AV13ResidentLanguage = A599ResidentLanguage;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00GO3 */
         pr_default.execute(1, new Object[] {AV11LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00GO3_A29LocationId[0];
            n29LocationId = P00GO3_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00GO3_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00GO3_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00GO3_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00GO3_n584ActiveAppVersionId[0];
            A11OrganisationId = P00GO3_A11OrganisationId[0];
            n11OrganisationId = P00GO3_n11OrganisationId[0];
            AV14AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV14AppVersionId) )
            {
               AV14AppVersionId = A584ActiveAppVersionId;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00GO4 */
         pr_default.execute(2, new Object[] {AV11LocationId, AV12OrganisationId, AV14AppVersionId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A523AppVersionId = P00GO4_A523AppVersionId[0];
            A11OrganisationId = P00GO4_A11OrganisationId[0];
            n11OrganisationId = P00GO4_n11OrganisationId[0];
            A29LocationId = P00GO4_A29LocationId[0];
            n29LocationId = P00GO4_n29LocationId[0];
            /* Using cursor P00GO5 */
            pr_default.execute(3, new Object[] {A523AppVersionId, AV10PageId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A516PageId = P00GO5_A516PageId[0];
               A517PageName = P00GO5_A517PageName[0];
               AV8SDT_InfoPage = new SdtSDT_InfoPage(context);
               AV8SDT_InfoPage.gxTpr_Pageid = A516PageId;
               AV8SDT_InfoPage.gxTpr_Pagename = A517PageName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
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
         AV8SDT_InfoPage = new SdtSDT_InfoPage(context);
         P00GO2_A71ResidentGUID = new string[] {""} ;
         P00GO2_A599ResidentLanguage = new string[] {""} ;
         P00GO2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00GO2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GO2_n29LocationId = new bool[] {false} ;
         P00GO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GO2_n11OrganisationId = new bool[] {false} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV13ResidentLanguage = "";
         P00GO3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GO3_n29LocationId = new bool[] {false} ;
         P00GO3_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00GO3_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00GO3_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00GO3_n584ActiveAppVersionId = new bool[] {false} ;
         P00GO3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GO3_n11OrganisationId = new bool[] {false} ;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         AV14AppVersionId = Guid.Empty;
         P00GO4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GO4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GO4_n11OrganisationId = new bool[] {false} ;
         P00GO4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GO4_n29LocationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         P00GO5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GO5_A516PageId = new Guid[] {Guid.Empty} ;
         P00GO5_A517PageName = new string[] {""} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_modulepageapi__default(),
            new Object[][] {
                new Object[] {
               P00GO2_A71ResidentGUID, P00GO2_A599ResidentLanguage, P00GO2_A62ResidentId, P00GO2_A29LocationId, P00GO2_A11OrganisationId
               }
               , new Object[] {
               P00GO3_A29LocationId, P00GO3_A598PublishedActiveAppVersionId, P00GO3_n598PublishedActiveAppVersionId, P00GO3_A584ActiveAppVersionId, P00GO3_n584ActiveAppVersionId, P00GO3_A11OrganisationId
               }
               , new Object[] {
               P00GO4_A523AppVersionId, P00GO4_A11OrganisationId, P00GO4_n11OrganisationId, P00GO4_A29LocationId, P00GO4_n29LocationId
               }
               , new Object[] {
               P00GO5_A523AppVersionId, P00GO5_A516PageId, P00GO5_A517PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A599ResidentLanguage ;
      private string AV13ResidentLanguage ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private string AV9UserId ;
      private string A71ResidentGUID ;
      private string A517PageName ;
      private Guid AV10PageId ;
      private Guid AV11LocationId ;
      private Guid AV12OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid AV14AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_InfoPage AV8SDT_InfoPage ;
      private IDataStoreProvider pr_default ;
      private string[] P00GO2_A71ResidentGUID ;
      private string[] P00GO2_A599ResidentLanguage ;
      private Guid[] P00GO2_A62ResidentId ;
      private Guid[] P00GO2_A29LocationId ;
      private bool[] P00GO2_n29LocationId ;
      private Guid[] P00GO2_A11OrganisationId ;
      private bool[] P00GO2_n11OrganisationId ;
      private Guid[] P00GO3_A29LocationId ;
      private bool[] P00GO3_n29LocationId ;
      private Guid[] P00GO3_A598PublishedActiveAppVersionId ;
      private bool[] P00GO3_n598PublishedActiveAppVersionId ;
      private Guid[] P00GO3_A584ActiveAppVersionId ;
      private bool[] P00GO3_n584ActiveAppVersionId ;
      private Guid[] P00GO3_A11OrganisationId ;
      private bool[] P00GO3_n11OrganisationId ;
      private Guid[] P00GO4_A523AppVersionId ;
      private Guid[] P00GO4_A11OrganisationId ;
      private bool[] P00GO4_n11OrganisationId ;
      private Guid[] P00GO4_A29LocationId ;
      private bool[] P00GO4_n29LocationId ;
      private Guid[] P00GO5_A523AppVersionId ;
      private Guid[] P00GO5_A516PageId ;
      private string[] P00GO5_A517PageName ;
      private SdtSDT_InfoPage aP4_SDT_InfoPage ;
   }

   public class prc_modulepageapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GO2;
          prmP00GO2 = new Object[] {
          new ParDef("AV9UserId",GXType.VarChar,100,0)
          };
          Object[] prmP00GO3;
          prmP00GO3 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GO4;
          prmP00GO4 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV14AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GO5;
          prmP00GO5 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GO2", "SELECT ResidentGUID, ResidentLanguage, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV9UserId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GO3", "SELECT LocationId, PublishedActiveAppVersionId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV11LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GO4", "SELECT AppVersionId, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV11LocationId and OrganisationId = :AV12OrganisationId) AND (AppVersionId = :AV14AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GO5", "SELECT AppVersionId, PageId, PageName FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV10PageId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
