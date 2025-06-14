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
   [XmlRoot(ElementName = "Trn_ProductService" )]
   [XmlType(TypeName =  "Trn_ProductService" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_ProductService : GxSilentTrnSdt
   {
      public SdtTrn_ProductService( )
      {
      }

      public SdtTrn_ProductService( IGxContext context )
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

      public void Load( Guid AV58ProductServiceId ,
                        Guid AV29LocationId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV58ProductServiceId,(Guid)AV29LocationId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductServiceId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_ProductService");
         metadata.Set("BT", "Trn_ProductService");
         metadata.Set("PK", "[ \"ProductServiceId\",\"LocationId\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"ProductServiceId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SupplierAgbId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SupplierGenId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productserviceimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Productservicename_Z");
         state.Add("gxTpr_Productservicetilename_Z");
         state.Add("gxTpr_Productserviceclass_Z");
         state.Add("gxTpr_Productservicegroup_Z");
         state.Add("gxTpr_Suppliergenid_Z");
         state.Add("gxTpr_Suppliergencompanyname_Z");
         state.Add("gxTpr_Supplieragbid_Z");
         state.Add("gxTpr_Supplieragbname_Z");
         state.Add("gxTpr_Productserviceimage_gxi_Z");
         state.Add("gxTpr_Productserviceid_N");
         state.Add("gxTpr_Suppliergenid_N");
         state.Add("gxTpr_Supplieragbid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_ProductService sdt;
         sdt = (SdtTrn_ProductService)(source);
         gxTv_SdtTrn_ProductService_Productserviceid = sdt.gxTv_SdtTrn_ProductService_Productserviceid ;
         gxTv_SdtTrn_ProductService_Locationid = sdt.gxTv_SdtTrn_ProductService_Locationid ;
         gxTv_SdtTrn_ProductService_Organisationid = sdt.gxTv_SdtTrn_ProductService_Organisationid ;
         gxTv_SdtTrn_ProductService_Productservicename = sdt.gxTv_SdtTrn_ProductService_Productservicename ;
         gxTv_SdtTrn_ProductService_Productservicetilename = sdt.gxTv_SdtTrn_ProductService_Productservicetilename ;
         gxTv_SdtTrn_ProductService_Productservicedescription = sdt.gxTv_SdtTrn_ProductService_Productservicedescription ;
         gxTv_SdtTrn_ProductService_Productserviceclass = sdt.gxTv_SdtTrn_ProductService_Productserviceclass ;
         gxTv_SdtTrn_ProductService_Productserviceimage = sdt.gxTv_SdtTrn_ProductService_Productserviceimage ;
         gxTv_SdtTrn_ProductService_Productserviceimage_gxi = sdt.gxTv_SdtTrn_ProductService_Productserviceimage_gxi ;
         gxTv_SdtTrn_ProductService_Productservicegroup = sdt.gxTv_SdtTrn_ProductService_Productservicegroup ;
         gxTv_SdtTrn_ProductService_Suppliergenid = sdt.gxTv_SdtTrn_ProductService_Suppliergenid ;
         gxTv_SdtTrn_ProductService_Suppliergencompanyname = sdt.gxTv_SdtTrn_ProductService_Suppliergencompanyname ;
         gxTv_SdtTrn_ProductService_Supplieragbid = sdt.gxTv_SdtTrn_ProductService_Supplieragbid ;
         gxTv_SdtTrn_ProductService_Supplieragbname = sdt.gxTv_SdtTrn_ProductService_Supplieragbname ;
         gxTv_SdtTrn_ProductService_Mode = sdt.gxTv_SdtTrn_ProductService_Mode ;
         gxTv_SdtTrn_ProductService_Initialized = sdt.gxTv_SdtTrn_ProductService_Initialized ;
         gxTv_SdtTrn_ProductService_Productserviceid_Z = sdt.gxTv_SdtTrn_ProductService_Productserviceid_Z ;
         gxTv_SdtTrn_ProductService_Locationid_Z = sdt.gxTv_SdtTrn_ProductService_Locationid_Z ;
         gxTv_SdtTrn_ProductService_Organisationid_Z = sdt.gxTv_SdtTrn_ProductService_Organisationid_Z ;
         gxTv_SdtTrn_ProductService_Productservicename_Z = sdt.gxTv_SdtTrn_ProductService_Productservicename_Z ;
         gxTv_SdtTrn_ProductService_Productservicetilename_Z = sdt.gxTv_SdtTrn_ProductService_Productservicetilename_Z ;
         gxTv_SdtTrn_ProductService_Productserviceclass_Z = sdt.gxTv_SdtTrn_ProductService_Productserviceclass_Z ;
         gxTv_SdtTrn_ProductService_Productservicegroup_Z = sdt.gxTv_SdtTrn_ProductService_Productservicegroup_Z ;
         gxTv_SdtTrn_ProductService_Suppliergenid_Z = sdt.gxTv_SdtTrn_ProductService_Suppliergenid_Z ;
         gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z = sdt.gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z ;
         gxTv_SdtTrn_ProductService_Supplieragbid_Z = sdt.gxTv_SdtTrn_ProductService_Supplieragbid_Z ;
         gxTv_SdtTrn_ProductService_Supplieragbname_Z = sdt.gxTv_SdtTrn_ProductService_Supplieragbname_Z ;
         gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z = sdt.gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z ;
         gxTv_SdtTrn_ProductService_Productserviceid_N = sdt.gxTv_SdtTrn_ProductService_Productserviceid_N ;
         gxTv_SdtTrn_ProductService_Suppliergenid_N = sdt.gxTv_SdtTrn_ProductService_Suppliergenid_N ;
         gxTv_SdtTrn_ProductService_Supplieragbid_N = sdt.gxTv_SdtTrn_ProductService_Supplieragbid_N ;
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
         AddObjectProperty("ProductServiceId", gxTv_SdtTrn_ProductService_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_ProductService_Productserviceid_N, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_ProductService_Locationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_ProductService_Organisationid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceName", gxTv_SdtTrn_ProductService_Productservicename, false, includeNonInitialized);
         AddObjectProperty("ProductServiceTileName", gxTv_SdtTrn_ProductService_Productservicetilename, false, includeNonInitialized);
         AddObjectProperty("ProductServiceDescription", gxTv_SdtTrn_ProductService_Productservicedescription, false, includeNonInitialized);
         AddObjectProperty("ProductServiceClass", gxTv_SdtTrn_ProductService_Productserviceclass, false, includeNonInitialized);
         AddObjectProperty("ProductServiceImage", gxTv_SdtTrn_ProductService_Productserviceimage, false, includeNonInitialized);
         AddObjectProperty("ProductServiceGroup", gxTv_SdtTrn_ProductService_Productservicegroup, false, includeNonInitialized);
         AddObjectProperty("SupplierGenId", gxTv_SdtTrn_ProductService_Suppliergenid, false, includeNonInitialized);
         AddObjectProperty("SupplierGenId_N", gxTv_SdtTrn_ProductService_Suppliergenid_N, false, includeNonInitialized);
         AddObjectProperty("SupplierGenCompanyName", gxTv_SdtTrn_ProductService_Suppliergencompanyname, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbId", gxTv_SdtTrn_ProductService_Supplieragbid, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbId_N", gxTv_SdtTrn_ProductService_Supplieragbid_N, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbName", gxTv_SdtTrn_ProductService_Supplieragbname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductServiceImage_GXI", gxTv_SdtTrn_ProductService_Productserviceimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_ProductService_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_ProductService_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtTrn_ProductService_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_ProductService_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_ProductService_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceName_Z", gxTv_SdtTrn_ProductService_Productservicename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceTileName_Z", gxTv_SdtTrn_ProductService_Productservicetilename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceClass_Z", gxTv_SdtTrn_ProductService_Productserviceclass_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceGroup_Z", gxTv_SdtTrn_ProductService_Productservicegroup_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenId_Z", gxTv_SdtTrn_ProductService_Suppliergenid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenCompanyName_Z", gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbId_Z", gxTv_SdtTrn_ProductService_Supplieragbid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbName_Z", gxTv_SdtTrn_ProductService_Supplieragbname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceImage_GXI_Z", gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_ProductService_Productserviceid_N, false, includeNonInitialized);
            AddObjectProperty("SupplierGenId_N", gxTv_SdtTrn_ProductService_Suppliergenid_N, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbId_N", gxTv_SdtTrn_ProductService_Supplieragbid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_ProductService sdt )
      {
         if ( sdt.IsDirty("ProductServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceid = sdt.gxTv_SdtTrn_ProductService_Productserviceid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Locationid = sdt.gxTv_SdtTrn_ProductService_Locationid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Organisationid = sdt.gxTv_SdtTrn_ProductService_Organisationid ;
         }
         if ( sdt.IsDirty("ProductServiceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicename = sdt.gxTv_SdtTrn_ProductService_Productservicename ;
         }
         if ( sdt.IsDirty("ProductServiceTileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicetilename = sdt.gxTv_SdtTrn_ProductService_Productservicetilename ;
         }
         if ( sdt.IsDirty("ProductServiceDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicedescription = sdt.gxTv_SdtTrn_ProductService_Productservicedescription ;
         }
         if ( sdt.IsDirty("ProductServiceClass") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceclass = sdt.gxTv_SdtTrn_ProductService_Productserviceclass ;
         }
         if ( sdt.IsDirty("ProductServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceimage = sdt.gxTv_SdtTrn_ProductService_Productserviceimage ;
         }
         if ( sdt.IsDirty("ProductServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceimage_gxi = sdt.gxTv_SdtTrn_ProductService_Productserviceimage_gxi ;
         }
         if ( sdt.IsDirty("ProductServiceGroup") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicegroup = sdt.gxTv_SdtTrn_ProductService_Productservicegroup ;
         }
         if ( sdt.IsDirty("SupplierGenId") )
         {
            gxTv_SdtTrn_ProductService_Suppliergenid_N = (short)(sdt.gxTv_SdtTrn_ProductService_Suppliergenid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergenid = sdt.gxTv_SdtTrn_ProductService_Suppliergenid ;
         }
         if ( sdt.IsDirty("SupplierGenCompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergencompanyname = sdt.gxTv_SdtTrn_ProductService_Suppliergencompanyname ;
         }
         if ( sdt.IsDirty("SupplierAgbId") )
         {
            gxTv_SdtTrn_ProductService_Supplieragbid_N = (short)(sdt.gxTv_SdtTrn_ProductService_Supplieragbid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbid = sdt.gxTv_SdtTrn_ProductService_Supplieragbid ;
         }
         if ( sdt.IsDirty("SupplierAgbName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbname = sdt.gxTv_SdtTrn_ProductService_Supplieragbname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductServiceId" )]
      [  XmlElement( ElementName = "ProductServiceId"   )]
      public Guid gxTpr_Productserviceid
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ProductService_Productserviceid != value )
            {
               gxTv_SdtTrn_ProductService_Mode = "INS";
               this.gxTv_SdtTrn_ProductService_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicetilename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceclass_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicegroup_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_ProductService_Productserviceid = value;
            SetDirty("Productserviceid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_ProductService_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ProductService_Locationid != value )
            {
               gxTv_SdtTrn_ProductService_Mode = "INS";
               this.gxTv_SdtTrn_ProductService_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicetilename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceclass_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicegroup_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_ProductService_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_ProductService_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ProductService_Organisationid != value )
            {
               gxTv_SdtTrn_ProductService_Mode = "INS";
               this.gxTv_SdtTrn_ProductService_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicetilename_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceclass_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productservicegroup_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbid_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Supplieragbname_Z_SetNull( );
               this.gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_ProductService_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "ProductServiceName" )]
      [  XmlElement( ElementName = "ProductServiceName"   )]
      public string gxTpr_Productservicename
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicename = value;
            SetDirty("Productservicename");
         }

      }

      [  SoapElement( ElementName = "ProductServiceTileName" )]
      [  XmlElement( ElementName = "ProductServiceTileName"   )]
      public string gxTpr_Productservicetilename
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicetilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicetilename = value;
            SetDirty("Productservicetilename");
         }

      }

      [  SoapElement( ElementName = "ProductServiceDescription" )]
      [  XmlElement( ElementName = "ProductServiceDescription"   )]
      public string gxTpr_Productservicedescription
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicedescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicedescription = value;
            SetDirty("Productservicedescription");
         }

      }

      [  SoapElement( ElementName = "ProductServiceClass" )]
      [  XmlElement( ElementName = "ProductServiceClass"   )]
      public string gxTpr_Productserviceclass
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceclass ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceclass = value;
            SetDirty("Productserviceclass");
         }

      }

      [  SoapElement( ElementName = "ProductServiceImage" )]
      [  XmlElement( ElementName = "ProductServiceImage"   )]
      [GxUpload()]
      public string gxTpr_Productserviceimage
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceimage = value;
            SetDirty("Productserviceimage");
         }

      }

      [  SoapElement( ElementName = "ProductServiceImage_GXI" )]
      [  XmlElement( ElementName = "ProductServiceImage_GXI"   )]
      public string gxTpr_Productserviceimage_gxi
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceimage_gxi = value;
            SetDirty("Productserviceimage_gxi");
         }

      }

      [  SoapElement( ElementName = "ProductServiceGroup" )]
      [  XmlElement( ElementName = "ProductServiceGroup"   )]
      public string gxTpr_Productservicegroup
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicegroup ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicegroup = value;
            SetDirty("Productservicegroup");
         }

      }

      [  SoapElement( ElementName = "SupplierGenId" )]
      [  XmlElement( ElementName = "SupplierGenId"   )]
      public Guid gxTpr_Suppliergenid
      {
         get {
            return gxTv_SdtTrn_ProductService_Suppliergenid ;
         }

         set {
            gxTv_SdtTrn_ProductService_Suppliergenid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergenid = value;
            SetDirty("Suppliergenid");
         }

      }

      public void gxTv_SdtTrn_ProductService_Suppliergenid_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Suppliergenid_N = 1;
         gxTv_SdtTrn_ProductService_Suppliergenid = Guid.Empty;
         SetDirty("Suppliergenid");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Suppliergenid_IsNull( )
      {
         return (gxTv_SdtTrn_ProductService_Suppliergenid_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierGenCompanyName" )]
      [  XmlElement( ElementName = "SupplierGenCompanyName"   )]
      public string gxTpr_Suppliergencompanyname
      {
         get {
            return gxTv_SdtTrn_ProductService_Suppliergencompanyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergencompanyname = value;
            SetDirty("Suppliergencompanyname");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbId" )]
      [  XmlElement( ElementName = "SupplierAgbId"   )]
      public Guid gxTpr_Supplieragbid
      {
         get {
            return gxTv_SdtTrn_ProductService_Supplieragbid ;
         }

         set {
            gxTv_SdtTrn_ProductService_Supplieragbid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbid = value;
            SetDirty("Supplieragbid");
         }

      }

      public void gxTv_SdtTrn_ProductService_Supplieragbid_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Supplieragbid_N = 1;
         gxTv_SdtTrn_ProductService_Supplieragbid = Guid.Empty;
         SetDirty("Supplieragbid");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Supplieragbid_IsNull( )
      {
         return (gxTv_SdtTrn_ProductService_Supplieragbid_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierAgbName" )]
      [  XmlElement( ElementName = "SupplierAgbName"   )]
      public string gxTpr_Supplieragbname
      {
         get {
            return gxTv_SdtTrn_ProductService_Supplieragbname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbname = value;
            SetDirty("Supplieragbname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_ProductService_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_ProductService_Mode_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_ProductService_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_ProductService_Initialized_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_Z" )]
      [  XmlElement( ElementName = "ProductServiceId_Z"   )]
      public Guid gxTpr_Productserviceid_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceid_Z = value;
            SetDirty("Productserviceid_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productserviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productserviceid_Z = Guid.Empty;
         SetDirty("Productserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceName_Z" )]
      [  XmlElement( ElementName = "ProductServiceName_Z"   )]
      public string gxTpr_Productservicename_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicename_Z = value;
            SetDirty("Productservicename_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productservicename_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productservicename_Z = "";
         SetDirty("Productservicename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productservicename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceTileName_Z" )]
      [  XmlElement( ElementName = "ProductServiceTileName_Z"   )]
      public string gxTpr_Productservicetilename_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicetilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicetilename_Z = value;
            SetDirty("Productservicetilename_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productservicetilename_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productservicetilename_Z = "";
         SetDirty("Productservicetilename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productservicetilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceClass_Z" )]
      [  XmlElement( ElementName = "ProductServiceClass_Z"   )]
      public string gxTpr_Productserviceclass_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceclass_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceclass_Z = value;
            SetDirty("Productserviceclass_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productserviceclass_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productserviceclass_Z = "";
         SetDirty("Productserviceclass_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productserviceclass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceGroup_Z" )]
      [  XmlElement( ElementName = "ProductServiceGroup_Z"   )]
      public string gxTpr_Productservicegroup_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productservicegroup_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productservicegroup_Z = value;
            SetDirty("Productservicegroup_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productservicegroup_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productservicegroup_Z = "";
         SetDirty("Productservicegroup_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productservicegroup_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenId_Z" )]
      [  XmlElement( ElementName = "SupplierGenId_Z"   )]
      public Guid gxTpr_Suppliergenid_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Suppliergenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergenid_Z = value;
            SetDirty("Suppliergenid_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Suppliergenid_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Suppliergenid_Z = Guid.Empty;
         SetDirty("Suppliergenid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Suppliergenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenCompanyName_Z" )]
      [  XmlElement( ElementName = "SupplierGenCompanyName_Z"   )]
      public string gxTpr_Suppliergencompanyname_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z = value;
            SetDirty("Suppliergencompanyname_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z = "";
         SetDirty("Suppliergencompanyname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbId_Z" )]
      [  XmlElement( ElementName = "SupplierAgbId_Z"   )]
      public Guid gxTpr_Supplieragbid_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Supplieragbid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbid_Z = value;
            SetDirty("Supplieragbid_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Supplieragbid_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Supplieragbid_Z = Guid.Empty;
         SetDirty("Supplieragbid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Supplieragbid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbName_Z" )]
      [  XmlElement( ElementName = "SupplierAgbName_Z"   )]
      public string gxTpr_Supplieragbname_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Supplieragbname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbname_Z = value;
            SetDirty("Supplieragbname_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Supplieragbname_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Supplieragbname_Z = "";
         SetDirty("Supplieragbname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Supplieragbname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceImage_GXI_Z" )]
      [  XmlElement( ElementName = "ProductServiceImage_GXI_Z"   )]
      public string gxTpr_Productserviceimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z = value;
            SetDirty("Productserviceimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z = "";
         SetDirty("Productserviceimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_N" )]
      [  XmlElement( ElementName = "ProductServiceId_N"   )]
      public short gxTpr_Productserviceid_N
      {
         get {
            return gxTv_SdtTrn_ProductService_Productserviceid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Productserviceid_N = value;
            SetDirty("Productserviceid_N");
         }

      }

      public void gxTv_SdtTrn_ProductService_Productserviceid_N_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Productserviceid_N = 0;
         SetDirty("Productserviceid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Productserviceid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenId_N" )]
      [  XmlElement( ElementName = "SupplierGenId_N"   )]
      public short gxTpr_Suppliergenid_N
      {
         get {
            return gxTv_SdtTrn_ProductService_Suppliergenid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Suppliergenid_N = value;
            SetDirty("Suppliergenid_N");
         }

      }

      public void gxTv_SdtTrn_ProductService_Suppliergenid_N_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Suppliergenid_N = 0;
         SetDirty("Suppliergenid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Suppliergenid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbId_N" )]
      [  XmlElement( ElementName = "SupplierAgbId_N"   )]
      public short gxTpr_Supplieragbid_N
      {
         get {
            return gxTv_SdtTrn_ProductService_Supplieragbid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ProductService_Supplieragbid_N = value;
            SetDirty("Supplieragbid_N");
         }

      }

      public void gxTv_SdtTrn_ProductService_Supplieragbid_N_SetNull( )
      {
         gxTv_SdtTrn_ProductService_Supplieragbid_N = 0;
         SetDirty("Supplieragbid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_ProductService_Supplieragbid_N_IsNull( )
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
         gxTv_SdtTrn_ProductService_Productserviceid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_ProductService_Locationid = Guid.Empty;
         gxTv_SdtTrn_ProductService_Organisationid = Guid.Empty;
         gxTv_SdtTrn_ProductService_Productservicename = "";
         gxTv_SdtTrn_ProductService_Productservicetilename = "";
         gxTv_SdtTrn_ProductService_Productservicedescription = "";
         gxTv_SdtTrn_ProductService_Productserviceclass = "";
         gxTv_SdtTrn_ProductService_Productserviceimage = "";
         gxTv_SdtTrn_ProductService_Productserviceimage_gxi = "";
         gxTv_SdtTrn_ProductService_Productservicegroup = "";
         gxTv_SdtTrn_ProductService_Suppliergenid = Guid.Empty;
         gxTv_SdtTrn_ProductService_Suppliergencompanyname = "";
         gxTv_SdtTrn_ProductService_Supplieragbid = Guid.Empty;
         gxTv_SdtTrn_ProductService_Supplieragbname = "";
         gxTv_SdtTrn_ProductService_Mode = "";
         gxTv_SdtTrn_ProductService_Productserviceid_Z = Guid.Empty;
         gxTv_SdtTrn_ProductService_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_ProductService_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_ProductService_Productservicename_Z = "";
         gxTv_SdtTrn_ProductService_Productservicetilename_Z = "";
         gxTv_SdtTrn_ProductService_Productserviceclass_Z = "";
         gxTv_SdtTrn_ProductService_Productservicegroup_Z = "";
         gxTv_SdtTrn_ProductService_Suppliergenid_Z = Guid.Empty;
         gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z = "";
         gxTv_SdtTrn_ProductService_Supplieragbid_Z = Guid.Empty;
         gxTv_SdtTrn_ProductService_Supplieragbname_Z = "";
         gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_productservice", "GeneXus.Programs.trn_productservice_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_ProductService_Initialized ;
      private short gxTv_SdtTrn_ProductService_Productserviceid_N ;
      private short gxTv_SdtTrn_ProductService_Suppliergenid_N ;
      private short gxTv_SdtTrn_ProductService_Supplieragbid_N ;
      private string gxTv_SdtTrn_ProductService_Productservicetilename ;
      private string gxTv_SdtTrn_ProductService_Mode ;
      private string gxTv_SdtTrn_ProductService_Productservicetilename_Z ;
      private string gxTv_SdtTrn_ProductService_Productservicedescription ;
      private string gxTv_SdtTrn_ProductService_Productservicename ;
      private string gxTv_SdtTrn_ProductService_Productserviceclass ;
      private string gxTv_SdtTrn_ProductService_Productserviceimage_gxi ;
      private string gxTv_SdtTrn_ProductService_Productservicegroup ;
      private string gxTv_SdtTrn_ProductService_Suppliergencompanyname ;
      private string gxTv_SdtTrn_ProductService_Supplieragbname ;
      private string gxTv_SdtTrn_ProductService_Productservicename_Z ;
      private string gxTv_SdtTrn_ProductService_Productserviceclass_Z ;
      private string gxTv_SdtTrn_ProductService_Productservicegroup_Z ;
      private string gxTv_SdtTrn_ProductService_Suppliergencompanyname_Z ;
      private string gxTv_SdtTrn_ProductService_Supplieragbname_Z ;
      private string gxTv_SdtTrn_ProductService_Productserviceimage_gxi_Z ;
      private string gxTv_SdtTrn_ProductService_Productserviceimage ;
      private Guid gxTv_SdtTrn_ProductService_Productserviceid ;
      private Guid gxTv_SdtTrn_ProductService_Locationid ;
      private Guid gxTv_SdtTrn_ProductService_Organisationid ;
      private Guid gxTv_SdtTrn_ProductService_Suppliergenid ;
      private Guid gxTv_SdtTrn_ProductService_Supplieragbid ;
      private Guid gxTv_SdtTrn_ProductService_Productserviceid_Z ;
      private Guid gxTv_SdtTrn_ProductService_Locationid_Z ;
      private Guid gxTv_SdtTrn_ProductService_Organisationid_Z ;
      private Guid gxTv_SdtTrn_ProductService_Suppliergenid_Z ;
      private Guid gxTv_SdtTrn_ProductService_Supplieragbid_Z ;
   }

   [DataContract(Name = @"Trn_ProductService", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ProductService_RESTInterface : GxGenericCollectionItem<SdtTrn_ProductService>
   {
      public SdtTrn_ProductService_RESTInterface( ) : base()
      {
      }

      public SdtTrn_ProductService_RESTInterface( SdtTrn_ProductService psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductServiceId" , Order = 0 )]
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

      [DataMember( Name = "ProductServiceName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Productservicename
      {
         get {
            return sdt.gxTpr_Productservicename ;
         }

         set {
            sdt.gxTpr_Productservicename = value;
         }

      }

      [DataMember( Name = "ProductServiceTileName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Productservicetilename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productservicetilename) ;
         }

         set {
            sdt.gxTpr_Productservicetilename = value;
         }

      }

      [DataMember( Name = "ProductServiceDescription" , Order = 5 )]
      public string gxTpr_Productservicedescription
      {
         get {
            return sdt.gxTpr_Productservicedescription ;
         }

         set {
            sdt.gxTpr_Productservicedescription = value;
         }

      }

      [DataMember( Name = "ProductServiceClass" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Productserviceclass
      {
         get {
            return sdt.gxTpr_Productserviceclass ;
         }

         set {
            sdt.gxTpr_Productserviceclass = value;
         }

      }

      [DataMember( Name = "ProductServiceImage" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Productserviceimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productserviceimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Productserviceimage) : StringUtil.RTrim( sdt.gxTpr_Productserviceimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Productserviceimage = value;
         }

      }

      [DataMember( Name = "ProductServiceGroup" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Productservicegroup
      {
         get {
            return sdt.gxTpr_Productservicegroup ;
         }

         set {
            sdt.gxTpr_Productservicegroup = value;
         }

      }

      [DataMember( Name = "SupplierGenId" , Order = 9 )]
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

      [DataMember( Name = "SupplierGenCompanyName" , Order = 10 )]
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

      [DataMember( Name = "SupplierAgbId" , Order = 11 )]
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

      [DataMember( Name = "SupplierAgbName" , Order = 12 )]
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

      public SdtTrn_ProductService sdt
      {
         get {
            return (SdtTrn_ProductService)Sdt ;
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
            sdt = new SdtTrn_ProductService() ;
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

   [DataContract(Name = @"Trn_ProductService", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ProductService_RESTLInterface : GxGenericCollectionItem<SdtTrn_ProductService>
   {
      public SdtTrn_ProductService_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_ProductService_RESTLInterface( SdtTrn_ProductService psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductServiceName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productservicename
      {
         get {
            return sdt.gxTpr_Productservicename ;
         }

         set {
            sdt.gxTpr_Productservicename = value;
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

      public SdtTrn_ProductService sdt
      {
         get {
            return (SdtTrn_ProductService)Sdt ;
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
            sdt = new SdtTrn_ProductService() ;
         }
      }

   }

}
