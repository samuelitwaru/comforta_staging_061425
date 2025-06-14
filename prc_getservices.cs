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
   public class prc_getservices : GXProcedure
   {
      public prc_getservices( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getservices( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ,
                           out SdtSDT_Error aP1_error )
      {
         this.AV10SDT_ProductServiceCollection = aP0_SDT_ProductServiceCollection;
         this.AV11error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_error=this.AV11error;
      }

      public SdtSDT_Error executeUdp( GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection )
      {
         execute(aP0_SDT_ProductServiceCollection, out aP1_error);
         return AV11error ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         this.AV10SDT_ProductServiceCollection = aP0_SDT_ProductServiceCollection;
         this.AV11error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_error=this.AV11error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV13LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV13LocationId = GXt_guid1;
         GXt_guid1 = AV14OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV14OrganisationId = GXt_guid1;
         /* Using cursor P00AR2 */
         pr_default.execute(0, new Object[] {AV13LocationId, AV14OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00AR2_A11OrganisationId[0];
            A29LocationId = P00AR2_A29LocationId[0];
            A58ProductServiceId = P00AR2_A58ProductServiceId[0];
            A40000ProductServiceImage_GXI = P00AR2_A40000ProductServiceImage_GXI[0];
            A59ProductServiceName = P00AR2_A59ProductServiceName[0];
            A60ProductServiceDescription = P00AR2_A60ProductServiceDescription[0];
            A61ProductServiceImage = P00AR2_A61ProductServiceImage[0];
            AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
            AV8SDT_ProductService = new SdtSDT_ProductService(context);
            AV12BC_Trn_ProductService.Load(A58ProductServiceId, AV13LocationId, AV14OrganisationId);
            AV8SDT_ProductService.FromJSonString(AV12BC_Trn_ProductService.ToJSonString(true, true), null);
            AV8SDT_ProductService.gxTpr_Productserviceid = A58ProductServiceId;
            AV8SDT_ProductService.gxTpr_Productservicename = A59ProductServiceName;
            AV8SDT_ProductService.gxTpr_Productserviceimage = A61ProductServiceImage;
            AV8SDT_ProductService.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
            AV8SDT_ProductService.gxTpr_Productservicedescription = A60ProductServiceDescription;
            /* Using cursor P00AR3 */
            pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A368CallToActionName = P00AR3_A368CallToActionName[0];
               A342CallToActionPhone = P00AR3_A342CallToActionPhone[0];
               A341CallToActionEmail = P00AR3_A341CallToActionEmail[0];
               A367CallToActionUrl = P00AR3_A367CallToActionUrl[0];
               A340CallToActionType = P00AR3_A340CallToActionType[0];
               A339CallToActionId = P00AR3_A339CallToActionId[0];
               AV9SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
               AV9SDT_CallToActionItem.gxTpr_Calltoactionname = A368CallToActionName;
               AV9SDT_CallToActionItem.gxTpr_Calltoactionphone = A342CallToActionPhone;
               AV9SDT_CallToActionItem.gxTpr_Calltoactionemail = A341CallToActionEmail;
               AV9SDT_CallToActionItem.gxTpr_Calltoactionurl = A367CallToActionUrl;
               AV9SDT_CallToActionItem.gxTpr_Calltoactiontype = A340CallToActionType;
               AV8SDT_ProductService.gxTpr_Calltoactions.Add(AV9SDT_CallToActionItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV10SDT_ProductServiceCollection.Add(AV8SDT_ProductService, 0);
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
         AV11error = new SdtSDT_Error(context);
         AV13LocationId = Guid.Empty;
         AV14OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00AR2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AR2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AR2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00AR2_A40000ProductServiceImage_GXI = new string[] {""} ;
         P00AR2_A59ProductServiceName = new string[] {""} ;
         P00AR2_A60ProductServiceDescription = new string[] {""} ;
         P00AR2_A61ProductServiceImage = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A59ProductServiceName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV8SDT_ProductService = new SdtSDT_ProductService(context);
         P00AR3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00AR3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AR3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AR3_A368CallToActionName = new string[] {""} ;
         P00AR3_A342CallToActionPhone = new string[] {""} ;
         P00AR3_A341CallToActionEmail = new string[] {""} ;
         P00AR3_A367CallToActionUrl = new string[] {""} ;
         P00AR3_A340CallToActionType = new string[] {""} ;
         P00AR3_A339CallToActionId = new Guid[] {Guid.Empty} ;
         A368CallToActionName = "";
         A342CallToActionPhone = "";
         A341CallToActionEmail = "";
         A367CallToActionUrl = "";
         A340CallToActionType = "";
         A339CallToActionId = Guid.Empty;
         AV9SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getservices__default(),
            new Object[][] {
                new Object[] {
               P00AR2_A11OrganisationId, P00AR2_A29LocationId, P00AR2_A58ProductServiceId, P00AR2_A40000ProductServiceImage_GXI, P00AR2_A59ProductServiceName, P00AR2_A60ProductServiceDescription, P00AR2_A61ProductServiceImage
               }
               , new Object[] {
               P00AR3_A58ProductServiceId, P00AR3_A29LocationId, P00AR3_A11OrganisationId, P00AR3_A368CallToActionName, P00AR3_A342CallToActionPhone, P00AR3_A341CallToActionEmail, P00AR3_A367CallToActionUrl, P00AR3_A340CallToActionType, P00AR3_A339CallToActionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A342CallToActionPhone ;
      private string A60ProductServiceDescription ;
      private string A40000ProductServiceImage_GXI ;
      private string A59ProductServiceName ;
      private string A368CallToActionName ;
      private string A341CallToActionEmail ;
      private string A367CallToActionUrl ;
      private string A340CallToActionType ;
      private string A61ProductServiceImage ;
      private Guid AV13LocationId ;
      private Guid AV14OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A339CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ProductService> AV10SDT_ProductServiceCollection ;
      private SdtSDT_Error AV11error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AR2_A11OrganisationId ;
      private Guid[] P00AR2_A29LocationId ;
      private Guid[] P00AR2_A58ProductServiceId ;
      private string[] P00AR2_A40000ProductServiceImage_GXI ;
      private string[] P00AR2_A59ProductServiceName ;
      private string[] P00AR2_A60ProductServiceDescription ;
      private string[] P00AR2_A61ProductServiceImage ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private SdtSDT_ProductService AV8SDT_ProductService ;
      private Guid[] P00AR3_A58ProductServiceId ;
      private Guid[] P00AR3_A29LocationId ;
      private Guid[] P00AR3_A11OrganisationId ;
      private string[] P00AR3_A368CallToActionName ;
      private string[] P00AR3_A342CallToActionPhone ;
      private string[] P00AR3_A341CallToActionEmail ;
      private string[] P00AR3_A367CallToActionUrl ;
      private string[] P00AR3_A340CallToActionType ;
      private Guid[] P00AR3_A339CallToActionId ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV9SDT_CallToActionItem ;
      private SdtSDT_Error aP1_error ;
   }

   public class prc_getservices__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AR2;
          prmP00AR2 = new Object[] {
          new ParDef("AV13LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV14OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00AR3;
          prmP00AR3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AR2", "SELECT OrganisationId, LocationId, ProductServiceId, ProductServiceImage_GXI, ProductServiceName, ProductServiceDescription, ProductServiceImage FROM Trn_ProductService WHERE LocationId = :AV13LocationId and OrganisationId = :AV14OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AR3", "SELECT ProductServiceId, LocationId, OrganisationId, CallToActionName, CallToActionPhone, CallToActionEmail, CallToActionUrl, CallToActionType, CallToActionId FROM Trn_CallToAction WHERE ProductServiceId = :ProductServiceId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
