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
   public class prc_updatelocationimages : GXProcedure
   {
      public prc_updatelocationimages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationimages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           GXBaseCollection<SdtSDT_FileUploadData> aP1_UploadedFiles ,
                           GXBaseCollection<SdtSDT_FileUploadData> aP2_FilesAlreadyExisting )
      {
         this.AV23LocationId = aP0_LocationId;
         this.AV22UploadedFiles = aP1_UploadedFiles;
         this.AV12FilesAlreadyExisting = aP2_FilesAlreadyExisting;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 GXBaseCollection<SdtSDT_FileUploadData> aP1_UploadedFiles ,
                                 GXBaseCollection<SdtSDT_FileUploadData> aP2_FilesAlreadyExisting )
      {
         this.AV23LocationId = aP0_LocationId;
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
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV12FilesAlreadyExisting.Count )
         {
            AV11file = ((SdtSDT_FileUploadData)AV12FilesAlreadyExisting.Item(AV26GXV1));
            AV17OriginalImageIds.Add(AV11file.gxTpr_Name, 0);
            AV26GXV1 = (int)(AV26GXV1+1);
         }
         AV27GXV2 = 1;
         while ( AV27GXV2 <= AV22UploadedFiles.Count )
         {
            AV11file = ((SdtSDT_FileUploadData)AV22UploadedFiles.Item(AV27GXV2));
            if ( StringUtil.StartsWith( AV11file.gxTpr_File, context.GetMessage( "data:", "")) )
            {
               AV13FilesToInsert.Add(AV11file, 0);
            }
            else
            {
               AV15ImageIdsToKeep.Add(AV11file.gxTpr_Name, 0);
            }
            AV27GXV2 = (int)(AV27GXV2+1);
         }
         if ( AV13FilesToInsert.Count > 0 )
         {
            AV28GXV3 = 1;
            while ( AV28GXV3 <= AV13FilesToInsert.Count )
            {
               AV20SDT_FileUploadData = ((SdtSDT_FileUploadData)AV13FilesToInsert.Item(AV28GXV3));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SDT_FileUploadData.gxTpr_File)) )
               {
                  AV14ImageFile = "";
                  AV9base64String = GxRegex.Split(AV20SDT_FileUploadData.gxTpr_File,",").GetString(2);
                  AV14ImageFile=context.FileFromBase64( AV9base64String) ;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ImageFile)) )
                  {
                     AV24Trn_LocationImage = new SdtTrn_LocationImage(context);
                     AV24Trn_LocationImage.gxTpr_Organisationlocationid = AV23LocationId;
                     AV24Trn_LocationImage.gxTpr_Organisationlocationimage = AV14ImageFile;
                     AV24Trn_LocationImage.gxTpr_Organisationlocationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV14ImageFile);
                     AV24Trn_LocationImage.Insert();
                  }
               }
               AV28GXV3 = (int)(AV28GXV3+1);
            }
         }
         if ( AV15ImageIdsToKeep.Count > 0 )
         {
            AV29GXV4 = 1;
            while ( AV29GXV4 <= AV17OriginalImageIds.Count )
            {
               AV8ImageId = ((string)AV17OriginalImageIds.Item(AV29GXV4));
               if ( ! (AV15ImageIdsToKeep.IndexOf(StringUtil.RTrim( AV8ImageId))>0) )
               {
                  AV24Trn_LocationImage.Load(StringUtil.StrToGuid( AV8ImageId));
                  AV24Trn_LocationImage.Delete();
               }
               AV29GXV4 = (int)(AV29GXV4+1);
            }
         }
         context.CommitDataStores("prc_updatelocationimages",pr_default);
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
         AV24Trn_LocationImage = new SdtTrn_LocationImage(context);
         AV8ImageId = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationimages__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationimages__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationimages__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV26GXV1 ;
      private int AV27GXV2 ;
      private int AV28GXV3 ;
      private int AV29GXV4 ;
      private string AV9base64String ;
      private string AV8ImageId ;
      private Guid AV23LocationId ;
      private string AV14ImageFile ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV22UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV12FilesAlreadyExisting ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV13FilesToInsert ;
      private GxSimpleCollection<string> AV15ImageIdsToKeep ;
      private GxSimpleCollection<string> AV17OriginalImageIds ;
      private SdtSDT_FileUploadData AV11file ;
      private SdtSDT_FileUploadData AV20SDT_FileUploadData ;
      private SdtTrn_LocationImage AV24Trn_LocationImage ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatelocationimages__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatelocationimages__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatelocationimages__default : DataStoreHelperBase, IDataStoreHelper
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
