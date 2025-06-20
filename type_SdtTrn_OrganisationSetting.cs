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
   [XmlRoot(ElementName = "Trn_OrganisationSetting" )]
   [XmlType(TypeName =  "Trn_OrganisationSetting" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_OrganisationSetting : GxSilentTrnSdt
   {
      public SdtTrn_OrganisationSetting( )
      {
      }

      public SdtTrn_OrganisationSetting( IGxContext context )
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

      public void Load( Guid AV100OrganisationSettingid ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV100OrganisationSettingid,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OrganisationSettingid", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_OrganisationSetting");
         metadata.Set("BT", "Trn_OrganisationSetting");
         metadata.Set("PK", "[ \"OrganisationSettingid\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"OrganisationSettingid\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Trn_ThemeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Organisationsettinglogo_gxi");
         state.Add("gxTpr_Organisationsettingfavicon_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Organisationsettingid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Organisationsettingbasecolor_Z");
         state.Add("gxTpr_Organisationsettingfontsize_Z");
         state.Add("gxTpr_Organisationhasmycare_Z");
         state.Add("gxTpr_Organisationhasmyliving_Z");
         state.Add("gxTpr_Organisationhasmyservices_Z");
         state.Add("gxTpr_Organisationhasdynamicforms_Z");
         state.Add("gxTpr_Organisationhasownbrand_Z");
         state.Add("gxTpr_Trn_themeid_Z");
         state.Add("gxTpr_Organisationsettinglogo_gxi_Z");
         state.Add("gxTpr_Organisationsettingfavicon_gxi_Z");
         state.Add("gxTpr_Organisationdefinitions_N");
         state.Add("gxTpr_Trn_themeid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_OrganisationSetting sdt;
         sdt = (SdtTrn_OrganisationSetting)(source);
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         gxTv_SdtTrn_OrganisationSetting_Organisationid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms ;
         gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme ;
         gxTv_SdtTrn_OrganisationSetting_Organisationctatheme = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationctatheme ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand ;
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions ;
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid = sdt.gxTv_SdtTrn_OrganisationSetting_Trn_themeid ;
         gxTv_SdtTrn_OrganisationSetting_Mode = sdt.gxTv_SdtTrn_OrganisationSetting_Mode ;
         gxTv_SdtTrn_OrganisationSetting_Initialized = sdt.gxTv_SdtTrn_OrganisationSetting_Initialized ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z ;
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N ;
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = sdt.gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N ;
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
         AddObjectProperty("OrganisationSettingid", gxTv_SdtTrn_OrganisationSetting_Organisationsettingid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_OrganisationSetting_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingLogo", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingFavicon", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingBaseColor", gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingFontSize", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize, false, includeNonInitialized);
         AddObjectProperty("OrganisationSettingLanguage", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage, false, includeNonInitialized);
         AddObjectProperty("OrganisationHasMyCare", gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare, false, includeNonInitialized);
         AddObjectProperty("OrganisationHasMyLiving", gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving, false, includeNonInitialized);
         AddObjectProperty("OrganisationHasMyServices", gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices, false, includeNonInitialized);
         AddObjectProperty("OrganisationHasDynamicForms", gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms, false, includeNonInitialized);
         AddObjectProperty("OrganisationBrandTheme", gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme, false, includeNonInitialized);
         AddObjectProperty("OrganisationCtaTheme", gxTv_SdtTrn_OrganisationSetting_Organisationctatheme, false, includeNonInitialized);
         AddObjectProperty("OrganisationHasOwnBrand", gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand, false, includeNonInitialized);
         AddObjectProperty("OrganisationDefinitions", gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions, false, includeNonInitialized);
         AddObjectProperty("OrganisationDefinitions_N", gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeId", gxTv_SdtTrn_OrganisationSetting_Trn_themeid, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeId_N", gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("OrganisationSettingLogo_GXI", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFavicon_GXI", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_OrganisationSetting_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_OrganisationSetting_Initialized, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingid_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_OrganisationSetting_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingBaseColor_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFontSize_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationHasMyCare_Z", gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationHasMyLiving_Z", gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationHasMyServices_Z", gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationHasDynamicForms_Z", gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationHasOwnBrand_Z", gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_Z", gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingLogo_GXI_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationSettingFavicon_GXI_Z", gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationDefinitions_N", gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_N", gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_OrganisationSetting sdt )
      {
         if ( sdt.IsDirty("OrganisationSettingid") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationid = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         }
         if ( sdt.IsDirty("OrganisationSettingLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         }
         if ( sdt.IsDirty("OrganisationSettingLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         }
         if ( sdt.IsDirty("OrganisationSettingFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         }
         if ( sdt.IsDirty("OrganisationSettingFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         }
         if ( sdt.IsDirty("OrganisationSettingBaseColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         }
         if ( sdt.IsDirty("OrganisationSettingFontSize") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         }
         if ( sdt.IsDirty("OrganisationSettingLanguage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         }
         if ( sdt.IsDirty("OrganisationHasMyCare") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare ;
         }
         if ( sdt.IsDirty("OrganisationHasMyLiving") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving ;
         }
         if ( sdt.IsDirty("OrganisationHasMyServices") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices ;
         }
         if ( sdt.IsDirty("OrganisationHasDynamicForms") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms ;
         }
         if ( sdt.IsDirty("OrganisationBrandTheme") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme ;
         }
         if ( sdt.IsDirty("OrganisationCtaTheme") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationctatheme = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationctatheme ;
         }
         if ( sdt.IsDirty("OrganisationHasOwnBrand") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand ;
         }
         if ( sdt.IsDirty("OrganisationDefinitions") )
         {
            gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = (short)(sdt.gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions = sdt.gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions ;
         }
         if ( sdt.IsDirty("Trn_ThemeId") )
         {
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = (short)(sdt.gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid = sdt.gxTv_SdtTrn_OrganisationSetting_Trn_themeid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OrganisationSettingid" )]
      [  XmlElement( ElementName = "OrganisationSettingid"   )]
      public Guid gxTpr_Organisationsettingid
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_OrganisationSetting_Organisationsettingid != value )
            {
               gxTv_SdtTrn_OrganisationSetting_Mode = "INS";
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = value;
            SetDirty("Organisationsettingid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_OrganisationSetting_Organisationid != value )
            {
               gxTv_SdtTrn_OrganisationSetting_Mode = "INS";
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_OrganisationSetting_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLogo" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo"   )]
      [GxUpload()]
      public string gxTpr_Organisationsettinglogo
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = value;
            SetDirty("Organisationsettinglogo");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLogo_GXI" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo_GXI"   )]
      public string gxTpr_Organisationsettinglogo_gxi
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = value;
            SetDirty("Organisationsettinglogo_gxi");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon"   )]
      [GxUpload()]
      public string gxTpr_Organisationsettingfavicon
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = value;
            SetDirty("Organisationsettingfavicon");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon_GXI" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon_GXI"   )]
      public string gxTpr_Organisationsettingfavicon_gxi
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = value;
            SetDirty("Organisationsettingfavicon_gxi");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingBaseColor" )]
      [  XmlElement( ElementName = "OrganisationSettingBaseColor"   )]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = value;
            SetDirty("Organisationsettingbasecolor");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingFontSize" )]
      [  XmlElement( ElementName = "OrganisationSettingFontSize"   )]
      public string gxTpr_Organisationsettingfontsize
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = value;
            SetDirty("Organisationsettingfontsize");
         }

      }

      [  SoapElement( ElementName = "OrganisationSettingLanguage" )]
      [  XmlElement( ElementName = "OrganisationSettingLanguage"   )]
      public string gxTpr_Organisationsettinglanguage
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = value;
            SetDirty("Organisationsettinglanguage");
         }

      }

      [  SoapElement( ElementName = "OrganisationHasMyCare" )]
      [  XmlElement( ElementName = "OrganisationHasMyCare"   )]
      public bool gxTpr_Organisationhasmycare
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare = value;
            SetDirty("Organisationhasmycare");
         }

      }

      [  SoapElement( ElementName = "OrganisationHasMyLiving" )]
      [  XmlElement( ElementName = "OrganisationHasMyLiving"   )]
      public bool gxTpr_Organisationhasmyliving
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving = value;
            SetDirty("Organisationhasmyliving");
         }

      }

      [  SoapElement( ElementName = "OrganisationHasMyServices" )]
      [  XmlElement( ElementName = "OrganisationHasMyServices"   )]
      public bool gxTpr_Organisationhasmyservices
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices = value;
            SetDirty("Organisationhasmyservices");
         }

      }

      [  SoapElement( ElementName = "OrganisationHasDynamicForms" )]
      [  XmlElement( ElementName = "OrganisationHasDynamicForms"   )]
      public bool gxTpr_Organisationhasdynamicforms
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms = value;
            SetDirty("Organisationhasdynamicforms");
         }

      }

      [  SoapElement( ElementName = "OrganisationBrandTheme" )]
      [  XmlElement( ElementName = "OrganisationBrandTheme"   )]
      public string gxTpr_Organisationbrandtheme
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme = value;
            SetDirty("Organisationbrandtheme");
         }

      }

      [  SoapElement( ElementName = "OrganisationCtaTheme" )]
      [  XmlElement( ElementName = "OrganisationCtaTheme"   )]
      public string gxTpr_Organisationctatheme
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationctatheme ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationctatheme = value;
            SetDirty("Organisationctatheme");
         }

      }

      [  SoapElement( ElementName = "OrganisationHasOwnBrand" )]
      [  XmlElement( ElementName = "OrganisationHasOwnBrand"   )]
      public bool gxTpr_Organisationhasownbrand
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand = value;
            SetDirty("Organisationhasownbrand");
         }

      }

      [  SoapElement( ElementName = "OrganisationDefinitions" )]
      [  XmlElement( ElementName = "OrganisationDefinitions"   )]
      public string gxTpr_Organisationdefinitions
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions ;
         }

         set {
            gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions = value;
            SetDirty("Organisationdefinitions");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = 1;
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions = "";
         SetDirty("Organisationdefinitions");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_IsNull( )
      {
         return (gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N==1) ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId" )]
      [  XmlElement( ElementName = "Trn_ThemeId"   )]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Trn_themeid ;
         }

         set {
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid = value;
            SetDirty("Trn_themeid");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Trn_themeid_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = 1;
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid = Guid.Empty;
         SetDirty("Trn_themeid");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Trn_themeid_IsNull( )
      {
         return (gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Mode_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Initialized_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingid_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingid_Z"   )]
      public Guid gxTpr_Organisationsettingid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = value;
            SetDirty("Organisationsettingid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = Guid.Empty;
         SetDirty("Organisationsettingid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingBaseColor_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingBaseColor_Z"   )]
      public string gxTpr_Organisationsettingbasecolor_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = value;
            SetDirty("Organisationsettingbasecolor_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = "";
         SetDirty("Organisationsettingbasecolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingFontSize_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingFontSize_Z"   )]
      public string gxTpr_Organisationsettingfontsize_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = value;
            SetDirty("Organisationsettingfontsize_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = "";
         SetDirty("Organisationsettingfontsize_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationHasMyCare_Z" )]
      [  XmlElement( ElementName = "OrganisationHasMyCare_Z"   )]
      public bool gxTpr_Organisationhasmycare_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z = value;
            SetDirty("Organisationhasmycare_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z = false;
         SetDirty("Organisationhasmycare_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationHasMyLiving_Z" )]
      [  XmlElement( ElementName = "OrganisationHasMyLiving_Z"   )]
      public bool gxTpr_Organisationhasmyliving_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z = value;
            SetDirty("Organisationhasmyliving_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z = false;
         SetDirty("Organisationhasmyliving_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationHasMyServices_Z" )]
      [  XmlElement( ElementName = "OrganisationHasMyServices_Z"   )]
      public bool gxTpr_Organisationhasmyservices_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z = value;
            SetDirty("Organisationhasmyservices_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z = false;
         SetDirty("Organisationhasmyservices_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationHasDynamicForms_Z" )]
      [  XmlElement( ElementName = "OrganisationHasDynamicForms_Z"   )]
      public bool gxTpr_Organisationhasdynamicforms_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z = value;
            SetDirty("Organisationhasdynamicforms_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z = false;
         SetDirty("Organisationhasdynamicforms_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationHasOwnBrand_Z" )]
      [  XmlElement( ElementName = "OrganisationHasOwnBrand_Z"   )]
      public bool gxTpr_Organisationhasownbrand_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z = value;
            SetDirty("Organisationhasownbrand_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z = false;
         SetDirty("Organisationhasownbrand_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeId_Z"   )]
      public Guid gxTpr_Trn_themeid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z = value;
            SetDirty("Trn_themeid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z = Guid.Empty;
         SetDirty("Trn_themeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingLogo_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingLogo_GXI_Z"   )]
      public string gxTpr_Organisationsettinglogo_gxi_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = value;
            SetDirty("Organisationsettinglogo_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = "";
         SetDirty("Organisationsettinglogo_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationSettingFavicon_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationSettingFavicon_GXI_Z"   )]
      public string gxTpr_Organisationsettingfavicon_gxi_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = value;
            SetDirty("Organisationsettingfavicon_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = "";
         SetDirty("Organisationsettingfavicon_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationDefinitions_N" )]
      [  XmlElement( ElementName = "OrganisationDefinitions_N"   )]
      public short gxTpr_Organisationdefinitions_N
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = value;
            SetDirty("Organisationdefinitions_N");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N = 0;
         SetDirty("Organisationdefinitions_N");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_N" )]
      [  XmlElement( ElementName = "Trn_ThemeId_N"   )]
      public short gxTpr_Trn_themeid_N
      {
         get {
            return gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = value;
            SetDirty("Trn_themeid_N");
         }

      }

      public void gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N_SetNull( )
      {
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N = 0;
         SetDirty("Trn_themeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N_IsNull( )
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
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_OrganisationSetting_Organisationid = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationctatheme = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions = "";
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Mode = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z = "";
         gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_organisationsetting", "GeneXus.Programs.trn_organisationsetting_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_OrganisationSetting_Initialized ;
      private short gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions_N ;
      private short gxTv_SdtTrn_OrganisationSetting_Trn_themeid_N ;
      private string gxTv_SdtTrn_OrganisationSetting_Mode ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmycare_Z ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyliving_Z ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasmyservices_Z ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasdynamicforms_Z ;
      private bool gxTv_SdtTrn_OrganisationSetting_Organisationhasownbrand_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglanguage ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationbrandtheme ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationctatheme ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationdefinitions ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingbasecolor_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfontsize_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo_gxi_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon_gxi_Z ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettinglogo ;
      private string gxTv_SdtTrn_OrganisationSetting_Organisationsettingfavicon ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationsettingid ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationid ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Trn_themeid ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationsettingid_Z ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Organisationid_Z ;
      private Guid gxTv_SdtTrn_OrganisationSetting_Trn_themeid_Z ;
   }

   [DataContract(Name = @"Trn_OrganisationSetting", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationSetting_RESTInterface : GxGenericCollectionItem<SdtTrn_OrganisationSetting>
   {
      public SdtTrn_OrganisationSetting_RESTInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationSetting_RESTInterface( SdtTrn_OrganisationSetting psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationSettingid" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationsettingid
      {
         get {
            return sdt.gxTpr_Organisationsettingid ;
         }

         set {
            sdt.gxTpr_Organisationsettingid = value;
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

      [DataMember( Name = "OrganisationSettingLogo" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Organisationsettinglogo
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationsettinglogo) : StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationsettinglogo = value;
         }

      }

      [DataMember( Name = "OrganisationSettingFavicon" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Organisationsettingfavicon
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationsettingfavicon) : StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationsettingfavicon = value;
         }

      }

      [DataMember( Name = "OrganisationSettingBaseColor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return sdt.gxTpr_Organisationsettingbasecolor ;
         }

         set {
            sdt.gxTpr_Organisationsettingbasecolor = value;
         }

      }

      [DataMember( Name = "OrganisationSettingFontSize" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingfontsize
      {
         get {
            return sdt.gxTpr_Organisationsettingfontsize ;
         }

         set {
            sdt.gxTpr_Organisationsettingfontsize = value;
         }

      }

      [DataMember( Name = "OrganisationSettingLanguage" , Order = 6 )]
      public string gxTpr_Organisationsettinglanguage
      {
         get {
            return sdt.gxTpr_Organisationsettinglanguage ;
         }

         set {
            sdt.gxTpr_Organisationsettinglanguage = value;
         }

      }

      [DataMember( Name = "OrganisationHasMyCare" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Organisationhasmycare
      {
         get {
            return sdt.gxTpr_Organisationhasmycare ;
         }

         set {
            sdt.gxTpr_Organisationhasmycare = value;
         }

      }

      [DataMember( Name = "OrganisationHasMyLiving" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Organisationhasmyliving
      {
         get {
            return sdt.gxTpr_Organisationhasmyliving ;
         }

         set {
            sdt.gxTpr_Organisationhasmyliving = value;
         }

      }

      [DataMember( Name = "OrganisationHasMyServices" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Organisationhasmyservices
      {
         get {
            return sdt.gxTpr_Organisationhasmyservices ;
         }

         set {
            sdt.gxTpr_Organisationhasmyservices = value;
         }

      }

      [DataMember( Name = "OrganisationHasDynamicForms" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Organisationhasdynamicforms
      {
         get {
            return sdt.gxTpr_Organisationhasdynamicforms ;
         }

         set {
            sdt.gxTpr_Organisationhasdynamicforms = value;
         }

      }

      [DataMember( Name = "OrganisationBrandTheme" , Order = 11 )]
      public string gxTpr_Organisationbrandtheme
      {
         get {
            return sdt.gxTpr_Organisationbrandtheme ;
         }

         set {
            sdt.gxTpr_Organisationbrandtheme = value;
         }

      }

      [DataMember( Name = "OrganisationCtaTheme" , Order = 12 )]
      public string gxTpr_Organisationctatheme
      {
         get {
            return sdt.gxTpr_Organisationctatheme ;
         }

         set {
            sdt.gxTpr_Organisationctatheme = value;
         }

      }

      [DataMember( Name = "OrganisationHasOwnBrand" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Organisationhasownbrand
      {
         get {
            return sdt.gxTpr_Organisationhasownbrand ;
         }

         set {
            sdt.gxTpr_Organisationhasownbrand = value;
         }

      }

      [DataMember( Name = "OrganisationDefinitions" , Order = 14 )]
      public string gxTpr_Organisationdefinitions
      {
         get {
            return sdt.gxTpr_Organisationdefinitions ;
         }

         set {
            sdt.gxTpr_Organisationdefinitions = value;
         }

      }

      [DataMember( Name = "Trn_ThemeId" , Order = 15 )]
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

      public SdtTrn_OrganisationSetting sdt
      {
         get {
            return (SdtTrn_OrganisationSetting)Sdt ;
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
            sdt = new SdtTrn_OrganisationSetting() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 16 )]
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

   [DataContract(Name = @"Trn_OrganisationSetting", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationSetting_RESTLInterface : GxGenericCollectionItem<SdtTrn_OrganisationSetting>
   {
      public SdtTrn_OrganisationSetting_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationSetting_RESTLInterface( SdtTrn_OrganisationSetting psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationSettingBaseColor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Organisationsettingbasecolor
      {
         get {
            return sdt.gxTpr_Organisationsettingbasecolor ;
         }

         set {
            sdt.gxTpr_Organisationsettingbasecolor = value;
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

      public SdtTrn_OrganisationSetting sdt
      {
         get {
            return (SdtTrn_OrganisationSetting)Sdt ;
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
            sdt = new SdtTrn_OrganisationSetting() ;
         }
      }

   }

}
