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
   public class trn_organisationwwgetfilterdata : GXProcedure
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
            return "trn_organisationww_Services_Execute" ;
         }

      }

      public trn_organisationwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationwwgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ORGANISATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ORGANISATIONTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ORGANISATIONEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ORGANISATIONPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADORGANISATIONPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("Trn_OrganisationWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_OrganisationWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("Trn_OrganisationWWGridState"), null, "", "");
         }
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONNAME") == 0 )
            {
               AV13TFOrganisationName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONNAME_SEL") == 0 )
            {
               AV14TFOrganisationName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONTYPENAME") == 0 )
            {
               AV25TFOrganisationTypeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONTYPENAME_SEL") == 0 )
            {
               AV26TFOrganisationTypeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONEMAIL") == 0 )
            {
               AV19TFOrganisationEmail = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONEMAIL_SEL") == 0 )
            {
               AV20TFOrganisationEmail_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONPHONE") == 0 )
            {
               AV21TFOrganisationPhone = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFORGANISATIONPHONE_SEL") == 0 )
            {
               AV22TFOrganisationPhone_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADORGANISATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFOrganisationName = AV27SearchTxt;
         AV14TFOrganisationName_Sel = "";
         AV70Trn_organisationwwds_1_filterfulltext = AV49FilterFullText;
         AV71Trn_organisationwwds_2_tforganisationname = AV13TFOrganisationName;
         AV72Trn_organisationwwds_3_tforganisationname_sel = AV14TFOrganisationName_Sel;
         AV73Trn_organisationwwds_4_tforganisationtypename = AV25TFOrganisationTypeName;
         AV74Trn_organisationwwds_5_tforganisationtypename_sel = AV26TFOrganisationTypeName_Sel;
         AV75Trn_organisationwwds_6_tforganisationemail = AV19TFOrganisationEmail;
         AV76Trn_organisationwwds_7_tforganisationemail_sel = AV20TFOrganisationEmail_Sel;
         AV77Trn_organisationwwds_8_tforganisationphone = AV21TFOrganisationPhone;
         AV78Trn_organisationwwds_9_tforganisationphone_sel = AV22TFOrganisationPhone_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV70Trn_organisationwwds_1_filterfulltext ,
                                              AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                              AV71Trn_organisationwwds_2_tforganisationname ,
                                              AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                              AV73Trn_organisationwwds_4_tforganisationtypename ,
                                              AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                              AV75Trn_organisationwwds_6_tforganisationemail ,
                                              AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                              AV77Trn_organisationwwds_8_tforganisationphone ,
                                              A13OrganisationName ,
                                              A20OrganisationTypeName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone } ,
                                              new int[]{
                                              }
         });
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV71Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname), "%", "");
         lV73Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename), "%", "");
         lV75Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail), "%", "");
         lV77Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone), 20, "%");
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV71Trn_organisationwwds_2_tforganisationname, AV72Trn_organisationwwds_3_tforganisationname_sel, lV73Trn_organisationwwds_4_tforganisationtypename, AV74Trn_organisationwwds_5_tforganisationtypename_sel, lV75Trn_organisationwwds_6_tforganisationemail, AV76Trn_organisationwwds_7_tforganisationemail_sel, lV77Trn_organisationwwds_8_tforganisationphone, AV78Trn_organisationwwds_9_tforganisationphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5X2 = false;
            A19OrganisationTypeId = P005X2_A19OrganisationTypeId[0];
            A13OrganisationName = P005X2_A13OrganisationName[0];
            A17OrganisationPhone = P005X2_A17OrganisationPhone[0];
            A16OrganisationEmail = P005X2_A16OrganisationEmail[0];
            A20OrganisationTypeName = P005X2_A20OrganisationTypeName[0];
            A11OrganisationId = P005X2_A11OrganisationId[0];
            A20OrganisationTypeName = P005X2_A20OrganisationTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005X2_A13OrganisationName[0], A13OrganisationName) == 0 ) )
            {
               BRK5X2 = false;
               A11OrganisationId = P005X2_A11OrganisationId[0];
               AV37count = (long)(AV37count+1);
               BRK5X2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A13OrganisationName)) ? "<#Empty#>" : A13OrganisationName);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK5X2 )
            {
               BRK5X2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADORGANISATIONTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV25TFOrganisationTypeName = AV27SearchTxt;
         AV26TFOrganisationTypeName_Sel = "";
         AV70Trn_organisationwwds_1_filterfulltext = AV49FilterFullText;
         AV71Trn_organisationwwds_2_tforganisationname = AV13TFOrganisationName;
         AV72Trn_organisationwwds_3_tforganisationname_sel = AV14TFOrganisationName_Sel;
         AV73Trn_organisationwwds_4_tforganisationtypename = AV25TFOrganisationTypeName;
         AV74Trn_organisationwwds_5_tforganisationtypename_sel = AV26TFOrganisationTypeName_Sel;
         AV75Trn_organisationwwds_6_tforganisationemail = AV19TFOrganisationEmail;
         AV76Trn_organisationwwds_7_tforganisationemail_sel = AV20TFOrganisationEmail_Sel;
         AV77Trn_organisationwwds_8_tforganisationphone = AV21TFOrganisationPhone;
         AV78Trn_organisationwwds_9_tforganisationphone_sel = AV22TFOrganisationPhone_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV70Trn_organisationwwds_1_filterfulltext ,
                                              AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                              AV71Trn_organisationwwds_2_tforganisationname ,
                                              AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                              AV73Trn_organisationwwds_4_tforganisationtypename ,
                                              AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                              AV75Trn_organisationwwds_6_tforganisationemail ,
                                              AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                              AV77Trn_organisationwwds_8_tforganisationphone ,
                                              A13OrganisationName ,
                                              A20OrganisationTypeName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone } ,
                                              new int[]{
                                              }
         });
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV71Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname), "%", "");
         lV73Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename), "%", "");
         lV75Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail), "%", "");
         lV77Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone), 20, "%");
         /* Using cursor P005X3 */
         pr_default.execute(1, new Object[] {lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV71Trn_organisationwwds_2_tforganisationname, AV72Trn_organisationwwds_3_tforganisationname_sel, lV73Trn_organisationwwds_4_tforganisationtypename, AV74Trn_organisationwwds_5_tforganisationtypename_sel, lV75Trn_organisationwwds_6_tforganisationemail, AV76Trn_organisationwwds_7_tforganisationemail_sel, lV77Trn_organisationwwds_8_tforganisationphone, AV78Trn_organisationwwds_9_tforganisationphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5X4 = false;
            A19OrganisationTypeId = P005X3_A19OrganisationTypeId[0];
            A17OrganisationPhone = P005X3_A17OrganisationPhone[0];
            A16OrganisationEmail = P005X3_A16OrganisationEmail[0];
            A20OrganisationTypeName = P005X3_A20OrganisationTypeName[0];
            A13OrganisationName = P005X3_A13OrganisationName[0];
            A11OrganisationId = P005X3_A11OrganisationId[0];
            A20OrganisationTypeName = P005X3_A20OrganisationTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P005X3_A19OrganisationTypeId[0] == A19OrganisationTypeId ) )
            {
               BRK5X4 = false;
               A11OrganisationId = P005X3_A11OrganisationId[0];
               AV37count = (long)(AV37count+1);
               BRK5X4 = true;
               pr_default.readNext(1);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A20OrganisationTypeName)) ? "<#Empty#>" : A20OrganisationTypeName);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK5X4 )
            {
               BRK5X4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADORGANISATIONEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFOrganisationEmail = AV27SearchTxt;
         AV20TFOrganisationEmail_Sel = "";
         AV70Trn_organisationwwds_1_filterfulltext = AV49FilterFullText;
         AV71Trn_organisationwwds_2_tforganisationname = AV13TFOrganisationName;
         AV72Trn_organisationwwds_3_tforganisationname_sel = AV14TFOrganisationName_Sel;
         AV73Trn_organisationwwds_4_tforganisationtypename = AV25TFOrganisationTypeName;
         AV74Trn_organisationwwds_5_tforganisationtypename_sel = AV26TFOrganisationTypeName_Sel;
         AV75Trn_organisationwwds_6_tforganisationemail = AV19TFOrganisationEmail;
         AV76Trn_organisationwwds_7_tforganisationemail_sel = AV20TFOrganisationEmail_Sel;
         AV77Trn_organisationwwds_8_tforganisationphone = AV21TFOrganisationPhone;
         AV78Trn_organisationwwds_9_tforganisationphone_sel = AV22TFOrganisationPhone_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV70Trn_organisationwwds_1_filterfulltext ,
                                              AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                              AV71Trn_organisationwwds_2_tforganisationname ,
                                              AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                              AV73Trn_organisationwwds_4_tforganisationtypename ,
                                              AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                              AV75Trn_organisationwwds_6_tforganisationemail ,
                                              AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                              AV77Trn_organisationwwds_8_tforganisationphone ,
                                              A13OrganisationName ,
                                              A20OrganisationTypeName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone } ,
                                              new int[]{
                                              }
         });
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV71Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname), "%", "");
         lV73Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename), "%", "");
         lV75Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail), "%", "");
         lV77Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone), 20, "%");
         /* Using cursor P005X4 */
         pr_default.execute(2, new Object[] {lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV71Trn_organisationwwds_2_tforganisationname, AV72Trn_organisationwwds_3_tforganisationname_sel, lV73Trn_organisationwwds_4_tforganisationtypename, AV74Trn_organisationwwds_5_tforganisationtypename_sel, lV75Trn_organisationwwds_6_tforganisationemail, AV76Trn_organisationwwds_7_tforganisationemail_sel, lV77Trn_organisationwwds_8_tforganisationphone, AV78Trn_organisationwwds_9_tforganisationphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5X6 = false;
            A19OrganisationTypeId = P005X4_A19OrganisationTypeId[0];
            A16OrganisationEmail = P005X4_A16OrganisationEmail[0];
            A17OrganisationPhone = P005X4_A17OrganisationPhone[0];
            A20OrganisationTypeName = P005X4_A20OrganisationTypeName[0];
            A13OrganisationName = P005X4_A13OrganisationName[0];
            A11OrganisationId = P005X4_A11OrganisationId[0];
            A20OrganisationTypeName = P005X4_A20OrganisationTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005X4_A16OrganisationEmail[0], A16OrganisationEmail) == 0 ) )
            {
               BRK5X6 = false;
               A11OrganisationId = P005X4_A11OrganisationId[0];
               AV37count = (long)(AV37count+1);
               BRK5X6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A16OrganisationEmail)) ? "<#Empty#>" : A16OrganisationEmail);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK5X6 )
            {
               BRK5X6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADORGANISATIONPHONEOPTIONS' Routine */
         returnInSub = false;
         AV21TFOrganisationPhone = AV27SearchTxt;
         AV22TFOrganisationPhone_Sel = "";
         AV70Trn_organisationwwds_1_filterfulltext = AV49FilterFullText;
         AV71Trn_organisationwwds_2_tforganisationname = AV13TFOrganisationName;
         AV72Trn_organisationwwds_3_tforganisationname_sel = AV14TFOrganisationName_Sel;
         AV73Trn_organisationwwds_4_tforganisationtypename = AV25TFOrganisationTypeName;
         AV74Trn_organisationwwds_5_tforganisationtypename_sel = AV26TFOrganisationTypeName_Sel;
         AV75Trn_organisationwwds_6_tforganisationemail = AV19TFOrganisationEmail;
         AV76Trn_organisationwwds_7_tforganisationemail_sel = AV20TFOrganisationEmail_Sel;
         AV77Trn_organisationwwds_8_tforganisationphone = AV21TFOrganisationPhone;
         AV78Trn_organisationwwds_9_tforganisationphone_sel = AV22TFOrganisationPhone_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV70Trn_organisationwwds_1_filterfulltext ,
                                              AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                              AV71Trn_organisationwwds_2_tforganisationname ,
                                              AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                              AV73Trn_organisationwwds_4_tforganisationtypename ,
                                              AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                              AV75Trn_organisationwwds_6_tforganisationemail ,
                                              AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                              AV77Trn_organisationwwds_8_tforganisationphone ,
                                              A13OrganisationName ,
                                              A20OrganisationTypeName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone } ,
                                              new int[]{
                                              }
         });
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV70Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext), "%", "");
         lV71Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname), "%", "");
         lV73Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename), "%", "");
         lV75Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail), "%", "");
         lV77Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone), 20, "%");
         /* Using cursor P005X5 */
         pr_default.execute(3, new Object[] {lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV70Trn_organisationwwds_1_filterfulltext, lV71Trn_organisationwwds_2_tforganisationname, AV72Trn_organisationwwds_3_tforganisationname_sel, lV73Trn_organisationwwds_4_tforganisationtypename, AV74Trn_organisationwwds_5_tforganisationtypename_sel, lV75Trn_organisationwwds_6_tforganisationemail, AV76Trn_organisationwwds_7_tforganisationemail_sel, lV77Trn_organisationwwds_8_tforganisationphone, AV78Trn_organisationwwds_9_tforganisationphone_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK5X8 = false;
            A19OrganisationTypeId = P005X5_A19OrganisationTypeId[0];
            A17OrganisationPhone = P005X5_A17OrganisationPhone[0];
            A16OrganisationEmail = P005X5_A16OrganisationEmail[0];
            A20OrganisationTypeName = P005X5_A20OrganisationTypeName[0];
            A13OrganisationName = P005X5_A13OrganisationName[0];
            A11OrganisationId = P005X5_A11OrganisationId[0];
            A20OrganisationTypeName = P005X5_A20OrganisationTypeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P005X5_A17OrganisationPhone[0], A17OrganisationPhone) == 0 ) )
            {
               BRK5X8 = false;
               A11OrganisationId = P005X5_A11OrganisationId[0];
               AV37count = (long)(AV37count+1);
               BRK5X8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A17OrganisationPhone)) ? "<#Empty#>" : A17OrganisationPhone);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK5X8 )
            {
               BRK5X8 = true;
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV41GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
         AV13TFOrganisationName = "";
         AV14TFOrganisationName_Sel = "";
         AV25TFOrganisationTypeName = "";
         AV26TFOrganisationTypeName_Sel = "";
         AV19TFOrganisationEmail = "";
         AV20TFOrganisationEmail_Sel = "";
         AV21TFOrganisationPhone = "";
         AV22TFOrganisationPhone_Sel = "";
         AV70Trn_organisationwwds_1_filterfulltext = "";
         AV71Trn_organisationwwds_2_tforganisationname = "";
         AV72Trn_organisationwwds_3_tforganisationname_sel = "";
         AV73Trn_organisationwwds_4_tforganisationtypename = "";
         AV74Trn_organisationwwds_5_tforganisationtypename_sel = "";
         AV75Trn_organisationwwds_6_tforganisationemail = "";
         AV76Trn_organisationwwds_7_tforganisationemail_sel = "";
         AV77Trn_organisationwwds_8_tforganisationphone = "";
         AV78Trn_organisationwwds_9_tforganisationphone_sel = "";
         lV70Trn_organisationwwds_1_filterfulltext = "";
         lV71Trn_organisationwwds_2_tforganisationname = "";
         lV73Trn_organisationwwds_4_tforganisationtypename = "";
         lV75Trn_organisationwwds_6_tforganisationemail = "";
         lV77Trn_organisationwwds_8_tforganisationphone = "";
         A13OrganisationName = "";
         A20OrganisationTypeName = "";
         A16OrganisationEmail = "";
         A17OrganisationPhone = "";
         P005X2_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005X2_A13OrganisationName = new string[] {""} ;
         P005X2_A17OrganisationPhone = new string[] {""} ;
         P005X2_A16OrganisationEmail = new string[] {""} ;
         P005X2_A20OrganisationTypeName = new string[] {""} ;
         P005X2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A19OrganisationTypeId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV32Option = "";
         P005X3_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005X3_A17OrganisationPhone = new string[] {""} ;
         P005X3_A16OrganisationEmail = new string[] {""} ;
         P005X3_A20OrganisationTypeName = new string[] {""} ;
         P005X3_A13OrganisationName = new string[] {""} ;
         P005X3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005X4_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005X4_A16OrganisationEmail = new string[] {""} ;
         P005X4_A17OrganisationPhone = new string[] {""} ;
         P005X4_A20OrganisationTypeName = new string[] {""} ;
         P005X4_A13OrganisationName = new string[] {""} ;
         P005X4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005X5_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P005X5_A17OrganisationPhone = new string[] {""} ;
         P005X5_A16OrganisationEmail = new string[] {""} ;
         P005X5_A20OrganisationTypeName = new string[] {""} ;
         P005X5_A13OrganisationName = new string[] {""} ;
         P005X5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005X2_A19OrganisationTypeId, P005X2_A13OrganisationName, P005X2_A17OrganisationPhone, P005X2_A16OrganisationEmail, P005X2_A20OrganisationTypeName, P005X2_A11OrganisationId
               }
               , new Object[] {
               P005X3_A19OrganisationTypeId, P005X3_A17OrganisationPhone, P005X3_A16OrganisationEmail, P005X3_A20OrganisationTypeName, P005X3_A13OrganisationName, P005X3_A11OrganisationId
               }
               , new Object[] {
               P005X4_A19OrganisationTypeId, P005X4_A16OrganisationEmail, P005X4_A17OrganisationPhone, P005X4_A20OrganisationTypeName, P005X4_A13OrganisationName, P005X4_A11OrganisationId
               }
               , new Object[] {
               P005X5_A19OrganisationTypeId, P005X5_A17OrganisationPhone, P005X5_A16OrganisationEmail, P005X5_A20OrganisationTypeName, P005X5_A13OrganisationName, P005X5_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private int AV68GXV1 ;
      private int AV31InsertIndex ;
      private long AV37count ;
      private string AV21TFOrganisationPhone ;
      private string AV22TFOrganisationPhone_Sel ;
      private string AV77Trn_organisationwwds_8_tforganisationphone ;
      private string AV78Trn_organisationwwds_9_tforganisationphone_sel ;
      private string lV77Trn_organisationwwds_8_tforganisationphone ;
      private string A17OrganisationPhone ;
      private bool returnInSub ;
      private bool BRK5X2 ;
      private bool BRK5X4 ;
      private bool BRK5X6 ;
      private bool BRK5X8 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV13TFOrganisationName ;
      private string AV14TFOrganisationName_Sel ;
      private string AV25TFOrganisationTypeName ;
      private string AV26TFOrganisationTypeName_Sel ;
      private string AV19TFOrganisationEmail ;
      private string AV20TFOrganisationEmail_Sel ;
      private string AV70Trn_organisationwwds_1_filterfulltext ;
      private string AV71Trn_organisationwwds_2_tforganisationname ;
      private string AV72Trn_organisationwwds_3_tforganisationname_sel ;
      private string AV73Trn_organisationwwds_4_tforganisationtypename ;
      private string AV74Trn_organisationwwds_5_tforganisationtypename_sel ;
      private string AV75Trn_organisationwwds_6_tforganisationemail ;
      private string AV76Trn_organisationwwds_7_tforganisationemail_sel ;
      private string lV70Trn_organisationwwds_1_filterfulltext ;
      private string lV71Trn_organisationwwds_2_tforganisationname ;
      private string lV73Trn_organisationwwds_4_tforganisationtypename ;
      private string lV75Trn_organisationwwds_6_tforganisationemail ;
      private string A13OrganisationName ;
      private string A20OrganisationTypeName ;
      private string A16OrganisationEmail ;
      private string AV32Option ;
      private Guid A19OrganisationTypeId ;
      private Guid A11OrganisationId ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV40GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005X2_A19OrganisationTypeId ;
      private string[] P005X2_A13OrganisationName ;
      private string[] P005X2_A17OrganisationPhone ;
      private string[] P005X2_A16OrganisationEmail ;
      private string[] P005X2_A20OrganisationTypeName ;
      private Guid[] P005X2_A11OrganisationId ;
      private Guid[] P005X3_A19OrganisationTypeId ;
      private string[] P005X3_A17OrganisationPhone ;
      private string[] P005X3_A16OrganisationEmail ;
      private string[] P005X3_A20OrganisationTypeName ;
      private string[] P005X3_A13OrganisationName ;
      private Guid[] P005X3_A11OrganisationId ;
      private Guid[] P005X4_A19OrganisationTypeId ;
      private string[] P005X4_A16OrganisationEmail ;
      private string[] P005X4_A17OrganisationPhone ;
      private string[] P005X4_A20OrganisationTypeName ;
      private string[] P005X4_A13OrganisationName ;
      private Guid[] P005X4_A11OrganisationId ;
      private Guid[] P005X5_A19OrganisationTypeId ;
      private string[] P005X5_A17OrganisationPhone ;
      private string[] P005X5_A16OrganisationEmail ;
      private string[] P005X5_A20OrganisationTypeName ;
      private string[] P005X5_A13OrganisationName ;
      private Guid[] P005X5_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_organisationwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005X2( IGxContext context ,
                                             string AV70Trn_organisationwwds_1_filterfulltext ,
                                             string AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV71Trn_organisationwwds_2_tforganisationname ,
                                             string AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV73Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV75Trn_organisationwwds_6_tforganisationemail ,
                                             string AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV77Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationTypeId, T1.OrganisationName, T1.OrganisationPhone, T1.OrganisationEmail, T2.OrganisationTypeName, T1.OrganisationId FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV71Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV72Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV73Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV74Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV75Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV76Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV77Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV78Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.OrganisationName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005X3( IGxContext context ,
                                             string AV70Trn_organisationwwds_1_filterfulltext ,
                                             string AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV71Trn_organisationwwds_2_tforganisationname ,
                                             string AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV73Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV75Trn_organisationwwds_6_tforganisationemail ,
                                             string AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV77Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationTypeId, T1.OrganisationPhone, T1.OrganisationEmail, T2.OrganisationTypeName, T1.OrganisationName, T1.OrganisationId FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV71Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV72Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV73Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV74Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV75Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV76Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV77Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV78Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.OrganisationTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005X4( IGxContext context ,
                                             string AV70Trn_organisationwwds_1_filterfulltext ,
                                             string AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV71Trn_organisationwwds_2_tforganisationname ,
                                             string AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV73Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV75Trn_organisationwwds_6_tforganisationemail ,
                                             string AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV77Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationTypeId, T1.OrganisationEmail, T1.OrganisationPhone, T2.OrganisationTypeName, T1.OrganisationName, T1.OrganisationId FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV71Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV72Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV73Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV74Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV75Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV76Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV77Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV78Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.OrganisationEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P005X5( IGxContext context ,
                                             string AV70Trn_organisationwwds_1_filterfulltext ,
                                             string AV72Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV71Trn_organisationwwds_2_tforganisationname ,
                                             string AV74Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV73Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV76Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV75Trn_organisationwwds_6_tforganisationemail ,
                                             string AV78Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV77Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationTypeId, T1.OrganisationPhone, T1.OrganisationEmail, T2.OrganisationTypeName, T1.OrganisationName, T1.OrganisationId FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV70Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV71Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV72Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_organisationwwds_3_tforganisationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV73Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV74Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_organisationwwds_5_tforganisationtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV75Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV76Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_organisationwwds_7_tforganisationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV77Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV78Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_organisationwwds_9_tforganisationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.OrganisationPhone";
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
                     return conditional_P005X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P005X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P005X4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 3 :
                     return conditional_P005X5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV78Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005X3;
          prmP005X3 = new Object[] {
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV78Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005X4;
          prmP005X4 = new Object[] {
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV78Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005X5;
          prmP005X5 = new Object[] {
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV78Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005X4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005X5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
       }
    }

 }

}
