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
   public class prc_deletecascadememo : GXProcedure
   {
      public prc_deletecascadememo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadememo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           ref Guid aP1_ResidentId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.AV10MemoId = aP0_MemoId;
         this.AV11ResidentId = aP1_ResidentId;
         this.AV8LocationId = aP2_LocationId;
         this.AV9OrganisationId = aP3_OrganisationId;
         initialize();
         ExecuteImpl();
         aP1_ResidentId=this.AV11ResidentId;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 ref Guid aP1_ResidentId ,
                                 Guid aP2_LocationId ,
                                 Guid aP3_OrganisationId )
      {
         this.AV10MemoId = aP0_MemoId;
         this.AV11ResidentId = aP1_ResidentId;
         this.AV8LocationId = aP2_LocationId;
         this.AV9OrganisationId = aP3_OrganisationId;
         SubmitImpl();
         aP1_ResidentId=this.AV11ResidentId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8LocationId ,
                                              AV9OrganisationId ,
                                              AV11ResidentId ,
                                              AV10MemoId ,
                                              A528SG_LocationId ,
                                              A529SG_OrganisationId ,
                                              A62ResidentId ,
                                              A549MemoId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00DF2 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9OrganisationId, AV11ResidentId, AV10MemoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A549MemoId = P00DF2_A549MemoId[0];
            A62ResidentId = P00DF2_A62ResidentId[0];
            A529SG_OrganisationId = P00DF2_A529SG_OrganisationId[0];
            A528SG_LocationId = P00DF2_A528SG_LocationId[0];
            /* Using cursor P00DF3 */
            pr_default.execute(1, new Object[] {A549MemoId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadememo",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A528SG_LocationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A549MemoId = Guid.Empty;
         P00DF2_A549MemoId = new Guid[] {Guid.Empty} ;
         P00DF2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00DF2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00DF2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadememo__default(),
            new Object[][] {
                new Object[] {
               P00DF2_A549MemoId, P00DF2_A62ResidentId, P00DF2_A529SG_OrganisationId, P00DF2_A528SG_LocationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV10MemoId ;
      private Guid AV11ResidentId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A528SG_LocationId ;
      private Guid A529SG_OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A549MemoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP1_ResidentId ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DF2_A549MemoId ;
      private Guid[] P00DF2_A62ResidentId ;
      private Guid[] P00DF2_A529SG_OrganisationId ;
      private Guid[] P00DF2_A528SG_LocationId ;
   }

   public class prc_deletecascadememo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DF2( IGxContext context ,
                                             Guid AV8LocationId ,
                                             Guid AV9OrganisationId ,
                                             Guid AV11ResidentId ,
                                             Guid AV10MemoId ,
                                             Guid A528SG_LocationId ,
                                             Guid A529SG_OrganisationId ,
                                             Guid A62ResidentId ,
                                             Guid A549MemoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MemoId, ResidentId, SG_OrganisationId, SG_LocationId FROM Trn_Memo";
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            AddWhere(sWhereString, "(SG_LocationId = :AV8LocationId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            AddWhere(sWhereString, "(SG_OrganisationId = :AV9OrganisationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Guid.Empty==AV11ResidentId) )
         {
            AddWhere(sWhereString, "(ResidentId = :AV11ResidentId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Guid.Empty==AV10MemoId) )
         {
            AddWhere(sWhereString, "(MemoId = :AV10MemoId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MemoId";
         scmdbuf += " FOR UPDATE OF Trn_Memo";
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
                     return conditional_P00DF2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] );
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
          Object[] prmP00DF3;
          prmP00DF3 = new Object[] {
          new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DF2;
          prmP00DF2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10MemoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DF2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DF3", "SAVEPOINT gxupdate;DELETE FROM Trn_Memo  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DF3)
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
