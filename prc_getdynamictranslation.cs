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
                           string aP2_DefaultValue ,
                           out string aP3_TranslatedValue )
      {
         this.AV10DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV13Language = aP1_Language;
         this.AV9DefaultValue = aP2_DefaultValue;
         this.AV14TranslatedValue = "" ;
         initialize();
         ExecuteImpl();
         aP3_TranslatedValue=this.AV14TranslatedValue;
      }

      public string executeUdp( Guid aP0_DynamicTranslationPrimaryKey ,
                                string aP1_Language ,
                                string aP2_DefaultValue )
      {
         execute(aP0_DynamicTranslationPrimaryKey, aP1_Language, aP2_DefaultValue, out aP3_TranslatedValue);
         return AV14TranslatedValue ;
      }

      public void executeSubmit( Guid aP0_DynamicTranslationPrimaryKey ,
                                 string aP1_Language ,
                                 string aP2_DefaultValue ,
                                 out string aP3_TranslatedValue )
      {
         this.AV10DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV13Language = aP1_Language;
         this.AV9DefaultValue = aP2_DefaultValue;
         this.AV14TranslatedValue = "" ;
         SubmitImpl();
         aP3_TranslatedValue=this.AV14TranslatedValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14TranslatedValue = AV9DefaultValue;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Language)) )
         {
            AV13Language = context.GetLanguage( );
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Language)) )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV13Language, "Dutch") == 0 )
         {
            AV13Language = "nl";
         }
         else if ( StringUtil.StrCmp(AV13Language, "English") == 0 )
         {
            AV13Language = "en";
         }
         else
         {
         }
         /* Using cursor P00ED2 */
         pr_default.execute(0, new Object[] {AV10DynamicTranslationPrimaryKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A580DynamicTranslationPrimaryKey = P00ED2_A580DynamicTranslationPrimaryKey[0];
            A583DynamicTranslationDutch = P00ED2_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00ED2_A582DynamicTranslationEnglish[0];
            A578DynamicTranslationId = P00ED2_A578DynamicTranslationId[0];
            AV13Language = StringUtil.Trim( AV13Language);
            if ( StringUtil.StrCmp(AV13Language, context.GetMessage( "nl", "")) == 0 )
            {
               AV14TranslatedValue = A583DynamicTranslationDutch;
            }
            if ( StringUtil.StrCmp(AV13Language, context.GetMessage( "en", "")) == 0 )
            {
               AV14TranslatedValue = A582DynamicTranslationEnglish;
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
         AV14TranslatedValue = "";
         P00ED2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00ED2_A583DynamicTranslationDutch = new string[] {""} ;
         P00ED2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00ED2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A583DynamicTranslationDutch = "";
         A582DynamicTranslationEnglish = "";
         A578DynamicTranslationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdynamictranslation__default(),
            new Object[][] {
                new Object[] {
               P00ED2_A580DynamicTranslationPrimaryKey, P00ED2_A583DynamicTranslationDutch, P00ED2_A582DynamicTranslationEnglish, P00ED2_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV9DefaultValue ;
      private string AV14TranslatedValue ;
      private string A583DynamicTranslationDutch ;
      private string A582DynamicTranslationEnglish ;
      private string AV13Language ;
      private Guid AV10DynamicTranslationPrimaryKey ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00ED2_A580DynamicTranslationPrimaryKey ;
      private string[] P00ED2_A583DynamicTranslationDutch ;
      private string[] P00ED2_A582DynamicTranslationEnglish ;
      private Guid[] P00ED2_A578DynamicTranslationId ;
      private string aP3_TranslatedValue ;
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
              new CursorDef("P00ED2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV10DynamicTranslationPrimaryKey ORDER BY DynamicTranslationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ED2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
