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
   [XmlRoot(ElementName = "Trn_Device" )]
   [XmlType(TypeName =  "Trn_Device" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Device : GxSilentTrnSdt
   {
      public SdtTrn_Device( )
      {
      }

      public SdtTrn_Device( IGxContext context )
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

      public void Load( string AV333DeviceId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV333DeviceId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DeviceId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Device");
         metadata.Set("BT", "Trn_Device");
         metadata.Set("PK", "[ \"DeviceId\" ]");
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
         state.Add("gxTpr_Deviceid_Z");
         state.Add("gxTpr_Devicetype_Z");
         state.Add("gxTpr_Devicetoken_Z");
         state.Add("gxTpr_Devicename_Z");
         state.Add("gxTpr_Deviceuserid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Device sdt;
         sdt = (SdtTrn_Device)(source);
         gxTv_SdtTrn_Device_Deviceid = sdt.gxTv_SdtTrn_Device_Deviceid ;
         gxTv_SdtTrn_Device_Devicetype = sdt.gxTv_SdtTrn_Device_Devicetype ;
         gxTv_SdtTrn_Device_Devicetoken = sdt.gxTv_SdtTrn_Device_Devicetoken ;
         gxTv_SdtTrn_Device_Devicename = sdt.gxTv_SdtTrn_Device_Devicename ;
         gxTv_SdtTrn_Device_Deviceuserid = sdt.gxTv_SdtTrn_Device_Deviceuserid ;
         gxTv_SdtTrn_Device_Mode = sdt.gxTv_SdtTrn_Device_Mode ;
         gxTv_SdtTrn_Device_Initialized = sdt.gxTv_SdtTrn_Device_Initialized ;
         gxTv_SdtTrn_Device_Deviceid_Z = sdt.gxTv_SdtTrn_Device_Deviceid_Z ;
         gxTv_SdtTrn_Device_Devicetype_Z = sdt.gxTv_SdtTrn_Device_Devicetype_Z ;
         gxTv_SdtTrn_Device_Devicetoken_Z = sdt.gxTv_SdtTrn_Device_Devicetoken_Z ;
         gxTv_SdtTrn_Device_Devicename_Z = sdt.gxTv_SdtTrn_Device_Devicename_Z ;
         gxTv_SdtTrn_Device_Deviceuserid_Z = sdt.gxTv_SdtTrn_Device_Deviceuserid_Z ;
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
         AddObjectProperty("DeviceId", gxTv_SdtTrn_Device_Deviceid, false, includeNonInitialized);
         AddObjectProperty("DeviceType", gxTv_SdtTrn_Device_Devicetype, false, includeNonInitialized);
         AddObjectProperty("DeviceToken", gxTv_SdtTrn_Device_Devicetoken, false, includeNonInitialized);
         AddObjectProperty("DeviceName", gxTv_SdtTrn_Device_Devicename, false, includeNonInitialized);
         AddObjectProperty("DeviceUserId", gxTv_SdtTrn_Device_Deviceuserid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Device_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Device_Initialized, false, includeNonInitialized);
            AddObjectProperty("DeviceId_Z", gxTv_SdtTrn_Device_Deviceid_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceType_Z", gxTv_SdtTrn_Device_Devicetype_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceToken_Z", gxTv_SdtTrn_Device_Devicetoken_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceName_Z", gxTv_SdtTrn_Device_Devicename_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceUserId_Z", gxTv_SdtTrn_Device_Deviceuserid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Device sdt )
      {
         if ( sdt.IsDirty("DeviceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Deviceid = sdt.gxTv_SdtTrn_Device_Deviceid ;
         }
         if ( sdt.IsDirty("DeviceType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetype = sdt.gxTv_SdtTrn_Device_Devicetype ;
         }
         if ( sdt.IsDirty("DeviceToken") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetoken = sdt.gxTv_SdtTrn_Device_Devicetoken ;
         }
         if ( sdt.IsDirty("DeviceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicename = sdt.gxTv_SdtTrn_Device_Devicename ;
         }
         if ( sdt.IsDirty("DeviceUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Deviceuserid = sdt.gxTv_SdtTrn_Device_Deviceuserid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DeviceId" )]
      [  XmlElement( ElementName = "DeviceId"   )]
      public string gxTpr_Deviceid
      {
         get {
            return gxTv_SdtTrn_Device_Deviceid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtTrn_Device_Deviceid, value) != 0 )
            {
               gxTv_SdtTrn_Device_Mode = "INS";
               this.gxTv_SdtTrn_Device_Deviceid_Z_SetNull( );
               this.gxTv_SdtTrn_Device_Devicetype_Z_SetNull( );
               this.gxTv_SdtTrn_Device_Devicetoken_Z_SetNull( );
               this.gxTv_SdtTrn_Device_Devicename_Z_SetNull( );
               this.gxTv_SdtTrn_Device_Deviceuserid_Z_SetNull( );
            }
            gxTv_SdtTrn_Device_Deviceid = value;
            SetDirty("Deviceid");
         }

      }

      [  SoapElement( ElementName = "DeviceType" )]
      [  XmlElement( ElementName = "DeviceType"   )]
      public short gxTpr_Devicetype
      {
         get {
            return gxTv_SdtTrn_Device_Devicetype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetype = value;
            SetDirty("Devicetype");
         }

      }

      [  SoapElement( ElementName = "DeviceToken" )]
      [  XmlElement( ElementName = "DeviceToken"   )]
      public string gxTpr_Devicetoken
      {
         get {
            return gxTv_SdtTrn_Device_Devicetoken ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetoken = value;
            SetDirty("Devicetoken");
         }

      }

      [  SoapElement( ElementName = "DeviceName" )]
      [  XmlElement( ElementName = "DeviceName"   )]
      public string gxTpr_Devicename
      {
         get {
            return gxTv_SdtTrn_Device_Devicename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicename = value;
            SetDirty("Devicename");
         }

      }

      [  SoapElement( ElementName = "DeviceUserId" )]
      [  XmlElement( ElementName = "DeviceUserId"   )]
      public string gxTpr_Deviceuserid
      {
         get {
            return gxTv_SdtTrn_Device_Deviceuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Deviceuserid = value;
            SetDirty("Deviceuserid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Device_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Device_Mode_SetNull( )
      {
         gxTv_SdtTrn_Device_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Device_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Device_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Device_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceId_Z" )]
      [  XmlElement( ElementName = "DeviceId_Z"   )]
      public string gxTpr_Deviceid_Z
      {
         get {
            return gxTv_SdtTrn_Device_Deviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Deviceid_Z = value;
            SetDirty("Deviceid_Z");
         }

      }

      public void gxTv_SdtTrn_Device_Deviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_Device_Deviceid_Z = "";
         SetDirty("Deviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Deviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceType_Z" )]
      [  XmlElement( ElementName = "DeviceType_Z"   )]
      public short gxTpr_Devicetype_Z
      {
         get {
            return gxTv_SdtTrn_Device_Devicetype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetype_Z = value;
            SetDirty("Devicetype_Z");
         }

      }

      public void gxTv_SdtTrn_Device_Devicetype_Z_SetNull( )
      {
         gxTv_SdtTrn_Device_Devicetype_Z = 0;
         SetDirty("Devicetype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Devicetype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceToken_Z" )]
      [  XmlElement( ElementName = "DeviceToken_Z"   )]
      public string gxTpr_Devicetoken_Z
      {
         get {
            return gxTv_SdtTrn_Device_Devicetoken_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicetoken_Z = value;
            SetDirty("Devicetoken_Z");
         }

      }

      public void gxTv_SdtTrn_Device_Devicetoken_Z_SetNull( )
      {
         gxTv_SdtTrn_Device_Devicetoken_Z = "";
         SetDirty("Devicetoken_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Devicetoken_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceName_Z" )]
      [  XmlElement( ElementName = "DeviceName_Z"   )]
      public string gxTpr_Devicename_Z
      {
         get {
            return gxTv_SdtTrn_Device_Devicename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Devicename_Z = value;
            SetDirty("Devicename_Z");
         }

      }

      public void gxTv_SdtTrn_Device_Devicename_Z_SetNull( )
      {
         gxTv_SdtTrn_Device_Devicename_Z = "";
         SetDirty("Devicename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Devicename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceUserId_Z" )]
      [  XmlElement( ElementName = "DeviceUserId_Z"   )]
      public string gxTpr_Deviceuserid_Z
      {
         get {
            return gxTv_SdtTrn_Device_Deviceuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Device_Deviceuserid_Z = value;
            SetDirty("Deviceuserid_Z");
         }

      }

      public void gxTv_SdtTrn_Device_Deviceuserid_Z_SetNull( )
      {
         gxTv_SdtTrn_Device_Deviceuserid_Z = "";
         SetDirty("Deviceuserid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Device_Deviceuserid_Z_IsNull( )
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
         gxTv_SdtTrn_Device_Deviceid = "";
         sdtIsNull = 1;
         gxTv_SdtTrn_Device_Devicetoken = "";
         gxTv_SdtTrn_Device_Devicename = "";
         gxTv_SdtTrn_Device_Deviceuserid = "";
         gxTv_SdtTrn_Device_Mode = "";
         gxTv_SdtTrn_Device_Deviceid_Z = "";
         gxTv_SdtTrn_Device_Devicetoken_Z = "";
         gxTv_SdtTrn_Device_Devicename_Z = "";
         gxTv_SdtTrn_Device_Deviceuserid_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_device", "GeneXus.Programs.trn_device_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Device_Devicetype ;
      private short gxTv_SdtTrn_Device_Initialized ;
      private short gxTv_SdtTrn_Device_Devicetype_Z ;
      private string gxTv_SdtTrn_Device_Deviceid ;
      private string gxTv_SdtTrn_Device_Devicetoken ;
      private string gxTv_SdtTrn_Device_Devicename ;
      private string gxTv_SdtTrn_Device_Mode ;
      private string gxTv_SdtTrn_Device_Deviceid_Z ;
      private string gxTv_SdtTrn_Device_Devicetoken_Z ;
      private string gxTv_SdtTrn_Device_Devicename_Z ;
      private string gxTv_SdtTrn_Device_Deviceuserid ;
      private string gxTv_SdtTrn_Device_Deviceuserid_Z ;
   }

   [DataContract(Name = @"Trn_Device", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Device_RESTInterface : GxGenericCollectionItem<SdtTrn_Device>
   {
      public SdtTrn_Device_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Device_RESTInterface( SdtTrn_Device psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DeviceId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Deviceid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Deviceid) ;
         }

         set {
            sdt.gxTpr_Deviceid = value;
         }

      }

      [DataMember( Name = "DeviceType" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Devicetype
      {
         get {
            return sdt.gxTpr_Devicetype ;
         }

         set {
            sdt.gxTpr_Devicetype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "DeviceToken" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Devicetoken
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Devicetoken) ;
         }

         set {
            sdt.gxTpr_Devicetoken = value;
         }

      }

      [DataMember( Name = "DeviceName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Devicename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Devicename) ;
         }

         set {
            sdt.gxTpr_Devicename = value;
         }

      }

      [DataMember( Name = "DeviceUserId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Deviceuserid
      {
         get {
            return sdt.gxTpr_Deviceuserid ;
         }

         set {
            sdt.gxTpr_Deviceuserid = value;
         }

      }

      public SdtTrn_Device sdt
      {
         get {
            return (SdtTrn_Device)Sdt ;
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
            sdt = new SdtTrn_Device() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Trn_Device", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Device_RESTLInterface : GxGenericCollectionItem<SdtTrn_Device>
   {
      public SdtTrn_Device_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Device_RESTLInterface( SdtTrn_Device psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DeviceType" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Devicetype
      {
         get {
            return sdt.gxTpr_Devicetype ;
         }

         set {
            sdt.gxTpr_Devicetype = (short)(value.HasValue ? value.Value : 0);
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

      public SdtTrn_Device sdt
      {
         get {
            return (SdtTrn_Device)Sdt ;
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
            sdt = new SdtTrn_Device() ;
         }
      }

   }

}
