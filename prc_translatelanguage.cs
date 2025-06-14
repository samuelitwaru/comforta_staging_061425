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
   public class prc_translatelanguage : GXProcedure
   {
      public prc_translatelanguage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_translatelanguage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_from ,
                           string aP1_to ,
                           string aP2_LanguageFrom ,
                           out string aP3_LanguageTo )
      {
         this.AV12from = aP0_from;
         this.AV13to = aP1_to;
         this.AV14LanguageFrom = aP2_LanguageFrom;
         this.AV15LanguageTo = "" ;
         initialize();
         ExecuteImpl();
         aP3_LanguageTo=this.AV15LanguageTo;
      }

      public string executeUdp( string aP0_from ,
                                string aP1_to ,
                                string aP2_LanguageFrom )
      {
         execute(aP0_from, aP1_to, aP2_LanguageFrom, out aP3_LanguageTo);
         return AV15LanguageTo ;
      }

      public void executeSubmit( string aP0_from ,
                                 string aP1_to ,
                                 string aP2_LanguageFrom ,
                                 out string aP3_LanguageTo )
      {
         this.AV12from = aP0_from;
         this.AV13to = aP1_to;
         this.AV14LanguageFrom = aP2_LanguageFrom;
         this.AV15LanguageTo = "" ;
         SubmitImpl();
         aP3_LanguageTo=this.AV15LanguageTo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A633EnvironmentVariableKey = P00DS2_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = P00DS2_A634EnvironmentVariableValue[0];
            A632EnvironmentVariableId = P00DS2_A632EnvironmentVariableId[0];
            if ( StringUtil.StrCmp(A633EnvironmentVariableKey, "AmazonAccessKey") == 0 )
            {
               AV22AmazonAccessKey = A634EnvironmentVariableValue;
            }
            else if ( StringUtil.StrCmp(A633EnvironmentVariableKey, "AmazonSecretKey") == 0 )
            {
               AV23AmazonSecretKey = A634EnvironmentVariableValue;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22AmazonAccessKey)) || String.IsNullOrEmpty(StringUtil.RTrim( AV23AmazonSecretKey)) )
         {
            AV15LanguageTo = AV14LanguageFrom;
            cleanup();
            if (true) return;
         }
         AV21Translator.gxTpr_Accesskey = AV22AmazonAccessKey;
         AV21Translator.gxTpr_Secretkey = AV23AmazonSecretKey;
         AV21Translator.gxTpr_Regionname = context.GetMessage( "eu-north-1", "");
         AV15LanguageTo = AV21Translator.translatetext(AV14LanguageFrom, AV12from, AV13to);
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
         AV15LanguageTo = "";
         P00DS2_A633EnvironmentVariableKey = new string[] {""} ;
         P00DS2_A634EnvironmentVariableValue = new string[] {""} ;
         P00DS2_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         A633EnvironmentVariableKey = "";
         A634EnvironmentVariableValue = "";
         A632EnvironmentVariableId = Guid.Empty;
         AV22AmazonAccessKey = "";
         AV23AmazonSecretKey = "";
         AV21Translator = new SdtTranslator(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_translatelanguage__default(),
            new Object[][] {
                new Object[] {
               P00DS2_A633EnvironmentVariableKey, P00DS2_A634EnvironmentVariableValue, P00DS2_A632EnvironmentVariableId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV12from ;
      private string AV13to ;
      private string AV14LanguageFrom ;
      private string AV15LanguageTo ;
      private string A634EnvironmentVariableValue ;
      private string AV23AmazonSecretKey ;
      private string A633EnvironmentVariableKey ;
      private string AV22AmazonAccessKey ;
      private Guid A632EnvironmentVariableId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DS2_A633EnvironmentVariableKey ;
      private string[] P00DS2_A634EnvironmentVariableValue ;
      private Guid[] P00DS2_A632EnvironmentVariableId ;
      private SdtTranslator AV21Translator ;
      private string aP3_LanguageTo ;
   }

   public class prc_translatelanguage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DS2;
          prmP00DS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00DS2", "SELECT EnvironmentVariableKey, EnvironmentVariableValue, EnvironmentVariableId FROM Trn_EnvironmentVariable ORDER BY EnvironmentVariableId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
