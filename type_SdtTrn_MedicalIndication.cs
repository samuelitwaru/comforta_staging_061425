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
   [XmlRoot(ElementName = "Trn_MedicalIndication" )]
   [XmlType(TypeName =  "Trn_MedicalIndication" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_MedicalIndication : GxSilentTrnSdt
   {
      public SdtTrn_MedicalIndication( )
      {
      }

      public SdtTrn_MedicalIndication( IGxContext context )
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

      public void Load( Guid AV98MedicalIndicationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV98MedicalIndicationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MedicalIndicationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_MedicalIndication");
         metadata.Set("BT", "Trn_MedicalIndication");
         metadata.Set("PK", "[ \"MedicalIndicationId\" ]");
         metadata.Set("PKAssigned", "[ \"MedicalIndicationId\" ]");
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
         state.Add("gxTpr_Medicalindicationid_Z");
         state.Add("gxTpr_Medicalindicationname_Z");
         state.Add("gxTpr_Medicalindicationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_MedicalIndication sdt;
         sdt = (SdtTrn_MedicalIndication)(source);
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationid ;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationname = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationname ;
         gxTv_SdtTrn_MedicalIndication_Mode = sdt.gxTv_SdtTrn_MedicalIndication_Mode ;
         gxTv_SdtTrn_MedicalIndication_Initialized = sdt.gxTv_SdtTrn_MedicalIndication_Initialized ;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z ;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z ;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N ;
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
         AddObjectProperty("MedicalIndicationId", gxTv_SdtTrn_MedicalIndication_Medicalindicationid, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N, false, includeNonInitialized);
         AddObjectProperty("MedicalIndicationName", gxTv_SdtTrn_MedicalIndication_Medicalindicationname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_MedicalIndication_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_MedicalIndication_Initialized, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_Z", gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationName_Z", gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z, false, includeNonInitialized);
            AddObjectProperty("MedicalIndicationId_N", gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_MedicalIndication sdt )
      {
         if ( sdt.IsDirty("MedicalIndicationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationid = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationid ;
         }
         if ( sdt.IsDirty("MedicalIndicationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationname = sdt.gxTv_SdtTrn_MedicalIndication_Medicalindicationname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId" )]
      [  XmlElement( ElementName = "MedicalIndicationId"   )]
      public Guid gxTpr_Medicalindicationid
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Medicalindicationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_MedicalIndication_Medicalindicationid != value )
            {
               gxTv_SdtTrn_MedicalIndication_Mode = "INS";
               this.gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z_SetNull( );
               this.gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z_SetNull( );
            }
            gxTv_SdtTrn_MedicalIndication_Medicalindicationid = value;
            SetDirty("Medicalindicationid");
         }

      }

      [  SoapElement( ElementName = "MedicalIndicationName" )]
      [  XmlElement( ElementName = "MedicalIndicationName"   )]
      public string gxTpr_Medicalindicationname
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Medicalindicationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationname = value;
            SetDirty("Medicalindicationname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_MedicalIndication_Mode_SetNull( )
      {
         gxTv_SdtTrn_MedicalIndication_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_MedicalIndication_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_MedicalIndication_Initialized_SetNull( )
      {
         gxTv_SdtTrn_MedicalIndication_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_MedicalIndication_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationId_Z"   )]
      public Guid gxTpr_Medicalindicationid_Z
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z = value;
            SetDirty("Medicalindicationid_Z");
         }

      }

      public void gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z_SetNull( )
      {
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z = Guid.Empty;
         SetDirty("Medicalindicationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationName_Z" )]
      [  XmlElement( ElementName = "MedicalIndicationName_Z"   )]
      public string gxTpr_Medicalindicationname_Z
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z = value;
            SetDirty("Medicalindicationname_Z");
         }

      }

      public void gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z_SetNull( )
      {
         gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z = "";
         SetDirty("Medicalindicationname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedicalIndicationId_N" )]
      [  XmlElement( ElementName = "MedicalIndicationId_N"   )]
      public short gxTpr_Medicalindicationid_N
      {
         get {
            return gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N = value;
            SetDirty("Medicalindicationid_N");
         }

      }

      public void gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N_SetNull( )
      {
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N = 0;
         SetDirty("Medicalindicationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N_IsNull( )
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
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationname = "";
         gxTv_SdtTrn_MedicalIndication_Mode = "";
         gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z = Guid.Empty;
         gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_medicalindication", "GeneXus.Programs.trn_medicalindication_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_MedicalIndication_Initialized ;
      private short gxTv_SdtTrn_MedicalIndication_Medicalindicationid_N ;
      private string gxTv_SdtTrn_MedicalIndication_Mode ;
      private string gxTv_SdtTrn_MedicalIndication_Medicalindicationname ;
      private string gxTv_SdtTrn_MedicalIndication_Medicalindicationname_Z ;
      private Guid gxTv_SdtTrn_MedicalIndication_Medicalindicationid ;
      private Guid gxTv_SdtTrn_MedicalIndication_Medicalindicationid_Z ;
   }

   [DataContract(Name = @"Trn_MedicalIndication", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_MedicalIndication_RESTInterface : GxGenericCollectionItem<SdtTrn_MedicalIndication>
   {
      public SdtTrn_MedicalIndication_RESTInterface( ) : base()
      {
      }

      public SdtTrn_MedicalIndication_RESTInterface( SdtTrn_MedicalIndication psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedicalIndicationId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Medicalindicationid
      {
         get {
            return sdt.gxTpr_Medicalindicationid ;
         }

         set {
            sdt.gxTpr_Medicalindicationid = value;
         }

      }

      [DataMember( Name = "MedicalIndicationName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Medicalindicationname
      {
         get {
            return sdt.gxTpr_Medicalindicationname ;
         }

         set {
            sdt.gxTpr_Medicalindicationname = value;
         }

      }

      public SdtTrn_MedicalIndication sdt
      {
         get {
            return (SdtTrn_MedicalIndication)Sdt ;
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
            sdt = new SdtTrn_MedicalIndication() ;
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

   [DataContract(Name = @"Trn_MedicalIndication", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_MedicalIndication_RESTLInterface : GxGenericCollectionItem<SdtTrn_MedicalIndication>
   {
      public SdtTrn_MedicalIndication_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_MedicalIndication_RESTLInterface( SdtTrn_MedicalIndication psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedicalIndicationName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medicalindicationname
      {
         get {
            return sdt.gxTpr_Medicalindicationname ;
         }

         set {
            sdt.gxTpr_Medicalindicationname = value;
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

      public SdtTrn_MedicalIndication sdt
      {
         get {
            return (SdtTrn_MedicalIndication)Sdt ;
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
            sdt = new SdtTrn_MedicalIndication() ;
         }
      }

   }

}
