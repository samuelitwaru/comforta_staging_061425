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
   [XmlRoot(ElementName = "Trn_Resident" )]
   [XmlType(TypeName =  "Trn_Resident" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_Resident : GxSilentTrnSdt
   {
      public SdtTrn_Resident( )
      {
      }

      public SdtTrn_Resident( IGxContext context )
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

      public void Load( Guid AV62ResidentId ,
                        Guid AV29LocationId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV62ResidentId,(Guid)AV29LocationId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ResidentId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Resident");
         metadata.Set("BT", "Trn_Resident");
         metadata.Set("PK", "[ \"ResidentId\",\"LocationId\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"LocationId\",\"OrganisationId\",\"ResidentId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MedicalIndicationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ResidentPackageId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ResidentTypeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Residentimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Residentid_Z");
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
         state.Add("gxTpr_Residenthomephone_Z");
         state.Add("gxTpr_Residentbirthdate_Z_Nullable");
         state.Add("gxTpr_Residentguid_Z");
         state.Add("gxTpr_Residenttypeid_Z");
         state.Add("gxTpr_Residenttypename_Z");
         state.Add("gxTpr_Medicalindicationid_Z");
         state.Add("gxTpr_Medicalindicationname_Z");
         state.Add("gxTpr_Residentphonecode_Z");
         state.Add("gxTpr_Residentphonenumber_Z");
         state.Add("gxTpr_Residenthomephonecode_Z");
         state.Add("gxTpr_Residenthomephonenumber_Z");
         state.Add("gxTpr_Residentlanguage_Z");
         state.Add("gxTpr_Residentpackageid_Z");
         state.Add("gxTpr_Residentpackagename_Z");
         state.Add("gxTpr_Sg_locationid_Z");
         state.Add("gxTpr_Sg_organisationid_Z");
         state.Add("gxTpr_Residentimage_gxi_Z");
         state.Add("gxTpr_Residenttypeid_N");
         state.Add("gxTpr_Medicalindicationid_N");
         state.Add("gxTpr_Residentimage_N");
         state.Add("gxTpr_Residentpackageid_N");
         state.Add("gxTpr_Residentimage_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Resident sdt;
         sdt = (SdtTrn_Resident)(source);
         gxTv_SdtTrn_Resident_Residentid = sdt.gxTv_SdtTrn_Resident_Residentid ;
         gxTv_SdtTrn_Resident_Locationid = sdt.gxTv_SdtTrn_Resident_Locationid ;
         gxTv_SdtTrn_Resident_Organisationid = sdt.gxTv_SdtTrn_Resident_Organisationid ;
         gxTv_SdtTrn_Resident_Residentsalutation = sdt.gxTv_SdtTrn_Resident_Residentsalutation ;
         gxTv_SdtTrn_Resident_Residentbsnnumber = sdt.gxTv_SdtTrn_Resident_Residentbsnnumber ;
         gxTv_SdtTrn_Resident_Residentgivenname = sdt.gxTv_SdtTrn_Resident_Residentgivenname ;
         gxTv_SdtTrn_Resident_Residentlastname = sdt.gxTv_SdtTrn_Resident_Residentlastname ;
         gxTv_SdtTrn_Resident_Residentinitials = sdt.gxTv_SdtTrn_Resident_Residentinitials ;
         gxTv_SdtTrn_Resident_Residentemail = sdt.gxTv_SdtTrn_Resident_Residentemail ;
         gxTv_SdtTrn_Resident_Residentgender = sdt.gxTv_SdtTrn_Resident_Residentgender ;
         gxTv_SdtTrn_Resident_Residentcountry = sdt.gxTv_SdtTrn_Resident_Residentcountry ;
         gxTv_SdtTrn_Resident_Residentcity = sdt.gxTv_SdtTrn_Resident_Residentcity ;
         gxTv_SdtTrn_Resident_Residentzipcode = sdt.gxTv_SdtTrn_Resident_Residentzipcode ;
         gxTv_SdtTrn_Resident_Residentaddressline1 = sdt.gxTv_SdtTrn_Resident_Residentaddressline1 ;
         gxTv_SdtTrn_Resident_Residentaddressline2 = sdt.gxTv_SdtTrn_Resident_Residentaddressline2 ;
         gxTv_SdtTrn_Resident_Residentphone = sdt.gxTv_SdtTrn_Resident_Residentphone ;
         gxTv_SdtTrn_Resident_Residenthomephone = sdt.gxTv_SdtTrn_Resident_Residenthomephone ;
         gxTv_SdtTrn_Resident_Residentbirthdate = sdt.gxTv_SdtTrn_Resident_Residentbirthdate ;
         gxTv_SdtTrn_Resident_Residentguid = sdt.gxTv_SdtTrn_Resident_Residentguid ;
         gxTv_SdtTrn_Resident_Residenttypeid = sdt.gxTv_SdtTrn_Resident_Residenttypeid ;
         gxTv_SdtTrn_Resident_Residenttypename = sdt.gxTv_SdtTrn_Resident_Residenttypename ;
         gxTv_SdtTrn_Resident_Medicalindicationid = sdt.gxTv_SdtTrn_Resident_Medicalindicationid ;
         gxTv_SdtTrn_Resident_Medicalindicationname = sdt.gxTv_SdtTrn_Resident_Medicalindicationname ;
         gxTv_SdtTrn_Resident_Residentphonecode = sdt.gxTv_SdtTrn_Resident_Residentphonecode ;
         gxTv_SdtTrn_Resident_Residentphonenumber = sdt.gxTv_SdtTrn_Resident_Residentphonenumber ;
         gxTv_SdtTrn_Resident_Residenthomephonecode = sdt.gxTv_SdtTrn_Resident_Residenthomephonecode ;
         gxTv_SdtTrn_Resident_Residenthomephonenumber = sdt.gxTv_SdtTrn_Resident_Residenthomephonenumber ;
         gxTv_SdtTrn_Resident_Residentimage = sdt.gxTv_SdtTrn_Resident_Residentimage ;
         gxTv_SdtTrn_Resident_Residentimage_gxi = sdt.gxTv_SdtTrn_Resident_Residentimage_gxi ;
         gxTv_SdtTrn_Resident_Residentlanguage = sdt.gxTv_SdtTrn_Resident_Residentlanguage ;
         gxTv_SdtTrn_Resident_Residentpackageid = sdt.gxTv_SdtTrn_Resident_Residentpackageid ;
         gxTv_SdtTrn_Resident_Residentpackagename = sdt.gxTv_SdtTrn_Resident_Residentpackagename ;
         gxTv_SdtTrn_Resident_Sg_locationid = sdt.gxTv_SdtTrn_Resident_Sg_locationid ;
         gxTv_SdtTrn_Resident_Sg_organisationid = sdt.gxTv_SdtTrn_Resident_Sg_organisationid ;
         gxTv_SdtTrn_Resident_Mode = sdt.gxTv_SdtTrn_Resident_Mode ;
         gxTv_SdtTrn_Resident_Initialized = sdt.gxTv_SdtTrn_Resident_Initialized ;
         gxTv_SdtTrn_Resident_Residentid_Z = sdt.gxTv_SdtTrn_Resident_Residentid_Z ;
         gxTv_SdtTrn_Resident_Locationid_Z = sdt.gxTv_SdtTrn_Resident_Locationid_Z ;
         gxTv_SdtTrn_Resident_Organisationid_Z = sdt.gxTv_SdtTrn_Resident_Organisationid_Z ;
         gxTv_SdtTrn_Resident_Residentsalutation_Z = sdt.gxTv_SdtTrn_Resident_Residentsalutation_Z ;
         gxTv_SdtTrn_Resident_Residentbsnnumber_Z = sdt.gxTv_SdtTrn_Resident_Residentbsnnumber_Z ;
         gxTv_SdtTrn_Resident_Residentgivenname_Z = sdt.gxTv_SdtTrn_Resident_Residentgivenname_Z ;
         gxTv_SdtTrn_Resident_Residentlastname_Z = sdt.gxTv_SdtTrn_Resident_Residentlastname_Z ;
         gxTv_SdtTrn_Resident_Residentinitials_Z = sdt.gxTv_SdtTrn_Resident_Residentinitials_Z ;
         gxTv_SdtTrn_Resident_Residentemail_Z = sdt.gxTv_SdtTrn_Resident_Residentemail_Z ;
         gxTv_SdtTrn_Resident_Residentgender_Z = sdt.gxTv_SdtTrn_Resident_Residentgender_Z ;
         gxTv_SdtTrn_Resident_Residentcountry_Z = sdt.gxTv_SdtTrn_Resident_Residentcountry_Z ;
         gxTv_SdtTrn_Resident_Residentcity_Z = sdt.gxTv_SdtTrn_Resident_Residentcity_Z ;
         gxTv_SdtTrn_Resident_Residentzipcode_Z = sdt.gxTv_SdtTrn_Resident_Residentzipcode_Z ;
         gxTv_SdtTrn_Resident_Residentaddressline1_Z = sdt.gxTv_SdtTrn_Resident_Residentaddressline1_Z ;
         gxTv_SdtTrn_Resident_Residentaddressline2_Z = sdt.gxTv_SdtTrn_Resident_Residentaddressline2_Z ;
         gxTv_SdtTrn_Resident_Residentphone_Z = sdt.gxTv_SdtTrn_Resident_Residentphone_Z ;
         gxTv_SdtTrn_Resident_Residenthomephone_Z = sdt.gxTv_SdtTrn_Resident_Residenthomephone_Z ;
         gxTv_SdtTrn_Resident_Residentbirthdate_Z = sdt.gxTv_SdtTrn_Resident_Residentbirthdate_Z ;
         gxTv_SdtTrn_Resident_Residentguid_Z = sdt.gxTv_SdtTrn_Resident_Residentguid_Z ;
         gxTv_SdtTrn_Resident_Residenttypeid_Z = sdt.gxTv_SdtTrn_Resident_Residenttypeid_Z ;
         gxTv_SdtTrn_Resident_Residenttypename_Z = sdt.gxTv_SdtTrn_Resident_Residenttypename_Z ;
         gxTv_SdtTrn_Resident_Medicalindicationid_Z = sdt.gxTv_SdtTrn_Resident_Medicalindicationid_Z ;
         gxTv_SdtTrn_Resident_Medicalindicationname_Z = sdt.gxTv_SdtTrn_Resident_Medicalindicationname_Z ;
         gxTv_SdtTrn_Resident_Residentphonecode_Z = sdt.gxTv_SdtTrn_Resident_Residentphonecode_Z ;
         gxTv_SdtTrn_Resident_Residentphonenumber_Z = sdt.gxTv_SdtTrn_Resident_Residentphonenumber_Z ;
         gxTv_SdtTrn_Resident_Residenthomephonecode_Z = sdt.gxTv_SdtTrn_Resident_Residenthomephonecode_Z ;
         gxTv_SdtTrn_Resident_Residenthomephonenumber_Z = sdt.gxTv_SdtTrn_Resident_Residenthomephonenumber_Z ;
         gxTv_SdtTrn_Resident_Residentlanguage_Z = sdt.gxTv_SdtTrn_Resident_Residentlanguage_Z ;
         gxTv_SdtTrn_Resident_Residentpackageid_Z = sdt.gxTv_SdtTrn_Resident_Residentpackageid_Z ;
         gxTv_SdtTrn_Resident_Residentpackagename_Z = sdt.gxTv_SdtTrn_Resident_Residentpackagename_Z ;
         gxTv_SdtTrn_Resident_Sg_locationid_Z = sdt.gxTv_SdtTrn_Resident_Sg_locationid_Z ;
         gxTv_SdtTrn_Resident_Sg_organisationid_Z = sdt.gxTv_SdtTrn_Resident_Sg_organisationid_Z ;
         gxTv_SdtTrn_Resident_Residentimage_gxi_Z = sdt.gxTv_SdtTrn_Resident_Residentimage_gxi_Z ;
         gxTv_SdtTrn_Resident_Residenttypeid_N = sdt.gxTv_SdtTrn_Resident_Residenttypeid_N ;
         gxTv_SdtTrn_Resident_Medicalindicationid_N = sdt.gxTv_SdtTrn_Resident_Medicalindicationid_N ;
         gxTv_SdtTrn_Resident_Residentimage_N = sdt.gxTv_SdtTrn_Resident_Residentimage_N ;
         gxTv_SdtTrn_Resident_Residentpackageid_N = sdt.gxTv_SdtTrn_Resident_Residentpackageid_N ;
         gxTv_SdtTrn_Resident_Residentimage_gxi_N = sdt.gxTv_SdtTrn_Resident_Residentimage_gxi_N ;
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
         AddObjectProperty("ResidentId", gxTv_SdtTrn_Resident_Residentid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Resident_Locationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Resident_Organisationid, false, includeNonInitialized);
         AddObjectProperty("ResidentSalutation", gxTv_SdtTrn_Resident_Residentsalutation, false, includeNonInitialized);
         AddObjectProperty("ResidentBsnNumber", gxTv_SdtTrn_Resident_Residentbsnnumber, false, includeNonInitialized);
         AddObjectProperty("ResidentGivenName", gxTv_SdtTrn_Resident_Residentgivenname, false, includeNonInitialized);
         AddObjectProperty("ResidentLastName", gxTv_SdtTrn_Resident_Residentlastname, false, includeNonInitialized);
         AddObjectProperty("ResidentInitials", gxTv_SdtTrn_Resident_Residentinitials, false, includeNonInitialized);
         AddObjectProperty("ResidentEmail", gxTv_SdtTrn_Resident_Residentemail, false, includeNonInitialized);
         AddObjectProperty("ResidentGender", gxTv_SdtTrn_Resident_Residentgender, false, includeNonInitialized);
         AddObjectProperty("ResidentCountry", gxTv_SdtTrn_Resident_Residentcountry, false, includeNonInitialized);
         AddObjectProperty("ResidentCity", gxTv_SdtTrn_Resident_Residentcity, false, includeNonInitialized);
         AddObjectProperty("ResidentZipCode", gxTv_SdtTrn_Resident_Residentzipcode, false, includeNonInitialized);
         AddObjectProperty("ResidentAddressLine1", gxTv_SdtTrn_Resident_Residentaddressline1, false, includeNonInitialized);
         AddObjectProperty("ResidentAddressLine2", gxTv_SdtTrn_Resident_Residentaddressline2, false, includeNonInitialized);
         AddObjectProperty("ResidentPhone", gxTv_SdtTrn_Resident_Residentphone, false, includeNonInitialized);
         AddObjectProperty("ResidentHomePhone", gxTv_SdtTrn_Resident_Residenthomephone, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_Resident_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_Resident_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_Resident_Residentbirthdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ResidentBirthDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ResidentGUID", gxTv_SdtTrn_Resident_Residentguid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId", gxTv_SdtTrn_Resident_Residenttypeid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_Resident_Residenttypeid_N, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeName", gxTv_SdtTrn_Resident_Residenttypename, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationId", gxTv_SdtTrn_Resident_Medicalindicationid, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_Resident_Medicalindicationid_N, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationName", gxTv_SdtTrn_Resident_Medicalindicationname, false, includeNonInitialized);
         AddObjectProperty("ResidentPhoneCode", gxTv_SdtTrn_Resident_Residentphonecode, false, includeNonInitialized);
         AddObjectProperty("ResidentPhoneNumber", gxTv_SdtTrn_Resident_Residentphonenumber, false, includeNonInitialized);
         AddObjectProperty("ResidentHomePhoneCode", gxTv_SdtTrn_Resident_Residenthomephonecode, false, includeNonInitialized);
         AddObjectProperty("ResidentHomePhoneNumber", gxTv_SdtTrn_Resident_Residenthomephonenumber, false, includeNonInitialized);
         AddObjectProperty("ResidentImage", gxTv_SdtTrn_Resident_Residentimage, false, includeNonInitialized);
         AddObjectProperty("ResidentImage_N", gxTv_SdtTrn_Resident_Residentimage_N, false, includeNonInitialized);
         AddObjectProperty("ResidentLanguage", gxTv_SdtTrn_Resident_Residentlanguage, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageId", gxTv_SdtTrn_Resident_Residentpackageid, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageId_N", gxTv_SdtTrn_Resident_Residentpackageid_N, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageName", gxTv_SdtTrn_Resident_Residentpackagename, false, includeNonInitialized);
         AddObjectProperty("SG_LocationId", gxTv_SdtTrn_Resident_Sg_locationid, false, includeNonInitialized);
         AddObjectProperty("SG_OrganisationId", gxTv_SdtTrn_Resident_Sg_organisationid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ResidentImage_GXI", gxTv_SdtTrn_Resident_Residentimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Resident_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Resident_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentId_Z", gxTv_SdtTrn_Resident_Residentid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Resident_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Resident_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentSalutation_Z", gxTv_SdtTrn_Resident_Residentsalutation_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentBsnNumber_Z", gxTv_SdtTrn_Resident_Residentbsnnumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGivenName_Z", gxTv_SdtTrn_Resident_Residentgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastName_Z", gxTv_SdtTrn_Resident_Residentlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentInitials_Z", gxTv_SdtTrn_Resident_Residentinitials_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentEmail_Z", gxTv_SdtTrn_Resident_Residentemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGender_Z", gxTv_SdtTrn_Resident_Residentgender_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentCountry_Z", gxTv_SdtTrn_Resident_Residentcountry_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentCity_Z", gxTv_SdtTrn_Resident_Residentcity_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentZipCode_Z", gxTv_SdtTrn_Resident_Residentzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentAddressLine1_Z", gxTv_SdtTrn_Resident_Residentaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentAddressLine2_Z", gxTv_SdtTrn_Resident_Residentaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhone_Z", gxTv_SdtTrn_Resident_Residentphone_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentHomePhone_Z", gxTv_SdtTrn_Resident_Residenthomephone_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrn_Resident_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrn_Resident_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrn_Resident_Residentbirthdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ResidentBirthDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ResidentGUID_Z", gxTv_SdtTrn_Resident_Residentguid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_Z", gxTv_SdtTrn_Resident_Residenttypeid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeName_Z", gxTv_SdtTrn_Resident_Residenttypename_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_Z", gxTv_SdtTrn_Resident_Medicalindicationid_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationName_Z", gxTv_SdtTrn_Resident_Medicalindicationname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhoneCode_Z", gxTv_SdtTrn_Resident_Residentphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhoneNumber_Z", gxTv_SdtTrn_Resident_Residentphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentHomePhoneCode_Z", gxTv_SdtTrn_Resident_Residenthomephonecode_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentHomePhoneNumber_Z", gxTv_SdtTrn_Resident_Residenthomephonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLanguage_Z", gxTv_SdtTrn_Resident_Residentlanguage_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageId_Z", gxTv_SdtTrn_Resident_Residentpackageid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageName_Z", gxTv_SdtTrn_Resident_Residentpackagename_Z, false, includeNonInitialized);
            AddObjectProperty("SG_LocationId_Z", gxTv_SdtTrn_Resident_Sg_locationid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_OrganisationId_Z", gxTv_SdtTrn_Resident_Sg_organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentImage_GXI_Z", gxTv_SdtTrn_Resident_Residentimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_Resident_Residenttypeid_N, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_Resident_Medicalindicationid_N, false, includeNonInitialized);
            AddObjectProperty("ResidentImage_N", gxTv_SdtTrn_Resident_Residentimage_N, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageId_N", gxTv_SdtTrn_Resident_Residentpackageid_N, false, includeNonInitialized);
            AddObjectProperty("ResidentImage_GXI_N", gxTv_SdtTrn_Resident_Residentimage_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Resident sdt )
      {
         if ( sdt.IsDirty("ResidentId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentid = sdt.gxTv_SdtTrn_Resident_Residentid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Locationid = sdt.gxTv_SdtTrn_Resident_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Organisationid = sdt.gxTv_SdtTrn_Resident_Organisationid ;
         }
         if ( sdt.IsDirty("ResidentSalutation") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentsalutation = sdt.gxTv_SdtTrn_Resident_Residentsalutation ;
         }
         if ( sdt.IsDirty("ResidentBsnNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbsnnumber = sdt.gxTv_SdtTrn_Resident_Residentbsnnumber ;
         }
         if ( sdt.IsDirty("ResidentGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgivenname = sdt.gxTv_SdtTrn_Resident_Residentgivenname ;
         }
         if ( sdt.IsDirty("ResidentLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlastname = sdt.gxTv_SdtTrn_Resident_Residentlastname ;
         }
         if ( sdt.IsDirty("ResidentInitials") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentinitials = sdt.gxTv_SdtTrn_Resident_Residentinitials ;
         }
         if ( sdt.IsDirty("ResidentEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentemail = sdt.gxTv_SdtTrn_Resident_Residentemail ;
         }
         if ( sdt.IsDirty("ResidentGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgender = sdt.gxTv_SdtTrn_Resident_Residentgender ;
         }
         if ( sdt.IsDirty("ResidentCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcountry = sdt.gxTv_SdtTrn_Resident_Residentcountry ;
         }
         if ( sdt.IsDirty("ResidentCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcity = sdt.gxTv_SdtTrn_Resident_Residentcity ;
         }
         if ( sdt.IsDirty("ResidentZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentzipcode = sdt.gxTv_SdtTrn_Resident_Residentzipcode ;
         }
         if ( sdt.IsDirty("ResidentAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline1 = sdt.gxTv_SdtTrn_Resident_Residentaddressline1 ;
         }
         if ( sdt.IsDirty("ResidentAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline2 = sdt.gxTv_SdtTrn_Resident_Residentaddressline2 ;
         }
         if ( sdt.IsDirty("ResidentPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphone = sdt.gxTv_SdtTrn_Resident_Residentphone ;
         }
         if ( sdt.IsDirty("ResidentHomePhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephone = sdt.gxTv_SdtTrn_Resident_Residenthomephone ;
         }
         if ( sdt.IsDirty("ResidentBirthDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbirthdate = sdt.gxTv_SdtTrn_Resident_Residentbirthdate ;
         }
         if ( sdt.IsDirty("ResidentGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentguid = sdt.gxTv_SdtTrn_Resident_Residentguid ;
         }
         if ( sdt.IsDirty("ResidentTypeId") )
         {
            gxTv_SdtTrn_Resident_Residenttypeid_N = (short)(sdt.gxTv_SdtTrn_Resident_Residenttypeid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypeid = sdt.gxTv_SdtTrn_Resident_Residenttypeid ;
         }
         if ( sdt.IsDirty("ResidentTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypename = sdt.gxTv_SdtTrn_Resident_Residenttypename ;
         }
         if ( sdt.IsDirty("MedicalIndicationId") )
         {
            gxTv_SdtTrn_Resident_Medicalindicationid_N = (short)(sdt.gxTv_SdtTrn_Resident_Medicalindicationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationid = sdt.gxTv_SdtTrn_Resident_Medicalindicationid ;
         }
         if ( sdt.IsDirty("MedicalIndicationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationname = sdt.gxTv_SdtTrn_Resident_Medicalindicationname ;
         }
         if ( sdt.IsDirty("ResidentPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonecode = sdt.gxTv_SdtTrn_Resident_Residentphonecode ;
         }
         if ( sdt.IsDirty("ResidentPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonenumber = sdt.gxTv_SdtTrn_Resident_Residentphonenumber ;
         }
         if ( sdt.IsDirty("ResidentHomePhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonecode = sdt.gxTv_SdtTrn_Resident_Residenthomephonecode ;
         }
         if ( sdt.IsDirty("ResidentHomePhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonenumber = sdt.gxTv_SdtTrn_Resident_Residenthomephonenumber ;
         }
         if ( sdt.IsDirty("ResidentImage") )
         {
            gxTv_SdtTrn_Resident_Residentimage_N = (short)(sdt.gxTv_SdtTrn_Resident_Residentimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage = sdt.gxTv_SdtTrn_Resident_Residentimage ;
         }
         if ( sdt.IsDirty("ResidentImage") )
         {
            gxTv_SdtTrn_Resident_Residentimage_gxi_N = (short)(sdt.gxTv_SdtTrn_Resident_Residentimage_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage_gxi = sdt.gxTv_SdtTrn_Resident_Residentimage_gxi ;
         }
         if ( sdt.IsDirty("ResidentLanguage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlanguage = sdt.gxTv_SdtTrn_Resident_Residentlanguage ;
         }
         if ( sdt.IsDirty("ResidentPackageId") )
         {
            gxTv_SdtTrn_Resident_Residentpackageid_N = (short)(sdt.gxTv_SdtTrn_Resident_Residentpackageid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackageid = sdt.gxTv_SdtTrn_Resident_Residentpackageid ;
         }
         if ( sdt.IsDirty("ResidentPackageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackagename = sdt.gxTv_SdtTrn_Resident_Residentpackagename ;
         }
         if ( sdt.IsDirty("SG_LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_locationid = sdt.gxTv_SdtTrn_Resident_Sg_locationid ;
         }
         if ( sdt.IsDirty("SG_OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_organisationid = sdt.gxTv_SdtTrn_Resident_Sg_organisationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentId" )]
      [  XmlElement( ElementName = "ResidentId"   )]
      public Guid gxTpr_Residentid
      {
         get {
            return gxTv_SdtTrn_Resident_Residentid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Resident_Residentid != value )
            {
               gxTv_SdtTrn_Resident_Mode = "INS";
               this.gxTv_SdtTrn_Resident_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentemail_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgender_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcity_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbirthdate_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlanguage_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackageid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackagename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Resident_Residentid = value;
            SetDirty("Residentid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Resident_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Resident_Locationid != value )
            {
               gxTv_SdtTrn_Resident_Mode = "INS";
               this.gxTv_SdtTrn_Resident_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentemail_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgender_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcity_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbirthdate_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlanguage_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackageid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackagename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Resident_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Resident_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Resident_Organisationid != value )
            {
               gxTv_SdtTrn_Resident_Mode = "INS";
               this.gxTv_SdtTrn_Resident_Residentid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentsalutation_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentemail_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentgender_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentcity_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephone_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentbirthdate_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentguid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenttypename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Medicalindicationname_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residenthomephonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentlanguage_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackageid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentpackagename_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Sg_organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Resident_Residentimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Resident_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "ResidentSalutation" )]
      [  XmlElement( ElementName = "ResidentSalutation"   )]
      public string gxTpr_Residentsalutation
      {
         get {
            return gxTv_SdtTrn_Resident_Residentsalutation ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentsalutation = value;
            SetDirty("Residentsalutation");
         }

      }

      [  SoapElement( ElementName = "ResidentBsnNumber" )]
      [  XmlElement( ElementName = "ResidentBsnNumber"   )]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return gxTv_SdtTrn_Resident_Residentbsnnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbsnnumber = value;
            SetDirty("Residentbsnnumber");
         }

      }

      [  SoapElement( ElementName = "ResidentGivenName" )]
      [  XmlElement( ElementName = "ResidentGivenName"   )]
      public string gxTpr_Residentgivenname
      {
         get {
            return gxTv_SdtTrn_Resident_Residentgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgivenname = value;
            SetDirty("Residentgivenname");
         }

      }

      [  SoapElement( ElementName = "ResidentLastName" )]
      [  XmlElement( ElementName = "ResidentLastName"   )]
      public string gxTpr_Residentlastname
      {
         get {
            return gxTv_SdtTrn_Resident_Residentlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlastname = value;
            SetDirty("Residentlastname");
         }

      }

      [  SoapElement( ElementName = "ResidentInitials" )]
      [  XmlElement( ElementName = "ResidentInitials"   )]
      public string gxTpr_Residentinitials
      {
         get {
            return gxTv_SdtTrn_Resident_Residentinitials ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentinitials = value;
            SetDirty("Residentinitials");
         }

      }

      [  SoapElement( ElementName = "ResidentEmail" )]
      [  XmlElement( ElementName = "ResidentEmail"   )]
      public string gxTpr_Residentemail
      {
         get {
            return gxTv_SdtTrn_Resident_Residentemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentemail = value;
            SetDirty("Residentemail");
         }

      }

      [  SoapElement( ElementName = "ResidentGender" )]
      [  XmlElement( ElementName = "ResidentGender"   )]
      public string gxTpr_Residentgender
      {
         get {
            return gxTv_SdtTrn_Resident_Residentgender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgender = value;
            SetDirty("Residentgender");
         }

      }

      [  SoapElement( ElementName = "ResidentCountry" )]
      [  XmlElement( ElementName = "ResidentCountry"   )]
      public string gxTpr_Residentcountry
      {
         get {
            return gxTv_SdtTrn_Resident_Residentcountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcountry = value;
            SetDirty("Residentcountry");
         }

      }

      [  SoapElement( ElementName = "ResidentCity" )]
      [  XmlElement( ElementName = "ResidentCity"   )]
      public string gxTpr_Residentcity
      {
         get {
            return gxTv_SdtTrn_Resident_Residentcity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcity = value;
            SetDirty("Residentcity");
         }

      }

      [  SoapElement( ElementName = "ResidentZipCode" )]
      [  XmlElement( ElementName = "ResidentZipCode"   )]
      public string gxTpr_Residentzipcode
      {
         get {
            return gxTv_SdtTrn_Resident_Residentzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentzipcode = value;
            SetDirty("Residentzipcode");
         }

      }

      [  SoapElement( ElementName = "ResidentAddressLine1" )]
      [  XmlElement( ElementName = "ResidentAddressLine1"   )]
      public string gxTpr_Residentaddressline1
      {
         get {
            return gxTv_SdtTrn_Resident_Residentaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline1 = value;
            SetDirty("Residentaddressline1");
         }

      }

      [  SoapElement( ElementName = "ResidentAddressLine2" )]
      [  XmlElement( ElementName = "ResidentAddressLine2"   )]
      public string gxTpr_Residentaddressline2
      {
         get {
            return gxTv_SdtTrn_Resident_Residentaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline2 = value;
            SetDirty("Residentaddressline2");
         }

      }

      [  SoapElement( ElementName = "ResidentPhone" )]
      [  XmlElement( ElementName = "ResidentPhone"   )]
      public string gxTpr_Residentphone
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphone = value;
            SetDirty("Residentphone");
         }

      }

      [  SoapElement( ElementName = "ResidentHomePhone" )]
      [  XmlElement( ElementName = "ResidentHomePhone"   )]
      public string gxTpr_Residenthomephone
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephone = value;
            SetDirty("Residenthomephone");
         }

      }

      [  SoapElement( ElementName = "ResidentBirthDate" )]
      [  XmlElement( ElementName = "ResidentBirthDate"  , IsNullable=true )]
      public string gxTpr_Residentbirthdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Resident_Residentbirthdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_Resident_Residentbirthdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_Resident_Residentbirthdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_Resident_Residentbirthdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Residentbirthdate
      {
         get {
            return gxTv_SdtTrn_Resident_Residentbirthdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbirthdate = value;
            SetDirty("Residentbirthdate");
         }

      }

      [  SoapElement( ElementName = "ResidentGUID" )]
      [  XmlElement( ElementName = "ResidentGUID"   )]
      public string gxTpr_Residentguid
      {
         get {
            return gxTv_SdtTrn_Resident_Residentguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentguid = value;
            SetDirty("Residentguid");
         }

      }

      [  SoapElement( ElementName = "ResidentTypeId" )]
      [  XmlElement( ElementName = "ResidentTypeId"   )]
      public Guid gxTpr_Residenttypeid
      {
         get {
            return gxTv_SdtTrn_Resident_Residenttypeid ;
         }

         set {
            gxTv_SdtTrn_Resident_Residenttypeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypeid = value;
            SetDirty("Residenttypeid");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenttypeid_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenttypeid_N = 1;
         gxTv_SdtTrn_Resident_Residenttypeid = Guid.Empty;
         SetDirty("Residenttypeid");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenttypeid_IsNull( )
      {
         return (gxTv_SdtTrn_Resident_Residenttypeid_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentTypeName" )]
      [  XmlElement( ElementName = "ResidentTypeName"   )]
      public string gxTpr_Residenttypename
      {
         get {
            return gxTv_SdtTrn_Resident_Residenttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypename = value;
            SetDirty("Residenttypename");
         }

      }

      [  SoapElement( ElementName = "MedicalIndicationId" )]
      [  XmlElement( ElementName = "MedicalIndicationId"   )]
      public Guid gxTpr_Medicalindicationid
      {
         get {
            return gxTv_SdtTrn_Resident_Medicalindicationid ;
         }

         set {
            gxTv_SdtTrn_Resident_Medicalindicationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationid = value;
            SetDirty("Medicalindicationid");
         }

      }

      public void gxTv_SdtTrn_Resident_Medicalindicationid_SetNull( )
      {
         gxTv_SdtTrn_Resident_Medicalindicationid_N = 1;
         gxTv_SdtTrn_Resident_Medicalindicationid = Guid.Empty;
         SetDirty("Medicalindicationid");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Medicalindicationid_IsNull( )
      {
         return (gxTv_SdtTrn_Resident_Medicalindicationid_N==1) ;
      }

      [  SoapElement( ElementName = "MedicalIndicationName" )]
      [  XmlElement( ElementName = "MedicalIndicationName"   )]
      public string gxTpr_Medicalindicationname
      {
         get {
            return gxTv_SdtTrn_Resident_Medicalindicationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationname = value;
            SetDirty("Medicalindicationname");
         }

      }

      [  SoapElement( ElementName = "ResidentPhoneCode" )]
      [  XmlElement( ElementName = "ResidentPhoneCode"   )]
      public string gxTpr_Residentphonecode
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonecode = value;
            SetDirty("Residentphonecode");
         }

      }

      [  SoapElement( ElementName = "ResidentPhoneNumber" )]
      [  XmlElement( ElementName = "ResidentPhoneNumber"   )]
      public string gxTpr_Residentphonenumber
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonenumber = value;
            SetDirty("Residentphonenumber");
         }

      }

      [  SoapElement( ElementName = "ResidentHomePhoneCode" )]
      [  XmlElement( ElementName = "ResidentHomePhoneCode"   )]
      public string gxTpr_Residenthomephonecode
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonecode = value;
            SetDirty("Residenthomephonecode");
         }

      }

      [  SoapElement( ElementName = "ResidentHomePhoneNumber" )]
      [  XmlElement( ElementName = "ResidentHomePhoneNumber"   )]
      public string gxTpr_Residenthomephonenumber
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonenumber = value;
            SetDirty("Residenthomephonenumber");
         }

      }

      [  SoapElement( ElementName = "ResidentImage" )]
      [  XmlElement( ElementName = "ResidentImage"   )]
      [GxUpload()]
      public string gxTpr_Residentimage
      {
         get {
            return gxTv_SdtTrn_Resident_Residentimage ;
         }

         set {
            gxTv_SdtTrn_Resident_Residentimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage = value;
            SetDirty("Residentimage");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentimage_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentimage_N = 1;
         gxTv_SdtTrn_Resident_Residentimage = "";
         SetDirty("Residentimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentimage_IsNull( )
      {
         return (gxTv_SdtTrn_Resident_Residentimage_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentImage_GXI" )]
      [  XmlElement( ElementName = "ResidentImage_GXI"   )]
      public string gxTpr_Residentimage_gxi
      {
         get {
            return gxTv_SdtTrn_Resident_Residentimage_gxi ;
         }

         set {
            gxTv_SdtTrn_Resident_Residentimage_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage_gxi = value;
            SetDirty("Residentimage_gxi");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentimage_gxi_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentimage_gxi_N = 1;
         gxTv_SdtTrn_Resident_Residentimage_gxi = "";
         SetDirty("Residentimage_gxi");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentimage_gxi_IsNull( )
      {
         return (gxTv_SdtTrn_Resident_Residentimage_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentLanguage" )]
      [  XmlElement( ElementName = "ResidentLanguage"   )]
      public string gxTpr_Residentlanguage
      {
         get {
            return gxTv_SdtTrn_Resident_Residentlanguage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlanguage = value;
            SetDirty("Residentlanguage");
         }

      }

      [  SoapElement( ElementName = "ResidentPackageId" )]
      [  XmlElement( ElementName = "ResidentPackageId"   )]
      public Guid gxTpr_Residentpackageid
      {
         get {
            return gxTv_SdtTrn_Resident_Residentpackageid ;
         }

         set {
            gxTv_SdtTrn_Resident_Residentpackageid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackageid = value;
            SetDirty("Residentpackageid");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentpackageid_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentpackageid_N = 1;
         gxTv_SdtTrn_Resident_Residentpackageid = Guid.Empty;
         SetDirty("Residentpackageid");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentpackageid_IsNull( )
      {
         return (gxTv_SdtTrn_Resident_Residentpackageid_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentPackageName" )]
      [  XmlElement( ElementName = "ResidentPackageName"   )]
      public string gxTpr_Residentpackagename
      {
         get {
            return gxTv_SdtTrn_Resident_Residentpackagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackagename = value;
            SetDirty("Residentpackagename");
         }

      }

      [  SoapElement( ElementName = "SG_LocationId" )]
      [  XmlElement( ElementName = "SG_LocationId"   )]
      public Guid gxTpr_Sg_locationid
      {
         get {
            return gxTv_SdtTrn_Resident_Sg_locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_locationid = value;
            SetDirty("Sg_locationid");
         }

      }

      [  SoapElement( ElementName = "SG_OrganisationId" )]
      [  XmlElement( ElementName = "SG_OrganisationId"   )]
      public Guid gxTpr_Sg_organisationid
      {
         get {
            return gxTv_SdtTrn_Resident_Sg_organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_organisationid = value;
            SetDirty("Sg_organisationid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Resident_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Resident_Mode_SetNull( )
      {
         gxTv_SdtTrn_Resident_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Resident_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Resident_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Resident_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentId_Z" )]
      [  XmlElement( ElementName = "ResidentId_Z"   )]
      public Guid gxTpr_Residentid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentid_Z = value;
            SetDirty("Residentid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentid_Z = Guid.Empty;
         SetDirty("Residentid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentSalutation_Z" )]
      [  XmlElement( ElementName = "ResidentSalutation_Z"   )]
      public string gxTpr_Residentsalutation_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentsalutation_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentsalutation_Z = value;
            SetDirty("Residentsalutation_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentsalutation_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentsalutation_Z = "";
         SetDirty("Residentsalutation_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentsalutation_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentBsnNumber_Z" )]
      [  XmlElement( ElementName = "ResidentBsnNumber_Z"   )]
      public string gxTpr_Residentbsnnumber_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentbsnnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbsnnumber_Z = value;
            SetDirty("Residentbsnnumber_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentbsnnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentbsnnumber_Z = "";
         SetDirty("Residentbsnnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentbsnnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGivenName_Z" )]
      [  XmlElement( ElementName = "ResidentGivenName_Z"   )]
      public string gxTpr_Residentgivenname_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgivenname_Z = value;
            SetDirty("Residentgivenname_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentgivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentgivenname_Z = "";
         SetDirty("Residentgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastName_Z" )]
      [  XmlElement( ElementName = "ResidentLastName_Z"   )]
      public string gxTpr_Residentlastname_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlastname_Z = value;
            SetDirty("Residentlastname_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentlastname_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentlastname_Z = "";
         SetDirty("Residentlastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentInitials_Z" )]
      [  XmlElement( ElementName = "ResidentInitials_Z"   )]
      public string gxTpr_Residentinitials_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentinitials_Z = value;
            SetDirty("Residentinitials_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentinitials_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentinitials_Z = "";
         SetDirty("Residentinitials_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentEmail_Z" )]
      [  XmlElement( ElementName = "ResidentEmail_Z"   )]
      public string gxTpr_Residentemail_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentemail_Z = value;
            SetDirty("Residentemail_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentemail_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentemail_Z = "";
         SetDirty("Residentemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGender_Z" )]
      [  XmlElement( ElementName = "ResidentGender_Z"   )]
      public string gxTpr_Residentgender_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentgender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentgender_Z = value;
            SetDirty("Residentgender_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentgender_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentgender_Z = "";
         SetDirty("Residentgender_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentgender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentCountry_Z" )]
      [  XmlElement( ElementName = "ResidentCountry_Z"   )]
      public string gxTpr_Residentcountry_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentcountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcountry_Z = value;
            SetDirty("Residentcountry_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentcountry_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentcountry_Z = "";
         SetDirty("Residentcountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentcountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentCity_Z" )]
      [  XmlElement( ElementName = "ResidentCity_Z"   )]
      public string gxTpr_Residentcity_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentcity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentcity_Z = value;
            SetDirty("Residentcity_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentcity_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentcity_Z = "";
         SetDirty("Residentcity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentcity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentZipCode_Z" )]
      [  XmlElement( ElementName = "ResidentZipCode_Z"   )]
      public string gxTpr_Residentzipcode_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentzipcode_Z = value;
            SetDirty("Residentzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentzipcode_Z = "";
         SetDirty("Residentzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddressLine1_Z" )]
      [  XmlElement( ElementName = "ResidentAddressLine1_Z"   )]
      public string gxTpr_Residentaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline1_Z = value;
            SetDirty("Residentaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentaddressline1_Z = "";
         SetDirty("Residentaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddressLine2_Z" )]
      [  XmlElement( ElementName = "ResidentAddressLine2_Z"   )]
      public string gxTpr_Residentaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentaddressline2_Z = value;
            SetDirty("Residentaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentaddressline2_Z = "";
         SetDirty("Residentaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhone_Z" )]
      [  XmlElement( ElementName = "ResidentPhone_Z"   )]
      public string gxTpr_Residentphone_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphone_Z = value;
            SetDirty("Residentphone_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentphone_Z = "";
         SetDirty("Residentphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentHomePhone_Z" )]
      [  XmlElement( ElementName = "ResidentHomePhone_Z"   )]
      public string gxTpr_Residenthomephone_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephone_Z = value;
            SetDirty("Residenthomephone_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenthomephone_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenthomephone_Z = "";
         SetDirty("Residenthomephone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenthomephone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentBirthDate_Z" )]
      [  XmlElement( ElementName = "ResidentBirthDate_Z"  , IsNullable=true )]
      public string gxTpr_Residentbirthdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Resident_Residentbirthdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrn_Resident_Residentbirthdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrn_Resident_Residentbirthdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Resident_Residentbirthdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Residentbirthdate_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentbirthdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentbirthdate_Z = value;
            SetDirty("Residentbirthdate_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentbirthdate_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentbirthdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Residentbirthdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentbirthdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGUID_Z" )]
      [  XmlElement( ElementName = "ResidentGUID_Z"   )]
      public string gxTpr_Residentguid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentguid_Z = value;
            SetDirty("Residentguid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentguid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentguid_Z = "";
         SetDirty("Residentguid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_Z" )]
      [  XmlElement( ElementName = "ResidentTypeId_Z"   )]
      public Guid gxTpr_Residenttypeid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residenttypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypeid_Z = value;
            SetDirty("Residenttypeid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenttypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenttypeid_Z = Guid.Empty;
         SetDirty("Residenttypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenttypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeName_Z" )]
      [  XmlElement( ElementName = "ResidentTypeName_Z"   )]
      public string gxTpr_Residenttypename_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residenttypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypename_Z = value;
            SetDirty("Residenttypename_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenttypename_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenttypename_Z = "";
         SetDirty("Residenttypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenttypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationId_Z"   )]
      public Guid gxTpr_Medicalindicationid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Medicalindicationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationid_Z = value;
            SetDirty("Medicalindicationid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Medicalindicationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Medicalindicationid_Z = Guid.Empty;
         SetDirty("Medicalindicationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Medicalindicationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationName_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationName_Z"   )]
      public string gxTpr_Medicalindicationname_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Medicalindicationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationname_Z = value;
            SetDirty("Medicalindicationname_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Medicalindicationname_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Medicalindicationname_Z = "";
         SetDirty("Medicalindicationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Medicalindicationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhoneCode_Z" )]
      [  XmlElement( ElementName = "ResidentPhoneCode_Z"   )]
      public string gxTpr_Residentphonecode_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonecode_Z = value;
            SetDirty("Residentphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentphonecode_Z = "";
         SetDirty("Residentphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhoneNumber_Z" )]
      [  XmlElement( ElementName = "ResidentPhoneNumber_Z"   )]
      public string gxTpr_Residentphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentphonenumber_Z = value;
            SetDirty("Residentphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentphonenumber_Z = "";
         SetDirty("Residentphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentHomePhoneCode_Z" )]
      [  XmlElement( ElementName = "ResidentHomePhoneCode_Z"   )]
      public string gxTpr_Residenthomephonecode_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonecode_Z = value;
            SetDirty("Residenthomephonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenthomephonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenthomephonecode_Z = "";
         SetDirty("Residenthomephonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenthomephonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentHomePhoneNumber_Z" )]
      [  XmlElement( ElementName = "ResidentHomePhoneNumber_Z"   )]
      public string gxTpr_Residenthomephonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residenthomephonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenthomephonenumber_Z = value;
            SetDirty("Residenthomephonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenthomephonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenthomephonenumber_Z = "";
         SetDirty("Residenthomephonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenthomephonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLanguage_Z" )]
      [  XmlElement( ElementName = "ResidentLanguage_Z"   )]
      public string gxTpr_Residentlanguage_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentlanguage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentlanguage_Z = value;
            SetDirty("Residentlanguage_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentlanguage_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentlanguage_Z = "";
         SetDirty("Residentlanguage_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentlanguage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageId_Z" )]
      [  XmlElement( ElementName = "ResidentPackageId_Z"   )]
      public Guid gxTpr_Residentpackageid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentpackageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackageid_Z = value;
            SetDirty("Residentpackageid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentpackageid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentpackageid_Z = Guid.Empty;
         SetDirty("Residentpackageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentpackageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageName_Z" )]
      [  XmlElement( ElementName = "ResidentPackageName_Z"   )]
      public string gxTpr_Residentpackagename_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentpackagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackagename_Z = value;
            SetDirty("Residentpackagename_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentpackagename_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentpackagename_Z = "";
         SetDirty("Residentpackagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentpackagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationId_Z" )]
      [  XmlElement( ElementName = "SG_LocationId_Z"   )]
      public Guid gxTpr_Sg_locationid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Sg_locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_locationid_Z = value;
            SetDirty("Sg_locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Sg_locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Sg_locationid_Z = Guid.Empty;
         SetDirty("Sg_locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Sg_locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_OrganisationId_Z" )]
      [  XmlElement( ElementName = "SG_OrganisationId_Z"   )]
      public Guid gxTpr_Sg_organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Sg_organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Sg_organisationid_Z = value;
            SetDirty("Sg_organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Sg_organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Sg_organisationid_Z = Guid.Empty;
         SetDirty("Sg_organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Sg_organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentImage_GXI_Z" )]
      [  XmlElement( ElementName = "ResidentImage_GXI_Z"   )]
      public string gxTpr_Residentimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Resident_Residentimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage_gxi_Z = value;
            SetDirty("Residentimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentimage_gxi_Z = "";
         SetDirty("Residentimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_N" )]
      [  XmlElement( ElementName = "ResidentTypeId_N"   )]
      public short gxTpr_Residenttypeid_N
      {
         get {
            return gxTv_SdtTrn_Resident_Residenttypeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residenttypeid_N = value;
            SetDirty("Residenttypeid_N");
         }

      }

      public void gxTv_SdtTrn_Resident_Residenttypeid_N_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residenttypeid_N = 0;
         SetDirty("Residenttypeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residenttypeid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_N" )]
      [  XmlElement( ElementName = "MedicalIndicationId_N"   )]
      public short gxTpr_Medicalindicationid_N
      {
         get {
            return gxTv_SdtTrn_Resident_Medicalindicationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Medicalindicationid_N = value;
            SetDirty("Medicalindicationid_N");
         }

      }

      public void gxTv_SdtTrn_Resident_Medicalindicationid_N_SetNull( )
      {
         gxTv_SdtTrn_Resident_Medicalindicationid_N = 0;
         SetDirty("Medicalindicationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Medicalindicationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentImage_N" )]
      [  XmlElement( ElementName = "ResidentImage_N"   )]
      public short gxTpr_Residentimage_N
      {
         get {
            return gxTv_SdtTrn_Resident_Residentimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage_N = value;
            SetDirty("Residentimage_N");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentimage_N_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentimage_N = 0;
         SetDirty("Residentimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageId_N" )]
      [  XmlElement( ElementName = "ResidentPackageId_N"   )]
      public short gxTpr_Residentpackageid_N
      {
         get {
            return gxTv_SdtTrn_Resident_Residentpackageid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentpackageid_N = value;
            SetDirty("Residentpackageid_N");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentpackageid_N_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentpackageid_N = 0;
         SetDirty("Residentpackageid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentpackageid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentImage_GXI_N" )]
      [  XmlElement( ElementName = "ResidentImage_GXI_N"   )]
      public short gxTpr_Residentimage_gxi_N
      {
         get {
            return gxTv_SdtTrn_Resident_Residentimage_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Resident_Residentimage_gxi_N = value;
            SetDirty("Residentimage_gxi_N");
         }

      }

      public void gxTv_SdtTrn_Resident_Residentimage_gxi_N_SetNull( )
      {
         gxTv_SdtTrn_Resident_Residentimage_gxi_N = 0;
         SetDirty("Residentimage_gxi_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Resident_Residentimage_gxi_N_IsNull( )
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
         gxTv_SdtTrn_Resident_Residentid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Resident_Locationid = Guid.Empty;
         gxTv_SdtTrn_Resident_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Resident_Residentsalutation = "";
         gxTv_SdtTrn_Resident_Residentbsnnumber = "";
         gxTv_SdtTrn_Resident_Residentgivenname = "";
         gxTv_SdtTrn_Resident_Residentlastname = "";
         gxTv_SdtTrn_Resident_Residentinitials = "";
         gxTv_SdtTrn_Resident_Residentemail = "";
         gxTv_SdtTrn_Resident_Residentgender = "";
         gxTv_SdtTrn_Resident_Residentcountry = "";
         gxTv_SdtTrn_Resident_Residentcity = "";
         gxTv_SdtTrn_Resident_Residentzipcode = "";
         gxTv_SdtTrn_Resident_Residentaddressline1 = "";
         gxTv_SdtTrn_Resident_Residentaddressline2 = "";
         gxTv_SdtTrn_Resident_Residentphone = "";
         gxTv_SdtTrn_Resident_Residenthomephone = "";
         gxTv_SdtTrn_Resident_Residentbirthdate = DateTime.MinValue;
         gxTv_SdtTrn_Resident_Residentguid = "";
         gxTv_SdtTrn_Resident_Residenttypeid = Guid.Empty;
         gxTv_SdtTrn_Resident_Residenttypename = "";
         gxTv_SdtTrn_Resident_Medicalindicationid = Guid.Empty;
         gxTv_SdtTrn_Resident_Medicalindicationname = "";
         gxTv_SdtTrn_Resident_Residentphonecode = "";
         gxTv_SdtTrn_Resident_Residentphonenumber = "";
         gxTv_SdtTrn_Resident_Residenthomephonecode = "";
         gxTv_SdtTrn_Resident_Residenthomephonenumber = "";
         gxTv_SdtTrn_Resident_Residentimage = "";
         gxTv_SdtTrn_Resident_Residentimage_gxi = "";
         gxTv_SdtTrn_Resident_Residentlanguage = "";
         gxTv_SdtTrn_Resident_Residentpackageid = Guid.Empty;
         gxTv_SdtTrn_Resident_Residentpackagename = "";
         gxTv_SdtTrn_Resident_Sg_locationid = Guid.Empty;
         gxTv_SdtTrn_Resident_Sg_organisationid = Guid.Empty;
         gxTv_SdtTrn_Resident_Mode = "";
         gxTv_SdtTrn_Resident_Residentid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Residentsalutation_Z = "";
         gxTv_SdtTrn_Resident_Residentbsnnumber_Z = "";
         gxTv_SdtTrn_Resident_Residentgivenname_Z = "";
         gxTv_SdtTrn_Resident_Residentlastname_Z = "";
         gxTv_SdtTrn_Resident_Residentinitials_Z = "";
         gxTv_SdtTrn_Resident_Residentemail_Z = "";
         gxTv_SdtTrn_Resident_Residentgender_Z = "";
         gxTv_SdtTrn_Resident_Residentcountry_Z = "";
         gxTv_SdtTrn_Resident_Residentcity_Z = "";
         gxTv_SdtTrn_Resident_Residentzipcode_Z = "";
         gxTv_SdtTrn_Resident_Residentaddressline1_Z = "";
         gxTv_SdtTrn_Resident_Residentaddressline2_Z = "";
         gxTv_SdtTrn_Resident_Residentphone_Z = "";
         gxTv_SdtTrn_Resident_Residenthomephone_Z = "";
         gxTv_SdtTrn_Resident_Residentbirthdate_Z = DateTime.MinValue;
         gxTv_SdtTrn_Resident_Residentguid_Z = "";
         gxTv_SdtTrn_Resident_Residenttypeid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Residenttypename_Z = "";
         gxTv_SdtTrn_Resident_Medicalindicationid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Medicalindicationname_Z = "";
         gxTv_SdtTrn_Resident_Residentphonecode_Z = "";
         gxTv_SdtTrn_Resident_Residentphonenumber_Z = "";
         gxTv_SdtTrn_Resident_Residenthomephonecode_Z = "";
         gxTv_SdtTrn_Resident_Residenthomephonenumber_Z = "";
         gxTv_SdtTrn_Resident_Residentlanguage_Z = "";
         gxTv_SdtTrn_Resident_Residentpackageid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Residentpackagename_Z = "";
         gxTv_SdtTrn_Resident_Sg_locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Sg_organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Resident_Residentimage_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_resident", "GeneXus.Programs.trn_resident_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Resident_Initialized ;
      private short gxTv_SdtTrn_Resident_Residenttypeid_N ;
      private short gxTv_SdtTrn_Resident_Medicalindicationid_N ;
      private short gxTv_SdtTrn_Resident_Residentimage_N ;
      private short gxTv_SdtTrn_Resident_Residentpackageid_N ;
      private short gxTv_SdtTrn_Resident_Residentimage_gxi_N ;
      private string gxTv_SdtTrn_Resident_Residentsalutation ;
      private string gxTv_SdtTrn_Resident_Residentinitials ;
      private string gxTv_SdtTrn_Resident_Residentphone ;
      private string gxTv_SdtTrn_Resident_Residenthomephone ;
      private string gxTv_SdtTrn_Resident_Residentlanguage ;
      private string gxTv_SdtTrn_Resident_Mode ;
      private string gxTv_SdtTrn_Resident_Residentsalutation_Z ;
      private string gxTv_SdtTrn_Resident_Residentinitials_Z ;
      private string gxTv_SdtTrn_Resident_Residentphone_Z ;
      private string gxTv_SdtTrn_Resident_Residenthomephone_Z ;
      private string gxTv_SdtTrn_Resident_Residentlanguage_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_Resident_Residentbirthdate ;
      private DateTime gxTv_SdtTrn_Resident_Residentbirthdate_Z ;
      private string gxTv_SdtTrn_Resident_Residentbsnnumber ;
      private string gxTv_SdtTrn_Resident_Residentgivenname ;
      private string gxTv_SdtTrn_Resident_Residentlastname ;
      private string gxTv_SdtTrn_Resident_Residentemail ;
      private string gxTv_SdtTrn_Resident_Residentgender ;
      private string gxTv_SdtTrn_Resident_Residentcountry ;
      private string gxTv_SdtTrn_Resident_Residentcity ;
      private string gxTv_SdtTrn_Resident_Residentzipcode ;
      private string gxTv_SdtTrn_Resident_Residentaddressline1 ;
      private string gxTv_SdtTrn_Resident_Residentaddressline2 ;
      private string gxTv_SdtTrn_Resident_Residentguid ;
      private string gxTv_SdtTrn_Resident_Residenttypename ;
      private string gxTv_SdtTrn_Resident_Medicalindicationname ;
      private string gxTv_SdtTrn_Resident_Residentphonecode ;
      private string gxTv_SdtTrn_Resident_Residentphonenumber ;
      private string gxTv_SdtTrn_Resident_Residenthomephonecode ;
      private string gxTv_SdtTrn_Resident_Residenthomephonenumber ;
      private string gxTv_SdtTrn_Resident_Residentimage_gxi ;
      private string gxTv_SdtTrn_Resident_Residentpackagename ;
      private string gxTv_SdtTrn_Resident_Residentbsnnumber_Z ;
      private string gxTv_SdtTrn_Resident_Residentgivenname_Z ;
      private string gxTv_SdtTrn_Resident_Residentlastname_Z ;
      private string gxTv_SdtTrn_Resident_Residentemail_Z ;
      private string gxTv_SdtTrn_Resident_Residentgender_Z ;
      private string gxTv_SdtTrn_Resident_Residentcountry_Z ;
      private string gxTv_SdtTrn_Resident_Residentcity_Z ;
      private string gxTv_SdtTrn_Resident_Residentzipcode_Z ;
      private string gxTv_SdtTrn_Resident_Residentaddressline1_Z ;
      private string gxTv_SdtTrn_Resident_Residentaddressline2_Z ;
      private string gxTv_SdtTrn_Resident_Residentguid_Z ;
      private string gxTv_SdtTrn_Resident_Residenttypename_Z ;
      private string gxTv_SdtTrn_Resident_Medicalindicationname_Z ;
      private string gxTv_SdtTrn_Resident_Residentphonecode_Z ;
      private string gxTv_SdtTrn_Resident_Residentphonenumber_Z ;
      private string gxTv_SdtTrn_Resident_Residenthomephonecode_Z ;
      private string gxTv_SdtTrn_Resident_Residenthomephonenumber_Z ;
      private string gxTv_SdtTrn_Resident_Residentpackagename_Z ;
      private string gxTv_SdtTrn_Resident_Residentimage_gxi_Z ;
      private string gxTv_SdtTrn_Resident_Residentimage ;
      private Guid gxTv_SdtTrn_Resident_Residentid ;
      private Guid gxTv_SdtTrn_Resident_Locationid ;
      private Guid gxTv_SdtTrn_Resident_Organisationid ;
      private Guid gxTv_SdtTrn_Resident_Residenttypeid ;
      private Guid gxTv_SdtTrn_Resident_Medicalindicationid ;
      private Guid gxTv_SdtTrn_Resident_Residentpackageid ;
      private Guid gxTv_SdtTrn_Resident_Sg_locationid ;
      private Guid gxTv_SdtTrn_Resident_Sg_organisationid ;
      private Guid gxTv_SdtTrn_Resident_Residentid_Z ;
      private Guid gxTv_SdtTrn_Resident_Locationid_Z ;
      private Guid gxTv_SdtTrn_Resident_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Resident_Residenttypeid_Z ;
      private Guid gxTv_SdtTrn_Resident_Medicalindicationid_Z ;
      private Guid gxTv_SdtTrn_Resident_Residentpackageid_Z ;
      private Guid gxTv_SdtTrn_Resident_Sg_locationid_Z ;
      private Guid gxTv_SdtTrn_Resident_Sg_organisationid_Z ;
   }

   [DataContract(Name = @"Trn_Resident", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Resident_RESTInterface : GxGenericCollectionItem<SdtTrn_Resident>
   {
      public SdtTrn_Resident_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Resident_RESTInterface( SdtTrn_Resident psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentId" , Order = 0 )]
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

      [DataMember( Name = "LocationId" , Order = 1 )]
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

      [DataMember( Name = "ResidentSalutation" , Order = 3 )]
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

      [DataMember( Name = "ResidentBsnNumber" , Order = 4 )]
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

      [DataMember( Name = "ResidentGivenName" , Order = 5 )]
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

      [DataMember( Name = "ResidentLastName" , Order = 6 )]
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

      [DataMember( Name = "ResidentInitials" , Order = 7 )]
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

      [DataMember( Name = "ResidentEmail" , Order = 8 )]
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

      [DataMember( Name = "ResidentGender" , Order = 9 )]
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

      [DataMember( Name = "ResidentCountry" , Order = 10 )]
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

      [DataMember( Name = "ResidentCity" , Order = 11 )]
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

      [DataMember( Name = "ResidentZipCode" , Order = 12 )]
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

      [DataMember( Name = "ResidentAddressLine1" , Order = 13 )]
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

      [DataMember( Name = "ResidentAddressLine2" , Order = 14 )]
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

      [DataMember( Name = "ResidentPhone" , Order = 15 )]
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

      [DataMember( Name = "ResidentHomePhone" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Residenthomephone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residenthomephone) ;
         }

         set {
            sdt.gxTpr_Residenthomephone = value;
         }

      }

      [DataMember( Name = "ResidentBirthDate" , Order = 17 )]
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

      [DataMember( Name = "ResidentGUID" , Order = 18 )]
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

      [DataMember( Name = "ResidentTypeId" , Order = 19 )]
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

      [DataMember( Name = "ResidentTypeName" , Order = 20 )]
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

      [DataMember( Name = "MedicalIndicationId" , Order = 21 )]
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

      [DataMember( Name = "MedicalIndicationName" , Order = 22 )]
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

      [DataMember( Name = "ResidentPhoneCode" , Order = 23 )]
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

      [DataMember( Name = "ResidentPhoneNumber" , Order = 24 )]
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

      [DataMember( Name = "ResidentHomePhoneCode" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Residenthomephonecode
      {
         get {
            return sdt.gxTpr_Residenthomephonecode ;
         }

         set {
            sdt.gxTpr_Residenthomephonecode = value;
         }

      }

      [DataMember( Name = "ResidentHomePhoneNumber" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Residenthomephonenumber
      {
         get {
            return sdt.gxTpr_Residenthomephonenumber ;
         }

         set {
            sdt.gxTpr_Residenthomephonenumber = value;
         }

      }

      [DataMember( Name = "ResidentImage" , Order = 27 )]
      [GxUpload()]
      public string gxTpr_Residentimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Residentimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Residentimage) : StringUtil.RTrim( sdt.gxTpr_Residentimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Residentimage = value;
         }

      }

      [DataMember( Name = "ResidentLanguage" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Residentlanguage
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentlanguage) ;
         }

         set {
            sdt.gxTpr_Residentlanguage = value;
         }

      }

      [DataMember( Name = "ResidentPackageId" , Order = 29 )]
      [GxSeudo()]
      public Guid gxTpr_Residentpackageid
      {
         get {
            return sdt.gxTpr_Residentpackageid ;
         }

         set {
            sdt.gxTpr_Residentpackageid = value;
         }

      }

      [DataMember( Name = "ResidentPackageName" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Residentpackagename
      {
         get {
            return sdt.gxTpr_Residentpackagename ;
         }

         set {
            sdt.gxTpr_Residentpackagename = value;
         }

      }

      [DataMember( Name = "SG_LocationId" , Order = 31 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_locationid
      {
         get {
            return sdt.gxTpr_Sg_locationid ;
         }

         set {
            sdt.gxTpr_Sg_locationid = value;
         }

      }

      [DataMember( Name = "SG_OrganisationId" , Order = 32 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_organisationid
      {
         get {
            return sdt.gxTpr_Sg_organisationid ;
         }

         set {
            sdt.gxTpr_Sg_organisationid = value;
         }

      }

      public SdtTrn_Resident sdt
      {
         get {
            return (SdtTrn_Resident)Sdt ;
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
            sdt = new SdtTrn_Resident() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 33 )]
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

   [DataContract(Name = @"Trn_Resident", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Resident_RESTLInterface : GxGenericCollectionItem<SdtTrn_Resident>
   {
      public SdtTrn_Resident_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Resident_RESTLInterface( SdtTrn_Resident psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentLastName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_Resident sdt
      {
         get {
            return (SdtTrn_Resident)Sdt ;
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
            sdt = new SdtTrn_Resident() ;
         }
      }

   }

}
