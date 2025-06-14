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
   public class trn_mediawwgetfilterdata : GXProcedure
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
            return "trn_mediaww_Services_Execute" ;
         }

      }

      public trn_mediawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_mediawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MEDIANAME") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIANAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MEDIATYPE") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIATYPEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MEDIAURL") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIAURLOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("Trn_MediaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_MediaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Trn_MediaWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIANAME") == 0 )
            {
               AV11TFMediaName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIANAME_SEL") == 0 )
            {
               AV12TFMediaName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIASIZE") == 0 )
            {
               AV13TFMediaSize = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFMediaSize_To = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIATYPE") == 0 )
            {
               AV15TFMediaType = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIATYPE_SEL") == 0 )
            {
               AV16TFMediaType_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIAURL") == 0 )
            {
               AV17TFMediaUrl = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMEDIAURL_SEL") == 0 )
            {
               AV18TFMediaUrl_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMEDIANAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFMediaName = AV19SearchTxt;
         AV12TFMediaName_Sel = "";
         AV44Trn_mediawwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_mediawwds_2_tfmedianame = AV11TFMediaName;
         AV46Trn_mediawwds_3_tfmedianame_sel = AV12TFMediaName_Sel;
         AV47Trn_mediawwds_4_tfmediasize = AV13TFMediaSize;
         AV48Trn_mediawwds_5_tfmediasize_to = AV14TFMediaSize_To;
         AV49Trn_mediawwds_6_tfmediatype = AV15TFMediaType;
         AV50Trn_mediawwds_7_tfmediatype_sel = AV16TFMediaType_Sel;
         AV51Trn_mediawwds_8_tfmediaurl = AV17TFMediaUrl;
         AV52Trn_mediawwds_9_tfmediaurl_sel = AV18TFMediaUrl_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Trn_mediawwds_1_filterfulltext ,
                                              AV46Trn_mediawwds_3_tfmedianame_sel ,
                                              AV45Trn_mediawwds_2_tfmedianame ,
                                              AV47Trn_mediawwds_4_tfmediasize ,
                                              AV48Trn_mediawwds_5_tfmediasize_to ,
                                              AV50Trn_mediawwds_7_tfmediatype_sel ,
                                              AV49Trn_mediawwds_6_tfmediatype ,
                                              AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                              AV51Trn_mediawwds_8_tfmediaurl ,
                                              A414MediaName ,
                                              A417MediaSize ,
                                              A418MediaType ,
                                              A416MediaUrl } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV45Trn_mediawwds_2_tfmedianame = StringUtil.Concat( StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame), "%", "");
         lV49Trn_mediawwds_6_tfmediatype = StringUtil.PadR( StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype), 20, "%");
         lV51Trn_mediawwds_8_tfmediaurl = StringUtil.Concat( StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl), "%", "");
         /* Using cursor P00822 */
         pr_default.execute(0, new Object[] {lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV45Trn_mediawwds_2_tfmedianame, AV46Trn_mediawwds_3_tfmedianame_sel, AV47Trn_mediawwds_4_tfmediasize, AV48Trn_mediawwds_5_tfmediasize_to, lV49Trn_mediawwds_6_tfmediatype, AV50Trn_mediawwds_7_tfmediatype_sel, lV51Trn_mediawwds_8_tfmediaurl, AV52Trn_mediawwds_9_tfmediaurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK822 = false;
            A414MediaName = P00822_A414MediaName[0];
            A416MediaUrl = P00822_A416MediaUrl[0];
            A418MediaType = P00822_A418MediaType[0];
            A417MediaSize = P00822_A417MediaSize[0];
            A413MediaId = P00822_A413MediaId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00822_A414MediaName[0], A414MediaName) == 0 ) )
            {
               BRK822 = false;
               A413MediaId = P00822_A413MediaId[0];
               AV29count = (long)(AV29count+1);
               BRK822 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A414MediaName)) ? "<#Empty#>" : A414MediaName);
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
            if ( ! BRK822 )
            {
               BRK822 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMEDIATYPEOPTIONS' Routine */
         returnInSub = false;
         AV15TFMediaType = AV19SearchTxt;
         AV16TFMediaType_Sel = "";
         AV44Trn_mediawwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_mediawwds_2_tfmedianame = AV11TFMediaName;
         AV46Trn_mediawwds_3_tfmedianame_sel = AV12TFMediaName_Sel;
         AV47Trn_mediawwds_4_tfmediasize = AV13TFMediaSize;
         AV48Trn_mediawwds_5_tfmediasize_to = AV14TFMediaSize_To;
         AV49Trn_mediawwds_6_tfmediatype = AV15TFMediaType;
         AV50Trn_mediawwds_7_tfmediatype_sel = AV16TFMediaType_Sel;
         AV51Trn_mediawwds_8_tfmediaurl = AV17TFMediaUrl;
         AV52Trn_mediawwds_9_tfmediaurl_sel = AV18TFMediaUrl_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Trn_mediawwds_1_filterfulltext ,
                                              AV46Trn_mediawwds_3_tfmedianame_sel ,
                                              AV45Trn_mediawwds_2_tfmedianame ,
                                              AV47Trn_mediawwds_4_tfmediasize ,
                                              AV48Trn_mediawwds_5_tfmediasize_to ,
                                              AV50Trn_mediawwds_7_tfmediatype_sel ,
                                              AV49Trn_mediawwds_6_tfmediatype ,
                                              AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                              AV51Trn_mediawwds_8_tfmediaurl ,
                                              A414MediaName ,
                                              A417MediaSize ,
                                              A418MediaType ,
                                              A416MediaUrl } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV45Trn_mediawwds_2_tfmedianame = StringUtil.Concat( StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame), "%", "");
         lV49Trn_mediawwds_6_tfmediatype = StringUtil.PadR( StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype), 20, "%");
         lV51Trn_mediawwds_8_tfmediaurl = StringUtil.Concat( StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl), "%", "");
         /* Using cursor P00823 */
         pr_default.execute(1, new Object[] {lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV45Trn_mediawwds_2_tfmedianame, AV46Trn_mediawwds_3_tfmedianame_sel, AV47Trn_mediawwds_4_tfmediasize, AV48Trn_mediawwds_5_tfmediasize_to, lV49Trn_mediawwds_6_tfmediatype, AV50Trn_mediawwds_7_tfmediatype_sel, lV51Trn_mediawwds_8_tfmediaurl, AV52Trn_mediawwds_9_tfmediaurl_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK824 = false;
            A418MediaType = P00823_A418MediaType[0];
            A416MediaUrl = P00823_A416MediaUrl[0];
            A417MediaSize = P00823_A417MediaSize[0];
            A414MediaName = P00823_A414MediaName[0];
            A413MediaId = P00823_A413MediaId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00823_A418MediaType[0], A418MediaType) == 0 ) )
            {
               BRK824 = false;
               A413MediaId = P00823_A413MediaId[0];
               AV29count = (long)(AV29count+1);
               BRK824 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A418MediaType)) ? "<#Empty#>" : A418MediaType);
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
            if ( ! BRK824 )
            {
               BRK824 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMEDIAURLOPTIONS' Routine */
         returnInSub = false;
         AV17TFMediaUrl = AV19SearchTxt;
         AV18TFMediaUrl_Sel = "";
         AV44Trn_mediawwds_1_filterfulltext = AV41FilterFullText;
         AV45Trn_mediawwds_2_tfmedianame = AV11TFMediaName;
         AV46Trn_mediawwds_3_tfmedianame_sel = AV12TFMediaName_Sel;
         AV47Trn_mediawwds_4_tfmediasize = AV13TFMediaSize;
         AV48Trn_mediawwds_5_tfmediasize_to = AV14TFMediaSize_To;
         AV49Trn_mediawwds_6_tfmediatype = AV15TFMediaType;
         AV50Trn_mediawwds_7_tfmediatype_sel = AV16TFMediaType_Sel;
         AV51Trn_mediawwds_8_tfmediaurl = AV17TFMediaUrl;
         AV52Trn_mediawwds_9_tfmediaurl_sel = AV18TFMediaUrl_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV44Trn_mediawwds_1_filterfulltext ,
                                              AV46Trn_mediawwds_3_tfmedianame_sel ,
                                              AV45Trn_mediawwds_2_tfmedianame ,
                                              AV47Trn_mediawwds_4_tfmediasize ,
                                              AV48Trn_mediawwds_5_tfmediasize_to ,
                                              AV50Trn_mediawwds_7_tfmediatype_sel ,
                                              AV49Trn_mediawwds_6_tfmediatype ,
                                              AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                              AV51Trn_mediawwds_8_tfmediaurl ,
                                              A414MediaName ,
                                              A417MediaSize ,
                                              A418MediaType ,
                                              A416MediaUrl } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV44Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext), "%", "");
         lV45Trn_mediawwds_2_tfmedianame = StringUtil.Concat( StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame), "%", "");
         lV49Trn_mediawwds_6_tfmediatype = StringUtil.PadR( StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype), 20, "%");
         lV51Trn_mediawwds_8_tfmediaurl = StringUtil.Concat( StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl), "%", "");
         /* Using cursor P00824 */
         pr_default.execute(2, new Object[] {lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV44Trn_mediawwds_1_filterfulltext, lV45Trn_mediawwds_2_tfmedianame, AV46Trn_mediawwds_3_tfmedianame_sel, AV47Trn_mediawwds_4_tfmediasize, AV48Trn_mediawwds_5_tfmediasize_to, lV49Trn_mediawwds_6_tfmediatype, AV50Trn_mediawwds_7_tfmediatype_sel, lV51Trn_mediawwds_8_tfmediaurl, AV52Trn_mediawwds_9_tfmediaurl_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK826 = false;
            A416MediaUrl = P00824_A416MediaUrl[0];
            A418MediaType = P00824_A418MediaType[0];
            A417MediaSize = P00824_A417MediaSize[0];
            A414MediaName = P00824_A414MediaName[0];
            A413MediaId = P00824_A413MediaId[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00824_A416MediaUrl[0], A416MediaUrl) == 0 ) )
            {
               BRK826 = false;
               A413MediaId = P00824_A413MediaId[0];
               AV29count = (long)(AV29count+1);
               BRK826 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A416MediaUrl)) ? "<#Empty#>" : A416MediaUrl);
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
            if ( ! BRK826 )
            {
               BRK826 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV11TFMediaName = "";
         AV12TFMediaName_Sel = "";
         AV15TFMediaType = "";
         AV16TFMediaType_Sel = "";
         AV17TFMediaUrl = "";
         AV18TFMediaUrl_Sel = "";
         AV44Trn_mediawwds_1_filterfulltext = "";
         AV45Trn_mediawwds_2_tfmedianame = "";
         AV46Trn_mediawwds_3_tfmedianame_sel = "";
         AV49Trn_mediawwds_6_tfmediatype = "";
         AV50Trn_mediawwds_7_tfmediatype_sel = "";
         AV51Trn_mediawwds_8_tfmediaurl = "";
         AV52Trn_mediawwds_9_tfmediaurl_sel = "";
         lV44Trn_mediawwds_1_filterfulltext = "";
         lV45Trn_mediawwds_2_tfmedianame = "";
         lV49Trn_mediawwds_6_tfmediatype = "";
         lV51Trn_mediawwds_8_tfmediaurl = "";
         A414MediaName = "";
         A418MediaType = "";
         A416MediaUrl = "";
         P00822_A414MediaName = new string[] {""} ;
         P00822_A416MediaUrl = new string[] {""} ;
         P00822_A418MediaType = new string[] {""} ;
         P00822_A417MediaSize = new int[1] ;
         P00822_A413MediaId = new Guid[] {Guid.Empty} ;
         A413MediaId = Guid.Empty;
         AV24Option = "";
         P00823_A418MediaType = new string[] {""} ;
         P00823_A416MediaUrl = new string[] {""} ;
         P00823_A417MediaSize = new int[1] ;
         P00823_A414MediaName = new string[] {""} ;
         P00823_A413MediaId = new Guid[] {Guid.Empty} ;
         P00824_A416MediaUrl = new string[] {""} ;
         P00824_A418MediaType = new string[] {""} ;
         P00824_A417MediaSize = new int[1] ;
         P00824_A414MediaName = new string[] {""} ;
         P00824_A413MediaId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_mediawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00822_A414MediaName, P00822_A416MediaUrl, P00822_A418MediaType, P00822_A417MediaSize, P00822_A413MediaId
               }
               , new Object[] {
               P00823_A418MediaType, P00823_A416MediaUrl, P00823_A417MediaSize, P00823_A414MediaName, P00823_A413MediaId
               }
               , new Object[] {
               P00824_A416MediaUrl, P00824_A418MediaType, P00824_A417MediaSize, P00824_A414MediaName, P00824_A413MediaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV42GXV1 ;
      private int AV13TFMediaSize ;
      private int AV14TFMediaSize_To ;
      private int AV47Trn_mediawwds_4_tfmediasize ;
      private int AV48Trn_mediawwds_5_tfmediasize_to ;
      private int A417MediaSize ;
      private long AV29count ;
      private string AV15TFMediaType ;
      private string AV16TFMediaType_Sel ;
      private string AV49Trn_mediawwds_6_tfmediatype ;
      private string AV50Trn_mediawwds_7_tfmediatype_sel ;
      private string lV49Trn_mediawwds_6_tfmediatype ;
      private string A418MediaType ;
      private bool returnInSub ;
      private bool BRK822 ;
      private bool BRK824 ;
      private bool BRK826 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFMediaName ;
      private string AV12TFMediaName_Sel ;
      private string AV17TFMediaUrl ;
      private string AV18TFMediaUrl_Sel ;
      private string AV44Trn_mediawwds_1_filterfulltext ;
      private string AV45Trn_mediawwds_2_tfmedianame ;
      private string AV46Trn_mediawwds_3_tfmedianame_sel ;
      private string AV51Trn_mediawwds_8_tfmediaurl ;
      private string AV52Trn_mediawwds_9_tfmediaurl_sel ;
      private string lV44Trn_mediawwds_1_filterfulltext ;
      private string lV45Trn_mediawwds_2_tfmedianame ;
      private string lV51Trn_mediawwds_8_tfmediaurl ;
      private string A414MediaName ;
      private string A416MediaUrl ;
      private string AV24Option ;
      private Guid A413MediaId ;
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
      private string[] P00822_A414MediaName ;
      private string[] P00822_A416MediaUrl ;
      private string[] P00822_A418MediaType ;
      private int[] P00822_A417MediaSize ;
      private Guid[] P00822_A413MediaId ;
      private string[] P00823_A418MediaType ;
      private string[] P00823_A416MediaUrl ;
      private int[] P00823_A417MediaSize ;
      private string[] P00823_A414MediaName ;
      private Guid[] P00823_A413MediaId ;
      private string[] P00824_A416MediaUrl ;
      private string[] P00824_A418MediaType ;
      private int[] P00824_A417MediaSize ;
      private string[] P00824_A414MediaName ;
      private Guid[] P00824_A413MediaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_mediawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00822( IGxContext context ,
                                             string AV44Trn_mediawwds_1_filterfulltext ,
                                             string AV46Trn_mediawwds_3_tfmedianame_sel ,
                                             string AV45Trn_mediawwds_2_tfmedianame ,
                                             int AV47Trn_mediawwds_4_tfmediasize ,
                                             int AV48Trn_mediawwds_5_tfmediasize_to ,
                                             string AV50Trn_mediawwds_7_tfmediatype_sel ,
                                             string AV49Trn_mediawwds_6_tfmediatype ,
                                             string AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                             string AV51Trn_mediawwds_8_tfmediaurl ,
                                             string A414MediaName ,
                                             int A417MediaSize ,
                                             string A418MediaType ,
                                             string A416MediaUrl )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MediaName, MediaUrl, MediaType, MediaSize, MediaId FROM Trn_Media";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(MediaName) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(MediaSize,'99999999'), 2) like '%' || :lV44Trn_mediawwds_1_filterfulltext) or ( LOWER(MediaType) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( LOWER(MediaUrl) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame)) ) )
         {
            AddWhere(sWhereString, "(MediaName like :lV45Trn_mediawwds_2_tfmedianame)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ! ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaName = ( :AV46Trn_mediawwds_3_tfmedianame_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaName))=0))");
         }
         if ( ! (0==AV47Trn_mediawwds_4_tfmediasize) )
         {
            AddWhere(sWhereString, "(MediaSize >= :AV47Trn_mediawwds_4_tfmediasize)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV48Trn_mediawwds_5_tfmediasize_to) )
         {
            AddWhere(sWhereString, "(MediaSize <= :AV48Trn_mediawwds_5_tfmediasize_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype)) ) )
         {
            AddWhere(sWhereString, "(MediaType like :lV49Trn_mediawwds_6_tfmediatype)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ! ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaType = ( :AV50Trn_mediawwds_7_tfmediatype_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaType))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl)) ) )
         {
            AddWhere(sWhereString, "(MediaUrl like :lV51Trn_mediawwds_8_tfmediaurl)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ! ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaUrl = ( :AV52Trn_mediawwds_9_tfmediaurl_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaUrl))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MediaName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00823( IGxContext context ,
                                             string AV44Trn_mediawwds_1_filterfulltext ,
                                             string AV46Trn_mediawwds_3_tfmedianame_sel ,
                                             string AV45Trn_mediawwds_2_tfmedianame ,
                                             int AV47Trn_mediawwds_4_tfmediasize ,
                                             int AV48Trn_mediawwds_5_tfmediasize_to ,
                                             string AV50Trn_mediawwds_7_tfmediatype_sel ,
                                             string AV49Trn_mediawwds_6_tfmediatype ,
                                             string AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                             string AV51Trn_mediawwds_8_tfmediaurl ,
                                             string A414MediaName ,
                                             int A417MediaSize ,
                                             string A418MediaType ,
                                             string A416MediaUrl )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MediaType, MediaUrl, MediaSize, MediaName, MediaId FROM Trn_Media";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(MediaName) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(MediaSize,'99999999'), 2) like '%' || :lV44Trn_mediawwds_1_filterfulltext) or ( LOWER(MediaType) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( LOWER(MediaUrl) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame)) ) )
         {
            AddWhere(sWhereString, "(MediaName like :lV45Trn_mediawwds_2_tfmedianame)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ! ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaName = ( :AV46Trn_mediawwds_3_tfmedianame_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaName))=0))");
         }
         if ( ! (0==AV47Trn_mediawwds_4_tfmediasize) )
         {
            AddWhere(sWhereString, "(MediaSize >= :AV47Trn_mediawwds_4_tfmediasize)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV48Trn_mediawwds_5_tfmediasize_to) )
         {
            AddWhere(sWhereString, "(MediaSize <= :AV48Trn_mediawwds_5_tfmediasize_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype)) ) )
         {
            AddWhere(sWhereString, "(MediaType like :lV49Trn_mediawwds_6_tfmediatype)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ! ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaType = ( :AV50Trn_mediawwds_7_tfmediatype_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaType))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl)) ) )
         {
            AddWhere(sWhereString, "(MediaUrl like :lV51Trn_mediawwds_8_tfmediaurl)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ! ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaUrl = ( :AV52Trn_mediawwds_9_tfmediaurl_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaUrl))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MediaType";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00824( IGxContext context ,
                                             string AV44Trn_mediawwds_1_filterfulltext ,
                                             string AV46Trn_mediawwds_3_tfmedianame_sel ,
                                             string AV45Trn_mediawwds_2_tfmedianame ,
                                             int AV47Trn_mediawwds_4_tfmediasize ,
                                             int AV48Trn_mediawwds_5_tfmediasize_to ,
                                             string AV50Trn_mediawwds_7_tfmediatype_sel ,
                                             string AV49Trn_mediawwds_6_tfmediatype ,
                                             string AV52Trn_mediawwds_9_tfmediaurl_sel ,
                                             string AV51Trn_mediawwds_8_tfmediaurl ,
                                             string A414MediaName ,
                                             int A417MediaSize ,
                                             string A418MediaType ,
                                             string A416MediaUrl )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT MediaUrl, MediaType, MediaSize, MediaName, MediaId FROM Trn_Media";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(MediaName) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(MediaSize,'99999999'), 2) like '%' || :lV44Trn_mediawwds_1_filterfulltext) or ( LOWER(MediaType) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)) or ( LOWER(MediaUrl) like '%' || LOWER(:lV44Trn_mediawwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_mediawwds_2_tfmedianame)) ) )
         {
            AddWhere(sWhereString, "(MediaName like :lV45Trn_mediawwds_2_tfmedianame)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_mediawwds_3_tfmedianame_sel)) && ! ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaName = ( :AV46Trn_mediawwds_3_tfmedianame_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trn_mediawwds_3_tfmedianame_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaName))=0))");
         }
         if ( ! (0==AV47Trn_mediawwds_4_tfmediasize) )
         {
            AddWhere(sWhereString, "(MediaSize >= :AV47Trn_mediawwds_4_tfmediasize)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV48Trn_mediawwds_5_tfmediasize_to) )
         {
            AddWhere(sWhereString, "(MediaSize <= :AV48Trn_mediawwds_5_tfmediasize_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_mediawwds_6_tfmediatype)) ) )
         {
            AddWhere(sWhereString, "(MediaType like :lV49Trn_mediawwds_6_tfmediatype)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_mediawwds_7_tfmediatype_sel)) && ! ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaType = ( :AV50Trn_mediawwds_7_tfmediatype_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_mediawwds_7_tfmediatype_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaType))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_mediawwds_8_tfmediaurl)) ) )
         {
            AddWhere(sWhereString, "(MediaUrl like :lV51Trn_mediawwds_8_tfmediaurl)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_mediawwds_9_tfmediaurl_sel)) && ! ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(MediaUrl = ( :AV52Trn_mediawwds_9_tfmediaurl_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_mediawwds_9_tfmediaurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MediaUrl))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MediaUrl";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00822(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P00823(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P00824(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_mediawwds_2_tfmedianame",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_mediawwds_3_tfmedianame_sel",GXType.VarChar,100,0) ,
          new ParDef("AV47Trn_mediawwds_4_tfmediasize",GXType.Int32,8,0) ,
          new ParDef("AV48Trn_mediawwds_5_tfmediasize_to",GXType.Int32,8,0) ,
          new ParDef("lV49Trn_mediawwds_6_tfmediatype",GXType.Char,20,0) ,
          new ParDef("AV50Trn_mediawwds_7_tfmediatype_sel",GXType.Char,20,0) ,
          new ParDef("lV51Trn_mediawwds_8_tfmediaurl",GXType.VarChar,1000,0) ,
          new ParDef("AV52Trn_mediawwds_9_tfmediaurl_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP00823;
          prmP00823 = new Object[] {
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_mediawwds_2_tfmedianame",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_mediawwds_3_tfmedianame_sel",GXType.VarChar,100,0) ,
          new ParDef("AV47Trn_mediawwds_4_tfmediasize",GXType.Int32,8,0) ,
          new ParDef("AV48Trn_mediawwds_5_tfmediasize_to",GXType.Int32,8,0) ,
          new ParDef("lV49Trn_mediawwds_6_tfmediatype",GXType.Char,20,0) ,
          new ParDef("AV50Trn_mediawwds_7_tfmediatype_sel",GXType.Char,20,0) ,
          new ParDef("lV51Trn_mediawwds_8_tfmediaurl",GXType.VarChar,1000,0) ,
          new ParDef("AV52Trn_mediawwds_9_tfmediaurl_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP00824;
          prmP00824 = new Object[] {
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Trn_mediawwds_2_tfmedianame",GXType.VarChar,100,0) ,
          new ParDef("AV46Trn_mediawwds_3_tfmedianame_sel",GXType.VarChar,100,0) ,
          new ParDef("AV47Trn_mediawwds_4_tfmediasize",GXType.Int32,8,0) ,
          new ParDef("AV48Trn_mediawwds_5_tfmediasize_to",GXType.Int32,8,0) ,
          new ParDef("lV49Trn_mediawwds_6_tfmediatype",GXType.Char,20,0) ,
          new ParDef("AV50Trn_mediawwds_7_tfmediatype_sel",GXType.Char,20,0) ,
          new ParDef("lV51Trn_mediawwds_8_tfmediaurl",GXType.VarChar,1000,0) ,
          new ParDef("AV52Trn_mediawwds_9_tfmediaurl_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00823", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00823,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00824", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00824,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
