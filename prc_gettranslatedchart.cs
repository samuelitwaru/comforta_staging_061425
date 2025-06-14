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
   public class prc_gettranslatedchart : GXProcedure
   {
      public prc_gettranslatedchart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_gettranslatedchart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPDiscussionMessageId ,
                           out string aP1_TranslatedMessage )
      {
         this.AV8WWPDiscussionMessageId = aP0_WWPDiscussionMessageId;
         this.AV9TranslatedMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_TranslatedMessage=this.AV9TranslatedMessage;
      }

      public string executeUdp( long aP0_WWPDiscussionMessageId )
      {
         execute(aP0_WWPDiscussionMessageId, out aP1_TranslatedMessage);
         return AV9TranslatedMessage ;
      }

      public void executeSubmit( long aP0_WWPDiscussionMessageId ,
                                 out string aP1_TranslatedMessage )
      {
         this.AV8WWPDiscussionMessageId = aP0_WWPDiscussionMessageId;
         this.AV9TranslatedMessage = "" ;
         SubmitImpl();
         aP1_TranslatedMessage=this.AV9TranslatedMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Language = context.GetLanguage( );
         /* Using cursor P00EC2 */
         pr_default.execute(0, new Object[] {AV8WWPDiscussionMessageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A594DiscussionTranslationWWPDiscus = P00EC2_A594DiscussionTranslationWWPDiscus[0];
            A595DiscussionTranslationEnglish = P00EC2_A595DiscussionTranslationEnglish[0];
            A596DiscussionTranslationDutch = P00EC2_A596DiscussionTranslationDutch[0];
            A593Trn_DiscussionTranslationId = P00EC2_A593Trn_DiscussionTranslationId[0];
            if ( StringUtil.StrCmp(AV10Language, "English") == 0 )
            {
               AV9TranslatedMessage = A595DiscussionTranslationEnglish;
            }
            else if ( StringUtil.StrCmp(AV10Language, "Dutch") == 0 )
            {
               AV9TranslatedMessage = A596DiscussionTranslationDutch;
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
         AV9TranslatedMessage = "";
         AV10Language = "";
         P00EC2_A594DiscussionTranslationWWPDiscus = new long[1] ;
         P00EC2_A595DiscussionTranslationEnglish = new string[] {""} ;
         P00EC2_A596DiscussionTranslationDutch = new string[] {""} ;
         P00EC2_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         A595DiscussionTranslationEnglish = "";
         A596DiscussionTranslationDutch = "";
         A593Trn_DiscussionTranslationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_gettranslatedchart__default(),
            new Object[][] {
                new Object[] {
               P00EC2_A594DiscussionTranslationWWPDiscus, P00EC2_A595DiscussionTranslationEnglish, P00EC2_A596DiscussionTranslationDutch, P00EC2_A593Trn_DiscussionTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPDiscussionMessageId ;
      private long A594DiscussionTranslationWWPDiscus ;
      private string AV9TranslatedMessage ;
      private string AV10Language ;
      private string A595DiscussionTranslationEnglish ;
      private string A596DiscussionTranslationDutch ;
      private Guid A593Trn_DiscussionTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00EC2_A594DiscussionTranslationWWPDiscus ;
      private string[] P00EC2_A595DiscussionTranslationEnglish ;
      private string[] P00EC2_A596DiscussionTranslationDutch ;
      private Guid[] P00EC2_A593Trn_DiscussionTranslationId ;
      private string aP1_TranslatedMessage ;
   }

   public class prc_gettranslatedchart__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EC2;
          prmP00EC2 = new Object[] {
          new ParDef("AV8WWPDiscussionMessageId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EC2", "SELECT DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish, DiscussionTranslationDutch, Trn_DiscussionTranslationId FROM Trn_DiscussionTranslation WHERE DiscussionTranslationWWPDiscus = :AV8WWPDiscussionMessageId ORDER BY DiscussionTranslationWWPDiscus ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EC2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
