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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_forminstance : GXWebComponent
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
               AV7WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV7WWPFormInstanceId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
            {
               A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_15( A206WWPFormId, A207WWPFormVersionNumber) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               AssignAttri(sPrefix, false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A112WWPUserExtendedId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
            {
               A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               A210WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_18( A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
            {
               A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
               n211WWPFormElementParentId = false;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_19( A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_element") == 0 )
            {
               gxnrGridlevel_element_newrow_invoke( ) ;
               return  ;
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstance.aspx")), "workwithplus.dynamicforms.wwp_forminstance.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstance.aspx")))) ;
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
                     AV7WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
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
            Form.Meta.addItem("description", context.GetMessage( "WWPForm Instance", ""), 0) ;
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
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
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

      protected void gxnrGridlevel_element_newrow_invoke( )
      {
         nRC_GXsfl_47 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
         sPrefix = GetPar( "sPrefix");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_element_newrow( ) ;
         /* End function gxnrGridlevel_element_newrow_invoke */
      }

      public wwp_forminstance( )
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

      public wwp_forminstance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_WWPFormInstanceId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WWPFormInstanceId = aP1_WWPFormInstanceId;
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
         cmbWWPFormElementDataType = new GXCombobox();
         chkWWPFormInstanceElemBoolean = new GXCheckbox();
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
            return "wwp_forminstance_Execute" ;
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
            RenderHtmlCloseForm0U42( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_forminstance.aspx");
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormInstanceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormInstanceId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormInstanceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A214WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormInstanceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A214WWPFormInstanceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A214WWPFormInstanceId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormInstanceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormInstanceId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormInstanceDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormInstanceDate_Internalname, context.GetMessage( "Date", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormInstanceDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormInstanceDate_Internalname, context.localUtil.TToC( A239WWPFormInstanceDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A239WWPFormInstanceDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormInstanceDate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtWWPFormInstanceDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormInstanceDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormInstanceDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, context.GetMessage( "WWPForm Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, context.GetMessage( "WWPForm Version Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, context.GetMessage( "WWPForm Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_element_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_element( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_element( )
      {
         /*  Grid Control  */
         StartGridControl47( ) ;
         nGXsfl_47_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount43 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_43 = 1;
               ScanStart0U43( ) ;
               while ( RcdFound43 != 0 )
               {
                  init_level_properties43( ) ;
                  getByPrimaryKey0U43( ) ;
                  AddRow0U43( ) ;
                  ScanNext0U43( ) ;
               }
               ScanEnd0U43( ) ;
               nBlankRcdCount43 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0U43( ) ;
            standaloneModal0U43( ) ;
            sMode43 = Gx_mode;
            while ( nGXsfl_47_idx < nRC_GXsfl_47 )
            {
               bGXsfl_47_Refreshing = true;
               ReadRow0U43( ) ;
               edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemChar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemNumeric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemNumeric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemBlob_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               chkWWPFormInstanceElemBoolean.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemDateTime_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemBlobFileNam_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileNam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemBlobFileTyp_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileTyp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0), !bGXsfl_47_Refreshing);
               if ( ( nRcdExists_43 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal0U43( ) ;
               }
               SendRow0U43( ) ;
               bGXsfl_47_Refreshing = false;
            }
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount43 = 5;
            nRcdExists_43 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0U43( ) ;
               while ( RcdFound43 != 0 )
               {
                  sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4743( ) ;
                  init_level_properties43( ) ;
                  standaloneNotModal0U43( ) ;
                  getByPrimaryKey0U43( ) ;
                  standaloneModal0U43( ) ;
                  AddRow0U43( ) ;
                  ScanNext0U43( ) ;
               }
               ScanEnd0U43( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode43 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4743( ) ;
            InitAll0U43( ) ;
            init_level_properties43( ) ;
            nRcdExists_43 = 0;
            nIsMod_43 = 0;
            nRcdDeleted_43 = 0;
            nBlankRcdCount43 = (short)(nBlankRcdUsr43+nBlankRcdCount43);
            fRowAdded = 0;
            while ( nBlankRcdCount43 > 0 )
            {
               standaloneNotModal0U43( ) ;
               standaloneModal0U43( ) ;
               AddRow0U43( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtWWPFormElementId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount43 = (short)(nBlankRcdCount43-1);
            }
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+sPrefix+"Gridlevel_elementContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridlevel_element", Gridlevel_elementContainer, subGridlevel_element_Internalname);
         if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData", Gridlevel_elementContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData"+"V", Gridlevel_elementContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridlevel_elementContainerData"+"V"+"\" value='"+Gridlevel_elementContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110U2 ();
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
               Z214WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z214WWPFormInstanceId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z239WWPFormInstanceDate = context.localUtil.CToT( cgiGet( sPrefix+"Z239WWPFormInstanceDate"), 0);
               Z206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z112WWPUserExtendedId = cgiGet( sPrefix+"Z112WWPUserExtendedId");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormInstanceId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A112WWPUserExtendedId = cgiGet( sPrefix+"Z112WWPUserExtendedId");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_47"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"N206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"N207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N112WWPUserExtendedId = cgiGet( sPrefix+"N112WWPUserExtendedId");
               AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMINSTANCEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_WWPFORMID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV12Insert_WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_WWPFORMVERSIONNUMBER"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV16Insert_WWPUserExtendedId = cgiGet( sPrefix+"vINSERT_WWPUSEREXTENDEDID");
               A112WWPUserExtendedId = cgiGet( sPrefix+"WWPUSEREXTENDEDID");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A243WWPFormInstanceRecordKey = cgiGet( sPrefix+"WWPFORMINSTANCERECORDKEY");
               n243WWPFormInstanceRecordKey = false;
               n243WWPFormInstanceRecordKey = (String.IsNullOrEmpty(StringUtil.RTrim( A243WWPFormInstanceRecordKey)) ? true : false);
               A208WWPFormReferenceName = cgiGet( sPrefix+"WWPFORMREFERENCENAME");
               A216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMRESUME"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A233WWPFormValidations = cgiGet( sPrefix+"WWPFORMVALIDATIONS");
               A113WWPUserExtendedFullName = cgiGet( sPrefix+"WWPUSEREXTENDEDFULLNAME");
               AV21Pgmname = cgiGet( sPrefix+"vPGMNAME");
               A217WWPFormElementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A236WWPFormElementMetadata = cgiGet( sPrefix+"WWPFORMELEMENTMETADATA");
               A237WWPFormElementCaption = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A230WWPFormElementParentType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A214WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormInstanceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormInstanceDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Instance Date", "")}), 1, "WWPFORMINSTANCEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
                  AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A239WWPFormInstanceDate = context.localUtil.CToT( cgiGet( edtWWPFormInstanceDate_Internalname));
                  AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A206WWPFormId = 0;
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               else
               {
                  A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormVersionNumber_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A207WWPFormVersionNumber = 0;
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               else
               {
                  A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_FormInstance");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A214WWPFormInstanceId != Z214WWPFormInstanceId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_forminstance:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A214WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode42 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode42;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound42 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WWPFORMINSTANCEID");
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormInstanceId_Internalname;
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
                                 E110U2 ();
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
                                 E120U2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E120U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0U42( ) ;
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
            DisableAttributes0U42( ) ;
         }
         AssignProp(sPrefix, false, edtWWPFormInstanceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceDate_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U42( ) ;
            }
            else
            {
               CheckExtendedTable0U42( ) ;
               CloseExtendedTableCursors0U42( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode42 = Gx_mode;
            CONFIRM_0U43( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode42;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode42;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0U43( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            ReadRow0U43( ) ;
            if ( ( nRcdExists_43 != 0 ) || ( nIsMod_43 != 0 ) )
            {
               GetKey0U43( ) ;
               if ( ( nRcdExists_43 == 0 ) && ( nRcdDeleted_43 == 0 ) )
               {
                  if ( RcdFound43 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate0U43( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0U43( ) ;
                        CloseExtendedTableCursors0U43( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormElementId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound43 != 0 )
                  {
                     if ( nRcdDeleted_43 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0U43( ) ;
                        Load0U43( ) ;
                        BeforeValidate0U43( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0U43( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_43 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate0U43( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0U43( ) ;
                              CloseExtendedTableCursors0U43( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_43 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemChar_Internalname, A221WWPFormInstanceElemChar) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDate_Internalname, context.localUtil.Format(A220WWPFormInstanceElemDate, "99/99/99")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemNumeric_Internalname, StringUtil.LTrim( StringUtil.NToC( A222WWPFormInstanceElemNumeric, 21, 5, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlob_Internalname, A223WWPFormInstanceElemBlob) ;
            ChangePostValue( sPrefix+chkWWPFormInstanceElemBoolean_Internalname, StringUtil.BoolToStr( A226WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDateTime_Internalname, context.localUtil.TToC( A227WWPFormInstanceElemDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileNam_Internalname, A225WWPFormInstanceElemBlobFileNam) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileTyp_Internalname, A224WWPFormInstanceElemBlobFileTyp) ;
            ChangePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z215WWPFormInstanceElementId_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z220WWPFormInstanceElemDate_"+sGXsfl_47_idx, context.localUtil.DToC( Z220WWPFormInstanceElemDate, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z227WWPFormInstanceElemDateTime_"+sGXsfl_47_idx, context.localUtil.TToC( Z227WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z222WWPFormInstanceElemNumeric_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( Z222WWPFormInstanceElemNumeric, 18, 5, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z226WWPFormInstanceElemBoolean_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z226WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nIsMod_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_43 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0U0( )
      {
      }

      protected void E110U2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            AssignAttri(sPrefix, false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormId") == 0 )
               {
                  AV11Insert_WWPFormId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11Insert_WWPFormId", StringUtil.LTrimStr( (decimal)(AV11Insert_WWPFormId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormVersionNumber") == 0 )
               {
                  AV12Insert_WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV12Insert_WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV12Insert_WWPFormVersionNumber), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPUserExtendedId") == 0 )
               {
                  AV16Insert_WWPUserExtendedId = AV13TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri(sPrefix, false, "AV16Insert_WWPUserExtendedId", AV16Insert_WWPUserExtendedId);
               }
               AV22GXV1 = (int)(AV22GXV1+1);
               AssignAttri(sPrefix, false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            }
         }
      }

      protected void E120U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0U42( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z239WWPFormInstanceDate = T000U7_A239WWPFormInstanceDate[0];
               Z206WWPFormId = T000U7_A206WWPFormId[0];
               Z207WWPFormVersionNumber = T000U7_A207WWPFormVersionNumber[0];
               Z112WWPUserExtendedId = T000U7_A112WWPUserExtendedId[0];
            }
            else
            {
               Z239WWPFormInstanceDate = A239WWPFormInstanceDate;
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
               Z112WWPUserExtendedId = A112WWPUserExtendedId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z239WWPFormInstanceDate = A239WWPFormInstanceDate;
            Z243WWPFormInstanceRecordKey = A243WWPFormInstanceRecordKey;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z216WWPFormResume = A216WWPFormResume;
            Z233WWPFormValidations = A233WWPFormValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         AV21Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance";
         AssignAttri(sPrefix, false, "AV21Pgmname", AV21Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WWPFormInstanceId) )
         {
            A214WWPFormInstanceId = AV7WWPFormInstanceId;
            AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormVersionNumber_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_WWPUserExtendedId)) )
         {
            A112WWPUserExtendedId = AV16Insert_WWPUserExtendedId;
            AssignAttri(sPrefix, false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_WWPFormVersionNumber) )
         {
            A207WWPFormVersionNumber = AV12Insert_WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_WWPFormId) )
         {
            A206WWPFormId = AV11Insert_WWPFormId;
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A239WWPFormInstanceDate) && ( Gx_BScreen == 0 ) )
         {
            A239WWPFormInstanceDate = DateTimeUtil.Now( context);
            AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000U9 */
            pr_default.execute(7, new Object[] {A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = T000U9_A113WWPUserExtendedFullName[0];
            pr_default.close(7);
            /* Using cursor T000U8 */
            pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = T000U8_A208WWPFormReferenceName[0];
            A209WWPFormTitle = T000U8_A209WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
            A216WWPFormResume = T000U8_A216WWPFormResume[0];
            A233WWPFormValidations = T000U8_A233WWPFormValidations[0];
            pr_default.close(6);
         }
      }

      protected void Load0U42( )
      {
         /* Using cursor T000U10 */
         pr_default.execute(8, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound42 = 1;
            A239WWPFormInstanceDate = T000U10_A239WWPFormInstanceDate[0];
            AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A208WWPFormReferenceName = T000U10_A208WWPFormReferenceName[0];
            A209WWPFormTitle = T000U10_A209WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
            A113WWPUserExtendedFullName = T000U10_A113WWPUserExtendedFullName[0];
            A216WWPFormResume = T000U10_A216WWPFormResume[0];
            A233WWPFormValidations = T000U10_A233WWPFormValidations[0];
            A243WWPFormInstanceRecordKey = T000U10_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = T000U10_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = T000U10_A206WWPFormId[0];
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T000U10_A207WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            A112WWPUserExtendedId = T000U10_A112WWPUserExtendedId[0];
            ZM0U42( -14) ;
         }
         pr_default.close(8);
         OnLoadActions0U42( ) ;
      }

      protected void OnLoadActions0U42( )
      {
      }

      protected void CheckExtendedTable0U42( )
      {
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000U8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T000U8_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T000U8_A209WWPFormTitle[0];
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         A216WWPFormResume = T000U8_A216WWPFormResume[0];
         A233WWPFormValidations = T000U8_A233WWPFormValidations[0];
         pr_default.close(6);
         /* Using cursor T000U9 */
         pr_default.execute(7, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A113WWPUserExtendedFullName = T000U9_A113WWPUserExtendedFullName[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0U42( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( short A206WWPFormId ,
                                short A207WWPFormVersionNumber )
      {
         /* Using cursor T000U11 */
         pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T000U11_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T000U11_A209WWPFormTitle[0];
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         A216WWPFormResume = T000U11_A216WWPFormResume[0];
         A233WWPFormValidations = T000U11_A233WWPFormValidations[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A208WWPFormReferenceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A209WWPFormTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A233WWPFormValidations)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_16( string A112WWPUserExtendedId )
      {
         /* Using cursor T000U12 */
         pr_default.execute(10, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A113WWPUserExtendedFullName = T000U12_A113WWPUserExtendedFullName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A113WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0U42( )
      {
         /* Using cursor T000U13 */
         pr_default.execute(11, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000U7 */
         pr_default.execute(5, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0U42( 14) ;
            RcdFound42 = 1;
            A214WWPFormInstanceId = T000U7_A214WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
            A239WWPFormInstanceDate = T000U7_A239WWPFormInstanceDate[0];
            AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A243WWPFormInstanceRecordKey = T000U7_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = T000U7_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = T000U7_A206WWPFormId[0];
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T000U7_A207WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            A112WWPUserExtendedId = T000U7_A112WWPUserExtendedId[0];
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0U42( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey0U42( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey0U42( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U42( ) ;
         if ( RcdFound42 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound42 = 0;
         /* Using cursor T000U14 */
         pr_default.execute(12, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000U14_A214WWPFormInstanceId[0] < A214WWPFormInstanceId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000U14_A214WWPFormInstanceId[0] > A214WWPFormInstanceId ) ) )
            {
               A214WWPFormInstanceId = T000U14_A214WWPFormInstanceId[0];
               AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T000U15 */
         pr_default.execute(13, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000U15_A214WWPFormInstanceId[0] > A214WWPFormInstanceId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000U15_A214WWPFormInstanceId[0] < A214WWPFormInstanceId ) ) )
            {
               A214WWPFormInstanceId = T000U15_A214WWPFormInstanceId[0];
               AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0U42( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0U42( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
               {
                  A214WWPFormInstanceId = Z214WWPFormInstanceId;
                  AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPFORMINSTANCEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormInstanceId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0U42( ) ;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
               {
                  /* Insert record */
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0U42( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPFORMINSTANCEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormInstanceId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0U42( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
         {
            A214WWPFormInstanceId = Z214WWPFormInstanceId;
            AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPFORMINSTANCEID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0U42( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U6 */
            pr_default.execute(4, new Object[] {A214WWPFormInstanceId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( Z239WWPFormInstanceDate != T000U6_A239WWPFormInstanceDate[0] ) || ( Z206WWPFormId != T000U6_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != T000U6_A207WWPFormVersionNumber[0] ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000U6_A112WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z239WWPFormInstanceDate != T000U6_A239WWPFormInstanceDate[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceDate");
                  GXUtil.WriteLogRaw("Old: ",Z239WWPFormInstanceDate);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A239WWPFormInstanceDate[0]);
               }
               if ( Z206WWPFormId != T000U6_A206WWPFormId[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormId");
                  GXUtil.WriteLogRaw("Old: ",Z206WWPFormId);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A206WWPFormId[0]);
               }
               if ( Z207WWPFormVersionNumber != T000U6_A207WWPFormVersionNumber[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormVersionNumber");
                  GXUtil.WriteLogRaw("Old: ",Z207WWPFormVersionNumber);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A207WWPFormVersionNumber[0]);
               }
               if ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000U6_A112WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z112WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A112WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstance"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U42( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U42( 0) ;
            CheckOptimisticConcurrency0U42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U16 */
                     pr_default.execute(14, new Object[] {A239WWPFormInstanceDate, n243WWPFormInstanceRecordKey, A243WWPFormInstanceRecordKey, A206WWPFormId, A207WWPFormVersionNumber, A112WWPUserExtendedId});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000U17 */
                     pr_default.execute(15);
                     A214WWPFormInstanceId = T000U17_A214WWPFormInstanceId[0];
                     AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U42( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0U0( ) ;
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
               Load0U42( ) ;
            }
            EndLevel0U42( ) ;
         }
         CloseExtendedTableCursors0U42( ) ;
      }

      protected void Update0U42( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U18 */
                     pr_default.execute(16, new Object[] {A239WWPFormInstanceDate, n243WWPFormInstanceRecordKey, A243WWPFormInstanceRecordKey, A206WWPFormId, A207WWPFormVersionNumber, A112WWPUserExtendedId, A214WWPFormInstanceId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U42( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U42( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
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
            }
            EndLevel0U42( ) ;
         }
         CloseExtendedTableCursors0U42( ) ;
      }

      protected void DeferredUpdate0U42( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U42( ) ;
            AfterConfirm0U42( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U42( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0U43( ) ;
                  while ( RcdFound43 != 0 )
                  {
                     getByPrimaryKey0U43( ) ;
                     Delete0U43( ) ;
                     ScanNext0U43( ) ;
                  }
                  ScanEnd0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U19 */
                     pr_default.execute(17, new Object[] {A214WWPFormInstanceId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
         }
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0U42( ) ;
         Gx_mode = sMode42;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U42( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000U20 */
            pr_default.execute(18, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = T000U20_A208WWPFormReferenceName[0];
            A209WWPFormTitle = T000U20_A209WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
            A216WWPFormResume = T000U20_A216WWPFormResume[0];
            A233WWPFormValidations = T000U20_A233WWPFormValidations[0];
            pr_default.close(18);
            /* Using cursor T000U21 */
            pr_default.execute(19, new Object[] {A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = T000U21_A113WWPUserExtendedFullName[0];
            pr_default.close(19);
         }
      }

      protected void ProcessNestedLevel0U43( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            ReadRow0U43( ) ;
            if ( ( nRcdExists_43 != 0 ) || ( nIsMod_43 != 0 ) )
            {
               standaloneNotModal0U43( ) ;
               GetKey0U43( ) ;
               if ( ( nRcdExists_43 == 0 ) && ( nRcdDeleted_43 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert0U43( ) ;
               }
               else
               {
                  if ( RcdFound43 != 0 )
                  {
                     if ( ( nRcdDeleted_43 != 0 ) && ( nRcdExists_43 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete0U43( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_43 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update0U43( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_43 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemChar_Internalname, A221WWPFormInstanceElemChar) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDate_Internalname, context.localUtil.Format(A220WWPFormInstanceElemDate, "99/99/99")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemNumeric_Internalname, StringUtil.LTrim( StringUtil.NToC( A222WWPFormInstanceElemNumeric, 21, 5, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlob_Internalname, A223WWPFormInstanceElemBlob) ;
            ChangePostValue( sPrefix+chkWWPFormInstanceElemBoolean_Internalname, StringUtil.BoolToStr( A226WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDateTime_Internalname, context.localUtil.TToC( A227WWPFormInstanceElemDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileNam_Internalname, A225WWPFormInstanceElemBlobFileNam) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileTyp_Internalname, A224WWPFormInstanceElemBlobFileTyp) ;
            ChangePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z215WWPFormInstanceElementId_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z220WWPFormInstanceElemDate_"+sGXsfl_47_idx, context.localUtil.DToC( Z220WWPFormInstanceElemDate, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z227WWPFormInstanceElemDateTime_"+sGXsfl_47_idx, context.localUtil.TToC( Z227WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z222WWPFormInstanceElemNumeric_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( Z222WWPFormInstanceElemNumeric, 18, 5, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z226WWPFormInstanceElemBoolean_"+sGXsfl_47_idx, StringUtil.BoolToStr( Z226WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nIsMod_43_"+sGXsfl_47_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_43 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0U43( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_43 = 0;
         nIsMod_43 = 0;
         nRcdDeleted_43 = 0;
      }

      protected void ProcessLevel0U42( )
      {
         /* Save parent mode. */
         sMode42 = Gx_mode;
         ProcessNestedLevel0U43( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode42;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0U42( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_forminstance",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("workwithplus.dynamicforms.wwp_forminstance",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U42( )
      {
         /* Scan By routine */
         /* Using cursor T000U22 */
         pr_default.execute(20);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound42 = 1;
            A214WWPFormInstanceId = T000U22_A214WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U42( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound42 = 1;
            A214WWPFormInstanceId = T000U22_A214WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
         }
      }

      protected void ScanEnd0U42( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0U42( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U42( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U42( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U42( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U42( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U42( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U42( )
      {
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         edtWWPFormInstanceDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceDate_Enabled), 5, 0), true);
         edtWWPFormId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
      }

      protected void ZM0U43( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z220WWPFormInstanceElemDate = T000U3_A220WWPFormInstanceElemDate[0];
               Z227WWPFormInstanceElemDateTime = T000U3_A227WWPFormInstanceElemDateTime[0];
               Z222WWPFormInstanceElemNumeric = T000U3_A222WWPFormInstanceElemNumeric[0];
               Z226WWPFormInstanceElemBoolean = T000U3_A226WWPFormInstanceElemBoolean[0];
            }
            else
            {
               Z220WWPFormInstanceElemDate = A220WWPFormInstanceElemDate;
               Z227WWPFormInstanceElemDateTime = A227WWPFormInstanceElemDateTime;
               Z222WWPFormInstanceElemNumeric = A222WWPFormInstanceElemNumeric;
               Z226WWPFormInstanceElemBoolean = A226WWPFormInstanceElemBoolean;
            }
         }
         if ( GX_JID == -17 )
         {
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
            Z221WWPFormInstanceElemChar = A221WWPFormInstanceElemChar;
            Z220WWPFormInstanceElemDate = A220WWPFormInstanceElemDate;
            Z227WWPFormInstanceElemDateTime = A227WWPFormInstanceElemDateTime;
            Z222WWPFormInstanceElemNumeric = A222WWPFormInstanceElemNumeric;
            Z223WWPFormInstanceElemBlob = A223WWPFormInstanceElemBlob;
            Z226WWPFormInstanceElemBoolean = A226WWPFormInstanceElemBoolean;
            Z224WWPFormInstanceElemBlobFileTyp = A224WWPFormInstanceElemBlobFileTyp;
            Z225WWPFormInstanceElemBlobFileNam = A225WWPFormInstanceElemBlobFileNam;
            Z210WWPFormElementId = A210WWPFormElementId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z229WWPFormElementTitle = A229WWPFormElementTitle;
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z236WWPFormElementMetadata = A236WWPFormElementMetadata;
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0U43( )
      {
      }

      protected void standaloneModal0U43( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
         else
         {
            edtWWPFormElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormInstanceElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
         else
         {
            edtWWPFormInstanceElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         }
      }

      protected void Load0U43( )
      {
         /* Using cursor T000U23 */
         pr_default.execute(21, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A214WWPFormInstanceId, A215WWPFormInstanceElementId, A210WWPFormElementId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound43 = 1;
            A229WWPFormElementTitle = T000U23_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = T000U23_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = T000U23_A218WWPFormElementDataType[0];
            A230WWPFormElementParentType = T000U23_A230WWPFormElementParentType[0];
            A217WWPFormElementType = T000U23_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = T000U23_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = T000U23_A237WWPFormElementCaption[0];
            A221WWPFormInstanceElemChar = T000U23_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = T000U23_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = T000U23_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = T000U23_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = T000U23_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = T000U23_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = T000U23_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = T000U23_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = T000U23_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = T000U23_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = T000U23_A224WWPFormInstanceElemBlobFileTyp[0];
            edtWWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_47_Refreshing);
            A225WWPFormInstanceElemBlobFileNam = T000U23_A225WWPFormInstanceElemBlobFileNam[0];
            edtWWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A211WWPFormElementParentId = T000U23_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T000U23_n211WWPFormElementParentId[0];
            A223WWPFormInstanceElemBlob = T000U23_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = T000U23_n223WWPFormInstanceElemBlob[0];
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A223WWPFormInstanceElemBlob), !bGXsfl_47_Refreshing);
            ZM0U43( -17) ;
         }
         pr_default.close(21);
         OnLoadActions0U43( ) ;
      }

      protected void OnLoadActions0U43( )
      {
      }

      protected void CheckExtendedTable0U43( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0U43( ) ;
         /* Using cursor T000U4 */
         pr_default.execute(2, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Element", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A229WWPFormElementTitle = T000U4_A229WWPFormElementTitle[0];
         A213WWPFormElementReferenceId = T000U4_A213WWPFormElementReferenceId[0];
         A218WWPFormElementDataType = T000U4_A218WWPFormElementDataType[0];
         A217WWPFormElementType = T000U4_A217WWPFormElementType[0];
         A236WWPFormElementMetadata = T000U4_A236WWPFormElementMetadata[0];
         A237WWPFormElementCaption = T000U4_A237WWPFormElementCaption[0];
         A211WWPFormElementParentId = T000U4_A211WWPFormElementParentId[0];
         n211WWPFormElementParentId = T000U4_n211WWPFormElementParentId[0];
         pr_default.close(2);
         /* Using cursor T000U5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_47_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A230WWPFormElementParentType = T000U5_A230WWPFormElementParentType[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0U43( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0U43( )
      {
      }

      protected void gxLoad_18( short A206WWPFormId ,
                                short A207WWPFormVersionNumber ,
                                short A210WWPFormElementId )
      {
         /* Using cursor T000U24 */
         pr_default.execute(22, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Element", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A229WWPFormElementTitle = T000U24_A229WWPFormElementTitle[0];
         A213WWPFormElementReferenceId = T000U24_A213WWPFormElementReferenceId[0];
         A218WWPFormElementDataType = T000U24_A218WWPFormElementDataType[0];
         A217WWPFormElementType = T000U24_A217WWPFormElementType[0];
         A236WWPFormElementMetadata = T000U24_A236WWPFormElementMetadata[0];
         A237WWPFormElementCaption = T000U24_A237WWPFormElementCaption[0];
         A211WWPFormElementParentId = T000U24_A211WWPFormElementParentId[0];
         n211WWPFormElementParentId = T000U24_n211WWPFormElementParentId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A229WWPFormElementTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( A213WWPFormElementReferenceId)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A236WWPFormElementMetadata)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_19( short A206WWPFormId ,
                                short A207WWPFormVersionNumber ,
                                short A211WWPFormElementParentId )
      {
         /* Using cursor T000U25 */
         pr_default.execute(23, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_47_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A230WWPFormElementParentType = T000U25_A230WWPFormElementParentType[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void GetKey0U43( )
      {
         /* Using cursor T000U26 */
         pr_default.execute(24, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey0U43( )
      {
         /* Using cursor T000U3 */
         pr_default.execute(1, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U43( 17) ;
            RcdFound43 = 1;
            InitializeNonKey0U43( ) ;
            A215WWPFormInstanceElementId = T000U3_A215WWPFormInstanceElementId[0];
            A221WWPFormInstanceElemChar = T000U3_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = T000U3_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = T000U3_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = T000U3_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = T000U3_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = T000U3_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = T000U3_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = T000U3_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = T000U3_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = T000U3_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = T000U3_A224WWPFormInstanceElemBlobFileTyp[0];
            edtWWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_47_Refreshing);
            A225WWPFormInstanceElemBlobFileNam = T000U3_A225WWPFormInstanceElemBlobFileNam[0];
            edtWWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A210WWPFormElementId = T000U3_A210WWPFormElementId[0];
            A223WWPFormInstanceElemBlob = T000U3_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = T000U3_n223WWPFormInstanceElemBlob[0];
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A223WWPFormInstanceElemBlob), !bGXsfl_47_Refreshing);
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z210WWPFormElementId = A210WWPFormElementId;
            Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0U43( ) ;
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey0U43( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal0U43( ) ;
            Gx_mode = sMode43;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0U43( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0U43( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U2 */
            pr_default.execute(0, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z220WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( T000U2_A220WWPFormInstanceElemDate[0] ) ) || ( Z227WWPFormInstanceElemDateTime != T000U2_A227WWPFormInstanceElemDateTime[0] ) || ( Z222WWPFormInstanceElemNumeric != T000U2_A222WWPFormInstanceElemNumeric[0] ) || ( Z226WWPFormInstanceElemBoolean != T000U2_A226WWPFormInstanceElemBoolean[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z220WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( T000U2_A220WWPFormInstanceElemDate[0] ) )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemDate");
                  GXUtil.WriteLogRaw("Old: ",Z220WWPFormInstanceElemDate);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A220WWPFormInstanceElemDate[0]);
               }
               if ( Z227WWPFormInstanceElemDateTime != T000U2_A227WWPFormInstanceElemDateTime[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z227WWPFormInstanceElemDateTime);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A227WWPFormInstanceElemDateTime[0]);
               }
               if ( Z222WWPFormInstanceElemNumeric != T000U2_A222WWPFormInstanceElemNumeric[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemNumeric");
                  GXUtil.WriteLogRaw("Old: ",Z222WWPFormInstanceElemNumeric);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A222WWPFormInstanceElemNumeric[0]);
               }
               if ( Z226WWPFormInstanceElemBoolean != T000U2_A226WWPFormInstanceElemBoolean[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemBoolean");
                  GXUtil.WriteLogRaw("Old: ",Z226WWPFormInstanceElemBoolean);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A226WWPFormInstanceElemBoolean[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstanceElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U43( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U43( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U43( 0) ;
            CheckOptimisticConcurrency0U43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U27 */
                     A224WWPFormInstanceElemBlobFileTyp = edtWWPFormInstanceElemBlob_Filetype;
                     A225WWPFormInstanceElemBlobFileNam = edtWWPFormInstanceElemBlob_Filename;
                     pr_default.execute(25, new Object[] {A214WWPFormInstanceId, A215WWPFormInstanceElementId, n221WWPFormInstanceElemChar, A221WWPFormInstanceElemChar, n220WWPFormInstanceElemDate, A220WWPFormInstanceElemDate, n227WWPFormInstanceElemDateTime, A227WWPFormInstanceElemDateTime, n222WWPFormInstanceElemNumeric, A222WWPFormInstanceElemNumeric, n223WWPFormInstanceElemBlob, A223WWPFormInstanceElemBlob, n226WWPFormInstanceElemBoolean, A226WWPFormInstanceElemBoolean, A224WWPFormInstanceElemBlobFileTyp, A225WWPFormInstanceElemBlobFileNam, A210WWPFormElementId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(25) == 1) )
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
                           /* Save values for previous() function. */
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
               Load0U43( ) ;
            }
            EndLevel0U43( ) ;
         }
         CloseExtendedTableCursors0U43( ) ;
      }

      protected void Update0U43( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U43( ) ;
         }
         if ( ( nIsMod_43 != 0 ) || ( nIsDirty_43 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0U43( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0U43( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000U28 */
                        A224WWPFormInstanceElemBlobFileTyp = edtWWPFormInstanceElemBlob_Filetype;
                        A225WWPFormInstanceElemBlobFileNam = edtWWPFormInstanceElemBlob_Filename;
                        pr_default.execute(26, new Object[] {n221WWPFormInstanceElemChar, A221WWPFormInstanceElemChar, n220WWPFormInstanceElemDate, A220WWPFormInstanceElemDate, n227WWPFormInstanceElemDateTime, A227WWPFormInstanceElemDateTime, n222WWPFormInstanceElemNumeric, A222WWPFormInstanceElemNumeric, n226WWPFormInstanceElemBoolean, A226WWPFormInstanceElemBoolean, A224WWPFormInstanceElemBlobFileTyp, A225WWPFormInstanceElemBlobFileNam, A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
                        pr_default.close(26);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                        if ( (pr_default.getStatus(26) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0U43( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0U43( ) ;
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
               EndLevel0U43( ) ;
            }
         }
         CloseExtendedTableCursors0U43( ) ;
      }

      protected void DeferredUpdate0U43( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000U29 */
            pr_default.execute(27, new Object[] {n223WWPFormInstanceElemBlob, A223WWPFormInstanceElemBlob, A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
            pr_default.close(27);
            pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
         }
      }

      protected void Delete0U43( )
      {
         if ( ! IsAuthorized("wwp_forminstance_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U43( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U43( ) ;
            AfterConfirm0U43( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U43( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000U30 */
                  pr_default.execute(28, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0U43( ) ;
         Gx_mode = sMode43;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U43( )
      {
         standaloneModal0U43( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000U31 */
            pr_default.execute(29, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            A229WWPFormElementTitle = T000U31_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = T000U31_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = T000U31_A218WWPFormElementDataType[0];
            A217WWPFormElementType = T000U31_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = T000U31_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = T000U31_A237WWPFormElementCaption[0];
            A211WWPFormElementParentId = T000U31_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T000U31_n211WWPFormElementParentId[0];
            pr_default.close(29);
            /* Using cursor T000U32 */
            pr_default.execute(30, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
            A230WWPFormElementParentType = T000U32_A230WWPFormElementParentType[0];
            pr_default.close(30);
         }
      }

      protected void EndLevel0U43( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U43( )
      {
         /* Scan By routine */
         /* Using cursor T000U33 */
         pr_default.execute(31, new Object[] {A214WWPFormInstanceId});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound43 = 1;
            A210WWPFormElementId = T000U33_A210WWPFormElementId[0];
            A215WWPFormInstanceElementId = T000U33_A215WWPFormInstanceElementId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U43( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound43 = 1;
            A210WWPFormElementId = T000U33_A210WWPFormElementId[0];
            A215WWPFormInstanceElementId = T000U33_A215WWPFormInstanceElementId[0];
         }
      }

      protected void ScanEnd0U43( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm0U43( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U43( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U43( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U43( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U43( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U43( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U43( )
      {
         edtWWPFormElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormElementTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         cmbWWPFormElementDataType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemChar_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemNumeric_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemNumeric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemBlob_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         chkWWPFormInstanceElemBoolean.Enabled = 0;
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormElementReferenceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormElementParentId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemBlobFileNam_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileNam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemBlobFileTyp_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileTyp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0), !bGXsfl_47_Refreshing);
      }

      protected void send_integrity_lvl_hashes0U43( )
      {
      }

      protected void send_integrity_lvl_hashes0U42( )
      {
      }

      protected void SubsflControlProps_4743( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx;
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx;
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemBlobFileNam_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx;
         edtWWPFormInstanceElemBlobFileTyp_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_4743( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_fel_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_fel_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_fel_idx;
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_fel_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_fel_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemBlobFileNam_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_fel_idx;
         edtWWPFormInstanceElemBlobFileTyp_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_fel_idx;
      }

      protected void AddRow0U43( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4743( ) ;
         SendRow0U43( ) ;
      }

      protected void SendRow0U43( )
      {
         Gridlevel_elementRow = GXWebRow.GetNew(context);
         if ( subGridlevel_element_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            subGridlevel_element_Backcolor = subGridlevel_element_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Uniform";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
            subGridlevel_element_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_element_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Even";
               }
            }
            else
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A210WWPFormElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,48);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A215WWPFormInstanceElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementTitle_Internalname,(string)A229WWPFormElementTitle,(string)A229WWPFormElementTitle,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementTitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)47,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_47_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", context.GetMessage( "WWP_DF_DataType_Boolean", ""), 0);
         cmbWWPFormElementDataType.addItem("2", context.GetMessage( "WWP_DF_DataType_Character", ""), 0);
         cmbWWPFormElementDataType.addItem("3", context.GetMessage( "WWP_DF_DataType_Numeric", ""), 0);
         cmbWWPFormElementDataType.addItem("4", context.GetMessage( "WWP_DF_DataType_Date", ""), 0);
         cmbWWPFormElementDataType.addItem("5", context.GetMessage( "WWP_DF_DataType_Datetime", ""), 0);
         cmbWWPFormElementDataType.addItem("6", context.GetMessage( "WWP_DF_DataType_Password", ""), 0);
         cmbWWPFormElementDataType.addItem("7", context.GetMessage( "WWP_DF_DataType_Email", ""), 0);
         cmbWWPFormElementDataType.addItem("8", context.GetMessage( "WWP_DF_DataType_Url", ""), 0);
         cmbWWPFormElementDataType.addItem("9", context.GetMessage( "WWP_DF_DataType_File", ""), 0);
         cmbWWPFormElementDataType.addItem("10", context.GetMessage( "WWP_DF_DataType_Image", ""), 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
            A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementDataType,(string)cmbWWPFormElementDataType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0)),(short)1,(string)cmbWWPFormElementDataType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementDataType.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", (string)(cmbWWPFormElementDataType.ToJavascriptSource()), !bGXsfl_47_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemChar_Internalname,(string)A221WWPFormInstanceElemChar,(string)A221WWPFormInstanceElemChar,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemChar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemChar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)47,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "AttributeDate";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemDate_Internalname,context.localUtil.Format(A220WWPFormInstanceElemDate, "99/99/99"),context.localUtil.Format( A220WWPFormInstanceElemDate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemDate_Jsonclick,(short)0,(string)"AttributeDate",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemDate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemNumeric_Internalname,StringUtil.LTrim( StringUtil.NToC( A222WWPFormInstanceElemNumeric, 21, 5, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormInstanceElemNumeric_Enabled!=0) ? context.localUtil.Format( A222WWPFormInstanceElemNumeric, "ZZZ,ZZZ,ZZZ,ZZ9.99999") : context.localUtil.Format( A222WWPFormInstanceElemNumeric, "ZZZ,ZZZ,ZZZ,ZZ9.99999"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'5');"+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemNumeric_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemNumeric_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         ClassString = "Attribute";
         StyleString = "";
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         edtWWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
         edtWWPFormInstanceElemBlob_Filetype = "";
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_47_Refreshing);
         edtWWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_47_Refreshing);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A223WWPFormInstanceElemBlob)) )
         {
            gxblobfileaux.Source = A223WWPFormInstanceElemBlob;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtWWPFormInstanceElemBlob_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtWWPFormInstanceElemBlob_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A223WWPFormInstanceElemBlob = gxblobfileaux.GetURI();
               n223WWPFormInstanceElemBlob = false;
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A223WWPFormInstanceElemBlob), !bGXsfl_47_Refreshing);
               edtWWPFormInstanceElemBlob_Filetype = gxblobfileaux.GetExtension();
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_47_Refreshing);
            }
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A223WWPFormInstanceElemBlob), !bGXsfl_47_Refreshing);
         }
         Gridlevel_elementRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlob_Internalname,StringUtil.RTrim( A223WWPFormInstanceElemBlob),context.PathToRelativeUrl( A223WWPFormInstanceElemBlob),(String.IsNullOrEmpty(StringUtil.RTrim( edtWWPFormInstanceElemBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype)) ? A223WWPFormInstanceElemBlob : edtWWPFormInstanceElemBlob_Filetype)) : edtWWPFormInstanceElemBlob_Contenttype),(bool)true,(string)"",(string)edtWWPFormInstanceElemBlob_Parameters,(short)0,(int)edtWWPFormInstanceElemBlob_Enabled,(short)-1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtWWPFormInstanceElemBlob_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"",(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "WWPFORMINSTANCEELEMBOOLEAN_" + sGXsfl_47_idx;
         chkWWPFormInstanceElemBoolean.Name = GXCCtl;
         chkWWPFormInstanceElemBoolean.WebTags = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "TitleCaption", chkWWPFormInstanceElemBoolean.Caption, !bGXsfl_47_Refreshing);
         chkWWPFormInstanceElemBoolean.CheckedValue = "false";
         Gridlevel_elementRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkWWPFormInstanceElemBoolean_Internalname,StringUtil.BoolToStr( A226WWPFormInstanceElemBoolean),(string)"",(string)"",(short)-1,chkWWPFormInstanceElemBoolean.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementReferenceId_Internalname,(string)A213WWPFormElementReferenceId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementReferenceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementReferenceId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormElementParentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9") : context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,58);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "AttributeDateTime";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemDateTime_Internalname,context.localUtil.TToC( A227WWPFormInstanceElemDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A227WWPFormInstanceElemDateTime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemDateTime_Jsonclick,(short)0,(string)"AttributeDateTime",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemDateTime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlobFileNam_Internalname,(string)A225WWPFormInstanceElemBlobFileNam,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemBlobFileNam_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemBlobFileNam_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_47_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_47_idx + "',47)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlobFileTyp_Internalname,(string)A224WWPFormInstanceElemBlobFileTyp,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemBlobFileTyp_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemBlobFileTyp_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_elementRow);
         send_integrity_lvl_hashes0U43( ) ;
         GXCCtl = "Z210WWPFormElementId_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z215WWPFormInstanceElementId_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z215WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z220WWPFormInstanceElemDate_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.DToC( Z220WWPFormInstanceElemDate, 0, "/"));
         GXCCtl = "Z227WWPFormInstanceElemDateTime_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z227WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z222WWPFormInstanceElemNumeric_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z222WWPFormInstanceElemNumeric, 18, 5, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z226WWPFormInstanceElemBoolean_" + sGXsfl_47_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z226WWPFormInstanceElemBoolean);
         GXCCtl = "nRcdDeleted_43_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_43_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_43_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vWWPFORMINSTANCEID_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_" + sGXsfl_47_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, A223WWPFormInstanceElemBlob);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filename));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filename));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_47_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_elementContainer.AddRow(Gridlevel_elementRow);
      }

      protected void ReadRow0U43( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4743( ) ;
         edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemChar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemNumeric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlob_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkWWPFormInstanceElemBoolean.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemDateTime_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlobFileNam_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlobFileTyp_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP_"+sGXsfl_47_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_47_idx;
         edtWWPFormInstanceElemBlob_Filetype = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_47_idx;
         edtWWPFormInstanceElemBlob_Filename = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_47_idx;
         edtWWPFormInstanceElemBlob_Filename = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_47_idx;
         edtWWPFormInstanceElemBlob_Filetype = cgiGet( sPrefix+GXCCtl);
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_47_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            wbErr = true;
            A210WWPFormElementId = 0;
         }
         else
         {
            A210WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMENTID_" + sGXsfl_47_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElementId_Internalname;
            wbErr = true;
            A215WWPFormInstanceElementId = 0;
         }
         else
         {
            A215WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A229WWPFormElementTitle = cgiGet( edtWWPFormElementTitle_Internalname);
         cmbWWPFormElementDataType.Name = cmbWWPFormElementDataType_Internalname;
         cmbWWPFormElementDataType.CurrentValue = cgiGet( cmbWWPFormElementDataType_Internalname);
         A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementDataType_Internalname), "."), 18, MidpointRounding.ToEven));
         A221WWPFormInstanceElemChar = cgiGet( edtWWPFormInstanceElemChar_Internalname);
         n221WWPFormInstanceElemChar = false;
         n221WWPFormInstanceElemChar = (String.IsNullOrEmpty(StringUtil.RTrim( A221WWPFormInstanceElemChar)) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtWWPFormInstanceElemDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
         {
            GXCCtl = "WWPFORMINSTANCEELEMDATE_" + sGXsfl_47_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "WWPForm Instance Elem Date", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemDate_Internalname;
            wbErr = true;
            A220WWPFormInstanceElemDate = DateTime.MinValue;
            n220WWPFormInstanceElemDate = false;
         }
         else
         {
            A220WWPFormInstanceElemDate = context.localUtil.CToD( cgiGet( edtWWPFormInstanceElemDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            n220WWPFormInstanceElemDate = false;
         }
         n220WWPFormInstanceElemDate = ((DateTime.MinValue==A220WWPFormInstanceElemDate) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999.99999m ) ) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMNUMERIC_" + sGXsfl_47_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemNumeric_Internalname;
            wbErr = true;
            A222WWPFormInstanceElemNumeric = 0;
            n222WWPFormInstanceElemNumeric = false;
         }
         else
         {
            A222WWPFormInstanceElemNumeric = context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n222WWPFormInstanceElemNumeric = false;
         }
         n222WWPFormInstanceElemNumeric = ((Convert.ToDecimal(0)==A222WWPFormInstanceElemNumeric) ? true : false);
         A223WWPFormInstanceElemBlob = cgiGet( edtWWPFormInstanceElemBlob_Internalname);
         n223WWPFormInstanceElemBlob = false;
         n223WWPFormInstanceElemBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A223WWPFormInstanceElemBlob)) ? true : false);
         A226WWPFormInstanceElemBoolean = StringUtil.StrToBool( cgiGet( chkWWPFormInstanceElemBoolean_Internalname));
         n226WWPFormInstanceElemBoolean = false;
         n226WWPFormInstanceElemBoolean = ((false==A226WWPFormInstanceElemBoolean) ? true : false);
         A213WWPFormElementReferenceId = cgiGet( edtWWPFormElementReferenceId_Internalname);
         A211WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = false;
         if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormInstanceElemDateTime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "WWPFORMINSTANCEELEMDATETIME_" + sGXsfl_47_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "WWPForm Instance Elem Date Time", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemDateTime_Internalname;
            wbErr = true;
            A227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
            n227WWPFormInstanceElemDateTime = false;
         }
         else
         {
            A227WWPFormInstanceElemDateTime = context.localUtil.CToT( cgiGet( edtWWPFormInstanceElemDateTime_Internalname));
            n227WWPFormInstanceElemDateTime = false;
         }
         n227WWPFormInstanceElemDateTime = ((DateTime.MinValue==A227WWPFormInstanceElemDateTime) ? true : false);
         GXCCtl = "Z210WWPFormElementId_" + sGXsfl_47_idx;
         Z210WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z215WWPFormInstanceElementId_" + sGXsfl_47_idx;
         Z215WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z220WWPFormInstanceElemDate_" + sGXsfl_47_idx;
         Z220WWPFormInstanceElemDate = context.localUtil.CToD( cgiGet( sPrefix+GXCCtl), 0);
         n220WWPFormInstanceElemDate = ((DateTime.MinValue==A220WWPFormInstanceElemDate) ? true : false);
         GXCCtl = "Z227WWPFormInstanceElemDateTime_" + sGXsfl_47_idx;
         Z227WWPFormInstanceElemDateTime = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n227WWPFormInstanceElemDateTime = ((DateTime.MinValue==A227WWPFormInstanceElemDateTime) ? true : false);
         GXCCtl = "Z222WWPFormInstanceElemNumeric_" + sGXsfl_47_idx;
         Z222WWPFormInstanceElemNumeric = context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n222WWPFormInstanceElemNumeric = ((Convert.ToDecimal(0)==A222WWPFormInstanceElemNumeric) ? true : false);
         GXCCtl = "Z226WWPFormInstanceElemBoolean_" + sGXsfl_47_idx;
         Z226WWPFormInstanceElemBoolean = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n226WWPFormInstanceElemBoolean = ((false==A226WWPFormInstanceElemBoolean) ? true : false);
         GXCCtl = "nRcdDeleted_43_" + sGXsfl_47_idx;
         nRcdDeleted_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_43_" + sGXsfl_47_idx;
         nRcdExists_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_43_" + sGXsfl_47_idx;
         nIsMod_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( nRcdDeleted_43 == 0 ) && ( nIsMod_43 == 1 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( A223WWPFormInstanceElemBlob)) )
         {
            edtWWPFormInstanceElemBlob_Filename = (string)(CGIGetFileName(edtWWPFormInstanceElemBlob_Internalname));
            edtWWPFormInstanceElemBlob_Filetype = (string)(CGIGetFileType(edtWWPFormInstanceElemBlob_Internalname));
         }
         A224WWPFormInstanceElemBlobFileTyp = edtWWPFormInstanceElemBlob_Filetype;
         A225WWPFormInstanceElemBlobFileNam = edtWWPFormInstanceElemBlob_Filename;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A223WWPFormInstanceElemBlob)) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMBLOB_" + sGXsfl_47_idx;
            GXCCtlgxBlob = GXCCtl + "_gxBlob";
            A223WWPFormInstanceElemBlob = cgiGet( sPrefix+GXCCtlgxBlob);
            n223WWPFormInstanceElemBlob = false;
         }
      }

      protected void assign_properties_default( )
      {
         defedtWWPFormInstanceElementId_Enabled = edtWWPFormInstanceElementId_Enabled;
         defedtWWPFormElementId_Enabled = edtWWPFormElementId_Enabled;
      }

      protected void ConfirmValues0U0( )
      {
         nGXsfl_47_idx = 0;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_4743( ) ;
         while ( nGXsfl_47_idx < nRC_GXsfl_47 )
         {
            nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_4743( ) ;
            ChangePostValue( sPrefix+"Z210WWPFormElementId_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_47_idx) ;
            ChangePostValue( sPrefix+"Z215WWPFormInstanceElementId_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z215WWPFormInstanceElementId_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z215WWPFormInstanceElementId_"+sGXsfl_47_idx) ;
            ChangePostValue( sPrefix+"Z220WWPFormInstanceElemDate_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z220WWPFormInstanceElemDate_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z220WWPFormInstanceElemDate_"+sGXsfl_47_idx) ;
            ChangePostValue( sPrefix+"Z227WWPFormInstanceElemDateTime_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z227WWPFormInstanceElemDateTime_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z227WWPFormInstanceElemDateTime_"+sGXsfl_47_idx) ;
            ChangePostValue( sPrefix+"Z222WWPFormInstanceElemNumeric_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z222WWPFormInstanceElemNumeric_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z222WWPFormInstanceElemNumeric_"+sGXsfl_47_idx) ;
            ChangePostValue( sPrefix+"Z226WWPFormInstanceElemBoolean_"+sGXsfl_47_idx, cgiGet( sPrefix+"ZT_"+"Z226WWPFormInstanceElemBoolean_"+sGXsfl_47_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z226WWPFormInstanceElemBoolean_"+sGXsfl_47_idx) ;
         }
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
            context.SendWebValue( context.GetMessage( "WWPForm Instance", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstance.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPFormInstanceId,6,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_forminstance.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_FormInstance");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_forminstance:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z214WWPFormInstanceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z214WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z239WWPFormInstanceDate", context.localUtil.TToC( Z239WWPFormInstanceDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPFormInstanceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_47_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N112WWPUserExtendedId", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_WWPUSEREXTENDEDID", StringUtil.RTrim( AV16Insert_WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCERECORDKEY", A243WWPFormInstanceRecordKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUME", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVALIDATIONS", A233WWPFormValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDFULLNAME", A113WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA", A236WWPFormElementMetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTCAPTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm0U42( )
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
         return "WorkWithPlus.DynamicForms.WWP_FormInstance" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWPForm Instance", "") ;
      }

      protected void InitializeNonKey0U42( )
      {
         A206WWPFormId = 0;
         AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         A112WWPUserExtendedId = "";
         AssignAttri(sPrefix, false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         A208WWPFormReferenceName = "";
         AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = "";
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         A113WWPUserExtendedFullName = "";
         AssignAttri(sPrefix, false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A216WWPFormResume = 0;
         AssignAttri(sPrefix, false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A233WWPFormValidations = "";
         AssignAttri(sPrefix, false, "A233WWPFormValidations", A233WWPFormValidations);
         A243WWPFormInstanceRecordKey = "";
         n243WWPFormInstanceRecordKey = false;
         AssignAttri(sPrefix, false, "A243WWPFormInstanceRecordKey", A243WWPFormInstanceRecordKey);
         A239WWPFormInstanceDate = DateTimeUtil.Now( context);
         AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0U42( )
      {
         A214WWPFormInstanceId = 0;
         AssignAttri(sPrefix, false, "A214WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A214WWPFormInstanceId), 6, 0));
         InitializeNonKey0U42( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A239WWPFormInstanceDate = i239WWPFormInstanceDate;
         AssignAttri(sPrefix, false, "A239WWPFormInstanceDate", context.localUtil.TToC( A239WWPFormInstanceDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected void InitializeNonKey0U43( )
      {
         A229WWPFormElementTitle = "";
         A213WWPFormElementReferenceId = "";
         A218WWPFormElementDataType = 0;
         A211WWPFormElementParentId = 0;
         n211WWPFormElementParentId = false;
         A230WWPFormElementParentType = 0;
         AssignAttri(sPrefix, false, "A230WWPFormElementParentType", StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         A217WWPFormElementType = 0;
         AssignAttri(sPrefix, false, "A217WWPFormElementType", StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0));
         A236WWPFormElementMetadata = "";
         AssignAttri(sPrefix, false, "A236WWPFormElementMetadata", A236WWPFormElementMetadata);
         A237WWPFormElementCaption = 0;
         AssignAttri(sPrefix, false, "A237WWPFormElementCaption", StringUtil.Str( (decimal)(A237WWPFormElementCaption), 1, 0));
         A221WWPFormInstanceElemChar = "";
         n221WWPFormInstanceElemChar = false;
         A220WWPFormInstanceElemDate = DateTime.MinValue;
         n220WWPFormInstanceElemDate = false;
         A227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         n227WWPFormInstanceElemDateTime = false;
         A222WWPFormInstanceElemNumeric = 0;
         n222WWPFormInstanceElemNumeric = false;
         A223WWPFormInstanceElemBlob = "";
         n223WWPFormInstanceElemBlob = false;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A223WWPFormInstanceElemBlob), !bGXsfl_47_Refreshing);
         A226WWPFormInstanceElemBoolean = false;
         n226WWPFormInstanceElemBoolean = false;
         A224WWPFormInstanceElemBlobFileTyp = "";
         A225WWPFormInstanceElemBlobFileNam = "";
         Z220WWPFormInstanceElemDate = DateTime.MinValue;
         Z227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z222WWPFormInstanceElemNumeric = 0;
         Z226WWPFormInstanceElemBoolean = false;
      }

      protected void InitAll0U43( )
      {
         A210WWPFormElementId = 0;
         A215WWPFormInstanceElementId = 0;
         InitializeNonKey0U43( ) ;
      }

      protected void StandaloneModalInsert0U43( )
      {
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
         sCtrlAV7WWPFormInstanceId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_forminstance", GetJustCreated( ));
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
            AV7WWPFormInstanceId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormInstanceId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7WWPFormInstanceId != wcpOAV7WWPFormInstanceId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7WWPFormInstanceId = AV7WWPFormInstanceId;
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
         sCtrlAV7WWPFormInstanceId = cgiGet( sPrefix+"AV7WWPFormInstanceId_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPFormInstanceId) > 0 )
         {
            AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPFormInstanceId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
         }
         else
         {
            AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPFormInstanceId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormInstanceId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPFormInstanceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormInstanceId_CTRL", StringUtil.RTrim( sCtrlAV7WWPFormInstanceId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614524555", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_forminstance.js", "?2025614524556", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties43( )
      {
         edtWWPFormInstanceElementId_Enabled = defedtWWPFormInstanceElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormElementId_Enabled = defedtWWPFormElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_47_Refreshing);
      }

      protected void StartGridControl47( )
      {
         Gridlevel_elementContainer.AddObjectProperty("GridName", "Gridlevel_element");
         Gridlevel_elementContainer.AddObjectProperty("Header", subGridlevel_element_Header);
         Gridlevel_elementContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_elementContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridlevel_elementContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A215WWPFormInstanceElementId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A229WWPFormElementTitle));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A221WWPFormInstanceElemChar));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A220WWPFormInstanceElemDate, "99/99/99")));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A222WWPFormInstanceElemNumeric, 21, 5, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A223WWPFormInstanceElemBlob));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A226WWPFormInstanceElemBoolean)));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A213WWPFormElementReferenceId));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A227WWPFormInstanceElemDateTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A225WWPFormInstanceElemBlobFileNam));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileNam_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A224WWPFormInstanceElemBlobFileTyp));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileTyp_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectedindex), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowselection), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowhovering), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtWWPFormInstanceId_Internalname = sPrefix+"WWPFORMINSTANCEID";
         edtWWPFormInstanceDate_Internalname = sPrefix+"WWPFORMINSTANCEDATE";
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID";
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER";
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID";
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID";
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE";
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE";
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR";
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE";
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC";
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB";
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN";
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID";
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID";
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME";
         edtWWPFormInstanceElemBlobFileNam_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAM";
         edtWWPFormInstanceElemBlobFileTyp_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYP";
         divTableleaflevel_element_Internalname = sPrefix+"TABLELEAFLEVEL_ELEMENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridlevel_element_Internalname = sPrefix+"GRIDLEVEL_ELEMENT";
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
         subGridlevel_element_Allowcollapsing = 0;
         subGridlevel_element_Allowselection = 0;
         subGridlevel_element_Header = "";
         edtWWPFormInstanceElemBlobFileTyp_Jsonclick = "";
         edtWWPFormInstanceElemBlobFileNam_Jsonclick = "";
         edtWWPFormInstanceElemDateTime_Jsonclick = "";
         edtWWPFormElementParentId_Jsonclick = "";
         edtWWPFormElementReferenceId_Jsonclick = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         edtWWPFormInstanceElemBlob_Jsonclick = "";
         edtWWPFormInstanceElemBlob_Parameters = "";
         edtWWPFormInstanceElemBlob_Contenttype = "";
         edtWWPFormInstanceElemNumeric_Jsonclick = "";
         edtWWPFormInstanceElemDate_Jsonclick = "";
         edtWWPFormInstanceElemChar_Jsonclick = "";
         cmbWWPFormElementDataType_Jsonclick = "";
         edtWWPFormElementTitle_Jsonclick = "";
         edtWWPFormInstanceElementId_Jsonclick = "";
         edtWWPFormElementId_Jsonclick = "";
         subGridlevel_element_Class = "WorkWith";
         subGridlevel_element_Backcolorstyle = 0;
         edtWWPFormInstanceElemBlob_Filename = "";
         edtWWPFormInstanceElemBlob_Filetype = "";
         edtWWPFormInstanceElemBlobFileTyp_Enabled = 1;
         edtWWPFormInstanceElemBlobFileNam_Enabled = 1;
         edtWWPFormInstanceElemDateTime_Enabled = 1;
         edtWWPFormElementParentId_Enabled = 0;
         edtWWPFormElementReferenceId_Enabled = 0;
         chkWWPFormInstanceElemBoolean.Enabled = 1;
         edtWWPFormInstanceElemBlob_Enabled = 1;
         edtWWPFormInstanceElemNumeric_Enabled = 1;
         edtWWPFormInstanceElemDate_Enabled = 1;
         edtWWPFormInstanceElemChar_Enabled = 1;
         cmbWWPFormElementDataType.Enabled = 0;
         edtWWPFormElementTitle_Enabled = 0;
         edtWWPFormInstanceElementId_Enabled = 1;
         edtWWPFormElementId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
         edtWWPFormInstanceDate_Jsonclick = "";
         edtWWPFormInstanceDate_Enabled = 1;
         edtWWPFormInstanceId_Jsonclick = "";
         edtWWPFormInstanceId_Enabled = 0;
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

      protected void gxnrGridlevel_element_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_4743( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0U43( ) ;
            standaloneModal0U43( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0U43( ) ;
            nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_4743( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_elementContainer)) ;
         /* End function gxnrGridlevel_element_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_47_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", context.GetMessage( "WWP_DF_DataType_Boolean", ""), 0);
         cmbWWPFormElementDataType.addItem("2", context.GetMessage( "WWP_DF_DataType_Character", ""), 0);
         cmbWWPFormElementDataType.addItem("3", context.GetMessage( "WWP_DF_DataType_Numeric", ""), 0);
         cmbWWPFormElementDataType.addItem("4", context.GetMessage( "WWP_DF_DataType_Date", ""), 0);
         cmbWWPFormElementDataType.addItem("5", context.GetMessage( "WWP_DF_DataType_Datetime", ""), 0);
         cmbWWPFormElementDataType.addItem("6", context.GetMessage( "WWP_DF_DataType_Password", ""), 0);
         cmbWWPFormElementDataType.addItem("7", context.GetMessage( "WWP_DF_DataType_Email", ""), 0);
         cmbWWPFormElementDataType.addItem("8", context.GetMessage( "WWP_DF_DataType_Url", ""), 0);
         cmbWWPFormElementDataType.addItem("9", context.GetMessage( "WWP_DF_DataType_File", ""), 0);
         cmbWWPFormElementDataType.addItem("10", context.GetMessage( "WWP_DF_DataType_Image", ""), 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
         }
         GXCCtl = "WWPFORMINSTANCEELEMBOOLEAN_" + sGXsfl_47_idx;
         chkWWPFormInstanceElemBoolean.Name = GXCCtl;
         chkWWPFormInstanceElemBoolean.WebTags = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "TitleCaption", chkWWPFormInstanceElemBoolean.Caption, !bGXsfl_47_Refreshing);
         chkWWPFormInstanceElemBoolean.CheckedValue = "false";
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

      public void Valid_Wwpformversionnumber( )
      {
         /* Using cursor T000U20 */
         pr_default.execute(18, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
         }
         A208WWPFormReferenceName = T000U20_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T000U20_A209WWPFormTitle[0];
         A216WWPFormResume = T000U20_A216WWPFormResume[0];
         A233WWPFormValidations = T000U20_A233WWPFormValidations[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri(sPrefix, false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A233WWPFormValidations", A233WWPFormValidations);
      }

      public void Valid_Wwpformelementid( )
      {
         n211WWPFormElementParentId = false;
         A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A218WWPFormElementDataType), 2, 0);
         /* Using cursor T000U31 */
         pr_default.execute(29, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Element", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
         }
         A229WWPFormElementTitle = T000U31_A229WWPFormElementTitle[0];
         A213WWPFormElementReferenceId = T000U31_A213WWPFormElementReferenceId[0];
         A218WWPFormElementDataType = T000U31_A218WWPFormElementDataType[0];
         cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A218WWPFormElementDataType), 2, 0);
         A217WWPFormElementType = T000U31_A217WWPFormElementType[0];
         A236WWPFormElementMetadata = T000U31_A236WWPFormElementMetadata[0];
         A237WWPFormElementCaption = T000U31_A237WWPFormElementCaption[0];
         A211WWPFormElementParentId = T000U31_A211WWPFormElementParentId[0];
         n211WWPFormElementParentId = T000U31_n211WWPFormElementParentId[0];
         pr_default.close(29);
         /* Using cursor T000U32 */
         pr_default.execute(30, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
            }
         }
         A230WWPFormElementParentType = T000U32_A230WWPFormElementParentType[0];
         pr_default.close(30);
         dynload_actions( ) ;
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
            A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A218WWPFormElementDataType), 2, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A229WWPFormElementTitle", A229WWPFormElementTitle);
         AssignAttri(sPrefix, false, "A213WWPFormElementReferenceId", A213WWPFormElementReferenceId);
         AssignAttri(sPrefix, false, "A218WWPFormElementDataType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", "")));
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", cmbWWPFormElementDataType.ToJavascriptSource(), true);
         AssignAttri(sPrefix, false, "A217WWPFormElementType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A236WWPFormElementMetadata", A236WWPFormElementMetadata);
         AssignAttri(sPrefix, false, "A237WWPFormElementCaption", StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A211WWPFormElementParentId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, ".", "")));
         AssignAttri(sPrefix, false, "A230WWPFormElementParentType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"componentprocess","iparms":[{"postForm":true},{"sPrefix":true},{"sSFPrefix":true},{"sCompEvt":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV7WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120U2","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMINSTANCEID","""{"handler":"Valid_Wwpforminstanceid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTID","""{"handler":"Valid_Wwpformelementid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A213WWPFormElementReferenceId","fld":"WWPFORMELEMENTREFERENCEID"},{"av":"cmbWWPFormElementDataType"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"A237WWPFormElementCaption","fld":"WWPFORMELEMENTCAPTION","pic":"9"},{"av":"A230WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTID",""","oparms":[{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A213WWPFormElementReferenceId","fld":"WWPFORMELEMENTREFERENCEID"},{"av":"cmbWWPFormElementDataType"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"A237WWPFormElementCaption","fld":"WWPFORMELEMENTCAPTION","pic":"9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A230WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9"}]}""");
         setEventMetadata("VALID_WWPFORMINSTANCEELEMENTID","""{"handler":"Valid_Wwpforminstanceelementid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID","""{"handler":"Valid_Wwpformelementparentid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Wwpforminstanceelemblobfiletyp","iparms":[]}""");
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
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(5);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         Z112WWPUserExtendedId = "";
         N112WWPUserExtendedId = "";
         Z220WWPFormInstanceElemDate = DateTime.MinValue;
         Z227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A112WWPUserExtendedId = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         A209WWPFormTitle = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_elementContainer = new GXWebGrid( context);
         sMode43 = "";
         sStyleString = "";
         AV16Insert_WWPUserExtendedId = "";
         A243WWPFormInstanceRecordKey = "";
         A208WWPFormReferenceName = "";
         A233WWPFormValidations = "";
         A113WWPUserExtendedFullName = "";
         AV21Pgmname = "";
         A236WWPFormElementMetadata = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode42 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A229WWPFormElementTitle = "";
         A221WWPFormInstanceElemChar = "";
         A220WWPFormInstanceElemDate = DateTime.MinValue;
         A223WWPFormInstanceElemBlob = "";
         A213WWPFormElementReferenceId = "";
         A227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         A225WWPFormInstanceElemBlobFileNam = "";
         A224WWPFormInstanceElemBlobFileTyp = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z243WWPFormInstanceRecordKey = "";
         Z113WWPUserExtendedFullName = "";
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z233WWPFormValidations = "";
         T000U9_A113WWPUserExtendedFullName = new string[] {""} ;
         T000U8_A208WWPFormReferenceName = new string[] {""} ;
         T000U8_A209WWPFormTitle = new string[] {""} ;
         T000U8_A216WWPFormResume = new short[1] ;
         T000U8_A233WWPFormValidations = new string[] {""} ;
         T000U10_A214WWPFormInstanceId = new int[1] ;
         T000U10_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000U10_A208WWPFormReferenceName = new string[] {""} ;
         T000U10_A209WWPFormTitle = new string[] {""} ;
         T000U10_A113WWPUserExtendedFullName = new string[] {""} ;
         T000U10_A216WWPFormResume = new short[1] ;
         T000U10_A233WWPFormValidations = new string[] {""} ;
         T000U10_A243WWPFormInstanceRecordKey = new string[] {""} ;
         T000U10_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         T000U10_A206WWPFormId = new short[1] ;
         T000U10_A207WWPFormVersionNumber = new short[1] ;
         T000U10_A112WWPUserExtendedId = new string[] {""} ;
         T000U11_A208WWPFormReferenceName = new string[] {""} ;
         T000U11_A209WWPFormTitle = new string[] {""} ;
         T000U11_A216WWPFormResume = new short[1] ;
         T000U11_A233WWPFormValidations = new string[] {""} ;
         T000U12_A113WWPUserExtendedFullName = new string[] {""} ;
         T000U13_A214WWPFormInstanceId = new int[1] ;
         T000U7_A214WWPFormInstanceId = new int[1] ;
         T000U7_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000U7_A243WWPFormInstanceRecordKey = new string[] {""} ;
         T000U7_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         T000U7_A206WWPFormId = new short[1] ;
         T000U7_A207WWPFormVersionNumber = new short[1] ;
         T000U7_A112WWPUserExtendedId = new string[] {""} ;
         T000U14_A214WWPFormInstanceId = new int[1] ;
         T000U15_A214WWPFormInstanceId = new int[1] ;
         T000U6_A214WWPFormInstanceId = new int[1] ;
         T000U6_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000U6_A243WWPFormInstanceRecordKey = new string[] {""} ;
         T000U6_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         T000U6_A206WWPFormId = new short[1] ;
         T000U6_A207WWPFormVersionNumber = new short[1] ;
         T000U6_A112WWPUserExtendedId = new string[] {""} ;
         T000U17_A214WWPFormInstanceId = new int[1] ;
         T000U20_A208WWPFormReferenceName = new string[] {""} ;
         T000U20_A209WWPFormTitle = new string[] {""} ;
         T000U20_A216WWPFormResume = new short[1] ;
         T000U20_A233WWPFormValidations = new string[] {""} ;
         T000U21_A113WWPUserExtendedFullName = new string[] {""} ;
         T000U22_A214WWPFormInstanceId = new int[1] ;
         Z221WWPFormInstanceElemChar = "";
         Z223WWPFormInstanceElemBlob = "";
         Z224WWPFormInstanceElemBlobFileTyp = "";
         Z225WWPFormInstanceElemBlobFileNam = "";
         Z229WWPFormElementTitle = "";
         Z213WWPFormElementReferenceId = "";
         Z236WWPFormElementMetadata = "";
         T000U23_A206WWPFormId = new short[1] ;
         T000U23_A207WWPFormVersionNumber = new short[1] ;
         T000U23_A214WWPFormInstanceId = new int[1] ;
         T000U23_A215WWPFormInstanceElementId = new short[1] ;
         T000U23_A229WWPFormElementTitle = new string[] {""} ;
         T000U23_A213WWPFormElementReferenceId = new string[] {""} ;
         T000U23_A218WWPFormElementDataType = new short[1] ;
         T000U23_A230WWPFormElementParentType = new short[1] ;
         T000U23_A217WWPFormElementType = new short[1] ;
         T000U23_A236WWPFormElementMetadata = new string[] {""} ;
         T000U23_A237WWPFormElementCaption = new short[1] ;
         T000U23_A221WWPFormInstanceElemChar = new string[] {""} ;
         T000U23_n221WWPFormInstanceElemChar = new bool[] {false} ;
         T000U23_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000U23_n220WWPFormInstanceElemDate = new bool[] {false} ;
         T000U23_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000U23_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000U23_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         T000U23_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000U23_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U23_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U23_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         T000U23_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         T000U23_A210WWPFormElementId = new short[1] ;
         T000U23_A211WWPFormElementParentId = new short[1] ;
         T000U23_n211WWPFormElementParentId = new bool[] {false} ;
         T000U23_A223WWPFormInstanceElemBlob = new string[] {""} ;
         T000U23_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         T000U4_A206WWPFormId = new short[1] ;
         T000U4_A207WWPFormVersionNumber = new short[1] ;
         T000U4_A229WWPFormElementTitle = new string[] {""} ;
         T000U4_A213WWPFormElementReferenceId = new string[] {""} ;
         T000U4_A218WWPFormElementDataType = new short[1] ;
         T000U4_A217WWPFormElementType = new short[1] ;
         T000U4_A236WWPFormElementMetadata = new string[] {""} ;
         T000U4_A237WWPFormElementCaption = new short[1] ;
         T000U4_A211WWPFormElementParentId = new short[1] ;
         T000U4_n211WWPFormElementParentId = new bool[] {false} ;
         T000U5_A230WWPFormElementParentType = new short[1] ;
         T000U24_A206WWPFormId = new short[1] ;
         T000U24_A207WWPFormVersionNumber = new short[1] ;
         T000U24_A229WWPFormElementTitle = new string[] {""} ;
         T000U24_A213WWPFormElementReferenceId = new string[] {""} ;
         T000U24_A218WWPFormElementDataType = new short[1] ;
         T000U24_A217WWPFormElementType = new short[1] ;
         T000U24_A236WWPFormElementMetadata = new string[] {""} ;
         T000U24_A237WWPFormElementCaption = new short[1] ;
         T000U24_A211WWPFormElementParentId = new short[1] ;
         T000U24_n211WWPFormElementParentId = new bool[] {false} ;
         T000U25_A230WWPFormElementParentType = new short[1] ;
         T000U26_A214WWPFormInstanceId = new int[1] ;
         T000U26_A210WWPFormElementId = new short[1] ;
         T000U26_A215WWPFormInstanceElementId = new short[1] ;
         T000U3_A214WWPFormInstanceId = new int[1] ;
         T000U3_A215WWPFormInstanceElementId = new short[1] ;
         T000U3_A221WWPFormInstanceElemChar = new string[] {""} ;
         T000U3_n221WWPFormInstanceElemChar = new bool[] {false} ;
         T000U3_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000U3_n220WWPFormInstanceElemDate = new bool[] {false} ;
         T000U3_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000U3_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000U3_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         T000U3_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000U3_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U3_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U3_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         T000U3_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         T000U3_A210WWPFormElementId = new short[1] ;
         T000U3_A223WWPFormInstanceElemBlob = new string[] {""} ;
         T000U3_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         T000U2_A214WWPFormInstanceId = new int[1] ;
         T000U2_A215WWPFormInstanceElementId = new short[1] ;
         T000U2_A221WWPFormInstanceElemChar = new string[] {""} ;
         T000U2_n221WWPFormInstanceElemChar = new bool[] {false} ;
         T000U2_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000U2_n220WWPFormInstanceElemDate = new bool[] {false} ;
         T000U2_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000U2_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000U2_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         T000U2_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000U2_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U2_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000U2_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         T000U2_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         T000U2_A210WWPFormElementId = new short[1] ;
         T000U2_A223WWPFormInstanceElemBlob = new string[] {""} ;
         T000U2_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         T000U31_A229WWPFormElementTitle = new string[] {""} ;
         T000U31_A213WWPFormElementReferenceId = new string[] {""} ;
         T000U31_A218WWPFormElementDataType = new short[1] ;
         T000U31_A217WWPFormElementType = new short[1] ;
         T000U31_A236WWPFormElementMetadata = new string[] {""} ;
         T000U31_A237WWPFormElementCaption = new short[1] ;
         T000U31_A211WWPFormElementParentId = new short[1] ;
         T000U31_n211WWPFormElementParentId = new bool[] {false} ;
         T000U32_A230WWPFormElementParentType = new short[1] ;
         T000U33_A214WWPFormInstanceId = new int[1] ;
         T000U33_A210WWPFormElementId = new short[1] ;
         T000U33_A215WWPFormInstanceElementId = new short[1] ;
         Gridlevel_elementRow = new GXWebRow();
         subGridlevel_element_Linesclass = "";
         ROClassString = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         sCtrlGx_mode = "";
         sCtrlAV7WWPFormInstanceId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Gridlevel_elementColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance__default(),
            new Object[][] {
                new Object[] {
               T000U2_A214WWPFormInstanceId, T000U2_A215WWPFormInstanceElementId, T000U2_A221WWPFormInstanceElemChar, T000U2_n221WWPFormInstanceElemChar, T000U2_A220WWPFormInstanceElemDate, T000U2_n220WWPFormInstanceElemDate, T000U2_A227WWPFormInstanceElemDateTime, T000U2_n227WWPFormInstanceElemDateTime, T000U2_A222WWPFormInstanceElemNumeric, T000U2_n222WWPFormInstanceElemNumeric,
               T000U2_A226WWPFormInstanceElemBoolean, T000U2_n226WWPFormInstanceElemBoolean, T000U2_A224WWPFormInstanceElemBlobFileTyp, T000U2_A225WWPFormInstanceElemBlobFileNam, T000U2_A210WWPFormElementId, T000U2_A223WWPFormInstanceElemBlob, T000U2_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000U3_A214WWPFormInstanceId, T000U3_A215WWPFormInstanceElementId, T000U3_A221WWPFormInstanceElemChar, T000U3_n221WWPFormInstanceElemChar, T000U3_A220WWPFormInstanceElemDate, T000U3_n220WWPFormInstanceElemDate, T000U3_A227WWPFormInstanceElemDateTime, T000U3_n227WWPFormInstanceElemDateTime, T000U3_A222WWPFormInstanceElemNumeric, T000U3_n222WWPFormInstanceElemNumeric,
               T000U3_A226WWPFormInstanceElemBoolean, T000U3_n226WWPFormInstanceElemBoolean, T000U3_A224WWPFormInstanceElemBlobFileTyp, T000U3_A225WWPFormInstanceElemBlobFileNam, T000U3_A210WWPFormElementId, T000U3_A223WWPFormInstanceElemBlob, T000U3_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000U4_A206WWPFormId, T000U4_A207WWPFormVersionNumber, T000U4_A229WWPFormElementTitle, T000U4_A213WWPFormElementReferenceId, T000U4_A218WWPFormElementDataType, T000U4_A217WWPFormElementType, T000U4_A236WWPFormElementMetadata, T000U4_A237WWPFormElementCaption, T000U4_A211WWPFormElementParentId, T000U4_n211WWPFormElementParentId
               }
               , new Object[] {
               T000U5_A230WWPFormElementParentType
               }
               , new Object[] {
               T000U6_A214WWPFormInstanceId, T000U6_A239WWPFormInstanceDate, T000U6_A243WWPFormInstanceRecordKey, T000U6_n243WWPFormInstanceRecordKey, T000U6_A206WWPFormId, T000U6_A207WWPFormVersionNumber, T000U6_A112WWPUserExtendedId
               }
               , new Object[] {
               T000U7_A214WWPFormInstanceId, T000U7_A239WWPFormInstanceDate, T000U7_A243WWPFormInstanceRecordKey, T000U7_n243WWPFormInstanceRecordKey, T000U7_A206WWPFormId, T000U7_A207WWPFormVersionNumber, T000U7_A112WWPUserExtendedId
               }
               , new Object[] {
               T000U8_A208WWPFormReferenceName, T000U8_A209WWPFormTitle, T000U8_A216WWPFormResume, T000U8_A233WWPFormValidations
               }
               , new Object[] {
               T000U9_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000U10_A214WWPFormInstanceId, T000U10_A239WWPFormInstanceDate, T000U10_A208WWPFormReferenceName, T000U10_A209WWPFormTitle, T000U10_A113WWPUserExtendedFullName, T000U10_A216WWPFormResume, T000U10_A233WWPFormValidations, T000U10_A243WWPFormInstanceRecordKey, T000U10_n243WWPFormInstanceRecordKey, T000U10_A206WWPFormId,
               T000U10_A207WWPFormVersionNumber, T000U10_A112WWPUserExtendedId
               }
               , new Object[] {
               T000U11_A208WWPFormReferenceName, T000U11_A209WWPFormTitle, T000U11_A216WWPFormResume, T000U11_A233WWPFormValidations
               }
               , new Object[] {
               T000U12_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000U13_A214WWPFormInstanceId
               }
               , new Object[] {
               T000U14_A214WWPFormInstanceId
               }
               , new Object[] {
               T000U15_A214WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               T000U17_A214WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U20_A208WWPFormReferenceName, T000U20_A209WWPFormTitle, T000U20_A216WWPFormResume, T000U20_A233WWPFormValidations
               }
               , new Object[] {
               T000U21_A113WWPUserExtendedFullName
               }
               , new Object[] {
               T000U22_A214WWPFormInstanceId
               }
               , new Object[] {
               T000U23_A206WWPFormId, T000U23_A207WWPFormVersionNumber, T000U23_A214WWPFormInstanceId, T000U23_A215WWPFormInstanceElementId, T000U23_A229WWPFormElementTitle, T000U23_A213WWPFormElementReferenceId, T000U23_A218WWPFormElementDataType, T000U23_A230WWPFormElementParentType, T000U23_A217WWPFormElementType, T000U23_A236WWPFormElementMetadata,
               T000U23_A237WWPFormElementCaption, T000U23_A221WWPFormInstanceElemChar, T000U23_n221WWPFormInstanceElemChar, T000U23_A220WWPFormInstanceElemDate, T000U23_n220WWPFormInstanceElemDate, T000U23_A227WWPFormInstanceElemDateTime, T000U23_n227WWPFormInstanceElemDateTime, T000U23_A222WWPFormInstanceElemNumeric, T000U23_n222WWPFormInstanceElemNumeric, T000U23_A226WWPFormInstanceElemBoolean,
               T000U23_n226WWPFormInstanceElemBoolean, T000U23_A224WWPFormInstanceElemBlobFileTyp, T000U23_A225WWPFormInstanceElemBlobFileNam, T000U23_A210WWPFormElementId, T000U23_A211WWPFormElementParentId, T000U23_n211WWPFormElementParentId, T000U23_A223WWPFormInstanceElemBlob, T000U23_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000U24_A206WWPFormId, T000U24_A207WWPFormVersionNumber, T000U24_A229WWPFormElementTitle, T000U24_A213WWPFormElementReferenceId, T000U24_A218WWPFormElementDataType, T000U24_A217WWPFormElementType, T000U24_A236WWPFormElementMetadata, T000U24_A237WWPFormElementCaption, T000U24_A211WWPFormElementParentId, T000U24_n211WWPFormElementParentId
               }
               , new Object[] {
               T000U25_A230WWPFormElementParentType
               }
               , new Object[] {
               T000U26_A214WWPFormInstanceId, T000U26_A210WWPFormElementId, T000U26_A215WWPFormInstanceElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U31_A229WWPFormElementTitle, T000U31_A213WWPFormElementReferenceId, T000U31_A218WWPFormElementDataType, T000U31_A217WWPFormElementType, T000U31_A236WWPFormElementMetadata, T000U31_A237WWPFormElementCaption, T000U31_A211WWPFormElementParentId, T000U31_n211WWPFormElementParentId
               }
               , new Object[] {
               T000U32_A230WWPFormElementParentType
               }
               , new Object[] {
               T000U33_A214WWPFormInstanceId, T000U33_A210WWPFormElementId, T000U33_A215WWPFormInstanceElementId
               }
            }
         );
         AV21Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance";
         Z239WWPFormInstanceDate = DateTimeUtil.Now( context);
         A239WWPFormInstanceDate = DateTimeUtil.Now( context);
         i239WWPFormInstanceDate = DateTimeUtil.Now( context);
      }

      private short Z206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short N206WWPFormId ;
      private short N207WWPFormVersionNumber ;
      private short Z210WWPFormElementId ;
      private short Z215WWPFormInstanceElementId ;
      private short nRcdDeleted_43 ;
      private short nRcdExists_43 ;
      private short nIsMod_43 ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A210WWPFormElementId ;
      private short A211WWPFormElementParentId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount43 ;
      private short RcdFound43 ;
      private short nBlankRcdUsr43 ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV11Insert_WWPFormId ;
      private short AV12Insert_WWPFormVersionNumber ;
      private short Gx_BScreen ;
      private short A216WWPFormResume ;
      private short A217WWPFormElementType ;
      private short A237WWPFormElementCaption ;
      private short A230WWPFormElementParentType ;
      private short RcdFound42 ;
      private short A215WWPFormInstanceElementId ;
      private short A218WWPFormElementDataType ;
      private short Z216WWPFormResume ;
      private short Z218WWPFormElementDataType ;
      private short Z217WWPFormElementType ;
      private short Z237WWPFormElementCaption ;
      private short Z211WWPFormElementParentId ;
      private short Z230WWPFormElementParentType ;
      private short nIsDirty_43 ;
      private short subGridlevel_element_Backcolorstyle ;
      private short subGridlevel_element_Backstyle ;
      private short subGridlevel_element_Allowselection ;
      private short subGridlevel_element_Allowhovering ;
      private short subGridlevel_element_Allowcollapsing ;
      private short subGridlevel_element_Collapsed ;
      private int wcpOAV7WWPFormInstanceId ;
      private int Z214WWPFormInstanceId ;
      private int nRC_GXsfl_47 ;
      private int nGXsfl_47_idx=1 ;
      private int AV7WWPFormInstanceId ;
      private int trnEnded ;
      private int A214WWPFormInstanceId ;
      private int edtWWPFormInstanceId_Enabled ;
      private int edtWWPFormInstanceDate_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtWWPFormElementId_Enabled ;
      private int edtWWPFormInstanceElementId_Enabled ;
      private int edtWWPFormElementTitle_Enabled ;
      private int edtWWPFormInstanceElemChar_Enabled ;
      private int edtWWPFormInstanceElemDate_Enabled ;
      private int edtWWPFormInstanceElemNumeric_Enabled ;
      private int edtWWPFormInstanceElemBlob_Enabled ;
      private int edtWWPFormElementReferenceId_Enabled ;
      private int edtWWPFormElementParentId_Enabled ;
      private int edtWWPFormInstanceElemDateTime_Enabled ;
      private int edtWWPFormInstanceElemBlobFileNam_Enabled ;
      private int edtWWPFormInstanceElemBlobFileTyp_Enabled ;
      private int fRowAdded ;
      private int AV22GXV1 ;
      private int subGridlevel_element_Backcolor ;
      private int subGridlevel_element_Allbackcolor ;
      private int defedtWWPFormInstanceElementId_Enabled ;
      private int defedtWWPFormElementId_Enabled ;
      private int idxLst ;
      private int subGridlevel_element_Selectedindex ;
      private int subGridlevel_element_Selectioncolor ;
      private int subGridlevel_element_Hoveringcolor ;
      private long GRIDLEVEL_ELEMENT_nFirstRecordOnPage ;
      private decimal Z222WWPFormInstanceElemNumeric ;
      private decimal A222WWPFormInstanceElemNumeric ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z112WWPUserExtendedId ;
      private string N112WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string A112WWPUserExtendedId ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtWWPFormInstanceDate_Internalname ;
      private string sGXsfl_47_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtWWPFormInstanceId_Internalname ;
      private string TempTags ;
      private string edtWWPFormInstanceId_Jsonclick ;
      private string edtWWPFormInstanceDate_Jsonclick ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string divTableleaflevel_element_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode43 ;
      private string edtWWPFormElementId_Internalname ;
      private string edtWWPFormInstanceElementId_Internalname ;
      private string edtWWPFormElementTitle_Internalname ;
      private string cmbWWPFormElementDataType_Internalname ;
      private string edtWWPFormInstanceElemChar_Internalname ;
      private string edtWWPFormInstanceElemDate_Internalname ;
      private string edtWWPFormInstanceElemNumeric_Internalname ;
      private string edtWWPFormInstanceElemBlob_Internalname ;
      private string chkWWPFormInstanceElemBoolean_Internalname ;
      private string edtWWPFormElementReferenceId_Internalname ;
      private string edtWWPFormElementParentId_Internalname ;
      private string edtWWPFormInstanceElemDateTime_Internalname ;
      private string edtWWPFormInstanceElemBlobFileNam_Internalname ;
      private string edtWWPFormInstanceElemBlobFileTyp_Internalname ;
      private string sStyleString ;
      private string subGridlevel_element_Internalname ;
      private string AV16Insert_WWPUserExtendedId ;
      private string AV21Pgmname ;
      private string hsh ;
      private string sMode42 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string edtWWPFormInstanceElemBlob_Filetype ;
      private string edtWWPFormInstanceElemBlob_Filename ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string subGridlevel_element_Class ;
      private string subGridlevel_element_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormElementId_Jsonclick ;
      private string edtWWPFormInstanceElementId_Jsonclick ;
      private string edtWWPFormElementTitle_Jsonclick ;
      private string cmbWWPFormElementDataType_Jsonclick ;
      private string edtWWPFormInstanceElemChar_Jsonclick ;
      private string edtWWPFormInstanceElemDate_Jsonclick ;
      private string edtWWPFormInstanceElemNumeric_Jsonclick ;
      private string edtWWPFormInstanceElemBlob_Contenttype ;
      private string edtWWPFormInstanceElemBlob_Parameters ;
      private string edtWWPFormInstanceElemBlob_Jsonclick ;
      private string edtWWPFormElementReferenceId_Jsonclick ;
      private string edtWWPFormElementParentId_Jsonclick ;
      private string edtWWPFormInstanceElemDateTime_Jsonclick ;
      private string edtWWPFormInstanceElemBlobFileNam_Jsonclick ;
      private string edtWWPFormInstanceElemBlobFileTyp_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7WWPFormInstanceId ;
      private string subGridlevel_element_Header ;
      private DateTime Z239WWPFormInstanceDate ;
      private DateTime Z227WWPFormInstanceElemDateTime ;
      private DateTime A239WWPFormInstanceDate ;
      private DateTime A227WWPFormInstanceElemDateTime ;
      private DateTime i239WWPFormInstanceDate ;
      private DateTime Z220WWPFormInstanceElemDate ;
      private DateTime A220WWPFormInstanceElemDate ;
      private bool Z226WWPFormInstanceElemBoolean ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n211WWPFormElementParentId ;
      private bool wbErr ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool n243WWPFormInstanceRecordKey ;
      private bool A226WWPFormInstanceElemBoolean ;
      private bool returnInSub ;
      private bool n221WWPFormInstanceElemChar ;
      private bool n220WWPFormInstanceElemDate ;
      private bool n227WWPFormInstanceElemDateTime ;
      private bool n222WWPFormInstanceElemNumeric ;
      private bool n226WWPFormInstanceElemBoolean ;
      private bool n223WWPFormInstanceElemBlob ;
      private string A243WWPFormInstanceRecordKey ;
      private string A233WWPFormValidations ;
      private string A236WWPFormElementMetadata ;
      private string A229WWPFormElementTitle ;
      private string A221WWPFormInstanceElemChar ;
      private string Z243WWPFormInstanceRecordKey ;
      private string Z233WWPFormValidations ;
      private string Z221WWPFormInstanceElemChar ;
      private string Z229WWPFormElementTitle ;
      private string Z236WWPFormElementMetadata ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string A113WWPUserExtendedFullName ;
      private string A213WWPFormElementReferenceId ;
      private string A225WWPFormInstanceElemBlobFileNam ;
      private string A224WWPFormInstanceElemBlobFileTyp ;
      private string Z113WWPUserExtendedFullName ;
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z224WWPFormInstanceElemBlobFileTyp ;
      private string Z225WWPFormInstanceElemBlobFileNam ;
      private string Z213WWPFormElementReferenceId ;
      private string A223WWPFormInstanceElemBlob ;
      private string Z223WWPFormInstanceElemBlob ;
      private IGxSession AV10WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_elementContainer ;
      private GXWebRow Gridlevel_elementRow ;
      private GXWebColumn Gridlevel_elementColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPFormElementDataType ;
      private GXCheckbox chkWWPFormInstanceElemBoolean ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000U9_A113WWPUserExtendedFullName ;
      private string[] T000U8_A208WWPFormReferenceName ;
      private string[] T000U8_A209WWPFormTitle ;
      private short[] T000U8_A216WWPFormResume ;
      private string[] T000U8_A233WWPFormValidations ;
      private int[] T000U10_A214WWPFormInstanceId ;
      private DateTime[] T000U10_A239WWPFormInstanceDate ;
      private string[] T000U10_A208WWPFormReferenceName ;
      private string[] T000U10_A209WWPFormTitle ;
      private string[] T000U10_A113WWPUserExtendedFullName ;
      private short[] T000U10_A216WWPFormResume ;
      private string[] T000U10_A233WWPFormValidations ;
      private string[] T000U10_A243WWPFormInstanceRecordKey ;
      private bool[] T000U10_n243WWPFormInstanceRecordKey ;
      private short[] T000U10_A206WWPFormId ;
      private short[] T000U10_A207WWPFormVersionNumber ;
      private string[] T000U10_A112WWPUserExtendedId ;
      private string[] T000U11_A208WWPFormReferenceName ;
      private string[] T000U11_A209WWPFormTitle ;
      private short[] T000U11_A216WWPFormResume ;
      private string[] T000U11_A233WWPFormValidations ;
      private string[] T000U12_A113WWPUserExtendedFullName ;
      private int[] T000U13_A214WWPFormInstanceId ;
      private int[] T000U7_A214WWPFormInstanceId ;
      private DateTime[] T000U7_A239WWPFormInstanceDate ;
      private string[] T000U7_A243WWPFormInstanceRecordKey ;
      private bool[] T000U7_n243WWPFormInstanceRecordKey ;
      private short[] T000U7_A206WWPFormId ;
      private short[] T000U7_A207WWPFormVersionNumber ;
      private string[] T000U7_A112WWPUserExtendedId ;
      private int[] T000U14_A214WWPFormInstanceId ;
      private int[] T000U15_A214WWPFormInstanceId ;
      private int[] T000U6_A214WWPFormInstanceId ;
      private DateTime[] T000U6_A239WWPFormInstanceDate ;
      private string[] T000U6_A243WWPFormInstanceRecordKey ;
      private bool[] T000U6_n243WWPFormInstanceRecordKey ;
      private short[] T000U6_A206WWPFormId ;
      private short[] T000U6_A207WWPFormVersionNumber ;
      private string[] T000U6_A112WWPUserExtendedId ;
      private int[] T000U17_A214WWPFormInstanceId ;
      private string[] T000U20_A208WWPFormReferenceName ;
      private string[] T000U20_A209WWPFormTitle ;
      private short[] T000U20_A216WWPFormResume ;
      private string[] T000U20_A233WWPFormValidations ;
      private string[] T000U21_A113WWPUserExtendedFullName ;
      private int[] T000U22_A214WWPFormInstanceId ;
      private short[] T000U23_A206WWPFormId ;
      private short[] T000U23_A207WWPFormVersionNumber ;
      private int[] T000U23_A214WWPFormInstanceId ;
      private short[] T000U23_A215WWPFormInstanceElementId ;
      private string[] T000U23_A229WWPFormElementTitle ;
      private string[] T000U23_A213WWPFormElementReferenceId ;
      private short[] T000U23_A218WWPFormElementDataType ;
      private short[] T000U23_A230WWPFormElementParentType ;
      private short[] T000U23_A217WWPFormElementType ;
      private string[] T000U23_A236WWPFormElementMetadata ;
      private short[] T000U23_A237WWPFormElementCaption ;
      private string[] T000U23_A221WWPFormInstanceElemChar ;
      private bool[] T000U23_n221WWPFormInstanceElemChar ;
      private DateTime[] T000U23_A220WWPFormInstanceElemDate ;
      private bool[] T000U23_n220WWPFormInstanceElemDate ;
      private DateTime[] T000U23_A227WWPFormInstanceElemDateTime ;
      private bool[] T000U23_n227WWPFormInstanceElemDateTime ;
      private decimal[] T000U23_A222WWPFormInstanceElemNumeric ;
      private bool[] T000U23_n222WWPFormInstanceElemNumeric ;
      private bool[] T000U23_A226WWPFormInstanceElemBoolean ;
      private bool[] T000U23_n226WWPFormInstanceElemBoolean ;
      private string[] T000U23_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] T000U23_A225WWPFormInstanceElemBlobFileNam ;
      private short[] T000U23_A210WWPFormElementId ;
      private short[] T000U23_A211WWPFormElementParentId ;
      private bool[] T000U23_n211WWPFormElementParentId ;
      private string[] T000U23_A223WWPFormInstanceElemBlob ;
      private bool[] T000U23_n223WWPFormInstanceElemBlob ;
      private short[] T000U4_A206WWPFormId ;
      private short[] T000U4_A207WWPFormVersionNumber ;
      private string[] T000U4_A229WWPFormElementTitle ;
      private string[] T000U4_A213WWPFormElementReferenceId ;
      private short[] T000U4_A218WWPFormElementDataType ;
      private short[] T000U4_A217WWPFormElementType ;
      private string[] T000U4_A236WWPFormElementMetadata ;
      private short[] T000U4_A237WWPFormElementCaption ;
      private short[] T000U4_A211WWPFormElementParentId ;
      private bool[] T000U4_n211WWPFormElementParentId ;
      private short[] T000U5_A230WWPFormElementParentType ;
      private short[] T000U24_A206WWPFormId ;
      private short[] T000U24_A207WWPFormVersionNumber ;
      private string[] T000U24_A229WWPFormElementTitle ;
      private string[] T000U24_A213WWPFormElementReferenceId ;
      private short[] T000U24_A218WWPFormElementDataType ;
      private short[] T000U24_A217WWPFormElementType ;
      private string[] T000U24_A236WWPFormElementMetadata ;
      private short[] T000U24_A237WWPFormElementCaption ;
      private short[] T000U24_A211WWPFormElementParentId ;
      private bool[] T000U24_n211WWPFormElementParentId ;
      private short[] T000U25_A230WWPFormElementParentType ;
      private int[] T000U26_A214WWPFormInstanceId ;
      private short[] T000U26_A210WWPFormElementId ;
      private short[] T000U26_A215WWPFormInstanceElementId ;
      private int[] T000U3_A214WWPFormInstanceId ;
      private short[] T000U3_A215WWPFormInstanceElementId ;
      private string[] T000U3_A221WWPFormInstanceElemChar ;
      private bool[] T000U3_n221WWPFormInstanceElemChar ;
      private DateTime[] T000U3_A220WWPFormInstanceElemDate ;
      private bool[] T000U3_n220WWPFormInstanceElemDate ;
      private DateTime[] T000U3_A227WWPFormInstanceElemDateTime ;
      private bool[] T000U3_n227WWPFormInstanceElemDateTime ;
      private decimal[] T000U3_A222WWPFormInstanceElemNumeric ;
      private bool[] T000U3_n222WWPFormInstanceElemNumeric ;
      private bool[] T000U3_A226WWPFormInstanceElemBoolean ;
      private bool[] T000U3_n226WWPFormInstanceElemBoolean ;
      private string[] T000U3_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] T000U3_A225WWPFormInstanceElemBlobFileNam ;
      private short[] T000U3_A210WWPFormElementId ;
      private string[] T000U3_A223WWPFormInstanceElemBlob ;
      private bool[] T000U3_n223WWPFormInstanceElemBlob ;
      private int[] T000U2_A214WWPFormInstanceId ;
      private short[] T000U2_A215WWPFormInstanceElementId ;
      private string[] T000U2_A221WWPFormInstanceElemChar ;
      private bool[] T000U2_n221WWPFormInstanceElemChar ;
      private DateTime[] T000U2_A220WWPFormInstanceElemDate ;
      private bool[] T000U2_n220WWPFormInstanceElemDate ;
      private DateTime[] T000U2_A227WWPFormInstanceElemDateTime ;
      private bool[] T000U2_n227WWPFormInstanceElemDateTime ;
      private decimal[] T000U2_A222WWPFormInstanceElemNumeric ;
      private bool[] T000U2_n222WWPFormInstanceElemNumeric ;
      private bool[] T000U2_A226WWPFormInstanceElemBoolean ;
      private bool[] T000U2_n226WWPFormInstanceElemBoolean ;
      private string[] T000U2_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] T000U2_A225WWPFormInstanceElemBlobFileNam ;
      private short[] T000U2_A210WWPFormElementId ;
      private string[] T000U2_A223WWPFormInstanceElemBlob ;
      private bool[] T000U2_n223WWPFormInstanceElemBlob ;
      private string[] T000U31_A229WWPFormElementTitle ;
      private string[] T000U31_A213WWPFormElementReferenceId ;
      private short[] T000U31_A218WWPFormElementDataType ;
      private short[] T000U31_A217WWPFormElementType ;
      private string[] T000U31_A236WWPFormElementMetadata ;
      private short[] T000U31_A237WWPFormElementCaption ;
      private short[] T000U31_A211WWPFormElementParentId ;
      private bool[] T000U31_n211WWPFormElementParentId ;
      private short[] T000U32_A230WWPFormElementParentType ;
      private int[] T000U33_A214WWPFormInstanceId ;
      private short[] T000U33_A210WWPFormElementId ;
      private short[] T000U33_A215WWPFormInstanceElementId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_forminstance__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_forminstance__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_forminstance__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new UpdateCursor(def[25])
      ,new UpdateCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new ForEachCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000U2;
       prmT000U2 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U3;
       prmT000U3 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U4;
       prmT000U4 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U5;
       prmT000U5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000U6;
       prmT000U6 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U7;
       prmT000U7 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U8;
       prmT000U8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000U9;
       prmT000U9 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000U10;
       prmT000U10 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U11;
       prmT000U11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000U12;
       prmT000U12 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000U13;
       prmT000U13 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U14;
       prmT000U14 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U15;
       prmT000U15 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U16;
       prmT000U16 = new Object[] {
       new ParDef("WWPFormInstanceDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000U17;
       prmT000U17 = new Object[] {
       };
       Object[] prmT000U18;
       prmT000U18 = new Object[] {
       new ParDef("WWPFormInstanceDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U19;
       prmT000U19 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmT000U20;
       prmT000U20 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000U21;
       prmT000U21 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000U22;
       prmT000U22 = new Object[] {
       };
       Object[] prmT000U23;
       prmT000U23 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U24;
       prmT000U24 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U25;
       prmT000U25 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000U26;
       prmT000U26 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U27;
       prmT000U27 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
       new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlobFileTyp",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceElemBlobFileNam",GXType.VarChar,40,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U28;
       prmT000U28 = new Object[] {
       new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlobFileTyp",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceElemBlobFileNam",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U29;
       prmT000U29 = new Object[] {
       new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U30;
       prmT000U30 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U31;
       prmT000U31 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000U32;
       prmT000U32 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000U33;
       prmT000U33 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000U2", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId  FOR UPDATE OF WWP_FormInstanceElement NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U3", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U4", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U5", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U6", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId  FOR UPDATE OF WWP_FormInstance NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000U6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U7", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U8", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U9", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U10", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T3.WWPFormReferenceName, T3.WWPFormTitle, T2.WWPUserExtendedFullName, T3.WWPFormResume, T3.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPUserExtendedId FROM ((WWP_FormInstance TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = TM1.WWPFormId AND T3.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U10,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U11", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U12", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U13", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U14", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE ( WWPFormInstanceId > :WWPFormInstanceId) ORDER BY WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000U15", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE ( WWPFormInstanceId < :WWPFormInstanceId) ORDER BY WWPFormInstanceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000U16", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstance(WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId) VALUES(:WWPFormInstanceDate, :WWPFormInstanceRecordKey, :WWPFormId, :WWPFormVersionNumber, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000U16)
          ,new CursorDef("T000U17", "SELECT currval('WWPFormInstanceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U17,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U18", "SAVEPOINT gxupdate;UPDATE WWP_FormInstance SET WWPFormInstanceDate=:WWPFormInstanceDate, WWPFormInstanceRecordKey=:WWPFormInstanceRecordKey, WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U18)
          ,new CursorDef("T000U19", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U19)
          ,new CursorDef("T000U20", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U21", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U22", "SELECT WWPFormInstanceId FROM WWP_FormInstance ORDER BY WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U22,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U23", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileTyp, T1.WWPFormInstanceElemBlobFileNam, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId and T1.WWPFormInstanceElementId = :WWPFormInstanceElementId and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U23,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U24", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U24,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U25", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U25,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U26", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U27", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstanceElement(WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBlob, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId) VALUES(:WWPFormInstanceId, :WWPFormInstanceElementId, :WWPFormInstanceElemChar, :WWPFormInstanceElemDate, :WWPFormInstanceElemDateTime, :WWPFormInstanceElemNumeric, :WWPFormInstanceElemBlob, :WWPFormInstanceElemBoolean, :WWPFormInstanceElemBlobFileTyp, :WWPFormInstanceElemBlobFileNam, :WWPFormElementId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000U27)
          ,new CursorDef("T000U28", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemChar=:WWPFormInstanceElemChar, WWPFormInstanceElemDate=:WWPFormInstanceElemDate, WWPFormInstanceElemDateTime=:WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric=:WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean=:WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp=:WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam=:WWPFormInstanceElemBlobFileNam  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U28)
          ,new CursorDef("T000U29", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemBlob=:WWPFormInstanceElemBlob  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U29)
          ,new CursorDef("T000U30", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U30)
          ,new CursorDef("T000U31", "SELECT WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U31,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U32", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U32,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000U33", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId ORDER BY WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U33,11, GxCacheFrequency.OFF ,true,false )
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
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getVarchar(8);
             ((string[]) buf[13])[0] = rslt.getVarchar(9);
             ((short[]) buf[14])[0] = rslt.getShort(10);
             ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getVarchar(8);
             ((string[]) buf[13])[0] = rslt.getVarchar(9);
             ((short[]) buf[14])[0] = rslt.getShort(10);
             ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 4 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((short[]) buf[4])[0] = rslt.getShort(4);
             ((short[]) buf[5])[0] = rslt.getShort(5);
             ((string[]) buf[6])[0] = rslt.getString(6, 40);
             return;
          case 5 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((short[]) buf[4])[0] = rslt.getShort(4);
             ((short[]) buf[5])[0] = rslt.getShort(5);
             ((string[]) buf[6])[0] = rslt.getString(6, 40);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((short[]) buf[9])[0] = rslt.getShort(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 12 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 13 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 15 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 18 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 19 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 20 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 21 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
             ((bool[]) buf[18])[0] = rslt.wasNull(15);
             ((bool[]) buf[19])[0] = rslt.getBool(16);
             ((bool[]) buf[20])[0] = rslt.wasNull(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getVarchar(18);
             ((short[]) buf[23])[0] = rslt.getShort(19);
             ((short[]) buf[24])[0] = rslt.getShort(20);
             ((bool[]) buf[25])[0] = rslt.wasNull(20);
             ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
             ((bool[]) buf[27])[0] = rslt.wasNull(21);
             return;
          case 22 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 23 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 24 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 29 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
    }
    getresults30( cursor, rslt, buf) ;
 }

 public void getresults30( int cursor ,
                           IFieldGetter rslt ,
                           Object[] buf )
 {
    switch ( cursor )
    {
          case 30 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 31 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
    }
 }

}

}
