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
   [XmlRoot(ElementName = "Trn_Page" )]
   [XmlType(TypeName =  "Trn_Page" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Page : GxSilentTrnSdt
   {
      public SdtTrn_Page( )
      {
      }

      public SdtTrn_Page( IGxContext context )
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

      public void Load( Guid AV392Trn_PageId ,
                        Guid AV29LocationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV392Trn_PageId,(Guid)AV29LocationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_PageId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Page");
         metadata.Set("BT", "Trn_Page");
         metadata.Set("PK", "[ \"Trn_PageId\",\"LocationId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_PageId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProductServiceId\",\"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Trn_pageid_Z");
         state.Add("gxTpr_Trn_pagename_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Pageispublished_Z");
         state.Add("gxTpr_Pageispredefined_Z");
         state.Add("gxTpr_Pageiscontentpage_Z");
         state.Add("gxTpr_Pageisdynamicform_Z");
         state.Add("gxTpr_Pageisweblinkpage_Z");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Pagejsoncontent_N");
         state.Add("gxTpr_Pagegjshtml_N");
         state.Add("gxTpr_Pagegjsjson_N");
         state.Add("gxTpr_Pageispublished_N");
         state.Add("gxTpr_Pageiscontentpage_N");
         state.Add("gxTpr_Pagechildren_N");
         state.Add("gxTpr_Productserviceid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Page sdt;
         sdt = (SdtTrn_Page)(source);
         gxTv_SdtTrn_Page_Trn_pageid = sdt.gxTv_SdtTrn_Page_Trn_pageid ;
         gxTv_SdtTrn_Page_Trn_pagename = sdt.gxTv_SdtTrn_Page_Trn_pagename ;
         gxTv_SdtTrn_Page_Locationid = sdt.gxTv_SdtTrn_Page_Locationid ;
         gxTv_SdtTrn_Page_Pagejsoncontent = sdt.gxTv_SdtTrn_Page_Pagejsoncontent ;
         gxTv_SdtTrn_Page_Pagegjshtml = sdt.gxTv_SdtTrn_Page_Pagegjshtml ;
         gxTv_SdtTrn_Page_Pagegjsjson = sdt.gxTv_SdtTrn_Page_Pagegjsjson ;
         gxTv_SdtTrn_Page_Pageispublished = sdt.gxTv_SdtTrn_Page_Pageispublished ;
         gxTv_SdtTrn_Page_Pageispredefined = sdt.gxTv_SdtTrn_Page_Pageispredefined ;
         gxTv_SdtTrn_Page_Pageiscontentpage = sdt.gxTv_SdtTrn_Page_Pageiscontentpage ;
         gxTv_SdtTrn_Page_Pageisdynamicform = sdt.gxTv_SdtTrn_Page_Pageisdynamicform ;
         gxTv_SdtTrn_Page_Pageisweblinkpage = sdt.gxTv_SdtTrn_Page_Pageisweblinkpage ;
         gxTv_SdtTrn_Page_Pagechildren = sdt.gxTv_SdtTrn_Page_Pagechildren ;
         gxTv_SdtTrn_Page_Productserviceid = sdt.gxTv_SdtTrn_Page_Productserviceid ;
         gxTv_SdtTrn_Page_Organisationid = sdt.gxTv_SdtTrn_Page_Organisationid ;
         gxTv_SdtTrn_Page_Mode = sdt.gxTv_SdtTrn_Page_Mode ;
         gxTv_SdtTrn_Page_Initialized = sdt.gxTv_SdtTrn_Page_Initialized ;
         gxTv_SdtTrn_Page_Trn_pageid_Z = sdt.gxTv_SdtTrn_Page_Trn_pageid_Z ;
         gxTv_SdtTrn_Page_Trn_pagename_Z = sdt.gxTv_SdtTrn_Page_Trn_pagename_Z ;
         gxTv_SdtTrn_Page_Locationid_Z = sdt.gxTv_SdtTrn_Page_Locationid_Z ;
         gxTv_SdtTrn_Page_Pageispublished_Z = sdt.gxTv_SdtTrn_Page_Pageispublished_Z ;
         gxTv_SdtTrn_Page_Pageispredefined_Z = sdt.gxTv_SdtTrn_Page_Pageispredefined_Z ;
         gxTv_SdtTrn_Page_Pageiscontentpage_Z = sdt.gxTv_SdtTrn_Page_Pageiscontentpage_Z ;
         gxTv_SdtTrn_Page_Pageisdynamicform_Z = sdt.gxTv_SdtTrn_Page_Pageisdynamicform_Z ;
         gxTv_SdtTrn_Page_Pageisweblinkpage_Z = sdt.gxTv_SdtTrn_Page_Pageisweblinkpage_Z ;
         gxTv_SdtTrn_Page_Productserviceid_Z = sdt.gxTv_SdtTrn_Page_Productserviceid_Z ;
         gxTv_SdtTrn_Page_Organisationid_Z = sdt.gxTv_SdtTrn_Page_Organisationid_Z ;
         gxTv_SdtTrn_Page_Pagejsoncontent_N = sdt.gxTv_SdtTrn_Page_Pagejsoncontent_N ;
         gxTv_SdtTrn_Page_Pagegjshtml_N = sdt.gxTv_SdtTrn_Page_Pagegjshtml_N ;
         gxTv_SdtTrn_Page_Pagegjsjson_N = sdt.gxTv_SdtTrn_Page_Pagegjsjson_N ;
         gxTv_SdtTrn_Page_Pageispublished_N = sdt.gxTv_SdtTrn_Page_Pageispublished_N ;
         gxTv_SdtTrn_Page_Pageiscontentpage_N = sdt.gxTv_SdtTrn_Page_Pageiscontentpage_N ;
         gxTv_SdtTrn_Page_Pagechildren_N = sdt.gxTv_SdtTrn_Page_Pagechildren_N ;
         gxTv_SdtTrn_Page_Productserviceid_N = sdt.gxTv_SdtTrn_Page_Productserviceid_N ;
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
         AddObjectProperty("Trn_PageId", gxTv_SdtTrn_Page_Trn_pageid, false, includeNonInitialized);
         AddObjectProperty("Trn_PageName", gxTv_SdtTrn_Page_Trn_pagename, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Page_Locationid, false, includeNonInitialized);
         AddObjectProperty("PageJsonContent", gxTv_SdtTrn_Page_Pagejsoncontent, false, includeNonInitialized);
         AddObjectProperty("PageJsonContent_N", gxTv_SdtTrn_Page_Pagejsoncontent_N, false, includeNonInitialized);
         AddObjectProperty("PageGJSHtml", gxTv_SdtTrn_Page_Pagegjshtml, false, includeNonInitialized);
         AddObjectProperty("PageGJSHtml_N", gxTv_SdtTrn_Page_Pagegjshtml_N, false, includeNonInitialized);
         AddObjectProperty("PageGJSJson", gxTv_SdtTrn_Page_Pagegjsjson, false, includeNonInitialized);
         AddObjectProperty("PageGJSJson_N", gxTv_SdtTrn_Page_Pagegjsjson_N, false, includeNonInitialized);
         AddObjectProperty("PageIsPublished", gxTv_SdtTrn_Page_Pageispublished, false, includeNonInitialized);
         AddObjectProperty("PageIsPublished_N", gxTv_SdtTrn_Page_Pageispublished_N, false, includeNonInitialized);
         AddObjectProperty("PageIsPredefined", gxTv_SdtTrn_Page_Pageispredefined, false, includeNonInitialized);
         AddObjectProperty("PageIsContentPage", gxTv_SdtTrn_Page_Pageiscontentpage, false, includeNonInitialized);
         AddObjectProperty("PageIsContentPage_N", gxTv_SdtTrn_Page_Pageiscontentpage_N, false, includeNonInitialized);
         AddObjectProperty("PageIsDynamicForm", gxTv_SdtTrn_Page_Pageisdynamicform, false, includeNonInitialized);
         AddObjectProperty("PageIsWebLinkPage", gxTv_SdtTrn_Page_Pageisweblinkpage, false, includeNonInitialized);
         AddObjectProperty("PageChildren", gxTv_SdtTrn_Page_Pagechildren, false, includeNonInitialized);
         AddObjectProperty("PageChildren_N", gxTv_SdtTrn_Page_Pagechildren_N, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId", gxTv_SdtTrn_Page_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_Page_Productserviceid_N, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Page_Organisationid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Page_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Page_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_PageId_Z", gxTv_SdtTrn_Page_Trn_pageid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_PageName_Z", gxTv_SdtTrn_Page_Trn_pagename_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Page_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("PageIsPublished_Z", gxTv_SdtTrn_Page_Pageispublished_Z, false, includeNonInitialized);
            AddObjectProperty("PageIsPredefined_Z", gxTv_SdtTrn_Page_Pageispredefined_Z, false, includeNonInitialized);
            AddObjectProperty("PageIsContentPage_Z", gxTv_SdtTrn_Page_Pageiscontentpage_Z, false, includeNonInitialized);
            AddObjectProperty("PageIsDynamicForm_Z", gxTv_SdtTrn_Page_Pageisdynamicform_Z, false, includeNonInitialized);
            AddObjectProperty("PageIsWebLinkPage_Z", gxTv_SdtTrn_Page_Pageisweblinkpage_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtTrn_Page_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Page_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("PageJsonContent_N", gxTv_SdtTrn_Page_Pagejsoncontent_N, false, includeNonInitialized);
            AddObjectProperty("PageGJSHtml_N", gxTv_SdtTrn_Page_Pagegjshtml_N, false, includeNonInitialized);
            AddObjectProperty("PageGJSJson_N", gxTv_SdtTrn_Page_Pagegjsjson_N, false, includeNonInitialized);
            AddObjectProperty("PageIsPublished_N", gxTv_SdtTrn_Page_Pageispublished_N, false, includeNonInitialized);
            AddObjectProperty("PageIsContentPage_N", gxTv_SdtTrn_Page_Pageiscontentpage_N, false, includeNonInitialized);
            AddObjectProperty("PageChildren_N", gxTv_SdtTrn_Page_Pagechildren_N, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_Page_Productserviceid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Page sdt )
      {
         if ( sdt.IsDirty("Trn_PageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pageid = sdt.gxTv_SdtTrn_Page_Trn_pageid ;
         }
         if ( sdt.IsDirty("Trn_PageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename = sdt.gxTv_SdtTrn_Page_Trn_pagename ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Locationid = sdt.gxTv_SdtTrn_Page_Locationid ;
         }
         if ( sdt.IsDirty("PageJsonContent") )
         {
            gxTv_SdtTrn_Page_Pagejsoncontent_N = (short)(sdt.gxTv_SdtTrn_Page_Pagejsoncontent_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagejsoncontent = sdt.gxTv_SdtTrn_Page_Pagejsoncontent ;
         }
         if ( sdt.IsDirty("PageGJSHtml") )
         {
            gxTv_SdtTrn_Page_Pagegjshtml_N = (short)(sdt.gxTv_SdtTrn_Page_Pagegjshtml_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjshtml = sdt.gxTv_SdtTrn_Page_Pagegjshtml ;
         }
         if ( sdt.IsDirty("PageGJSJson") )
         {
            gxTv_SdtTrn_Page_Pagegjsjson_N = (short)(sdt.gxTv_SdtTrn_Page_Pagegjsjson_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjsjson = sdt.gxTv_SdtTrn_Page_Pagegjsjson ;
         }
         if ( sdt.IsDirty("PageIsPublished") )
         {
            gxTv_SdtTrn_Page_Pageispublished_N = (short)(sdt.gxTv_SdtTrn_Page_Pageispublished_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispublished = sdt.gxTv_SdtTrn_Page_Pageispublished ;
         }
         if ( sdt.IsDirty("PageIsPredefined") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispredefined = sdt.gxTv_SdtTrn_Page_Pageispredefined ;
         }
         if ( sdt.IsDirty("PageIsContentPage") )
         {
            gxTv_SdtTrn_Page_Pageiscontentpage_N = (short)(sdt.gxTv_SdtTrn_Page_Pageiscontentpage_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageiscontentpage = sdt.gxTv_SdtTrn_Page_Pageiscontentpage ;
         }
         if ( sdt.IsDirty("PageIsDynamicForm") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisdynamicform = sdt.gxTv_SdtTrn_Page_Pageisdynamicform ;
         }
         if ( sdt.IsDirty("PageIsWebLinkPage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisweblinkpage = sdt.gxTv_SdtTrn_Page_Pageisweblinkpage ;
         }
         if ( sdt.IsDirty("PageChildren") )
         {
            gxTv_SdtTrn_Page_Pagechildren_N = (short)(sdt.gxTv_SdtTrn_Page_Pagechildren_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagechildren = sdt.gxTv_SdtTrn_Page_Pagechildren ;
         }
         if ( sdt.IsDirty("ProductServiceId") )
         {
            gxTv_SdtTrn_Page_Productserviceid_N = (short)(sdt.gxTv_SdtTrn_Page_Productserviceid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Productserviceid = sdt.gxTv_SdtTrn_Page_Productserviceid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Organisationid = sdt.gxTv_SdtTrn_Page_Organisationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_PageId" )]
      [  XmlElement( ElementName = "Trn_PageId"   )]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Page_Trn_pageid != value )
            {
               gxTv_SdtTrn_Page_Mode = "INS";
               this.gxTv_SdtTrn_Page_Trn_pageid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Trn_pagename_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageispublished_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageispredefined_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageiscontentpage_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageisdynamicform_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageisweblinkpage_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Organisationid_Z_SetNull( );
            }
            gxTv_SdtTrn_Page_Trn_pageid = value;
            SetDirty("Trn_pageid");
         }

      }

      [  SoapElement( ElementName = "Trn_PageName" )]
      [  XmlElement( ElementName = "Trn_PageName"   )]
      public string gxTpr_Trn_pagename
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename = value;
            SetDirty("Trn_pagename");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Page_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Page_Locationid != value )
            {
               gxTv_SdtTrn_Page_Mode = "INS";
               this.gxTv_SdtTrn_Page_Trn_pageid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Trn_pagename_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageispublished_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageispredefined_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageiscontentpage_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageisdynamicform_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Pageisweblinkpage_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Organisationid_Z_SetNull( );
            }
            gxTv_SdtTrn_Page_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "PageJsonContent" )]
      [  XmlElement( ElementName = "PageJsonContent"   )]
      public string gxTpr_Pagejsoncontent
      {
         get {
            return gxTv_SdtTrn_Page_Pagejsoncontent ;
         }

         set {
            gxTv_SdtTrn_Page_Pagejsoncontent_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagejsoncontent = value;
            SetDirty("Pagejsoncontent");
         }

      }

      public void gxTv_SdtTrn_Page_Pagejsoncontent_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagejsoncontent_N = 1;
         gxTv_SdtTrn_Page_Pagejsoncontent = "";
         SetDirty("Pagejsoncontent");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagejsoncontent_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pagejsoncontent_N==1) ;
      }

      [  SoapElement( ElementName = "PageGJSHtml" )]
      [  XmlElement( ElementName = "PageGJSHtml"   )]
      public string gxTpr_Pagegjshtml
      {
         get {
            return gxTv_SdtTrn_Page_Pagegjshtml ;
         }

         set {
            gxTv_SdtTrn_Page_Pagegjshtml_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjshtml = value;
            SetDirty("Pagegjshtml");
         }

      }

      public void gxTv_SdtTrn_Page_Pagegjshtml_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagegjshtml_N = 1;
         gxTv_SdtTrn_Page_Pagegjshtml = "";
         SetDirty("Pagegjshtml");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagegjshtml_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pagegjshtml_N==1) ;
      }

      [  SoapElement( ElementName = "PageGJSJson" )]
      [  XmlElement( ElementName = "PageGJSJson"   )]
      public string gxTpr_Pagegjsjson
      {
         get {
            return gxTv_SdtTrn_Page_Pagegjsjson ;
         }

         set {
            gxTv_SdtTrn_Page_Pagegjsjson_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjsjson = value;
            SetDirty("Pagegjsjson");
         }

      }

      public void gxTv_SdtTrn_Page_Pagegjsjson_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagegjsjson_N = 1;
         gxTv_SdtTrn_Page_Pagegjsjson = "";
         SetDirty("Pagegjsjson");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagegjsjson_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pagegjsjson_N==1) ;
      }

      [  SoapElement( ElementName = "PageIsPublished" )]
      [  XmlElement( ElementName = "PageIsPublished"   )]
      public bool gxTpr_Pageispublished
      {
         get {
            return gxTv_SdtTrn_Page_Pageispublished ;
         }

         set {
            gxTv_SdtTrn_Page_Pageispublished_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispublished = value;
            SetDirty("Pageispublished");
         }

      }

      public void gxTv_SdtTrn_Page_Pageispublished_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageispublished_N = 1;
         gxTv_SdtTrn_Page_Pageispublished = false;
         SetDirty("Pageispublished");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageispublished_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pageispublished_N==1) ;
      }

      [  SoapElement( ElementName = "PageIsPredefined" )]
      [  XmlElement( ElementName = "PageIsPredefined"   )]
      public bool gxTpr_Pageispredefined
      {
         get {
            return gxTv_SdtTrn_Page_Pageispredefined ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispredefined = value;
            SetDirty("Pageispredefined");
         }

      }

      [  SoapElement( ElementName = "PageIsContentPage" )]
      [  XmlElement( ElementName = "PageIsContentPage"   )]
      public bool gxTpr_Pageiscontentpage
      {
         get {
            return gxTv_SdtTrn_Page_Pageiscontentpage ;
         }

         set {
            gxTv_SdtTrn_Page_Pageiscontentpage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageiscontentpage = value;
            SetDirty("Pageiscontentpage");
         }

      }

      public void gxTv_SdtTrn_Page_Pageiscontentpage_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageiscontentpage_N = 1;
         gxTv_SdtTrn_Page_Pageiscontentpage = false;
         SetDirty("Pageiscontentpage");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageiscontentpage_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pageiscontentpage_N==1) ;
      }

      [  SoapElement( ElementName = "PageIsDynamicForm" )]
      [  XmlElement( ElementName = "PageIsDynamicForm"   )]
      public bool gxTpr_Pageisdynamicform
      {
         get {
            return gxTv_SdtTrn_Page_Pageisdynamicform ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisdynamicform = value;
            SetDirty("Pageisdynamicform");
         }

      }

      [  SoapElement( ElementName = "PageIsWebLinkPage" )]
      [  XmlElement( ElementName = "PageIsWebLinkPage"   )]
      public bool gxTpr_Pageisweblinkpage
      {
         get {
            return gxTv_SdtTrn_Page_Pageisweblinkpage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisweblinkpage = value;
            SetDirty("Pageisweblinkpage");
         }

      }

      [  SoapElement( ElementName = "PageChildren" )]
      [  XmlElement( ElementName = "PageChildren"   )]
      public string gxTpr_Pagechildren
      {
         get {
            return gxTv_SdtTrn_Page_Pagechildren ;
         }

         set {
            gxTv_SdtTrn_Page_Pagechildren_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagechildren = value;
            SetDirty("Pagechildren");
         }

      }

      public void gxTv_SdtTrn_Page_Pagechildren_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagechildren_N = 1;
         gxTv_SdtTrn_Page_Pagechildren = "";
         SetDirty("Pagechildren");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagechildren_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Pagechildren_N==1) ;
      }

      [  SoapElement( ElementName = "ProductServiceId" )]
      [  XmlElement( ElementName = "ProductServiceId"   )]
      public Guid gxTpr_Productserviceid
      {
         get {
            return gxTv_SdtTrn_Page_Productserviceid ;
         }

         set {
            gxTv_SdtTrn_Page_Productserviceid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Productserviceid = value;
            SetDirty("Productserviceid");
         }

      }

      public void gxTv_SdtTrn_Page_Productserviceid_SetNull( )
      {
         gxTv_SdtTrn_Page_Productserviceid_N = 1;
         gxTv_SdtTrn_Page_Productserviceid = Guid.Empty;
         SetDirty("Productserviceid");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Productserviceid_IsNull( )
      {
         return (gxTv_SdtTrn_Page_Productserviceid_N==1) ;
      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Page_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Page_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Page_Mode_SetNull( )
      {
         gxTv_SdtTrn_Page_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Page_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Page_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Page_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageId_Z" )]
      [  XmlElement( ElementName = "Trn_PageId_Z"   )]
      public Guid gxTpr_Trn_pageid_Z
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pageid_Z = value;
            SetDirty("Trn_pageid_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Trn_pageid_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Trn_pageid_Z = Guid.Empty;
         SetDirty("Trn_pageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Trn_pageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageName_Z" )]
      [  XmlElement( ElementName = "Trn_PageName_Z"   )]
      public string gxTpr_Trn_pagename_Z
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename_Z = value;
            SetDirty("Trn_pagename_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Trn_pagename_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Trn_pagename_Z = "";
         SetDirty("Trn_pagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Trn_pagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Page_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsPublished_Z" )]
      [  XmlElement( ElementName = "PageIsPublished_Z"   )]
      public bool gxTpr_Pageispublished_Z
      {
         get {
            return gxTv_SdtTrn_Page_Pageispublished_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispublished_Z = value;
            SetDirty("Pageispublished_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Pageispublished_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageispublished_Z = false;
         SetDirty("Pageispublished_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageispublished_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsPredefined_Z" )]
      [  XmlElement( ElementName = "PageIsPredefined_Z"   )]
      public bool gxTpr_Pageispredefined_Z
      {
         get {
            return gxTv_SdtTrn_Page_Pageispredefined_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispredefined_Z = value;
            SetDirty("Pageispredefined_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Pageispredefined_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageispredefined_Z = false;
         SetDirty("Pageispredefined_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageispredefined_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsContentPage_Z" )]
      [  XmlElement( ElementName = "PageIsContentPage_Z"   )]
      public bool gxTpr_Pageiscontentpage_Z
      {
         get {
            return gxTv_SdtTrn_Page_Pageiscontentpage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageiscontentpage_Z = value;
            SetDirty("Pageiscontentpage_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Pageiscontentpage_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageiscontentpage_Z = false;
         SetDirty("Pageiscontentpage_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageiscontentpage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsDynamicForm_Z" )]
      [  XmlElement( ElementName = "PageIsDynamicForm_Z"   )]
      public bool gxTpr_Pageisdynamicform_Z
      {
         get {
            return gxTv_SdtTrn_Page_Pageisdynamicform_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisdynamicform_Z = value;
            SetDirty("Pageisdynamicform_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Pageisdynamicform_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageisdynamicform_Z = false;
         SetDirty("Pageisdynamicform_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageisdynamicform_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsWebLinkPage_Z" )]
      [  XmlElement( ElementName = "PageIsWebLinkPage_Z"   )]
      public bool gxTpr_Pageisweblinkpage_Z
      {
         get {
            return gxTv_SdtTrn_Page_Pageisweblinkpage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageisweblinkpage_Z = value;
            SetDirty("Pageisweblinkpage_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Pageisweblinkpage_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageisweblinkpage_Z = false;
         SetDirty("Pageisweblinkpage_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageisweblinkpage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_Z" )]
      [  XmlElement( ElementName = "ProductServiceId_Z"   )]
      public Guid gxTpr_Productserviceid_Z
      {
         get {
            return gxTv_SdtTrn_Page_Productserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Productserviceid_Z = value;
            SetDirty("Productserviceid_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Productserviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Productserviceid_Z = Guid.Empty;
         SetDirty("Productserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Productserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Page_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageJsonContent_N" )]
      [  XmlElement( ElementName = "PageJsonContent_N"   )]
      public short gxTpr_Pagejsoncontent_N
      {
         get {
            return gxTv_SdtTrn_Page_Pagejsoncontent_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagejsoncontent_N = value;
            SetDirty("Pagejsoncontent_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pagejsoncontent_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagejsoncontent_N = 0;
         SetDirty("Pagejsoncontent_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagejsoncontent_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageGJSHtml_N" )]
      [  XmlElement( ElementName = "PageGJSHtml_N"   )]
      public short gxTpr_Pagegjshtml_N
      {
         get {
            return gxTv_SdtTrn_Page_Pagegjshtml_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjshtml_N = value;
            SetDirty("Pagegjshtml_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pagegjshtml_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagegjshtml_N = 0;
         SetDirty("Pagegjshtml_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagegjshtml_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageGJSJson_N" )]
      [  XmlElement( ElementName = "PageGJSJson_N"   )]
      public short gxTpr_Pagegjsjson_N
      {
         get {
            return gxTv_SdtTrn_Page_Pagegjsjson_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagegjsjson_N = value;
            SetDirty("Pagegjsjson_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pagegjsjson_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagegjsjson_N = 0;
         SetDirty("Pagegjsjson_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagegjsjson_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsPublished_N" )]
      [  XmlElement( ElementName = "PageIsPublished_N"   )]
      public short gxTpr_Pageispublished_N
      {
         get {
            return gxTv_SdtTrn_Page_Pageispublished_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageispublished_N = value;
            SetDirty("Pageispublished_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pageispublished_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageispublished_N = 0;
         SetDirty("Pageispublished_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageispublished_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageIsContentPage_N" )]
      [  XmlElement( ElementName = "PageIsContentPage_N"   )]
      public short gxTpr_Pageiscontentpage_N
      {
         get {
            return gxTv_SdtTrn_Page_Pageiscontentpage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pageiscontentpage_N = value;
            SetDirty("Pageiscontentpage_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pageiscontentpage_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pageiscontentpage_N = 0;
         SetDirty("Pageiscontentpage_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pageiscontentpage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageChildren_N" )]
      [  XmlElement( ElementName = "PageChildren_N"   )]
      public short gxTpr_Pagechildren_N
      {
         get {
            return gxTv_SdtTrn_Page_Pagechildren_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Pagechildren_N = value;
            SetDirty("Pagechildren_N");
         }

      }

      public void gxTv_SdtTrn_Page_Pagechildren_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Pagechildren_N = 0;
         SetDirty("Pagechildren_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Pagechildren_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_N" )]
      [  XmlElement( ElementName = "ProductServiceId_N"   )]
      public short gxTpr_Productserviceid_N
      {
         get {
            return gxTv_SdtTrn_Page_Productserviceid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Productserviceid_N = value;
            SetDirty("Productserviceid_N");
         }

      }

      public void gxTv_SdtTrn_Page_Productserviceid_N_SetNull( )
      {
         gxTv_SdtTrn_Page_Productserviceid_N = 0;
         SetDirty("Productserviceid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Productserviceid_N_IsNull( )
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
         gxTv_SdtTrn_Page_Trn_pageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Page_Trn_pagename = "";
         gxTv_SdtTrn_Page_Locationid = Guid.Empty;
         gxTv_SdtTrn_Page_Pagejsoncontent = "";
         gxTv_SdtTrn_Page_Pagegjshtml = "";
         gxTv_SdtTrn_Page_Pagegjsjson = "";
         gxTv_SdtTrn_Page_Pageispublished = false;
         gxTv_SdtTrn_Page_Pageispredefined = false;
         gxTv_SdtTrn_Page_Pageiscontentpage = false;
         gxTv_SdtTrn_Page_Pageisdynamicform = false;
         gxTv_SdtTrn_Page_Pagechildren = "";
         gxTv_SdtTrn_Page_Productserviceid = Guid.Empty;
         gxTv_SdtTrn_Page_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Page_Mode = "";
         gxTv_SdtTrn_Page_Trn_pageid_Z = Guid.Empty;
         gxTv_SdtTrn_Page_Trn_pagename_Z = "";
         gxTv_SdtTrn_Page_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Page_Productserviceid_Z = Guid.Empty;
         gxTv_SdtTrn_Page_Organisationid_Z = Guid.Empty;
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_page", "GeneXus.Programs.trn_page_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Page_Initialized ;
      private short gxTv_SdtTrn_Page_Pagejsoncontent_N ;
      private short gxTv_SdtTrn_Page_Pagegjshtml_N ;
      private short gxTv_SdtTrn_Page_Pagegjsjson_N ;
      private short gxTv_SdtTrn_Page_Pageispublished_N ;
      private short gxTv_SdtTrn_Page_Pageiscontentpage_N ;
      private short gxTv_SdtTrn_Page_Pagechildren_N ;
      private short gxTv_SdtTrn_Page_Productserviceid_N ;
      private string gxTv_SdtTrn_Page_Mode ;
      private bool gxTv_SdtTrn_Page_Pageispublished ;
      private bool gxTv_SdtTrn_Page_Pageispredefined ;
      private bool gxTv_SdtTrn_Page_Pageiscontentpage ;
      private bool gxTv_SdtTrn_Page_Pageisdynamicform ;
      private bool gxTv_SdtTrn_Page_Pageisweblinkpage ;
      private bool gxTv_SdtTrn_Page_Pageispublished_Z ;
      private bool gxTv_SdtTrn_Page_Pageispredefined_Z ;
      private bool gxTv_SdtTrn_Page_Pageiscontentpage_Z ;
      private bool gxTv_SdtTrn_Page_Pageisdynamicform_Z ;
      private bool gxTv_SdtTrn_Page_Pageisweblinkpage_Z ;
      private string gxTv_SdtTrn_Page_Pagejsoncontent ;
      private string gxTv_SdtTrn_Page_Pagegjshtml ;
      private string gxTv_SdtTrn_Page_Pagegjsjson ;
      private string gxTv_SdtTrn_Page_Pagechildren ;
      private string gxTv_SdtTrn_Page_Trn_pagename ;
      private string gxTv_SdtTrn_Page_Trn_pagename_Z ;
      private Guid gxTv_SdtTrn_Page_Trn_pageid ;
      private Guid gxTv_SdtTrn_Page_Locationid ;
      private Guid gxTv_SdtTrn_Page_Productserviceid ;
      private Guid gxTv_SdtTrn_Page_Organisationid ;
      private Guid gxTv_SdtTrn_Page_Trn_pageid_Z ;
      private Guid gxTv_SdtTrn_Page_Locationid_Z ;
      private Guid gxTv_SdtTrn_Page_Productserviceid_Z ;
      private Guid gxTv_SdtTrn_Page_Organisationid_Z ;
   }

   [DataContract(Name = @"Trn_Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Page_RESTInterface : GxGenericCollectionItem<SdtTrn_Page>
   {
      public SdtTrn_Page_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Page_RESTInterface( SdtTrn_Page psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_PageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return sdt.gxTpr_Trn_pageid ;
         }

         set {
            sdt.gxTpr_Trn_pageid = value;
         }

      }

      [DataMember( Name = "Trn_PageName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_pagename
      {
         get {
            return sdt.gxTpr_Trn_pagename ;
         }

         set {
            sdt.gxTpr_Trn_pagename = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "PageJsonContent" , Order = 3 )]
      public string gxTpr_Pagejsoncontent
      {
         get {
            return sdt.gxTpr_Pagejsoncontent ;
         }

         set {
            sdt.gxTpr_Pagejsoncontent = value;
         }

      }

      [DataMember( Name = "PageGJSHtml" , Order = 4 )]
      public string gxTpr_Pagegjshtml
      {
         get {
            return sdt.gxTpr_Pagegjshtml ;
         }

         set {
            sdt.gxTpr_Pagegjshtml = value;
         }

      }

      [DataMember( Name = "PageGJSJson" , Order = 5 )]
      public string gxTpr_Pagegjsjson
      {
         get {
            return sdt.gxTpr_Pagegjsjson ;
         }

         set {
            sdt.gxTpr_Pagegjsjson = value;
         }

      }

      [DataMember( Name = "PageIsPublished" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Pageispublished
      {
         get {
            return sdt.gxTpr_Pageispublished ;
         }

         set {
            sdt.gxTpr_Pageispublished = value;
         }

      }

      [DataMember( Name = "PageIsPredefined" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Pageispredefined
      {
         get {
            return sdt.gxTpr_Pageispredefined ;
         }

         set {
            sdt.gxTpr_Pageispredefined = value;
         }

      }

      [DataMember( Name = "PageIsContentPage" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Pageiscontentpage
      {
         get {
            return sdt.gxTpr_Pageiscontentpage ;
         }

         set {
            sdt.gxTpr_Pageiscontentpage = value;
         }

      }

      [DataMember( Name = "PageIsDynamicForm" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Pageisdynamicform
      {
         get {
            return sdt.gxTpr_Pageisdynamicform ;
         }

         set {
            sdt.gxTpr_Pageisdynamicform = value;
         }

      }

      [DataMember( Name = "PageIsWebLinkPage" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Pageisweblinkpage
      {
         get {
            return sdt.gxTpr_Pageisweblinkpage ;
         }

         set {
            sdt.gxTpr_Pageisweblinkpage = value;
         }

      }

      [DataMember( Name = "PageChildren" , Order = 11 )]
      public string gxTpr_Pagechildren
      {
         get {
            return sdt.gxTpr_Pagechildren ;
         }

         set {
            sdt.gxTpr_Pagechildren = value;
         }

      }

      [DataMember( Name = "ProductServiceId" , Order = 12 )]
      [GxSeudo()]
      public Guid gxTpr_Productserviceid
      {
         get {
            return sdt.gxTpr_Productserviceid ;
         }

         set {
            sdt.gxTpr_Productserviceid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 13 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      public SdtTrn_Page sdt
      {
         get {
            return (SdtTrn_Page)Sdt ;
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
            sdt = new SdtTrn_Page() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
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

   [DataContract(Name = @"Trn_Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Page_RESTLInterface : GxGenericCollectionItem<SdtTrn_Page>
   {
      public SdtTrn_Page_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Page_RESTLInterface( SdtTrn_Page psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_PageName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_pagename
      {
         get {
            return sdt.gxTpr_Trn_pagename ;
         }

         set {
            sdt.gxTpr_Trn_pagename = value;
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

      public SdtTrn_Page sdt
      {
         get {
            return (SdtTrn_Page)Sdt ;
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
            sdt = new SdtTrn_Page() ;
         }
      }

   }

}
