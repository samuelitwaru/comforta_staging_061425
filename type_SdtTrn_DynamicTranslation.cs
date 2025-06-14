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
   [XmlRoot(ElementName = "Trn_DynamicTranslation" )]
   [XmlType(TypeName =  "Trn_DynamicTranslation" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_DynamicTranslation : GxSilentTrnSdt
   {
      public SdtTrn_DynamicTranslation( )
      {
      }

      public SdtTrn_DynamicTranslation( IGxContext context )
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

      public void Load( Guid AV578DynamicTranslationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV578DynamicTranslationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DynamicTranslationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_DynamicTranslation");
         metadata.Set("BT", "Trn_DynamicTranslation");
         metadata.Set("PK", "[ \"DynamicTranslationId\" ]");
         metadata.Set("PKAssigned", "[ \"DynamicTranslationId\" ]");
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
         state.Add("gxTpr_Dynamictranslationid_Z");
         state.Add("gxTpr_Dynamictranslationtrnname_Z");
         state.Add("gxTpr_Dynamictranslationprimarykey_Z");
         state.Add("gxTpr_Dynamictranslationattributename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_DynamicTranslation sdt;
         sdt = (SdtTrn_DynamicTranslation)(source);
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch ;
         gxTv_SdtTrn_DynamicTranslation_Mode = sdt.gxTv_SdtTrn_DynamicTranslation_Mode ;
         gxTv_SdtTrn_DynamicTranslation_Initialized = sdt.gxTv_SdtTrn_DynamicTranslation_Initialized ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z ;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z ;
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
         AddObjectProperty("DynamicTranslationId", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid, false, includeNonInitialized);
         AddObjectProperty("DynamicTranslationTrnName", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname, false, includeNonInitialized);
         AddObjectProperty("DynamicTranslationPrimaryKey", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey, false, includeNonInitialized);
         AddObjectProperty("DynamicTranslationAttributeName", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename, false, includeNonInitialized);
         AddObjectProperty("DynamicTranslationEnglish", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish, false, includeNonInitialized);
         AddObjectProperty("DynamicTranslationDutch", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_DynamicTranslation_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_DynamicTranslation_Initialized, false, includeNonInitialized);
            AddObjectProperty("DynamicTranslationId_Z", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z, false, includeNonInitialized);
            AddObjectProperty("DynamicTranslationTrnName_Z", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z, false, includeNonInitialized);
            AddObjectProperty("DynamicTranslationPrimaryKey_Z", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z, false, includeNonInitialized);
            AddObjectProperty("DynamicTranslationAttributeName_Z", gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_DynamicTranslation sdt )
      {
         if ( sdt.IsDirty("DynamicTranslationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid ;
         }
         if ( sdt.IsDirty("DynamicTranslationTrnName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname ;
         }
         if ( sdt.IsDirty("DynamicTranslationPrimaryKey") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey ;
         }
         if ( sdt.IsDirty("DynamicTranslationAttributeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename ;
         }
         if ( sdt.IsDirty("DynamicTranslationEnglish") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish ;
         }
         if ( sdt.IsDirty("DynamicTranslationDutch") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch = sdt.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DynamicTranslationId" )]
      [  XmlElement( ElementName = "DynamicTranslationId"   )]
      public Guid gxTpr_Dynamictranslationid
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid != value )
            {
               gxTv_SdtTrn_DynamicTranslation_Mode = "INS";
               this.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z_SetNull( );
               this.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z_SetNull( );
               this.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z_SetNull( );
               this.gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z_SetNull( );
            }
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid = value;
            SetDirty("Dynamictranslationid");
         }

      }

      [  SoapElement( ElementName = "DynamicTranslationTrnName" )]
      [  XmlElement( ElementName = "DynamicTranslationTrnName"   )]
      public string gxTpr_Dynamictranslationtrnname
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname = value;
            SetDirty("Dynamictranslationtrnname");
         }

      }

      [  SoapElement( ElementName = "DynamicTranslationPrimaryKey" )]
      [  XmlElement( ElementName = "DynamicTranslationPrimaryKey"   )]
      public Guid gxTpr_Dynamictranslationprimarykey
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey = value;
            SetDirty("Dynamictranslationprimarykey");
         }

      }

      [  SoapElement( ElementName = "DynamicTranslationAttributeName" )]
      [  XmlElement( ElementName = "DynamicTranslationAttributeName"   )]
      public string gxTpr_Dynamictranslationattributename
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename = value;
            SetDirty("Dynamictranslationattributename");
         }

      }

      [  SoapElement( ElementName = "DynamicTranslationEnglish" )]
      [  XmlElement( ElementName = "DynamicTranslationEnglish"   )]
      public string gxTpr_Dynamictranslationenglish
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish = value;
            SetDirty("Dynamictranslationenglish");
         }

      }

      [  SoapElement( ElementName = "DynamicTranslationDutch" )]
      [  XmlElement( ElementName = "DynamicTranslationDutch"   )]
      public string gxTpr_Dynamictranslationdutch
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch = value;
            SetDirty("Dynamictranslationdutch");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Mode_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Initialized_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DynamicTranslationId_Z" )]
      [  XmlElement( ElementName = "DynamicTranslationId_Z"   )]
      public Guid gxTpr_Dynamictranslationid_Z
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z = value;
            SetDirty("Dynamictranslationid_Z");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z = Guid.Empty;
         SetDirty("Dynamictranslationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DynamicTranslationTrnName_Z" )]
      [  XmlElement( ElementName = "DynamicTranslationTrnName_Z"   )]
      public string gxTpr_Dynamictranslationtrnname_Z
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z = value;
            SetDirty("Dynamictranslationtrnname_Z");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z = "";
         SetDirty("Dynamictranslationtrnname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DynamicTranslationPrimaryKey_Z" )]
      [  XmlElement( ElementName = "DynamicTranslationPrimaryKey_Z"   )]
      public Guid gxTpr_Dynamictranslationprimarykey_Z
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z = value;
            SetDirty("Dynamictranslationprimarykey_Z");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z = Guid.Empty;
         SetDirty("Dynamictranslationprimarykey_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DynamicTranslationAttributeName_Z" )]
      [  XmlElement( ElementName = "DynamicTranslationAttributeName_Z"   )]
      public string gxTpr_Dynamictranslationattributename_Z
      {
         get {
            return gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z = value;
            SetDirty("Dynamictranslationattributename_Z");
         }

      }

      public void gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z_SetNull( )
      {
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z = "";
         SetDirty("Dynamictranslationattributename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z_IsNull( )
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
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname = "";
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey = Guid.Empty;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename = "";
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish = "";
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch = "";
         gxTv_SdtTrn_DynamicTranslation_Mode = "";
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z = Guid.Empty;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z = "";
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z = Guid.Empty;
         gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_dynamictranslation", "GeneXus.Programs.trn_dynamictranslation_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_DynamicTranslation_Initialized ;
      private string gxTv_SdtTrn_DynamicTranslation_Mode ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationenglish ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationdutch ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationtrnname_Z ;
      private string gxTv_SdtTrn_DynamicTranslation_Dynamictranslationattributename_Z ;
      private Guid gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid ;
      private Guid gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey ;
      private Guid gxTv_SdtTrn_DynamicTranslation_Dynamictranslationid_Z ;
      private Guid gxTv_SdtTrn_DynamicTranslation_Dynamictranslationprimarykey_Z ;
   }

   [DataContract(Name = @"Trn_DynamicTranslation", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_DynamicTranslation_RESTInterface : GxGenericCollectionItem<SdtTrn_DynamicTranslation>
   {
      public SdtTrn_DynamicTranslation_RESTInterface( ) : base()
      {
      }

      public SdtTrn_DynamicTranslation_RESTInterface( SdtTrn_DynamicTranslation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DynamicTranslationId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Dynamictranslationid
      {
         get {
            return sdt.gxTpr_Dynamictranslationid ;
         }

         set {
            sdt.gxTpr_Dynamictranslationid = value;
         }

      }

      [DataMember( Name = "DynamicTranslationTrnName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Dynamictranslationtrnname
      {
         get {
            return sdt.gxTpr_Dynamictranslationtrnname ;
         }

         set {
            sdt.gxTpr_Dynamictranslationtrnname = value;
         }

      }

      [DataMember( Name = "DynamicTranslationPrimaryKey" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Dynamictranslationprimarykey
      {
         get {
            return sdt.gxTpr_Dynamictranslationprimarykey ;
         }

         set {
            sdt.gxTpr_Dynamictranslationprimarykey = value;
         }

      }

      [DataMember( Name = "DynamicTranslationAttributeName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Dynamictranslationattributename
      {
         get {
            return sdt.gxTpr_Dynamictranslationattributename ;
         }

         set {
            sdt.gxTpr_Dynamictranslationattributename = value;
         }

      }

      [DataMember( Name = "DynamicTranslationEnglish" , Order = 4 )]
      public string gxTpr_Dynamictranslationenglish
      {
         get {
            return sdt.gxTpr_Dynamictranslationenglish ;
         }

         set {
            sdt.gxTpr_Dynamictranslationenglish = value;
         }

      }

      [DataMember( Name = "DynamicTranslationDutch" , Order = 5 )]
      public string gxTpr_Dynamictranslationdutch
      {
         get {
            return sdt.gxTpr_Dynamictranslationdutch ;
         }

         set {
            sdt.gxTpr_Dynamictranslationdutch = value;
         }

      }

      public SdtTrn_DynamicTranslation sdt
      {
         get {
            return (SdtTrn_DynamicTranslation)Sdt ;
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
            sdt = new SdtTrn_DynamicTranslation() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Trn_DynamicTranslation", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_DynamicTranslation_RESTLInterface : GxGenericCollectionItem<SdtTrn_DynamicTranslation>
   {
      public SdtTrn_DynamicTranslation_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_DynamicTranslation_RESTLInterface( SdtTrn_DynamicTranslation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DynamicTranslationTrnName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Dynamictranslationtrnname
      {
         get {
            return sdt.gxTpr_Dynamictranslationtrnname ;
         }

         set {
            sdt.gxTpr_Dynamictranslationtrnname = value;
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

      public SdtTrn_DynamicTranslation sdt
      {
         get {
            return (SdtTrn_DynamicTranslation)Sdt ;
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
            sdt = new SdtTrn_DynamicTranslation() ;
         }
      }

   }

}
