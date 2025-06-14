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
   public class prc_initmodulepages : GXProcedure
   {
      public prc_initmodulepages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initmodulepages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtTrn_AppVersion_Page aP1_BC_MyActivityPage ,
                           out SdtTrn_AppVersion_Page aP2_BC_CalendarPage ,
                           out SdtTrn_AppVersion_Page aP3_BC_MapsPage )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV11BC_MyActivityPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV10BC_CalendarPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV9BC_MapsPage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP1_BC_MyActivityPage=this.AV11BC_MyActivityPage;
         aP2_BC_CalendarPage=this.AV10BC_CalendarPage;
         aP3_BC_MapsPage=this.AV9BC_MapsPage;
      }

      public SdtTrn_AppVersion_Page executeUdp( Guid aP0_AppVersionId ,
                                                out SdtTrn_AppVersion_Page aP1_BC_MyActivityPage ,
                                                out SdtTrn_AppVersion_Page aP2_BC_CalendarPage )
      {
         execute(aP0_AppVersionId, out aP1_BC_MyActivityPage, out aP2_BC_CalendarPage, out aP3_BC_MapsPage);
         return AV9BC_MapsPage ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtTrn_AppVersion_Page aP1_BC_MyActivityPage ,
                                 out SdtTrn_AppVersion_Page aP2_BC_CalendarPage ,
                                 out SdtTrn_AppVersion_Page aP3_BC_MapsPage )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV11BC_MyActivityPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV10BC_CalendarPage = new SdtTrn_AppVersion_Page(context) ;
         this.AV9BC_MapsPage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP1_BC_MyActivityPage=this.AV11BC_MyActivityPage;
         aP2_BC_CalendarPage=this.AV10BC_CalendarPage;
         aP3_BC_MapsPage=this.AV9BC_MapsPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00EF2 */
         pr_default.execute(0, new Object[] {AV8AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00EF2_A523AppVersionId[0];
            /* Using cursor P00EF3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A525PageType = P00EF3_A525PageType[0];
               A516PageId = P00EF3_A516PageId[0];
               if ( StringUtil.StrCmp(A525PageType, "MyActivity") == 0 )
               {
                  AV11BC_MyActivityPage.gxTpr_Pageid = A516PageId;
               }
               else if ( StringUtil.StrCmp(A525PageType, "Calendar") == 0 )
               {
                  AV10BC_CalendarPage.gxTpr_Pageid = A516PageId;
               }
               else if ( StringUtil.StrCmp(A525PageType, "Map") == 0 )
               {
                  AV9BC_MapsPage.gxTpr_Pageid = A516PageId;
               }
               else
               {
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV11BC_MyActivityPage.gxTpr_Pagename = "My Activity";
         AV11BC_MyActivityPage.gxTpr_Ispredefined = true;
         AV11BC_MyActivityPage.gxTpr_Pagetype = "MyActivity";
         AV10BC_CalendarPage.gxTpr_Pagename = "Calendar";
         AV10BC_CalendarPage.gxTpr_Ispredefined = true;
         AV10BC_CalendarPage.gxTpr_Pagetype = "Calendar";
         AV9BC_MapsPage.gxTpr_Pagename = "Maps";
         AV9BC_MapsPage.gxTpr_Ispredefined = true;
         AV9BC_MapsPage.gxTpr_Pagetype = "Map";
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
         AV11BC_MyActivityPage = new SdtTrn_AppVersion_Page(context);
         AV10BC_CalendarPage = new SdtTrn_AppVersion_Page(context);
         AV9BC_MapsPage = new SdtTrn_AppVersion_Page(context);
         P00EF2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00EF3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00EF3_A525PageType = new string[] {""} ;
         P00EF3_A516PageId = new Guid[] {Guid.Empty} ;
         A525PageType = "";
         A516PageId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initmodulepages__default(),
            new Object[][] {
                new Object[] {
               P00EF2_A523AppVersionId
               }
               , new Object[] {
               P00EF3_A523AppVersionId, P00EF3_A525PageType, P00EF3_A516PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A525PageType ;
      private Guid AV8AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion_Page AV11BC_MyActivityPage ;
      private SdtTrn_AppVersion_Page AV10BC_CalendarPage ;
      private SdtTrn_AppVersion_Page AV9BC_MapsPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EF2_A523AppVersionId ;
      private Guid[] P00EF3_A523AppVersionId ;
      private string[] P00EF3_A525PageType ;
      private Guid[] P00EF3_A516PageId ;
      private SdtTrn_AppVersion_Page aP1_BC_MyActivityPage ;
      private SdtTrn_AppVersion_Page aP2_BC_CalendarPage ;
      private SdtTrn_AppVersion_Page aP3_BC_MapsPage ;
   }

   public class prc_initmodulepages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EF2;
          prmP00EF2 = new Object[] {
          new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EF3;
          prmP00EF3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EF2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV8AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EF2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00EF3", "SELECT AppVersionId, PageType, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EF3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
