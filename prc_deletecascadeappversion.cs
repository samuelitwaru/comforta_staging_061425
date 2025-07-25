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
   public class prc_deletecascadeappversion : GXProcedure
   {
      public prc_deletecascadeappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8AppVersionId ,
                                              AV9LocationId ,
                                              AV10OrganisationId ,
                                              A523AppVersionId ,
                                              A29LocationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00HC2 */
         pr_default.execute(0, new Object[] {AV8AppVersionId, AV9LocationId, AV10OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTHC2 = 0;
            A11OrganisationId = P00HC2_A11OrganisationId[0];
            n11OrganisationId = P00HC2_n11OrganisationId[0];
            A29LocationId = P00HC2_A29LocationId[0];
            n29LocationId = P00HC2_n29LocationId[0];
            A523AppVersionId = P00HC2_A523AppVersionId[0];
            /* Using cursor P00HC3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            GXTHC2 = 1;
            if ( GXTHC2 == 1 )
            {
               context.CommitDataStores("prc_deletecascadeappversion",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadeappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A523AppVersionId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00HC2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00HC2_n11OrganisationId = new bool[] {false} ;
         P00HC2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00HC2_n29LocationId = new bool[] {false} ;
         P00HC2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeappversion__default(),
            new Object[][] {
                new Object[] {
               P00HC2_A11OrganisationId, P00HC2_n11OrganisationId, P00HC2_A29LocationId, P00HC2_n29LocationId, P00HC2_A523AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTHC2 ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private Guid AV8AppVersionId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00HC2_A11OrganisationId ;
      private bool[] P00HC2_n11OrganisationId ;
      private Guid[] P00HC2_A29LocationId ;
      private bool[] P00HC2_n29LocationId ;
      private Guid[] P00HC2_A523AppVersionId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadeappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_deletecascadeappversion__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_deletecascadeappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00HC2( IGxContext context ,
                                          Guid AV8AppVersionId ,
                                          Guid AV9LocationId ,
                                          Guid AV10OrganisationId ,
                                          Guid A523AppVersionId ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int1 = new short[3];
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT OrganisationId, LocationId, AppVersionId FROM Trn_AppVersion";
      if ( ! (Guid.Empty==AV8AppVersionId) )
      {
         AddWhere(sWhereString, "(AppVersionId = :AV8AppVersionId)");
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
      scmdbuf += " ORDER BY AppVersionId";
      scmdbuf += " FOR UPDATE OF Trn_AppVersion";
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
                  return conditional_P00HC2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
       Object[] prmP00HC3;
       prmP00HC3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00HC2;
       prmP00HC2 = new Object[] {
       new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00HC2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HC2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00HC3", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00HC3)
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
             ((bool[]) buf[3])[0] = rslt.wasNull(2);
             ((Guid[]) buf[4])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
