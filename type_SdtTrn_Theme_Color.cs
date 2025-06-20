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
   [XmlRoot(ElementName = "Trn_Theme.Color" )]
   [XmlType(TypeName =  "Trn_Theme.Color" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Theme_Color : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_Theme_Color( )
      {
      }

      public SdtTrn_Theme_Color( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ColorId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Color");
         metadata.Set("BT", "Trn_ThemeColor");
         metadata.Set("PK", "[ \"ColorId\" ]");
         metadata.Set("PKAssigned", "[ \"ColorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"Trn_ThemeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Colorid_Z");
         state.Add("gxTpr_Colorname_Z");
         state.Add("gxTpr_Colorcode_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Theme_Color sdt;
         sdt = (SdtTrn_Theme_Color)(source);
         gxTv_SdtTrn_Theme_Color_Colorid = sdt.gxTv_SdtTrn_Theme_Color_Colorid ;
         gxTv_SdtTrn_Theme_Color_Colorname = sdt.gxTv_SdtTrn_Theme_Color_Colorname ;
         gxTv_SdtTrn_Theme_Color_Colorcode = sdt.gxTv_SdtTrn_Theme_Color_Colorcode ;
         gxTv_SdtTrn_Theme_Color_Mode = sdt.gxTv_SdtTrn_Theme_Color_Mode ;
         gxTv_SdtTrn_Theme_Color_Modified = sdt.gxTv_SdtTrn_Theme_Color_Modified ;
         gxTv_SdtTrn_Theme_Color_Initialized = sdt.gxTv_SdtTrn_Theme_Color_Initialized ;
         gxTv_SdtTrn_Theme_Color_Colorid_Z = sdt.gxTv_SdtTrn_Theme_Color_Colorid_Z ;
         gxTv_SdtTrn_Theme_Color_Colorname_Z = sdt.gxTv_SdtTrn_Theme_Color_Colorname_Z ;
         gxTv_SdtTrn_Theme_Color_Colorcode_Z = sdt.gxTv_SdtTrn_Theme_Color_Colorcode_Z ;
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
         AddObjectProperty("ColorId", gxTv_SdtTrn_Theme_Color_Colorid, false, includeNonInitialized);
         AddObjectProperty("ColorName", gxTv_SdtTrn_Theme_Color_Colorname, false, includeNonInitialized);
         AddObjectProperty("ColorCode", gxTv_SdtTrn_Theme_Color_Colorcode, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Theme_Color_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_Theme_Color_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Theme_Color_Initialized, false, includeNonInitialized);
            AddObjectProperty("ColorId_Z", gxTv_SdtTrn_Theme_Color_Colorid_Z, false, includeNonInitialized);
            AddObjectProperty("ColorName_Z", gxTv_SdtTrn_Theme_Color_Colorname_Z, false, includeNonInitialized);
            AddObjectProperty("ColorCode_Z", gxTv_SdtTrn_Theme_Color_Colorcode_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Theme_Color sdt )
      {
         if ( sdt.IsDirty("ColorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorid = sdt.gxTv_SdtTrn_Theme_Color_Colorid ;
         }
         if ( sdt.IsDirty("ColorName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorname = sdt.gxTv_SdtTrn_Theme_Color_Colorname ;
         }
         if ( sdt.IsDirty("ColorCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorcode = sdt.gxTv_SdtTrn_Theme_Color_Colorcode ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ColorId" )]
      [  XmlElement( ElementName = "ColorId"   )]
      public Guid gxTpr_Colorid
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorid = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorid");
         }

      }

      [  SoapElement( ElementName = "ColorName" )]
      [  XmlElement( ElementName = "ColorName"   )]
      public string gxTpr_Colorname
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorname = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorname");
         }

      }

      [  SoapElement( ElementName = "ColorCode" )]
      [  XmlElement( ElementName = "ColorCode"   )]
      public string gxTpr_Colorcode
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorcode = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorcode");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Mode_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Modified_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Initialized = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ColorId_Z" )]
      [  XmlElement( ElementName = "ColorId_Z"   )]
      public Guid gxTpr_Colorid_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorid_Z = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorid_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Colorid_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Colorid_Z = Guid.Empty;
         SetDirty("Colorid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Colorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ColorName_Z" )]
      [  XmlElement( ElementName = "ColorName_Z"   )]
      public string gxTpr_Colorname_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorname_Z = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorname_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Colorname_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Colorname_Z = "";
         SetDirty("Colorname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Colorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ColorCode_Z" )]
      [  XmlElement( ElementName = "ColorCode_Z"   )]
      public string gxTpr_Colorcode_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Color_Colorcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color_Colorcode_Z = value;
            gxTv_SdtTrn_Theme_Color_Modified = 1;
            SetDirty("Colorcode_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_Colorcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color_Colorcode_Z = "";
         SetDirty("Colorcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_Colorcode_Z_IsNull( )
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
         gxTv_SdtTrn_Theme_Color_Colorid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Theme_Color_Colorname = "";
         gxTv_SdtTrn_Theme_Color_Colorcode = "";
         gxTv_SdtTrn_Theme_Color_Mode = "";
         gxTv_SdtTrn_Theme_Color_Colorid_Z = Guid.Empty;
         gxTv_SdtTrn_Theme_Color_Colorname_Z = "";
         gxTv_SdtTrn_Theme_Color_Colorcode_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Theme_Color_Modified ;
      private short gxTv_SdtTrn_Theme_Color_Initialized ;
      private string gxTv_SdtTrn_Theme_Color_Mode ;
      private string gxTv_SdtTrn_Theme_Color_Colorname ;
      private string gxTv_SdtTrn_Theme_Color_Colorcode ;
      private string gxTv_SdtTrn_Theme_Color_Colorname_Z ;
      private string gxTv_SdtTrn_Theme_Color_Colorcode_Z ;
      private Guid gxTv_SdtTrn_Theme_Color_Colorid ;
      private Guid gxTv_SdtTrn_Theme_Color_Colorid_Z ;
   }

   [DataContract(Name = @"Trn_Theme.Color", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_Color_RESTInterface : GxGenericCollectionItem<SdtTrn_Theme_Color>
   {
      public SdtTrn_Theme_Color_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Theme_Color_RESTInterface( SdtTrn_Theme_Color psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ColorId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Colorid
      {
         get {
            return sdt.gxTpr_Colorid ;
         }

         set {
            sdt.gxTpr_Colorid = value;
         }

      }

      [DataMember( Name = "ColorName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Colorname
      {
         get {
            return sdt.gxTpr_Colorname ;
         }

         set {
            sdt.gxTpr_Colorname = value;
         }

      }

      [DataMember( Name = "ColorCode" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Colorcode
      {
         get {
            return sdt.gxTpr_Colorcode ;
         }

         set {
            sdt.gxTpr_Colorcode = value;
         }

      }

      public SdtTrn_Theme_Color sdt
      {
         get {
            return (SdtTrn_Theme_Color)Sdt ;
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
            sdt = new SdtTrn_Theme_Color() ;
         }
      }

   }

   [DataContract(Name = @"Trn_Theme.Color", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_Color_RESTLInterface : GxGenericCollectionItem<SdtTrn_Theme_Color>
   {
      public SdtTrn_Theme_Color_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Theme_Color_RESTLInterface( SdtTrn_Theme_Color psdt ) : base(psdt)
      {
      }

      public SdtTrn_Theme_Color sdt
      {
         get {
            return (SdtTrn_Theme_Color)Sdt ;
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
            sdt = new SdtTrn_Theme_Color() ;
         }
      }

   }

}
