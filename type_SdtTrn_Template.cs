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
   [XmlRoot(ElementName = "Trn_Template" )]
   [XmlType(TypeName =  "Trn_Template" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Template : GxSilentTrnSdt
   {
      public SdtTrn_Template( )
      {
      }

      public SdtTrn_Template( IGxContext context )
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

      public void Load( Guid AV299Trn_TemplateId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV299Trn_TemplateId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_TemplateId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Template");
         metadata.Set("BT", "Trn_Template");
         metadata.Set("PK", "[ \"Trn_TemplateId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_TemplateId\" ]");
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
         state.Add("gxTpr_Trn_templateid_Z");
         state.Add("gxTpr_Trn_templatename_Z");
         state.Add("gxTpr_Trn_templatemedia_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Template sdt;
         sdt = (SdtTrn_Template)(source);
         gxTv_SdtTrn_Template_Trn_templateid = sdt.gxTv_SdtTrn_Template_Trn_templateid ;
         gxTv_SdtTrn_Template_Trn_templatename = sdt.gxTv_SdtTrn_Template_Trn_templatename ;
         gxTv_SdtTrn_Template_Trn_templatemedia = sdt.gxTv_SdtTrn_Template_Trn_templatemedia ;
         gxTv_SdtTrn_Template_Trn_templatecontent = sdt.gxTv_SdtTrn_Template_Trn_templatecontent ;
         gxTv_SdtTrn_Template_Mode = sdt.gxTv_SdtTrn_Template_Mode ;
         gxTv_SdtTrn_Template_Initialized = sdt.gxTv_SdtTrn_Template_Initialized ;
         gxTv_SdtTrn_Template_Trn_templateid_Z = sdt.gxTv_SdtTrn_Template_Trn_templateid_Z ;
         gxTv_SdtTrn_Template_Trn_templatename_Z = sdt.gxTv_SdtTrn_Template_Trn_templatename_Z ;
         gxTv_SdtTrn_Template_Trn_templatemedia_Z = sdt.gxTv_SdtTrn_Template_Trn_templatemedia_Z ;
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
         AddObjectProperty("Trn_TemplateId", gxTv_SdtTrn_Template_Trn_templateid, false, includeNonInitialized);
         AddObjectProperty("Trn_TemplateName", gxTv_SdtTrn_Template_Trn_templatename, false, includeNonInitialized);
         AddObjectProperty("Trn_TemplateMedia", gxTv_SdtTrn_Template_Trn_templatemedia, false, includeNonInitialized);
         AddObjectProperty("Trn_TemplateContent", gxTv_SdtTrn_Template_Trn_templatecontent, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Template_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Template_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_TemplateId_Z", gxTv_SdtTrn_Template_Trn_templateid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TemplateName_Z", gxTv_SdtTrn_Template_Trn_templatename_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TemplateMedia_Z", gxTv_SdtTrn_Template_Trn_templatemedia_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Template sdt )
      {
         if ( sdt.IsDirty("Trn_TemplateId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templateid = sdt.gxTv_SdtTrn_Template_Trn_templateid ;
         }
         if ( sdt.IsDirty("Trn_TemplateName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatename = sdt.gxTv_SdtTrn_Template_Trn_templatename ;
         }
         if ( sdt.IsDirty("Trn_TemplateMedia") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatemedia = sdt.gxTv_SdtTrn_Template_Trn_templatemedia ;
         }
         if ( sdt.IsDirty("Trn_TemplateContent") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatecontent = sdt.gxTv_SdtTrn_Template_Trn_templatecontent ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_TemplateId" )]
      [  XmlElement( ElementName = "Trn_TemplateId"   )]
      public Guid gxTpr_Trn_templateid
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templateid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Template_Trn_templateid != value )
            {
               gxTv_SdtTrn_Template_Mode = "INS";
               this.gxTv_SdtTrn_Template_Trn_templateid_Z_SetNull( );
               this.gxTv_SdtTrn_Template_Trn_templatename_Z_SetNull( );
               this.gxTv_SdtTrn_Template_Trn_templatemedia_Z_SetNull( );
            }
            gxTv_SdtTrn_Template_Trn_templateid = value;
            SetDirty("Trn_templateid");
         }

      }

      [  SoapElement( ElementName = "Trn_TemplateName" )]
      [  XmlElement( ElementName = "Trn_TemplateName"   )]
      public string gxTpr_Trn_templatename
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templatename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatename = value;
            SetDirty("Trn_templatename");
         }

      }

      [  SoapElement( ElementName = "Trn_TemplateMedia" )]
      [  XmlElement( ElementName = "Trn_TemplateMedia"   )]
      public string gxTpr_Trn_templatemedia
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templatemedia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatemedia = value;
            SetDirty("Trn_templatemedia");
         }

      }

      [  SoapElement( ElementName = "Trn_TemplateContent" )]
      [  XmlElement( ElementName = "Trn_TemplateContent"   )]
      public string gxTpr_Trn_templatecontent
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templatecontent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatecontent = value;
            SetDirty("Trn_templatecontent");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Template_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Template_Mode_SetNull( )
      {
         gxTv_SdtTrn_Template_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Template_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Template_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Template_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Template_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Template_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TemplateId_Z" )]
      [  XmlElement( ElementName = "Trn_TemplateId_Z"   )]
      public Guid gxTpr_Trn_templateid_Z
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templateid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templateid_Z = value;
            SetDirty("Trn_templateid_Z");
         }

      }

      public void gxTv_SdtTrn_Template_Trn_templateid_Z_SetNull( )
      {
         gxTv_SdtTrn_Template_Trn_templateid_Z = Guid.Empty;
         SetDirty("Trn_templateid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Template_Trn_templateid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TemplateName_Z" )]
      [  XmlElement( ElementName = "Trn_TemplateName_Z"   )]
      public string gxTpr_Trn_templatename_Z
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templatename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatename_Z = value;
            SetDirty("Trn_templatename_Z");
         }

      }

      public void gxTv_SdtTrn_Template_Trn_templatename_Z_SetNull( )
      {
         gxTv_SdtTrn_Template_Trn_templatename_Z = "";
         SetDirty("Trn_templatename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Template_Trn_templatename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TemplateMedia_Z" )]
      [  XmlElement( ElementName = "Trn_TemplateMedia_Z"   )]
      public string gxTpr_Trn_templatemedia_Z
      {
         get {
            return gxTv_SdtTrn_Template_Trn_templatemedia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Template_Trn_templatemedia_Z = value;
            SetDirty("Trn_templatemedia_Z");
         }

      }

      public void gxTv_SdtTrn_Template_Trn_templatemedia_Z_SetNull( )
      {
         gxTv_SdtTrn_Template_Trn_templatemedia_Z = "";
         SetDirty("Trn_templatemedia_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Template_Trn_templatemedia_Z_IsNull( )
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
         gxTv_SdtTrn_Template_Trn_templateid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Template_Trn_templatename = "";
         gxTv_SdtTrn_Template_Trn_templatemedia = "";
         gxTv_SdtTrn_Template_Trn_templatecontent = "";
         gxTv_SdtTrn_Template_Mode = "";
         gxTv_SdtTrn_Template_Trn_templateid_Z = Guid.Empty;
         gxTv_SdtTrn_Template_Trn_templatename_Z = "";
         gxTv_SdtTrn_Template_Trn_templatemedia_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_template", "GeneXus.Programs.trn_template_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Template_Initialized ;
      private string gxTv_SdtTrn_Template_Mode ;
      private string gxTv_SdtTrn_Template_Trn_templatecontent ;
      private string gxTv_SdtTrn_Template_Trn_templatename ;
      private string gxTv_SdtTrn_Template_Trn_templatemedia ;
      private string gxTv_SdtTrn_Template_Trn_templatename_Z ;
      private string gxTv_SdtTrn_Template_Trn_templatemedia_Z ;
      private Guid gxTv_SdtTrn_Template_Trn_templateid ;
      private Guid gxTv_SdtTrn_Template_Trn_templateid_Z ;
   }

   [DataContract(Name = @"Trn_Template", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Template_RESTInterface : GxGenericCollectionItem<SdtTrn_Template>
   {
      public SdtTrn_Template_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Template_RESTInterface( SdtTrn_Template psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_TemplateId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_templateid
      {
         get {
            return sdt.gxTpr_Trn_templateid ;
         }

         set {
            sdt.gxTpr_Trn_templateid = value;
         }

      }

      [DataMember( Name = "Trn_TemplateName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_templatename
      {
         get {
            return sdt.gxTpr_Trn_templatename ;
         }

         set {
            sdt.gxTpr_Trn_templatename = value;
         }

      }

      [DataMember( Name = "Trn_TemplateMedia" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Trn_templatemedia
      {
         get {
            return sdt.gxTpr_Trn_templatemedia ;
         }

         set {
            sdt.gxTpr_Trn_templatemedia = value;
         }

      }

      [DataMember( Name = "Trn_TemplateContent" , Order = 3 )]
      public string gxTpr_Trn_templatecontent
      {
         get {
            return sdt.gxTpr_Trn_templatecontent ;
         }

         set {
            sdt.gxTpr_Trn_templatecontent = value;
         }

      }

      public SdtTrn_Template sdt
      {
         get {
            return (SdtTrn_Template)Sdt ;
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
            sdt = new SdtTrn_Template() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Trn_Template", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Template_RESTLInterface : GxGenericCollectionItem<SdtTrn_Template>
   {
      public SdtTrn_Template_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Template_RESTLInterface( SdtTrn_Template psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_TemplateName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_templatename
      {
         get {
            return sdt.gxTpr_Trn_templatename ;
         }

         set {
            sdt.gxTpr_Trn_templatename = value;
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

      public SdtTrn_Template sdt
      {
         get {
            return (SdtTrn_Template)Sdt ;
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
            sdt = new SdtTrn_Template() ;
         }
      }

   }

}
