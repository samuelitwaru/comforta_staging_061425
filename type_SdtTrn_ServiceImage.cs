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
   [XmlRoot(ElementName = "Trn_ServiceImage" )]
   [XmlType(TypeName =  "Trn_ServiceImage" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_ServiceImage : GxSilentTrnSdt
   {
      public SdtTrn_ServiceImage( )
      {
      }

      public SdtTrn_ServiceImage( IGxContext context )
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

      public void Load( Guid AV608ServiceImageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV608ServiceImageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ServiceImageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_ServiceImage");
         metadata.Set("BT", "Trn_ServiceImage");
         metadata.Set("PK", "[ \"ServiceImageId\" ]");
         metadata.Set("PKAssigned", "[ \"ServiceImageId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Serviceimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Serviceimageid_Z");
         state.Add("gxTpr_Serviceid_Z");
         state.Add("gxTpr_Serviceimage_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_ServiceImage sdt;
         sdt = (SdtTrn_ServiceImage)(source);
         gxTv_SdtTrn_ServiceImage_Serviceimageid = sdt.gxTv_SdtTrn_ServiceImage_Serviceimageid ;
         gxTv_SdtTrn_ServiceImage_Serviceid = sdt.gxTv_SdtTrn_ServiceImage_Serviceid ;
         gxTv_SdtTrn_ServiceImage_Serviceimage = sdt.gxTv_SdtTrn_ServiceImage_Serviceimage ;
         gxTv_SdtTrn_ServiceImage_Serviceimage_gxi = sdt.gxTv_SdtTrn_ServiceImage_Serviceimage_gxi ;
         gxTv_SdtTrn_ServiceImage_Mode = sdt.gxTv_SdtTrn_ServiceImage_Mode ;
         gxTv_SdtTrn_ServiceImage_Initialized = sdt.gxTv_SdtTrn_ServiceImage_Initialized ;
         gxTv_SdtTrn_ServiceImage_Serviceimageid_Z = sdt.gxTv_SdtTrn_ServiceImage_Serviceimageid_Z ;
         gxTv_SdtTrn_ServiceImage_Serviceid_Z = sdt.gxTv_SdtTrn_ServiceImage_Serviceid_Z ;
         gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z = sdt.gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z ;
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
         AddObjectProperty("ServiceImageId", gxTv_SdtTrn_ServiceImage_Serviceimageid, false, includeNonInitialized);
         AddObjectProperty("ServiceId", gxTv_SdtTrn_ServiceImage_Serviceid, false, includeNonInitialized);
         AddObjectProperty("ServiceImage", gxTv_SdtTrn_ServiceImage_Serviceimage, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ServiceImage_GXI", gxTv_SdtTrn_ServiceImage_Serviceimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_ServiceImage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_ServiceImage_Initialized, false, includeNonInitialized);
            AddObjectProperty("ServiceImageId_Z", gxTv_SdtTrn_ServiceImage_Serviceimageid_Z, false, includeNonInitialized);
            AddObjectProperty("ServiceId_Z", gxTv_SdtTrn_ServiceImage_Serviceid_Z, false, includeNonInitialized);
            AddObjectProperty("ServiceImage_GXI_Z", gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_ServiceImage sdt )
      {
         if ( sdt.IsDirty("ServiceImageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimageid = sdt.gxTv_SdtTrn_ServiceImage_Serviceimageid ;
         }
         if ( sdt.IsDirty("ServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceid = sdt.gxTv_SdtTrn_ServiceImage_Serviceid ;
         }
         if ( sdt.IsDirty("ServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimage = sdt.gxTv_SdtTrn_ServiceImage_Serviceimage ;
         }
         if ( sdt.IsDirty("ServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimage_gxi = sdt.gxTv_SdtTrn_ServiceImage_Serviceimage_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ServiceImageId" )]
      [  XmlElement( ElementName = "ServiceImageId"   )]
      public Guid gxTpr_Serviceimageid
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceimageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_ServiceImage_Serviceimageid != value )
            {
               gxTv_SdtTrn_ServiceImage_Mode = "INS";
               this.gxTv_SdtTrn_ServiceImage_Serviceimageid_Z_SetNull( );
               this.gxTv_SdtTrn_ServiceImage_Serviceid_Z_SetNull( );
               this.gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_ServiceImage_Serviceimageid = value;
            SetDirty("Serviceimageid");
         }

      }

      [  SoapElement( ElementName = "ServiceId" )]
      [  XmlElement( ElementName = "ServiceId"   )]
      public Guid gxTpr_Serviceid
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceid = value;
            SetDirty("Serviceid");
         }

      }

      [  SoapElement( ElementName = "ServiceImage" )]
      [  XmlElement( ElementName = "ServiceImage"   )]
      [GxUpload()]
      public string gxTpr_Serviceimage
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimage = value;
            SetDirty("Serviceimage");
         }

      }

      [  SoapElement( ElementName = "ServiceImage_GXI" )]
      [  XmlElement( ElementName = "ServiceImage_GXI"   )]
      public string gxTpr_Serviceimage_gxi
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimage_gxi = value;
            SetDirty("Serviceimage_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_ServiceImage_Mode_SetNull( )
      {
         gxTv_SdtTrn_ServiceImage_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_ServiceImage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_ServiceImage_Initialized_SetNull( )
      {
         gxTv_SdtTrn_ServiceImage_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_ServiceImage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiceImageId_Z" )]
      [  XmlElement( ElementName = "ServiceImageId_Z"   )]
      public Guid gxTpr_Serviceimageid_Z
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceimageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimageid_Z = value;
            SetDirty("Serviceimageid_Z");
         }

      }

      public void gxTv_SdtTrn_ServiceImage_Serviceimageid_Z_SetNull( )
      {
         gxTv_SdtTrn_ServiceImage_Serviceimageid_Z = Guid.Empty;
         SetDirty("Serviceimageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ServiceImage_Serviceimageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiceId_Z" )]
      [  XmlElement( ElementName = "ServiceId_Z"   )]
      public Guid gxTpr_Serviceid_Z
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceid_Z = value;
            SetDirty("Serviceid_Z");
         }

      }

      public void gxTv_SdtTrn_ServiceImage_Serviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_ServiceImage_Serviceid_Z = Guid.Empty;
         SetDirty("Serviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ServiceImage_Serviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiceImage_GXI_Z" )]
      [  XmlElement( ElementName = "ServiceImage_GXI_Z"   )]
      public string gxTpr_Serviceimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z = value;
            SetDirty("Serviceimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z = "";
         SetDirty("Serviceimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z_IsNull( )
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
         gxTv_SdtTrn_ServiceImage_Serviceimageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_ServiceImage_Serviceid = Guid.Empty;
         gxTv_SdtTrn_ServiceImage_Serviceimage = "";
         gxTv_SdtTrn_ServiceImage_Serviceimage_gxi = "";
         gxTv_SdtTrn_ServiceImage_Mode = "";
         gxTv_SdtTrn_ServiceImage_Serviceimageid_Z = Guid.Empty;
         gxTv_SdtTrn_ServiceImage_Serviceid_Z = Guid.Empty;
         gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_serviceimage", "GeneXus.Programs.trn_serviceimage_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_ServiceImage_Initialized ;
      private string gxTv_SdtTrn_ServiceImage_Mode ;
      private string gxTv_SdtTrn_ServiceImage_Serviceimage_gxi ;
      private string gxTv_SdtTrn_ServiceImage_Serviceimage_gxi_Z ;
      private string gxTv_SdtTrn_ServiceImage_Serviceimage ;
      private Guid gxTv_SdtTrn_ServiceImage_Serviceimageid ;
      private Guid gxTv_SdtTrn_ServiceImage_Serviceid ;
      private Guid gxTv_SdtTrn_ServiceImage_Serviceimageid_Z ;
      private Guid gxTv_SdtTrn_ServiceImage_Serviceid_Z ;
   }

   [DataContract(Name = @"Trn_ServiceImage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ServiceImage_RESTInterface : GxGenericCollectionItem<SdtTrn_ServiceImage>
   {
      public SdtTrn_ServiceImage_RESTInterface( ) : base()
      {
      }

      public SdtTrn_ServiceImage_RESTInterface( SdtTrn_ServiceImage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ServiceImageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Serviceimageid
      {
         get {
            return sdt.gxTpr_Serviceimageid ;
         }

         set {
            sdt.gxTpr_Serviceimageid = value;
         }

      }

      [DataMember( Name = "ServiceId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Serviceid
      {
         get {
            return sdt.gxTpr_Serviceid ;
         }

         set {
            sdt.gxTpr_Serviceid = value;
         }

      }

      [DataMember( Name = "ServiceImage" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Serviceimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Serviceimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Serviceimage) : StringUtil.RTrim( sdt.gxTpr_Serviceimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Serviceimage = value;
         }

      }

      public SdtTrn_ServiceImage sdt
      {
         get {
            return (SdtTrn_ServiceImage)Sdt ;
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
            sdt = new SdtTrn_ServiceImage() ;
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

   [DataContract(Name = @"Trn_ServiceImage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_ServiceImage_RESTLInterface : GxGenericCollectionItem<SdtTrn_ServiceImage>
   {
      public SdtTrn_ServiceImage_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_ServiceImage_RESTLInterface( SdtTrn_ServiceImage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ServiceId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Serviceid
      {
         get {
            return sdt.gxTpr_Serviceid ;
         }

         set {
            sdt.gxTpr_Serviceid = value;
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

      public SdtTrn_ServiceImage sdt
      {
         get {
            return (SdtTrn_ServiceImage)Sdt ;
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
            sdt = new SdtTrn_ServiceImage() ;
         }
      }

   }

}
