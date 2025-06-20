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
   [XmlRoot(ElementName = "Trn_Theme.CtaColor" )]
   [XmlType(TypeName =  "Trn_Theme.CtaColor" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Theme_CtaColor : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_Theme_CtaColor( )
      {
      }

      public SdtTrn_Theme_CtaColor( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"CtaColorId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CtaColor");
         metadata.Set("BT", "Trn_ThemeCtaColor");
         metadata.Set("PK", "[ \"CtaColorId\" ]");
         metadata.Set("PKAssigned", "[ \"CtaColorId\" ]");
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
         state.Add("gxTpr_Ctacolorid_Z");
         state.Add("gxTpr_Ctacolorname_Z");
         state.Add("gxTpr_Ctacolorcode_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Theme_CtaColor sdt;
         sdt = (SdtTrn_Theme_CtaColor)(source);
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorid = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorid ;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorname = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorname ;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode ;
         gxTv_SdtTrn_Theme_CtaColor_Mode = sdt.gxTv_SdtTrn_Theme_CtaColor_Mode ;
         gxTv_SdtTrn_Theme_CtaColor_Modified = sdt.gxTv_SdtTrn_Theme_CtaColor_Modified ;
         gxTv_SdtTrn_Theme_CtaColor_Initialized = sdt.gxTv_SdtTrn_Theme_CtaColor_Initialized ;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z ;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z ;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z ;
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
         AddObjectProperty("CtaColorId", gxTv_SdtTrn_Theme_CtaColor_Ctacolorid, false, includeNonInitialized);
         AddObjectProperty("CtaColorName", gxTv_SdtTrn_Theme_CtaColor_Ctacolorname, false, includeNonInitialized);
         AddObjectProperty("CtaColorCode", gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Theme_CtaColor_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_Theme_CtaColor_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Theme_CtaColor_Initialized, false, includeNonInitialized);
            AddObjectProperty("CtaColorId_Z", gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z, false, includeNonInitialized);
            AddObjectProperty("CtaColorName_Z", gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z, false, includeNonInitialized);
            AddObjectProperty("CtaColorCode_Z", gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Theme_CtaColor sdt )
      {
         if ( sdt.IsDirty("CtaColorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorid = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorid ;
         }
         if ( sdt.IsDirty("CtaColorName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorname = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorname ;
         }
         if ( sdt.IsDirty("CtaColorCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode = sdt.gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CtaColorId" )]
      [  XmlElement( ElementName = "CtaColorId"   )]
      public Guid gxTpr_Ctacolorid
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorid = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorid");
         }

      }

      [  SoapElement( ElementName = "CtaColorName" )]
      [  XmlElement( ElementName = "CtaColorName"   )]
      public string gxTpr_Ctacolorname
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorname = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorname");
         }

      }

      [  SoapElement( ElementName = "CtaColorCode" )]
      [  XmlElement( ElementName = "CtaColorCode"   )]
      public string gxTpr_Ctacolorcode
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorcode");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Mode_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Modified_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Initialized = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CtaColorId_Z" )]
      [  XmlElement( ElementName = "CtaColorId_Z"   )]
      public Guid gxTpr_Ctacolorid_Z
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorid_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z = Guid.Empty;
         SetDirty("Ctacolorid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CtaColorName_Z" )]
      [  XmlElement( ElementName = "CtaColorName_Z"   )]
      public string gxTpr_Ctacolorname_Z
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorname_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z = "";
         SetDirty("Ctacolorname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CtaColorCode_Z" )]
      [  XmlElement( ElementName = "CtaColorCode_Z"   )]
      public string gxTpr_Ctacolorcode_Z
      {
         get {
            return gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z = value;
            gxTv_SdtTrn_Theme_CtaColor_Modified = 1;
            SetDirty("Ctacolorcode_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z = "";
         SetDirty("Ctacolorcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z_IsNull( )
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
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorname = "";
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode = "";
         gxTv_SdtTrn_Theme_CtaColor_Mode = "";
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z = Guid.Empty;
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z = "";
         gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Theme_CtaColor_Modified ;
      private short gxTv_SdtTrn_Theme_CtaColor_Initialized ;
      private string gxTv_SdtTrn_Theme_CtaColor_Mode ;
      private string gxTv_SdtTrn_Theme_CtaColor_Ctacolorname ;
      private string gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode ;
      private string gxTv_SdtTrn_Theme_CtaColor_Ctacolorname_Z ;
      private string gxTv_SdtTrn_Theme_CtaColor_Ctacolorcode_Z ;
      private Guid gxTv_SdtTrn_Theme_CtaColor_Ctacolorid ;
      private Guid gxTv_SdtTrn_Theme_CtaColor_Ctacolorid_Z ;
   }

   [DataContract(Name = @"Trn_Theme.CtaColor", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_CtaColor_RESTInterface : GxGenericCollectionItem<SdtTrn_Theme_CtaColor>
   {
      public SdtTrn_Theme_CtaColor_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Theme_CtaColor_RESTInterface( SdtTrn_Theme_CtaColor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CtaColorId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Ctacolorid
      {
         get {
            return sdt.gxTpr_Ctacolorid ;
         }

         set {
            sdt.gxTpr_Ctacolorid = value;
         }

      }

      [DataMember( Name = "CtaColorName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ctacolorname
      {
         get {
            return sdt.gxTpr_Ctacolorname ;
         }

         set {
            sdt.gxTpr_Ctacolorname = value;
         }

      }

      [DataMember( Name = "CtaColorCode" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ctacolorcode
      {
         get {
            return sdt.gxTpr_Ctacolorcode ;
         }

         set {
            sdt.gxTpr_Ctacolorcode = value;
         }

      }

      public SdtTrn_Theme_CtaColor sdt
      {
         get {
            return (SdtTrn_Theme_CtaColor)Sdt ;
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
            sdt = new SdtTrn_Theme_CtaColor() ;
         }
      }

   }

   [DataContract(Name = @"Trn_Theme.CtaColor", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_CtaColor_RESTLInterface : GxGenericCollectionItem<SdtTrn_Theme_CtaColor>
   {
      public SdtTrn_Theme_CtaColor_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Theme_CtaColor_RESTLInterface( SdtTrn_Theme_CtaColor psdt ) : base(psdt)
      {
      }

      public SdtTrn_Theme_CtaColor sdt
      {
         get {
            return (SdtTrn_Theme_CtaColor)Sdt ;
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
            sdt = new SdtTrn_Theme_CtaColor() ;
         }
      }

   }

}
