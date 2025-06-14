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
   [XmlRoot(ElementName = "Trn_ResidentPackage" )]
   [XmlType(TypeName =  "Trn_ResidentPackage" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_ResidentPackage : GxSilentTrnSdt
   {
      public SdtTrn_ResidentPackage( )
      {
      }

      public SdtTrn_ResidentPackage( IGxContext context )
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

      public void Load( Guid AV527ResidentPackageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV527ResidentPackageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ResidentPackageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_ResidentPackage");
         metadata.Set("BT", "Trn_ResidentPackage");
         metadata.Set("PK", "[ \"ResidentPackageId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentPackageId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[ \"SG_LocationId-LocationId\",\"SG_OrganisationId-OrganisationId\" ] } ]");
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
         state.Add("gxTpr_Residentpackageid_Z");
         state.Add("gxTpr_Sg_locationid_Z");
         state.Add("gxTpr_Sg_organisationid_Z");
         state.Add("gxTpr_Residentpackagename_Z");
         state.Add("gxTpr_Residentpackagedefault_Z");
         state.Add("gxTpr_Residentpackageid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_ResidentPackage sdt;
         sdt = (SdtTrn_ResidentPackage)(source);
         gxTv_SdtTrn_ResidentPackage_Residentpackageid = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackageid ;
         gxTv_SdtTrn_ResidentPackage_Sg_locationid = sdt.gxTv_SdtTrn_ResidentPackage_Sg_locationid ;
         gxTv_SdtTrn_ResidentPackage_Sg_organisationid = sdt.gxTv_SdtTrn_ResidentPackage_Sg_organisationid ;
         gxTv_SdtTrn_ResidentPackage_Residentpackagename = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagename ;
         gxTv_SdtTrn_ResidentPackage_Residentpackagemodules = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagemodules ;
         gxTv_SdtTrn_ResidentPackage_Residentpackagedefault = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagedefault ;
         gxTv_SdtTrn_ResidentPackage_Mode = sdt.gxTv_SdtTrn_ResidentPackage_Mode ;
         gxTv_SdtTrn_ResidentPackage_Initialized = sdt.gxTv_SdtTrn_ResidentPackage_Initialized ;
         gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z ;
         gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z = sdt.gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z ;
         gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z = sdt.gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z ;
         gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z ;
         gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z ;
         gxTv_SdtTrn_ResidentPackage_Residentpackageid_N = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackageid_N ;
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
         AddObjectProperty("ResidentPackageId", gxTv_SdtTrn_ResidentPackage_Residentpackageid, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageId_N", gxTv_SdtTrn_ResidentPackage_Residentpackageid_N, false, includeNonInitialized);
         AddObjectProperty("SG_LocationId", gxTv_SdtTrn_ResidentPackage_Sg_locationid, false, includeNonInitialized);
         AddObjectProperty("SG_OrganisationId", gxTv_SdtTrn_ResidentPackage_Sg_organisationid, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageName", gxTv_SdtTrn_ResidentPackage_Residentpackagename, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageModules", gxTv_SdtTrn_ResidentPackage_Residentpackagemodules, false, includeNonInitialized);
         AddObjectProperty("ResidentPackageDefault", gxTv_SdtTrn_ResidentPackage_Residentpackagedefault, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_ResidentPackage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_ResidentPackage_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageId_Z", gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_LocationId_Z", gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_OrganisationId_Z", gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageName_Z", gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageDefault_Z", gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPackageId_N", gxTv_SdtTrn_ResidentPackage_Residentpackageid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_ResidentPackage sdt )
      {
         if ( sdt.IsDirty("ResidentPackageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackageid = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackageid ;
         }
         if ( sdt.IsDirty("SG_LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_locationid = sdt.gxTv_SdtTrn_ResidentPackage_Sg_locationid ;
         }
         if ( sdt.IsDirty("SG_OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_organisationid = sdt.gxTv_SdtTrn_ResidentPackage_Sg_organisationid ;
         }
         if ( sdt.IsDirty("ResidentPackageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagename = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagename ;
         }
         if ( sdt.IsDirty("ResidentPackageModules") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagemodules = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagemodules ;
         }
         if ( sdt.IsDirty("ResidentPackageDefault") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagedefault = sdt.gxTv_SdtTrn_ResidentPackage_Residentpackagedefault ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentPackageId" )]
      [  XmlElement( ElementName = "ResidentPackageId"   )]
      public Guid gxTpr_Residentpackageid
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ResidentPackage_Residentpackageid != value )
            {
               gxTv_SdtTrn_ResidentPackage_Mode = "INS";
               this.gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z_SetNull( );
            }
            gxTv_SdtTrn_ResidentPackage_Residentpackageid = value;
            SetDirty("Residentpackageid");
         }

      }

      [  SoapElement( ElementName = "SG_LocationId" )]
      [  XmlElement( ElementName = "SG_LocationId"   )]
      public Guid gxTpr_Sg_locationid
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Sg_locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_locationid = value;
            SetDirty("Sg_locationid");
         }

      }

      [  SoapElement( ElementName = "SG_OrganisationId" )]
      [  XmlElement( ElementName = "SG_OrganisationId"   )]
      public Guid gxTpr_Sg_organisationid
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Sg_organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_organisationid = value;
            SetDirty("Sg_organisationid");
         }

      }

      [  SoapElement( ElementName = "ResidentPackageName" )]
      [  XmlElement( ElementName = "ResidentPackageName"   )]
      public string gxTpr_Residentpackagename
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagename = value;
            SetDirty("Residentpackagename");
         }

      }

      [  SoapElement( ElementName = "ResidentPackageModules" )]
      [  XmlElement( ElementName = "ResidentPackageModules"   )]
      public string gxTpr_Residentpackagemodules
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackagemodules ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagemodules = value;
            SetDirty("Residentpackagemodules");
         }

      }

      [  SoapElement( ElementName = "ResidentPackageDefault" )]
      [  XmlElement( ElementName = "ResidentPackageDefault"   )]
      public bool gxTpr_Residentpackagedefault
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackagedefault ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagedefault = value;
            SetDirty("Residentpackagedefault");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Mode_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Initialized_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageId_Z" )]
      [  XmlElement( ElementName = "ResidentPackageId_Z"   )]
      public Guid gxTpr_Residentpackageid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z = value;
            SetDirty("Residentpackageid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z = Guid.Empty;
         SetDirty("Residentpackageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_LocationId_Z" )]
      [  XmlElement( ElementName = "SG_LocationId_Z"   )]
      public Guid gxTpr_Sg_locationid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z = value;
            SetDirty("Sg_locationid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z = Guid.Empty;
         SetDirty("Sg_locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_OrganisationId_Z" )]
      [  XmlElement( ElementName = "SG_OrganisationId_Z"   )]
      public Guid gxTpr_Sg_organisationid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z = value;
            SetDirty("Sg_organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z = Guid.Empty;
         SetDirty("Sg_organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageName_Z" )]
      [  XmlElement( ElementName = "ResidentPackageName_Z"   )]
      public string gxTpr_Residentpackagename_Z
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z = value;
            SetDirty("Residentpackagename_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z = "";
         SetDirty("Residentpackagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageDefault_Z" )]
      [  XmlElement( ElementName = "ResidentPackageDefault_Z"   )]
      public bool gxTpr_Residentpackagedefault_Z
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z = value;
            SetDirty("Residentpackagedefault_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z = false;
         SetDirty("Residentpackagedefault_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPackageId_N" )]
      [  XmlElement( ElementName = "ResidentPackageId_N"   )]
      public short gxTpr_Residentpackageid_N
      {
         get {
            return gxTv_SdtTrn_ResidentPackage_Residentpackageid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentPackage_Residentpackageid_N = value;
            SetDirty("Residentpackageid_N");
         }

      }

      public void gxTv_SdtTrn_ResidentPackage_Residentpackageid_N_SetNull( )
      {
         gxTv_SdtTrn_ResidentPackage_Residentpackageid_N = 0;
         SetDirty("Residentpackageid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentPackage_Residentpackageid_N_IsNull( )
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
         gxTv_SdtTrn_ResidentPackage_Residentpackageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_ResidentPackage_Sg_locationid = Guid.Empty;
         gxTv_SdtTrn_ResidentPackage_Sg_organisationid = Guid.Empty;
         gxTv_SdtTrn_ResidentPackage_Residentpackagename = "";
         gxTv_SdtTrn_ResidentPackage_Residentpackagemodules = "";
         gxTv_SdtTrn_ResidentPackage_Mode = "";
         gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_residentpackage", "GeneXus.Programs.trn_residentpackage_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_ResidentPackage_Initialized ;
      private short gxTv_SdtTrn_ResidentPackage_Residentpackageid_N ;
      private string gxTv_SdtTrn_ResidentPackage_Mode ;
      private bool gxTv_SdtTrn_ResidentPackage_Residentpackagedefault ;
      private bool gxTv_SdtTrn_ResidentPackage_Residentpackagedefault_Z ;
      private string gxTv_SdtTrn_ResidentPackage_Residentpackagemodules ;
      private string gxTv_SdtTrn_ResidentPackage_Residentpackagename ;
      private string gxTv_SdtTrn_ResidentPackage_Residentpackagename_Z ;
      private Guid gxTv_SdtTrn_ResidentPackage_Residentpackageid ;
      private Guid gxTv_SdtTrn_ResidentPackage_Sg_locationid ;
      private Guid gxTv_SdtTrn_ResidentPackage_Sg_organisationid ;
      private Guid gxTv_SdtTrn_ResidentPackage_Residentpackageid_Z ;
      private Guid gxTv_SdtTrn_ResidentPackage_Sg_locationid_Z ;
      private Guid gxTv_SdtTrn_ResidentPackage_Sg_organisationid_Z ;
   }

   [DataContract(Name = @"Trn_ResidentPackage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentPackage_RESTInterface : GxGenericCollectionItem<SdtTrn_ResidentPackage>
   {
      public SdtTrn_ResidentPackage_RESTInterface( ) : base()
      {
      }

      public SdtTrn_ResidentPackage_RESTInterface( SdtTrn_ResidentPackage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentPackageId" , Order = 0 )]
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

      [DataMember( Name = "SG_LocationId" , Order = 1 )]
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

      [DataMember( Name = "SG_OrganisationId" , Order = 2 )]
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

      [DataMember( Name = "ResidentPackageName" , Order = 3 )]
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

      [DataMember( Name = "ResidentPackageModules" , Order = 4 )]
      public string gxTpr_Residentpackagemodules
      {
         get {
            return sdt.gxTpr_Residentpackagemodules ;
         }

         set {
            sdt.gxTpr_Residentpackagemodules = value;
         }

      }

      [DataMember( Name = "ResidentPackageDefault" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Residentpackagedefault
      {
         get {
            return sdt.gxTpr_Residentpackagedefault ;
         }

         set {
            sdt.gxTpr_Residentpackagedefault = value;
         }

      }

      public SdtTrn_ResidentPackage sdt
      {
         get {
            return (SdtTrn_ResidentPackage)Sdt ;
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
            sdt = new SdtTrn_ResidentPackage() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Trn_ResidentPackage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentPackage_RESTLInterface : GxGenericCollectionItem<SdtTrn_ResidentPackage>
   {
      public SdtTrn_ResidentPackage_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_ResidentPackage_RESTLInterface( SdtTrn_ResidentPackage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentPackageName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_ResidentPackage sdt
      {
         get {
            return (SdtTrn_ResidentPackage)Sdt ;
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
            sdt = new SdtTrn_ResidentPackage() ;
         }
      }

   }

}
