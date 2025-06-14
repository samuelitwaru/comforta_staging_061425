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
   [XmlRoot(ElementName = "Trn_MemoCategory" )]
   [XmlType(TypeName =  "Trn_MemoCategory" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_MemoCategory : GxSilentTrnSdt
   {
      public SdtTrn_MemoCategory( )
      {
      }

      public SdtTrn_MemoCategory( IGxContext context )
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

      public void Load( Guid AV542MemoCategoryId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV542MemoCategoryId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MemoCategoryId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_MemoCategory");
         metadata.Set("BT", "Trn_MemoCategory");
         metadata.Set("PK", "[ \"MemoCategoryId\" ]");
         metadata.Set("PKAssigned", "[ \"MemoCategoryId\" ]");
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
         state.Add("gxTpr_Memocategoryid_Z");
         state.Add("gxTpr_Memocategoryname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_MemoCategory sdt;
         sdt = (SdtTrn_MemoCategory)(source);
         gxTv_SdtTrn_MemoCategory_Memocategoryid = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryid ;
         gxTv_SdtTrn_MemoCategory_Memocategoryname = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryname ;
         gxTv_SdtTrn_MemoCategory_Mode = sdt.gxTv_SdtTrn_MemoCategory_Mode ;
         gxTv_SdtTrn_MemoCategory_Initialized = sdt.gxTv_SdtTrn_MemoCategory_Initialized ;
         gxTv_SdtTrn_MemoCategory_Memocategoryid_Z = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryid_Z ;
         gxTv_SdtTrn_MemoCategory_Memocategoryname_Z = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryname_Z ;
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
         AddObjectProperty("MemoCategoryId", gxTv_SdtTrn_MemoCategory_Memocategoryid, false, includeNonInitialized);
         AddObjectProperty("MemoCategoryName", gxTv_SdtTrn_MemoCategory_Memocategoryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_MemoCategory_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_MemoCategory_Initialized, false, includeNonInitialized);
            AddObjectProperty("MemoCategoryId_Z", gxTv_SdtTrn_MemoCategory_Memocategoryid_Z, false, includeNonInitialized);
            AddObjectProperty("MemoCategoryName_Z", gxTv_SdtTrn_MemoCategory_Memocategoryname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_MemoCategory sdt )
      {
         if ( sdt.IsDirty("MemoCategoryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Memocategoryid = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryid ;
         }
         if ( sdt.IsDirty("MemoCategoryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Memocategoryname = sdt.gxTv_SdtTrn_MemoCategory_Memocategoryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MemoCategoryId" )]
      [  XmlElement( ElementName = "MemoCategoryId"   )]
      public Guid gxTpr_Memocategoryid
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Memocategoryid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_MemoCategory_Memocategoryid != value )
            {
               gxTv_SdtTrn_MemoCategory_Mode = "INS";
               this.gxTv_SdtTrn_MemoCategory_Memocategoryid_Z_SetNull( );
               this.gxTv_SdtTrn_MemoCategory_Memocategoryname_Z_SetNull( );
            }
            gxTv_SdtTrn_MemoCategory_Memocategoryid = value;
            SetDirty("Memocategoryid");
         }

      }

      [  SoapElement( ElementName = "MemoCategoryName" )]
      [  XmlElement( ElementName = "MemoCategoryName"   )]
      public string gxTpr_Memocategoryname
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Memocategoryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Memocategoryname = value;
            SetDirty("Memocategoryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_MemoCategory_Mode_SetNull( )
      {
         gxTv_SdtTrn_MemoCategory_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_MemoCategory_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_MemoCategory_Initialized_SetNull( )
      {
         gxTv_SdtTrn_MemoCategory_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_MemoCategory_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoCategoryId_Z" )]
      [  XmlElement( ElementName = "MemoCategoryId_Z"   )]
      public Guid gxTpr_Memocategoryid_Z
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Memocategoryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Memocategoryid_Z = value;
            SetDirty("Memocategoryid_Z");
         }

      }

      public void gxTv_SdtTrn_MemoCategory_Memocategoryid_Z_SetNull( )
      {
         gxTv_SdtTrn_MemoCategory_Memocategoryid_Z = Guid.Empty;
         SetDirty("Memocategoryid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_MemoCategory_Memocategoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MemoCategoryName_Z" )]
      [  XmlElement( ElementName = "MemoCategoryName_Z"   )]
      public string gxTpr_Memocategoryname_Z
      {
         get {
            return gxTv_SdtTrn_MemoCategory_Memocategoryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_MemoCategory_Memocategoryname_Z = value;
            SetDirty("Memocategoryname_Z");
         }

      }

      public void gxTv_SdtTrn_MemoCategory_Memocategoryname_Z_SetNull( )
      {
         gxTv_SdtTrn_MemoCategory_Memocategoryname_Z = "";
         SetDirty("Memocategoryname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_MemoCategory_Memocategoryname_Z_IsNull( )
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
         gxTv_SdtTrn_MemoCategory_Memocategoryid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_MemoCategory_Memocategoryname = "";
         gxTv_SdtTrn_MemoCategory_Mode = "";
         gxTv_SdtTrn_MemoCategory_Memocategoryid_Z = Guid.Empty;
         gxTv_SdtTrn_MemoCategory_Memocategoryname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_memocategory", "GeneXus.Programs.trn_memocategory_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_MemoCategory_Initialized ;
      private string gxTv_SdtTrn_MemoCategory_Mode ;
      private string gxTv_SdtTrn_MemoCategory_Memocategoryname ;
      private string gxTv_SdtTrn_MemoCategory_Memocategoryname_Z ;
      private Guid gxTv_SdtTrn_MemoCategory_Memocategoryid ;
      private Guid gxTv_SdtTrn_MemoCategory_Memocategoryid_Z ;
   }

   [DataContract(Name = @"Trn_MemoCategory", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_MemoCategory_RESTInterface : GxGenericCollectionItem<SdtTrn_MemoCategory>
   {
      public SdtTrn_MemoCategory_RESTInterface( ) : base()
      {
      }

      public SdtTrn_MemoCategory_RESTInterface( SdtTrn_MemoCategory psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MemoCategoryId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Memocategoryid
      {
         get {
            return sdt.gxTpr_Memocategoryid ;
         }

         set {
            sdt.gxTpr_Memocategoryid = value;
         }

      }

      [DataMember( Name = "MemoCategoryName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Memocategoryname
      {
         get {
            return sdt.gxTpr_Memocategoryname ;
         }

         set {
            sdt.gxTpr_Memocategoryname = value;
         }

      }

      public SdtTrn_MemoCategory sdt
      {
         get {
            return (SdtTrn_MemoCategory)Sdt ;
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
            sdt = new SdtTrn_MemoCategory() ;
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

   [DataContract(Name = @"Trn_MemoCategory", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_MemoCategory_RESTLInterface : GxGenericCollectionItem<SdtTrn_MemoCategory>
   {
      public SdtTrn_MemoCategory_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_MemoCategory_RESTLInterface( SdtTrn_MemoCategory psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MemoCategoryName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Memocategoryname
      {
         get {
            return sdt.gxTpr_Memocategoryname ;
         }

         set {
            sdt.gxTpr_Memocategoryname = value;
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

      public SdtTrn_MemoCategory sdt
      {
         get {
            return (SdtTrn_MemoCategory)Sdt ;
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
            sdt = new SdtTrn_MemoCategory() ;
         }
      }

   }

}
