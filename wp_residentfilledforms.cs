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
   public class wp_residentfilledforms : GXDataArea
   {
      public wp_residentfilledforms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_residentfilledforms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AccessToken )
      {
         this.AV6AccessToken = aP0_AccessToken;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AccessToken");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AccessToken");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AccessToken");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
            {
               gxnrFreestylegrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
            {
               gxgrFreestylegrid1_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV6AccessToken = gxfirstwebparm;
               AssignAttri("", false, "AV6AccessToken", AV6AccessToken);
               GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV6AccessToken, context));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_19 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_19"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_19_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_19_idx = GetPar( "sGXsfl_19_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         AV6AccessToken = GetPar( "AccessToken");
         AV20SearchKeyValue = GetPar( "SearchKeyValue");
         AV8ResidentId = GetPar( "ResidentId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( AV6AccessToken, AV20SearchKeyValue, AV8ResidentId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA9B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9B2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal ResidentForm\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal ResidentForm\" data-gx-class=\"form-horizontal ResidentForm\" novalidate action=\""+formatLink("wp_residentfilledforms.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6AccessToken))}, new string[] {"AccessToken"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal ResidentForm", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV6AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV6AccessToken, context));
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV20SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20SearchKeyValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTID", AV8ResidentId);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8ResidentId, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_residentfilledforms", AV9SDT_ResidentFilledForms);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_residentfilledforms", AV9SDT_ResidentFilledForms);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_19", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_19), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RESIDENTFILLEDFORMS", AV9SDT_ResidentFilledForms);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RESIDENTFILLEDFORMS", AV9SDT_ResidentFilledForms);
         }
         GxWebStd.gx_hidden_field( context, "vACCESSTOKEN", AV6AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV6AccessToken, context));
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV20SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20SearchKeyValue, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A214WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vRESIDENTID", AV8ResidentId);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8ResidentId, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "WWPFORMINSTANCEDATE", context.localUtil.TToC( A239WWPFormInstanceDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal ResidentForm" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9B2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wp_residentfilledforms.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6AccessToken))}, new string[] {"AccessToken"})  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ResidentFilledForms" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Resident Filled Forms", "") ;
      }

      protected void WB9B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemaincontent_Internalname, divTablemaincontent_Visible, 0, "px", 0, "px", "MainFilledFormsTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSearchtable_Internalname, 1, 0, "px", 0, "px", "SearchFormsTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "col-sm-3 FilledFormSearchInputLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_19_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "FilledFormSearchInput", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_ResidentFilledForms.htm");
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
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl19( ) ;
         }
         if ( wbEnd == 19 )
         {
            wbEnd = 0;
            nRC_GXsfl_19 = (int)(nGXsfl_19_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV21GXV1 = nGXsfl_19_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNorecordfoundtable_Internalname, divNorecordfoundtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_63_9B2( true) ;
         }
         else
         {
            wb_table1_63_9B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_63_9B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBanicon_Internalname, context.GetMessage( "<i class='fas fa-ban' style='font-size: 50px'></i>", ""), "", "", lblBanicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ResidentFilledForms.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_72_9B2( true) ;
         }
         else
         {
            wb_table2_72_9B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_9B2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblErrormessage_Internalname, lblErrormessage_Caption, "", "", lblErrormessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblErrormessage_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentFilledForms.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 19 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV21GXV1 = nGXsfl_19_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START9B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "WP_Resident Filled Forms", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9B0( ) ;
      }

      protected void WS9B2( )
      {
         START9B2( ) ;
         EVT9B2( ) ;
      }

      protected void EVT9B2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERFULLTEXT.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E119B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLAYOUT.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridlayout.Click */
                              E129B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'DOVIEWFORMRESPONSE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDLAYOUT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_19_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
                              SubsflControlProps_192( ) ;
                              AV21GXV1 = nGXsfl_19_idx;
                              if ( ( AV9SDT_ResidentFilledForms.Count >= AV21GXV1 ) && ( AV21GXV1 > 0 ) )
                              {
                                 AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E139B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1.Load */
                                    E149B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVIEWFORMRESPONSE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoViewFormResponse' */
                                    E159B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLAYOUT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlayout.Click */
                                    E129B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA9B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_192( ) ;
         while ( nGXsfl_19_idx <= nRC_GXsfl_19 )
         {
            sendrow_192( ) ;
            nGXsfl_19_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( string AV6AccessToken ,
                                                 string AV20SearchKeyValue ,
                                                 string AV8ResidentId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RF9B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreestylegrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_residentfilledforms__formfilleddate_Enabled = 0;
         edtavSdt_residentfilledforms__formtitle_Enabled = 0;
      }

      protected void RF9B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 19;
         nGXsfl_19_idx = 1;
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         bGXsfl_19_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", "");
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_192( ) ;
            /* Execute user event: Freestylegrid1.Load */
            E149B2 ();
            wbEnd = 19;
            WB9B0( ) ;
         }
         bGXsfl_19_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9B2( )
      {
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV20SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20SearchKeyValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vRESIDENTID", AV8ResidentId);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8ResidentId, "")), context));
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_residentfilledforms__formfilleddate_Enabled = 0;
         edtavSdt_residentfilledforms__formtitle_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E139B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_residentfilledforms"), AV9SDT_ResidentFilledForms);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_RESIDENTFILLEDFORMS"), AV9SDT_ResidentFilledForms);
            /* Read saved values. */
            nRC_GXsfl_19 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_19"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_19 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_19"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_19_fel_idx = 0;
            while ( nGXsfl_19_fel_idx < nRC_GXsfl_19 )
            {
               nGXsfl_19_fel_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_19_fel_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_fel_idx+1);
               sGXsfl_19_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_192( ) ;
               AV21GXV1 = nGXsfl_19_fel_idx;
               if ( ( AV9SDT_ResidentFilledForms.Count >= AV21GXV1 ) && ( AV21GXV1 > 0 ) )
               {
                  AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
               }
            }
            if ( nGXsfl_19_fel_idx == 0 )
            {
               nGXsfl_19_idx = 1;
               sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
               SubsflControlProps_192( ) ;
            }
            nGXsfl_19_fel_idx = 1;
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E139B2 ();
         if (returnInSub) return;
      }

      protected void E139B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV16ShowNoRecordFound = false;
         AssignAttri("", false, "AV16ShowNoRecordFound", AV16ShowNoRecordFound);
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV14Message = AV13WebSession.Get(context.GetMessage( "FormFilledMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Message)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV14Message,  "success",  "",  "true",  ""));
            AV13WebSession.Remove(context.GetMessage( "FormFilledMessage", ""));
         }
         new prc_getuseridfromaccesstoken(context ).execute(  AV6AccessToken, out  AV8ResidentId, out  AV15isTokenValid) ;
         AssignAttri("", false, "AV8ResidentId", AV8ResidentId);
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8ResidentId, "")), context));
         if ( AV15isTokenValid )
         {
            /* Execute user subroutine: 'LOADGRIDSDT' */
            S112 ();
            if (returnInSub) return;
            AV13WebSession.Set(context.GetMessage( "WebViewResidentId", ""), AV8ResidentId);
            AV5isResidentFound = true;
         }
         else
         {
            AV5isResidentFound = false;
            lblErrormessage_Caption = context.GetMessage( "The user session is invalid", "");
            AssignProp("", false, lblErrormessage_Internalname, "Caption", lblErrormessage_Caption, true);
            lblErrormessage_Forecolor = GXUtil.RGB(128,0,0);
            AssignProp("", false, lblErrormessage_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblErrormessage_Forecolor), 9, 0), true);
            AV16ShowNoRecordFound = true;
            AssignAttri("", false, "AV16ShowNoRecordFound", AV16ShowNoRecordFound);
         }
         tblSpacetable2_Height = 30;
         AssignProp("", false, tblSpacetable2_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblSpacetable2_Height), 9, 0), true);
         tblSpacetable1_Height = 60;
         AssignProp("", false, tblSpacetable1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblSpacetable1_Height), 9, 0), true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         edtavSdt_residentfilledforms__formid_Visible = 0;
         AssignProp("", false, edtavSdt_residentfilledforms__formid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residentfilledforms__formid_Visible), 5, 0), !bGXsfl_19_Refreshing);
         edtavSdt_residentfilledforms__forminstanceid_Visible = 0;
         AssignProp("", false, edtavSdt_residentfilledforms__forminstanceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residentfilledforms__forminstanceid_Visible), 5, 0), !bGXsfl_19_Refreshing);
         edtavSdt_residentfilledforms__formversionnumber_Visible = 0;
         AssignProp("", false, edtavSdt_residentfilledforms__formversionnumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residentfilledforms__formversionnumber_Visible), 5, 0), !bGXsfl_19_Refreshing);
         edtavSdt_residentfilledforms__formfilledby_Visible = 0;
         AssignProp("", false, edtavSdt_residentfilledforms__formfilledby_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residentfilledforms__formfilledby_Visible), 5, 0), !bGXsfl_19_Refreshing);
      }

      private void E149B2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV9SDT_ResidentFilledForms.Count )
         {
            AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 19;
            }
            sendrow_192( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_19_Refreshing )
            {
               DoAjaxLoad(19, Freestylegrid1Row);
            }
            AV21GXV1 = (int)(AV21GXV1+1);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTablemaincontent_Visible = ((!AV16ShowNoRecordFound) ? 1 : 0);
         AssignProp("", false, divTablemaincontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemaincontent_Visible), 5, 0), true);
         divNorecordfoundtable_Visible = (((AV16ShowNoRecordFound)) ? 1 : 0);
         AssignProp("", false, divNorecordfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divNorecordfoundtable_Visible), 5, 0), true);
      }

      protected void E159B2( )
      {
         AV21GXV1 = nGXsfl_19_idx;
         if ( ( AV21GXV1 > 0 ) && ( AV9SDT_ResidentFilledForms.Count >= AV21GXV1 ) )
         {
            AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
         }
         /* 'DoViewFormResponse' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_residentdynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)(AV9SDT_ResidentFilledForms.CurrentItem)).gxTpr_Formreferencename)),UrlEncode(StringUtil.LTrimStr(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)(AV9SDT_ResidentFilledForms.CurrentItem)).gxTpr_Forminstanceid,4,0)),UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV6AccessToken))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","AccessToken"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E129B2( )
      {
         AV21GXV1 = nGXsfl_19_idx;
         if ( ( AV21GXV1 > 0 ) && ( AV9SDT_ResidentFilledForms.Count >= AV21GXV1 ) )
         {
            AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
         }
         /* Gridlayout_Click Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_residentdynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)(AV9SDT_ResidentFilledForms.CurrentItem)).gxTpr_Formreferencename)),UrlEncode(StringUtil.LTrimStr(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)(AV9SDT_ResidentFilledForms.CurrentItem)).gxTpr_Forminstanceid,4,0)),UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV6AccessToken))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","AccessToken"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E119B2( )
      {
         AV21GXV1 = nGXsfl_19_idx;
         if ( ( AV21GXV1 > 0 ) && ( AV9SDT_ResidentFilledForms.Count >= AV21GXV1 ) )
         {
            AV9SDT_ResidentFilledForms.CurrentItem = ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1));
         }
         /* Filterfulltext_Controlvaluechanging Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV19 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9SDT_ResidentFilledForms", AV9SDT_ResidentFilledForms);
            nGXsfl_19_bak_idx = nGXsfl_19_idx;
            gxgrFreestylegrid1_refresh( AV6AccessToken, AV20SearchKeyValue, AV8ResidentId) ;
            nGXsfl_19_idx = nGXsfl_19_bak_idx;
            sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
            SubsflControlProps_192( ) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV9SDT_ResidentFilledForms = new GXBaseCollection<SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem>( context, "SDT_ResidentFilledFormsItem", "Comforta_version2");
         gx_BV19 = true;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19FilterFullText ,
                                              A209WWPFormTitle ,
                                              A112WWPUserExtendedId ,
                                              AV8ResidentId } ,
                                              new int[]{
                                              }
         });
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         /* Using cursor H009B2 */
         pr_default.execute(0, new Object[] {AV8ResidentId, lV19FilterFullText});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A209WWPFormTitle = H009B2_A209WWPFormTitle[0];
            A112WWPUserExtendedId = H009B2_A112WWPUserExtendedId[0];
            A239WWPFormInstanceDate = H009B2_A239WWPFormInstanceDate[0];
            A206WWPFormId = H009B2_A206WWPFormId[0];
            A208WWPFormReferenceName = H009B2_A208WWPFormReferenceName[0];
            A207WWPFormVersionNumber = H009B2_A207WWPFormVersionNumber[0];
            A214WWPFormInstanceId = H009B2_A214WWPFormInstanceId[0];
            A209WWPFormTitle = H009B2_A209WWPFormTitle[0];
            A208WWPFormReferenceName = H009B2_A208WWPFormReferenceName[0];
            AV10SDT_ResidentFilledFormsItem = new SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem(context);
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formfilledby = A112WWPUserExtendedId;
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formfilleddate = A239WWPFormInstanceDate;
            AV10SDT_ResidentFilledFormsItem.gxTpr_Forminstanceid = (short)(A214WWPFormInstanceId);
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formid = A206WWPFormId;
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formreferencename = A208WWPFormReferenceName;
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formversionnumber = A207WWPFormVersionNumber;
            AV10SDT_ResidentFilledFormsItem.gxTpr_Formtitle = A209WWPFormTitle;
            AV9SDT_ResidentFilledForms.Add(AV10SDT_ResidentFilledFormsItem, 0);
            gx_BV19 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void wb_table2_72_9B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(tblSpacetable2_Height), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblSpacetable2_Internalname, tblSpacetable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentFilledForms.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_9B2e( true) ;
         }
         else
         {
            wb_table2_72_9B2e( false) ;
         }
      }

      protected void wb_table1_63_9B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(tblSpacetable1_Height), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblSpacetable1_Internalname, tblSpacetable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ResidentFilledForms.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_63_9B2e( true) ;
         }
         else
         {
            wb_table1_63_9B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6AccessToken = (string)getParm(obj,0);
         AssignAttri("", false, "AV6AccessToken", AV6AccessToken);
         GxWebStd.gx_hidden_field( context, "gxhash_vACCESSTOKEN", GetSecureSignedToken( "", AV6AccessToken, context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA9B2( ) ;
         WS9B2( ) ;
         WE9B2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630952458", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_residentfilledforms.js", "?2025630952458", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_192( )
      {
         edtavSdt_residentfilledforms__formfilleddate_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDDATE_"+sGXsfl_19_idx;
         edtavSdt_residentfilledforms__formtitle_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMTITLE_"+sGXsfl_19_idx;
         lblFilledformarrow_Internalname = "FILLEDFORMARROW_"+sGXsfl_19_idx;
         edtavSdt_residentfilledforms__formid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMID_"+sGXsfl_19_idx;
         edtavSdt_residentfilledforms__forminstanceid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMINSTANCEID_"+sGXsfl_19_idx;
         edtavSdt_residentfilledforms__formversionnumber_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMVERSIONNUMBER_"+sGXsfl_19_idx;
         edtavSdt_residentfilledforms__formfilledby_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDBY_"+sGXsfl_19_idx;
      }

      protected void SubsflControlProps_fel_192( )
      {
         edtavSdt_residentfilledforms__formfilleddate_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDDATE_"+sGXsfl_19_fel_idx;
         edtavSdt_residentfilledforms__formtitle_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMTITLE_"+sGXsfl_19_fel_idx;
         lblFilledformarrow_Internalname = "FILLEDFORMARROW_"+sGXsfl_19_fel_idx;
         edtavSdt_residentfilledforms__formid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMID_"+sGXsfl_19_fel_idx;
         edtavSdt_residentfilledforms__forminstanceid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMINSTANCEID_"+sGXsfl_19_fel_idx;
         edtavSdt_residentfilledforms__formversionnumber_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMVERSIONNUMBER_"+sGXsfl_19_fel_idx;
         edtavSdt_residentfilledforms__formfilledby_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDBY_"+sGXsfl_19_fel_idx;
      }

      protected void sendrow_192( )
      {
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         WB9B0( ) ;
         Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
         if ( subFreestylegrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
            subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_19_idx) % (2))) == 0 )
            {
               subFreestylegrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_19_idx+"\">") ;
         }
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridlayout_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablefscard_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"FilledFormCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontent_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"align-items:flex-start;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divValuestable_Internalname+"_"+sGXsfl_19_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"flex-direction:column;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"MarginLeft5",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formfilleddate_Internalname,context.GetMessage( "Form Filled Date", ""),(string)"gx-form-item FilledFormDateTimeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "FilledFormDateTime";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formfilleddate_Internalname,context.localUtil.TToC( ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formfilleddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( ((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formfilleddate, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__formfilleddate_Jsonclick,(short)0,(string)"FilledFormDateTime",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdt_residentfilledforms__formfilleddate_Enabled,(short)0,(string)"text",(string)"",(short)17,(string)"chr",(short)1,(string)"row",(short)17,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formtitle_Internalname,context.GetMessage( "Form Title", ""),(string)"gx-form-item FilledFormTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "FilledFormTitle";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formtitle_Internalname,((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formtitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__formtitle_Jsonclick,(short)0,(string)"FilledFormTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdt_residentfilledforms__formtitle_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"align-self:center;",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblFilledformarrow_Internalname,context.GetMessage( "<i class='FilledFormArrowIcon fas fa-angle-right'></i>", ""),(string)"",(string)"",(string)lblFilledformarrow_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_19_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formid_Internalname,context.GetMessage( "Form Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__formid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdt_residentfilledforms__formid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_19230( ) ;
      }

      protected void sendrow_19230( )
      {
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__forminstanceid_Internalname,context.GetMessage( "Form Instance Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__forminstanceid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Forminstanceid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Forminstanceid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__forminstanceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdt_residentfilledforms__forminstanceid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formversionnumber_Internalname,context.GetMessage( "Form Version Number", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formversionnumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formversionnumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formversionnumber), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__formversionnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdt_residentfilledforms__formversionnumber_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)19,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formfilledby_Internalname,context.GetMessage( "Form Filled By", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_19_idx + "',19)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residentfilledforms__formfilledby_Internalname,((SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)AV9SDT_ResidentFilledForms.Item(AV21GXV1)).gxTpr_Formfilledby,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residentfilledforms__formfilledby_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdt_residentfilledforms__formfilledby_Visible,(short)1,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)19,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes9B2( ) ;
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_19_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_19_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_19_idx+1);
         sGXsfl_19_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_19_idx), 4, 0), 4, "0");
         SubsflControlProps_192( ) ;
         /* End function sendrow_192 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl19( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"19\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", "");
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__formfilleddate_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__formtitle_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblFilledformarrow_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__formid_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__forminstanceid_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__formversionnumber_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residentfilledforms__formfilledby_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divSearchtable_Internalname = "SEARCHTABLE";
         edtavSdt_residentfilledforms__formfilleddate_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDDATE";
         edtavSdt_residentfilledforms__formtitle_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMTITLE";
         divValuestable_Internalname = "VALUESTABLE";
         lblFilledformarrow_Internalname = "FILLEDFORMARROW";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablefscard_Internalname = "TABLEFSCARD";
         edtavSdt_residentfilledforms__formid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMID";
         edtavSdt_residentfilledforms__forminstanceid_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMINSTANCEID";
         edtavSdt_residentfilledforms__formversionnumber_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMVERSIONNUMBER";
         edtavSdt_residentfilledforms__formfilledby_Internalname = "SDT_RESIDENTFILLEDFORMS__FORMFILLEDBY";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = "UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         divGridlayout_Internalname = "GRIDLAYOUT";
         divTablemaincontent_Internalname = "TABLEMAINCONTENT";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         tblSpacetable1_Internalname = "SPACETABLE1";
         lblBanicon_Internalname = "BANICON";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         tblSpacetable2_Internalname = "SPACETABLE2";
         lblErrormessage_Internalname = "ERRORMESSAGE";
         divNorecordfoundtable_Internalname = "NORECORDFOUNDTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreestylegrid1_Internalname = "FREESTYLEGRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreestylegrid1_Allowcollapsing = 0;
         lblFilledformarrow_Caption = context.GetMessage( "<i class='FilledFormArrowIcon fas fa-angle-right'></i>", "");
         edtavSdt_residentfilledforms__formfilledby_Jsonclick = "";
         edtavSdt_residentfilledforms__formfilledby_Visible = 1;
         edtavSdt_residentfilledforms__formversionnumber_Jsonclick = "";
         edtavSdt_residentfilledforms__formversionnumber_Visible = 1;
         edtavSdt_residentfilledforms__forminstanceid_Jsonclick = "";
         edtavSdt_residentfilledforms__forminstanceid_Visible = 1;
         edtavSdt_residentfilledforms__formid_Jsonclick = "";
         edtavSdt_residentfilledforms__formid_Visible = 1;
         edtavSdt_residentfilledforms__formtitle_Jsonclick = "";
         edtavSdt_residentfilledforms__formtitle_Enabled = 0;
         edtavSdt_residentfilledforms__formfilleddate_Jsonclick = "";
         edtavSdt_residentfilledforms__formfilleddate_Enabled = 0;
         subFreestylegrid1_Class = "FreeStyleGrid";
         tblSpacetable1_Height = 0;
         tblSpacetable2_Height = 0;
         subFreestylegrid1_Backcolorstyle = 0;
         edtavSdt_residentfilledforms__formtitle_Enabled = -1;
         edtavSdt_residentfilledforms__formfilleddate_Enabled = -1;
         lblErrormessage_Forecolor = (int)(0x000000);
         lblErrormessage_Caption = context.GetMessage( "No forms found", "");
         divNorecordfoundtable_Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         divTablemaincontent_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Resident Filled Forms", "");
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"AV9SDT_ResidentFilledForms","fld":"vSDT_RESIDENTFILLEDFORMS","grid":19},{"av":"nGXsfl_19_idx","ctrl":"GRID","prop":"GridCurrRow","grid":19},{"av":"nRC_GXsfl_19","ctrl":"FREESTYLEGRID1","prop":"GridRC","grid":19},{"av":"AV6AccessToken","fld":"vACCESSTOKEN","hsh":true},{"av":"AV20SearchKeyValue","fld":"vSEARCHKEYVALUE","hsh":true},{"av":"AV8ResidentId","fld":"vRESIDENTID","hsh":true}]}""");
         setEventMetadata("FREESTYLEGRID1.LOAD","""{"handler":"E149B2","iparms":[]}""");
         setEventMetadata("'DOVIEWFORMRESPONSE'","""{"handler":"E159B2","iparms":[{"av":"AV9SDT_ResidentFilledForms","fld":"vSDT_RESIDENTFILLEDFORMS","grid":19},{"av":"nGXsfl_19_idx","ctrl":"GRID","prop":"GridCurrRow","grid":19},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"nRC_GXsfl_19","ctrl":"FREESTYLEGRID1","prop":"GridRC","grid":19},{"av":"AV6AccessToken","fld":"vACCESSTOKEN","hsh":true}]}""");
         setEventMetadata("GRIDLAYOUT.CLICK","""{"handler":"E129B2","iparms":[{"av":"AV9SDT_ResidentFilledForms","fld":"vSDT_RESIDENTFILLEDFORMS","grid":19},{"av":"nGXsfl_19_idx","ctrl":"GRID","prop":"GridCurrRow","grid":19},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"nRC_GXsfl_19","ctrl":"FREESTYLEGRID1","prop":"GridRC","grid":19},{"av":"AV6AccessToken","fld":"vACCESSTOKEN","hsh":true}]}""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGING","""{"handler":"E119B2","iparms":[{"av":"AV20SearchKeyValue","fld":"vSEARCHKEYVALUE","hsh":true},{"av":"A214WWPFormInstanceId","fld":"WWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV8ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A239WWPFormInstanceDate","fld":"WWPFORMINSTANCEDATE","pic":"99/99/99 99:99"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV9SDT_ResidentFilledForms","fld":"vSDT_RESIDENTFILLEDFORMS","grid":19},{"av":"nGXsfl_19_idx","ctrl":"GRID","prop":"GridCurrRow","grid":19},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"nRC_GXsfl_19","ctrl":"FREESTYLEGRID1","prop":"GridRC","grid":19},{"av":"FREESTYLEGRID1_nEOF"},{"av":"AV6AccessToken","fld":"vACCESSTOKEN","hsh":true}]""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGING",""","oparms":[{"av":"AV9SDT_ResidentFilledForms","fld":"vSDT_RESIDENTFILLEDFORMS","grid":19},{"av":"nGXsfl_19_idx","ctrl":"GRID","prop":"GridCurrRow","grid":19},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"nRC_GXsfl_19","ctrl":"FREESTYLEGRID1","prop":"GridRC","grid":19}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv7","iparms":[]}""");
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

      public override void initialize( )
      {
         wcpOAV6AccessToken = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV20SearchKeyValue = "";
         AV8ResidentId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV9SDT_ResidentFilledForms = new GXBaseCollection<SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem>( context, "SDT_ResidentFilledFormsItem", "Comforta_version2");
         A112WWPUserExtendedId = "";
         A209WWPFormTitle = "";
         A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         A208WWPFormReferenceName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         AV19FilterFullText = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         lblBanicon_Jsonclick = "";
         lblErrormessage_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV14Message = "";
         AV13WebSession = context.GetSession();
         Freestylegrid1Row = new GXWebRow();
         lV19FilterFullText = "";
         H009B2_A209WWPFormTitle = new string[] {""} ;
         H009B2_A112WWPUserExtendedId = new string[] {""} ;
         H009B2_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         H009B2_A206WWPFormId = new short[1] ;
         H009B2_A208WWPFormReferenceName = new string[] {""} ;
         H009B2_A207WWPFormVersionNumber = new short[1] ;
         H009B2_A214WWPFormInstanceId = new int[1] ;
         AV10SDT_ResidentFilledFormsItem = new SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem(context);
         lblTextblock2_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegrid1_Linesclass = "";
         ROClassString = "";
         lblFilledformarrow_Jsonclick = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_residentfilledforms__default(),
            new Object[][] {
                new Object[] {
               H009B2_A209WWPFormTitle, H009B2_A112WWPUserExtendedId, H009B2_A239WWPFormInstanceDate, H009B2_A206WWPFormId, H009B2_A208WWPFormReferenceName, H009B2_A207WWPFormVersionNumber, H009B2_A214WWPFormInstanceId
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_residentfilledforms__formfilleddate_Enabled = 0;
         edtavSdt_residentfilledforms__formtitle_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short FREESTYLEGRID1_nEOF ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int nRC_GXsfl_19 ;
      private int nGXsfl_19_idx=1 ;
      private int A214WWPFormInstanceId ;
      private int divTablemaincontent_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int AV21GXV1 ;
      private int divNorecordfoundtable_Visible ;
      private int lblErrormessage_Forecolor ;
      private int subFreestylegrid1_Islastpage ;
      private int edtavSdt_residentfilledforms__formfilleddate_Enabled ;
      private int edtavSdt_residentfilledforms__formtitle_Enabled ;
      private int nGXsfl_19_fel_idx=1 ;
      private int tblSpacetable2_Height ;
      private int tblSpacetable1_Height ;
      private int edtavSdt_residentfilledforms__formid_Visible ;
      private int edtavSdt_residentfilledforms__forminstanceid_Visible ;
      private int edtavSdt_residentfilledforms__formversionnumber_Visible ;
      private int edtavSdt_residentfilledforms__formfilledby_Visible ;
      private int nGXsfl_19_bak_idx=1 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_19_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A112WWPUserExtendedId ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablemaincontent_Internalname ;
      private string divSearchtable_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string divNorecordfoundtable_Internalname ;
      private string lblBanicon_Internalname ;
      private string lblBanicon_Jsonclick ;
      private string lblErrormessage_Internalname ;
      private string lblErrormessage_Caption ;
      private string lblErrormessage_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_19_fel_idx="0001" ;
      private string tblSpacetable2_Internalname ;
      private string tblSpacetable1_Internalname ;
      private string edtavSdt_residentfilledforms__formid_Internalname ;
      private string edtavSdt_residentfilledforms__forminstanceid_Internalname ;
      private string edtavSdt_residentfilledforms__formversionnumber_Internalname ;
      private string edtavSdt_residentfilledforms__formfilledby_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtavSdt_residentfilledforms__formfilleddate_Internalname ;
      private string edtavSdt_residentfilledforms__formtitle_Internalname ;
      private string lblFilledformarrow_Internalname ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divGridlayout_Internalname ;
      private string divTablefscard_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divValuestable_Internalname ;
      private string ROClassString ;
      private string edtavSdt_residentfilledforms__formfilleddate_Jsonclick ;
      private string edtavSdt_residentfilledforms__formtitle_Jsonclick ;
      private string lblFilledformarrow_Jsonclick ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string edtavSdt_residentfilledforms__formid_Jsonclick ;
      private string edtavSdt_residentfilledforms__forminstanceid_Jsonclick ;
      private string edtavSdt_residentfilledforms__formversionnumber_Jsonclick ;
      private string edtavSdt_residentfilledforms__formfilledby_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private string lblFilledformarrow_Caption ;
      private DateTime A239WWPFormInstanceDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_19_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16ShowNoRecordFound ;
      private bool AV15isTokenValid ;
      private bool AV5isResidentFound ;
      private bool gx_BV19 ;
      private string AV6AccessToken ;
      private string wcpOAV6AccessToken ;
      private string AV20SearchKeyValue ;
      private string AV8ResidentId ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string AV19FilterFullText ;
      private string AV14Message ;
      private string lV19FilterFullText ;
      private IGxSession AV13WebSession ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem> AV9SDT_ResidentFilledForms ;
      private IDataStoreProvider pr_default ;
      private string[] H009B2_A209WWPFormTitle ;
      private string[] H009B2_A112WWPUserExtendedId ;
      private DateTime[] H009B2_A239WWPFormInstanceDate ;
      private short[] H009B2_A206WWPFormId ;
      private string[] H009B2_A208WWPFormReferenceName ;
      private short[] H009B2_A207WWPFormVersionNumber ;
      private int[] H009B2_A214WWPFormInstanceId ;
      private SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem AV10SDT_ResidentFilledFormsItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_residentfilledforms__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009B2( IGxContext context ,
                                             string AV19FilterFullText ,
                                             string A209WWPFormTitle ,
                                             string A112WWPUserExtendedId ,
                                             string AV8ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.WWPFormTitle, T1.WWPUserExtendedId, T1.WWPFormInstanceDate, T1.WWPFormId, T2.WWPFormReferenceName, T1.WWPFormVersionNumber, T1.WWPFormInstanceId FROM (WWP_FormInstance T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPUserExtendedId = ( :AV8ResidentId))");
         if ( StringUtil.Len( AV19FilterFullText) > 2 )
         {
            AddWhere(sWhereString, "(LOWER(T2.WWPFormTitle) like '%' || LOWER(:lV19FilterFullText) || '%')");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormInstanceId DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH009B2;
          prmH009B2 = new Object[] {
          new ParDef("AV8ResidentId",GXType.VarChar,100,60) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009B2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
