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
   [XmlRoot(ElementName = "Trn_NetworkCompany" )]
   [XmlType(TypeName =  "Trn_NetworkCompany" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_NetworkCompany : GxSilentTrnSdt
   {
      public SdtTrn_NetworkCompany( )
      {
      }

      public SdtTrn_NetworkCompany( IGxContext context )
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

      public void Load( Guid AV82NetworkCompanyId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV82NetworkCompanyId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NetworkCompanyId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_NetworkCompany");
         metadata.Set("BT", "Trn_NetworkCompany");
         metadata.Set("PK", "[ \"NetworkCompanyId\" ]");
         metadata.Set("PKAssigned", "[ \"NetworkCompanyId\" ]");
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
         state.Add("gxTpr_Networkcompanyid_Z");
         state.Add("gxTpr_Networkcompanykvknumber_Z");
         state.Add("gxTpr_Networkcompanyname_Z");
         state.Add("gxTpr_Networkcompanycontactname_Z");
         state.Add("gxTpr_Networkcompanyemail_Z");
         state.Add("gxTpr_Networkcompanyphone_Z");
         state.Add("gxTpr_Networkcompanyphonecode_Z");
         state.Add("gxTpr_Networkcompanyphonenumber_Z");
         state.Add("gxTpr_Networkcompanycountry_Z");
         state.Add("gxTpr_Networkcompanycity_Z");
         state.Add("gxTpr_Networkcompanyzipcode_Z");
         state.Add("gxTpr_Networkcompanyaddressline1_Z");
         state.Add("gxTpr_Networkcompanyaddressline2_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_NetworkCompany sdt;
         sdt = (SdtTrn_NetworkCompany)(source);
         gxTv_SdtTrn_NetworkCompany_Networkcompanyid = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyid ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyname = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyname ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyemail = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyemail ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphone = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphone ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycountry = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycountry ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycity = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycity ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 ;
         gxTv_SdtTrn_NetworkCompany_Mode = sdt.gxTv_SdtTrn_NetworkCompany_Mode ;
         gxTv_SdtTrn_NetworkCompany_Initialized = sdt.gxTv_SdtTrn_NetworkCompany_Initialized ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z ;
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z ;
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
         AddObjectProperty("NetworkCompanyId", gxTv_SdtTrn_NetworkCompany_Networkcompanyid, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyKvkNumber", gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyName", gxTv_SdtTrn_NetworkCompany_Networkcompanyname, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyContactName", gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyEmail", gxTv_SdtTrn_NetworkCompany_Networkcompanyemail, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyPhone", gxTv_SdtTrn_NetworkCompany_Networkcompanyphone, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyPhoneCode", gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyPhoneNumber", gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyCountry", gxTv_SdtTrn_NetworkCompany_Networkcompanycountry, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyCity", gxTv_SdtTrn_NetworkCompany_Networkcompanycity, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyZipCode", gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyAddressLine1", gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1, false, includeNonInitialized);
         AddObjectProperty("NetworkCompanyAddressLine2", gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_NetworkCompany_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_NetworkCompany_Initialized, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyId_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyKvkNumber_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyName_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyContactName_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyEmail_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyPhone_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyPhoneCode_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyPhoneNumber_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyCountry_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyCity_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyZipCode_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyAddressLine1_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkCompanyAddressLine2_Z", gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_NetworkCompany sdt )
      {
         if ( sdt.IsDirty("NetworkCompanyId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyid = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyid ;
         }
         if ( sdt.IsDirty("NetworkCompanyKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber ;
         }
         if ( sdt.IsDirty("NetworkCompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyname = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyname ;
         }
         if ( sdt.IsDirty("NetworkCompanyContactName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname ;
         }
         if ( sdt.IsDirty("NetworkCompanyEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyemail = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyemail ;
         }
         if ( sdt.IsDirty("NetworkCompanyPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphone = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphone ;
         }
         if ( sdt.IsDirty("NetworkCompanyPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode ;
         }
         if ( sdt.IsDirty("NetworkCompanyPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber ;
         }
         if ( sdt.IsDirty("NetworkCompanyCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycountry = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycountry ;
         }
         if ( sdt.IsDirty("NetworkCompanyCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycity = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanycity ;
         }
         if ( sdt.IsDirty("NetworkCompanyZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode ;
         }
         if ( sdt.IsDirty("NetworkCompanyAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 ;
         }
         if ( sdt.IsDirty("NetworkCompanyAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 = sdt.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NetworkCompanyId" )]
      [  XmlElement( ElementName = "NetworkCompanyId"   )]
      public Guid gxTpr_Networkcompanyid
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_NetworkCompany_Networkcompanyid != value )
            {
               gxTv_SdtTrn_NetworkCompany_Mode = "INS";
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z_SetNull( );
            }
            gxTv_SdtTrn_NetworkCompany_Networkcompanyid = value;
            SetDirty("Networkcompanyid");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyKvkNumber" )]
      [  XmlElement( ElementName = "NetworkCompanyKvkNumber"   )]
      public string gxTpr_Networkcompanykvknumber
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber = value;
            SetDirty("Networkcompanykvknumber");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyName" )]
      [  XmlElement( ElementName = "NetworkCompanyName"   )]
      public string gxTpr_Networkcompanyname
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyname = value;
            SetDirty("Networkcompanyname");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyContactName" )]
      [  XmlElement( ElementName = "NetworkCompanyContactName"   )]
      public string gxTpr_Networkcompanycontactname
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname = value;
            SetDirty("Networkcompanycontactname");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyEmail" )]
      [  XmlElement( ElementName = "NetworkCompanyEmail"   )]
      public string gxTpr_Networkcompanyemail
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyemail = value;
            SetDirty("Networkcompanyemail");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyPhone" )]
      [  XmlElement( ElementName = "NetworkCompanyPhone"   )]
      public string gxTpr_Networkcompanyphone
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphone = value;
            SetDirty("Networkcompanyphone");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyPhoneCode" )]
      [  XmlElement( ElementName = "NetworkCompanyPhoneCode"   )]
      public string gxTpr_Networkcompanyphonecode
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode = value;
            SetDirty("Networkcompanyphonecode");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyPhoneNumber" )]
      [  XmlElement( ElementName = "NetworkCompanyPhoneNumber"   )]
      public string gxTpr_Networkcompanyphonenumber
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber = value;
            SetDirty("Networkcompanyphonenumber");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyCountry" )]
      [  XmlElement( ElementName = "NetworkCompanyCountry"   )]
      public string gxTpr_Networkcompanycountry
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycountry = value;
            SetDirty("Networkcompanycountry");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyCity" )]
      [  XmlElement( ElementName = "NetworkCompanyCity"   )]
      public string gxTpr_Networkcompanycity
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycity = value;
            SetDirty("Networkcompanycity");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyZipCode" )]
      [  XmlElement( ElementName = "NetworkCompanyZipCode"   )]
      public string gxTpr_Networkcompanyzipcode
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode = value;
            SetDirty("Networkcompanyzipcode");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyAddressLine1" )]
      [  XmlElement( ElementName = "NetworkCompanyAddressLine1"   )]
      public string gxTpr_Networkcompanyaddressline1
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 = value;
            SetDirty("Networkcompanyaddressline1");
         }

      }

      [  SoapElement( ElementName = "NetworkCompanyAddressLine2" )]
      [  XmlElement( ElementName = "NetworkCompanyAddressLine2"   )]
      public string gxTpr_Networkcompanyaddressline2
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 = value;
            SetDirty("Networkcompanyaddressline2");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Mode_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Initialized_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyId_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyId_Z"   )]
      public Guid gxTpr_Networkcompanyid_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z = value;
            SetDirty("Networkcompanyid_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z = Guid.Empty;
         SetDirty("Networkcompanyid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyKvkNumber_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyKvkNumber_Z"   )]
      public string gxTpr_Networkcompanykvknumber_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z = value;
            SetDirty("Networkcompanykvknumber_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z = "";
         SetDirty("Networkcompanykvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyName_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyName_Z"   )]
      public string gxTpr_Networkcompanyname_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z = value;
            SetDirty("Networkcompanyname_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z = "";
         SetDirty("Networkcompanyname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyContactName_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyContactName_Z"   )]
      public string gxTpr_Networkcompanycontactname_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z = value;
            SetDirty("Networkcompanycontactname_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z = "";
         SetDirty("Networkcompanycontactname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyEmail_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyEmail_Z"   )]
      public string gxTpr_Networkcompanyemail_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z = value;
            SetDirty("Networkcompanyemail_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z = "";
         SetDirty("Networkcompanyemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyPhone_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyPhone_Z"   )]
      public string gxTpr_Networkcompanyphone_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z = value;
            SetDirty("Networkcompanyphone_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z = "";
         SetDirty("Networkcompanyphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyPhoneCode_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyPhoneCode_Z"   )]
      public string gxTpr_Networkcompanyphonecode_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z = value;
            SetDirty("Networkcompanyphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z = "";
         SetDirty("Networkcompanyphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyPhoneNumber_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyPhoneNumber_Z"   )]
      public string gxTpr_Networkcompanyphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z = value;
            SetDirty("Networkcompanyphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z = "";
         SetDirty("Networkcompanyphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyCountry_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyCountry_Z"   )]
      public string gxTpr_Networkcompanycountry_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z = value;
            SetDirty("Networkcompanycountry_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z = "";
         SetDirty("Networkcompanycountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyCity_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyCity_Z"   )]
      public string gxTpr_Networkcompanycity_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z = value;
            SetDirty("Networkcompanycity_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z = "";
         SetDirty("Networkcompanycity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyZipCode_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyZipCode_Z"   )]
      public string gxTpr_Networkcompanyzipcode_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z = value;
            SetDirty("Networkcompanyzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z = "";
         SetDirty("Networkcompanyzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyAddressLine1_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyAddressLine1_Z"   )]
      public string gxTpr_Networkcompanyaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z = value;
            SetDirty("Networkcompanyaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z = "";
         SetDirty("Networkcompanyaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkCompanyAddressLine2_Z" )]
      [  XmlElement( ElementName = "NetworkCompanyAddressLine2_Z"   )]
      public string gxTpr_Networkcompanyaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z = value;
            SetDirty("Networkcompanyaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z = "";
         SetDirty("Networkcompanyaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z_IsNull( )
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
         gxTv_SdtTrn_NetworkCompany_Networkcompanyid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyname = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyemail = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphone = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycountry = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycity = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 = "";
         gxTv_SdtTrn_NetworkCompany_Mode = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z = Guid.Empty;
         gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z = "";
         gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_networkcompany", "GeneXus.Programs.trn_networkcompany_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_NetworkCompany_Initialized ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphone ;
      private string gxTv_SdtTrn_NetworkCompany_Mode ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphone_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyname ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyemail ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycountry ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycity ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1 ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2 ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanykvknumber_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyname_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycontactname_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyemail_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphonecode_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyphonenumber_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycountry_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanycity_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyzipcode_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline1_Z ;
      private string gxTv_SdtTrn_NetworkCompany_Networkcompanyaddressline2_Z ;
      private Guid gxTv_SdtTrn_NetworkCompany_Networkcompanyid ;
      private Guid gxTv_SdtTrn_NetworkCompany_Networkcompanyid_Z ;
   }

   [DataContract(Name = @"Trn_NetworkCompany", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_NetworkCompany_RESTInterface : GxGenericCollectionItem<SdtTrn_NetworkCompany>
   {
      public SdtTrn_NetworkCompany_RESTInterface( ) : base()
      {
      }

      public SdtTrn_NetworkCompany_RESTInterface( SdtTrn_NetworkCompany psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NetworkCompanyId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Networkcompanyid
      {
         get {
            return sdt.gxTpr_Networkcompanyid ;
         }

         set {
            sdt.gxTpr_Networkcompanyid = value;
         }

      }

      [DataMember( Name = "NetworkCompanyKvkNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanykvknumber
      {
         get {
            return sdt.gxTpr_Networkcompanykvknumber ;
         }

         set {
            sdt.gxTpr_Networkcompanykvknumber = value;
         }

      }

      [DataMember( Name = "NetworkCompanyName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyname
      {
         get {
            return sdt.gxTpr_Networkcompanyname ;
         }

         set {
            sdt.gxTpr_Networkcompanyname = value;
         }

      }

      [DataMember( Name = "NetworkCompanyContactName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanycontactname
      {
         get {
            return sdt.gxTpr_Networkcompanycontactname ;
         }

         set {
            sdt.gxTpr_Networkcompanycontactname = value;
         }

      }

      [DataMember( Name = "NetworkCompanyEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyemail
      {
         get {
            return sdt.gxTpr_Networkcompanyemail ;
         }

         set {
            sdt.gxTpr_Networkcompanyemail = value;
         }

      }

      [DataMember( Name = "NetworkCompanyPhone" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Networkcompanyphone) ;
         }

         set {
            sdt.gxTpr_Networkcompanyphone = value;
         }

      }

      [DataMember( Name = "NetworkCompanyPhoneCode" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyphonecode
      {
         get {
            return sdt.gxTpr_Networkcompanyphonecode ;
         }

         set {
            sdt.gxTpr_Networkcompanyphonecode = value;
         }

      }

      [DataMember( Name = "NetworkCompanyPhoneNumber" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyphonenumber
      {
         get {
            return sdt.gxTpr_Networkcompanyphonenumber ;
         }

         set {
            sdt.gxTpr_Networkcompanyphonenumber = value;
         }

      }

      [DataMember( Name = "NetworkCompanyCountry" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanycountry
      {
         get {
            return sdt.gxTpr_Networkcompanycountry ;
         }

         set {
            sdt.gxTpr_Networkcompanycountry = value;
         }

      }

      [DataMember( Name = "NetworkCompanyCity" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanycity
      {
         get {
            return sdt.gxTpr_Networkcompanycity ;
         }

         set {
            sdt.gxTpr_Networkcompanycity = value;
         }

      }

      [DataMember( Name = "NetworkCompanyZipCode" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyzipcode
      {
         get {
            return sdt.gxTpr_Networkcompanyzipcode ;
         }

         set {
            sdt.gxTpr_Networkcompanyzipcode = value;
         }

      }

      [DataMember( Name = "NetworkCompanyAddressLine1" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyaddressline1
      {
         get {
            return sdt.gxTpr_Networkcompanyaddressline1 ;
         }

         set {
            sdt.gxTpr_Networkcompanyaddressline1 = value;
         }

      }

      [DataMember( Name = "NetworkCompanyAddressLine2" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyaddressline2
      {
         get {
            return sdt.gxTpr_Networkcompanyaddressline2 ;
         }

         set {
            sdt.gxTpr_Networkcompanyaddressline2 = value;
         }

      }

      public SdtTrn_NetworkCompany sdt
      {
         get {
            return (SdtTrn_NetworkCompany)Sdt ;
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
            sdt = new SdtTrn_NetworkCompany() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 13 )]
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

   [DataContract(Name = @"Trn_NetworkCompany", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_NetworkCompany_RESTLInterface : GxGenericCollectionItem<SdtTrn_NetworkCompany>
   {
      public SdtTrn_NetworkCompany_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_NetworkCompany_RESTLInterface( SdtTrn_NetworkCompany psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NetworkCompanyName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Networkcompanyname
      {
         get {
            return sdt.gxTpr_Networkcompanyname ;
         }

         set {
            sdt.gxTpr_Networkcompanyname = value;
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

      public SdtTrn_NetworkCompany sdt
      {
         get {
            return (SdtTrn_NetworkCompany)Sdt ;
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
            sdt = new SdtTrn_NetworkCompany() ;
         }
      }

   }

}
