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
   public class prc_adddynamicformtosdt : GXProcedure
   {
      public prc_adddynamicformtosdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_adddynamicformtosdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           ref short aP1_WWPFormVersionNumber ,
                           out GXBaseCollection<SdtSDT_DynamicFormTranslation> aP2_SDT_DynamicFormTranslationCollection )
      {
         this.AV8WWPFormId = aP0_WWPFormId;
         this.AV9WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV11SDT_DynamicFormTranslationCollection = new GXBaseCollection<SdtSDT_DynamicFormTranslation>( context, "SDT_DynamicFormTranslation", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_WWPFormVersionNumber=this.AV9WWPFormVersionNumber;
         aP2_SDT_DynamicFormTranslationCollection=this.AV11SDT_DynamicFormTranslationCollection;
      }

      public GXBaseCollection<SdtSDT_DynamicFormTranslation> executeUdp( short aP0_WWPFormId ,
                                                                         ref short aP1_WWPFormVersionNumber )
      {
         execute(aP0_WWPFormId, ref aP1_WWPFormVersionNumber, out aP2_SDT_DynamicFormTranslationCollection);
         return AV11SDT_DynamicFormTranslationCollection ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 ref short aP1_WWPFormVersionNumber ,
                                 out GXBaseCollection<SdtSDT_DynamicFormTranslation> aP2_SDT_DynamicFormTranslationCollection )
      {
         this.AV8WWPFormId = aP0_WWPFormId;
         this.AV9WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV11SDT_DynamicFormTranslationCollection = new GXBaseCollection<SdtSDT_DynamicFormTranslation>( context, "SDT_DynamicFormTranslation", "Comforta_version2") ;
         SubmitImpl();
         aP1_WWPFormVersionNumber=this.AV9WWPFormVersionNumber;
         aP2_SDT_DynamicFormTranslationCollection=this.AV11SDT_DynamicFormTranslationCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00E42 */
         pr_default.execute(0, new Object[] {AV8WWPFormId, AV9WWPFormVersionNumber});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = P00E42_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00E42_A207WWPFormVersionNumber[0];
            A209WWPFormTitle = P00E42_A209WWPFormTitle[0];
            AV10SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
            AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = A206WWPFormId;
            AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = A207WWPFormVersionNumber;
            AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname = "WWP_Form";
            AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationattributename = "WWPFormTitle";
            AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue = A209WWPFormTitle;
            AV11SDT_DynamicFormTranslationCollection.Add(AV10SDT_DynamicFormTranslation, 0);
            /* Using cursor P00E43 */
            pr_default.execute(1, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A210WWPFormElementId = P00E43_A210WWPFormElementId[0];
               A229WWPFormElementTitle = P00E43_A229WWPFormElementTitle[0];
               AV10SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = A206WWPFormId;
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = A207WWPFormVersionNumber;
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = A210WWPFormElementId;
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationtrnname = "WWP_Form.Element";
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationattributename = "WWPFormElementTitle";
               AV10SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue = A229WWPFormElementTitle;
               AV11SDT_DynamicFormTranslationCollection.Add(AV10SDT_DynamicFormTranslation, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV11SDT_DynamicFormTranslationCollection = new GXBaseCollection<SdtSDT_DynamicFormTranslation>( context, "SDT_DynamicFormTranslation", "Comforta_version2");
         P00E42_A206WWPFormId = new short[1] ;
         P00E42_A207WWPFormVersionNumber = new short[1] ;
         P00E42_A209WWPFormTitle = new string[] {""} ;
         A209WWPFormTitle = "";
         AV10SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         P00E43_A206WWPFormId = new short[1] ;
         P00E43_A207WWPFormVersionNumber = new short[1] ;
         P00E43_A210WWPFormElementId = new short[1] ;
         P00E43_A229WWPFormElementTitle = new string[] {""} ;
         A229WWPFormElementTitle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_adddynamicformtosdt__default(),
            new Object[][] {
                new Object[] {
               P00E42_A206WWPFormId, P00E42_A207WWPFormVersionNumber, P00E42_A209WWPFormTitle
               }
               , new Object[] {
               P00E43_A206WWPFormId, P00E43_A207WWPFormVersionNumber, P00E43_A210WWPFormElementId, P00E43_A229WWPFormElementTitle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8WWPFormId ;
      private short AV9WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A210WWPFormElementId ;
      private string A229WWPFormElementTitle ;
      private string A209WWPFormTitle ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP1_WWPFormVersionNumber ;
      private GXBaseCollection<SdtSDT_DynamicFormTranslation> AV11SDT_DynamicFormTranslationCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P00E42_A206WWPFormId ;
      private short[] P00E42_A207WWPFormVersionNumber ;
      private string[] P00E42_A209WWPFormTitle ;
      private SdtSDT_DynamicFormTranslation AV10SDT_DynamicFormTranslation ;
      private short[] P00E43_A206WWPFormId ;
      private short[] P00E43_A207WWPFormVersionNumber ;
      private short[] P00E43_A210WWPFormElementId ;
      private string[] P00E43_A229WWPFormElementTitle ;
      private GXBaseCollection<SdtSDT_DynamicFormTranslation> aP2_SDT_DynamicFormTranslationCollection ;
   }

   public class prc_adddynamicformtosdt__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00E42;
          prmP00E42 = new Object[] {
          new ParDef("AV8WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmP00E43;
          prmP00E43 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E42", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormTitle FROM WWP_Form WHERE WWPFormId = :AV8WWPFormId and WWPFormVersionNumber = :AV9WWPFormVersionNumber ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00E43", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId, WWPFormElementTitle FROM WWP_FormElement WHERE WWPFormId = :WWPFormId and WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E43,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
