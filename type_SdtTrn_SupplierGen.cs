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
   [XmlRoot(ElementName = "Trn_SupplierGen" )]
   [XmlType(TypeName =  "Trn_SupplierGen" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_SupplierGen : GxSilentTrnSdt
   {
      public SdtTrn_SupplierGen( )
      {
      }

      public SdtTrn_SupplierGen( IGxContext context )
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

      public void Load( Guid AV42SupplierGenId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV42SupplierGenId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierGenId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_SupplierGen");
         metadata.Set("BT", "Trn_SupplierGen");
         metadata.Set("PK", "[ \"SupplierGenId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierGenId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[ \"SG_LocationSupplierLocationId-LocationId\",\"SG_LocationSupplierOrganisationId-OrganisationId\" ] },{ \"FK\":[ \"OrganisationId\" ],\"FKMap\":[ \"SG_OrganisationSupplierId-OrganisationId\" ] },{ \"FK\":[ \"SupplierGenTypeId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Suppliergenid_Z");
         state.Add("gxTpr_Suppliergenkvknumber_Z");
         state.Add("gxTpr_Suppliergentypeid_Z");
         state.Add("gxTpr_Suppliergentypename_Z");
         state.Add("gxTpr_Suppliergencompanyname_Z");
         state.Add("gxTpr_Suppliergenaddresscountry_Z");
         state.Add("gxTpr_Suppliergenaddresscity_Z");
         state.Add("gxTpr_Suppliergenaddresszipcode_Z");
         state.Add("gxTpr_Suppliergenaddressline1_Z");
         state.Add("gxTpr_Suppliergenaddressline2_Z");
         state.Add("gxTpr_Suppliergencontactname_Z");
         state.Add("gxTpr_Suppliergencontactphone_Z");
         state.Add("gxTpr_Suppliergenphonecode_Z");
         state.Add("gxTpr_Suppliergenphonenumber_Z");
         state.Add("gxTpr_Suppliergenlandlinecode_Z");
         state.Add("gxTpr_Suppliergenlandlinesubnumber_Z");
         state.Add("gxTpr_Suppliergenlandlinenumber_Z");
         state.Add("gxTpr_Suppliergenemail_Z");
         state.Add("gxTpr_Suppliergenwebsite_Z");
         state.Add("gxTpr_Sg_organisationsupplierid_Z");
         state.Add("gxTpr_Sg_locationsupplierorganisationid_Z");
         state.Add("gxTpr_Sg_locationsupplierlocationid_Z");
         state.Add("gxTpr_Suppliergenid_N");
         state.Add("gxTpr_Sg_organisationsupplierid_N");
         state.Add("gxTpr_Sg_locationsupplierorganisationid_N");
         state.Add("gxTpr_Sg_locationsupplierlocationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_SupplierGen sdt;
         sdt = (SdtTrn_SupplierGen)(source);
         gxTv_SdtTrn_SupplierGen_Suppliergenid = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenid ;
         gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber ;
         gxTv_SdtTrn_SupplierGen_Suppliergentypeid = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypeid ;
         gxTv_SdtTrn_SupplierGen_Suppliergentypename = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypename ;
         gxTv_SdtTrn_SupplierGen_Suppliergencompanyname = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencompanyname ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 ;
         gxTv_SdtTrn_SupplierGen_Suppliergencontactname = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactname ;
         gxTv_SdtTrn_SupplierGen_Suppliergencontactphone = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactphone ;
         gxTv_SdtTrn_SupplierGen_Suppliergenphonecode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonecode ;
         gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber ;
         gxTv_SdtTrn_SupplierGen_Suppliergenemail = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenemail ;
         gxTv_SdtTrn_SupplierGen_Suppliergenwebsite = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenwebsite ;
         gxTv_SdtTrn_SupplierGen_Suppliergendescription = sdt.gxTv_SdtTrn_SupplierGen_Suppliergendescription ;
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid = sdt.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid ;
         gxTv_SdtTrn_SupplierGen_Mode = sdt.gxTv_SdtTrn_SupplierGen_Mode ;
         gxTv_SdtTrn_SupplierGen_Initialized = sdt.gxTv_SdtTrn_SupplierGen_Initialized ;
         gxTv_SdtTrn_SupplierGen_Suppliergenid_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenid_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z ;
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z = sdt.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z ;
         gxTv_SdtTrn_SupplierGen_Suppliergenid_N = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenid_N ;
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = sdt.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N ;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N ;
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
         AddObjectProperty("SupplierGenId", gxTv_SdtTrn_SupplierGen_Suppliergenid, false, includeNonInitialized);
         AddObjectProperty("SupplierGenId_N", gxTv_SdtTrn_SupplierGen_Suppliergenid_N, false, includeNonInitialized);
         AddObjectProperty("SupplierGenKvkNumber", gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber, false, includeNonInitialized);
         AddObjectProperty("SupplierGenTypeId", gxTv_SdtTrn_SupplierGen_Suppliergentypeid, false, includeNonInitialized);
         AddObjectProperty("SupplierGenTypeName", gxTv_SdtTrn_SupplierGen_Suppliergentypename, false, includeNonInitialized);
         AddObjectProperty("SupplierGenCompanyName", gxTv_SdtTrn_SupplierGen_Suppliergencompanyname, false, includeNonInitialized);
         AddObjectProperty("SupplierGenAddressCountry", gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry, false, includeNonInitialized);
         AddObjectProperty("SupplierGenAddressCity", gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity, false, includeNonInitialized);
         AddObjectProperty("SupplierGenAddressZipCode", gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode, false, includeNonInitialized);
         AddObjectProperty("SupplierGenAddressLine1", gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1, false, includeNonInitialized);
         AddObjectProperty("SupplierGenAddressLine2", gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2, false, includeNonInitialized);
         AddObjectProperty("SupplierGenContactName", gxTv_SdtTrn_SupplierGen_Suppliergencontactname, false, includeNonInitialized);
         AddObjectProperty("SupplierGenContactPhone", gxTv_SdtTrn_SupplierGen_Suppliergencontactphone, false, includeNonInitialized);
         AddObjectProperty("SupplierGenPhoneCode", gxTv_SdtTrn_SupplierGen_Suppliergenphonecode, false, includeNonInitialized);
         AddObjectProperty("SupplierGenPhoneNumber", gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber, false, includeNonInitialized);
         AddObjectProperty("SupplierGenLandlineCode", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode, false, includeNonInitialized);
         AddObjectProperty("SupplierGenLandlineSubNumber", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber, false, includeNonInitialized);
         AddObjectProperty("SupplierGenLandlineNumber", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber, false, includeNonInitialized);
         AddObjectProperty("SupplierGenEmail", gxTv_SdtTrn_SupplierGen_Suppliergenemail, false, includeNonInitialized);
         AddObjectProperty("SupplierGenWebsite", gxTv_SdtTrn_SupplierGen_Suppliergenwebsite, false, includeNonInitialized);
         AddObjectProperty("SupplierGenDescription", gxTv_SdtTrn_SupplierGen_Suppliergendescription, false, includeNonInitialized);
         AddObjectProperty("SG_OrganisationSupplierId", gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid, false, includeNonInitialized);
         AddObjectProperty("SG_OrganisationSupplierId_N", gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N, false, includeNonInitialized);
         AddObjectProperty("SG_LocationSupplierOrganisationId", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid, false, includeNonInitialized);
         AddObjectProperty("SG_LocationSupplierOrganisationId_N", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N, false, includeNonInitialized);
         AddObjectProperty("SG_LocationSupplierLocationId", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid, false, includeNonInitialized);
         AddObjectProperty("SG_LocationSupplierLocationId_N", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_SupplierGen_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_SupplierGen_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierGenId_Z", gxTv_SdtTrn_SupplierGen_Suppliergenid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenKvkNumber_Z", gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenTypeId_Z", gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenTypeName_Z", gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenCompanyName_Z", gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenAddressCountry_Z", gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenAddressCity_Z", gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenAddressZipCode_Z", gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenAddressLine1_Z", gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenAddressLine2_Z", gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenContactName_Z", gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenContactPhone_Z", gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenPhoneCode_Z", gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenPhoneNumber_Z", gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenLandlineCode_Z", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenLandlineSubNumber_Z", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenLandlineNumber_Z", gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenEmail_Z", gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenWebsite_Z", gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z, false, includeNonInitialized);
            AddObjectProperty("SG_OrganisationSupplierId_Z", gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_LocationSupplierOrganisationId_Z", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_LocationSupplierLocationId_Z", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenId_N", gxTv_SdtTrn_SupplierGen_Suppliergenid_N, false, includeNonInitialized);
            AddObjectProperty("SG_OrganisationSupplierId_N", gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N, false, includeNonInitialized);
            AddObjectProperty("SG_LocationSupplierOrganisationId_N", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N, false, includeNonInitialized);
            AddObjectProperty("SG_LocationSupplierLocationId_N", gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_SupplierGen sdt )
      {
         if ( sdt.IsDirty("SupplierGenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenid = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenid ;
         }
         if ( sdt.IsDirty("SupplierGenKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber ;
         }
         if ( sdt.IsDirty("SupplierGenTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypeid = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypeid ;
         }
         if ( sdt.IsDirty("SupplierGenTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypename = sdt.gxTv_SdtTrn_SupplierGen_Suppliergentypename ;
         }
         if ( sdt.IsDirty("SupplierGenCompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencompanyname = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencompanyname ;
         }
         if ( sdt.IsDirty("SupplierGenAddressCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry ;
         }
         if ( sdt.IsDirty("SupplierGenAddressCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity ;
         }
         if ( sdt.IsDirty("SupplierGenAddressZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode ;
         }
         if ( sdt.IsDirty("SupplierGenAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 ;
         }
         if ( sdt.IsDirty("SupplierGenAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 ;
         }
         if ( sdt.IsDirty("SupplierGenContactName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactname = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactname ;
         }
         if ( sdt.IsDirty("SupplierGenContactPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactphone = sdt.gxTv_SdtTrn_SupplierGen_Suppliergencontactphone ;
         }
         if ( sdt.IsDirty("SupplierGenPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonecode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonecode ;
         }
         if ( sdt.IsDirty("SupplierGenPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber ;
         }
         if ( sdt.IsDirty("SupplierGenLandlineCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode ;
         }
         if ( sdt.IsDirty("SupplierGenLandlineSubNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber ;
         }
         if ( sdt.IsDirty("SupplierGenLandlineNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber ;
         }
         if ( sdt.IsDirty("SupplierGenEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenemail = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenemail ;
         }
         if ( sdt.IsDirty("SupplierGenWebsite") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenwebsite = sdt.gxTv_SdtTrn_SupplierGen_Suppliergenwebsite ;
         }
         if ( sdt.IsDirty("SupplierGenDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergendescription = sdt.gxTv_SdtTrn_SupplierGen_Suppliergendescription ;
         }
         if ( sdt.IsDirty("SG_OrganisationSupplierId") )
         {
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = (short)(sdt.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid = sdt.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid ;
         }
         if ( sdt.IsDirty("SG_LocationSupplierOrganisationId") )
         {
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = (short)(sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid ;
         }
         if ( sdt.IsDirty("SG_LocationSupplierLocationId") )
         {
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = (short)(sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid = sdt.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierGenId" )]
      [  XmlElement( ElementName = "SupplierGenId"   )]
      public Guid gxTpr_Suppliergenid
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierGen_Suppliergenid != value )
            {
               gxTv_SdtTrn_SupplierGen_Mode = "INS";
               this.gxTv_SdtTrn_SupplierGen_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierGen_Suppliergenid = value;
            SetDirty("Suppliergenid");
         }

      }

      [  SoapElement( ElementName = "SupplierGenKvkNumber" )]
      [  XmlElement( ElementName = "SupplierGenKvkNumber"   )]
      public string gxTpr_Suppliergenkvknumber
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber = value;
            SetDirty("Suppliergenkvknumber");
         }

      }

      [  SoapElement( ElementName = "SupplierGenTypeId" )]
      [  XmlElement( ElementName = "SupplierGenTypeId"   )]
      public Guid gxTpr_Suppliergentypeid
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergentypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypeid = value;
            SetDirty("Suppliergentypeid");
         }

      }

      [  SoapElement( ElementName = "SupplierGenTypeName" )]
      [  XmlElement( ElementName = "SupplierGenTypeName"   )]
      public string gxTpr_Suppliergentypename
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergentypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypename = value;
            SetDirty("Suppliergentypename");
         }

      }

      [  SoapElement( ElementName = "SupplierGenCompanyName" )]
      [  XmlElement( ElementName = "SupplierGenCompanyName"   )]
      public string gxTpr_Suppliergencompanyname
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencompanyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencompanyname = value;
            SetDirty("Suppliergencompanyname");
         }

      }

      [  SoapElement( ElementName = "SupplierGenAddressCountry" )]
      [  XmlElement( ElementName = "SupplierGenAddressCountry"   )]
      public string gxTpr_Suppliergenaddresscountry
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry = value;
            SetDirty("Suppliergenaddresscountry");
         }

      }

      [  SoapElement( ElementName = "SupplierGenAddressCity" )]
      [  XmlElement( ElementName = "SupplierGenAddressCity"   )]
      public string gxTpr_Suppliergenaddresscity
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity = value;
            SetDirty("Suppliergenaddresscity");
         }

      }

      [  SoapElement( ElementName = "SupplierGenAddressZipCode" )]
      [  XmlElement( ElementName = "SupplierGenAddressZipCode"   )]
      public string gxTpr_Suppliergenaddresszipcode
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode = value;
            SetDirty("Suppliergenaddresszipcode");
         }

      }

      [  SoapElement( ElementName = "SupplierGenAddressLine1" )]
      [  XmlElement( ElementName = "SupplierGenAddressLine1"   )]
      public string gxTpr_Suppliergenaddressline1
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 = value;
            SetDirty("Suppliergenaddressline1");
         }

      }

      [  SoapElement( ElementName = "SupplierGenAddressLine2" )]
      [  XmlElement( ElementName = "SupplierGenAddressLine2"   )]
      public string gxTpr_Suppliergenaddressline2
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 = value;
            SetDirty("Suppliergenaddressline2");
         }

      }

      [  SoapElement( ElementName = "SupplierGenContactName" )]
      [  XmlElement( ElementName = "SupplierGenContactName"   )]
      public string gxTpr_Suppliergencontactname
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencontactname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactname = value;
            SetDirty("Suppliergencontactname");
         }

      }

      [  SoapElement( ElementName = "SupplierGenContactPhone" )]
      [  XmlElement( ElementName = "SupplierGenContactPhone"   )]
      public string gxTpr_Suppliergencontactphone
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencontactphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactphone = value;
            SetDirty("Suppliergencontactphone");
         }

      }

      [  SoapElement( ElementName = "SupplierGenPhoneCode" )]
      [  XmlElement( ElementName = "SupplierGenPhoneCode"   )]
      public string gxTpr_Suppliergenphonecode
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonecode = value;
            SetDirty("Suppliergenphonecode");
         }

      }

      [  SoapElement( ElementName = "SupplierGenPhoneNumber" )]
      [  XmlElement( ElementName = "SupplierGenPhoneNumber"   )]
      public string gxTpr_Suppliergenphonenumber
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber = value;
            SetDirty("Suppliergenphonenumber");
         }

      }

      [  SoapElement( ElementName = "SupplierGenLandlineCode" )]
      [  XmlElement( ElementName = "SupplierGenLandlineCode"   )]
      public string gxTpr_Suppliergenlandlinecode
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode = value;
            SetDirty("Suppliergenlandlinecode");
         }

      }

      [  SoapElement( ElementName = "SupplierGenLandlineSubNumber" )]
      [  XmlElement( ElementName = "SupplierGenLandlineSubNumber"   )]
      public string gxTpr_Suppliergenlandlinesubnumber
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber = value;
            SetDirty("Suppliergenlandlinesubnumber");
         }

      }

      [  SoapElement( ElementName = "SupplierGenLandlineNumber" )]
      [  XmlElement( ElementName = "SupplierGenLandlineNumber"   )]
      public string gxTpr_Suppliergenlandlinenumber
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber = value;
            SetDirty("Suppliergenlandlinenumber");
         }

      }

      [  SoapElement( ElementName = "SupplierGenEmail" )]
      [  XmlElement( ElementName = "SupplierGenEmail"   )]
      public string gxTpr_Suppliergenemail
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenemail = value;
            SetDirty("Suppliergenemail");
         }

      }

      [  SoapElement( ElementName = "SupplierGenWebsite" )]
      [  XmlElement( ElementName = "SupplierGenWebsite"   )]
      public string gxTpr_Suppliergenwebsite
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenwebsite ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenwebsite = value;
            SetDirty("Suppliergenwebsite");
         }

      }

      [  SoapElement( ElementName = "SupplierGenDescription" )]
      [  XmlElement( ElementName = "SupplierGenDescription"   )]
      public string gxTpr_Suppliergendescription
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergendescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergendescription = value;
            SetDirty("Suppliergendescription");
         }

      }

      [  SoapElement( ElementName = "SG_OrganisationSupplierId" )]
      [  XmlElement( ElementName = "SG_OrganisationSupplierId"   )]
      public Guid gxTpr_Sg_organisationsupplierid
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid ;
         }

         set {
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid = value;
            SetDirty("Sg_organisationsupplierid");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = 1;
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid = Guid.Empty;
         SetDirty("Sg_organisationsupplierid");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_IsNull( )
      {
         return (gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N==1) ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierOrganisationId" )]
      [  XmlElement( ElementName = "SG_LocationSupplierOrganisationId"   )]
      public Guid gxTpr_Sg_locationsupplierorganisationid
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid ;
         }

         set {
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid = value;
            SetDirty("Sg_locationsupplierorganisationid");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = 1;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid = Guid.Empty;
         SetDirty("Sg_locationsupplierorganisationid");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_IsNull( )
      {
         return (gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N==1) ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierLocationId" )]
      [  XmlElement( ElementName = "SG_LocationSupplierLocationId"   )]
      public Guid gxTpr_Sg_locationsupplierlocationid
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid ;
         }

         set {
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid = value;
            SetDirty("Sg_locationsupplierlocationid");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = 1;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid = Guid.Empty;
         SetDirty("Sg_locationsupplierlocationid");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_IsNull( )
      {
         return (gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Mode_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Initialized_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenId_Z" )]
      [  XmlElement( ElementName = "SupplierGenId_Z"   )]
      public Guid gxTpr_Suppliergenid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenid_Z = value;
            SetDirty("Suppliergenid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenid_Z = Guid.Empty;
         SetDirty("Suppliergenid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenKvkNumber_Z" )]
      [  XmlElement( ElementName = "SupplierGenKvkNumber_Z"   )]
      public string gxTpr_Suppliergenkvknumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z = value;
            SetDirty("Suppliergenkvknumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z = "";
         SetDirty("Suppliergenkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenTypeId_Z" )]
      [  XmlElement( ElementName = "SupplierGenTypeId_Z"   )]
      public Guid gxTpr_Suppliergentypeid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z = value;
            SetDirty("Suppliergentypeid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z = Guid.Empty;
         SetDirty("Suppliergentypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenTypeName_Z" )]
      [  XmlElement( ElementName = "SupplierGenTypeName_Z"   )]
      public string gxTpr_Suppliergentypename_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z = value;
            SetDirty("Suppliergentypename_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z = "";
         SetDirty("Suppliergentypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenCompanyName_Z" )]
      [  XmlElement( ElementName = "SupplierGenCompanyName_Z"   )]
      public string gxTpr_Suppliergencompanyname_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z = value;
            SetDirty("Suppliergencompanyname_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z = "";
         SetDirty("Suppliergencompanyname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenAddressCountry_Z" )]
      [  XmlElement( ElementName = "SupplierGenAddressCountry_Z"   )]
      public string gxTpr_Suppliergenaddresscountry_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z = value;
            SetDirty("Suppliergenaddresscountry_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z = "";
         SetDirty("Suppliergenaddresscountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenAddressCity_Z" )]
      [  XmlElement( ElementName = "SupplierGenAddressCity_Z"   )]
      public string gxTpr_Suppliergenaddresscity_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z = value;
            SetDirty("Suppliergenaddresscity_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z = "";
         SetDirty("Suppliergenaddresscity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenAddressZipCode_Z" )]
      [  XmlElement( ElementName = "SupplierGenAddressZipCode_Z"   )]
      public string gxTpr_Suppliergenaddresszipcode_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z = value;
            SetDirty("Suppliergenaddresszipcode_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z = "";
         SetDirty("Suppliergenaddresszipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenAddressLine1_Z" )]
      [  XmlElement( ElementName = "SupplierGenAddressLine1_Z"   )]
      public string gxTpr_Suppliergenaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z = value;
            SetDirty("Suppliergenaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z = "";
         SetDirty("Suppliergenaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenAddressLine2_Z" )]
      [  XmlElement( ElementName = "SupplierGenAddressLine2_Z"   )]
      public string gxTpr_Suppliergenaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z = value;
            SetDirty("Suppliergenaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z = "";
         SetDirty("Suppliergenaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenContactName_Z" )]
      [  XmlElement( ElementName = "SupplierGenContactName_Z"   )]
      public string gxTpr_Suppliergencontactname_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z = value;
            SetDirty("Suppliergencontactname_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z = "";
         SetDirty("Suppliergencontactname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenContactPhone_Z" )]
      [  XmlElement( ElementName = "SupplierGenContactPhone_Z"   )]
      public string gxTpr_Suppliergencontactphone_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z = value;
            SetDirty("Suppliergencontactphone_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z = "";
         SetDirty("Suppliergencontactphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenPhoneCode_Z" )]
      [  XmlElement( ElementName = "SupplierGenPhoneCode_Z"   )]
      public string gxTpr_Suppliergenphonecode_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z = value;
            SetDirty("Suppliergenphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z = "";
         SetDirty("Suppliergenphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenPhoneNumber_Z" )]
      [  XmlElement( ElementName = "SupplierGenPhoneNumber_Z"   )]
      public string gxTpr_Suppliergenphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z = value;
            SetDirty("Suppliergenphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z = "";
         SetDirty("Suppliergenphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenLandlineCode_Z" )]
      [  XmlElement( ElementName = "SupplierGenLandlineCode_Z"   )]
      public string gxTpr_Suppliergenlandlinecode_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z = value;
            SetDirty("Suppliergenlandlinecode_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z = "";
         SetDirty("Suppliergenlandlinecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenLandlineSubNumber_Z" )]
      [  XmlElement( ElementName = "SupplierGenLandlineSubNumber_Z"   )]
      public string gxTpr_Suppliergenlandlinesubnumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z = value;
            SetDirty("Suppliergenlandlinesubnumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z = "";
         SetDirty("Suppliergenlandlinesubnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenLandlineNumber_Z" )]
      [  XmlElement( ElementName = "SupplierGenLandlineNumber_Z"   )]
      public string gxTpr_Suppliergenlandlinenumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z = value;
            SetDirty("Suppliergenlandlinenumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z = "";
         SetDirty("Suppliergenlandlinenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenEmail_Z" )]
      [  XmlElement( ElementName = "SupplierGenEmail_Z"   )]
      public string gxTpr_Suppliergenemail_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z = value;
            SetDirty("Suppliergenemail_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z = "";
         SetDirty("Suppliergenemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenWebsite_Z" )]
      [  XmlElement( ElementName = "SupplierGenWebsite_Z"   )]
      public string gxTpr_Suppliergenwebsite_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z = value;
            SetDirty("Suppliergenwebsite_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z = "";
         SetDirty("Suppliergenwebsite_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_OrganisationSupplierId_Z" )]
      [  XmlElement( ElementName = "SG_OrganisationSupplierId_Z"   )]
      public Guid gxTpr_Sg_organisationsupplierid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z = value;
            SetDirty("Sg_organisationsupplierid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z = Guid.Empty;
         SetDirty("Sg_organisationsupplierid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierOrganisationId_Z" )]
      [  XmlElement( ElementName = "SG_LocationSupplierOrganisationId_Z"   )]
      public Guid gxTpr_Sg_locationsupplierorganisationid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z = value;
            SetDirty("Sg_locationsupplierorganisationid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z = Guid.Empty;
         SetDirty("Sg_locationsupplierorganisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierLocationId_Z" )]
      [  XmlElement( ElementName = "SG_LocationSupplierLocationId_Z"   )]
      public Guid gxTpr_Sg_locationsupplierlocationid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z = value;
            SetDirty("Sg_locationsupplierlocationid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z = Guid.Empty;
         SetDirty("Sg_locationsupplierlocationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenId_N" )]
      [  XmlElement( ElementName = "SupplierGenId_N"   )]
      public short gxTpr_Suppliergenid_N
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Suppliergenid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Suppliergenid_N = value;
            SetDirty("Suppliergenid_N");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Suppliergenid_N_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Suppliergenid_N = 0;
         SetDirty("Suppliergenid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Suppliergenid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_OrganisationSupplierId_N" )]
      [  XmlElement( ElementName = "SG_OrganisationSupplierId_N"   )]
      public short gxTpr_Sg_organisationsupplierid_N
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = value;
            SetDirty("Sg_organisationsupplierid_N");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N = 0;
         SetDirty("Sg_organisationsupplierid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierOrganisationId_N" )]
      [  XmlElement( ElementName = "SG_LocationSupplierOrganisationId_N"   )]
      public short gxTpr_Sg_locationsupplierorganisationid_N
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = value;
            SetDirty("Sg_locationsupplierorganisationid_N");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N = 0;
         SetDirty("Sg_locationsupplierorganisationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationSupplierLocationId_N" )]
      [  XmlElement( ElementName = "SG_LocationSupplierLocationId_N"   )]
      public short gxTpr_Sg_locationsupplierlocationid_N
      {
         get {
            return gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = value;
            SetDirty("Sg_locationsupplierlocationid_N");
         }

      }

      public void gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N_SetNull( )
      {
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N = 0;
         SetDirty("Sg_locationsupplierlocationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N_IsNull( )
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
         gxTv_SdtTrn_SupplierGen_Suppliergenid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber = "";
         gxTv_SdtTrn_SupplierGen_Suppliergentypeid = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Suppliergentypename = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencompanyname = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencontactname = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencontactphone = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenphonecode = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenemail = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenwebsite = "";
         gxTv_SdtTrn_SupplierGen_Suppliergendescription = "";
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Mode = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z = "";
         gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z = "";
         gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_suppliergen", "GeneXus.Programs.trn_suppliergen_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_SupplierGen_Initialized ;
      private short gxTv_SdtTrn_SupplierGen_Suppliergenid_N ;
      private short gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_N ;
      private short gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_N ;
      private short gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_N ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencontactphone ;
      private string gxTv_SdtTrn_SupplierGen_Mode ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencontactphone_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergendescription ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergentypename ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencompanyname ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1 ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2 ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencontactname ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenphonecode ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenemail ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenwebsite ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenkvknumber_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergentypename_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencompanyname_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresscountry_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresscity_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddresszipcode_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddressline1_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenaddressline2_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergencontactname_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenphonecode_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenphonenumber_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinecode_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinesubnumber_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenlandlinenumber_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenemail_Z ;
      private string gxTv_SdtTrn_SupplierGen_Suppliergenwebsite_Z ;
      private Guid gxTv_SdtTrn_SupplierGen_Suppliergenid ;
      private Guid gxTv_SdtTrn_SupplierGen_Suppliergentypeid ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid ;
      private Guid gxTv_SdtTrn_SupplierGen_Suppliergenid_Z ;
      private Guid gxTv_SdtTrn_SupplierGen_Suppliergentypeid_Z ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_organisationsupplierid_Z ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_locationsupplierorganisationid_Z ;
      private Guid gxTv_SdtTrn_SupplierGen_Sg_locationsupplierlocationid_Z ;
   }

   [DataContract(Name = @"Trn_SupplierGen", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierGen_RESTInterface : GxGenericCollectionItem<SdtTrn_SupplierGen>
   {
      public SdtTrn_SupplierGen_RESTInterface( ) : base()
      {
      }

      public SdtTrn_SupplierGen_RESTInterface( SdtTrn_SupplierGen psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierGenId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Suppliergenid
      {
         get {
            return sdt.gxTpr_Suppliergenid ;
         }

         set {
            sdt.gxTpr_Suppliergenid = value;
         }

      }

      [DataMember( Name = "SupplierGenKvkNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenkvknumber
      {
         get {
            return sdt.gxTpr_Suppliergenkvknumber ;
         }

         set {
            sdt.gxTpr_Suppliergenkvknumber = value;
         }

      }

      [DataMember( Name = "SupplierGenTypeId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Suppliergentypeid
      {
         get {
            return sdt.gxTpr_Suppliergentypeid ;
         }

         set {
            sdt.gxTpr_Suppliergentypeid = value;
         }

      }

      [DataMember( Name = "SupplierGenTypeName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Suppliergentypename
      {
         get {
            return sdt.gxTpr_Suppliergentypename ;
         }

         set {
            sdt.gxTpr_Suppliergentypename = value;
         }

      }

      [DataMember( Name = "SupplierGenCompanyName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Suppliergencompanyname
      {
         get {
            return sdt.gxTpr_Suppliergencompanyname ;
         }

         set {
            sdt.gxTpr_Suppliergencompanyname = value;
         }

      }

      [DataMember( Name = "SupplierGenAddressCountry" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenaddresscountry
      {
         get {
            return sdt.gxTpr_Suppliergenaddresscountry ;
         }

         set {
            sdt.gxTpr_Suppliergenaddresscountry = value;
         }

      }

      [DataMember( Name = "SupplierGenAddressCity" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenaddresscity
      {
         get {
            return sdt.gxTpr_Suppliergenaddresscity ;
         }

         set {
            sdt.gxTpr_Suppliergenaddresscity = value;
         }

      }

      [DataMember( Name = "SupplierGenAddressZipCode" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenaddresszipcode
      {
         get {
            return sdt.gxTpr_Suppliergenaddresszipcode ;
         }

         set {
            sdt.gxTpr_Suppliergenaddresszipcode = value;
         }

      }

      [DataMember( Name = "SupplierGenAddressLine1" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenaddressline1
      {
         get {
            return sdt.gxTpr_Suppliergenaddressline1 ;
         }

         set {
            sdt.gxTpr_Suppliergenaddressline1 = value;
         }

      }

      [DataMember( Name = "SupplierGenAddressLine2" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenaddressline2
      {
         get {
            return sdt.gxTpr_Suppliergenaddressline2 ;
         }

         set {
            sdt.gxTpr_Suppliergenaddressline2 = value;
         }

      }

      [DataMember( Name = "SupplierGenContactName" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Suppliergencontactname
      {
         get {
            return sdt.gxTpr_Suppliergencontactname ;
         }

         set {
            sdt.gxTpr_Suppliergencontactname = value;
         }

      }

      [DataMember( Name = "SupplierGenContactPhone" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Suppliergencontactphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Suppliergencontactphone) ;
         }

         set {
            sdt.gxTpr_Suppliergencontactphone = value;
         }

      }

      [DataMember( Name = "SupplierGenPhoneCode" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenphonecode
      {
         get {
            return sdt.gxTpr_Suppliergenphonecode ;
         }

         set {
            sdt.gxTpr_Suppliergenphonecode = value;
         }

      }

      [DataMember( Name = "SupplierGenPhoneNumber" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenphonenumber
      {
         get {
            return sdt.gxTpr_Suppliergenphonenumber ;
         }

         set {
            sdt.gxTpr_Suppliergenphonenumber = value;
         }

      }

      [DataMember( Name = "SupplierGenLandlineCode" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenlandlinecode
      {
         get {
            return sdt.gxTpr_Suppliergenlandlinecode ;
         }

         set {
            sdt.gxTpr_Suppliergenlandlinecode = value;
         }

      }

      [DataMember( Name = "SupplierGenLandlineSubNumber" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenlandlinesubnumber
      {
         get {
            return sdt.gxTpr_Suppliergenlandlinesubnumber ;
         }

         set {
            sdt.gxTpr_Suppliergenlandlinesubnumber = value;
         }

      }

      [DataMember( Name = "SupplierGenLandlineNumber" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenlandlinenumber
      {
         get {
            return sdt.gxTpr_Suppliergenlandlinenumber ;
         }

         set {
            sdt.gxTpr_Suppliergenlandlinenumber = value;
         }

      }

      [DataMember( Name = "SupplierGenEmail" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenemail
      {
         get {
            return sdt.gxTpr_Suppliergenemail ;
         }

         set {
            sdt.gxTpr_Suppliergenemail = value;
         }

      }

      [DataMember( Name = "SupplierGenWebsite" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Suppliergenwebsite
      {
         get {
            return sdt.gxTpr_Suppliergenwebsite ;
         }

         set {
            sdt.gxTpr_Suppliergenwebsite = value;
         }

      }

      [DataMember( Name = "SupplierGenDescription" , Order = 19 )]
      public string gxTpr_Suppliergendescription
      {
         get {
            return sdt.gxTpr_Suppliergendescription ;
         }

         set {
            sdt.gxTpr_Suppliergendescription = value;
         }

      }

      [DataMember( Name = "SG_OrganisationSupplierId" , Order = 20 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_organisationsupplierid
      {
         get {
            return sdt.gxTpr_Sg_organisationsupplierid ;
         }

         set {
            sdt.gxTpr_Sg_organisationsupplierid = value;
         }

      }

      [DataMember( Name = "SG_LocationSupplierOrganisationId" , Order = 21 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_locationsupplierorganisationid
      {
         get {
            return sdt.gxTpr_Sg_locationsupplierorganisationid ;
         }

         set {
            sdt.gxTpr_Sg_locationsupplierorganisationid = value;
         }

      }

      [DataMember( Name = "SG_LocationSupplierLocationId" , Order = 22 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_locationsupplierlocationid
      {
         get {
            return sdt.gxTpr_Sg_locationsupplierlocationid ;
         }

         set {
            sdt.gxTpr_Sg_locationsupplierlocationid = value;
         }

      }

      public SdtTrn_SupplierGen sdt
      {
         get {
            return (SdtTrn_SupplierGen)Sdt ;
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
            sdt = new SdtTrn_SupplierGen() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 23 )]
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

   [DataContract(Name = @"Trn_SupplierGen", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierGen_RESTLInterface : GxGenericCollectionItem<SdtTrn_SupplierGen>
   {
      public SdtTrn_SupplierGen_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_SupplierGen_RESTLInterface( SdtTrn_SupplierGen psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierGenCompanyName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Suppliergencompanyname
      {
         get {
            return sdt.gxTpr_Suppliergencompanyname ;
         }

         set {
            sdt.gxTpr_Suppliergencompanyname = value;
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

      public SdtTrn_SupplierGen sdt
      {
         get {
            return (SdtTrn_SupplierGen)Sdt ;
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
            sdt = new SdtTrn_SupplierGen() ;
         }
      }

   }

}
