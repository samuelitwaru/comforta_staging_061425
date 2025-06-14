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
   public class trn_pagewwgetfilterdata : GXProcedure
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
            return "trn_pageww_Services_Execute" ;
         }

      }

      public trn_pagewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_pagewwgetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV16MaxItems = 10;
         AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
         AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_PAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_PAGENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEJSONCONTENT") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEJSONCONTENTOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEGJSHTML") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEGJSHTMLOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEGJSJSON") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEGJSJSONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGECHILDREN") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGECHILDRENOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_PageWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_PageWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_PageWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME") == 0 )
            {
               AV11TFTrn_PageName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME_SEL") == 0 )
            {
               AV12TFTrn_PageName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT") == 0 )
            {
               AV36TFPageJsonContent = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT_SEL") == 0 )
            {
               AV37TFPageJsonContent_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML") == 0 )
            {
               AV38TFPageGJSHtml = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML_SEL") == 0 )
            {
               AV39TFPageGJSHtml_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON") == 0 )
            {
               AV40TFPageGJSJson = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON_SEL") == 0 )
            {
               AV41TFPageGJSJson_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEISPUBLISHED_SEL") == 0 )
            {
               AV43TFPageIsPublished_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEISCONTENTPAGE_SEL") == 0 )
            {
               AV42TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN") == 0 )
            {
               AV44TFPageChildren = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN_SEL") == 0 )
            {
               AV45TFPageChildren_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_PAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_PageName = AV13SearchTxt;
         AV12TFTrn_PageName_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P00852 */
         pr_default.execute(0, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK852 = false;
            A397Trn_PageName = P00852_A397Trn_PageName[0];
            A424PageChildren = P00852_A424PageChildren[0];
            n424PageChildren = P00852_n424PageChildren[0];
            A423PageIsPublished = P00852_A423PageIsPublished[0];
            n423PageIsPublished = P00852_n423PageIsPublished[0];
            A422PageGJSJson = P00852_A422PageGJSJson[0];
            n422PageGJSJson = P00852_n422PageGJSJson[0];
            A421PageGJSHtml = P00852_A421PageGJSHtml[0];
            n421PageGJSHtml = P00852_n421PageGJSHtml[0];
            A420PageJsonContent = P00852_A420PageJsonContent[0];
            n420PageJsonContent = P00852_n420PageJsonContent[0];
            A429PageIsContentPage = P00852_A429PageIsContentPage[0];
            n429PageIsContentPage = P00852_n429PageIsContentPage[0];
            A392Trn_PageId = P00852_A392Trn_PageId[0];
            A29LocationId = P00852_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00852_A397Trn_PageName[0], A397Trn_PageName) == 0 ) )
               {
                  BRK852 = false;
                  A392Trn_PageId = P00852_A392Trn_PageId[0];
                  A29LocationId = P00852_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK852 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A397Trn_PageName)) ? "<#Empty#>" : A397Trn_PageName);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK852 )
            {
               BRK852 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPAGEJSONCONTENTOPTIONS' Routine */
         returnInSub = false;
         AV36TFPageJsonContent = AV13SearchTxt;
         AV37TFPageJsonContent_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P00853 */
         pr_default.execute(1, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK854 = false;
            A420PageJsonContent = P00853_A420PageJsonContent[0];
            n420PageJsonContent = P00853_n420PageJsonContent[0];
            A424PageChildren = P00853_A424PageChildren[0];
            n424PageChildren = P00853_n424PageChildren[0];
            A423PageIsPublished = P00853_A423PageIsPublished[0];
            n423PageIsPublished = P00853_n423PageIsPublished[0];
            A422PageGJSJson = P00853_A422PageGJSJson[0];
            n422PageGJSJson = P00853_n422PageGJSJson[0];
            A421PageGJSHtml = P00853_A421PageGJSHtml[0];
            n421PageGJSHtml = P00853_n421PageGJSHtml[0];
            A397Trn_PageName = P00853_A397Trn_PageName[0];
            A429PageIsContentPage = P00853_A429PageIsContentPage[0];
            n429PageIsContentPage = P00853_n429PageIsContentPage[0];
            A392Trn_PageId = P00853_A392Trn_PageId[0];
            A29LocationId = P00853_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00853_A420PageJsonContent[0], A420PageJsonContent) == 0 ) )
               {
                  BRK854 = false;
                  A392Trn_PageId = P00853_A392Trn_PageId[0];
                  A29LocationId = P00853_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK854 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A420PageJsonContent)) ? "<#Empty#>" : A420PageJsonContent);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK854 )
            {
               BRK854 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAGEGJSHTMLOPTIONS' Routine */
         returnInSub = false;
         AV38TFPageGJSHtml = AV13SearchTxt;
         AV39TFPageGJSHtml_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P00854 */
         pr_default.execute(2, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK856 = false;
            A421PageGJSHtml = P00854_A421PageGJSHtml[0];
            n421PageGJSHtml = P00854_n421PageGJSHtml[0];
            A424PageChildren = P00854_A424PageChildren[0];
            n424PageChildren = P00854_n424PageChildren[0];
            A423PageIsPublished = P00854_A423PageIsPublished[0];
            n423PageIsPublished = P00854_n423PageIsPublished[0];
            A422PageGJSJson = P00854_A422PageGJSJson[0];
            n422PageGJSJson = P00854_n422PageGJSJson[0];
            A420PageJsonContent = P00854_A420PageJsonContent[0];
            n420PageJsonContent = P00854_n420PageJsonContent[0];
            A397Trn_PageName = P00854_A397Trn_PageName[0];
            A429PageIsContentPage = P00854_A429PageIsContentPage[0];
            n429PageIsContentPage = P00854_n429PageIsContentPage[0];
            A392Trn_PageId = P00854_A392Trn_PageId[0];
            A29LocationId = P00854_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00854_A421PageGJSHtml[0], A421PageGJSHtml) == 0 ) )
               {
                  BRK856 = false;
                  A392Trn_PageId = P00854_A392Trn_PageId[0];
                  A29LocationId = P00854_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK856 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A421PageGJSHtml)) ? "<#Empty#>" : A421PageGJSHtml);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK856 )
            {
               BRK856 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPAGEGJSJSONOPTIONS' Routine */
         returnInSub = false;
         AV40TFPageGJSJson = AV13SearchTxt;
         AV41TFPageGJSJson_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P00855 */
         pr_default.execute(3, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK858 = false;
            A422PageGJSJson = P00855_A422PageGJSJson[0];
            n422PageGJSJson = P00855_n422PageGJSJson[0];
            A424PageChildren = P00855_A424PageChildren[0];
            n424PageChildren = P00855_n424PageChildren[0];
            A423PageIsPublished = P00855_A423PageIsPublished[0];
            n423PageIsPublished = P00855_n423PageIsPublished[0];
            A421PageGJSHtml = P00855_A421PageGJSHtml[0];
            n421PageGJSHtml = P00855_n421PageGJSHtml[0];
            A420PageJsonContent = P00855_A420PageJsonContent[0];
            n420PageJsonContent = P00855_n420PageJsonContent[0];
            A397Trn_PageName = P00855_A397Trn_PageName[0];
            A429PageIsContentPage = P00855_A429PageIsContentPage[0];
            n429PageIsContentPage = P00855_n429PageIsContentPage[0];
            A392Trn_PageId = P00855_A392Trn_PageId[0];
            A29LocationId = P00855_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00855_A422PageGJSJson[0], A422PageGJSJson) == 0 ) )
               {
                  BRK858 = false;
                  A392Trn_PageId = P00855_A392Trn_PageId[0];
                  A29LocationId = P00855_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK858 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A422PageGJSJson)) ? "<#Empty#>" : A422PageGJSJson);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK858 )
            {
               BRK858 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPAGECHILDRENOPTIONS' Routine */
         returnInSub = false;
         AV44TFPageChildren = AV13SearchTxt;
         AV45TFPageChildren_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A397Trn_PageName ,
                                              A420PageJsonContent ,
                                              A421PageGJSHtml ,
                                              A422PageGJSJson ,
                                              A423PageIsPublished ,
                                              A429PageIsContentPage ,
                                              A424PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P00856 */
         pr_default.execute(4, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK8510 = false;
            A424PageChildren = P00856_A424PageChildren[0];
            n424PageChildren = P00856_n424PageChildren[0];
            A423PageIsPublished = P00856_A423PageIsPublished[0];
            n423PageIsPublished = P00856_n423PageIsPublished[0];
            A422PageGJSJson = P00856_A422PageGJSJson[0];
            n422PageGJSJson = P00856_n422PageGJSJson[0];
            A421PageGJSHtml = P00856_A421PageGJSHtml[0];
            n421PageGJSHtml = P00856_n421PageGJSHtml[0];
            A420PageJsonContent = P00856_A420PageJsonContent[0];
            n420PageJsonContent = P00856_n420PageJsonContent[0];
            A397Trn_PageName = P00856_A397Trn_PageName[0];
            A429PageIsContentPage = P00856_A429PageIsContentPage[0];
            n429PageIsContentPage = P00856_n429PageIsContentPage[0];
            A392Trn_PageId = P00856_A392Trn_PageId[0];
            A29LocationId = P00856_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A397Trn_PageName) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A420PageJsonContent) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A421PageGJSHtml) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A422PageGJSJson) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A429PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A429PageIsContentPage ) || ( StringUtil.Like( StringUtil.Lower( A424PageChildren) , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00856_A424PageChildren[0], A424PageChildren) == 0 ) )
               {
                  BRK8510 = false;
                  A392Trn_PageId = P00856_A392Trn_PageId[0];
                  A29LocationId = P00856_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK8510 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A424PageChildren)) ? "<#Empty#>" : A424PageChildren);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK8510 )
            {
               BRK8510 = true;
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV27GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV11TFTrn_PageName = "";
         AV12TFTrn_PageName_Sel = "";
         AV36TFPageJsonContent = "";
         AV37TFPageJsonContent_Sel = "";
         AV38TFPageGJSHtml = "";
         AV39TFPageGJSHtml_Sel = "";
         AV40TFPageGJSJson = "";
         AV41TFPageGJSJson_Sel = "";
         AV44TFPageChildren = "";
         AV45TFPageChildren_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = "";
         AV49Trn_pagewwds_2_tftrn_pagename = "";
         AV50Trn_pagewwds_3_tftrn_pagename_sel = "";
         AV51Trn_pagewwds_4_tfpagejsoncontent = "";
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = "";
         AV53Trn_pagewwds_6_tfpagegjshtml = "";
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = "";
         AV55Trn_pagewwds_8_tfpagegjsjson = "";
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = "";
         AV59Trn_pagewwds_12_tfpagechildren = "";
         AV60Trn_pagewwds_13_tfpagechildren_sel = "";
         lV48Trn_pagewwds_1_filterfulltext = "";
         lV49Trn_pagewwds_2_tftrn_pagename = "";
         lV51Trn_pagewwds_4_tfpagejsoncontent = "";
         lV53Trn_pagewwds_6_tfpagegjshtml = "";
         lV55Trn_pagewwds_8_tfpagegjsjson = "";
         lV59Trn_pagewwds_12_tfpagechildren = "";
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         P00852_A397Trn_PageName = new string[] {""} ;
         P00852_A424PageChildren = new string[] {""} ;
         P00852_n424PageChildren = new bool[] {false} ;
         P00852_A423PageIsPublished = new bool[] {false} ;
         P00852_n423PageIsPublished = new bool[] {false} ;
         P00852_A422PageGJSJson = new string[] {""} ;
         P00852_n422PageGJSJson = new bool[] {false} ;
         P00852_A421PageGJSHtml = new string[] {""} ;
         P00852_n421PageGJSHtml = new bool[] {false} ;
         P00852_A420PageJsonContent = new string[] {""} ;
         P00852_n420PageJsonContent = new bool[] {false} ;
         P00852_A429PageIsContentPage = new bool[] {false} ;
         P00852_n429PageIsContentPage = new bool[] {false} ;
         P00852_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00852_A29LocationId = new Guid[] {Guid.Empty} ;
         A392Trn_PageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV18Option = "";
         P00853_A420PageJsonContent = new string[] {""} ;
         P00853_n420PageJsonContent = new bool[] {false} ;
         P00853_A424PageChildren = new string[] {""} ;
         P00853_n424PageChildren = new bool[] {false} ;
         P00853_A423PageIsPublished = new bool[] {false} ;
         P00853_n423PageIsPublished = new bool[] {false} ;
         P00853_A422PageGJSJson = new string[] {""} ;
         P00853_n422PageGJSJson = new bool[] {false} ;
         P00853_A421PageGJSHtml = new string[] {""} ;
         P00853_n421PageGJSHtml = new bool[] {false} ;
         P00853_A397Trn_PageName = new string[] {""} ;
         P00853_A429PageIsContentPage = new bool[] {false} ;
         P00853_n429PageIsContentPage = new bool[] {false} ;
         P00853_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00853_A29LocationId = new Guid[] {Guid.Empty} ;
         P00854_A421PageGJSHtml = new string[] {""} ;
         P00854_n421PageGJSHtml = new bool[] {false} ;
         P00854_A424PageChildren = new string[] {""} ;
         P00854_n424PageChildren = new bool[] {false} ;
         P00854_A423PageIsPublished = new bool[] {false} ;
         P00854_n423PageIsPublished = new bool[] {false} ;
         P00854_A422PageGJSJson = new string[] {""} ;
         P00854_n422PageGJSJson = new bool[] {false} ;
         P00854_A420PageJsonContent = new string[] {""} ;
         P00854_n420PageJsonContent = new bool[] {false} ;
         P00854_A397Trn_PageName = new string[] {""} ;
         P00854_A429PageIsContentPage = new bool[] {false} ;
         P00854_n429PageIsContentPage = new bool[] {false} ;
         P00854_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00854_A29LocationId = new Guid[] {Guid.Empty} ;
         P00855_A422PageGJSJson = new string[] {""} ;
         P00855_n422PageGJSJson = new bool[] {false} ;
         P00855_A424PageChildren = new string[] {""} ;
         P00855_n424PageChildren = new bool[] {false} ;
         P00855_A423PageIsPublished = new bool[] {false} ;
         P00855_n423PageIsPublished = new bool[] {false} ;
         P00855_A421PageGJSHtml = new string[] {""} ;
         P00855_n421PageGJSHtml = new bool[] {false} ;
         P00855_A420PageJsonContent = new string[] {""} ;
         P00855_n420PageJsonContent = new bool[] {false} ;
         P00855_A397Trn_PageName = new string[] {""} ;
         P00855_A429PageIsContentPage = new bool[] {false} ;
         P00855_n429PageIsContentPage = new bool[] {false} ;
         P00855_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00855_A29LocationId = new Guid[] {Guid.Empty} ;
         P00856_A424PageChildren = new string[] {""} ;
         P00856_n424PageChildren = new bool[] {false} ;
         P00856_A423PageIsPublished = new bool[] {false} ;
         P00856_n423PageIsPublished = new bool[] {false} ;
         P00856_A422PageGJSJson = new string[] {""} ;
         P00856_n422PageGJSJson = new bool[] {false} ;
         P00856_A421PageGJSHtml = new string[] {""} ;
         P00856_n421PageGJSHtml = new bool[] {false} ;
         P00856_A420PageJsonContent = new string[] {""} ;
         P00856_n420PageJsonContent = new bool[] {false} ;
         P00856_A397Trn_PageName = new string[] {""} ;
         P00856_A429PageIsContentPage = new bool[] {false} ;
         P00856_n429PageIsContentPage = new bool[] {false} ;
         P00856_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00856_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pagewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00852_A397Trn_PageName, P00852_A424PageChildren, P00852_n424PageChildren, P00852_A423PageIsPublished, P00852_n423PageIsPublished, P00852_A422PageGJSJson, P00852_n422PageGJSJson, P00852_A421PageGJSHtml, P00852_n421PageGJSHtml, P00852_A420PageJsonContent,
               P00852_n420PageJsonContent, P00852_A429PageIsContentPage, P00852_n429PageIsContentPage, P00852_A392Trn_PageId, P00852_A29LocationId
               }
               , new Object[] {
               P00853_A420PageJsonContent, P00853_n420PageJsonContent, P00853_A424PageChildren, P00853_n424PageChildren, P00853_A423PageIsPublished, P00853_n423PageIsPublished, P00853_A422PageGJSJson, P00853_n422PageGJSJson, P00853_A421PageGJSHtml, P00853_n421PageGJSHtml,
               P00853_A397Trn_PageName, P00853_A429PageIsContentPage, P00853_n429PageIsContentPage, P00853_A392Trn_PageId, P00853_A29LocationId
               }
               , new Object[] {
               P00854_A421PageGJSHtml, P00854_n421PageGJSHtml, P00854_A424PageChildren, P00854_n424PageChildren, P00854_A423PageIsPublished, P00854_n423PageIsPublished, P00854_A422PageGJSJson, P00854_n422PageGJSJson, P00854_A420PageJsonContent, P00854_n420PageJsonContent,
               P00854_A397Trn_PageName, P00854_A429PageIsContentPage, P00854_n429PageIsContentPage, P00854_A392Trn_PageId, P00854_A29LocationId
               }
               , new Object[] {
               P00855_A422PageGJSJson, P00855_n422PageGJSJson, P00855_A424PageChildren, P00855_n424PageChildren, P00855_A423PageIsPublished, P00855_n423PageIsPublished, P00855_A421PageGJSHtml, P00855_n421PageGJSHtml, P00855_A420PageJsonContent, P00855_n420PageJsonContent,
               P00855_A397Trn_PageName, P00855_A429PageIsContentPage, P00855_n429PageIsContentPage, P00855_A392Trn_PageId, P00855_A29LocationId
               }
               , new Object[] {
               P00856_A424PageChildren, P00856_n424PageChildren, P00856_A423PageIsPublished, P00856_n423PageIsPublished, P00856_A422PageGJSJson, P00856_n422PageGJSJson, P00856_A421PageGJSHtml, P00856_n421PageGJSHtml, P00856_A420PageJsonContent, P00856_n420PageJsonContent,
               P00856_A397Trn_PageName, P00856_A429PageIsContentPage, P00856_n429PageIsContentPage, P00856_A392Trn_PageId, P00856_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV43TFPageIsPublished_Sel ;
      private short AV42TFPageIsContentPage_Sel ;
      private short AV57Trn_pagewwds_10_tfpageispublished_sel ;
      private short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ;
      private int AV46GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool A423PageIsPublished ;
      private bool A429PageIsContentPage ;
      private bool BRK852 ;
      private bool n424PageChildren ;
      private bool n423PageIsPublished ;
      private bool n422PageGJSJson ;
      private bool n421PageGJSHtml ;
      private bool n420PageJsonContent ;
      private bool n429PageIsContentPage ;
      private bool BRK854 ;
      private bool BRK856 ;
      private bool BRK858 ;
      private bool BRK8510 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFTrn_PageName ;
      private string AV12TFTrn_PageName_Sel ;
      private string AV36TFPageJsonContent ;
      private string AV37TFPageJsonContent_Sel ;
      private string AV38TFPageGJSHtml ;
      private string AV39TFPageGJSHtml_Sel ;
      private string AV40TFPageGJSJson ;
      private string AV41TFPageGJSJson_Sel ;
      private string AV44TFPageChildren ;
      private string AV45TFPageChildren_Sel ;
      private string AV48Trn_pagewwds_1_filterfulltext ;
      private string AV49Trn_pagewwds_2_tftrn_pagename ;
      private string AV50Trn_pagewwds_3_tftrn_pagename_sel ;
      private string AV51Trn_pagewwds_4_tfpagejsoncontent ;
      private string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ;
      private string AV53Trn_pagewwds_6_tfpagegjshtml ;
      private string AV54Trn_pagewwds_7_tfpagegjshtml_sel ;
      private string AV55Trn_pagewwds_8_tfpagegjsjson ;
      private string AV56Trn_pagewwds_9_tfpagegjsjson_sel ;
      private string AV59Trn_pagewwds_12_tfpagechildren ;
      private string AV60Trn_pagewwds_13_tfpagechildren_sel ;
      private string lV48Trn_pagewwds_1_filterfulltext ;
      private string lV49Trn_pagewwds_2_tftrn_pagename ;
      private string lV51Trn_pagewwds_4_tfpagejsoncontent ;
      private string lV53Trn_pagewwds_6_tfpagegjshtml ;
      private string lV55Trn_pagewwds_8_tfpagegjsjson ;
      private string lV59Trn_pagewwds_12_tfpagechildren ;
      private string A397Trn_PageName ;
      private string AV18Option ;
      private Guid A392Trn_PageId ;
      private Guid A29LocationId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV26GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00852_A397Trn_PageName ;
      private string[] P00852_A424PageChildren ;
      private bool[] P00852_n424PageChildren ;
      private bool[] P00852_A423PageIsPublished ;
      private bool[] P00852_n423PageIsPublished ;
      private string[] P00852_A422PageGJSJson ;
      private bool[] P00852_n422PageGJSJson ;
      private string[] P00852_A421PageGJSHtml ;
      private bool[] P00852_n421PageGJSHtml ;
      private string[] P00852_A420PageJsonContent ;
      private bool[] P00852_n420PageJsonContent ;
      private bool[] P00852_A429PageIsContentPage ;
      private bool[] P00852_n429PageIsContentPage ;
      private Guid[] P00852_A392Trn_PageId ;
      private Guid[] P00852_A29LocationId ;
      private string[] P00853_A420PageJsonContent ;
      private bool[] P00853_n420PageJsonContent ;
      private string[] P00853_A424PageChildren ;
      private bool[] P00853_n424PageChildren ;
      private bool[] P00853_A423PageIsPublished ;
      private bool[] P00853_n423PageIsPublished ;
      private string[] P00853_A422PageGJSJson ;
      private bool[] P00853_n422PageGJSJson ;
      private string[] P00853_A421PageGJSHtml ;
      private bool[] P00853_n421PageGJSHtml ;
      private string[] P00853_A397Trn_PageName ;
      private bool[] P00853_A429PageIsContentPage ;
      private bool[] P00853_n429PageIsContentPage ;
      private Guid[] P00853_A392Trn_PageId ;
      private Guid[] P00853_A29LocationId ;
      private string[] P00854_A421PageGJSHtml ;
      private bool[] P00854_n421PageGJSHtml ;
      private string[] P00854_A424PageChildren ;
      private bool[] P00854_n424PageChildren ;
      private bool[] P00854_A423PageIsPublished ;
      private bool[] P00854_n423PageIsPublished ;
      private string[] P00854_A422PageGJSJson ;
      private bool[] P00854_n422PageGJSJson ;
      private string[] P00854_A420PageJsonContent ;
      private bool[] P00854_n420PageJsonContent ;
      private string[] P00854_A397Trn_PageName ;
      private bool[] P00854_A429PageIsContentPage ;
      private bool[] P00854_n429PageIsContentPage ;
      private Guid[] P00854_A392Trn_PageId ;
      private Guid[] P00854_A29LocationId ;
      private string[] P00855_A422PageGJSJson ;
      private bool[] P00855_n422PageGJSJson ;
      private string[] P00855_A424PageChildren ;
      private bool[] P00855_n424PageChildren ;
      private bool[] P00855_A423PageIsPublished ;
      private bool[] P00855_n423PageIsPublished ;
      private string[] P00855_A421PageGJSHtml ;
      private bool[] P00855_n421PageGJSHtml ;
      private string[] P00855_A420PageJsonContent ;
      private bool[] P00855_n420PageJsonContent ;
      private string[] P00855_A397Trn_PageName ;
      private bool[] P00855_A429PageIsContentPage ;
      private bool[] P00855_n429PageIsContentPage ;
      private Guid[] P00855_A392Trn_PageId ;
      private Guid[] P00855_A29LocationId ;
      private string[] P00856_A424PageChildren ;
      private bool[] P00856_n424PageChildren ;
      private bool[] P00856_A423PageIsPublished ;
      private bool[] P00856_n423PageIsPublished ;
      private string[] P00856_A422PageGJSJson ;
      private bool[] P00856_n422PageGJSJson ;
      private string[] P00856_A421PageGJSHtml ;
      private bool[] P00856_n421PageGJSHtml ;
      private string[] P00856_A420PageJsonContent ;
      private bool[] P00856_n420PageJsonContent ;
      private string[] P00856_A397Trn_PageName ;
      private bool[] P00856_A429PageIsContentPage ;
      private bool[] P00856_n429PageIsContentPage ;
      private Guid[] P00856_A392Trn_PageId ;
      private Guid[] P00856_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_pagewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00852( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageName, PageChildren, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, PageIsContentPage, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_PageName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00853( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PageJsonContent, PageChildren, PageIsPublished, PageGJSJson, PageGJSHtml, Trn_PageName, PageIsContentPage, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageJsonContent";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00854( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT PageGJSHtml, PageChildren, PageIsPublished, PageGJSJson, PageJsonContent, Trn_PageName, PageIsContentPage, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageGJSHtml";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00855( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT PageGJSJson, PageChildren, PageIsPublished, PageGJSHtml, PageJsonContent, Trn_PageName, PageIsContentPage, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageGJSJson";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00856( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A397Trn_PageName ,
                                             string A420PageJsonContent ,
                                             string A421PageGJSHtml ,
                                             string A422PageGJSJson ,
                                             bool A423PageIsPublished ,
                                             bool A429PageIsContentPage ,
                                             string A424PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT PageChildren, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageName, PageIsContentPage, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageChildren";
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
                     return conditional_P00852(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P00853(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 2 :
                     return conditional_P00854(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 3 :
                     return conditional_P00855(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 4 :
                     return conditional_P00856(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00852;
          prmP00852 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00853;
          prmP00853 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00854;
          prmP00854 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00855;
          prmP00855 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00856;
          prmP00856 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00852", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00852,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00853", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00853,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00854", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00854,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00855", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00855,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00856", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00856,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
