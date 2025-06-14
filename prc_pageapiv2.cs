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
   public class prc_pageapiv2 : GXProcedure
   {
      public prc_pageapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pageapiv2( IGxContext context )
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
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV9LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV12UserId = aP3_UserId;
         this.AV13SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV13SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( Guid aP0_PageId ,
                                           Guid aP1_LocationId ,
                                           Guid aP2_OrganisationId ,
                                           string aP3_UserId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_UserId, out aP4_SDT_MobilePage);
         return AV13SDT_MobilePage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_UserId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV9LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV12UserId = aP3_UserId;
         this.AV13SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV13SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DT2 */
         pr_default.execute(0, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00DT2_A29LocationId[0];
            n29LocationId = P00DT2_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00DT2_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00DT2_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00DT2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00DT2_n584ActiveAppVersionId[0];
            A11OrganisationId = P00DT2_A11OrganisationId[0];
            n11OrganisationId = P00DT2_n11OrganisationId[0];
            AV14AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV14AppVersionId) )
            {
               AV14AppVersionId = A584ActiveAppVersionId;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00DT3 */
         pr_default.execute(1, new Object[] {AV9LocationId, AV8OrganisationId, AV14AppVersionId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A523AppVersionId = P00DT3_A523AppVersionId[0];
            A11OrganisationId = P00DT3_A11OrganisationId[0];
            n11OrganisationId = P00DT3_n11OrganisationId[0];
            A29LocationId = P00DT3_A29LocationId[0];
            n29LocationId = P00DT3_n29LocationId[0];
            /* Using cursor P00DT4 */
            pr_default.execute(2, new Object[] {A523AppVersionId, AV11PageId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A516PageId = P00DT4_A516PageId[0];
               A536PagePublishedStructure = P00DT4_A536PagePublishedStructure[0];
               A517PageName = P00DT4_A517PageName[0];
               AV10SDT_MenuPage = new SdtSDT_MenuPage(context);
               AV10SDT_MenuPage.FromJSonString(A536PagePublishedStructure, null);
               GXt_SdtSDT_MobilePage1 = AV13SDT_MobilePage;
               new prc_convertnewtooldmenustructure(context ).execute(  AV10SDT_MenuPage,  A516PageId,  A517PageName,  AV9LocationId, out  GXt_SdtSDT_MobilePage1) ;
               AV13SDT_MobilePage = GXt_SdtSDT_MobilePage1;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV13SDT_MobilePage = new SdtSDT_MobilePage(context);
         P00DT2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DT2_n29LocationId = new bool[] {false} ;
         P00DT2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DT2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00DT2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00DT2_n584ActiveAppVersionId = new bool[] {false} ;
         P00DT2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DT2_n11OrganisationId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV14AppVersionId = Guid.Empty;
         P00DT3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DT3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DT3_n11OrganisationId = new bool[] {false} ;
         P00DT3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DT3_n29LocationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         P00DT4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DT4_A516PageId = new Guid[] {Guid.Empty} ;
         P00DT4_A536PagePublishedStructure = new string[] {""} ;
         P00DT4_A517PageName = new string[] {""} ;
         A516PageId = Guid.Empty;
         A536PagePublishedStructure = "";
         A517PageName = "";
         AV10SDT_MenuPage = new SdtSDT_MenuPage(context);
         GXt_SdtSDT_MobilePage1 = new SdtSDT_MobilePage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pageapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DT2_A29LocationId, P00DT2_A598PublishedActiveAppVersionId, P00DT2_n598PublishedActiveAppVersionId, P00DT2_A584ActiveAppVersionId, P00DT2_n584ActiveAppVersionId, P00DT2_A11OrganisationId
               }
               , new Object[] {
               P00DT3_A523AppVersionId, P00DT3_A11OrganisationId, P00DT3_n11OrganisationId, P00DT3_A29LocationId, P00DT3_n29LocationId
               }
               , new Object[] {
               P00DT4_A523AppVersionId, P00DT4_A516PageId, P00DT4_A536PagePublishedStructure, P00DT4_A517PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private bool n11OrganisationId ;
      private string A536PagePublishedStructure ;
      private string AV12UserId ;
      private string A517PageName ;
      private Guid AV11PageId ;
      private Guid AV9LocationId ;
      private Guid AV8OrganisationId ;
      private Guid A29LocationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A11OrganisationId ;
      private Guid AV14AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV13SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DT2_A29LocationId ;
      private bool[] P00DT2_n29LocationId ;
      private Guid[] P00DT2_A598PublishedActiveAppVersionId ;
      private bool[] P00DT2_n598PublishedActiveAppVersionId ;
      private Guid[] P00DT2_A584ActiveAppVersionId ;
      private bool[] P00DT2_n584ActiveAppVersionId ;
      private Guid[] P00DT2_A11OrganisationId ;
      private bool[] P00DT2_n11OrganisationId ;
      private Guid[] P00DT3_A523AppVersionId ;
      private Guid[] P00DT3_A11OrganisationId ;
      private bool[] P00DT3_n11OrganisationId ;
      private Guid[] P00DT3_A29LocationId ;
      private bool[] P00DT3_n29LocationId ;
      private Guid[] P00DT4_A523AppVersionId ;
      private Guid[] P00DT4_A516PageId ;
      private string[] P00DT4_A536PagePublishedStructure ;
      private string[] P00DT4_A517PageName ;
      private SdtSDT_MenuPage AV10SDT_MenuPage ;
      private SdtSDT_MobilePage GXt_SdtSDT_MobilePage1 ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_pageapiv2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DT2;
          prmP00DT2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DT3;
          prmP00DT3 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV14AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DT4;
          prmP00DT4 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DT2", "SELECT LocationId, PublishedActiveAppVersionId, ActiveAppVersionId, OrganisationId FROM Trn_Location WHERE LocationId = :AV9LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DT2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DT3", "SELECT AppVersionId, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV9LocationId and OrganisationId = :AV8OrganisationId) AND (AppVersionId = :AV14AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DT4", "SELECT AppVersionId, PageId, PagePublishedStructure, PageName FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV11PageId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DT4,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
