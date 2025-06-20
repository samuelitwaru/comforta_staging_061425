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
   public class dp_locationdynamicform : GXProcedure
   {
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

      public dp_locationdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_locationdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Udparg3 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P000G2 */
         pr_default.execute(0, new Object[] {AV8Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P000G2_A29LocationId[0];
            A366LocationDynamicFormId = P000G2_A366LocationDynamicFormId[0];
            A11OrganisationId = P000G2_A11OrganisationId[0];
            A207WWPFormVersionNumber = P000G2_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = P000G2_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P000G2_A209WWPFormTitle[0];
            A231WWPFormDate = P000G2_A231WWPFormDate[0];
            A232WWPFormIsWizard = P000G2_A232WWPFormIsWizard[0];
            A216WWPFormResume = P000G2_A216WWPFormResume[0];
            A235WWPFormResumeMessage = P000G2_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = P000G2_A233WWPFormValidations[0];
            A234WWPFormInstantiated = P000G2_A234WWPFormInstantiated[0];
            A240WWPFormType = P000G2_A240WWPFormType[0];
            A241WWPFormSectionRefElements = P000G2_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = P000G2_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = P000G2_A206WWPFormId[0];
            A208WWPFormReferenceName = P000G2_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P000G2_A209WWPFormTitle[0];
            A231WWPFormDate = P000G2_A231WWPFormDate[0];
            A232WWPFormIsWizard = P000G2_A232WWPFormIsWizard[0];
            A216WWPFormResume = P000G2_A216WWPFormResume[0];
            A235WWPFormResumeMessage = P000G2_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = P000G2_A233WWPFormValidations[0];
            A234WWPFormInstantiated = P000G2_A234WWPFormInstantiated[0];
            A240WWPFormType = P000G2_A240WWPFormType[0];
            A241WWPFormSectionRefElements = P000G2_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = P000G2_A242WWPFormIsForDynamicValidations[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            Gxm1sdt_locationdynamicform = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
            Gxm2rootcol.Add(Gxm1sdt_locationdynamicform, 0);
            Gxm1sdt_locationdynamicform.gxTpr_Locationdynamicformid = A366LocationDynamicFormId;
            Gxm1sdt_locationdynamicform.gxTpr_Organisationid = A11OrganisationId;
            Gxm1sdt_locationdynamicform.gxTpr_Locationid = A29LocationId;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformid = A206WWPFormId;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformtitle = A209WWPFormTitle;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformdate = A231WWPFormDate;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformresume = A216WWPFormResume;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformvalidations = A233WWPFormValidations;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformtype = A240WWPFormType;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
            Gxm1sdt_locationdynamicform.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
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
         AV8Udparg3 = Guid.Empty;
         P000G2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000G2_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P000G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000G2_A207WWPFormVersionNumber = new short[1] ;
         P000G2_A208WWPFormReferenceName = new string[] {""} ;
         P000G2_A209WWPFormTitle = new string[] {""} ;
         P000G2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P000G2_A232WWPFormIsWizard = new bool[] {false} ;
         P000G2_A216WWPFormResume = new short[1] ;
         P000G2_A235WWPFormResumeMessage = new string[] {""} ;
         P000G2_A233WWPFormValidations = new string[] {""} ;
         P000G2_A234WWPFormInstantiated = new bool[] {false} ;
         P000G2_A240WWPFormType = new short[1] ;
         P000G2_A241WWPFormSectionRefElements = new string[] {""} ;
         P000G2_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         P000G2_A206WWPFormId = new short[1] ;
         A29LocationId = Guid.Empty;
         A366LocationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A241WWPFormSectionRefElements = "";
         Gxm1sdt_locationdynamicform = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_locationdynamicform__default(),
            new Object[][] {
                new Object[] {
               P000G2_A29LocationId, P000G2_A366LocationDynamicFormId, P000G2_A11OrganisationId, P000G2_A207WWPFormVersionNumber, P000G2_A208WWPFormReferenceName, P000G2_A209WWPFormTitle, P000G2_A231WWPFormDate, P000G2_A232WWPFormIsWizard, P000G2_A216WWPFormResume, P000G2_A235WWPFormResumeMessage,
               P000G2_A233WWPFormValidations, P000G2_A234WWPFormInstantiated, P000G2_A240WWPFormType, P000G2_A241WWPFormSectionRefElements, P000G2_A242WWPFormIsForDynamicValidations, P000G2_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A207WWPFormVersionNumber ;
      private short A216WWPFormResume ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short A219WWPFormLatestVersionNumber ;
      private short GXt_int1 ;
      private DateTime A231WWPFormDate ;
      private bool A232WWPFormIsWizard ;
      private bool A234WWPFormInstantiated ;
      private bool A242WWPFormIsForDynamicValidations ;
      private string A235WWPFormResumeMessage ;
      private string A233WWPFormValidations ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private Guid AV8Udparg3 ;
      private Guid A29LocationId ;
      private Guid A366LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000G2_A29LocationId ;
      private Guid[] P000G2_A366LocationDynamicFormId ;
      private Guid[] P000G2_A11OrganisationId ;
      private short[] P000G2_A207WWPFormVersionNumber ;
      private string[] P000G2_A208WWPFormReferenceName ;
      private string[] P000G2_A209WWPFormTitle ;
      private DateTime[] P000G2_A231WWPFormDate ;
      private bool[] P000G2_A232WWPFormIsWizard ;
      private short[] P000G2_A216WWPFormResume ;
      private string[] P000G2_A235WWPFormResumeMessage ;
      private string[] P000G2_A233WWPFormValidations ;
      private bool[] P000G2_A234WWPFormInstantiated ;
      private short[] P000G2_A240WWPFormType ;
      private string[] P000G2_A241WWPFormSectionRefElements ;
      private bool[] P000G2_A242WWPFormIsForDynamicValidations ;
      private short[] P000G2_A206WWPFormId ;
      private SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem Gxm1sdt_locationdynamicform ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> aP0_Gxm2rootcol ;
   }

   public class dp_locationdynamicform__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("AV8Udparg3",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.LocationId, T1.LocationDynamicFormId, T1.OrganisationId, T1.WWPFormVersionNumber, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, T1.WWPFormId FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE T1.LocationId = :AV8Udparg3 ORDER BY T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                return;
       }
    }

 }

}
