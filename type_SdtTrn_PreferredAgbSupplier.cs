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
   [XmlRoot(ElementName = "Trn_PreferredAgbSupplier" )]
   [XmlType(TypeName =  "Trn_PreferredAgbSupplier" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_PreferredAgbSupplier : GxSilentTrnSdt
   {
      public SdtTrn_PreferredAgbSupplier( )
      {
      }

      public SdtTrn_PreferredAgbSupplier( IGxContext context )
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

      public void Load( Guid AV384PreferredAgbSupplierId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV384PreferredAgbSupplierId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PreferredAgbSupplierId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_PreferredAgbSupplier");
         metadata.Set("BT", "Trn_PreferredAgbSupplier");
         metadata.Set("PK", "[ \"PreferredAgbSupplierId\" ]");
         metadata.Set("PKAssigned", "[ \"PreferredAgbSupplierId\" ]");
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
         state.Add("gxTpr_Preferredagbsupplierid_Z");
         state.Add("gxTpr_Preferredagborganisationid_Z");
         state.Add("gxTpr_Preferredsupplieragbid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_PreferredAgbSupplier sdt;
         sdt = (SdtTrn_PreferredAgbSupplier)(source);
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid ;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid ;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid ;
         gxTv_SdtTrn_PreferredAgbSupplier_Mode = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Mode ;
         gxTv_SdtTrn_PreferredAgbSupplier_Initialized = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Initialized ;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z ;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z ;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z ;
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
         AddObjectProperty("PreferredAgbSupplierId", gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid, false, includeNonInitialized);
         AddObjectProperty("PreferredAgbOrganisationId", gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid, false, includeNonInitialized);
         AddObjectProperty("PreferredSupplierAgbId", gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_PreferredAgbSupplier_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_PreferredAgbSupplier_Initialized, false, includeNonInitialized);
            AddObjectProperty("PreferredAgbSupplierId_Z", gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z, false, includeNonInitialized);
            AddObjectProperty("PreferredAgbOrganisationId_Z", gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z, false, includeNonInitialized);
            AddObjectProperty("PreferredSupplierAgbId_Z", gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_PreferredAgbSupplier sdt )
      {
         if ( sdt.IsDirty("PreferredAgbSupplierId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid ;
         }
         if ( sdt.IsDirty("PreferredAgbOrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid ;
         }
         if ( sdt.IsDirty("PreferredSupplierAgbId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid = sdt.gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PreferredAgbSupplierId" )]
      [  XmlElement( ElementName = "PreferredAgbSupplierId"   )]
      public Guid gxTpr_Preferredagbsupplierid
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid != value )
            {
               gxTv_SdtTrn_PreferredAgbSupplier_Mode = "INS";
               this.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z_SetNull( );
               this.gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z_SetNull( );
               this.gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z_SetNull( );
            }
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid = value;
            SetDirty("Preferredagbsupplierid");
         }

      }

      [  SoapElement( ElementName = "PreferredAgbOrganisationId" )]
      [  XmlElement( ElementName = "PreferredAgbOrganisationId"   )]
      public Guid gxTpr_Preferredagborganisationid
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid = value;
            SetDirty("Preferredagborganisationid");
         }

      }

      [  SoapElement( ElementName = "PreferredSupplierAgbId" )]
      [  XmlElement( ElementName = "PreferredSupplierAgbId"   )]
      public Guid gxTpr_Preferredsupplieragbid
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid = value;
            SetDirty("Preferredsupplieragbid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_PreferredAgbSupplier_Mode_SetNull( )
      {
         gxTv_SdtTrn_PreferredAgbSupplier_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredAgbSupplier_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_PreferredAgbSupplier_Initialized_SetNull( )
      {
         gxTv_SdtTrn_PreferredAgbSupplier_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredAgbSupplier_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredAgbSupplierId_Z" )]
      [  XmlElement( ElementName = "PreferredAgbSupplierId_Z"   )]
      public Guid gxTpr_Preferredagbsupplierid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z = value;
            SetDirty("Preferredagbsupplierid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z = Guid.Empty;
         SetDirty("Preferredagbsupplierid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredAgbOrganisationId_Z" )]
      [  XmlElement( ElementName = "PreferredAgbOrganisationId_Z"   )]
      public Guid gxTpr_Preferredagborganisationid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z = value;
            SetDirty("Preferredagborganisationid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z = Guid.Empty;
         SetDirty("Preferredagborganisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferredSupplierAgbId_Z" )]
      [  XmlElement( ElementName = "PreferredSupplierAgbId_Z"   )]
      public Guid gxTpr_Preferredsupplieragbid_Z
      {
         get {
            return gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z = value;
            SetDirty("Preferredsupplieragbid_Z");
         }

      }

      public void gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z_SetNull( )
      {
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z = Guid.Empty;
         SetDirty("Preferredsupplieragbid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z_IsNull( )
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
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid = Guid.Empty;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid = Guid.Empty;
         gxTv_SdtTrn_PreferredAgbSupplier_Mode = "";
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z = Guid.Empty;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z = Guid.Empty;
         gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_preferredagbsupplier", "GeneXus.Programs.trn_preferredagbsupplier_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_PreferredAgbSupplier_Initialized ;
      private string gxTv_SdtTrn_PreferredAgbSupplier_Mode ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredagbsupplierid_Z ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredagborganisationid_Z ;
      private Guid gxTv_SdtTrn_PreferredAgbSupplier_Preferredsupplieragbid_Z ;
   }

   [DataContract(Name = @"Trn_PreferredAgbSupplier", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_PreferredAgbSupplier_RESTInterface : GxGenericCollectionItem<SdtTrn_PreferredAgbSupplier>
   {
      public SdtTrn_PreferredAgbSupplier_RESTInterface( ) : base()
      {
      }

      public SdtTrn_PreferredAgbSupplier_RESTInterface( SdtTrn_PreferredAgbSupplier psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PreferredAgbSupplierId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredagbsupplierid
      {
         get {
            return sdt.gxTpr_Preferredagbsupplierid ;
         }

         set {
            sdt.gxTpr_Preferredagbsupplierid = value;
         }

      }

      [DataMember( Name = "PreferredAgbOrganisationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredagborganisationid
      {
         get {
            return sdt.gxTpr_Preferredagborganisationid ;
         }

         set {
            sdt.gxTpr_Preferredagborganisationid = value;
         }

      }

      [DataMember( Name = "PreferredSupplierAgbId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Preferredsupplieragbid
      {
         get {
            return sdt.gxTpr_Preferredsupplieragbid ;
         }

         set {
            sdt.gxTpr_Preferredsupplieragbid = value;
         }

      }

      public SdtTrn_PreferredAgbSupplier sdt
      {
         get {
            return (SdtTrn_PreferredAgbSupplier)Sdt ;
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
            sdt = new SdtTrn_PreferredAgbSupplier() ;
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

   [DataContract(Name = @"Trn_PreferredAgbSupplier", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_PreferredAgbSupplier_RESTLInterface : GxGenericCollectionItem<SdtTrn_PreferredAgbSupplier>
   {
      public SdtTrn_PreferredAgbSupplier_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_PreferredAgbSupplier_RESTLInterface( SdtTrn_PreferredAgbSupplier psdt ) : base(psdt)
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

      public SdtTrn_PreferredAgbSupplier sdt
      {
         get {
            return (SdtTrn_PreferredAgbSupplier)Sdt ;
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
            sdt = new SdtTrn_PreferredAgbSupplier() ;
         }
      }

   }

}
