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
   public class prc_copyappversion : GXProcedure
   {
      public prc_copyappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_copyappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_AppVersionName ,
                           out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV22AppVersionName = aP1_AppVersionName;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_AppVersionName ,
                                      out SdtSDT_AppVersion aP2_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, aP1_AppVersionName, out aP2_SDT_AppVersion, out aP3_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_AppVersionName ,
                                 out SdtSDT_AppVersion aP2_SDT_AppVersion ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV23AppVersionId = aP0_AppVersionId;
         this.AV22AppVersionName = aP1_AppVersionName;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP3_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV24Trn_AppVersion.Load(AV23AppVersionId);
         AV10LocationId = AV24Trn_AppVersion.gxTpr_Locationid;
         AV13OrganisationId = AV24Trn_AppVersion.gxTpr_Organisationid;
         AV11BC_Trn_AppVersion.gxTpr_Appversionid = Guid.NewGuid( );
         AV11BC_Trn_AppVersion.gxTpr_Appversionname = AV22AppVersionName;
         AV11BC_Trn_AppVersion.gxTpr_Appversionlanguage = AV24Trn_AppVersion.gxTpr_Appversionlanguage;
         AV11BC_Trn_AppVersion.gxTpr_Locationid = AV10LocationId;
         AV11BC_Trn_AppVersion.gxTpr_Organisationid = AV13OrganisationId;
         AV11BC_Trn_AppVersion.gxTpr_Trn_themeid = AV24Trn_AppVersion.gxTpr_Trn_themeid;
         AV11BC_Trn_AppVersion.gxTpr_Isactive = false;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV24Trn_AppVersion.gxTpr_Page.Count )
         {
            AV25TrnAppVersionPage = ((SdtTrn_AppVersion_Page)AV24Trn_AppVersion.gxTpr_Page.Item(AV31GXV1));
            AV26oldId = AV25TrnAppVersionPage.gxTpr_Pageid;
            AV27NewId = Guid.NewGuid( );
            new prc_convertpageid(context ).execute(  AV26oldId,  AV27NewId, ref  AV24Trn_AppVersion) ;
            /* Using cursor P00CB2 */
            pr_default.execute(0, new Object[] {AV26oldId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A580DynamicTranslationPrimaryKey = P00CB2_A580DynamicTranslationPrimaryKey[0];
               A581DynamicTranslationAttributeNam = P00CB2_A581DynamicTranslationAttributeNam[0];
               A583DynamicTranslationDutch = P00CB2_A583DynamicTranslationDutch[0];
               A582DynamicTranslationEnglish = P00CB2_A582DynamicTranslationEnglish[0];
               A578DynamicTranslationId = P00CB2_A578DynamicTranslationId[0];
               AV28SDT_DynamicTranslation = new SdtSDT_DynamicTranslation(context);
               AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationprimarykey = AV27NewId;
               if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageStructure") == 0 )
               {
                  AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationattributename = "PageStructure";
               }
               else if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageName") == 0 )
               {
                  AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationattributename = "PageName";
               }
               AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationdutch = A583DynamicTranslationDutch;
               AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationenglish = A582DynamicTranslationEnglish;
               AV29SDT_DynamicTranslationCollection.Add(AV28SDT_DynamicTranslation, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV25TrnAppVersionPage.gxTpr_Pageid = AV27NewId;
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         AV33GXV2 = 1;
         while ( AV33GXV2 <= AV24Trn_AppVersion.gxTpr_Page.Count )
         {
            AV25TrnAppVersionPage = ((SdtTrn_AppVersion_Page)AV24Trn_AppVersion.gxTpr_Page.Item(AV33GXV2));
            AV11BC_Trn_AppVersion.gxTpr_Page.Add(AV25TrnAppVersionPage, 0);
            AV33GXV2 = (int)(AV33GXV2+1);
         }
         AV11BC_Trn_AppVersion.Save();
         if ( AV11BC_Trn_AppVersion.Success() )
         {
            AV34GXV3 = 1;
            while ( AV34GXV3 <= AV29SDT_DynamicTranslationCollection.Count )
            {
               AV28SDT_DynamicTranslation = ((SdtSDT_DynamicTranslation)AV29SDT_DynamicTranslationCollection.Item(AV34GXV3));
               AV30BC_Trn_DynamicTranslation = new SdtTrn_DynamicTranslation(context);
               AV30BC_Trn_DynamicTranslation.gxTpr_Dynamictranslationid = Guid.NewGuid( );
               AV30BC_Trn_DynamicTranslation.gxTpr_Dynamictranslationattributename = AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationattributename;
               AV30BC_Trn_DynamicTranslation.gxTpr_Dynamictranslationprimarykey = AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationprimarykey;
               AV30BC_Trn_DynamicTranslation.gxTpr_Dynamictranslationenglish = AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationenglish;
               AV30BC_Trn_DynamicTranslation.gxTpr_Dynamictranslationdutch = AV28SDT_DynamicTranslation.gxTpr_Sdt_dynamictranslationdutch;
               AV30BC_Trn_DynamicTranslation.Insert();
               AV34GXV3 = (int)(AV34GXV3+1);
            }
            context.CommitDataStores("prc_copyappversion",pr_default);
            GXt_SdtSDT_Error1 = new SdtSDT_Error();
            new prc_activateappversion(context ).execute(  AV11BC_Trn_AppVersion.gxTpr_Appversionid, out  AV8SDT_AppVersion, out  GXt_SdtSDT_Error1,  Guid.Empty) ;
         }
         else
         {
            AV36GXV5 = 1;
            AV35GXV4 = AV11BC_Trn_AppVersion.GetMessages();
            while ( AV36GXV5 <= AV35GXV4.Count )
            {
               AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV35GXV4.Item(AV36GXV5));
               new prc_logtofile(context ).execute(  context.GetMessage( "&Message.Description", "")+AV21Message.gxTpr_Description) ;
               AV36GXV5 = (int)(AV36GXV5+1);
            }
         }
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
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV24Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV10LocationId = Guid.Empty;
         AV13OrganisationId = Guid.Empty;
         AV11BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV25TrnAppVersionPage = new SdtTrn_AppVersion_Page(context);
         AV26oldId = Guid.Empty;
         AV27NewId = Guid.Empty;
         P00CB2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00CB2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00CB2_A583DynamicTranslationDutch = new string[] {""} ;
         P00CB2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00CB2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A581DynamicTranslationAttributeNam = "";
         A583DynamicTranslationDutch = "";
         A582DynamicTranslationEnglish = "";
         A578DynamicTranslationId = Guid.Empty;
         AV28SDT_DynamicTranslation = new SdtSDT_DynamicTranslation(context);
         AV29SDT_DynamicTranslationCollection = new GXBaseCollection<SdtSDT_DynamicTranslation>( context, "SDT_DynamicTranslation", "Comforta_version2");
         AV30BC_Trn_DynamicTranslation = new SdtTrn_DynamicTranslation(context);
         GXt_SdtSDT_Error1 = new SdtSDT_Error(context);
         AV35GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_copyappversion__default(),
            new Object[][] {
                new Object[] {
               P00CB2_A580DynamicTranslationPrimaryKey, P00CB2_A581DynamicTranslationAttributeNam, P00CB2_A583DynamicTranslationDutch, P00CB2_A582DynamicTranslationEnglish, P00CB2_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV31GXV1 ;
      private int AV33GXV2 ;
      private int AV34GXV3 ;
      private int AV36GXV5 ;
      private string A583DynamicTranslationDutch ;
      private string A582DynamicTranslationEnglish ;
      private string AV22AppVersionName ;
      private string A581DynamicTranslationAttributeNam ;
      private Guid AV23AppVersionId ;
      private Guid AV10LocationId ;
      private Guid AV13OrganisationId ;
      private Guid AV26oldId ;
      private Guid AV27NewId ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private SdtTrn_AppVersion AV24Trn_AppVersion ;
      private SdtTrn_AppVersion AV11BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV25TrnAppVersionPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CB2_A580DynamicTranslationPrimaryKey ;
      private string[] P00CB2_A581DynamicTranslationAttributeNam ;
      private string[] P00CB2_A583DynamicTranslationDutch ;
      private string[] P00CB2_A582DynamicTranslationEnglish ;
      private Guid[] P00CB2_A578DynamicTranslationId ;
      private SdtSDT_DynamicTranslation AV28SDT_DynamicTranslation ;
      private GXBaseCollection<SdtSDT_DynamicTranslation> AV29SDT_DynamicTranslationCollection ;
      private SdtTrn_DynamicTranslation AV30BC_Trn_DynamicTranslation ;
      private SdtSDT_Error GXt_SdtSDT_Error1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV35GXV4 ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private SdtSDT_AppVersion aP2_SDT_AppVersion ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_copyappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_copyappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_copyappversion__default : DataStoreHelperBase, IDataStoreHelper
{
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
       Object[] prmP00CB2;
       prmP00CB2 = new Object[] {
       new ParDef("AV26oldId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CB2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV26oldId ORDER BY DynamicTranslationPrimaryKey ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB2,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
