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
   public class trn_residentwwgetfilterdata : GXProcedure
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
            return "trn_residentww_Services_Execute" ;
         }

      }

      public trn_residentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentwwgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36MaxItems = 10;
         AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESIDENTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESIDENTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESIDENTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESIDENTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESIDENTTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTTYPENAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("Trn_ResidentWWGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_ResidentWWGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("Trn_ResidentWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTSALUTATION_SEL") == 0 )
            {
               AV11TFResidentSalutation_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV12TFResidentSalutation_Sels.FromJSonString(AV11TFResidentSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV13TFResidentGivenName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV14TFResidentGivenName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV15TFResidentLastName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV16TFResidentLastName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTGENDER_SEL") == 0 )
            {
               AV21TFResidentGender_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV22TFResidentGender_Sels.FromJSonString(AV21TFResidentGender_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV19TFResidentEmail = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV20TFResidentEmail_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV25TFResidentPhone = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV26TFResidentPhone_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV29TFResidentTypeName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV30TFResidentTypeName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentGivenName = AV33SearchTxt;
         AV14TFResidentGivenName_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = AV55FilterFullText;
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV66Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV68Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV69Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV70Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV71Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV72Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV73Trn_residentwwds_10_tfresidentphone = AV25TFResidentPhone;
         AV74Trn_residentwwds_11_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV75Trn_residentwwds_12_tfresidenttypename = AV29TFResidentTypeName;
         AV76Trn_residentwwds_13_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV66Trn_residentwwds_3_tfresidentgivenname ,
                                              AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV68Trn_residentwwds_5_tfresidentlastname ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV71Trn_residentwwds_8_tfresidentemail ,
                                              AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_10_tfresidentphone ,
                                              AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV75Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV64Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV66Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV68Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV71Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail), "%", "");
         lV73Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV75Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P006R2 */
         pr_default.execute(0, new Object[] {lV66Trn_residentwwds_3_tfresidentgivenname, AV67Trn_residentwwds_4_tfresidentgivenname_sel, lV68Trn_residentwwds_5_tfresidentlastname, AV69Trn_residentwwds_6_tfresidentlastname_sel, lV71Trn_residentwwds_8_tfresidentemail, AV72Trn_residentwwds_9_tfresidentemail_sel, lV73Trn_residentwwds_10_tfresidentphone, AV74Trn_residentwwds_11_tfresidentphone_sel, lV75Trn_residentwwds_12_tfresidenttypename, AV76Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6R2 = false;
            A96ResidentTypeId = P006R2_A96ResidentTypeId[0];
            n96ResidentTypeId = P006R2_n96ResidentTypeId[0];
            A64ResidentGivenName = P006R2_A64ResidentGivenName[0];
            A97ResidentTypeName = P006R2_A97ResidentTypeName[0];
            A70ResidentPhone = P006R2_A70ResidentPhone[0];
            A67ResidentEmail = P006R2_A67ResidentEmail[0];
            A65ResidentLastName = P006R2_A65ResidentLastName[0];
            A68ResidentGender = P006R2_A68ResidentGender[0];
            A72ResidentSalutation = P006R2_A72ResidentSalutation[0];
            A62ResidentId = P006R2_A62ResidentId[0];
            A29LocationId = P006R2_A29LocationId[0];
            A11OrganisationId = P006R2_A11OrganisationId[0];
            A97ResidentTypeName = P006R2_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A64ResidentGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A65ResidentLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A67ResidentEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A70ResidentPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A97ResidentTypeName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006R2_A64ResidentGivenName[0], A64ResidentGivenName) == 0 ) )
               {
                  BRK6R2 = false;
                  A62ResidentId = P006R2_A62ResidentId[0];
                  A29LocationId = P006R2_A29LocationId[0];
                  A11OrganisationId = P006R2_A11OrganisationId[0];
                  AV43count = (long)(AV43count+1);
                  BRK6R2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) ? "<#Empty#>" : A64ResidentGivenName);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK6R2 )
            {
               BRK6R2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFResidentLastName = AV33SearchTxt;
         AV16TFResidentLastName_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = AV55FilterFullText;
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV66Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV68Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV69Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV70Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV71Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV72Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV73Trn_residentwwds_10_tfresidentphone = AV25TFResidentPhone;
         AV74Trn_residentwwds_11_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV75Trn_residentwwds_12_tfresidenttypename = AV29TFResidentTypeName;
         AV76Trn_residentwwds_13_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV66Trn_residentwwds_3_tfresidentgivenname ,
                                              AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV68Trn_residentwwds_5_tfresidentlastname ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV71Trn_residentwwds_8_tfresidentemail ,
                                              AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_10_tfresidentphone ,
                                              AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV75Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV64Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV66Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV68Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV71Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail), "%", "");
         lV73Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV75Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P006R3 */
         pr_default.execute(1, new Object[] {lV66Trn_residentwwds_3_tfresidentgivenname, AV67Trn_residentwwds_4_tfresidentgivenname_sel, lV68Trn_residentwwds_5_tfresidentlastname, AV69Trn_residentwwds_6_tfresidentlastname_sel, lV71Trn_residentwwds_8_tfresidentemail, AV72Trn_residentwwds_9_tfresidentemail_sel, lV73Trn_residentwwds_10_tfresidentphone, AV74Trn_residentwwds_11_tfresidentphone_sel, lV75Trn_residentwwds_12_tfresidenttypename, AV76Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6R4 = false;
            A96ResidentTypeId = P006R3_A96ResidentTypeId[0];
            n96ResidentTypeId = P006R3_n96ResidentTypeId[0];
            A65ResidentLastName = P006R3_A65ResidentLastName[0];
            A97ResidentTypeName = P006R3_A97ResidentTypeName[0];
            A70ResidentPhone = P006R3_A70ResidentPhone[0];
            A67ResidentEmail = P006R3_A67ResidentEmail[0];
            A64ResidentGivenName = P006R3_A64ResidentGivenName[0];
            A68ResidentGender = P006R3_A68ResidentGender[0];
            A72ResidentSalutation = P006R3_A72ResidentSalutation[0];
            A62ResidentId = P006R3_A62ResidentId[0];
            A29LocationId = P006R3_A29LocationId[0];
            A11OrganisationId = P006R3_A11OrganisationId[0];
            A97ResidentTypeName = P006R3_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A64ResidentGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A65ResidentLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A67ResidentEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A70ResidentPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A97ResidentTypeName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006R3_A65ResidentLastName[0], A65ResidentLastName) == 0 ) )
               {
                  BRK6R4 = false;
                  A62ResidentId = P006R3_A62ResidentId[0];
                  A29LocationId = P006R3_A29LocationId[0];
                  A11OrganisationId = P006R3_A11OrganisationId[0];
                  AV43count = (long)(AV43count+1);
                  BRK6R4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) ? "<#Empty#>" : A65ResidentLastName);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK6R4 )
            {
               BRK6R4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESIDENTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFResidentEmail = AV33SearchTxt;
         AV20TFResidentEmail_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = AV55FilterFullText;
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV66Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV68Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV69Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV70Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV71Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV72Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV73Trn_residentwwds_10_tfresidentphone = AV25TFResidentPhone;
         AV74Trn_residentwwds_11_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV75Trn_residentwwds_12_tfresidenttypename = AV29TFResidentTypeName;
         AV76Trn_residentwwds_13_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV66Trn_residentwwds_3_tfresidentgivenname ,
                                              AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV68Trn_residentwwds_5_tfresidentlastname ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV71Trn_residentwwds_8_tfresidentemail ,
                                              AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_10_tfresidentphone ,
                                              AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV75Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV64Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV66Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV68Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV71Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail), "%", "");
         lV73Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV75Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P006R4 */
         pr_default.execute(2, new Object[] {lV66Trn_residentwwds_3_tfresidentgivenname, AV67Trn_residentwwds_4_tfresidentgivenname_sel, lV68Trn_residentwwds_5_tfresidentlastname, AV69Trn_residentwwds_6_tfresidentlastname_sel, lV71Trn_residentwwds_8_tfresidentemail, AV72Trn_residentwwds_9_tfresidentemail_sel, lV73Trn_residentwwds_10_tfresidentphone, AV74Trn_residentwwds_11_tfresidentphone_sel, lV75Trn_residentwwds_12_tfresidenttypename, AV76Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6R6 = false;
            A96ResidentTypeId = P006R4_A96ResidentTypeId[0];
            n96ResidentTypeId = P006R4_n96ResidentTypeId[0];
            A67ResidentEmail = P006R4_A67ResidentEmail[0];
            A97ResidentTypeName = P006R4_A97ResidentTypeName[0];
            A70ResidentPhone = P006R4_A70ResidentPhone[0];
            A65ResidentLastName = P006R4_A65ResidentLastName[0];
            A64ResidentGivenName = P006R4_A64ResidentGivenName[0];
            A68ResidentGender = P006R4_A68ResidentGender[0];
            A72ResidentSalutation = P006R4_A72ResidentSalutation[0];
            A62ResidentId = P006R4_A62ResidentId[0];
            A29LocationId = P006R4_A29LocationId[0];
            A11OrganisationId = P006R4_A11OrganisationId[0];
            A97ResidentTypeName = P006R4_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A64ResidentGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A65ResidentLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A67ResidentEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A70ResidentPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A97ResidentTypeName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006R4_A67ResidentEmail[0], A67ResidentEmail) == 0 ) )
               {
                  BRK6R6 = false;
                  A62ResidentId = P006R4_A62ResidentId[0];
                  A29LocationId = P006R4_A29LocationId[0];
                  A11OrganisationId = P006R4_A11OrganisationId[0];
                  AV43count = (long)(AV43count+1);
                  BRK6R6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) ? "<#Empty#>" : A67ResidentEmail);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK6R6 )
            {
               BRK6R6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRESIDENTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV25TFResidentPhone = AV33SearchTxt;
         AV26TFResidentPhone_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = AV55FilterFullText;
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV66Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV68Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV69Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV70Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV71Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV72Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV73Trn_residentwwds_10_tfresidentphone = AV25TFResidentPhone;
         AV74Trn_residentwwds_11_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV75Trn_residentwwds_12_tfresidenttypename = AV29TFResidentTypeName;
         AV76Trn_residentwwds_13_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV66Trn_residentwwds_3_tfresidentgivenname ,
                                              AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV68Trn_residentwwds_5_tfresidentlastname ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV71Trn_residentwwds_8_tfresidentemail ,
                                              AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_10_tfresidentphone ,
                                              AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV75Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV64Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV66Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV68Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV71Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail), "%", "");
         lV73Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV75Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P006R5 */
         pr_default.execute(3, new Object[] {lV66Trn_residentwwds_3_tfresidentgivenname, AV67Trn_residentwwds_4_tfresidentgivenname_sel, lV68Trn_residentwwds_5_tfresidentlastname, AV69Trn_residentwwds_6_tfresidentlastname_sel, lV71Trn_residentwwds_8_tfresidentemail, AV72Trn_residentwwds_9_tfresidentemail_sel, lV73Trn_residentwwds_10_tfresidentphone, AV74Trn_residentwwds_11_tfresidentphone_sel, lV75Trn_residentwwds_12_tfresidenttypename, AV76Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6R8 = false;
            A96ResidentTypeId = P006R5_A96ResidentTypeId[0];
            n96ResidentTypeId = P006R5_n96ResidentTypeId[0];
            A70ResidentPhone = P006R5_A70ResidentPhone[0];
            A97ResidentTypeName = P006R5_A97ResidentTypeName[0];
            A67ResidentEmail = P006R5_A67ResidentEmail[0];
            A65ResidentLastName = P006R5_A65ResidentLastName[0];
            A64ResidentGivenName = P006R5_A64ResidentGivenName[0];
            A68ResidentGender = P006R5_A68ResidentGender[0];
            A72ResidentSalutation = P006R5_A72ResidentSalutation[0];
            A62ResidentId = P006R5_A62ResidentId[0];
            A29LocationId = P006R5_A29LocationId[0];
            A11OrganisationId = P006R5_A11OrganisationId[0];
            A97ResidentTypeName = P006R5_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A64ResidentGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A65ResidentLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A67ResidentEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A70ResidentPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A97ResidentTypeName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006R5_A70ResidentPhone[0], A70ResidentPhone) == 0 ) )
               {
                  BRK6R8 = false;
                  A62ResidentId = P006R5_A62ResidentId[0];
                  A29LocationId = P006R5_A29LocationId[0];
                  A11OrganisationId = P006R5_A11OrganisationId[0];
                  AV43count = (long)(AV43count+1);
                  BRK6R8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70ResidentPhone)) ? "<#Empty#>" : A70ResidentPhone);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK6R8 )
            {
               BRK6R8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADRESIDENTTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV29TFResidentTypeName = AV33SearchTxt;
         AV30TFResidentTypeName_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = AV55FilterFullText;
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV66Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV68Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV69Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV70Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV71Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV72Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV73Trn_residentwwds_10_tfresidentphone = AV25TFResidentPhone;
         AV74Trn_residentwwds_11_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV75Trn_residentwwds_12_tfresidenttypename = AV29TFResidentTypeName;
         AV76Trn_residentwwds_13_tfresidenttypename_sel = AV30TFResidentTypeName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV65Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV66Trn_residentwwds_3_tfresidentgivenname ,
                                              AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV68Trn_residentwwds_5_tfresidentlastname ,
                                              AV70Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV71Trn_residentwwds_8_tfresidentemail ,
                                              AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_10_tfresidentphone ,
                                              AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV75Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV64Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV66Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV68Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV71Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail), "%", "");
         lV73Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV75Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P006R6 */
         pr_default.execute(4, new Object[] {lV66Trn_residentwwds_3_tfresidentgivenname, AV67Trn_residentwwds_4_tfresidentgivenname_sel, lV68Trn_residentwwds_5_tfresidentlastname, AV69Trn_residentwwds_6_tfresidentlastname_sel, lV71Trn_residentwwds_8_tfresidentemail, AV72Trn_residentwwds_9_tfresidentemail_sel, lV73Trn_residentwwds_10_tfresidentphone, AV74Trn_residentwwds_11_tfresidentphone_sel, lV75Trn_residentwwds_12_tfresidenttypename, AV76Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6R10 = false;
            A96ResidentTypeId = P006R6_A96ResidentTypeId[0];
            n96ResidentTypeId = P006R6_n96ResidentTypeId[0];
            A97ResidentTypeName = P006R6_A97ResidentTypeName[0];
            A70ResidentPhone = P006R6_A70ResidentPhone[0];
            A67ResidentEmail = P006R6_A67ResidentEmail[0];
            A65ResidentLastName = P006R6_A65ResidentLastName[0];
            A64ResidentGivenName = P006R6_A64ResidentGivenName[0];
            A68ResidentGender = P006R6_A68ResidentGender[0];
            A72ResidentSalutation = P006R6_A72ResidentSalutation[0];
            A62ResidentId = P006R6_A62ResidentId[0];
            A29LocationId = P006R6_A29LocationId[0];
            A11OrganisationId = P006R6_A11OrganisationId[0];
            A97ResidentTypeName = P006R6_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A64ResidentGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A65ResidentLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A67ResidentEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A70ResidentPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A97ResidentTypeName) , StringUtil.PadR( "%" + StringUtil.Lower( AV64Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P006R6_A96ResidentTypeId[0] == A96ResidentTypeId ) )
               {
                  BRK6R10 = false;
                  A62ResidentId = P006R6_A62ResidentId[0];
                  A29LocationId = P006R6_A29LocationId[0];
                  A11OrganisationId = P006R6_A11OrganisationId[0];
                  AV43count = (long)(AV43count+1);
                  BRK6R10 = true;
                  pr_default.readNext(4);
               }
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A97ResidentTypeName)) ? "<#Empty#>" : A97ResidentTypeName);
               AV37InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV37InsertIndex = (int)(AV37InsertIndex+1);
               }
               AV39Options.Add(AV38Option, AV37InsertIndex);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
               if ( AV39Options.Count == AV34SkipItems + 11 )
               {
                  AV39Options.RemoveItem(AV39Options.Count);
                  AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
               }
            }
            if ( ! BRK6R10 )
            {
               BRK6R10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV47GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV11TFResidentSalutation_SelsJson = "";
         AV12TFResidentSalutation_Sels = new GxSimpleCollection<string>();
         AV13TFResidentGivenName = "";
         AV14TFResidentGivenName_Sel = "";
         AV15TFResidentLastName = "";
         AV16TFResidentLastName_Sel = "";
         AV21TFResidentGender_SelsJson = "";
         AV22TFResidentGender_Sels = new GxSimpleCollection<string>();
         AV19TFResidentEmail = "";
         AV20TFResidentEmail_Sel = "";
         AV25TFResidentPhone = "";
         AV26TFResidentPhone_Sel = "";
         AV29TFResidentTypeName = "";
         AV30TFResidentTypeName_Sel = "";
         AV64Trn_residentwwds_1_filterfulltext = "";
         AV65Trn_residentwwds_2_tfresidentsalutation_sels = new GxSimpleCollection<string>();
         AV66Trn_residentwwds_3_tfresidentgivenname = "";
         AV67Trn_residentwwds_4_tfresidentgivenname_sel = "";
         AV68Trn_residentwwds_5_tfresidentlastname = "";
         AV69Trn_residentwwds_6_tfresidentlastname_sel = "";
         AV70Trn_residentwwds_7_tfresidentgender_sels = new GxSimpleCollection<string>();
         AV71Trn_residentwwds_8_tfresidentemail = "";
         AV72Trn_residentwwds_9_tfresidentemail_sel = "";
         AV73Trn_residentwwds_10_tfresidentphone = "";
         AV74Trn_residentwwds_11_tfresidentphone_sel = "";
         AV75Trn_residentwwds_12_tfresidenttypename = "";
         AV76Trn_residentwwds_13_tfresidenttypename_sel = "";
         lV64Trn_residentwwds_1_filterfulltext = "";
         lV66Trn_residentwwds_3_tfresidentgivenname = "";
         lV68Trn_residentwwds_5_tfresidentlastname = "";
         lV71Trn_residentwwds_8_tfresidentemail = "";
         lV73Trn_residentwwds_10_tfresidentphone = "";
         lV75Trn_residentwwds_12_tfresidenttypename = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A67ResidentEmail = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         P006R2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006R2_n96ResidentTypeId = new bool[] {false} ;
         P006R2_A64ResidentGivenName = new string[] {""} ;
         P006R2_A97ResidentTypeName = new string[] {""} ;
         P006R2_A70ResidentPhone = new string[] {""} ;
         P006R2_A67ResidentEmail = new string[] {""} ;
         P006R2_A65ResidentLastName = new string[] {""} ;
         P006R2_A68ResidentGender = new string[] {""} ;
         P006R2_A72ResidentSalutation = new string[] {""} ;
         P006R2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006R2_A29LocationId = new Guid[] {Guid.Empty} ;
         P006R2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A96ResidentTypeId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV38Option = "";
         P006R3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006R3_n96ResidentTypeId = new bool[] {false} ;
         P006R3_A65ResidentLastName = new string[] {""} ;
         P006R3_A97ResidentTypeName = new string[] {""} ;
         P006R3_A70ResidentPhone = new string[] {""} ;
         P006R3_A67ResidentEmail = new string[] {""} ;
         P006R3_A64ResidentGivenName = new string[] {""} ;
         P006R3_A68ResidentGender = new string[] {""} ;
         P006R3_A72ResidentSalutation = new string[] {""} ;
         P006R3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006R3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006R3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006R4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006R4_n96ResidentTypeId = new bool[] {false} ;
         P006R4_A67ResidentEmail = new string[] {""} ;
         P006R4_A97ResidentTypeName = new string[] {""} ;
         P006R4_A70ResidentPhone = new string[] {""} ;
         P006R4_A65ResidentLastName = new string[] {""} ;
         P006R4_A64ResidentGivenName = new string[] {""} ;
         P006R4_A68ResidentGender = new string[] {""} ;
         P006R4_A72ResidentSalutation = new string[] {""} ;
         P006R4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006R4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006R4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006R5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006R5_n96ResidentTypeId = new bool[] {false} ;
         P006R5_A70ResidentPhone = new string[] {""} ;
         P006R5_A97ResidentTypeName = new string[] {""} ;
         P006R5_A67ResidentEmail = new string[] {""} ;
         P006R5_A65ResidentLastName = new string[] {""} ;
         P006R5_A64ResidentGivenName = new string[] {""} ;
         P006R5_A68ResidentGender = new string[] {""} ;
         P006R5_A72ResidentSalutation = new string[] {""} ;
         P006R5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006R5_A29LocationId = new Guid[] {Guid.Empty} ;
         P006R5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006R6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P006R6_n96ResidentTypeId = new bool[] {false} ;
         P006R6_A97ResidentTypeName = new string[] {""} ;
         P006R6_A70ResidentPhone = new string[] {""} ;
         P006R6_A67ResidentEmail = new string[] {""} ;
         P006R6_A65ResidentLastName = new string[] {""} ;
         P006R6_A64ResidentGivenName = new string[] {""} ;
         P006R6_A68ResidentGender = new string[] {""} ;
         P006R6_A72ResidentSalutation = new string[] {""} ;
         P006R6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006R6_A29LocationId = new Guid[] {Guid.Empty} ;
         P006R6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006R2_A96ResidentTypeId, P006R2_n96ResidentTypeId, P006R2_A64ResidentGivenName, P006R2_A97ResidentTypeName, P006R2_A70ResidentPhone, P006R2_A67ResidentEmail, P006R2_A65ResidentLastName, P006R2_A68ResidentGender, P006R2_A72ResidentSalutation, P006R2_A62ResidentId,
               P006R2_A29LocationId, P006R2_A11OrganisationId
               }
               , new Object[] {
               P006R3_A96ResidentTypeId, P006R3_n96ResidentTypeId, P006R3_A65ResidentLastName, P006R3_A97ResidentTypeName, P006R3_A70ResidentPhone, P006R3_A67ResidentEmail, P006R3_A64ResidentGivenName, P006R3_A68ResidentGender, P006R3_A72ResidentSalutation, P006R3_A62ResidentId,
               P006R3_A29LocationId, P006R3_A11OrganisationId
               }
               , new Object[] {
               P006R4_A96ResidentTypeId, P006R4_n96ResidentTypeId, P006R4_A67ResidentEmail, P006R4_A97ResidentTypeName, P006R4_A70ResidentPhone, P006R4_A65ResidentLastName, P006R4_A64ResidentGivenName, P006R4_A68ResidentGender, P006R4_A72ResidentSalutation, P006R4_A62ResidentId,
               P006R4_A29LocationId, P006R4_A11OrganisationId
               }
               , new Object[] {
               P006R5_A96ResidentTypeId, P006R5_n96ResidentTypeId, P006R5_A70ResidentPhone, P006R5_A97ResidentTypeName, P006R5_A67ResidentEmail, P006R5_A65ResidentLastName, P006R5_A64ResidentGivenName, P006R5_A68ResidentGender, P006R5_A72ResidentSalutation, P006R5_A62ResidentId,
               P006R5_A29LocationId, P006R5_A11OrganisationId
               }
               , new Object[] {
               P006R6_A96ResidentTypeId, P006R6_n96ResidentTypeId, P006R6_A97ResidentTypeName, P006R6_A70ResidentPhone, P006R6_A67ResidentEmail, P006R6_A65ResidentLastName, P006R6_A64ResidentGivenName, P006R6_A68ResidentGender, P006R6_A72ResidentSalutation, P006R6_A62ResidentId,
               P006R6_A29LocationId, P006R6_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private int AV62GXV1 ;
      private int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ;
      private int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ;
      private int AV37InsertIndex ;
      private long AV43count ;
      private string AV25TFResidentPhone ;
      private string AV26TFResidentPhone_Sel ;
      private string AV73Trn_residentwwds_10_tfresidentphone ;
      private string AV74Trn_residentwwds_11_tfresidentphone_sel ;
      private string lV73Trn_residentwwds_10_tfresidentphone ;
      private string A72ResidentSalutation ;
      private string A70ResidentPhone ;
      private bool returnInSub ;
      private bool BRK6R2 ;
      private bool n96ResidentTypeId ;
      private bool BRK6R4 ;
      private bool BRK6R6 ;
      private bool BRK6R8 ;
      private bool BRK6R10 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV11TFResidentSalutation_SelsJson ;
      private string AV21TFResidentGender_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV13TFResidentGivenName ;
      private string AV14TFResidentGivenName_Sel ;
      private string AV15TFResidentLastName ;
      private string AV16TFResidentLastName_Sel ;
      private string AV19TFResidentEmail ;
      private string AV20TFResidentEmail_Sel ;
      private string AV29TFResidentTypeName ;
      private string AV30TFResidentTypeName_Sel ;
      private string AV64Trn_residentwwds_1_filterfulltext ;
      private string AV66Trn_residentwwds_3_tfresidentgivenname ;
      private string AV67Trn_residentwwds_4_tfresidentgivenname_sel ;
      private string AV68Trn_residentwwds_5_tfresidentlastname ;
      private string AV69Trn_residentwwds_6_tfresidentlastname_sel ;
      private string AV71Trn_residentwwds_8_tfresidentemail ;
      private string AV72Trn_residentwwds_9_tfresidentemail_sel ;
      private string AV75Trn_residentwwds_12_tfresidenttypename ;
      private string AV76Trn_residentwwds_13_tfresidenttypename_sel ;
      private string lV64Trn_residentwwds_1_filterfulltext ;
      private string lV66Trn_residentwwds_3_tfresidentgivenname ;
      private string lV68Trn_residentwwds_5_tfresidentlastname ;
      private string lV71Trn_residentwwds_8_tfresidentemail ;
      private string lV75Trn_residentwwds_12_tfresidenttypename ;
      private string A68ResidentGender ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A97ResidentTypeName ;
      private string AV38Option ;
      private Guid A96ResidentTypeId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV46GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private GxSimpleCollection<string> AV12TFResidentSalutation_Sels ;
      private GxSimpleCollection<string> AV22TFResidentGender_Sels ;
      private GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ;
      private GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006R2_A96ResidentTypeId ;
      private bool[] P006R2_n96ResidentTypeId ;
      private string[] P006R2_A64ResidentGivenName ;
      private string[] P006R2_A97ResidentTypeName ;
      private string[] P006R2_A70ResidentPhone ;
      private string[] P006R2_A67ResidentEmail ;
      private string[] P006R2_A65ResidentLastName ;
      private string[] P006R2_A68ResidentGender ;
      private string[] P006R2_A72ResidentSalutation ;
      private Guid[] P006R2_A62ResidentId ;
      private Guid[] P006R2_A29LocationId ;
      private Guid[] P006R2_A11OrganisationId ;
      private Guid[] P006R3_A96ResidentTypeId ;
      private bool[] P006R3_n96ResidentTypeId ;
      private string[] P006R3_A65ResidentLastName ;
      private string[] P006R3_A97ResidentTypeName ;
      private string[] P006R3_A70ResidentPhone ;
      private string[] P006R3_A67ResidentEmail ;
      private string[] P006R3_A64ResidentGivenName ;
      private string[] P006R3_A68ResidentGender ;
      private string[] P006R3_A72ResidentSalutation ;
      private Guid[] P006R3_A62ResidentId ;
      private Guid[] P006R3_A29LocationId ;
      private Guid[] P006R3_A11OrganisationId ;
      private Guid[] P006R4_A96ResidentTypeId ;
      private bool[] P006R4_n96ResidentTypeId ;
      private string[] P006R4_A67ResidentEmail ;
      private string[] P006R4_A97ResidentTypeName ;
      private string[] P006R4_A70ResidentPhone ;
      private string[] P006R4_A65ResidentLastName ;
      private string[] P006R4_A64ResidentGivenName ;
      private string[] P006R4_A68ResidentGender ;
      private string[] P006R4_A72ResidentSalutation ;
      private Guid[] P006R4_A62ResidentId ;
      private Guid[] P006R4_A29LocationId ;
      private Guid[] P006R4_A11OrganisationId ;
      private Guid[] P006R5_A96ResidentTypeId ;
      private bool[] P006R5_n96ResidentTypeId ;
      private string[] P006R5_A70ResidentPhone ;
      private string[] P006R5_A97ResidentTypeName ;
      private string[] P006R5_A67ResidentEmail ;
      private string[] P006R5_A65ResidentLastName ;
      private string[] P006R5_A64ResidentGivenName ;
      private string[] P006R5_A68ResidentGender ;
      private string[] P006R5_A72ResidentSalutation ;
      private Guid[] P006R5_A62ResidentId ;
      private Guid[] P006R5_A29LocationId ;
      private Guid[] P006R5_A11OrganisationId ;
      private Guid[] P006R6_A96ResidentTypeId ;
      private bool[] P006R6_n96ResidentTypeId ;
      private string[] P006R6_A97ResidentTypeName ;
      private string[] P006R6_A70ResidentPhone ;
      private string[] P006R6_A67ResidentEmail ;
      private string[] P006R6_A65ResidentLastName ;
      private string[] P006R6_A64ResidentGivenName ;
      private string[] P006R6_A68ResidentGender ;
      private string[] P006R6_A72ResidentSalutation ;
      private Guid[] P006R6_A62ResidentId ;
      private Guid[] P006R6_A29LocationId ;
      private Guid[] P006R6_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_residentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006R2( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV66Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV68Trn_residentwwds_5_tfresidentlastname ,
                                             int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV71Trn_residentwwds_8_tfresidentemail ,
                                             string AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_10_tfresidentphone ,
                                             string AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV75Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV64Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentGivenName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGender, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV66Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV67Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV68Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV69Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV70Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV75Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV76Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName IS NULL or (char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006R3( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV66Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV68Trn_residentwwds_5_tfresidentlastname ,
                                             int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV71Trn_residentwwds_8_tfresidentemail ,
                                             string AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_10_tfresidentphone ,
                                             string AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV75Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV64Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentLastName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentGivenName, T1.ResidentGender, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV66Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV67Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV68Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV69Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV70Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV75Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV76Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName IS NULL or (char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006R4( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV66Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV68Trn_residentwwds_5_tfresidentlastname ,
                                             int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV71Trn_residentwwds_8_tfresidentemail ,
                                             string AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_10_tfresidentphone ,
                                             string AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV75Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV64Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentEmail, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentGender, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV66Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV67Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV68Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV69Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV70Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV75Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV76Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName IS NULL or (char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006R5( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV66Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV68Trn_residentwwds_5_tfresidentlastname ,
                                             int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV71Trn_residentwwds_8_tfresidentemail ,
                                             string AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_10_tfresidentphone ,
                                             string AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV75Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV64Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentPhone, T2.ResidentTypeName, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentGender, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV66Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV67Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV68Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV69Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV70Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV75Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV76Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName IS NULL or (char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P006R6( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV65Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV70Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV67Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV66Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV69Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV68Trn_residentwwds_5_tfresidentlastname ,
                                             int AV70Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV72Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV71Trn_residentwwds_8_tfresidentemail ,
                                             string AV74Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_10_tfresidentphone ,
                                             string AV76Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV75Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV64Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentGender, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV65Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV65Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV66Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV67Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV68Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV69Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV70Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV71Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV72Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV75Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV76Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName IS NULL or (char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentTypeId";
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
                     return conditional_P006R2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 1 :
                     return conditional_P006R3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 2 :
                     return conditional_P006R4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 3 :
                     return conditional_P006R5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 4 :
                     return conditional_P006R6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
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
          Object[] prmP006R2;
          prmP006R2 = new Object[] {
          new ParDef("lV66Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV75Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006R3;
          prmP006R3 = new Object[] {
          new ParDef("lV66Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV75Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006R4;
          prmP006R4 = new Object[] {
          new ParDef("lV66Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV75Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006R5;
          prmP006R5 = new Object[] {
          new ParDef("lV66Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV75Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006R6;
          prmP006R6 = new Object[] {
          new ParDef("lV66Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV75Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV76Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
