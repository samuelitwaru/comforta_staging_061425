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
   public class prc_checktranslationsbeforepublish : GXProcedure
   {
      public prc_checktranslationsbeforepublish( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checktranslationsbeforepublish( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out GxSimpleCollection<string> aP1_Messages ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV28Messages = new GxSimpleCollection<string>() ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_Messages=this.AV28Messages;
         aP2_SDT_Error=this.AV10SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      out GxSimpleCollection<string> aP1_Messages )
      {
         execute(aP0_AppVersionId, out aP1_Messages, out aP2_SDT_Error);
         return AV10SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out GxSimpleCollection<string> aP1_Messages ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         this.AV28Messages = new GxSimpleCollection<string>() ;
         this.AV10SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_Messages=this.AV28Messages;
         aP2_SDT_Error=this.AV10SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV10SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV10SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV9BC_Trn_AppVersion.Load(AV8AppVersionId);
         if ( ! (Guid.Empty==AV9BC_Trn_AppVersion.gxTpr_Appversionid) )
         {
            /* Using cursor P00H82 */
            pr_default.execute(0, new Object[] {AV8AppVersionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A523AppVersionId = P00H82_A523AppVersionId[0];
               A648AppVersionLanguage = P00H82_A648AppVersionLanguage[0];
               AV26AppVersionLanguage = A648AppVersionLanguage;
               AV28Messages = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               /* Using cursor P00H83 */
               pr_default.execute(1, new Object[] {A523AppVersionId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A516PageId = P00H83_A516PageId[0];
                  A525PageType = P00H83_A525PageType[0];
                  A518PageStructure = P00H83_A518PageStructure[0];
                  A517PageName = P00H83_A517PageName[0];
                  AV32GXLvl19 = 0;
                  /* Using cursor P00H84 */
                  pr_default.execute(2, new Object[] {A516PageId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A580DynamicTranslationPrimaryKey = P00H84_A580DynamicTranslationPrimaryKey[0];
                     A583DynamicTranslationDutch = P00H84_A583DynamicTranslationDutch[0];
                     A582DynamicTranslationEnglish = P00H84_A582DynamicTranslationEnglish[0];
                     A581DynamicTranslationAttributeNam = P00H84_A581DynamicTranslationAttributeNam[0];
                     A578DynamicTranslationId = P00H84_A578DynamicTranslationId[0];
                     AV32GXLvl19 = 1;
                     if ( StringUtil.StrCmp(AV26AppVersionLanguage, "nl") == 0 )
                     {
                        AV27Original = A583DynamicTranslationDutch;
                     }
                     else if ( StringUtil.StrCmp(AV26AppVersionLanguage, "en") == 0 )
                     {
                        AV27Original = A582DynamicTranslationEnglish;
                     }
                     if ( ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageStructure") == 0 ) && ( StringUtil.StrCmp(A525PageType, "Information") == 0 ) )
                     {
                        if ( ! ( ( StringUtil.StrCmp(A518PageStructure, AV27Original) == 0 ) ) )
                        {
                           AV29Message = A517PageName + context.GetMessage( " structure translation is not updated", "");
                           AV28Messages.Add(AV29Message, 0);
                        }
                     }
                     if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PageName") == 0 )
                     {
                        if ( ! ( ( StringUtil.StrCmp(A517PageName, AV27Original) == 0 ) ) )
                        {
                           AV29Message = A517PageName + context.GetMessage( " is not yet translated", "");
                           AV28Messages.Add(AV29Message, 0);
                        }
                     }
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  if ( AV32GXLvl19 == 0 )
                  {
                     if ( StringUtil.StrCmp(A525PageType, "Information") == 0 )
                     {
                        AV29Message = A517PageName + context.GetMessage( " page name is not yet translated", "");
                        AV28Messages.Add(AV29Message, 0);
                     }
                     AV29Message = A517PageName + context.GetMessage( " is not yet translated", "");
                     AV28Messages.Add(AV29Message, 0);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else
         {
            AV10SDT_Error.gxTpr_Message = context.GetMessage( "App version not found", "");
         }
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
         AV28Messages = new GxSimpleCollection<string>();
         AV10SDT_Error = new SdtSDT_Error(context);
         AV9BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00H82_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00H82_A648AppVersionLanguage = new string[] {""} ;
         A523AppVersionId = Guid.Empty;
         A648AppVersionLanguage = "";
         AV26AppVersionLanguage = "";
         P00H83_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00H83_A516PageId = new Guid[] {Guid.Empty} ;
         P00H83_A525PageType = new string[] {""} ;
         P00H83_A518PageStructure = new string[] {""} ;
         P00H83_A517PageName = new string[] {""} ;
         A516PageId = Guid.Empty;
         A525PageType = "";
         A518PageStructure = "";
         A517PageName = "";
         P00H84_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00H84_A583DynamicTranslationDutch = new string[] {""} ;
         P00H84_A582DynamicTranslationEnglish = new string[] {""} ;
         P00H84_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00H84_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A583DynamicTranslationDutch = "";
         A582DynamicTranslationEnglish = "";
         A581DynamicTranslationAttributeNam = "";
         A578DynamicTranslationId = Guid.Empty;
         AV27Original = "";
         AV29Message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_checktranslationsbeforepublish__default(),
            new Object[][] {
                new Object[] {
               P00H82_A523AppVersionId, P00H82_A648AppVersionLanguage
               }
               , new Object[] {
               P00H83_A523AppVersionId, P00H83_A516PageId, P00H83_A525PageType, P00H83_A518PageStructure, P00H83_A517PageName
               }
               , new Object[] {
               P00H84_A580DynamicTranslationPrimaryKey, P00H84_A583DynamicTranslationDutch, P00H84_A582DynamicTranslationEnglish, P00H84_A581DynamicTranslationAttributeNam, P00H84_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32GXLvl19 ;
      private string A518PageStructure ;
      private string A583DynamicTranslationDutch ;
      private string A582DynamicTranslationEnglish ;
      private string AV27Original ;
      private string A648AppVersionLanguage ;
      private string AV26AppVersionLanguage ;
      private string A525PageType ;
      private string A517PageName ;
      private string A581DynamicTranslationAttributeNam ;
      private string AV29Message ;
      private Guid AV8AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Messages ;
      private SdtSDT_Error AV10SDT_Error ;
      private SdtTrn_AppVersion AV9BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00H82_A523AppVersionId ;
      private string[] P00H82_A648AppVersionLanguage ;
      private Guid[] P00H83_A523AppVersionId ;
      private Guid[] P00H83_A516PageId ;
      private string[] P00H83_A525PageType ;
      private string[] P00H83_A518PageStructure ;
      private string[] P00H83_A517PageName ;
      private Guid[] P00H84_A580DynamicTranslationPrimaryKey ;
      private string[] P00H84_A583DynamicTranslationDutch ;
      private string[] P00H84_A582DynamicTranslationEnglish ;
      private string[] P00H84_A581DynamicTranslationAttributeNam ;
      private Guid[] P00H84_A578DynamicTranslationId ;
      private GxSimpleCollection<string> aP1_Messages ;
      private SdtSDT_Error aP2_SDT_Error ;
   }

   public class prc_checktranslationsbeforepublish__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00H82;
          prmP00H82 = new Object[] {
          new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H83;
          prmP00H83 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00H84;
          prmP00H84 = new Object[] {
          new ParDef("PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H82", "SELECT AppVersionId, AppVersionLanguage FROM Trn_AppVersion WHERE AppVersionId = :AV8AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H82,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00H83", "SELECT AppVersionId, PageId, PageType, PageStructure, PageName FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H83,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H84", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationAttributeNam, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :PageId ORDER BY DynamicTranslationPrimaryKey ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H84,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
