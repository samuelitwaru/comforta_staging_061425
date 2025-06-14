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
   public class prc_deletecascadesupplierdynamicform : GXProcedure
   {
      public prc_deletecascadesupplierdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadesupplierdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierDynamicFormId ,
                           short aP1_WWPFormId ,
                           Guid aP2_SupplierGenId )
      {
         this.AV9SupplierDynamicFormId = aP0_SupplierDynamicFormId;
         this.AV11WWPFormId = aP1_WWPFormId;
         this.AV10SupplierGenId = aP2_SupplierGenId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_SupplierDynamicFormId ,
                                 short aP1_WWPFormId ,
                                 Guid aP2_SupplierGenId )
      {
         this.AV9SupplierDynamicFormId = aP0_SupplierDynamicFormId;
         this.AV11WWPFormId = aP1_WWPFormId;
         this.AV10SupplierGenId = aP2_SupplierGenId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10SupplierGenId ,
                                              AV9SupplierDynamicFormId ,
                                              AV11WWPFormId ,
                                              A42SupplierGenId ,
                                              A616SupplierDynamicFormId ,
                                              A206WWPFormId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00GC2 */
         pr_default.execute(0, new Object[] {AV10SupplierGenId, AV9SupplierDynamicFormId, AV11WWPFormId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = P00GC2_A206WWPFormId[0];
            A616SupplierDynamicFormId = P00GC2_A616SupplierDynamicFormId[0];
            A42SupplierGenId = P00GC2_A42SupplierGenId[0];
            new prc_deletesupplierform(context ).execute(  A616SupplierDynamicFormId,  A42SupplierGenId, out  AV8Messages) ;
            if ( AV8Messages.Count == 0 )
            {
               /* Using cursor P00GC3 */
               pr_default.execute(1, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadesupplierdynamicform",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A42SupplierGenId = Guid.Empty;
         A616SupplierDynamicFormId = Guid.Empty;
         P00GC2_A206WWPFormId = new short[1] ;
         P00GC2_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         P00GC2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadesupplierdynamicform__default(),
            new Object[][] {
                new Object[] {
               P00GC2_A206WWPFormId, P00GC2_A616SupplierDynamicFormId, P00GC2_A42SupplierGenId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11WWPFormId ;
      private short A206WWPFormId ;
      private Guid AV9SupplierDynamicFormId ;
      private Guid AV10SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid A616SupplierDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00GC2_A206WWPFormId ;
      private Guid[] P00GC2_A616SupplierDynamicFormId ;
      private Guid[] P00GC2_A42SupplierGenId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
   }

   public class prc_deletecascadesupplierdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GC2( IGxContext context ,
                                             Guid AV10SupplierGenId ,
                                             Guid AV9SupplierDynamicFormId ,
                                             short AV11WWPFormId ,
                                             Guid A42SupplierGenId ,
                                             Guid A616SupplierDynamicFormId ,
                                             short A206WWPFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormId, SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm";
         if ( ! (Guid.Empty==AV10SupplierGenId) )
         {
            AddWhere(sWhereString, "(SupplierGenId = :AV10SupplierGenId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Guid.Empty==AV9SupplierDynamicFormId) )
         {
            AddWhere(sWhereString, "(SupplierDynamicFormId = :AV9SupplierDynamicFormId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV11WWPFormId) )
         {
            AddWhere(sWhereString, "(WWPFormId = :AV11WWPFormId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierDynamicFormId, SupplierGenId";
         scmdbuf += " FOR UPDATE OF Trn_SupplierDynamicForm";
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
                     return conditional_P00GC2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (short)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (short)dynConstraints[5] );
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
          Object[] prmP00GC3;
          prmP00GC3 = new Object[] {
          new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GC2;
          prmP00GC2 = new Object[] {
          new ParDef("AV10SupplierGenId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GC2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GC2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GC3", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierDynamicForm  WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GC3)
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
                return;
       }
    }

 }

}
