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
   public class trn_receptionistwwgetfilterdata : GXProcedure
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
            return "trn_receptionistww_Services_Execute" ;
         }

      }

      public trn_receptionistwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionistwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTPHONEOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV34Session.Get("Trn_ReceptionistWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "Trn_ReceptionistWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("Trn_ReceptionistWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME") == 0 )
            {
               AV11TFReceptionistGivenName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME_SEL") == 0 )
            {
               AV12TFReceptionistGivenName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME") == 0 )
            {
               AV13TFReceptionistLastName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME_SEL") == 0 )
            {
               AV14TFReceptionistLastName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL") == 0 )
            {
               AV17TFReceptionistEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL_SEL") == 0 )
            {
               AV18TFReceptionistEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE") == 0 )
            {
               AV19TFReceptionistPhone = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE_SEL") == 0 )
            {
               AV20TFReceptionistPhone_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTISACTIVE_SEL") == 0 )
            {
               AV51TFReceptionistIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTSALUTATION_SEL") == 0 )
            {
               AV52TFReceptionistSalutation_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV53TFReceptionistSalutation_Sels.FromJSonString(AV52TFReceptionistSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGENDER_SEL") == 0 )
            {
               AV54TFReceptionistGender_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV55TFReceptionistGender_Sels.FromJSonString(AV54TFReceptionistGender_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRECEPTIONISTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFReceptionistGivenName = AV23SearchTxt;
         AV12TFReceptionistGivenName_Sel = "";
         AV58Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV59Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV61Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV63Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV64Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV65Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV66Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels = AV53TFReceptionistSalutation_Sels;
         AV69Trn_receptionistwwds_12_tfreceptionistgender_sels = AV55TFReceptionistGender_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A659ReceptionistSalutation ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                              A660ReceptionistGender ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                              AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels.Count ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels.Count ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A369ReceptionistIsActive ,
                                              AV58Trn_receptionistwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV61Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV63Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV65Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P00662 */
         pr_default.execute(0, new Object[] {lV59Trn_receptionistwwds_2_tfreceptionistgivenname, AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV61Trn_receptionistwwds_4_tfreceptionistlastname, AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV63Trn_receptionistwwds_6_tfreceptionistemail, AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, lV65Trn_receptionistwwds_8_tfreceptionistphone, AV66Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK662 = false;
            A90ReceptionistGivenName = P00662_A90ReceptionistGivenName[0];
            A369ReceptionistIsActive = P00662_A369ReceptionistIsActive[0];
            A94ReceptionistPhone = P00662_A94ReceptionistPhone[0];
            A93ReceptionistEmail = P00662_A93ReceptionistEmail[0];
            A91ReceptionistLastName = P00662_A91ReceptionistLastName[0];
            A660ReceptionistGender = P00662_A660ReceptionistGender[0];
            n660ReceptionistGender = P00662_n660ReceptionistGender[0];
            A659ReceptionistSalutation = P00662_A659ReceptionistSalutation[0];
            n659ReceptionistSalutation = P00662_n659ReceptionistSalutation[0];
            A89ReceptionistId = P00662_A89ReceptionistId[0];
            A11OrganisationId = P00662_A11OrganisationId[0];
            A29LocationId = P00662_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A90ReceptionistGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A91ReceptionistLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A93ReceptionistEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A94ReceptionistPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            String.IsNullOrEmpty(StringUtil.RTrim( A659ReceptionistSalutation)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A660ReceptionistGender)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Other", "")) == 0 ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00662_A90ReceptionistGivenName[0], A90ReceptionistGivenName) == 0 ) )
               {
                  BRK662 = false;
                  A89ReceptionistId = P00662_A89ReceptionistId[0];
                  A11OrganisationId = P00662_A11OrganisationId[0];
                  A29LocationId = P00662_A29LocationId[0];
                  AV33count = (long)(AV33count+1);
                  BRK662 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A90ReceptionistGivenName)) ? "<#Empty#>" : A90ReceptionistGivenName);
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
            }
            if ( ! BRK662 )
            {
               BRK662 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRECEPTIONISTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFReceptionistLastName = AV23SearchTxt;
         AV14TFReceptionistLastName_Sel = "";
         AV58Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV59Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV61Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV63Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV64Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV65Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV66Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels = AV53TFReceptionistSalutation_Sels;
         AV69Trn_receptionistwwds_12_tfreceptionistgender_sels = AV55TFReceptionistGender_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A659ReceptionistSalutation ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                              A660ReceptionistGender ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                              AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels.Count ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels.Count ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A369ReceptionistIsActive ,
                                              AV58Trn_receptionistwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV61Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV63Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV65Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P00663 */
         pr_default.execute(1, new Object[] {lV59Trn_receptionistwwds_2_tfreceptionistgivenname, AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV61Trn_receptionistwwds_4_tfreceptionistlastname, AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV63Trn_receptionistwwds_6_tfreceptionistemail, AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, lV65Trn_receptionistwwds_8_tfreceptionistphone, AV66Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK664 = false;
            A91ReceptionistLastName = P00663_A91ReceptionistLastName[0];
            A369ReceptionistIsActive = P00663_A369ReceptionistIsActive[0];
            A94ReceptionistPhone = P00663_A94ReceptionistPhone[0];
            A93ReceptionistEmail = P00663_A93ReceptionistEmail[0];
            A90ReceptionistGivenName = P00663_A90ReceptionistGivenName[0];
            A660ReceptionistGender = P00663_A660ReceptionistGender[0];
            n660ReceptionistGender = P00663_n660ReceptionistGender[0];
            A659ReceptionistSalutation = P00663_A659ReceptionistSalutation[0];
            n659ReceptionistSalutation = P00663_n659ReceptionistSalutation[0];
            A89ReceptionistId = P00663_A89ReceptionistId[0];
            A11OrganisationId = P00663_A11OrganisationId[0];
            A29LocationId = P00663_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A90ReceptionistGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A91ReceptionistLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A93ReceptionistEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A94ReceptionistPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            String.IsNullOrEmpty(StringUtil.RTrim( A659ReceptionistSalutation)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A660ReceptionistGender)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Other", "")) == 0 ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00663_A91ReceptionistLastName[0], A91ReceptionistLastName) == 0 ) )
               {
                  BRK664 = false;
                  A89ReceptionistId = P00663_A89ReceptionistId[0];
                  A11OrganisationId = P00663_A11OrganisationId[0];
                  A29LocationId = P00663_A29LocationId[0];
                  AV33count = (long)(AV33count+1);
                  BRK664 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A91ReceptionistLastName)) ? "<#Empty#>" : A91ReceptionistLastName);
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
            }
            if ( ! BRK664 )
            {
               BRK664 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRECEPTIONISTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFReceptionistEmail = AV23SearchTxt;
         AV18TFReceptionistEmail_Sel = "";
         AV58Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV59Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV61Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV63Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV64Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV65Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV66Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels = AV53TFReceptionistSalutation_Sels;
         AV69Trn_receptionistwwds_12_tfreceptionistgender_sels = AV55TFReceptionistGender_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A659ReceptionistSalutation ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                              A660ReceptionistGender ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                              AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels.Count ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels.Count ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A369ReceptionistIsActive ,
                                              AV58Trn_receptionistwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV61Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV63Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV65Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P00664 */
         pr_default.execute(2, new Object[] {lV59Trn_receptionistwwds_2_tfreceptionistgivenname, AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV61Trn_receptionistwwds_4_tfreceptionistlastname, AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV63Trn_receptionistwwds_6_tfreceptionistemail, AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, lV65Trn_receptionistwwds_8_tfreceptionistphone, AV66Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK666 = false;
            A93ReceptionistEmail = P00664_A93ReceptionistEmail[0];
            A369ReceptionistIsActive = P00664_A369ReceptionistIsActive[0];
            A94ReceptionistPhone = P00664_A94ReceptionistPhone[0];
            A91ReceptionistLastName = P00664_A91ReceptionistLastName[0];
            A90ReceptionistGivenName = P00664_A90ReceptionistGivenName[0];
            A660ReceptionistGender = P00664_A660ReceptionistGender[0];
            n660ReceptionistGender = P00664_n660ReceptionistGender[0];
            A659ReceptionistSalutation = P00664_A659ReceptionistSalutation[0];
            n659ReceptionistSalutation = P00664_n659ReceptionistSalutation[0];
            A89ReceptionistId = P00664_A89ReceptionistId[0];
            A11OrganisationId = P00664_A11OrganisationId[0];
            A29LocationId = P00664_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A90ReceptionistGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A91ReceptionistLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A93ReceptionistEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A94ReceptionistPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            String.IsNullOrEmpty(StringUtil.RTrim( A659ReceptionistSalutation)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A660ReceptionistGender)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Other", "")) == 0 ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00664_A93ReceptionistEmail[0], A93ReceptionistEmail) == 0 ) )
               {
                  BRK666 = false;
                  A89ReceptionistId = P00664_A89ReceptionistId[0];
                  A11OrganisationId = P00664_A11OrganisationId[0];
                  A29LocationId = P00664_A29LocationId[0];
                  AV33count = (long)(AV33count+1);
                  BRK666 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A93ReceptionistEmail)) ? "<#Empty#>" : A93ReceptionistEmail);
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
            }
            if ( ! BRK666 )
            {
               BRK666 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRECEPTIONISTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV19TFReceptionistPhone = AV23SearchTxt;
         AV20TFReceptionistPhone_Sel = "";
         AV58Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV59Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV61Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV63Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV64Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV65Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV66Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels = AV53TFReceptionistSalutation_Sels;
         AV69Trn_receptionistwwds_12_tfreceptionistgender_sels = AV55TFReceptionistGender_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A659ReceptionistSalutation ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                              A660ReceptionistGender ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                              AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels.Count ,
                                              AV69Trn_receptionistwwds_12_tfreceptionistgender_sels.Count ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A369ReceptionistIsActive ,
                                              AV58Trn_receptionistwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV61Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV63Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV65Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P00665 */
         pr_default.execute(3, new Object[] {lV59Trn_receptionistwwds_2_tfreceptionistgivenname, AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV61Trn_receptionistwwds_4_tfreceptionistlastname, AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV63Trn_receptionistwwds_6_tfreceptionistemail, AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, lV65Trn_receptionistwwds_8_tfreceptionistphone, AV66Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK668 = false;
            A94ReceptionistPhone = P00665_A94ReceptionistPhone[0];
            A369ReceptionistIsActive = P00665_A369ReceptionistIsActive[0];
            A93ReceptionistEmail = P00665_A93ReceptionistEmail[0];
            A91ReceptionistLastName = P00665_A91ReceptionistLastName[0];
            A90ReceptionistGivenName = P00665_A90ReceptionistGivenName[0];
            A660ReceptionistGender = P00665_A660ReceptionistGender[0];
            n660ReceptionistGender = P00665_n660ReceptionistGender[0];
            A659ReceptionistSalutation = P00665_A659ReceptionistSalutation[0];
            n659ReceptionistSalutation = P00665_n659ReceptionistSalutation[0];
            A89ReceptionistId = P00665_A89ReceptionistId[0];
            A11OrganisationId = P00665_A11OrganisationId[0];
            A29LocationId = P00665_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A90ReceptionistGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A91ReceptionistLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A93ReceptionistEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Lower( A94ReceptionistPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            String.IsNullOrEmpty(StringUtil.RTrim( A659ReceptionistSalutation)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A659ReceptionistSalutation, context.GetMessage( "Miss", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A660ReceptionistGender)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Trn_receptionistwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A660ReceptionistGender, context.GetMessage( "Other", "")) == 0 ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00665_A94ReceptionistPhone[0], A94ReceptionistPhone) == 0 ) )
               {
                  BRK668 = false;
                  A89ReceptionistId = P00665_A89ReceptionistId[0];
                  A11OrganisationId = P00665_A11OrganisationId[0];
                  A29LocationId = P00665_A29LocationId[0];
                  AV33count = (long)(AV33count+1);
                  BRK668 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A94ReceptionistPhone)) ? "<#Empty#>" : A94ReceptionistPhone);
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
            }
            if ( ! BRK668 )
            {
               BRK668 = true;
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
         AV11TFReceptionistGivenName = "";
         AV12TFReceptionistGivenName_Sel = "";
         AV13TFReceptionistLastName = "";
         AV14TFReceptionistLastName_Sel = "";
         AV17TFReceptionistEmail = "";
         AV18TFReceptionistEmail_Sel = "";
         AV19TFReceptionistPhone = "";
         AV20TFReceptionistPhone_Sel = "";
         AV52TFReceptionistSalutation_SelsJson = "";
         AV53TFReceptionistSalutation_Sels = new GxSimpleCollection<string>();
         AV54TFReceptionistGender_SelsJson = "";
         AV55TFReceptionistGender_Sels = new GxSimpleCollection<string>();
         AV58Trn_receptionistwwds_1_filterfulltext = "";
         AV59Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel = "";
         AV61Trn_receptionistwwds_4_tfreceptionistlastname = "";
         AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel = "";
         AV63Trn_receptionistwwds_6_tfreceptionistemail = "";
         AV64Trn_receptionistwwds_7_tfreceptionistemail_sel = "";
         AV65Trn_receptionistwwds_8_tfreceptionistphone = "";
         AV66Trn_receptionistwwds_9_tfreceptionistphone_sel = "";
         AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels = new GxSimpleCollection<string>();
         AV69Trn_receptionistwwds_12_tfreceptionistgender_sels = new GxSimpleCollection<string>();
         lV59Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         lV61Trn_receptionistwwds_4_tfreceptionistlastname = "";
         lV63Trn_receptionistwwds_6_tfreceptionistemail = "";
         lV65Trn_receptionistwwds_8_tfreceptionistphone = "";
         A659ReceptionistSalutation = "";
         A660ReceptionistGender = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A93ReceptionistEmail = "";
         A94ReceptionistPhone = "";
         P00662_A90ReceptionistGivenName = new string[] {""} ;
         P00662_A369ReceptionistIsActive = new bool[] {false} ;
         P00662_A94ReceptionistPhone = new string[] {""} ;
         P00662_A93ReceptionistEmail = new string[] {""} ;
         P00662_A91ReceptionistLastName = new string[] {""} ;
         P00662_A660ReceptionistGender = new string[] {""} ;
         P00662_n660ReceptionistGender = new bool[] {false} ;
         P00662_A659ReceptionistSalutation = new string[] {""} ;
         P00662_n659ReceptionistSalutation = new bool[] {false} ;
         P00662_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00662_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00662_A29LocationId = new Guid[] {Guid.Empty} ;
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV28Option = "";
         P00663_A91ReceptionistLastName = new string[] {""} ;
         P00663_A369ReceptionistIsActive = new bool[] {false} ;
         P00663_A94ReceptionistPhone = new string[] {""} ;
         P00663_A93ReceptionistEmail = new string[] {""} ;
         P00663_A90ReceptionistGivenName = new string[] {""} ;
         P00663_A660ReceptionistGender = new string[] {""} ;
         P00663_n660ReceptionistGender = new bool[] {false} ;
         P00663_A659ReceptionistSalutation = new string[] {""} ;
         P00663_n659ReceptionistSalutation = new bool[] {false} ;
         P00663_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00663_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00663_A29LocationId = new Guid[] {Guid.Empty} ;
         P00664_A93ReceptionistEmail = new string[] {""} ;
         P00664_A369ReceptionistIsActive = new bool[] {false} ;
         P00664_A94ReceptionistPhone = new string[] {""} ;
         P00664_A91ReceptionistLastName = new string[] {""} ;
         P00664_A90ReceptionistGivenName = new string[] {""} ;
         P00664_A660ReceptionistGender = new string[] {""} ;
         P00664_n660ReceptionistGender = new bool[] {false} ;
         P00664_A659ReceptionistSalutation = new string[] {""} ;
         P00664_n659ReceptionistSalutation = new bool[] {false} ;
         P00664_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00664_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00664_A29LocationId = new Guid[] {Guid.Empty} ;
         P00665_A94ReceptionistPhone = new string[] {""} ;
         P00665_A369ReceptionistIsActive = new bool[] {false} ;
         P00665_A93ReceptionistEmail = new string[] {""} ;
         P00665_A91ReceptionistLastName = new string[] {""} ;
         P00665_A90ReceptionistGivenName = new string[] {""} ;
         P00665_A660ReceptionistGender = new string[] {""} ;
         P00665_n660ReceptionistGender = new bool[] {false} ;
         P00665_A659ReceptionistSalutation = new string[] {""} ;
         P00665_n659ReceptionistSalutation = new bool[] {false} ;
         P00665_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00665_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00665_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00662_A90ReceptionistGivenName, P00662_A369ReceptionistIsActive, P00662_A94ReceptionistPhone, P00662_A93ReceptionistEmail, P00662_A91ReceptionistLastName, P00662_A660ReceptionistGender, P00662_n660ReceptionistGender, P00662_A659ReceptionistSalutation, P00662_n659ReceptionistSalutation, P00662_A89ReceptionistId,
               P00662_A11OrganisationId, P00662_A29LocationId
               }
               , new Object[] {
               P00663_A91ReceptionistLastName, P00663_A369ReceptionistIsActive, P00663_A94ReceptionistPhone, P00663_A93ReceptionistEmail, P00663_A90ReceptionistGivenName, P00663_A660ReceptionistGender, P00663_n660ReceptionistGender, P00663_A659ReceptionistSalutation, P00663_n659ReceptionistSalutation, P00663_A89ReceptionistId,
               P00663_A11OrganisationId, P00663_A29LocationId
               }
               , new Object[] {
               P00664_A93ReceptionistEmail, P00664_A369ReceptionistIsActive, P00664_A94ReceptionistPhone, P00664_A91ReceptionistLastName, P00664_A90ReceptionistGivenName, P00664_A660ReceptionistGender, P00664_n660ReceptionistGender, P00664_A659ReceptionistSalutation, P00664_n659ReceptionistSalutation, P00664_A89ReceptionistId,
               P00664_A11OrganisationId, P00664_A29LocationId
               }
               , new Object[] {
               P00665_A94ReceptionistPhone, P00665_A369ReceptionistIsActive, P00665_A93ReceptionistEmail, P00665_A91ReceptionistLastName, P00665_A90ReceptionistGivenName, P00665_A660ReceptionistGender, P00665_n660ReceptionistGender, P00665_A659ReceptionistSalutation, P00665_n659ReceptionistSalutation, P00665_A89ReceptionistId,
               P00665_A11OrganisationId, P00665_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV51TFReceptionistIsActive_Sel ;
      private short AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ;
      private int AV56GXV1 ;
      private int AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count ;
      private int AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count ;
      private long AV33count ;
      private string AV19TFReceptionistPhone ;
      private string AV20TFReceptionistPhone_Sel ;
      private string AV65Trn_receptionistwwds_8_tfreceptionistphone ;
      private string AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ;
      private string lV65Trn_receptionistwwds_8_tfreceptionistphone ;
      private string A659ReceptionistSalutation ;
      private string A94ReceptionistPhone ;
      private bool returnInSub ;
      private bool A369ReceptionistIsActive ;
      private bool BRK662 ;
      private bool n660ReceptionistGender ;
      private bool n659ReceptionistSalutation ;
      private bool BRK664 ;
      private bool BRK666 ;
      private bool BRK668 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV52TFReceptionistSalutation_SelsJson ;
      private string AV54TFReceptionistGender_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV11TFReceptionistGivenName ;
      private string AV12TFReceptionistGivenName_Sel ;
      private string AV13TFReceptionistLastName ;
      private string AV14TFReceptionistLastName_Sel ;
      private string AV17TFReceptionistEmail ;
      private string AV18TFReceptionistEmail_Sel ;
      private string AV58Trn_receptionistwwds_1_filterfulltext ;
      private string AV59Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ;
      private string AV61Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ;
      private string AV63Trn_receptionistwwds_6_tfreceptionistemail ;
      private string AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ;
      private string lV59Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string lV61Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string lV63Trn_receptionistwwds_6_tfreceptionistemail ;
      private string A660ReceptionistGender ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string AV28Option ;
      private Guid A89ReceptionistId ;
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
      private GxSimpleCollection<string> AV53TFReceptionistSalutation_Sels ;
      private GxSimpleCollection<string> AV55TFReceptionistGender_Sels ;
      private GxSimpleCollection<string> AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ;
      private GxSimpleCollection<string> AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00662_A90ReceptionistGivenName ;
      private bool[] P00662_A369ReceptionistIsActive ;
      private string[] P00662_A94ReceptionistPhone ;
      private string[] P00662_A93ReceptionistEmail ;
      private string[] P00662_A91ReceptionistLastName ;
      private string[] P00662_A660ReceptionistGender ;
      private bool[] P00662_n660ReceptionistGender ;
      private string[] P00662_A659ReceptionistSalutation ;
      private bool[] P00662_n659ReceptionistSalutation ;
      private Guid[] P00662_A89ReceptionistId ;
      private Guid[] P00662_A11OrganisationId ;
      private Guid[] P00662_A29LocationId ;
      private string[] P00663_A91ReceptionistLastName ;
      private bool[] P00663_A369ReceptionistIsActive ;
      private string[] P00663_A94ReceptionistPhone ;
      private string[] P00663_A93ReceptionistEmail ;
      private string[] P00663_A90ReceptionistGivenName ;
      private string[] P00663_A660ReceptionistGender ;
      private bool[] P00663_n660ReceptionistGender ;
      private string[] P00663_A659ReceptionistSalutation ;
      private bool[] P00663_n659ReceptionistSalutation ;
      private Guid[] P00663_A89ReceptionistId ;
      private Guid[] P00663_A11OrganisationId ;
      private Guid[] P00663_A29LocationId ;
      private string[] P00664_A93ReceptionistEmail ;
      private bool[] P00664_A369ReceptionistIsActive ;
      private string[] P00664_A94ReceptionistPhone ;
      private string[] P00664_A91ReceptionistLastName ;
      private string[] P00664_A90ReceptionistGivenName ;
      private string[] P00664_A660ReceptionistGender ;
      private bool[] P00664_n660ReceptionistGender ;
      private string[] P00664_A659ReceptionistSalutation ;
      private bool[] P00664_n659ReceptionistSalutation ;
      private Guid[] P00664_A89ReceptionistId ;
      private Guid[] P00664_A11OrganisationId ;
      private Guid[] P00664_A29LocationId ;
      private string[] P00665_A94ReceptionistPhone ;
      private bool[] P00665_A369ReceptionistIsActive ;
      private string[] P00665_A93ReceptionistEmail ;
      private string[] P00665_A91ReceptionistLastName ;
      private string[] P00665_A90ReceptionistGivenName ;
      private string[] P00665_A660ReceptionistGender ;
      private bool[] P00665_n660ReceptionistGender ;
      private string[] P00665_A659ReceptionistSalutation ;
      private bool[] P00665_n659ReceptionistSalutation ;
      private Guid[] P00665_A89ReceptionistId ;
      private Guid[] P00665_A11OrganisationId ;
      private Guid[] P00665_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_receptionistwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00662( IGxContext context ,
                                             string A659ReceptionistSalutation ,
                                             GxSimpleCollection<string> AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                             string A660ReceptionistGender ,
                                             GxSimpleCollection<string> AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                             string AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             int AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count ,
                                             int AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A369ReceptionistIsActive ,
                                             string AV58Trn_receptionistwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ReceptionistGivenName, ReceptionistIsActive, ReceptionistPhone, ReceptionistEmail, ReceptionistLastName, ReceptionistGender, ReceptionistSalutation, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV59Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV61Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV63Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV64Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV65Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV66Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         if ( AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels, "ReceptionistSalutation IN (", ")")+")");
         }
         if ( AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Trn_receptionistwwds_12_tfreceptionistgender_sels, "ReceptionistGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00663( IGxContext context ,
                                             string A659ReceptionistSalutation ,
                                             GxSimpleCollection<string> AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                             string A660ReceptionistGender ,
                                             GxSimpleCollection<string> AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                             string AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             int AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count ,
                                             int AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A369ReceptionistIsActive ,
                                             string AV58Trn_receptionistwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ReceptionistLastName, ReceptionistIsActive, ReceptionistPhone, ReceptionistEmail, ReceptionistGivenName, ReceptionistGender, ReceptionistSalutation, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV59Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV61Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV63Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV64Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV65Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV66Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         if ( AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels, "ReceptionistSalutation IN (", ")")+")");
         }
         if ( AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Trn_receptionistwwds_12_tfreceptionistgender_sels, "ReceptionistGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00664( IGxContext context ,
                                             string A659ReceptionistSalutation ,
                                             GxSimpleCollection<string> AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                             string A660ReceptionistGender ,
                                             GxSimpleCollection<string> AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                             string AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             int AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count ,
                                             int AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A369ReceptionistIsActive ,
                                             string AV58Trn_receptionistwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[8];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT ReceptionistEmail, ReceptionistIsActive, ReceptionistPhone, ReceptionistLastName, ReceptionistGivenName, ReceptionistGender, ReceptionistSalutation, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV59Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV61Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV63Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV64Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV65Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV66Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         if ( AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels, "ReceptionistSalutation IN (", ")")+")");
         }
         if ( AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Trn_receptionistwwds_12_tfreceptionistgender_sels, "ReceptionistGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00665( IGxContext context ,
                                             string A659ReceptionistSalutation ,
                                             GxSimpleCollection<string> AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels ,
                                             string A660ReceptionistGender ,
                                             GxSimpleCollection<string> AV69Trn_receptionistwwds_12_tfreceptionistgender_sels ,
                                             string AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV59Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV61Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV64Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV63Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV66Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV65Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             int AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count ,
                                             int AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A369ReceptionistIsActive ,
                                             string AV58Trn_receptionistwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[8];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT ReceptionistPhone, ReceptionistIsActive, ReceptionistEmail, ReceptionistLastName, ReceptionistGivenName, ReceptionistGender, ReceptionistSalutation, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV59Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV61Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV63Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV64Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV65Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV66Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV66Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV67Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         if ( AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_receptionistwwds_11_tfreceptionistsalutation_sels, "ReceptionistSalutation IN (", ")")+")");
         }
         if ( AV69Trn_receptionistwwds_12_tfreceptionistgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69Trn_receptionistwwds_12_tfreceptionistgender_sels, "ReceptionistGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistPhone";
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
                     return conditional_P00662(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
               case 1 :
                     return conditional_P00663(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
               case 2 :
                     return conditional_P00664(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
               case 3 :
                     return conditional_P00665(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP00662;
          prmP00662 = new Object[] {
          new ParDef("lV59Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV66Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP00663;
          prmP00663 = new Object[] {
          new ParDef("lV59Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV66Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP00664;
          prmP00664 = new Object[] {
          new ParDef("lV59Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV66Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP00665;
          prmP00665 = new Object[] {
          new ParDef("lV59Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV66Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00662", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00662,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00663", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00663,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00664", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00664,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00665", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00665,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
