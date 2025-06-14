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
   [XmlRoot(ElementName = "Trn_OrganisationType" )]
   [XmlType(TypeName =  "Trn_OrganisationType" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_OrganisationType : GxSilentTrnSdt
   {
      public SdtTrn_OrganisationType( )
      {
      }

      public SdtTrn_OrganisationType( IGxContext context )
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

      public void Load( Guid AV19OrganisationTypeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV19OrganisationTypeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OrganisationTypeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_OrganisationType");
         metadata.Set("BT", "Trn_OrganisationType");
         metadata.Set("PK", "[ \"OrganisationTypeId\" ]");
         metadata.Set("PKAssigned", "[ \"OrganisationTypeId\" ]");
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
         state.Add("gxTpr_Organisationtypeid_Z");
         state.Add("gxTpr_Organisationtypename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_OrganisationType sdt;
         sdt = (SdtTrn_OrganisationType)(source);
         gxTv_SdtTrn_OrganisationType_Organisationtypeid = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypeid ;
         gxTv_SdtTrn_OrganisationType_Organisationtypename = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypename ;
         gxTv_SdtTrn_OrganisationType_Mode = sdt.gxTv_SdtTrn_OrganisationType_Mode ;
         gxTv_SdtTrn_OrganisationType_Initialized = sdt.gxTv_SdtTrn_OrganisationType_Initialized ;
         gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z ;
         gxTv_SdtTrn_OrganisationType_Organisationtypename_Z = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypename_Z ;
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
         AddObjectProperty("OrganisationTypeId", gxTv_SdtTrn_OrganisationType_Organisationtypeid, false, includeNonInitialized);
         AddObjectProperty("OrganisationTypeName", gxTv_SdtTrn_OrganisationType_Organisationtypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_OrganisationType_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_OrganisationType_Initialized, false, includeNonInitialized);
            AddObjectProperty("OrganisationTypeId_Z", gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationTypeName_Z", gxTv_SdtTrn_OrganisationType_Organisationtypename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_OrganisationType sdt )
      {
         if ( sdt.IsDirty("OrganisationTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Organisationtypeid = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypeid ;
         }
         if ( sdt.IsDirty("OrganisationTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Organisationtypename = sdt.gxTv_SdtTrn_OrganisationType_Organisationtypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OrganisationTypeId" )]
      [  XmlElement( ElementName = "OrganisationTypeId"   )]
      public Guid gxTpr_Organisationtypeid
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Organisationtypeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_OrganisationType_Organisationtypeid != value )
            {
               gxTv_SdtTrn_OrganisationType_Mode = "INS";
               this.gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z_SetNull( );
               this.gxTv_SdtTrn_OrganisationType_Organisationtypename_Z_SetNull( );
            }
            gxTv_SdtTrn_OrganisationType_Organisationtypeid = value;
            SetDirty("Organisationtypeid");
         }

      }

      [  SoapElement( ElementName = "OrganisationTypeName" )]
      [  XmlElement( ElementName = "OrganisationTypeName"   )]
      public string gxTpr_Organisationtypename
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Organisationtypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Organisationtypename = value;
            SetDirty("Organisationtypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_OrganisationType_Mode_SetNull( )
      {
         gxTv_SdtTrn_OrganisationType_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationType_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_OrganisationType_Initialized_SetNull( )
      {
         gxTv_SdtTrn_OrganisationType_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationType_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationTypeId_Z" )]
      [  XmlElement( ElementName = "OrganisationTypeId_Z"   )]
      public Guid gxTpr_Organisationtypeid_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z = value;
            SetDirty("Organisationtypeid_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z = Guid.Empty;
         SetDirty("Organisationtypeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationTypeName_Z" )]
      [  XmlElement( ElementName = "OrganisationTypeName_Z"   )]
      public string gxTpr_Organisationtypename_Z
      {
         get {
            return gxTv_SdtTrn_OrganisationType_Organisationtypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_OrganisationType_Organisationtypename_Z = value;
            SetDirty("Organisationtypename_Z");
         }

      }

      public void gxTv_SdtTrn_OrganisationType_Organisationtypename_Z_SetNull( )
      {
         gxTv_SdtTrn_OrganisationType_Organisationtypename_Z = "";
         SetDirty("Organisationtypename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_OrganisationType_Organisationtypename_Z_IsNull( )
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
         gxTv_SdtTrn_OrganisationType_Organisationtypeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_OrganisationType_Organisationtypename = "";
         gxTv_SdtTrn_OrganisationType_Mode = "";
         gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z = Guid.Empty;
         gxTv_SdtTrn_OrganisationType_Organisationtypename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_organisationtype", "GeneXus.Programs.trn_organisationtype_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_OrganisationType_Initialized ;
      private string gxTv_SdtTrn_OrganisationType_Mode ;
      private string gxTv_SdtTrn_OrganisationType_Organisationtypename ;
      private string gxTv_SdtTrn_OrganisationType_Organisationtypename_Z ;
      private Guid gxTv_SdtTrn_OrganisationType_Organisationtypeid ;
      private Guid gxTv_SdtTrn_OrganisationType_Organisationtypeid_Z ;
   }

   [DataContract(Name = @"Trn_OrganisationType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationType_RESTInterface : GxGenericCollectionItem<SdtTrn_OrganisationType>
   {
      public SdtTrn_OrganisationType_RESTInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationType_RESTInterface( SdtTrn_OrganisationType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationTypeId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationtypeid
      {
         get {
            return sdt.gxTpr_Organisationtypeid ;
         }

         set {
            sdt.gxTpr_Organisationtypeid = value;
         }

      }

      [DataMember( Name = "OrganisationTypeName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Organisationtypename
      {
         get {
            return sdt.gxTpr_Organisationtypename ;
         }

         set {
            sdt.gxTpr_Organisationtypename = value;
         }

      }

      public SdtTrn_OrganisationType sdt
      {
         get {
            return (SdtTrn_OrganisationType)Sdt ;
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
            sdt = new SdtTrn_OrganisationType() ;
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

   [DataContract(Name = @"Trn_OrganisationType", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_OrganisationType_RESTLInterface : GxGenericCollectionItem<SdtTrn_OrganisationType>
   {
      public SdtTrn_OrganisationType_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_OrganisationType_RESTLInterface( SdtTrn_OrganisationType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OrganisationTypeName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Organisationtypename
      {
         get {
            return sdt.gxTpr_Organisationtypename ;
         }

         set {
            sdt.gxTpr_Organisationtypename = value;
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

      public SdtTrn_OrganisationType sdt
      {
         get {
            return (SdtTrn_OrganisationType)Sdt ;
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
            sdt = new SdtTrn_OrganisationType() ;
         }
      }

   }

}
