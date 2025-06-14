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
   public class prc_createinfopage : GXProcedure
   {
      public prc_createinfopage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createinfopage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV11PageName = aP1_PageName;
         this.AV17PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV17PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_PageName, out aP2_PageItem, out aP3_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV11PageName = aP1_PageName;
         this.AV17PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV17PageItem;
         aP3_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV15BC_Trn_AppVersion.Load(AV10AppVersionId);
         AV9BC_Page.gxTpr_Pageid = Guid.NewGuid( );
         AV9BC_Page.gxTpr_Pagename = AV11PageName;
         AV9BC_Page.gxTpr_Pagetype = "Information";
         AV19SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV9BC_Page.gxTpr_Pagestructure = AV19SDT_InfoContent.ToJSonString(false, true);
         AV15BC_Trn_AppVersion.gxTpr_Page.Add(AV9BC_Page, 0);
         AV15BC_Trn_AppVersion.Save();
         if ( AV15BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createinfopage",pr_default);
            AV17PageItem.FromJSonString(AV9BC_Page.ToJSonString(true, true), null);
            AV17PageItem.gxTpr_Pageinfostructure = AV19SDT_InfoContent;
         }
         else
         {
            AV21GXV2 = 1;
            AV20GXV1 = AV15BC_Trn_AppVersion.GetMessages();
            while ( AV21GXV2 <= AV20GXV1.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV20GXV1.Item(AV21GXV2));
               AV8SDT_Error.gxTpr_Message = AV16Message.gxTpr_Description;
               AV21GXV2 = (int)(AV21GXV2+1);
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
         AV17PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV8SDT_Error = new SdtSDT_Error(context);
         AV15BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV9BC_Page = new SdtTrn_AppVersion_Page(context);
         AV19SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV20GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createinfopage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createinfopage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createinfopage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV2 ;
      private string AV11PageName ;
      private Guid AV10AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV17PageItem ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_AppVersion AV15BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV9BC_Page ;
      private SdtSDT_InfoContent AV19SDT_InfoContent ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createinfopage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createinfopage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createinfopage__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
