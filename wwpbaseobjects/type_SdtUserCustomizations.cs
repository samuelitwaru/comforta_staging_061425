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
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlRoot(ElementName = "UserCustomizations" )]
   [XmlType(TypeName =  "UserCustomizations" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtUserCustomizations : GxSilentTrnSdt
   {
      public SdtUserCustomizations( )
      {
      }

      public SdtUserCustomizations( IGxContext context )
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

      public void Load( string AV244UserCustomizationsId ,
                        string AV245UserCustomizationsKey )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV244UserCustomizationsId,(string)AV245UserCustomizationsKey});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UserCustomizationsId", typeof(string)}, new Object[]{"UserCustomizationsKey", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\UserCustomizations");
         metadata.Set("BT", "UserCustomizations");
         metadata.Set("PK", "[ \"UserCustomizationsId\",\"UserCustomizationsKey\" ]");
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
         state.Add("gxTpr_Usercustomizationsid_Z");
         state.Add("gxTpr_Usercustomizationskey_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(source);
         gxTv_SdtUserCustomizations_Usercustomizationsid = sdt.gxTv_SdtUserCustomizations_Usercustomizationsid ;
         gxTv_SdtUserCustomizations_Usercustomizationskey = sdt.gxTv_SdtUserCustomizations_Usercustomizationskey ;
         gxTv_SdtUserCustomizations_Usercustomizationsvalue = sdt.gxTv_SdtUserCustomizations_Usercustomizationsvalue ;
         gxTv_SdtUserCustomizations_Mode = sdt.gxTv_SdtUserCustomizations_Mode ;
         gxTv_SdtUserCustomizations_Initialized = sdt.gxTv_SdtUserCustomizations_Initialized ;
         gxTv_SdtUserCustomizations_Usercustomizationsid_Z = sdt.gxTv_SdtUserCustomizations_Usercustomizationsid_Z ;
         gxTv_SdtUserCustomizations_Usercustomizationskey_Z = sdt.gxTv_SdtUserCustomizations_Usercustomizationskey_Z ;
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
         AddObjectProperty("UserCustomizationsId", gxTv_SdtUserCustomizations_Usercustomizationsid, false, includeNonInitialized);
         AddObjectProperty("UserCustomizationsKey", gxTv_SdtUserCustomizations_Usercustomizationskey, false, includeNonInitialized);
         AddObjectProperty("UserCustomizationsValue", gxTv_SdtUserCustomizations_Usercustomizationsvalue, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUserCustomizations_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUserCustomizations_Initialized, false, includeNonInitialized);
            AddObjectProperty("UserCustomizationsId_Z", gxTv_SdtUserCustomizations_Usercustomizationsid_Z, false, includeNonInitialized);
            AddObjectProperty("UserCustomizationsKey_Z", gxTv_SdtUserCustomizations_Usercustomizationskey_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations sdt )
      {
         if ( sdt.IsDirty("UserCustomizationsId") )
         {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationsid = sdt.gxTv_SdtUserCustomizations_Usercustomizationsid ;
         }
         if ( sdt.IsDirty("UserCustomizationsKey") )
         {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationskey = sdt.gxTv_SdtUserCustomizations_Usercustomizationskey ;
         }
         if ( sdt.IsDirty("UserCustomizationsValue") )
         {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationsvalue = sdt.gxTv_SdtUserCustomizations_Usercustomizationsvalue ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UserCustomizationsId" )]
      [  XmlElement( ElementName = "UserCustomizationsId"   )]
      public string gxTpr_Usercustomizationsid
      {
         get {
            return gxTv_SdtUserCustomizations_Usercustomizationsid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtUserCustomizations_Usercustomizationsid, value) != 0 )
            {
               gxTv_SdtUserCustomizations_Mode = "INS";
               this.gxTv_SdtUserCustomizations_Usercustomizationsid_Z_SetNull( );
               this.gxTv_SdtUserCustomizations_Usercustomizationskey_Z_SetNull( );
            }
            gxTv_SdtUserCustomizations_Usercustomizationsid = value;
            SetDirty("Usercustomizationsid");
         }

      }

      [  SoapElement( ElementName = "UserCustomizationsKey" )]
      [  XmlElement( ElementName = "UserCustomizationsKey"   )]
      public string gxTpr_Usercustomizationskey
      {
         get {
            return gxTv_SdtUserCustomizations_Usercustomizationskey ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtUserCustomizations_Usercustomizationskey, value) != 0 )
            {
               gxTv_SdtUserCustomizations_Mode = "INS";
               this.gxTv_SdtUserCustomizations_Usercustomizationsid_Z_SetNull( );
               this.gxTv_SdtUserCustomizations_Usercustomizationskey_Z_SetNull( );
            }
            gxTv_SdtUserCustomizations_Usercustomizationskey = value;
            SetDirty("Usercustomizationskey");
         }

      }

      [  SoapElement( ElementName = "UserCustomizationsValue" )]
      [  XmlElement( ElementName = "UserCustomizationsValue"   )]
      public string gxTpr_Usercustomizationsvalue
      {
         get {
            return gxTv_SdtUserCustomizations_Usercustomizationsvalue ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationsvalue = value;
            SetDirty("Usercustomizationsvalue");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUserCustomizations_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUserCustomizations_Mode_SetNull( )
      {
         gxTv_SdtUserCustomizations_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUserCustomizations_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUserCustomizations_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUserCustomizations_Initialized_SetNull( )
      {
         gxTv_SdtUserCustomizations_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUserCustomizations_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserCustomizationsId_Z" )]
      [  XmlElement( ElementName = "UserCustomizationsId_Z"   )]
      public string gxTpr_Usercustomizationsid_Z
      {
         get {
            return gxTv_SdtUserCustomizations_Usercustomizationsid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationsid_Z = value;
            SetDirty("Usercustomizationsid_Z");
         }

      }

      public void gxTv_SdtUserCustomizations_Usercustomizationsid_Z_SetNull( )
      {
         gxTv_SdtUserCustomizations_Usercustomizationsid_Z = "";
         SetDirty("Usercustomizationsid_Z");
         return  ;
      }

      public bool gxTv_SdtUserCustomizations_Usercustomizationsid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserCustomizationsKey_Z" )]
      [  XmlElement( ElementName = "UserCustomizationsKey_Z"   )]
      public string gxTpr_Usercustomizationskey_Z
      {
         get {
            return gxTv_SdtUserCustomizations_Usercustomizationskey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserCustomizations_Usercustomizationskey_Z = value;
            SetDirty("Usercustomizationskey_Z");
         }

      }

      public void gxTv_SdtUserCustomizations_Usercustomizationskey_Z_SetNull( )
      {
         gxTv_SdtUserCustomizations_Usercustomizationskey_Z = "";
         SetDirty("Usercustomizationskey_Z");
         return  ;
      }

      public bool gxTv_SdtUserCustomizations_Usercustomizationskey_Z_IsNull( )
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
         gxTv_SdtUserCustomizations_Usercustomizationsid = "";
         sdtIsNull = 1;
         gxTv_SdtUserCustomizations_Usercustomizationskey = "";
         gxTv_SdtUserCustomizations_Usercustomizationsvalue = "";
         gxTv_SdtUserCustomizations_Mode = "";
         gxTv_SdtUserCustomizations_Usercustomizationsid_Z = "";
         gxTv_SdtUserCustomizations_Usercustomizationskey_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.usercustomizations", "GeneXus.Programs.wwpbaseobjects.usercustomizations_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtUserCustomizations_Initialized ;
      private string gxTv_SdtUserCustomizations_Usercustomizationsid ;
      private string gxTv_SdtUserCustomizations_Mode ;
      private string gxTv_SdtUserCustomizations_Usercustomizationsid_Z ;
      private string gxTv_SdtUserCustomizations_Usercustomizationsvalue ;
      private string gxTv_SdtUserCustomizations_Usercustomizationskey ;
      private string gxTv_SdtUserCustomizations_Usercustomizationskey_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\UserCustomizations", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtUserCustomizations_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations>
   {
      public SdtUserCustomizations_RESTInterface( ) : base()
      {
      }

      public SdtUserCustomizations_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserCustomizationsId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usercustomizationsid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usercustomizationsid) ;
         }

         set {
            sdt.gxTpr_Usercustomizationsid = value;
         }

      }

      [DataMember( Name = "UserCustomizationsKey" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Usercustomizationskey
      {
         get {
            return sdt.gxTpr_Usercustomizationskey ;
         }

         set {
            sdt.gxTpr_Usercustomizationskey = value;
         }

      }

      [DataMember( Name = "UserCustomizationsValue" , Order = 2 )]
      public string gxTpr_Usercustomizationsvalue
      {
         get {
            return sdt.gxTpr_Usercustomizationsvalue ;
         }

         set {
            sdt.gxTpr_Usercustomizationsvalue = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations() ;
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

   [DataContract(Name = @"WWPBaseObjects\UserCustomizations", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtUserCustomizations_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations>
   {
      public SdtUserCustomizations_RESTLInterface( ) : base()
      {
      }

      public SdtUserCustomizations_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserCustomizationsKey" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usercustomizationskey
      {
         get {
            return sdt.gxTpr_Usercustomizationskey ;
         }

         set {
            sdt.gxTpr_Usercustomizationskey = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/WWPBaseObjects\\UserCustomizations/{0},{1}";
            gxuri = String.Format(gxuri,gxTpr_Usercustomizationskey) ;
            return gxuri ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations() ;
         }
      }

      private string gxuri ;
   }

}
