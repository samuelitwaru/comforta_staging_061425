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
   public class trn_locationwwgetfilterdata : GXProcedure
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
            return "trn_locationww_Services_Execute" ;
         }

      }

      public trn_locationwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationwwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_LOCATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_LOCATIONEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_LOCATIONPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONPHONEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("Trn_LocationWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_LocationWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("Trn_LocationWWGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME") == 0 )
            {
               AV11TFLocationName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME_SEL") == 0 )
            {
               AV46TFLocationName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL") == 0 )
            {
               AV17TFLocationEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL_SEL") == 0 )
            {
               AV18TFLocationEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE") == 0 )
            {
               AV19TFLocationPhone = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE_SEL") == 0 )
            {
               AV20TFLocationPhone_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLOCATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFLocationName = AV23SearchTxt;
         AV46TFLocationName_Sel = "";
         AV65Trn_locationwwds_1_filterfulltext = AV45FilterFullText;
         AV66Trn_locationwwds_2_tflocationname = AV11TFLocationName;
         AV67Trn_locationwwds_3_tflocationname_sel = AV46TFLocationName_Sel;
         AV68Trn_locationwwds_4_tflocationemail = AV17TFLocationEmail;
         AV69Trn_locationwwds_5_tflocationemail_sel = AV18TFLocationEmail_Sel;
         AV70Trn_locationwwds_6_tflocationphone = AV19TFLocationPhone;
         AV71Trn_locationwwds_7_tflocationphone_sel = AV20TFLocationPhone_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV65Trn_locationwwds_1_filterfulltext ,
                                              AV67Trn_locationwwds_3_tflocationname_sel ,
                                              AV66Trn_locationwwds_2_tflocationname ,
                                              AV69Trn_locationwwds_5_tflocationemail_sel ,
                                              AV68Trn_locationwwds_4_tflocationemail ,
                                              AV71Trn_locationwwds_7_tflocationphone_sel ,
                                              AV70Trn_locationwwds_6_tflocationphone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              A11OrganisationId ,
                                              AV9WWPContext.gxTpr_Organisationid } ,
                                              new int[]{
                                              }
         });
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV66Trn_locationwwds_2_tflocationname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname), "%", "");
         lV68Trn_locationwwds_4_tflocationemail = StringUtil.Concat( StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail), "%", "");
         lV70Trn_locationwwds_6_tflocationphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone), 20, "%");
         /* Using cursor P00652 */
         pr_default.execute(0, new Object[] {AV9WWPContext.gxTpr_Organisationid, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV66Trn_locationwwds_2_tflocationname, AV67Trn_locationwwds_3_tflocationname_sel, lV68Trn_locationwwds_4_tflocationemail, AV69Trn_locationwwds_5_tflocationemail_sel, lV70Trn_locationwwds_6_tflocationphone, AV71Trn_locationwwds_7_tflocationphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK652 = false;
            A31LocationName = P00652_A31LocationName[0];
            A11OrganisationId = P00652_A11OrganisationId[0];
            A35LocationPhone = P00652_A35LocationPhone[0];
            A34LocationEmail = P00652_A34LocationEmail[0];
            A29LocationId = P00652_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00652_A31LocationName[0], A31LocationName) == 0 ) )
            {
               BRK652 = false;
               A11OrganisationId = P00652_A11OrganisationId[0];
               A29LocationId = P00652_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK652 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A31LocationName)) ? "<#Empty#>" : A31LocationName);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK652 )
            {
               BRK652 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLOCATIONEMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFLocationEmail = AV23SearchTxt;
         AV18TFLocationEmail_Sel = "";
         AV65Trn_locationwwds_1_filterfulltext = AV45FilterFullText;
         AV66Trn_locationwwds_2_tflocationname = AV11TFLocationName;
         AV67Trn_locationwwds_3_tflocationname_sel = AV46TFLocationName_Sel;
         AV68Trn_locationwwds_4_tflocationemail = AV17TFLocationEmail;
         AV69Trn_locationwwds_5_tflocationemail_sel = AV18TFLocationEmail_Sel;
         AV70Trn_locationwwds_6_tflocationphone = AV19TFLocationPhone;
         AV71Trn_locationwwds_7_tflocationphone_sel = AV20TFLocationPhone_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Trn_locationwwds_1_filterfulltext ,
                                              AV67Trn_locationwwds_3_tflocationname_sel ,
                                              AV66Trn_locationwwds_2_tflocationname ,
                                              AV69Trn_locationwwds_5_tflocationemail_sel ,
                                              AV68Trn_locationwwds_4_tflocationemail ,
                                              AV71Trn_locationwwds_7_tflocationphone_sel ,
                                              AV70Trn_locationwwds_6_tflocationphone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              A11OrganisationId ,
                                              AV9WWPContext.gxTpr_Organisationid } ,
                                              new int[]{
                                              }
         });
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV66Trn_locationwwds_2_tflocationname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname), "%", "");
         lV68Trn_locationwwds_4_tflocationemail = StringUtil.Concat( StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail), "%", "");
         lV70Trn_locationwwds_6_tflocationphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone), 20, "%");
         /* Using cursor P00653 */
         pr_default.execute(1, new Object[] {AV9WWPContext.gxTpr_Organisationid, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV66Trn_locationwwds_2_tflocationname, AV67Trn_locationwwds_3_tflocationname_sel, lV68Trn_locationwwds_4_tflocationemail, AV69Trn_locationwwds_5_tflocationemail_sel, lV70Trn_locationwwds_6_tflocationphone, AV71Trn_locationwwds_7_tflocationphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK654 = false;
            A11OrganisationId = P00653_A11OrganisationId[0];
            A34LocationEmail = P00653_A34LocationEmail[0];
            A35LocationPhone = P00653_A35LocationPhone[0];
            A31LocationName = P00653_A31LocationName[0];
            A29LocationId = P00653_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00653_A34LocationEmail[0], A34LocationEmail) == 0 ) )
            {
               BRK654 = false;
               A11OrganisationId = P00653_A11OrganisationId[0];
               A29LocationId = P00653_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK654 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) ? "<#Empty#>" : A34LocationEmail);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK654 )
            {
               BRK654 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLOCATIONPHONEOPTIONS' Routine */
         returnInSub = false;
         AV19TFLocationPhone = AV23SearchTxt;
         AV20TFLocationPhone_Sel = "";
         AV65Trn_locationwwds_1_filterfulltext = AV45FilterFullText;
         AV66Trn_locationwwds_2_tflocationname = AV11TFLocationName;
         AV67Trn_locationwwds_3_tflocationname_sel = AV46TFLocationName_Sel;
         AV68Trn_locationwwds_4_tflocationemail = AV17TFLocationEmail;
         AV69Trn_locationwwds_5_tflocationemail_sel = AV18TFLocationEmail_Sel;
         AV70Trn_locationwwds_6_tflocationphone = AV19TFLocationPhone;
         AV71Trn_locationwwds_7_tflocationphone_sel = AV20TFLocationPhone_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV65Trn_locationwwds_1_filterfulltext ,
                                              AV67Trn_locationwwds_3_tflocationname_sel ,
                                              AV66Trn_locationwwds_2_tflocationname ,
                                              AV69Trn_locationwwds_5_tflocationemail_sel ,
                                              AV68Trn_locationwwds_4_tflocationemail ,
                                              AV71Trn_locationwwds_7_tflocationphone_sel ,
                                              AV70Trn_locationwwds_6_tflocationphone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              A11OrganisationId ,
                                              AV9WWPContext.gxTpr_Organisationid } ,
                                              new int[]{
                                              }
         });
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV65Trn_locationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext), "%", "");
         lV66Trn_locationwwds_2_tflocationname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname), "%", "");
         lV68Trn_locationwwds_4_tflocationemail = StringUtil.Concat( StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail), "%", "");
         lV70Trn_locationwwds_6_tflocationphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone), 20, "%");
         /* Using cursor P00654 */
         pr_default.execute(2, new Object[] {AV9WWPContext.gxTpr_Organisationid, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV65Trn_locationwwds_1_filterfulltext, lV66Trn_locationwwds_2_tflocationname, AV67Trn_locationwwds_3_tflocationname_sel, lV68Trn_locationwwds_4_tflocationemail, AV69Trn_locationwwds_5_tflocationemail_sel, lV70Trn_locationwwds_6_tflocationphone, AV71Trn_locationwwds_7_tflocationphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK656 = false;
            A11OrganisationId = P00654_A11OrganisationId[0];
            A35LocationPhone = P00654_A35LocationPhone[0];
            A34LocationEmail = P00654_A34LocationEmail[0];
            A31LocationName = P00654_A31LocationName[0];
            A29LocationId = P00654_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00654_A35LocationPhone[0], A35LocationPhone) == 0 ) )
            {
               BRK656 = false;
               A11OrganisationId = P00654_A11OrganisationId[0];
               A29LocationId = P00654_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK656 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A35LocationPhone)) ? "<#Empty#>" : A35LocationPhone);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK656 )
            {
               BRK656 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV37GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV11TFLocationName = "";
         AV46TFLocationName_Sel = "";
         AV17TFLocationEmail = "";
         AV18TFLocationEmail_Sel = "";
         AV19TFLocationPhone = "";
         AV20TFLocationPhone_Sel = "";
         AV65Trn_locationwwds_1_filterfulltext = "";
         AV66Trn_locationwwds_2_tflocationname = "";
         AV67Trn_locationwwds_3_tflocationname_sel = "";
         AV68Trn_locationwwds_4_tflocationemail = "";
         AV69Trn_locationwwds_5_tflocationemail_sel = "";
         AV70Trn_locationwwds_6_tflocationphone = "";
         AV71Trn_locationwwds_7_tflocationphone_sel = "";
         lV65Trn_locationwwds_1_filterfulltext = "";
         lV66Trn_locationwwds_2_tflocationname = "";
         lV68Trn_locationwwds_4_tflocationemail = "";
         lV70Trn_locationwwds_6_tflocationphone = "";
         A31LocationName = "";
         A34LocationEmail = "";
         A35LocationPhone = "";
         A11OrganisationId = Guid.Empty;
         P00652_A31LocationName = new string[] {""} ;
         P00652_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00652_A35LocationPhone = new string[] {""} ;
         P00652_A34LocationEmail = new string[] {""} ;
         P00652_A29LocationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         AV28Option = "";
         P00653_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00653_A34LocationEmail = new string[] {""} ;
         P00653_A35LocationPhone = new string[] {""} ;
         P00653_A31LocationName = new string[] {""} ;
         P00653_A29LocationId = new Guid[] {Guid.Empty} ;
         P00654_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00654_A35LocationPhone = new string[] {""} ;
         P00654_A34LocationEmail = new string[] {""} ;
         P00654_A31LocationName = new string[] {""} ;
         P00654_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00652_A31LocationName, P00652_A11OrganisationId, P00652_A35LocationPhone, P00652_A34LocationEmail, P00652_A29LocationId
               }
               , new Object[] {
               P00653_A11OrganisationId, P00653_A34LocationEmail, P00653_A35LocationPhone, P00653_A31LocationName, P00653_A29LocationId
               }
               , new Object[] {
               P00654_A11OrganisationId, P00654_A35LocationPhone, P00654_A34LocationEmail, P00654_A31LocationName, P00654_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV63GXV1 ;
      private long AV33count ;
      private string AV19TFLocationPhone ;
      private string AV20TFLocationPhone_Sel ;
      private string AV70Trn_locationwwds_6_tflocationphone ;
      private string AV71Trn_locationwwds_7_tflocationphone_sel ;
      private string lV70Trn_locationwwds_6_tflocationphone ;
      private string A35LocationPhone ;
      private bool returnInSub ;
      private bool BRK652 ;
      private bool BRK654 ;
      private bool BRK656 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV11TFLocationName ;
      private string AV46TFLocationName_Sel ;
      private string AV17TFLocationEmail ;
      private string AV18TFLocationEmail_Sel ;
      private string AV65Trn_locationwwds_1_filterfulltext ;
      private string AV66Trn_locationwwds_2_tflocationname ;
      private string AV67Trn_locationwwds_3_tflocationname_sel ;
      private string AV68Trn_locationwwds_4_tflocationemail ;
      private string AV69Trn_locationwwds_5_tflocationemail_sel ;
      private string lV65Trn_locationwwds_1_filterfulltext ;
      private string lV66Trn_locationwwds_2_tflocationname ;
      private string lV68Trn_locationwwds_4_tflocationemail ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string AV28Option ;
      private Guid AV9WWPContext_gxTpr_Organisationid ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV36GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00652_A31LocationName ;
      private Guid[] P00652_A11OrganisationId ;
      private string[] P00652_A35LocationPhone ;
      private string[] P00652_A34LocationEmail ;
      private Guid[] P00652_A29LocationId ;
      private Guid[] P00653_A11OrganisationId ;
      private string[] P00653_A34LocationEmail ;
      private string[] P00653_A35LocationPhone ;
      private string[] P00653_A31LocationName ;
      private Guid[] P00653_A29LocationId ;
      private Guid[] P00654_A11OrganisationId ;
      private string[] P00654_A35LocationPhone ;
      private string[] P00654_A34LocationEmail ;
      private string[] P00654_A31LocationName ;
      private Guid[] P00654_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_locationwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00652( IGxContext context ,
                                             string AV65Trn_locationwwds_1_filterfulltext ,
                                             string AV67Trn_locationwwds_3_tflocationname_sel ,
                                             string AV66Trn_locationwwds_2_tflocationname ,
                                             string AV69Trn_locationwwds_5_tflocationemail_sel ,
                                             string AV68Trn_locationwwds_4_tflocationemail ,
                                             string AV71Trn_locationwwds_7_tflocationphone_sel ,
                                             string AV70Trn_locationwwds_6_tflocationphone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV9WWPContext_gxTpr_Organisationid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LocationName, OrganisationId, LocationPhone, LocationEmail, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV9WWPContext__Organisationid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV66Trn_locationwwds_2_tflocationname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV67Trn_locationwwds_3_tflocationname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV68Trn_locationwwds_4_tflocationemail)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ! ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV69Trn_locationwwds_5_tflocationemail_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV70Trn_locationwwds_6_tflocationphone)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV71Trn_locationwwds_7_tflocationphone_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LocationName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00653( IGxContext context ,
                                             string AV65Trn_locationwwds_1_filterfulltext ,
                                             string AV67Trn_locationwwds_3_tflocationname_sel ,
                                             string AV66Trn_locationwwds_2_tflocationname ,
                                             string AV69Trn_locationwwds_5_tflocationemail_sel ,
                                             string AV68Trn_locationwwds_4_tflocationemail ,
                                             string AV71Trn_locationwwds_7_tflocationphone_sel ,
                                             string AV70Trn_locationwwds_6_tflocationphone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV9WWPContext_gxTpr_Organisationid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationEmail, LocationPhone, LocationName, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV9WWPContext__Organisationid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV66Trn_locationwwds_2_tflocationname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV67Trn_locationwwds_3_tflocationname_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV68Trn_locationwwds_4_tflocationemail)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ! ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV69Trn_locationwwds_5_tflocationemail_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV70Trn_locationwwds_6_tflocationphone)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV71Trn_locationwwds_7_tflocationphone_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LocationEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00654( IGxContext context ,
                                             string AV65Trn_locationwwds_1_filterfulltext ,
                                             string AV67Trn_locationwwds_3_tflocationname_sel ,
                                             string AV66Trn_locationwwds_2_tflocationname ,
                                             string AV69Trn_locationwwds_5_tflocationemail_sel ,
                                             string AV68Trn_locationwwds_4_tflocationemail ,
                                             string AV71Trn_locationwwds_7_tflocationphone_sel ,
                                             string AV70Trn_locationwwds_6_tflocationphone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV9WWPContext_gxTpr_Organisationid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationPhone, LocationEmail, LocationName, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV9WWPContext__Organisationid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_locationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV65Trn_locationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_locationwwds_2_tflocationname)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV66Trn_locationwwds_2_tflocationname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_locationwwds_3_tflocationname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV67Trn_locationwwds_3_tflocationname_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_locationwwds_3_tflocationname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_locationwwds_4_tflocationemail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV68Trn_locationwwds_4_tflocationemail)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_locationwwds_5_tflocationemail_sel)) && ! ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV69Trn_locationwwds_5_tflocationemail_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_locationwwds_5_tflocationemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_locationwwds_6_tflocationphone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV70Trn_locationwwds_6_tflocationphone)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_locationwwds_7_tflocationphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV71Trn_locationwwds_7_tflocationphone_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_locationwwds_7_tflocationphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LocationPhone";
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
                     return conditional_P00652(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 1 :
                     return conditional_P00653(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 2 :
                     return conditional_P00654(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
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
          Object[] prmP00652;
          prmP00652 = new Object[] {
          new ParDef("AV9WWPContext__Organisationid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_locationwwds_2_tflocationname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_locationwwds_3_tflocationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_locationwwds_4_tflocationemail",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_locationwwds_5_tflocationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_locationwwds_6_tflocationphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_locationwwds_7_tflocationphone_sel",GXType.Char,20,0)
          };
          Object[] prmP00653;
          prmP00653 = new Object[] {
          new ParDef("AV9WWPContext__Organisationid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_locationwwds_2_tflocationname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_locationwwds_3_tflocationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_locationwwds_4_tflocationemail",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_locationwwds_5_tflocationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_locationwwds_6_tflocationphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_locationwwds_7_tflocationphone_sel",GXType.Char,20,0)
          };
          Object[] prmP00654;
          prmP00654 = new Object[] {
          new ParDef("AV9WWPContext__Organisationid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_locationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_locationwwds_2_tflocationname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_locationwwds_3_tflocationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_locationwwds_4_tflocationemail",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_locationwwds_5_tflocationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_locationwwds_6_tflocationphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_locationwwds_7_tflocationphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00652", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00652,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00653", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00653,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00654", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00654,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
