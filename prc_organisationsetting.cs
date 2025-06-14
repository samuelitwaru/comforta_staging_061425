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
   public class prc_organisationsetting : GXProcedure
   {
      public prc_organisationsetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_organisationsetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out SdtSDT_OrganisationSetting aP0_SDT_OrganisationSetting )
      {
         this.AV8SDT_OrganisationSetting = new SdtSDT_OrganisationSetting(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_OrganisationSetting=this.AV8SDT_OrganisationSetting;
      }

      public SdtSDT_OrganisationSetting executeUdp( )
      {
         execute(out aP0_SDT_OrganisationSetting);
         return AV8SDT_OrganisationSetting ;
      }

      public void executeSubmit( out SdtSDT_OrganisationSetting aP0_SDT_OrganisationSetting )
      {
         this.AV8SDT_OrganisationSetting = new SdtSDT_OrganisationSetting(context) ;
         SubmitImpl();
         aP0_SDT_OrganisationSetting=this.AV8SDT_OrganisationSetting;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GXLvl1 = 0;
         AV10Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {AV10Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00642_A11OrganisationId[0];
            A40000OrganisationSettingFavicon_GXI = P00642_A40000OrganisationSettingFavicon_GXI[0];
            A40001OrganisationSettingLogo_GXI = P00642_A40001OrganisationSettingLogo_GXI[0];
            A105OrganisationSettingLanguage = P00642_A105OrganisationSettingLanguage[0];
            A100OrganisationSettingid = P00642_A100OrganisationSettingid[0];
            A102OrganisationSettingFavicon = P00642_A102OrganisationSettingFavicon[0];
            A101OrganisationSettingLogo = P00642_A101OrganisationSettingLogo[0];
            AV9GXLvl1 = 1;
            AV8SDT_OrganisationSetting = new SdtSDT_OrganisationSetting(context);
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingbasecolor = "Custom";
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingfavicon = A102OrganisationSettingFavicon;
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingfavicon_gxi = A40000OrganisationSettingFavicon_GXI;
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingfontsize = "Medium";
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettinglogo = A101OrganisationSettingLogo;
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettinglogo_gxi = A40001OrganisationSettingLogo_GXI;
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettinglanguage = A105OrganisationSettingLanguage;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9GXLvl1 == 0 )
         {
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingbasecolor = "Custom";
            AV8SDT_OrganisationSetting.gxTpr_Organisationsettingfontsize = "Medium";
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
         AV8SDT_OrganisationSetting = new SdtSDT_OrganisationSetting(context);
         AV10Udparg1 = Guid.Empty;
         P00642_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00642_A40000OrganisationSettingFavicon_GXI = new string[] {""} ;
         P00642_A40001OrganisationSettingLogo_GXI = new string[] {""} ;
         P00642_A105OrganisationSettingLanguage = new string[] {""} ;
         P00642_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P00642_A102OrganisationSettingFavicon = new string[] {""} ;
         P00642_A101OrganisationSettingLogo = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A40000OrganisationSettingFavicon_GXI = "";
         A40001OrganisationSettingLogo_GXI = "";
         A105OrganisationSettingLanguage = "";
         A100OrganisationSettingid = Guid.Empty;
         A102OrganisationSettingFavicon = "";
         A101OrganisationSettingLogo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_organisationsetting__default(),
            new Object[][] {
                new Object[] {
               P00642_A11OrganisationId, P00642_A40000OrganisationSettingFavicon_GXI, P00642_A40001OrganisationSettingLogo_GXI, P00642_A105OrganisationSettingLanguage, P00642_A100OrganisationSettingid, P00642_A102OrganisationSettingFavicon, P00642_A101OrganisationSettingLogo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9GXLvl1 ;
      private string A105OrganisationSettingLanguage ;
      private string A40000OrganisationSettingFavicon_GXI ;
      private string A40001OrganisationSettingLogo_GXI ;
      private string A102OrganisationSettingFavicon ;
      private string A101OrganisationSettingLogo ;
      private Guid AV10Udparg1 ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OrganisationSetting AV8SDT_OrganisationSetting ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00642_A11OrganisationId ;
      private string[] P00642_A40000OrganisationSettingFavicon_GXI ;
      private string[] P00642_A40001OrganisationSettingLogo_GXI ;
      private string[] P00642_A105OrganisationSettingLanguage ;
      private Guid[] P00642_A100OrganisationSettingid ;
      private string[] P00642_A102OrganisationSettingFavicon ;
      private string[] P00642_A101OrganisationSettingLogo ;
      private SdtSDT_OrganisationSetting aP0_SDT_OrganisationSetting ;
   }

   public class prc_organisationsetting__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("AV10Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "SELECT OrganisationId, OrganisationSettingFavicon_GXI, OrganisationSettingLogo_GXI, OrganisationSettingLanguage, OrganisationSettingid, OrganisationSettingFavicon, OrganisationSettingLogo FROM Trn_OrganisationSetting WHERE OrganisationId = :AV10Udparg1 ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(2));
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
       }
    }

 }

}
