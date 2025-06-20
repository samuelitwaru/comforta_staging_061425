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
   [XmlRoot(ElementName = "Trn_AgendaEventGroup" )]
   [XmlType(TypeName =  "Trn_AgendaEventGroup" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_AgendaEventGroup : GxSilentTrnSdt
   {
      public SdtTrn_AgendaEventGroup( )
      {
      }

      public SdtTrn_AgendaEventGroup( IGxContext context )
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

      public void Load( Guid AV268AgendaCalendarId ,
                        Guid AV62ResidentId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV268AgendaCalendarId,(Guid)AV62ResidentId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AgendaCalendarId", typeof(Guid)}, new Object[]{"ResidentId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_AgendaEventGroup");
         metadata.Set("BT", "Trn_AgendaEventGroup");
         metadata.Set("PK", "[ \"AgendaCalendarId\",\"ResidentId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AgendaCalendarId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Agendacalendarid_Z");
         state.Add("gxTpr_Residentid_Z");
         state.Add("gxTpr_Agendaeventgrouprsvp_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Residentsalutation_Z");
         state.Add("gxTpr_Residentbsnnumber_Z");
         state.Add("gxTpr_Residentgivenname_Z");
         state.Add("gxTpr_Residentlastname_Z");
         state.Add("gxTpr_Residentinitials_Z");
         state.Add("gxTpr_Residentemail_Z");
         state.Add("gxTpr_Residentgender_Z");
         state.Add("gxTpr_Residentcountry_Z");
         state.Add("gxTpr_Residentcity_Z");
         state.Add("gxTpr_Residentzipcode_Z");
         state.Add("gxTpr_Residentaddressline1_Z");
         state.Add("gxTpr_Residentaddressline2_Z");
         state.Add("gxTpr_Residentphone_Z");
         state.Add("gxTpr_Residentbirthdate_Z_Nullable");
         state.Add("gxTpr_Residentguid_Z");
         state.Add("gxTpr_Residenttypeid_Z");
         state.Add("gxTpr_Residenttypename_Z");
         state.Add("gxTpr_Medicalindicationid_Z");
         state.Add("gxTpr_Medicalindicationname_Z");
         state.Add("gxTpr_Residentphonecode_Z");
         state.Add("gxTpr_Residentphonenumber_Z");
         state.Add("gxTpr_Residenttypeid_N");
         state.Add("gxTpr_Medicalindicationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_AgendaEventGroup sdt;
         sdt = (SdtTrn_AgendaEventGroup)(source);
         gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid ;
         gxTv_SdtTrn_AgendaEventGroup_Residentid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentid ;
         gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp ;
         gxTv_SdtTrn_AgendaEventGroup_Locationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Locationid ;
         gxTv_SdtTrn_AgendaEventGroup_Organisationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Organisationid ;
         gxTv_SdtTrn_AgendaEventGroup_Residentsalutation = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentsalutation ;
         gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber ;
         gxTv_SdtTrn_AgendaEventGroup_Residentgivenname = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgivenname ;
         gxTv_SdtTrn_AgendaEventGroup_Residentlastname = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentlastname ;
         gxTv_SdtTrn_AgendaEventGroup_Residentinitials = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentinitials ;
         gxTv_SdtTrn_AgendaEventGroup_Residentemail = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentemail ;
         gxTv_SdtTrn_AgendaEventGroup_Residentgender = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgender ;
         gxTv_SdtTrn_AgendaEventGroup_Residentcountry = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcountry ;
         gxTv_SdtTrn_AgendaEventGroup_Residentcity = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcity ;
         gxTv_SdtTrn_AgendaEventGroup_Residentzipcode = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentzipcode ;
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 ;
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphone = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphone ;
         gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate ;
         gxTv_SdtTrn_AgendaEventGroup_Residentguid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentguid ;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid ;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypename = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypename ;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid ;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphonecode = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonecode ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber ;
         gxTv_SdtTrn_AgendaEventGroup_Mode = sdt.gxTv_SdtTrn_AgendaEventGroup_Mode ;
         gxTv_SdtTrn_AgendaEventGroup_Initialized = sdt.gxTv_SdtTrn_AgendaEventGroup_Initialized ;
         gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Locationid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Locationid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z ;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N ;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N ;
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
         AddObjectProperty("AgendaCalendarId", gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid, false, includeNonInitialized);
         AddObjectProperty("ResidentId", gxTv_SdtTrn_AgendaEventGroup_Residentid, false, includeNonInitialized);
         AddObjectProperty("AgendaEventGroupRSVP", gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_AgendaEventGroup_Locationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_AgendaEventGroup_Organisationid, false, includeNonInitialized);
         AddObjectProperty("ResidentSalutation", gxTv_SdtTrn_AgendaEventGroup_Residentsalutation, false, includeNonInitialized);
         AddObjectProperty("ResidentBsnNumber", gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber, false, includeNonInitialized);
         AddObjectProperty("ResidentGivenName", gxTv_SdtTrn_AgendaEventGroup_Residentgivenname, false, includeNonInitialized);
         AddObjectProperty("ResidentLastName", gxTv_SdtTrn_AgendaEventGroup_Residentlastname, false, includeNonInitialized);
         AddObjectProperty("ResidentInitials", gxTv_SdtTrn_AgendaEventGroup_Residentinitials, false, includeNonInitialized);
         AddObjectProperty("ResidentEmail", gxTv_SdtTrn_AgendaEventGroup_Residentemail, false, includeNonInitialized);
         AddObjectProperty("ResidentGender", gxTv_SdtTrn_AgendaEventGroup_Residentgender, false, includeNonInitialized);
         AddObjectProperty("ResidentCountry", gxTv_SdtTrn_AgendaEventGroup_Residentcountry, false, includeNonInitialized);
         AddObjectProperty("ResidentCity", gxTv_SdtTrn_AgendaEventGroup_Residentcity, false, includeNonInitialized);
         AddObjectProperty("ResidentZipCode", gxTv_SdtTrn_AgendaEventGroup_Residentzipcode, false, includeNonInitialized);
         AddObjectProperty("ResidentAddressLine1", gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1, false, includeNonInitialized);
         AddObjectProperty("ResidentAddressLine2", gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2, false, includeNonInitialized);
         AddObjectProperty("ResidentPhone", gxTv_SdtTrn_AgendaEventGroup_Residentphone, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ResidentBirthDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ResidentGUID", gxTv_SdtTrn_AgendaEventGroup_Residentguid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId", gxTv_SdtTrn_AgendaEventGroup_Residenttypeid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeName", gxTv_SdtTrn_AgendaEventGroup_Residenttypename, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationId", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationName", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname, false, includeNonInitialized);
         AddObjectProperty("ResidentPhoneCode", gxTv_SdtTrn_AgendaEventGroup_Residentphonecode, false, includeNonInitialized);
         AddObjectProperty("ResidentPhoneNumber", gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_AgendaEventGroup_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_AgendaEventGroup_Initialized, false, includeNonInitialized);
            AddObjectProperty("AgendaCalendarId_Z", gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentId_Z", gxTv_SdtTrn_AgendaEventGroup_Residentid_Z, false, includeNonInitialized);
            AddObjectProperty("AgendaEventGroupRSVP_Z", gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_AgendaEventGroup_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentSalutation_Z", gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentBsnNumber_Z", gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGivenName_Z", gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastName_Z", gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentInitials_Z", gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentEmail_Z", gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGender_Z", gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentCountry_Z", gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentCity_Z", gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentZipCode_Z", gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentAddressLine1_Z", gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentAddressLine2_Z", gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhone_Z", gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ResidentBirthDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ResidentGUID_Z", gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_Z", gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeName_Z", gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_Z", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationName_Z", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhoneCode_Z", gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhoneNumber_Z", gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_AgendaEventGroup sdt )
      {
         if ( sdt.IsDirty("AgendaCalendarId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid ;
         }
         if ( sdt.IsDirty("ResidentId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentid ;
         }
         if ( sdt.IsDirty("AgendaEventGroupRSVP") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp = sdt.gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Locationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Organisationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Organisationid ;
         }
         if ( sdt.IsDirty("ResidentSalutation") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentsalutation = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentsalutation ;
         }
         if ( sdt.IsDirty("ResidentBsnNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber ;
         }
         if ( sdt.IsDirty("ResidentGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgivenname = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgivenname ;
         }
         if ( sdt.IsDirty("ResidentLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentlastname = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentlastname ;
         }
         if ( sdt.IsDirty("ResidentInitials") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentinitials = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentinitials ;
         }
         if ( sdt.IsDirty("ResidentEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentemail = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentemail ;
         }
         if ( sdt.IsDirty("ResidentGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgender = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentgender ;
         }
         if ( sdt.IsDirty("ResidentCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcountry = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcountry ;
         }
         if ( sdt.IsDirty("ResidentCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcity = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentcity ;
         }
         if ( sdt.IsDirty("ResidentZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentzipcode = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentzipcode ;
         }
         if ( sdt.IsDirty("ResidentAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 ;
         }
         if ( sdt.IsDirty("ResidentAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 ;
         }
         if ( sdt.IsDirty("ResidentPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphone = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphone ;
         }
         if ( sdt.IsDirty("ResidentBirthDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate ;
         }
         if ( sdt.IsDirty("ResidentGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentguid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentguid ;
         }
         if ( sdt.IsDirty("ResidentTypeId") )
         {
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = (short)(sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid ;
         }
         if ( sdt.IsDirty("ResidentTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypename = sdt.gxTv_SdtTrn_AgendaEventGroup_Residenttypename ;
         }
         if ( sdt.IsDirty("MedicalIndicationId") )
         {
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = (short)(sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid ;
         }
         if ( sdt.IsDirty("MedicalIndicationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname = sdt.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname ;
         }
         if ( sdt.IsDirty("ResidentPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonecode = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonecode ;
         }
         if ( sdt.IsDirty("ResidentPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber = sdt.gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AgendaCalendarId" )]
      [  XmlElement( ElementName = "AgendaCalendarId"   )]
      public Guid gxTpr_Agendacalendarid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid != value )
            {
               gxTv_SdtTrn_AgendaEventGroup_Mode = "INS";
               this.gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z_SetNull( );
            }
            gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid = value;
            SetDirty("Agendacalendarid");
         }

      }

      [  SoapElement( ElementName = "ResidentId" )]
      [  XmlElement( ElementName = "ResidentId"   )]
      public Guid gxTpr_Residentid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_AgendaEventGroup_Residentid != value )
            {
               gxTv_SdtTrn_AgendaEventGroup_Mode = "INS";
               this.gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z_SetNull( );
            }
            gxTv_SdtTrn_AgendaEventGroup_Residentid = value;
            SetDirty("Residentid");
         }

      }

      [  SoapElement( ElementName = "AgendaEventGroupRSVP" )]
      [  XmlElement( ElementName = "AgendaEventGroupRSVP"   )]
      public bool gxTpr_Agendaeventgrouprsvp
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp = value;
            SetDirty("Agendaeventgrouprsvp");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "ResidentSalutation" )]
      [  XmlElement( ElementName = "ResidentSalutation"   )]
      public string gxTpr_Residentsalutation
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentsalutation ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentsalutation = value;
            SetDirty("Residentsalutation");
         }

      }

      [  SoapElement( ElementName = "ResidentBsnNumber" )]
      [  XmlElement( ElementName = "ResidentBsnNumber"   )]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber = value;
            SetDirty("Residentbsnnumber");
         }

      }

      [  SoapElement( ElementName = "ResidentGivenName" )]
      [  XmlElement( ElementName = "ResidentGivenName"   )]
      public string gxTpr_Residentgivenname
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgivenname = value;
            SetDirty("Residentgivenname");
         }

      }

      [  SoapElement( ElementName = "ResidentLastName" )]
      [  XmlElement( ElementName = "ResidentLastName"   )]
      public string gxTpr_Residentlastname
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentlastname = value;
            SetDirty("Residentlastname");
         }

      }

      [  SoapElement( ElementName = "ResidentInitials" )]
      [  XmlElement( ElementName = "ResidentInitials"   )]
      public string gxTpr_Residentinitials
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentinitials ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentinitials = value;
            SetDirty("Residentinitials");
         }

      }

      [  SoapElement( ElementName = "ResidentEmail" )]
      [  XmlElement( ElementName = "ResidentEmail"   )]
      public string gxTpr_Residentemail
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentemail = value;
            SetDirty("Residentemail");
         }

      }

      [  SoapElement( ElementName = "ResidentGender" )]
      [  XmlElement( ElementName = "ResidentGender"   )]
      public string gxTpr_Residentgender
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentgender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgender = value;
            SetDirty("Residentgender");
         }

      }

      [  SoapElement( ElementName = "ResidentCountry" )]
      [  XmlElement( ElementName = "ResidentCountry"   )]
      public string gxTpr_Residentcountry
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentcountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcountry = value;
            SetDirty("Residentcountry");
         }

      }

      [  SoapElement( ElementName = "ResidentCity" )]
      [  XmlElement( ElementName = "ResidentCity"   )]
      public string gxTpr_Residentcity
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentcity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcity = value;
            SetDirty("Residentcity");
         }

      }

      [  SoapElement( ElementName = "ResidentZipCode" )]
      [  XmlElement( ElementName = "ResidentZipCode"   )]
      public string gxTpr_Residentzipcode
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentzipcode = value;
            SetDirty("Residentzipcode");
         }

      }

      [  SoapElement( ElementName = "ResidentAddressLine1" )]
      [  XmlElement( ElementName = "ResidentAddressLine1"   )]
      public string gxTpr_Residentaddressline1
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 = value;
            SetDirty("Residentaddressline1");
         }

      }

      [  SoapElement( ElementName = "ResidentAddressLine2" )]
      [  XmlElement( ElementName = "ResidentAddressLine2"   )]
      public string gxTpr_Residentaddressline2
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 = value;
            SetDirty("Residentaddressline2");
         }

      }

      [  SoapElement( ElementName = "ResidentPhone" )]
      [  XmlElement( ElementName = "ResidentPhone"   )]
      public string gxTpr_Residentphone
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphone = value;
            SetDirty("Residentphone");
         }

      }

      [  SoapElement( ElementName = "ResidentBirthDate" )]
      [  XmlElement( ElementName = "ResidentBirthDate"  , IsNullable=true )]
      public string gxTpr_Residentbirthdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Residentbirthdate
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = value;
            SetDirty("Residentbirthdate");
         }

      }

      [  SoapElement( ElementName = "ResidentGUID" )]
      [  XmlElement( ElementName = "ResidentGUID"   )]
      public string gxTpr_Residentguid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentguid = value;
            SetDirty("Residentguid");
         }

      }

      [  SoapElement( ElementName = "ResidentTypeId" )]
      [  XmlElement( ElementName = "ResidentTypeId"   )]
      public Guid gxTpr_Residenttypeid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residenttypeid ;
         }

         set {
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid = value;
            SetDirty("Residenttypeid");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = 1;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid = Guid.Empty;
         SetDirty("Residenttypeid");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_IsNull( )
      {
         return (gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentTypeName" )]
      [  XmlElement( ElementName = "ResidentTypeName"   )]
      public string gxTpr_Residenttypename
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residenttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypename = value;
            SetDirty("Residenttypename");
         }

      }

      [  SoapElement( ElementName = "MedicalIndicationId" )]
      [  XmlElement( ElementName = "MedicalIndicationId"   )]
      public Guid gxTpr_Medicalindicationid
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid ;
         }

         set {
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid = value;
            SetDirty("Medicalindicationid");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = 1;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid = Guid.Empty;
         SetDirty("Medicalindicationid");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_IsNull( )
      {
         return (gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N==1) ;
      }

      [  SoapElement( ElementName = "MedicalIndicationName" )]
      [  XmlElement( ElementName = "MedicalIndicationName"   )]
      public string gxTpr_Medicalindicationname
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname = value;
            SetDirty("Medicalindicationname");
         }

      }

      [  SoapElement( ElementName = "ResidentPhoneCode" )]
      [  XmlElement( ElementName = "ResidentPhoneCode"   )]
      public string gxTpr_Residentphonecode
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonecode = value;
            SetDirty("Residentphonecode");
         }

      }

      [  SoapElement( ElementName = "ResidentPhoneNumber" )]
      [  XmlElement( ElementName = "ResidentPhoneNumber"   )]
      public string gxTpr_Residentphonenumber
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber = value;
            SetDirty("Residentphonenumber");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Mode_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Initialized_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarId_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarId_Z"   )]
      public Guid gxTpr_Agendacalendarid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z = value;
            SetDirty("Agendacalendarid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z = Guid.Empty;
         SetDirty("Agendacalendarid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentId_Z" )]
      [  XmlElement( ElementName = "ResidentId_Z"   )]
      public Guid gxTpr_Residentid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentid_Z = value;
            SetDirty("Residentid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentid_Z = Guid.Empty;
         SetDirty("Residentid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaEventGroupRSVP_Z" )]
      [  XmlElement( ElementName = "AgendaEventGroupRSVP_Z"   )]
      public bool gxTpr_Agendaeventgrouprsvp_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z = value;
            SetDirty("Agendaeventgrouprsvp_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z = false;
         SetDirty("Agendaeventgrouprsvp_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentSalutation_Z" )]
      [  XmlElement( ElementName = "ResidentSalutation_Z"   )]
      public string gxTpr_Residentsalutation_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z = value;
            SetDirty("Residentsalutation_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z = "";
         SetDirty("Residentsalutation_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentBsnNumber_Z" )]
      [  XmlElement( ElementName = "ResidentBsnNumber_Z"   )]
      public string gxTpr_Residentbsnnumber_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z = value;
            SetDirty("Residentbsnnumber_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z = "";
         SetDirty("Residentbsnnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGivenName_Z" )]
      [  XmlElement( ElementName = "ResidentGivenName_Z"   )]
      public string gxTpr_Residentgivenname_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z = value;
            SetDirty("Residentgivenname_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z = "";
         SetDirty("Residentgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastName_Z" )]
      [  XmlElement( ElementName = "ResidentLastName_Z"   )]
      public string gxTpr_Residentlastname_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z = value;
            SetDirty("Residentlastname_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z = "";
         SetDirty("Residentlastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentInitials_Z" )]
      [  XmlElement( ElementName = "ResidentInitials_Z"   )]
      public string gxTpr_Residentinitials_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z = value;
            SetDirty("Residentinitials_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z = "";
         SetDirty("Residentinitials_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentEmail_Z" )]
      [  XmlElement( ElementName = "ResidentEmail_Z"   )]
      public string gxTpr_Residentemail_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z = value;
            SetDirty("Residentemail_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z = "";
         SetDirty("Residentemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGender_Z" )]
      [  XmlElement( ElementName = "ResidentGender_Z"   )]
      public string gxTpr_Residentgender_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z = value;
            SetDirty("Residentgender_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z = "";
         SetDirty("Residentgender_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentCountry_Z" )]
      [  XmlElement( ElementName = "ResidentCountry_Z"   )]
      public string gxTpr_Residentcountry_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z = value;
            SetDirty("Residentcountry_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z = "";
         SetDirty("Residentcountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentCity_Z" )]
      [  XmlElement( ElementName = "ResidentCity_Z"   )]
      public string gxTpr_Residentcity_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z = value;
            SetDirty("Residentcity_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z = "";
         SetDirty("Residentcity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentZipCode_Z" )]
      [  XmlElement( ElementName = "ResidentZipCode_Z"   )]
      public string gxTpr_Residentzipcode_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z = value;
            SetDirty("Residentzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z = "";
         SetDirty("Residentzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddressLine1_Z" )]
      [  XmlElement( ElementName = "ResidentAddressLine1_Z"   )]
      public string gxTpr_Residentaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z = value;
            SetDirty("Residentaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z = "";
         SetDirty("Residentaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddressLine2_Z" )]
      [  XmlElement( ElementName = "ResidentAddressLine2_Z"   )]
      public string gxTpr_Residentaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z = value;
            SetDirty("Residentaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z = "";
         SetDirty("Residentaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhone_Z" )]
      [  XmlElement( ElementName = "ResidentPhone_Z"   )]
      public string gxTpr_Residentphone_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z = value;
            SetDirty("Residentphone_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z = "";
         SetDirty("Residentphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentBirthDate_Z" )]
      [  XmlElement( ElementName = "ResidentBirthDate_Z"  , IsNullable=true )]
      public string gxTpr_Residentbirthdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Residentbirthdate_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = value;
            SetDirty("Residentbirthdate_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Residentbirthdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGUID_Z" )]
      [  XmlElement( ElementName = "ResidentGUID_Z"   )]
      public string gxTpr_Residentguid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z = value;
            SetDirty("Residentguid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z = "";
         SetDirty("Residentguid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_Z" )]
      [  XmlElement( ElementName = "ResidentTypeId_Z"   )]
      public Guid gxTpr_Residenttypeid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z = value;
            SetDirty("Residenttypeid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z = Guid.Empty;
         SetDirty("Residenttypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeName_Z" )]
      [  XmlElement( ElementName = "ResidentTypeName_Z"   )]
      public string gxTpr_Residenttypename_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z = value;
            SetDirty("Residenttypename_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z = "";
         SetDirty("Residenttypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationId_Z"   )]
      public Guid gxTpr_Medicalindicationid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z = value;
            SetDirty("Medicalindicationid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z = Guid.Empty;
         SetDirty("Medicalindicationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationName_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationName_Z"   )]
      public string gxTpr_Medicalindicationname_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z = value;
            SetDirty("Medicalindicationname_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z = "";
         SetDirty("Medicalindicationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhoneCode_Z" )]
      [  XmlElement( ElementName = "ResidentPhoneCode_Z"   )]
      public string gxTpr_Residentphonecode_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z = value;
            SetDirty("Residentphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z = "";
         SetDirty("Residentphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhoneNumber_Z" )]
      [  XmlElement( ElementName = "ResidentPhoneNumber_Z"   )]
      public string gxTpr_Residentphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z = value;
            SetDirty("Residentphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z = "";
         SetDirty("Residentphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_N" )]
      [  XmlElement( ElementName = "ResidentTypeId_N"   )]
      public short gxTpr_Residenttypeid_N
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = value;
            SetDirty("Residenttypeid_N");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N = 0;
         SetDirty("Residenttypeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_N" )]
      [  XmlElement( ElementName = "MedicalIndicationId_N"   )]
      public short gxTpr_Medicalindicationid_N
      {
         get {
            return gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = value;
            SetDirty("Medicalindicationid_N");
         }

      }

      public void gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N_SetNull( )
      {
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N = 0;
         SetDirty("Medicalindicationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N_IsNull( )
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
         gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_AgendaEventGroup_Residentid = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Locationid = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Organisationid = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Residentsalutation = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentgivenname = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentlastname = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentinitials = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentemail = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentgender = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentcountry = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentcity = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentzipcode = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphone = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate = DateTime.MinValue;
         gxTv_SdtTrn_AgendaEventGroup_Residentguid = "";
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypename = "";
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphonecode = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber = "";
         gxTv_SdtTrn_AgendaEventGroup_Mode = "";
         gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Residentid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z = DateTime.MinValue;
         gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z = "";
         gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_agendaeventgroup", "GeneXus.Programs.trn_agendaeventgroup_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_AgendaEventGroup_Initialized ;
      private short gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_N ;
      private short gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_N ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentsalutation ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentinitials ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphone ;
      private string gxTv_SdtTrn_AgendaEventGroup_Mode ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentsalutation_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentinitials_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate ;
      private DateTime gxTv_SdtTrn_AgendaEventGroup_Residentbirthdate_Z ;
      private bool gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp ;
      private bool gxTv_SdtTrn_AgendaEventGroup_Agendaeventgrouprsvp_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentgivenname ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentlastname ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentemail ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentgender ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentcountry ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentcity ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentzipcode ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1 ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2 ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentguid ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residenttypename ;
      private string gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphonecode ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentbsnnumber_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentgivenname_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentlastname_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentemail_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentgender_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentcountry_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentcity_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentzipcode_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentaddressline1_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentaddressline2_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentguid_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residenttypename_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Medicalindicationname_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphonecode_Z ;
      private string gxTv_SdtTrn_AgendaEventGroup_Residentphonenumber_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Residentid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Locationid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Organisationid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Residenttypeid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Agendacalendarid_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Residentid_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Locationid_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Organisationid_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Residenttypeid_Z ;
      private Guid gxTv_SdtTrn_AgendaEventGroup_Medicalindicationid_Z ;
   }

   [DataContract(Name = @"Trn_AgendaEventGroup", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AgendaEventGroup_RESTInterface : GxGenericCollectionItem<SdtTrn_AgendaEventGroup>
   {
      public SdtTrn_AgendaEventGroup_RESTInterface( ) : base()
      {
      }

      public SdtTrn_AgendaEventGroup_RESTInterface( SdtTrn_AgendaEventGroup psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgendaCalendarId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Agendacalendarid
      {
         get {
            return sdt.gxTpr_Agendacalendarid ;
         }

         set {
            sdt.gxTpr_Agendacalendarid = value;
         }

      }

      [DataMember( Name = "ResidentId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Residentid
      {
         get {
            return sdt.gxTpr_Residentid ;
         }

         set {
            sdt.gxTpr_Residentid = value;
         }

      }

      [DataMember( Name = "AgendaEventGroupRSVP" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Agendaeventgrouprsvp
      {
         get {
            return sdt.gxTpr_Agendaeventgrouprsvp ;
         }

         set {
            sdt.gxTpr_Agendaeventgrouprsvp = value;
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

      [DataMember( Name = "OrganisationId" , Order = 4 )]
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

      [DataMember( Name = "ResidentSalutation" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Residentsalutation
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentsalutation) ;
         }

         set {
            sdt.gxTpr_Residentsalutation = value;
         }

      }

      [DataMember( Name = "ResidentBsnNumber" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return sdt.gxTpr_Residentbsnnumber ;
         }

         set {
            sdt.gxTpr_Residentbsnnumber = value;
         }

      }

      [DataMember( Name = "ResidentGivenName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Residentgivenname
      {
         get {
            return sdt.gxTpr_Residentgivenname ;
         }

         set {
            sdt.gxTpr_Residentgivenname = value;
         }

      }

      [DataMember( Name = "ResidentLastName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Residentlastname
      {
         get {
            return sdt.gxTpr_Residentlastname ;
         }

         set {
            sdt.gxTpr_Residentlastname = value;
         }

      }

      [DataMember( Name = "ResidentInitials" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Residentinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentinitials) ;
         }

         set {
            sdt.gxTpr_Residentinitials = value;
         }

      }

      [DataMember( Name = "ResidentEmail" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Residentemail
      {
         get {
            return sdt.gxTpr_Residentemail ;
         }

         set {
            sdt.gxTpr_Residentemail = value;
         }

      }

      [DataMember( Name = "ResidentGender" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Residentgender
      {
         get {
            return sdt.gxTpr_Residentgender ;
         }

         set {
            sdt.gxTpr_Residentgender = value;
         }

      }

      [DataMember( Name = "ResidentCountry" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Residentcountry
      {
         get {
            return sdt.gxTpr_Residentcountry ;
         }

         set {
            sdt.gxTpr_Residentcountry = value;
         }

      }

      [DataMember( Name = "ResidentCity" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Residentcity
      {
         get {
            return sdt.gxTpr_Residentcity ;
         }

         set {
            sdt.gxTpr_Residentcity = value;
         }

      }

      [DataMember( Name = "ResidentZipCode" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Residentzipcode
      {
         get {
            return sdt.gxTpr_Residentzipcode ;
         }

         set {
            sdt.gxTpr_Residentzipcode = value;
         }

      }

      [DataMember( Name = "ResidentAddressLine1" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Residentaddressline1
      {
         get {
            return sdt.gxTpr_Residentaddressline1 ;
         }

         set {
            sdt.gxTpr_Residentaddressline1 = value;
         }

      }

      [DataMember( Name = "ResidentAddressLine2" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Residentaddressline2
      {
         get {
            return sdt.gxTpr_Residentaddressline2 ;
         }

         set {
            sdt.gxTpr_Residentaddressline2 = value;
         }

      }

      [DataMember( Name = "ResidentPhone" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Residentphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentphone) ;
         }

         set {
            sdt.gxTpr_Residentphone = value;
         }

      }

      [DataMember( Name = "ResidentBirthDate" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Residentbirthdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Residentbirthdate) ;
         }

         set {
            sdt.gxTpr_Residentbirthdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ResidentGUID" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Residentguid
      {
         get {
            return sdt.gxTpr_Residentguid ;
         }

         set {
            sdt.gxTpr_Residentguid = value;
         }

      }

      [DataMember( Name = "ResidentTypeId" , Order = 20 )]
      [GxSeudo()]
      public Guid gxTpr_Residenttypeid
      {
         get {
            return sdt.gxTpr_Residenttypeid ;
         }

         set {
            sdt.gxTpr_Residenttypeid = value;
         }

      }

      [DataMember( Name = "ResidentTypeName" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Residenttypename
      {
         get {
            return sdt.gxTpr_Residenttypename ;
         }

         set {
            sdt.gxTpr_Residenttypename = value;
         }

      }

      [DataMember( Name = "MedicalIndicationId" , Order = 22 )]
      [GxSeudo()]
      public Guid gxTpr_Medicalindicationid
      {
         get {
            return sdt.gxTpr_Medicalindicationid ;
         }

         set {
            sdt.gxTpr_Medicalindicationid = value;
         }

      }

      [DataMember( Name = "MedicalIndicationName" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Medicalindicationname
      {
         get {
            return sdt.gxTpr_Medicalindicationname ;
         }

         set {
            sdt.gxTpr_Medicalindicationname = value;
         }

      }

      [DataMember( Name = "ResidentPhoneCode" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Residentphonecode
      {
         get {
            return sdt.gxTpr_Residentphonecode ;
         }

         set {
            sdt.gxTpr_Residentphonecode = value;
         }

      }

      [DataMember( Name = "ResidentPhoneNumber" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Residentphonenumber
      {
         get {
            return sdt.gxTpr_Residentphonenumber ;
         }

         set {
            sdt.gxTpr_Residentphonenumber = value;
         }

      }

      public SdtTrn_AgendaEventGroup sdt
      {
         get {
            return (SdtTrn_AgendaEventGroup)Sdt ;
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
            sdt = new SdtTrn_AgendaEventGroup() ;
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

   [DataContract(Name = @"Trn_AgendaEventGroup", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AgendaEventGroup_RESTLInterface : GxGenericCollectionItem<SdtTrn_AgendaEventGroup>
   {
      public SdtTrn_AgendaEventGroup_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_AgendaEventGroup_RESTLInterface( SdtTrn_AgendaEventGroup psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgendaEventGroupRSVP" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Agendaeventgrouprsvp
      {
         get {
            return sdt.gxTpr_Agendaeventgrouprsvp ;
         }

         set {
            sdt.gxTpr_Agendaeventgrouprsvp = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_AgendaEventGroup sdt
      {
         get {
            return (SdtTrn_AgendaEventGroup)Sdt ;
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
            sdt = new SdtTrn_AgendaEventGroup() ;
         }
      }

   }

}
