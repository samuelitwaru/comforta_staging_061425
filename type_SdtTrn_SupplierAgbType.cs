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
   [XmlRoot(ElementName = "Trn_SupplierAgbType" )]
   [XmlType(TypeName =  "Trn_SupplierAgbType" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_SupplierAgbType : GxSilentTrnSdt
   {
      public SdtTrn_SupplierAgbType( )
      {
      }

      public SdtTrn_SupplierAgbType( IGxContext context )
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

      public void Load( Guid AV255SupplierAgbTypeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV255SupplierAgbTypeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierAgbTypeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_SupplierAgbType");
         metadata.Set("BT", "Trn_SupplierAgbType");
         metadata.Set("PK", "[ \"SupplierAgbTypeId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierAgbTypeId\" ]");
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
         state.Add("gxTpr_Supplieragbtypeid_Z");
         state.Add("gxTpr_Supplieragbtypename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_SupplierAgbType sdt;
         sdt = (SdtTrn_SupplierAgbType)(source);
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid ;
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename ;
         gxTv_SdtTrn_SupplierAgbType_Mode = sdt.gxTv_SdtTrn_SupplierAgbType_Mode ;
         gxTv_SdtTrn_SupplierAgbType_Initialized = sdt.gxTv_SdtTrn_SupplierAgbType_Initialized ;
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z ;
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z ;
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
         AddObjectProperty("SupplierAgbTypeId", gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid, false, includeNonInitialized);
         AddObjectProperty("SupplierAgbTypeName", gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_SupplierAgbType_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_SupplierAgbType_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbTypeId_Z", gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierAgbTypeName_Z", gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_SupplierAgbType sdt )
      {
         if ( sdt.IsDirty("SupplierAgbTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid ;
         }
         if ( sdt.IsDirty("SupplierAgbTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename = sdt.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierAgbTypeId" )]
      [  XmlElement( ElementName = "SupplierAgbTypeId"   )]
      public Guid gxTpr_Supplieragbtypeid
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid != value )
            {
               gxTv_SdtTrn_SupplierAgbType_Mode = "INS";
               this.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid = value;
            SetDirty("Supplieragbtypeid");
         }

      }

      [  SoapElement( ElementName = "SupplierAgbTypeName" )]
      [  XmlElement( ElementName = "SupplierAgbTypeName"   )]
      public string gxTpr_Supplieragbtypename
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename = value;
            SetDirty("Supplieragbtypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_SupplierAgbType_Mode_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgbType_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgbType_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_SupplierAgbType_Initialized_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgbType_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgbType_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbTypeId_Z" )]
      [  XmlElement( ElementName = "SupplierAgbTypeId_Z"   )]
      public Guid gxTpr_Supplieragbtypeid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z = value;
            SetDirty("Supplieragbtypeid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z = Guid.Empty;
         SetDirty("Supplieragbtypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierAgbTypeName_Z" )]
      [  XmlElement( ElementName = "SupplierAgbTypeName_Z"   )]
      public string gxTpr_Supplieragbtypename_Z
      {
         get {
            return gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z = value;
            SetDirty("Supplieragbtypename_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z = "";
         SetDirty("Supplieragbtypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z_IsNull( )
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
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename = "";
         gxTv_SdtTrn_SupplierAgbType_Mode = "";
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_supplieragbtype", "GeneXus.Programs.trn_supplieragbtype_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_SupplierAgbType_Initialized ;
      private string gxTv_SdtTrn_SupplierAgbType_Mode ;
      private string gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename ;
      private string gxTv_SdtTrn_SupplierAgbType_Supplieragbtypename_Z ;
      private Guid gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid ;
      private Guid gxTv_SdtTrn_SupplierAgbType_Supplieragbtypeid_Z ;
   }

   [DataContract(Name = @"Trn_SupplierAgbType", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierAgbType_RESTInterface : GxGenericCollectionItem<SdtTrn_SupplierAgbType>
   {
      public SdtTrn_SupplierAgbType_RESTInterface( ) : base()
      {
      }

      public SdtTrn_SupplierAgbType_RESTInterface( SdtTrn_SupplierAgbType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierAgbTypeId" , Order = 0 )]
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

      [DataMember( Name = "SupplierAgbTypeName" , Order = 1 )]
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

      public SdtTrn_SupplierAgbType sdt
      {
         get {
            return (SdtTrn_SupplierAgbType)Sdt ;
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
            sdt = new SdtTrn_SupplierAgbType() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"Trn_SupplierAgbType", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierAgbType_RESTLInterface : GxGenericCollectionItem<SdtTrn_SupplierAgbType>
   {
      public SdtTrn_SupplierAgbType_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_SupplierAgbType_RESTLInterface( SdtTrn_SupplierAgbType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierAgbTypeName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_SupplierAgbType sdt
      {
         get {
            return (SdtTrn_SupplierAgbType)Sdt ;
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
            sdt = new SdtTrn_SupplierAgbType() ;
         }
      }

   }

}
