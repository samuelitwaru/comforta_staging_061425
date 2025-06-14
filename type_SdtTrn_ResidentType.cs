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
   [XmlRoot(ElementName = "Trn_ResidentType" )]
   [XmlType(TypeName =  "Trn_ResidentType" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_ResidentType : GxSilentTrnSdt
   {
      public SdtTrn_ResidentType( )
      {
      }

      public SdtTrn_ResidentType( IGxContext context )
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

      public void Load( Guid AV96ResidentTypeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV96ResidentTypeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ResidentTypeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_ResidentType");
         metadata.Set("BT", "Trn_ResidentType");
         metadata.Set("PK", "[ \"ResidentTypeId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentTypeId\" ]");
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
         state.Add("gxTpr_Residenttypeid_Z");
         state.Add("gxTpr_Residenttypename_Z");
         state.Add("gxTpr_Residenttypeid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_ResidentType sdt;
         sdt = (SdtTrn_ResidentType)(source);
         gxTv_SdtTrn_ResidentType_Residenttypeid = sdt.gxTv_SdtTrn_ResidentType_Residenttypeid ;
         gxTv_SdtTrn_ResidentType_Residenttypename = sdt.gxTv_SdtTrn_ResidentType_Residenttypename ;
         gxTv_SdtTrn_ResidentType_Mode = sdt.gxTv_SdtTrn_ResidentType_Mode ;
         gxTv_SdtTrn_ResidentType_Initialized = sdt.gxTv_SdtTrn_ResidentType_Initialized ;
         gxTv_SdtTrn_ResidentType_Residenttypeid_Z = sdt.gxTv_SdtTrn_ResidentType_Residenttypeid_Z ;
         gxTv_SdtTrn_ResidentType_Residenttypename_Z = sdt.gxTv_SdtTrn_ResidentType_Residenttypename_Z ;
         gxTv_SdtTrn_ResidentType_Residenttypeid_N = sdt.gxTv_SdtTrn_ResidentType_Residenttypeid_N ;
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
         AddObjectProperty("ResidentTypeId", gxTv_SdtTrn_ResidentType_Residenttypeid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_ResidentType_Residenttypeid_N, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeName", gxTv_SdtTrn_ResidentType_Residenttypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_ResidentType_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_ResidentType_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_Z", gxTv_SdtTrn_ResidentType_Residenttypeid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeName_Z", gxTv_SdtTrn_ResidentType_Residenttypename_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_N", gxTv_SdtTrn_ResidentType_Residenttypeid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_ResidentType sdt )
      {
         if ( sdt.IsDirty("ResidentTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypeid = sdt.gxTv_SdtTrn_ResidentType_Residenttypeid ;
         }
         if ( sdt.IsDirty("ResidentTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypename = sdt.gxTv_SdtTrn_ResidentType_Residenttypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentTypeId" )]
      [  XmlElement( ElementName = "ResidentTypeId"   )]
      public Guid gxTpr_Residenttypeid
      {
         get {
            return gxTv_SdtTrn_ResidentType_Residenttypeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ResidentType_Residenttypeid != value )
            {
               gxTv_SdtTrn_ResidentType_Mode = "INS";
               this.gxTv_SdtTrn_ResidentType_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtTrn_ResidentType_Residenttypename_Z_SetNull( );
            }
            gxTv_SdtTrn_ResidentType_Residenttypeid = value;
            SetDirty("Residenttypeid");
         }

      }

      [  SoapElement( ElementName = "ResidentTypeName" )]
      [  XmlElement( ElementName = "ResidentTypeName"   )]
      public string gxTpr_Residenttypename
      {
         get {
            return gxTv_SdtTrn_ResidentType_Residenttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypename = value;
            SetDirty("Residenttypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_ResidentType_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_ResidentType_Mode_SetNull( )
      {
         gxTv_SdtTrn_ResidentType_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentType_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_ResidentType_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_ResidentType_Initialized_SetNull( )
      {
         gxTv_SdtTrn_ResidentType_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentType_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_Z" )]
      [  XmlElement( ElementName = "ResidentTypeId_Z"   )]
      public Guid gxTpr_Residenttypeid_Z
      {
         get {
            return gxTv_SdtTrn_ResidentType_Residenttypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypeid_Z = value;
            SetDirty("Residenttypeid_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentType_Residenttypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentType_Residenttypeid_Z = Guid.Empty;
         SetDirty("Residenttypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentType_Residenttypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeName_Z" )]
      [  XmlElement( ElementName = "ResidentTypeName_Z"   )]
      public string gxTpr_Residenttypename_Z
      {
         get {
            return gxTv_SdtTrn_ResidentType_Residenttypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypename_Z = value;
            SetDirty("Residenttypename_Z");
         }

      }

      public void gxTv_SdtTrn_ResidentType_Residenttypename_Z_SetNull( )
      {
         gxTv_SdtTrn_ResidentType_Residenttypename_Z = "";
         SetDirty("Residenttypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentType_Residenttypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_N" )]
      [  XmlElement( ElementName = "ResidentTypeId_N"   )]
      public short gxTpr_Residenttypeid_N
      {
         get {
            return gxTv_SdtTrn_ResidentType_Residenttypeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ResidentType_Residenttypeid_N = value;
            SetDirty("Residenttypeid_N");
         }

      }

      public void gxTv_SdtTrn_ResidentType_Residenttypeid_N_SetNull( )
      {
         gxTv_SdtTrn_ResidentType_Residenttypeid_N = 0;
         SetDirty("Residenttypeid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_ResidentType_Residenttypeid_N_IsNull( )
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
         gxTv_SdtTrn_ResidentType_Residenttypeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_ResidentType_Residenttypename = "";
         gxTv_SdtTrn_ResidentType_Mode = "";
         gxTv_SdtTrn_ResidentType_Residenttypeid_Z = Guid.Empty;
         gxTv_SdtTrn_ResidentType_Residenttypename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_residenttype", "GeneXus.Programs.trn_residenttype_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_ResidentType_Initialized ;
      private short gxTv_SdtTrn_ResidentType_Residenttypeid_N ;
      private string gxTv_SdtTrn_ResidentType_Mode ;
      private string gxTv_SdtTrn_ResidentType_Residenttypename ;
      private string gxTv_SdtTrn_ResidentType_Residenttypename_Z ;
      private Guid gxTv_SdtTrn_ResidentType_Residenttypeid ;
      private Guid gxTv_SdtTrn_ResidentType_Residenttypeid_Z ;
   }

   [DataContract(Name = @"Trn_ResidentType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentType_RESTInterface : GxGenericCollectionItem<SdtTrn_ResidentType>
   {
      public SdtTrn_ResidentType_RESTInterface( ) : base()
      {
      }

      public SdtTrn_ResidentType_RESTInterface( SdtTrn_ResidentType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentTypeId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Residenttypeid
      {
         get {
            return sdt.gxTpr_Residenttypeid ;
         }

         set {
            sdt.gxTpr_Residenttypeid = value;
         }

      }

      [DataMember( Name = "ResidentTypeName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Residenttypename
      {
         get {
            return sdt.gxTpr_Residenttypename ;
         }

         set {
            sdt.gxTpr_Residenttypename = value;
         }

      }

      public SdtTrn_ResidentType sdt
      {
         get {
            return (SdtTrn_ResidentType)Sdt ;
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
            sdt = new SdtTrn_ResidentType() ;
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

   [DataContract(Name = @"Trn_ResidentType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ResidentType_RESTLInterface : GxGenericCollectionItem<SdtTrn_ResidentType>
   {
      public SdtTrn_ResidentType_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_ResidentType_RESTLInterface( SdtTrn_ResidentType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentTypeName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Residenttypename
      {
         get {
            return sdt.gxTpr_Residenttypename ;
         }

         set {
            sdt.gxTpr_Residenttypename = value;
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

      public SdtTrn_ResidentType sdt
      {
         get {
            return (SdtTrn_ResidentType)Sdt ;
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
            sdt = new SdtTrn_ResidentType() ;
         }
      }

   }

}
