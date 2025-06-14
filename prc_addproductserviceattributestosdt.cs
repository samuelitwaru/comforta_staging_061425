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
   public class prc_addproductserviceattributestosdt : GXProcedure
   {
      public prc_addproductserviceattributestosdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addproductserviceattributestosdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           out SdtSDT_TrnAttributes aP1_SDT_TrnAttributes )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_TrnAttributes = new SdtSDT_TrnAttributes(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_TrnAttributes=this.AV9SDT_TrnAttributes;
      }

      public SdtSDT_TrnAttributes executeUdp( Guid aP0_ProductServiceId )
      {
         execute(aP0_ProductServiceId, out aP1_SDT_TrnAttributes);
         return AV9SDT_TrnAttributes ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 out SdtSDT_TrnAttributes aP1_SDT_TrnAttributes )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_TrnAttributes = new SdtSDT_TrnAttributes(context) ;
         SubmitImpl();
         aP1_SDT_TrnAttributes=this.AV9SDT_TrnAttributes;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DL2 */
         pr_default.execute(0, new Object[] {AV8ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A58ProductServiceId = P00DL2_A58ProductServiceId[0];
            A59ProductServiceName = P00DL2_A59ProductServiceName[0];
            A266ProductServiceTileName = P00DL2_A266ProductServiceTileName[0];
            A60ProductServiceDescription = P00DL2_A60ProductServiceDescription[0];
            A29LocationId = P00DL2_A29LocationId[0];
            A11OrganisationId = P00DL2_A11OrganisationId[0];
            AV9SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
            AV9SDT_TrnAttributes.gxTpr_Trnname = "Trn_ProductService";
            AV9SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Primarykeyid = A58ProductServiceId;
            AV10Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
            AV10Attribute.gxTpr_Attributename = "ProductServiceName";
            AV10Attribute.gxTpr_Attributevalue = A59ProductServiceName;
            AV9SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Add(AV10Attribute, 0);
            AV10Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
            AV10Attribute.gxTpr_Attributename = "ProductServiceTileName";
            AV10Attribute.gxTpr_Attributevalue = A266ProductServiceTileName;
            AV9SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Add(AV10Attribute, 0);
            AV10Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
            AV10Attribute.gxTpr_Attributename = "ProductServiceDescription";
            AV10Attribute.gxTpr_Attributevalue = A60ProductServiceDescription;
            AV9SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Add(AV10Attribute, 0);
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
         AV9SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         P00DL2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00DL2_A59ProductServiceName = new string[] {""} ;
         P00DL2_A266ProductServiceTileName = new string[] {""} ;
         P00DL2_A60ProductServiceDescription = new string[] {""} ;
         P00DL2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DL2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A59ProductServiceName = "";
         A266ProductServiceTileName = "";
         A60ProductServiceDescription = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV10Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addproductserviceattributestosdt__default(),
            new Object[][] {
                new Object[] {
               P00DL2_A58ProductServiceId, P00DL2_A59ProductServiceName, P00DL2_A266ProductServiceTileName, P00DL2_A60ProductServiceDescription, P00DL2_A29LocationId, P00DL2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A266ProductServiceTileName ;
      private string A60ProductServiceDescription ;
      private string A59ProductServiceName ;
      private Guid AV8ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_TrnAttributes AV9SDT_TrnAttributes ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DL2_A58ProductServiceId ;
      private string[] P00DL2_A59ProductServiceName ;
      private string[] P00DL2_A266ProductServiceTileName ;
      private string[] P00DL2_A60ProductServiceDescription ;
      private Guid[] P00DL2_A29LocationId ;
      private Guid[] P00DL2_A11OrganisationId ;
      private SdtSDT_TrnAttributes_Transaction_AttributeItem AV10Attribute ;
      private SdtSDT_TrnAttributes aP1_SDT_TrnAttributes ;
   }

   public class prc_addproductserviceattributestosdt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DL2;
          prmP00DL2 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DL2", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :AV8ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
       }
    }

 }

}
