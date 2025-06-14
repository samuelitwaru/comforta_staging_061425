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
   public class prc_adddynamicformtransalation : GXProcedure
   {
      public prc_adddynamicformtransalation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_adddynamicformtransalation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDT_DynamicFormTranslation> aP0_SDT_DynamicFormTranslationCollection )
      {
         this.AV21SDT_DynamicFormTranslationCollection = aP0_SDT_DynamicFormTranslationCollection;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_DynamicFormTranslation> aP0_SDT_DynamicFormTranslationCollection )
      {
         this.AV21SDT_DynamicFormTranslationCollection = aP0_SDT_DynamicFormTranslationCollection;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  AV21SDT_DynamicFormTranslationCollection.ToJSonString(false)) ;
         AV9Language = context.GetLanguage( );
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV12LanguageCode = "en";
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV12LanguageCode = "nl";
         }
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV21SDT_DynamicFormTranslationCollection.Count )
         {
            AV22SDT_DynamicFormTranslation = ((SdtSDT_DynamicFormTranslation)AV21SDT_DynamicFormTranslationCollection.Item(AV23GXV1));
            new prc_logtofile(context ).execute(  AV22SDT_DynamicFormTranslation.ToJSonString(false, true)) ;
            if ( StringUtil.StrCmp(AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname, "WWP_Form") == 0 )
            {
               AV24GXLvl17 = 0;
               /* Using cursor P00E52 */
               pr_default.execute(0, new Object[] {AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid, AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber, AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A589DynamicFormTranslationTrnName = P00E52_A589DynamicFormTranslationTrnName[0];
                  A587DynamicFormTranslationWWPFormV = P00E52_A587DynamicFormTranslationWWPFormV[0];
                  A586DynamicFormTranslationWWpFormI = P00E52_A586DynamicFormTranslationWWpFormI[0];
                  A591DynamicFormTranslationEnglish = P00E52_A591DynamicFormTranslationEnglish[0];
                  A592DynamicFormTranslationDutch = P00E52_A592DynamicFormTranslationDutch[0];
                  A585DynamicFormTranslationId = P00E52_A585DynamicFormTranslationId[0];
                  AV24GXLvl17 = 1;
                  /* Execute user subroutine: 'TRANSLATE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A591DynamicFormTranslationEnglish = AV19DynamicTranslationEnglish;
                  A592DynamicFormTranslationDutch = AV20DynamicTranslationDutch;
                  /* Using cursor P00E53 */
                  pr_default.execute(1, new Object[] {A591DynamicFormTranslationEnglish, A592DynamicFormTranslationDutch, A585DynamicFormTranslationId});
                  pr_default.close(1);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicFormTranslation");
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( AV24GXLvl17 == 0 )
               {
                  /* Execute user subroutine: 'TRANSLATE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  /*
                     INSERT RECORD ON TABLE Trn_DynamicFormTranslation

                  */
                  A586DynamicFormTranslationWWpFormI = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid;
                  A587DynamicFormTranslationWWPFormV = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber;
                  A589DynamicFormTranslationTrnName = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname;
                  A590DynamicFormTranslationAttribut = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationattributename;
                  A591DynamicFormTranslationEnglish = AV19DynamicTranslationEnglish;
                  A592DynamicFormTranslationDutch = AV20DynamicTranslationDutch;
                  A585DynamicFormTranslationId = Guid.NewGuid( );
                  /* Using cursor P00E54 */
                  pr_default.execute(2, new Object[] {A585DynamicFormTranslationId, A586DynamicFormTranslationWWpFormI, A587DynamicFormTranslationWWPFormV, A589DynamicFormTranslationTrnName, A590DynamicFormTranslationAttribut, A591DynamicFormTranslationEnglish, A592DynamicFormTranslationDutch});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicFormTranslation");
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
            }
            if ( StringUtil.StrCmp(AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname, "WWP_Form.Element") == 0 )
            {
               AV25GXLvl43 = 0;
               /* Using cursor P00E55 */
               pr_default.execute(3, new Object[] {AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid, AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber, AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname, AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A588DynamicFormTranslationWWPFormE = P00E55_A588DynamicFormTranslationWWPFormE[0];
                  A589DynamicFormTranslationTrnName = P00E55_A589DynamicFormTranslationTrnName[0];
                  A587DynamicFormTranslationWWPFormV = P00E55_A587DynamicFormTranslationWWPFormV[0];
                  A586DynamicFormTranslationWWpFormI = P00E55_A586DynamicFormTranslationWWpFormI[0];
                  A591DynamicFormTranslationEnglish = P00E55_A591DynamicFormTranslationEnglish[0];
                  A592DynamicFormTranslationDutch = P00E55_A592DynamicFormTranslationDutch[0];
                  A585DynamicFormTranslationId = P00E55_A585DynamicFormTranslationId[0];
                  AV25GXLvl43 = 1;
                  /* Execute user subroutine: 'TRANSLATE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(3);
                     cleanup();
                     if (true) return;
                  }
                  A591DynamicFormTranslationEnglish = AV19DynamicTranslationEnglish;
                  A592DynamicFormTranslationDutch = AV20DynamicTranslationDutch;
                  /* Using cursor P00E56 */
                  pr_default.execute(4, new Object[] {A591DynamicFormTranslationEnglish, A592DynamicFormTranslationDutch, A585DynamicFormTranslationId});
                  pr_default.close(4);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicFormTranslation");
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               if ( AV25GXLvl43 == 0 )
               {
                  /* Execute user subroutine: 'TRANSLATE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  /*
                     INSERT RECORD ON TABLE Trn_DynamicFormTranslation

                  */
                  A586DynamicFormTranslationWWpFormI = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid;
                  A587DynamicFormTranslationWWPFormV = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber;
                  A589DynamicFormTranslationTrnName = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname;
                  A588DynamicFormTranslationWWPFormE = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid;
                  A590DynamicFormTranslationAttribut = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationattributename;
                  A591DynamicFormTranslationEnglish = AV19DynamicTranslationEnglish;
                  A592DynamicFormTranslationDutch = AV20DynamicTranslationDutch;
                  A585DynamicFormTranslationId = Guid.NewGuid( );
                  /* Using cursor P00E57 */
                  pr_default.execute(5, new Object[] {A585DynamicFormTranslationId, A586DynamicFormTranslationWWpFormI, A587DynamicFormTranslationWWPFormV, A588DynamicFormTranslationWWPFormE, A589DynamicFormTranslationTrnName, A590DynamicFormTranslationAttribut, A591DynamicFormTranslationEnglish, A592DynamicFormTranslationDutch});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicFormTranslation");
                  if ( (pr_default.getStatus(5) == 1) )
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
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         context.CommitDataStores("prc_adddynamicformtransalation",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'TRANSLATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV19DynamicTranslationEnglish = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            GXt_char1 = AV20DynamicTranslationDutch;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue, out  GXt_char1) ;
            AV20DynamicTranslationDutch = GXt_char1;
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV20DynamicTranslationDutch = AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            GXt_char1 = AV19DynamicTranslationEnglish;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV22SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue, out  GXt_char1) ;
            AV19DynamicTranslationEnglish = GXt_char1;
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_adddynamicformtransalation",pr_default);
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
         AV22SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         P00E52_A589DynamicFormTranslationTrnName = new string[] {""} ;
         P00E52_A587DynamicFormTranslationWWPFormV = new int[1] ;
         P00E52_A586DynamicFormTranslationWWpFormI = new int[1] ;
         P00E52_A591DynamicFormTranslationEnglish = new string[] {""} ;
         P00E52_A592DynamicFormTranslationDutch = new string[] {""} ;
         P00E52_A585DynamicFormTranslationId = new Guid[] {Guid.Empty} ;
         A589DynamicFormTranslationTrnName = "";
         A591DynamicFormTranslationEnglish = "";
         A592DynamicFormTranslationDutch = "";
         A585DynamicFormTranslationId = Guid.Empty;
         AV19DynamicTranslationEnglish = "";
         AV20DynamicTranslationDutch = "";
         A590DynamicFormTranslationAttribut = "";
         Gx_emsg = "";
         P00E55_A588DynamicFormTranslationWWPFormE = new int[1] ;
         P00E55_A589DynamicFormTranslationTrnName = new string[] {""} ;
         P00E55_A587DynamicFormTranslationWWPFormV = new int[1] ;
         P00E55_A586DynamicFormTranslationWWpFormI = new int[1] ;
         P00E55_A591DynamicFormTranslationEnglish = new string[] {""} ;
         P00E55_A592DynamicFormTranslationDutch = new string[] {""} ;
         P00E55_A585DynamicFormTranslationId = new Guid[] {Guid.Empty} ;
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_adddynamicformtransalation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_adddynamicformtransalation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_adddynamicformtransalation__default(),
            new Object[][] {
                new Object[] {
               P00E52_A589DynamicFormTranslationTrnName, P00E52_A587DynamicFormTranslationWWPFormV, P00E52_A586DynamicFormTranslationWWpFormI, P00E52_A591DynamicFormTranslationEnglish, P00E52_A592DynamicFormTranslationDutch, P00E52_A585DynamicFormTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00E55_A588DynamicFormTranslationWWPFormE, P00E55_A589DynamicFormTranslationTrnName, P00E55_A587DynamicFormTranslationWWPFormV, P00E55_A586DynamicFormTranslationWWpFormI, P00E55_A591DynamicFormTranslationEnglish, P00E55_A592DynamicFormTranslationDutch, P00E55_A585DynamicFormTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl17 ;
      private short AV25GXLvl43 ;
      private int AV23GXV1 ;
      private int A587DynamicFormTranslationWWPFormV ;
      private int A586DynamicFormTranslationWWpFormI ;
      private int GX_INS102 ;
      private int A588DynamicFormTranslationWWPFormE ;
      private string AV12LanguageCode ;
      private string Gx_emsg ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string A591DynamicFormTranslationEnglish ;
      private string A592DynamicFormTranslationDutch ;
      private string AV19DynamicTranslationEnglish ;
      private string AV20DynamicTranslationDutch ;
      private string AV9Language ;
      private string A589DynamicFormTranslationTrnName ;
      private string A590DynamicFormTranslationAttribut ;
      private Guid A585DynamicFormTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_DynamicFormTranslation> AV21SDT_DynamicFormTranslationCollection ;
      private SdtSDT_DynamicFormTranslation AV22SDT_DynamicFormTranslation ;
      private IDataStoreProvider pr_default ;
      private string[] P00E52_A589DynamicFormTranslationTrnName ;
      private int[] P00E52_A587DynamicFormTranslationWWPFormV ;
      private int[] P00E52_A586DynamicFormTranslationWWpFormI ;
      private string[] P00E52_A591DynamicFormTranslationEnglish ;
      private string[] P00E52_A592DynamicFormTranslationDutch ;
      private Guid[] P00E52_A585DynamicFormTranslationId ;
      private int[] P00E55_A588DynamicFormTranslationWWPFormE ;
      private string[] P00E55_A589DynamicFormTranslationTrnName ;
      private int[] P00E55_A587DynamicFormTranslationWWPFormV ;
      private int[] P00E55_A586DynamicFormTranslationWWpFormI ;
      private string[] P00E55_A591DynamicFormTranslationEnglish ;
      private string[] P00E55_A592DynamicFormTranslationDutch ;
      private Guid[] P00E55_A585DynamicFormTranslationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_adddynamicformtransalation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_adddynamicformtransalation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_adddynamicformtransalation__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00E52;
       prmP00E52 = new Object[] {
       new ParDef("AV22SDT__1Dynamicformtranslat",GXType.Int32,6,0) ,
       new ParDef("AV22SDT__2Dynamicformtranslat",GXType.Int32,6,0) ,
       new ParDef("AV22SDT__3Dynamicformtranslat",GXType.VarChar,400,0)
       };
       Object[] prmP00E53;
       prmP00E53 = new Object[] {
       new ParDef("DynamicFormTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00E54;
       prmP00E54 = new Object[] {
       new ParDef("DynamicFormTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicFormTranslationWWpFormI",GXType.Int32,6,0) ,
       new ParDef("DynamicFormTranslationWWPFormV",GXType.Int32,6,0) ,
       new ParDef("DynamicFormTranslationTrnName",GXType.VarChar,400,0) ,
       new ParDef("DynamicFormTranslationAttribut",GXType.VarChar,40,0) ,
       new ParDef("DynamicFormTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       Object[] prmP00E55;
       prmP00E55 = new Object[] {
       new ParDef("AV22SDT__1Dynamicformtranslat",GXType.Int32,6,0) ,
       new ParDef("AV22SDT__2Dynamicformtranslat",GXType.Int32,6,0) ,
       new ParDef("AV22SDT__3Dynamicformtranslat",GXType.VarChar,400,0) ,
       new ParDef("AV22SDT__4Dynamicformtranslat",GXType.Int32,6,0)
       };
       Object[] prmP00E56;
       prmP00E56 = new Object[] {
       new ParDef("DynamicFormTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00E57;
       prmP00E57 = new Object[] {
       new ParDef("DynamicFormTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicFormTranslationWWpFormI",GXType.Int32,6,0) ,
       new ParDef("DynamicFormTranslationWWPFormV",GXType.Int32,6,0) ,
       new ParDef("DynamicFormTranslationWWPFormE",GXType.Int32,6,0) ,
       new ParDef("DynamicFormTranslationTrnName",GXType.VarChar,400,0) ,
       new ParDef("DynamicFormTranslationAttribut",GXType.VarChar,40,0) ,
       new ParDef("DynamicFormTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicFormTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00E52", "SELECT DynamicFormTranslationTrnName, DynamicFormTranslationWWPFormV, DynamicFormTranslationWWpFormI, DynamicFormTranslationEnglish, DynamicFormTranslationDutch, DynamicFormTranslationId FROM Trn_DynamicFormTranslation WHERE (DynamicFormTranslationWWpFormI = :AV22SDT__1Dynamicformtranslat) AND (DynamicFormTranslationWWPFormV = :AV22SDT__2Dynamicformtranslat) AND (DynamicFormTranslationTrnName = ( :AV22SDT__3Dynamicformtranslat)) ORDER BY DynamicFormTranslationId  FOR UPDATE OF Trn_DynamicFormTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E52,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00E53", "SAVEPOINT gxupdate;UPDATE Trn_DynamicFormTranslation SET DynamicFormTranslationEnglish=:DynamicFormTranslationEnglish, DynamicFormTranslationDutch=:DynamicFormTranslationDutch  WHERE DynamicFormTranslationId = :DynamicFormTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00E53)
          ,new CursorDef("P00E54", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicFormTranslation(DynamicFormTranslationId, DynamicFormTranslationWWpFormI, DynamicFormTranslationWWPFormV, DynamicFormTranslationTrnName, DynamicFormTranslationAttribut, DynamicFormTranslationEnglish, DynamicFormTranslationDutch, DynamicFormTranslationWWPFormE) VALUES(:DynamicFormTranslationId, :DynamicFormTranslationWWpFormI, :DynamicFormTranslationWWPFormV, :DynamicFormTranslationTrnName, :DynamicFormTranslationAttribut, :DynamicFormTranslationEnglish, :DynamicFormTranslationDutch, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00E54)
          ,new CursorDef("P00E55", "SELECT DynamicFormTranslationWWPFormE, DynamicFormTranslationTrnName, DynamicFormTranslationWWPFormV, DynamicFormTranslationWWpFormI, DynamicFormTranslationEnglish, DynamicFormTranslationDutch, DynamicFormTranslationId FROM Trn_DynamicFormTranslation WHERE (DynamicFormTranslationWWpFormI = :AV22SDT__1Dynamicformtranslat) AND (DynamicFormTranslationWWPFormV = :AV22SDT__2Dynamicformtranslat) AND (DynamicFormTranslationTrnName = ( :AV22SDT__3Dynamicformtranslat)) AND (DynamicFormTranslationWWPFormE = :AV22SDT__4Dynamicformtranslat) ORDER BY DynamicFormTranslationId  FOR UPDATE OF Trn_DynamicFormTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E55,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00E56", "SAVEPOINT gxupdate;UPDATE Trn_DynamicFormTranslation SET DynamicFormTranslationEnglish=:DynamicFormTranslationEnglish, DynamicFormTranslationDutch=:DynamicFormTranslationDutch  WHERE DynamicFormTranslationId = :DynamicFormTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00E56)
          ,new CursorDef("P00E57", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicFormTranslation(DynamicFormTranslationId, DynamicFormTranslationWWpFormI, DynamicFormTranslationWWPFormV, DynamicFormTranslationWWPFormE, DynamicFormTranslationTrnName, DynamicFormTranslationAttribut, DynamicFormTranslationEnglish, DynamicFormTranslationDutch) VALUES(:DynamicFormTranslationId, :DynamicFormTranslationWWpFormI, :DynamicFormTranslationWWPFormV, :DynamicFormTranslationWWPFormE, :DynamicFormTranslationTrnName, :DynamicFormTranslationAttribut, :DynamicFormTranslationEnglish, :DynamicFormTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00E57)
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
             ((int[]) buf[1])[0] = rslt.getInt(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 3 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             return;
    }
 }

}

}
