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
   public class prc_deletecascademanager : GXProcedure
   {
      public prc_deletecascademanager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascademanager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ManagerId ,
                           Guid aP1_OrganisationId )
      {
         this.AV9ManagerId = aP0_ManagerId;
         this.AV10OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ManagerId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV9ManagerId = aP0_ManagerId;
         this.AV10OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9ManagerId ,
                                              AV10OrganisationId ,
                                              A21ManagerId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BX2 */
         pr_default.execute(0, new Object[] {AV9ManagerId, AV10OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BX2_A11OrganisationId[0];
            A21ManagerId = P00BX2_A21ManagerId[0];
            A28ManagerGAMGUID = P00BX2_A28ManagerGAMGUID[0];
            new prc_deletegamuseraccount(context ).execute(  A28ManagerGAMGUID, out  AV8GAMErrorResponse) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8GAMErrorResponse)) )
            {
               /* Using cursor P00BX3 */
               pr_default.execute(1, new Object[] {A21ManagerId, A11OrganisationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascademanager",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A21ManagerId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00BX2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BX2_A21ManagerId = new Guid[] {Guid.Empty} ;
         P00BX2_A28ManagerGAMGUID = new string[] {""} ;
         A28ManagerGAMGUID = "";
         AV8GAMErrorResponse = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascademanager__default(),
            new Object[][] {
                new Object[] {
               P00BX2_A11OrganisationId, P00BX2_A21ManagerId, P00BX2_A28ManagerGAMGUID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8GAMErrorResponse ;
      private string A28ManagerGAMGUID ;
      private Guid AV9ManagerId ;
      private Guid AV10OrganisationId ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BX2_A11OrganisationId ;
      private Guid[] P00BX2_A21ManagerId ;
      private string[] P00BX2_A28ManagerGAMGUID ;
   }

   public class prc_deletecascademanager__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BX2( IGxContext context ,
                                             Guid AV9ManagerId ,
                                             Guid AV10OrganisationId ,
                                             Guid A21ManagerId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ManagerId, ManagerGAMGUID FROM Trn_Manager";
         if ( ! (Guid.Empty==AV9ManagerId) )
         {
            AddWhere(sWhereString, "(ManagerId = :AV9ManagerId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV10OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV10OrganisationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ManagerId, OrganisationId";
         scmdbuf += " FOR UPDATE OF Trn_Manager";
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
                     return conditional_P00BX2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmP00BX3;
          prmP00BX3 = new Object[] {
          new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BX2;
          prmP00BX2 = new Object[] {
          new ParDef("AV9ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BX2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BX3", "SAVEPOINT gxupdate;DELETE FROM Trn_Manager  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BX3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
