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
   public class prc_deletecascadeaudit : GXProcedure
   {
      public prc_deletecascadeaudit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeaudit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AuditId ,
                           Guid aP1_OrganisationId )
      {
         this.AV8AuditId = aP0_AuditId;
         this.AV9OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AuditId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8AuditId = aP0_AuditId;
         this.AV9OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8AuditId ,
                                              AV9OrganisationId ,
                                              A371AuditId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00BQ2 */
         pr_default.execute(0, new Object[] {AV8AuditId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BQ2_A11OrganisationId[0];
            n11OrganisationId = P00BQ2_n11OrganisationId[0];
            A371AuditId = P00BQ2_A371AuditId[0];
            /* Using cursor P00BQ3 */
            pr_default.execute(1, new Object[] {A371AuditId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeaudit",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A371AuditId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00BQ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BQ2_n11OrganisationId = new bool[] {false} ;
         P00BQ2_A371AuditId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeaudit__default(),
            new Object[][] {
                new Object[] {
               P00BQ2_A11OrganisationId, P00BQ2_n11OrganisationId, P00BQ2_A371AuditId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n11OrganisationId ;
      private Guid AV8AuditId ;
      private Guid AV9OrganisationId ;
      private Guid A371AuditId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BQ2_A11OrganisationId ;
      private bool[] P00BQ2_n11OrganisationId ;
      private Guid[] P00BQ2_A371AuditId ;
   }

   public class prc_deletecascadeaudit__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BQ2( IGxContext context ,
                                             Guid AV8AuditId ,
                                             Guid AV9OrganisationId ,
                                             Guid A371AuditId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditId FROM Trn_Audit";
         if ( ! (Guid.Empty==AV8AuditId) )
         {
            AddWhere(sWhereString, "(AuditId = :AV8AuditId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV9OrganisationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditId";
         scmdbuf += " FOR UPDATE OF Trn_Audit";
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
                     return conditional_P00BQ2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmP00BQ3;
          prmP00BQ3 = new Object[] {
          new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BQ2;
          prmP00BQ2 = new Object[] {
          new ParDef("AV8AuditId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BQ2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BQ3", "SAVEPOINT gxupdate;DELETE FROM Trn_Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BQ3)
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
                return;
       }
    }

 }

}
