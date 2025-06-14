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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_savepagethumbnail : GXProcedure
   {
      public prc_savepagethumbnail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_savepagethumbnail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           string aP1_PageThumbnailData ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV9PageId = aP0_PageId;
         this.AV10PageThumbnailData = aP1_PageThumbnailData;
         this.AV11SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Error=this.AV11SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_PageId ,
                                      string aP1_PageThumbnailData )
      {
         execute(aP0_PageId, aP1_PageThumbnailData, out aP2_SDT_Error);
         return AV11SDT_Error ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 string aP1_PageThumbnailData ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV9PageId = aP0_PageId;
         this.AV10PageThumbnailData = aP1_PageThumbnailData;
         this.AV11SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Error=this.AV11SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV11SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV11SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         new prc_logtoserver(context ).execute(  context.GetMessage( "Thumbnail: ", "")+AV10PageThumbnailData) ;
         new prc_logtoserver(context ).execute(  context.GetMessage( "PageId: ", "")+AV9PageId.ToString()) ;
         /* Using cursor P00F12 */
         pr_default.execute(0, new Object[] {AV9PageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTF12 = 0;
            A516PageId = P00F12_A516PageId[0];
            A40000PageThumbnail_GXI = P00F12_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = P00F12_n40000PageThumbnail_GXI[0];
            A523AppVersionId = P00F12_A523AppVersionId[0];
            A600PageThumbnail = P00F12_A600PageThumbnail[0];
            n600PageThumbnail = P00F12_n600PageThumbnail[0];
            O600PageThumbnail = A600PageThumbnail;
            n600PageThumbnail = false;
            O600PageThumbnail = A600PageThumbnail;
            n600PageThumbnail = false;
            AV15GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
            AV14baseUrl = AV15GAMApplication.gxTpr_Environment.gxTpr_Url;
            AV13MediaName = A516PageId.ToString() + context.GetMessage( ".png", "");
            AV16MediaUrl = AV14baseUrl + context.GetMessage( "media/", "") + AV13MediaName;
            AV12Path = context.GetMessage( "media/", "");
            if ( StringUtil.StartsWith( AV18HttpRequest.BaseURL, context.GetMessage( "http://localhost", "")) )
            {
               AV12Path = context.GetMessage( "C:\\KBs\\Comforta_version20\\NETPostgreSQL1039\\Web\\media\\", "");
            }
            new SdtEO_Base64Image(context).saveimage(AV10PageThumbnailData, AV12Path+AV13MediaName) ;
            AV19PageThumbnail = AV16MediaUrl;
            AV23Pagethumbnail_GXI = GXDbFile.PathToUrl( AV16MediaUrl, context);
            if ( ! ( ( StringUtil.StrCmp(O600PageThumbnail, AV19PageThumbnail) == 0 ) ) )
            {
               new prc_logtoserver(context ).execute(  context.GetMessage( "MediaURL: ", "")+AV16MediaUrl) ;
               A600PageThumbnail = AV19PageThumbnail;
               n600PageThumbnail = false;
               A40000PageThumbnail_GXI = AV23Pagethumbnail_GXI;
               n40000PageThumbnail_GXI = false;
               GXTF12 = 1;
            }
            /* Using cursor P00F13 */
            pr_default.execute(1, new Object[] {n600PageThumbnail, A600PageThumbnail, n40000PageThumbnail_GXI, A40000PageThumbnail_GXI, A523AppVersionId, A516PageId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
            if ( GXTF12 == 1 )
            {
               context.CommitDataStores("prc_savepagethumbnail",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepagethumbnail",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11SDT_Error = new SdtSDT_Error(context);
         P00F12_A516PageId = new Guid[] {Guid.Empty} ;
         P00F12_A40000PageThumbnail_GXI = new string[] {""} ;
         P00F12_n40000PageThumbnail_GXI = new bool[] {false} ;
         P00F12_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00F12_A600PageThumbnail = new string[] {""} ;
         P00F12_n600PageThumbnail = new bool[] {false} ;
         A516PageId = Guid.Empty;
         A40000PageThumbnail_GXI = "";
         A523AppVersionId = Guid.Empty;
         A600PageThumbnail = "";
         O600PageThumbnail = "";
         AV15GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV14baseUrl = "";
         AV13MediaName = "";
         AV16MediaUrl = "";
         AV12Path = "";
         AV18HttpRequest = new GxHttpRequest( context);
         AV19PageThumbnail = "";
         AV23Pagethumbnail_GXI = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagethumbnail__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagethumbnail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagethumbnail__default(),
            new Object[][] {
                new Object[] {
               P00F12_A516PageId, P00F12_A40000PageThumbnail_GXI, P00F12_n40000PageThumbnail_GXI, P00F12_A523AppVersionId, P00F12_A600PageThumbnail, P00F12_n600PageThumbnail
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTF12 ;
      private bool n40000PageThumbnail_GXI ;
      private bool n600PageThumbnail ;
      private string AV10PageThumbnailData ;
      private string A40000PageThumbnail_GXI ;
      private string AV14baseUrl ;
      private string AV13MediaName ;
      private string AV16MediaUrl ;
      private string AV12Path ;
      private string AV23Pagethumbnail_GXI ;
      private string A600PageThumbnail ;
      private string O600PageThumbnail ;
      private string AV19PageThumbnail ;
      private Guid AV9PageId ;
      private Guid A516PageId ;
      private Guid A523AppVersionId ;
      private GxHttpRequest AV18HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV11SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00F12_A516PageId ;
      private string[] P00F12_A40000PageThumbnail_GXI ;
      private bool[] P00F12_n40000PageThumbnail_GXI ;
      private Guid[] P00F12_A523AppVersionId ;
      private string[] P00F12_A600PageThumbnail ;
      private bool[] P00F12_n600PageThumbnail ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV15GAMApplication ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_savepagethumbnail__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_savepagethumbnail__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_savepagethumbnail__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00F12;
       prmP00F12 = new Object[] {
       new ParDef("AV9PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00F13;
       prmP00F13 = new Object[] {
       new ParDef("PageThumbnail",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("PageThumbnail_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_AppVersionPage", Fld="PageThumbnail"} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00F12", "SELECT PageId, PageThumbnail_GXI, AppVersionId, PageThumbnail FROM Trn_AppVersionPage WHERE PageId = :AV9PageId ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00F13", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageThumbnail=:PageThumbnail, PageThumbnail_GXI=:PageThumbnail_GXI  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00F13)
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
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             return;
    }
 }

}

}
