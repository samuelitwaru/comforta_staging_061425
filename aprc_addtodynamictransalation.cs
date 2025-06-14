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
   public class aprc_addtodynamictransalation : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_addtodynamictransalation().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_addtodynamictransalation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_addtodynamictransalation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_TrnAttributes aP0_SDT_TrnAttributes )
      {
         this.AV8SDT_TrnAttributes = aP0_SDT_TrnAttributes;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( SdtSDT_TrnAttributes aP0_SDT_TrnAttributes )
      {
         this.AV8SDT_TrnAttributes = aP0_SDT_TrnAttributes;
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
         AV16GXLvl11 = 0;
         /* Using cursor P00DK2 */
         pr_default.execute(0, new Object[] {AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Primarykeyid, AV8SDT_TrnAttributes.gxTpr_Trnname});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A580DynamicTranslationPrimaryKey = P00DK2_A580DynamicTranslationPrimaryKey[0];
            A579DynamicTranslationTrnName = P00DK2_A579DynamicTranslationTrnName[0];
            A581DynamicTranslationAttributeNam = P00DK2_A581DynamicTranslationAttributeNam[0];
            A582DynamicTranslationEnglish = P00DK2_A582DynamicTranslationEnglish[0];
            A583DynamicTranslationDutch = P00DK2_A583DynamicTranslationDutch[0];
            A578DynamicTranslationId = P00DK2_A578DynamicTranslationId[0];
            AV16GXLvl11 = 1;
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Count )
            {
               AV11Attribute = ((SdtSDT_TrnAttributes_Transaction_AttributeItem)AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV11Attribute.gxTpr_Attributename, A581DynamicTranslationAttributeNam) == 0 )
               {
                  /* Execute user subroutine: 'TRANSLATE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  A582DynamicTranslationEnglish = AV14DynamicTranslationEnglish;
                  A583DynamicTranslationDutch = AV15DynamicTranslationDutch;
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
            /* Using cursor P00DK3 */
            pr_default.execute(1, new Object[] {A582DynamicTranslationEnglish, A583DynamicTranslationDutch, A578DynamicTranslationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV16GXLvl11 == 0 )
         {
            AV18GXV2 = 1;
            while ( AV18GXV2 <= AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Count )
            {
               AV11Attribute = ((SdtSDT_TrnAttributes_Transaction_AttributeItem)AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Item(AV18GXV2));
               /* Execute user subroutine: 'TRANSLATE' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /*
                  INSERT RECORD ON TABLE Trn_DynamicTranslation

               */
               A579DynamicTranslationTrnName = AV8SDT_TrnAttributes.gxTpr_Trnname;
               A580DynamicTranslationPrimaryKey = AV8SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Primarykeyid;
               A581DynamicTranslationAttributeNam = AV11Attribute.gxTpr_Attributename;
               A582DynamicTranslationEnglish = AV14DynamicTranslationEnglish;
               A583DynamicTranslationDutch = AV15DynamicTranslationDutch;
               A578DynamicTranslationId = Guid.NewGuid( );
               /* Using cursor P00DK4 */
               pr_default.execute(2, new Object[] {A578DynamicTranslationId, A579DynamicTranslationTrnName, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
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
               AV18GXV2 = (int)(AV18GXV2+1);
            }
         }
         context.CommitDataStores("prc_addtodynamictransalation",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'TRANSLATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9Language, "English") == 0 )
         {
            AV14DynamicTranslationEnglish = AV11Attribute.gxTpr_Attributevalue;
            GXt_char1 = AV15DynamicTranslationDutch;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "nl", ""),  AV11Attribute.gxTpr_Attributevalue, out  GXt_char1) ;
            AV15DynamicTranslationDutch = GXt_char1;
         }
         else if ( StringUtil.StrCmp(AV9Language, "Dutch") == 0 )
         {
            AV15DynamicTranslationDutch = AV11Attribute.gxTpr_Attributevalue;
            GXt_char1 = AV14DynamicTranslationEnglish;
            new prc_translatelanguage(context ).execute(  AV12LanguageCode,  context.GetMessage( "en", ""),  AV11Attribute.gxTpr_Attributevalue, out  GXt_char1) ;
            AV14DynamicTranslationEnglish = GXt_char1;
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addtodynamictransalation",pr_default);
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
         P00DK2_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00DK2_A579DynamicTranslationTrnName = new string[] {""} ;
         P00DK2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00DK2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00DK2_A583DynamicTranslationDutch = new string[] {""} ;
         P00DK2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A579DynamicTranslationTrnName = "";
         A581DynamicTranslationAttributeNam = "";
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         A578DynamicTranslationId = Guid.Empty;
         AV11Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
         AV14DynamicTranslationEnglish = "";
         AV15DynamicTranslationDutch = "";
         Gx_emsg = "";
         GXt_char1 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_addtodynamictransalation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_addtodynamictransalation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_addtodynamictransalation__default(),
            new Object[][] {
                new Object[] {
               P00DK2_A580DynamicTranslationPrimaryKey, P00DK2_A579DynamicTranslationTrnName, P00DK2_A581DynamicTranslationAttributeNam, P00DK2_A582DynamicTranslationEnglish, P00DK2_A583DynamicTranslationDutch, P00DK2_A578DynamicTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16GXLvl11 ;
      private int AV17GXV1 ;
      private int AV18GXV2 ;
      private int GX_INS101 ;
      private string AV12LanguageCode ;
      private string Gx_emsg ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV14DynamicTranslationEnglish ;
      private string AV15DynamicTranslationDutch ;
      private string AV9Language ;
      private string A579DynamicTranslationTrnName ;
      private string A581DynamicTranslationAttributeNam ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_TrnAttributes AV8SDT_TrnAttributes ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DK2_A580DynamicTranslationPrimaryKey ;
      private string[] P00DK2_A579DynamicTranslationTrnName ;
      private string[] P00DK2_A581DynamicTranslationAttributeNam ;
      private string[] P00DK2_A582DynamicTranslationEnglish ;
      private string[] P00DK2_A583DynamicTranslationDutch ;
      private Guid[] P00DK2_A578DynamicTranslationId ;
      private SdtSDT_TrnAttributes_Transaction_AttributeItem AV11Attribute ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_addtodynamictransalation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_addtodynamictransalation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_addtodynamictransalation__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00DK2;
       prmP00DK2 = new Object[] {
       new ParDef("AV8SDT_T_1Transaction_1Primar",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV8SDT_TrnAttributes__Trnname",GXType.VarChar,100,0)
       };
       Object[] prmP00DK3;
       prmP00DK3 = new Object[] {
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00DK4;
       prmP00DK4 = new Object[] {
       new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationTrnName",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
       new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
       new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00DK2", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationTrnName, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE (DynamicTranslationPrimaryKey = :AV8SDT_T_1Transaction_1Primar) AND (DynamicTranslationTrnName = ( :AV8SDT_TrnAttributes__Trnname)) ORDER BY DynamicTranslationId  FOR UPDATE OF Trn_DynamicTranslation",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00DK3", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationEnglish=:DynamicTranslationEnglish, DynamicTranslationDutch=:DynamicTranslationDutch  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DK3)
          ,new CursorDef("P00DK4", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationTrnName, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch) VALUES(:DynamicTranslationId, :DynamicTranslationTrnName, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00DK4)
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
    }
 }

}

}
