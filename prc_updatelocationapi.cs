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
   public class prc_updatelocationapi : GXProcedure
   {
      public prc_updatelocationapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_LocationDescription ,
                           string aP1_LocationImageBase64 ,
                           string aP2_ReceptionDescription ,
                           string aP3_ReceptionImageBase64 ,
                           out SdtSDT_Error aP4_SDT_Error )
      {
         this.AV13LocationDescription = aP0_LocationDescription;
         this.AV15LocationImageBase64 = aP1_LocationImageBase64;
         this.AV18ReceptionDescription = aP2_ReceptionDescription;
         this.AV19ReceptionImageBase64 = aP3_ReceptionImageBase64;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( string aP0_LocationDescription ,
                                      string aP1_LocationImageBase64 ,
                                      string aP2_ReceptionDescription ,
                                      string aP3_ReceptionImageBase64 )
      {
         execute(aP0_LocationDescription, aP1_LocationImageBase64, aP2_ReceptionDescription, aP3_ReceptionImageBase64, out aP4_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( string aP0_LocationDescription ,
                                 string aP1_LocationImageBase64 ,
                                 string aP2_ReceptionDescription ,
                                 string aP3_ReceptionImageBase64 ,
                                 out SdtSDT_Error aP4_SDT_Error )
      {
         this.AV13LocationDescription = aP0_LocationDescription;
         this.AV15LocationImageBase64 = aP1_LocationImageBase64;
         this.AV18ReceptionDescription = aP2_ReceptionDescription;
         this.AV19ReceptionImageBase64 = aP3_ReceptionImageBase64;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_SDT_Error=this.AV8SDT_Error;
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
         AV11ImageFile = "";
         AV20ReceptionImageFile = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15LocationImageBase64)) )
         {
            AV12ImageFilePreprocess = GxRegex.Split(AV15LocationImageBase64,",").GetString(2);
            AV11ImageFile=context.FileFromBase64( AV12ImageFilePreprocess) ;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ReceptionImageBase64)) )
         {
            AV21ReceptionImageFilePreprocess = GxRegex.Split(AV19ReceptionImageBase64,",").GetString(2);
            AV20ReceptionImageFile=context.FileFromBase64( AV21ReceptionImageFilePreprocess) ;
         }
         GXt_guid1 = AV17OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV17OrganisationId = GXt_guid1;
         GXt_guid1 = AV14LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV14LocationId = GXt_guid1;
         AV9BC_Trn_Location.Load(AV14LocationId, AV17OrganisationId);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13LocationDescription)) )
         {
            AV9BC_Trn_Location.gxTpr_Locationdescription = AV13LocationDescription;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ImageFile)) )
         {
            AV9BC_Trn_Location.gxTpr_Locationimage = AV11ImageFile;
            AV9BC_Trn_Location.gxTpr_Locationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV11ImageFile);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ReceptionDescription)) )
         {
            AV9BC_Trn_Location.gxTpr_Receptiondescription = AV18ReceptionDescription;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ReceptionImageFile)) )
         {
            AV9BC_Trn_Location.gxTpr_Receptionimage = AV20ReceptionImageFile;
            AV9BC_Trn_Location.gxTpr_Receptionimage_gxi = GXDbFile.GetUriFromFile( "", "", AV20ReceptionImageFile);
         }
         if ( AV9BC_Trn_Location.Update() )
         {
            context.CommitDataStores("prc_updatelocationapi",pr_default);
         }
         else
         {
            AV10Errors = ((GeneXus.Utils.SdtMessages_Message)AV9BC_Trn_Location.GetMessages().Item(1)).gxTpr_Description;
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
         AV8SDT_Error = new SdtSDT_Error(context);
         AV11ImageFile = "";
         AV20ReceptionImageFile = "";
         AV12ImageFilePreprocess = "";
         AV21ReceptionImageFilePreprocess = "";
         AV17OrganisationId = Guid.Empty;
         AV14LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV9BC_Trn_Location = new SdtTrn_Location(context);
         AV10Errors = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationapi__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationapi__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV13LocationDescription ;
      private string AV15LocationImageBase64 ;
      private string AV19ReceptionImageBase64 ;
      private string AV12ImageFilePreprocess ;
      private string AV21ReceptionImageFilePreprocess ;
      private string AV18ReceptionDescription ;
      private string AV10Errors ;
      private Guid AV17OrganisationId ;
      private Guid AV14LocationId ;
      private Guid GXt_guid1 ;
      private string AV11ImageFile ;
      private string AV20ReceptionImageFile ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_Location AV9BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_Error aP4_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatelocationapi__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatelocationapi__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatelocationapi__default : DataStoreHelperBase, IDataStoreHelper
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
