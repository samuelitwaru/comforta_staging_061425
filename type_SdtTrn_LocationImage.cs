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
   [XmlRoot(ElementName = "Trn_LocationImage" )]
   [XmlType(TypeName =  "Trn_LocationImage" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_LocationImage : GxSilentTrnSdt
   {
      public SdtTrn_LocationImage( )
      {
      }

      public SdtTrn_LocationImage( IGxContext context )
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

      public void Load( Guid AV613LocationImageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV613LocationImageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LocationImageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_LocationImage");
         metadata.Set("BT", "Trn_LocationImage");
         metadata.Set("PK", "[ \"LocationImageId\" ]");
         metadata.Set("PKAssigned", "[ \"LocationImageId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Organisationlocationimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Locationimageid_Z");
         state.Add("gxTpr_Organisationlocationid_Z");
         state.Add("gxTpr_Organisationlocationimage_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_LocationImage sdt;
         sdt = (SdtTrn_LocationImage)(source);
         gxTv_SdtTrn_LocationImage_Locationimageid = sdt.gxTv_SdtTrn_LocationImage_Locationimageid ;
         gxTv_SdtTrn_LocationImage_Organisationlocationid = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationid ;
         gxTv_SdtTrn_LocationImage_Organisationlocationimage = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationimage ;
         gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi ;
         gxTv_SdtTrn_LocationImage_Mode = sdt.gxTv_SdtTrn_LocationImage_Mode ;
         gxTv_SdtTrn_LocationImage_Initialized = sdt.gxTv_SdtTrn_LocationImage_Initialized ;
         gxTv_SdtTrn_LocationImage_Locationimageid_Z = sdt.gxTv_SdtTrn_LocationImage_Locationimageid_Z ;
         gxTv_SdtTrn_LocationImage_Organisationlocationid_Z = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationid_Z ;
         gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z ;
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
         AddObjectProperty("LocationImageId", gxTv_SdtTrn_LocationImage_Locationimageid, false, includeNonInitialized);
         AddObjectProperty("OrganisationLocationId", gxTv_SdtTrn_LocationImage_Organisationlocationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationLocationImage", gxTv_SdtTrn_LocationImage_Organisationlocationimage, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("OrganisationLocationImage_GXI", gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_LocationImage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_LocationImage_Initialized, false, includeNonInitialized);
            AddObjectProperty("LocationImageId_Z", gxTv_SdtTrn_LocationImage_Locationimageid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationLocationId_Z", gxTv_SdtTrn_LocationImage_Organisationlocationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationLocationImage_GXI_Z", gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_LocationImage sdt )
      {
         if ( sdt.IsDirty("LocationImageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Locationimageid = sdt.gxTv_SdtTrn_LocationImage_Locationimageid ;
         }
         if ( sdt.IsDirty("OrganisationLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationid = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationid ;
         }
         if ( sdt.IsDirty("OrganisationLocationImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationimage = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationimage ;
         }
         if ( sdt.IsDirty("OrganisationLocationImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi = sdt.gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LocationImageId" )]
      [  XmlElement( ElementName = "LocationImageId"   )]
      public Guid gxTpr_Locationimageid
      {
         get {
            return gxTv_SdtTrn_LocationImage_Locationimageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_LocationImage_Locationimageid != value )
            {
               gxTv_SdtTrn_LocationImage_Mode = "INS";
               this.gxTv_SdtTrn_LocationImage_Locationimageid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationImage_Organisationlocationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_LocationImage_Locationimageid = value;
            SetDirty("Locationimageid");
         }

      }

      [  SoapElement( ElementName = "OrganisationLocationId" )]
      [  XmlElement( ElementName = "OrganisationLocationId"   )]
      public Guid gxTpr_Organisationlocationid
      {
         get {
            return gxTv_SdtTrn_LocationImage_Organisationlocationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationid = value;
            SetDirty("Organisationlocationid");
         }

      }

      [  SoapElement( ElementName = "OrganisationLocationImage" )]
      [  XmlElement( ElementName = "OrganisationLocationImage"   )]
      [GxUpload()]
      public string gxTpr_Organisationlocationimage
      {
         get {
            return gxTv_SdtTrn_LocationImage_Organisationlocationimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationimage = value;
            SetDirty("Organisationlocationimage");
         }

      }

      [  SoapElement( ElementName = "OrganisationLocationImage_GXI" )]
      [  XmlElement( ElementName = "OrganisationLocationImage_GXI"   )]
      public string gxTpr_Organisationlocationimage_gxi
      {
         get {
            return gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi = value;
            SetDirty("Organisationlocationimage_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_LocationImage_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_LocationImage_Mode_SetNull( )
      {
         gxTv_SdtTrn_LocationImage_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationImage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_LocationImage_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_LocationImage_Initialized_SetNull( )
      {
         gxTv_SdtTrn_LocationImage_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationImage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationImageId_Z" )]
      [  XmlElement( ElementName = "LocationImageId_Z"   )]
      public Guid gxTpr_Locationimageid_Z
      {
         get {
            return gxTv_SdtTrn_LocationImage_Locationimageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Locationimageid_Z = value;
            SetDirty("Locationimageid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationImage_Locationimageid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationImage_Locationimageid_Z = Guid.Empty;
         SetDirty("Locationimageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationImage_Locationimageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationLocationId_Z" )]
      [  XmlElement( ElementName = "OrganisationLocationId_Z"   )]
      public Guid gxTpr_Organisationlocationid_Z
      {
         get {
            return gxTv_SdtTrn_LocationImage_Organisationlocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationid_Z = value;
            SetDirty("Organisationlocationid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationImage_Organisationlocationid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationImage_Organisationlocationid_Z = Guid.Empty;
         SetDirty("Organisationlocationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationImage_Organisationlocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationLocationImage_GXI_Z" )]
      [  XmlElement( ElementName = "OrganisationLocationImage_GXI_Z"   )]
      public string gxTpr_Organisationlocationimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z = value;
            SetDirty("Organisationlocationimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z = "";
         SetDirty("Organisationlocationimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z_IsNull( )
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
         gxTv_SdtTrn_LocationImage_Locationimageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_LocationImage_Organisationlocationid = Guid.Empty;
         gxTv_SdtTrn_LocationImage_Organisationlocationimage = "";
         gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi = "";
         gxTv_SdtTrn_LocationImage_Mode = "";
         gxTv_SdtTrn_LocationImage_Locationimageid_Z = Guid.Empty;
         gxTv_SdtTrn_LocationImage_Organisationlocationid_Z = Guid.Empty;
         gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_locationimage", "GeneXus.Programs.trn_locationimage_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_LocationImage_Initialized ;
      private string gxTv_SdtTrn_LocationImage_Mode ;
      private string gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi ;
      private string gxTv_SdtTrn_LocationImage_Organisationlocationimage_gxi_Z ;
      private string gxTv_SdtTrn_LocationImage_Organisationlocationimage ;
      private Guid gxTv_SdtTrn_LocationImage_Locationimageid ;
      private Guid gxTv_SdtTrn_LocationImage_Organisationlocationid ;
      private Guid gxTv_SdtTrn_LocationImage_Locationimageid_Z ;
      private Guid gxTv_SdtTrn_LocationImage_Organisationlocationid_Z ;
   }

   [DataContract(Name = @"Trn_LocationImage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_LocationImage_RESTInterface : GxGenericCollectionItem<SdtTrn_LocationImage>
   {
      public SdtTrn_LocationImage_RESTInterface( ) : base()
      {
      }

      public SdtTrn_LocationImage_RESTInterface( SdtTrn_LocationImage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationImageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Locationimageid
      {
         get {
            return sdt.gxTpr_Locationimageid ;
         }

         set {
            sdt.gxTpr_Locationimageid = value;
         }

      }

      [DataMember( Name = "OrganisationLocationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationlocationid
      {
         get {
            return sdt.gxTpr_Organisationlocationid ;
         }

         set {
            sdt.gxTpr_Organisationlocationid = value;
         }

      }

      [DataMember( Name = "OrganisationLocationImage" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Organisationlocationimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationlocationimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Organisationlocationimage) : StringUtil.RTrim( sdt.gxTpr_Organisationlocationimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Organisationlocationimage = value;
         }

      }

      public SdtTrn_LocationImage sdt
      {
         get {
            return (SdtTrn_LocationImage)Sdt ;
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
            sdt = new SdtTrn_LocationImage() ;
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

   [DataContract(Name = @"Trn_LocationImage", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_LocationImage_RESTLInterface : GxGenericCollectionItem<SdtTrn_LocationImage>
   {
      public SdtTrn_LocationImage_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_LocationImage_RESTLInterface( SdtTrn_LocationImage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationLocationId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationlocationid
      {
         get {
            return sdt.gxTpr_Organisationlocationid ;
         }

         set {
            sdt.gxTpr_Organisationlocationid = value;
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

      public SdtTrn_LocationImage sdt
      {
         get {
            return (SdtTrn_LocationImage)Sdt ;
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
            sdt = new SdtTrn_LocationImage() ;
         }
      }

   }

}
