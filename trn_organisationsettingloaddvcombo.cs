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
   public class trn_organisationsettingloaddvcombo : GXProcedure
   {
      public trn_organisationsettingloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationsettingloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_OrganisationSettingid ,
                           Guid aP3_OrganisationId ,
                           out string aP4_SelectedValue ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20OrganisationSettingid = aP2_OrganisationSettingid;
         this.AV28OrganisationId = aP3_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP4_SelectedValue=this.AV22SelectedValue;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  Guid aP2_OrganisationSettingid ,
                                                                                                  Guid aP3_OrganisationId ,
                                                                                                  out string aP4_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_OrganisationSettingid, aP3_OrganisationId, out aP4_SelectedValue, out aP5_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_OrganisationSettingid ,
                                 Guid aP3_OrganisationId ,
                                 out string aP4_SelectedValue ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20OrganisationSettingid = aP2_OrganisationSettingid;
         this.AV28OrganisationId = aP3_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP4_SelectedValue=this.AV22SelectedValue;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "OrganisationSettingLanguage") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONSETTINGLANGUAGE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_ORGANISATIONSETTINGLANGUAGE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P005Y2 */
            pr_default.execute(0, new Object[] {AV20OrganisationSettingid, AV28OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P005Y2_A11OrganisationId[0];
               A100OrganisationSettingid = P005Y2_A100OrganisationSettingid[0];
               A105OrganisationSettingLanguage = P005Y2_A105OrganisationSettingLanguage[0];
               AV22SelectedValue = A105OrganisationSettingLanguage;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
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
         AV22SelectedValue = "";
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P005Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005Y2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P005Y2_A105OrganisationSettingLanguage = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         A105OrganisationSettingLanguage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsettingloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005Y2_A11OrganisationId, P005Y2_A100OrganisationSettingid, P005Y2_A105OrganisationSettingLanguage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18TrnMode ;
      private bool returnInSub ;
      private string A105OrganisationSettingLanguage ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private Guid AV20OrganisationSettingid ;
      private Guid AV28OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005Y2_A11OrganisationId ;
      private Guid[] P005Y2_A100OrganisationSettingid ;
      private string[] P005Y2_A105OrganisationSettingLanguage ;
      private string aP4_SelectedValue ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class trn_organisationsettingloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005Y2;
          prmP005Y2 = new Object[] {
          new ParDef("AV20OrganisationSettingid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV28OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Y2", "SELECT OrganisationId, OrganisationSettingid, OrganisationSettingLanguage FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :AV20OrganisationSettingid and OrganisationId = :AV28OrganisationId ORDER BY OrganisationSettingid, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
       }
    }

 }

}
