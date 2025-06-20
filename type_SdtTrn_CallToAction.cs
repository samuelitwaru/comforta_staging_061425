using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_CallToAction" )]
   [XmlType(TypeName =  "Trn_CallToAction" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_CallToAction : GxSilentTrnSdt
   {
      public SdtTrn_CallToAction( )
      {
      }

      public SdtTrn_CallToAction( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV339CallToActionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV339CallToActionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CallToActionId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_CallToAction");
         metadata.Set("BT", "Trn_CallToAction");
         metadata.Set("PK", "[ \"CallToActionId\" ]");
         metadata.Set("PKAssigned", "[ \"CallToActionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationDynamicFormId\",\"OrganisationId\",\"LocationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProductServiceId\",\"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Calltoactionid_Z");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Calltoactionname_Z");
         state.Add("gxTpr_Calltoactiontype_Z");
         state.Add("gxTpr_Calltoactionphone_Z");
         state.Add("gxTpr_Calltoactionphonecode_Z");
         state.Add("gxTpr_Calltoactionphonenumber_Z");
         state.Add("gxTpr_Calltoactionurl_Z");
         state.Add("gxTpr_Calltoactionemail_Z");
         state.Add("gxTpr_Locationdynamicformid_Z");
         state.Add("gxTpr_Wwpformid_Z");
         state.Add("gxTpr_Wwpformversionnumber_Z");
         state.Add("gxTpr_Wwpformreferencename_Z");
         state.Add("gxTpr_Wwpformtitle_Z");
         state.Add("gxTpr_Wwpformdate_Z_Nullable");
         state.Add("gxTpr_Wwpformiswizard_Z");
         state.Add("gxTpr_Wwpformresume_Z");
         state.Add("gxTpr_Wwpforminstantiated_Z");
         state.Add("gxTpr_Wwpformlatestversionnumber_Z");
         state.Add("gxTpr_Wwpformtype_Z");
         state.Add("gxTpr_Wwpformsectionrefelements_Z");
         state.Add("gxTpr_Wwpformisfordynamicvalidations_Z");
         state.Add("gxTpr_Locationdynamicformid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_CallToAction sdt;
         sdt = (SdtTrn_CallToAction)(source);
         gxTv_SdtTrn_CallToAction_Calltoactionid = sdt.gxTv_SdtTrn_CallToAction_Calltoactionid ;
         gxTv_SdtTrn_CallToAction_Productserviceid = sdt.gxTv_SdtTrn_CallToAction_Productserviceid ;
         gxTv_SdtTrn_CallToAction_Organisationid = sdt.gxTv_SdtTrn_CallToAction_Organisationid ;
         gxTv_SdtTrn_CallToAction_Locationid = sdt.gxTv_SdtTrn_CallToAction_Locationid ;
         gxTv_SdtTrn_CallToAction_Calltoactionname = sdt.gxTv_SdtTrn_CallToAction_Calltoactionname ;
         gxTv_SdtTrn_CallToAction_Calltoactiontype = sdt.gxTv_SdtTrn_CallToAction_Calltoactiontype ;
         gxTv_SdtTrn_CallToAction_Calltoactionphone = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphone ;
         gxTv_SdtTrn_CallToAction_Calltoactionphonecode = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonecode ;
         gxTv_SdtTrn_CallToAction_Calltoactionphonenumber = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonenumber ;
         gxTv_SdtTrn_CallToAction_Calltoactionurl = sdt.gxTv_SdtTrn_CallToAction_Calltoactionurl ;
         gxTv_SdtTrn_CallToAction_Calltoactionemail = sdt.gxTv_SdtTrn_CallToAction_Calltoactionemail ;
         gxTv_SdtTrn_CallToAction_Locationdynamicformid = sdt.gxTv_SdtTrn_CallToAction_Locationdynamicformid ;
         gxTv_SdtTrn_CallToAction_Wwpformid = sdt.gxTv_SdtTrn_CallToAction_Wwpformid ;
         gxTv_SdtTrn_CallToAction_Wwpformversionnumber = sdt.gxTv_SdtTrn_CallToAction_Wwpformversionnumber ;
         gxTv_SdtTrn_CallToAction_Wwpformreferencename = sdt.gxTv_SdtTrn_CallToAction_Wwpformreferencename ;
         gxTv_SdtTrn_CallToAction_Wwpformtitle = sdt.gxTv_SdtTrn_CallToAction_Wwpformtitle ;
         gxTv_SdtTrn_CallToAction_Wwpformdate = sdt.gxTv_SdtTrn_CallToAction_Wwpformdate ;
         gxTv_SdtTrn_CallToAction_Wwpformiswizard = sdt.gxTv_SdtTrn_CallToAction_Wwpformiswizard ;
         gxTv_SdtTrn_CallToAction_Wwpformresume = sdt.gxTv_SdtTrn_CallToAction_Wwpformresume ;
         gxTv_SdtTrn_CallToAction_Wwpformresumemessage = sdt.gxTv_SdtTrn_CallToAction_Wwpformresumemessage ;
         gxTv_SdtTrn_CallToAction_Wwpformvalidations = sdt.gxTv_SdtTrn_CallToAction_Wwpformvalidations ;
         gxTv_SdtTrn_CallToAction_Wwpforminstantiated = sdt.gxTv_SdtTrn_CallToAction_Wwpforminstantiated ;
         gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber ;
         gxTv_SdtTrn_CallToAction_Wwpformtype = sdt.gxTv_SdtTrn_CallToAction_Wwpformtype ;
         gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements ;
         gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations ;
         gxTv_SdtTrn_CallToAction_Mode = sdt.gxTv_SdtTrn_CallToAction_Mode ;
         gxTv_SdtTrn_CallToAction_Initialized = sdt.gxTv_SdtTrn_CallToAction_Initialized ;
         gxTv_SdtTrn_CallToAction_Calltoactionid_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionid_Z ;
         gxTv_SdtTrn_CallToAction_Productserviceid_Z = sdt.gxTv_SdtTrn_CallToAction_Productserviceid_Z ;
         gxTv_SdtTrn_CallToAction_Organisationid_Z = sdt.gxTv_SdtTrn_CallToAction_Organisationid_Z ;
         gxTv_SdtTrn_CallToAction_Locationid_Z = sdt.gxTv_SdtTrn_CallToAction_Locationid_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionname_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionname_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactiontype_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactiontype_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionphone_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphone_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionurl_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionurl_Z ;
         gxTv_SdtTrn_CallToAction_Calltoactionemail_Z = sdt.gxTv_SdtTrn_CallToAction_Calltoactionemail_Z ;
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z = sdt.gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformid_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformid_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformtitle_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformtitle_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformdate_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformdate_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformresume_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformresume_Z ;
         gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformtype_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformtype_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z ;
         gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z = sdt.gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z ;
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = sdt.gxTv_SdtTrn_CallToAction_Locationdynamicformid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("CallToActionId", gxTv_SdtTrn_CallToAction_Calltoactionid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId", gxTv_SdtTrn_CallToAction_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_CallToAction_Organisationid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_CallToAction_Locationid, false, includeNonInitialized);
         AddObjectProperty("CallToActionName", gxTv_SdtTrn_CallToAction_Calltoactionname, false, includeNonInitialized);
         AddObjectProperty("CallToActionType", gxTv_SdtTrn_CallToAction_Calltoactiontype, false, includeNonInitialized);
         AddObjectProperty("CallToActionPhone", gxTv_SdtTrn_CallToAction_Calltoactionphone, false, includeNonInitialized);
         AddObjectProperty("CallToActionPhoneCode", gxTv_SdtTrn_CallToAction_Calltoactionphonecode, false, includeNonInitialized);
         AddObjectProperty("CallToActionPhoneNumber", gxTv_SdtTrn_CallToAction_Calltoactionphonenumber, false, includeNonInitialized);
         AddObjectProperty("CallToActionUrl", gxTv_SdtTrn_CallToAction_Calltoactionurl, false, includeNonInitialized);
         AddObjectProperty("CallToActionEmail", gxTv_SdtTrn_CallToAction_Calltoactionemail, false, includeNonInitialized);
         AddObjectProperty("LocationDynamicFormId", gxTv_SdtTrn_CallToAction_Locationdynamicformid, false, includeNonInitialized);
         AddObjectProperty("LocationDynamicFormId_N", gxTv_SdtTrn_CallToAction_Locationdynamicformid_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormId", gxTv_SdtTrn_CallToAction_Wwpformid, false, includeNonInitialized);
         AddObjectProperty("WWPFormVersionNumber", gxTv_SdtTrn_CallToAction_Wwpformversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormReferenceName", gxTv_SdtTrn_CallToAction_Wwpformreferencename, false, includeNonInitialized);
         AddObjectProperty("WWPFormTitle", gxTv_SdtTrn_CallToAction_Wwpformtitle, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_CallToAction_Wwpformdate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPFormDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsWizard", gxTv_SdtTrn_CallToAction_Wwpformiswizard, false, includeNonInitialized);
         AddObjectProperty("WWPFormResume", gxTv_SdtTrn_CallToAction_Wwpformresume, false, includeNonInitialized);
         AddObjectProperty("WWPFormResumeMessage", gxTv_SdtTrn_CallToAction_Wwpformresumemessage, false, includeNonInitialized);
         AddObjectProperty("WWPFormValidations", gxTv_SdtTrn_CallToAction_Wwpformvalidations, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstantiated", gxTv_SdtTrn_CallToAction_Wwpforminstantiated, false, includeNonInitialized);
         AddObjectProperty("WWPFormLatestVersionNumber", gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormType", gxTv_SdtTrn_CallToAction_Wwpformtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormSectionRefElements", gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsForDynamicValidations", gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_CallToAction_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_CallToAction_Initialized, false, includeNonInitialized);
            AddObjectProperty("CallToActionId_Z", gxTv_SdtTrn_CallToAction_Calltoactionid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtTrn_CallToAction_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_CallToAction_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_CallToAction_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionName_Z", gxTv_SdtTrn_CallToAction_Calltoactionname_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionType_Z", gxTv_SdtTrn_CallToAction_Calltoactiontype_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionPhone_Z", gxTv_SdtTrn_CallToAction_Calltoactionphone_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionPhoneCode_Z", gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionPhoneNumber_Z", gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionUrl_Z", gxTv_SdtTrn_CallToAction_Calltoactionurl_Z, false, includeNonInitialized);
            AddObjectProperty("CallToActionEmail_Z", gxTv_SdtTrn_CallToAction_Calltoactionemail_Z, false, includeNonInitialized);
            AddObjectProperty("LocationDynamicFormId_Z", gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormId_Z", gxTv_SdtTrn_CallToAction_Wwpformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormVersionNumber_Z", gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormReferenceName_Z", gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormTitle_Z", gxTv_SdtTrn_CallToAction_Wwpformtitle_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_CallToAction_Wwpformdate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPFormDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsWizard_Z", gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormResume_Z", gxTv_SdtTrn_CallToAction_Wwpformresume_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstantiated_Z", gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormLatestVersionNumber_Z", gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormType_Z", gxTv_SdtTrn_CallToAction_Wwpformtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormSectionRefElements_Z", gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsForDynamicValidations_Z", gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z, false, includeNonInitialized);
            AddObjectProperty("LocationDynamicFormId_N", gxTv_SdtTrn_CallToAction_Locationdynamicformid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_CallToAction sdt )
      {
         if ( sdt.IsDirty("CallToActionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionid = sdt.gxTv_SdtTrn_CallToAction_Calltoactionid ;
         }
         if ( sdt.IsDirty("ProductServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Productserviceid = sdt.gxTv_SdtTrn_CallToAction_Productserviceid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Organisationid = sdt.gxTv_SdtTrn_CallToAction_Organisationid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationid = sdt.gxTv_SdtTrn_CallToAction_Locationid ;
         }
         if ( sdt.IsDirty("CallToActionName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionname = sdt.gxTv_SdtTrn_CallToAction_Calltoactionname ;
         }
         if ( sdt.IsDirty("CallToActionType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactiontype = sdt.gxTv_SdtTrn_CallToAction_Calltoactiontype ;
         }
         if ( sdt.IsDirty("CallToActionPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphone = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphone ;
         }
         if ( sdt.IsDirty("CallToActionPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonecode = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonecode ;
         }
         if ( sdt.IsDirty("CallToActionPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonenumber = sdt.gxTv_SdtTrn_CallToAction_Calltoactionphonenumber ;
         }
         if ( sdt.IsDirty("CallToActionUrl") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionurl = sdt.gxTv_SdtTrn_CallToAction_Calltoactionurl ;
         }
         if ( sdt.IsDirty("CallToActionEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionemail = sdt.gxTv_SdtTrn_CallToAction_Calltoactionemail ;
         }
         if ( sdt.IsDirty("LocationDynamicFormId") )
         {
            gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = (short)(sdt.gxTv_SdtTrn_CallToAction_Locationdynamicformid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationdynamicformid = sdt.gxTv_SdtTrn_CallToAction_Locationdynamicformid ;
         }
         if ( sdt.IsDirty("WWPFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformid = sdt.gxTv_SdtTrn_CallToAction_Wwpformid ;
         }
         if ( sdt.IsDirty("WWPFormVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformversionnumber = sdt.gxTv_SdtTrn_CallToAction_Wwpformversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormReferenceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformreferencename = sdt.gxTv_SdtTrn_CallToAction_Wwpformreferencename ;
         }
         if ( sdt.IsDirty("WWPFormTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtitle = sdt.gxTv_SdtTrn_CallToAction_Wwpformtitle ;
         }
         if ( sdt.IsDirty("WWPFormDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformdate = sdt.gxTv_SdtTrn_CallToAction_Wwpformdate ;
         }
         if ( sdt.IsDirty("WWPFormIsWizard") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformiswizard = sdt.gxTv_SdtTrn_CallToAction_Wwpformiswizard ;
         }
         if ( sdt.IsDirty("WWPFormResume") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformresume = sdt.gxTv_SdtTrn_CallToAction_Wwpformresume ;
         }
         if ( sdt.IsDirty("WWPFormResumeMessage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformresumemessage = sdt.gxTv_SdtTrn_CallToAction_Wwpformresumemessage ;
         }
         if ( sdt.IsDirty("WWPFormValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformvalidations = sdt.gxTv_SdtTrn_CallToAction_Wwpformvalidations ;
         }
         if ( sdt.IsDirty("WWPFormInstantiated") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpforminstantiated = sdt.gxTv_SdtTrn_CallToAction_Wwpforminstantiated ;
         }
         if ( sdt.IsDirty("WWPFormLatestVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtype = sdt.gxTv_SdtTrn_CallToAction_Wwpformtype ;
         }
         if ( sdt.IsDirty("WWPFormSectionRefElements") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements ;
         }
         if ( sdt.IsDirty("WWPFormIsForDynamicValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CallToActionId" )]
      [  XmlElement( ElementName = "CallToActionId"   )]
      public Guid gxTpr_Calltoactionid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_CallToAction_Calltoactionid != value )
            {
               gxTv_SdtTrn_CallToAction_Mode = "INS";
               this.gxTv_SdtTrn_CallToAction_Calltoactionid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionname_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactiontype_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionphone_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionurl_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Calltoactionemail_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_CallToAction_Calltoactionid = value;
            SetDirty("Calltoactionid");
         }

      }

      [  SoapElement( ElementName = "ProductServiceId" )]
      [  XmlElement( ElementName = "ProductServiceId"   )]
      public Guid gxTpr_Productserviceid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Productserviceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Productserviceid = value;
            SetDirty("Productserviceid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "CallToActionName" )]
      [  XmlElement( ElementName = "CallToActionName"   )]
      public string gxTpr_Calltoactionname
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionname = value;
            SetDirty("Calltoactionname");
         }

      }

      [  SoapElement( ElementName = "CallToActionType" )]
      [  XmlElement( ElementName = "CallToActionType"   )]
      public string gxTpr_Calltoactiontype
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactiontype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactiontype = value;
            SetDirty("Calltoactiontype");
         }

      }

      [  SoapElement( ElementName = "CallToActionPhone" )]
      [  XmlElement( ElementName = "CallToActionPhone"   )]
      public string gxTpr_Calltoactionphone
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphone = value;
            SetDirty("Calltoactionphone");
         }

      }

      [  SoapElement( ElementName = "CallToActionPhoneCode" )]
      [  XmlElement( ElementName = "CallToActionPhoneCode"   )]
      public string gxTpr_Calltoactionphonecode
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonecode = value;
            SetDirty("Calltoactionphonecode");
         }

      }

      [  SoapElement( ElementName = "CallToActionPhoneNumber" )]
      [  XmlElement( ElementName = "CallToActionPhoneNumber"   )]
      public string gxTpr_Calltoactionphonenumber
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonenumber = value;
            SetDirty("Calltoactionphonenumber");
         }

      }

      [  SoapElement( ElementName = "CallToActionUrl" )]
      [  XmlElement( ElementName = "CallToActionUrl"   )]
      public string gxTpr_Calltoactionurl
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionurl ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionurl = value;
            SetDirty("Calltoactionurl");
         }

      }

      [  SoapElement( ElementName = "CallToActionEmail" )]
      [  XmlElement( ElementName = "CallToActionEmail"   )]
      public string gxTpr_Calltoactionemail
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionemail = value;
            SetDirty("Calltoactionemail");
         }

      }

      [  SoapElement( ElementName = "LocationDynamicFormId" )]
      [  XmlElement( ElementName = "LocationDynamicFormId"   )]
      public Guid gxTpr_Locationdynamicformid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Locationdynamicformid ;
         }

         set {
            gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationdynamicformid = value;
            SetDirty("Locationdynamicformid");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Locationdynamicformid_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = 1;
         gxTv_SdtTrn_CallToAction_Locationdynamicformid = Guid.Empty;
         SetDirty("Locationdynamicformid");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Locationdynamicformid_IsNull( )
      {
         return (gxTv_SdtTrn_CallToAction_Locationdynamicformid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormId" )]
      [  XmlElement( ElementName = "WWPFormId"   )]
      public short gxTpr_Wwpformid
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformid = value;
            SetDirty("Wwpformid");
         }

      }

      [  SoapElement( ElementName = "WWPFormVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber"   )]
      public short gxTpr_Wwpformversionnumber
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformversionnumber = value;
            SetDirty("Wwpformversionnumber");
         }

      }

      [  SoapElement( ElementName = "WWPFormReferenceName" )]
      [  XmlElement( ElementName = "WWPFormReferenceName"   )]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformreferencename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformreferencename = value;
            SetDirty("Wwpformreferencename");
         }

      }

      [  SoapElement( ElementName = "WWPFormTitle" )]
      [  XmlElement( ElementName = "WWPFormTitle"   )]
      public string gxTpr_Wwpformtitle
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtitle = value;
            SetDirty("Wwpformtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormDate" )]
      [  XmlElement( ElementName = "WWPFormDate"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_CallToAction_Wwpformdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_CallToAction_Wwpformdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_CallToAction_Wwpformdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_CallToAction_Wwpformdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformdate = value;
            SetDirty("Wwpformdate");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsWizard" )]
      [  XmlElement( ElementName = "WWPFormIsWizard"   )]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformiswizard ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformiswizard = value;
            SetDirty("Wwpformiswizard");
         }

      }

      [  SoapElement( ElementName = "WWPFormResume" )]
      [  XmlElement( ElementName = "WWPFormResume"   )]
      public short gxTpr_Wwpformresume
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformresume ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformresume = value;
            SetDirty("Wwpformresume");
         }

      }

      [  SoapElement( ElementName = "WWPFormResumeMessage" )]
      [  XmlElement( ElementName = "WWPFormResumeMessage"   )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformresumemessage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformresumemessage = value;
            SetDirty("Wwpformresumemessage");
         }

      }

      [  SoapElement( ElementName = "WWPFormValidations" )]
      [  XmlElement( ElementName = "WWPFormValidations"   )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformvalidations = value;
            SetDirty("Wwpformvalidations");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstantiated" )]
      [  XmlElement( ElementName = "WWPFormInstantiated"   )]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpforminstantiated ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpforminstantiated = value;
            SetDirty("Wwpforminstantiated");
         }

      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber"   )]
      public short gxTpr_Wwpformlatestversionnumber
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber = value;
            SetDirty("Wwpformlatestversionnumber");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber = 0;
         SetDirty("Wwpformlatestversionnumber");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType" )]
      [  XmlElement( ElementName = "WWPFormType"   )]
      public short gxTpr_Wwpformtype
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtype = value;
            SetDirty("Wwpformtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements"   )]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements = value;
            SetDirty("Wwpformsectionrefelements");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations = value;
            SetDirty("Wwpformisfordynamicvalidations");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_CallToAction_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Mode_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_CallToAction_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Initialized_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionId_Z" )]
      [  XmlElement( ElementName = "CallToActionId_Z"   )]
      public Guid gxTpr_Calltoactionid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionid_Z = value;
            SetDirty("Calltoactionid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionid_Z = Guid.Empty;
         SetDirty("Calltoactionid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_Z" )]
      [  XmlElement( ElementName = "ProductServiceId_Z"   )]
      public Guid gxTpr_Productserviceid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Productserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Productserviceid_Z = value;
            SetDirty("Productserviceid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Productserviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Productserviceid_Z = Guid.Empty;
         SetDirty("Productserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Productserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionName_Z" )]
      [  XmlElement( ElementName = "CallToActionName_Z"   )]
      public string gxTpr_Calltoactionname_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionname_Z = value;
            SetDirty("Calltoactionname_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionname_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionname_Z = "";
         SetDirty("Calltoactionname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionType_Z" )]
      [  XmlElement( ElementName = "CallToActionType_Z"   )]
      public string gxTpr_Calltoactiontype_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactiontype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactiontype_Z = value;
            SetDirty("Calltoactiontype_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactiontype_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactiontype_Z = "";
         SetDirty("Calltoactiontype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactiontype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionPhone_Z" )]
      [  XmlElement( ElementName = "CallToActionPhone_Z"   )]
      public string gxTpr_Calltoactionphone_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphone_Z = value;
            SetDirty("Calltoactionphone_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionphone_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionphone_Z = "";
         SetDirty("Calltoactionphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionPhoneCode_Z" )]
      [  XmlElement( ElementName = "CallToActionPhoneCode_Z"   )]
      public string gxTpr_Calltoactionphonecode_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z = value;
            SetDirty("Calltoactionphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z = "";
         SetDirty("Calltoactionphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionPhoneNumber_Z" )]
      [  XmlElement( ElementName = "CallToActionPhoneNumber_Z"   )]
      public string gxTpr_Calltoactionphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z = value;
            SetDirty("Calltoactionphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z = "";
         SetDirty("Calltoactionphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionUrl_Z" )]
      [  XmlElement( ElementName = "CallToActionUrl_Z"   )]
      public string gxTpr_Calltoactionurl_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionurl_Z = value;
            SetDirty("Calltoactionurl_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionurl_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionurl_Z = "";
         SetDirty("Calltoactionurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CallToActionEmail_Z" )]
      [  XmlElement( ElementName = "CallToActionEmail_Z"   )]
      public string gxTpr_Calltoactionemail_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Calltoactionemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Calltoactionemail_Z = value;
            SetDirty("Calltoactionemail_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Calltoactionemail_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionemail_Z = "";
         SetDirty("Calltoactionemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Calltoactionemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationDynamicFormId_Z" )]
      [  XmlElement( ElementName = "LocationDynamicFormId_Z"   )]
      public Guid gxTpr_Locationdynamicformid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z = value;
            SetDirty("Locationdynamicformid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z = Guid.Empty;
         SetDirty("Locationdynamicformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormId_Z" )]
      [  XmlElement( ElementName = "WWPFormId_Z"   )]
      public short gxTpr_Wwpformid_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformid_Z = value;
            SetDirty("Wwpformid_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformid_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformid_Z = 0;
         SetDirty("Wwpformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber_Z"   )]
      public short gxTpr_Wwpformversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z = value;
            SetDirty("Wwpformversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z = 0;
         SetDirty("Wwpformversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormReferenceName_Z" )]
      [  XmlElement( ElementName = "WWPFormReferenceName_Z"   )]
      public string gxTpr_Wwpformreferencename_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z = value;
            SetDirty("Wwpformreferencename_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z = "";
         SetDirty("Wwpformreferencename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormTitle_Z" )]
      [  XmlElement( ElementName = "WWPFormTitle_Z"   )]
      public string gxTpr_Wwpformtitle_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtitle_Z = value;
            SetDirty("Wwpformtitle_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformtitle_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformtitle_Z = "";
         SetDirty("Wwpformtitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormDate_Z" )]
      [  XmlElement( ElementName = "WWPFormDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_CallToAction_Wwpformdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_CallToAction_Wwpformdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_CallToAction_Wwpformdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_CallToAction_Wwpformdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformdate_Z = value;
            SetDirty("Wwpformdate_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformdate_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpformdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsWizard_Z" )]
      [  XmlElement( ElementName = "WWPFormIsWizard_Z"   )]
      public bool gxTpr_Wwpformiswizard_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z = value;
            SetDirty("Wwpformiswizard_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z = false;
         SetDirty("Wwpformiswizard_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormResume_Z" )]
      [  XmlElement( ElementName = "WWPFormResume_Z"   )]
      public short gxTpr_Wwpformresume_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformresume_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformresume_Z = value;
            SetDirty("Wwpformresume_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformresume_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformresume_Z = 0;
         SetDirty("Wwpformresume_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformresume_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstantiated_Z" )]
      [  XmlElement( ElementName = "WWPFormInstantiated_Z"   )]
      public bool gxTpr_Wwpforminstantiated_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z = value;
            SetDirty("Wwpforminstantiated_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z = false;
         SetDirty("Wwpforminstantiated_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber_Z"   )]
      public short gxTpr_Wwpformlatestversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z = value;
            SetDirty("Wwpformlatestversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z = 0;
         SetDirty("Wwpformlatestversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType_Z" )]
      [  XmlElement( ElementName = "WWPFormType_Z"   )]
      public short gxTpr_Wwpformtype_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformtype_Z = value;
            SetDirty("Wwpformtype_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformtype_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformtype_Z = 0;
         SetDirty("Wwpformtype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements_Z" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements_Z"   )]
      public string gxTpr_Wwpformsectionrefelements_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z = value;
            SetDirty("Wwpformsectionrefelements_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z = "";
         SetDirty("Wwpformsectionrefelements_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations_Z" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations_Z"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations_Z
      {
         get {
            return gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z = value;
            SetDirty("Wwpformisfordynamicvalidations_Z");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z = false;
         SetDirty("Wwpformisfordynamicvalidations_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationDynamicFormId_N" )]
      [  XmlElement( ElementName = "LocationDynamicFormId_N"   )]
      public short gxTpr_Locationdynamicformid_N
      {
         get {
            return gxTv_SdtTrn_CallToAction_Locationdynamicformid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = value;
            SetDirty("Locationdynamicformid_N");
         }

      }

      public void gxTv_SdtTrn_CallToAction_Locationdynamicformid_N_SetNull( )
      {
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_N = 0;
         SetDirty("Locationdynamicformid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_CallToAction_Locationdynamicformid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtTrn_CallToAction_Calltoactionid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_CallToAction_Productserviceid = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Organisationid = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Locationid = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Calltoactionname = "";
         gxTv_SdtTrn_CallToAction_Calltoactiontype = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphone = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphonecode = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphonenumber = "";
         gxTv_SdtTrn_CallToAction_Calltoactionurl = "";
         gxTv_SdtTrn_CallToAction_Calltoactionemail = "";
         gxTv_SdtTrn_CallToAction_Locationdynamicformid = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Wwpformreferencename = "";
         gxTv_SdtTrn_CallToAction_Wwpformtitle = "";
         gxTv_SdtTrn_CallToAction_Wwpformdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_CallToAction_Wwpformresumemessage = "";
         gxTv_SdtTrn_CallToAction_Wwpformvalidations = "";
         gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements = "";
         gxTv_SdtTrn_CallToAction_Mode = "";
         gxTv_SdtTrn_CallToAction_Calltoactionid_Z = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Productserviceid_Z = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Calltoactionname_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactiontype_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphone_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactionurl_Z = "";
         gxTv_SdtTrn_CallToAction_Calltoactionemail_Z = "";
         gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z = Guid.Empty;
         gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z = "";
         gxTv_SdtTrn_CallToAction_Wwpformtitle_Z = "";
         gxTv_SdtTrn_CallToAction_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_calltoaction", "GeneXus.Programs.trn_calltoaction_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_CallToAction_Wwpformid ;
      private short gxTv_SdtTrn_CallToAction_Wwpformversionnumber ;
      private short gxTv_SdtTrn_CallToAction_Wwpformresume ;
      private short gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber ;
      private short gxTv_SdtTrn_CallToAction_Wwpformtype ;
      private short gxTv_SdtTrn_CallToAction_Initialized ;
      private short gxTv_SdtTrn_CallToAction_Wwpformid_Z ;
      private short gxTv_SdtTrn_CallToAction_Wwpformversionnumber_Z ;
      private short gxTv_SdtTrn_CallToAction_Wwpformresume_Z ;
      private short gxTv_SdtTrn_CallToAction_Wwpformlatestversionnumber_Z ;
      private short gxTv_SdtTrn_CallToAction_Wwpformtype_Z ;
      private short gxTv_SdtTrn_CallToAction_Locationdynamicformid_N ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphone ;
      private string gxTv_SdtTrn_CallToAction_Mode ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_CallToAction_Wwpformdate ;
      private DateTime gxTv_SdtTrn_CallToAction_Wwpformdate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_CallToAction_Wwpformiswizard ;
      private bool gxTv_SdtTrn_CallToAction_Wwpforminstantiated ;
      private bool gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations ;
      private bool gxTv_SdtTrn_CallToAction_Wwpformiswizard_Z ;
      private bool gxTv_SdtTrn_CallToAction_Wwpforminstantiated_Z ;
      private bool gxTv_SdtTrn_CallToAction_Wwpformisfordynamicvalidations_Z ;
      private string gxTv_SdtTrn_CallToAction_Wwpformresumemessage ;
      private string gxTv_SdtTrn_CallToAction_Wwpformvalidations ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionname ;
      private string gxTv_SdtTrn_CallToAction_Calltoactiontype ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphonecode ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphonenumber ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionurl ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionemail ;
      private string gxTv_SdtTrn_CallToAction_Wwpformreferencename ;
      private string gxTv_SdtTrn_CallToAction_Wwpformtitle ;
      private string gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionname_Z ;
      private string gxTv_SdtTrn_CallToAction_Calltoactiontype_Z ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphonecode_Z ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionphonenumber_Z ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionurl_Z ;
      private string gxTv_SdtTrn_CallToAction_Calltoactionemail_Z ;
      private string gxTv_SdtTrn_CallToAction_Wwpformreferencename_Z ;
      private string gxTv_SdtTrn_CallToAction_Wwpformtitle_Z ;
      private string gxTv_SdtTrn_CallToAction_Wwpformsectionrefelements_Z ;
      private Guid gxTv_SdtTrn_CallToAction_Calltoactionid ;
      private Guid gxTv_SdtTrn_CallToAction_Productserviceid ;
      private Guid gxTv_SdtTrn_CallToAction_Organisationid ;
      private Guid gxTv_SdtTrn_CallToAction_Locationid ;
      private Guid gxTv_SdtTrn_CallToAction_Locationdynamicformid ;
      private Guid gxTv_SdtTrn_CallToAction_Calltoactionid_Z ;
      private Guid gxTv_SdtTrn_CallToAction_Productserviceid_Z ;
      private Guid gxTv_SdtTrn_CallToAction_Organisationid_Z ;
      private Guid gxTv_SdtTrn_CallToAction_Locationid_Z ;
      private Guid gxTv_SdtTrn_CallToAction_Locationdynamicformid_Z ;
   }

   [DataContract(Name = @"Trn_CallToAction", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_CallToAction_RESTInterface : GxGenericCollectionItem<SdtTrn_CallToAction>
   {
      public SdtTrn_CallToAction_RESTInterface( ) : base()
      {
      }

      public SdtTrn_CallToAction_RESTInterface( SdtTrn_CallToAction psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CallToActionId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Calltoactionid
      {
         get {
            return sdt.gxTpr_Calltoactionid ;
         }

         set {
            sdt.gxTpr_Calltoactionid = value;
         }

      }

      [DataMember( Name = "ProductServiceId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Productserviceid
      {
         get {
            return sdt.gxTpr_Productserviceid ;
         }

         set {
            sdt.gxTpr_Productserviceid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 3 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "CallToActionName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionname
      {
         get {
            return sdt.gxTpr_Calltoactionname ;
         }

         set {
            sdt.gxTpr_Calltoactionname = value;
         }

      }

      [DataMember( Name = "CallToActionType" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Calltoactiontype
      {
         get {
            return sdt.gxTpr_Calltoactiontype ;
         }

         set {
            sdt.gxTpr_Calltoactiontype = value;
         }

      }

      [DataMember( Name = "CallToActionPhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Calltoactionphone) ;
         }

         set {
            sdt.gxTpr_Calltoactionphone = value;
         }

      }

      [DataMember( Name = "CallToActionPhoneCode" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionphonecode
      {
         get {
            return sdt.gxTpr_Calltoactionphonecode ;
         }

         set {
            sdt.gxTpr_Calltoactionphonecode = value;
         }

      }

      [DataMember( Name = "CallToActionPhoneNumber" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionphonenumber
      {
         get {
            return sdt.gxTpr_Calltoactionphonenumber ;
         }

         set {
            sdt.gxTpr_Calltoactionphonenumber = value;
         }

      }

      [DataMember( Name = "CallToActionUrl" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionurl
      {
         get {
            return sdt.gxTpr_Calltoactionurl ;
         }

         set {
            sdt.gxTpr_Calltoactionurl = value;
         }

      }

      [DataMember( Name = "CallToActionEmail" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Calltoactionemail
      {
         get {
            return sdt.gxTpr_Calltoactionemail ;
         }

         set {
            sdt.gxTpr_Calltoactionemail = value;
         }

      }

      [DataMember( Name = "LocationDynamicFormId" , Order = 11 )]
      [GxSeudo()]
      public Guid gxTpr_Locationdynamicformid
      {
         get {
            return sdt.gxTpr_Locationdynamicformid ;
         }

         set {
            sdt.gxTpr_Locationdynamicformid = value;
         }

      }

      [DataMember( Name = "WWPFormId" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformid
      {
         get {
            return sdt.gxTpr_Wwpformid ;
         }

         set {
            sdt.gxTpr_Wwpformid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormVersionNumber" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormReferenceName" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return sdt.gxTpr_Wwpformreferencename ;
         }

         set {
            sdt.gxTpr_Wwpformreferencename = value;
         }

      }

      [DataMember( Name = "WWPFormTitle" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Wwpformtitle
      {
         get {
            return sdt.gxTpr_Wwpformtitle ;
         }

         set {
            sdt.gxTpr_Wwpformtitle = value;
         }

      }

      [DataMember( Name = "WWPFormDate" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Wwpformdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpformdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpformdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPFormIsWizard" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return sdt.gxTpr_Wwpformiswizard ;
         }

         set {
            sdt.gxTpr_Wwpformiswizard = value;
         }

      }

      [DataMember( Name = "WWPFormResume" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformresume
      {
         get {
            return sdt.gxTpr_Wwpformresume ;
         }

         set {
            sdt.gxTpr_Wwpformresume = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormResumeMessage" , Order = 19 )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return sdt.gxTpr_Wwpformresumemessage ;
         }

         set {
            sdt.gxTpr_Wwpformresumemessage = value;
         }

      }

      [DataMember( Name = "WWPFormValidations" , Order = 20 )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return sdt.gxTpr_Wwpformvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformvalidations = value;
         }

      }

      [DataMember( Name = "WWPFormInstantiated" , Order = 21 )]
      [GxSeudo()]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return sdt.gxTpr_Wwpforminstantiated ;
         }

         set {
            sdt.gxTpr_Wwpforminstantiated = value;
         }

      }

      [DataMember( Name = "WWPFormLatestVersionNumber" , Order = 22 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformlatestversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformlatestversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformlatestversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormType" , Order = 23 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformtype
      {
         get {
            return sdt.gxTpr_Wwpformtype ;
         }

         set {
            sdt.gxTpr_Wwpformtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormSectionRefElements" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return sdt.gxTpr_Wwpformsectionrefelements ;
         }

         set {
            sdt.gxTpr_Wwpformsectionrefelements = value;
         }

      }

      [DataMember( Name = "WWPFormIsForDynamicValidations" , Order = 25 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return sdt.gxTpr_Wwpformisfordynamicvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformisfordynamicvalidations = value;
         }

      }

      public SdtTrn_CallToAction sdt
      {
         get {
            return (SdtTrn_CallToAction)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_CallToAction() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 26 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Trn_CallToAction", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_CallToAction_RESTLInterface : GxGenericCollectionItem<SdtTrn_CallToAction>
   {
      public SdtTrn_CallToAction_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_CallToAction_RESTLInterface( SdtTrn_CallToAction psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_CallToAction sdt
      {
         get {
            return (SdtTrn_CallToAction)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_CallToAction() ;
         }
      }

   }

}
