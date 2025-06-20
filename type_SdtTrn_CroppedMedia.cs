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
   [XmlRoot(ElementName = "Trn_CroppedMedia" )]
   [XmlType(TypeName =  "Trn_CroppedMedia" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_CroppedMedia : GxSilentTrnSdt
   {
      public SdtTrn_CroppedMedia( )
      {
      }

      public SdtTrn_CroppedMedia( IGxContext context )
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

      public void Load( Guid AV644CroppedMediaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV644CroppedMediaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CroppedMediaId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_CroppedMedia");
         metadata.Set("BT", "Trn_CroppedMedia");
         metadata.Set("PK", "[ \"CroppedMediaId\" ]");
         metadata.Set("PKAssigned", "[ \"CroppedMediaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MediaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Croppedmediaid_Z");
         state.Add("gxTpr_Mediaid_Z");
         state.Add("gxTpr_Croppedmedianame_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_CroppedMedia sdt;
         sdt = (SdtTrn_CroppedMedia)(source);
         gxTv_SdtTrn_CroppedMedia_Croppedmediaid = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmediaid ;
         gxTv_SdtTrn_CroppedMedia_Mediaid = sdt.gxTv_SdtTrn_CroppedMedia_Mediaid ;
         gxTv_SdtTrn_CroppedMedia_Croppedmedianame = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmedianame ;
         gxTv_SdtTrn_CroppedMedia_Mode = sdt.gxTv_SdtTrn_CroppedMedia_Mode ;
         gxTv_SdtTrn_CroppedMedia_Initialized = sdt.gxTv_SdtTrn_CroppedMedia_Initialized ;
         gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z ;
         gxTv_SdtTrn_CroppedMedia_Mediaid_Z = sdt.gxTv_SdtTrn_CroppedMedia_Mediaid_Z ;
         gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z ;
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
         AddObjectProperty("CroppedMediaId", gxTv_SdtTrn_CroppedMedia_Croppedmediaid, false, includeNonInitialized);
         AddObjectProperty("MediaId", gxTv_SdtTrn_CroppedMedia_Mediaid, false, includeNonInitialized);
         AddObjectProperty("CroppedMediaName", gxTv_SdtTrn_CroppedMedia_Croppedmedianame, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_CroppedMedia_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_CroppedMedia_Initialized, false, includeNonInitialized);
            AddObjectProperty("CroppedMediaId_Z", gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z, false, includeNonInitialized);
            AddObjectProperty("MediaId_Z", gxTv_SdtTrn_CroppedMedia_Mediaid_Z, false, includeNonInitialized);
            AddObjectProperty("CroppedMediaName_Z", gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_CroppedMedia sdt )
      {
         if ( sdt.IsDirty("CroppedMediaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Croppedmediaid = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmediaid ;
         }
         if ( sdt.IsDirty("MediaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Mediaid = sdt.gxTv_SdtTrn_CroppedMedia_Mediaid ;
         }
         if ( sdt.IsDirty("CroppedMediaName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Croppedmedianame = sdt.gxTv_SdtTrn_CroppedMedia_Croppedmedianame ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CroppedMediaId" )]
      [  XmlElement( ElementName = "CroppedMediaId"   )]
      public Guid gxTpr_Croppedmediaid
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Croppedmediaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_CroppedMedia_Croppedmediaid != value )
            {
               gxTv_SdtTrn_CroppedMedia_Mode = "INS";
               this.gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z_SetNull( );
               this.gxTv_SdtTrn_CroppedMedia_Mediaid_Z_SetNull( );
               this.gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z_SetNull( );
            }
            gxTv_SdtTrn_CroppedMedia_Croppedmediaid = value;
            SetDirty("Croppedmediaid");
         }

      }

      [  SoapElement( ElementName = "MediaId" )]
      [  XmlElement( ElementName = "MediaId"   )]
      public Guid gxTpr_Mediaid
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Mediaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Mediaid = value;
            SetDirty("Mediaid");
         }

      }

      [  SoapElement( ElementName = "CroppedMediaName" )]
      [  XmlElement( ElementName = "CroppedMediaName"   )]
      public string gxTpr_Croppedmedianame
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Croppedmedianame ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Croppedmedianame = value;
            SetDirty("Croppedmedianame");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_CroppedMedia_Mode_SetNull( )
      {
         gxTv_SdtTrn_CroppedMedia_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_CroppedMedia_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_CroppedMedia_Initialized_SetNull( )
      {
         gxTv_SdtTrn_CroppedMedia_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_CroppedMedia_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CroppedMediaId_Z" )]
      [  XmlElement( ElementName = "CroppedMediaId_Z"   )]
      public Guid gxTpr_Croppedmediaid_Z
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z = value;
            SetDirty("Croppedmediaid_Z");
         }

      }

      public void gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z_SetNull( )
      {
         gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z = Guid.Empty;
         SetDirty("Croppedmediaid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MediaId_Z" )]
      [  XmlElement( ElementName = "MediaId_Z"   )]
      public Guid gxTpr_Mediaid_Z
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Mediaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Mediaid_Z = value;
            SetDirty("Mediaid_Z");
         }

      }

      public void gxTv_SdtTrn_CroppedMedia_Mediaid_Z_SetNull( )
      {
         gxTv_SdtTrn_CroppedMedia_Mediaid_Z = Guid.Empty;
         SetDirty("Mediaid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CroppedMedia_Mediaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CroppedMediaName_Z" )]
      [  XmlElement( ElementName = "CroppedMediaName_Z"   )]
      public string gxTpr_Croppedmedianame_Z
      {
         get {
            return gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z = value;
            SetDirty("Croppedmedianame_Z");
         }

      }

      public void gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z_SetNull( )
      {
         gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z = "";
         SetDirty("Croppedmedianame_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z_IsNull( )
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
         gxTv_SdtTrn_CroppedMedia_Croppedmediaid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_CroppedMedia_Mediaid = Guid.Empty;
         gxTv_SdtTrn_CroppedMedia_Croppedmedianame = "";
         gxTv_SdtTrn_CroppedMedia_Mode = "";
         gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z = Guid.Empty;
         gxTv_SdtTrn_CroppedMedia_Mediaid_Z = Guid.Empty;
         gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_croppedmedia", "GeneXus.Programs.trn_croppedmedia_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_CroppedMedia_Initialized ;
      private string gxTv_SdtTrn_CroppedMedia_Mode ;
      private string gxTv_SdtTrn_CroppedMedia_Croppedmedianame ;
      private string gxTv_SdtTrn_CroppedMedia_Croppedmedianame_Z ;
      private Guid gxTv_SdtTrn_CroppedMedia_Croppedmediaid ;
      private Guid gxTv_SdtTrn_CroppedMedia_Mediaid ;
      private Guid gxTv_SdtTrn_CroppedMedia_Croppedmediaid_Z ;
      private Guid gxTv_SdtTrn_CroppedMedia_Mediaid_Z ;
   }

   [DataContract(Name = @"Trn_CroppedMedia", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_CroppedMedia_RESTInterface : GxGenericCollectionItem<SdtTrn_CroppedMedia>
   {
      public SdtTrn_CroppedMedia_RESTInterface( ) : base()
      {
      }

      public SdtTrn_CroppedMedia_RESTInterface( SdtTrn_CroppedMedia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CroppedMediaId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Croppedmediaid
      {
         get {
            return sdt.gxTpr_Croppedmediaid ;
         }

         set {
            sdt.gxTpr_Croppedmediaid = value;
         }

      }

      [DataMember( Name = "MediaId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Mediaid
      {
         get {
            return sdt.gxTpr_Mediaid ;
         }

         set {
            sdt.gxTpr_Mediaid = value;
         }

      }

      [DataMember( Name = "CroppedMediaName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Croppedmedianame
      {
         get {
            return sdt.gxTpr_Croppedmedianame ;
         }

         set {
            sdt.gxTpr_Croppedmedianame = value;
         }

      }

      public SdtTrn_CroppedMedia sdt
      {
         get {
            return (SdtTrn_CroppedMedia)Sdt ;
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
            sdt = new SdtTrn_CroppedMedia() ;
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

   [DataContract(Name = @"Trn_CroppedMedia", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_CroppedMedia_RESTLInterface : GxGenericCollectionItem<SdtTrn_CroppedMedia>
   {
      public SdtTrn_CroppedMedia_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_CroppedMedia_RESTLInterface( SdtTrn_CroppedMedia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CroppedMediaName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Croppedmedianame
      {
         get {
            return sdt.gxTpr_Croppedmedianame ;
         }

         set {
            sdt.gxTpr_Croppedmedianame = value;
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

      public SdtTrn_CroppedMedia sdt
      {
         get {
            return (SdtTrn_CroppedMedia)Sdt ;
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
            sdt = new SdtTrn_CroppedMedia() ;
         }
      }

   }

}
