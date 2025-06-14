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
   public class prc_deletecascadereceptionist : GXProcedure
   {
      public prc_deletecascadereceptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadereceptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ReceptionistId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.AV11ReceptionistId = aP0_ReceptionistId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ReceptionistId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId )
      {
         this.AV11ReceptionistId = aP0_ReceptionistId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9LocationId ,
                                              AV10OrganisationId ,
                                              AV11ReceptionistId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A89ReceptionistId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BV2 */
         pr_default.execute(0, new Object[] {AV9LocationId, AV10OrganisationId, AV11ReceptionistId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A89ReceptionistId = P00BV2_A89ReceptionistId[0];
            A11OrganisationId = P00BV2_A11OrganisationId[0];
            A29LocationId = P00BV2_A29LocationId[0];
            A95ReceptionistGAMGUID = P00BV2_A95ReceptionistGAMGUID[0];
            new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV8GAMErrorResponse) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8GAMErrorResponse)) )
            {
               /* Using cursor P00BV3 */
               pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadereceptionist",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         P00BV2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00BV2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BV2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BV2_A95ReceptionistGAMGUID = new string[] {""} ;
         A95ReceptionistGAMGUID = "";
         AV8GAMErrorResponse = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadereceptionist__default(),
            new Object[][] {
                new Object[] {
               P00BV2_A89ReceptionistId, P00BV2_A11OrganisationId, P00BV2_A29LocationId, P00BV2_A95ReceptionistGAMGUID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8GAMErrorResponse ;
      private string A95ReceptionistGAMGUID ;
      private Guid AV11ReceptionistId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BV2_A89ReceptionistId ;
      private Guid[] P00BV2_A11OrganisationId ;
      private Guid[] P00BV2_A29LocationId ;
      private string[] P00BV2_A95ReceptionistGAMGUID ;
   }

   public class prc_deletecascadereceptionist__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BV2( IGxContext context ,
                                             Guid AV9LocationId ,
                                             Guid AV10OrganisationId ,
                                             Guid AV11ReceptionistId ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid A89ReceptionistId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ReceptionistId, OrganisationId, LocationId, ReceptionistGAMGUID FROM Trn_Receptionist";
         if ( ! (Guid.Empty==AV9LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV9LocationId)");
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
         if ( ! (Guid.Empty==AV11ReceptionistId) )
         {
            AddWhere(sWhereString, "(ReceptionistId = :AV11ReceptionistId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistId, OrganisationId, LocationId";
         scmdbuf += " FOR UPDATE OF Trn_Receptionist";
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
                     return conditional_P00BV2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
          Object[] prmP00BV3;
          prmP00BV3 = new Object[] {
          new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BV2;
          prmP00BV2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11ReceptionistId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BV2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BV2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BV3", "SAVEPOINT gxupdate;DELETE FROM Trn_Receptionist  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BV3)
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
