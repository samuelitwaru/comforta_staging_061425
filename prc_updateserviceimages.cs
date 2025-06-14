using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prc_updateserviceimages : GXProcedure
   {
      public prc_updateserviceimages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateserviceimages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_ProductServiceId ,
                           GXBaseCollection<SdtSDT_FileUploadData> aP1_UploadedFiles ,
                           GXBaseCollection<SdtSDT_FileUploadData> aP2_FilesAlreadyExisting )
      {
         this.AV19ProductServiceId = aP0_ProductServiceId;
         this.AV22UploadedFiles = aP1_UploadedFiles;
         this.AV12FilesAlreadyExisting = aP2_FilesAlreadyExisting;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 GXBaseCollection<SdtSDT_FileUploadData> aP1_UploadedFiles ,
                                 GXBaseCollection<SdtSDT_FileUploadData> aP2_FilesAlreadyExisting )
      {
         this.AV19ProductServiceId = aP0_ProductServiceId;
         this.AV22UploadedFiles = aP1_UploadedFiles;
         this.AV12FilesAlreadyExisting = aP2_FilesAlreadyExisting;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13FilesToInsert = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21");
         AV15ImageIdsToKeep = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17OriginalImageIds = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV12FilesAlreadyExisting.Count )
         {
            AV11file = ((SdtSDT_FileUploadData)AV12FilesAlreadyExisting.Item(AV23GXV1));
            AV17OriginalImageIds.Add(AV11file.gxTpr_Name, 0);
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         AV24GXV2 = 1;
         while ( AV24GXV2 <= AV22UploadedFiles.Count )
         {
            AV11file = ((SdtSDT_FileUploadData)AV22UploadedFiles.Item(AV24GXV2));
            if ( StringUtil.StartsWith( AV11file.gxTpr_File, context.GetMessage( "data:", "")) )
            {
               AV13FilesToInsert.Add(AV11file, 0);
            }
            else
            {
               AV15ImageIdsToKeep.Add(AV11file.gxTpr_Name, 0);
            }
            AV24GXV2 = (int)(AV24GXV2+1);
         }
         if ( AV13FilesToInsert.Count > 0 )
         {
            AV25GXV3 = 1;
            while ( AV25GXV3 <= AV13FilesToInsert.Count )
            {
               AV20SDT_FileUploadData = ((SdtSDT_FileUploadData)AV13FilesToInsert.Item(AV25GXV3));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SDT_FileUploadData.gxTpr_File)) )
               {
                  AV14ImageFile = "";
                  AV9base64String = GxRegex.Split(AV20SDT_FileUploadData.gxTpr_File,",").GetString(2);
                  AV14ImageFile=context.FileFromBase64( AV9base64String) ;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ImageFile)) )
                  {
                     AV21Trn_ServiceImage = new SdtTrn_ServiceImage(context);
                     AV21Trn_ServiceImage.gxTpr_Serviceid = AV19ProductServiceId;
                     AV21Trn_ServiceImage.gxTpr_Serviceimage = AV14ImageFile;
                     AV21Trn_ServiceImage.gxTpr_Serviceimage_gxi = GXDbFile.GetUriFromFile( "", "", AV14ImageFile);
                     AV21Trn_ServiceImage.Insert();
                  }
               }
               AV25GXV3 = (int)(AV25GXV3+1);
            }
         }
         if ( AV15ImageIdsToKeep.Count > 0 )
         {
            AV26GXV4 = 1;
            while ( AV26GXV4 <= AV17OriginalImageIds.Count )
            {
               AV8ImageId = ((string)AV17OriginalImageIds.Item(AV26GXV4));
               if ( ! (AV15ImageIdsToKeep.IndexOf(StringUtil.RTrim( AV8ImageId))>0) )
               {
                  AV21Trn_ServiceImage.Load(StringUtil.StrToGuid( AV8ImageId));
                  AV21Trn_ServiceImage.Delete();
               }
               AV26GXV4 = (int)(AV26GXV4+1);
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
         AV13FilesToInsert = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21");
         AV15ImageIdsToKeep = new GxSimpleCollection<string>();
         AV17OriginalImageIds = new GxSimpleCollection<string>();
         AV11file = new SdtSDT_FileUploadData(context);
         AV20SDT_FileUploadData = new SdtSDT_FileUploadData(context);
         AV14ImageFile = "";
         AV9base64String = "";
         AV21Trn_ServiceImage = new SdtTrn_ServiceImage(context);
         AV8ImageId = "";
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private int AV25GXV3 ;
      private int AV26GXV4 ;
      private string AV9base64String ;
      private string AV8ImageId ;
      private Guid AV19ProductServiceId ;
      private string AV14ImageFile ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV22UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV12FilesAlreadyExisting ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV13FilesToInsert ;
      private GxSimpleCollection<string> AV15ImageIdsToKeep ;
      private GxSimpleCollection<string> AV17OriginalImageIds ;
      private SdtSDT_FileUploadData AV11file ;
      private SdtSDT_FileUploadData AV20SDT_FileUploadData ;
      private SdtTrn_ServiceImage AV21Trn_ServiceImage ;
   }

}
