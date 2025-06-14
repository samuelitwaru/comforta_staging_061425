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
   public class prc_getlocationtheme : GXProcedure
   {
      public prc_getlocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_LocationId ,
                           ref Guid aP1_OrganisationId ,
                           out SdtSDT_Theme aP2_SDT_Theme )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV14SDT_Theme = new SdtSDT_Theme(context) ;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV8LocationId;
         aP1_OrganisationId=this.AV9OrganisationId;
         aP2_SDT_Theme=this.AV14SDT_Theme;
      }

      public SdtSDT_Theme executeUdp( ref Guid aP0_LocationId ,
                                      ref Guid aP1_OrganisationId )
      {
         execute(ref aP0_LocationId, ref aP1_OrganisationId, out aP2_SDT_Theme);
         return AV14SDT_Theme ;
      }

      public void executeSubmit( ref Guid aP0_LocationId ,
                                 ref Guid aP1_OrganisationId ,
                                 out SdtSDT_Theme aP2_SDT_Theme )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV14SDT_Theme = new SdtSDT_Theme(context) ;
         SubmitImpl();
         aP0_LocationId=this.AV8LocationId;
         aP1_OrganisationId=this.AV9OrganisationId;
         aP2_SDT_Theme=this.AV14SDT_Theme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00962 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00962_A11OrganisationId[0];
            n11OrganisationId = P00962_n11OrganisationId[0];
            A29LocationId = P00962_A29LocationId[0];
            n29LocationId = P00962_n29LocationId[0];
            A598PublishedActiveAppVersionId = P00962_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00962_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = P00962_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00962_n584ActiveAppVersionId[0];
            AV17AppVersionId = A598PublishedActiveAppVersionId;
            if ( (Guid.Empty==AV17AppVersionId) )
            {
               AV17AppVersionId = A584ActiveAppVersionId;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00963 */
         pr_default.execute(1, new Object[] {AV8LocationId, AV9OrganisationId, AV17AppVersionId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A523AppVersionId = P00963_A523AppVersionId[0];
            A11OrganisationId = P00963_A11OrganisationId[0];
            n11OrganisationId = P00963_n11OrganisationId[0];
            A29LocationId = P00963_A29LocationId[0];
            n29LocationId = P00963_n29LocationId[0];
            A273Trn_ThemeId = P00963_A273Trn_ThemeId[0];
            AV13ThemeId = A273Trn_ThemeId;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV13ThemeId ,
                                              A273Trn_ThemeId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00964 */
         pr_default.execute(2, new Object[] {AV13ThemeId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A273Trn_ThemeId = P00964_A273Trn_ThemeId[0];
            A274Trn_ThemeName = P00964_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = P00964_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = P00964_A405Trn_ThemeFontSize[0];
            AV14SDT_Theme = new SdtSDT_Theme(context);
            AV14SDT_Theme.gxTpr_Themeid = A273Trn_ThemeId;
            AV14SDT_Theme.gxTpr_Themename = A274Trn_ThemeName;
            AV14SDT_Theme.gxTpr_Themefontfamily = A281Trn_ThemeFontFamily;
            AV14SDT_Theme.gxTpr_Themefontsize = A405Trn_ThemeFontSize;
            /* Using cursor P00965 */
            pr_default.execute(3, new Object[] {A273Trn_ThemeId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A282IconId = P00965_A282IconId[0];
               A443IconCategory = P00965_A443IconCategory[0];
               A283IconName = P00965_A283IconName[0];
               A284IconSVG = P00965_A284IconSVG[0];
               AV16IconsItem = new SdtSDT_Theme_IconsItem(context);
               AV16IconsItem.gxTpr_Iconid = A282IconId;
               AV16IconsItem.gxTpr_Iconcategory = A443IconCategory;
               AV16IconsItem.gxTpr_Iconname = A283IconName;
               AV16IconsItem.gxTpr_Iconsvg = A284IconSVG;
               AV14SDT_Theme.gxTpr_Icons.Add(AV16IconsItem, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV14SDT_Theme = new SdtSDT_Theme(context);
         P00962_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00962_n11OrganisationId = new bool[] {false} ;
         P00962_A29LocationId = new Guid[] {Guid.Empty} ;
         P00962_n29LocationId = new bool[] {false} ;
         P00962_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00962_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00962_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00962_n584ActiveAppVersionId = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         AV17AppVersionId = Guid.Empty;
         P00963_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00963_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00963_n11OrganisationId = new bool[] {false} ;
         P00963_A29LocationId = new Guid[] {Guid.Empty} ;
         P00963_n29LocationId = new bool[] {false} ;
         P00963_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         AV13ThemeId = Guid.Empty;
         P00964_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00964_A274Trn_ThemeName = new string[] {""} ;
         P00964_A281Trn_ThemeFontFamily = new string[] {""} ;
         P00964_A405Trn_ThemeFontSize = new short[1] ;
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         P00965_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00965_A282IconId = new Guid[] {Guid.Empty} ;
         P00965_A443IconCategory = new string[] {""} ;
         P00965_A283IconName = new string[] {""} ;
         P00965_A284IconSVG = new string[] {""} ;
         A282IconId = Guid.Empty;
         A443IconCategory = "";
         A283IconName = "";
         A284IconSVG = "";
         AV16IconsItem = new SdtSDT_Theme_IconsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationtheme__default(),
            new Object[][] {
                new Object[] {
               P00962_A11OrganisationId, P00962_A29LocationId, P00962_A598PublishedActiveAppVersionId, P00962_n598PublishedActiveAppVersionId, P00962_A584ActiveAppVersionId, P00962_n584ActiveAppVersionId
               }
               , new Object[] {
               P00963_A523AppVersionId, P00963_A11OrganisationId, P00963_n11OrganisationId, P00963_A29LocationId, P00963_n29LocationId, P00963_A273Trn_ThemeId
               }
               , new Object[] {
               P00964_A273Trn_ThemeId, P00964_A274Trn_ThemeName, P00964_A281Trn_ThemeFontFamily, P00964_A405Trn_ThemeFontSize
               }
               , new Object[] {
               P00965_A273Trn_ThemeId, P00965_A282IconId, P00965_A443IconCategory, P00965_A283IconName, P00965_A284IconSVG
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A405Trn_ThemeFontSize ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private string A284IconSVG ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string A443IconCategory ;
      private string A283IconName ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid AV17AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV13ThemeId ;
      private Guid A282IconId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_LocationId ;
      private Guid aP1_OrganisationId ;
      private SdtSDT_Theme AV14SDT_Theme ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00962_A11OrganisationId ;
      private bool[] P00962_n11OrganisationId ;
      private Guid[] P00962_A29LocationId ;
      private bool[] P00962_n29LocationId ;
      private Guid[] P00962_A598PublishedActiveAppVersionId ;
      private bool[] P00962_n598PublishedActiveAppVersionId ;
      private Guid[] P00962_A584ActiveAppVersionId ;
      private bool[] P00962_n584ActiveAppVersionId ;
      private Guid[] P00963_A523AppVersionId ;
      private Guid[] P00963_A11OrganisationId ;
      private bool[] P00963_n11OrganisationId ;
      private Guid[] P00963_A29LocationId ;
      private bool[] P00963_n29LocationId ;
      private Guid[] P00963_A273Trn_ThemeId ;
      private Guid[] P00964_A273Trn_ThemeId ;
      private string[] P00964_A274Trn_ThemeName ;
      private string[] P00964_A281Trn_ThemeFontFamily ;
      private short[] P00964_A405Trn_ThemeFontSize ;
      private Guid[] P00965_A273Trn_ThemeId ;
      private Guid[] P00965_A282IconId ;
      private string[] P00965_A443IconCategory ;
      private string[] P00965_A283IconName ;
      private string[] P00965_A284IconSVG ;
      private SdtSDT_Theme_IconsItem AV16IconsItem ;
      private SdtSDT_Theme aP2_SDT_Theme ;
   }

   public class prc_getlocationtheme__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00964( IGxContext context ,
                                             Guid AV13ThemeId ,
                                             Guid A273Trn_ThemeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme";
         if ( ! (Guid.Empty==AV13ThemeId) )
         {
            AddWhere(sWhereString, "(Trn_ThemeId = :AV13ThemeId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_ThemeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00964(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00962;
          prmP00962 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00963;
          prmP00963 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV17AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00965;
          prmP00965 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00964;
          prmP00964 = new Object[] {
          new ParDef("AV13ThemeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00962", "SELECT OrganisationId, LocationId, PublishedActiveAppVersionId, ActiveAppVersionId FROM Trn_Location WHERE LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00962,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00963", "SELECT AppVersionId, OrganisationId, LocationId, Trn_ThemeId FROM Trn_AppVersion WHERE (LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId) AND (AppVersionId = :AV17AppVersionId) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00963,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00964", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00964,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00965", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00965,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
       }
    }

 }

}
