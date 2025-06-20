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
   [XmlRoot(ElementName = "Trn_PreferredGenSupplier" )]
   [XmlType(TypeName =  "Trn_PreferredGenSupplier" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_PreferredGenSupplier : GxSilentTrnSdt
   {
      public SdtTrn_PreferredGenSupplier( )
      {
      }

      public SdtTrn_PreferredGenSupplier( IGxContext context )
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

      public void Load( Guid AV383PreferredGenSupplierId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV383PreferredGenSupplierId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PreferredGenSupplierId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_PreferredGenSupplier");
         metadata.Set("BT", "Trn_PreferredGenSupplier");
         metadata.Set("PK", "[ \"PreferredGenSupplierId\" ]");
         metadata.Set("PKAssigned", "[ \"PreferredGenSupplierId\" ]");
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
         state.Add("gxTpr_Preferredgensupplierid_Z");
         state.Add("gxTpr_Preferredgenorganisationid_Z");
         state.Add("gxTpr_Preferredsuppliergenid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_PreferredGenSupplier sdt;
         sdt = (SdtTrn_PreferredGenSupplier)(source);
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid ;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid ;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid ;
         gxTv_SdtTrn_PreferredGenSupplier_Mode = sdt.gxTv_SdtTrn_PreferredGenSupplier_Mode ;
         gxTv_SdtTrn_PreferredGenSupplier_Initialized = sdt.gxTv_SdtTrn_PreferredGenSupplier_Initialized ;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z ;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z ;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z ;
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
         AddObjectProperty("PreferredGenSupplierId", gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid, false, includeNonInitialized);
         AddObjectProperty("PreferredGenOrganisationId", gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid, false, includeNonInitialized);
         AddObjectProperty("PreferredSupplierGenId", gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_PreferredGenSupplier_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_PreferredGenSupplier_Initialized, false, includeNonInitialized);
            AddObjectProperty("PreferredGenSupplierId_Z", gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z, false, includeNonInitialized);
            AddObjectProperty("PreferredGenOrganisationId_Z", gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z, false, includeNonInitialized);
            AddObjectProperty("PreferredSupplierGenId_Z", gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_PreferredGenSupplier sdt )
      {
         if ( sdt.IsDirty("PreferredGenSupplierId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid ;
         }
         if ( sdt.IsDirty("PreferredGenOrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid ;
         }
         if ( sdt.IsDirty("PreferredSupplierGenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid = sdt.gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PreferredGenSupplierId" )]
      [  XmlElement( ElementName = "PreferredGenSupplierId"   )]
      public Guid gxTpr_Preferredgensupplierid
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid != value )
            {
               gxTv_SdtTrn_PreferredGenSupplier_Mode = "INS";
               this.gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z_SetNull( );
               this.gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z_SetNull( );
               this.gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z_SetNull( );
            }
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid = value;
            SetDirty("Preferredgensupplierid");
         }

      }

      [  SoapElement( ElementName = "PreferredGenOrganisationId" )]
      [  XmlElement( ElementName = "PreferredGenOrganisationId"   )]
      public Guid gxTpr_Preferredgenorganisationid
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid = value;
            SetDirty("Preferredgenorganisationid");
         }

      }

      [  SoapElement( ElementName = "PreferredSupplierGenId" )]
      [  XmlElement( ElementName = "PreferredSupplierGenId"   )]
      public Guid gxTpr_Preferredsuppliergenid
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid = value;
            SetDirty("Preferredsuppliergenid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_PreferredGenSupplier_Mode_SetNull( )
      {
         gxTv_SdtTrn_PreferredGenSupplier_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredGenSupplier_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_PreferredGenSupplier_Initialized_SetNull( )
      {
         gxTv_SdtTrn_PreferredGenSupplier_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredGenSupplier_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredGenSupplierId_Z" )]
      [  XmlElement( ElementName = "PreferredGenSupplierId_Z"   )]
      public Guid gxTpr_Preferredgensupplierid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z = value;
            SetDirty("Preferredgensupplierid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z = Guid.Empty;
         SetDirty("Preferredgensupplierid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredGenOrganisationId_Z" )]
      [  XmlElement( ElementName = "PreferredGenOrganisationId_Z"   )]
      public Guid gxTpr_Preferredgenorganisationid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z = value;
            SetDirty("Preferredgenorganisationid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z = Guid.Empty;
         SetDirty("Preferredgenorganisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredSupplierGenId_Z" )]
      [  XmlElement( ElementName = "PreferredSupplierGenId_Z"   )]
      public Guid gxTpr_Preferredsuppliergenid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z = value;
            SetDirty("Preferredsuppliergenid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z = Guid.Empty;
         SetDirty("Preferredsuppliergenid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z_IsNull( )
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
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid = Guid.Empty;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid = Guid.Empty;
         gxTv_SdtTrn_PreferredGenSupplier_Mode = "";
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z = Guid.Empty;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z = Guid.Empty;
         gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_preferredgensupplier", "GeneXus.Programs.trn_preferredgensupplier_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_PreferredGenSupplier_Initialized ;
      private string gxTv_SdtTrn_PreferredGenSupplier_Mode ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredgensupplierid_Z ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredgenorganisationid_Z ;
      private Guid gxTv_SdtTrn_PreferredGenSupplier_Preferredsuppliergenid_Z ;
   }

   [DataContract(Name = @"Trn_PreferredGenSupplier", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_PreferredGenSupplier_RESTInterface : GxGenericCollectionItem<SdtTrn_PreferredGenSupplier>
   {
      public SdtTrn_PreferredGenSupplier_RESTInterface( ) : base()
      {
      }

      public SdtTrn_PreferredGenSupplier_RESTInterface( SdtTrn_PreferredGenSupplier psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PreferredGenSupplierId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredgensupplierid
      {
         get {
            return sdt.gxTpr_Preferredgensupplierid ;
         }

         set {
            sdt.gxTpr_Preferredgensupplierid = value;
         }

      }

      [DataMember( Name = "PreferredGenOrganisationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredgenorganisationid
      {
         get {
            return sdt.gxTpr_Preferredgenorganisationid ;
         }

         set {
            sdt.gxTpr_Preferredgenorganisationid = value;
         }

      }

      [DataMember( Name = "PreferredSupplierGenId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredsuppliergenid
      {
         get {
            return sdt.gxTpr_Preferredsuppliergenid ;
         }

         set {
            sdt.gxTpr_Preferredsuppliergenid = value;
         }

      }

      public SdtTrn_PreferredGenSupplier sdt
      {
         get {
            return (SdtTrn_PreferredGenSupplier)Sdt ;
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
            sdt = new SdtTrn_PreferredGenSupplier() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Trn_PreferredGenSupplier", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_PreferredGenSupplier_RESTLInterface : GxGenericCollectionItem<SdtTrn_PreferredGenSupplier>
   {
      public SdtTrn_PreferredGenSupplier_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_PreferredGenSupplier_RESTLInterface( SdtTrn_PreferredGenSupplier psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_PreferredGenSupplier sdt
      {
         get {
            return (SdtTrn_PreferredGenSupplier)Sdt ;
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
            sdt = new SdtTrn_PreferredGenSupplier() ;
         }
      }

   }

}
