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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_masterpageruntimesettings : GXWebComponent
   {
      public wwp_masterpageruntimesettings( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_masterpageruntimesettings( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
         radavBackstyle = new GXRadio();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetNextPar( );
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fscolor") == 0 )
               {
                  gxnrFscolor_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fscolor") == 0 )
               {
                  gxgrFscolor_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrFscolor_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_12_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFscolor_newrow( ) ;
         /* End function gxnrFscolor_newrow_invoke */
      }

      protected void gxgrFscolor_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5WWP_DesignSystemSettings);
         edtavColorname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_12_Refreshing);
         AV8ColorItemClass = GetPar( "ColorItemClass");
         AV10ColorName = GetPar( "ColorName");
         AV6BackStyle = GetPar( "BackStyle");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFscolor_refresh( AV5WWP_DesignSystemSettings, AV8ColorItemClass, AV10ColorName, AV6BackStyle, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFscolor_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS3B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
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
            context.SendWebValue( context.GetMessage( "WWP_Master Page Runtime Settings", "")) ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_masterpageruntimesettings.aspx") +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV5WWP_DesignSystemSettings);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DESIGNSYSTEMSETTINGS", AV5WWP_DesignSystemSettings);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vFONTSIZESELECTED", AV11FontSizeSelected);
         GxWebStd.gx_hidden_field( context, sPrefix+"subFscolor_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORNAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3B2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
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
         return "WWPBaseObjects.WWP_MasterPageRuntimeSettings" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Master Page Runtime Settings", "") ;
      }

      protected void WB3B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_masterpageruntimesettings.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainDesignerSelector", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblColortxt_Internalname, context.GetMessage( "WWP_Color_Dsc", ""), "", "", lblColortxt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "RuntimeDesignSettingsTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingRight45", "start", "top", "", "", "div");
            /*  Grid Control  */
            FscolorContainer.SetIsFreestyle(true);
            FscolorContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( FscolorContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FscolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fscolor", FscolorContainer, subFscolor_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FscolorContainerData", FscolorContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FscolorContainerData"+"V", FscolorContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FscolorContainerData"+"V"+"\" value='"+FscolorContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBackstyletxt_Internalname, context.GetMessage( "WWP_BackgroundStyle_Dsc", ""), "", "", lblBackstyletxt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "RuntimeDesignSettingsTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavBackstyle_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavBackstyle, radavBackstyle_Internalname, StringUtil.RTrim( AV6BackStyle), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavBackstyle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFontsizetxt_Internalname, context.GetMessage( "WWP_FontSize_Dsc", ""), "", "", lblFontsizetxt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "RuntimeDesignSettingsTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-around;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFontsizesmall_Internalname, context.GetMessage( "A", ""), "", "", lblFontsizesmall_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFONTSIZESMALL.CLICK."+"'", "", lblFontsizesmall_Class, 5, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFontsizemedium_Internalname, context.GetMessage( "A", ""), "", "", lblFontsizemedium_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFONTSIZEMEDIUM.CLICK."+"'", "", lblFontsizemedium_Class, 5, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFontsizelargecell_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFontsizelarge_Internalname, context.GetMessage( "A", ""), "", "", lblFontsizelarge_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFONTSIZELARGE.CLICK."+"'", "", lblFontsizelarge_Class, 5, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_MasterPageRuntimeSettings.htm");
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FscolorContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FscolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fscolor", FscolorContainer, subFscolor_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FscolorContainerData", FscolorContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FscolorContainerData"+"V", FscolorContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FscolorContainerData"+"V"+"\" value='"+FscolorContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Master Page Runtime Settings", ""), 0) ;
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
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3B0( ) ;
            }
         }
      }

      protected void WS3B2( )
      {
         START3B2( ) ;
         EVT3B2( ) ;
      }

      protected void EVT3B2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FONTSIZESMALL.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Fontsizesmall.Click */
                                    E113B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FONTSIZEMEDIUM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Fontsizemedium.Click */
                                    E123B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FONTSIZELARGE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Fontsizelarge.Click */
                                    E133B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VBACKSTYLE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E143B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablecoloritem.Click */
                                    E153B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = radavBackstyle_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "FSCOLOR.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "TABLECOLORITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3B0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV10ColorName = cgiGet( edtavColorname_Internalname);
                              AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = radavBackstyle_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E163B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSCOLOR.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = radavBackstyle_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Fscolor.Load */
                                          E173B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = radavBackstyle_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E183B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLECOLORITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = radavBackstyle_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Tablecoloritem.Click */
                                          E153B2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3B0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = radavBackstyle_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE3B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3B2( ) ;
            }
         }
      }

      protected void PA3B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = radavBackstyle_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFscolor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subFscolor_Islastpage==1)&&(nGXsfl_12_idx+1>subFscolor_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FscolorContainer)) ;
         /* End function gxnrFscolor_newrow */
      }

      protected void gxgrFscolor_refresh( WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV5WWP_DesignSystemSettings ,
                                          string AV8ColorItemClass ,
                                          string AV10ColorName ,
                                          string AV6BackStyle ,
                                          string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSCOLOR_nCurrentRecord = 0;
         RF3B2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFscolor_refresh */
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
         AssignAttri(sPrefix, false, "AV6BackStyle", AV6BackStyle);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FscolorContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E183B2 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         FscolorContainer.AddObjectProperty("GridName", "Fscolor");
         FscolorContainer.AddObjectProperty("CmpContext", sPrefix);
         FscolorContainer.AddObjectProperty("InMasterPage", "false");
         FscolorContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FscolorContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FscolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FscolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FscolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Backcolorstyle), 1, 0, ".", "")));
         FscolorContainer.PageSize = subFscolor_fnc_Recordsperpage( );
         if ( subFscolor_Islastpage != 0 )
         {
            FSCOLOR_nFirstRecordOnPage = (long)(subFscolor_fnc_Recordcount( )-subFscolor_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FSCOLOR_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FSCOLOR_nFirstRecordOnPage), 15, 0, ".", "")));
            FscolorContainer.AddObjectProperty("FSCOLOR_nFirstRecordOnPage", FSCOLOR_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            /* Execute user event: Fscolor.Load */
            E173B2 ();
            wbEnd = 12;
            WB3B0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3B2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORITEMCLASS", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
      }

      protected int subFscolor_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFscolor_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E163B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFscolor_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFscolor_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV6BackStyle = cgiGet( radavBackstyle_Internalname);
            AssignAttri(sPrefix, false, "AV6BackStyle", AV6BackStyle);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E163B2 ();
         if (returnInSub) return;
      }

      protected void E163B2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavColorname_Visible = 0;
         AssignProp(sPrefix, false, edtavColorname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColorname_Visible), 5, 0), !bGXsfl_12_Refreshing);
      }

      private void E173B2( )
      {
         /* Fscolor_Load Routine */
         returnInSub = false;
         AV9ColorItemDefinition = "<div class=\"%1\" style=\"background-color:%2\">";
         AV10ColorName = "LightPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#b05792", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "MediumViolet";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "MediumVioletRed", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Pink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#a11a74", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "MediumPink";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#ED66D2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "MediumPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "MediumPurple", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "LightPurple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#696ef2", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Purple";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#7F4494", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Indigo";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "Indigo", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "LightBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#39b3d7", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Blue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#078bcd", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "SkyBlue";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#4978b0", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Navy";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#004080", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Green";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#5CB85C", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "SeaGreen";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#08A086", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Teal";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "Teal", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Olive";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#004000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Salmon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "Salmon", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Red";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#d9534f", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Tomato";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "Tomato", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Maroon";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#950000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Orange";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#FF8040", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Yellow";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#f0ad4e", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Ecru";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#B75B00", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         AV10ColorName = "Brown";
         AssignAttri(sPrefix, false, edtavColorname_Internalname, AV10ColorName);
         /* Execute user subroutine: 'GETCOLORCLASS' */
         S112 ();
         if (returnInSub) return;
         lblColorsquare_Caption = StringUtil.Format( AV9ColorItemDefinition, AV8ColorItemClass, "#804000", "", "", "", "", "", "", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, FscolorRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E183B2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV5WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV5WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV6BackStyle = AV5WWP_DesignSystemSettings.gxTpr_Backgroundstyle;
         AssignAttri(sPrefix, false, "AV6BackStyle", AV6BackStyle);
         /* Execute user subroutine: 'UPDATESELECTEDFONT' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
         radavBackstyle.CurrentValue = StringUtil.RTrim( AV6BackStyle);
         AssignProp(sPrefix, false, radavBackstyle_Internalname, "Values", radavBackstyle.ToJavascriptSource(), true);
      }

      protected void E153B2( )
      {
         /* Tablecoloritem_Click Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV5WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV5WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV5WWP_DesignSystemSettings.gxTpr_Basecolor = AV10ColorName;
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV5WWP_DesignSystemSettings.ToJSonString(false, true)) ;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV5WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
         gxgrFscolor_refresh( AV5WWP_DesignSystemSettings, AV8ColorItemClass, AV10ColorName, AV6BackStyle, sPrefix) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
         radavBackstyle.CurrentValue = StringUtil.RTrim( AV6BackStyle);
         AssignProp(sPrefix, false, radavBackstyle_Internalname, "Values", radavBackstyle.ToJavascriptSource(), true);
      }

      protected void E113B2( )
      {
         /* Fontsizesmall_Click Routine */
         returnInSub = false;
         AV11FontSizeSelected = "Small";
         AssignAttri(sPrefix, false, "AV11FontSizeSelected", AV11FontSizeSelected);
         /* Execute user subroutine: 'SELECTFONT' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATESELECTEDFONT' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
      }

      protected void E123B2( )
      {
         /* Fontsizemedium_Click Routine */
         returnInSub = false;
         AV11FontSizeSelected = "Medium";
         AssignAttri(sPrefix, false, "AV11FontSizeSelected", AV11FontSizeSelected);
         /* Execute user subroutine: 'SELECTFONT' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATESELECTEDFONT' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
      }

      protected void E133B2( )
      {
         /* Fontsizelarge_Click Routine */
         returnInSub = false;
         AV11FontSizeSelected = "Large";
         AssignAttri(sPrefix, false, "AV11FontSizeSelected", AV11FontSizeSelected);
         /* Execute user subroutine: 'SELECTFONT' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATESELECTEDFONT' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
      }

      protected void E143B2( )
      {
         /* Backstyle_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV5WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV5WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV5WWP_DesignSystemSettings.gxTpr_Backgroundstyle = AV6BackStyle;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV5WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
         AV5WWP_DesignSystemSettings.gxTpr_Menucolor = AV6BackStyle;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV5WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV5WWP_DesignSystemSettings.ToJSonString(false, true)) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWP_DesignSystemSettings", AV5WWP_DesignSystemSettings);
      }

      protected void S112( )
      {
         /* 'GETCOLORCLASS' Routine */
         returnInSub = false;
         AV7ColorItemBaseClass = "RuntimeSettingsColor";
         AV8ColorItemClass = ((StringUtil.StrCmp(AV5WWP_DesignSystemSettings.gxTpr_Basecolor, AV10ColorName)==0) ? AV7ColorItemBaseClass+"Selected" : AV7ColorItemBaseClass);
         AssignAttri(sPrefix, false, "AV8ColorItemClass", AV8ColorItemClass);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLORITEMCLASS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV8ColorItemClass, "")), context));
      }

      protected void S132( )
      {
         /* 'SELECTFONT' Routine */
         returnInSub = false;
         GXt_SdtWWP_DesignSystemSettings1 = AV5WWP_DesignSystemSettings;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
         AV5WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
         AV5WWP_DesignSystemSettings.gxTpr_Fontsize = AV11FontSizeSelected;
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV5WWP_DesignSystemSettings.ToJSonString(false, true)) ;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV5WWP_DesignSystemSettings.gxTpr_Fontsize}, false);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
      }

      protected void S122( )
      {
         /* 'UPDATESELECTEDFONT' Routine */
         returnInSub = false;
         AV11FontSizeSelected = AV5WWP_DesignSystemSettings.gxTpr_Fontsize;
         AssignAttri(sPrefix, false, "AV11FontSizeSelected", AV11FontSizeSelected);
         lblFontsizesmall_Class = "FontSizeSelectorSmall";
         AssignProp(sPrefix, false, lblFontsizesmall_Internalname, "Class", lblFontsizesmall_Class, true);
         lblFontsizemedium_Class = "FontSizeSelectorMedium";
         AssignProp(sPrefix, false, lblFontsizemedium_Internalname, "Class", lblFontsizemedium_Class, true);
         lblFontsizelarge_Class = "FontSizeSelectorLarge";
         AssignProp(sPrefix, false, lblFontsizelarge_Internalname, "Class", lblFontsizelarge_Class, true);
         if ( StringUtil.StrCmp(AV11FontSizeSelected, "Small") == 0 )
         {
            lblFontsizesmall_Class = lblFontsizesmall_Class+" "+"FontSizeSelectorSelected";
            AssignProp(sPrefix, false, lblFontsizesmall_Internalname, "Class", lblFontsizesmall_Class, true);
         }
         else if ( StringUtil.StrCmp(AV11FontSizeSelected, "Medium") == 0 )
         {
            lblFontsizemedium_Class = lblFontsizemedium_Class+" "+"FontSizeSelectorSelected";
            AssignProp(sPrefix, false, lblFontsizemedium_Internalname, "Class", lblFontsizemedium_Class, true);
         }
         else if ( StringUtil.StrCmp(AV11FontSizeSelected, "Large") == 0 )
         {
            lblFontsizelarge_Class = lblFontsizelarge_Class+" "+"FontSizeSelectorSelected";
            AssignProp(sPrefix, false, lblFontsizelarge_Internalname, "Class", lblFontsizelarge_Class, true);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA3B2( ) ;
         WS3B2( ) ;
         WE3B2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_masterpageruntimesettings", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         INITWEB( ) ;
         nDraw = 0;
         PA3B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3B2( ) ;
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
         WS3B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721243716", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wwpbaseobjects/wwp_masterpageruntimesettings.js", "?2025721243716", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_12_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE_"+sGXsfl_12_fel_idx;
         edtavColorname_Internalname = sPrefix+"vCOLORNAME_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB3B0( ) ;
         FscolorRow = GXWebRow.GetNew(context,FscolorContainer);
         if ( subFscolor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFscolor_Backstyle = 0;
            if ( StringUtil.StrCmp(subFscolor_Class, "") != 0 )
            {
               subFscolor_Linesclass = subFscolor_Class+"Odd";
            }
         }
         else if ( subFscolor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFscolor_Backstyle = 0;
            subFscolor_Backcolor = subFscolor_Allbackcolor;
            if ( StringUtil.StrCmp(subFscolor_Class, "") != 0 )
            {
               subFscolor_Linesclass = subFscolor_Class+"Uniform";
            }
         }
         else if ( subFscolor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFscolor_Backstyle = 1;
            if ( StringUtil.StrCmp(subFscolor_Class, "") != 0 )
            {
               subFscolor_Linesclass = subFscolor_Class+"Odd";
            }
            subFscolor_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFscolor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFscolor_Backstyle = 1;
            if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
            {
               subFscolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFscolor_Class, "") != 0 )
               {
                  subFscolor_Linesclass = subFscolor_Class+"Even";
               }
            }
            else
            {
               subFscolor_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFscolor_Class, "") != 0 )
               {
                  subFscolor_Linesclass = subFscolor_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFscolor_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
         }
         /* Table start */
         FscolorRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablefsfscolor_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FscolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FscolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FscolorRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecoloritem_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FscolorRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FscolorRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         FscolorRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblColorsquare_Internalname,(string)lblColorsquare_Caption,(string)"",(string)"",(string)lblColorsquare_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         FscolorRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FscolorRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FscolorRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("cell");
         }
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("row");
         }
         FscolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FscolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"Invisible"});
         /* Table start */
         FscolorRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfscolor_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FscolorRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FscolorRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FscolorRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FscolorRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,context.GetMessage( "Color Name", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         FscolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavColorname_Internalname,(string)AV10ColorName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavColorname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavColorname_Visible,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         FscolorRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("cell");
         }
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("row");
         }
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("table");
         }
         /* End of table */
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("cell");
         }
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("row");
         }
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            FscolorContainer.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes3B2( ) ;
         /* End of Columns property logic. */
         FscolorContainer.AddRow(FscolorRow);
         nGXsfl_12_idx = ((subFscolor_Islastpage==1)&&(nGXsfl_12_idx+1>subFscolor_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         radavBackstyle.Name = "vBACKSTYLE";
         radavBackstyle.WebTags = "";
         radavBackstyle.addItem("Light", context.GetMessage( "WWP_BackgroundStyle_Light", ""), 0);
         radavBackstyle.addItem("Dark", context.GetMessage( "WWP_BackgroundStyle_Dark", ""), 0);
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( FscolorContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FscolorContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFscolor_Internalname, subFscolor_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FscolorContainer.AddObjectProperty("GridName", "Fscolor");
         }
         else
         {
            FscolorContainer.AddObjectProperty("GridName", "Fscolor");
            FscolorContainer.AddObjectProperty("Header", subFscolor_Header);
            FscolorContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FscolorContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FscolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Backcolorstyle), 1, 0, ".", "")));
            FscolorContainer.AddObjectProperty("CmpContext", sPrefix);
            FscolorContainer.AddObjectProperty("InMasterPage", "false");
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorColumn.AddObjectProperty("Value", lblColorsquare_Caption);
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV10ColorName));
            FscolorColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavColorname_Visible), 5, 0, ".", "")));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FscolorContainer.AddColumnProperties(FscolorColumn);
            FscolorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Selectedindex), 4, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Allowselection), 1, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Selectioncolor), 9, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Allowhovering), 1, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Hoveringcolor), 9, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Allowcollapsing), 1, 0, ".", "")));
            FscolorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFscolor_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblColortxt_Internalname = sPrefix+"COLORTXT";
         lblColorsquare_Internalname = sPrefix+"COLORSQUARE";
         divTablecoloritem_Internalname = sPrefix+"TABLECOLORITEM";
         edtavColorname_Internalname = sPrefix+"vCOLORNAME";
         tblUnnamedtablecontentfsfscolor_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFSCOLOR";
         tblUnnamedtablefsfscolor_Internalname = sPrefix+"UNNAMEDTABLEFSFSCOLOR";
         lblBackstyletxt_Internalname = sPrefix+"BACKSTYLETXT";
         radavBackstyle_Internalname = sPrefix+"vBACKSTYLE";
         lblFontsizetxt_Internalname = sPrefix+"FONTSIZETXT";
         lblFontsizesmall_Internalname = sPrefix+"FONTSIZESMALL";
         lblFontsizemedium_Internalname = sPrefix+"FONTSIZEMEDIUM";
         lblFontsizelarge_Internalname = sPrefix+"FONTSIZELARGE";
         divFontsizelargecell_Internalname = sPrefix+"FONTSIZELARGECELL";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFscolor_Internalname = sPrefix+"FSCOLOR";
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
         subFscolor_Allowcollapsing = 0;
         lblColorsquare_Caption = " ";
         edtavColorname_Jsonclick = "";
         lblColorsquare_Caption = " ";
         subFscolor_Class = "FreeStyleGrid";
         subFscolor_Backcolorstyle = 0;
         lblFontsizelarge_Class = "FontSizeSelectorLarge";
         lblFontsizemedium_Class = "FontSizeSelectorMedium";
         lblFontsizesmall_Class = "FontSizeSelectorSmall";
         radavBackstyle_Jsonclick = "";
         edtavColorname_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSCOLOR_nFirstRecordOnPage"},{"av":"FSCOLOR_nEOF"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV10ColorName","fld":"vCOLORNAME"},{"av":"sPrefix"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"radavBackstyle"},{"av":"AV6BackStyle","fld":"vBACKSTYLE"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"radavBackstyle"},{"av":"AV6BackStyle","fld":"vBACKSTYLE"},{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"lblFontsizesmall_Class","ctrl":"FONTSIZESMALL","prop":"Class"},{"av":"lblFontsizemedium_Class","ctrl":"FONTSIZEMEDIUM","prop":"Class"},{"av":"lblFontsizelarge_Class","ctrl":"FONTSIZELARGE","prop":"Class"}]}""");
         setEventMetadata("FSCOLOR.LOAD","""{"handler":"E173B2","iparms":[{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"AV10ColorName","fld":"vCOLORNAME"}]""");
         setEventMetadata("FSCOLOR.LOAD",""","oparms":[{"av":"AV10ColorName","fld":"vCOLORNAME"},{"av":"lblColorsquare_Caption","ctrl":"COLORSQUARE","prop":"Caption"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true}]}""");
         setEventMetadata("TABLECOLORITEM.CLICK","""{"handler":"E153B2","iparms":[{"av":"FSCOLOR_nFirstRecordOnPage"},{"av":"FSCOLOR_nEOF"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"edtavColorname_Visible","ctrl":"vCOLORNAME","prop":"Visible"},{"av":"AV8ColorItemClass","fld":"vCOLORITEMCLASS","hsh":true},{"av":"AV10ColorName","fld":"vCOLORNAME"},{"av":"radavBackstyle"},{"av":"AV6BackStyle","fld":"vBACKSTYLE"},{"av":"sPrefix"}]""");
         setEventMetadata("TABLECOLORITEM.CLICK",""","oparms":[{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"radavBackstyle"},{"av":"AV6BackStyle","fld":"vBACKSTYLE"},{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"lblFontsizesmall_Class","ctrl":"FONTSIZESMALL","prop":"Class"},{"av":"lblFontsizemedium_Class","ctrl":"FONTSIZEMEDIUM","prop":"Class"},{"av":"lblFontsizelarge_Class","ctrl":"FONTSIZELARGE","prop":"Class"}]}""");
         setEventMetadata("FONTSIZESMALL.CLICK","""{"handler":"E113B2","iparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]""");
         setEventMetadata("FONTSIZESMALL.CLICK",""","oparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"lblFontsizesmall_Class","ctrl":"FONTSIZESMALL","prop":"Class"},{"av":"lblFontsizemedium_Class","ctrl":"FONTSIZEMEDIUM","prop":"Class"},{"av":"lblFontsizelarge_Class","ctrl":"FONTSIZELARGE","prop":"Class"}]}""");
         setEventMetadata("FONTSIZEMEDIUM.CLICK","""{"handler":"E123B2","iparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]""");
         setEventMetadata("FONTSIZEMEDIUM.CLICK",""","oparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"lblFontsizesmall_Class","ctrl":"FONTSIZESMALL","prop":"Class"},{"av":"lblFontsizemedium_Class","ctrl":"FONTSIZEMEDIUM","prop":"Class"},{"av":"lblFontsizelarge_Class","ctrl":"FONTSIZELARGE","prop":"Class"}]}""");
         setEventMetadata("FONTSIZELARGE.CLICK","""{"handler":"E133B2","iparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]""");
         setEventMetadata("FONTSIZELARGE.CLICK",""","oparms":[{"av":"AV11FontSizeSelected","fld":"vFONTSIZESELECTED"},{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"},{"av":"lblFontsizesmall_Class","ctrl":"FONTSIZESMALL","prop":"Class"},{"av":"lblFontsizemedium_Class","ctrl":"FONTSIZEMEDIUM","prop":"Class"},{"av":"lblFontsizelarge_Class","ctrl":"FONTSIZELARGE","prop":"Class"}]}""");
         setEventMetadata("VBACKSTYLE.CONTROLVALUECHANGED","""{"handler":"E143B2","iparms":[{"av":"radavBackstyle"},{"av":"AV6BackStyle","fld":"vBACKSTYLE"}]""");
         setEventMetadata("VBACKSTYLE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV5WWP_DesignSystemSettings","fld":"vWWP_DESIGNSYSTEMSETTINGS"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Colorname","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV5WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         AV8ColorItemClass = "";
         AV10ColorName = "";
         AV6BackStyle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11FontSizeSelected = "";
         GX_FocusControl = "";
         lblColortxt_Jsonclick = "";
         FscolorContainer = new GXWebGrid( context);
         sStyleString = "";
         lblBackstyletxt_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblFontsizetxt_Jsonclick = "";
         lblFontsizesmall_Jsonclick = "";
         lblFontsizemedium_Jsonclick = "";
         lblFontsizelarge_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9ColorItemDefinition = "";
         FscolorRow = new GXWebRow();
         AV7ColorItemBaseClass = "";
         GXt_SdtWWP_DesignSystemSettings1 = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFscolor_Linesclass = "";
         lblColorsquare_Jsonclick = "";
         ROClassString = "";
         subFscolor_Header = "";
         FscolorColumn = new GXWebColumn();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subFscolor_Backcolorstyle ;
      private short FSCOLOR_nEOF ;
      private short subFscolor_Backstyle ;
      private short subFscolor_Allowselection ;
      private short subFscolor_Allowhovering ;
      private short subFscolor_Allowcollapsing ;
      private short subFscolor_Collapsed ;
      private int edtavColorname_Visible ;
      private int nRC_GXsfl_12 ;
      private int subFscolor_Recordcount ;
      private int nGXsfl_12_idx=1 ;
      private int subFscolor_Islastpage ;
      private int idxLst ;
      private int subFscolor_Backcolor ;
      private int subFscolor_Allbackcolor ;
      private int subFscolor_Selectedindex ;
      private int subFscolor_Selectioncolor ;
      private int subFscolor_Hoveringcolor ;
      private long FSCOLOR_nCurrentRecord ;
      private long FSCOLOR_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavColorname_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string lblColortxt_Internalname ;
      private string lblColortxt_Jsonclick ;
      private string sStyleString ;
      private string subFscolor_Internalname ;
      private string lblBackstyletxt_Internalname ;
      private string lblBackstyletxt_Jsonclick ;
      private string radavBackstyle_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavBackstyle_Jsonclick ;
      private string lblFontsizetxt_Internalname ;
      private string lblFontsizetxt_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblFontsizesmall_Internalname ;
      private string lblFontsizesmall_Jsonclick ;
      private string lblFontsizesmall_Class ;
      private string lblFontsizemedium_Internalname ;
      private string lblFontsizemedium_Jsonclick ;
      private string lblFontsizemedium_Class ;
      private string divFontsizelargecell_Internalname ;
      private string lblFontsizelarge_Internalname ;
      private string lblFontsizelarge_Jsonclick ;
      private string lblFontsizelarge_Class ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblColorsquare_Caption ;
      private string lblColorsquare_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subFscolor_Class ;
      private string subFscolor_Linesclass ;
      private string tblUnnamedtablefsfscolor_Internalname ;
      private string divTablecoloritem_Internalname ;
      private string lblColorsquare_Jsonclick ;
      private string tblUnnamedtablecontentfsfscolor_Internalname ;
      private string ROClassString ;
      private string edtavColorname_Jsonclick ;
      private string subFscolor_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV8ColorItemClass ;
      private string AV10ColorName ;
      private string AV6BackStyle ;
      private string AV11FontSizeSelected ;
      private string AV9ColorItemDefinition ;
      private string AV7ColorItemBaseClass ;
      private GXWebGrid FscolorContainer ;
      private GXWebRow FscolorRow ;
      private GXWebColumn FscolorColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavBackstyle ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV5WWP_DesignSystemSettings ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
