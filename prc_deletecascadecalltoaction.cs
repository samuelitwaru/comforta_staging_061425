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
   public class prc_deletecascadecalltoaction : GXProcedure
   {
      public prc_deletecascadecalltoaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadecalltoaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CallToActionId ,
                           Guid aP1_LocationDynamicFormId ,
                           Guid aP2_ProductServiceId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId )
      {
         this.AV8CallToActionId = aP0_CallToActionId;
         this.AV9LocationDynamicFormId = aP1_LocationDynamicFormId;
         this.AV12ProductServiceId = aP2_ProductServiceId;
         this.AV10LocationId = aP3_LocationId;
         this.AV11OrganisationId = aP4_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_CallToActionId ,
                                 Guid aP1_LocationDynamicFormId ,
                                 Guid aP2_ProductServiceId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId )
      {
         this.AV8CallToActionId = aP0_CallToActionId;
         this.AV9LocationDynamicFormId = aP1_LocationDynamicFormId;
         this.AV12ProductServiceId = aP2_ProductServiceId;
         this.AV10LocationId = aP3_LocationId;
         this.AV11OrganisationId = aP4_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8CallToActionId ,
                                              AV10LocationId ,
                                              AV11OrganisationId ,
                                              AV12ProductServiceId ,
                                              AV9LocationDynamicFormId ,
                                              A339CallToActionId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A58ProductServiceId ,
                                              A366LocationDynamicFormId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV8CallToActionId, AV10LocationId, AV11OrganisationId, AV12ProductServiceId, AV9LocationDynamicFormId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A366LocationDynamicFormId = P00BR2_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = P00BR2_n366LocationDynamicFormId[0];
            A58ProductServiceId = P00BR2_A58ProductServiceId[0];
            A11OrganisationId = P00BR2_A11OrganisationId[0];
            A29LocationId = P00BR2_A29LocationId[0];
            A339CallToActionId = P00BR2_A339CallToActionId[0];
            /* Using cursor P00BR3 */
            pr_default.execute(1, new Object[] {A339CallToActionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadecalltoaction",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A339CallToActionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A366LocationDynamicFormId = Guid.Empty;
         P00BR2_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00BR2_n366LocationDynamicFormId = new bool[] {false} ;
         P00BR2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BR2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BR2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BR2_A339CallToActionId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadecalltoaction__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A366LocationDynamicFormId, P00BR2_n366LocationDynamicFormId, P00BR2_A58ProductServiceId, P00BR2_A11OrganisationId, P00BR2_A29LocationId, P00BR2_A339CallToActionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n366LocationDynamicFormId ;
      private Guid AV8CallToActionId ;
      private Guid AV9LocationDynamicFormId ;
      private Guid AV12ProductServiceId ;
      private Guid AV10LocationId ;
      private Guid AV11OrganisationId ;
      private Guid A339CallToActionId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A366LocationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BR2_A366LocationDynamicFormId ;
      private bool[] P00BR2_n366LocationDynamicFormId ;
      private Guid[] P00BR2_A58ProductServiceId ;
      private Guid[] P00BR2_A11OrganisationId ;
      private Guid[] P00BR2_A29LocationId ;
      private Guid[] P00BR2_A339CallToActionId ;
   }

   public class prc_deletecascadecalltoaction__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BR2( IGxContext context ,
                                             Guid AV8CallToActionId ,
                                             Guid AV10LocationId ,
                                             Guid AV11OrganisationId ,
                                             Guid AV12ProductServiceId ,
                                             Guid AV9LocationDynamicFormId ,
                                             Guid A339CallToActionId ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid A58ProductServiceId ,
                                             Guid A366LocationDynamicFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LocationDynamicFormId, ProductServiceId, OrganisationId, LocationId, CallToActionId FROM Trn_CallToAction";
         if ( ! (Guid.Empty==AV8CallToActionId) )
         {
            AddWhere(sWhereString, "(CallToActionId = :AV8CallToActionId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV10LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV10LocationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Guid.Empty==AV11OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV11OrganisationId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            AddWhere(sWhereString, "(ProductServiceId = :AV12ProductServiceId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Guid.Empty==AV9LocationDynamicFormId) )
         {
            AddWhere(sWhereString, "(LocationDynamicFormId = :AV9LocationDynamicFormId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CallToActionId";
         scmdbuf += " FOR UPDATE OF Trn_CallToAction";
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
                     return conditional_P00BR2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] , (Guid)dynConstraints[8] , (Guid)dynConstraints[9] );
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
          Object[] prmP00BR3;
          prmP00BR3 = new Object[] {
          new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BR2;
          prmP00BR2 = new Object[] {
          new ParDef("AV8CallToActionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9LocationDynamicFormId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BR2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BR3", "SAVEPOINT gxupdate;DELETE FROM Trn_CallToAction  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BR3)
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
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
