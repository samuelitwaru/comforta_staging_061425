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
   [XmlRoot(ElementName = "Trn_SupplierAgb" )]
   [XmlType(TypeName =  "Trn_SupplierAgb" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_SupplierAgb : GxSilentTrnSdt
   {
      public SdtTrn_SupplierAgb( )
      {
      }

      public SdtTrn_SupplierAgb( IGxContext context )
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

      public void Load( Guid AV49SupplierAgbId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV49SupplierAgbId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierAgbId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_SupplierAgb");
         metadata.Set("BT", "Trn_SupplierAGB");
         metadata.Set("PK", "[ \"SupplierAgbId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierAgbId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SupplierAgbTypeId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Supplieragbid_Z");
         state.Add("gxTpr_Supplieragbnumber_Z");
         state.Add("gxTpr_Supplieragbtypeid_Z");
         state.Add("gxTpr_Supplieragbtypename_Z");
         state.Add("gxTpr_Supplieragbname_Z");
         state.Add("gxTpr_Supplieragbkvknumber_Z");
         state.Add("gxTpr_Supplieragbaddresscountry_Z");
         state.Add("gxTpr_Supplieragbaddresscity_Z");
         state.Add("gxTpr_Supplieragbaddresszipcode_Z");
         state.Add("gxTpr_Supplieragbaddressline1_Z");
         state.Add("gxTpr_Supplieragbaddressline2_Z");
         state.Add("gxTpr_Supplieragbcontactname_Z");
         state.Add("gxTpr_Supplieragbphone_Z");
         state.Add("gxTpr_Supplieragbphonecode_Z");
         state.Add("gxTpr_Supplieragbphonenumber_Z");
         state.Add("gxTpr_Supplieragbemail_Z");
         state.Add("gxTpr_Supplieragbwebsite_Z");
         state.Add("gxTpr_Supplieragbid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_SupplierAgb sdt;
         sdt = (SdtTrn_SupplierAgb)(source);
         gxTv_SdtTrn_SupplierAgb_Supplieragbid = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbid ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbnumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbnumber ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypename = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypename ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbname = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbname ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphone = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphone ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbemail = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbemail ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite ;
         gxTv_SdtTrn_SupplierAgb_Mode = sdt.gxTv_SdtTrn_SupplierAgb_Mode ;
         gxTv_SdtTrn_SupplierAgb_Initialized = sdt.gxTv_SdtTrn_SupplierAgb_Initialized ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z ;
         gxTv_SdtTrn_SupplierAgb_Supplieragbid_N = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbid_N ;
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
         AddObjectProperty("SupplierAgbId", gxTv_SdtTrn_SupplierAgb_Supplieragbid, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbId_N", gxTv_SdtTrn_SupplierAgb_Supplieragbid_N, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbNumber", gxTv_SdtTrn_SupplierAgb_Supplieragbnumber, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbTypeId", gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbTypeName", gxTv_SdtTrn_SupplierAgb_Supplieragbtypename, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbName", gxTv_SdtTrn_SupplierAgb_Supplieragbname, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbKvkNumber", gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber, false, includeNonInitialized);
         AddObjectProperty("SupplierAGBAddressCountry", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbAddressCity", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbAddressZipCode", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbAddressLine1", gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbAddressLine2", gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbContactName", gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbPhone", gxTv_SdtTrn_SupplierAgb_Supplieragbphone, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbPhoneCode", gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbPhoneNumber", gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbEmail", gxTv_SdtTrn_SupplierAgb_Supplieragbemail, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbWebsite", gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_SupplierAgb_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_SupplierAgb_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbId_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbNumber_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbTypeId_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbTypeName_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbName_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbKvkNumber_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAGBAddressCountry_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbAddressCity_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbAddressZipCode_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbAddressLine1_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbAddressLine2_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbContactName_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbPhone_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbPhoneCode_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbPhoneNumber_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbEmail_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbWebsite_Z", gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbId_N", gxTv_SdtTrn_SupplierAgb_Supplieragbid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_SupplierAgb sdt )
      {
         if ( sdt.IsDirty("SupplierAgbId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbid = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbid ;
         }
         if ( sdt.IsDirty("SupplierAgbNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbnumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbnumber ;
         }
         if ( sdt.IsDirty("SupplierAgbTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid ;
         }
         if ( sdt.IsDirty("SupplierAgbTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypename = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbtypename ;
         }
         if ( sdt.IsDirty("SupplierAgbName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbname = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbname ;
         }
         if ( sdt.IsDirty("SupplierAgbKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber ;
         }
         if ( sdt.IsDirty("SupplierAGBAddressCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry ;
         }
         if ( sdt.IsDirty("SupplierAgbAddressCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity ;
         }
         if ( sdt.IsDirty("SupplierAgbAddressZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode ;
         }
         if ( sdt.IsDirty("SupplierAgbAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 ;
         }
         if ( sdt.IsDirty("SupplierAgbAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 ;
         }
         if ( sdt.IsDirty("SupplierAgbContactName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname ;
         }
         if ( sdt.IsDirty("SupplierAgbPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphone = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphone ;
         }
         if ( sdt.IsDirty("SupplierAgbPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode ;
         }
         if ( sdt.IsDirty("SupplierAgbPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber ;
         }
         if ( sdt.IsDirty("SupplierAgbEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbemail = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbemail ;
         }
         if ( sdt.IsDirty("SupplierAgbWebsite") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite = sdt.gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierAgbId" )]
      [  XmlElement( ElementName = "SupplierAgbId"   )]
      public Guid gxTpr_Supplieragbid
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierAgb_Supplieragbid != value )
            {
               gxTv_SdtTrn_SupplierAgb_Mode = "INS";
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierAgb_Supplieragbid = value;
            SetDirty("Supplieragbid");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbNumber" )]
      [  XmlElement( ElementName = "SupplierAgbNumber"   )]
      public string gxTpr_Supplieragbnumber
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbnumber = value;
            SetDirty("Supplieragbnumber");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbTypeId" )]
      [  XmlElement( ElementName = "SupplierAgbTypeId"   )]
      public Guid gxTpr_Supplieragbtypeid
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid = value;
            SetDirty("Supplieragbtypeid");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbTypeName" )]
      [  XmlElement( ElementName = "SupplierAgbTypeName"   )]
      public string gxTpr_Supplieragbtypename
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbtypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypename = value;
            SetDirty("Supplieragbtypename");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbName" )]
      [  XmlElement( ElementName = "SupplierAgbName"   )]
      public string gxTpr_Supplieragbname
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbname = value;
            SetDirty("Supplieragbname");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbKvkNumber" )]
      [  XmlElement( ElementName = "SupplierAgbKvkNumber"   )]
      public string gxTpr_Supplieragbkvknumber
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber = value;
            SetDirty("Supplieragbkvknumber");
         }

      }

      [  SoapElement( ElementName = "SupplierAGBAddressCountry" )]
      [  XmlElement( ElementName = "SupplierAGBAddressCountry"   )]
      public string gxTpr_Supplieragbaddresscountry
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry = value;
            SetDirty("Supplieragbaddresscountry");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbAddressCity" )]
      [  XmlElement( ElementName = "SupplierAgbAddressCity"   )]
      public string gxTpr_Supplieragbaddresscity
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity = value;
            SetDirty("Supplieragbaddresscity");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbAddressZipCode" )]
      [  XmlElement( ElementName = "SupplierAgbAddressZipCode"   )]
      public string gxTpr_Supplieragbaddresszipcode
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode = value;
            SetDirty("Supplieragbaddresszipcode");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbAddressLine1" )]
      [  XmlElement( ElementName = "SupplierAgbAddressLine1"   )]
      public string gxTpr_Supplieragbaddressline1
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 = value;
            SetDirty("Supplieragbaddressline1");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbAddressLine2" )]
      [  XmlElement( ElementName = "SupplierAgbAddressLine2"   )]
      public string gxTpr_Supplieragbaddressline2
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 = value;
            SetDirty("Supplieragbaddressline2");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbContactName" )]
      [  XmlElement( ElementName = "SupplierAgbContactName"   )]
      public string gxTpr_Supplieragbcontactname
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname = value;
            SetDirty("Supplieragbcontactname");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbPhone" )]
      [  XmlElement( ElementName = "SupplierAgbPhone"   )]
      public string gxTpr_Supplieragbphone
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphone = value;
            SetDirty("Supplieragbphone");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbPhoneCode" )]
      [  XmlElement( ElementName = "SupplierAgbPhoneCode"   )]
      public string gxTpr_Supplieragbphonecode
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode = value;
            SetDirty("Supplieragbphonecode");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbPhoneNumber" )]
      [  XmlElement( ElementName = "SupplierAgbPhoneNumber"   )]
      public string gxTpr_Supplieragbphonenumber
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber = value;
            SetDirty("Supplieragbphonenumber");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbEmail" )]
      [  XmlElement( ElementName = "SupplierAgbEmail"   )]
      public string gxTpr_Supplieragbemail
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbemail = value;
            SetDirty("Supplieragbemail");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbWebsite" )]
      [  XmlElement( ElementName = "SupplierAgbWebsite"   )]
      public string gxTpr_Supplieragbwebsite
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite = value;
            SetDirty("Supplieragbwebsite");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Mode_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Initialized_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbId_Z" )]
      [  XmlElement( ElementName = "SupplierAgbId_Z"   )]
      public Guid gxTpr_Supplieragbid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z = value;
            SetDirty("Supplieragbid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z = Guid.Empty;
         SetDirty("Supplieragbid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbNumber_Z" )]
      [  XmlElement( ElementName = "SupplierAgbNumber_Z"   )]
      public string gxTpr_Supplieragbnumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z = value;
            SetDirty("Supplieragbnumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z = "";
         SetDirty("Supplieragbnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbTypeId_Z" )]
      [  XmlElement( ElementName = "SupplierAgbTypeId_Z"   )]
      public Guid gxTpr_Supplieragbtypeid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z = value;
            SetDirty("Supplieragbtypeid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z = Guid.Empty;
         SetDirty("Supplieragbtypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbTypeName_Z" )]
      [  XmlElement( ElementName = "SupplierAgbTypeName_Z"   )]
      public string gxTpr_Supplieragbtypename_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z = value;
            SetDirty("Supplieragbtypename_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z = "";
         SetDirty("Supplieragbtypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbName_Z" )]
      [  XmlElement( ElementName = "SupplierAgbName_Z"   )]
      public string gxTpr_Supplieragbname_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z = value;
            SetDirty("Supplieragbname_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z = "";
         SetDirty("Supplieragbname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbKvkNumber_Z" )]
      [  XmlElement( ElementName = "SupplierAgbKvkNumber_Z"   )]
      public string gxTpr_Supplieragbkvknumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z = value;
            SetDirty("Supplieragbkvknumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z = "";
         SetDirty("Supplieragbkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAGBAddressCountry_Z" )]
      [  XmlElement( ElementName = "SupplierAGBAddressCountry_Z"   )]
      public string gxTpr_Supplieragbaddresscountry_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z = value;
            SetDirty("Supplieragbaddresscountry_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z = "";
         SetDirty("Supplieragbaddresscountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbAddressCity_Z" )]
      [  XmlElement( ElementName = "SupplierAgbAddressCity_Z"   )]
      public string gxTpr_Supplieragbaddresscity_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z = value;
            SetDirty("Supplieragbaddresscity_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z = "";
         SetDirty("Supplieragbaddresscity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbAddressZipCode_Z" )]
      [  XmlElement( ElementName = "SupplierAgbAddressZipCode_Z"   )]
      public string gxTpr_Supplieragbaddresszipcode_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z = value;
            SetDirty("Supplieragbaddresszipcode_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z = "";
         SetDirty("Supplieragbaddresszipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbAddressLine1_Z" )]
      [  XmlElement( ElementName = "SupplierAgbAddressLine1_Z"   )]
      public string gxTpr_Supplieragbaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z = value;
            SetDirty("Supplieragbaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z = "";
         SetDirty("Supplieragbaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbAddressLine2_Z" )]
      [  XmlElement( ElementName = "SupplierAgbAddressLine2_Z"   )]
      public string gxTpr_Supplieragbaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z = value;
            SetDirty("Supplieragbaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z = "";
         SetDirty("Supplieragbaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbContactName_Z" )]
      [  XmlElement( ElementName = "SupplierAgbContactName_Z"   )]
      public string gxTpr_Supplieragbcontactname_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z = value;
            SetDirty("Supplieragbcontactname_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z = "";
         SetDirty("Supplieragbcontactname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbPhone_Z" )]
      [  XmlElement( ElementName = "SupplierAgbPhone_Z"   )]
      public string gxTpr_Supplieragbphone_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z = value;
            SetDirty("Supplieragbphone_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z = "";
         SetDirty("Supplieragbphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbPhoneCode_Z" )]
      [  XmlElement( ElementName = "SupplierAgbPhoneCode_Z"   )]
      public string gxTpr_Supplieragbphonecode_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z = value;
            SetDirty("Supplieragbphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z = "";
         SetDirty("Supplieragbphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbPhoneNumber_Z" )]
      [  XmlElement( ElementName = "SupplierAgbPhoneNumber_Z"   )]
      public string gxTpr_Supplieragbphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z = value;
            SetDirty("Supplieragbphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z = "";
         SetDirty("Supplieragbphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbEmail_Z" )]
      [  XmlElement( ElementName = "SupplierAgbEmail_Z"   )]
      public string gxTpr_Supplieragbemail_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z = value;
            SetDirty("Supplieragbemail_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z = "";
         SetDirty("Supplieragbemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbWebsite_Z" )]
      [  XmlElement( ElementName = "SupplierAgbWebsite_Z"   )]
      public string gxTpr_Supplieragbwebsite_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z = value;
            SetDirty("Supplieragbwebsite_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z = "";
         SetDirty("Supplieragbwebsite_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbId_N" )]
      [  XmlElement( ElementName = "SupplierAgbId_N"   )]
      public short gxTpr_Supplieragbid_N
      {
         get {
            return gxTv_SdtTrn_SupplierAgb_Supplieragbid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgb_Supplieragbid_N = value;
            SetDirty("Supplieragbid_N");
         }

      }

      public void gxTv_SdtTrn_SupplierAgb_Supplieragbid_N_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgb_Supplieragbid_N = 0;
         SetDirty("Supplieragbid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgb_Supplieragbid_N_IsNull( )
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
         gxTv_SdtTrn_SupplierAgb_Supplieragbid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_SupplierAgb_Supplieragbnumber = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid = Guid.Empty;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypename = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbname = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphone = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbemail = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite = "";
         gxTv_SdtTrn_SupplierAgb_Mode = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z = "";
         gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_supplieragb", "GeneXus.Programs.trn_supplieragb_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_SupplierAgb_Initialized ;
      private short gxTv_SdtTrn_SupplierAgb_Supplieragbid_N ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphone ;
      private string gxTv_SdtTrn_SupplierAgb_Mode ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphone_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbnumber ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbtypename ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbname ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1 ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2 ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbemail ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbnumber_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbtypename_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbname_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbkvknumber_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscountry_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresscity_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddresszipcode_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline1_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbaddressline2_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbcontactname_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphonecode_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbphonenumber_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbemail_Z ;
      private string gxTv_SdtTrn_SupplierAgb_Supplieragbwebsite_Z ;
      private Guid gxTv_SdtTrn_SupplierAgb_Supplieragbid ;
      private Guid gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid ;
      private Guid gxTv_SdtTrn_SupplierAgb_Supplieragbid_Z ;
      private Guid gxTv_SdtTrn_SupplierAgb_Supplieragbtypeid_Z ;
   }

   [DataContract(Name = @"Trn_SupplierAgb", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierAgb_RESTInterface : GxGenericCollectionItem<SdtTrn_SupplierAgb>
   {
      public SdtTrn_SupplierAgb_RESTInterface( ) : base()
      {
      }

      public SdtTrn_SupplierAgb_RESTInterface( SdtTrn_SupplierAgb psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierAgbId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Supplieragbid
      {
         get {
            return sdt.gxTpr_Supplieragbid ;
         }

         set {
            sdt.gxTpr_Supplieragbid = value;
         }

      }

      [DataMember( Name = "SupplierAgbNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbnumber
      {
         get {
            return sdt.gxTpr_Supplieragbnumber ;
         }

         set {
            sdt.gxTpr_Supplieragbnumber = value;
         }

      }

      [DataMember( Name = "SupplierAgbTypeId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Supplieragbtypeid
      {
         get {
            return sdt.gxTpr_Supplieragbtypeid ;
         }

         set {
            sdt.gxTpr_Supplieragbtypeid = value;
         }

      }

      [DataMember( Name = "SupplierAgbTypeName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbtypename
      {
         get {
            return sdt.gxTpr_Supplieragbtypename ;
         }

         set {
            sdt.gxTpr_Supplieragbtypename = value;
         }

      }

      [DataMember( Name = "SupplierAgbName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbname
      {
         get {
            return sdt.gxTpr_Supplieragbname ;
         }

         set {
            sdt.gxTpr_Supplieragbname = value;
         }

      }

      [DataMember( Name = "SupplierAgbKvkNumber" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbkvknumber
      {
         get {
            return sdt.gxTpr_Supplieragbkvknumber ;
         }

         set {
            sdt.gxTpr_Supplieragbkvknumber = value;
         }

      }

      [DataMember( Name = "SupplierAGBAddressCountry" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbaddresscountry
      {
         get {
            return sdt.gxTpr_Supplieragbaddresscountry ;
         }

         set {
            sdt.gxTpr_Supplieragbaddresscountry = value;
         }

      }

      [DataMember( Name = "SupplierAgbAddressCity" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbaddresscity
      {
         get {
            return sdt.gxTpr_Supplieragbaddresscity ;
         }

         set {
            sdt.gxTpr_Supplieragbaddresscity = value;
         }

      }

      [DataMember( Name = "SupplierAgbAddressZipCode" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbaddresszipcode
      {
         get {
            return sdt.gxTpr_Supplieragbaddresszipcode ;
         }

         set {
            sdt.gxTpr_Supplieragbaddresszipcode = value;
         }

      }

      [DataMember( Name = "SupplierAgbAddressLine1" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbaddressline1
      {
         get {
            return sdt.gxTpr_Supplieragbaddressline1 ;
         }

         set {
            sdt.gxTpr_Supplieragbaddressline1 = value;
         }

      }

      [DataMember( Name = "SupplierAgbAddressLine2" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbaddressline2
      {
         get {
            return sdt.gxTpr_Supplieragbaddressline2 ;
         }

         set {
            sdt.gxTpr_Supplieragbaddressline2 = value;
         }

      }

      [DataMember( Name = "SupplierAgbContactName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbcontactname
      {
         get {
            return sdt.gxTpr_Supplieragbcontactname ;
         }

         set {
            sdt.gxTpr_Supplieragbcontactname = value;
         }

      }

      [DataMember( Name = "SupplierAgbPhone" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Supplieragbphone) ;
         }

         set {
            sdt.gxTpr_Supplieragbphone = value;
         }

      }

      [DataMember( Name = "SupplierAgbPhoneCode" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbphonecode
      {
         get {
            return sdt.gxTpr_Supplieragbphonecode ;
         }

         set {
            sdt.gxTpr_Supplieragbphonecode = value;
         }

      }

      [DataMember( Name = "SupplierAgbPhoneNumber" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbphonenumber
      {
         get {
            return sdt.gxTpr_Supplieragbphonenumber ;
         }

         set {
            sdt.gxTpr_Supplieragbphonenumber = value;
         }

      }

      [DataMember( Name = "SupplierAgbEmail" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbemail
      {
         get {
            return sdt.gxTpr_Supplieragbemail ;
         }

         set {
            sdt.gxTpr_Supplieragbemail = value;
         }

      }

      [DataMember( Name = "SupplierAgbWebsite" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbwebsite
      {
         get {
            return sdt.gxTpr_Supplieragbwebsite ;
         }

         set {
            sdt.gxTpr_Supplieragbwebsite = value;
         }

      }

      public SdtTrn_SupplierAgb sdt
      {
         get {
            return (SdtTrn_SupplierAgb)Sdt ;
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
            sdt = new SdtTrn_SupplierAgb() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 17 )]
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

   [DataContract(Name = @"Trn_SupplierAgb", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierAgb_RESTLInterface : GxGenericCollectionItem<SdtTrn_SupplierAgb>
   {
      public SdtTrn_SupplierAgb_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_SupplierAgb_RESTLInterface( SdtTrn_SupplierAgb psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierAgbName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Supplieragbname
      {
         get {
            return sdt.gxTpr_Supplieragbname ;
         }

         set {
            sdt.gxTpr_Supplieragbname = value;
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

      public SdtTrn_SupplierAgb sdt
      {
         get {
            return (SdtTrn_SupplierAgb)Sdt ;
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
            sdt = new SdtTrn_SupplierAgb() ;
         }
      }

   }

}
