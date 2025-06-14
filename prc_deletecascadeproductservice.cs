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
   public class prc_deletecascadeproductservice : GXProcedure
   {
      public prc_deletecascadeproductservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeproductservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           Guid aP1_SupplierGenId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.AV10ProductServiceId = aP0_ProductServiceId;
         this.AV11SupplierGenId = aP1_SupplierGenId;
         this.AV8LocationId = aP2_LocationId;
         this.AV9OrganisationId = aP3_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 Guid aP1_SupplierGenId ,
                                 Guid aP2_LocationId ,
                                 Guid aP3_OrganisationId )
      {
         this.AV10ProductServiceId = aP0_ProductServiceId;
         this.AV11SupplierGenId = aP1_SupplierGenId;
         this.AV8LocationId = aP2_LocationId;
         this.AV9OrganisationId = aP3_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9OrganisationId ,
                                              AV10ProductServiceId ,
                                              AV8LocationId ,
                                              AV11SupplierGenId ,
                                              A11OrganisationId ,
                                              A58ProductServiceId ,
                                              A29LocationId ,
                                              A42SupplierGenId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00BS2 */
         pr_default.execute(0, new Object[] {AV9OrganisationId, AV10ProductServiceId, AV8LocationId, AV11SupplierGenId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A42SupplierGenId = P00BS2_A42SupplierGenId[0];
            n42SupplierGenId = P00BS2_n42SupplierGenId[0];
            A29LocationId = P00BS2_A29LocationId[0];
            A58ProductServiceId = P00BS2_A58ProductServiceId[0];
            A11OrganisationId = P00BS2_A11OrganisationId[0];
            new prc_deletecascadecalltoaction(context ).execute(  Guid.Empty,  Guid.Empty,  A58ProductServiceId,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadepage(context ).execute(  Guid.Empty,  A58ProductServiceId,  A29LocationId,  A11OrganisationId) ;
            /* Using cursor P00BS3 */
            pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeproductservice",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         P00BS2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00BS2_n42SupplierGenId = new bool[] {false} ;
         P00BS2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BS2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BS2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeproductservice__default(),
            new Object[][] {
                new Object[] {
               P00BS2_A42SupplierGenId, P00BS2_n42SupplierGenId, P00BS2_A29LocationId, P00BS2_A58ProductServiceId, P00BS2_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n42SupplierGenId ;
      private Guid AV10ProductServiceId ;
      private Guid AV11SupplierGenId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BS2_A42SupplierGenId ;
      private bool[] P00BS2_n42SupplierGenId ;
      private Guid[] P00BS2_A29LocationId ;
      private Guid[] P00BS2_A58ProductServiceId ;
      private Guid[] P00BS2_A11OrganisationId ;
   }

   public class prc_deletecascadeproductservice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BS2( IGxContext context ,
                                             Guid AV9OrganisationId ,
                                             Guid AV10ProductServiceId ,
                                             Guid AV8LocationId ,
                                             Guid AV11SupplierGenId ,
                                             Guid A11OrganisationId ,
                                             Guid A58ProductServiceId ,
                                             Guid A29LocationId ,
                                             Guid A42SupplierGenId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, LocationId, ProductServiceId, OrganisationId FROM Trn_ProductService";
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV9OrganisationId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV10ProductServiceId) )
         {
            AddWhere(sWhereString, "(ProductServiceId = :AV10ProductServiceId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV8LocationId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Guid.Empty==AV11SupplierGenId) )
         {
            AddWhere(sWhereString, "(SupplierGenId = :AV11SupplierGenId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceId, LocationId, OrganisationId";
         scmdbuf += " FOR UPDATE OF Trn_ProductService";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BS2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00BS3;
          prmP00BS3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BS2;
          prmP00BS2 = new Object[] {
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BS2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS3", "SAVEPOINT gxupdate;DELETE FROM Trn_ProductService  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BS3)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
