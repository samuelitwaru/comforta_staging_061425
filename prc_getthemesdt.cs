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
   public class prc_getthemesdt : GXProcedure
   {
      public prc_getthemesdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getthemesdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ThemeId ,
                           out SdtSDT_Theme aP1_SDT_Theme )
      {
         this.AV13ThemeId = aP0_ThemeId;
         this.AV8SDT_Theme = new SdtSDT_Theme(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Theme=this.AV8SDT_Theme;
      }

      public SdtSDT_Theme executeUdp( Guid aP0_ThemeId )
      {
         execute(aP0_ThemeId, out aP1_SDT_Theme);
         return AV8SDT_Theme ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 out SdtSDT_Theme aP1_SDT_Theme )
      {
         this.AV13ThemeId = aP0_ThemeId;
         this.AV8SDT_Theme = new SdtSDT_Theme(context) ;
         SubmitImpl();
         aP1_SDT_Theme=this.AV8SDT_Theme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009J2 */
         pr_default.execute(0, new Object[] {AV13ThemeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273Trn_ThemeId = P009J2_A273Trn_ThemeId[0];
            A274Trn_ThemeName = P009J2_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = P009J2_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = P009J2_A405Trn_ThemeFontSize[0];
            AV8SDT_Theme = new SdtSDT_Theme(context);
            AV8SDT_Theme.gxTpr_Themeid = A273Trn_ThemeId;
            AV8SDT_Theme.gxTpr_Themename = A274Trn_ThemeName;
            AV8SDT_Theme.gxTpr_Themefontfamily = A281Trn_ThemeFontFamily;
            AV8SDT_Theme.gxTpr_Themefontsize = A405Trn_ThemeFontSize;
            /* Using cursor P009J3 */
            pr_default.execute(1, new Object[] {A273Trn_ThemeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A282IconId = P009J3_A282IconId[0];
               A443IconCategory = P009J3_A443IconCategory[0];
               A283IconName = P009J3_A283IconName[0];
               A284IconSVG = P009J3_A284IconSVG[0];
               AV10IconsItem = new SdtSDT_Theme_IconsItem(context);
               AV10IconsItem.gxTpr_Iconid = A282IconId;
               AV10IconsItem.gxTpr_Iconcategory = A443IconCategory;
               AV10IconsItem.gxTpr_Iconname = A283IconName;
               AV10IconsItem.gxTpr_Iconsvg = A284IconSVG;
               AV8SDT_Theme.gxTpr_Icons.Add(AV10IconsItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P009J4 */
            pr_default.execute(2, new Object[] {A273Trn_ThemeId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A275ColorId = P009J4_A275ColorId[0];
               A276ColorName = P009J4_A276ColorName[0];
               A277ColorCode = P009J4_A277ColorCode[0];
               AV11ColorsItem = new SdtSDT_Theme_ColorsItem(context);
               AV11ColorsItem.gxTpr_Colorid = A275ColorId;
               AV11ColorsItem.gxTpr_Colorname = A276ColorName;
               AV11ColorsItem.gxTpr_Colorcode = A277ColorCode;
               AV8SDT_Theme.gxTpr_Colors.Add(AV11ColorsItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
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
         AV8SDT_Theme = new SdtSDT_Theme(context);
         P009J2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P009J2_A274Trn_ThemeName = new string[] {""} ;
         P009J2_A281Trn_ThemeFontFamily = new string[] {""} ;
         P009J2_A405Trn_ThemeFontSize = new short[1] ;
         A273Trn_ThemeId = Guid.Empty;
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         P009J3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P009J3_A282IconId = new Guid[] {Guid.Empty} ;
         P009J3_A443IconCategory = new string[] {""} ;
         P009J3_A283IconName = new string[] {""} ;
         P009J3_A284IconSVG = new string[] {""} ;
         A282IconId = Guid.Empty;
         A443IconCategory = "";
         A283IconName = "";
         A284IconSVG = "";
         AV10IconsItem = new SdtSDT_Theme_IconsItem(context);
         P009J4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P009J4_A275ColorId = new Guid[] {Guid.Empty} ;
         P009J4_A276ColorName = new string[] {""} ;
         P009J4_A277ColorCode = new string[] {""} ;
         A275ColorId = Guid.Empty;
         A276ColorName = "";
         A277ColorCode = "";
         AV11ColorsItem = new SdtSDT_Theme_ColorsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getthemesdt__default(),
            new Object[][] {
                new Object[] {
               P009J2_A273Trn_ThemeId, P009J2_A274Trn_ThemeName, P009J2_A281Trn_ThemeFontFamily, P009J2_A405Trn_ThemeFontSize
               }
               , new Object[] {
               P009J3_A273Trn_ThemeId, P009J3_A282IconId, P009J3_A443IconCategory, P009J3_A283IconName, P009J3_A284IconSVG
               }
               , new Object[] {
               P009J4_A273Trn_ThemeId, P009J4_A275ColorId, P009J4_A276ColorName, P009J4_A277ColorCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A405Trn_ThemeFontSize ;
      private string A284IconSVG ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string A443IconCategory ;
      private string A283IconName ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private Guid AV13ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid A282IconId ;
      private Guid A275ColorId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Theme AV8SDT_Theme ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009J2_A273Trn_ThemeId ;
      private string[] P009J2_A274Trn_ThemeName ;
      private string[] P009J2_A281Trn_ThemeFontFamily ;
      private short[] P009J2_A405Trn_ThemeFontSize ;
      private Guid[] P009J3_A273Trn_ThemeId ;
      private Guid[] P009J3_A282IconId ;
      private string[] P009J3_A443IconCategory ;
      private string[] P009J3_A283IconName ;
      private string[] P009J3_A284IconSVG ;
      private SdtSDT_Theme_IconsItem AV10IconsItem ;
      private Guid[] P009J4_A273Trn_ThemeId ;
      private Guid[] P009J4_A275ColorId ;
      private string[] P009J4_A276ColorName ;
      private string[] P009J4_A277ColorCode ;
      private SdtSDT_Theme_ColorsItem AV11ColorsItem ;
      private SdtSDT_Theme aP1_SDT_Theme ;
   }

   public class prc_getthemesdt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009J2;
          prmP009J2 = new Object[] {
          new ParDef("AV13ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009J3;
          prmP009J3 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009J4;
          prmP009J4 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009J2", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Trn_ThemeId = :AV13ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P009J3", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009J4", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
