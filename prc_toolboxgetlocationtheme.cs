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
   public class prc_toolboxgetlocationtheme : GXProcedure
   {
      public prc_toolboxgetlocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_toolboxgetlocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV15Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_LocationTheme=this.AV10SDT_LocationTheme;
         aP1_Error=this.AV15Error;
      }

      public SdtSDT_Error executeUdp( out SdtSDT_LocationTheme aP0_SDT_LocationTheme )
      {
         execute(out aP0_SDT_LocationTheme, out aP1_Error);
         return AV15Error ;
      }

      public void executeSubmit( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV15Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_LocationTheme=this.AV10SDT_LocationTheme;
         aP1_Error=this.AV15Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV15Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV15Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV17Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV18Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P00AJ2 */
            pr_default.execute(0, new Object[] {AV17Udparg1, AV18Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A577LocationThemeId = P00AJ2_A577LocationThemeId[0];
               n577LocationThemeId = P00AJ2_n577LocationThemeId[0];
               A584ActiveAppVersionId = P00AJ2_A584ActiveAppVersionId[0];
               n584ActiveAppVersionId = P00AJ2_n584ActiveAppVersionId[0];
               A598PublishedActiveAppVersionId = P00AJ2_A598PublishedActiveAppVersionId[0];
               n598PublishedActiveAppVersionId = P00AJ2_n598PublishedActiveAppVersionId[0];
               A11OrganisationId = P00AJ2_A11OrganisationId[0];
               A29LocationId = P00AJ2_A29LocationId[0];
               A274Trn_ThemeName = P00AJ2_A274Trn_ThemeName[0];
               n274Trn_ThemeName = P00AJ2_n274Trn_ThemeName[0];
               A281Trn_ThemeFontFamily = P00AJ2_A281Trn_ThemeFontFamily[0];
               n281Trn_ThemeFontFamily = P00AJ2_n281Trn_ThemeFontFamily[0];
               A405Trn_ThemeFontSize = P00AJ2_A405Trn_ThemeFontSize[0];
               n405Trn_ThemeFontSize = P00AJ2_n405Trn_ThemeFontSize[0];
               A274Trn_ThemeName = P00AJ2_A274Trn_ThemeName[0];
               n274Trn_ThemeName = P00AJ2_n274Trn_ThemeName[0];
               A281Trn_ThemeFontFamily = P00AJ2_A281Trn_ThemeFontFamily[0];
               n281Trn_ThemeFontFamily = P00AJ2_n281Trn_ThemeFontFamily[0];
               A405Trn_ThemeFontSize = P00AJ2_A405Trn_ThemeFontSize[0];
               n405Trn_ThemeFontSize = P00AJ2_n405Trn_ThemeFontSize[0];
               /* Using cursor P00AJ3 */
               pr_default.execute(1, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
               A273Trn_ThemeId = P00AJ3_A273Trn_ThemeId[0];
               pr_default.close(1);
               /* Using cursor P00AJ4 */
               pr_default.execute(2, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
               A273Trn_ThemeId = P00AJ4_A273Trn_ThemeId[0];
               pr_default.close(2);
               AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context);
               AV10SDT_LocationTheme.gxTpr_Themeid = A273Trn_ThemeId;
               AV10SDT_LocationTheme.gxTpr_Themename = A274Trn_ThemeName;
               AV10SDT_LocationTheme.gxTpr_Themefontfamily = A281Trn_ThemeFontFamily;
               AV10SDT_LocationTheme.gxTpr_Themefontsize = A405Trn_ThemeFontSize;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.close(2);
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV15Error = new SdtSDT_Error(context);
         AV17Udparg1 = Guid.Empty;
         AV18Udparg2 = Guid.Empty;
         P00AJ2_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         P00AJ2_n577LocationThemeId = new bool[] {false} ;
         P00AJ2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00AJ2_n584ActiveAppVersionId = new bool[] {false} ;
         P00AJ2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00AJ2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00AJ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AJ2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AJ2_A274Trn_ThemeName = new string[] {""} ;
         P00AJ2_n274Trn_ThemeName = new bool[] {false} ;
         P00AJ2_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00AJ2_n281Trn_ThemeFontFamily = new bool[] {false} ;
         P00AJ2_A405Trn_ThemeFontSize = new short[1] ;
         P00AJ2_n405Trn_ThemeFontSize = new bool[] {false} ;
         A577LocationThemeId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         P00AJ3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         P00AJ4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_toolboxgetlocationtheme__default(),
            new Object[][] {
                new Object[] {
               P00AJ2_A577LocationThemeId, P00AJ2_n577LocationThemeId, P00AJ2_A584ActiveAppVersionId, P00AJ2_n584ActiveAppVersionId, P00AJ2_A598PublishedActiveAppVersionId, P00AJ2_n598PublishedActiveAppVersionId, P00AJ2_A11OrganisationId, P00AJ2_A29LocationId, P00AJ2_A274Trn_ThemeName, P00AJ2_n274Trn_ThemeName,
               P00AJ2_A281Trn_ThemeFontFamily, P00AJ2_n281Trn_ThemeFontFamily, P00AJ2_A405Trn_ThemeFontSize, P00AJ2_n405Trn_ThemeFontSize
               }
               , new Object[] {
               P00AJ3_A273Trn_ThemeId
               }
               , new Object[] {
               P00AJ4_A273Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A405Trn_ThemeFontSize ;
      private bool n577LocationThemeId ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n274Trn_ThemeName ;
      private bool n281Trn_ThemeFontFamily ;
      private bool n405Trn_ThemeFontSize ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private Guid AV17Udparg1 ;
      private Guid AV18Udparg2 ;
      private Guid A577LocationThemeId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A273Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_LocationTheme AV10SDT_LocationTheme ;
      private SdtSDT_Error AV15Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AJ2_A577LocationThemeId ;
      private bool[] P00AJ2_n577LocationThemeId ;
      private Guid[] P00AJ2_A584ActiveAppVersionId ;
      private bool[] P00AJ2_n584ActiveAppVersionId ;
      private Guid[] P00AJ2_A598PublishedActiveAppVersionId ;
      private bool[] P00AJ2_n598PublishedActiveAppVersionId ;
      private Guid[] P00AJ2_A11OrganisationId ;
      private Guid[] P00AJ2_A29LocationId ;
      private string[] P00AJ2_A274Trn_ThemeName ;
      private bool[] P00AJ2_n274Trn_ThemeName ;
      private string[] P00AJ2_A281Trn_ThemeFontFamily ;
      private bool[] P00AJ2_n281Trn_ThemeFontFamily ;
      private short[] P00AJ2_A405Trn_ThemeFontSize ;
      private bool[] P00AJ2_n405Trn_ThemeFontSize ;
      private Guid[] P00AJ3_A273Trn_ThemeId ;
      private Guid[] P00AJ4_A273Trn_ThemeId ;
      private SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      private SdtSDT_Error aP1_Error ;
   }

   public class prc_toolboxgetlocationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AJ2;
          prmP00AJ2 = new Object[] {
          new ParDef("AV17Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18Udparg2",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00AJ3;
          prmP00AJ3 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00AJ4;
          prmP00AJ4 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00AJ2", "SELECT T1.LocationThemeId AS LocationThemeId, T1.ActiveAppVersionId, T1.PublishedActiveAppVersionId, T1.OrganisationId, T1.LocationId, T2.Trn_ThemeName, T2.Trn_ThemeFontFamily, T2.Trn_ThemeFontSize FROM (Trn_Location T1 LEFT JOIN Trn_Theme T2 ON T2.Trn_ThemeId = T1.LocationThemeId) WHERE T1.LocationId = :AV17Udparg1 and T1.OrganisationId = :AV18Udparg2 ORDER BY T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00AJ3", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00AJ4", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ4,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
