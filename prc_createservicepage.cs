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
   public class prc_createservicepage : GXProcedure
   {
      public prc_createservicepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createservicepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_ProductServiceId ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV18ProductServiceId = aP1_ProductServiceId;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_ProductServiceId ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_ProductServiceId, out aP2_PageItem, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_ProductServiceId ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV18ProductServiceId = aP1_ProductServiceId;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = "Error";
            AV8SDT_Error.gxTpr_Message = "Not Authenticated";
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV15LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV15LocationId = GXt_guid1;
         GXt_guid1 = AV17OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV17OrganisationId = GXt_guid1;
         AV12BC_Trn_ProductService.Load(AV18ProductServiceId, AV15LocationId, AV17OrganisationId);
         AV11BC_Trn_AppVersion.Load(AV9AppVersionId);
         /* Using cursor P00BH2 */
         pr_default.execute(0, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00BH2_A523AppVersionId[0];
            AV22GXLvl18 = 0;
            /* Using cursor P00BH3 */
            pr_default.execute(1, new Object[] {A523AppVersionId, AV18ProductServiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A516PageId = P00BH3_A516PageId[0];
               A518PageStructure = P00BH3_A518PageStructure[0];
               AV22GXLvl18 = 1;
               AV10BC_Page.gxTpr_Pageid = AV18ProductServiceId;
               AV10BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
               AV10BC_Page.gxTpr_Pagetype = "Content";
               AV10BC_Page.gxTpr_Pagestructure = A518PageStructure;
               AV19SDT_ContentPage.FromJSonString(A518PageStructure, null);
               AV20PageItem.FromJSonString(AV10BC_Page.ToJSonString(true, true), null);
               AV20PageItem.gxTpr_Pagecontentstructure = AV19SDT_ContentPage;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV22GXLvl18 == 0 )
            {
               /* Execute user subroutine: 'CREATENEWSERVICEPAGE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWSERVICEPAGE' Routine */
         returnInSub = false;
         AV10BC_Page.gxTpr_Pageid = AV12BC_Trn_ProductService.gxTpr_Productserviceid;
         AV10BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
         AV10BC_Page.gxTpr_Pagetype = "Content";
         AV19SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV13ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV13ContentItem.gxTpr_Contenttype = "Image";
         AV13ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productserviceimage_gxi;
         AV19SDT_ContentPage.gxTpr_Content.Add(AV13ContentItem, 0);
         AV13ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV13ContentItem.gxTpr_Contenttype = "Description";
         AV13ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productservicedescription;
         AV19SDT_ContentPage.gxTpr_Content.Add(AV13ContentItem, 0);
         AV10BC_Page.gxTpr_Pagestructure = AV19SDT_ContentPage.ToJSonString(false, true);
         AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV10BC_Page, 0);
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createservicepage",pr_default);
            AV20PageItem.FromJSonString(AV10BC_Page.ToJSonString(true, true), null);
            AV20PageItem.gxTpr_Pagecontentstructure = AV19SDT_ContentPage;
         }
         else
         {
            AV24GXV2 = 1;
            AV23GXV1 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV24GXV2 <= AV23GXV1.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV23GXV1.Item(AV24GXV2));
               AV8SDT_Error.gxTpr_Message = AV16Message.gxTpr_Description;
               AV24GXV2 = (int)(AV24GXV2+1);
            }
         }
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
         AV20PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV15LocationId = Guid.Empty;
         AV17OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00BH2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00BH3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BH3_A516PageId = new Guid[] {Guid.Empty} ;
         P00BH3_A518PageStructure = new string[] {""} ;
         A516PageId = Guid.Empty;
         A518PageStructure = "";
         AV10BC_Page = new SdtTrn_AppVersion_Page(context);
         AV19SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV13ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV23GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__default(),
            new Object[][] {
                new Object[] {
               P00BH2_A523AppVersionId
               }
               , new Object[] {
               P00BH3_A523AppVersionId, P00BH3_A516PageId, P00BH3_A518PageStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22GXLvl18 ;
      private int AV24GXV2 ;
      private bool returnInSub ;
      private string A518PageStructure ;
      private Guid AV9AppVersionId ;
      private Guid AV18ProductServiceId ;
      private Guid AV15LocationId ;
      private Guid AV17OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV20PageItem ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BH2_A523AppVersionId ;
      private Guid[] P00BH3_A523AppVersionId ;
      private Guid[] P00BH3_A516PageId ;
      private string[] P00BH3_A518PageStructure ;
      private SdtTrn_AppVersion_Page AV10BC_Page ;
      private SdtSDT_ContentPage AV19SDT_ContentPage ;
      private SdtSDT_ContentPage_ContentItem AV13ContentItem ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createservicepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_createservicepage__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_createservicepage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00BH2;
       prmP00BH2 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BH3;
       prmP00BH3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV18ProductServiceId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BH2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BH3", "SELECT AppVersionId, PageId, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV18ProductServiceId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH3,1, GxCacheFrequency.OFF ,false,true )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
    }
 }

}

}
