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
   public class prc_deletecascadeorganisation : GXProcedure
   {
      public prc_deletecascadeorganisation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadeorganisation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           ref bool aP1_isSuccessful ,
                           ref string aP2_Message )
      {
         this.AV13OrganisationId = aP0_OrganisationId;
         this.AV9isSuccessful = aP1_isSuccessful;
         this.AV12Message = aP2_Message;
         initialize();
         ExecuteImpl();
         aP1_isSuccessful=this.AV9isSuccessful;
         aP2_Message=this.AV12Message;
      }

      public string executeUdp( Guid aP0_OrganisationId ,
                                ref bool aP1_isSuccessful )
      {
         execute(aP0_OrganisationId, ref aP1_isSuccessful, ref aP2_Message);
         return AV12Message ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 ref bool aP1_isSuccessful ,
                                 ref string aP2_Message )
      {
         this.AV13OrganisationId = aP0_OrganisationId;
         this.AV9isSuccessful = aP1_isSuccessful;
         this.AV12Message = aP2_Message;
         SubmitImpl();
         aP1_isSuccessful=this.AV9isSuccessful;
         aP2_Message=this.AV12Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13OrganisationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00BM2 */
         pr_default.execute(0, new Object[] {AV13OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BM2_A11OrganisationId[0];
            AV12Message = "";
            GXt_boolean1 = false;
            GXt_char2 = "";
            new prc_deletecascadelocation(context ).execute(  Guid.Empty,  Guid.Empty,  A11OrganisationId,  false, ref  GXt_boolean1, ref  GXt_char2) ;
            new prc_deletecascadeorganisationdynamicform(context ).execute(  Guid.Empty,  0,  A11OrganisationId) ;
            new prc_deletecascadeaudit(context ).execute(  Guid.Empty,  A11OrganisationId) ;
            new prc_deletecascademanager(context ).execute(  Guid.Empty,  A11OrganisationId) ;
            new prc_deletecascadeorganisationsetting(context ).execute(  Guid.Empty,  A11OrganisationId) ;
            GXt_boolean3 = false;
            GXt_char4 = "";
            new prc_deletecascadesuppliergen(context ).execute(  Guid.Empty,  A11OrganisationId,  false, ref  GXt_boolean3, ref  GXt_char4) ;
            AV14Trn_Organisation.Load(A11OrganisationId);
            AV14Trn_Organisation.Delete();
            if ( AV14Trn_Organisation.Success() )
            {
               AV9isSuccessful = true;
               context.CommitDataStores("prc_deletecascadeorganisation",pr_default);
               CallWebObject(formatLink("trn_organisationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV18GXV2 = 1;
               AV17GXV1 = AV14Trn_Organisation.GetMessages();
               while ( AV18GXV2 <= AV17GXV1.Count )
               {
                  AV8ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV17GXV1.Item(AV18GXV2));
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Message)) )
                  {
                     AV12Message = AV8ErrorMessage.gxTpr_Description;
                  }
                  else
                  {
                     AV12Message += ", " + AV8ErrorMessage.gxTpr_Description;
                  }
                  AV18GXV2 = (int)(AV18GXV2+1);
               }
               AV9isSuccessful = false;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A11OrganisationId = Guid.Empty;
         P00BM2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         GXt_char2 = "";
         GXt_char4 = "";
         AV14Trn_Organisation = new SdtTrn_Organisation(context);
         AV17GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeorganisation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeorganisation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadeorganisation__default(),
            new Object[][] {
                new Object[] {
               P00BM2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV18GXV2 ;
      private string AV12Message ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private bool AV9isSuccessful ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean3 ;
      private Guid AV13OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP1_isSuccessful ;
      private string aP2_Message ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BM2_A11OrganisationId ;
      private SdtTrn_Organisation AV14Trn_Organisation ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV8ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadeorganisation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecascadeorganisation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecascadeorganisation__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00BM2( IGxContext context ,
                                          Guid AV13OrganisationId ,
                                          Guid A11OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int5 = new short[1];
      Object[] GXv_Object6 = new Object[2];
      scmdbuf = "SELECT OrganisationId FROM Trn_Organisation";
      if ( ! (Guid.Empty==AV13OrganisationId) )
      {
         AddWhere(sWhereString, "(OrganisationId = :AV13OrganisationId)");
      }
      else
      {
         GXv_int5[0] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY OrganisationId";
      GXv_Object6[0] = scmdbuf;
      GXv_Object6[1] = GXv_int5;
      return GXv_Object6 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P00BM2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BM2;
       prmP00BM2 = new Object[] {
       new ParDef("AV13OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM2,100, GxCacheFrequency.OFF ,true,false )
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
             return;
    }
 }

}

}
