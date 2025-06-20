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
   [XmlRoot(ElementName = "Trn_EnvironmentVariable" )]
   [XmlType(TypeName =  "Trn_EnvironmentVariable" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_EnvironmentVariable : GxSilentTrnSdt
   {
      public SdtTrn_EnvironmentVariable( )
      {
      }

      public SdtTrn_EnvironmentVariable( IGxContext context )
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

      public void Load( Guid AV632EnvironmentVariableId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV632EnvironmentVariableId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EnvironmentVariableId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_EnvironmentVariable");
         metadata.Set("BT", "Trn_EnvironmentVariable");
         metadata.Set("PK", "[ \"EnvironmentVariableId\" ]");
         metadata.Set("PKAssigned", "[ \"EnvironmentVariableId\" ]");
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
         state.Add("gxTpr_Environmentvariableid_Z");
         state.Add("gxTpr_Environmentvariablekey_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_EnvironmentVariable sdt;
         sdt = (SdtTrn_EnvironmentVariable)(source);
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid ;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey ;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue ;
         gxTv_SdtTrn_EnvironmentVariable_Mode = sdt.gxTv_SdtTrn_EnvironmentVariable_Mode ;
         gxTv_SdtTrn_EnvironmentVariable_Initialized = sdt.gxTv_SdtTrn_EnvironmentVariable_Initialized ;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z ;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z ;
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
         AddObjectProperty("EnvironmentVariableId", gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid, false, includeNonInitialized);
         AddObjectProperty("EnvironmentVariableKey", gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey, false, includeNonInitialized);
         AddObjectProperty("EnvironmentVariableValue", gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_EnvironmentVariable_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_EnvironmentVariable_Initialized, false, includeNonInitialized);
            AddObjectProperty("EnvironmentVariableId_Z", gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z, false, includeNonInitialized);
            AddObjectProperty("EnvironmentVariableKey_Z", gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_EnvironmentVariable sdt )
      {
         if ( sdt.IsDirty("EnvironmentVariableId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid ;
         }
         if ( sdt.IsDirty("EnvironmentVariableKey") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey ;
         }
         if ( sdt.IsDirty("EnvironmentVariableValue") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue = sdt.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EnvironmentVariableId" )]
      [  XmlElement( ElementName = "EnvironmentVariableId"   )]
      public Guid gxTpr_Environmentvariableid
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid != value )
            {
               gxTv_SdtTrn_EnvironmentVariable_Mode = "INS";
               this.gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z_SetNull( );
               this.gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z_SetNull( );
            }
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid = value;
            SetDirty("Environmentvariableid");
         }

      }

      [  SoapElement( ElementName = "EnvironmentVariableKey" )]
      [  XmlElement( ElementName = "EnvironmentVariableKey"   )]
      public string gxTpr_Environmentvariablekey
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey = value;
            SetDirty("Environmentvariablekey");
         }

      }

      [  SoapElement( ElementName = "EnvironmentVariableValue" )]
      [  XmlElement( ElementName = "EnvironmentVariableValue"   )]
      public string gxTpr_Environmentvariablevalue
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue = value;
            SetDirty("Environmentvariablevalue");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_EnvironmentVariable_Mode_SetNull( )
      {
         gxTv_SdtTrn_EnvironmentVariable_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_EnvironmentVariable_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_EnvironmentVariable_Initialized_SetNull( )
      {
         gxTv_SdtTrn_EnvironmentVariable_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_EnvironmentVariable_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvironmentVariableId_Z" )]
      [  XmlElement( ElementName = "EnvironmentVariableId_Z"   )]
      public Guid gxTpr_Environmentvariableid_Z
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z = value;
            SetDirty("Environmentvariableid_Z");
         }

      }

      public void gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z_SetNull( )
      {
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z = Guid.Empty;
         SetDirty("Environmentvariableid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvironmentVariableKey_Z" )]
      [  XmlElement( ElementName = "EnvironmentVariableKey_Z"   )]
      public string gxTpr_Environmentvariablekey_Z
      {
         get {
            return gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z = value;
            SetDirty("Environmentvariablekey_Z");
         }

      }

      public void gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z_SetNull( )
      {
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z = "";
         SetDirty("Environmentvariablekey_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z_IsNull( )
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
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey = "";
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue = "";
         gxTv_SdtTrn_EnvironmentVariable_Mode = "";
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z = Guid.Empty;
         gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_environmentvariable", "GeneXus.Programs.trn_environmentvariable_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_EnvironmentVariable_Initialized ;
      private string gxTv_SdtTrn_EnvironmentVariable_Mode ;
      private string gxTv_SdtTrn_EnvironmentVariable_Environmentvariablevalue ;
      private string gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey ;
      private string gxTv_SdtTrn_EnvironmentVariable_Environmentvariablekey_Z ;
      private Guid gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid ;
      private Guid gxTv_SdtTrn_EnvironmentVariable_Environmentvariableid_Z ;
   }

   [DataContract(Name = @"Trn_EnvironmentVariable", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_EnvironmentVariable_RESTInterface : GxGenericCollectionItem<SdtTrn_EnvironmentVariable>
   {
      public SdtTrn_EnvironmentVariable_RESTInterface( ) : base()
      {
      }

      public SdtTrn_EnvironmentVariable_RESTInterface( SdtTrn_EnvironmentVariable psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EnvironmentVariableId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Environmentvariableid
      {
         get {
            return sdt.gxTpr_Environmentvariableid ;
         }

         set {
            sdt.gxTpr_Environmentvariableid = value;
         }

      }

      [DataMember( Name = "EnvironmentVariableKey" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Environmentvariablekey
      {
         get {
            return sdt.gxTpr_Environmentvariablekey ;
         }

         set {
            sdt.gxTpr_Environmentvariablekey = value;
         }

      }

      [DataMember( Name = "EnvironmentVariableValue" , Order = 2 )]
      public string gxTpr_Environmentvariablevalue
      {
         get {
            return sdt.gxTpr_Environmentvariablevalue ;
         }

         set {
            sdt.gxTpr_Environmentvariablevalue = value;
         }

      }

      public SdtTrn_EnvironmentVariable sdt
      {
         get {
            return (SdtTrn_EnvironmentVariable)Sdt ;
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
            sdt = new SdtTrn_EnvironmentVariable() ;
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

   [DataContract(Name = @"Trn_EnvironmentVariable", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_EnvironmentVariable_RESTLInterface : GxGenericCollectionItem<SdtTrn_EnvironmentVariable>
   {
      public SdtTrn_EnvironmentVariable_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_EnvironmentVariable_RESTLInterface( SdtTrn_EnvironmentVariable psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EnvironmentVariableKey" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Environmentvariablekey
      {
         get {
            return sdt.gxTpr_Environmentvariablekey ;
         }

         set {
            sdt.gxTpr_Environmentvariablekey = value;
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

      public SdtTrn_EnvironmentVariable sdt
      {
         get {
            return (SdtTrn_EnvironmentVariable)Sdt ;
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
            sdt = new SdtTrn_EnvironmentVariable() ;
         }
      }

   }

}
