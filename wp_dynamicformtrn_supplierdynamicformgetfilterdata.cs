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
   public class wp_dynamicformtrn_supplierdynamicformgetfilterdata : GXProcedure
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
            return "wp_dynamicform_Services_Execute" ;
         }

      }

      public wp_dynamicformtrn_supplierdynamicformgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_dynamicformtrn_supplierdynamicformgetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_SUPPLIERGENCOMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("WP_DynamicFormTrn_SupplierDynamicFormGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WP_DynamicFormTrn_SupplierDynamicFormGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WP_DynamicFormTrn_SupplierDynamicFormGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV46TFSupplierGenCompanyName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV47TFSupplierGenCompanyName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV10TFWWPFormTitle = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV11TFWWPFormTitle_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV14TFWWPFormDate = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV15TFWWPFormDate_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV16TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV17TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV18TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV19TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV43WWPFormType = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV44WWPFormIsForDynamicValidations = BooleanUtil.Val( AV34GridStateFilterValue.gxTpr_Value);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV46TFSupplierGenCompanyName = AV20SearchTxt;
         AV47TFSupplierGenCompanyName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47TFSupplierGenCompanyName_Sel ,
                                              AV46TFSupplierGenCompanyName ,
                                              AV11TFWWPFormTitle_Sel ,
                                              AV10TFWWPFormTitle ,
                                              AV14TFWWPFormDate ,
                                              AV15TFWWPFormDate_To ,
                                              AV16TFWWPFormVersionNumber ,
                                              AV17TFWWPFormVersionNumber_To ,
                                              AV45SupplierGenId ,
                                              A44SupplierGenCompanyName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              A42SupplierGenId ,
                                              AV42FilterFullText ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV18TFWWPFormLatestVersionNumber ,
                                              AV19TFWWPFormLatestVersionNumber_To ,
                                              AV43WWPFormType ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV46TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV46TFSupplierGenCompanyName), "%", "");
         lV10TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV10TFWWPFormTitle), "%", "");
         /* Using cursor P00FC2 */
         pr_default.execute(0, new Object[] {AV43WWPFormType, lV46TFSupplierGenCompanyName, AV47TFSupplierGenCompanyName_Sel, lV10TFWWPFormTitle, AV11TFWWPFormTitle_Sel, AV14TFWWPFormDate, AV15TFWWPFormDate_To, AV16TFWWPFormVersionNumber, AV17TFWWPFormVersionNumber_To, AV45SupplierGenId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFC2 = false;
            A240WWPFormType = P00FC2_A240WWPFormType[0];
            A44SupplierGenCompanyName = P00FC2_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P00FC2_A42SupplierGenId[0];
            A231WWPFormDate = P00FC2_A231WWPFormDate[0];
            A207WWPFormVersionNumber = P00FC2_A207WWPFormVersionNumber[0];
            A209WWPFormTitle = P00FC2_A209WWPFormTitle[0];
            A206WWPFormId = P00FC2_A206WWPFormId[0];
            A616SupplierDynamicFormId = P00FC2_A616SupplierDynamicFormId[0];
            A44SupplierGenCompanyName = P00FC2_A44SupplierGenCompanyName[0];
            A240WWPFormType = P00FC2_A240WWPFormType[0];
            A231WWPFormDate = P00FC2_A231WWPFormDate[0];
            A209WWPFormTitle = P00FC2_A209WWPFormTitle[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A44SupplierGenCompanyName) , StringUtil.PadR( "%" + StringUtil.Lower( AV42FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV42FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV42FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV42FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV18TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV18TFWWPFormLatestVersionNumber ) ) )
               {
                  if ( (0==AV19TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV19TFWWPFormLatestVersionNumber_To ) ) )
                  {
                     W240WWPFormType = A240WWPFormType;
                     AV30count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( P00FC2_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00FC2_A44SupplierGenCompanyName[0], A44SupplierGenCompanyName) == 0 ) )
                     {
                        BRKFC2 = false;
                        A42SupplierGenId = P00FC2_A42SupplierGenId[0];
                        A207WWPFormVersionNumber = P00FC2_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00FC2_A206WWPFormId[0];
                        A616SupplierDynamicFormId = P00FC2_A616SupplierDynamicFormId[0];
                        AV30count = (long)(AV30count+1);
                        BRKFC2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV21SkipItems) )
                     {
                        AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) ? "<#Empty#>" : A44SupplierGenCompanyName);
                        AV26Options.Add(AV25Option, 0);
                        AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV26Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV21SkipItems = (short)(AV21SkipItems-1);
                     }
                     A240WWPFormType = W240WWPFormType;
                  }
               }
            }
            if ( ! BRKFC2 )
            {
               BRKFC2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV10TFWWPFormTitle = AV20SearchTxt;
         AV11TFWWPFormTitle_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47TFSupplierGenCompanyName_Sel ,
                                              AV46TFSupplierGenCompanyName ,
                                              AV11TFWWPFormTitle_Sel ,
                                              AV10TFWWPFormTitle ,
                                              AV14TFWWPFormDate ,
                                              AV15TFWWPFormDate_To ,
                                              AV16TFWWPFormVersionNumber ,
                                              AV17TFWWPFormVersionNumber_To ,
                                              AV45SupplierGenId ,
                                              A44SupplierGenCompanyName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              A42SupplierGenId ,
                                              AV42FilterFullText ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV18TFWWPFormLatestVersionNumber ,
                                              AV19TFWWPFormLatestVersionNumber_To ,
                                              AV43WWPFormType ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV46TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV46TFSupplierGenCompanyName), "%", "");
         lV10TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV10TFWWPFormTitle), "%", "");
         /* Using cursor P00FC3 */
         pr_default.execute(1, new Object[] {AV43WWPFormType, lV46TFSupplierGenCompanyName, AV47TFSupplierGenCompanyName_Sel, lV10TFWWPFormTitle, AV11TFWWPFormTitle_Sel, AV14TFWWPFormDate, AV15TFWWPFormDate_To, AV16TFWWPFormVersionNumber, AV17TFWWPFormVersionNumber_To, AV45SupplierGenId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKFC4 = false;
            A240WWPFormType = P00FC3_A240WWPFormType[0];
            A209WWPFormTitle = P00FC3_A209WWPFormTitle[0];
            A42SupplierGenId = P00FC3_A42SupplierGenId[0];
            A231WWPFormDate = P00FC3_A231WWPFormDate[0];
            A207WWPFormVersionNumber = P00FC3_A207WWPFormVersionNumber[0];
            A44SupplierGenCompanyName = P00FC3_A44SupplierGenCompanyName[0];
            A206WWPFormId = P00FC3_A206WWPFormId[0];
            A616SupplierDynamicFormId = P00FC3_A616SupplierDynamicFormId[0];
            A44SupplierGenCompanyName = P00FC3_A44SupplierGenCompanyName[0];
            A240WWPFormType = P00FC3_A240WWPFormType[0];
            A209WWPFormTitle = P00FC3_A209WWPFormTitle[0];
            A231WWPFormDate = P00FC3_A231WWPFormDate[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A44SupplierGenCompanyName) , StringUtil.PadR( "%" + StringUtil.Lower( AV42FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV42FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV42FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV42FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV18TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV18TFWWPFormLatestVersionNumber ) ) )
               {
                  if ( (0==AV19TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV19TFWWPFormLatestVersionNumber_To ) ) )
                  {
                     W240WWPFormType = A240WWPFormType;
                     AV30count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( P00FC3_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00FC3_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
                     {
                        BRKFC4 = false;
                        A42SupplierGenId = P00FC3_A42SupplierGenId[0];
                        A207WWPFormVersionNumber = P00FC3_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00FC3_A206WWPFormId[0];
                        A616SupplierDynamicFormId = P00FC3_A616SupplierDynamicFormId[0];
                        AV30count = (long)(AV30count+1);
                        BRKFC4 = true;
                        pr_default.readNext(1);
                     }
                     if ( (0==AV21SkipItems) )
                     {
                        AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
                        AV26Options.Add(AV25Option, 0);
                        AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV26Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV21SkipItems = (short)(AV21SkipItems-1);
                     }
                     A240WWPFormType = W240WWPFormType;
                  }
               }
            }
            if ( ! BRKFC4 )
            {
               BRKFC4 = true;
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV34GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV42FilterFullText = "";
         AV46TFSupplierGenCompanyName = "";
         AV47TFSupplierGenCompanyName_Sel = "";
         AV10TFWWPFormTitle = "";
         AV11TFWWPFormTitle_Sel = "";
         AV14TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV15TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         lV46TFSupplierGenCompanyName = "";
         lV10TFWWPFormTitle = "";
         AV45SupplierGenId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A42SupplierGenId = Guid.Empty;
         P00FC2_A240WWPFormType = new short[1] ;
         P00FC2_A44SupplierGenCompanyName = new string[] {""} ;
         P00FC2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00FC2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00FC2_A207WWPFormVersionNumber = new short[1] ;
         P00FC2_A209WWPFormTitle = new string[] {""} ;
         P00FC2_A206WWPFormId = new short[1] ;
         P00FC2_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         A616SupplierDynamicFormId = Guid.Empty;
         AV25Option = "";
         P00FC3_A240WWPFormType = new short[1] ;
         P00FC3_A209WWPFormTitle = new string[] {""} ;
         P00FC3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00FC3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00FC3_A207WWPFormVersionNumber = new short[1] ;
         P00FC3_A44SupplierGenCompanyName = new string[] {""} ;
         P00FC3_A206WWPFormId = new short[1] ;
         P00FC3_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformtrn_supplierdynamicformgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00FC2_A240WWPFormType, P00FC2_A44SupplierGenCompanyName, P00FC2_A42SupplierGenId, P00FC2_A231WWPFormDate, P00FC2_A207WWPFormVersionNumber, P00FC2_A209WWPFormTitle, P00FC2_A206WWPFormId, P00FC2_A616SupplierDynamicFormId
               }
               , new Object[] {
               P00FC3_A240WWPFormType, P00FC3_A209WWPFormTitle, P00FC3_A42SupplierGenId, P00FC3_A231WWPFormDate, P00FC3_A207WWPFormVersionNumber, P00FC3_A44SupplierGenCompanyName, P00FC3_A206WWPFormId, P00FC3_A616SupplierDynamicFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private short AV16TFWWPFormVersionNumber ;
      private short AV17TFWWPFormVersionNumber_To ;
      private short AV18TFWWPFormLatestVersionNumber ;
      private short AV19TFWWPFormLatestVersionNumber_To ;
      private short AV43WWPFormType ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short W240WWPFormType ;
      private short GXt_int1 ;
      private int AV48GXV1 ;
      private long AV30count ;
      private DateTime AV14TFWWPFormDate ;
      private DateTime AV15TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV44WWPFormIsForDynamicValidations ;
      private bool BRKFC2 ;
      private bool BRKFC4 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV46TFSupplierGenCompanyName ;
      private string AV47TFSupplierGenCompanyName_Sel ;
      private string AV10TFWWPFormTitle ;
      private string AV11TFWWPFormTitle_Sel ;
      private string lV46TFSupplierGenCompanyName ;
      private string lV10TFWWPFormTitle ;
      private string A44SupplierGenCompanyName ;
      private string A209WWPFormTitle ;
      private string AV25Option ;
      private Guid AV45SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid A616SupplierDynamicFormId ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV33GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00FC2_A240WWPFormType ;
      private string[] P00FC2_A44SupplierGenCompanyName ;
      private Guid[] P00FC2_A42SupplierGenId ;
      private DateTime[] P00FC2_A231WWPFormDate ;
      private short[] P00FC2_A207WWPFormVersionNumber ;
      private string[] P00FC2_A209WWPFormTitle ;
      private short[] P00FC2_A206WWPFormId ;
      private Guid[] P00FC2_A616SupplierDynamicFormId ;
      private short[] P00FC3_A240WWPFormType ;
      private string[] P00FC3_A209WWPFormTitle ;
      private Guid[] P00FC3_A42SupplierGenId ;
      private DateTime[] P00FC3_A231WWPFormDate ;
      private short[] P00FC3_A207WWPFormVersionNumber ;
      private string[] P00FC3_A44SupplierGenCompanyName ;
      private short[] P00FC3_A206WWPFormId ;
      private Guid[] P00FC3_A616SupplierDynamicFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_dynamicformtrn_supplierdynamicformgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FC2( IGxContext context ,
                                             string AV47TFSupplierGenCompanyName_Sel ,
                                             string AV46TFSupplierGenCompanyName ,
                                             string AV11TFWWPFormTitle_Sel ,
                                             string AV10TFWWPFormTitle ,
                                             DateTime AV14TFWWPFormDate ,
                                             DateTime AV15TFWWPFormDate_To ,
                                             short AV16TFWWPFormVersionNumber ,
                                             short AV17TFWWPFormVersionNumber_To ,
                                             Guid AV45SupplierGenId ,
                                             string A44SupplierGenCompanyName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             Guid A42SupplierGenId ,
                                             string AV42FilterFullText ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV18TFWWPFormLatestVersionNumber ,
                                             short AV19TFWWPFormLatestVersionNumber_To ,
                                             short AV43WWPFormType ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.WWPFormType, T2.SupplierGenCompanyName, T1.SupplierGenId, T3.WWPFormDate, T1.WWPFormVersionNumber, T3.WWPFormTitle, T1.WWPFormId, T1.SupplierDynamicFormId FROM ((Trn_SupplierDynamicForm T1 INNER JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = T1.WWPFormId AND T3.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T3.WWPFormType = :AV43WWPFormType)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV46TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV47TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV47TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV47TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle like :lV10TFWWPFormTitle)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV11TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle = ( :AV11TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV14TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate >= :AV14TFWWPFormDate)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate <= :AV15TFWWPFormDate_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV16TFWWPFormVersionNumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV16TFWWPFormVersionNumber)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV17TFWWPFormVersionNumber_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV17TFWWPFormVersionNumber_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Guid.Empty==AV45SupplierGenId) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenId = :AV45SupplierGenId)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.WWPFormType, T2.SupplierGenCompanyName";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00FC3( IGxContext context ,
                                             string AV47TFSupplierGenCompanyName_Sel ,
                                             string AV46TFSupplierGenCompanyName ,
                                             string AV11TFWWPFormTitle_Sel ,
                                             string AV10TFWWPFormTitle ,
                                             DateTime AV14TFWWPFormDate ,
                                             DateTime AV15TFWWPFormDate_To ,
                                             short AV16TFWWPFormVersionNumber ,
                                             short AV17TFWWPFormVersionNumber_To ,
                                             Guid AV45SupplierGenId ,
                                             string A44SupplierGenCompanyName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             Guid A42SupplierGenId ,
                                             string AV42FilterFullText ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV18TFWWPFormLatestVersionNumber ,
                                             short AV19TFWWPFormLatestVersionNumber_To ,
                                             short AV43WWPFormType ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T3.WWPFormType, T3.WWPFormTitle, T1.SupplierGenId, T3.WWPFormDate, T1.WWPFormVersionNumber, T2.SupplierGenCompanyName, T1.WWPFormId, T1.SupplierDynamicFormId FROM ((Trn_SupplierDynamicForm T1 INNER JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = T1.WWPFormId AND T3.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T3.WWPFormType = :AV43WWPFormType)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV46TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV47TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV47TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV47TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle like :lV10TFWWPFormTitle)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV11TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle = ( :AV11TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV14TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate >= :AV14TFWWPFormDate)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate <= :AV15TFWWPFormDate_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV16TFWWPFormVersionNumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV16TFWWPFormVersionNumber)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV17TFWWPFormVersionNumber_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV17TFWWPFormVersionNumber_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (Guid.Empty==AV45SupplierGenId) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenId = :AV45SupplierGenId)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.WWPFormType, T3.WWPFormTitle";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00FC2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (Guid)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (short)dynConstraints[12] , (Guid)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] );
               case 1 :
                     return conditional_P00FC3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (Guid)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (short)dynConstraints[12] , (Guid)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] );
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
          Object[] prmP00FC2;
          prmP00FC2 = new Object[] {
          new ParDef("AV43WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV46TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV47TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV10TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV11TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV15TFWWPFormDate_To",GXType.DateTime,8,5) ,
          new ParDef("AV16TFWWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV17TFWWPFormVersionNumber_To",GXType.Int16,4,0) ,
          new ParDef("AV45SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00FC3;
          prmP00FC3 = new Object[] {
          new ParDef("AV43WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV46TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV47TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV10TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV11TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV15TFWWPFormDate_To",GXType.DateTime,8,5) ,
          new ParDef("AV16TFWWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV17TFWWPFormVersionNumber_To",GXType.Int16,4,0) ,
          new ParDef("AV45SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
