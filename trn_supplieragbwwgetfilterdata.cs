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
   public class trn_supplieragbwwgetfilterdata : GXProcedure
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
            return "trn_supplieragbww_Services_Execute" ;
         }

      }

      public trn_supplieragbwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIERAGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIERAGBTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIERAGBCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIERAGBPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIERAGBEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBEMAILOPTIONS' */
            S161 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("Trn_SupplierAgbWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_SupplierAgbWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Trn_SupplierAgbWWGridState"), null, "", "");
         }
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV15TFSupplierAgbName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV16TFSupplierAgbName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV13TFSupplierAgbTypeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV14TFSupplierAgbTypeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME") == 0 )
            {
               AV19TFSupplierAgbContactName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME_SEL") == 0 )
            {
               AV20TFSupplierAgbContactName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE") == 0 )
            {
               AV21TFSupplierAgbPhone = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE_SEL") == 0 )
            {
               AV22TFSupplierAgbPhone_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL") == 0 )
            {
               AV23TFSupplierAgbEmail = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL_SEL") == 0 )
            {
               AV24TFSupplierAgbEmail_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERAGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplierAgbName = AV25SearchTxt;
         AV16TFSupplierAgbName_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = AV47FilterFullText;
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = AV15TFSupplierAgbName;
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV16TFSupplierAgbName_Sel;
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV19TFSupplierAgbContactName;
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV20TFSupplierAgbContactName_Sel;
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = AV21TFSupplierAgbPhone;
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV22TFSupplierAgbPhone_Sel;
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = AV23TFSupplierAgbEmail;
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV24TFSupplierAgbEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68Trn_supplieragbwwds_1_filterfulltext ,
                                              AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {A11OrganisationId, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV69Trn_supplieragbwwds_2_tfsupplieragbname, AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV71Trn_supplieragbwwds_4_tfsupplieragbtypename, AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV75Trn_supplieragbwwds_8_tfsupplieragbphone, AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV77Trn_supplieragbwwds_10_tfsupplieragbemail, AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK692 = false;
            A255SupplierAgbTypeId = P00692_A255SupplierAgbTypeId[0];
            A51SupplierAgbName = P00692_A51SupplierAgbName[0];
            A57SupplierAgbEmail = P00692_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00692_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00692_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P00692_A256SupplierAgbTypeName[0];
            A49SupplierAgbId = P00692_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P00692_A256SupplierAgbTypeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00692_A51SupplierAgbName[0], A51SupplierAgbName) == 0 ) )
            {
               BRK692 = false;
               A49SupplierAgbId = P00692_A49SupplierAgbId[0];
               AV35count = (long)(AV35count+1);
               BRK692 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) ? "<#Empty#>" : A51SupplierAgbName);
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
            if ( ! BRK692 )
            {
               BRK692 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIERAGBTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplierAgbTypeName = AV25SearchTxt;
         AV14TFSupplierAgbTypeName_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = AV47FilterFullText;
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = AV15TFSupplierAgbName;
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV16TFSupplierAgbName_Sel;
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV19TFSupplierAgbContactName;
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV20TFSupplierAgbContactName_Sel;
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = AV21TFSupplierAgbPhone;
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV22TFSupplierAgbPhone_Sel;
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = AV23TFSupplierAgbEmail;
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV24TFSupplierAgbEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68Trn_supplieragbwwds_1_filterfulltext ,
                                              AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor P00693 */
         pr_default.execute(1, new Object[] {A11OrganisationId, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV69Trn_supplieragbwwds_2_tfsupplieragbname, AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV71Trn_supplieragbwwds_4_tfsupplieragbtypename, AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV75Trn_supplieragbwwds_8_tfsupplieragbphone, AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV77Trn_supplieragbwwds_10_tfsupplieragbemail, AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK694 = false;
            A255SupplierAgbTypeId = P00693_A255SupplierAgbTypeId[0];
            A57SupplierAgbEmail = P00693_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00693_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00693_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P00693_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P00693_A51SupplierAgbName[0];
            A49SupplierAgbId = P00693_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P00693_A256SupplierAgbTypeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00693_A255SupplierAgbTypeId[0] == A255SupplierAgbTypeId ) )
            {
               BRK694 = false;
               A49SupplierAgbId = P00693_A49SupplierAgbId[0];
               AV35count = (long)(AV35count+1);
               BRK694 = true;
               pr_default.readNext(1);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A256SupplierAgbTypeName)) ? "<#Empty#>" : A256SupplierAgbTypeName);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV26SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
            }
            if ( ! BRK694 )
            {
               BRK694 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplierAgbContactName = AV25SearchTxt;
         AV20TFSupplierAgbContactName_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = AV47FilterFullText;
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = AV15TFSupplierAgbName;
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV16TFSupplierAgbName_Sel;
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV19TFSupplierAgbContactName;
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV20TFSupplierAgbContactName_Sel;
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = AV21TFSupplierAgbPhone;
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV22TFSupplierAgbPhone_Sel;
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = AV23TFSupplierAgbEmail;
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV24TFSupplierAgbEmail_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV68Trn_supplieragbwwds_1_filterfulltext ,
                                              AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor P00694 */
         pr_default.execute(2, new Object[] {A11OrganisationId, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV69Trn_supplieragbwwds_2_tfsupplieragbname, AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV71Trn_supplieragbwwds_4_tfsupplieragbtypename, AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV75Trn_supplieragbwwds_8_tfsupplieragbphone, AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV77Trn_supplieragbwwds_10_tfsupplieragbemail, AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK696 = false;
            A255SupplierAgbTypeId = P00694_A255SupplierAgbTypeId[0];
            A55SupplierAgbContactName = P00694_A55SupplierAgbContactName[0];
            A57SupplierAgbEmail = P00694_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00694_A56SupplierAgbPhone[0];
            A256SupplierAgbTypeName = P00694_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P00694_A51SupplierAgbName[0];
            A49SupplierAgbId = P00694_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P00694_A256SupplierAgbTypeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00694_A55SupplierAgbContactName[0], A55SupplierAgbContactName) == 0 ) )
            {
               BRK696 = false;
               A49SupplierAgbId = P00694_A49SupplierAgbId[0];
               AV35count = (long)(AV35count+1);
               BRK696 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A55SupplierAgbContactName)) ? "<#Empty#>" : A55SupplierAgbContactName);
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
            if ( ! BRK696 )
            {
               BRK696 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERAGBPHONEOPTIONS' Routine */
         returnInSub = false;
         AV21TFSupplierAgbPhone = AV25SearchTxt;
         AV22TFSupplierAgbPhone_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = AV47FilterFullText;
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = AV15TFSupplierAgbName;
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV16TFSupplierAgbName_Sel;
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV19TFSupplierAgbContactName;
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV20TFSupplierAgbContactName_Sel;
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = AV21TFSupplierAgbPhone;
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV22TFSupplierAgbPhone_Sel;
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = AV23TFSupplierAgbEmail;
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV24TFSupplierAgbEmail_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV68Trn_supplieragbwwds_1_filterfulltext ,
                                              AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor P00695 */
         pr_default.execute(3, new Object[] {A11OrganisationId, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV69Trn_supplieragbwwds_2_tfsupplieragbname, AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV71Trn_supplieragbwwds_4_tfsupplieragbtypename, AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV75Trn_supplieragbwwds_8_tfsupplieragbphone, AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV77Trn_supplieragbwwds_10_tfsupplieragbemail, AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK698 = false;
            A255SupplierAgbTypeId = P00695_A255SupplierAgbTypeId[0];
            A56SupplierAgbPhone = P00695_A56SupplierAgbPhone[0];
            A57SupplierAgbEmail = P00695_A57SupplierAgbEmail[0];
            A55SupplierAgbContactName = P00695_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P00695_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P00695_A51SupplierAgbName[0];
            A49SupplierAgbId = P00695_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P00695_A256SupplierAgbTypeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00695_A56SupplierAgbPhone[0], A56SupplierAgbPhone) == 0 ) )
            {
               BRK698 = false;
               A49SupplierAgbId = P00695_A49SupplierAgbId[0];
               AV35count = (long)(AV35count+1);
               BRK698 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A56SupplierAgbPhone)) ? "<#Empty#>" : A56SupplierAgbPhone);
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
            if ( ! BRK698 )
            {
               BRK698 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIERAGBEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFSupplierAgbEmail = AV25SearchTxt;
         AV24TFSupplierAgbEmail_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = AV47FilterFullText;
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = AV15TFSupplierAgbName;
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = AV16TFSupplierAgbName_Sel;
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = AV13TFSupplierAgbTypeName;
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = AV14TFSupplierAgbTypeName_Sel;
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = AV19TFSupplierAgbContactName;
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = AV20TFSupplierAgbContactName_Sel;
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = AV21TFSupplierAgbPhone;
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = AV22TFSupplierAgbPhone_Sel;
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = AV23TFSupplierAgbEmail;
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = AV24TFSupplierAgbEmail_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV68Trn_supplieragbwwds_1_filterfulltext ,
                                              AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                              AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                              AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                              AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                              AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                              AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                              AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                              AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                              AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                              AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                              A51SupplierAgbName ,
                                              A256SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV68Trn_supplieragbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext), "%", "");
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname), "%", "");
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename), "%", "");
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname), "%", "");
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = StringUtil.PadR( StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone), 20, "%");
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = StringUtil.Concat( StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail), "%", "");
         /* Using cursor P00696 */
         pr_default.execute(4, new Object[] {A11OrganisationId, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV68Trn_supplieragbwwds_1_filterfulltext, lV69Trn_supplieragbwwds_2_tfsupplieragbname, AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, lV71Trn_supplieragbwwds_4_tfsupplieragbtypename, AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname, AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, lV75Trn_supplieragbwwds_8_tfsupplieragbphone, AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, lV77Trn_supplieragbwwds_10_tfsupplieragbemail, AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6910 = false;
            A255SupplierAgbTypeId = P00696_A255SupplierAgbTypeId[0];
            A57SupplierAgbEmail = P00696_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00696_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00696_A55SupplierAgbContactName[0];
            A256SupplierAgbTypeName = P00696_A256SupplierAgbTypeName[0];
            A51SupplierAgbName = P00696_A51SupplierAgbName[0];
            A49SupplierAgbId = P00696_A49SupplierAgbId[0];
            A256SupplierAgbTypeName = P00696_A256SupplierAgbTypeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00696_A57SupplierAgbEmail[0], A57SupplierAgbEmail) == 0 ) )
            {
               BRK6910 = false;
               A49SupplierAgbId = P00696_A49SupplierAgbId[0];
               AV35count = (long)(AV35count+1);
               BRK6910 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A57SupplierAgbEmail)) ? "<#Empty#>" : A57SupplierAgbEmail);
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
            if ( ! BRK6910 )
            {
               BRK6910 = true;
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
         AV15TFSupplierAgbName = "";
         AV16TFSupplierAgbName_Sel = "";
         AV13TFSupplierAgbTypeName = "";
         AV14TFSupplierAgbTypeName_Sel = "";
         AV19TFSupplierAgbContactName = "";
         AV20TFSupplierAgbContactName_Sel = "";
         AV21TFSupplierAgbPhone = "";
         AV22TFSupplierAgbPhone_Sel = "";
         AV23TFSupplierAgbEmail = "";
         AV24TFSupplierAgbEmail_Sel = "";
         AV68Trn_supplieragbwwds_1_filterfulltext = "";
         AV69Trn_supplieragbwwds_2_tfsupplieragbname = "";
         AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel = "";
         AV71Trn_supplieragbwwds_4_tfsupplieragbtypename = "";
         AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel = "";
         AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = "";
         AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel = "";
         AV75Trn_supplieragbwwds_8_tfsupplieragbphone = "";
         AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel = "";
         AV77Trn_supplieragbwwds_10_tfsupplieragbemail = "";
         AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel = "";
         lV68Trn_supplieragbwwds_1_filterfulltext = "";
         lV69Trn_supplieragbwwds_2_tfsupplieragbname = "";
         lV71Trn_supplieragbwwds_4_tfsupplieragbtypename = "";
         lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname = "";
         lV75Trn_supplieragbwwds_8_tfsupplieragbphone = "";
         lV77Trn_supplieragbwwds_10_tfsupplieragbemail = "";
         A51SupplierAgbName = "";
         A256SupplierAgbTypeName = "";
         A55SupplierAgbContactName = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         A11OrganisationId = Guid.Empty;
         P00692_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00692_A51SupplierAgbName = new string[] {""} ;
         P00692_A57SupplierAgbEmail = new string[] {""} ;
         P00692_A56SupplierAgbPhone = new string[] {""} ;
         P00692_A55SupplierAgbContactName = new string[] {""} ;
         P00692_A256SupplierAgbTypeName = new string[] {""} ;
         P00692_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         A255SupplierAgbTypeId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         AV30Option = "";
         P00693_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00693_A57SupplierAgbEmail = new string[] {""} ;
         P00693_A56SupplierAgbPhone = new string[] {""} ;
         P00693_A55SupplierAgbContactName = new string[] {""} ;
         P00693_A256SupplierAgbTypeName = new string[] {""} ;
         P00693_A51SupplierAgbName = new string[] {""} ;
         P00693_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00694_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00694_A55SupplierAgbContactName = new string[] {""} ;
         P00694_A57SupplierAgbEmail = new string[] {""} ;
         P00694_A56SupplierAgbPhone = new string[] {""} ;
         P00694_A256SupplierAgbTypeName = new string[] {""} ;
         P00694_A51SupplierAgbName = new string[] {""} ;
         P00694_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00695_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00695_A56SupplierAgbPhone = new string[] {""} ;
         P00695_A57SupplierAgbEmail = new string[] {""} ;
         P00695_A55SupplierAgbContactName = new string[] {""} ;
         P00695_A256SupplierAgbTypeName = new string[] {""} ;
         P00695_A51SupplierAgbName = new string[] {""} ;
         P00695_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00696_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00696_A57SupplierAgbEmail = new string[] {""} ;
         P00696_A56SupplierAgbPhone = new string[] {""} ;
         P00696_A55SupplierAgbContactName = new string[] {""} ;
         P00696_A256SupplierAgbTypeName = new string[] {""} ;
         P00696_A51SupplierAgbName = new string[] {""} ;
         P00696_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00692_A255SupplierAgbTypeId, P00692_A51SupplierAgbName, P00692_A57SupplierAgbEmail, P00692_A56SupplierAgbPhone, P00692_A55SupplierAgbContactName, P00692_A256SupplierAgbTypeName, P00692_A49SupplierAgbId
               }
               , new Object[] {
               P00693_A255SupplierAgbTypeId, P00693_A57SupplierAgbEmail, P00693_A56SupplierAgbPhone, P00693_A55SupplierAgbContactName, P00693_A256SupplierAgbTypeName, P00693_A51SupplierAgbName, P00693_A49SupplierAgbId
               }
               , new Object[] {
               P00694_A255SupplierAgbTypeId, P00694_A55SupplierAgbContactName, P00694_A57SupplierAgbEmail, P00694_A56SupplierAgbPhone, P00694_A256SupplierAgbTypeName, P00694_A51SupplierAgbName, P00694_A49SupplierAgbId
               }
               , new Object[] {
               P00695_A255SupplierAgbTypeId, P00695_A56SupplierAgbPhone, P00695_A57SupplierAgbEmail, P00695_A55SupplierAgbContactName, P00695_A256SupplierAgbTypeName, P00695_A51SupplierAgbName, P00695_A49SupplierAgbId
               }
               , new Object[] {
               P00696_A255SupplierAgbTypeId, P00696_A57SupplierAgbEmail, P00696_A56SupplierAgbPhone, P00696_A55SupplierAgbContactName, P00696_A256SupplierAgbTypeName, P00696_A51SupplierAgbName, P00696_A49SupplierAgbId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV66GXV1 ;
      private int AV29InsertIndex ;
      private long AV35count ;
      private string AV21TFSupplierAgbPhone ;
      private string AV22TFSupplierAgbPhone_Sel ;
      private string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ;
      private string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ;
      private string lV75Trn_supplieragbwwds_8_tfsupplieragbphone ;
      private string A56SupplierAgbPhone ;
      private bool returnInSub ;
      private bool BRK692 ;
      private bool BRK694 ;
      private bool BRK696 ;
      private bool BRK698 ;
      private bool BRK6910 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV15TFSupplierAgbName ;
      private string AV16TFSupplierAgbName_Sel ;
      private string AV13TFSupplierAgbTypeName ;
      private string AV14TFSupplierAgbTypeName_Sel ;
      private string AV19TFSupplierAgbContactName ;
      private string AV20TFSupplierAgbContactName_Sel ;
      private string AV23TFSupplierAgbEmail ;
      private string AV24TFSupplierAgbEmail_Sel ;
      private string AV68Trn_supplieragbwwds_1_filterfulltext ;
      private string AV69Trn_supplieragbwwds_2_tfsupplieragbname ;
      private string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ;
      private string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ;
      private string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ;
      private string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ;
      private string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ;
      private string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ;
      private string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ;
      private string lV68Trn_supplieragbwwds_1_filterfulltext ;
      private string lV69Trn_supplieragbwwds_2_tfsupplieragbname ;
      private string lV71Trn_supplieragbwwds_4_tfsupplieragbtypename ;
      private string lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ;
      private string lV77Trn_supplieragbwwds_10_tfsupplieragbemail ;
      private string A51SupplierAgbName ;
      private string A256SupplierAgbTypeName ;
      private string A55SupplierAgbContactName ;
      private string A57SupplierAgbEmail ;
      private string AV30Option ;
      private Guid A11OrganisationId ;
      private Guid A255SupplierAgbTypeId ;
      private Guid A49SupplierAgbId ;
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
      private Guid[] P00692_A255SupplierAgbTypeId ;
      private string[] P00692_A51SupplierAgbName ;
      private string[] P00692_A57SupplierAgbEmail ;
      private string[] P00692_A56SupplierAgbPhone ;
      private string[] P00692_A55SupplierAgbContactName ;
      private string[] P00692_A256SupplierAgbTypeName ;
      private Guid[] P00692_A49SupplierAgbId ;
      private Guid[] P00693_A255SupplierAgbTypeId ;
      private string[] P00693_A57SupplierAgbEmail ;
      private string[] P00693_A56SupplierAgbPhone ;
      private string[] P00693_A55SupplierAgbContactName ;
      private string[] P00693_A256SupplierAgbTypeName ;
      private string[] P00693_A51SupplierAgbName ;
      private Guid[] P00693_A49SupplierAgbId ;
      private Guid[] P00694_A255SupplierAgbTypeId ;
      private string[] P00694_A55SupplierAgbContactName ;
      private string[] P00694_A57SupplierAgbEmail ;
      private string[] P00694_A56SupplierAgbPhone ;
      private string[] P00694_A256SupplierAgbTypeName ;
      private string[] P00694_A51SupplierAgbName ;
      private Guid[] P00694_A49SupplierAgbId ;
      private Guid[] P00695_A255SupplierAgbTypeId ;
      private string[] P00695_A56SupplierAgbPhone ;
      private string[] P00695_A57SupplierAgbEmail ;
      private string[] P00695_A55SupplierAgbContactName ;
      private string[] P00695_A256SupplierAgbTypeName ;
      private string[] P00695_A51SupplierAgbName ;
      private Guid[] P00695_A49SupplierAgbId ;
      private Guid[] P00696_A255SupplierAgbTypeId ;
      private string[] P00696_A57SupplierAgbEmail ;
      private string[] P00696_A56SupplierAgbPhone ;
      private string[] P00696_A55SupplierAgbContactName ;
      private string[] P00696_A256SupplierAgbTypeName ;
      private string[] P00696_A51SupplierAgbName ;
      private Guid[] P00696_A49SupplierAgbId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_supplieragbwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string AV68Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbName, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(:OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV69Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV71Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV75Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV77Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00693( IGxContext context ,
                                             string AV68Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(:OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV69Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV71Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV75Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV77Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00694( IGxContext context ,
                                             string AV68Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbContactName, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(:OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV69Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV71Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV75Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV77Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00695( IGxContext context ,
                                             string AV68Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbPhone, T1.SupplierAgbEmail, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(:OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV69Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV71Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV75Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV77Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00696( IGxContext context ,
                                             string AV68Trn_supplieragbwwds_1_filterfulltext ,
                                             string AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel ,
                                             string AV69Trn_supplieragbwwds_2_tfsupplieragbname ,
                                             string AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel ,
                                             string AV71Trn_supplieragbwwds_4_tfsupplieragbtypename ,
                                             string AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel ,
                                             string AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname ,
                                             string AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel ,
                                             string AV75Trn_supplieragbwwds_8_tfsupplieragbphone ,
                                             string AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel ,
                                             string AV77Trn_supplieragbwwds_10_tfsupplieragbemail ,
                                             string A51SupplierAgbName ,
                                             string A256SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[16];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(:OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_supplieragbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SupplierAgbName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T2.SupplierAgbTypeName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbContactName) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbPhone) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)) or ( LOWER(T1.SupplierAgbEmail) like '%' || LOWER(:lV68Trn_supplieragbwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_supplieragbwwds_2_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV69Trn_supplieragbwwds_2_tfsupplieragbname)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_supplieragbwwds_4_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV71Trn_supplieragbwwds_4_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_supplieragbwwds_8_tfsupplieragbphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV75Trn_supplieragbwwds_8_tfsupplieragbphone)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel)) && ! ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_supplieragbwwds_10_tfsupplieragbemail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV77Trn_supplieragbwwds_10_tfsupplieragbemail)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel)) && ! ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbEmail";
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 1 :
                     return conditional_P00693(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 2 :
                     return conditional_P00694(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 3 :
                     return conditional_P00695(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 4 :
                     return conditional_P00696(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00693;
          prmP00693 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00694;
          prmP00694 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00695;
          prmP00695 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00696;
          prmP00696 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_supplieragbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_supplieragbwwds_2_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_supplieragbwwds_3_tfsupplieragbname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_supplieragbwwds_4_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_supplieragbwwds_5_tfsupplieragbtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_supplieragbwwds_6_tfsupplieragbcontactname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_supplieragbwwds_7_tfsupplieragbcontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV75Trn_supplieragbwwds_8_tfsupplieragbphone",GXType.Char,20,0) ,
          new ParDef("AV76Trn_supplieragbwwds_9_tfsupplieragbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV77Trn_supplieragbwwds_10_tfsupplieragbemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_supplieragbwwds_11_tfsupplieragbemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00693", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00693,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00694", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00694,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00695", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00695,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00696", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00696,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
