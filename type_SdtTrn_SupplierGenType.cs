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
   [XmlRoot(ElementName = "Trn_SupplierGenType" )]
   [XmlType(TypeName =  "Trn_SupplierGenType" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_SupplierGenType : GxSilentTrnSdt
   {
      public SdtTrn_SupplierGenType( )
      {
      }

      public SdtTrn_SupplierGenType( IGxContext context )
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

      public void Load( Guid AV253SupplierGenTypeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV253SupplierGenTypeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierGenTypeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_SupplierGenType");
         metadata.Set("BT", "Trn_SupplierGenType");
         metadata.Set("PK", "[ \"SupplierGenTypeId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierGenTypeId\" ]");
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
         state.Add("gxTpr_Suppliergentypeid_Z");
         state.Add("gxTpr_Suppliergentypename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_SupplierGenType sdt;
         sdt = (SdtTrn_SupplierGenType)(source);
         gxTv_SdtTrn_SupplierGenType_Suppliergentypeid = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypeid ;
         gxTv_SdtTrn_SupplierGenType_Suppliergentypename = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypename ;
         gxTv_SdtTrn_SupplierGenType_Mode = sdt.gxTv_SdtTrn_SupplierGenType_Mode ;
         gxTv_SdtTrn_SupplierGenType_Initialized = sdt.gxTv_SdtTrn_SupplierGenType_Initialized ;
         gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z ;
         gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z ;
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
         AddObjectProperty("SupplierGenTypeId", gxTv_SdtTrn_SupplierGenType_Suppliergentypeid, false, includeNonInitialized);
         AddObjectProperty("SupplierGenTypeName", gxTv_SdtTrn_SupplierGenType_Suppliergentypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_SupplierGenType_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_SupplierGenType_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierGenTypeId_Z", gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenTypeName_Z", gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_SupplierGenType sdt )
      {
         if ( sdt.IsDirty("SupplierGenTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Suppliergentypeid = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypeid ;
         }
         if ( sdt.IsDirty("SupplierGenTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Suppliergentypename = sdt.gxTv_SdtTrn_SupplierGenType_Suppliergentypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierGenTypeId" )]
      [  XmlElement( ElementName = "SupplierGenTypeId"   )]
      public Guid gxTpr_Suppliergentypeid
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Suppliergentypeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierGenType_Suppliergentypeid != value )
            {
               gxTv_SdtTrn_SupplierGenType_Mode = "INS";
               this.gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierGenType_Suppliergentypeid = value;
            SetDirty("Suppliergentypeid");
         }

      }

      [  SoapElement( ElementName = "SupplierGenTypeName" )]
      [  XmlElement( ElementName = "SupplierGenTypeName"   )]
      public string gxTpr_Suppliergentypename
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Suppliergentypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Suppliergentypename = value;
            SetDirty("Suppliergentypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_SupplierGenType_Mode_SetNull( )
      {
         gxTv_SdtTrn_SupplierGenType_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGenType_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_SupplierGenType_Initialized_SetNull( )
      {
         gxTv_SdtTrn_SupplierGenType_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGenType_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenTypeId_Z" )]
      [  XmlElement( ElementName = "SupplierGenTypeId_Z"   )]
      public Guid gxTpr_Suppliergentypeid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z = value;
            SetDirty("Suppliergentypeid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z = Guid.Empty;
         SetDirty("Suppliergentypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenTypeName_Z" )]
      [  XmlElement( ElementName = "SupplierGenTypeName_Z"   )]
      public string gxTpr_Suppliergentypename_Z
      {
         get {
            return gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z = value;
            SetDirty("Suppliergentypename_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z = "";
         SetDirty("Suppliergentypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z_IsNull( )
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
         gxTv_SdtTrn_SupplierGenType_Suppliergentypeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_SupplierGenType_Suppliergentypename = "";
         gxTv_SdtTrn_SupplierGenType_Mode = "";
         gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_suppliergentype", "GeneXus.Programs.trn_suppliergentype_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_SupplierGenType_Initialized ;
      private string gxTv_SdtTrn_SupplierGenType_Mode ;
      private string gxTv_SdtTrn_SupplierGenType_Suppliergentypename ;
      private string gxTv_SdtTrn_SupplierGenType_Suppliergentypename_Z ;
      private Guid gxTv_SdtTrn_SupplierGenType_Suppliergentypeid ;
      private Guid gxTv_SdtTrn_SupplierGenType_Suppliergentypeid_Z ;
   }

   [DataContract(Name = @"Trn_SupplierGenType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierGenType_RESTInterface : GxGenericCollectionItem<SdtTrn_SupplierGenType>
   {
      public SdtTrn_SupplierGenType_RESTInterface( ) : base()
      {
      }

      public SdtTrn_SupplierGenType_RESTInterface( SdtTrn_SupplierGenType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierGenTypeId" , Order = 0 )]
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

      [DataMember( Name = "SupplierGenTypeName" , Order = 1 )]
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

      public SdtTrn_SupplierGenType sdt
      {
         get {
            return (SdtTrn_SupplierGenType)Sdt ;
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
            sdt = new SdtTrn_SupplierGenType() ;
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

   [DataContract(Name = @"Trn_SupplierGenType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierGenType_RESTLInterface : GxGenericCollectionItem<SdtTrn_SupplierGenType>
   {
      public SdtTrn_SupplierGenType_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_SupplierGenType_RESTLInterface( SdtTrn_SupplierGenType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierGenTypeName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_SupplierGenType sdt
      {
         get {
            return (SdtTrn_SupplierGenType)Sdt ;
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
            sdt = new SdtTrn_SupplierGenType() ;
         }
      }

   }

}
