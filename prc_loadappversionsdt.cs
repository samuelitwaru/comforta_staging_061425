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
   public class prc_loadappversionsdt : GXProcedure
   {
      public prc_loadappversionsdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loadappversionsdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtTrn_AppVersion aP0_BC_Trn_AppVersion ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         this.AV8BC_Trn_AppVersion = aP0_BC_Trn_AppVersion;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV9SDT_AppVersion;
      }

      public SdtSDT_AppVersion executeUdp( SdtTrn_AppVersion aP0_BC_Trn_AppVersion )
      {
         execute(aP0_BC_Trn_AppVersion, out aP1_SDT_AppVersion);
         return AV9SDT_AppVersion ;
      }

      public void executeSubmit( SdtTrn_AppVersion aP0_BC_Trn_AppVersion ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         this.AV8BC_Trn_AppVersion = aP0_BC_Trn_AppVersion;
         this.AV9SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV9SDT_AppVersion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_AppVersion.FromJSonString(AV8BC_Trn_AppVersion.ToJSonString(true, true), null);
         AV9SDT_AppVersion.gxTpr_Themeid = AV8BC_Trn_AppVersion.gxTpr_Trn_themeid;
         AV9SDT_AppVersion.gxTpr_Pages.Clear();
         /* Using cursor P00CA2 */
         pr_default.execute(0, new Object[] {AV8BC_Trn_AppVersion.gxTpr_Appversionid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00CA2_A523AppVersionId[0];
            A620IsVersionDeleted = P00CA2_A620IsVersionDeleted[0];
            /* Using cursor P00CA3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A621IsPageDeleted = P00CA3_A621IsPageDeleted[0];
               A516PageId = P00CA3_A516PageId[0];
               A517PageName = P00CA3_A517PageName[0];
               A525PageType = P00CA3_A525PageType[0];
               A541IsPredefined = P00CA3_A541IsPredefined[0];
               A40000PageThumbnail_GXI = P00CA3_A40000PageThumbnail_GXI[0];
               n40000PageThumbnail_GXI = P00CA3_n40000PageThumbnail_GXI[0];
               A518PageStructure = P00CA3_A518PageStructure[0];
               AV10PageItem = new SdtSDT_AppVersion_PagesItem(context);
               AV10PageItem.gxTpr_Pageid = A516PageId;
               AV10PageItem.gxTpr_Pagename = A517PageName;
               AV10PageItem.gxTpr_Pagetype = A525PageType;
               AV10PageItem.gxTpr_Ispredefined = A541IsPredefined;
               AV10PageItem.gxTpr_Pagethumbnailurl = A40000PageThumbnail_GXI;
               AV11PageStructure = "";
               AV13SDT_ContentPage = new SdtSDT_ContentPage(context);
               AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
               AV16SDT_InfoContent = new SdtSDT_InfoContent(context);
               if ( StringUtil.StrCmp(AV10PageItem.gxTpr_Pagetype, "Information") == 0 )
               {
                  AV16SDT_InfoContent = new SdtSDT_InfoContent(context);
                  AV16SDT_InfoContent.FromJSonString(A518PageStructure, null);
                  AV11PageStructure = AV16SDT_InfoContent.ToJSonString(false, true);
                  GXt_SdtSDT_InfoContent1 = new SdtSDT_InfoContent();
                  new prc_validateinfostructure(context ).execute(  AV11PageStructure, out  GXt_SdtSDT_InfoContent1) ;
                  AV10PageItem.gxTpr_Pageinfostructure = GXt_SdtSDT_InfoContent1;
               }
               else if ( ( StringUtil.StrCmp(AV10PageItem.gxTpr_Pagetype, "DynamicForm") == 0 ) || ( StringUtil.StrCmp(AV10PageItem.gxTpr_Pagetype, "WebLink") == 0 ) )
               {
                  AV17SDT_LinkPage = new SdtSDT_LinkPage(context);
                  AV17SDT_LinkPage.FromJSonString(A518PageStructure, null);
                  AV10PageItem.gxTpr_Pagelinkstructure = AV17SDT_LinkPage;
               }
               else
               {
                  AV13SDT_ContentPage.FromJSonString(A518PageStructure, null);
               }
               AV10PageItem.gxTpr_Pagestructure = AV11PageStructure;
               AV9SDT_AppVersion.gxTpr_Pages.Add(AV10PageItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV9SDT_AppVersion = new SdtSDT_AppVersion(context);
         P00CA2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00CA2_A620IsVersionDeleted = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         P00CA3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00CA3_A621IsPageDeleted = new bool[] {false} ;
         P00CA3_A516PageId = new Guid[] {Guid.Empty} ;
         P00CA3_A517PageName = new string[] {""} ;
         P00CA3_A525PageType = new string[] {""} ;
         P00CA3_A541IsPredefined = new bool[] {false} ;
         P00CA3_A40000PageThumbnail_GXI = new string[] {""} ;
         P00CA3_n40000PageThumbnail_GXI = new bool[] {false} ;
         P00CA3_A518PageStructure = new string[] {""} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         A525PageType = "";
         A40000PageThumbnail_GXI = "";
         A518PageStructure = "";
         AV10PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV11PageStructure = "";
         AV13SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV16SDT_InfoContent = new SdtSDT_InfoContent(context);
         GXt_SdtSDT_InfoContent1 = new SdtSDT_InfoContent(context);
         AV17SDT_LinkPage = new SdtSDT_LinkPage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_loadappversionsdt__default(),
            new Object[][] {
                new Object[] {
               P00CA2_A523AppVersionId, P00CA2_A620IsVersionDeleted
               }
               , new Object[] {
               P00CA3_A523AppVersionId, P00CA3_A621IsPageDeleted, P00CA3_A516PageId, P00CA3_A517PageName, P00CA3_A525PageType, P00CA3_A541IsPredefined, P00CA3_A40000PageThumbnail_GXI, P00CA3_n40000PageThumbnail_GXI, P00CA3_A518PageStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A620IsVersionDeleted ;
      private bool A621IsPageDeleted ;
      private bool A541IsPredefined ;
      private bool n40000PageThumbnail_GXI ;
      private string A518PageStructure ;
      private string AV11PageStructure ;
      private string A517PageName ;
      private string A525PageType ;
      private string A40000PageThumbnail_GXI ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion AV8BC_Trn_AppVersion ;
      private SdtSDT_AppVersion AV9SDT_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CA2_A523AppVersionId ;
      private bool[] P00CA2_A620IsVersionDeleted ;
      private Guid[] P00CA3_A523AppVersionId ;
      private bool[] P00CA3_A621IsPageDeleted ;
      private Guid[] P00CA3_A516PageId ;
      private string[] P00CA3_A517PageName ;
      private string[] P00CA3_A525PageType ;
      private bool[] P00CA3_A541IsPredefined ;
      private string[] P00CA3_A40000PageThumbnail_GXI ;
      private bool[] P00CA3_n40000PageThumbnail_GXI ;
      private string[] P00CA3_A518PageStructure ;
      private SdtSDT_AppVersion_PagesItem AV10PageItem ;
      private SdtSDT_ContentPage AV13SDT_ContentPage ;
      private SdtSDT_MenuPage AV14SDT_MenuPage ;
      private SdtSDT_InfoContent AV16SDT_InfoContent ;
      private SdtSDT_InfoContent GXt_SdtSDT_InfoContent1 ;
      private SdtSDT_LinkPage AV17SDT_LinkPage ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
   }

   public class prc_loadappversionsdt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CA2;
          prmP00CA2 = new Object[] {
          new ParDef("AV8BC_Tr_1Appversionid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00CA3;
          prmP00CA3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CA2", "SELECT AppVersionId, IsVersionDeleted FROM Trn_AppVersion WHERE (AppVersionId = :AV8BC_Tr_1Appversionid) AND (IsVersionDeleted = FALSE) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CA3", "SELECT AppVersionId, IsPageDeleted, PageId, PageName, PageType, IsPredefined, PageThumbnail_GXI, PageStructure FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (IsPageDeleted = FALSE) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
                return;
       }
    }

 }

}
