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
   public class prc_getserviceimages : GXProcedure
   {
      public prc_getserviceimages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getserviceimages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           out GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection )
      {
         this.AV10ProductServiceId = aP0_ProductServiceId;
         this.AV13SDT_FileUploadDataCollection = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_FileUploadDataCollection=this.AV13SDT_FileUploadDataCollection;
      }

      public GXBaseCollection<SdtSDT_FileUploadData> executeUdp( Guid aP0_ProductServiceId )
      {
         execute(aP0_ProductServiceId, out aP1_SDT_FileUploadDataCollection);
         return AV13SDT_FileUploadDataCollection ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 out GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection )
      {
         this.AV10ProductServiceId = aP0_ProductServiceId;
         this.AV13SDT_FileUploadDataCollection = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21") ;
         SubmitImpl();
         aP1_SDT_FileUploadDataCollection=this.AV13SDT_FileUploadDataCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00F52 */
         pr_default.execute(0, new Object[] {AV10ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A609ServiceId = P00F52_A609ServiceId[0];
            A40000ServiceImage_GXI = P00F52_A40000ServiceImage_GXI[0];
            A608ServiceImageId = P00F52_A608ServiceImageId[0];
            A611ServiceImage = P00F52_A611ServiceImage[0];
            AV11Blob = A611ServiceImage;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Blob)) )
            {
               AV12SDT_FileUploadData = new SdtSDT_FileUploadData(context);
               AV12SDT_FileUploadData.gxTpr_Size = GxImageUtil.GetFileSize( A611ServiceImage);
               AV12SDT_FileUploadData.gxTpr_Extension = GXDbFile.GetFileType( A40000ServiceImage_GXI);
               AV12SDT_FileUploadData.gxTpr_Name = A608ServiceImageId.ToString();
               AV12SDT_FileUploadData.gxTpr_Fullname = GXDbFile.GetFileName( A40000ServiceImage_GXI);
               AV12SDT_FileUploadData.gxTpr_File = A40000ServiceImage_GXI;
               AV13SDT_FileUploadDataCollection.Add(AV12SDT_FileUploadData, 0);
            }
            AV11Blob = "";
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
         AV13SDT_FileUploadDataCollection = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21");
         P00F52_A609ServiceId = new Guid[] {Guid.Empty} ;
         P00F52_A40000ServiceImage_GXI = new string[] {""} ;
         P00F52_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         P00F52_A611ServiceImage = new string[] {""} ;
         A609ServiceId = Guid.Empty;
         A40000ServiceImage_GXI = "";
         A608ServiceImageId = Guid.Empty;
         A611ServiceImage = "";
         AV11Blob = "";
         AV12SDT_FileUploadData = new SdtSDT_FileUploadData(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getserviceimages__default(),
            new Object[][] {
                new Object[] {
               P00F52_A609ServiceId, P00F52_A40000ServiceImage_GXI, P00F52_A608ServiceImageId, P00F52_A611ServiceImage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A40000ServiceImage_GXI ;
      private string A611ServiceImage ;
      private Guid AV10ProductServiceId ;
      private Guid A609ServiceId ;
      private Guid A608ServiceImageId ;
      private string AV11Blob ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV13SDT_FileUploadDataCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00F52_A609ServiceId ;
      private string[] P00F52_A40000ServiceImage_GXI ;
      private Guid[] P00F52_A608ServiceImageId ;
      private string[] P00F52_A611ServiceImage ;
      private SdtSDT_FileUploadData AV12SDT_FileUploadData ;
      private GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection ;
   }

   public class prc_getserviceimages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F52;
          prmP00F52 = new Object[] {
          new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F52", "SELECT ServiceId, ServiceImage_GXI, ServiceImageId, ServiceImage FROM Trn_ServiceImage WHERE ServiceId = :AV10ProductServiceId ORDER BY ServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F52,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
       }
    }

 }

}
