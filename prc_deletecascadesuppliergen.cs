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
   public class prc_deletecascadesuppliergen : GXProcedure
   {
      public prc_deletecascadesuppliergen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadesuppliergen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierGenId ,
                           Guid aP1_OrganisationId ,
                           bool aP2_isMain ,
                           ref bool aP3_isSuccessful ,
                           ref string aP4_Message )
      {
         this.AV9SupplierGenId = aP0_SupplierGenId;
         this.AV8OrganisationId = aP1_OrganisationId;
         this.AV12isMain = aP2_isMain;
         this.AV13isSuccessful = aP3_isSuccessful;
         this.AV14Message = aP4_Message;
         initialize();
         ExecuteImpl();
         aP3_isSuccessful=this.AV13isSuccessful;
         aP4_Message=this.AV14Message;
      }

      public string executeUdp( Guid aP0_SupplierGenId ,
                                Guid aP1_OrganisationId ,
                                bool aP2_isMain ,
                                ref bool aP3_isSuccessful )
      {
         execute(aP0_SupplierGenId, aP1_OrganisationId, aP2_isMain, ref aP3_isSuccessful, ref aP4_Message);
         return AV14Message ;
      }

      public void executeSubmit( Guid aP0_SupplierGenId ,
                                 Guid aP1_OrganisationId ,
                                 bool aP2_isMain ,
                                 ref bool aP3_isSuccessful ,
                                 ref string aP4_Message )
      {
         this.AV9SupplierGenId = aP0_SupplierGenId;
         this.AV8OrganisationId = aP1_OrganisationId;
         this.AV12isMain = aP2_isMain;
         this.AV13isSuccessful = aP3_isSuccessful;
         this.AV14Message = aP4_Message;
         SubmitImpl();
         aP3_isSuccessful=this.AV13isSuccessful;
         aP4_Message=this.AV14Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9SupplierGenId ,
                                              AV8OrganisationId ,
                                              A42SupplierGenId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00C12 */
         pr_default.execute(0, new Object[] {AV9SupplierGenId, AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC12 = 0;
            A602SG_LocationSupplierOrganisatio = P00C12_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = P00C12_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = P00C12_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = P00C12_n603SG_LocationSupplierLocationId[0];
            A630ToolBoxLastUpdateReceptionistI = P00C12_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00C12_n630ToolBoxLastUpdateReceptionistI[0];
            A89ReceptionistId = P00C12_A89ReceptionistId[0];
            A29LocationId = P00C12_A29LocationId[0];
            A42SupplierGenId = P00C12_A42SupplierGenId[0];
            A630ToolBoxLastUpdateReceptionistI = P00C12_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00C12_n630ToolBoxLastUpdateReceptionistI[0];
            /* Using cursor P00C13 */
            pr_default.execute(1, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(1);
            new prc_deletecascadeproductservice(context ).execute(  Guid.Empty,  A42SupplierGenId,  Guid.Empty,  A11OrganisationId) ;
            new prc_deletecascadesupplierdynamicform(context ).execute(  Guid.Empty,  0,  A42SupplierGenId) ;
            if ( AV12isMain )
            {
               AV10Trn_SupplierGen.Load(A42SupplierGenId);
               AV10Trn_SupplierGen.Delete();
               if ( AV10Trn_SupplierGen.Success() )
               {
                  AV13isSuccessful = true;
                  GXTC12 = 1;
               }
               else
               {
                  AV17GXV2 = 1;
                  AV16GXV1 = AV10Trn_SupplierGen.GetMessages();
                  while ( AV17GXV2 <= AV16GXV1.Count )
                  {
                     AV11ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV16GXV1.Item(AV17GXV2));
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14Message)) )
                     {
                        AV14Message = AV11ErrorMessage.gxTpr_Description;
                     }
                     else
                     {
                        AV14Message += ", " + AV11ErrorMessage.gxTpr_Description;
                     }
                     AV17GXV2 = (int)(AV17GXV2+1);
                  }
                  AV13isSuccessful = false;
               }
            }
            else
            {
               /* Using cursor P00C14 */
               pr_default.execute(2, new Object[] {A42SupplierGenId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
            }
            if ( GXTC12 == 1 )
            {
               context.CommitDataStores("prc_deletecascadesuppliergen",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(1);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadesuppliergen",pr_default);
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
         A11OrganisationId = Guid.Empty;
         P00C12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C12_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         P00C12_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         P00C12_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         P00C12_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         P00C12_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00C12_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00C12_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00C12_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C12_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00C13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV10Trn_SupplierGen = new SdtTrn_SupplierGen(context);
         AV16GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadesuppliergen__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadesuppliergen__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadesuppliergen__default(),
            new Object[][] {
                new Object[] {
               P00C12_A11OrganisationId, P00C12_A602SG_LocationSupplierOrganisatio, P00C12_n602SG_LocationSupplierOrganisatio, P00C12_A603SG_LocationSupplierLocationId, P00C12_n603SG_LocationSupplierLocationId, P00C12_A630ToolBoxLastUpdateReceptionistI, P00C12_n630ToolBoxLastUpdateReceptionistI, P00C12_A89ReceptionistId, P00C12_A29LocationId, P00C12_A42SupplierGenId
               }
               , new Object[] {
               P00C13_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC12 ;
      private int AV17GXV2 ;
      private bool AV12isMain ;
      private bool AV13isSuccessful ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private string AV14Message ;
      private Guid AV9SupplierGenId ;
      private Guid AV8OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A11OrganisationId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A89ReceptionistId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP3_isSuccessful ;
      private string aP4_Message ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C12_A11OrganisationId ;
      private Guid[] P00C12_A602SG_LocationSupplierOrganisatio ;
      private bool[] P00C12_n602SG_LocationSupplierOrganisatio ;
      private Guid[] P00C12_A603SG_LocationSupplierLocationId ;
      private bool[] P00C12_n603SG_LocationSupplierLocationId ;
      private Guid[] P00C12_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00C12_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] P00C12_A89ReceptionistId ;
      private Guid[] P00C12_A29LocationId ;
      private Guid[] P00C12_A42SupplierGenId ;
      private Guid[] P00C13_A11OrganisationId ;
      private SdtTrn_SupplierGen AV10Trn_SupplierGen ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV11ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadesuppliergen__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecascadesuppliergen__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecascadesuppliergen__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00C12( IGxContext context ,
                                          Guid AV9SupplierGenId ,
                                          Guid AV8OrganisationId ,
                                          Guid A42SupplierGenId ,
                                          Guid A11OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int1 = new short[2];
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId)";
      if ( ! (Guid.Empty==AV9SupplierGenId) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenId = :AV9SupplierGenId)");
      }
      else
      {
         GXv_int1[0] = 1;
      }
      if ( ! (Guid.Empty==AV8OrganisationId) )
      {
         AddWhere(sWhereString, "(T3.OrganisationId = :AV8OrganisationId)");
      }
      else
      {
         GXv_int1[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.SupplierGenId";
      scmdbuf += " FOR UPDATE OF T1, T1, T1";
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
                  return conditional_P00C12(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00C13;
       prmP00C13 = new Object[] {
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00C14;
       prmP00C14 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C12;
       prmP00C12 = new Object[] {
       new ParDef("AV9SupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00C12", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C13", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C14", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C14)
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
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((bool[]) buf[4])[0] = rslt.wasNull(3);
             ((Guid[]) buf[5])[0] = rslt.getGuid(4);
             ((bool[]) buf[6])[0] = rslt.wasNull(4);
             ((Guid[]) buf[7])[0] = rslt.getGuid(5);
             ((Guid[]) buf[8])[0] = rslt.getGuid(6);
             ((Guid[]) buf[9])[0] = rslt.getGuid(7);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
