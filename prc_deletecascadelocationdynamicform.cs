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
   public class prc_deletecascadelocationdynamicform : GXProcedure
   {
      public prc_deletecascadelocationdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadelocationdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationDynamicFormId ,
                           short aP1_WWPFormId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.AV8LocationDynamicFormId = aP0_LocationDynamicFormId;
         this.AV11WWPFormId = aP1_WWPFormId;
         this.AV9LocationId = aP2_LocationId;
         this.AV10OrganisationId = aP3_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationDynamicFormId ,
                                 short aP1_WWPFormId ,
                                 Guid aP2_LocationId ,
                                 Guid aP3_OrganisationId )
      {
         this.AV8LocationDynamicFormId = aP0_LocationDynamicFormId;
         this.AV11WWPFormId = aP1_WWPFormId;
         this.AV9LocationId = aP2_LocationId;
         this.AV10OrganisationId = aP3_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9LocationId ,
                                              AV10OrganisationId ,
                                              AV8LocationDynamicFormId ,
                                              AV11WWPFormId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A366LocationDynamicFormId ,
                                              A206WWPFormId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BT2 */
         pr_default.execute(0, new Object[] {AV9LocationId, AV10OrganisationId, AV8LocationDynamicFormId, AV11WWPFormId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = P00BT2_A206WWPFormId[0];
            A366LocationDynamicFormId = P00BT2_A366LocationDynamicFormId[0];
            A11OrganisationId = P00BT2_A11OrganisationId[0];
            A29LocationId = P00BT2_A29LocationId[0];
            new prc_deletelocationform(context ).execute(  A366LocationDynamicFormId,  A11OrganisationId,  A29LocationId, out  AV12Messages) ;
            if ( AV12Messages.Count == 0 )
            {
               /* Using cursor P00BT3 */
               pr_default.execute(1, new Object[] {A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadelocationdynamicform",pr_default);
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
         A366LocationDynamicFormId = Guid.Empty;
         P00BT2_A206WWPFormId = new short[1] ;
         P00BT2_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00BT2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BT2_A29LocationId = new Guid[] {Guid.Empty} ;
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocationdynamicform__default(),
            new Object[][] {
                new Object[] {
               P00BT2_A206WWPFormId, P00BT2_A366LocationDynamicFormId, P00BT2_A11OrganisationId, P00BT2_A29LocationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11WWPFormId ;
      private short A206WWPFormId ;
      private Guid AV8LocationDynamicFormId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A366LocationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00BT2_A206WWPFormId ;
      private Guid[] P00BT2_A366LocationDynamicFormId ;
      private Guid[] P00BT2_A11OrganisationId ;
      private Guid[] P00BT2_A29LocationId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
   }

   public class prc_deletecascadelocationdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BT2( IGxContext context ,
                                             Guid AV9LocationId ,
                                             Guid AV10OrganisationId ,
                                             Guid AV8LocationDynamicFormId ,
                                             short AV11WWPFormId ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid A366LocationDynamicFormId ,
                                             short A206WWPFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormId, LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm";
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
         if ( ! (Guid.Empty==AV8LocationDynamicFormId) )
         {
            AddWhere(sWhereString, "(LocationDynamicFormId = :AV8LocationDynamicFormId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV11WWPFormId) )
         {
            AddWhere(sWhereString, "(WWPFormId = :AV11WWPFormId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LocationDynamicFormId, OrganisationId, LocationId";
         scmdbuf += " FOR UPDATE OF Trn_LocationDynamicForm";
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
                     return conditional_P00BT2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (short)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] , (Guid)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00BT3;
          prmP00BT3 = new Object[] {
          new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BT2;
          prmP00BT2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8LocationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BT2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BT3", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationDynamicForm  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BT3)
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
