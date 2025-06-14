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
   public class prc_createlinkpage : GXProcedure
   {
      public prc_createlinkpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createlinkpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           string aP2_Url ,
                           short aP3_WWPFormId ,
                           out SdtSDT_AppVersion_PagesItem aP4_PageItem ,
                           out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV21Url = aP2_Url;
         this.AV18WWPFormId = aP3_WWPFormId;
         this.AV11PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_PageItem=this.AV11PageItem;
         aP5_SDT_Error=this.AV10SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      string aP2_Url ,
                                      short aP3_WWPFormId ,
                                      out SdtSDT_AppVersion_PagesItem aP4_PageItem )
      {
         execute(aP0_AppVersionId, aP1_PageName, aP2_Url, aP3_WWPFormId, out aP4_PageItem, out aP5_SDT_Error);
         return AV10SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 string aP2_Url ,
                                 short aP3_WWPFormId ,
                                 out SdtSDT_AppVersion_PagesItem aP4_PageItem ,
                                 out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV21Url = aP2_Url;
         this.AV18WWPFormId = aP3_WWPFormId;
         this.AV11PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_PageItem=this.AV11PageItem;
         aP5_SDT_Error=this.AV10SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV10SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV10SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV13BC_Trn_AppVersion.Load(AV8AppVersionId);
         AV12BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV12BC_Page.gxTpr_Pagename = AV9PageName;
         AV15SDT_LinkPage = new SdtSDT_LinkPage(context);
         if ( ! ( AV18WWPFormId == 0 ) )
         {
            AV15SDT_LinkPage.gxTpr_Wwpformid = AV18WWPFormId;
            /* Using cursor P00G72 */
            pr_default.execute(0, new Object[] {AV18WWPFormId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A206WWPFormId = P00G72_A206WWPFormId[0];
               A207WWPFormVersionNumber = P00G72_A207WWPFormVersionNumber[0];
               AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
               AV20baseUrl = AV19GAMApplication.gxTpr_Environment.gxTpr_Url;
               AV15SDT_LinkPage.gxTpr_Url = AV20baseUrl+"utoolboxdynamicform.aspx?WWPFormId="+StringUtil.Trim( StringUtil.Str( (decimal)(AV18WWPFormId), 4, 0))+context.GetMessage( "&WWPDynamicFormMode=DSP&DefaultFormType=&WWPFormType=0", "");
               AV12BC_Page.gxTpr_Pagetype = "DynamicForm";
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV15SDT_LinkPage.gxTpr_Url = AV21Url;
            AV12BC_Page.gxTpr_Pagetype = "WebLink";
         }
         AV12BC_Page.gxTpr_Pagestructure = AV15SDT_LinkPage.ToJSonString(false, true);
         AV13BC_Trn_AppVersion.gxTpr_Page.Add(AV12BC_Page, 0);
         AV13BC_Trn_AppVersion.Save();
         if ( AV13BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createlinkpage",pr_default);
            AV11PageItem.FromJSonString(AV12BC_Page.ToJSonString(true, true), null);
            AV11PageItem.gxTpr_Pagelinkstructure = AV15SDT_LinkPage;
         }
         else
         {
            AV24GXV2 = 1;
            AV23GXV1 = AV13BC_Trn_AppVersion.GetMessages();
            while ( AV24GXV2 <= AV23GXV1.Count )
            {
               AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV23GXV1.Item(AV24GXV2));
               AV10SDT_Error.gxTpr_Message = AV14Message.gxTpr_Description;
               AV24GXV2 = (int)(AV24GXV2+1);
            }
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
         AV11PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV10SDT_Error = new SdtSDT_Error(context);
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV12BC_Page = new SdtTrn_AppVersion_Page(context);
         AV15SDT_LinkPage = new SdtSDT_LinkPage(context);
         P00G72_A206WWPFormId = new short[1] ;
         P00G72_A207WWPFormVersionNumber = new short[1] ;
         AV19GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV20baseUrl = "";
         AV23GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createlinkpage__default(),
            new Object[][] {
                new Object[] {
               P00G72_A206WWPFormId, P00G72_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18WWPFormId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV24GXV2 ;
      private string AV9PageName ;
      private string AV21Url ;
      private string AV20baseUrl ;
      private Guid AV8AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV11PageItem ;
      private SdtSDT_Error AV10SDT_Error ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV12BC_Page ;
      private SdtSDT_LinkPage AV15SDT_LinkPage ;
      private IDataStoreProvider pr_default ;
      private short[] P00G72_A206WWPFormId ;
      private short[] P00G72_A207WWPFormVersionNumber ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV19GAMApplication ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private SdtSDT_AppVersion_PagesItem aP4_PageItem ;
      private SdtSDT_Error aP5_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createlinkpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createlinkpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createlinkpage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00G72;
       prmP00G72 = new Object[] {
       new ParDef("AV18WWPFormId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00G72", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV18WWPFormId ORDER BY WWPFormId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G72,100, GxCacheFrequency.OFF ,false,false )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
    }
 }

}

}
