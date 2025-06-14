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
   public class prc_getdynamicformtranslation : GXProcedure
   {
      public prc_getdynamicformtranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdynamicformtranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref SdtSDT_DynamicFormTranslation aP0_SDT_DynamicFormTranslation )
      {
         this.AV10SDT_DynamicFormTranslation = aP0_SDT_DynamicFormTranslation;
         initialize();
         ExecuteImpl();
         aP0_SDT_DynamicFormTranslation=this.AV10SDT_DynamicFormTranslation;
      }

      public SdtSDT_DynamicFormTranslation executeUdp( )
      {
         execute(ref aP0_SDT_DynamicFormTranslation);
         return AV10SDT_DynamicFormTranslation ;
      }

      public void executeSubmit( ref SdtSDT_DynamicFormTranslation aP0_SDT_DynamicFormTranslation )
      {
         this.AV10SDT_DynamicFormTranslation = aP0_SDT_DynamicFormTranslation;
         SubmitImpl();
         aP0_SDT_DynamicFormTranslation=this.AV10SDT_DynamicFormTranslation;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Language = context.GetLanguage( );
         /* Using cursor P00E82 */
         pr_default.execute(0, new Object[] {AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid, AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber, AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A588DynamicFormTranslationWWPFormE = P00E82_A588DynamicFormTranslationWWPFormE[0];
            A587DynamicFormTranslationWWPFormV = P00E82_A587DynamicFormTranslationWWPFormV[0];
            A586DynamicFormTranslationWWpFormI = P00E82_A586DynamicFormTranslationWWpFormI[0];
            A591DynamicFormTranslationEnglish = P00E82_A591DynamicFormTranslationEnglish[0];
            A592DynamicFormTranslationDutch = P00E82_A592DynamicFormTranslationDutch[0];
            A585DynamicFormTranslationId = P00E82_A585DynamicFormTranslationId[0];
            if ( StringUtil.StrCmp(AV11Language, "English") == 0 )
            {
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue = A591DynamicFormTranslationEnglish;
            }
            else if ( StringUtil.StrCmp(AV11Language, "Dutch") == 0 )
            {
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue = A592DynamicFormTranslationDutch;
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
         AV11Language = "";
         P00E82_A588DynamicFormTranslationWWPFormE = new int[1] ;
         P00E82_A587DynamicFormTranslationWWPFormV = new int[1] ;
         P00E82_A586DynamicFormTranslationWWpFormI = new int[1] ;
         P00E82_A591DynamicFormTranslationEnglish = new string[] {""} ;
         P00E82_A592DynamicFormTranslationDutch = new string[] {""} ;
         P00E82_A585DynamicFormTranslationId = new Guid[] {Guid.Empty} ;
         A591DynamicFormTranslationEnglish = "";
         A592DynamicFormTranslationDutch = "";
         A585DynamicFormTranslationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdynamicformtranslation__default(),
            new Object[][] {
                new Object[] {
               P00E82_A588DynamicFormTranslationWWPFormE, P00E82_A587DynamicFormTranslationWWPFormV, P00E82_A586DynamicFormTranslationWWpFormI, P00E82_A591DynamicFormTranslationEnglish, P00E82_A592DynamicFormTranslationDutch, P00E82_A585DynamicFormTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A588DynamicFormTranslationWWPFormE ;
      private int A587DynamicFormTranslationWWPFormV ;
      private int A586DynamicFormTranslationWWpFormI ;
      private string A591DynamicFormTranslationEnglish ;
      private string A592DynamicFormTranslationDutch ;
      private string AV11Language ;
      private Guid A585DynamicFormTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_DynamicFormTranslation AV10SDT_DynamicFormTranslation ;
      private SdtSDT_DynamicFormTranslation aP0_SDT_DynamicFormTranslation ;
      private IDataStoreProvider pr_default ;
      private int[] P00E82_A588DynamicFormTranslationWWPFormE ;
      private int[] P00E82_A587DynamicFormTranslationWWPFormV ;
      private int[] P00E82_A586DynamicFormTranslationWWpFormI ;
      private string[] P00E82_A591DynamicFormTranslationEnglish ;
      private string[] P00E82_A592DynamicFormTranslationDutch ;
      private Guid[] P00E82_A585DynamicFormTranslationId ;
   }

   public class prc_getdynamicformtranslation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00E82;
          prmP00E82 = new Object[] {
          new ParDef("AV10SDT__1Dynamicformtranslat",GXType.Int32,6,0) ,
          new ParDef("AV10SDT__2Dynamicformtranslat",GXType.Int32,6,0) ,
          new ParDef("AV10SDT__3Dynamicformtranslat",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E82", "SELECT DynamicFormTranslationWWPFormE, DynamicFormTranslationWWPFormV, DynamicFormTranslationWWpFormI, DynamicFormTranslationEnglish, DynamicFormTranslationDutch, DynamicFormTranslationId FROM Trn_DynamicFormTranslation WHERE (DynamicFormTranslationWWpFormI = :AV10SDT__1Dynamicformtranslat) AND (DynamicFormTranslationWWPFormV = :AV10SDT__2Dynamicformtranslat) AND (DynamicFormTranslationWWPFormE = :AV10SDT__3Dynamicformtranslat) ORDER BY DynamicFormTranslationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E82,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
       }
    }

 }

}
