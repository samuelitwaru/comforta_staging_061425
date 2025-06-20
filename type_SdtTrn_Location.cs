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
   [XmlRoot(ElementName = "Trn_Location" )]
   [XmlType(TypeName =  "Trn_Location" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Location : GxSilentTrnSdt
   {
      public SdtTrn_Location( )
      {
      }

      public SdtTrn_Location( IGxContext context )
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

      public void Load( Guid AV29LocationId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV29LocationId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LocationId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Location");
         metadata.Set("BT", "Trn_Location");
         metadata.Set("PK", "[ \"LocationId\",\"OrganisationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AppVersionId\" ],\"FKMap\":[ \"ActiveAppVersionId-AppVersionId\" ] },{ \"FK\":[ \"AppVersionId\" ],\"FKMap\":[ \"PublishedActiveAppVersionId-AppVersionId\" ] },{ \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ReceptionistId\",\"OrganisationId\",\"LocationId\" ],\"FKMap\":[ \"ToolBoxLastUpdateReceptionistId-ReceptionistId\" ] },{ \"FK\":[ \"Trn_ThemeId\" ],\"FKMap\":[ \"LocationThemeId-Trn_ThemeId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Locationimage_gxi");
         state.Add("gxTpr_Receptionimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationname_Z");
         state.Add("gxTpr_Locationcountry_Z");
         state.Add("gxTpr_Locationcity_Z");
         state.Add("gxTpr_Locationzipcode_Z");
         state.Add("gxTpr_Locationaddressline1_Z");
         state.Add("gxTpr_Locationaddressline2_Z");
         state.Add("gxTpr_Locationemail_Z");
         state.Add("gxTpr_Locationphonecode_Z");
         state.Add("gxTpr_Locationphonenumber_Z");
         state.Add("gxTpr_Locationphone_Z");
         state.Add("gxTpr_Locationhasmycare_Z");
         state.Add("gxTpr_Locationhasmyservices_Z");
         state.Add("gxTpr_Locationhasmyliving_Z");
         state.Add("gxTpr_Locationhasownbrand_Z");
         state.Add("gxTpr_Toolboxdefaultprofileimage_Z");
         state.Add("gxTpr_Toolboxdefaultlogo_Z");
         state.Add("gxTpr_Receptiondescription_Z");
         state.Add("gxTpr_Activeappversionid_Z");
         state.Add("gxTpr_Publishedactiveappversionid_Z");
         state.Add("gxTpr_Trn_themeid_Z");
         state.Add("gxTpr_Locationthemeid_Z");
         state.Add("gxTpr_Toolboxlastupdatereceptionistid_Z");
         state.Add("gxTpr_Toolboxlastupdatetime_Z_Nullable");
         state.Add("gxTpr_Locationimage_gxi_Z");
         state.Add("gxTpr_Receptionimage_gxi_Z");
         state.Add("gxTpr_Locationid_N");
         state.Add("gxTpr_Organisationid_N");
         state.Add("gxTpr_Locationimage_N");
         state.Add("gxTpr_Locationbrandtheme_N");
         state.Add("gxTpr_Locationctatheme_N");
         state.Add("gxTpr_Toolboxdefaultprofileimage_N");
         state.Add("gxTpr_Toolboxdefaultlogo_N");
         state.Add("gxTpr_Receptionimage_N");
         state.Add("gxTpr_Receptiondescription_N");
         state.Add("gxTpr_Activeappversionid_N");
         state.Add("gxTpr_Publishedactiveappversionid_N");
         state.Add("gxTpr_Locationthemeid_N");
         state.Add("gxTpr_Toolboxlastupdatereceptionistid_N");
         state.Add("gxTpr_Toolboxlastupdatetime_N");
         state.Add("gxTpr_Locationimage_gxi_N");
         state.Add("gxTpr_Receptionimage_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Location sdt;
         sdt = (SdtTrn_Location)(source);
         gxTv_SdtTrn_Location_Locationid = sdt.gxTv_SdtTrn_Location_Locationid ;
         gxTv_SdtTrn_Location_Organisationid = sdt.gxTv_SdtTrn_Location_Organisationid ;
         gxTv_SdtTrn_Location_Locationname = sdt.gxTv_SdtTrn_Location_Locationname ;
         gxTv_SdtTrn_Location_Locationimage = sdt.gxTv_SdtTrn_Location_Locationimage ;
         gxTv_SdtTrn_Location_Locationimage_gxi = sdt.gxTv_SdtTrn_Location_Locationimage_gxi ;
         gxTv_SdtTrn_Location_Locationcountry = sdt.gxTv_SdtTrn_Location_Locationcountry ;
         gxTv_SdtTrn_Location_Locationcity = sdt.gxTv_SdtTrn_Location_Locationcity ;
         gxTv_SdtTrn_Location_Locationzipcode = sdt.gxTv_SdtTrn_Location_Locationzipcode ;
         gxTv_SdtTrn_Location_Locationaddressline1 = sdt.gxTv_SdtTrn_Location_Locationaddressline1 ;
         gxTv_SdtTrn_Location_Locationaddressline2 = sdt.gxTv_SdtTrn_Location_Locationaddressline2 ;
         gxTv_SdtTrn_Location_Locationemail = sdt.gxTv_SdtTrn_Location_Locationemail ;
         gxTv_SdtTrn_Location_Locationphonecode = sdt.gxTv_SdtTrn_Location_Locationphonecode ;
         gxTv_SdtTrn_Location_Locationphonenumber = sdt.gxTv_SdtTrn_Location_Locationphonenumber ;
         gxTv_SdtTrn_Location_Locationphone = sdt.gxTv_SdtTrn_Location_Locationphone ;
         gxTv_SdtTrn_Location_Locationdescription = sdt.gxTv_SdtTrn_Location_Locationdescription ;
         gxTv_SdtTrn_Location_Locationbrandtheme = sdt.gxTv_SdtTrn_Location_Locationbrandtheme ;
         gxTv_SdtTrn_Location_Locationctatheme = sdt.gxTv_SdtTrn_Location_Locationctatheme ;
         gxTv_SdtTrn_Location_Locationhasmycare = sdt.gxTv_SdtTrn_Location_Locationhasmycare ;
         gxTv_SdtTrn_Location_Locationhasmyservices = sdt.gxTv_SdtTrn_Location_Locationhasmyservices ;
         gxTv_SdtTrn_Location_Locationhasmyliving = sdt.gxTv_SdtTrn_Location_Locationhasmyliving ;
         gxTv_SdtTrn_Location_Locationhasownbrand = sdt.gxTv_SdtTrn_Location_Locationhasownbrand ;
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage = sdt.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage ;
         gxTv_SdtTrn_Location_Toolboxdefaultlogo = sdt.gxTv_SdtTrn_Location_Toolboxdefaultlogo ;
         gxTv_SdtTrn_Location_Receptionimage = sdt.gxTv_SdtTrn_Location_Receptionimage ;
         gxTv_SdtTrn_Location_Receptionimage_gxi = sdt.gxTv_SdtTrn_Location_Receptionimage_gxi ;
         gxTv_SdtTrn_Location_Receptiondescription = sdt.gxTv_SdtTrn_Location_Receptiondescription ;
         gxTv_SdtTrn_Location_Activeappversionid = sdt.gxTv_SdtTrn_Location_Activeappversionid ;
         gxTv_SdtTrn_Location_Publishedactiveappversionid = sdt.gxTv_SdtTrn_Location_Publishedactiveappversionid ;
         gxTv_SdtTrn_Location_Trn_themeid = sdt.gxTv_SdtTrn_Location_Trn_themeid ;
         gxTv_SdtTrn_Location_Locationthemeid = sdt.gxTv_SdtTrn_Location_Locationthemeid ;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid ;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatetime ;
         gxTv_SdtTrn_Location_Mode = sdt.gxTv_SdtTrn_Location_Mode ;
         gxTv_SdtTrn_Location_Initialized = sdt.gxTv_SdtTrn_Location_Initialized ;
         gxTv_SdtTrn_Location_Locationid_Z = sdt.gxTv_SdtTrn_Location_Locationid_Z ;
         gxTv_SdtTrn_Location_Organisationid_Z = sdt.gxTv_SdtTrn_Location_Organisationid_Z ;
         gxTv_SdtTrn_Location_Locationname_Z = sdt.gxTv_SdtTrn_Location_Locationname_Z ;
         gxTv_SdtTrn_Location_Locationcountry_Z = sdt.gxTv_SdtTrn_Location_Locationcountry_Z ;
         gxTv_SdtTrn_Location_Locationcity_Z = sdt.gxTv_SdtTrn_Location_Locationcity_Z ;
         gxTv_SdtTrn_Location_Locationzipcode_Z = sdt.gxTv_SdtTrn_Location_Locationzipcode_Z ;
         gxTv_SdtTrn_Location_Locationaddressline1_Z = sdt.gxTv_SdtTrn_Location_Locationaddressline1_Z ;
         gxTv_SdtTrn_Location_Locationaddressline2_Z = sdt.gxTv_SdtTrn_Location_Locationaddressline2_Z ;
         gxTv_SdtTrn_Location_Locationemail_Z = sdt.gxTv_SdtTrn_Location_Locationemail_Z ;
         gxTv_SdtTrn_Location_Locationphonecode_Z = sdt.gxTv_SdtTrn_Location_Locationphonecode_Z ;
         gxTv_SdtTrn_Location_Locationphonenumber_Z = sdt.gxTv_SdtTrn_Location_Locationphonenumber_Z ;
         gxTv_SdtTrn_Location_Locationphone_Z = sdt.gxTv_SdtTrn_Location_Locationphone_Z ;
         gxTv_SdtTrn_Location_Locationhasmycare_Z = sdt.gxTv_SdtTrn_Location_Locationhasmycare_Z ;
         gxTv_SdtTrn_Location_Locationhasmyservices_Z = sdt.gxTv_SdtTrn_Location_Locationhasmyservices_Z ;
         gxTv_SdtTrn_Location_Locationhasmyliving_Z = sdt.gxTv_SdtTrn_Location_Locationhasmyliving_Z ;
         gxTv_SdtTrn_Location_Locationhasownbrand_Z = sdt.gxTv_SdtTrn_Location_Locationhasownbrand_Z ;
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z = sdt.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z ;
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z = sdt.gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z ;
         gxTv_SdtTrn_Location_Receptiondescription_Z = sdt.gxTv_SdtTrn_Location_Receptiondescription_Z ;
         gxTv_SdtTrn_Location_Activeappversionid_Z = sdt.gxTv_SdtTrn_Location_Activeappversionid_Z ;
         gxTv_SdtTrn_Location_Publishedactiveappversionid_Z = sdt.gxTv_SdtTrn_Location_Publishedactiveappversionid_Z ;
         gxTv_SdtTrn_Location_Trn_themeid_Z = sdt.gxTv_SdtTrn_Location_Trn_themeid_Z ;
         gxTv_SdtTrn_Location_Locationthemeid_Z = sdt.gxTv_SdtTrn_Location_Locationthemeid_Z ;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z ;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z ;
         gxTv_SdtTrn_Location_Locationimage_gxi_Z = sdt.gxTv_SdtTrn_Location_Locationimage_gxi_Z ;
         gxTv_SdtTrn_Location_Receptionimage_gxi_Z = sdt.gxTv_SdtTrn_Location_Receptionimage_gxi_Z ;
         gxTv_SdtTrn_Location_Locationid_N = sdt.gxTv_SdtTrn_Location_Locationid_N ;
         gxTv_SdtTrn_Location_Organisationid_N = sdt.gxTv_SdtTrn_Location_Organisationid_N ;
         gxTv_SdtTrn_Location_Locationimage_N = sdt.gxTv_SdtTrn_Location_Locationimage_N ;
         gxTv_SdtTrn_Location_Locationbrandtheme_N = sdt.gxTv_SdtTrn_Location_Locationbrandtheme_N ;
         gxTv_SdtTrn_Location_Locationctatheme_N = sdt.gxTv_SdtTrn_Location_Locationctatheme_N ;
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = sdt.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N ;
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = sdt.gxTv_SdtTrn_Location_Toolboxdefaultlogo_N ;
         gxTv_SdtTrn_Location_Receptionimage_N = sdt.gxTv_SdtTrn_Location_Receptionimage_N ;
         gxTv_SdtTrn_Location_Receptiondescription_N = sdt.gxTv_SdtTrn_Location_Receptiondescription_N ;
         gxTv_SdtTrn_Location_Activeappversionid_N = sdt.gxTv_SdtTrn_Location_Activeappversionid_N ;
         gxTv_SdtTrn_Location_Publishedactiveappversionid_N = sdt.gxTv_SdtTrn_Location_Publishedactiveappversionid_N ;
         gxTv_SdtTrn_Location_Locationthemeid_N = sdt.gxTv_SdtTrn_Location_Locationthemeid_N ;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N ;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatetime_N ;
         gxTv_SdtTrn_Location_Locationimage_gxi_N = sdt.gxTv_SdtTrn_Location_Locationimage_gxi_N ;
         gxTv_SdtTrn_Location_Receptionimage_gxi_N = sdt.gxTv_SdtTrn_Location_Receptionimage_gxi_N ;
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
         AddObjectProperty("LocationId", gxTv_SdtTrn_Location_Locationid, false, includeNonInitialized);
         AddObjectProperty("LocationId_N", gxTv_SdtTrn_Location_Locationid_N, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Location_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Location_Organisationid_N, false, includeNonInitialized);
         AddObjectProperty("LocationName", gxTv_SdtTrn_Location_Locationname, false, includeNonInitialized);
         AddObjectProperty("LocationImage", gxTv_SdtTrn_Location_Locationimage, false, includeNonInitialized);
         AddObjectProperty("LocationImage_N", gxTv_SdtTrn_Location_Locationimage_N, false, includeNonInitialized);
         AddObjectProperty("LocationCountry", gxTv_SdtTrn_Location_Locationcountry, false, includeNonInitialized);
         AddObjectProperty("LocationCity", gxTv_SdtTrn_Location_Locationcity, false, includeNonInitialized);
         AddObjectProperty("LocationZipCode", gxTv_SdtTrn_Location_Locationzipcode, false, includeNonInitialized);
         AddObjectProperty("LocationAddressLine1", gxTv_SdtTrn_Location_Locationaddressline1, false, includeNonInitialized);
         AddObjectProperty("LocationAddressLine2", gxTv_SdtTrn_Location_Locationaddressline2, false, includeNonInitialized);
         AddObjectProperty("LocationEmail", gxTv_SdtTrn_Location_Locationemail, false, includeNonInitialized);
         AddObjectProperty("LocationPhoneCode", gxTv_SdtTrn_Location_Locationphonecode, false, includeNonInitialized);
         AddObjectProperty("LocationPhoneNumber", gxTv_SdtTrn_Location_Locationphonenumber, false, includeNonInitialized);
         AddObjectProperty("LocationPhone", gxTv_SdtTrn_Location_Locationphone, false, includeNonInitialized);
         AddObjectProperty("LocationDescription", gxTv_SdtTrn_Location_Locationdescription, false, includeNonInitialized);
         AddObjectProperty("LocationBrandTheme", gxTv_SdtTrn_Location_Locationbrandtheme, false, includeNonInitialized);
         AddObjectProperty("LocationBrandTheme_N", gxTv_SdtTrn_Location_Locationbrandtheme_N, false, includeNonInitialized);
         AddObjectProperty("LocationCtaTheme", gxTv_SdtTrn_Location_Locationctatheme, false, includeNonInitialized);
         AddObjectProperty("LocationCtaTheme_N", gxTv_SdtTrn_Location_Locationctatheme_N, false, includeNonInitialized);
         AddObjectProperty("LocationHasMyCare", gxTv_SdtTrn_Location_Locationhasmycare, false, includeNonInitialized);
         AddObjectProperty("LocationHasMyServices", gxTv_SdtTrn_Location_Locationhasmyservices, false, includeNonInitialized);
         AddObjectProperty("LocationHasMyLiving", gxTv_SdtTrn_Location_Locationhasmyliving, false, includeNonInitialized);
         AddObjectProperty("LocationHasOwnBrand", gxTv_SdtTrn_Location_Locationhasownbrand, false, includeNonInitialized);
         AddObjectProperty("ToolBoxDefaultProfileImage", gxTv_SdtTrn_Location_Toolboxdefaultprofileimage, false, includeNonInitialized);
         AddObjectProperty("ToolBoxDefaultProfileImage_N", gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N, false, includeNonInitialized);
         AddObjectProperty("ToolBoxDefaultLogo", gxTv_SdtTrn_Location_Toolboxdefaultlogo, false, includeNonInitialized);
         AddObjectProperty("ToolBoxDefaultLogo_N", gxTv_SdtTrn_Location_Toolboxdefaultlogo_N, false, includeNonInitialized);
         AddObjectProperty("ReceptionImage", gxTv_SdtTrn_Location_Receptionimage, false, includeNonInitialized);
         AddObjectProperty("ReceptionImage_N", gxTv_SdtTrn_Location_Receptionimage_N, false, includeNonInitialized);
         AddObjectProperty("ReceptionDescription", gxTv_SdtTrn_Location_Receptiondescription, false, includeNonInitialized);
         AddObjectProperty("ReceptionDescription_N", gxTv_SdtTrn_Location_Receptiondescription_N, false, includeNonInitialized);
         AddObjectProperty("ActiveAppVersionId", gxTv_SdtTrn_Location_Activeappversionid, false, includeNonInitialized);
         AddObjectProperty("ActiveAppVersionId_N", gxTv_SdtTrn_Location_Activeappversionid_N, false, includeNonInitialized);
         AddObjectProperty("PublishedActiveAppVersionId", gxTv_SdtTrn_Location_Publishedactiveappversionid, false, includeNonInitialized);
         AddObjectProperty("PublishedActiveAppVersionId_N", gxTv_SdtTrn_Location_Publishedactiveappversionid_N, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeId", gxTv_SdtTrn_Location_Trn_themeid, false, includeNonInitialized);
         AddObjectProperty("LocationThemeId", gxTv_SdtTrn_Location_Locationthemeid, false, includeNonInitialized);
         AddObjectProperty("LocationThemeId_N", gxTv_SdtTrn_Location_Locationthemeid_N, false, includeNonInitialized);
         AddObjectProperty("ToolBoxLastUpdateReceptionistId", gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid, false, includeNonInitialized);
         AddObjectProperty("ToolBoxLastUpdateReceptionistId_N", gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Location_Toolboxlastupdatetime;
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
         AddObjectProperty("ToolBoxLastUpdateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ToolBoxLastUpdateTime_N", gxTv_SdtTrn_Location_Toolboxlastupdatetime_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("LocationImage_GXI", gxTv_SdtTrn_Location_Locationimage_gxi, false, includeNonInitialized);
            AddObjectProperty("ReceptionImage_GXI", gxTv_SdtTrn_Location_Receptionimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Location_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Location_Initialized, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Location_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Location_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationName_Z", gxTv_SdtTrn_Location_Locationname_Z, false, includeNonInitialized);
            AddObjectProperty("LocationCountry_Z", gxTv_SdtTrn_Location_Locationcountry_Z, false, includeNonInitialized);
            AddObjectProperty("LocationCity_Z", gxTv_SdtTrn_Location_Locationcity_Z, false, includeNonInitialized);
            AddObjectProperty("LocationZipCode_Z", gxTv_SdtTrn_Location_Locationzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("LocationAddressLine1_Z", gxTv_SdtTrn_Location_Locationaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("LocationAddressLine2_Z", gxTv_SdtTrn_Location_Locationaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEmail_Z", gxTv_SdtTrn_Location_Locationemail_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhoneCode_Z", gxTv_SdtTrn_Location_Locationphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhoneNumber_Z", gxTv_SdtTrn_Location_Locationphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("LocationPhone_Z", gxTv_SdtTrn_Location_Locationphone_Z, false, includeNonInitialized);
            AddObjectProperty("LocationHasMyCare_Z", gxTv_SdtTrn_Location_Locationhasmycare_Z, false, includeNonInitialized);
            AddObjectProperty("LocationHasMyServices_Z", gxTv_SdtTrn_Location_Locationhasmyservices_Z, false, includeNonInitialized);
            AddObjectProperty("LocationHasMyLiving_Z", gxTv_SdtTrn_Location_Locationhasmyliving_Z, false, includeNonInitialized);
            AddObjectProperty("LocationHasOwnBrand_Z", gxTv_SdtTrn_Location_Locationhasownbrand_Z, false, includeNonInitialized);
            AddObjectProperty("ToolBoxDefaultProfileImage_Z", gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z, false, includeNonInitialized);
            AddObjectProperty("ToolBoxDefaultLogo_Z", gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionDescription_Z", gxTv_SdtTrn_Location_Receptiondescription_Z, false, includeNonInitialized);
            AddObjectProperty("ActiveAppVersionId_Z", gxTv_SdtTrn_Location_Activeappversionid_Z, false, includeNonInitialized);
            AddObjectProperty("PublishedActiveAppVersionId_Z", gxTv_SdtTrn_Location_Publishedactiveappversionid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_Z", gxTv_SdtTrn_Location_Trn_themeid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationThemeId_Z", gxTv_SdtTrn_Location_Locationthemeid_Z, false, includeNonInitialized);
            AddObjectProperty("ToolBoxLastUpdateReceptionistId_Z", gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z;
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
            AddObjectProperty("ToolBoxLastUpdateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LocationImage_GXI_Z", gxTv_SdtTrn_Location_Locationimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionImage_GXI_Z", gxTv_SdtTrn_Location_Receptionimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_N", gxTv_SdtTrn_Location_Locationid_N, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Location_Organisationid_N, false, includeNonInitialized);
            AddObjectProperty("LocationImage_N", gxTv_SdtTrn_Location_Locationimage_N, false, includeNonInitialized);
            AddObjectProperty("LocationBrandTheme_N", gxTv_SdtTrn_Location_Locationbrandtheme_N, false, includeNonInitialized);
            AddObjectProperty("LocationCtaTheme_N", gxTv_SdtTrn_Location_Locationctatheme_N, false, includeNonInitialized);
            AddObjectProperty("ToolBoxDefaultProfileImage_N", gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N, false, includeNonInitialized);
            AddObjectProperty("ToolBoxDefaultLogo_N", gxTv_SdtTrn_Location_Toolboxdefaultlogo_N, false, includeNonInitialized);
            AddObjectProperty("ReceptionImage_N", gxTv_SdtTrn_Location_Receptionimage_N, false, includeNonInitialized);
            AddObjectProperty("ReceptionDescription_N", gxTv_SdtTrn_Location_Receptiondescription_N, false, includeNonInitialized);
            AddObjectProperty("ActiveAppVersionId_N", gxTv_SdtTrn_Location_Activeappversionid_N, false, includeNonInitialized);
            AddObjectProperty("PublishedActiveAppVersionId_N", gxTv_SdtTrn_Location_Publishedactiveappversionid_N, false, includeNonInitialized);
            AddObjectProperty("LocationThemeId_N", gxTv_SdtTrn_Location_Locationthemeid_N, false, includeNonInitialized);
            AddObjectProperty("ToolBoxLastUpdateReceptionistId_N", gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N, false, includeNonInitialized);
            AddObjectProperty("ToolBoxLastUpdateTime_N", gxTv_SdtTrn_Location_Toolboxlastupdatetime_N, false, includeNonInitialized);
            AddObjectProperty("LocationImage_GXI_N", gxTv_SdtTrn_Location_Locationimage_gxi_N, false, includeNonInitialized);
            AddObjectProperty("ReceptionImage_GXI_N", gxTv_SdtTrn_Location_Receptionimage_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Location sdt )
      {
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationid = sdt.gxTv_SdtTrn_Location_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Organisationid = sdt.gxTv_SdtTrn_Location_Organisationid ;
         }
         if ( sdt.IsDirty("LocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname = sdt.gxTv_SdtTrn_Location_Locationname ;
         }
         if ( sdt.IsDirty("LocationImage") )
         {
            gxTv_SdtTrn_Location_Locationimage_N = (short)(sdt.gxTv_SdtTrn_Location_Locationimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage = sdt.gxTv_SdtTrn_Location_Locationimage ;
         }
         if ( sdt.IsDirty("LocationImage") )
         {
            gxTv_SdtTrn_Location_Locationimage_gxi_N = (short)(sdt.gxTv_SdtTrn_Location_Locationimage_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage_gxi = sdt.gxTv_SdtTrn_Location_Locationimage_gxi ;
         }
         if ( sdt.IsDirty("LocationCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry = sdt.gxTv_SdtTrn_Location_Locationcountry ;
         }
         if ( sdt.IsDirty("LocationCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity = sdt.gxTv_SdtTrn_Location_Locationcity ;
         }
         if ( sdt.IsDirty("LocationZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode = sdt.gxTv_SdtTrn_Location_Locationzipcode ;
         }
         if ( sdt.IsDirty("LocationAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1 = sdt.gxTv_SdtTrn_Location_Locationaddressline1 ;
         }
         if ( sdt.IsDirty("LocationAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2 = sdt.gxTv_SdtTrn_Location_Locationaddressline2 ;
         }
         if ( sdt.IsDirty("LocationEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail = sdt.gxTv_SdtTrn_Location_Locationemail ;
         }
         if ( sdt.IsDirty("LocationPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode = sdt.gxTv_SdtTrn_Location_Locationphonecode ;
         }
         if ( sdt.IsDirty("LocationPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber = sdt.gxTv_SdtTrn_Location_Locationphonenumber ;
         }
         if ( sdt.IsDirty("LocationPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone = sdt.gxTv_SdtTrn_Location_Locationphone ;
         }
         if ( sdt.IsDirty("LocationDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationdescription = sdt.gxTv_SdtTrn_Location_Locationdescription ;
         }
         if ( sdt.IsDirty("LocationBrandTheme") )
         {
            gxTv_SdtTrn_Location_Locationbrandtheme_N = (short)(sdt.gxTv_SdtTrn_Location_Locationbrandtheme_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationbrandtheme = sdt.gxTv_SdtTrn_Location_Locationbrandtheme ;
         }
         if ( sdt.IsDirty("LocationCtaTheme") )
         {
            gxTv_SdtTrn_Location_Locationctatheme_N = (short)(sdt.gxTv_SdtTrn_Location_Locationctatheme_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationctatheme = sdt.gxTv_SdtTrn_Location_Locationctatheme ;
         }
         if ( sdt.IsDirty("LocationHasMyCare") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmycare = sdt.gxTv_SdtTrn_Location_Locationhasmycare ;
         }
         if ( sdt.IsDirty("LocationHasMyServices") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyservices = sdt.gxTv_SdtTrn_Location_Locationhasmyservices ;
         }
         if ( sdt.IsDirty("LocationHasMyLiving") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyliving = sdt.gxTv_SdtTrn_Location_Locationhasmyliving ;
         }
         if ( sdt.IsDirty("LocationHasOwnBrand") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasownbrand = sdt.gxTv_SdtTrn_Location_Locationhasownbrand ;
         }
         if ( sdt.IsDirty("ToolBoxDefaultProfileImage") )
         {
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = (short)(sdt.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage = sdt.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage ;
         }
         if ( sdt.IsDirty("ToolBoxDefaultLogo") )
         {
            gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = (short)(sdt.gxTv_SdtTrn_Location_Toolboxdefaultlogo_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultlogo = sdt.gxTv_SdtTrn_Location_Toolboxdefaultlogo ;
         }
         if ( sdt.IsDirty("ReceptionImage") )
         {
            gxTv_SdtTrn_Location_Receptionimage_N = (short)(sdt.gxTv_SdtTrn_Location_Receptionimage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage = sdt.gxTv_SdtTrn_Location_Receptionimage ;
         }
         if ( sdt.IsDirty("ReceptionImage") )
         {
            gxTv_SdtTrn_Location_Receptionimage_gxi_N = (short)(sdt.gxTv_SdtTrn_Location_Receptionimage_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage_gxi = sdt.gxTv_SdtTrn_Location_Receptionimage_gxi ;
         }
         if ( sdt.IsDirty("ReceptionDescription") )
         {
            gxTv_SdtTrn_Location_Receptiondescription_N = (short)(sdt.gxTv_SdtTrn_Location_Receptiondescription_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptiondescription = sdt.gxTv_SdtTrn_Location_Receptiondescription ;
         }
         if ( sdt.IsDirty("ActiveAppVersionId") )
         {
            gxTv_SdtTrn_Location_Activeappversionid_N = (short)(sdt.gxTv_SdtTrn_Location_Activeappversionid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Activeappversionid = sdt.gxTv_SdtTrn_Location_Activeappversionid ;
         }
         if ( sdt.IsDirty("PublishedActiveAppVersionId") )
         {
            gxTv_SdtTrn_Location_Publishedactiveappversionid_N = (short)(sdt.gxTv_SdtTrn_Location_Publishedactiveappversionid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Publishedactiveappversionid = sdt.gxTv_SdtTrn_Location_Publishedactiveappversionid ;
         }
         if ( sdt.IsDirty("Trn_ThemeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid = sdt.gxTv_SdtTrn_Location_Trn_themeid ;
         }
         if ( sdt.IsDirty("LocationThemeId") )
         {
            gxTv_SdtTrn_Location_Locationthemeid_N = (short)(sdt.gxTv_SdtTrn_Location_Locationthemeid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationthemeid = sdt.gxTv_SdtTrn_Location_Locationthemeid ;
         }
         if ( sdt.IsDirty("ToolBoxLastUpdateReceptionistId") )
         {
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = (short)(sdt.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid ;
         }
         if ( sdt.IsDirty("ToolBoxLastUpdateTime") )
         {
            gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = (short)(sdt.gxTv_SdtTrn_Location_Toolboxlastupdatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatetime = sdt.gxTv_SdtTrn_Location_Toolboxlastupdatetime ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Location_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Location_Locationid != value )
            {
               gxTv_SdtTrn_Location_Mode = "INS";
               this.gxTv_SdtTrn_Location_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationname_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcity_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationemail_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphone_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmycare_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmyservices_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmyliving_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasownbrand_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Receptiondescription_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Activeappversionid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Publishedactiveappversionid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationthemeid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationimage_gxi_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Receptionimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Location_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Location_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Location_Organisationid != value )
            {
               gxTv_SdtTrn_Location_Mode = "INS";
               this.gxTv_SdtTrn_Location_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationname_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationcity_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationemail_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationphone_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmycare_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmyservices_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasmyliving_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationhasownbrand_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Receptiondescription_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Activeappversionid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Publishedactiveappversionid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationthemeid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Locationimage_gxi_Z_SetNull( );
               this.gxTv_SdtTrn_Location_Receptionimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Location_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationName" )]
      [  XmlElement( ElementName = "LocationName"   )]
      public string gxTpr_Locationname
      {
         get {
            return gxTv_SdtTrn_Location_Locationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname = value;
            SetDirty("Locationname");
         }

      }

      [  SoapElement( ElementName = "LocationImage" )]
      [  XmlElement( ElementName = "LocationImage"   )]
      [GxUpload()]
      public string gxTpr_Locationimage
      {
         get {
            return gxTv_SdtTrn_Location_Locationimage ;
         }

         set {
            gxTv_SdtTrn_Location_Locationimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage = value;
            SetDirty("Locationimage");
         }

      }

      public void gxTv_SdtTrn_Location_Locationimage_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationimage_N = 1;
         gxTv_SdtTrn_Location_Locationimage = "";
         SetDirty("Locationimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationimage_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Locationimage_N==1) ;
      }

      [  SoapElement( ElementName = "LocationImage_GXI" )]
      [  XmlElement( ElementName = "LocationImage_GXI"   )]
      public string gxTpr_Locationimage_gxi
      {
         get {
            return gxTv_SdtTrn_Location_Locationimage_gxi ;
         }

         set {
            gxTv_SdtTrn_Location_Locationimage_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage_gxi = value;
            SetDirty("Locationimage_gxi");
         }

      }

      public void gxTv_SdtTrn_Location_Locationimage_gxi_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationimage_gxi_N = 1;
         gxTv_SdtTrn_Location_Locationimage_gxi = "";
         SetDirty("Locationimage_gxi");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationimage_gxi_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Locationimage_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "LocationCountry" )]
      [  XmlElement( ElementName = "LocationCountry"   )]
      public string gxTpr_Locationcountry
      {
         get {
            return gxTv_SdtTrn_Location_Locationcountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry = value;
            SetDirty("Locationcountry");
         }

      }

      [  SoapElement( ElementName = "LocationCity" )]
      [  XmlElement( ElementName = "LocationCity"   )]
      public string gxTpr_Locationcity
      {
         get {
            return gxTv_SdtTrn_Location_Locationcity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity = value;
            SetDirty("Locationcity");
         }

      }

      [  SoapElement( ElementName = "LocationZipCode" )]
      [  XmlElement( ElementName = "LocationZipCode"   )]
      public string gxTpr_Locationzipcode
      {
         get {
            return gxTv_SdtTrn_Location_Locationzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode = value;
            SetDirty("Locationzipcode");
         }

      }

      [  SoapElement( ElementName = "LocationAddressLine1" )]
      [  XmlElement( ElementName = "LocationAddressLine1"   )]
      public string gxTpr_Locationaddressline1
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1 = value;
            SetDirty("Locationaddressline1");
         }

      }

      [  SoapElement( ElementName = "LocationAddressLine2" )]
      [  XmlElement( ElementName = "LocationAddressLine2"   )]
      public string gxTpr_Locationaddressline2
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2 = value;
            SetDirty("Locationaddressline2");
         }

      }

      [  SoapElement( ElementName = "LocationEmail" )]
      [  XmlElement( ElementName = "LocationEmail"   )]
      public string gxTpr_Locationemail
      {
         get {
            return gxTv_SdtTrn_Location_Locationemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail = value;
            SetDirty("Locationemail");
         }

      }

      [  SoapElement( ElementName = "LocationPhoneCode" )]
      [  XmlElement( ElementName = "LocationPhoneCode"   )]
      public string gxTpr_Locationphonecode
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode = value;
            SetDirty("Locationphonecode");
         }

      }

      [  SoapElement( ElementName = "LocationPhoneNumber" )]
      [  XmlElement( ElementName = "LocationPhoneNumber"   )]
      public string gxTpr_Locationphonenumber
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber = value;
            SetDirty("Locationphonenumber");
         }

      }

      [  SoapElement( ElementName = "LocationPhone" )]
      [  XmlElement( ElementName = "LocationPhone"   )]
      public string gxTpr_Locationphone
      {
         get {
            return gxTv_SdtTrn_Location_Locationphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone = value;
            SetDirty("Locationphone");
         }

      }

      [  SoapElement( ElementName = "LocationDescription" )]
      [  XmlElement( ElementName = "LocationDescription"   )]
      public string gxTpr_Locationdescription
      {
         get {
            return gxTv_SdtTrn_Location_Locationdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationdescription = value;
            SetDirty("Locationdescription");
         }

      }

      [  SoapElement( ElementName = "LocationBrandTheme" )]
      [  XmlElement( ElementName = "LocationBrandTheme"   )]
      public string gxTpr_Locationbrandtheme
      {
         get {
            return gxTv_SdtTrn_Location_Locationbrandtheme ;
         }

         set {
            gxTv_SdtTrn_Location_Locationbrandtheme_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationbrandtheme = value;
            SetDirty("Locationbrandtheme");
         }

      }

      public void gxTv_SdtTrn_Location_Locationbrandtheme_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationbrandtheme_N = 1;
         gxTv_SdtTrn_Location_Locationbrandtheme = "";
         SetDirty("Locationbrandtheme");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationbrandtheme_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Locationbrandtheme_N==1) ;
      }

      [  SoapElement( ElementName = "LocationCtaTheme" )]
      [  XmlElement( ElementName = "LocationCtaTheme"   )]
      public string gxTpr_Locationctatheme
      {
         get {
            return gxTv_SdtTrn_Location_Locationctatheme ;
         }

         set {
            gxTv_SdtTrn_Location_Locationctatheme_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationctatheme = value;
            SetDirty("Locationctatheme");
         }

      }

      public void gxTv_SdtTrn_Location_Locationctatheme_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationctatheme_N = 1;
         gxTv_SdtTrn_Location_Locationctatheme = "";
         SetDirty("Locationctatheme");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationctatheme_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Locationctatheme_N==1) ;
      }

      [  SoapElement( ElementName = "LocationHasMyCare" )]
      [  XmlElement( ElementName = "LocationHasMyCare"   )]
      public bool gxTpr_Locationhasmycare
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmycare ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmycare = value;
            SetDirty("Locationhasmycare");
         }

      }

      [  SoapElement( ElementName = "LocationHasMyServices" )]
      [  XmlElement( ElementName = "LocationHasMyServices"   )]
      public bool gxTpr_Locationhasmyservices
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmyservices ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyservices = value;
            SetDirty("Locationhasmyservices");
         }

      }

      [  SoapElement( ElementName = "LocationHasMyLiving" )]
      [  XmlElement( ElementName = "LocationHasMyLiving"   )]
      public bool gxTpr_Locationhasmyliving
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmyliving ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyliving = value;
            SetDirty("Locationhasmyliving");
         }

      }

      [  SoapElement( ElementName = "LocationHasOwnBrand" )]
      [  XmlElement( ElementName = "LocationHasOwnBrand"   )]
      public bool gxTpr_Locationhasownbrand
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasownbrand ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasownbrand = value;
            SetDirty("Locationhasownbrand");
         }

      }

      [  SoapElement( ElementName = "ToolBoxDefaultProfileImage" )]
      [  XmlElement( ElementName = "ToolBoxDefaultProfileImage"   )]
      public string gxTpr_Toolboxdefaultprofileimage
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultprofileimage ;
         }

         set {
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage = value;
            SetDirty("Toolboxdefaultprofileimage");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = 1;
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage = "";
         SetDirty("Toolboxdefaultprofileimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N==1) ;
      }

      [  SoapElement( ElementName = "ToolBoxDefaultLogo" )]
      [  XmlElement( ElementName = "ToolBoxDefaultLogo"   )]
      public string gxTpr_Toolboxdefaultlogo
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultlogo ;
         }

         set {
            gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultlogo = value;
            SetDirty("Toolboxdefaultlogo");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultlogo_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = 1;
         gxTv_SdtTrn_Location_Toolboxdefaultlogo = "";
         SetDirty("Toolboxdefaultlogo");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultlogo_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Toolboxdefaultlogo_N==1) ;
      }

      [  SoapElement( ElementName = "ReceptionImage" )]
      [  XmlElement( ElementName = "ReceptionImage"   )]
      [GxUpload()]
      public string gxTpr_Receptionimage
      {
         get {
            return gxTv_SdtTrn_Location_Receptionimage ;
         }

         set {
            gxTv_SdtTrn_Location_Receptionimage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage = value;
            SetDirty("Receptionimage");
         }

      }

      public void gxTv_SdtTrn_Location_Receptionimage_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptionimage_N = 1;
         gxTv_SdtTrn_Location_Receptionimage = "";
         SetDirty("Receptionimage");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptionimage_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Receptionimage_N==1) ;
      }

      [  SoapElement( ElementName = "ReceptionImage_GXI" )]
      [  XmlElement( ElementName = "ReceptionImage_GXI"   )]
      public string gxTpr_Receptionimage_gxi
      {
         get {
            return gxTv_SdtTrn_Location_Receptionimage_gxi ;
         }

         set {
            gxTv_SdtTrn_Location_Receptionimage_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage_gxi = value;
            SetDirty("Receptionimage_gxi");
         }

      }

      public void gxTv_SdtTrn_Location_Receptionimage_gxi_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptionimage_gxi_N = 1;
         gxTv_SdtTrn_Location_Receptionimage_gxi = "";
         SetDirty("Receptionimage_gxi");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptionimage_gxi_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Receptionimage_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "ReceptionDescription" )]
      [  XmlElement( ElementName = "ReceptionDescription"   )]
      public string gxTpr_Receptiondescription
      {
         get {
            return gxTv_SdtTrn_Location_Receptiondescription ;
         }

         set {
            gxTv_SdtTrn_Location_Receptiondescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptiondescription = value;
            SetDirty("Receptiondescription");
         }

      }

      public void gxTv_SdtTrn_Location_Receptiondescription_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptiondescription_N = 1;
         gxTv_SdtTrn_Location_Receptiondescription = "";
         SetDirty("Receptiondescription");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptiondescription_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Receptiondescription_N==1) ;
      }

      [  SoapElement( ElementName = "ActiveAppVersionId" )]
      [  XmlElement( ElementName = "ActiveAppVersionId"   )]
      public Guid gxTpr_Activeappversionid
      {
         get {
            return gxTv_SdtTrn_Location_Activeappversionid ;
         }

         set {
            gxTv_SdtTrn_Location_Activeappversionid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Activeappversionid = value;
            SetDirty("Activeappversionid");
         }

      }

      public void gxTv_SdtTrn_Location_Activeappversionid_SetNull( )
      {
         gxTv_SdtTrn_Location_Activeappversionid_N = 1;
         gxTv_SdtTrn_Location_Activeappversionid = Guid.Empty;
         SetDirty("Activeappversionid");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Activeappversionid_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Activeappversionid_N==1) ;
      }

      [  SoapElement( ElementName = "PublishedActiveAppVersionId" )]
      [  XmlElement( ElementName = "PublishedActiveAppVersionId"   )]
      public Guid gxTpr_Publishedactiveappversionid
      {
         get {
            return gxTv_SdtTrn_Location_Publishedactiveappversionid ;
         }

         set {
            gxTv_SdtTrn_Location_Publishedactiveappversionid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Publishedactiveappversionid = value;
            SetDirty("Publishedactiveappversionid");
         }

      }

      public void gxTv_SdtTrn_Location_Publishedactiveappversionid_SetNull( )
      {
         gxTv_SdtTrn_Location_Publishedactiveappversionid_N = 1;
         gxTv_SdtTrn_Location_Publishedactiveappversionid = Guid.Empty;
         SetDirty("Publishedactiveappversionid");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Publishedactiveappversionid_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Publishedactiveappversionid_N==1) ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId" )]
      [  XmlElement( ElementName = "Trn_ThemeId"   )]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return gxTv_SdtTrn_Location_Trn_themeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid = value;
            SetDirty("Trn_themeid");
         }

      }

      [  SoapElement( ElementName = "LocationThemeId" )]
      [  XmlElement( ElementName = "LocationThemeId"   )]
      public Guid gxTpr_Locationthemeid
      {
         get {
            return gxTv_SdtTrn_Location_Locationthemeid ;
         }

         set {
            gxTv_SdtTrn_Location_Locationthemeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationthemeid = value;
            SetDirty("Locationthemeid");
         }

      }

      public void gxTv_SdtTrn_Location_Locationthemeid_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationthemeid_N = 1;
         gxTv_SdtTrn_Location_Locationthemeid = Guid.Empty;
         SetDirty("Locationthemeid");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationthemeid_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Locationthemeid_N==1) ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateReceptionistId" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateReceptionistId"   )]
      public Guid gxTpr_Toolboxlastupdatereceptionistid
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid ;
         }

         set {
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid = value;
            SetDirty("Toolboxlastupdatereceptionistid");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = 1;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid = Guid.Empty;
         SetDirty("Toolboxlastupdatereceptionistid");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N==1) ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateTime" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateTime"  , IsNullable=true )]
      public string gxTpr_Toolboxlastupdatetime_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Location_Toolboxlastupdatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Location_Toolboxlastupdatetime).value ;
         }

         set {
            gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Location_Toolboxlastupdatetime = DateTime.MinValue;
            else
               gxTv_SdtTrn_Location_Toolboxlastupdatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Toolboxlastupdatetime
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatetime ;
         }

         set {
            gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatetime = value;
            SetDirty("Toolboxlastupdatetime");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatetime_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = 1;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Toolboxlastupdatetime");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatetime_IsNull( )
      {
         return (gxTv_SdtTrn_Location_Toolboxlastupdatetime_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Location_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Location_Mode_SetNull( )
      {
         gxTv_SdtTrn_Location_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Location_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Location_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Location_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationName_Z" )]
      [  XmlElement( ElementName = "LocationName_Z"   )]
      public string gxTpr_Locationname_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationname_Z = value;
            SetDirty("Locationname_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationname_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationname_Z = "";
         SetDirty("Locationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationCountry_Z" )]
      [  XmlElement( ElementName = "LocationCountry_Z"   )]
      public string gxTpr_Locationcountry_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationcountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcountry_Z = value;
            SetDirty("Locationcountry_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationcountry_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationcountry_Z = "";
         SetDirty("Locationcountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationcountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationCity_Z" )]
      [  XmlElement( ElementName = "LocationCity_Z"   )]
      public string gxTpr_Locationcity_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationcity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationcity_Z = value;
            SetDirty("Locationcity_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationcity_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationcity_Z = "";
         SetDirty("Locationcity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationcity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationZipCode_Z" )]
      [  XmlElement( ElementName = "LocationZipCode_Z"   )]
      public string gxTpr_Locationzipcode_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationzipcode_Z = value;
            SetDirty("Locationzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationzipcode_Z = "";
         SetDirty("Locationzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationAddressLine1_Z" )]
      [  XmlElement( ElementName = "LocationAddressLine1_Z"   )]
      public string gxTpr_Locationaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline1_Z = value;
            SetDirty("Locationaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationaddressline1_Z = "";
         SetDirty("Locationaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationAddressLine2_Z" )]
      [  XmlElement( ElementName = "LocationAddressLine2_Z"   )]
      public string gxTpr_Locationaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationaddressline2_Z = value;
            SetDirty("Locationaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationaddressline2_Z = "";
         SetDirty("Locationaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEmail_Z" )]
      [  XmlElement( ElementName = "LocationEmail_Z"   )]
      public string gxTpr_Locationemail_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationemail_Z = value;
            SetDirty("Locationemail_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationemail_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationemail_Z = "";
         SetDirty("Locationemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhoneCode_Z" )]
      [  XmlElement( ElementName = "LocationPhoneCode_Z"   )]
      public string gxTpr_Locationphonecode_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonecode_Z = value;
            SetDirty("Locationphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphonecode_Z = "";
         SetDirty("Locationphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhoneNumber_Z" )]
      [  XmlElement( ElementName = "LocationPhoneNumber_Z"   )]
      public string gxTpr_Locationphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphonenumber_Z = value;
            SetDirty("Locationphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphonenumber_Z = "";
         SetDirty("Locationphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationPhone_Z" )]
      [  XmlElement( ElementName = "LocationPhone_Z"   )]
      public string gxTpr_Locationphone_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationphone_Z = value;
            SetDirty("Locationphone_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationphone_Z = "";
         SetDirty("Locationphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationHasMyCare_Z" )]
      [  XmlElement( ElementName = "LocationHasMyCare_Z"   )]
      public bool gxTpr_Locationhasmycare_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmycare_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmycare_Z = value;
            SetDirty("Locationhasmycare_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationhasmycare_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationhasmycare_Z = false;
         SetDirty("Locationhasmycare_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationhasmycare_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationHasMyServices_Z" )]
      [  XmlElement( ElementName = "LocationHasMyServices_Z"   )]
      public bool gxTpr_Locationhasmyservices_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmyservices_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyservices_Z = value;
            SetDirty("Locationhasmyservices_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationhasmyservices_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationhasmyservices_Z = false;
         SetDirty("Locationhasmyservices_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationhasmyservices_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationHasMyLiving_Z" )]
      [  XmlElement( ElementName = "LocationHasMyLiving_Z"   )]
      public bool gxTpr_Locationhasmyliving_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasmyliving_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasmyliving_Z = value;
            SetDirty("Locationhasmyliving_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationhasmyliving_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationhasmyliving_Z = false;
         SetDirty("Locationhasmyliving_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationhasmyliving_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationHasOwnBrand_Z" )]
      [  XmlElement( ElementName = "LocationHasOwnBrand_Z"   )]
      public bool gxTpr_Locationhasownbrand_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationhasownbrand_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationhasownbrand_Z = value;
            SetDirty("Locationhasownbrand_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationhasownbrand_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationhasownbrand_Z = false;
         SetDirty("Locationhasownbrand_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationhasownbrand_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxDefaultProfileImage_Z" )]
      [  XmlElement( ElementName = "ToolBoxDefaultProfileImage_Z"   )]
      public string gxTpr_Toolboxdefaultprofileimage_Z
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z = value;
            SetDirty("Toolboxdefaultprofileimage_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z = "";
         SetDirty("Toolboxdefaultprofileimage_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxDefaultLogo_Z" )]
      [  XmlElement( ElementName = "ToolBoxDefaultLogo_Z"   )]
      public string gxTpr_Toolboxdefaultlogo_Z
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z = value;
            SetDirty("Toolboxdefaultlogo_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z = "";
         SetDirty("Toolboxdefaultlogo_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionDescription_Z" )]
      [  XmlElement( ElementName = "ReceptionDescription_Z"   )]
      public string gxTpr_Receptiondescription_Z
      {
         get {
            return gxTv_SdtTrn_Location_Receptiondescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptiondescription_Z = value;
            SetDirty("Receptiondescription_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Receptiondescription_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptiondescription_Z = "";
         SetDirty("Receptiondescription_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptiondescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActiveAppVersionId_Z" )]
      [  XmlElement( ElementName = "ActiveAppVersionId_Z"   )]
      public Guid gxTpr_Activeappversionid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Activeappversionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Activeappversionid_Z = value;
            SetDirty("Activeappversionid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Activeappversionid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Activeappversionid_Z = Guid.Empty;
         SetDirty("Activeappversionid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Activeappversionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublishedActiveAppVersionId_Z" )]
      [  XmlElement( ElementName = "PublishedActiveAppVersionId_Z"   )]
      public Guid gxTpr_Publishedactiveappversionid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Publishedactiveappversionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Publishedactiveappversionid_Z = value;
            SetDirty("Publishedactiveappversionid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Publishedactiveappversionid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Publishedactiveappversionid_Z = Guid.Empty;
         SetDirty("Publishedactiveappversionid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Publishedactiveappversionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeId_Z"   )]
      public Guid gxTpr_Trn_themeid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Trn_themeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Trn_themeid_Z = value;
            SetDirty("Trn_themeid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Trn_themeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Trn_themeid_Z = Guid.Empty;
         SetDirty("Trn_themeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Trn_themeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationThemeId_Z" )]
      [  XmlElement( ElementName = "LocationThemeId_Z"   )]
      public Guid gxTpr_Locationthemeid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationthemeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationthemeid_Z = value;
            SetDirty("Locationthemeid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationthemeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationthemeid_Z = Guid.Empty;
         SetDirty("Locationthemeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationthemeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateReceptionistId_Z" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateReceptionistId_Z"   )]
      public Guid gxTpr_Toolboxlastupdatereceptionistid_Z
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z = value;
            SetDirty("Toolboxlastupdatereceptionistid_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z = Guid.Empty;
         SetDirty("Toolboxlastupdatereceptionistid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateTime_Z" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateTime_Z"  , IsNullable=true )]
      public string gxTpr_Toolboxlastupdatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Toolboxlastupdatetime_Z
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = value;
            SetDirty("Toolboxlastupdatetime_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Toolboxlastupdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationImage_GXI_Z" )]
      [  XmlElement( ElementName = "LocationImage_GXI_Z"   )]
      public string gxTpr_Locationimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Location_Locationimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage_gxi_Z = value;
            SetDirty("Locationimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Locationimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationimage_gxi_Z = "";
         SetDirty("Locationimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionImage_GXI_Z" )]
      [  XmlElement( ElementName = "ReceptionImage_GXI_Z"   )]
      public string gxTpr_Receptionimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Location_Receptionimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage_gxi_Z = value;
            SetDirty("Receptionimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Location_Receptionimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptionimage_gxi_Z = "";
         SetDirty("Receptionimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptionimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_N" )]
      [  XmlElement( ElementName = "LocationId_N"   )]
      public short gxTpr_Locationid_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationid_N = value;
            SetDirty("Locationid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationid_N = 0;
         SetDirty("Locationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_N" )]
      [  XmlElement( ElementName = "OrganisationId_N"   )]
      public short gxTpr_Organisationid_N
      {
         get {
            return gxTv_SdtTrn_Location_Organisationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Organisationid_N = value;
            SetDirty("Organisationid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Organisationid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Organisationid_N = 0;
         SetDirty("Organisationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Organisationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationImage_N" )]
      [  XmlElement( ElementName = "LocationImage_N"   )]
      public short gxTpr_Locationimage_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage_N = value;
            SetDirty("Locationimage_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationimage_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationimage_N = 0;
         SetDirty("Locationimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationBrandTheme_N" )]
      [  XmlElement( ElementName = "LocationBrandTheme_N"   )]
      public short gxTpr_Locationbrandtheme_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationbrandtheme_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationbrandtheme_N = value;
            SetDirty("Locationbrandtheme_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationbrandtheme_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationbrandtheme_N = 0;
         SetDirty("Locationbrandtheme_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationbrandtheme_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationCtaTheme_N" )]
      [  XmlElement( ElementName = "LocationCtaTheme_N"   )]
      public short gxTpr_Locationctatheme_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationctatheme_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationctatheme_N = value;
            SetDirty("Locationctatheme_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationctatheme_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationctatheme_N = 0;
         SetDirty("Locationctatheme_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationctatheme_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxDefaultProfileImage_N" )]
      [  XmlElement( ElementName = "ToolBoxDefaultProfileImage_N"   )]
      public short gxTpr_Toolboxdefaultprofileimage_N
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = value;
            SetDirty("Toolboxdefaultprofileimage_N");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N = 0;
         SetDirty("Toolboxdefaultprofileimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxDefaultLogo_N" )]
      [  XmlElement( ElementName = "ToolBoxDefaultLogo_N"   )]
      public short gxTpr_Toolboxdefaultlogo_N
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxdefaultlogo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = value;
            SetDirty("Toolboxdefaultlogo_N");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxdefaultlogo_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_N = 0;
         SetDirty("Toolboxdefaultlogo_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxdefaultlogo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionImage_N" )]
      [  XmlElement( ElementName = "ReceptionImage_N"   )]
      public short gxTpr_Receptionimage_N
      {
         get {
            return gxTv_SdtTrn_Location_Receptionimage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage_N = value;
            SetDirty("Receptionimage_N");
         }

      }

      public void gxTv_SdtTrn_Location_Receptionimage_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptionimage_N = 0;
         SetDirty("Receptionimage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptionimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionDescription_N" )]
      [  XmlElement( ElementName = "ReceptionDescription_N"   )]
      public short gxTpr_Receptiondescription_N
      {
         get {
            return gxTv_SdtTrn_Location_Receptiondescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptiondescription_N = value;
            SetDirty("Receptiondescription_N");
         }

      }

      public void gxTv_SdtTrn_Location_Receptiondescription_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptiondescription_N = 0;
         SetDirty("Receptiondescription_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptiondescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ActiveAppVersionId_N" )]
      [  XmlElement( ElementName = "ActiveAppVersionId_N"   )]
      public short gxTpr_Activeappversionid_N
      {
         get {
            return gxTv_SdtTrn_Location_Activeappversionid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Activeappversionid_N = value;
            SetDirty("Activeappversionid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Activeappversionid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Activeappversionid_N = 0;
         SetDirty("Activeappversionid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Activeappversionid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublishedActiveAppVersionId_N" )]
      [  XmlElement( ElementName = "PublishedActiveAppVersionId_N"   )]
      public short gxTpr_Publishedactiveappversionid_N
      {
         get {
            return gxTv_SdtTrn_Location_Publishedactiveappversionid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Publishedactiveappversionid_N = value;
            SetDirty("Publishedactiveappversionid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Publishedactiveappversionid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Publishedactiveappversionid_N = 0;
         SetDirty("Publishedactiveappversionid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Publishedactiveappversionid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationThemeId_N" )]
      [  XmlElement( ElementName = "LocationThemeId_N"   )]
      public short gxTpr_Locationthemeid_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationthemeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationthemeid_N = value;
            SetDirty("Locationthemeid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationthemeid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationthemeid_N = 0;
         SetDirty("Locationthemeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationthemeid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateReceptionistId_N" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateReceptionistId_N"   )]
      public short gxTpr_Toolboxlastupdatereceptionistid_N
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = value;
            SetDirty("Toolboxlastupdatereceptionistid_N");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N = 0;
         SetDirty("Toolboxlastupdatereceptionistid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ToolBoxLastUpdateTime_N" )]
      [  XmlElement( ElementName = "ToolBoxLastUpdateTime_N"   )]
      public short gxTpr_Toolboxlastupdatetime_N
      {
         get {
            return gxTv_SdtTrn_Location_Toolboxlastupdatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = value;
            SetDirty("Toolboxlastupdatetime_N");
         }

      }

      public void gxTv_SdtTrn_Location_Toolboxlastupdatetime_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_N = 0;
         SetDirty("Toolboxlastupdatetime_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Toolboxlastupdatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationImage_GXI_N" )]
      [  XmlElement( ElementName = "LocationImage_GXI_N"   )]
      public short gxTpr_Locationimage_gxi_N
      {
         get {
            return gxTv_SdtTrn_Location_Locationimage_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Locationimage_gxi_N = value;
            SetDirty("Locationimage_gxi_N");
         }

      }

      public void gxTv_SdtTrn_Location_Locationimage_gxi_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Locationimage_gxi_N = 0;
         SetDirty("Locationimage_gxi_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Locationimage_gxi_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionImage_GXI_N" )]
      [  XmlElement( ElementName = "ReceptionImage_GXI_N"   )]
      public short gxTpr_Receptionimage_gxi_N
      {
         get {
            return gxTv_SdtTrn_Location_Receptionimage_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Location_Receptionimage_gxi_N = value;
            SetDirty("Receptionimage_gxi_N");
         }

      }

      public void gxTv_SdtTrn_Location_Receptionimage_gxi_N_SetNull( )
      {
         gxTv_SdtTrn_Location_Receptionimage_gxi_N = 0;
         SetDirty("Receptionimage_gxi_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Location_Receptionimage_gxi_N_IsNull( )
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
         gxTv_SdtTrn_Location_Locationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Location_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Location_Locationname = "";
         gxTv_SdtTrn_Location_Locationimage = "";
         gxTv_SdtTrn_Location_Locationimage_gxi = "";
         gxTv_SdtTrn_Location_Locationcountry = "";
         gxTv_SdtTrn_Location_Locationcity = "";
         gxTv_SdtTrn_Location_Locationzipcode = "";
         gxTv_SdtTrn_Location_Locationaddressline1 = "";
         gxTv_SdtTrn_Location_Locationaddressline2 = "";
         gxTv_SdtTrn_Location_Locationemail = "";
         gxTv_SdtTrn_Location_Locationphonecode = "";
         gxTv_SdtTrn_Location_Locationphonenumber = "";
         gxTv_SdtTrn_Location_Locationphone = "";
         gxTv_SdtTrn_Location_Locationdescription = "";
         gxTv_SdtTrn_Location_Locationbrandtheme = "";
         gxTv_SdtTrn_Location_Locationctatheme = "";
         gxTv_SdtTrn_Location_Locationhasmycare = false;
         gxTv_SdtTrn_Location_Locationhasmyservices = false;
         gxTv_SdtTrn_Location_Locationhasmyliving = false;
         gxTv_SdtTrn_Location_Locationhasownbrand = false;
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage = "";
         gxTv_SdtTrn_Location_Toolboxdefaultlogo = "";
         gxTv_SdtTrn_Location_Receptionimage = "";
         gxTv_SdtTrn_Location_Receptionimage_gxi = "";
         gxTv_SdtTrn_Location_Receptiondescription = "";
         gxTv_SdtTrn_Location_Activeappversionid = Guid.Empty;
         gxTv_SdtTrn_Location_Publishedactiveappversionid = Guid.Empty;
         gxTv_SdtTrn_Location_Trn_themeid = Guid.Empty;
         gxTv_SdtTrn_Location_Locationthemeid = Guid.Empty;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid = Guid.Empty;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Location_Mode = "";
         gxTv_SdtTrn_Location_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Locationname_Z = "";
         gxTv_SdtTrn_Location_Locationcountry_Z = "";
         gxTv_SdtTrn_Location_Locationcity_Z = "";
         gxTv_SdtTrn_Location_Locationzipcode_Z = "";
         gxTv_SdtTrn_Location_Locationaddressline1_Z = "";
         gxTv_SdtTrn_Location_Locationaddressline2_Z = "";
         gxTv_SdtTrn_Location_Locationemail_Z = "";
         gxTv_SdtTrn_Location_Locationphonecode_Z = "";
         gxTv_SdtTrn_Location_Locationphonenumber_Z = "";
         gxTv_SdtTrn_Location_Locationphone_Z = "";
         gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z = "";
         gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z = "";
         gxTv_SdtTrn_Location_Receptiondescription_Z = "";
         gxTv_SdtTrn_Location_Activeappversionid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Publishedactiveappversionid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Trn_themeid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Locationthemeid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z = Guid.Empty;
         gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Location_Locationimage_gxi_Z = "";
         gxTv_SdtTrn_Location_Receptionimage_gxi_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_location", "GeneXus.Programs.trn_location_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Location_Initialized ;
      private short gxTv_SdtTrn_Location_Locationid_N ;
      private short gxTv_SdtTrn_Location_Organisationid_N ;
      private short gxTv_SdtTrn_Location_Locationimage_N ;
      private short gxTv_SdtTrn_Location_Locationbrandtheme_N ;
      private short gxTv_SdtTrn_Location_Locationctatheme_N ;
      private short gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_N ;
      private short gxTv_SdtTrn_Location_Toolboxdefaultlogo_N ;
      private short gxTv_SdtTrn_Location_Receptionimage_N ;
      private short gxTv_SdtTrn_Location_Receptiondescription_N ;
      private short gxTv_SdtTrn_Location_Activeappversionid_N ;
      private short gxTv_SdtTrn_Location_Publishedactiveappversionid_N ;
      private short gxTv_SdtTrn_Location_Locationthemeid_N ;
      private short gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_N ;
      private short gxTv_SdtTrn_Location_Toolboxlastupdatetime_N ;
      private short gxTv_SdtTrn_Location_Locationimage_gxi_N ;
      private short gxTv_SdtTrn_Location_Receptionimage_gxi_N ;
      private string gxTv_SdtTrn_Location_Locationphone ;
      private string gxTv_SdtTrn_Location_Mode ;
      private string gxTv_SdtTrn_Location_Locationphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_Location_Toolboxlastupdatetime ;
      private DateTime gxTv_SdtTrn_Location_Toolboxlastupdatetime_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_Location_Locationhasmycare ;
      private bool gxTv_SdtTrn_Location_Locationhasmyservices ;
      private bool gxTv_SdtTrn_Location_Locationhasmyliving ;
      private bool gxTv_SdtTrn_Location_Locationhasownbrand ;
      private bool gxTv_SdtTrn_Location_Locationhasmycare_Z ;
      private bool gxTv_SdtTrn_Location_Locationhasmyservices_Z ;
      private bool gxTv_SdtTrn_Location_Locationhasmyliving_Z ;
      private bool gxTv_SdtTrn_Location_Locationhasownbrand_Z ;
      private string gxTv_SdtTrn_Location_Locationdescription ;
      private string gxTv_SdtTrn_Location_Locationbrandtheme ;
      private string gxTv_SdtTrn_Location_Locationctatheme ;
      private string gxTv_SdtTrn_Location_Locationname ;
      private string gxTv_SdtTrn_Location_Locationimage_gxi ;
      private string gxTv_SdtTrn_Location_Locationcountry ;
      private string gxTv_SdtTrn_Location_Locationcity ;
      private string gxTv_SdtTrn_Location_Locationzipcode ;
      private string gxTv_SdtTrn_Location_Locationaddressline1 ;
      private string gxTv_SdtTrn_Location_Locationaddressline2 ;
      private string gxTv_SdtTrn_Location_Locationemail ;
      private string gxTv_SdtTrn_Location_Locationphonecode ;
      private string gxTv_SdtTrn_Location_Locationphonenumber ;
      private string gxTv_SdtTrn_Location_Toolboxdefaultprofileimage ;
      private string gxTv_SdtTrn_Location_Toolboxdefaultlogo ;
      private string gxTv_SdtTrn_Location_Receptionimage_gxi ;
      private string gxTv_SdtTrn_Location_Receptiondescription ;
      private string gxTv_SdtTrn_Location_Locationname_Z ;
      private string gxTv_SdtTrn_Location_Locationcountry_Z ;
      private string gxTv_SdtTrn_Location_Locationcity_Z ;
      private string gxTv_SdtTrn_Location_Locationzipcode_Z ;
      private string gxTv_SdtTrn_Location_Locationaddressline1_Z ;
      private string gxTv_SdtTrn_Location_Locationaddressline2_Z ;
      private string gxTv_SdtTrn_Location_Locationemail_Z ;
      private string gxTv_SdtTrn_Location_Locationphonecode_Z ;
      private string gxTv_SdtTrn_Location_Locationphonenumber_Z ;
      private string gxTv_SdtTrn_Location_Toolboxdefaultprofileimage_Z ;
      private string gxTv_SdtTrn_Location_Toolboxdefaultlogo_Z ;
      private string gxTv_SdtTrn_Location_Receptiondescription_Z ;
      private string gxTv_SdtTrn_Location_Locationimage_gxi_Z ;
      private string gxTv_SdtTrn_Location_Receptionimage_gxi_Z ;
      private string gxTv_SdtTrn_Location_Locationimage ;
      private string gxTv_SdtTrn_Location_Receptionimage ;
      private Guid gxTv_SdtTrn_Location_Locationid ;
      private Guid gxTv_SdtTrn_Location_Organisationid ;
      private Guid gxTv_SdtTrn_Location_Activeappversionid ;
      private Guid gxTv_SdtTrn_Location_Publishedactiveappversionid ;
      private Guid gxTv_SdtTrn_Location_Trn_themeid ;
      private Guid gxTv_SdtTrn_Location_Locationthemeid ;
      private Guid gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid ;
      private Guid gxTv_SdtTrn_Location_Locationid_Z ;
      private Guid gxTv_SdtTrn_Location_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Location_Activeappversionid_Z ;
      private Guid gxTv_SdtTrn_Location_Publishedactiveappversionid_Z ;
      private Guid gxTv_SdtTrn_Location_Trn_themeid_Z ;
      private Guid gxTv_SdtTrn_Location_Locationthemeid_Z ;
      private Guid gxTv_SdtTrn_Location_Toolboxlastupdatereceptionistid_Z ;
   }

   [DataContract(Name = @"Trn_Location", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Location_RESTInterface : GxGenericCollectionItem<SdtTrn_Location>
   {
      public SdtTrn_Location_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Location_RESTInterface( SdtTrn_Location psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationId" , Order = 0 )]
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

      [DataMember( Name = "OrganisationId" , Order = 1 )]
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

      [DataMember( Name = "LocationName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Locationname
      {
         get {
            return sdt.gxTpr_Locationname ;
         }

         set {
            sdt.gxTpr_Locationname = value;
         }

      }

      [DataMember( Name = "LocationImage" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Locationimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Locationimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Locationimage) : StringUtil.RTrim( sdt.gxTpr_Locationimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Locationimage = value;
         }

      }

      [DataMember( Name = "LocationCountry" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Locationcountry
      {
         get {
            return sdt.gxTpr_Locationcountry ;
         }

         set {
            sdt.gxTpr_Locationcountry = value;
         }

      }

      [DataMember( Name = "LocationCity" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Locationcity
      {
         get {
            return sdt.gxTpr_Locationcity ;
         }

         set {
            sdt.gxTpr_Locationcity = value;
         }

      }

      [DataMember( Name = "LocationZipCode" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Locationzipcode
      {
         get {
            return sdt.gxTpr_Locationzipcode ;
         }

         set {
            sdt.gxTpr_Locationzipcode = value;
         }

      }

      [DataMember( Name = "LocationAddressLine1" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Locationaddressline1
      {
         get {
            return sdt.gxTpr_Locationaddressline1 ;
         }

         set {
            sdt.gxTpr_Locationaddressline1 = value;
         }

      }

      [DataMember( Name = "LocationAddressLine2" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Locationaddressline2
      {
         get {
            return sdt.gxTpr_Locationaddressline2 ;
         }

         set {
            sdt.gxTpr_Locationaddressline2 = value;
         }

      }

      [DataMember( Name = "LocationEmail" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Locationemail
      {
         get {
            return sdt.gxTpr_Locationemail ;
         }

         set {
            sdt.gxTpr_Locationemail = value;
         }

      }

      [DataMember( Name = "LocationPhoneCode" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Locationphonecode
      {
         get {
            return sdt.gxTpr_Locationphonecode ;
         }

         set {
            sdt.gxTpr_Locationphonecode = value;
         }

      }

      [DataMember( Name = "LocationPhoneNumber" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Locationphonenumber
      {
         get {
            return sdt.gxTpr_Locationphonenumber ;
         }

         set {
            sdt.gxTpr_Locationphonenumber = value;
         }

      }

      [DataMember( Name = "LocationPhone" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Locationphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Locationphone) ;
         }

         set {
            sdt.gxTpr_Locationphone = value;
         }

      }

      [DataMember( Name = "LocationDescription" , Order = 13 )]
      public string gxTpr_Locationdescription
      {
         get {
            return sdt.gxTpr_Locationdescription ;
         }

         set {
            sdt.gxTpr_Locationdescription = value;
         }

      }

      [DataMember( Name = "LocationBrandTheme" , Order = 14 )]
      public string gxTpr_Locationbrandtheme
      {
         get {
            return sdt.gxTpr_Locationbrandtheme ;
         }

         set {
            sdt.gxTpr_Locationbrandtheme = value;
         }

      }

      [DataMember( Name = "LocationCtaTheme" , Order = 15 )]
      public string gxTpr_Locationctatheme
      {
         get {
            return sdt.gxTpr_Locationctatheme ;
         }

         set {
            sdt.gxTpr_Locationctatheme = value;
         }

      }

      [DataMember( Name = "LocationHasMyCare" , Order = 16 )]
      [GxSeudo()]
      public bool gxTpr_Locationhasmycare
      {
         get {
            return sdt.gxTpr_Locationhasmycare ;
         }

         set {
            sdt.gxTpr_Locationhasmycare = value;
         }

      }

      [DataMember( Name = "LocationHasMyServices" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Locationhasmyservices
      {
         get {
            return sdt.gxTpr_Locationhasmyservices ;
         }

         set {
            sdt.gxTpr_Locationhasmyservices = value;
         }

      }

      [DataMember( Name = "LocationHasMyLiving" , Order = 18 )]
      [GxSeudo()]
      public bool gxTpr_Locationhasmyliving
      {
         get {
            return sdt.gxTpr_Locationhasmyliving ;
         }

         set {
            sdt.gxTpr_Locationhasmyliving = value;
         }

      }

      [DataMember( Name = "LocationHasOwnBrand" , Order = 19 )]
      [GxSeudo()]
      public bool gxTpr_Locationhasownbrand
      {
         get {
            return sdt.gxTpr_Locationhasownbrand ;
         }

         set {
            sdt.gxTpr_Locationhasownbrand = value;
         }

      }

      [DataMember( Name = "ToolBoxDefaultProfileImage" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Toolboxdefaultprofileimage
      {
         get {
            return sdt.gxTpr_Toolboxdefaultprofileimage ;
         }

         set {
            sdt.gxTpr_Toolboxdefaultprofileimage = value;
         }

      }

      [DataMember( Name = "ToolBoxDefaultLogo" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Toolboxdefaultlogo
      {
         get {
            return sdt.gxTpr_Toolboxdefaultlogo ;
         }

         set {
            sdt.gxTpr_Toolboxdefaultlogo = value;
         }

      }

      [DataMember( Name = "ReceptionImage" , Order = 22 )]
      [GxUpload()]
      public string gxTpr_Receptionimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Receptionimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Receptionimage) : StringUtil.RTrim( sdt.gxTpr_Receptionimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Receptionimage = value;
         }

      }

      [DataMember( Name = "ReceptionDescription" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Receptiondescription
      {
         get {
            return sdt.gxTpr_Receptiondescription ;
         }

         set {
            sdt.gxTpr_Receptiondescription = value;
         }

      }

      [DataMember( Name = "ActiveAppVersionId" , Order = 24 )]
      [GxSeudo()]
      public Guid gxTpr_Activeappversionid
      {
         get {
            return sdt.gxTpr_Activeappversionid ;
         }

         set {
            sdt.gxTpr_Activeappversionid = value;
         }

      }

      [DataMember( Name = "PublishedActiveAppVersionId" , Order = 25 )]
      [GxSeudo()]
      public Guid gxTpr_Publishedactiveappversionid
      {
         get {
            return sdt.gxTpr_Publishedactiveappversionid ;
         }

         set {
            sdt.gxTpr_Publishedactiveappversionid = value;
         }

      }

      [DataMember( Name = "Trn_ThemeId" , Order = 26 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return sdt.gxTpr_Trn_themeid ;
         }

         set {
            sdt.gxTpr_Trn_themeid = value;
         }

      }

      [DataMember( Name = "LocationThemeId" , Order = 27 )]
      [GxSeudo()]
      public Guid gxTpr_Locationthemeid
      {
         get {
            return sdt.gxTpr_Locationthemeid ;
         }

         set {
            sdt.gxTpr_Locationthemeid = value;
         }

      }

      [DataMember( Name = "ToolBoxLastUpdateReceptionistId" , Order = 28 )]
      [GxSeudo()]
      public Guid gxTpr_Toolboxlastupdatereceptionistid
      {
         get {
            return sdt.gxTpr_Toolboxlastupdatereceptionistid ;
         }

         set {
            sdt.gxTpr_Toolboxlastupdatereceptionistid = value;
         }

      }

      [DataMember( Name = "ToolBoxLastUpdateTime" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Toolboxlastupdatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Toolboxlastupdatetime, (IGxContext)(context)) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value, (IGxContext)(context)));
            sdt.gxTpr_Toolboxlastupdatetime = GXt_dtime1;
         }

      }

      public SdtTrn_Location sdt
      {
         get {
            return (SdtTrn_Location)Sdt ;
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
            sdt = new SdtTrn_Location() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 30 )]
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
      private DateTime GXt_dtime1 ;
   }

   [DataContract(Name = @"Trn_Location", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Location_RESTLInterface : GxGenericCollectionItem<SdtTrn_Location>
   {
      public SdtTrn_Location_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Location_RESTLInterface( SdtTrn_Location psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Locationname
      {
         get {
            return sdt.gxTpr_Locationname ;
         }

         set {
            sdt.gxTpr_Locationname = value;
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

      public SdtTrn_Location sdt
      {
         get {
            return (SdtTrn_Location)Sdt ;
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
            sdt = new SdtTrn_Location() ;
         }
      }

   }

}
