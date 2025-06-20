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
   [XmlRoot(ElementName = "UForm.Element" )]
   [XmlType(TypeName =  "UForm.Element" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtUForm_Element : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtUForm_Element( )
      {
      }

      public SdtUForm_Element( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"WWPFormElementId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Element");
         metadata.Set("BT", "WWP_FormElement");
         metadata.Set("PK", "[ \"WWPFormElementId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPFormId\",\"WWPFormVersionNumber\",\"WWPFormElementId\" ],\"FKMap\":[ \"WWPFormElementParentId-WWPFormElementId\" ] } ]");
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
         state.Add("gxTpr_Wwpformelementid_Z");
         state.Add("gxTpr_Wwpformelementtype_Z");
         state.Add("gxTpr_Wwpformelementorderindex_Z");
         state.Add("gxTpr_Wwpformelementdatatype_Z");
         state.Add("gxTpr_Wwpformelementparentid_Z");
         state.Add("gxTpr_Wwpformelementparenttype_Z");
         state.Add("gxTpr_Wwpformelementcaption_Z");
         state.Add("gxTpr_Wwpformelementreferenceid_Z");
         state.Add("gxTpr_Wwpformelementexcludefromexport_Z");
         state.Add("gxTpr_Wwpformelementparentid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUForm_Element sdt;
         sdt = (SdtUForm_Element)(source);
         gxTv_SdtUForm_Element_Wwpformelementid = sdt.gxTv_SdtUForm_Element_Wwpformelementid ;
         gxTv_SdtUForm_Element_Wwpformelementtitle = sdt.gxTv_SdtUForm_Element_Wwpformelementtitle ;
         gxTv_SdtUForm_Element_Wwpformelementtype = sdt.gxTv_SdtUForm_Element_Wwpformelementtype ;
         gxTv_SdtUForm_Element_Wwpformelementorderindex = sdt.gxTv_SdtUForm_Element_Wwpformelementorderindex ;
         gxTv_SdtUForm_Element_Wwpformelementdatatype = sdt.gxTv_SdtUForm_Element_Wwpformelementdatatype ;
         gxTv_SdtUForm_Element_Wwpformelementparentid = sdt.gxTv_SdtUForm_Element_Wwpformelementparentid ;
         gxTv_SdtUForm_Element_Wwpformelementparentname = sdt.gxTv_SdtUForm_Element_Wwpformelementparentname ;
         gxTv_SdtUForm_Element_Wwpformelementparenttype = sdt.gxTv_SdtUForm_Element_Wwpformelementparenttype ;
         gxTv_SdtUForm_Element_Wwpformelementmetadata = sdt.gxTv_SdtUForm_Element_Wwpformelementmetadata ;
         gxTv_SdtUForm_Element_Wwpformelementcaption = sdt.gxTv_SdtUForm_Element_Wwpformelementcaption ;
         gxTv_SdtUForm_Element_Wwpformelementreferenceid = sdt.gxTv_SdtUForm_Element_Wwpformelementreferenceid ;
         gxTv_SdtUForm_Element_Wwpformelementexcludefromexport = sdt.gxTv_SdtUForm_Element_Wwpformelementexcludefromexport ;
         gxTv_SdtUForm_Element_Mode = sdt.gxTv_SdtUForm_Element_Mode ;
         gxTv_SdtUForm_Element_Modified = sdt.gxTv_SdtUForm_Element_Modified ;
         gxTv_SdtUForm_Element_Initialized = sdt.gxTv_SdtUForm_Element_Initialized ;
         gxTv_SdtUForm_Element_Wwpformelementid_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementid_Z ;
         gxTv_SdtUForm_Element_Wwpformelementtype_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementtype_Z ;
         gxTv_SdtUForm_Element_Wwpformelementorderindex_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementorderindex_Z ;
         gxTv_SdtUForm_Element_Wwpformelementdatatype_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementdatatype_Z ;
         gxTv_SdtUForm_Element_Wwpformelementparentid_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementparentid_Z ;
         gxTv_SdtUForm_Element_Wwpformelementparenttype_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementparenttype_Z ;
         gxTv_SdtUForm_Element_Wwpformelementcaption_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementcaption_Z ;
         gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z ;
         gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z = sdt.gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z ;
         gxTv_SdtUForm_Element_Wwpformelementparentid_N = sdt.gxTv_SdtUForm_Element_Wwpformelementparentid_N ;
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
         AddObjectProperty("WWPFormElementId", gxTv_SdtUForm_Element_Wwpformelementid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementTitle", gxTv_SdtUForm_Element_Wwpformelementtitle, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementType", gxTv_SdtUForm_Element_Wwpformelementtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementOrderIndex", gxTv_SdtUForm_Element_Wwpformelementorderindex, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementDataType", gxTv_SdtUForm_Element_Wwpformelementdatatype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentId", gxTv_SdtUForm_Element_Wwpformelementparentid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentId_N", gxTv_SdtUForm_Element_Wwpformelementparentid_N, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentName", gxTv_SdtUForm_Element_Wwpformelementparentname, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementParentType", gxTv_SdtUForm_Element_Wwpformelementparenttype, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementMetadata", gxTv_SdtUForm_Element_Wwpformelementmetadata, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementCaption", gxTv_SdtUForm_Element_Wwpformelementcaption, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementReferenceId", gxTv_SdtUForm_Element_Wwpformelementreferenceid, false, includeNonInitialized);
         AddObjectProperty("WWPFormElementExcludeFromExport", gxTv_SdtUForm_Element_Wwpformelementexcludefromexport, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUForm_Element_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtUForm_Element_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUForm_Element_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementId_Z", gxTv_SdtUForm_Element_Wwpformelementid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementType_Z", gxTv_SdtUForm_Element_Wwpformelementtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementOrderIndex_Z", gxTv_SdtUForm_Element_Wwpformelementorderindex_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementDataType_Z", gxTv_SdtUForm_Element_Wwpformelementdatatype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentId_Z", gxTv_SdtUForm_Element_Wwpformelementparentid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentType_Z", gxTv_SdtUForm_Element_Wwpformelementparenttype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementCaption_Z", gxTv_SdtUForm_Element_Wwpformelementcaption_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementReferenceId_Z", gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementExcludeFromExport_Z", gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormElementParentId_N", gxTv_SdtUForm_Element_Wwpformelementparentid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUForm_Element sdt )
      {
         if ( sdt.IsDirty("WWPFormElementId") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementid = sdt.gxTv_SdtUForm_Element_Wwpformelementid ;
         }
         if ( sdt.IsDirty("WWPFormElementTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementtitle = sdt.gxTv_SdtUForm_Element_Wwpformelementtitle ;
         }
         if ( sdt.IsDirty("WWPFormElementType") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementtype = sdt.gxTv_SdtUForm_Element_Wwpformelementtype ;
         }
         if ( sdt.IsDirty("WWPFormElementOrderIndex") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementorderindex = sdt.gxTv_SdtUForm_Element_Wwpformelementorderindex ;
         }
         if ( sdt.IsDirty("WWPFormElementDataType") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementdatatype = sdt.gxTv_SdtUForm_Element_Wwpformelementdatatype ;
         }
         if ( sdt.IsDirty("WWPFormElementParentId") )
         {
            gxTv_SdtUForm_Element_Wwpformelementparentid_N = (short)(sdt.gxTv_SdtUForm_Element_Wwpformelementparentid_N);
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentid = sdt.gxTv_SdtUForm_Element_Wwpformelementparentid ;
         }
         if ( sdt.IsDirty("WWPFormElementParentName") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentname = sdt.gxTv_SdtUForm_Element_Wwpformelementparentname ;
         }
         if ( sdt.IsDirty("WWPFormElementParentType") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparenttype = sdt.gxTv_SdtUForm_Element_Wwpformelementparenttype ;
         }
         if ( sdt.IsDirty("WWPFormElementMetadata") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementmetadata = sdt.gxTv_SdtUForm_Element_Wwpformelementmetadata ;
         }
         if ( sdt.IsDirty("WWPFormElementCaption") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementcaption = sdt.gxTv_SdtUForm_Element_Wwpformelementcaption ;
         }
         if ( sdt.IsDirty("WWPFormElementReferenceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementreferenceid = sdt.gxTv_SdtUForm_Element_Wwpformelementreferenceid ;
         }
         if ( sdt.IsDirty("WWPFormElementExcludeFromExport") )
         {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementexcludefromexport = sdt.gxTv_SdtUForm_Element_Wwpformelementexcludefromexport ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPFormElementId" )]
      [  XmlElement( ElementName = "WWPFormElementId"   )]
      public short gxTpr_Wwpformelementid
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementid = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementid");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementTitle" )]
      [  XmlElement( ElementName = "WWPFormElementTitle"   )]
      public string gxTpr_Wwpformelementtitle
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementtitle = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementType" )]
      [  XmlElement( ElementName = "WWPFormElementType"   )]
      public short gxTpr_Wwpformelementtype
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementtype = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementOrderIndex" )]
      [  XmlElement( ElementName = "WWPFormElementOrderIndex"   )]
      public short gxTpr_Wwpformelementorderindex
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementorderindex ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementorderindex = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementorderindex");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementDataType" )]
      [  XmlElement( ElementName = "WWPFormElementDataType"   )]
      public short gxTpr_Wwpformelementdatatype
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementdatatype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementdatatype = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementdatatype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementParentId" )]
      [  XmlElement( ElementName = "WWPFormElementParentId"   )]
      public short gxTpr_Wwpformelementparentid
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparentid ;
         }

         set {
            gxTv_SdtUForm_Element_Wwpformelementparentid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentid = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparentid");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementparentid_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementparentid_N = 1;
         gxTv_SdtUForm_Element_Wwpformelementparentid = 0;
         SetDirty("Wwpformelementparentid");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementparentid_IsNull( )
      {
         return (gxTv_SdtUForm_Element_Wwpformelementparentid_N==1) ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentName" )]
      [  XmlElement( ElementName = "WWPFormElementParentName"   )]
      public string gxTpr_Wwpformelementparentname
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparentname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentname = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparentname");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementParentType" )]
      [  XmlElement( ElementName = "WWPFormElementParentType"   )]
      public short gxTpr_Wwpformelementparenttype
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparenttype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparenttype = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparenttype");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementMetadata" )]
      [  XmlElement( ElementName = "WWPFormElementMetadata"   )]
      public string gxTpr_Wwpformelementmetadata
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementmetadata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementmetadata = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementmetadata");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementCaption" )]
      [  XmlElement( ElementName = "WWPFormElementCaption"   )]
      public short gxTpr_Wwpformelementcaption
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementcaption ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementcaption = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementcaption");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementReferenceId" )]
      [  XmlElement( ElementName = "WWPFormElementReferenceId"   )]
      public string gxTpr_Wwpformelementreferenceid
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementreferenceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementreferenceid = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementreferenceid");
         }

      }

      [  SoapElement( ElementName = "WWPFormElementExcludeFromExport" )]
      [  XmlElement( ElementName = "WWPFormElementExcludeFromExport"   )]
      public bool gxTpr_Wwpformelementexcludefromexport
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementexcludefromexport ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementexcludefromexport = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementexcludefromexport");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUForm_Element_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUForm_Element_Mode_SetNull( )
      {
         gxTv_SdtUForm_Element_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtUForm_Element_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtUForm_Element_Modified_SetNull( )
      {
         gxTv_SdtUForm_Element_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUForm_Element_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Initialized = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUForm_Element_Initialized_SetNull( )
      {
         gxTv_SdtUForm_Element_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementId_Z"   )]
      public short gxTpr_Wwpformelementid_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementid_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementid_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementid_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementid_Z = 0;
         SetDirty("Wwpformelementid_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementType_Z"   )]
      public short gxTpr_Wwpformelementtype_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementtype_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementtype_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementtype_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementtype_Z = 0;
         SetDirty("Wwpformelementtype_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementOrderIndex_Z" )]
      [  XmlElement( ElementName = "WWPFormElementOrderIndex_Z"   )]
      public short gxTpr_Wwpformelementorderindex_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementorderindex_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementorderindex_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementorderindex_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementorderindex_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementorderindex_Z = 0;
         SetDirty("Wwpformelementorderindex_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementorderindex_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementDataType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementDataType_Z"   )]
      public short gxTpr_Wwpformelementdatatype_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementdatatype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementdatatype_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementdatatype_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementdatatype_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementdatatype_Z = 0;
         SetDirty("Wwpformelementdatatype_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementdatatype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementParentId_Z"   )]
      public short gxTpr_Wwpformelementparentid_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentid_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparentid_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementparentid_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementparentid_Z = 0;
         SetDirty("Wwpformelementparentid_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementparentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentType_Z" )]
      [  XmlElement( ElementName = "WWPFormElementParentType_Z"   )]
      public short gxTpr_Wwpformelementparenttype_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparenttype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparenttype_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparenttype_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementparenttype_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementparenttype_Z = 0;
         SetDirty("Wwpformelementparenttype_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementparenttype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementCaption_Z" )]
      [  XmlElement( ElementName = "WWPFormElementCaption_Z"   )]
      public short gxTpr_Wwpformelementcaption_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementcaption_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementcaption_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementcaption_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementcaption_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementcaption_Z = 0;
         SetDirty("Wwpformelementcaption_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementcaption_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementReferenceId_Z" )]
      [  XmlElement( ElementName = "WWPFormElementReferenceId_Z"   )]
      public string gxTpr_Wwpformelementreferenceid_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementreferenceid_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z = "";
         SetDirty("Wwpformelementreferenceid_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementExcludeFromExport_Z" )]
      [  XmlElement( ElementName = "WWPFormElementExcludeFromExport_Z"   )]
      public bool gxTpr_Wwpformelementexcludefromexport_Z
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementexcludefromexport_Z");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z = false;
         SetDirty("Wwpformelementexcludefromexport_Z");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormElementParentId_N" )]
      [  XmlElement( ElementName = "WWPFormElementParentId_N"   )]
      public short gxTpr_Wwpformelementparentid_N
      {
         get {
            return gxTv_SdtUForm_Element_Wwpformelementparentid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUForm_Element_Wwpformelementparentid_N = value;
            gxTv_SdtUForm_Element_Modified = 1;
            SetDirty("Wwpformelementparentid_N");
         }

      }

      public void gxTv_SdtUForm_Element_Wwpformelementparentid_N_SetNull( )
      {
         gxTv_SdtUForm_Element_Wwpformelementparentid_N = 0;
         SetDirty("Wwpformelementparentid_N");
         return  ;
      }

      public bool gxTv_SdtUForm_Element_Wwpformelementparentid_N_IsNull( )
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
         sdtIsNull = 1;
         gxTv_SdtUForm_Element_Wwpformelementtitle = "";
         gxTv_SdtUForm_Element_Wwpformelementparentname = "";
         gxTv_SdtUForm_Element_Wwpformelementmetadata = "";
         gxTv_SdtUForm_Element_Wwpformelementreferenceid = "";
         gxTv_SdtUForm_Element_Mode = "";
         gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtUForm_Element_Wwpformelementid ;
      private short sdtIsNull ;
      private short gxTv_SdtUForm_Element_Wwpformelementtype ;
      private short gxTv_SdtUForm_Element_Wwpformelementorderindex ;
      private short gxTv_SdtUForm_Element_Wwpformelementdatatype ;
      private short gxTv_SdtUForm_Element_Wwpformelementparentid ;
      private short gxTv_SdtUForm_Element_Wwpformelementparenttype ;
      private short gxTv_SdtUForm_Element_Wwpformelementcaption ;
      private short gxTv_SdtUForm_Element_Modified ;
      private short gxTv_SdtUForm_Element_Initialized ;
      private short gxTv_SdtUForm_Element_Wwpformelementid_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementtype_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementorderindex_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementdatatype_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementparentid_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementparenttype_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementcaption_Z ;
      private short gxTv_SdtUForm_Element_Wwpformelementparentid_N ;
      private string gxTv_SdtUForm_Element_Mode ;
      private bool gxTv_SdtUForm_Element_Wwpformelementexcludefromexport ;
      private bool gxTv_SdtUForm_Element_Wwpformelementexcludefromexport_Z ;
      private string gxTv_SdtUForm_Element_Wwpformelementtitle ;
      private string gxTv_SdtUForm_Element_Wwpformelementparentname ;
      private string gxTv_SdtUForm_Element_Wwpformelementmetadata ;
      private string gxTv_SdtUForm_Element_Wwpformelementreferenceid ;
      private string gxTv_SdtUForm_Element_Wwpformelementreferenceid_Z ;
   }

   [DataContract(Name = @"UForm.Element", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtUForm_Element_RESTInterface : GxGenericCollectionItem<SdtUForm_Element>
   {
      public SdtUForm_Element_RESTInterface( ) : base()
      {
      }

      public SdtUForm_Element_RESTInterface( SdtUForm_Element psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormElementId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementid
      {
         get {
            return sdt.gxTpr_Wwpformelementid ;
         }

         set {
            sdt.gxTpr_Wwpformelementid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementTitle" , Order = 1 )]
      public string gxTpr_Wwpformelementtitle
      {
         get {
            return sdt.gxTpr_Wwpformelementtitle ;
         }

         set {
            sdt.gxTpr_Wwpformelementtitle = value;
         }

      }

      [DataMember( Name = "WWPFormElementType" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementtype
      {
         get {
            return sdt.gxTpr_Wwpformelementtype ;
         }

         set {
            sdt.gxTpr_Wwpformelementtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementOrderIndex" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementorderindex
      {
         get {
            return sdt.gxTpr_Wwpformelementorderindex ;
         }

         set {
            sdt.gxTpr_Wwpformelementorderindex = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementDataType" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementdatatype
      {
         get {
            return sdt.gxTpr_Wwpformelementdatatype ;
         }

         set {
            sdt.gxTpr_Wwpformelementdatatype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementParentId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementparentid
      {
         get {
            return sdt.gxTpr_Wwpformelementparentid ;
         }

         set {
            sdt.gxTpr_Wwpformelementparentid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementParentName" , Order = 6 )]
      public string gxTpr_Wwpformelementparentname
      {
         get {
            return sdt.gxTpr_Wwpformelementparentname ;
         }

         set {
            sdt.gxTpr_Wwpformelementparentname = value;
         }

      }

      [DataMember( Name = "WWPFormElementParentType" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementparenttype
      {
         get {
            return sdt.gxTpr_Wwpformelementparenttype ;
         }

         set {
            sdt.gxTpr_Wwpformelementparenttype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementMetadata" , Order = 8 )]
      public string gxTpr_Wwpformelementmetadata
      {
         get {
            return sdt.gxTpr_Wwpformelementmetadata ;
         }

         set {
            sdt.gxTpr_Wwpformelementmetadata = value;
         }

      }

      [DataMember( Name = "WWPFormElementCaption" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformelementcaption
      {
         get {
            return sdt.gxTpr_Wwpformelementcaption ;
         }

         set {
            sdt.gxTpr_Wwpformelementcaption = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormElementReferenceId" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Wwpformelementreferenceid
      {
         get {
            return sdt.gxTpr_Wwpformelementreferenceid ;
         }

         set {
            sdt.gxTpr_Wwpformelementreferenceid = value;
         }

      }

      [DataMember( Name = "WWPFormElementExcludeFromExport" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformelementexcludefromexport
      {
         get {
            return sdt.gxTpr_Wwpformelementexcludefromexport ;
         }

         set {
            sdt.gxTpr_Wwpformelementexcludefromexport = value;
         }

      }

      public SdtUForm_Element sdt
      {
         get {
            return (SdtUForm_Element)Sdt ;
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
            sdt = new SdtUForm_Element() ;
         }
      }

   }

   [DataContract(Name = @"UForm.Element", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtUForm_Element_RESTLInterface : GxGenericCollectionItem<SdtUForm_Element>
   {
      public SdtUForm_Element_RESTLInterface( ) : base()
      {
      }

      public SdtUForm_Element_RESTLInterface( SdtUForm_Element psdt ) : base(psdt)
      {
      }

      public SdtUForm_Element sdt
      {
         get {
            return (SdtUForm_Element)Sdt ;
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
            sdt = new SdtUForm_Element() ;
         }
      }

   }

}
