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
   public class trn_productservicewwgetfilterdata : GXProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_productserviceww_Services_Execute" ;
         }

      }

      public trn_productservicewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservicewwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICETILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICETILENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("Trn_ProductServiceWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_ProductServiceWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Trn_ProductServiceWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV11TFProductServiceName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV12TFProductServiceName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME") == 0 )
            {
               AV44TFProductServiceTileName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME_SEL") == 0 )
            {
               AV45TFProductServiceTileName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICECLASS_SEL") == 0 )
            {
               AV48TFProductServiceClass_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV49TFProductServiceClass_Sels.FromJSonString(AV48TFProductServiceClass_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFProductServiceName = AV15SearchTxt;
         AV12TFProductServiceName_Sel = "";
         AV58Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV59Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV60Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV61Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV62Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV63Trn_productservicewwds_6_tfproductserviceclass_sels = AV49TFProductServiceClass_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A370ProductServiceClass ,
                                              AV63Trn_productservicewwds_6_tfproductserviceclass_sels ,
                                              AV60Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV59Trn_productservicewwds_2_tfproductservicename ,
                                              AV62Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV61Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV63Trn_productservicewwds_6_tfproductserviceclass_sels.Count ,
                                              AV50LocationId ,
                                              A59ProductServiceName ,
                                              A266ProductServiceTileName ,
                                              A29LocationId ,
                                              AV58Trn_productservicewwds_1_filterfulltext ,
                                              A11OrganisationId ,
                                              AV55OrganisationId } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV59Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV59Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV61Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV61Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         /* Using cursor P006D2 */
         pr_default.execute(0, new Object[] {AV55OrganisationId, lV59Trn_productservicewwds_2_tfproductservicename, AV60Trn_productservicewwds_3_tfproductservicename_sel, lV61Trn_productservicewwds_4_tfproductservicetilename, AV62Trn_productservicewwds_5_tfproductservicetilename_sel, AV50LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6D2 = false;
            A59ProductServiceName = P006D2_A59ProductServiceName[0];
            A29LocationId = P006D2_A29LocationId[0];
            A11OrganisationId = P006D2_A11OrganisationId[0];
            A266ProductServiceTileName = P006D2_A266ProductServiceTileName[0];
            A370ProductServiceClass = P006D2_A370ProductServiceClass[0];
            A58ProductServiceId = P006D2_A58ProductServiceId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A59ProductServiceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A266ProductServiceTileName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "select category", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A370ProductServiceClass)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my care", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Care", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Services", "")) == 0 ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006D2_A59ProductServiceName[0], A59ProductServiceName) == 0 ) )
               {
                  BRK6D2 = false;
                  A29LocationId = P006D2_A29LocationId[0];
                  A11OrganisationId = P006D2_A11OrganisationId[0];
                  A58ProductServiceId = P006D2_A58ProductServiceId[0];
                  AV25count = (long)(AV25count+1);
                  BRK6D2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) ? "<#Empty#>" : A59ProductServiceName);
                  AV21Options.Add(AV20Option, 0);
                  AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV21Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV16SkipItems = (short)(AV16SkipItems-1);
               }
            }
            if ( ! BRK6D2 )
            {
               BRK6D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRODUCTSERVICETILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV44TFProductServiceTileName = AV15SearchTxt;
         AV45TFProductServiceTileName_Sel = "";
         AV58Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV59Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV60Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV61Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV62Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV63Trn_productservicewwds_6_tfproductserviceclass_sels = AV49TFProductServiceClass_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A370ProductServiceClass ,
                                              AV63Trn_productservicewwds_6_tfproductserviceclass_sels ,
                                              AV60Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV59Trn_productservicewwds_2_tfproductservicename ,
                                              AV62Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV61Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV63Trn_productservicewwds_6_tfproductserviceclass_sels.Count ,
                                              AV50LocationId ,
                                              A59ProductServiceName ,
                                              A266ProductServiceTileName ,
                                              A29LocationId ,
                                              AV58Trn_productservicewwds_1_filterfulltext ,
                                              A11OrganisationId ,
                                              AV55OrganisationId } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV59Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV59Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV61Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV61Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         /* Using cursor P006D3 */
         pr_default.execute(1, new Object[] {AV55OrganisationId, lV59Trn_productservicewwds_2_tfproductservicename, AV60Trn_productservicewwds_3_tfproductservicename_sel, lV61Trn_productservicewwds_4_tfproductservicetilename, AV62Trn_productservicewwds_5_tfproductservicetilename_sel, AV50LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6D4 = false;
            A11OrganisationId = P006D3_A11OrganisationId[0];
            A266ProductServiceTileName = P006D3_A266ProductServiceTileName[0];
            A29LocationId = P006D3_A29LocationId[0];
            A59ProductServiceName = P006D3_A59ProductServiceName[0];
            A370ProductServiceClass = P006D3_A370ProductServiceClass[0];
            A58ProductServiceId = P006D3_A58ProductServiceId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A59ProductServiceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A266ProductServiceTileName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "select category", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A370ProductServiceClass)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my care", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Care", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "my services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A370ProductServiceClass, context.GetMessage( "My Services", "")) == 0 ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006D3_A266ProductServiceTileName[0], A266ProductServiceTileName) == 0 ) )
               {
                  BRK6D4 = false;
                  A11OrganisationId = P006D3_A11OrganisationId[0];
                  A29LocationId = P006D3_A29LocationId[0];
                  A58ProductServiceId = P006D3_A58ProductServiceId[0];
                  AV25count = (long)(AV25count+1);
                  BRK6D4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A266ProductServiceTileName)) ? "<#Empty#>" : A266ProductServiceTileName);
                  AV21Options.Add(AV20Option, 0);
                  AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV21Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV16SkipItems = (short)(AV16SkipItems-1);
               }
            }
            if ( ! BRK6D4 )
            {
               BRK6D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV29GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFProductServiceName = "";
         AV12TFProductServiceName_Sel = "";
         AV44TFProductServiceTileName = "";
         AV45TFProductServiceTileName_Sel = "";
         AV48TFProductServiceClass_SelsJson = "";
         AV49TFProductServiceClass_Sels = new GxSimpleCollection<string>();
         AV58Trn_productservicewwds_1_filterfulltext = "";
         AV59Trn_productservicewwds_2_tfproductservicename = "";
         AV60Trn_productservicewwds_3_tfproductservicename_sel = "";
         AV61Trn_productservicewwds_4_tfproductservicetilename = "";
         AV62Trn_productservicewwds_5_tfproductservicetilename_sel = "";
         AV63Trn_productservicewwds_6_tfproductserviceclass_sels = new GxSimpleCollection<string>();
         lV59Trn_productservicewwds_2_tfproductservicename = "";
         lV61Trn_productservicewwds_4_tfproductservicetilename = "";
         A370ProductServiceClass = "";
         AV50LocationId = Guid.Empty;
         A59ProductServiceName = "";
         A266ProductServiceTileName = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV55OrganisationId = Guid.Empty;
         P006D2_A59ProductServiceName = new string[] {""} ;
         P006D2_A29LocationId = new Guid[] {Guid.Empty} ;
         P006D2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006D2_A266ProductServiceTileName = new string[] {""} ;
         P006D2_A370ProductServiceClass = new string[] {""} ;
         P006D2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         AV20Option = "";
         P006D3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006D3_A266ProductServiceTileName = new string[] {""} ;
         P006D3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006D3_A59ProductServiceName = new string[] {""} ;
         P006D3_A370ProductServiceClass = new string[] {""} ;
         P006D3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservicewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006D2_A59ProductServiceName, P006D2_A29LocationId, P006D2_A11OrganisationId, P006D2_A266ProductServiceTileName, P006D2_A370ProductServiceClass, P006D2_A58ProductServiceId
               }
               , new Object[] {
               P006D3_A11OrganisationId, P006D3_A266ProductServiceTileName, P006D3_A29LocationId, P006D3_A59ProductServiceName, P006D3_A370ProductServiceClass, P006D3_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV56GXV1 ;
      private int AV63Trn_productservicewwds_6_tfproductserviceclass_sels_Count ;
      private long AV25count ;
      private string AV44TFProductServiceTileName ;
      private string AV45TFProductServiceTileName_Sel ;
      private string AV61Trn_productservicewwds_4_tfproductservicetilename ;
      private string AV62Trn_productservicewwds_5_tfproductservicetilename_sel ;
      private string lV61Trn_productservicewwds_4_tfproductservicetilename ;
      private string A266ProductServiceTileName ;
      private bool returnInSub ;
      private bool BRK6D2 ;
      private bool BRK6D4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV48TFProductServiceClass_SelsJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFProductServiceName ;
      private string AV12TFProductServiceName_Sel ;
      private string AV58Trn_productservicewwds_1_filterfulltext ;
      private string AV59Trn_productservicewwds_2_tfproductservicename ;
      private string AV60Trn_productservicewwds_3_tfproductservicename_sel ;
      private string lV59Trn_productservicewwds_2_tfproductservicename ;
      private string A370ProductServiceClass ;
      private string A59ProductServiceName ;
      private string AV20Option ;
      private Guid AV50LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV55OrganisationId ;
      private Guid A58ProductServiceId ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV28GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GxSimpleCollection<string> AV49TFProductServiceClass_Sels ;
      private GxSimpleCollection<string> AV63Trn_productservicewwds_6_tfproductserviceclass_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006D2_A59ProductServiceName ;
      private Guid[] P006D2_A29LocationId ;
      private Guid[] P006D2_A11OrganisationId ;
      private string[] P006D2_A266ProductServiceTileName ;
      private string[] P006D2_A370ProductServiceClass ;
      private Guid[] P006D2_A58ProductServiceId ;
      private Guid[] P006D3_A11OrganisationId ;
      private string[] P006D3_A266ProductServiceTileName ;
      private Guid[] P006D3_A29LocationId ;
      private string[] P006D3_A59ProductServiceName ;
      private string[] P006D3_A370ProductServiceClass ;
      private Guid[] P006D3_A58ProductServiceId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_productservicewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006D2( IGxContext context ,
                                             string A370ProductServiceClass ,
                                             GxSimpleCollection<string> AV63Trn_productservicewwds_6_tfproductserviceclass_sels ,
                                             string AV60Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV59Trn_productservicewwds_2_tfproductservicename ,
                                             string AV62Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV61Trn_productservicewwds_4_tfproductservicetilename ,
                                             int AV63Trn_productservicewwds_6_tfproductserviceclass_sels_Count ,
                                             Guid AV50LocationId ,
                                             string A59ProductServiceName ,
                                             string A266ProductServiceTileName ,
                                             Guid A29LocationId ,
                                             string AV58Trn_productservicewwds_1_filterfulltext ,
                                             Guid A11OrganisationId ,
                                             Guid AV55OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ProductServiceName, LocationId, OrganisationId, ProductServiceTileName, ProductServiceClass, ProductServiceId FROM Trn_ProductService";
         AddWhere(sWhereString, "(OrganisationId = :AV55OrganisationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceName like :lV59Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV60Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceName = ( :AV60Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName like :lV61Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName = ( :AV62Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTileName))=0))");
         }
         if ( AV63Trn_productservicewwds_6_tfproductserviceclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_productservicewwds_6_tfproductserviceclass_sels, "ProductServiceClass IN (", ")")+")");
         }
         if ( ! (Guid.Empty==AV50LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV50LocationId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006D3( IGxContext context ,
                                             string A370ProductServiceClass ,
                                             GxSimpleCollection<string> AV63Trn_productservicewwds_6_tfproductserviceclass_sels ,
                                             string AV60Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV59Trn_productservicewwds_2_tfproductservicename ,
                                             string AV62Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV61Trn_productservicewwds_4_tfproductservicetilename ,
                                             int AV63Trn_productservicewwds_6_tfproductserviceclass_sels_Count ,
                                             Guid AV50LocationId ,
                                             string A59ProductServiceName ,
                                             string A266ProductServiceTileName ,
                                             Guid A29LocationId ,
                                             string AV58Trn_productservicewwds_1_filterfulltext ,
                                             Guid A11OrganisationId ,
                                             Guid AV55OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ProductServiceTileName, LocationId, ProductServiceName, ProductServiceClass, ProductServiceId FROM Trn_ProductService";
         AddWhere(sWhereString, "(OrganisationId = :AV55OrganisationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceName like :lV59Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV60Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceName = ( :AV60Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName like :lV61Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName = ( :AV62Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTileName))=0))");
         }
         if ( AV63Trn_productservicewwds_6_tfproductserviceclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_productservicewwds_6_tfproductserviceclass_sels, "ProductServiceClass IN (", ")")+")");
         }
         if ( ! (Guid.Empty==AV50LocationId) )
         {
            AddWhere(sWhereString, "(LocationId = :AV50LocationId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceTileName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (Guid)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (string)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 1 :
                     return conditional_P006D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (Guid)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (string)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP006D2;
          prmP006D2 = new Object[] {
          new ParDef("AV55OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV59Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV62Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("AV50LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006D3;
          prmP006D3 = new Object[] {
          new ParDef("AV55OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV59Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV62Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("AV50LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
       }
    }

 }

}
