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
   public class prc_getthemecolorbyname : GXProcedure
   {
      public prc_getthemecolorbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getthemecolorbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ThemeId ,
                           string aP1_ColorName ,
                           out string aP2_ColorCode )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV10ColorName = aP1_ColorName;
         this.AV9ColorCode = "" ;
         initialize();
         ExecuteImpl();
         aP2_ColorCode=this.AV9ColorCode;
      }

      public string executeUdp( Guid aP0_ThemeId ,
                                string aP1_ColorName )
      {
         execute(aP0_ThemeId, aP1_ColorName, out aP2_ColorCode);
         return AV9ColorCode ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 string aP1_ColorName ,
                                 out string aP2_ColorCode )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV10ColorName = aP1_ColorName;
         this.AV9ColorCode = "" ;
         SubmitImpl();
         aP2_ColorCode=this.AV9ColorCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DV2 */
         pr_default.execute(0, new Object[] {AV8ThemeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273Trn_ThemeId = P00DV2_A273Trn_ThemeId[0];
            AV12GXLvl3 = 0;
            /* Using cursor P00DV3 */
            pr_default.execute(1, new Object[] {A273Trn_ThemeId, AV10ColorName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A276ColorName = P00DV3_A276ColorName[0];
               A277ColorCode = P00DV3_A277ColorCode[0];
               A275ColorId = P00DV3_A275ColorId[0];
               AV12GXLvl3 = 1;
               AV9ColorCode = A277ColorCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV12GXLvl3 == 0 )
            {
               /* Using cursor P00DV4 */
               pr_default.execute(2, new Object[] {A273Trn_ThemeId, AV10ColorName});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A539CtaColorName = P00DV4_A539CtaColorName[0];
                  A540CtaColorCode = P00DV4_A540CtaColorCode[0];
                  A538CtaColorId = P00DV4_A538CtaColorId[0];
                  AV9ColorCode = A540CtaColorCode;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
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
         AV9ColorCode = "";
         P00DV2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         P00DV3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00DV3_A276ColorName = new string[] {""} ;
         P00DV3_A277ColorCode = new string[] {""} ;
         P00DV3_A275ColorId = new Guid[] {Guid.Empty} ;
         A276ColorName = "";
         A277ColorCode = "";
         A275ColorId = Guid.Empty;
         P00DV4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00DV4_A539CtaColorName = new string[] {""} ;
         P00DV4_A540CtaColorCode = new string[] {""} ;
         P00DV4_A538CtaColorId = new Guid[] {Guid.Empty} ;
         A539CtaColorName = "";
         A540CtaColorCode = "";
         A538CtaColorId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getthemecolorbyname__default(),
            new Object[][] {
                new Object[] {
               P00DV2_A273Trn_ThemeId
               }
               , new Object[] {
               P00DV3_A273Trn_ThemeId, P00DV3_A276ColorName, P00DV3_A277ColorCode, P00DV3_A275ColorId
               }
               , new Object[] {
               P00DV4_A273Trn_ThemeId, P00DV4_A539CtaColorName, P00DV4_A540CtaColorCode, P00DV4_A538CtaColorId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12GXLvl3 ;
      private string AV10ColorName ;
      private string AV9ColorCode ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private string A539CtaColorName ;
      private string A540CtaColorCode ;
      private Guid AV8ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid A275ColorId ;
      private Guid A538CtaColorId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DV2_A273Trn_ThemeId ;
      private Guid[] P00DV3_A273Trn_ThemeId ;
      private string[] P00DV3_A276ColorName ;
      private string[] P00DV3_A277ColorCode ;
      private Guid[] P00DV3_A275ColorId ;
      private Guid[] P00DV4_A273Trn_ThemeId ;
      private string[] P00DV4_A539CtaColorName ;
      private string[] P00DV4_A540CtaColorCode ;
      private Guid[] P00DV4_A538CtaColorId ;
      private string aP2_ColorCode ;
   }

   public class prc_getthemecolorbyname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DV2;
          prmP00DV2 = new Object[] {
          new ParDef("AV8ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DV3;
          prmP00DV3 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10ColorName",GXType.VarChar,100,0)
          };
          Object[] prmP00DV4;
          prmP00DV4 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10ColorName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DV2", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :AV8ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DV2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00DV3", "SELECT Trn_ThemeId, ColorName, ColorCode, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorName = ( :AV10ColorName) ORDER BY Trn_ThemeId, ColorName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DV3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DV4", "SELECT Trn_ThemeId, CtaColorName, CtaColorCode, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId and CtaColorName = ( :AV10ColorName) ORDER BY Trn_ThemeId, CtaColorName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DV4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
