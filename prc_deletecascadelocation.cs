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
   public class prc_deletecascadelocation : GXProcedure
   {
      public prc_deletecascadelocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadelocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_Trn_ThemeId ,
                           Guid aP2_OrganisationId ,
                           bool aP3_isMain ,
                           ref bool aP4_isSuccessful ,
                           ref string aP5_Message )
      {
         this.AV12LocationId = aP0_LocationId;
         this.AV15Trn_ThemeId = aP1_Trn_ThemeId;
         this.AV14OrganisationId = aP2_OrganisationId;
         this.AV10isMain = aP3_isMain;
         this.AV11isSuccessful = aP4_isSuccessful;
         this.AV13Message = aP5_Message;
         initialize();
         ExecuteImpl();
         aP4_isSuccessful=this.AV11isSuccessful;
         aP5_Message=this.AV13Message;
      }

      public string executeUdp( Guid aP0_LocationId ,
                                Guid aP1_Trn_ThemeId ,
                                Guid aP2_OrganisationId ,
                                bool aP3_isMain ,
                                ref bool aP4_isSuccessful )
      {
         execute(aP0_LocationId, aP1_Trn_ThemeId, aP2_OrganisationId, aP3_isMain, ref aP4_isSuccessful, ref aP5_Message);
         return AV13Message ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_Trn_ThemeId ,
                                 Guid aP2_OrganisationId ,
                                 bool aP3_isMain ,
                                 ref bool aP4_isSuccessful ,
                                 ref string aP5_Message )
      {
         this.AV12LocationId = aP0_LocationId;
         this.AV15Trn_ThemeId = aP1_Trn_ThemeId;
         this.AV14OrganisationId = aP2_OrganisationId;
         this.AV10isMain = aP3_isMain;
         this.AV11isSuccessful = aP4_isSuccessful;
         this.AV13Message = aP5_Message;
         SubmitImpl();
         aP4_isSuccessful=this.AV11isSuccessful;
         aP5_Message=this.AV13Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12LocationId ,
                                              AV14OrganisationId ,
                                              AV15Trn_ThemeId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A273Trn_ThemeId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BN2 */
         pr_default.execute(0, new Object[] {AV12LocationId, AV14OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTBN2 = 0;
            A584ActiveAppVersionId = P00BN2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00BN2_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = P00BN2_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00BN2_n598PublishedActiveAppVersionId[0];
            A11OrganisationId = P00BN2_A11OrganisationId[0];
            A29LocationId = P00BN2_A29LocationId[0];
            /* Using cursor P00BN3 */
            pr_default.execute(1, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = P00BN3_A273Trn_ThemeId[0];
            pr_default.close(1);
            /* Using cursor P00BN4 */
            pr_default.execute(2, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = P00BN4_A273Trn_ThemeId[0];
            pr_default.close(2);
            new prc_deletecascadeproductservice(context ).execute(  Guid.Empty,  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadelocationdynamicform(context ).execute(  Guid.Empty,  0,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadepage(context ).execute(  Guid.Empty,  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            GXt_guid1 = Guid.Empty;
            new prc_deletecascadememo(context ).execute(  Guid.Empty, ref  GXt_guid1,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadeagendacalendar(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadereceptionist(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            GXt_boolean2 = false;
            GXt_char3 = "";
            new prc_deletecascaderesident(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId,  false, ref  GXt_boolean2, ref  GXt_char3) ;
            if ( AV10isMain )
            {
               AV8Trn_Location.Load(A29LocationId, A11OrganisationId);
               AV8Trn_Location.Delete();
               if ( AV8Trn_Location.Success() )
               {
                  AV11isSuccessful = true;
                  GXTBN2 = 1;
                  CallWebObject(formatLink("trn_locationww.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV18GXV2 = 1;
                  AV17GXV1 = AV8Trn_Location.GetMessages();
                  while ( AV18GXV2 <= AV17GXV1.Count )
                  {
                     AV9ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV17GXV1.Item(AV18GXV2));
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Message)) )
                     {
                        AV13Message = AV9ErrorMessage.gxTpr_Description;
                     }
                     else
                     {
                        AV13Message += ", " + AV9ErrorMessage.gxTpr_Description;
                     }
                     AV18GXV2 = (int)(AV18GXV2+1);
                  }
                  AV11isSuccessful = false;
               }
            }
            else
            {
               /* Using cursor P00BN5 */
               pr_default.execute(3, new Object[] {A29LocationId, A11OrganisationId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
            }
            if ( GXTBN2 == 1 )
            {
               context.CommitDataStores("prc_deletecascadelocation",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(2);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadelocation",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         P00BN2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00BN2_n584ActiveAppVersionId = new bool[] {false} ;
         P00BN2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00BN2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00BN2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BN2_A29LocationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         P00BN3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00BN4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         GXt_guid1 = Guid.Empty;
         GXt_char3 = "";
         AV8Trn_Location = new SdtTrn_Location(context);
         AV17GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__default(),
            new Object[][] {
                new Object[] {
               P00BN2_A584ActiveAppVersionId, P00BN2_n584ActiveAppVersionId, P00BN2_A598PublishedActiveAppVersionId, P00BN2_n598PublishedActiveAppVersionId, P00BN2_A11OrganisationId, P00BN2_A29LocationId
               }
               , new Object[] {
               P00BN3_A273Trn_ThemeId
               }
               , new Object[] {
               P00BN4_A273Trn_ThemeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBN2 ;
      private int AV18GXV2 ;
      private string AV13Message ;
      private string GXt_char3 ;
      private bool AV10isMain ;
      private bool AV11isSuccessful ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool GXt_boolean2 ;
      private Guid AV12LocationId ;
      private Guid AV15Trn_ThemeId ;
      private Guid AV14OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A273Trn_ThemeId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP4_isSuccessful ;
      private string aP5_Message ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BN2_A584ActiveAppVersionId ;
      private bool[] P00BN2_n584ActiveAppVersionId ;
      private Guid[] P00BN2_A598PublishedActiveAppVersionId ;
      private bool[] P00BN2_n598PublishedActiveAppVersionId ;
      private Guid[] P00BN2_A11OrganisationId ;
      private Guid[] P00BN2_A29LocationId ;
      private Guid[] P00BN3_A273Trn_ThemeId ;
      private Guid[] P00BN4_A273Trn_ThemeId ;
      private SdtTrn_Location AV8Trn_Location ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadelocation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecascadelocation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecascadelocation__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00BN2( IGxContext context ,
                                          Guid AV12LocationId ,
                                          Guid AV14OrganisationId ,
                                          Guid AV15Trn_ThemeId ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          Guid A273Trn_ThemeId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int4 = new short[2];
      Object[] GXv_Object5 = new Object[2];
      scmdbuf = "SELECT ActiveAppVersionId, PublishedActiveAppVersionId, OrganisationId, LocationId FROM Trn_Location";
      if ( ! (Guid.Empty==AV12LocationId) )
      {
         AddWhere(sWhereString, "(LocationId = :AV12LocationId)");
      }
      else
      {
         GXv_int4[0] = 1;
      }
      if ( ! (Guid.Empty==AV14OrganisationId) )
      {
         AddWhere(sWhereString, "(OrganisationId = :AV14OrganisationId)");
      }
      else
      {
         GXv_int4[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY LocationId, OrganisationId";
      scmdbuf += " FOR UPDATE OF Trn_Location";
      GXv_Object5[0] = scmdbuf;
      GXv_Object5[1] = GXv_int4;
      return GXv_Object5 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P00BN2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new UpdateCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BN3;
       prmP00BN3 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00BN4;
       prmP00BN4 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmP00BN5;
       prmP00BN5 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BN2;
       prmP00BN2 = new Object[] {
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV14OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BN2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BN3", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BN4", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BN5", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BN5)
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
             ((Guid[]) buf[5])[0] = rslt.getGuid(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
