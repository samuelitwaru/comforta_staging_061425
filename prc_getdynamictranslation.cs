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
   public class prc_getdynamictranslation : GXProcedure
   {
      public prc_getdynamictranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdynamictranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_DynamicTranslationPrimaryKey ,
                           string aP1_Language ,
                           string aP2_VersionLanguage ,
                           ref SdtSDT_TranslatedPageBO aP3_TranslatedValue )
      {
         this.AV10DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV13Language = aP1_Language;
         this.AV15VersionLanguage = aP2_VersionLanguage;
         this.AV14TranslatedValue = aP3_TranslatedValue;
         initialize();
         ExecuteImpl();
         aP3_TranslatedValue=this.AV14TranslatedValue;
      }

      public SdtSDT_TranslatedPageBO executeUdp( Guid aP0_DynamicTranslationPrimaryKey ,
                                                 string aP1_Language ,
                                                 string aP2_VersionLanguage )
      {
         execute(aP0_DynamicTranslationPrimaryKey, aP1_Language, aP2_VersionLanguage, ref aP3_TranslatedValue);
         return AV14TranslatedValue ;
      }

      public void executeSubmit( Guid aP0_DynamicTranslationPrimaryKey ,
                                 string aP1_Language ,
                                 string aP2_VersionLanguage ,
                                 ref SdtSDT_TranslatedPageBO aP3_TranslatedValue )
      {
         this.AV10DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV13Language = aP1_Language;
         this.AV15VersionLanguage = aP2_VersionLanguage;
         this.AV14TranslatedValue = aP3_TranslatedValue;
         SubmitImpl();
         aP3_TranslatedValue=this.AV14TranslatedValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00ED2 */
         pr_default.execute(0, new Object[] {AV10DynamicTranslationPrimaryKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A580DynamicTranslationPrimaryKey = P00ED2_A580DynamicTranslationPrimaryKey[0];
            A581DynamicTranslationAttributeNam = P00ED2_A581DynamicTranslationAttributeNam[0];
            A672DynamicTranslationDutchPublish = P00ED2_A672DynamicTranslationDutchPublish[0];
            A671DynamicTranslationEnglishPubli = P00ED2_A671DynamicTranslationEnglishPubli[0];
            A578DynamicTranslationId = P00ED2_A578DynamicTranslationId[0];
            if ( StringUtil.StrCmp(AV13Language, AV15VersionLanguage) != 0 )
            {
               if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageName") == 0 )
               {
                  if ( StringUtil.StrCmp(AV13Language, "nl") == 0 )
                  {
                     AV14TranslatedValue.gxTpr_Pagename = A672DynamicTranslationDutchPublish;
                  }
                  else if ( StringUtil.StrCmp(AV13Language, "en") == 0 )
                  {
                     AV14TranslatedValue.gxTpr_Pagename = A671DynamicTranslationEnglishPubli;
                  }
               }
               if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageStructure") == 0 )
               {
                  if ( StringUtil.StrCmp(AV13Language, "nl") == 0 )
                  {
                     AV14TranslatedValue.gxTpr_Pagestructure = A672DynamicTranslationDutchPublish;
                  }
                  else if ( StringUtil.StrCmp(AV13Language, "en") == 0 )
                  {
                     AV14TranslatedValue.gxTpr_Pagestructure = A671DynamicTranslationEnglishPubli;
                  }
               }
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
         P00ED2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00ED2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00ED2_A672DynamicTranslationDutchPublish = new string[] {""} ;
         P00ED2_A671DynamicTranslationEnglishPubli = new string[] {""} ;
         P00ED2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A581DynamicTranslationAttributeNam = "";
         A672DynamicTranslationDutchPublish = "";
         A671DynamicTranslationEnglishPubli = "";
         A578DynamicTranslationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdynamictranslation__default(),
            new Object[][] {
                new Object[] {
               P00ED2_A580DynamicTranslationPrimaryKey, P00ED2_A581DynamicTranslationAttributeNam, P00ED2_A672DynamicTranslationDutchPublish, P00ED2_A671DynamicTranslationEnglishPubli, P00ED2_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A672DynamicTranslationDutchPublish ;
      private string A671DynamicTranslationEnglishPubli ;
      private string AV13Language ;
      private string AV15VersionLanguage ;
      private string A581DynamicTranslationAttributeNam ;
      private Guid AV10DynamicTranslationPrimaryKey ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_TranslatedPageBO AV14TranslatedValue ;
      private SdtSDT_TranslatedPageBO aP3_TranslatedValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00ED2_A580DynamicTranslationPrimaryKey ;
      private string[] P00ED2_A581DynamicTranslationAttributeNam ;
      private string[] P00ED2_A672DynamicTranslationDutchPublish ;
      private string[] P00ED2_A671DynamicTranslationEnglishPubli ;
      private Guid[] P00ED2_A578DynamicTranslationId ;
   }

   public class prc_getdynamictranslation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ED2;
          prmP00ED2 = new Object[] {
          new ParDef("AV10DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ED2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationDutchPublish, DynamicTranslationEnglishPubli, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV10DynamicTranslationPrimaryKey ORDER BY DynamicTranslationPrimaryKey ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED2,100, GxCacheFrequency.OFF ,false,false )
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
