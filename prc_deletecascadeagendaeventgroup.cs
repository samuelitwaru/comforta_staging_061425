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
   public class prc_deletecascadeagendaeventgroup : GXProcedure
   {
      public prc_deletecascadeagendaeventgroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeagendaeventgroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AgendaCalendarId ,
                           Guid aP1_ResidentId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         this.AV11ResidentId = aP1_ResidentId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AgendaCalendarId ,
                                 Guid aP1_ResidentId )
      {
         this.AV8AgendaCalendarId = aP0_AgendaCalendarId;
         this.AV11ResidentId = aP1_ResidentId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8AgendaCalendarId ,
                                              AV11ResidentId ,
                                              A268AgendaCalendarId ,
                                              A62ResidentId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BP2 */
         pr_default.execute(0, new Object[] {AV8AgendaCalendarId, AV11ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A62ResidentId = P00BP2_A62ResidentId[0];
            A268AgendaCalendarId = P00BP2_A268AgendaCalendarId[0];
            /* Using cursor P00BP3 */
            pr_default.execute(1, new Object[] {A268AgendaCalendarId, A62ResidentId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeagendaeventgroup",pr_default);
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
         A62ResidentId = Guid.Empty;
         P00BP2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00BP2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeagendaeventgroup__default(),
            new Object[][] {
                new Object[] {
               P00BP2_A62ResidentId, P00BP2_A268AgendaCalendarId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8AgendaCalendarId ;
      private Guid AV11ResidentId ;
      private Guid A268AgendaCalendarId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BP2_A62ResidentId ;
      private Guid[] P00BP2_A268AgendaCalendarId ;
   }

   public class prc_deletecascadeagendaeventgroup__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BP2( IGxContext context ,
                                             Guid AV8AgendaCalendarId ,
                                             Guid AV11ResidentId ,
                                             Guid A268AgendaCalendarId ,
                                             Guid A62ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ResidentId, AgendaCalendarId FROM Trn_AgendaEventGroup";
         if ( ! (Guid.Empty==AV8AgendaCalendarId) )
         {
            AddWhere(sWhereString, "(AgendaCalendarId = :AV8AgendaCalendarId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV11ResidentId) )
         {
            AddWhere(sWhereString, "(ResidentId = :AV11ResidentId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AgendaCalendarId, ResidentId";
         scmdbuf += " FOR UPDATE OF Trn_AgendaEventGroup";
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
                     return conditional_P00BP2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmP00BP3;
          prmP00BP3 = new Object[] {
          new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BP2;
          prmP00BP2 = new Object[] {
          new ParDef("AV8AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11ResidentId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BP2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BP3", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaEventGroup  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BP3)
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
