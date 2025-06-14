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
   public class trn_dynamictranslationwwgetfilterdata : GXProcedure
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
            return "trn_dynamictranslationww_Services_Execute" ;
         }

      }

      public trn_dynamictranslationwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_dynamictranslationwwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DYNAMICTRANSLATIONTRNNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADDYNAMICTRANSLATIONTRNNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DYNAMICTRANSLATIONATTRIBUTENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADDYNAMICTRANSLATIONATTRIBUTENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DYNAMICTRANSLATIONENGLISH") == 0 )
         {
            /* Execute user subroutine: 'LOADDYNAMICTRANSLATIONENGLISHOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DYNAMICTRANSLATIONDUTCH") == 0 )
         {
            /* Execute user subroutine: 'LOADDYNAMICTRANSLATIONDUTCHOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("Trn_DynamicTranslationWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_DynamicTranslationWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Trn_DynamicTranslationWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONTRNNAME") == 0 )
            {
               AV11TFDynamicTranslationTrnName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONTRNNAME_SEL") == 0 )
            {
               AV12TFDynamicTranslationTrnName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONATTRIBUTENAME") == 0 )
            {
               AV13TFDynamicTranslationAttributeName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONATTRIBUTENAME_SEL") == 0 )
            {
               AV14TFDynamicTranslationAttributeName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONENGLISH") == 0 )
            {
               AV15TFDynamicTranslationEnglish = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONENGLISH_SEL") == 0 )
            {
               AV16TFDynamicTranslationEnglish_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONDUTCH") == 0 )
            {
               AV17TFDynamicTranslationDutch = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDYNAMICTRANSLATIONDUTCH_SEL") == 0 )
            {
               AV18TFDynamicTranslationDutch_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDYNAMICTRANSLATIONTRNNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFDynamicTranslationTrnName = AV19SearchTxt;
         AV12TFDynamicTranslationTrnName_Sel = "";
         AV44Trn_dynamictranslationwwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = AV11TFDynamicTranslationTrnName;
         AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel = AV12TFDynamicTranslationTrnName_Sel;
         AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = AV13TFDynamicTranslationAttributeName;
         AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel = AV14TFDynamicTranslationAttributeName_Sel;
         AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = AV15TFDynamicTranslationEnglish;
         AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel = AV16TFDynamicTranslationEnglish_Sel;
         AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = AV17TFDynamicTranslationDutch;
         AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel = AV18TFDynamicTranslationDutch_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                              AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                              AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                              AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                              AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                              AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                              AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                              AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                              AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                              A579DynamicTranslationTrnName ,
                                              A581DynamicTranslationAttributeNam ,
                                              A582DynamicTranslationEnglish ,
                                              A583DynamicTranslationDutch } ,
                                              new int[]{
                                              }
         });
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname), "%", "");
         lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename), "%", "");
         lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish), "%", "");
         lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch), "%", "");
         /* Using cursor P00DR2 */
         pr_default.execute(0, new Object[] {lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname, AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename, AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish, AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch, AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDR2 = false;
            A579DynamicTranslationTrnName = P00DR2_A579DynamicTranslationTrnName[0];
            A583DynamicTranslationDutch = P00DR2_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00DR2_A582DynamicTranslationEnglish[0];
            A581DynamicTranslationAttributeNam = P00DR2_A581DynamicTranslationAttributeNam[0];
            A578DynamicTranslationId = P00DR2_A578DynamicTranslationId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DR2_A579DynamicTranslationTrnName[0], A579DynamicTranslationTrnName) == 0 ) )
            {
               BRKDR2 = false;
               A578DynamicTranslationId = P00DR2_A578DynamicTranslationId[0];
               AV29count = (long)(AV29count+1);
               BRKDR2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A579DynamicTranslationTrnName)) ? "<#Empty#>" : A579DynamicTranslationTrnName);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKDR2 )
            {
               BRKDR2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDYNAMICTRANSLATIONATTRIBUTENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFDynamicTranslationAttributeName = AV19SearchTxt;
         AV14TFDynamicTranslationAttributeName_Sel = "";
         AV44Trn_dynamictranslationwwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = AV11TFDynamicTranslationTrnName;
         AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel = AV12TFDynamicTranslationTrnName_Sel;
         AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = AV13TFDynamicTranslationAttributeName;
         AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel = AV14TFDynamicTranslationAttributeName_Sel;
         AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = AV15TFDynamicTranslationEnglish;
         AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel = AV16TFDynamicTranslationEnglish_Sel;
         AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = AV17TFDynamicTranslationDutch;
         AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel = AV18TFDynamicTranslationDutch_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                              AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                              AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                              AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                              AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                              AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                              AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                              AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                              AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                              A579DynamicTranslationTrnName ,
                                              A581DynamicTranslationAttributeNam ,
                                              A582DynamicTranslationEnglish ,
                                              A583DynamicTranslationDutch } ,
                                              new int[]{
                                              }
         });
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname), "%", "");
         lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename), "%", "");
         lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish), "%", "");
         lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch), "%", "");
         /* Using cursor P00DR3 */
         pr_default.execute(1, new Object[] {lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname, AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename, AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish, AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch, AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDR4 = false;
            A581DynamicTranslationAttributeNam = P00DR3_A581DynamicTranslationAttributeNam[0];
            A583DynamicTranslationDutch = P00DR3_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00DR3_A582DynamicTranslationEnglish[0];
            A579DynamicTranslationTrnName = P00DR3_A579DynamicTranslationTrnName[0];
            A578DynamicTranslationId = P00DR3_A578DynamicTranslationId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00DR3_A581DynamicTranslationAttributeNam[0], A581DynamicTranslationAttributeNam) == 0 ) )
            {
               BRKDR4 = false;
               A578DynamicTranslationId = P00DR3_A578DynamicTranslationId[0];
               AV29count = (long)(AV29count+1);
               BRKDR4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A581DynamicTranslationAttributeNam)) ? "<#Empty#>" : A581DynamicTranslationAttributeNam);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKDR4 )
            {
               BRKDR4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADDYNAMICTRANSLATIONENGLISHOPTIONS' Routine */
         returnInSub = false;
         AV15TFDynamicTranslationEnglish = AV19SearchTxt;
         AV16TFDynamicTranslationEnglish_Sel = "";
         AV44Trn_dynamictranslationwwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = AV11TFDynamicTranslationTrnName;
         AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel = AV12TFDynamicTranslationTrnName_Sel;
         AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = AV13TFDynamicTranslationAttributeName;
         AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel = AV14TFDynamicTranslationAttributeName_Sel;
         AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = AV15TFDynamicTranslationEnglish;
         AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel = AV16TFDynamicTranslationEnglish_Sel;
         AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = AV17TFDynamicTranslationDutch;
         AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel = AV18TFDynamicTranslationDutch_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                              AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                              AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                              AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                              AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                              AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                              AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                              AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                              AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                              A579DynamicTranslationTrnName ,
                                              A581DynamicTranslationAttributeNam ,
                                              A582DynamicTranslationEnglish ,
                                              A583DynamicTranslationDutch } ,
                                              new int[]{
                                              }
         });
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname), "%", "");
         lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename), "%", "");
         lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish), "%", "");
         lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch), "%", "");
         /* Using cursor P00DR4 */
         pr_default.execute(2, new Object[] {lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname, AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename, AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish, AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch, AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKDR6 = false;
            A582DynamicTranslationEnglish = P00DR4_A582DynamicTranslationEnglish[0];
            A583DynamicTranslationDutch = P00DR4_A583DynamicTranslationDutch[0];
            A581DynamicTranslationAttributeNam = P00DR4_A581DynamicTranslationAttributeNam[0];
            A579DynamicTranslationTrnName = P00DR4_A579DynamicTranslationTrnName[0];
            A578DynamicTranslationId = P00DR4_A578DynamicTranslationId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00DR4_A582DynamicTranslationEnglish[0], A582DynamicTranslationEnglish) == 0 ) )
            {
               BRKDR6 = false;
               A578DynamicTranslationId = P00DR4_A578DynamicTranslationId[0];
               AV29count = (long)(AV29count+1);
               BRKDR6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A582DynamicTranslationEnglish)) ? "<#Empty#>" : A582DynamicTranslationEnglish);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKDR6 )
            {
               BRKDR6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADDYNAMICTRANSLATIONDUTCHOPTIONS' Routine */
         returnInSub = false;
         AV17TFDynamicTranslationDutch = AV19SearchTxt;
         AV18TFDynamicTranslationDutch_Sel = "";
         AV44Trn_dynamictranslationwwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = AV11TFDynamicTranslationTrnName;
         AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel = AV12TFDynamicTranslationTrnName_Sel;
         AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = AV13TFDynamicTranslationAttributeName;
         AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel = AV14TFDynamicTranslationAttributeName_Sel;
         AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = AV15TFDynamicTranslationEnglish;
         AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel = AV16TFDynamicTranslationEnglish_Sel;
         AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = AV17TFDynamicTranslationDutch;
         AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel = AV18TFDynamicTranslationDutch_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                              AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                              AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                              AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                              AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                              AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                              AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                              AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                              AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                              A579DynamicTranslationTrnName ,
                                              A581DynamicTranslationAttributeNam ,
                                              A582DynamicTranslationEnglish ,
                                              A583DynamicTranslationDutch } ,
                                              new int[]{
                                              }
         });
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV44Trn_dynamictranslationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext), "%", "");
         lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = StringUtil.Concat( StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname), "%", "");
         lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = StringUtil.Concat( StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename), "%", "");
         lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = StringUtil.Concat( StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish), "%", "");
         lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = StringUtil.Concat( StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch), "%", "");
         /* Using cursor P00DR5 */
         pr_default.execute(3, new Object[] {lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV44Trn_dynamictranslationwwds_1_filterfulltext, lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname, AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename, AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish, AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch, AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKDR8 = false;
            A583DynamicTranslationDutch = P00DR5_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00DR5_A582DynamicTranslationEnglish[0];
            A581DynamicTranslationAttributeNam = P00DR5_A581DynamicTranslationAttributeNam[0];
            A579DynamicTranslationTrnName = P00DR5_A579DynamicTranslationTrnName[0];
            A578DynamicTranslationId = P00DR5_A578DynamicTranslationId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DR5_A583DynamicTranslationDutch[0], A583DynamicTranslationDutch) == 0 ) )
            {
               BRKDR8 = false;
               A578DynamicTranslationId = P00DR5_A578DynamicTranslationId[0];
               AV29count = (long)(AV29count+1);
               BRKDR8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A583DynamicTranslationDutch)) ? "<#Empty#>" : A583DynamicTranslationDutch);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKDR8 )
            {
               BRKDR8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV33GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV11TFDynamicTranslationTrnName = "";
         AV12TFDynamicTranslationTrnName_Sel = "";
         AV13TFDynamicTranslationAttributeName = "";
         AV14TFDynamicTranslationAttributeName_Sel = "";
         AV15TFDynamicTranslationEnglish = "";
         AV16TFDynamicTranslationEnglish_Sel = "";
         AV17TFDynamicTranslationDutch = "";
         AV18TFDynamicTranslationDutch_Sel = "";
         AV44Trn_dynamictranslationwwds_1_filterfulltext = "";
         AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = "";
         AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel = "";
         AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = "";
         AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel = "";
         AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = "";
         AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel = "";
         AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = "";
         AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel = "";
         lV44Trn_dynamictranslationwwds_1_filterfulltext = "";
         lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname = "";
         lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename = "";
         lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish = "";
         lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch = "";
         A579DynamicTranslationTrnName = "";
         A581DynamicTranslationAttributeNam = "";
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         P00DR2_A579DynamicTranslationTrnName = new string[] {""} ;
         P00DR2_A583DynamicTranslationDutch = new string[] {""} ;
         P00DR2_A582DynamicTranslationEnglish = new string[] {""} ;
         P00DR2_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00DR2_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A578DynamicTranslationId = Guid.Empty;
         AV24Option = "";
         P00DR3_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00DR3_A583DynamicTranslationDutch = new string[] {""} ;
         P00DR3_A582DynamicTranslationEnglish = new string[] {""} ;
         P00DR3_A579DynamicTranslationTrnName = new string[] {""} ;
         P00DR3_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         P00DR4_A582DynamicTranslationEnglish = new string[] {""} ;
         P00DR4_A583DynamicTranslationDutch = new string[] {""} ;
         P00DR4_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00DR4_A579DynamicTranslationTrnName = new string[] {""} ;
         P00DR4_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         P00DR5_A583DynamicTranslationDutch = new string[] {""} ;
         P00DR5_A582DynamicTranslationEnglish = new string[] {""} ;
         P00DR5_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00DR5_A579DynamicTranslationTrnName = new string[] {""} ;
         P00DR5_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_dynamictranslationwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DR2_A579DynamicTranslationTrnName, P00DR2_A583DynamicTranslationDutch, P00DR2_A582DynamicTranslationEnglish, P00DR2_A581DynamicTranslationAttributeNam, P00DR2_A578DynamicTranslationId
               }
               , new Object[] {
               P00DR3_A581DynamicTranslationAttributeNam, P00DR3_A583DynamicTranslationDutch, P00DR3_A582DynamicTranslationEnglish, P00DR3_A579DynamicTranslationTrnName, P00DR3_A578DynamicTranslationId
               }
               , new Object[] {
               P00DR4_A582DynamicTranslationEnglish, P00DR4_A583DynamicTranslationDutch, P00DR4_A581DynamicTranslationAttributeNam, P00DR4_A579DynamicTranslationTrnName, P00DR4_A578DynamicTranslationId
               }
               , new Object[] {
               P00DR5_A583DynamicTranslationDutch, P00DR5_A582DynamicTranslationEnglish, P00DR5_A581DynamicTranslationAttributeNam, P00DR5_A579DynamicTranslationTrnName, P00DR5_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV42GXV1 ;
      private long AV29count ;
      private bool returnInSub ;
      private bool BRKDR2 ;
      private bool BRKDR4 ;
      private bool BRKDR6 ;
      private bool BRKDR8 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFDynamicTranslationTrnName ;
      private string AV12TFDynamicTranslationTrnName_Sel ;
      private string AV13TFDynamicTranslationAttributeName ;
      private string AV14TFDynamicTranslationAttributeName_Sel ;
      private string AV15TFDynamicTranslationEnglish ;
      private string AV16TFDynamicTranslationEnglish_Sel ;
      private string AV17TFDynamicTranslationDutch ;
      private string AV18TFDynamicTranslationDutch_Sel ;
      private string AV44Trn_dynamictranslationwwds_1_filterfulltext ;
      private string AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ;
      private string AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ;
      private string AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ;
      private string AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ;
      private string AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ;
      private string AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ;
      private string AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ;
      private string AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ;
      private string lV44Trn_dynamictranslationwwds_1_filterfulltext ;
      private string lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ;
      private string lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ;
      private string lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ;
      private string lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ;
      private string A579DynamicTranslationTrnName ;
      private string A581DynamicTranslationAttributeNam ;
      private string AV24Option ;
      private Guid A578DynamicTranslationId ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV32GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00DR2_A579DynamicTranslationTrnName ;
      private string[] P00DR2_A583DynamicTranslationDutch ;
      private string[] P00DR2_A582DynamicTranslationEnglish ;
      private string[] P00DR2_A581DynamicTranslationAttributeNam ;
      private Guid[] P00DR2_A578DynamicTranslationId ;
      private string[] P00DR3_A581DynamicTranslationAttributeNam ;
      private string[] P00DR3_A583DynamicTranslationDutch ;
      private string[] P00DR3_A582DynamicTranslationEnglish ;
      private string[] P00DR3_A579DynamicTranslationTrnName ;
      private Guid[] P00DR3_A578DynamicTranslationId ;
      private string[] P00DR4_A582DynamicTranslationEnglish ;
      private string[] P00DR4_A583DynamicTranslationDutch ;
      private string[] P00DR4_A581DynamicTranslationAttributeNam ;
      private string[] P00DR4_A579DynamicTranslationTrnName ;
      private Guid[] P00DR4_A578DynamicTranslationId ;
      private string[] P00DR5_A583DynamicTranslationDutch ;
      private string[] P00DR5_A582DynamicTranslationEnglish ;
      private string[] P00DR5_A581DynamicTranslationAttributeNam ;
      private string[] P00DR5_A579DynamicTranslationTrnName ;
      private Guid[] P00DR5_A578DynamicTranslationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_dynamictranslationwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DR2( IGxContext context ,
                                             string AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                             string AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                             string AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                             string AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                             string AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                             string AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                             string AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                             string AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                             string AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                             string A579DynamicTranslationTrnName ,
                                             string A581DynamicTranslationAttributeNam ,
                                             string A582DynamicTranslationEnglish ,
                                             string A583DynamicTranslationDutch )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DynamicTranslationTrnName, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationAttributeNam, DynamicTranslationId FROM Trn_DynamicTranslation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(DynamicTranslationTrnName) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationAttributeNam) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationEnglish) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationDutch) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName like :lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName = ( :AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam like :lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam = ( :AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationAttributeNam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish like :lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish = ( :AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch like :lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch = ( :AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationDutch))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DynamicTranslationTrnName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DR3( IGxContext context ,
                                             string AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                             string AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                             string AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                             string AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                             string AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                             string AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                             string AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                             string AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                             string AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                             string A579DynamicTranslationTrnName ,
                                             string A581DynamicTranslationAttributeNam ,
                                             string A582DynamicTranslationEnglish ,
                                             string A583DynamicTranslationDutch )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DynamicTranslationAttributeNam, DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationTrnName, DynamicTranslationId FROM Trn_DynamicTranslation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(DynamicTranslationTrnName) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationAttributeNam) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationEnglish) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationDutch) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName like :lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName = ( :AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam like :lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam = ( :AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationAttributeNam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish like :lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish = ( :AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch like :lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch = ( :AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationDutch))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DynamicTranslationAttributeNam";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DR4( IGxContext context ,
                                             string AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                             string AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                             string AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                             string AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                             string AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                             string AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                             string AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                             string AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                             string AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                             string A579DynamicTranslationTrnName ,
                                             string A581DynamicTranslationAttributeNam ,
                                             string A582DynamicTranslationEnglish ,
                                             string A583DynamicTranslationDutch )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationAttributeNam, DynamicTranslationTrnName, DynamicTranslationId FROM Trn_DynamicTranslation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(DynamicTranslationTrnName) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationAttributeNam) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationEnglish) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationDutch) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName like :lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName = ( :AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam like :lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam = ( :AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationAttributeNam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish like :lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish = ( :AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch like :lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch = ( :AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationDutch))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DynamicTranslationEnglish";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00DR5( IGxContext context ,
                                             string AV44Trn_dynamictranslationwwds_1_filterfulltext ,
                                             string AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel ,
                                             string AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname ,
                                             string AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel ,
                                             string AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename ,
                                             string AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel ,
                                             string AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish ,
                                             string AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel ,
                                             string AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch ,
                                             string A579DynamicTranslationTrnName ,
                                             string A581DynamicTranslationAttributeNam ,
                                             string A582DynamicTranslationEnglish ,
                                             string A583DynamicTranslationDutch )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT DynamicTranslationDutch, DynamicTranslationEnglish, DynamicTranslationAttributeNam, DynamicTranslationTrnName, DynamicTranslationId FROM Trn_DynamicTranslation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_dynamictranslationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(DynamicTranslationTrnName) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationAttributeNam) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationEnglish) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)) or ( LOWER(DynamicTranslationDutch) like '%' || LOWER(:lV44Trn_dynamictranslationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName like :lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel)) && ! ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationTrnName = ( :AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationTrnName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributename)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam like :lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel)) && ! ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationAttributeNam = ( :AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationAttributeNam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish like :lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel)) && ! ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationEnglish = ( :AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationEnglish))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)) ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch like :lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel)) && ! ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(DynamicTranslationDutch = ( :AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DynamicTranslationDutch))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DynamicTranslationDutch";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DR2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P00DR3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P00DR4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 3 :
                     return conditional_P00DR5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP00DR2;
          prmP00DR2 = new Object[] {
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish",GXType.VarChar,200,0) ,
          new ParDef("AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se",GXType.VarChar,200,0) ,
          new ParDef("lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00DR3;
          prmP00DR3 = new Object[] {
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish",GXType.VarChar,200,0) ,
          new ParDef("AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se",GXType.VarChar,200,0) ,
          new ParDef("lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00DR4;
          prmP00DR4 = new Object[] {
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish",GXType.VarChar,200,0) ,
          new ParDef("AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se",GXType.VarChar,200,0) ,
          new ParDef("lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00DR5;
          prmP00DR5 = new Object[] {
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_dynamictranslationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_dynamictranslationwwds_2_tfdynamictranslationtrnname",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_dynamictranslationwwds_3_tfdynamictranslationtrnname_se",GXType.VarChar,100,0) ,
          new ParDef("lV47Trn_dynamictranslationwwds_4_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("AV48Trn_dynamictranslationwwds_5_tfdynamictranslationattributen",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_dynamictranslationwwds_6_tfdynamictranslationenglish",GXType.VarChar,200,0) ,
          new ParDef("AV50Trn_dynamictranslationwwds_7_tfdynamictranslationenglish_se",GXType.VarChar,200,0) ,
          new ParDef("lV51Trn_dynamictranslationwwds_8_tfdynamictranslationdutch",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_dynamictranslationwwds_9_tfdynamictranslationdutch_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
