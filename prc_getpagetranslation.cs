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
   public class prc_getpagetranslation : GXProcedure
   {
      public prc_getpagetranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getpagetranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_DynamicTranslationPrimaryKey ,
                           string aP1_Language ,
                           out SdtSDT_InfoContent aP2_SDT_InfoContent ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV12Language = aP1_Language;
         this.AV15SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         this.AV14SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_InfoContent=this.AV15SDT_InfoContent;
         aP3_SDT_Error=this.AV14SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_DynamicTranslationPrimaryKey ,
                                      string aP1_Language ,
                                      out SdtSDT_InfoContent aP2_SDT_InfoContent )
      {
         execute(aP0_DynamicTranslationPrimaryKey, aP1_Language, out aP2_SDT_InfoContent, out aP3_SDT_Error);
         return AV14SDT_Error ;
      }

      public void executeSubmit( Guid aP0_DynamicTranslationPrimaryKey ,
                                 string aP1_Language ,
                                 out SdtSDT_InfoContent aP2_SDT_InfoContent ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9DynamicTranslationPrimaryKey = aP0_DynamicTranslationPrimaryKey;
         this.AV12Language = aP1_Language;
         this.AV15SDT_InfoContent = new SdtSDT_InfoContent(context) ;
         this.AV14SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_InfoContent=this.AV15SDT_InfoContent;
         aP3_SDT_Error=this.AV14SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV14SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV14SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00GZ2 */
         pr_default.execute(0, new Object[] {AV9DynamicTranslationPrimaryKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A580DynamicTranslationPrimaryKey = P00GZ2_A580DynamicTranslationPrimaryKey[0];
            A583DynamicTranslationDutch = P00GZ2_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00GZ2_A582DynamicTranslationEnglish[0];
            A578DynamicTranslationId = P00GZ2_A578DynamicTranslationId[0];
            AV12Language = StringUtil.Trim( AV12Language);
            if ( StringUtil.StrCmp(AV12Language, "nl") == 0 )
            {
               AV13TranslatedValue = A583DynamicTranslationDutch;
            }
            else if ( StringUtil.StrCmp(AV12Language, "en") == 0 )
            {
               AV13TranslatedValue = A582DynamicTranslationEnglish;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV15SDT_InfoContent.FromJSonString(AV13TranslatedValue, null);
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
         AV15SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV14SDT_Error = new SdtSDT_Error(context);
         P00GZ2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00GZ2_A583DynamicTranslationDutch = new string[] {""} ;
         P00GZ2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00GZ2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A583DynamicTranslationDutch = "";
         A582DynamicTranslationEnglish = "";
         A578DynamicTranslationId = Guid.Empty;
         AV13TranslatedValue = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getpagetranslation__default(),
            new Object[][] {
                new Object[] {
               P00GZ2_A580DynamicTranslationPrimaryKey, P00GZ2_A583DynamicTranslationDutch, P00GZ2_A582DynamicTranslationEnglish, P00GZ2_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A583DynamicTranslationDutch ;
      private string A582DynamicTranslationEnglish ;
      private string AV13TranslatedValue ;
      private string AV12Language ;
      private Guid AV9DynamicTranslationPrimaryKey ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_InfoContent AV15SDT_InfoContent ;
      private SdtSDT_Error AV14SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GZ2_A580DynamicTranslationPrimaryKey ;
      private string[] P00GZ2_A583DynamicTranslationDutch ;
      private string[] P00GZ2_A582DynamicTranslationEnglish ;
      private Guid[] P00GZ2_A578DynamicTranslationId ;
      private SdtSDT_InfoContent aP2_SDT_InfoContent ;
      private SdtSDT_Error aP3_SDT_Error ;
   }

   public class prc_getpagetranslation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GZ2;
          prmP00GZ2 = new Object[] {
          new ParDef("AV9DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GZ2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV9DynamicTranslationPrimaryKey ORDER BY DynamicTranslationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GZ2,100, GxCacheFrequency.OFF ,false,false )
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
