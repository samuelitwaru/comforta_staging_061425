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
   public class trn_iconwwgetfilterdata : GXProcedure
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
            return "trn_iconww_Services_Execute" ;
         }

      }

      public trn_iconwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_iconwwgetfilterdata( IGxContext context )
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
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27MaxItems = 10;
         AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
         AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_ICONENGLISHNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADICONENGLISHNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_ICONDUTCHNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADICONDUTCHNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_TRN_ICONSVG") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_ICONSVGOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_ICONENGLISHTAGS") == 0 )
         {
            /* Execute user subroutine: 'LOADICONENGLISHTAGSOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_ICONDUTCHTAGS") == 0 )
         {
            /* Execute user subroutine: 'LOADICONDUTCHTAGSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("Trn_IconWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_IconWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Trn_IconWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONENGLISHNAME") == 0 )
            {
               AV12TFIconEnglishName = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONENGLISHNAME_SEL") == 0 )
            {
               AV13TFIconEnglishName_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONDUTCHNAME") == 0 )
            {
               AV14TFIconDutchName = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONDUTCHNAME_SEL") == 0 )
            {
               AV15TFIconDutchName_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRN_ICONSVG") == 0 )
            {
               AV16TFTrn_IconSVG = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRN_ICONSVG_SEL") == 0 )
            {
               AV17TFTrn_IconSVG_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRN_ICONCATEGORY_SEL") == 0 )
            {
               AV18TFTrn_IconCategory_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV19TFTrn_IconCategory_Sels.FromJSonString(AV18TFTrn_IconCategory_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONENGLISHTAGS") == 0 )
            {
               AV20TFIconEnglishTags = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONENGLISHTAGS_SEL") == 0 )
            {
               AV21TFIconEnglishTags_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONDUTCHTAGS") == 0 )
            {
               AV22TFIconDutchTags = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFICONDUTCHTAGS_SEL") == 0 )
            {
               AV23TFIconDutchTags_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADICONENGLISHNAMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFIconEnglishName = AV24SearchTxt;
         AV13TFIconEnglishName_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = AV46FilterFullText;
         AV50Trn_iconwwds_2_tficonenglishname = AV12TFIconEnglishName;
         AV51Trn_iconwwds_3_tficonenglishname_sel = AV13TFIconEnglishName_Sel;
         AV52Trn_iconwwds_4_tficondutchname = AV14TFIconDutchName;
         AV53Trn_iconwwds_5_tficondutchname_sel = AV15TFIconDutchName_Sel;
         AV54Trn_iconwwds_6_tftrn_iconsvg = AV16TFTrn_IconSVG;
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = AV17TFTrn_IconSVG_Sel;
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = AV19TFTrn_IconCategory_Sels;
         AV57Trn_iconwwds_9_tficonenglishtags = AV20TFIconEnglishTags;
         AV58Trn_iconwwds_10_tficonenglishtags_sel = AV21TFIconEnglishTags_Sel;
         AV59Trn_iconwwds_11_tficondutchtags = AV22TFIconDutchTags;
         AV60Trn_iconwwds_12_tficondutchtags_sel = AV23TFIconDutchTags_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A654Trn_IconCategory ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                              AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                              AV50Trn_iconwwds_2_tficonenglishname ,
                                              AV53Trn_iconwwds_5_tficondutchname_sel ,
                                              AV52Trn_iconwwds_4_tficondutchname ,
                                              AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                              AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels.Count ,
                                              AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                              AV57Trn_iconwwds_9_tficonenglishtags ,
                                              AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                              AV59Trn_iconwwds_11_tficondutchtags ,
                                              A651IconEnglishName ,
                                              A652IconDutchName ,
                                              A653Trn_IconSVG ,
                                              A655IconEnglishTags ,
                                              A656IconDutchTags ,
                                              AV49Trn_iconwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_iconwwds_2_tficonenglishname = StringUtil.Concat( StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname), "%", "");
         lV52Trn_iconwwds_4_tficondutchname = StringUtil.Concat( StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname), "%", "");
         lV54Trn_iconwwds_6_tftrn_iconsvg = StringUtil.Concat( StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg), "%", "");
         lV57Trn_iconwwds_9_tficonenglishtags = StringUtil.Concat( StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags), "%", "");
         lV59Trn_iconwwds_11_tficondutchtags = StringUtil.Concat( StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags), "%", "");
         /* Using cursor P00GY2 */
         pr_default.execute(0, new Object[] {lV50Trn_iconwwds_2_tficonenglishname, AV51Trn_iconwwds_3_tficonenglishname_sel, lV52Trn_iconwwds_4_tficondutchname, AV53Trn_iconwwds_5_tficondutchname_sel, lV54Trn_iconwwds_6_tftrn_iconsvg, AV55Trn_iconwwds_7_tftrn_iconsvg_sel, lV57Trn_iconwwds_9_tficonenglishtags, AV58Trn_iconwwds_10_tficonenglishtags_sel, lV59Trn_iconwwds_11_tficondutchtags, AV60Trn_iconwwds_12_tficondutchtags_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKGY2 = false;
            A651IconEnglishName = P00GY2_A651IconEnglishName[0];
            A656IconDutchTags = P00GY2_A656IconDutchTags[0];
            A655IconEnglishTags = P00GY2_A655IconEnglishTags[0];
            A653Trn_IconSVG = P00GY2_A653Trn_IconSVG[0];
            A652IconDutchName = P00GY2_A652IconDutchName[0];
            A654Trn_IconCategory = P00GY2_A654Trn_IconCategory[0];
            A649Trn_IconId = P00GY2_A649Trn_IconId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_iconwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A651IconEnglishName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A652IconDutchName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A653Trn_IconSVG) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "General", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Services", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "health", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Health", "")) == 0 ) ) || ( StringUtil.Like( StringUtil.Lower( A655IconEnglishTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A656IconDutchTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00GY2_A651IconEnglishName[0], A651IconEnglishName) == 0 ) )
               {
                  BRKGY2 = false;
                  A649Trn_IconId = P00GY2_A649Trn_IconId[0];
                  AV34count = (long)(AV34count+1);
                  BRKGY2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A651IconEnglishName)) ? "<#Empty#>" : A651IconEnglishName);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRKGY2 )
            {
               BRKGY2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADICONDUTCHNAMEOPTIONS' Routine */
         returnInSub = false;
         AV14TFIconDutchName = AV24SearchTxt;
         AV15TFIconDutchName_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = AV46FilterFullText;
         AV50Trn_iconwwds_2_tficonenglishname = AV12TFIconEnglishName;
         AV51Trn_iconwwds_3_tficonenglishname_sel = AV13TFIconEnglishName_Sel;
         AV52Trn_iconwwds_4_tficondutchname = AV14TFIconDutchName;
         AV53Trn_iconwwds_5_tficondutchname_sel = AV15TFIconDutchName_Sel;
         AV54Trn_iconwwds_6_tftrn_iconsvg = AV16TFTrn_IconSVG;
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = AV17TFTrn_IconSVG_Sel;
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = AV19TFTrn_IconCategory_Sels;
         AV57Trn_iconwwds_9_tficonenglishtags = AV20TFIconEnglishTags;
         AV58Trn_iconwwds_10_tficonenglishtags_sel = AV21TFIconEnglishTags_Sel;
         AV59Trn_iconwwds_11_tficondutchtags = AV22TFIconDutchTags;
         AV60Trn_iconwwds_12_tficondutchtags_sel = AV23TFIconDutchTags_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A654Trn_IconCategory ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                              AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                              AV50Trn_iconwwds_2_tficonenglishname ,
                                              AV53Trn_iconwwds_5_tficondutchname_sel ,
                                              AV52Trn_iconwwds_4_tficondutchname ,
                                              AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                              AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels.Count ,
                                              AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                              AV57Trn_iconwwds_9_tficonenglishtags ,
                                              AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                              AV59Trn_iconwwds_11_tficondutchtags ,
                                              A651IconEnglishName ,
                                              A652IconDutchName ,
                                              A653Trn_IconSVG ,
                                              A655IconEnglishTags ,
                                              A656IconDutchTags ,
                                              AV49Trn_iconwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_iconwwds_2_tficonenglishname = StringUtil.Concat( StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname), "%", "");
         lV52Trn_iconwwds_4_tficondutchname = StringUtil.Concat( StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname), "%", "");
         lV54Trn_iconwwds_6_tftrn_iconsvg = StringUtil.Concat( StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg), "%", "");
         lV57Trn_iconwwds_9_tficonenglishtags = StringUtil.Concat( StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags), "%", "");
         lV59Trn_iconwwds_11_tficondutchtags = StringUtil.Concat( StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags), "%", "");
         /* Using cursor P00GY3 */
         pr_default.execute(1, new Object[] {lV50Trn_iconwwds_2_tficonenglishname, AV51Trn_iconwwds_3_tficonenglishname_sel, lV52Trn_iconwwds_4_tficondutchname, AV53Trn_iconwwds_5_tficondutchname_sel, lV54Trn_iconwwds_6_tftrn_iconsvg, AV55Trn_iconwwds_7_tftrn_iconsvg_sel, lV57Trn_iconwwds_9_tficonenglishtags, AV58Trn_iconwwds_10_tficonenglishtags_sel, lV59Trn_iconwwds_11_tficondutchtags, AV60Trn_iconwwds_12_tficondutchtags_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKGY4 = false;
            A652IconDutchName = P00GY3_A652IconDutchName[0];
            A656IconDutchTags = P00GY3_A656IconDutchTags[0];
            A655IconEnglishTags = P00GY3_A655IconEnglishTags[0];
            A653Trn_IconSVG = P00GY3_A653Trn_IconSVG[0];
            A651IconEnglishName = P00GY3_A651IconEnglishName[0];
            A654Trn_IconCategory = P00GY3_A654Trn_IconCategory[0];
            A649Trn_IconId = P00GY3_A649Trn_IconId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_iconwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A651IconEnglishName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A652IconDutchName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A653Trn_IconSVG) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "General", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Services", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "health", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Health", "")) == 0 ) ) || ( StringUtil.Like( StringUtil.Lower( A655IconEnglishTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A656IconDutchTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00GY3_A652IconDutchName[0], A652IconDutchName) == 0 ) )
               {
                  BRKGY4 = false;
                  A649Trn_IconId = P00GY3_A649Trn_IconId[0];
                  AV34count = (long)(AV34count+1);
                  BRKGY4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A652IconDutchName)) ? "<#Empty#>" : A652IconDutchName);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRKGY4 )
            {
               BRKGY4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTRN_ICONSVGOPTIONS' Routine */
         returnInSub = false;
         AV16TFTrn_IconSVG = AV24SearchTxt;
         AV17TFTrn_IconSVG_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = AV46FilterFullText;
         AV50Trn_iconwwds_2_tficonenglishname = AV12TFIconEnglishName;
         AV51Trn_iconwwds_3_tficonenglishname_sel = AV13TFIconEnglishName_Sel;
         AV52Trn_iconwwds_4_tficondutchname = AV14TFIconDutchName;
         AV53Trn_iconwwds_5_tficondutchname_sel = AV15TFIconDutchName_Sel;
         AV54Trn_iconwwds_6_tftrn_iconsvg = AV16TFTrn_IconSVG;
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = AV17TFTrn_IconSVG_Sel;
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = AV19TFTrn_IconCategory_Sels;
         AV57Trn_iconwwds_9_tficonenglishtags = AV20TFIconEnglishTags;
         AV58Trn_iconwwds_10_tficonenglishtags_sel = AV21TFIconEnglishTags_Sel;
         AV59Trn_iconwwds_11_tficondutchtags = AV22TFIconDutchTags;
         AV60Trn_iconwwds_12_tficondutchtags_sel = AV23TFIconDutchTags_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A654Trn_IconCategory ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                              AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                              AV50Trn_iconwwds_2_tficonenglishname ,
                                              AV53Trn_iconwwds_5_tficondutchname_sel ,
                                              AV52Trn_iconwwds_4_tficondutchname ,
                                              AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                              AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels.Count ,
                                              AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                              AV57Trn_iconwwds_9_tficonenglishtags ,
                                              AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                              AV59Trn_iconwwds_11_tficondutchtags ,
                                              A651IconEnglishName ,
                                              A652IconDutchName ,
                                              A653Trn_IconSVG ,
                                              A655IconEnglishTags ,
                                              A656IconDutchTags ,
                                              AV49Trn_iconwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_iconwwds_2_tficonenglishname = StringUtil.Concat( StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname), "%", "");
         lV52Trn_iconwwds_4_tficondutchname = StringUtil.Concat( StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname), "%", "");
         lV54Trn_iconwwds_6_tftrn_iconsvg = StringUtil.Concat( StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg), "%", "");
         lV57Trn_iconwwds_9_tficonenglishtags = StringUtil.Concat( StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags), "%", "");
         lV59Trn_iconwwds_11_tficondutchtags = StringUtil.Concat( StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags), "%", "");
         /* Using cursor P00GY4 */
         pr_default.execute(2, new Object[] {lV50Trn_iconwwds_2_tficonenglishname, AV51Trn_iconwwds_3_tficonenglishname_sel, lV52Trn_iconwwds_4_tficondutchname, AV53Trn_iconwwds_5_tficondutchname_sel, lV54Trn_iconwwds_6_tftrn_iconsvg, AV55Trn_iconwwds_7_tftrn_iconsvg_sel, lV57Trn_iconwwds_9_tficonenglishtags, AV58Trn_iconwwds_10_tficonenglishtags_sel, lV59Trn_iconwwds_11_tficondutchtags, AV60Trn_iconwwds_12_tficondutchtags_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKGY6 = false;
            A653Trn_IconSVG = P00GY4_A653Trn_IconSVG[0];
            A656IconDutchTags = P00GY4_A656IconDutchTags[0];
            A655IconEnglishTags = P00GY4_A655IconEnglishTags[0];
            A652IconDutchName = P00GY4_A652IconDutchName[0];
            A651IconEnglishName = P00GY4_A651IconEnglishName[0];
            A654Trn_IconCategory = P00GY4_A654Trn_IconCategory[0];
            A649Trn_IconId = P00GY4_A649Trn_IconId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_iconwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A651IconEnglishName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A652IconDutchName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A653Trn_IconSVG) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "General", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Services", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "health", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Health", "")) == 0 ) ) || ( StringUtil.Like( StringUtil.Lower( A655IconEnglishTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A656IconDutchTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00GY4_A653Trn_IconSVG[0], A653Trn_IconSVG) == 0 ) )
               {
                  BRKGY6 = false;
                  A649Trn_IconId = P00GY4_A649Trn_IconId[0];
                  AV34count = (long)(AV34count+1);
                  BRKGY6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A653Trn_IconSVG)) ? "<#Empty#>" : A653Trn_IconSVG);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRKGY6 )
            {
               BRKGY6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADICONENGLISHTAGSOPTIONS' Routine */
         returnInSub = false;
         AV20TFIconEnglishTags = AV24SearchTxt;
         AV21TFIconEnglishTags_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = AV46FilterFullText;
         AV50Trn_iconwwds_2_tficonenglishname = AV12TFIconEnglishName;
         AV51Trn_iconwwds_3_tficonenglishname_sel = AV13TFIconEnglishName_Sel;
         AV52Trn_iconwwds_4_tficondutchname = AV14TFIconDutchName;
         AV53Trn_iconwwds_5_tficondutchname_sel = AV15TFIconDutchName_Sel;
         AV54Trn_iconwwds_6_tftrn_iconsvg = AV16TFTrn_IconSVG;
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = AV17TFTrn_IconSVG_Sel;
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = AV19TFTrn_IconCategory_Sels;
         AV57Trn_iconwwds_9_tficonenglishtags = AV20TFIconEnglishTags;
         AV58Trn_iconwwds_10_tficonenglishtags_sel = AV21TFIconEnglishTags_Sel;
         AV59Trn_iconwwds_11_tficondutchtags = AV22TFIconDutchTags;
         AV60Trn_iconwwds_12_tficondutchtags_sel = AV23TFIconDutchTags_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A654Trn_IconCategory ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                              AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                              AV50Trn_iconwwds_2_tficonenglishname ,
                                              AV53Trn_iconwwds_5_tficondutchname_sel ,
                                              AV52Trn_iconwwds_4_tficondutchname ,
                                              AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                              AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels.Count ,
                                              AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                              AV57Trn_iconwwds_9_tficonenglishtags ,
                                              AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                              AV59Trn_iconwwds_11_tficondutchtags ,
                                              A651IconEnglishName ,
                                              A652IconDutchName ,
                                              A653Trn_IconSVG ,
                                              A655IconEnglishTags ,
                                              A656IconDutchTags ,
                                              AV49Trn_iconwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_iconwwds_2_tficonenglishname = StringUtil.Concat( StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname), "%", "");
         lV52Trn_iconwwds_4_tficondutchname = StringUtil.Concat( StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname), "%", "");
         lV54Trn_iconwwds_6_tftrn_iconsvg = StringUtil.Concat( StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg), "%", "");
         lV57Trn_iconwwds_9_tficonenglishtags = StringUtil.Concat( StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags), "%", "");
         lV59Trn_iconwwds_11_tficondutchtags = StringUtil.Concat( StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags), "%", "");
         /* Using cursor P00GY5 */
         pr_default.execute(3, new Object[] {lV50Trn_iconwwds_2_tficonenglishname, AV51Trn_iconwwds_3_tficonenglishname_sel, lV52Trn_iconwwds_4_tficondutchname, AV53Trn_iconwwds_5_tficondutchname_sel, lV54Trn_iconwwds_6_tftrn_iconsvg, AV55Trn_iconwwds_7_tftrn_iconsvg_sel, lV57Trn_iconwwds_9_tficonenglishtags, AV58Trn_iconwwds_10_tficonenglishtags_sel, lV59Trn_iconwwds_11_tficondutchtags, AV60Trn_iconwwds_12_tficondutchtags_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKGY8 = false;
            A655IconEnglishTags = P00GY5_A655IconEnglishTags[0];
            A656IconDutchTags = P00GY5_A656IconDutchTags[0];
            A653Trn_IconSVG = P00GY5_A653Trn_IconSVG[0];
            A652IconDutchName = P00GY5_A652IconDutchName[0];
            A651IconEnglishName = P00GY5_A651IconEnglishName[0];
            A654Trn_IconCategory = P00GY5_A654Trn_IconCategory[0];
            A649Trn_IconId = P00GY5_A649Trn_IconId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_iconwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A651IconEnglishName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A652IconDutchName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A653Trn_IconSVG) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "General", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Services", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "health", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Health", "")) == 0 ) ) || ( StringUtil.Like( StringUtil.Lower( A655IconEnglishTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A656IconDutchTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00GY5_A655IconEnglishTags[0], A655IconEnglishTags) == 0 ) )
               {
                  BRKGY8 = false;
                  A649Trn_IconId = P00GY5_A649Trn_IconId[0];
                  AV34count = (long)(AV34count+1);
                  BRKGY8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A655IconEnglishTags)) ? "<#Empty#>" : A655IconEnglishTags);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRKGY8 )
            {
               BRKGY8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADICONDUTCHTAGSOPTIONS' Routine */
         returnInSub = false;
         AV22TFIconDutchTags = AV24SearchTxt;
         AV23TFIconDutchTags_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = AV46FilterFullText;
         AV50Trn_iconwwds_2_tficonenglishname = AV12TFIconEnglishName;
         AV51Trn_iconwwds_3_tficonenglishname_sel = AV13TFIconEnglishName_Sel;
         AV52Trn_iconwwds_4_tficondutchname = AV14TFIconDutchName;
         AV53Trn_iconwwds_5_tficondutchname_sel = AV15TFIconDutchName_Sel;
         AV54Trn_iconwwds_6_tftrn_iconsvg = AV16TFTrn_IconSVG;
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = AV17TFTrn_IconSVG_Sel;
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = AV19TFTrn_IconCategory_Sels;
         AV57Trn_iconwwds_9_tficonenglishtags = AV20TFIconEnglishTags;
         AV58Trn_iconwwds_10_tficonenglishtags_sel = AV21TFIconEnglishTags_Sel;
         AV59Trn_iconwwds_11_tficondutchtags = AV22TFIconDutchTags;
         AV60Trn_iconwwds_12_tficondutchtags_sel = AV23TFIconDutchTags_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A654Trn_IconCategory ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                              AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                              AV50Trn_iconwwds_2_tficonenglishname ,
                                              AV53Trn_iconwwds_5_tficondutchname_sel ,
                                              AV52Trn_iconwwds_4_tficondutchname ,
                                              AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                              AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                              AV56Trn_iconwwds_8_tftrn_iconcategory_sels.Count ,
                                              AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                              AV57Trn_iconwwds_9_tficonenglishtags ,
                                              AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                              AV59Trn_iconwwds_11_tficondutchtags ,
                                              A651IconEnglishName ,
                                              A652IconDutchName ,
                                              A653Trn_IconSVG ,
                                              A655IconEnglishTags ,
                                              A656IconDutchTags ,
                                              AV49Trn_iconwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_iconwwds_2_tficonenglishname = StringUtil.Concat( StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname), "%", "");
         lV52Trn_iconwwds_4_tficondutchname = StringUtil.Concat( StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname), "%", "");
         lV54Trn_iconwwds_6_tftrn_iconsvg = StringUtil.Concat( StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg), "%", "");
         lV57Trn_iconwwds_9_tficonenglishtags = StringUtil.Concat( StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags), "%", "");
         lV59Trn_iconwwds_11_tficondutchtags = StringUtil.Concat( StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags), "%", "");
         /* Using cursor P00GY6 */
         pr_default.execute(4, new Object[] {lV50Trn_iconwwds_2_tficonenglishname, AV51Trn_iconwwds_3_tficonenglishname_sel, lV52Trn_iconwwds_4_tficondutchname, AV53Trn_iconwwds_5_tficondutchname_sel, lV54Trn_iconwwds_6_tftrn_iconsvg, AV55Trn_iconwwds_7_tftrn_iconsvg_sel, lV57Trn_iconwwds_9_tficonenglishtags, AV58Trn_iconwwds_10_tficonenglishtags_sel, lV59Trn_iconwwds_11_tficondutchtags, AV60Trn_iconwwds_12_tficondutchtags_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKGY10 = false;
            A656IconDutchTags = P00GY6_A656IconDutchTags[0];
            A655IconEnglishTags = P00GY6_A655IconEnglishTags[0];
            A653Trn_IconSVG = P00GY6_A653Trn_IconSVG[0];
            A652IconDutchName = P00GY6_A652IconDutchName[0];
            A651IconEnglishName = P00GY6_A651IconEnglishName[0];
            A654Trn_IconCategory = P00GY6_A654Trn_IconCategory[0];
            A649Trn_IconId = P00GY6_A649Trn_IconId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_iconwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A651IconEnglishName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A652IconDutchName) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A653Trn_IconSVG) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "General", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "services", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Services", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "living", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Living", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "health", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A654Trn_IconCategory, context.GetMessage( "Health", "")) == 0 ) ) || ( StringUtil.Like( StringUtil.Lower( A655IconEnglishTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A656IconDutchTags) , StringUtil.PadR( "%" + StringUtil.Lower( AV49Trn_iconwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00GY6_A656IconDutchTags[0], A656IconDutchTags) == 0 ) )
               {
                  BRKGY10 = false;
                  A649Trn_IconId = P00GY6_A649Trn_IconId[0];
                  AV34count = (long)(AV34count+1);
                  BRKGY10 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A656IconDutchTags)) ? "<#Empty#>" : A656IconDutchTags);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRKGY10 )
            {
               BRKGY10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV38GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV12TFIconEnglishName = "";
         AV13TFIconEnglishName_Sel = "";
         AV14TFIconDutchName = "";
         AV15TFIconDutchName_Sel = "";
         AV16TFTrn_IconSVG = "";
         AV17TFTrn_IconSVG_Sel = "";
         AV18TFTrn_IconCategory_SelsJson = "";
         AV19TFTrn_IconCategory_Sels = new GxSimpleCollection<string>();
         AV20TFIconEnglishTags = "";
         AV21TFIconEnglishTags_Sel = "";
         AV22TFIconDutchTags = "";
         AV23TFIconDutchTags_Sel = "";
         AV49Trn_iconwwds_1_filterfulltext = "";
         AV50Trn_iconwwds_2_tficonenglishname = "";
         AV51Trn_iconwwds_3_tficonenglishname_sel = "";
         AV52Trn_iconwwds_4_tficondutchname = "";
         AV53Trn_iconwwds_5_tficondutchname_sel = "";
         AV54Trn_iconwwds_6_tftrn_iconsvg = "";
         AV55Trn_iconwwds_7_tftrn_iconsvg_sel = "";
         AV56Trn_iconwwds_8_tftrn_iconcategory_sels = new GxSimpleCollection<string>();
         AV57Trn_iconwwds_9_tficonenglishtags = "";
         AV58Trn_iconwwds_10_tficonenglishtags_sel = "";
         AV59Trn_iconwwds_11_tficondutchtags = "";
         AV60Trn_iconwwds_12_tficondutchtags_sel = "";
         lV49Trn_iconwwds_1_filterfulltext = "";
         lV50Trn_iconwwds_2_tficonenglishname = "";
         lV52Trn_iconwwds_4_tficondutchname = "";
         lV54Trn_iconwwds_6_tftrn_iconsvg = "";
         lV57Trn_iconwwds_9_tficonenglishtags = "";
         lV59Trn_iconwwds_11_tficondutchtags = "";
         A654Trn_IconCategory = "";
         A651IconEnglishName = "";
         A652IconDutchName = "";
         A653Trn_IconSVG = "";
         A655IconEnglishTags = "";
         A656IconDutchTags = "";
         P00GY2_A651IconEnglishName = new string[] {""} ;
         P00GY2_A656IconDutchTags = new string[] {""} ;
         P00GY2_A655IconEnglishTags = new string[] {""} ;
         P00GY2_A653Trn_IconSVG = new string[] {""} ;
         P00GY2_A652IconDutchName = new string[] {""} ;
         P00GY2_A654Trn_IconCategory = new string[] {""} ;
         P00GY2_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         A649Trn_IconId = Guid.Empty;
         AV29Option = "";
         P00GY3_A652IconDutchName = new string[] {""} ;
         P00GY3_A656IconDutchTags = new string[] {""} ;
         P00GY3_A655IconEnglishTags = new string[] {""} ;
         P00GY3_A653Trn_IconSVG = new string[] {""} ;
         P00GY3_A651IconEnglishName = new string[] {""} ;
         P00GY3_A654Trn_IconCategory = new string[] {""} ;
         P00GY3_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         P00GY4_A653Trn_IconSVG = new string[] {""} ;
         P00GY4_A656IconDutchTags = new string[] {""} ;
         P00GY4_A655IconEnglishTags = new string[] {""} ;
         P00GY4_A652IconDutchName = new string[] {""} ;
         P00GY4_A651IconEnglishName = new string[] {""} ;
         P00GY4_A654Trn_IconCategory = new string[] {""} ;
         P00GY4_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         P00GY5_A655IconEnglishTags = new string[] {""} ;
         P00GY5_A656IconDutchTags = new string[] {""} ;
         P00GY5_A653Trn_IconSVG = new string[] {""} ;
         P00GY5_A652IconDutchName = new string[] {""} ;
         P00GY5_A651IconEnglishName = new string[] {""} ;
         P00GY5_A654Trn_IconCategory = new string[] {""} ;
         P00GY5_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         P00GY6_A656IconDutchTags = new string[] {""} ;
         P00GY6_A655IconEnglishTags = new string[] {""} ;
         P00GY6_A653Trn_IconSVG = new string[] {""} ;
         P00GY6_A652IconDutchName = new string[] {""} ;
         P00GY6_A651IconEnglishName = new string[] {""} ;
         P00GY6_A654Trn_IconCategory = new string[] {""} ;
         P00GY6_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_iconwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00GY2_A651IconEnglishName, P00GY2_A656IconDutchTags, P00GY2_A655IconEnglishTags, P00GY2_A653Trn_IconSVG, P00GY2_A652IconDutchName, P00GY2_A654Trn_IconCategory, P00GY2_A649Trn_IconId
               }
               , new Object[] {
               P00GY3_A652IconDutchName, P00GY3_A656IconDutchTags, P00GY3_A655IconEnglishTags, P00GY3_A653Trn_IconSVG, P00GY3_A651IconEnglishName, P00GY3_A654Trn_IconCategory, P00GY3_A649Trn_IconId
               }
               , new Object[] {
               P00GY4_A653Trn_IconSVG, P00GY4_A656IconDutchTags, P00GY4_A655IconEnglishTags, P00GY4_A652IconDutchName, P00GY4_A651IconEnglishName, P00GY4_A654Trn_IconCategory, P00GY4_A649Trn_IconId
               }
               , new Object[] {
               P00GY5_A655IconEnglishTags, P00GY5_A656IconDutchTags, P00GY5_A653Trn_IconSVG, P00GY5_A652IconDutchName, P00GY5_A651IconEnglishName, P00GY5_A654Trn_IconCategory, P00GY5_A649Trn_IconId
               }
               , new Object[] {
               P00GY6_A656IconDutchTags, P00GY6_A655IconEnglishTags, P00GY6_A653Trn_IconSVG, P00GY6_A652IconDutchName, P00GY6_A651IconEnglishName, P00GY6_A654Trn_IconCategory, P00GY6_A649Trn_IconId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private int AV47GXV1 ;
      private int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ;
      private long AV34count ;
      private bool returnInSub ;
      private bool BRKGY2 ;
      private bool BRKGY4 ;
      private bool BRKGY6 ;
      private bool BRKGY8 ;
      private bool BRKGY10 ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV18TFTrn_IconCategory_SelsJson ;
      private string A653Trn_IconSVG ;
      private string A655IconEnglishTags ;
      private string A656IconDutchTags ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV46FilterFullText ;
      private string AV12TFIconEnglishName ;
      private string AV13TFIconEnglishName_Sel ;
      private string AV14TFIconDutchName ;
      private string AV15TFIconDutchName_Sel ;
      private string AV16TFTrn_IconSVG ;
      private string AV17TFTrn_IconSVG_Sel ;
      private string AV20TFIconEnglishTags ;
      private string AV21TFIconEnglishTags_Sel ;
      private string AV22TFIconDutchTags ;
      private string AV23TFIconDutchTags_Sel ;
      private string AV49Trn_iconwwds_1_filterfulltext ;
      private string AV50Trn_iconwwds_2_tficonenglishname ;
      private string AV51Trn_iconwwds_3_tficonenglishname_sel ;
      private string AV52Trn_iconwwds_4_tficondutchname ;
      private string AV53Trn_iconwwds_5_tficondutchname_sel ;
      private string AV54Trn_iconwwds_6_tftrn_iconsvg ;
      private string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ;
      private string AV57Trn_iconwwds_9_tficonenglishtags ;
      private string AV58Trn_iconwwds_10_tficonenglishtags_sel ;
      private string AV59Trn_iconwwds_11_tficondutchtags ;
      private string AV60Trn_iconwwds_12_tficondutchtags_sel ;
      private string lV49Trn_iconwwds_1_filterfulltext ;
      private string lV50Trn_iconwwds_2_tficonenglishname ;
      private string lV52Trn_iconwwds_4_tficondutchname ;
      private string lV54Trn_iconwwds_6_tftrn_iconsvg ;
      private string lV57Trn_iconwwds_9_tficonenglishtags ;
      private string lV59Trn_iconwwds_11_tficondutchtags ;
      private string A654Trn_IconCategory ;
      private string A651IconEnglishName ;
      private string A652IconDutchName ;
      private string AV29Option ;
      private Guid A649Trn_IconId ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV37GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GxSimpleCollection<string> AV19TFTrn_IconCategory_Sels ;
      private GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00GY2_A651IconEnglishName ;
      private string[] P00GY2_A656IconDutchTags ;
      private string[] P00GY2_A655IconEnglishTags ;
      private string[] P00GY2_A653Trn_IconSVG ;
      private string[] P00GY2_A652IconDutchName ;
      private string[] P00GY2_A654Trn_IconCategory ;
      private Guid[] P00GY2_A649Trn_IconId ;
      private string[] P00GY3_A652IconDutchName ;
      private string[] P00GY3_A656IconDutchTags ;
      private string[] P00GY3_A655IconEnglishTags ;
      private string[] P00GY3_A653Trn_IconSVG ;
      private string[] P00GY3_A651IconEnglishName ;
      private string[] P00GY3_A654Trn_IconCategory ;
      private Guid[] P00GY3_A649Trn_IconId ;
      private string[] P00GY4_A653Trn_IconSVG ;
      private string[] P00GY4_A656IconDutchTags ;
      private string[] P00GY4_A655IconEnglishTags ;
      private string[] P00GY4_A652IconDutchName ;
      private string[] P00GY4_A651IconEnglishName ;
      private string[] P00GY4_A654Trn_IconCategory ;
      private Guid[] P00GY4_A649Trn_IconId ;
      private string[] P00GY5_A655IconEnglishTags ;
      private string[] P00GY5_A656IconDutchTags ;
      private string[] P00GY5_A653Trn_IconSVG ;
      private string[] P00GY5_A652IconDutchName ;
      private string[] P00GY5_A651IconEnglishName ;
      private string[] P00GY5_A654Trn_IconCategory ;
      private Guid[] P00GY5_A649Trn_IconId ;
      private string[] P00GY6_A656IconDutchTags ;
      private string[] P00GY6_A655IconEnglishTags ;
      private string[] P00GY6_A653Trn_IconSVG ;
      private string[] P00GY6_A652IconDutchName ;
      private string[] P00GY6_A651IconEnglishName ;
      private string[] P00GY6_A654Trn_IconCategory ;
      private Guid[] P00GY6_A649Trn_IconId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_iconwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GY2( IGxContext context ,
                                             string A654Trn_IconCategory ,
                                             GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                             string AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                             string AV50Trn_iconwwds_2_tficonenglishname ,
                                             string AV53Trn_iconwwds_5_tficondutchname_sel ,
                                             string AV52Trn_iconwwds_4_tficondutchname ,
                                             string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                             string AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                             int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ,
                                             string AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                             string AV57Trn_iconwwds_9_tficonenglishtags ,
                                             string AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                             string AV59Trn_iconwwds_11_tficondutchtags ,
                                             string A651IconEnglishName ,
                                             string A652IconDutchName ,
                                             string A653Trn_IconSVG ,
                                             string A655IconEnglishTags ,
                                             string A656IconDutchTags ,
                                             string AV49Trn_iconwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT IconEnglishName, IconDutchTags, IconEnglishTags, Trn_IconSVG, IconDutchName, Trn_IconCategory, Trn_IconId FROM Trn_Icon";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishName like :lV50Trn_iconwwds_2_tficonenglishname)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ! ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishName = ( :AV51Trn_iconwwds_3_tficonenglishname_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname)) ) )
         {
            AddWhere(sWhereString, "(IconDutchName like :lV52Trn_iconwwds_4_tficondutchname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ! ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchName = ( :AV53Trn_iconwwds_5_tficondutchname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg)) ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG like :lV54Trn_iconwwds_6_tftrn_iconsvg)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ! ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG = ( :AV55Trn_iconwwds_7_tftrn_iconsvg_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_IconSVG))=0))");
         }
         if ( AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Trn_iconwwds_8_tftrn_iconcategory_sels, "Trn_IconCategory IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags like :lV57Trn_iconwwds_9_tficonenglishtags)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ! ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags = ( :AV58Trn_iconwwds_10_tficonenglishtags_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishTags))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags)) ) )
         {
            AddWhere(sWhereString, "(IconDutchTags like :lV59Trn_iconwwds_11_tficondutchtags)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ! ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchTags = ( :AV60Trn_iconwwds_12_tficondutchtags_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchTags))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY IconEnglishName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00GY3( IGxContext context ,
                                             string A654Trn_IconCategory ,
                                             GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                             string AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                             string AV50Trn_iconwwds_2_tficonenglishname ,
                                             string AV53Trn_iconwwds_5_tficondutchname_sel ,
                                             string AV52Trn_iconwwds_4_tficondutchname ,
                                             string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                             string AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                             int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ,
                                             string AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                             string AV57Trn_iconwwds_9_tficonenglishtags ,
                                             string AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                             string AV59Trn_iconwwds_11_tficondutchtags ,
                                             string A651IconEnglishName ,
                                             string A652IconDutchName ,
                                             string A653Trn_IconSVG ,
                                             string A655IconEnglishTags ,
                                             string A656IconDutchTags ,
                                             string AV49Trn_iconwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT IconDutchName, IconDutchTags, IconEnglishTags, Trn_IconSVG, IconEnglishName, Trn_IconCategory, Trn_IconId FROM Trn_Icon";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishName like :lV50Trn_iconwwds_2_tficonenglishname)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ! ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishName = ( :AV51Trn_iconwwds_3_tficonenglishname_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname)) ) )
         {
            AddWhere(sWhereString, "(IconDutchName like :lV52Trn_iconwwds_4_tficondutchname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ! ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchName = ( :AV53Trn_iconwwds_5_tficondutchname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg)) ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG like :lV54Trn_iconwwds_6_tftrn_iconsvg)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ! ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG = ( :AV55Trn_iconwwds_7_tftrn_iconsvg_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_IconSVG))=0))");
         }
         if ( AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Trn_iconwwds_8_tftrn_iconcategory_sels, "Trn_IconCategory IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags like :lV57Trn_iconwwds_9_tficonenglishtags)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ! ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags = ( :AV58Trn_iconwwds_10_tficonenglishtags_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishTags))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags)) ) )
         {
            AddWhere(sWhereString, "(IconDutchTags like :lV59Trn_iconwwds_11_tficondutchtags)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ! ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchTags = ( :AV60Trn_iconwwds_12_tficondutchtags_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchTags))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY IconDutchName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00GY4( IGxContext context ,
                                             string A654Trn_IconCategory ,
                                             GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                             string AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                             string AV50Trn_iconwwds_2_tficonenglishname ,
                                             string AV53Trn_iconwwds_5_tficondutchname_sel ,
                                             string AV52Trn_iconwwds_4_tficondutchname ,
                                             string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                             string AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                             int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ,
                                             string AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                             string AV57Trn_iconwwds_9_tficonenglishtags ,
                                             string AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                             string AV59Trn_iconwwds_11_tficondutchtags ,
                                             string A651IconEnglishName ,
                                             string A652IconDutchName ,
                                             string A653Trn_IconSVG ,
                                             string A655IconEnglishTags ,
                                             string A656IconDutchTags ,
                                             string AV49Trn_iconwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT Trn_IconSVG, IconDutchTags, IconEnglishTags, IconDutchName, IconEnglishName, Trn_IconCategory, Trn_IconId FROM Trn_Icon";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishName like :lV50Trn_iconwwds_2_tficonenglishname)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ! ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishName = ( :AV51Trn_iconwwds_3_tficonenglishname_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname)) ) )
         {
            AddWhere(sWhereString, "(IconDutchName like :lV52Trn_iconwwds_4_tficondutchname)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ! ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchName = ( :AV53Trn_iconwwds_5_tficondutchname_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg)) ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG like :lV54Trn_iconwwds_6_tftrn_iconsvg)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ! ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG = ( :AV55Trn_iconwwds_7_tftrn_iconsvg_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_IconSVG))=0))");
         }
         if ( AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Trn_iconwwds_8_tftrn_iconcategory_sels, "Trn_IconCategory IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags like :lV57Trn_iconwwds_9_tficonenglishtags)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ! ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags = ( :AV58Trn_iconwwds_10_tficonenglishtags_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishTags))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags)) ) )
         {
            AddWhere(sWhereString, "(IconDutchTags like :lV59Trn_iconwwds_11_tficondutchtags)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ! ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchTags = ( :AV60Trn_iconwwds_12_tficondutchtags_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchTags))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_IconSVG";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00GY5( IGxContext context ,
                                             string A654Trn_IconCategory ,
                                             GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                             string AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                             string AV50Trn_iconwwds_2_tficonenglishname ,
                                             string AV53Trn_iconwwds_5_tficondutchname_sel ,
                                             string AV52Trn_iconwwds_4_tficondutchname ,
                                             string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                             string AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                             int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ,
                                             string AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                             string AV57Trn_iconwwds_9_tficonenglishtags ,
                                             string AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                             string AV59Trn_iconwwds_11_tficondutchtags ,
                                             string A651IconEnglishName ,
                                             string A652IconDutchName ,
                                             string A653Trn_IconSVG ,
                                             string A655IconEnglishTags ,
                                             string A656IconDutchTags ,
                                             string AV49Trn_iconwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT IconEnglishTags, IconDutchTags, Trn_IconSVG, IconDutchName, IconEnglishName, Trn_IconCategory, Trn_IconId FROM Trn_Icon";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishName like :lV50Trn_iconwwds_2_tficonenglishname)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ! ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishName = ( :AV51Trn_iconwwds_3_tficonenglishname_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname)) ) )
         {
            AddWhere(sWhereString, "(IconDutchName like :lV52Trn_iconwwds_4_tficondutchname)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ! ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchName = ( :AV53Trn_iconwwds_5_tficondutchname_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg)) ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG like :lV54Trn_iconwwds_6_tftrn_iconsvg)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ! ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG = ( :AV55Trn_iconwwds_7_tftrn_iconsvg_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_IconSVG))=0))");
         }
         if ( AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Trn_iconwwds_8_tftrn_iconcategory_sels, "Trn_IconCategory IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags like :lV57Trn_iconwwds_9_tficonenglishtags)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ! ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags = ( :AV58Trn_iconwwds_10_tficonenglishtags_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishTags))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags)) ) )
         {
            AddWhere(sWhereString, "(IconDutchTags like :lV59Trn_iconwwds_11_tficondutchtags)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ! ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchTags = ( :AV60Trn_iconwwds_12_tficondutchtags_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchTags))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY IconEnglishTags";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00GY6( IGxContext context ,
                                             string A654Trn_IconCategory ,
                                             GxSimpleCollection<string> AV56Trn_iconwwds_8_tftrn_iconcategory_sels ,
                                             string AV51Trn_iconwwds_3_tficonenglishname_sel ,
                                             string AV50Trn_iconwwds_2_tficonenglishname ,
                                             string AV53Trn_iconwwds_5_tficondutchname_sel ,
                                             string AV52Trn_iconwwds_4_tficondutchname ,
                                             string AV55Trn_iconwwds_7_tftrn_iconsvg_sel ,
                                             string AV54Trn_iconwwds_6_tftrn_iconsvg ,
                                             int AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count ,
                                             string AV58Trn_iconwwds_10_tficonenglishtags_sel ,
                                             string AV57Trn_iconwwds_9_tficonenglishtags ,
                                             string AV60Trn_iconwwds_12_tficondutchtags_sel ,
                                             string AV59Trn_iconwwds_11_tficondutchtags ,
                                             string A651IconEnglishName ,
                                             string A652IconDutchName ,
                                             string A653Trn_IconSVG ,
                                             string A655IconEnglishTags ,
                                             string A656IconDutchTags ,
                                             string AV49Trn_iconwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT IconDutchTags, IconEnglishTags, Trn_IconSVG, IconDutchName, IconEnglishName, Trn_IconCategory, Trn_IconId FROM Trn_Icon";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_iconwwds_2_tficonenglishname)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishName like :lV50Trn_iconwwds_2_tficonenglishname)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_iconwwds_3_tficonenglishname_sel)) && ! ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishName = ( :AV51Trn_iconwwds_3_tficonenglishname_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Trn_iconwwds_3_tficonenglishname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_iconwwds_4_tficondutchname)) ) )
         {
            AddWhere(sWhereString, "(IconDutchName like :lV52Trn_iconwwds_4_tficondutchname)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_iconwwds_5_tficondutchname_sel)) && ! ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchName = ( :AV53Trn_iconwwds_5_tficondutchname_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Trn_iconwwds_5_tficondutchname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_iconwwds_6_tftrn_iconsvg)) ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG like :lV54Trn_iconwwds_6_tftrn_iconsvg)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_iconwwds_7_tftrn_iconsvg_sel)) && ! ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_IconSVG = ( :AV55Trn_iconwwds_7_tftrn_iconsvg_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Trn_iconwwds_7_tftrn_iconsvg_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_IconSVG))=0))");
         }
         if ( AV56Trn_iconwwds_8_tftrn_iconcategory_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Trn_iconwwds_8_tftrn_iconcategory_sels, "Trn_IconCategory IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_iconwwds_9_tficonenglishtags)) ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags like :lV57Trn_iconwwds_9_tficonenglishtags)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_iconwwds_10_tficonenglishtags_sel)) && ! ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconEnglishTags = ( :AV58Trn_iconwwds_10_tficonenglishtags_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_iconwwds_10_tficonenglishtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconEnglishTags))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_iconwwds_11_tficondutchtags)) ) )
         {
            AddWhere(sWhereString, "(IconDutchTags like :lV59Trn_iconwwds_11_tficondutchtags)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_iconwwds_12_tficondutchtags_sel)) && ! ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(IconDutchTags = ( :AV60Trn_iconwwds_12_tficondutchtags_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_iconwwds_12_tficondutchtags_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IconDutchTags))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY IconDutchTags";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00GY2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P00GY3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 2 :
                     return conditional_P00GY4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 3 :
                     return conditional_P00GY5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 4 :
                     return conditional_P00GY6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GY2;
          prmP00GY2 = new Object[] {
          new ParDef("lV50Trn_iconwwds_2_tficonenglishname",GXType.VarChar,100,0) ,
          new ParDef("AV51Trn_iconwwds_3_tficonenglishname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_iconwwds_4_tficondutchname",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_iconwwds_5_tficondutchname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_iconwwds_6_tftrn_iconsvg",GXType.VarChar,200,0) ,
          new ParDef("AV55Trn_iconwwds_7_tftrn_iconsvg_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Trn_iconwwds_9_tficonenglishtags",GXType.VarChar,200,0) ,
          new ParDef("AV58Trn_iconwwds_10_tficonenglishtags_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_iconwwds_11_tficondutchtags",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_iconwwds_12_tficondutchtags_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00GY3;
          prmP00GY3 = new Object[] {
          new ParDef("lV50Trn_iconwwds_2_tficonenglishname",GXType.VarChar,100,0) ,
          new ParDef("AV51Trn_iconwwds_3_tficonenglishname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_iconwwds_4_tficondutchname",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_iconwwds_5_tficondutchname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_iconwwds_6_tftrn_iconsvg",GXType.VarChar,200,0) ,
          new ParDef("AV55Trn_iconwwds_7_tftrn_iconsvg_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Trn_iconwwds_9_tficonenglishtags",GXType.VarChar,200,0) ,
          new ParDef("AV58Trn_iconwwds_10_tficonenglishtags_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_iconwwds_11_tficondutchtags",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_iconwwds_12_tficondutchtags_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00GY4;
          prmP00GY4 = new Object[] {
          new ParDef("lV50Trn_iconwwds_2_tficonenglishname",GXType.VarChar,100,0) ,
          new ParDef("AV51Trn_iconwwds_3_tficonenglishname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_iconwwds_4_tficondutchname",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_iconwwds_5_tficondutchname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_iconwwds_6_tftrn_iconsvg",GXType.VarChar,200,0) ,
          new ParDef("AV55Trn_iconwwds_7_tftrn_iconsvg_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Trn_iconwwds_9_tficonenglishtags",GXType.VarChar,200,0) ,
          new ParDef("AV58Trn_iconwwds_10_tficonenglishtags_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_iconwwds_11_tficondutchtags",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_iconwwds_12_tficondutchtags_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00GY5;
          prmP00GY5 = new Object[] {
          new ParDef("lV50Trn_iconwwds_2_tficonenglishname",GXType.VarChar,100,0) ,
          new ParDef("AV51Trn_iconwwds_3_tficonenglishname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_iconwwds_4_tficondutchname",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_iconwwds_5_tficondutchname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_iconwwds_6_tftrn_iconsvg",GXType.VarChar,200,0) ,
          new ParDef("AV55Trn_iconwwds_7_tftrn_iconsvg_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Trn_iconwwds_9_tficonenglishtags",GXType.VarChar,200,0) ,
          new ParDef("AV58Trn_iconwwds_10_tficonenglishtags_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_iconwwds_11_tficondutchtags",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_iconwwds_12_tficondutchtags_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00GY6;
          prmP00GY6 = new Object[] {
          new ParDef("lV50Trn_iconwwds_2_tficonenglishname",GXType.VarChar,100,0) ,
          new ParDef("AV51Trn_iconwwds_3_tficonenglishname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_iconwwds_4_tficondutchname",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_iconwwds_5_tficondutchname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_iconwwds_6_tftrn_iconsvg",GXType.VarChar,200,0) ,
          new ParDef("AV55Trn_iconwwds_7_tftrn_iconsvg_sel",GXType.VarChar,200,0) ,
          new ParDef("lV57Trn_iconwwds_9_tficonenglishtags",GXType.VarChar,200,0) ,
          new ParDef("AV58Trn_iconwwds_10_tficonenglishtags_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_iconwwds_11_tficondutchtags",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_iconwwds_12_tficondutchtags_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GY3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GY4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GY5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GY6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
