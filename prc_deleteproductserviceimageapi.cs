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
   public class prc_deleteproductserviceimageapi : GXProcedure
   {
      public prc_deleteproductserviceimageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deleteproductserviceimageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV16ProductServiceId = aP0_ProductServiceId;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_ProductServiceId )
      {
         execute(aP0_ProductServiceId, out aP1_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV16ProductServiceId = aP0_ProductServiceId;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_Error=this.AV8SDT_Error;
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
         GXt_guid1 = AV14OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV14OrganisationId = GXt_guid1;
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         AV9BC_ProductService.Load(AV16ProductServiceId, AV12LocationId, AV14OrganisationId);
         AV9BC_ProductService.gxTpr_Productserviceimage = "";
         AV9BC_ProductService.gxTpr_Productserviceimage_gxi = "";
         if ( AV9BC_ProductService.Update() )
         {
            context.CommitDataStores("prc_deleteproductserviceimageapi",pr_default);
         }
         else
         {
            AV10Errors = ((GeneXus.Utils.SdtMessages_Message)AV9BC_ProductService.GetMessages().Item(1)).gxTpr_Description;
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
         AV14OrganisationId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV9BC_ProductService = new SdtTrn_ProductService(context);
         AV10Errors = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deleteproductserviceimageapi__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deleteproductserviceimageapi__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deleteproductserviceimageapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10Errors ;
      private Guid AV16ProductServiceId ;
      private Guid AV14OrganisationId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8SDT_Error ;
      private SdtTrn_ProductService AV9BC_ProductService ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_Error aP1_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deleteproductserviceimageapi__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deleteproductserviceimageapi__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deleteproductserviceimageapi__default : DataStoreHelperBase, IDataStoreHelper
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
