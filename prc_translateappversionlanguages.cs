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
   public class prc_translateappversionlanguages : GXProcedure
   {
      public prc_translateappversionlanguages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_translateappversionlanguages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_activePageId ,
                           string aP2_languageFrom ,
                           GxSimpleCollection<string> aP3_LanguageToCollection ,
                           out string aP4_result ,
                           out SdtSDT_Error aP5_error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV18activePageId = aP1_activePageId;
         this.AV9languageFrom = aP2_languageFrom;
         this.AV19LanguageToCollection = aP3_LanguageToCollection;
         this.AV21result = "" ;
         this.AV11error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP4_result=this.AV21result;
         aP5_error=this.AV11error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_activePageId ,
                                      string aP2_languageFrom ,
                                      GxSimpleCollection<string> aP3_LanguageToCollection ,
                                      out string aP4_result )
      {
         execute(aP0_AppVersionId, aP1_activePageId, aP2_languageFrom, aP3_LanguageToCollection, out aP4_result, out aP5_error);
         return AV11error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_activePageId ,
                                 string aP2_languageFrom ,
                                 GxSimpleCollection<string> aP3_LanguageToCollection ,
                                 out string aP4_result ,
                                 out SdtSDT_Error aP5_error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV18activePageId = aP1_activePageId;
         this.AV9languageFrom = aP2_languageFrom;
         this.AV19LanguageToCollection = aP3_LanguageToCollection;
         this.AV21result = "" ;
         this.AV11error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP4_result=this.AV21result;
         aP5_error=this.AV11error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV12SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV12SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV19LanguageToCollection.Count )
         {
            AV10LanguageTo = ((string)AV19LanguageToCollection.Item(AV22GXV1));
            AV20SDT_InfoPageActivePage = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version2");
            AV13SDT_InfoPageTranslationCollection = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version2");
            /* Using cursor P00GX2 */
            pr_default.execute(0, new Object[] {AV8AppVersionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A525PageType = P00GX2_A525PageType[0];
               A523AppVersionId = P00GX2_A523AppVersionId[0];
               A516PageId = P00GX2_A516PageId[0];
               A518PageStructure = P00GX2_A518PageStructure[0];
               AV17BC_Trn_AppVersion.Load(A523AppVersionId);
               AV14SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
               AV14SDT_InfoPageTranslation.gxTpr_Pagetype = A525PageType;
               AV14SDT_InfoPageTranslation.gxTpr_Pageid = A516PageId;
               AV14SDT_InfoPageTranslation.gxTpr_Pageattributetype = "PageStructure";
               AV14SDT_InfoPageTranslation.gxTpr_Pagestructure = A518PageStructure;
               if ( A516PageId == AV18activePageId )
               {
                  AV20SDT_InfoPageActivePage.Add(AV14SDT_InfoPageTranslation, 0);
               }
               else
               {
                  AV13SDT_InfoPageTranslationCollection.Add(AV14SDT_InfoPageTranslation, 0);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new prc_addappversionpagetodynamictransalation3(context ).execute(  AV20SDT_InfoPageActivePage, ref  AV9languageFrom, ref  AV10LanguageTo) ;
            new prc_addappversionpagetodynamictransalation3(context).executeSubmit(  AV13SDT_InfoPageTranslationCollection, ref  AV9languageFrom, ref  AV10LanguageTo) ;
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         AV21result = context.GetMessage( "success", "");
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
         AV21result = "";
         AV11error = new SdtSDT_Error(context);
         AV12SDT_Error = new SdtSDT_Error(context);
         AV10LanguageTo = "";
         AV20SDT_InfoPageActivePage = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version2");
         AV13SDT_InfoPageTranslationCollection = new GXBaseCollection<SdtSDT_InfoPageTranslation>( context, "SDT_InfoPageTranslation", "Comforta_version2");
         P00GX2_A525PageType = new string[] {""} ;
         P00GX2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00GX2_A516PageId = new Guid[] {Guid.Empty} ;
         P00GX2_A518PageStructure = new string[] {""} ;
         A525PageType = "";
         A523AppVersionId = Guid.Empty;
         A516PageId = Guid.Empty;
         A518PageStructure = "";
         AV17BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV14SDT_InfoPageTranslation = new SdtSDT_InfoPageTranslation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_translateappversionlanguages__default(),
            new Object[][] {
                new Object[] {
               P00GX2_A525PageType, P00GX2_A523AppVersionId, P00GX2_A516PageId, P00GX2_A518PageStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private string AV9languageFrom ;
      private string AV10LanguageTo ;
      private string A518PageStructure ;
      private string AV21result ;
      private string A525PageType ;
      private Guid AV8AppVersionId ;
      private Guid AV18activePageId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19LanguageToCollection ;
      private SdtSDT_Error AV11error ;
      private SdtSDT_Error AV12SDT_Error ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> AV20SDT_InfoPageActivePage ;
      private GXBaseCollection<SdtSDT_InfoPageTranslation> AV13SDT_InfoPageTranslationCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00GX2_A525PageType ;
      private Guid[] P00GX2_A523AppVersionId ;
      private Guid[] P00GX2_A516PageId ;
      private string[] P00GX2_A518PageStructure ;
      private SdtTrn_AppVersion AV17BC_Trn_AppVersion ;
      private SdtSDT_InfoPageTranslation AV14SDT_InfoPageTranslation ;
      private string aP4_result ;
      private SdtSDT_Error aP5_error ;
   }

   public class prc_translateappversionlanguages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GX2;
          prmP00GX2 = new Object[] {
          new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GX2", "SELECT PageType, AppVersionId, PageId, PageStructure FROM Trn_AppVersionPage WHERE (AppVersionId = :AV8AppVersionId) AND (PageType = ( 'Information')) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GX2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
