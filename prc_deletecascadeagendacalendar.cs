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
   public class prc_deletecascadeagendacalendar : GXProcedure
   {
      public prc_deletecascadeagendacalendar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeagendacalendar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AgendaCalendarId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AgendaCalendarId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8AgendaCalendarId ,
                                              AV9LocationId ,
                                              AV10OrganisationId ,
                                              A268AgendaCalendarId ,
                                              A29LocationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BO2 */
         pr_default.execute(0, new Object[] {AV8AgendaCalendarId, AV9LocationId, AV10OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BO2_A11OrganisationId[0];
            A29LocationId = P00BO2_A29LocationId[0];
            A268AgendaCalendarId = P00BO2_A268AgendaCalendarId[0];
            new prc_deletecascadeagendaeventgroup(context ).execute(  A268AgendaCalendarId,  Guid.Empty) ;
            /* Using cursor P00BO3 */
            pr_default.execute(1, new Object[] {A268AgendaCalendarId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeagendacalendar",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A268AgendaCalendarId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00BO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BO2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BO2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeagendacalendar__default(),
            new Object[][] {
                new Object[] {
               P00BO2_A11OrganisationId, P00BO2_A29LocationId, P00BO2_A268AgendaCalendarId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8AgendaCalendarId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid A268AgendaCalendarId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BO2_A11OrganisationId ;
      private Guid[] P00BO2_A29LocationId ;
      private Guid[] P00BO2_A268AgendaCalendarId ;
   }

   public class prc_deletecascadeagendacalendar__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BO2( IGxContext context ,
                                             Guid AV8AgendaCalendarId ,
                                             Guid AV9LocationId ,
                                             Guid AV10OrganisationId ,
                                             Guid A268AgendaCalendarId ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationId, AgendaCalendarId FROM Trn_AgendaCalendar";
         if ( ! (Guid.Empty==AV8AgendaCalendarId) )
         {
            AddWhere(sWhereString, "(AgendaCalendarId = :AV8AgendaCalendarId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV9LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV9LocationId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Guid.Empty==AV10OrganisationId) )
         {
            AddWhere(sWhereString, "(OrganisationId = :AV10OrganisationId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AgendaCalendarId";
         scmdbuf += " FOR UPDATE OF Trn_AgendaCalendar";
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
                     return conditional_P00BO2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
          Object[] prmP00BO3;
          prmP00BO3 = new Object[] {
          new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BO2;
          prmP00BO2 = new Object[] {
          new ParDef("AV8AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BO2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BO2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BO3", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BO3)
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
