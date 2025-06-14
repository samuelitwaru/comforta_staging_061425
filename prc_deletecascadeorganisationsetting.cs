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
   public class prc_deletecascadeorganisationsetting : GXProcedure
   {
      public prc_deletecascadeorganisationsetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeorganisationsetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationSettingId ,
                           Guid aP1_OrganisationId )
      {
         this.AV9OrganisationSettingId = aP0_OrganisationSettingId;
         this.AV8OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_OrganisationSettingId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV9OrganisationSettingId = aP0_OrganisationSettingId;
         this.AV8OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8OrganisationId ,
                                              AV9OrganisationSettingId ,
                                              A11OrganisationId ,
                                              A100OrganisationSettingid } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00C02 */
         pr_default.execute(0, new Object[] {AV8OrganisationId, AV9OrganisationSettingId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100OrganisationSettingid = P00C02_A100OrganisationSettingid[0];
            A11OrganisationId = P00C02_A11OrganisationId[0];
            /* Using cursor P00C03 */
            pr_default.execute(1, new Object[] {A100OrganisationSettingid, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationSetting");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeorganisationsetting",pr_default);
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
         A100OrganisationSettingid = Guid.Empty;
         P00C02_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P00C02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeorganisationsetting__default(),
            new Object[][] {
                new Object[] {
               P00C02_A100OrganisationSettingid, P00C02_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV9OrganisationSettingId ;
      private Guid AV8OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C02_A100OrganisationSettingid ;
      private Guid[] P00C02_A11OrganisationId ;
   }

   public class prc_deletecascadeorganisationsetting__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C02( IGxContext context ,
                                             Guid AV8OrganisationId ,
                                             Guid AV9OrganisationSettingId ,
                                             Guid A11OrganisationId ,
                                             Guid A100OrganisationSettingid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting";
         if ( ! (Guid.Empty==AV8OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV8OrganisationId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV9OrganisationSettingId) )
         {
            AddWhere(sWhereString, "(OrganisationSettingid = :AV9OrganisationSettingId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationSettingid, OrganisationId";
         scmdbuf += " FOR UPDATE OF Trn_OrganisationSetting";
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
                     return conditional_P00C02(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmP00C03;
          prmP00C03 = new Object[] {
          new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00C02;
          prmP00C02 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationSettingId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C02", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C03", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationSetting  WHERE OrganisationSettingid = :OrganisationSettingid AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C03)
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
                return;
       }
    }

 }

}
