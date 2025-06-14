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
   public class trn_auditwwgetfilterdata : GXProcedure
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
            return "trn_auditww_Services_Execute" ;
         }

      }

      public trn_auditwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_auditwwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITACTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITACTIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITUSERNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITTABLEDIAPLAYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITTABLEDIAPLAYNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITSHORTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITSHORTDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("Trn_AuditWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_AuditWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Trn_AuditWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV11TFAuditDate = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV12TFAuditDate_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV23TFAuditAction = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV24TFAuditAction_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME") == 0 )
            {
               AV21TFAuditUserName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME_SEL") == 0 )
            {
               AV22TFAuditUserName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLEDIAPLAYNAME") == 0 )
            {
               AV50TFAuditTableDiaplayName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLEDIAPLAYNAME_SEL") == 0 )
            {
               AV51TFAuditTableDiaplayName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV17TFAuditShortDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV18TFAuditShortDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAUDITACTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFAuditAction = AV25SearchTxt;
         AV24TFAuditAction_Sel = "";
         AV54Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV55Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV56Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV57Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV58Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV59Trn_auditwwds_6_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_7_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_8_tfaudittablediaplayname = AV50TFAuditTableDiaplayName;
         AV62Trn_auditwwds_9_tfaudittablediaplayname_sel = AV51TFAuditTableDiaplayName_Sel;
         AV63Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV64Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Trn_auditwwds_1_filterfulltext ,
                                              AV55Trn_auditwwds_2_tfauditdate ,
                                              AV56Trn_auditwwds_3_tfauditdate_to ,
                                              AV58Trn_auditwwds_5_tfauditaction_sel ,
                                              AV57Trn_auditwwds_4_tfauditaction ,
                                              AV60Trn_auditwwds_7_tfauditusername_sel ,
                                              AV59Trn_auditwwds_6_tfauditusername ,
                                              AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                              AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                              AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV63Trn_auditwwds_10_tfauditshortdescription ,
                                              A378AuditAction ,
                                              A377AuditUserName ,
                                              A373AuditTableName ,
                                              A375AuditShortDescription ,
                                              A372AuditDate ,
                                              A11OrganisationId ,
                                              AV65Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV57Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction), "%", "");
         lV59Trn_auditwwds_6_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername), "%", "");
         lV61Trn_auditwwds_8_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname), "%", "");
         lV63Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P007U2 */
         pr_default.execute(0, new Object[] {AV65Udparg12, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, AV55Trn_auditwwds_2_tfauditdate, AV56Trn_auditwwds_3_tfauditdate_to, lV57Trn_auditwwds_4_tfauditaction, AV58Trn_auditwwds_5_tfauditaction_sel, lV59Trn_auditwwds_6_tfauditusername, AV60Trn_auditwwds_7_tfauditusername_sel, lV61Trn_auditwwds_8_tfaudittablediaplayname, AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, lV63Trn_auditwwds_10_tfauditshortdescription, AV64Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7U2 = false;
            A11OrganisationId = P007U2_A11OrganisationId[0];
            n11OrganisationId = P007U2_n11OrganisationId[0];
            A378AuditAction = P007U2_A378AuditAction[0];
            A375AuditShortDescription = P007U2_A375AuditShortDescription[0];
            A377AuditUserName = P007U2_A377AuditUserName[0];
            A372AuditDate = P007U2_A372AuditDate[0];
            A373AuditTableName = P007U2_A373AuditTableName[0];
            A371AuditId = P007U2_A371AuditId[0];
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007U2_A378AuditAction[0], A378AuditAction) == 0 ) )
            {
               BRK7U2 = false;
               A371AuditId = P007U2_A371AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK7U2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A378AuditAction)) ? "<#Empty#>" : A378AuditAction);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7U2 )
            {
               BRK7U2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAUDITUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFAuditUserName = AV25SearchTxt;
         AV22TFAuditUserName_Sel = "";
         AV54Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV55Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV56Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV57Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV58Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV59Trn_auditwwds_6_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_7_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_8_tfaudittablediaplayname = AV50TFAuditTableDiaplayName;
         AV62Trn_auditwwds_9_tfaudittablediaplayname_sel = AV51TFAuditTableDiaplayName_Sel;
         AV63Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV64Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Trn_auditwwds_1_filterfulltext ,
                                              AV55Trn_auditwwds_2_tfauditdate ,
                                              AV56Trn_auditwwds_3_tfauditdate_to ,
                                              AV58Trn_auditwwds_5_tfauditaction_sel ,
                                              AV57Trn_auditwwds_4_tfauditaction ,
                                              AV60Trn_auditwwds_7_tfauditusername_sel ,
                                              AV59Trn_auditwwds_6_tfauditusername ,
                                              AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                              AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                              AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV63Trn_auditwwds_10_tfauditshortdescription ,
                                              A378AuditAction ,
                                              A377AuditUserName ,
                                              A373AuditTableName ,
                                              A375AuditShortDescription ,
                                              A372AuditDate ,
                                              A11OrganisationId ,
                                              AV65Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV57Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction), "%", "");
         lV59Trn_auditwwds_6_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername), "%", "");
         lV61Trn_auditwwds_8_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname), "%", "");
         lV63Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P007U3 */
         pr_default.execute(1, new Object[] {AV65Udparg12, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, AV55Trn_auditwwds_2_tfauditdate, AV56Trn_auditwwds_3_tfauditdate_to, lV57Trn_auditwwds_4_tfauditaction, AV58Trn_auditwwds_5_tfauditaction_sel, lV59Trn_auditwwds_6_tfauditusername, AV60Trn_auditwwds_7_tfauditusername_sel, lV61Trn_auditwwds_8_tfaudittablediaplayname, AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, lV63Trn_auditwwds_10_tfauditshortdescription, AV64Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7U4 = false;
            A11OrganisationId = P007U3_A11OrganisationId[0];
            n11OrganisationId = P007U3_n11OrganisationId[0];
            A377AuditUserName = P007U3_A377AuditUserName[0];
            A375AuditShortDescription = P007U3_A375AuditShortDescription[0];
            A378AuditAction = P007U3_A378AuditAction[0];
            A372AuditDate = P007U3_A372AuditDate[0];
            A373AuditTableName = P007U3_A373AuditTableName[0];
            A371AuditId = P007U3_A371AuditId[0];
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007U3_A377AuditUserName[0], A377AuditUserName) == 0 ) )
            {
               BRK7U4 = false;
               A371AuditId = P007U3_A371AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK7U4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A377AuditUserName)) ? "<#Empty#>" : A377AuditUserName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7U4 )
            {
               BRK7U4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADAUDITTABLEDIAPLAYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV50TFAuditTableDiaplayName = AV25SearchTxt;
         AV51TFAuditTableDiaplayName_Sel = "";
         AV54Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV55Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV56Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV57Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV58Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV59Trn_auditwwds_6_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_7_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_8_tfaudittablediaplayname = AV50TFAuditTableDiaplayName;
         AV62Trn_auditwwds_9_tfaudittablediaplayname_sel = AV51TFAuditTableDiaplayName_Sel;
         AV63Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV64Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Trn_auditwwds_1_filterfulltext ,
                                              AV55Trn_auditwwds_2_tfauditdate ,
                                              AV56Trn_auditwwds_3_tfauditdate_to ,
                                              AV58Trn_auditwwds_5_tfauditaction_sel ,
                                              AV57Trn_auditwwds_4_tfauditaction ,
                                              AV60Trn_auditwwds_7_tfauditusername_sel ,
                                              AV59Trn_auditwwds_6_tfauditusername ,
                                              AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                              AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                              AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV63Trn_auditwwds_10_tfauditshortdescription ,
                                              A378AuditAction ,
                                              A377AuditUserName ,
                                              A373AuditTableName ,
                                              A375AuditShortDescription ,
                                              A372AuditDate ,
                                              AV65Udparg12 ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV57Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction), "%", "");
         lV59Trn_auditwwds_6_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername), "%", "");
         lV61Trn_auditwwds_8_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname), "%", "");
         lV63Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P007U4 */
         pr_default.execute(2, new Object[] {AV65Udparg12, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, AV55Trn_auditwwds_2_tfauditdate, AV56Trn_auditwwds_3_tfauditdate_to, lV57Trn_auditwwds_4_tfauditaction, AV58Trn_auditwwds_5_tfauditaction_sel, lV59Trn_auditwwds_6_tfauditusername, AV60Trn_auditwwds_7_tfauditusername_sel, lV61Trn_auditwwds_8_tfaudittablediaplayname, AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, lV63Trn_auditwwds_10_tfauditshortdescription, AV64Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11OrganisationId = P007U4_A11OrganisationId[0];
            n11OrganisationId = P007U4_n11OrganisationId[0];
            A375AuditShortDescription = P007U4_A375AuditShortDescription[0];
            A377AuditUserName = P007U4_A377AuditUserName[0];
            A378AuditAction = P007U4_A378AuditAction[0];
            A372AuditDate = P007U4_A372AuditDate[0];
            A373AuditTableName = P007U4_A373AuditTableName[0];
            A371AuditId = P007U4_A371AuditId[0];
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A491AuditTableDiaplayName)) ? "<#Empty#>" : A491AuditTableDiaplayName);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            if ( ( AV29InsertIndex <= AV31Options.Count ) && ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) == 0 ) )
            {
               AV35count = (long)(Math.Round(NumberUtil.Val( ((string)AV34OptionIndexes.Item(AV29InsertIndex)), "."), 18, MidpointRounding.ToEven));
               AV35count = (long)(AV35count+1);
               AV34OptionIndexes.RemoveItem(AV29InsertIndex);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            }
            else
            {
               AV31Options.Add(AV30Option, AV29InsertIndex);
               AV34OptionIndexes.Add("1", AV29InsertIndex);
            }
            if ( AV31Options.Count == AV26SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADAUDITSHORTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFAuditShortDescription = AV25SearchTxt;
         AV18TFAuditShortDescription_Sel = "";
         AV54Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV55Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV56Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV57Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV58Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV59Trn_auditwwds_6_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_7_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_8_tfaudittablediaplayname = AV50TFAuditTableDiaplayName;
         AV62Trn_auditwwds_9_tfaudittablediaplayname_sel = AV51TFAuditTableDiaplayName_Sel;
         AV63Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV64Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV65Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV54Trn_auditwwds_1_filterfulltext ,
                                              AV55Trn_auditwwds_2_tfauditdate ,
                                              AV56Trn_auditwwds_3_tfauditdate_to ,
                                              AV58Trn_auditwwds_5_tfauditaction_sel ,
                                              AV57Trn_auditwwds_4_tfauditaction ,
                                              AV60Trn_auditwwds_7_tfauditusername_sel ,
                                              AV59Trn_auditwwds_6_tfauditusername ,
                                              AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                              AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                              AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV63Trn_auditwwds_10_tfauditshortdescription ,
                                              A378AuditAction ,
                                              A377AuditUserName ,
                                              A373AuditTableName ,
                                              A375AuditShortDescription ,
                                              A372AuditDate ,
                                              A11OrganisationId ,
                                              AV65Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV54Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext), "%", "");
         lV57Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction), "%", "");
         lV59Trn_auditwwds_6_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername), "%", "");
         lV61Trn_auditwwds_8_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname), "%", "");
         lV63Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P007U5 */
         pr_default.execute(3, new Object[] {AV65Udparg12, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, lV54Trn_auditwwds_1_filterfulltext, AV55Trn_auditwwds_2_tfauditdate, AV56Trn_auditwwds_3_tfauditdate_to, lV57Trn_auditwwds_4_tfauditaction, AV58Trn_auditwwds_5_tfauditaction_sel, lV59Trn_auditwwds_6_tfauditusername, AV60Trn_auditwwds_7_tfauditusername_sel, lV61Trn_auditwwds_8_tfaudittablediaplayname, AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, lV63Trn_auditwwds_10_tfauditshortdescription, AV64Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7U7 = false;
            A11OrganisationId = P007U5_A11OrganisationId[0];
            n11OrganisationId = P007U5_n11OrganisationId[0];
            A375AuditShortDescription = P007U5_A375AuditShortDescription[0];
            A377AuditUserName = P007U5_A377AuditUserName[0];
            A378AuditAction = P007U5_A378AuditAction[0];
            A372AuditDate = P007U5_A372AuditDate[0];
            A373AuditTableName = P007U5_A373AuditTableName[0];
            A371AuditId = P007U5_A371AuditId[0];
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007U5_A375AuditShortDescription[0], A375AuditShortDescription) == 0 ) )
            {
               BRK7U7 = false;
               A371AuditId = P007U5_A371AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK7U7 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A375AuditShortDescription)) ? "<#Empty#>" : A375AuditShortDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7U7 )
            {
               BRK7U7 = true;
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV39GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV11TFAuditDate = (DateTime)(DateTime.MinValue);
         AV12TFAuditDate_To = (DateTime)(DateTime.MinValue);
         AV23TFAuditAction = "";
         AV24TFAuditAction_Sel = "";
         AV21TFAuditUserName = "";
         AV22TFAuditUserName_Sel = "";
         AV50TFAuditTableDiaplayName = "";
         AV51TFAuditTableDiaplayName_Sel = "";
         AV17TFAuditShortDescription = "";
         AV18TFAuditShortDescription_Sel = "";
         AV54Trn_auditwwds_1_filterfulltext = "";
         AV55Trn_auditwwds_2_tfauditdate = (DateTime)(DateTime.MinValue);
         AV56Trn_auditwwds_3_tfauditdate_to = (DateTime)(DateTime.MinValue);
         AV57Trn_auditwwds_4_tfauditaction = "";
         AV58Trn_auditwwds_5_tfauditaction_sel = "";
         AV59Trn_auditwwds_6_tfauditusername = "";
         AV60Trn_auditwwds_7_tfauditusername_sel = "";
         AV61Trn_auditwwds_8_tfaudittablediaplayname = "";
         AV62Trn_auditwwds_9_tfaudittablediaplayname_sel = "";
         AV63Trn_auditwwds_10_tfauditshortdescription = "";
         AV64Trn_auditwwds_11_tfauditshortdescription_sel = "";
         AV65Udparg12 = Guid.Empty;
         lV54Trn_auditwwds_1_filterfulltext = "";
         lV57Trn_auditwwds_4_tfauditaction = "";
         lV59Trn_auditwwds_6_tfauditusername = "";
         lV61Trn_auditwwds_8_tfaudittablediaplayname = "";
         lV63Trn_auditwwds_10_tfauditshortdescription = "";
         A378AuditAction = "";
         A377AuditUserName = "";
         A373AuditTableName = "";
         A375AuditShortDescription = "";
         A372AuditDate = (DateTime)(DateTime.MinValue);
         A11OrganisationId = Guid.Empty;
         P007U2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007U2_n11OrganisationId = new bool[] {false} ;
         P007U2_A378AuditAction = new string[] {""} ;
         P007U2_A375AuditShortDescription = new string[] {""} ;
         P007U2_A377AuditUserName = new string[] {""} ;
         P007U2_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007U2_A373AuditTableName = new string[] {""} ;
         P007U2_A371AuditId = new Guid[] {Guid.Empty} ;
         A371AuditId = Guid.Empty;
         A491AuditTableDiaplayName = "";
         AV30Option = "";
         P007U3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007U3_n11OrganisationId = new bool[] {false} ;
         P007U3_A377AuditUserName = new string[] {""} ;
         P007U3_A375AuditShortDescription = new string[] {""} ;
         P007U3_A378AuditAction = new string[] {""} ;
         P007U3_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007U3_A373AuditTableName = new string[] {""} ;
         P007U3_A371AuditId = new Guid[] {Guid.Empty} ;
         P007U4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007U4_n11OrganisationId = new bool[] {false} ;
         P007U4_A375AuditShortDescription = new string[] {""} ;
         P007U4_A377AuditUserName = new string[] {""} ;
         P007U4_A378AuditAction = new string[] {""} ;
         P007U4_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007U4_A373AuditTableName = new string[] {""} ;
         P007U4_A371AuditId = new Guid[] {Guid.Empty} ;
         P007U5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007U5_n11OrganisationId = new bool[] {false} ;
         P007U5_A375AuditShortDescription = new string[] {""} ;
         P007U5_A377AuditUserName = new string[] {""} ;
         P007U5_A378AuditAction = new string[] {""} ;
         P007U5_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007U5_A373AuditTableName = new string[] {""} ;
         P007U5_A371AuditId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_auditwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007U2_A11OrganisationId, P007U2_n11OrganisationId, P007U2_A378AuditAction, P007U2_A375AuditShortDescription, P007U2_A377AuditUserName, P007U2_A372AuditDate, P007U2_A373AuditTableName, P007U2_A371AuditId
               }
               , new Object[] {
               P007U3_A11OrganisationId, P007U3_n11OrganisationId, P007U3_A377AuditUserName, P007U3_A375AuditShortDescription, P007U3_A378AuditAction, P007U3_A372AuditDate, P007U3_A373AuditTableName, P007U3_A371AuditId
               }
               , new Object[] {
               P007U4_A11OrganisationId, P007U4_n11OrganisationId, P007U4_A375AuditShortDescription, P007U4_A377AuditUserName, P007U4_A378AuditAction, P007U4_A372AuditDate, P007U4_A373AuditTableName, P007U4_A371AuditId
               }
               , new Object[] {
               P007U5_A11OrganisationId, P007U5_n11OrganisationId, P007U5_A375AuditShortDescription, P007U5_A377AuditUserName, P007U5_A378AuditAction, P007U5_A372AuditDate, P007U5_A373AuditTableName, P007U5_A371AuditId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV52GXV1 ;
      private int AV29InsertIndex ;
      private long AV35count ;
      private DateTime AV11TFAuditDate ;
      private DateTime AV12TFAuditDate_To ;
      private DateTime AV55Trn_auditwwds_2_tfauditdate ;
      private DateTime AV56Trn_auditwwds_3_tfauditdate_to ;
      private DateTime A372AuditDate ;
      private bool returnInSub ;
      private bool BRK7U2 ;
      private bool n11OrganisationId ;
      private bool BRK7U4 ;
      private bool BRK7U7 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV23TFAuditAction ;
      private string AV24TFAuditAction_Sel ;
      private string AV21TFAuditUserName ;
      private string AV22TFAuditUserName_Sel ;
      private string AV50TFAuditTableDiaplayName ;
      private string AV51TFAuditTableDiaplayName_Sel ;
      private string AV17TFAuditShortDescription ;
      private string AV18TFAuditShortDescription_Sel ;
      private string AV54Trn_auditwwds_1_filterfulltext ;
      private string AV57Trn_auditwwds_4_tfauditaction ;
      private string AV58Trn_auditwwds_5_tfauditaction_sel ;
      private string AV59Trn_auditwwds_6_tfauditusername ;
      private string AV60Trn_auditwwds_7_tfauditusername_sel ;
      private string AV61Trn_auditwwds_8_tfaudittablediaplayname ;
      private string AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ;
      private string AV63Trn_auditwwds_10_tfauditshortdescription ;
      private string AV64Trn_auditwwds_11_tfauditshortdescription_sel ;
      private string lV54Trn_auditwwds_1_filterfulltext ;
      private string lV57Trn_auditwwds_4_tfauditaction ;
      private string lV59Trn_auditwwds_6_tfauditusername ;
      private string lV61Trn_auditwwds_8_tfaudittablediaplayname ;
      private string lV63Trn_auditwwds_10_tfauditshortdescription ;
      private string A378AuditAction ;
      private string A377AuditUserName ;
      private string A373AuditTableName ;
      private string A375AuditShortDescription ;
      private string A491AuditTableDiaplayName ;
      private string AV30Option ;
      private Guid AV65Udparg12 ;
      private Guid A11OrganisationId ;
      private Guid A371AuditId ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV38GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007U2_A11OrganisationId ;
      private bool[] P007U2_n11OrganisationId ;
      private string[] P007U2_A378AuditAction ;
      private string[] P007U2_A375AuditShortDescription ;
      private string[] P007U2_A377AuditUserName ;
      private DateTime[] P007U2_A372AuditDate ;
      private string[] P007U2_A373AuditTableName ;
      private Guid[] P007U2_A371AuditId ;
      private Guid[] P007U3_A11OrganisationId ;
      private bool[] P007U3_n11OrganisationId ;
      private string[] P007U3_A377AuditUserName ;
      private string[] P007U3_A375AuditShortDescription ;
      private string[] P007U3_A378AuditAction ;
      private DateTime[] P007U3_A372AuditDate ;
      private string[] P007U3_A373AuditTableName ;
      private Guid[] P007U3_A371AuditId ;
      private Guid[] P007U4_A11OrganisationId ;
      private bool[] P007U4_n11OrganisationId ;
      private string[] P007U4_A375AuditShortDescription ;
      private string[] P007U4_A377AuditUserName ;
      private string[] P007U4_A378AuditAction ;
      private DateTime[] P007U4_A372AuditDate ;
      private string[] P007U4_A373AuditTableName ;
      private Guid[] P007U4_A371AuditId ;
      private Guid[] P007U5_A11OrganisationId ;
      private bool[] P007U5_n11OrganisationId ;
      private string[] P007U5_A375AuditShortDescription ;
      private string[] P007U5_A377AuditUserName ;
      private string[] P007U5_A378AuditAction ;
      private DateTime[] P007U5_A372AuditDate ;
      private string[] P007U5_A373AuditTableName ;
      private Guid[] P007U5_A371AuditId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_auditwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007U2( IGxContext context ,
                                             string AV54Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV55Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV56Trn_auditwwds_3_tfauditdate_to ,
                                             string AV58Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV57Trn_auditwwds_4_tfauditaction ,
                                             string AV60Trn_auditwwds_7_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_6_tfauditusername ,
                                             string AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                             string AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                             string AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV63Trn_auditwwds_10_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV65Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditAction, AuditShortDescription, AuditUserName, AuditDate, AuditTableName, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV65Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV55Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV56Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV57Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV58Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_6_tfauditusername)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_7_tfauditusername_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV61Trn_auditwwds_8_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV62Trn_auditwwds_9_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV63Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV64Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditAction";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007U3( IGxContext context ,
                                             string AV54Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV55Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV56Trn_auditwwds_3_tfauditdate_to ,
                                             string AV58Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV57Trn_auditwwds_4_tfauditaction ,
                                             string AV60Trn_auditwwds_7_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_6_tfauditusername ,
                                             string AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                             string AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                             string AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV63Trn_auditwwds_10_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV65Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditUserName, AuditShortDescription, AuditAction, AuditDate, AuditTableName, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV65Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV55Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV56Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV57Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV58Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_6_tfauditusername)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_7_tfauditusername_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV61Trn_auditwwds_8_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV62Trn_auditwwds_9_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV63Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV64Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditUserName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007U4( IGxContext context ,
                                             string AV54Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV55Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV56Trn_auditwwds_3_tfauditdate_to ,
                                             string AV58Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV57Trn_auditwwds_4_tfauditaction ,
                                             string AV60Trn_auditwwds_7_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_6_tfauditusername ,
                                             string AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                             string AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                             string AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV63Trn_auditwwds_10_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             Guid AV65Udparg12 ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditShortDescription, AuditUserName, AuditAction, AuditDate, AuditTableName, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV65Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV55Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV56Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV57Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV58Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_6_tfauditusername)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_7_tfauditusername_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV61Trn_auditwwds_8_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV62Trn_auditwwds_9_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV63Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV64Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007U5( IGxContext context ,
                                             string AV54Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV55Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV56Trn_auditwwds_3_tfauditdate_to ,
                                             string AV58Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV57Trn_auditwwds_4_tfauditaction ,
                                             string AV60Trn_auditwwds_7_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_6_tfauditusername ,
                                             string AV62Trn_auditwwds_9_tfaudittablediaplayname_sel ,
                                             string AV61Trn_auditwwds_8_tfaudittablediaplayname ,
                                             string AV64Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV63Trn_auditwwds_10_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV65Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditShortDescription, AuditUserName, AuditAction, AuditDate, AuditTableName, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV65Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV54Trn_auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV55Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV56Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV57Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV58Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_5_tfauditaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_6_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_6_tfauditusername)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_7_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_7_tfauditusername_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_7_tfauditusername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_8_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV61Trn_auditwwds_8_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_9_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV62Trn_auditwwds_9_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_9_tfaudittablediaplayname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV63Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV64Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_auditwwds_11_tfauditshortdescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditShortDescription";
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
                     return conditional_P007U2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 1 :
                     return conditional_P007U3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 2 :
                     return conditional_P007U4(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 3 :
                     return conditional_P007U5(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
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
          Object[] prmP007U2;
          prmP007U2 = new Object[] {
          new ParDef("AV65Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV57Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV58Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Trn_auditwwds_6_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_7_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_8_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_auditwwds_9_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV64Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP007U3;
          prmP007U3 = new Object[] {
          new ParDef("AV65Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV57Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV58Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Trn_auditwwds_6_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_7_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_8_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_auditwwds_9_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV64Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP007U4;
          prmP007U4 = new Object[] {
          new ParDef("AV65Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV57Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV58Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Trn_auditwwds_6_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_7_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_8_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_auditwwds_9_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV64Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP007U5;
          prmP007U5 = new Object[] {
          new ParDef("AV65Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV57Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV58Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Trn_auditwwds_6_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_7_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_8_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_auditwwds_9_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV64Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007U4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007U5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U5,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
