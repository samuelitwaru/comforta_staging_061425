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
   public class aprc_createcontentpage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createcontentpage().MainImpl(args); ;
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

      public aprc_createcontentpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createcontentpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           out string aP1_Response ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         this.AV22Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
         aP2_Error=this.AV22Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_PageId ,
                                      out string aP1_Response )
      {
         execute(aP0_PageId, out aP1_Response, out aP2_Error);
         return AV22Error ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 out string aP1_Response ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV12PageId = aP0_PageId;
         this.AV17Response = "" ;
         this.AV22Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Response=this.AV17Response;
         aP2_Error=this.AV22Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV22Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV22Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            GXt_guid1 = AV19LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            AV19LocationId = GXt_guid1;
            GXt_guid1 = AV20OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV20OrganisationId = GXt_guid1;
            AV23GXLvl8 = 0;
            /* Using cursor P008O2 */
            pr_default.execute(0, new Object[] {AV12PageId, AV19LocationId, AV20OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P008O2_A11OrganisationId[0];
               A29LocationId = P008O2_A29LocationId[0];
               A58ProductServiceId = P008O2_A58ProductServiceId[0];
               AV23GXLvl8 = 1;
               AV18BC_Trn_ProductService.Load(AV12PageId, AV19LocationId, AV20OrganisationId);
               AV16PageName = AV18BC_Trn_ProductService.gxTpr_Productservicename;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV23GXLvl8 == 0 )
            {
               AV18BC_Trn_ProductService = new SdtTrn_ProductService(context);
               AV18BC_Trn_ProductService.FromJSonString(context.GetMessage( "{\"ProductServiceId_N\":0,\"LocationId\":\"a81dfcef-c383-44ce-8cad-891516e1a568\",\"OrganisationId\":\"aca3bfc6-a3ff-4130-9ebd-b30269c32aef\",\"ProductServiceName\":\"Hello World Service 1\",\"ProductServiceTileName\":\"Hello World Service \",\"ProductServiceDescription\":\"\",\"ProductServiceClass\":\"My Living\",\"ProductServiceImage\":\"\",\"ProductServiceGroup\":\"Location\",\"SupplierGenId\":\"00000000-0000-0000-0000-000000000000\",\"SupplierGenId_N\":1,\"SupplierGenCompanyName\":\"\",\"SupplierAgbId\":\"00000000-0000-0000-0000-000000000000\",\"SupplierAgbId_N\":1,\"SupplierAgbName\":\"\",\"ProductServiceImage_GXI\":\"\",\"Mode\":\"UPD\",\"Initialized\":0,\"ProductServiceId_Z\":\"c7a43bec-83bc-4a9a-ac74-9700882d6529\",\"LocationId_Z\":\"a81dfcef-c383-44ce-8cad-891516e1a568\",\"OrganisationId_Z\":\"aca3bfc6-a3ff-4130-9ebd-b30269c32aef\",\"ProductServiceName_Z\":\"Hello World Service\",\"ProductServiceTileName_Z\":\"Hello World Service \",\"ProductServiceClass_Z\":\"My Living\",\"ProductServiceGroup_Z\":\"Location\",\"SupplierGenId_Z\":\"00000000-0000-0000-0000-000000000000\",\"SupplierGenCompanyName_Z\":\"\",\"SupplierAgbId_Z\":\"00000000-0000-0000-0000-000000000000\",\"SupplierAgbName_Z\":\"\",\"ProductServiceImage_GXI_Z\":\"\"}", ""), null);
               AV18BC_Trn_ProductService.gxTpr_Productservicename = context.GetMessage( "Name - ", "")+AV18BC_Trn_ProductService.gxTpr_Productserviceid.ToString();
               AV18BC_Trn_ProductService.gxTpr_Productservicetilename = context.GetMessage( "Service Tile Name", "");
               AV18BC_Trn_ProductService.gxTpr_Productservicedescription = context.GetMessage( "Product Service Description", "");
               AV18BC_Trn_ProductService.gxTpr_Productserviceclass = context.GetMessage( "My Living", "");
               AV18BC_Trn_ProductService.gxTpr_Productserviceimage_gxi = context.GetMessage( "/Resources/UCGrapes1/src/images/img-dummy-product.jpg", "");
               AV18BC_Trn_ProductService.gxTpr_Productserviceimage = "";
               AV18BC_Trn_ProductService.gxTpr_Locationid = AV19LocationId;
               AV18BC_Trn_ProductService.gxTpr_Organisationid = AV20OrganisationId;
               if ( AV18BC_Trn_ProductService.Insert() )
               {
                  context.CommitDataStores("prc_createcontentpage",pr_default);
               }
               else
               {
                  AV25GXV2 = 1;
                  AV24GXV1 = AV18BC_Trn_ProductService.GetMessages();
                  while ( AV25GXV2 <= AV24GXV1.Count )
                  {
                     AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV24GXV1.Item(AV25GXV2));
                     AV22Error.gxTpr_Message = AV9Message.gxTpr_Description;
                     AV25GXV2 = (int)(AV25GXV2+1);
                  }
               }
            }
            if ( ! (Guid.Empty==AV18BC_Trn_ProductService.gxTpr_Productserviceid) )
            {
               AV8BC_Trn_Page = new SdtTrn_Page(context);
               AV8BC_Trn_Page.Load(AV12PageId, AV19LocationId);
               AV8BC_Trn_Page.gxTpr_Trn_pageid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
               AV8BC_Trn_Page.gxTpr_Trn_pagename = AV18BC_Trn_ProductService.gxTpr_Productservicename;
               AV8BC_Trn_Page.gxTpr_Productserviceid = AV18BC_Trn_ProductService.gxTpr_Productserviceid;
               AV8BC_Trn_Page.gxTpr_Pagejsoncontent = AV13PageJsonContent;
               AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
               AV8BC_Trn_Page.gxTpr_Pagegjsjson = "";
               AV8BC_Trn_Page.gxTpr_Pageiscontentpage = true;
               AV8BC_Trn_Page.gxTpr_Pageispublished = false;
               GXt_guid1 = Guid.Empty;
               new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Locationid = GXt_guid1;
               GXt_guid1 = Guid.Empty;
               new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
               AV8BC_Trn_Page.gxTpr_Organisationid = GXt_guid1;
               AV8BC_Trn_Page.Save();
               if ( AV8BC_Trn_Page.Success() )
               {
                  context.CommitDataStores("prc_createcontentpage",pr_default);
                  AV17Response = context.GetMessage( "Content page saved successfully", "");
                  new prc_logtofile(context ).execute(  AV17Response) ;
               }
               else
               {
                  AV27GXV4 = 1;
                  AV26GXV3 = AV8BC_Trn_Page.GetMessages();
                  while ( AV27GXV4 <= AV26GXV3.Count )
                  {
                     AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV26GXV3.Item(AV27GXV4));
                     new prc_logtofile(context ).execute(  ">>>>> "+AV9Message.gxTpr_Description) ;
                     AV27GXV4 = (int)(AV27GXV4+1);
                  }
               }
            }
            AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
            cleanup();
            if (true) return;
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
         AV17Response = "";
         AV22Error = new SdtSDT_Error(context);
         AV19LocationId = Guid.Empty;
         AV20OrganisationId = Guid.Empty;
         P008O2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008O2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008O2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV18BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV16PageName = "";
         AV24GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV13PageJsonContent = "";
         GXt_guid1 = Guid.Empty;
         AV26GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createcontentpage__default(),
            new Object[][] {
                new Object[] {
               P008O2_A11OrganisationId, P008O2_A29LocationId, P008O2_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23GXLvl8 ;
      private int AV25GXV2 ;
      private int AV27GXV4 ;
      private string AV17Response ;
      private string AV13PageJsonContent ;
      private string AV16PageName ;
      private Guid AV12PageId ;
      private Guid AV19LocationId ;
      private Guid AV20OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV22Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008O2_A11OrganisationId ;
      private Guid[] P008O2_A29LocationId ;
      private Guid[] P008O2_A58ProductServiceId ;
      private SdtTrn_ProductService AV18BC_Trn_ProductService ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV26GXV3 ;
      private string aP1_Response ;
      private SdtSDT_Error aP2_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createcontentpage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_createcontentpage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createcontentpage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP008O2;
       prmP008O2 = new Object[] {
       new ParDef("AV12PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P008O2", "SELECT OrganisationId, LocationId, ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :AV12PageId and LocationId = :AV19LocationId and OrganisationId = :AV20OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O2,1, GxCacheFrequency.OFF ,true,true )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
