using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_mediaconversion : GXProcedure
   {
      public trn_mediaconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_mediaconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_MEDIAC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A636IsCropped = TRN_MEDIAC2_A636IsCropped[0];
            A618MediaDateTime = TRN_MEDIAC2_A618MediaDateTime[0];
            n618MediaDateTime = TRN_MEDIAC2_n618MediaDateTime[0];
            A29LocationId = TRN_MEDIAC2_A29LocationId[0];
            A416MediaUrl = TRN_MEDIAC2_A416MediaUrl[0];
            A418MediaType = TRN_MEDIAC2_A418MediaType[0];
            A417MediaSize = TRN_MEDIAC2_A417MediaSize[0];
            A414MediaName = TRN_MEDIAC2_A414MediaName[0];
            A413MediaId = TRN_MEDIAC2_A413MediaId[0];
            A40000MediaImage_GXI = TRN_MEDIAC2_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = TRN_MEDIAC2_n40000MediaImage_GXI[0];
            A415MediaImage = TRN_MEDIAC2_A415MediaImage[0];
            n415MediaImage = TRN_MEDIAC2_n415MediaImage[0];
            /*
               INSERT RECORD ON TABLE GXA0076

            */
            AV2MediaId = A413MediaId;
            AV3MediaName = A414MediaName;
            if ( TRN_MEDIAC2_n415MediaImage[0] )
            {
               AV4MediaImage = "";
               nV4MediaImage = false;
               nV4MediaImage = true;
            }
            else
            {
               AV4MediaImage = A415MediaImage;
               nV4MediaImage = false;
               AV5MediaImage_GXI = A40000MediaImage_GXI;
               nV5MediaImage_GXI = false;
            }
            if ( TRN_MEDIAC2_n40000MediaImage_GXI[0] )
            {
               AV5MediaImage_GXI = "";
               nV5MediaImage_GXI = false;
               nV5MediaImage_GXI = true;
            }
            else
            {
               AV5MediaImage_GXI = A40000MediaImage_GXI;
               nV5MediaImage_GXI = false;
            }
            AV6MediaSize = A417MediaSize;
            AV7MediaType = A418MediaType;
            AV8MediaUrl = A416MediaUrl;
            AV9LocationId = A29LocationId;
            if ( TRN_MEDIAC2_n618MediaDateTime[0] )
            {
               AV10MediaDateTime = (DateTime)(DateTime.MinValue);
               nV10MediaDateTime = false;
               nV10MediaDateTime = true;
            }
            else
            {
               AV10MediaDateTime = A618MediaDateTime;
               nV10MediaDateTime = false;
            }
            AV11IsCropped = A636IsCropped;
            AV12CroppedOriginalMediaId = Guid.Empty;
            nV12CroppedOriginalMediaId = false;
            nV12CroppedOriginalMediaId = true;
            /* Using cursor TRN_MEDIAC3 */
            pr_default.execute(1, new Object[] {AV2MediaId, AV3MediaName, nV4MediaImage, AV4MediaImage, nV5MediaImage_GXI, AV5MediaImage_GXI, AV6MediaSize, AV7MediaType, AV8MediaUrl, AV9LocationId, nV10MediaDateTime, AV10MediaDateTime, AV11IsCropped, nV12CroppedOriginalMediaId, AV12CroppedOriginalMediaId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0076");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
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
         TRN_MEDIAC2_A636IsCropped = new bool[] {false} ;
         TRN_MEDIAC2_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         TRN_MEDIAC2_n618MediaDateTime = new bool[] {false} ;
         TRN_MEDIAC2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_MEDIAC2_A416MediaUrl = new string[] {""} ;
         TRN_MEDIAC2_A418MediaType = new string[] {""} ;
         TRN_MEDIAC2_A417MediaSize = new int[1] ;
         TRN_MEDIAC2_A414MediaName = new string[] {""} ;
         TRN_MEDIAC2_A413MediaId = new Guid[] {Guid.Empty} ;
         TRN_MEDIAC2_A40000MediaImage_GXI = new string[] {""} ;
         TRN_MEDIAC2_n40000MediaImage_GXI = new bool[] {false} ;
         TRN_MEDIAC2_A415MediaImage = new string[] {""} ;
         TRN_MEDIAC2_n415MediaImage = new bool[] {false} ;
         A618MediaDateTime = (DateTime)(DateTime.MinValue);
         A29LocationId = Guid.Empty;
         A416MediaUrl = "";
         A418MediaType = "";
         A414MediaName = "";
         A413MediaId = Guid.Empty;
         A40000MediaImage_GXI = "";
         A415MediaImage = "";
         AV2MediaId = Guid.Empty;
         AV3MediaName = "";
         AV4MediaImage = "";
         AV5MediaImage_GXI = "";
         AV7MediaType = "";
         AV8MediaUrl = "";
         AV9LocationId = Guid.Empty;
         AV10MediaDateTime = (DateTime)(DateTime.MinValue);
         AV12CroppedOriginalMediaId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_mediaconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_MEDIAC2_A636IsCropped, TRN_MEDIAC2_A618MediaDateTime, TRN_MEDIAC2_n618MediaDateTime, TRN_MEDIAC2_A29LocationId, TRN_MEDIAC2_A416MediaUrl, TRN_MEDIAC2_A418MediaType, TRN_MEDIAC2_A417MediaSize, TRN_MEDIAC2_A414MediaName, TRN_MEDIAC2_A413MediaId, TRN_MEDIAC2_A40000MediaImage_GXI,
               TRN_MEDIAC2_n40000MediaImage_GXI, TRN_MEDIAC2_A415MediaImage, TRN_MEDIAC2_n415MediaImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A417MediaSize ;
      private int GIGXA0076 ;
      private int AV6MediaSize ;
      private string A418MediaType ;
      private string AV7MediaType ;
      private string Gx_emsg ;
      private DateTime A618MediaDateTime ;
      private DateTime AV10MediaDateTime ;
      private bool A636IsCropped ;
      private bool n618MediaDateTime ;
      private bool n40000MediaImage_GXI ;
      private bool n415MediaImage ;
      private bool nV4MediaImage ;
      private bool nV5MediaImage_GXI ;
      private bool nV10MediaDateTime ;
      private bool AV11IsCropped ;
      private bool nV12CroppedOriginalMediaId ;
      private string A416MediaUrl ;
      private string A414MediaName ;
      private string A40000MediaImage_GXI ;
      private string AV3MediaName ;
      private string AV5MediaImage_GXI ;
      private string AV8MediaUrl ;
      private string A415MediaImage ;
      private string AV4MediaImage ;
      private Guid A29LocationId ;
      private Guid A413MediaId ;
      private Guid AV2MediaId ;
      private Guid AV9LocationId ;
      private Guid AV12CroppedOriginalMediaId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] TRN_MEDIAC2_A636IsCropped ;
      private DateTime[] TRN_MEDIAC2_A618MediaDateTime ;
      private bool[] TRN_MEDIAC2_n618MediaDateTime ;
      private Guid[] TRN_MEDIAC2_A29LocationId ;
      private string[] TRN_MEDIAC2_A416MediaUrl ;
      private string[] TRN_MEDIAC2_A418MediaType ;
      private int[] TRN_MEDIAC2_A417MediaSize ;
      private string[] TRN_MEDIAC2_A414MediaName ;
      private Guid[] TRN_MEDIAC2_A413MediaId ;
      private string[] TRN_MEDIAC2_A40000MediaImage_GXI ;
      private bool[] TRN_MEDIAC2_n40000MediaImage_GXI ;
      private string[] TRN_MEDIAC2_A415MediaImage ;
      private bool[] TRN_MEDIAC2_n415MediaImage ;
   }

   public class trn_mediaconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_MEDIAC2;
          prmTRN_MEDIAC2 = new Object[] {
          };
          Object[] prmTRN_MEDIAC3;
          prmTRN_MEDIAC3 = new Object[] {
          new ParDef("AV2MediaId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3MediaName",GXType.VarChar,100,0) ,
          new ParDef("AV4MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
          new ParDef("AV5MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="GXA0076", Fld="MediaImage"} ,
          new ParDef("AV6MediaSize",GXType.Int32,8,0) ,
          new ParDef("AV7MediaType",GXType.Char,20,0) ,
          new ParDef("AV8MediaUrl",GXType.VarChar,1000,0) ,
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10MediaDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AV11IsCropped",GXType.Boolean,4,0) ,
          new ParDef("AV12CroppedOriginalMediaId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_MEDIAC2", "SELECT IsCropped, MediaDateTime, LocationId, MediaUrl, MediaType, MediaSize, MediaName, MediaId, MediaImage_GXI, MediaImage FROM Trn_Media ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_MEDIAC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_MEDIAC3", "INSERT INTO GXA0076(MediaId, MediaName, MediaImage, MediaImage_GXI, MediaSize, MediaType, MediaUrl, LocationId, MediaDateTime, IsCropped, CroppedOriginalMediaId) VALUES(:AV2MediaId, :AV3MediaName, :AV4MediaImage, :AV5MediaImage_GXI, :AV6MediaSize, :AV7MediaType, :AV8MediaUrl, :AV9LocationId, :AV10MediaDateTime, :AV11IsCropped, :AV12CroppedOriginalMediaId)", GxErrorMask.GX_NOMASK,prmTRN_MEDIAC3)
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(9));
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
