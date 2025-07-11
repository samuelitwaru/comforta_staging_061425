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
   public class prc_addappversionpagenametodynamictransalation : GXProcedure
   {
      public prc_addappversionpagenametodynamictransalation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addappversionpagenametodynamictransalation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDT_PageNameTranslation> aP0_SDT_PageNameTranslationCollection ,
                           string aP1_languageFrom ,
                           string aP2_LanguageTo )
      {
         this.AV9SDT_PageNameTranslationCollection = aP0_SDT_PageNameTranslationCollection;
         this.AV10languageFrom = aP1_languageFrom;
         this.AV11LanguageTo = aP2_LanguageTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_PageNameTranslation> aP0_SDT_PageNameTranslationCollection ,
                                 string aP1_languageFrom ,
                                 string aP2_LanguageTo )
      {
         this.AV9SDT_PageNameTranslationCollection = aP0_SDT_PageNameTranslationCollection;
         this.AV10languageFrom = aP1_languageFrom;
         this.AV11LanguageTo = aP2_LanguageTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV9SDT_PageNameTranslationCollection.Count )
         {
            AV12SDT_PageNameTranslation = ((SdtSDT_PageNameTranslation)AV9SDT_PageNameTranslationCollection.Item(AV19GXV1));
            AV20GXLvl3 = 0;
            /* Using cursor P00H32 */
            pr_default.execute(0, new Object[] {AV12SDT_PageNameTranslation.gxTpr_Pageid, AV12SDT_PageNameTranslation.gxTpr_Pageattributetype});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A581DynamicTranslationAttributeNam = P00H32_A581DynamicTranslationAttributeNam[0];
               A580DynamicTranslationPrimaryKey = P00H32_A580DynamicTranslationPrimaryKey[0];
               A582DynamicTranslationEnglish = P00H32_A582DynamicTranslationEnglish[0];
               A583DynamicTranslationDutch = P00H32_A583DynamicTranslationDutch[0];
               A578DynamicTranslationId = P00H32_A578DynamicTranslationId[0];
               AV20GXLvl3 = 1;
               AV14OldEnglish = A582DynamicTranslationEnglish;
               AV15OldDutch = A583DynamicTranslationDutch;
               if ( StringUtil.StrCmp(AV10languageFrom, "en") == 0 )
               {
                  AV13OldName = AV14OldEnglish;
                  A582DynamicTranslationEnglish = AV12SDT_PageNameTranslation.gxTpr_Pagename;
               }
               else if ( StringUtil.StrCmp(AV10languageFrom, "nl") == 0 )
               {
                  AV13OldName = AV15OldDutch;
                  A583DynamicTranslationDutch = AV12SDT_PageNameTranslation.gxTpr_Pagename;
               }
               if ( StringUtil.StrCmp(AV11LanguageTo, "en") == 0 )
               {
                  AV16TranslateName = A582DynamicTranslationEnglish;
                  /* Execute user subroutine: 'TRANSLATEEXISTINGPAGEUPDATE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A582DynamicTranslationEnglish = AV16TranslateName;
               }
               else if ( StringUtil.StrCmp(AV11LanguageTo, "nl") == 0 )
               {
                  AV16TranslateName = A583DynamicTranslationDutch;
                  /* Execute user subroutine: 'TRANSLATEEXISTINGPAGEUPDATE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A583DynamicTranslationDutch = AV16TranslateName;
               }
               /* Using cursor P00H33 */
               pr_default.execute(1, new Object[] {A582DynamicTranslationEnglish, A583DynamicTranslationDutch, A578DynamicTranslationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV20GXLvl3 == 0 )
            {
               if ( StringUtil.StrCmp(AV10languageFrom, "en") == 0 )
               {
                  AV17DynamicTranslationEnglish = AV12SDT_PageNameTranslation.gxTpr_Pagename;
               }
               else if ( StringUtil.StrCmp(AV10languageFrom, "nl") == 0 )
               {
                  AV18DynamicTranslationDutch = AV12SDT_PageNameTranslation.gxTpr_Pagename;
               }
               /* Execute user subroutine: 'TRANSLATENEWNAME' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( StringUtil.StrCmp(AV11LanguageTo, "en") == 0 )
               {
                  AV17DynamicTranslationEnglish = AV16TranslateName;
               }
               else if ( StringUtil.StrCmp(AV11LanguageTo, "nl") == 0 )
               {
                  AV18DynamicTranslationDutch = AV16TranslateName;
               }
               /*
                  INSERT RECORD ON TABLE Trn_DynamicTranslation

               */
               A580DynamicTranslationPrimaryKey = AV12SDT_PageNameTranslation.gxTpr_Pageid;
               A582DynamicTranslationEnglish = AV17DynamicTranslationEnglish;
               A583DynamicTranslationDutch = AV18DynamicTranslationDutch;
               A581DynamicTranslationAttributeNam = AV12SDT_PageNameTranslation.gxTpr_Pageattributetype;
               A578DynamicTranslationId = Guid.NewGuid( );
               /* Using cursor P00H34 */
               pr_default.execute(2, new Object[] {A578DynamicTranslationId, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               if ( (pr_default.getStatus(2) == 1) )
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
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         context.CommitDataStores("prc_addappversionpagenametodynamictransalation",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'TRANSLATENEWNAME' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12SDT_PageNameTranslation.gxTpr_Pagename, "Home") == 0 )
         {
            AV16TranslateName = AV12SDT_PageNameTranslation.gxTpr_Pagename;
         }
         else
         {
            GXt_char1 = AV16TranslateName;
            new prc_translatelanguage(context ).execute(  AV10languageFrom,  AV11LanguageTo,  AV12SDT_PageNameTranslation.gxTpr_Pagename, out  GXt_char1) ;
            AV16TranslateName = GXt_char1;
         }
      }

      protected void S121( )
      {
         /* 'TRANSLATEEXISTINGPAGEUPDATE' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(AV13OldName, AV12SDT_PageNameTranslation.gxTpr_Pagename) == 0 ) )
         {
            GXt_char1 = AV16TranslateName;
            new prc_translatelanguage(context ).execute(  AV10languageFrom,  AV11LanguageTo,  AV12SDT_PageNameTranslation.gxTpr_Pagename, out  GXt_char1) ;
            AV16TranslateName = GXt_char1;
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addappversionpagenametodynamictransalation",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12SDT_PageNameTranslation = new SdtSDT_PageNameTranslation(context);
         P00H32_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00H32_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00H32_A582DynamicTranslationEnglish = new string[] {""} ;
         P00H32_A583DynamicTranslationDutch = new string[] {""} ;
         P00H32_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A581DynamicTranslationAttributeNam = "";
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         A578DynamicTranslationId = Guid.Empty;
         AV14OldEnglish = "";
         AV15OldDutch = "";
         AV13OldName = "";
         AV16TranslateName = "";
         AV17DynamicTranslationEnglish = "";
         AV18DynamicTranslationDutch = "";
         Gx_emsg = "";
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagenametodynamictransalation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagenametodynamictransalation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addappversionpagenametodynamictransalation__default(),
            new Object[][] {
                new Object[] {
               P00H32_A581DynamicTranslationAttributeNam, P00H32_A580DynamicTranslationPrimaryKey, P00H32_A582DynamicTranslationEnglish, P00H32_A583DynamicTranslationDutch, P00H32_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20GXLvl3 ;
      private int AV19GXV1 ;
      private int GX_INS101 ;
      private string AV10languageFrom ;
      private string AV11LanguageTo ;
      private string Gx_emsg ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV17DynamicTranslationEnglish ;
      private string AV18DynamicTranslationDutch ;
      private string A581DynamicTranslationAttributeNam ;
      private string AV14OldEnglish ;
      private string AV15OldDutch ;
      private string AV13OldName ;
      private string AV16TranslateName ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageNameTranslation> AV9SDT_PageNameTranslationCollection ;
      private SdtSDT_PageNameTranslation AV12SDT_PageNameTranslation ;
      private IDataStoreProvider pr_default ;
      private string[] P00H32_A581DynamicTranslationAttributeNam ;
      private Guid[] P00H32_A580DynamicTranslationPrimaryKey ;
      private string[] P00H32_A582DynamicTranslationEnglish ;
      private string[] P00H32_A583DynamicTranslationDutch ;
      private Guid[] P00H32_A578DynamicTranslationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_addappversionpagenametodynamictransalation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_addappversionpagenametodynamictransalation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_addappversionpagenametodynamictransalation__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00H32;
       prmP00H32 = new Object[] {
       new ParDef("AV12SDT__1Pageid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12SDT__2Pageattributetype",GXType.VarChar,40,0)
       };
       Object[] prmP00H33;
       prmP00H33 = new Object[] {
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00H34;
       prmP00H34 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00H32", "SELECT DynamicTranslationAttributeNam, DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE (DynamicTranslationPrimaryKey = :AV12SDT__1Pageid) AND (DynamicTranslationAttributeNam = ( :AV12SDT__2Pageattributetype)) ORDER BY DynamicTranslationId  FOR UPDATE OF Trn_DynamicTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H32,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00H33", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00H33)
          ,new CursorDef("P00H34", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationTrnName) VALUES(:DynamicTranslationId, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00H34)
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
