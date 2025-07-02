using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_memo : GXWebComponent
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetPar( "sCompPrefix");
               sSFPrefix = GetPar( "sSFPrefix");
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV7MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
               AssignAttri(sPrefix, false, "AV7MemoId", AV7MemoId.ToString());
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(Guid)AV7MemoId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
            {
               A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
               AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
               A528SG_LocationId = StringUtil.StrToGuid( GetPar( "SG_LocationId"));
               AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
               A529SG_OrganisationId = StringUtil.StrToGuid( GetPar( "SG_OrganisationId"));
               AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_18( A62ResidentId, A528SG_LocationId, A529SG_OrganisationId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_memo.aspx")), "trn_memo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_memo.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  Gx_mode = gxfirstwebparm;
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                  {
                     AV7MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
                     AssignAttri(sPrefix, false, "AV7MemoId", AV7MemoId.ToString());
                  }
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Trn_Memo", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMemoTitle_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public trn_memo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public trn_memo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_MemoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MemoId = aP1_MemoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbResidentSalutation = new GXCombobox();
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_memo_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", cmbResidentSalutation.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
            RenderHtmlCloseForm1P100( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_memo.aspx");
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Memo.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A550MemoTitle", A550MemoTitle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoTitle_Internalname, A550MemoTitle, StringUtil.RTrim( context.localUtil.Format( A550MemoTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A551MemoDescription", A551MemoDescription);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoDescription_Internalname, A551MemoDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtMemoDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoImage_Internalname, context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A552MemoImage", A552MemoImage);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoImage_Internalname, A552MemoImage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtMemoImage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDocument_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoDocument_Internalname, context.GetMessage( "Document", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A553MemoDocument", A553MemoDocument);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMemoDocument_Internalname, A553MemoDocument, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtMemoDocument_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoStartDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoStartDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoStartDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoStartDateTime_Internalname, context.localUtil.TToC( A561MemoStartDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A561MemoStartDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoStartDateTime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMemoStartDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoStartDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoStartDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoEndDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoEndDateTime_Internalname, context.GetMessage( "Date Time", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoEndDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoEndDateTime_Internalname, context.localUtil.TToC( A562MemoEndDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A562MemoEndDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoEndDateTime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMemoEndDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoEndDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoEndDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoDuration_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoDuration_Internalname, context.GetMessage( "Duration", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( A563MemoDuration, 6, 3, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMemoDuration_Enabled!=0) ? context.localUtil.Format( A563MemoDuration, "Z9.999") : context.localUtil.Format( A563MemoDuration, "Z9.999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'3');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'3');"+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMemoDuration_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoRemoveDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoRemoveDate_Internalname, context.GetMessage( "Remove Date", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoRemoveDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoRemoveDate_Internalname, context.localUtil.Format(A564MemoRemoveDate, "99/99/99"), context.localUtil.Format( A564MemoRemoveDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoRemoveDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtMemoRemoveDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoRemoveDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoRemoveDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentId_Internalname, context.GetMessage( "Resident", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMemoCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMemoCreatedAt_Internalname, context.GetMessage( "Created At", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMemoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMemoCreatedAt_Internalname, context.localUtil.TToC( A647MemoCreatedAt, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A647MemoCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoCreatedAt_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMemoCreatedAt_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_bitmap( context, edtMemoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMemoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Memo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMemoId_Internalname, A549MemoId.ToString(), A549MemoId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMemoId_Jsonclick, 0, "Attribute", "", "", "", "", edtMemoId_Visible, edtMemoId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Memo.htm");
         AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", cmbResidentSalutation.Visible, cmbResidentSalutation.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "", true, 0, "HLP_Trn_Memo.htm");
         cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), true);
         /* Single line edit */
         AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGivenName_Visible, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Memo.htm");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, edtResidentGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Memo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z549MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z549MemoId"));
               Z550MemoTitle = cgiGet( sPrefix+"Z550MemoTitle");
               Z551MemoDescription = cgiGet( sPrefix+"Z551MemoDescription");
               Z553MemoDocument = cgiGet( sPrefix+"Z553MemoDocument");
               n553MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A553MemoDocument)) ? true : false);
               Z561MemoStartDateTime = context.localUtil.CToT( cgiGet( sPrefix+"Z561MemoStartDateTime"), 0);
               n561MemoStartDateTime = ((DateTime.MinValue==A561MemoStartDateTime) ? true : false);
               Z562MemoEndDateTime = context.localUtil.CToT( cgiGet( sPrefix+"Z562MemoEndDateTime"), 0);
               n562MemoEndDateTime = ((DateTime.MinValue==A562MemoEndDateTime) ? true : false);
               Z563MemoDuration = context.localUtil.CToN( cgiGet( sPrefix+"Z563MemoDuration"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n563MemoDuration = ((Convert.ToDecimal(0)==A563MemoDuration) ? true : false);
               Z564MemoRemoveDate = context.localUtil.CToD( cgiGet( sPrefix+"Z564MemoRemoveDate"), 0);
               n564MemoRemoveDate = ((DateTime.MinValue==A564MemoRemoveDate) ? true : false);
               Z566MemoBgColorCode = cgiGet( sPrefix+"Z566MemoBgColorCode");
               n566MemoBgColorCode = (String.IsNullOrEmpty(StringUtil.RTrim( A566MemoBgColorCode)) ? true : false);
               Z567MemoForm = cgiGet( sPrefix+"Z567MemoForm");
               Z624MemoType = cgiGet( sPrefix+"Z624MemoType");
               Z625MemoName = cgiGet( sPrefix+"Z625MemoName");
               Z626MemoLeftOffset = context.localUtil.CToN( cgiGet( sPrefix+"Z626MemoLeftOffset"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z627MemoTopOffset = context.localUtil.CToN( cgiGet( sPrefix+"Z627MemoTopOffset"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z628MemoTitleAngle = context.localUtil.CToN( cgiGet( sPrefix+"Z628MemoTitleAngle"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z629MemoTitleScale = context.localUtil.CToN( cgiGet( sPrefix+"Z629MemoTitleScale"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z637MemoTextFontName = cgiGet( sPrefix+"Z637MemoTextFontName");
               Z638MemoTextAlignment = cgiGet( sPrefix+"Z638MemoTextAlignment");
               Z639MemoIsBold = StringUtil.StrToBool( cgiGet( sPrefix+"Z639MemoIsBold"));
               Z640MemoIsItalic = StringUtil.StrToBool( cgiGet( sPrefix+"Z640MemoIsItalic"));
               Z641MemoIsCapitalized = StringUtil.StrToBool( cgiGet( sPrefix+"Z641MemoIsCapitalized"));
               Z642MemoTextColor = cgiGet( sPrefix+"Z642MemoTextColor");
               Z647MemoCreatedAt = context.localUtil.CToT( cgiGet( sPrefix+"Z647MemoCreatedAt"), 0);
               n647MemoCreatedAt = ((DateTime.MinValue==A647MemoCreatedAt) ? true : false);
               Z62ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z62ResidentId"));
               Z528SG_LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z528SG_LocationId"));
               Z529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z529SG_OrganisationId"));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV7MemoId"));
               A566MemoBgColorCode = cgiGet( sPrefix+"Z566MemoBgColorCode");
               n566MemoBgColorCode = false;
               n566MemoBgColorCode = (String.IsNullOrEmpty(StringUtil.RTrim( A566MemoBgColorCode)) ? true : false);
               A567MemoForm = cgiGet( sPrefix+"Z567MemoForm");
               A624MemoType = cgiGet( sPrefix+"Z624MemoType");
               A625MemoName = cgiGet( sPrefix+"Z625MemoName");
               A626MemoLeftOffset = context.localUtil.CToN( cgiGet( sPrefix+"Z626MemoLeftOffset"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A627MemoTopOffset = context.localUtil.CToN( cgiGet( sPrefix+"Z627MemoTopOffset"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A628MemoTitleAngle = context.localUtil.CToN( cgiGet( sPrefix+"Z628MemoTitleAngle"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A629MemoTitleScale = context.localUtil.CToN( cgiGet( sPrefix+"Z629MemoTitleScale"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A637MemoTextFontName = cgiGet( sPrefix+"Z637MemoTextFontName");
               A638MemoTextAlignment = cgiGet( sPrefix+"Z638MemoTextAlignment");
               A639MemoIsBold = StringUtil.StrToBool( cgiGet( sPrefix+"Z639MemoIsBold"));
               A640MemoIsItalic = StringUtil.StrToBool( cgiGet( sPrefix+"Z640MemoIsItalic"));
               A641MemoIsCapitalized = StringUtil.StrToBool( cgiGet( sPrefix+"Z641MemoIsCapitalized"));
               A642MemoTextColor = cgiGet( sPrefix+"Z642MemoTextColor");
               A528SG_LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z528SG_LocationId"));
               A529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"Z529SG_OrganisationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N62ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"N62ResidentId"));
               N529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"N529SG_OrganisationId"));
               N528SG_LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"N528SG_LocationId"));
               AV7MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"vMEMOID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV26Insert_ResidentId = StringUtil.StrToGuid( cgiGet( sPrefix+"vINSERT_RESIDENTID"));
               AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"vINSERT_SG_ORGANISATIONID"));
               A529SG_OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"SG_ORGANISATIONID"));
               AV30Insert_SG_LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"vINSERT_SG_LOCATIONID"));
               A528SG_LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"SG_LOCATIONID"));
               A566MemoBgColorCode = cgiGet( sPrefix+"MEMOBGCOLORCODE");
               n566MemoBgColorCode = (String.IsNullOrEmpty(StringUtil.RTrim( A566MemoBgColorCode)) ? true : false);
               A567MemoForm = cgiGet( sPrefix+"MEMOFORM");
               A624MemoType = cgiGet( sPrefix+"MEMOTYPE");
               A625MemoName = cgiGet( sPrefix+"MEMONAME");
               A626MemoLeftOffset = context.localUtil.CToN( cgiGet( sPrefix+"MEMOLEFTOFFSET"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A627MemoTopOffset = context.localUtil.CToN( cgiGet( sPrefix+"MEMOTOPOFFSET"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A628MemoTitleAngle = context.localUtil.CToN( cgiGet( sPrefix+"MEMOTITLEANGLE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A629MemoTitleScale = context.localUtil.CToN( cgiGet( sPrefix+"MEMOTITLESCALE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A637MemoTextFontName = cgiGet( sPrefix+"MEMOTEXTFONTNAME");
               A638MemoTextAlignment = cgiGet( sPrefix+"MEMOTEXTALIGNMENT");
               A639MemoIsBold = StringUtil.StrToBool( cgiGet( sPrefix+"MEMOISBOLD"));
               A640MemoIsItalic = StringUtil.StrToBool( cgiGet( sPrefix+"MEMOISITALIC"));
               A641MemoIsCapitalized = StringUtil.StrToBool( cgiGet( sPrefix+"MEMOISCAPITALIZED"));
               A642MemoTextColor = cgiGet( sPrefix+"MEMOTEXTCOLOR");
               A65ResidentLastName = cgiGet( sPrefix+"RESIDENTLASTNAME");
               AV32Pgmname = cgiGet( sPrefix+"vPGMNAME");
               /* Read variables values. */
               A550MemoTitle = cgiGet( edtMemoTitle_Internalname);
               AssignAttri(sPrefix, false, "A550MemoTitle", A550MemoTitle);
               A551MemoDescription = cgiGet( edtMemoDescription_Internalname);
               AssignAttri(sPrefix, false, "A551MemoDescription", A551MemoDescription);
               A552MemoImage = cgiGet( edtMemoImage_Internalname);
               n552MemoImage = false;
               AssignAttri(sPrefix, false, "A552MemoImage", A552MemoImage);
               n552MemoImage = (String.IsNullOrEmpty(StringUtil.RTrim( A552MemoImage)) ? true : false);
               A553MemoDocument = cgiGet( edtMemoDocument_Internalname);
               n553MemoDocument = false;
               AssignAttri(sPrefix, false, "A553MemoDocument", A553MemoDocument);
               n553MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A553MemoDocument)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtMemoStartDateTime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Memo Start Date Time", "")}), 1, "MEMOSTARTDATETIME");
                  AnyError = 1;
                  GX_FocusControl = edtMemoStartDateTime_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
                  n561MemoStartDateTime = false;
                  AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A561MemoStartDateTime = context.localUtil.CToT( cgiGet( edtMemoStartDateTime_Internalname));
                  n561MemoStartDateTime = false;
                  AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n561MemoStartDateTime = ((DateTime.MinValue==A561MemoStartDateTime) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtMemoEndDateTime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Memo End Date Time", "")}), 1, "MEMOENDDATETIME");
                  AnyError = 1;
                  GX_FocusControl = edtMemoEndDateTime_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
                  n562MemoEndDateTime = false;
                  AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A562MemoEndDateTime = context.localUtil.CToT( cgiGet( edtMemoEndDateTime_Internalname));
                  n562MemoEndDateTime = false;
                  AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n562MemoEndDateTime = ((DateTime.MinValue==A562MemoEndDateTime) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MEMODURATION");
                  AnyError = 1;
                  GX_FocusControl = edtMemoDuration_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A563MemoDuration = 0;
                  n563MemoDuration = false;
                  AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
               }
               else
               {
                  A563MemoDuration = context.localUtil.CToN( cgiGet( edtMemoDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n563MemoDuration = false;
                  AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
               }
               n563MemoDuration = ((Convert.ToDecimal(0)==A563MemoDuration) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtMemoRemoveDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Memo Remove Date", "")}), 1, "MEMOREMOVEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtMemoRemoveDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A564MemoRemoveDate = DateTime.MinValue;
                  n564MemoRemoveDate = false;
                  AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
               }
               else
               {
                  A564MemoRemoveDate = context.localUtil.CToD( cgiGet( edtMemoRemoveDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  n564MemoRemoveDate = false;
                  AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
               }
               n564MemoRemoveDate = ((DateTime.MinValue==A564MemoRemoveDate) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtResidentId_Internalname), "") == 0 )
               {
                  A62ResidentId = Guid.Empty;
                  AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
               }
               else
               {
                  try
                  {
                     A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
                     AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RESIDENTID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A647MemoCreatedAt = context.localUtil.CToT( cgiGet( edtMemoCreatedAt_Internalname));
               n647MemoCreatedAt = false;
               AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( StringUtil.StrCmp(cgiGet( edtMemoId_Internalname), "") == 0 )
               {
                  A549MemoId = Guid.Empty;
                  AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
               }
               else
               {
                  try
                  {
                     A549MemoId = StringUtil.StrToGuid( cgiGet( edtMemoId_Internalname));
                     AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "MEMOID");
                     AnyError = 1;
                     GX_FocusControl = edtMemoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
               A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
               AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
               A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
               AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
               A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
               AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_Memo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("MemoBgColorCode", StringUtil.RTrim( context.localUtil.Format( A566MemoBgColorCode, "")));
               forbiddenHiddens.Add("MemoForm", StringUtil.RTrim( context.localUtil.Format( A567MemoForm, "")));
               forbiddenHiddens.Add("MemoType", StringUtil.RTrim( context.localUtil.Format( A624MemoType, "")));
               forbiddenHiddens.Add("MemoName", StringUtil.RTrim( context.localUtil.Format( A625MemoName, "")));
               forbiddenHiddens.Add("MemoLeftOffset", context.localUtil.Format( A626MemoLeftOffset, "Z9.999"));
               forbiddenHiddens.Add("MemoTopOffset", context.localUtil.Format( A627MemoTopOffset, "Z9.999"));
               forbiddenHiddens.Add("MemoTitleAngle", context.localUtil.Format( A628MemoTitleAngle, "Z9.999"));
               forbiddenHiddens.Add("MemoTitleScale", context.localUtil.Format( A629MemoTitleScale, "Z9.999"));
               forbiddenHiddens.Add("MemoTextFontName", StringUtil.RTrim( context.localUtil.Format( A637MemoTextFontName, "")));
               forbiddenHiddens.Add("MemoTextAlignment", StringUtil.RTrim( context.localUtil.Format( A638MemoTextAlignment, "")));
               forbiddenHiddens.Add("MemoIsBold", StringUtil.BoolToStr( A639MemoIsBold));
               forbiddenHiddens.Add("MemoIsItalic", StringUtil.BoolToStr( A640MemoIsItalic));
               forbiddenHiddens.Add("MemoIsCapitalized", StringUtil.BoolToStr( A641MemoIsCapitalized));
               forbiddenHiddens.Add("MemoTextColor", StringUtil.RTrim( context.localUtil.Format( A642MemoTextColor, "")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A549MemoId != Z549MemoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_memo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A549MemoId = StringUtil.StrToGuid( GetPar( "MemoId"));
                  AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7MemoId) )
                  {
                     A549MemoId = AV7MemoId;
                     AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A549MemoId) && ( Gx_BScreen == 0 ) )
                     {
                        A549MemoId = Guid.NewGuid( );
                        AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode100 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7MemoId) )
                     {
                        A549MemoId = AV7MemoId;
                        AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A549MemoId) && ( Gx_BScreen == 0 ) )
                        {
                           A549MemoId = Guid.NewGuid( );
                           AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                        }
                     }
                     Gx_mode = sMode100;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound100 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MEMOID");
                        AnyError = 1;
                        GX_FocusControl = edtMemoId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E111P2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E121P2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E121P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1P100( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1P100( ) ;
         }
         AssignProp(sPrefix, false, edtMemoTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoTitle_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDescription_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoImage_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoDocument_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDocument_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoStartDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoStartDateTime_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoEndDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoEndDateTime_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDuration_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtMemoRemoveDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoRemoveDate_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P100( ) ;
            }
            else
            {
               CheckExtendedTable1P100( ) ;
               CloseExtendedTableCursors1P100( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1P0( )
      {
      }

      protected void E111P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri(sPrefix, false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ResidentId") == 0 )
               {
                  AV26Insert_ResidentId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri(sPrefix, false, "AV26Insert_ResidentId", AV26Insert_ResidentId.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri(sPrefix, false, "AV29Insert_SG_OrganisationId", AV29Insert_SG_OrganisationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV30Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri(sPrefix, false, "AV30Insert_SG_LocationId", AV30Insert_SG_LocationId.ToString());
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri(sPrefix, false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtMemoId_Visible = 0;
         AssignProp(sPrefix, false, edtMemoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMemoId_Visible), 5, 0), true);
         cmbResidentSalutation.Visible = 0;
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Visible), 5, 0), true);
         edtResidentGivenName_Visible = 0;
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
      }

      protected void E121P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_memoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1P100( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z550MemoTitle = T001P3_A550MemoTitle[0];
               Z551MemoDescription = T001P3_A551MemoDescription[0];
               Z553MemoDocument = T001P3_A553MemoDocument[0];
               Z561MemoStartDateTime = T001P3_A561MemoStartDateTime[0];
               Z562MemoEndDateTime = T001P3_A562MemoEndDateTime[0];
               Z563MemoDuration = T001P3_A563MemoDuration[0];
               Z564MemoRemoveDate = T001P3_A564MemoRemoveDate[0];
               Z566MemoBgColorCode = T001P3_A566MemoBgColorCode[0];
               Z567MemoForm = T001P3_A567MemoForm[0];
               Z624MemoType = T001P3_A624MemoType[0];
               Z625MemoName = T001P3_A625MemoName[0];
               Z626MemoLeftOffset = T001P3_A626MemoLeftOffset[0];
               Z627MemoTopOffset = T001P3_A627MemoTopOffset[0];
               Z628MemoTitleAngle = T001P3_A628MemoTitleAngle[0];
               Z629MemoTitleScale = T001P3_A629MemoTitleScale[0];
               Z637MemoTextFontName = T001P3_A637MemoTextFontName[0];
               Z638MemoTextAlignment = T001P3_A638MemoTextAlignment[0];
               Z639MemoIsBold = T001P3_A639MemoIsBold[0];
               Z640MemoIsItalic = T001P3_A640MemoIsItalic[0];
               Z641MemoIsCapitalized = T001P3_A641MemoIsCapitalized[0];
               Z642MemoTextColor = T001P3_A642MemoTextColor[0];
               Z647MemoCreatedAt = T001P3_A647MemoCreatedAt[0];
               Z62ResidentId = T001P3_A62ResidentId[0];
               Z528SG_LocationId = T001P3_A528SG_LocationId[0];
               Z529SG_OrganisationId = T001P3_A529SG_OrganisationId[0];
            }
            else
            {
               Z550MemoTitle = A550MemoTitle;
               Z551MemoDescription = A551MemoDescription;
               Z553MemoDocument = A553MemoDocument;
               Z561MemoStartDateTime = A561MemoStartDateTime;
               Z562MemoEndDateTime = A562MemoEndDateTime;
               Z563MemoDuration = A563MemoDuration;
               Z564MemoRemoveDate = A564MemoRemoveDate;
               Z566MemoBgColorCode = A566MemoBgColorCode;
               Z567MemoForm = A567MemoForm;
               Z624MemoType = A624MemoType;
               Z625MemoName = A625MemoName;
               Z626MemoLeftOffset = A626MemoLeftOffset;
               Z627MemoTopOffset = A627MemoTopOffset;
               Z628MemoTitleAngle = A628MemoTitleAngle;
               Z629MemoTitleScale = A629MemoTitleScale;
               Z637MemoTextFontName = A637MemoTextFontName;
               Z638MemoTextAlignment = A638MemoTextAlignment;
               Z639MemoIsBold = A639MemoIsBold;
               Z640MemoIsItalic = A640MemoIsItalic;
               Z641MemoIsCapitalized = A641MemoIsCapitalized;
               Z642MemoTextColor = A642MemoTextColor;
               Z647MemoCreatedAt = A647MemoCreatedAt;
               Z62ResidentId = A62ResidentId;
               Z528SG_LocationId = A528SG_LocationId;
               Z529SG_OrganisationId = A529SG_OrganisationId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z549MemoId = A549MemoId;
            Z550MemoTitle = A550MemoTitle;
            Z551MemoDescription = A551MemoDescription;
            Z552MemoImage = A552MemoImage;
            Z553MemoDocument = A553MemoDocument;
            Z561MemoStartDateTime = A561MemoStartDateTime;
            Z562MemoEndDateTime = A562MemoEndDateTime;
            Z563MemoDuration = A563MemoDuration;
            Z564MemoRemoveDate = A564MemoRemoveDate;
            Z566MemoBgColorCode = A566MemoBgColorCode;
            Z567MemoForm = A567MemoForm;
            Z624MemoType = A624MemoType;
            Z625MemoName = A625MemoName;
            Z626MemoLeftOffset = A626MemoLeftOffset;
            Z627MemoTopOffset = A627MemoTopOffset;
            Z628MemoTitleAngle = A628MemoTitleAngle;
            Z629MemoTitleScale = A629MemoTitleScale;
            Z637MemoTextFontName = A637MemoTextFontName;
            Z638MemoTextAlignment = A638MemoTextAlignment;
            Z639MemoIsBold = A639MemoIsBold;
            Z640MemoIsItalic = A640MemoIsItalic;
            Z641MemoIsCapitalized = A641MemoIsCapitalized;
            Z642MemoTextColor = A642MemoTextColor;
            Z647MemoCreatedAt = A647MemoCreatedAt;
            Z62ResidentId = A62ResidentId;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMemoCreatedAt_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCreatedAt_Enabled), 5, 0), true);
         AV32Pgmname = "Trn_Memo";
         AssignAttri(sPrefix, false, "AV32Pgmname", AV32Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtMemoCreatedAt_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCreatedAt_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            edtMemoId_Enabled = 0;
            AssignProp(sPrefix, false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         else
         {
            edtMemoId_Enabled = 1;
            AssignProp(sPrefix, false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            edtMemoId_Enabled = 0;
            AssignProp(sPrefix, false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV26Insert_ResidentId) )
         {
            edtResidentId_Enabled = 0;
            AssignProp(sPrefix, false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentId_Enabled = 1;
            AssignProp(sPrefix, false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV30Insert_SG_LocationId) )
         {
            A528SG_LocationId = AV30Insert_SG_LocationId;
            AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV29Insert_SG_OrganisationId) )
         {
            A529SG_OrganisationId = AV29Insert_SG_OrganisationId;
            AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV26Insert_ResidentId) )
         {
            A62ResidentId = AV26Insert_ResidentId;
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7MemoId) )
         {
            A549MemoId = AV7MemoId;
            AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A549MemoId) && ( Gx_BScreen == 0 ) )
            {
               A549MemoId = Guid.NewGuid( );
               AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A647MemoCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A647MemoCreatedAt = DateTimeUtil.Now( context);
            n647MemoCreatedAt = false;
            AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001P4 */
            pr_default.execute(2, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
            A72ResidentSalutation = T001P4_A72ResidentSalutation[0];
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001P4_A64ResidentGivenName[0];
            AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001P4_A65ResidentLastName[0];
            A71ResidentGUID = T001P4_A71ResidentGUID[0];
            AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
            pr_default.close(2);
         }
      }

      protected void Load1P100( )
      {
         /* Using cursor T001P5 */
         pr_default.execute(3, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound100 = 1;
            A29LocationId = T001P5_A29LocationId[0];
            A11OrganisationId = T001P5_A11OrganisationId[0];
            A550MemoTitle = T001P5_A550MemoTitle[0];
            AssignAttri(sPrefix, false, "A550MemoTitle", A550MemoTitle);
            A551MemoDescription = T001P5_A551MemoDescription[0];
            AssignAttri(sPrefix, false, "A551MemoDescription", A551MemoDescription);
            A552MemoImage = T001P5_A552MemoImage[0];
            n552MemoImage = T001P5_n552MemoImage[0];
            AssignAttri(sPrefix, false, "A552MemoImage", A552MemoImage);
            A553MemoDocument = T001P5_A553MemoDocument[0];
            n553MemoDocument = T001P5_n553MemoDocument[0];
            AssignAttri(sPrefix, false, "A553MemoDocument", A553MemoDocument);
            A561MemoStartDateTime = T001P5_A561MemoStartDateTime[0];
            n561MemoStartDateTime = T001P5_n561MemoStartDateTime[0];
            AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A562MemoEndDateTime = T001P5_A562MemoEndDateTime[0];
            n562MemoEndDateTime = T001P5_n562MemoEndDateTime[0];
            AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A563MemoDuration = T001P5_A563MemoDuration[0];
            n563MemoDuration = T001P5_n563MemoDuration[0];
            AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
            A564MemoRemoveDate = T001P5_A564MemoRemoveDate[0];
            n564MemoRemoveDate = T001P5_n564MemoRemoveDate[0];
            AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
            A72ResidentSalutation = T001P5_A72ResidentSalutation[0];
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001P5_A64ResidentGivenName[0];
            AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001P5_A65ResidentLastName[0];
            A71ResidentGUID = T001P5_A71ResidentGUID[0];
            AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
            A566MemoBgColorCode = T001P5_A566MemoBgColorCode[0];
            n566MemoBgColorCode = T001P5_n566MemoBgColorCode[0];
            A567MemoForm = T001P5_A567MemoForm[0];
            A624MemoType = T001P5_A624MemoType[0];
            A625MemoName = T001P5_A625MemoName[0];
            A626MemoLeftOffset = T001P5_A626MemoLeftOffset[0];
            A627MemoTopOffset = T001P5_A627MemoTopOffset[0];
            A628MemoTitleAngle = T001P5_A628MemoTitleAngle[0];
            A629MemoTitleScale = T001P5_A629MemoTitleScale[0];
            A637MemoTextFontName = T001P5_A637MemoTextFontName[0];
            A638MemoTextAlignment = T001P5_A638MemoTextAlignment[0];
            A639MemoIsBold = T001P5_A639MemoIsBold[0];
            A640MemoIsItalic = T001P5_A640MemoIsItalic[0];
            A641MemoIsCapitalized = T001P5_A641MemoIsCapitalized[0];
            A642MemoTextColor = T001P5_A642MemoTextColor[0];
            A647MemoCreatedAt = T001P5_A647MemoCreatedAt[0];
            n647MemoCreatedAt = T001P5_n647MemoCreatedAt[0];
            AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A62ResidentId = T001P5_A62ResidentId[0];
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
            A528SG_LocationId = T001P5_A528SG_LocationId[0];
            A529SG_OrganisationId = T001P5_A529SG_OrganisationId[0];
            ZM1P100( -17) ;
         }
         pr_default.close(3);
         OnLoadActions1P100( ) ;
      }

      protected void OnLoadActions1P100( )
      {
      }

      protected void CheckExtendedTable1P100( )
      {
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001P4 */
         pr_default.execute(2, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001P4_A72ResidentSalutation[0];
         AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = T001P4_A64ResidentGivenName[0];
         AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001P4_A65ResidentLastName[0];
         A71ResidentGUID = T001P4_A71ResidentGUID[0];
         AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1P100( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( Guid A62ResidentId ,
                                Guid A528SG_LocationId ,
                                Guid A529SG_OrganisationId )
      {
         /* Using cursor T001P6 */
         pr_default.execute(4, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A72ResidentSalutation = T001P6_A72ResidentSalutation[0];
         AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = T001P6_A64ResidentGivenName[0];
         AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = T001P6_A65ResidentLastName[0];
         A71ResidentGUID = T001P6_A71ResidentGUID[0];
         AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A72ResidentSalutation))+"\""+","+"\""+GXUtil.EncodeJSConstant( A64ResidentGivenName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A65ResidentLastName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A71ResidentGUID)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1P100( )
      {
         /* Using cursor T001P7 */
         pr_default.execute(5, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound100 = 1;
         }
         else
         {
            RcdFound100 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001P3 */
         pr_default.execute(1, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P100( 17) ;
            RcdFound100 = 1;
            A549MemoId = T001P3_A549MemoId[0];
            AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
            A550MemoTitle = T001P3_A550MemoTitle[0];
            AssignAttri(sPrefix, false, "A550MemoTitle", A550MemoTitle);
            A551MemoDescription = T001P3_A551MemoDescription[0];
            AssignAttri(sPrefix, false, "A551MemoDescription", A551MemoDescription);
            A552MemoImage = T001P3_A552MemoImage[0];
            n552MemoImage = T001P3_n552MemoImage[0];
            AssignAttri(sPrefix, false, "A552MemoImage", A552MemoImage);
            A553MemoDocument = T001P3_A553MemoDocument[0];
            n553MemoDocument = T001P3_n553MemoDocument[0];
            AssignAttri(sPrefix, false, "A553MemoDocument", A553MemoDocument);
            A561MemoStartDateTime = T001P3_A561MemoStartDateTime[0];
            n561MemoStartDateTime = T001P3_n561MemoStartDateTime[0];
            AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A562MemoEndDateTime = T001P3_A562MemoEndDateTime[0];
            n562MemoEndDateTime = T001P3_n562MemoEndDateTime[0];
            AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A563MemoDuration = T001P3_A563MemoDuration[0];
            n563MemoDuration = T001P3_n563MemoDuration[0];
            AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
            A564MemoRemoveDate = T001P3_A564MemoRemoveDate[0];
            n564MemoRemoveDate = T001P3_n564MemoRemoveDate[0];
            AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
            A566MemoBgColorCode = T001P3_A566MemoBgColorCode[0];
            n566MemoBgColorCode = T001P3_n566MemoBgColorCode[0];
            A567MemoForm = T001P3_A567MemoForm[0];
            A624MemoType = T001P3_A624MemoType[0];
            A625MemoName = T001P3_A625MemoName[0];
            A626MemoLeftOffset = T001P3_A626MemoLeftOffset[0];
            A627MemoTopOffset = T001P3_A627MemoTopOffset[0];
            A628MemoTitleAngle = T001P3_A628MemoTitleAngle[0];
            A629MemoTitleScale = T001P3_A629MemoTitleScale[0];
            A637MemoTextFontName = T001P3_A637MemoTextFontName[0];
            A638MemoTextAlignment = T001P3_A638MemoTextAlignment[0];
            A639MemoIsBold = T001P3_A639MemoIsBold[0];
            A640MemoIsItalic = T001P3_A640MemoIsItalic[0];
            A641MemoIsCapitalized = T001P3_A641MemoIsCapitalized[0];
            A642MemoTextColor = T001P3_A642MemoTextColor[0];
            A647MemoCreatedAt = T001P3_A647MemoCreatedAt[0];
            n647MemoCreatedAt = T001P3_n647MemoCreatedAt[0];
            AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A62ResidentId = T001P3_A62ResidentId[0];
            AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
            A528SG_LocationId = T001P3_A528SG_LocationId[0];
            A529SG_OrganisationId = T001P3_A529SG_OrganisationId[0];
            Z549MemoId = A549MemoId;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load1P100( ) ;
            if ( AnyError == 1 )
            {
               RcdFound100 = 0;
               InitializeNonKey1P100( ) ;
            }
            Gx_mode = sMode100;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound100 = 0;
            InitializeNonKey1P100( ) ;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode100;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P100( ) ;
         if ( RcdFound100 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound100 = 0;
         /* Using cursor T001P8 */
         pr_default.execute(6, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001P8_A549MemoId[0], A549MemoId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T001P8_A549MemoId[0], A549MemoId, 0) > 0 ) ) )
            {
               A549MemoId = T001P8_A549MemoId[0];
               AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
               RcdFound100 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound100 = 0;
         /* Using cursor T001P9 */
         pr_default.execute(7, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001P9_A549MemoId[0], A549MemoId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001P9_A549MemoId[0], A549MemoId, 0) < 0 ) ) )
            {
               A549MemoId = T001P9_A549MemoId[0];
               AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
               RcdFound100 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1P100( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMemoTitle_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert1P100( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound100 == 1 )
            {
               if ( A549MemoId != Z549MemoId )
               {
                  A549MemoId = Z549MemoId;
                  AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MEMOID");
                  AnyError = 1;
                  GX_FocusControl = edtMemoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMemoTitle_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1P100( ) ;
                  GX_FocusControl = edtMemoTitle_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A549MemoId != Z549MemoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMemoTitle_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert1P100( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MEMOID");
                     AnyError = 1;
                     GX_FocusControl = edtMemoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMemoTitle_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert1P100( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A549MemoId != Z549MemoId )
         {
            A549MemoId = Z549MemoId;
            AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MEMOID");
            AnyError = 1;
            GX_FocusControl = edtMemoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMemoTitle_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1P100( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001P2 */
            pr_default.execute(0, new Object[] {A549MemoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z550MemoTitle, T001P2_A550MemoTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z551MemoDescription, T001P2_A551MemoDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z553MemoDocument, T001P2_A553MemoDocument[0]) != 0 ) || ( Z561MemoStartDateTime != T001P2_A561MemoStartDateTime[0] ) || ( Z562MemoEndDateTime != T001P2_A562MemoEndDateTime[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z563MemoDuration != T001P2_A563MemoDuration[0] ) || ( DateTimeUtil.ResetTime ( Z564MemoRemoveDate ) != DateTimeUtil.ResetTime ( T001P2_A564MemoRemoveDate[0] ) ) || ( StringUtil.StrCmp(Z566MemoBgColorCode, T001P2_A566MemoBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z567MemoForm, T001P2_A567MemoForm[0]) != 0 ) || ( StringUtil.StrCmp(Z624MemoType, T001P2_A624MemoType[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z625MemoName, T001P2_A625MemoName[0]) != 0 ) || ( Z626MemoLeftOffset != T001P2_A626MemoLeftOffset[0] ) || ( Z627MemoTopOffset != T001P2_A627MemoTopOffset[0] ) || ( Z628MemoTitleAngle != T001P2_A628MemoTitleAngle[0] ) || ( Z629MemoTitleScale != T001P2_A629MemoTitleScale[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z637MemoTextFontName, T001P2_A637MemoTextFontName[0]) != 0 ) || ( StringUtil.StrCmp(Z638MemoTextAlignment, T001P2_A638MemoTextAlignment[0]) != 0 ) || ( Z639MemoIsBold != T001P2_A639MemoIsBold[0] ) || ( Z640MemoIsItalic != T001P2_A640MemoIsItalic[0] ) || ( Z641MemoIsCapitalized != T001P2_A641MemoIsCapitalized[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z642MemoTextColor, T001P2_A642MemoTextColor[0]) != 0 ) || ( Z647MemoCreatedAt != T001P2_A647MemoCreatedAt[0] ) || ( Z62ResidentId != T001P2_A62ResidentId[0] ) || ( Z528SG_LocationId != T001P2_A528SG_LocationId[0] ) || ( Z529SG_OrganisationId != T001P2_A529SG_OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z550MemoTitle, T001P2_A550MemoTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTitle");
                  GXUtil.WriteLogRaw("Old: ",Z550MemoTitle);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A550MemoTitle[0]);
               }
               if ( StringUtil.StrCmp(Z551MemoDescription, T001P2_A551MemoDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDescription");
                  GXUtil.WriteLogRaw("Old: ",Z551MemoDescription);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A551MemoDescription[0]);
               }
               if ( StringUtil.StrCmp(Z553MemoDocument, T001P2_A553MemoDocument[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDocument");
                  GXUtil.WriteLogRaw("Old: ",Z553MemoDocument);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A553MemoDocument[0]);
               }
               if ( Z561MemoStartDateTime != T001P2_A561MemoStartDateTime[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoStartDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z561MemoStartDateTime);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A561MemoStartDateTime[0]);
               }
               if ( Z562MemoEndDateTime != T001P2_A562MemoEndDateTime[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoEndDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z562MemoEndDateTime);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A562MemoEndDateTime[0]);
               }
               if ( Z563MemoDuration != T001P2_A563MemoDuration[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoDuration");
                  GXUtil.WriteLogRaw("Old: ",Z563MemoDuration);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A563MemoDuration[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z564MemoRemoveDate ) != DateTimeUtil.ResetTime ( T001P2_A564MemoRemoveDate[0] ) )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoRemoveDate");
                  GXUtil.WriteLogRaw("Old: ",Z564MemoRemoveDate);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A564MemoRemoveDate[0]);
               }
               if ( StringUtil.StrCmp(Z566MemoBgColorCode, T001P2_A566MemoBgColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoBgColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z566MemoBgColorCode);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A566MemoBgColorCode[0]);
               }
               if ( StringUtil.StrCmp(Z567MemoForm, T001P2_A567MemoForm[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoForm");
                  GXUtil.WriteLogRaw("Old: ",Z567MemoForm);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A567MemoForm[0]);
               }
               if ( StringUtil.StrCmp(Z624MemoType, T001P2_A624MemoType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoType");
                  GXUtil.WriteLogRaw("Old: ",Z624MemoType);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A624MemoType[0]);
               }
               if ( StringUtil.StrCmp(Z625MemoName, T001P2_A625MemoName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoName");
                  GXUtil.WriteLogRaw("Old: ",Z625MemoName);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A625MemoName[0]);
               }
               if ( Z626MemoLeftOffset != T001P2_A626MemoLeftOffset[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoLeftOffset");
                  GXUtil.WriteLogRaw("Old: ",Z626MemoLeftOffset);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A626MemoLeftOffset[0]);
               }
               if ( Z627MemoTopOffset != T001P2_A627MemoTopOffset[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTopOffset");
                  GXUtil.WriteLogRaw("Old: ",Z627MemoTopOffset);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A627MemoTopOffset[0]);
               }
               if ( Z628MemoTitleAngle != T001P2_A628MemoTitleAngle[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTitleAngle");
                  GXUtil.WriteLogRaw("Old: ",Z628MemoTitleAngle);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A628MemoTitleAngle[0]);
               }
               if ( Z629MemoTitleScale != T001P2_A629MemoTitleScale[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTitleScale");
                  GXUtil.WriteLogRaw("Old: ",Z629MemoTitleScale);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A629MemoTitleScale[0]);
               }
               if ( StringUtil.StrCmp(Z637MemoTextFontName, T001P2_A637MemoTextFontName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTextFontName");
                  GXUtil.WriteLogRaw("Old: ",Z637MemoTextFontName);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A637MemoTextFontName[0]);
               }
               if ( StringUtil.StrCmp(Z638MemoTextAlignment, T001P2_A638MemoTextAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTextAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z638MemoTextAlignment);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A638MemoTextAlignment[0]);
               }
               if ( Z639MemoIsBold != T001P2_A639MemoIsBold[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoIsBold");
                  GXUtil.WriteLogRaw("Old: ",Z639MemoIsBold);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A639MemoIsBold[0]);
               }
               if ( Z640MemoIsItalic != T001P2_A640MemoIsItalic[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoIsItalic");
                  GXUtil.WriteLogRaw("Old: ",Z640MemoIsItalic);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A640MemoIsItalic[0]);
               }
               if ( Z641MemoIsCapitalized != T001P2_A641MemoIsCapitalized[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoIsCapitalized");
                  GXUtil.WriteLogRaw("Old: ",Z641MemoIsCapitalized);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A641MemoIsCapitalized[0]);
               }
               if ( StringUtil.StrCmp(Z642MemoTextColor, T001P2_A642MemoTextColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoTextColor");
                  GXUtil.WriteLogRaw("Old: ",Z642MemoTextColor);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A642MemoTextColor[0]);
               }
               if ( Z647MemoCreatedAt != T001P2_A647MemoCreatedAt[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"MemoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z647MemoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A647MemoCreatedAt[0]);
               }
               if ( Z62ResidentId != T001P2_A62ResidentId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"ResidentId");
                  GXUtil.WriteLogRaw("Old: ",Z62ResidentId);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A62ResidentId[0]);
               }
               if ( Z528SG_LocationId != T001P2_A528SG_LocationId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"SG_LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z528SG_LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A528SG_LocationId[0]);
               }
               if ( Z529SG_OrganisationId != T001P2_A529SG_OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_memo:[seudo value changed for attri]"+"SG_OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z529SG_OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A529SG_OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Memo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P100( )
      {
         if ( ! IsAuthorized("trn_memo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P100( 0) ;
            CheckOptimisticConcurrency1P100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P10 */
                     pr_default.execute(8, new Object[] {A549MemoId, A550MemoTitle, A551MemoDescription, n552MemoImage, A552MemoImage, n553MemoDocument, A553MemoDocument, n561MemoStartDateTime, A561MemoStartDateTime, n562MemoEndDateTime, A562MemoEndDateTime, n563MemoDuration, A563MemoDuration, n564MemoRemoveDate, A564MemoRemoveDate, n566MemoBgColorCode, A566MemoBgColorCode, A567MemoForm, A624MemoType, A625MemoName, A626MemoLeftOffset, A627MemoTopOffset, A628MemoTitleAngle, A629MemoTitleScale, A637MemoTextFontName, A638MemoTextAlignment, A639MemoIsBold, A640MemoIsItalic, A641MemoIsCapitalized, A642MemoTextColor, n647MemoCreatedAt, A647MemoCreatedAt, A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1P100( ) ;
            }
            EndLevel1P100( ) ;
         }
         CloseExtendedTableCursors1P100( ) ;
      }

      protected void Update1P100( )
      {
         if ( ! IsAuthorized("trn_memo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P11 */
                     pr_default.execute(9, new Object[] {A550MemoTitle, A551MemoDescription, n552MemoImage, A552MemoImage, n553MemoDocument, A553MemoDocument, n561MemoStartDateTime, A561MemoStartDateTime, n562MemoEndDateTime, A562MemoEndDateTime, n563MemoDuration, A563MemoDuration, n564MemoRemoveDate, A564MemoRemoveDate, n566MemoBgColorCode, A566MemoBgColorCode, A567MemoForm, A624MemoType, A625MemoName, A626MemoLeftOffset, A627MemoTopOffset, A628MemoTitleAngle, A629MemoTitleScale, A637MemoTextFontName, A638MemoTextAlignment, A639MemoIsBold, A640MemoIsItalic, A641MemoIsCapitalized, A642MemoTextColor, n647MemoCreatedAt, A647MemoCreatedAt, A62ResidentId, A528SG_LocationId, A529SG_OrganisationId, A549MemoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P100( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1P100( ) ;
         }
         CloseExtendedTableCursors1P100( ) ;
      }

      protected void DeferredUpdate1P100( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_memo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P100( ) ;
            AfterConfirm1P100( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P100( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001P12 */
                  pr_default.execute(10, new Object[] {A549MemoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode100 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel1P100( ) ;
         Gx_mode = sMode100;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1P100( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001P13 */
            pr_default.execute(11, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
            A72ResidentSalutation = T001P13_A72ResidentSalutation[0];
            AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
            A64ResidentGivenName = T001P13_A64ResidentGivenName[0];
            AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T001P13_A65ResidentLastName[0];
            A71ResidentGUID = T001P13_A71ResidentGUID[0];
            AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
            pr_default.close(11);
         }
      }

      protected void EndLevel1P100( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_memo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_memo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1P100( )
      {
         /* Scan By routine */
         /* Using cursor T001P14 */
         pr_default.execute(12);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound100 = 1;
            A549MemoId = T001P14_A549MemoId[0];
            AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1P100( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound100 = 1;
            A549MemoId = T001P14_A549MemoId[0];
            AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
         }
      }

      protected void ScanEnd1P100( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1P100( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P100( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P100( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P100( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P100( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P100( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P100( )
      {
         edtMemoTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoTitle_Enabled), 5, 0), true);
         edtMemoDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDescription_Enabled), 5, 0), true);
         edtMemoImage_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoImage_Enabled), 5, 0), true);
         edtMemoDocument_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDocument_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDocument_Enabled), 5, 0), true);
         edtMemoStartDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoStartDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoStartDateTime_Enabled), 5, 0), true);
         edtMemoEndDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoEndDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoEndDateTime_Enabled), 5, 0), true);
         edtMemoDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoDuration_Enabled), 5, 0), true);
         edtMemoRemoveDate_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoRemoveDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoRemoveDate_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtMemoCreatedAt_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoCreatedAt_Enabled), 5, 0), true);
         edtMemoId_Enabled = 0;
         AssignProp(sPrefix, false, edtMemoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMemoId_Enabled), 5, 0), true);
         cmbResidentSalutation.Enabled = 0;
         AssignProp(sPrefix, false, cmbResidentSalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentSalutation.Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1P100( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1P0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Trn_Memo", "")) ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_memo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7MemoId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_memo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_Memo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("MemoBgColorCode", StringUtil.RTrim( context.localUtil.Format( A566MemoBgColorCode, "")));
         forbiddenHiddens.Add("MemoForm", StringUtil.RTrim( context.localUtil.Format( A567MemoForm, "")));
         forbiddenHiddens.Add("MemoType", StringUtil.RTrim( context.localUtil.Format( A624MemoType, "")));
         forbiddenHiddens.Add("MemoName", StringUtil.RTrim( context.localUtil.Format( A625MemoName, "")));
         forbiddenHiddens.Add("MemoLeftOffset", context.localUtil.Format( A626MemoLeftOffset, "Z9.999"));
         forbiddenHiddens.Add("MemoTopOffset", context.localUtil.Format( A627MemoTopOffset, "Z9.999"));
         forbiddenHiddens.Add("MemoTitleAngle", context.localUtil.Format( A628MemoTitleAngle, "Z9.999"));
         forbiddenHiddens.Add("MemoTitleScale", context.localUtil.Format( A629MemoTitleScale, "Z9.999"));
         forbiddenHiddens.Add("MemoTextFontName", StringUtil.RTrim( context.localUtil.Format( A637MemoTextFontName, "")));
         forbiddenHiddens.Add("MemoTextAlignment", StringUtil.RTrim( context.localUtil.Format( A638MemoTextAlignment, "")));
         forbiddenHiddens.Add("MemoIsBold", StringUtil.BoolToStr( A639MemoIsBold));
         forbiddenHiddens.Add("MemoIsItalic", StringUtil.BoolToStr( A640MemoIsItalic));
         forbiddenHiddens.Add("MemoIsCapitalized", StringUtil.BoolToStr( A641MemoIsCapitalized));
         forbiddenHiddens.Add("MemoTextColor", StringUtil.RTrim( context.localUtil.Format( A642MemoTextColor, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_memo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z549MemoId", Z549MemoId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"Z550MemoTitle", Z550MemoTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z551MemoDescription", Z551MemoDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z553MemoDocument", Z553MemoDocument);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z561MemoStartDateTime", context.localUtil.TToC( Z561MemoStartDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z562MemoEndDateTime", context.localUtil.TToC( Z562MemoEndDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z563MemoDuration", StringUtil.LTrim( StringUtil.NToC( Z563MemoDuration, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z564MemoRemoveDate", context.localUtil.DToC( Z564MemoRemoveDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z566MemoBgColorCode", Z566MemoBgColorCode);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z567MemoForm", StringUtil.RTrim( Z567MemoForm));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z624MemoType", Z624MemoType);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z625MemoName", Z625MemoName);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z626MemoLeftOffset", StringUtil.LTrim( StringUtil.NToC( Z626MemoLeftOffset, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z627MemoTopOffset", StringUtil.LTrim( StringUtil.NToC( Z627MemoTopOffset, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z628MemoTitleAngle", StringUtil.LTrim( StringUtil.NToC( Z628MemoTitleAngle, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z629MemoTitleScale", StringUtil.LTrim( StringUtil.NToC( Z629MemoTitleScale, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z637MemoTextFontName", Z637MemoTextFontName);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z638MemoTextAlignment", StringUtil.RTrim( Z638MemoTextAlignment));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z639MemoIsBold", Z639MemoIsBold);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z640MemoIsItalic", Z640MemoIsItalic);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z641MemoIsCapitalized", Z641MemoIsCapitalized);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z642MemoTextColor", Z642MemoTextColor);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z647MemoCreatedAt", context.localUtil.TToC( Z647MemoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z62ResidentId", Z62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"Z528SG_LocationId", Z528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"Z529SG_OrganisationId", Z529SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7MemoId", wcpOAV7MemoId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N62ResidentId", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"N529SG_OrganisationId", A529SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"N528SG_LocationId", A528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMEMOID", AV7MemoId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_RESIDENTID", AV26Insert_ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SG_ORGANISATIONID", AV29Insert_SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"SG_ORGANISATIONID", A529SG_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SG_LOCATIONID", AV30Insert_SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"SG_LOCATIONID", A528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOBGCOLORCODE", A566MemoBgColorCode);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOFORM", StringUtil.RTrim( A567MemoForm));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTYPE", A624MemoType);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMONAME", A625MemoName);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOLEFTOFFSET", StringUtil.LTrim( StringUtil.NToC( A626MemoLeftOffset, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTOPOFFSET", StringUtil.LTrim( StringUtil.NToC( A627MemoTopOffset, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTITLEANGLE", StringUtil.LTrim( StringUtil.NToC( A628MemoTitleAngle, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTITLESCALE", StringUtil.LTrim( StringUtil.NToC( A629MemoTitleScale, 6, 3, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTEXTFONTNAME", A637MemoTextFontName);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTEXTALIGNMENT", StringUtil.RTrim( A638MemoTextAlignment));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"MEMOISBOLD", A639MemoIsBold);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"MEMOISITALIC", A640MemoIsItalic);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"MEMOISCAPITALIZED", A641MemoIsCapitalized);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEMOTEXTCOLOR", A642MemoTextColor);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTLASTNAME", A65ResidentLastName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV32Pgmname));
      }

      protected void RenderHtmlCloseForm1P100( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlText( "<script type=\"text/javascript\">") ;
            context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
            if ( ! context.isSpaRequest( ) )
            {
               context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
               context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
               context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
               context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
               context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
               context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
            }
            context.WriteHtmlText( "</script>") ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Trn_Memo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Memo", "") ;
      }

      protected void InitializeNonKey1P100( )
      {
         A11OrganisationId = Guid.Empty;
         AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         A62ResidentId = Guid.Empty;
         AssignAttri(sPrefix, false, "A62ResidentId", A62ResidentId.ToString());
         A529SG_OrganisationId = Guid.Empty;
         AssignAttri(sPrefix, false, "A529SG_OrganisationId", A529SG_OrganisationId.ToString());
         A528SG_LocationId = Guid.Empty;
         AssignAttri(sPrefix, false, "A528SG_LocationId", A528SG_LocationId.ToString());
         A550MemoTitle = "";
         AssignAttri(sPrefix, false, "A550MemoTitle", A550MemoTitle);
         A551MemoDescription = "";
         AssignAttri(sPrefix, false, "A551MemoDescription", A551MemoDescription);
         A552MemoImage = "";
         n552MemoImage = false;
         AssignAttri(sPrefix, false, "A552MemoImage", A552MemoImage);
         n552MemoImage = (String.IsNullOrEmpty(StringUtil.RTrim( A552MemoImage)) ? true : false);
         A553MemoDocument = "";
         n553MemoDocument = false;
         AssignAttri(sPrefix, false, "A553MemoDocument", A553MemoDocument);
         n553MemoDocument = (String.IsNullOrEmpty(StringUtil.RTrim( A553MemoDocument)) ? true : false);
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         n561MemoStartDateTime = false;
         AssignAttri(sPrefix, false, "A561MemoStartDateTime", context.localUtil.TToC( A561MemoStartDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n561MemoStartDateTime = ((DateTime.MinValue==A561MemoStartDateTime) ? true : false);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         n562MemoEndDateTime = false;
         AssignAttri(sPrefix, false, "A562MemoEndDateTime", context.localUtil.TToC( A562MemoEndDateTime, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n562MemoEndDateTime = ((DateTime.MinValue==A562MemoEndDateTime) ? true : false);
         A563MemoDuration = 0;
         n563MemoDuration = false;
         AssignAttri(sPrefix, false, "A563MemoDuration", StringUtil.LTrimStr( A563MemoDuration, 6, 3));
         n563MemoDuration = ((Convert.ToDecimal(0)==A563MemoDuration) ? true : false);
         A564MemoRemoveDate = DateTime.MinValue;
         n564MemoRemoveDate = false;
         AssignAttri(sPrefix, false, "A564MemoRemoveDate", context.localUtil.Format(A564MemoRemoveDate, "99/99/99"));
         n564MemoRemoveDate = ((DateTime.MinValue==A564MemoRemoveDate) ? true : false);
         A72ResidentSalutation = "";
         AssignAttri(sPrefix, false, "A72ResidentSalutation", A72ResidentSalutation);
         A64ResidentGivenName = "";
         AssignAttri(sPrefix, false, "A64ResidentGivenName", A64ResidentGivenName);
         A65ResidentLastName = "";
         AssignAttri(sPrefix, false, "A65ResidentLastName", A65ResidentLastName);
         A71ResidentGUID = "";
         AssignAttri(sPrefix, false, "A71ResidentGUID", A71ResidentGUID);
         A566MemoBgColorCode = "";
         n566MemoBgColorCode = false;
         AssignAttri(sPrefix, false, "A566MemoBgColorCode", A566MemoBgColorCode);
         A567MemoForm = "";
         AssignAttri(sPrefix, false, "A567MemoForm", A567MemoForm);
         A624MemoType = "";
         AssignAttri(sPrefix, false, "A624MemoType", A624MemoType);
         A625MemoName = "";
         AssignAttri(sPrefix, false, "A625MemoName", A625MemoName);
         A626MemoLeftOffset = 0;
         AssignAttri(sPrefix, false, "A626MemoLeftOffset", StringUtil.LTrimStr( A626MemoLeftOffset, 6, 3));
         A627MemoTopOffset = 0;
         AssignAttri(sPrefix, false, "A627MemoTopOffset", StringUtil.LTrimStr( A627MemoTopOffset, 6, 3));
         A628MemoTitleAngle = 0;
         AssignAttri(sPrefix, false, "A628MemoTitleAngle", StringUtil.LTrimStr( A628MemoTitleAngle, 6, 3));
         A629MemoTitleScale = 0;
         AssignAttri(sPrefix, false, "A629MemoTitleScale", StringUtil.LTrimStr( A629MemoTitleScale, 6, 3));
         A637MemoTextFontName = "";
         AssignAttri(sPrefix, false, "A637MemoTextFontName", A637MemoTextFontName);
         A638MemoTextAlignment = "";
         AssignAttri(sPrefix, false, "A638MemoTextAlignment", A638MemoTextAlignment);
         A639MemoIsBold = false;
         AssignAttri(sPrefix, false, "A639MemoIsBold", A639MemoIsBold);
         A640MemoIsItalic = false;
         AssignAttri(sPrefix, false, "A640MemoIsItalic", A640MemoIsItalic);
         A641MemoIsCapitalized = false;
         AssignAttri(sPrefix, false, "A641MemoIsCapitalized", A641MemoIsCapitalized);
         A642MemoTextColor = "";
         AssignAttri(sPrefix, false, "A642MemoTextColor", A642MemoTextColor);
         A647MemoCreatedAt = DateTimeUtil.Now( context);
         n647MemoCreatedAt = false;
         AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z550MemoTitle = "";
         Z551MemoDescription = "";
         Z553MemoDocument = "";
         Z561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z563MemoDuration = 0;
         Z564MemoRemoveDate = DateTime.MinValue;
         Z566MemoBgColorCode = "";
         Z567MemoForm = "";
         Z624MemoType = "";
         Z625MemoName = "";
         Z626MemoLeftOffset = 0;
         Z627MemoTopOffset = 0;
         Z628MemoTitleAngle = 0;
         Z629MemoTitleScale = 0;
         Z637MemoTextFontName = "";
         Z638MemoTextAlignment = "";
         Z639MemoIsBold = false;
         Z640MemoIsItalic = false;
         Z641MemoIsCapitalized = false;
         Z642MemoTextColor = "";
         Z647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         Z62ResidentId = Guid.Empty;
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1P100( )
      {
         A549MemoId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "A549MemoId", A549MemoId.ToString());
         InitializeNonKey1P100( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A647MemoCreatedAt = i647MemoCreatedAt;
         n647MemoCreatedAt = false;
         AssignAttri(sPrefix, false, "A647MemoCreatedAt", context.localUtil.TToC( A647MemoCreatedAt, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7MemoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_memo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7MemoId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV7MemoId", AV7MemoId.ToString());
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV7MemoId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7MemoId != wcpOAV7MemoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7MemoId = AV7MemoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV7MemoId = cgiGet( sPrefix+"AV7MemoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7MemoId) > 0 )
         {
            AV7MemoId = StringUtil.StrToGuid( cgiGet( sCtrlAV7MemoId));
            AssignAttri(sPrefix, false, "AV7MemoId", AV7MemoId.ToString());
         }
         else
         {
            AV7MemoId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV7MemoId_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7MemoId_PARM", AV7MemoId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7MemoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7MemoId_CTRL", StringUtil.RTrim( sCtrlAV7MemoId));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            Draw( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212433760", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_memo.js", "?20257212433762", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMemoTitle_Internalname = sPrefix+"MEMOTITLE";
         edtMemoDescription_Internalname = sPrefix+"MEMODESCRIPTION";
         edtMemoImage_Internalname = sPrefix+"MEMOIMAGE";
         edtMemoDocument_Internalname = sPrefix+"MEMODOCUMENT";
         edtMemoStartDateTime_Internalname = sPrefix+"MEMOSTARTDATETIME";
         edtMemoEndDateTime_Internalname = sPrefix+"MEMOENDDATETIME";
         edtMemoDuration_Internalname = sPrefix+"MEMODURATION";
         edtMemoRemoveDate_Internalname = sPrefix+"MEMOREMOVEDATE";
         edtResidentId_Internalname = sPrefix+"RESIDENTID";
         edtMemoCreatedAt_Internalname = sPrefix+"MEMOCREATEDAT";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtMemoId_Internalname = sPrefix+"MEMOID";
         cmbResidentSalutation_Internalname = sPrefix+"RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = sPrefix+"RESIDENTGIVENNAME";
         edtResidentGUID_Internalname = sPrefix+"RESIDENTGUID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Enabled = 0;
         edtResidentGUID_Visible = 1;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 0;
         edtResidentGivenName_Visible = 1;
         cmbResidentSalutation_Jsonclick = "";
         cmbResidentSalutation.Visible = 1;
         cmbResidentSalutation.Enabled = 0;
         edtMemoId_Jsonclick = "";
         edtMemoId_Enabled = 1;
         edtMemoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMemoCreatedAt_Jsonclick = "";
         edtMemoCreatedAt_Enabled = 0;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 1;
         edtMemoRemoveDate_Jsonclick = "";
         edtMemoRemoveDate_Enabled = 1;
         edtMemoDuration_Jsonclick = "";
         edtMemoDuration_Enabled = 1;
         edtMemoEndDateTime_Jsonclick = "";
         edtMemoEndDateTime_Enabled = 1;
         edtMemoStartDateTime_Jsonclick = "";
         edtMemoStartDateTime_Enabled = 1;
         edtMemoDocument_Enabled = 1;
         edtMemoImage_Enabled = 1;
         edtMemoDescription_Enabled = 1;
         edtMemoTitle_Jsonclick = "";
         edtMemoTitle_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbResidentSalutation.Name = "RESIDENTSALUTATION";
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbResidentSalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbResidentSalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbResidentSalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"componentprocess","iparms":[{"postForm":true},{"sPrefix":true},{"sSFPrefix":true},{"sCompEvt":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV7MemoId","fld":"vMEMOID"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A566MemoBgColorCode","fld":"MEMOBGCOLORCODE"},{"av":"A567MemoForm","fld":"MEMOFORM"},{"av":"A624MemoType","fld":"MEMOTYPE"},{"av":"A625MemoName","fld":"MEMONAME"},{"av":"A626MemoLeftOffset","fld":"MEMOLEFTOFFSET","pic":"Z9.999"},{"av":"A627MemoTopOffset","fld":"MEMOTOPOFFSET","pic":"Z9.999"},{"av":"A628MemoTitleAngle","fld":"MEMOTITLEANGLE","pic":"Z9.999"},{"av":"A629MemoTitleScale","fld":"MEMOTITLESCALE","pic":"Z9.999"},{"av":"A637MemoTextFontName","fld":"MEMOTEXTFONTNAME"},{"av":"A638MemoTextAlignment","fld":"MEMOTEXTALIGNMENT"},{"av":"A639MemoIsBold","fld":"MEMOISBOLD"},{"av":"A640MemoIsItalic","fld":"MEMOISITALIC"},{"av":"A641MemoIsCapitalized","fld":"MEMOISCAPITALIZED"},{"av":"A642MemoTextColor","fld":"MEMOTEXTCOLOR"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121P2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_MEMOID","""{"handler":"Valid_Memoid","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7MemoId = Guid.Empty;
         Z549MemoId = Guid.Empty;
         Z550MemoTitle = "";
         Z551MemoDescription = "";
         Z553MemoDocument = "";
         Z561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z564MemoRemoveDate = DateTime.MinValue;
         Z566MemoBgColorCode = "";
         Z567MemoForm = "";
         Z624MemoType = "";
         Z625MemoName = "";
         Z637MemoTextFontName = "";
         Z638MemoTextAlignment = "";
         Z642MemoTextColor = "";
         Z647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         Z62ResidentId = Guid.Empty;
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
         N62ResidentId = Guid.Empty;
         N529SG_OrganisationId = Guid.Empty;
         N528SG_LocationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A62ResidentId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         A72ResidentSalutation = "";
         ClassString = "";
         StyleString = "";
         A550MemoTitle = "";
         TempTags = "";
         A551MemoDescription = "";
         A552MemoImage = "";
         A553MemoDocument = "";
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A564MemoRemoveDate = DateTime.MinValue;
         A647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A549MemoId = Guid.Empty;
         A64ResidentGivenName = "";
         A71ResidentGUID = "";
         A566MemoBgColorCode = "";
         A567MemoForm = "";
         A624MemoType = "";
         A625MemoName = "";
         A637MemoTextFontName = "";
         A638MemoTextAlignment = "";
         A642MemoTextColor = "";
         AV26Insert_ResidentId = Guid.Empty;
         AV29Insert_SG_OrganisationId = Guid.Empty;
         AV30Insert_SG_LocationId = Guid.Empty;
         A65ResidentLastName = "";
         AV32Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode100 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z552MemoImage = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z71ResidentGUID = "";
         T001P4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001P4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001P4_A72ResidentSalutation = new string[] {""} ;
         T001P4_A64ResidentGivenName = new string[] {""} ;
         T001P4_A65ResidentLastName = new string[] {""} ;
         T001P4_A71ResidentGUID = new string[] {""} ;
         T001P5_A29LocationId = new Guid[] {Guid.Empty} ;
         T001P5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001P5_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P5_A550MemoTitle = new string[] {""} ;
         T001P5_A551MemoDescription = new string[] {""} ;
         T001P5_A552MemoImage = new string[] {""} ;
         T001P5_n552MemoImage = new bool[] {false} ;
         T001P5_A553MemoDocument = new string[] {""} ;
         T001P5_n553MemoDocument = new bool[] {false} ;
         T001P5_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P5_n561MemoStartDateTime = new bool[] {false} ;
         T001P5_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P5_n562MemoEndDateTime = new bool[] {false} ;
         T001P5_A563MemoDuration = new decimal[1] ;
         T001P5_n563MemoDuration = new bool[] {false} ;
         T001P5_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001P5_n564MemoRemoveDate = new bool[] {false} ;
         T001P5_A72ResidentSalutation = new string[] {""} ;
         T001P5_A64ResidentGivenName = new string[] {""} ;
         T001P5_A65ResidentLastName = new string[] {""} ;
         T001P5_A71ResidentGUID = new string[] {""} ;
         T001P5_A566MemoBgColorCode = new string[] {""} ;
         T001P5_n566MemoBgColorCode = new bool[] {false} ;
         T001P5_A567MemoForm = new string[] {""} ;
         T001P5_A624MemoType = new string[] {""} ;
         T001P5_A625MemoName = new string[] {""} ;
         T001P5_A626MemoLeftOffset = new decimal[1] ;
         T001P5_A627MemoTopOffset = new decimal[1] ;
         T001P5_A628MemoTitleAngle = new decimal[1] ;
         T001P5_A629MemoTitleScale = new decimal[1] ;
         T001P5_A637MemoTextFontName = new string[] {""} ;
         T001P5_A638MemoTextAlignment = new string[] {""} ;
         T001P5_A639MemoIsBold = new bool[] {false} ;
         T001P5_A640MemoIsItalic = new bool[] {false} ;
         T001P5_A641MemoIsCapitalized = new bool[] {false} ;
         T001P5_A642MemoTextColor = new string[] {""} ;
         T001P5_A647MemoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001P5_n647MemoCreatedAt = new bool[] {false} ;
         T001P5_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001P5_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001P5_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001P6_A29LocationId = new Guid[] {Guid.Empty} ;
         T001P6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001P6_A72ResidentSalutation = new string[] {""} ;
         T001P6_A64ResidentGivenName = new string[] {""} ;
         T001P6_A65ResidentLastName = new string[] {""} ;
         T001P6_A71ResidentGUID = new string[] {""} ;
         T001P7_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P3_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P3_A550MemoTitle = new string[] {""} ;
         T001P3_A551MemoDescription = new string[] {""} ;
         T001P3_A552MemoImage = new string[] {""} ;
         T001P3_n552MemoImage = new bool[] {false} ;
         T001P3_A553MemoDocument = new string[] {""} ;
         T001P3_n553MemoDocument = new bool[] {false} ;
         T001P3_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P3_n561MemoStartDateTime = new bool[] {false} ;
         T001P3_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P3_n562MemoEndDateTime = new bool[] {false} ;
         T001P3_A563MemoDuration = new decimal[1] ;
         T001P3_n563MemoDuration = new bool[] {false} ;
         T001P3_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001P3_n564MemoRemoveDate = new bool[] {false} ;
         T001P3_A566MemoBgColorCode = new string[] {""} ;
         T001P3_n566MemoBgColorCode = new bool[] {false} ;
         T001P3_A567MemoForm = new string[] {""} ;
         T001P3_A624MemoType = new string[] {""} ;
         T001P3_A625MemoName = new string[] {""} ;
         T001P3_A626MemoLeftOffset = new decimal[1] ;
         T001P3_A627MemoTopOffset = new decimal[1] ;
         T001P3_A628MemoTitleAngle = new decimal[1] ;
         T001P3_A629MemoTitleScale = new decimal[1] ;
         T001P3_A637MemoTextFontName = new string[] {""} ;
         T001P3_A638MemoTextAlignment = new string[] {""} ;
         T001P3_A639MemoIsBold = new bool[] {false} ;
         T001P3_A640MemoIsItalic = new bool[] {false} ;
         T001P3_A641MemoIsCapitalized = new bool[] {false} ;
         T001P3_A642MemoTextColor = new string[] {""} ;
         T001P3_A647MemoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001P3_n647MemoCreatedAt = new bool[] {false} ;
         T001P3_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001P3_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001P3_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001P8_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P9_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P2_A549MemoId = new Guid[] {Guid.Empty} ;
         T001P2_A550MemoTitle = new string[] {""} ;
         T001P2_A551MemoDescription = new string[] {""} ;
         T001P2_A552MemoImage = new string[] {""} ;
         T001P2_n552MemoImage = new bool[] {false} ;
         T001P2_A553MemoDocument = new string[] {""} ;
         T001P2_n553MemoDocument = new bool[] {false} ;
         T001P2_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P2_n561MemoStartDateTime = new bool[] {false} ;
         T001P2_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         T001P2_n562MemoEndDateTime = new bool[] {false} ;
         T001P2_A563MemoDuration = new decimal[1] ;
         T001P2_n563MemoDuration = new bool[] {false} ;
         T001P2_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         T001P2_n564MemoRemoveDate = new bool[] {false} ;
         T001P2_A566MemoBgColorCode = new string[] {""} ;
         T001P2_n566MemoBgColorCode = new bool[] {false} ;
         T001P2_A567MemoForm = new string[] {""} ;
         T001P2_A624MemoType = new string[] {""} ;
         T001P2_A625MemoName = new string[] {""} ;
         T001P2_A626MemoLeftOffset = new decimal[1] ;
         T001P2_A627MemoTopOffset = new decimal[1] ;
         T001P2_A628MemoTitleAngle = new decimal[1] ;
         T001P2_A629MemoTitleScale = new decimal[1] ;
         T001P2_A637MemoTextFontName = new string[] {""} ;
         T001P2_A638MemoTextAlignment = new string[] {""} ;
         T001P2_A639MemoIsBold = new bool[] {false} ;
         T001P2_A640MemoIsItalic = new bool[] {false} ;
         T001P2_A641MemoIsCapitalized = new bool[] {false} ;
         T001P2_A642MemoTextColor = new string[] {""} ;
         T001P2_A647MemoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001P2_n647MemoCreatedAt = new bool[] {false} ;
         T001P2_A62ResidentId = new Guid[] {Guid.Empty} ;
         T001P2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         T001P2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         T001P13_A72ResidentSalutation = new string[] {""} ;
         T001P13_A64ResidentGivenName = new string[] {""} ;
         T001P13_A65ResidentLastName = new string[] {""} ;
         T001P13_A71ResidentGUID = new string[] {""} ;
         T001P14_A549MemoId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         sCtrlGx_mode = "";
         sCtrlAV7MemoId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memo__default(),
            new Object[][] {
                new Object[] {
               T001P2_A549MemoId, T001P2_A550MemoTitle, T001P2_A551MemoDescription, T001P2_A552MemoImage, T001P2_n552MemoImage, T001P2_A553MemoDocument, T001P2_n553MemoDocument, T001P2_A561MemoStartDateTime, T001P2_n561MemoStartDateTime, T001P2_A562MemoEndDateTime,
               T001P2_n562MemoEndDateTime, T001P2_A563MemoDuration, T001P2_n563MemoDuration, T001P2_A564MemoRemoveDate, T001P2_n564MemoRemoveDate, T001P2_A566MemoBgColorCode, T001P2_n566MemoBgColorCode, T001P2_A567MemoForm, T001P2_A624MemoType, T001P2_A625MemoName,
               T001P2_A626MemoLeftOffset, T001P2_A627MemoTopOffset, T001P2_A628MemoTitleAngle, T001P2_A629MemoTitleScale, T001P2_A637MemoTextFontName, T001P2_A638MemoTextAlignment, T001P2_A639MemoIsBold, T001P2_A640MemoIsItalic, T001P2_A641MemoIsCapitalized, T001P2_A642MemoTextColor,
               T001P2_A647MemoCreatedAt, T001P2_n647MemoCreatedAt, T001P2_A62ResidentId, T001P2_A528SG_LocationId, T001P2_A529SG_OrganisationId
               }
               , new Object[] {
               T001P3_A549MemoId, T001P3_A550MemoTitle, T001P3_A551MemoDescription, T001P3_A552MemoImage, T001P3_n552MemoImage, T001P3_A553MemoDocument, T001P3_n553MemoDocument, T001P3_A561MemoStartDateTime, T001P3_n561MemoStartDateTime, T001P3_A562MemoEndDateTime,
               T001P3_n562MemoEndDateTime, T001P3_A563MemoDuration, T001P3_n563MemoDuration, T001P3_A564MemoRemoveDate, T001P3_n564MemoRemoveDate, T001P3_A566MemoBgColorCode, T001P3_n566MemoBgColorCode, T001P3_A567MemoForm, T001P3_A624MemoType, T001P3_A625MemoName,
               T001P3_A626MemoLeftOffset, T001P3_A627MemoTopOffset, T001P3_A628MemoTitleAngle, T001P3_A629MemoTitleScale, T001P3_A637MemoTextFontName, T001P3_A638MemoTextAlignment, T001P3_A639MemoIsBold, T001P3_A640MemoIsItalic, T001P3_A641MemoIsCapitalized, T001P3_A642MemoTextColor,
               T001P3_A647MemoCreatedAt, T001P3_n647MemoCreatedAt, T001P3_A62ResidentId, T001P3_A528SG_LocationId, T001P3_A529SG_OrganisationId
               }
               , new Object[] {
               T001P4_A29LocationId, T001P4_A11OrganisationId, T001P4_A72ResidentSalutation, T001P4_A64ResidentGivenName, T001P4_A65ResidentLastName, T001P4_A71ResidentGUID
               }
               , new Object[] {
               T001P5_A29LocationId, T001P5_A11OrganisationId, T001P5_A549MemoId, T001P5_A550MemoTitle, T001P5_A551MemoDescription, T001P5_A552MemoImage, T001P5_n552MemoImage, T001P5_A553MemoDocument, T001P5_n553MemoDocument, T001P5_A561MemoStartDateTime,
               T001P5_n561MemoStartDateTime, T001P5_A562MemoEndDateTime, T001P5_n562MemoEndDateTime, T001P5_A563MemoDuration, T001P5_n563MemoDuration, T001P5_A564MemoRemoveDate, T001P5_n564MemoRemoveDate, T001P5_A72ResidentSalutation, T001P5_A64ResidentGivenName, T001P5_A65ResidentLastName,
               T001P5_A71ResidentGUID, T001P5_A566MemoBgColorCode, T001P5_n566MemoBgColorCode, T001P5_A567MemoForm, T001P5_A624MemoType, T001P5_A625MemoName, T001P5_A626MemoLeftOffset, T001P5_A627MemoTopOffset, T001P5_A628MemoTitleAngle, T001P5_A629MemoTitleScale,
               T001P5_A637MemoTextFontName, T001P5_A638MemoTextAlignment, T001P5_A639MemoIsBold, T001P5_A640MemoIsItalic, T001P5_A641MemoIsCapitalized, T001P5_A642MemoTextColor, T001P5_A647MemoCreatedAt, T001P5_n647MemoCreatedAt, T001P5_A62ResidentId, T001P5_A528SG_LocationId,
               T001P5_A529SG_OrganisationId
               }
               , new Object[] {
               T001P6_A29LocationId, T001P6_A11OrganisationId, T001P6_A72ResidentSalutation, T001P6_A64ResidentGivenName, T001P6_A65ResidentLastName, T001P6_A71ResidentGUID
               }
               , new Object[] {
               T001P7_A549MemoId
               }
               , new Object[] {
               T001P8_A549MemoId
               }
               , new Object[] {
               T001P9_A549MemoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001P13_A72ResidentSalutation, T001P13_A64ResidentGivenName, T001P13_A65ResidentLastName, T001P13_A71ResidentGUID
               }
               , new Object[] {
               T001P14_A549MemoId
               }
            }
         );
         Z549MemoId = Guid.NewGuid( );
         A549MemoId = Guid.NewGuid( );
         AV32Pgmname = "Trn_Memo";
         Z647MemoCreatedAt = DateTimeUtil.Now( context);
         n647MemoCreatedAt = false;
         A647MemoCreatedAt = DateTimeUtil.Now( context);
         n647MemoCreatedAt = false;
         i647MemoCreatedAt = DateTimeUtil.Now( context);
         n647MemoCreatedAt = false;
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound100 ;
      private int trnEnded ;
      private int edtMemoTitle_Enabled ;
      private int edtMemoDescription_Enabled ;
      private int edtMemoImage_Enabled ;
      private int edtMemoDocument_Enabled ;
      private int edtMemoStartDateTime_Enabled ;
      private int edtMemoEndDateTime_Enabled ;
      private int edtMemoDuration_Enabled ;
      private int edtMemoRemoveDate_Enabled ;
      private int edtResidentId_Enabled ;
      private int edtMemoCreatedAt_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtMemoId_Visible ;
      private int edtMemoId_Enabled ;
      private int edtResidentGivenName_Visible ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentGUID_Visible ;
      private int edtResidentGUID_Enabled ;
      private int AV33GXV1 ;
      private int idxLst ;
      private decimal Z563MemoDuration ;
      private decimal Z626MemoLeftOffset ;
      private decimal Z627MemoTopOffset ;
      private decimal Z628MemoTitleAngle ;
      private decimal Z629MemoTitleScale ;
      private decimal A563MemoDuration ;
      private decimal A626MemoLeftOffset ;
      private decimal A627MemoTopOffset ;
      private decimal A628MemoTitleAngle ;
      private decimal A629MemoTitleScale ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z567MemoForm ;
      private string Z638MemoTextAlignment ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtMemoTitle_Internalname ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtMemoTitle_Jsonclick ;
      private string edtMemoDescription_Internalname ;
      private string edtMemoImage_Internalname ;
      private string edtMemoDocument_Internalname ;
      private string edtMemoStartDateTime_Internalname ;
      private string edtMemoStartDateTime_Jsonclick ;
      private string edtMemoEndDateTime_Internalname ;
      private string edtMemoEndDateTime_Jsonclick ;
      private string edtMemoDuration_Internalname ;
      private string edtMemoDuration_Jsonclick ;
      private string edtMemoRemoveDate_Internalname ;
      private string edtMemoRemoveDate_Jsonclick ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string edtMemoCreatedAt_Internalname ;
      private string edtMemoCreatedAt_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMemoId_Internalname ;
      private string edtMemoId_Jsonclick ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string A567MemoForm ;
      private string A638MemoTextAlignment ;
      private string AV32Pgmname ;
      private string hsh ;
      private string sMode100 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z72ResidentSalutation ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7MemoId ;
      private DateTime Z561MemoStartDateTime ;
      private DateTime Z562MemoEndDateTime ;
      private DateTime Z647MemoCreatedAt ;
      private DateTime A561MemoStartDateTime ;
      private DateTime A562MemoEndDateTime ;
      private DateTime A647MemoCreatedAt ;
      private DateTime i647MemoCreatedAt ;
      private DateTime Z564MemoRemoveDate ;
      private DateTime A564MemoRemoveDate ;
      private bool Z639MemoIsBold ;
      private bool Z640MemoIsItalic ;
      private bool Z641MemoIsCapitalized ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n553MemoDocument ;
      private bool n561MemoStartDateTime ;
      private bool n562MemoEndDateTime ;
      private bool n563MemoDuration ;
      private bool n564MemoRemoveDate ;
      private bool n566MemoBgColorCode ;
      private bool n647MemoCreatedAt ;
      private bool A639MemoIsBold ;
      private bool A640MemoIsItalic ;
      private bool A641MemoIsCapitalized ;
      private bool n552MemoImage ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A552MemoImage ;
      private string Z552MemoImage ;
      private string Z550MemoTitle ;
      private string Z551MemoDescription ;
      private string Z553MemoDocument ;
      private string Z566MemoBgColorCode ;
      private string Z624MemoType ;
      private string Z625MemoName ;
      private string Z637MemoTextFontName ;
      private string Z642MemoTextColor ;
      private string A550MemoTitle ;
      private string A551MemoDescription ;
      private string A553MemoDocument ;
      private string A64ResidentGivenName ;
      private string A71ResidentGUID ;
      private string A566MemoBgColorCode ;
      private string A624MemoType ;
      private string A625MemoName ;
      private string A637MemoTextFontName ;
      private string A642MemoTextColor ;
      private string A65ResidentLastName ;
      private string Z64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string Z71ResidentGUID ;
      private Guid wcpOAV7MemoId ;
      private Guid Z549MemoId ;
      private Guid Z62ResidentId ;
      private Guid Z528SG_LocationId ;
      private Guid Z529SG_OrganisationId ;
      private Guid N62ResidentId ;
      private Guid N529SG_OrganisationId ;
      private Guid N528SG_LocationId ;
      private Guid AV7MemoId ;
      private Guid A62ResidentId ;
      private Guid A528SG_LocationId ;
      private Guid A529SG_OrganisationId ;
      private Guid A549MemoId ;
      private Guid AV26Insert_ResidentId ;
      private Guid AV29Insert_SG_OrganisationId ;
      private Guid AV30Insert_SG_LocationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001P4_A29LocationId ;
      private Guid[] T001P4_A11OrganisationId ;
      private string[] T001P4_A72ResidentSalutation ;
      private string[] T001P4_A64ResidentGivenName ;
      private string[] T001P4_A65ResidentLastName ;
      private string[] T001P4_A71ResidentGUID ;
      private Guid[] T001P5_A29LocationId ;
      private Guid[] T001P5_A11OrganisationId ;
      private Guid[] T001P5_A549MemoId ;
      private string[] T001P5_A550MemoTitle ;
      private string[] T001P5_A551MemoDescription ;
      private string[] T001P5_A552MemoImage ;
      private bool[] T001P5_n552MemoImage ;
      private string[] T001P5_A553MemoDocument ;
      private bool[] T001P5_n553MemoDocument ;
      private DateTime[] T001P5_A561MemoStartDateTime ;
      private bool[] T001P5_n561MemoStartDateTime ;
      private DateTime[] T001P5_A562MemoEndDateTime ;
      private bool[] T001P5_n562MemoEndDateTime ;
      private decimal[] T001P5_A563MemoDuration ;
      private bool[] T001P5_n563MemoDuration ;
      private DateTime[] T001P5_A564MemoRemoveDate ;
      private bool[] T001P5_n564MemoRemoveDate ;
      private string[] T001P5_A72ResidentSalutation ;
      private string[] T001P5_A64ResidentGivenName ;
      private string[] T001P5_A65ResidentLastName ;
      private string[] T001P5_A71ResidentGUID ;
      private string[] T001P5_A566MemoBgColorCode ;
      private bool[] T001P5_n566MemoBgColorCode ;
      private string[] T001P5_A567MemoForm ;
      private string[] T001P5_A624MemoType ;
      private string[] T001P5_A625MemoName ;
      private decimal[] T001P5_A626MemoLeftOffset ;
      private decimal[] T001P5_A627MemoTopOffset ;
      private decimal[] T001P5_A628MemoTitleAngle ;
      private decimal[] T001P5_A629MemoTitleScale ;
      private string[] T001P5_A637MemoTextFontName ;
      private string[] T001P5_A638MemoTextAlignment ;
      private bool[] T001P5_A639MemoIsBold ;
      private bool[] T001P5_A640MemoIsItalic ;
      private bool[] T001P5_A641MemoIsCapitalized ;
      private string[] T001P5_A642MemoTextColor ;
      private DateTime[] T001P5_A647MemoCreatedAt ;
      private bool[] T001P5_n647MemoCreatedAt ;
      private Guid[] T001P5_A62ResidentId ;
      private Guid[] T001P5_A528SG_LocationId ;
      private Guid[] T001P5_A529SG_OrganisationId ;
      private Guid[] T001P6_A29LocationId ;
      private Guid[] T001P6_A11OrganisationId ;
      private string[] T001P6_A72ResidentSalutation ;
      private string[] T001P6_A64ResidentGivenName ;
      private string[] T001P6_A65ResidentLastName ;
      private string[] T001P6_A71ResidentGUID ;
      private Guid[] T001P7_A549MemoId ;
      private Guid[] T001P3_A549MemoId ;
      private string[] T001P3_A550MemoTitle ;
      private string[] T001P3_A551MemoDescription ;
      private string[] T001P3_A552MemoImage ;
      private bool[] T001P3_n552MemoImage ;
      private string[] T001P3_A553MemoDocument ;
      private bool[] T001P3_n553MemoDocument ;
      private DateTime[] T001P3_A561MemoStartDateTime ;
      private bool[] T001P3_n561MemoStartDateTime ;
      private DateTime[] T001P3_A562MemoEndDateTime ;
      private bool[] T001P3_n562MemoEndDateTime ;
      private decimal[] T001P3_A563MemoDuration ;
      private bool[] T001P3_n563MemoDuration ;
      private DateTime[] T001P3_A564MemoRemoveDate ;
      private bool[] T001P3_n564MemoRemoveDate ;
      private string[] T001P3_A566MemoBgColorCode ;
      private bool[] T001P3_n566MemoBgColorCode ;
      private string[] T001P3_A567MemoForm ;
      private string[] T001P3_A624MemoType ;
      private string[] T001P3_A625MemoName ;
      private decimal[] T001P3_A626MemoLeftOffset ;
      private decimal[] T001P3_A627MemoTopOffset ;
      private decimal[] T001P3_A628MemoTitleAngle ;
      private decimal[] T001P3_A629MemoTitleScale ;
      private string[] T001P3_A637MemoTextFontName ;
      private string[] T001P3_A638MemoTextAlignment ;
      private bool[] T001P3_A639MemoIsBold ;
      private bool[] T001P3_A640MemoIsItalic ;
      private bool[] T001P3_A641MemoIsCapitalized ;
      private string[] T001P3_A642MemoTextColor ;
      private DateTime[] T001P3_A647MemoCreatedAt ;
      private bool[] T001P3_n647MemoCreatedAt ;
      private Guid[] T001P3_A62ResidentId ;
      private Guid[] T001P3_A528SG_LocationId ;
      private Guid[] T001P3_A529SG_OrganisationId ;
      private Guid[] T001P8_A549MemoId ;
      private Guid[] T001P9_A549MemoId ;
      private Guid[] T001P2_A549MemoId ;
      private string[] T001P2_A550MemoTitle ;
      private string[] T001P2_A551MemoDescription ;
      private string[] T001P2_A552MemoImage ;
      private bool[] T001P2_n552MemoImage ;
      private string[] T001P2_A553MemoDocument ;
      private bool[] T001P2_n553MemoDocument ;
      private DateTime[] T001P2_A561MemoStartDateTime ;
      private bool[] T001P2_n561MemoStartDateTime ;
      private DateTime[] T001P2_A562MemoEndDateTime ;
      private bool[] T001P2_n562MemoEndDateTime ;
      private decimal[] T001P2_A563MemoDuration ;
      private bool[] T001P2_n563MemoDuration ;
      private DateTime[] T001P2_A564MemoRemoveDate ;
      private bool[] T001P2_n564MemoRemoveDate ;
      private string[] T001P2_A566MemoBgColorCode ;
      private bool[] T001P2_n566MemoBgColorCode ;
      private string[] T001P2_A567MemoForm ;
      private string[] T001P2_A624MemoType ;
      private string[] T001P2_A625MemoName ;
      private decimal[] T001P2_A626MemoLeftOffset ;
      private decimal[] T001P2_A627MemoTopOffset ;
      private decimal[] T001P2_A628MemoTitleAngle ;
      private decimal[] T001P2_A629MemoTitleScale ;
      private string[] T001P2_A637MemoTextFontName ;
      private string[] T001P2_A638MemoTextAlignment ;
      private bool[] T001P2_A639MemoIsBold ;
      private bool[] T001P2_A640MemoIsItalic ;
      private bool[] T001P2_A641MemoIsCapitalized ;
      private string[] T001P2_A642MemoTextColor ;
      private DateTime[] T001P2_A647MemoCreatedAt ;
      private bool[] T001P2_n647MemoCreatedAt ;
      private Guid[] T001P2_A62ResidentId ;
      private Guid[] T001P2_A528SG_LocationId ;
      private Guid[] T001P2_A529SG_OrganisationId ;
      private string[] T001P13_A72ResidentSalutation ;
      private string[] T001P13_A64ResidentGivenName ;
      private string[] T001P13_A65ResidentLastName ;
      private string[] T001P13_A71ResidentGUID ;
      private Guid[] T001P14_A549MemoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memo__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_memo__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_memo__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001P2;
       prmT001P2 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P3;
       prmT001P3 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P4;
       prmT001P4 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P5;
       prmT001P5 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P6;
       prmT001P6 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P7;
       prmT001P7 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P8;
       prmT001P8 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P9;
       prmT001P9 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P10;
       prmT001P10 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Number,6,3){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0){Nullable=true} ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoType",GXType.VarChar,100,0) ,
       new ParDef("MemoName",GXType.VarChar,100,0) ,
       new ParDef("MemoLeftOffset",GXType.Number,6,3) ,
       new ParDef("MemoTopOffset",GXType.Number,6,3) ,
       new ParDef("MemoTitleAngle",GXType.Number,6,3) ,
       new ParDef("MemoTitleScale",GXType.Number,6,3) ,
       new ParDef("MemoTextFontName",GXType.VarChar,100,0) ,
       new ParDef("MemoTextAlignment",GXType.Char,20,0) ,
       new ParDef("MemoIsBold",GXType.Boolean,4,0) ,
       new ParDef("MemoIsItalic",GXType.Boolean,4,0) ,
       new ParDef("MemoIsCapitalized",GXType.Boolean,4,0) ,
       new ParDef("MemoTextColor",GXType.VarChar,40,0) ,
       new ParDef("MemoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P11;
       prmT001P11 = new Object[] {
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Number,6,3){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0){Nullable=true} ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoType",GXType.VarChar,100,0) ,
       new ParDef("MemoName",GXType.VarChar,100,0) ,
       new ParDef("MemoLeftOffset",GXType.Number,6,3) ,
       new ParDef("MemoTopOffset",GXType.Number,6,3) ,
       new ParDef("MemoTitleAngle",GXType.Number,6,3) ,
       new ParDef("MemoTitleScale",GXType.Number,6,3) ,
       new ParDef("MemoTextFontName",GXType.VarChar,100,0) ,
       new ParDef("MemoTextAlignment",GXType.Char,20,0) ,
       new ParDef("MemoIsBold",GXType.Boolean,4,0) ,
       new ParDef("MemoIsItalic",GXType.Boolean,4,0) ,
       new ParDef("MemoIsCapitalized",GXType.Boolean,4,0) ,
       new ParDef("MemoTextColor",GXType.VarChar,40,0) ,
       new ParDef("MemoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P12;
       prmT001P12 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P13;
       prmT001P13 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001P14;
       prmT001P14 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001P2", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, MemoCreatedAt, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId  FOR UPDATE OF Trn_Memo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001P2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P3", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, MemoCreatedAt, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P4", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P5", "SELECT T2.LocationId, T2.OrganisationId, TM1.MemoId, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoType, TM1.MemoName, TM1.MemoLeftOffset, TM1.MemoTopOffset, TM1.MemoTitleAngle, TM1.MemoTitleScale, TM1.MemoTextFontName, TM1.MemoTextAlignment, TM1.MemoIsBold, TM1.MemoIsItalic, TM1.MemoIsCapitalized, TM1.MemoTextColor, TM1.MemoCreatedAt, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM (Trn_Memo TM1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = TM1.ResidentId AND T2.LocationId = TM1.SG_LocationId AND T2.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P6", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P7", "SELECT MemoId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P8", "SELECT MemoId FROM Trn_Memo WHERE ( MemoId > :MemoId) ORDER BY MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001P9", "SELECT MemoId FROM Trn_Memo WHERE ( MemoId < :MemoId) ORDER BY MemoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001P10", "SAVEPOINT gxupdate;INSERT INTO Trn_Memo(MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, MemoCreatedAt, ResidentId, SG_LocationId, SG_OrganisationId) VALUES(:MemoId, :MemoTitle, :MemoDescription, :MemoImage, :MemoDocument, :MemoStartDateTime, :MemoEndDateTime, :MemoDuration, :MemoRemoveDate, :MemoBgColorCode, :MemoForm, :MemoType, :MemoName, :MemoLeftOffset, :MemoTopOffset, :MemoTitleAngle, :MemoTitleScale, :MemoTextFontName, :MemoTextAlignment, :MemoIsBold, :MemoIsItalic, :MemoIsCapitalized, :MemoTextColor, :MemoCreatedAt, :ResidentId, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001P10)
          ,new CursorDef("T001P11", "SAVEPOINT gxupdate;UPDATE Trn_Memo SET MemoTitle=:MemoTitle, MemoDescription=:MemoDescription, MemoImage=:MemoImage, MemoDocument=:MemoDocument, MemoStartDateTime=:MemoStartDateTime, MemoEndDateTime=:MemoEndDateTime, MemoDuration=:MemoDuration, MemoRemoveDate=:MemoRemoveDate, MemoBgColorCode=:MemoBgColorCode, MemoForm=:MemoForm, MemoType=:MemoType, MemoName=:MemoName, MemoLeftOffset=:MemoLeftOffset, MemoTopOffset=:MemoTopOffset, MemoTitleAngle=:MemoTitleAngle, MemoTitleScale=:MemoTitleScale, MemoTextFontName=:MemoTextFontName, MemoTextAlignment=:MemoTextAlignment, MemoIsBold=:MemoIsBold, MemoIsItalic=:MemoIsItalic, MemoIsCapitalized=:MemoIsCapitalized, MemoTextColor=:MemoTextColor, MemoCreatedAt=:MemoCreatedAt, ResidentId=:ResidentId, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001P11)
          ,new CursorDef("T001P12", "SAVEPOINT gxupdate;DELETE FROM Trn_Memo  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001P12)
          ,new CursorDef("T001P13", "SELECT ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001P14", "SELECT MemoId FROM Trn_Memo ORDER BY MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P14,100, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((string[]) buf[15])[0] = rslt.getVarchar(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((string[]) buf[17])[0] = rslt.getString(11, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(12);
             ((string[]) buf[19])[0] = rslt.getVarchar(13);
             ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
             ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
             ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
             ((decimal[]) buf[23])[0] = rslt.getDecimal(17);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getString(19, 20);
             ((bool[]) buf[26])[0] = rslt.getBool(20);
             ((bool[]) buf[27])[0] = rslt.getBool(21);
             ((bool[]) buf[28])[0] = rslt.getBool(22);
             ((string[]) buf[29])[0] = rslt.getVarchar(23);
             ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(24);
             ((bool[]) buf[31])[0] = rslt.wasNull(24);
             ((Guid[]) buf[32])[0] = rslt.getGuid(25);
             ((Guid[]) buf[33])[0] = rslt.getGuid(26);
             ((Guid[]) buf[34])[0] = rslt.getGuid(27);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((string[]) buf[15])[0] = rslt.getVarchar(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((string[]) buf[17])[0] = rslt.getString(11, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(12);
             ((string[]) buf[19])[0] = rslt.getVarchar(13);
             ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
             ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
             ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
             ((decimal[]) buf[23])[0] = rslt.getDecimal(17);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getString(19, 20);
             ((bool[]) buf[26])[0] = rslt.getBool(20);
             ((bool[]) buf[27])[0] = rslt.getBool(21);
             ((bool[]) buf[28])[0] = rslt.getBool(22);
             ((string[]) buf[29])[0] = rslt.getVarchar(23);
             ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(24);
             ((bool[]) buf[31])[0] = rslt.wasNull(24);
             ((Guid[]) buf[32])[0] = rslt.getGuid(25);
             ((Guid[]) buf[33])[0] = rslt.getGuid(26);
             ((Guid[]) buf[34])[0] = rslt.getGuid(27);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[12])[0] = rslt.wasNull(9);
             ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
             ((bool[]) buf[14])[0] = rslt.wasNull(10);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((string[]) buf[17])[0] = rslt.getString(12, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(13);
             ((string[]) buf[19])[0] = rslt.getVarchar(14);
             ((string[]) buf[20])[0] = rslt.getVarchar(15);
             ((string[]) buf[21])[0] = rslt.getVarchar(16);
             ((bool[]) buf[22])[0] = rslt.wasNull(16);
             ((string[]) buf[23])[0] = rslt.getString(17, 20);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getVarchar(19);
             ((decimal[]) buf[26])[0] = rslt.getDecimal(20);
             ((decimal[]) buf[27])[0] = rslt.getDecimal(21);
             ((decimal[]) buf[28])[0] = rslt.getDecimal(22);
             ((decimal[]) buf[29])[0] = rslt.getDecimal(23);
             ((string[]) buf[30])[0] = rslt.getVarchar(24);
             ((string[]) buf[31])[0] = rslt.getString(25, 20);
             ((bool[]) buf[32])[0] = rslt.getBool(26);
             ((bool[]) buf[33])[0] = rslt.getBool(27);
             ((bool[]) buf[34])[0] = rslt.getBool(28);
             ((string[]) buf[35])[0] = rslt.getVarchar(29);
             ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(30);
             ((bool[]) buf[37])[0] = rslt.wasNull(30);
             ((Guid[]) buf[38])[0] = rslt.getGuid(31);
             ((Guid[]) buf[39])[0] = rslt.getGuid(32);
             ((Guid[]) buf[40])[0] = rslt.getGuid(33);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
