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
   [XmlRoot(ElementName = "Trn_Organisation" )]
   [XmlType(TypeName =  "Trn_Organisation" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Organisation : GxSilentTrnSdt
   {
      public SdtTrn_Organisation( )
      {
      }

      public SdtTrn_Organisation( IGxContext context )
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

      public void Load( Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Organisation");
         metadata.Set("BT", "Trn_Organisation");
         metadata.Set("PK", "[ \"OrganisationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationTypeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Organisationlogo_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Organisationname_Z");
         state.Add("gxTpr_Organisationkvknumber_Z");
         state.Add("gxTpr_Organisationemail_Z");
         state.Add("gxTpr_Organisationphone_Z");
         state.Add("gxTpr_Organisationphonecode_Z");
         state.Add("gxTpr_Organisationphonenumber_Z");
         state.Add("gxTpr_Organisationvatnumber_Z");
         state.Add("gxTpr_Organisationaddresscountry_Z");
         state.Add("gxTpr_Organisationaddresscity_Z");
         state.Add("gxTpr_Organisationaddresszipcode_Z");
         state.Add("gxTpr_Organisationaddressline1_Z");
         state.Add("gxTpr_Organisationaddressline2_Z");
         state.Add("gxTpr_Organisationtypeid_Z");
         state.Add("gxTpr_Organisationtypename_Z");
         state.Add("gxTpr_Organisationlogo_gxi_Z");
         state.Add("gxTpr_Organisationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Organisation sdt;
         sdt = (SdtTrn_Organisation)(source);
         gxTv_SdtTrn_Organisation_Organisationid = sdt.gxTv_SdtTrn_Organisation_Organisationid ;
         gxTv_SdtTrn_Organisation_Organisationname = sdt.gxTv_SdtTrn_Organisation_Organisationname ;
         gxTv_SdtTrn_Organisation_Organisationkvknumber = sdt.gxTv_SdtTrn_Organisation_Organisationkvknumber ;
         gxTv_SdtTrn_Organisation_Organisationemail = sdt.gxTv_SdtTrn_Organisation_Organisationemail ;
         gxTv_SdtTrn_Organisation_Organisationphone = sdt.gxTv_SdtTrn_Organisation_Organisationphone ;
         gxTv_SdtTrn_Organisation_Organisationphonecode = sdt.gxTv_SdtTrn_Organisation_Organisationphonecode ;
         gxTv_SdtTrn_Organisation_Organisationphonenumber = sdt.gxTv_SdtTrn_Organisation_Organisationphonenumber ;
         gxTv_SdtTrn_Organisation_Organisationvatnumber = sdt.gxTv_SdtTrn_Organisation_Organisationvatnumber ;
         gxTv_SdtTrn_Organisation_Organisationlogo = sdt.gxTv_SdtTrn_Organisation_Organisationlogo ;
         gxTv_SdtTrn_Organisation_Organisationlogo_gxi = sdt.gxTv_SdtTrn_Organisation_Organisationlogo_gxi ;
         gxTv_SdtTrn_Organisation_Organisationaddresscountry = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscountry ;
         gxTv_SdtTrn_Organisation_Organisationaddresscity = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscity ;
         gxTv_SdtTrn_Organisation_Organisationaddresszipcode = sdt.gxTv_SdtTrn_Organisation_Organisationaddresszipcode ;
         gxTv_SdtTrn_Organisation_Organisationaddressline1 = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline1 ;
         gxTv_SdtTrn_Organisation_Organisationaddressline2 = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline2 ;
         gxTv_SdtTrn_Organisation_Organisationtypeid = sdt.gxTv_SdtTrn_Organisation_Organisationtypeid ;
         gxTv_SdtTrn_Organisation_Organisationtypename = sdt.gxTv_SdtTrn_Organisation_Organisationtypename ;
         gxTv_SdtTrn_Organisation_Mode = sdt.gxTv_SdtTrn_Organisation_Mode ;
         gxTv_SdtTrn_Organisation_Initialized = sdt.gxTv_SdtTrn_Organisation_Initialized ;
         gxTv_SdtTrn_Organisation_Organisationid_Z = sdt.gxTv_SdtTrn_Organisation_Organisationid_Z ;
         gxTv_SdtTrn_Organisation_Organisationname_Z = sdt.gxTv_SdtTrn_Organisation_Organisationname_Z ;
         gxTv_SdtTrn_Organisation_Organisationkvknumber_Z = sdt.gxTv_SdtTrn_Organisation_Organisationkvknumber_Z ;
         gxTv_SdtTrn_Organisation_Organisationemail_Z = sdt.gxTv_SdtTrn_Organisation_Organisationemail_Z ;
         gxTv_SdtTrn_Organisation_Organisationphone_Z = sdt.gxTv_SdtTrn_Organisation_Organisationphone_Z ;
         gxTv_SdtTrn_Organisation_Organisationphonecode_Z = sdt.gxTv_SdtTrn_Organisation_Organisationphonecode_Z ;
         gxTv_SdtTrn_Organisation_Organisationphonenumber_Z = sdt.gxTv_SdtTrn_Organisation_Organisationphonenumber_Z ;
         gxTv_SdtTrn_Organisation_Organisationvatnumber_Z = sdt.gxTv_SdtTrn_Organisation_Organisationvatnumber_Z ;
         gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z ;
         gxTv_SdtTrn_Organisation_Organisationaddresscity_Z = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscity_Z ;
         gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z = sdt.gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z ;
         gxTv_SdtTrn_Organisation_Organisationaddressline1_Z = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline1_Z ;
         gxTv_SdtTrn_Organisation_Organisationaddressline2_Z = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline2_Z ;
         gxTv_SdtTrn_Organisation_Organisationtypeid_Z = sdt.gxTv_SdtTrn_Organisation_Organisationtypeid_Z ;
         gxTv_SdtTrn_Organisation_Organisationtypename_Z = sdt.gxTv_SdtTrn_Organisation_Organisationtypename_Z ;
         gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z = sdt.gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z ;
         gxTv_SdtTrn_Organisation_Organisationid_N = sdt.gxTv_SdtTrn_Organisation_Organisationid_N ;
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
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Organisation_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Organisation_Organisationid_N, false, includeNonInitialized);
         AddObjectProperty("OrganisationName", gxTv_SdtTrn_Organisation_Organisationname, false, includeNonInitialized);
         AddObjectProperty("OrganisationKvkNumber", gxTv_SdtTrn_Organisation_Organisationkvknumber, false, includeNonInitialized);
         AddObjectProperty("OrganisationEmail", gxTv_SdtTrn_Organisation_Organisationemail, false, includeNonInitialized);
         AddObjectProperty("OrganisationPhone", gxTv_SdtTrn_Organisation_Organisationphone, false, includeNonInitialized);
         AddObjectProperty("OrganisationPhoneCode", gxTv_SdtTrn_Organisation_Organisationphonecode, false, includeNonInitialized);
         AddObjectProperty("OrganisationPhoneNumber", gxTv_SdtTrn_Organisation_Organisationphonenumber, false, includeNonInitialized);
         AddObjectProperty("OrganisationVATNumber", gxTv_SdtTrn_Organisation_Organisationvatnumber, false, includeNonInitialized);
         AddObjectProperty("OrganisationLogo", gxTv_SdtTrn_Organisation_Organisationlogo, false, includeNonInitialized);
         AddObjectProperty("OrganisationAddressCountry", gxTv_SdtTrn_Organisation_Organisationaddresscountry, false, includeNonInitialized);
         AddObjectProperty("OrganisationAddressCity", gxTv_SdtTrn_Organisation_Organisationaddresscity, false, includeNonInitialized);
         AddObjectProperty("OrganisationAddressZipCode", gxTv_SdtTrn_Organisation_Organisationaddresszipcode, false, includeNonInitialized);
         AddObjectProperty("OrganisationAddressLine1", gxTv_SdtTrn_Organisation_Organisationaddressline1, false, includeNonInitialized);
         AddObjectProperty("OrganisationAddressLine2", gxTv_SdtTrn_Organisation_Organisationaddressline2, false, includeNonInitialized);
         AddObjectProperty("OrganisationTypeId", gxTv_SdtTrn_Organisation_Organisationtypeid, false, includeNonInitialized);
         AddObjectProperty("OrganisationTypeName", gxTv_SdtTrn_Organisation_Organisationtypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("OrganisationLogo_GXI", gxTv_SdtTrn_Organisation_Organisationlogo_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Organisation_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Organisation_Initialized, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Organisation_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationName_Z", gxTv_SdtTrn_Organisation_Organisationname_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationKvkNumber_Z", gxTv_SdtTrn_Organisation_Organisationkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationEmail_Z", gxTv_SdtTrn_Organisation_Organisationemail_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationPhone_Z", gxTv_SdtTrn_Organisation_Organisationphone_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationPhoneCode_Z", gxTv_SdtTrn_Organisation_Organisationphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationPhoneNumber_Z", gxTv_SdtTrn_Organisation_Organisationphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationVATNumber_Z", gxTv_SdtTrn_Organisation_Organisationvatnumber_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationAddressCountry_Z", gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationAddressCity_Z", gxTv_SdtTrn_Organisation_Organisationaddresscity_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationAddressZipCode_Z", gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationAddressLine1_Z", gxTv_SdtTrn_Organisation_Organisationaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationAddressLine2_Z", gxTv_SdtTrn_Organisation_Organisationaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationTypeId_Z", gxTv_SdtTrn_Organisation_Organisationtypeid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationTypeName_Z", gxTv_SdtTrn_Organisation_Organisationtypename_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationLogo_GXI_Z", gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Organisation_Organisationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Organisation sdt )
      {
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationid = sdt.gxTv_SdtTrn_Organisation_Organisationid ;
         }
         if ( sdt.IsDirty("OrganisationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationname = sdt.gxTv_SdtTrn_Organisation_Organisationname ;
         }
         if ( sdt.IsDirty("OrganisationKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationkvknumber = sdt.gxTv_SdtTrn_Organisation_Organisationkvknumber ;
         }
         if ( sdt.IsDirty("OrganisationEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationemail = sdt.gxTv_SdtTrn_Organisation_Organisationemail ;
         }
         if ( sdt.IsDirty("OrganisationPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphone = sdt.gxTv_SdtTrn_Organisation_Organisationphone ;
         }
         if ( sdt.IsDirty("OrganisationPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonecode = sdt.gxTv_SdtTrn_Organisation_Organisationphonecode ;
         }
         if ( sdt.IsDirty("OrganisationPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonenumber = sdt.gxTv_SdtTrn_Organisation_Organisationphonenumber ;
         }
         if ( sdt.IsDirty("OrganisationVATNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationvatnumber = sdt.gxTv_SdtTrn_Organisation_Organisationvatnumber ;
         }
         if ( sdt.IsDirty("OrganisationLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationlogo = sdt.gxTv_SdtTrn_Organisation_Organisationlogo ;
         }
         if ( sdt.IsDirty("OrganisationLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationlogo_gxi = sdt.gxTv_SdtTrn_Organisation_Organisationlogo_gxi ;
         }
         if ( sdt.IsDirty("OrganisationAddressCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscountry = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscountry ;
         }
         if ( sdt.IsDirty("OrganisationAddressCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscity = sdt.gxTv_SdtTrn_Organisation_Organisationaddresscity ;
         }
         if ( sdt.IsDirty("OrganisationAddressZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresszipcode = sdt.gxTv_SdtTrn_Organisation_Organisationaddresszipcode ;
         }
         if ( sdt.IsDirty("OrganisationAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline1 = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline1 ;
         }
         if ( sdt.IsDirty("OrganisationAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline2 = sdt.gxTv_SdtTrn_Organisation_Organisationaddressline2 ;
         }
         if ( sdt.IsDirty("OrganisationTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypeid = sdt.gxTv_SdtTrn_Organisation_Organisationtypeid ;
         }
         if ( sdt.IsDirty("OrganisationTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypename = sdt.gxTv_SdtTrn_Organisation_Organisationtypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Organisation_Organisationid != value )
            {
               gxTv_SdtTrn_Organisation_Mode = "INS";
               this.gxTv_SdtTrn_Organisation_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationname_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationkvknumber_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationemail_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationphone_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationvatnumber_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationaddresscity_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationtypeid_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationtypename_Z_SetNull( );
               this.gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Organisation_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationName" )]
      [  XmlElement( ElementName = "OrganisationName"   )]
      public string gxTpr_Organisationname
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationname = value;
            SetDirty("Organisationname");
         }

      }

      [  SoapElement( ElementName = "OrganisationKvkNumber" )]
      [  XmlElement( ElementName = "OrganisationKvkNumber"   )]
      public string gxTpr_Organisationkvknumber
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationkvknumber = value;
            SetDirty("Organisationkvknumber");
         }

      }

      [  SoapElement( ElementName = "OrganisationEmail" )]
      [  XmlElement( ElementName = "OrganisationEmail"   )]
      public string gxTpr_Organisationemail
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationemail = value;
            SetDirty("Organisationemail");
         }

      }

      [  SoapElement( ElementName = "OrganisationPhone" )]
      [  XmlElement( ElementName = "OrganisationPhone"   )]
      public string gxTpr_Organisationphone
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphone = value;
            SetDirty("Organisationphone");
         }

      }

      [  SoapElement( ElementName = "OrganisationPhoneCode" )]
      [  XmlElement( ElementName = "OrganisationPhoneCode"   )]
      public string gxTpr_Organisationphonecode
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonecode = value;
            SetDirty("Organisationphonecode");
         }

      }

      [  SoapElement( ElementName = "OrganisationPhoneNumber" )]
      [  XmlElement( ElementName = "OrganisationPhoneNumber"   )]
      public string gxTpr_Organisationphonenumber
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonenumber = value;
            SetDirty("Organisationphonenumber");
         }

      }

      [  SoapElement( ElementName = "OrganisationVATNumber" )]
      [  XmlElement( ElementName = "OrganisationVATNumber"   )]
      public string gxTpr_Organisationvatnumber
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationvatnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationvatnumber = value;
            SetDirty("Organisationvatnumber");
         }

      }

      [  SoapElement( ElementName = "OrganisationLogo" )]
      [  XmlElement( ElementName = "OrganisationLogo"   )]
      [GxUpload()]
      public string gxTpr_Organisationlogo
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationlogo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationlogo = value;
            SetDirty("Organisationlogo");
         }

      }

      [  SoapElement( ElementName = "OrganisationLogo_GXI" )]
      [  XmlElement( ElementName = "OrganisationLogo_GXI"   )]
      public string gxTpr_Organisationlogo_gxi
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationlogo_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationlogo_gxi = value;
            SetDirty("Organisationlogo_gxi");
         }

      }

      [  SoapElement( ElementName = "OrganisationAddressCountry" )]
      [  XmlElement( ElementName = "OrganisationAddressCountry"   )]
      public string gxTpr_Organisationaddresscountry
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresscountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscountry = value;
            SetDirty("Organisationaddresscountry");
         }

      }

      [  SoapElement( ElementName = "OrganisationAddressCity" )]
      [  XmlElement( ElementName = "OrganisationAddressCity"   )]
      public string gxTpr_Organisationaddresscity
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresscity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscity = value;
            SetDirty("Organisationaddresscity");
         }

      }

      [  SoapElement( ElementName = "OrganisationAddressZipCode" )]
      [  XmlElement( ElementName = "OrganisationAddressZipCode"   )]
      public string gxTpr_Organisationaddresszipcode
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresszipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresszipcode = value;
            SetDirty("Organisationaddresszipcode");
         }

      }

      [  SoapElement( ElementName = "OrganisationAddressLine1" )]
      [  XmlElement( ElementName = "OrganisationAddressLine1"   )]
      public string gxTpr_Organisationaddressline1
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline1 = value;
            SetDirty("Organisationaddressline1");
         }

      }

      [  SoapElement( ElementName = "OrganisationAddressLine2" )]
      [  XmlElement( ElementName = "OrganisationAddressLine2"   )]
      public string gxTpr_Organisationaddressline2
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline2 = value;
            SetDirty("Organisationaddressline2");
         }

      }

      [  SoapElement( ElementName = "OrganisationTypeId" )]
      [  XmlElement( ElementName = "OrganisationTypeId"   )]
      public Guid gxTpr_Organisationtypeid
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationtypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypeid = value;
            SetDirty("Organisationtypeid");
         }

      }

      [  SoapElement( ElementName = "OrganisationTypeName" )]
      [  XmlElement( ElementName = "OrganisationTypeName"   )]
      public string gxTpr_Organisationtypename
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationtypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypename = value;
            SetDirty("Organisationtypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Organisation_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Organisation_Mode_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Organisation_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Organisation_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationName_Z" )]
      [  XmlElement( ElementName = "OrganisationName_Z"   )]
      public string gxTpr_Organisationname_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationname_Z = value;
            SetDirty("Organisationname_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationname_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationname_Z = "";
         SetDirty("Organisationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationKvkNumber_Z" )]
      [  XmlElement( ElementName = "OrganisationKvkNumber_Z"   )]
      public string gxTpr_Organisationkvknumber_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationkvknumber_Z = value;
            SetDirty("Organisationkvknumber_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationkvknumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationkvknumber_Z = "";
         SetDirty("Organisationkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationEmail_Z" )]
      [  XmlElement( ElementName = "OrganisationEmail_Z"   )]
      public string gxTpr_Organisationemail_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationemail_Z = value;
            SetDirty("Organisationemail_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationemail_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationemail_Z = "";
         SetDirty("Organisationemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationPhone_Z" )]
      [  XmlElement( ElementName = "OrganisationPhone_Z"   )]
      public string gxTpr_Organisationphone_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphone_Z = value;
            SetDirty("Organisationphone_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationphone_Z = "";
         SetDirty("Organisationphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationPhoneCode_Z" )]
      [  XmlElement( ElementName = "OrganisationPhoneCode_Z"   )]
      public string gxTpr_Organisationphonecode_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonecode_Z = value;
            SetDirty("Organisationphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationphonecode_Z = "";
         SetDirty("Organisationphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationPhoneNumber_Z" )]
      [  XmlElement( ElementName = "OrganisationPhoneNumber_Z"   )]
      public string gxTpr_Organisationphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationphonenumber_Z = value;
            SetDirty("Organisationphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationphonenumber_Z = "";
         SetDirty("Organisationphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationVATNumber_Z" )]
      [  XmlElement( ElementName = "OrganisationVATNumber_Z"   )]
      public string gxTpr_Organisationvatnumber_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationvatnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationvatnumber_Z = value;
            SetDirty("Organisationvatnumber_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationvatnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationvatnumber_Z = "";
         SetDirty("Organisationvatnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationvatnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationAddressCountry_Z" )]
      [  XmlElement( ElementName = "OrganisationAddressCountry_Z"   )]
      public string gxTpr_Organisationaddresscountry_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z = value;
            SetDirty("Organisationaddresscountry_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z = "";
         SetDirty("Organisationaddresscountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationAddressCity_Z" )]
      [  XmlElement( ElementName = "OrganisationAddressCity_Z"   )]
      public string gxTpr_Organisationaddresscity_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresscity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresscity_Z = value;
            SetDirty("Organisationaddresscity_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationaddresscity_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationaddresscity_Z = "";
         SetDirty("Organisationaddresscity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationaddresscity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationAddressZipCode_Z" )]
      [  XmlElement( ElementName = "OrganisationAddressZipCode_Z"   )]
      public string gxTpr_Organisationaddresszipcode_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z = value;
            SetDirty("Organisationaddresszipcode_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z = "";
         SetDirty("Organisationaddresszipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationAddressLine1_Z" )]
      [  XmlElement( ElementName = "OrganisationAddressLine1_Z"   )]
      public string gxTpr_Organisationaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline1_Z = value;
            SetDirty("Organisationaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationaddressline1_Z = "";
         SetDirty("Organisationaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationAddressLine2_Z" )]
      [  XmlElement( ElementName = "OrganisationAddressLine2_Z"   )]
      public string gxTpr_Organisationaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationaddressline2_Z = value;
            SetDirty("Organisationaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationaddressline2_Z = "";
         SetDirty("Organisationaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationTypeId_Z" )]
      [  XmlElement( ElementName = "OrganisationTypeId_Z"   )]
      public Guid gxTpr_Organisationtypeid_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationtypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypeid_Z = value;
            SetDirty("Organisationtypeid_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationtypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationtypeid_Z = Guid.Empty;
         SetDirty("Organisationtypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationtypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationTypeName_Z" )]
      [  XmlElement( ElementName = "OrganisationTypeName_Z"   )]
      public string gxTpr_Organisationtypename_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationtypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationtypename_Z = value;
            SetDirty("Organisationtypename_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationtypename_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationtypename_Z = "";
         SetDirty("Organisationtypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationtypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationLogo_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationLogo_GXI_Z"   )]
      public string gxTpr_Organisationlogo_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z = value;
            SetDirty("Organisationlogo_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z = "";
         SetDirty("Organisationlogo_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_N" )]
      [  XmlElement( ElementName = "OrganisationId_N"   )]
      public short gxTpr_Organisationid_N
      {
         get {
            return gxTv_SdtTrn_Organisation_Organisationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Organisation_Organisationid_N = value;
            SetDirty("Organisationid_N");
         }

      }

      public void gxTv_SdtTrn_Organisation_Organisationid_N_SetNull( )
      {
         gxTv_SdtTrn_Organisation_Organisationid_N = 0;
         SetDirty("Organisationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Organisation_Organisationid_N_IsNull( )
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
         gxTv_SdtTrn_Organisation_Organisationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Organisation_Organisationname = "";
         gxTv_SdtTrn_Organisation_Organisationkvknumber = "";
         gxTv_SdtTrn_Organisation_Organisationemail = "";
         gxTv_SdtTrn_Organisation_Organisationphone = "";
         gxTv_SdtTrn_Organisation_Organisationphonecode = "";
         gxTv_SdtTrn_Organisation_Organisationphonenumber = "";
         gxTv_SdtTrn_Organisation_Organisationvatnumber = "";
         gxTv_SdtTrn_Organisation_Organisationlogo = "";
         gxTv_SdtTrn_Organisation_Organisationlogo_gxi = "";
         gxTv_SdtTrn_Organisation_Organisationaddresscountry = "";
         gxTv_SdtTrn_Organisation_Organisationaddresscity = "";
         gxTv_SdtTrn_Organisation_Organisationaddresszipcode = "";
         gxTv_SdtTrn_Organisation_Organisationaddressline1 = "";
         gxTv_SdtTrn_Organisation_Organisationaddressline2 = "";
         gxTv_SdtTrn_Organisation_Organisationtypeid = Guid.Empty;
         gxTv_SdtTrn_Organisation_Organisationtypename = "";
         gxTv_SdtTrn_Organisation_Mode = "";
         gxTv_SdtTrn_Organisation_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Organisation_Organisationname_Z = "";
         gxTv_SdtTrn_Organisation_Organisationkvknumber_Z = "";
         gxTv_SdtTrn_Organisation_Organisationemail_Z = "";
         gxTv_SdtTrn_Organisation_Organisationphone_Z = "";
         gxTv_SdtTrn_Organisation_Organisationphonecode_Z = "";
         gxTv_SdtTrn_Organisation_Organisationphonenumber_Z = "";
         gxTv_SdtTrn_Organisation_Organisationvatnumber_Z = "";
         gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z = "";
         gxTv_SdtTrn_Organisation_Organisationaddresscity_Z = "";
         gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z = "";
         gxTv_SdtTrn_Organisation_Organisationaddressline1_Z = "";
         gxTv_SdtTrn_Organisation_Organisationaddressline2_Z = "";
         gxTv_SdtTrn_Organisation_Organisationtypeid_Z = Guid.Empty;
         gxTv_SdtTrn_Organisation_Organisationtypename_Z = "";
         gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_organisation", "GeneXus.Programs.trn_organisation_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Organisation_Initialized ;
      private short gxTv_SdtTrn_Organisation_Organisationid_N ;
      private string gxTv_SdtTrn_Organisation_Organisationphone ;
      private string gxTv_SdtTrn_Organisation_Mode ;
      private string gxTv_SdtTrn_Organisation_Organisationphone_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationname ;
      private string gxTv_SdtTrn_Organisation_Organisationkvknumber ;
      private string gxTv_SdtTrn_Organisation_Organisationemail ;
      private string gxTv_SdtTrn_Organisation_Organisationphonecode ;
      private string gxTv_SdtTrn_Organisation_Organisationphonenumber ;
      private string gxTv_SdtTrn_Organisation_Organisationvatnumber ;
      private string gxTv_SdtTrn_Organisation_Organisationlogo_gxi ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresscountry ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresscity ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresszipcode ;
      private string gxTv_SdtTrn_Organisation_Organisationaddressline1 ;
      private string gxTv_SdtTrn_Organisation_Organisationaddressline2 ;
      private string gxTv_SdtTrn_Organisation_Organisationtypename ;
      private string gxTv_SdtTrn_Organisation_Organisationname_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationkvknumber_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationemail_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationphonecode_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationphonenumber_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationvatnumber_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresscountry_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresscity_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationaddresszipcode_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationaddressline1_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationaddressline2_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationtypename_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationlogo_gxi_Z ;
      private string gxTv_SdtTrn_Organisation_Organisationlogo ;
      private Guid gxTv_SdtTrn_Organisation_Organisationid ;
      private Guid gxTv_SdtTrn_Organisation_Organisationtypeid ;
      private Guid gxTv_SdtTrn_Organisation_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Organisation_Organisationtypeid_Z ;
   }

   [DataContract(Name = @"Trn_Organisation", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Organisation_RESTInterface : GxGenericCollectionItem<SdtTrn_Organisation>
   {
      public SdtTrn_Organisation_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Organisation_RESTInterface( SdtTrn_Organisation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationId" , Order = 0 )]
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

      [DataMember( Name = "OrganisationName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Organisationname
      {
         get {
            return sdt.gxTpr_Organisationname ;
         }

         set {
            sdt.gxTpr_Organisationname = value;
         }

      }

      [DataMember( Name = "OrganisationKvkNumber" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Organisationkvknumber
      {
         get {
            return sdt.gxTpr_Organisationkvknumber ;
         }

         set {
            sdt.gxTpr_Organisationkvknumber = value;
         }

      }

      [DataMember( Name = "OrganisationEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Organisationemail
      {
         get {
            return sdt.gxTpr_Organisationemail ;
         }

         set {
            sdt.gxTpr_Organisationemail = value;
         }

      }

      [DataMember( Name = "OrganisationPhone" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Organisationphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Organisationphone) ;
         }

         set {
            sdt.gxTpr_Organisationphone = value;
         }

      }

      [DataMember( Name = "OrganisationPhoneCode" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Organisationphonecode
      {
         get {
            return sdt.gxTpr_Organisationphonecode ;
         }

         set {
            sdt.gxTpr_Organisationphonecode = value;
         }

      }

      [DataMember( Name = "OrganisationPhoneNumber" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Organisationphonenumber
      {
         get {
            return sdt.gxTpr_Organisationphonenumber ;
         }

         set {
            sdt.gxTpr_Organisationphonenumber = value;
         }

      }

      [DataMember( Name = "OrganisationVATNumber" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Organisationvatnumber
      {
         get {
            return sdt.gxTpr_Organisationvatnumber ;
         }

         set {
            sdt.gxTpr_Organisationvatnumber = value;
         }

      }

      [DataMember( Name = "OrganisationLogo" , Order = 8 )]
      [GxUpload()]
      public string gxTpr_Organisationlogo
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationlogo)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationlogo) : StringUtil.RTrim( sdt.gxTpr_Organisationlogo_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationlogo = value;
         }

      }

      [DataMember( Name = "OrganisationAddressCountry" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Organisationaddresscountry
      {
         get {
            return sdt.gxTpr_Organisationaddresscountry ;
         }

         set {
            sdt.gxTpr_Organisationaddresscountry = value;
         }

      }

      [DataMember( Name = "OrganisationAddressCity" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Organisationaddresscity
      {
         get {
            return sdt.gxTpr_Organisationaddresscity ;
         }

         set {
            sdt.gxTpr_Organisationaddresscity = value;
         }

      }

      [DataMember( Name = "OrganisationAddressZipCode" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Organisationaddresszipcode
      {
         get {
            return sdt.gxTpr_Organisationaddresszipcode ;
         }

         set {
            sdt.gxTpr_Organisationaddresszipcode = value;
         }

      }

      [DataMember( Name = "OrganisationAddressLine1" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Organisationaddressline1
      {
         get {
            return sdt.gxTpr_Organisationaddressline1 ;
         }

         set {
            sdt.gxTpr_Organisationaddressline1 = value;
         }

      }

      [DataMember( Name = "OrganisationAddressLine2" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Organisationaddressline2
      {
         get {
            return sdt.gxTpr_Organisationaddressline2 ;
         }

         set {
            sdt.gxTpr_Organisationaddressline2 = value;
         }

      }

      [DataMember( Name = "OrganisationTypeId" , Order = 14 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationtypeid
      {
         get {
            return sdt.gxTpr_Organisationtypeid ;
         }

         set {
            sdt.gxTpr_Organisationtypeid = value;
         }

      }

      [DataMember( Name = "OrganisationTypeName" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Organisationtypename
      {
         get {
            return sdt.gxTpr_Organisationtypename ;
         }

         set {
            sdt.gxTpr_Organisationtypename = value;
         }

      }

      public SdtTrn_Organisation sdt
      {
         get {
            return (SdtTrn_Organisation)Sdt ;
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
            sdt = new SdtTrn_Organisation() ;
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

   [DataContract(Name = @"Trn_Organisation", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Organisation_RESTLInterface : GxGenericCollectionItem<SdtTrn_Organisation>
   {
      public SdtTrn_Organisation_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Organisation_RESTLInterface( SdtTrn_Organisation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Organisationname
      {
         get {
            return sdt.gxTpr_Organisationname ;
         }

         set {
            sdt.gxTpr_Organisationname = value;
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

      public SdtTrn_Organisation sdt
      {
         get {
            return (SdtTrn_Organisation)Sdt ;
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
            sdt = new SdtTrn_Organisation() ;
         }
      }

   }

}
