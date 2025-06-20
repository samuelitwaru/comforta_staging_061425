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
   [XmlRoot(ElementName = "Trn_Theme.Icon" )]
   [XmlType(TypeName =  "Trn_Theme.Icon" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Theme_Icon : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTrn_Theme_Icon( )
      {
      }

      public SdtTrn_Theme_Icon( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"IconId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Icon");
         metadata.Set("BT", "Trn_ThemeIcon");
         metadata.Set("PK", "[ \"IconId\" ]");
         metadata.Set("PKAssigned", "[ \"IconId\" ]");
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
         state.Add("gxTpr_Iconid_Z");
         state.Add("gxTpr_Iconcategory_Z");
         state.Add("gxTpr_Iconname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Theme_Icon sdt;
         sdt = (SdtTrn_Theme_Icon)(source);
         gxTv_SdtTrn_Theme_Icon_Iconid = sdt.gxTv_SdtTrn_Theme_Icon_Iconid ;
         gxTv_SdtTrn_Theme_Icon_Iconcategory = sdt.gxTv_SdtTrn_Theme_Icon_Iconcategory ;
         gxTv_SdtTrn_Theme_Icon_Iconname = sdt.gxTv_SdtTrn_Theme_Icon_Iconname ;
         gxTv_SdtTrn_Theme_Icon_Icontags = sdt.gxTv_SdtTrn_Theme_Icon_Icontags ;
         gxTv_SdtTrn_Theme_Icon_Iconsvg = sdt.gxTv_SdtTrn_Theme_Icon_Iconsvg ;
         gxTv_SdtTrn_Theme_Icon_Mode = sdt.gxTv_SdtTrn_Theme_Icon_Mode ;
         gxTv_SdtTrn_Theme_Icon_Modified = sdt.gxTv_SdtTrn_Theme_Icon_Modified ;
         gxTv_SdtTrn_Theme_Icon_Initialized = sdt.gxTv_SdtTrn_Theme_Icon_Initialized ;
         gxTv_SdtTrn_Theme_Icon_Iconid_Z = sdt.gxTv_SdtTrn_Theme_Icon_Iconid_Z ;
         gxTv_SdtTrn_Theme_Icon_Iconcategory_Z = sdt.gxTv_SdtTrn_Theme_Icon_Iconcategory_Z ;
         gxTv_SdtTrn_Theme_Icon_Iconname_Z = sdt.gxTv_SdtTrn_Theme_Icon_Iconname_Z ;
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
         AddObjectProperty("IconId", gxTv_SdtTrn_Theme_Icon_Iconid, false, includeNonInitialized);
         AddObjectProperty("IconCategory", gxTv_SdtTrn_Theme_Icon_Iconcategory, false, includeNonInitialized);
         AddObjectProperty("IconName", gxTv_SdtTrn_Theme_Icon_Iconname, false, includeNonInitialized);
         AddObjectProperty("IconTags", gxTv_SdtTrn_Theme_Icon_Icontags, false, includeNonInitialized);
         AddObjectProperty("IconSVG", gxTv_SdtTrn_Theme_Icon_Iconsvg, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Theme_Icon_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTrn_Theme_Icon_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Theme_Icon_Initialized, false, includeNonInitialized);
            AddObjectProperty("IconId_Z", gxTv_SdtTrn_Theme_Icon_Iconid_Z, false, includeNonInitialized);
            AddObjectProperty("IconCategory_Z", gxTv_SdtTrn_Theme_Icon_Iconcategory_Z, false, includeNonInitialized);
            AddObjectProperty("IconName_Z", gxTv_SdtTrn_Theme_Icon_Iconname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Theme_Icon sdt )
      {
         if ( sdt.IsDirty("IconId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconid = sdt.gxTv_SdtTrn_Theme_Icon_Iconid ;
         }
         if ( sdt.IsDirty("IconCategory") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconcategory = sdt.gxTv_SdtTrn_Theme_Icon_Iconcategory ;
         }
         if ( sdt.IsDirty("IconName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconname = sdt.gxTv_SdtTrn_Theme_Icon_Iconname ;
         }
         if ( sdt.IsDirty("IconTags") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Icontags = sdt.gxTv_SdtTrn_Theme_Icon_Icontags ;
         }
         if ( sdt.IsDirty("IconSVG") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconsvg = sdt.gxTv_SdtTrn_Theme_Icon_Iconsvg ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "IconId" )]
      [  XmlElement( ElementName = "IconId"   )]
      public Guid gxTpr_Iconid
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconid = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconid");
         }

      }

      [  SoapElement( ElementName = "IconCategory" )]
      [  XmlElement( ElementName = "IconCategory"   )]
      public string gxTpr_Iconcategory
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconcategory ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconcategory = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconcategory");
         }

      }

      [  SoapElement( ElementName = "IconName" )]
      [  XmlElement( ElementName = "IconName"   )]
      public string gxTpr_Iconname
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconname = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconname");
         }

      }

      [  SoapElement( ElementName = "IconTags" )]
      [  XmlElement( ElementName = "IconTags"   )]
      public string gxTpr_Icontags
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Icontags ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Icontags = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Icontags");
         }

      }

      [  SoapElement( ElementName = "IconSVG" )]
      [  XmlElement( ElementName = "IconSVG"   )]
      public string gxTpr_Iconsvg
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconsvg ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconsvg = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconsvg");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Mode_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Modified_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Initialized = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IconId_Z" )]
      [  XmlElement( ElementName = "IconId_Z"   )]
      public Guid gxTpr_Iconid_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconid_Z = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconid_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Iconid_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Iconid_Z = Guid.Empty;
         SetDirty("Iconid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Iconid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IconCategory_Z" )]
      [  XmlElement( ElementName = "IconCategory_Z"   )]
      public string gxTpr_Iconcategory_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconcategory_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconcategory_Z = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconcategory_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Iconcategory_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Iconcategory_Z = "";
         SetDirty("Iconcategory_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Iconcategory_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IconName_Z" )]
      [  XmlElement( ElementName = "IconName_Z"   )]
      public string gxTpr_Iconname_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Icon_Iconname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon_Iconname_Z = value;
            gxTv_SdtTrn_Theme_Icon_Modified = 1;
            SetDirty("Iconname_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_Iconname_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon_Iconname_Z = "";
         SetDirty("Iconname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_Iconname_Z_IsNull( )
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
         gxTv_SdtTrn_Theme_Icon_Iconid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Theme_Icon_Iconcategory = "";
         gxTv_SdtTrn_Theme_Icon_Iconname = "";
         gxTv_SdtTrn_Theme_Icon_Icontags = "";
         gxTv_SdtTrn_Theme_Icon_Iconsvg = "";
         gxTv_SdtTrn_Theme_Icon_Mode = "";
         gxTv_SdtTrn_Theme_Icon_Iconid_Z = Guid.Empty;
         gxTv_SdtTrn_Theme_Icon_Iconcategory_Z = "";
         gxTv_SdtTrn_Theme_Icon_Iconname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Theme_Icon_Modified ;
      private short gxTv_SdtTrn_Theme_Icon_Initialized ;
      private string gxTv_SdtTrn_Theme_Icon_Mode ;
      private string gxTv_SdtTrn_Theme_Icon_Icontags ;
      private string gxTv_SdtTrn_Theme_Icon_Iconsvg ;
      private string gxTv_SdtTrn_Theme_Icon_Iconcategory ;
      private string gxTv_SdtTrn_Theme_Icon_Iconname ;
      private string gxTv_SdtTrn_Theme_Icon_Iconcategory_Z ;
      private string gxTv_SdtTrn_Theme_Icon_Iconname_Z ;
      private Guid gxTv_SdtTrn_Theme_Icon_Iconid ;
      private Guid gxTv_SdtTrn_Theme_Icon_Iconid_Z ;
   }

   [DataContract(Name = @"Trn_Theme.Icon", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_Icon_RESTInterface : GxGenericCollectionItem<SdtTrn_Theme_Icon>
   {
      public SdtTrn_Theme_Icon_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Theme_Icon_RESTInterface( SdtTrn_Theme_Icon psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "IconId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Iconid
      {
         get {
            return sdt.gxTpr_Iconid ;
         }

         set {
            sdt.gxTpr_Iconid = value;
         }

      }

      [DataMember( Name = "IconCategory" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Iconcategory
      {
         get {
            return sdt.gxTpr_Iconcategory ;
         }

         set {
            sdt.gxTpr_Iconcategory = value;
         }

      }

      [DataMember( Name = "IconName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Iconname
      {
         get {
            return sdt.gxTpr_Iconname ;
         }

         set {
            sdt.gxTpr_Iconname = value;
         }

      }

      [DataMember( Name = "IconTags" , Order = 3 )]
      public string gxTpr_Icontags
      {
         get {
            return sdt.gxTpr_Icontags ;
         }

         set {
            sdt.gxTpr_Icontags = value;
         }

      }

      [DataMember( Name = "IconSVG" , Order = 4 )]
      public string gxTpr_Iconsvg
      {
         get {
            return sdt.gxTpr_Iconsvg ;
         }

         set {
            sdt.gxTpr_Iconsvg = value;
         }

      }

      public SdtTrn_Theme_Icon sdt
      {
         get {
            return (SdtTrn_Theme_Icon)Sdt ;
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
            sdt = new SdtTrn_Theme_Icon() ;
         }
      }

   }

   [DataContract(Name = @"Trn_Theme.Icon", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_Icon_RESTLInterface : GxGenericCollectionItem<SdtTrn_Theme_Icon>
   {
      public SdtTrn_Theme_Icon_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Theme_Icon_RESTLInterface( SdtTrn_Theme_Icon psdt ) : base(psdt)
      {
      }

      public SdtTrn_Theme_Icon sdt
      {
         get {
            return (SdtTrn_Theme_Icon)Sdt ;
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
            sdt = new SdtTrn_Theme_Icon() ;
         }
      }

   }

}
