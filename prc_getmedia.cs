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
   public class prc_getmedia : GXProcedure
   {
      public prc_getmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection )
      {
         this.AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_SDT_MediaCollection=this.AV9SDT_MediaCollection;
      }

      public GXBaseCollection<SdtSDT_Media> executeUdp( )
      {
         execute(out aP0_SDT_MediaCollection);
         return AV9SDT_MediaCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection )
      {
         this.AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2") ;
         SubmitImpl();
         aP0_SDT_MediaCollection=this.AV9SDT_MediaCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV13Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV13Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV17Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            /* Using cursor P009M2 */
            pr_default.execute(0, new Object[] {AV17Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A29LocationId = P009M2_A29LocationId[0];
               A636IsCropped = P009M2_A636IsCropped[0];
               A40000MediaImage_GXI = P009M2_A40000MediaImage_GXI[0];
               n40000MediaImage_GXI = P009M2_n40000MediaImage_GXI[0];
               A413MediaId = P009M2_A413MediaId[0];
               A414MediaName = P009M2_A414MediaName[0];
               A417MediaSize = P009M2_A417MediaSize[0];
               A418MediaType = P009M2_A418MediaType[0];
               A416MediaUrl = P009M2_A416MediaUrl[0];
               A618MediaDateTime = P009M2_A618MediaDateTime[0];
               n618MediaDateTime = P009M2_n618MediaDateTime[0];
               A415MediaImage = P009M2_A415MediaImage[0];
               n415MediaImage = P009M2_n415MediaImage[0];
               AV8SDT_Media = new SdtSDT_Media(context);
               AV8SDT_Media.gxTpr_Mediaid = A413MediaId;
               AV8SDT_Media.gxTpr_Medianame = A414MediaName;
               AV8SDT_Media.gxTpr_Mediaimage = A415MediaImage;
               AV8SDT_Media.gxTpr_Mediaimage_gxi = A40000MediaImage_GXI;
               AV8SDT_Media.gxTpr_Mediasize = A417MediaSize;
               AV8SDT_Media.gxTpr_Mediatype = A418MediaType;
               AV8SDT_Media.gxTpr_Mediaurl = A416MediaUrl;
               AV15MediaPath = context.GetMessage( "media/", "") + A414MediaName;
               AV14File = new GxFile(context.GetPhysicalPath());
               AV14File.Source = context.GetMessage( "media/", "")+A414MediaName;
               if ( AV14File.Exists() )
               {
                  AV9SDT_MediaCollection.Add(AV8SDT_Media, 0);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2");
         AV13Error = new SdtSDT_Error(context);
         AV17Udparg1 = Guid.Empty;
         P009M2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009M2_A636IsCropped = new bool[] {false} ;
         P009M2_A40000MediaImage_GXI = new string[] {""} ;
         P009M2_n40000MediaImage_GXI = new bool[] {false} ;
         P009M2_A413MediaId = new Guid[] {Guid.Empty} ;
         P009M2_A414MediaName = new string[] {""} ;
         P009M2_A417MediaSize = new int[1] ;
         P009M2_A418MediaType = new string[] {""} ;
         P009M2_A416MediaUrl = new string[] {""} ;
         P009M2_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         P009M2_n618MediaDateTime = new bool[] {false} ;
         P009M2_A415MediaImage = new string[] {""} ;
         P009M2_n415MediaImage = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A40000MediaImage_GXI = "";
         A413MediaId = Guid.Empty;
         A414MediaName = "";
         A418MediaType = "";
         A416MediaUrl = "";
         A618MediaDateTime = (DateTime)(DateTime.MinValue);
         A415MediaImage = "";
         AV8SDT_Media = new SdtSDT_Media(context);
         AV15MediaPath = "";
         AV14File = new GxFile(context.GetPhysicalPath());
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmedia__default(),
            new Object[][] {
                new Object[] {
               P009M2_A29LocationId, P009M2_A636IsCropped, P009M2_A40000MediaImage_GXI, P009M2_n40000MediaImage_GXI, P009M2_A413MediaId, P009M2_A414MediaName, P009M2_A417MediaSize, P009M2_A418MediaType, P009M2_A416MediaUrl, P009M2_A618MediaDateTime,
               P009M2_n618MediaDateTime, P009M2_A415MediaImage, P009M2_n415MediaImage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A417MediaSize ;
      private string A418MediaType ;
      private DateTime A618MediaDateTime ;
      private bool A636IsCropped ;
      private bool n40000MediaImage_GXI ;
      private bool n618MediaDateTime ;
      private bool n415MediaImage ;
      private string A40000MediaImage_GXI ;
      private string A414MediaName ;
      private string A416MediaUrl ;
      private string AV15MediaPath ;
      private string A415MediaImage ;
      private Guid AV17Udparg1 ;
      private Guid A29LocationId ;
      private Guid A413MediaId ;
      private GxFile AV14File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Media> AV9SDT_MediaCollection ;
      private SdtSDT_Error AV13Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009M2_A29LocationId ;
      private bool[] P009M2_A636IsCropped ;
      private string[] P009M2_A40000MediaImage_GXI ;
      private bool[] P009M2_n40000MediaImage_GXI ;
      private Guid[] P009M2_A413MediaId ;
      private string[] P009M2_A414MediaName ;
      private int[] P009M2_A417MediaSize ;
      private string[] P009M2_A418MediaType ;
      private string[] P009M2_A416MediaUrl ;
      private DateTime[] P009M2_A618MediaDateTime ;
      private bool[] P009M2_n618MediaDateTime ;
      private string[] P009M2_A415MediaImage ;
      private bool[] P009M2_n415MediaImage ;
      private SdtSDT_Media AV8SDT_Media ;
      private GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
   }

   public class prc_getmedia__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009M2;
          prmP009M2 = new Object[] {
          new ParDef("AV17Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009M2", "SELECT LocationId, IsCropped, MediaImage_GXI, MediaId, MediaName, MediaSize, MediaType, MediaUrl, MediaDateTime, MediaImage FROM Trn_Media WHERE (LocationId = :AV17Udparg1) AND (IsCropped = FALSE) ORDER BY MediaDateTime DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
