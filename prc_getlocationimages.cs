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
   public class prc_getlocationimages : GXProcedure
   {
      public prc_getlocationimages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationimages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           out GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection )
      {
         this.AV14LocationId = aP0_LocationId;
         this.AV13SDT_FileUploadDataCollection = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_FileUploadDataCollection=this.AV13SDT_FileUploadDataCollection;
      }

      public GXBaseCollection<SdtSDT_FileUploadData> executeUdp( Guid aP0_LocationId )
      {
         execute(aP0_LocationId, out aP1_SDT_FileUploadDataCollection);
         return AV13SDT_FileUploadDataCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection )
      {
         this.AV14LocationId = aP0_LocationId;
         this.AV13SDT_FileUploadDataCollection = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21") ;
         SubmitImpl();
         aP1_SDT_FileUploadDataCollection=this.AV13SDT_FileUploadDataCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00F22 */
         pr_default.execute(0, new Object[] {AV14LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A614OrganisationLocationId = P00F22_A614OrganisationLocationId[0];
            A40000OrganisationLocationImage_GXI = P00F22_A40000OrganisationLocationImage_GXI[0];
            A613LocationImageId = P00F22_A613LocationImageId[0];
            A615OrganisationLocationImage = P00F22_A615OrganisationLocationImage[0];
            AV11Blob = A615OrganisationLocationImage;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Blob)) )
            {
               AV12SDT_FileUploadData = new SdtSDT_FileUploadData(context);
               AV12SDT_FileUploadData.gxTpr_Size = GxImageUtil.GetFileSize( A615OrganisationLocationImage);
               AV12SDT_FileUploadData.gxTpr_Extension = GXDbFile.GetFileType( A40000OrganisationLocationImage_GXI);
               AV12SDT_FileUploadData.gxTpr_Name = A613LocationImageId.ToString();
               AV12SDT_FileUploadData.gxTpr_Fullname = GXDbFile.GetFileName( A40000OrganisationLocationImage_GXI);
               AV12SDT_FileUploadData.gxTpr_File = A40000OrganisationLocationImage_GXI;
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
         P00F22_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         P00F22_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         P00F22_A613LocationImageId = new Guid[] {Guid.Empty} ;
         P00F22_A615OrganisationLocationImage = new string[] {""} ;
         A614OrganisationLocationId = Guid.Empty;
         A40000OrganisationLocationImage_GXI = "";
         A613LocationImageId = Guid.Empty;
         A615OrganisationLocationImage = "";
         AV11Blob = "";
         AV12SDT_FileUploadData = new SdtSDT_FileUploadData(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationimages__default(),
            new Object[][] {
                new Object[] {
               P00F22_A614OrganisationLocationId, P00F22_A40000OrganisationLocationImage_GXI, P00F22_A613LocationImageId, P00F22_A615OrganisationLocationImage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A40000OrganisationLocationImage_GXI ;
      private string A615OrganisationLocationImage ;
      private Guid AV14LocationId ;
      private Guid A614OrganisationLocationId ;
      private Guid A613LocationImageId ;
      private string AV11Blob ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV13SDT_FileUploadDataCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00F22_A614OrganisationLocationId ;
      private string[] P00F22_A40000OrganisationLocationImage_GXI ;
      private Guid[] P00F22_A613LocationImageId ;
      private string[] P00F22_A615OrganisationLocationImage ;
      private SdtSDT_FileUploadData AV12SDT_FileUploadData ;
      private GXBaseCollection<SdtSDT_FileUploadData> aP1_SDT_FileUploadDataCollection ;
   }

   public class prc_getlocationimages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F22;
          prmP00F22 = new Object[] {
          new ParDef("AV14LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F22", "SELECT OrganisationLocationId, OrganisationLocationImage_GXI, LocationImageId, OrganisationLocationImage FROM Trn_LocationImage WHERE OrganisationLocationId = :AV14LocationId ORDER BY LocationImageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F22,100, GxCacheFrequency.OFF ,false,false )
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
