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
   public class prc_addtodiscussiontransalation : GXProcedure
   {
      public prc_addtodiscussiontransalation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addtodiscussiontransalation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_DiscussionTranslation aP0_SDT_DiscussionTranslation )
      {
         this.AV16SDT_DiscussionTranslation = aP0_SDT_DiscussionTranslation;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( SdtSDT_DiscussionTranslation aP0_SDT_DiscussionTranslation )
      {
         this.AV16SDT_DiscussionTranslation = aP0_SDT_DiscussionTranslation;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Language = context.GetLanguage( );
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV12LanguageCode = "en";
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV12LanguageCode = "nl";
         }
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV14DynamicTranslationEnglish = AV16SDT_DiscussionTranslation.gxTpr_Discussiontranslationvalue;
            GXt_char1 = AV15DynamicTranslationDutch;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV16SDT_DiscussionTranslation.gxTpr_Discussiontranslationvalue, out  GXt_char1) ;
            AV15DynamicTranslationDutch = GXt_char1;
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV15DynamicTranslationDutch = AV16SDT_DiscussionTranslation.gxTpr_Discussiontranslationvalue;
            GXt_char1 = AV14DynamicTranslationEnglish;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV16SDT_DiscussionTranslation.gxTpr_Discussiontranslationvalue, out  GXt_char1) ;
            AV14DynamicTranslationEnglish = GXt_char1;
         }
         /*
            INSERT RECORD ON TABLE Trn_DiscussionTranslation

         */
         A594DiscussionTranslationWWPDiscus = AV16SDT_DiscussionTranslation.gxTpr_Discussiontranslationwwpdiscussionmessageid;
         A595DiscussionTranslationEnglish = AV14DynamicTranslationEnglish;
         A596DiscussionTranslationDutch = AV15DynamicTranslationDutch;
         A593Trn_DiscussionTranslationId = Guid.NewGuid( );
         /* Using cursor P00EB2 */
         pr_default.execute(0, new Object[] {A593Trn_DiscussionTranslationId, A594DiscussionTranslationWWPDiscus, A595DiscussionTranslationEnglish, A596DiscussionTranslationDutch});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_DiscussionTranslation");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         context.CommitDataStores("prc_addtodiscussiontransalation",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addtodiscussiontransalation",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Language = "";
         AV12LanguageCode = "";
         AV14DynamicTranslationEnglish = "";
         AV15DynamicTranslationDutch = "";
         GXt_char1 = "";
         A595DiscussionTranslationEnglish = "";
         A596DiscussionTranslationDutch = "";
         A593Trn_DiscussionTranslationId = Guid.Empty;
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_addtodiscussiontransalation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_addtodiscussiontransalation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addtodiscussiontransalation__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS103 ;
      private long A594DiscussionTranslationWWPDiscus ;
      private string AV12LanguageCode ;
      private string GXt_char1 ;
      private string Gx_emsg ;
      private string AV14DynamicTranslationEnglish ;
      private string AV15DynamicTranslationDutch ;
      private string AV9Language ;
      private string A595DiscussionTranslationEnglish ;
      private string A596DiscussionTranslationDutch ;
      private Guid A593Trn_DiscussionTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_DiscussionTranslation AV16SDT_DiscussionTranslation ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_addtodiscussiontransalation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_addtodiscussiontransalation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_addtodiscussiontransalation__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new UpdateCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00EB2;
       prmP00EB2 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DiscussionTranslationWWPDiscus",GXType.Int64,10,0) ,
       new ParDef("DiscussionTranslationEnglish",GXType.VarChar,1000,0) ,
       new ParDef("DiscussionTranslationDutch",GXType.VarChar,1000,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00EB2", "SAVEPOINT gxupdate;INSERT INTO Trn_DiscussionTranslation(Trn_DiscussionTranslationId, DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish, DiscussionTranslationDutch) VALUES(:Trn_DiscussionTranslationId, :DiscussionTranslationWWPDiscus, :DiscussionTranslationEnglish, :DiscussionTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00EB2)
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
