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
   public class aprc_uploadcroppedmedia : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_uploadcroppedmedia().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_uploadcroppedmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_uploadcroppedmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MediaName ,
                           string aP1_MediaImageData ,
                           int aP2_MediaSize ,
                           string aP3_MediaType ,
                           out SdtTrn_Media aP4_BC_Trn_Media ,
                           out SdtSDT_Error aP5_Error )
      {
         this.AV11MediaName = aP0_MediaName;
         this.AV15MediaImageData = aP1_MediaImageData;
         this.AV17MediaSize = aP2_MediaSize;
         this.AV18MediaType = aP3_MediaType;
         this.AV13BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV25Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_BC_Trn_Media=this.AV13BC_Trn_Media;
         aP5_Error=this.AV25Error;
      }

      public SdtSDT_Error executeUdp( string aP0_MediaName ,
                                      string aP1_MediaImageData ,
                                      int aP2_MediaSize ,
                                      string aP3_MediaType ,
                                      out SdtTrn_Media aP4_BC_Trn_Media )
      {
         execute(aP0_MediaName, aP1_MediaImageData, aP2_MediaSize, aP3_MediaType, out aP4_BC_Trn_Media, out aP5_Error);
         return AV25Error ;
      }

      public void executeSubmit( string aP0_MediaName ,
                                 string aP1_MediaImageData ,
                                 int aP2_MediaSize ,
                                 string aP3_MediaType ,
                                 out SdtTrn_Media aP4_BC_Trn_Media ,
                                 out SdtSDT_Error aP5_Error )
      {
         this.AV11MediaName = aP0_MediaName;
         this.AV15MediaImageData = aP1_MediaImageData;
         this.AV17MediaSize = aP2_MediaSize;
         this.AV18MediaType = aP3_MediaType;
         this.AV13BC_Trn_Media = new SdtTrn_Media(context) ;
         this.AV25Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_BC_Trn_Media=this.AV13BC_Trn_Media;
         aP5_Error=this.AV25Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV25Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV25Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV26GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
            AV27baseUrl = AV26GAMApplication.gxTpr_Environment.gxTpr_Url;
            AV13BC_Trn_Media = new SdtTrn_Media(context);
            AV13BC_Trn_Media.gxTpr_Medianame = AV11MediaName;
            AV13BC_Trn_Media.gxTpr_Mediasize = AV17MediaSize;
            AV13BC_Trn_Media.gxTpr_Mediatype = AV18MediaType;
            AV13BC_Trn_Media.gxTpr_Iscropped = true;
            GXt_guid1 = Guid.Empty;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV13BC_Trn_Media.gxTpr_Locationid = GXt_guid1;
            AV20MediaUrl = AV27baseUrl + context.GetMessage( "media/cropped/", "") + AV11MediaName;
            AV13BC_Trn_Media.gxTpr_Mediaurl = AV20MediaUrl;
            AV13BC_Trn_Media.Save();
            new prc_logtofile(context ).execute(  AV13BC_Trn_Media.ToJSonString(true, true)) ;
            new prc_logtofile(context ).execute(  StringUtil.BoolToStr( AV13BC_Trn_Media.Success())) ;
            if ( AV13BC_Trn_Media.Success() )
            {
               AV19Path = context.GetMessage( "media/", "");
               if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, context.GetMessage( "http://localhost", "")) )
               {
                  AV19Path = context.GetMessage( "D:\\KBs\\ComfortaKB\\NETSQLServer043\\Web\\media\\cropped\\", "");
               }
               new SdtEO_Base64Image(context).saveimage(AV15MediaImageData, AV19Path+AV11MediaName) ;
               new prc_logtofile(context ).execute(  AV19Path+AV11MediaName) ;
               AV9response = AV13BC_Trn_Media.ToJSonString(true, true);
               context.CommitDataStores("prc_uploadcroppedmedia",pr_default);
            }
            else
            {
               AV29GXV2 = 1;
               AV28GXV1 = AV13BC_Trn_Media.GetMessages();
               while ( AV29GXV2 <= AV28GXV1.Count )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV28GXV1.Item(AV29GXV2));
                  new prc_logtofile(context ).execute(  AV14Message.gxTpr_Description) ;
                  AV29GXV2 = (int)(AV29GXV2+1);
               }
               AV9response = context.GetMessage( "Insert ERROR", "");
               context.RollbackDataStores("prc_uploadcroppedmedia",pr_default);
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
         AV13BC_Trn_Media = new SdtTrn_Media(context);
         AV25Error = new SdtSDT_Error(context);
         AV26GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV27baseUrl = "";
         GXt_guid1 = Guid.Empty;
         AV20MediaUrl = "";
         AV19Path = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV9response = "";
         AV28GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadcroppedmedia__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadcroppedmedia__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadcroppedmedia__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17MediaSize ;
      private int AV29GXV2 ;
      private string AV18MediaType ;
      private string AV15MediaImageData ;
      private string AV9response ;
      private string AV11MediaName ;
      private string AV27baseUrl ;
      private string AV20MediaUrl ;
      private string AV19Path ;
      private Guid GXt_guid1 ;
      private GxHttpRequest AV8HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Media AV13BC_Trn_Media ;
      private SdtSDT_Error AV25Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV26GAMApplication ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private SdtTrn_Media aP4_BC_Trn_Media ;
      private SdtSDT_Error aP5_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_uploadcroppedmedia__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_uploadcroppedmedia__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_uploadcroppedmedia__default : DataStoreHelperBase, IDataStoreHelper
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
