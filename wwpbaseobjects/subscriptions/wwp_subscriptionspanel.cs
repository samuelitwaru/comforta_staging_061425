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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscriptionspanel : GXWebComponent
   {
      public wwp_subscriptionspanel( )
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

      public wwp_subscriptionspanel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_RecordAttDescription )
      {
         this.AV6WWPEntityName = aP0_WWPEntityName;
         this.AV7WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV20WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV14RecordAttDescription = aP3_RecordAttDescription;
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
         chkavIncludenotification = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
                  AV6WWPEntityName = GetPar( "WWPEntityName");
                  AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
                  AV7WWPNotificationAppliesTo = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
                  AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
                  AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
                  AV14RecordAttDescription = GetPar( "RecordAttDescription");
                  AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WWPEntityName,(short)AV7WWPNotificationAppliesTo,(string)AV20WWPSubscriptionEntityRecordId,(string)AV14RecordAttDescription});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
         edtWWPNotificationDefinitionId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV5WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
         AV7WWPNotificationAppliesTo = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."), 18, MidpointRounding.ToEven));
         AV25Pgmname = GetPar( "Pgmname");
         edtWWPNotificationDefinitionId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
         n112WWPUserExtendedId = false;
         AV28Udparg1 = GetPar( "Udparg1");
         A132WWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "WWPSubscriptionSubscribed"));
         A124WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
         n124WWPSubscriptionRoleId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV23WWPSubscriptionRoleIdCollection);
         AV8WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         A131WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
         AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
         A130WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
         AV24WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA1Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV25Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
               WS1Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "Subscriptions of an Entity/Record", "")) ;
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
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx"+UrlEncode(StringUtil.RTrim(AV6WWPEntityName)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationAppliesTo,1,0)) + "," + UrlEncode(StringUtil.RTrim(AV20WWPSubscriptionEntityRecordId)) + "," + UrlEncode(StringUtil.RTrim(AV14RecordAttDescription));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV28Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Udparg1, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WWPEntityName", wcpOAV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPNotificationAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPNotificationAppliesTo), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId", wcpOAV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14RecordAttDescription", wcpOAV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV28Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Udparg1, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONSUBSCRIBED", A132WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A124WWPSubscriptionRoleId));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONENTITYRECORDID", A131WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID", AV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A130WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECORDATTDESCRIPTION", AV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYNAME", AV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONAPPLIESTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONSECFU", A172WWPNotificationDefinitionSecFu);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONISAUT", A173WWPNotificationDefinitionIsAut);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1Q2( )
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
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Subscriptions of an Entity/Record", "") ;
      }

      protected void WB1Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainSubscriptions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SubscriptionsPanelCell", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Subscriptions of an Entity/Record", ""), 0) ;
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
               STRUP1Q0( ) ;
            }
         }
      }

      protected void WS1Q2( )
      {
         START1Q2( ) ;
         EVT1Q2( ) ;
      }

      protected void EVT1Q2( )
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
                                 STRUP1Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablesubscriptionitem.Click */
                                    E111Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavIncludenotification_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Q0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "TABLESUBSCRIPTIONITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Q0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
                              AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
                              A134WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
                              A128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                                 GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22WWPSubscriptionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
                              }
                              else
                              {
                                 AV22WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
                              }
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E121Q2 ();
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E131Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E141Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Tablesubscriptionitem.Click */
                                          E111Q2 ();
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
                                       STRUP1Q0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
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

      protected void WE1Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1Q2( ) ;
            }
         }
      }

      protected void PA1Q2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx")), "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx")))) ;
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
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WWPEntityName");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       long AV5WWPEntityId ,
                                       short AV7WWPNotificationAppliesTo ,
                                       string AV25Pgmname ,
                                       string A112WWPUserExtendedId ,
                                       string AV28Udparg1 ,
                                       bool A132WWPSubscriptionSubscribed ,
                                       string A124WWPSubscriptionRoleId ,
                                       GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                       long AV8WWPNotificationId ,
                                       string A131WWPSubscriptionEntityRecordId ,
                                       string AV20WWPSubscriptionEntityRecordId ,
                                       long A130WWPSubscriptionId ,
                                       long AV24WWPNotificationDefinitionId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1Q2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", "")));
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
         RF1Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV25Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         /* Using cursor H001Q2 */
         pr_default.execute(0, new Object[] {AV7WWPNotificationAppliesTo, AV5WWPEntityId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A136WWPNotificationDefinitionAllow = H001Q2_A136WWPNotificationDefinitionAllow[0];
            A135WWPNotificationDefinitionAppli = H001Q2_A135WWPNotificationDefinitionAppli[0];
            A125WWPEntityId = H001Q2_A125WWPEntityId[0];
            A128WWPNotificationDefinitionId = H001Q2_A128WWPNotificationDefinitionId[0];
            A134WWPNotificationDefinitionDescr = H001Q2_A134WWPNotificationDefinitionDescr[0];
            A172WWPNotificationDefinitionSecFu = H001Q2_A172WWPNotificationDefinitionSecFu[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
            {
               A173WWPNotificationDefinitionIsAut = true;
               AssignAttri(sPrefix, false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
            }
            else
            {
               GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A173WWPNotificationDefinitionIsAut = GXt_boolean1;
               AssignAttri(sPrefix, false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
            }
            if ( A173WWPNotificationDefinitionIsAut )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF1Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E131Q2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Using cursor H001Q3 */
            pr_default.execute(1, new Object[] {AV7WWPNotificationAppliesTo, AV5WWPEntityId});
            nGXsfl_9_idx = 1;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A136WWPNotificationDefinitionAllow = H001Q3_A136WWPNotificationDefinitionAllow[0];
               A135WWPNotificationDefinitionAppli = H001Q3_A135WWPNotificationDefinitionAppli[0];
               A125WWPEntityId = H001Q3_A125WWPEntityId[0];
               A128WWPNotificationDefinitionId = H001Q3_A128WWPNotificationDefinitionId[0];
               A134WWPNotificationDefinitionDescr = H001Q3_A134WWPNotificationDefinitionDescr[0];
               A172WWPNotificationDefinitionSecFu = H001Q3_A172WWPNotificationDefinitionSecFu[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
               {
                  A173WWPNotificationDefinitionIsAut = true;
                  AssignAttri(sPrefix, false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
               }
               else
               {
                  GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
                  new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
                  A173WWPNotificationDefinitionIsAut = GXt_boolean1;
                  AssignAttri(sPrefix, false, "A173WWPNotificationDefinitionIsAut", A173WWPNotificationDefinitionIsAut);
               }
               if ( A173WWPNotificationDefinitionIsAut )
               {
                  /* Execute user event: Grid.Load */
                  E141Q2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 9;
            WB1Q0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1Q2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV28Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Udparg1, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPNOTIFICATIONDEFINITIONID"+"_"+sGXsfl_9_idx, GetSecureSignedToken( sPrefix+sGXsfl_9_idx, context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV25Pgmname, A112WWPUserExtendedId, AV28Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A131WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A130WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV25Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         edtWWPNotificationDefinitionId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
            wcpOAV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
            wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E121Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E121Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtWWPNotificationDefinitionId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_int2 = AV5WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV6WWPEntityName, out  GXt_int2) ;
         AV5WWPEntityId = GXt_int2;
         AssignAttri(sPrefix, false, "AV5WWPEntityId", StringUtil.LTrimStr( (decimal)(AV5WWPEntityId), 10, 0));
         GXt_objcol_char3 = AV23WWPSubscriptionRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles(context ).execute( out  GXt_objcol_char3) ;
         AV23WWPSubscriptionRoleIdCollection = GXt_objcol_char3;
      }

      protected void E131Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E141Q2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV8WWPNotificationId = A128WWPNotificationDefinitionId;
            AssignAttri(sPrefix, false, "AV8WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV8WWPNotificationId), 10, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
            /* Execute user subroutine: 'LOADCHECKINCLUDENOTIFICATIONS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV25Pgmname+"GridState"), "") == 0 )
         {
            AV9GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV25Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV9GridState.FromXml(AV16Session.Get(AV25Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV9GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV9GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV9GridState.FromXml(AV16Session.Get(AV25Pgmname+"GridState"), null, "", "");
         AV9GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV25Pgmname+"GridState",  AV9GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV17TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV17TrnContext.gxTpr_Callerobject = AV25Pgmname;
         AV17TrnContext.gxTpr_Callerondelete = true;
         AV17TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV17TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition";
         AV16Session.Set("TrnContext", AV17TrnContext.ToXml(false, true, "", ""));
      }

      protected void E111Q2( )
      {
         /* Tablesubscriptionitem_Click Routine */
         returnInSub = false;
         AV12IncludeNotification = (bool)(!AV12IncludeNotification);
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription(context ).execute(  AV12IncludeNotification, ref  AV22WWPSubscriptionId,  A128WWPNotificationDefinitionId,  AV20WWPSubscriptionEntityRecordId,  AV14RecordAttDescription) ;
         AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
         if ( 1 == 0 )
         {
            /* Start For Each Line */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_9_fel_idx = 0;
            while ( nGXsfl_9_fel_idx < nRC_GXsfl_9 )
            {
               nGXsfl_9_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_fel_idx+1);
               sGXsfl_9_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_92( ) ;
               AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
               A134WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
               A128WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                  GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                  wbErr = true;
                  AV22WWPSubscriptionId = 0;
               }
               else
               {
                  AV22WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               }
               /* End For Each Line */
            }
            if ( nGXsfl_9_fel_idx == 0 )
            {
               nGXsfl_9_idx = 1;
               sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
               SubsflControlProps_92( ) ;
            }
            nGXsfl_9_fel_idx = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCHECKINCLUDENOTIFICATIONS' Routine */
         returnInSub = false;
         AV12IncludeNotification = false;
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         AV28Udparg1 = new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A124WWPSubscriptionRoleId ,
                                              AV23WWPSubscriptionRoleIdCollection ,
                                              AV20WWPSubscriptionEntityRecordId ,
                                              A131WWPSubscriptionEntityRecordId ,
                                              A112WWPUserExtendedId ,
                                              AV28Udparg1 ,
                                              A132WWPSubscriptionSubscribed ,
                                              AV8WWPNotificationId ,
                                              A128WWPNotificationDefinitionId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H001Q4 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId, AV28Udparg1, AV20WWPSubscriptionEntityRecordId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A131WWPSubscriptionEntityRecordId = H001Q4_A131WWPSubscriptionEntityRecordId[0];
            A128WWPNotificationDefinitionId = H001Q4_A128WWPNotificationDefinitionId[0];
            A124WWPSubscriptionRoleId = H001Q4_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = H001Q4_n124WWPSubscriptionRoleId[0];
            A132WWPSubscriptionSubscribed = H001Q4_A132WWPSubscriptionSubscribed[0];
            A112WWPUserExtendedId = H001Q4_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = H001Q4_n112WWPUserExtendedId[0];
            A130WWPSubscriptionId = H001Q4_A130WWPSubscriptionId[0];
            AV22WWPSubscriptionId = A130WWPSubscriptionId;
            AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
            AV12IncludeNotification = true;
            AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A124WWPSubscriptionRoleId)) )
            {
               GXt_boolean1 = AV12IncludeNotification;
               new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed(context ).execute(  AV24WWPNotificationDefinitionId, ref  AV22WWPSubscriptionId, ref  GXt_boolean1) ;
               AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
               AV12IncludeNotification = GXt_boolean1;
               AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WWPEntityName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         AV14RecordAttDescription = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
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
         PA1Q2( ) ;
         WS1Q2( ) ;
         WE1Q2( ) ;
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
         sCtrlAV6WWPEntityName = (string)((string)getParm(obj,0));
         sCtrlAV7WWPNotificationAppliesTo = (string)((string)getParm(obj,1));
         sCtrlAV20WWPSubscriptionEntityRecordId = (string)((string)getParm(obj,2));
         sCtrlAV14RecordAttDescription = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\subscriptions\\wwp_subscriptionspanel", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WWPEntityName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
            AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
            AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
            AV14RecordAttDescription = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
         wcpOAV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
         wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WWPEntityName, wcpOAV6WWPEntityName) != 0 ) || ( AV7WWPNotificationAppliesTo != wcpOAV7WWPNotificationAppliesTo ) || ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, wcpOAV20WWPSubscriptionEntityRecordId) != 0 ) || ( StringUtil.StrCmp(AV14RecordAttDescription, wcpOAV14RecordAttDescription) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WWPEntityName = AV6WWPEntityName;
         wcpOAV7WWPNotificationAppliesTo = AV7WWPNotificationAppliesTo;
         wcpOAV20WWPSubscriptionEntityRecordId = AV20WWPSubscriptionEntityRecordId;
         wcpOAV14RecordAttDescription = AV14RecordAttDescription;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_CTRL");
         if ( StringUtil.Len( sCtrlAV6WWPEntityName) > 0 )
         {
            AV6WWPEntityName = cgiGet( sCtrlAV6WWPEntityName);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         }
         else
         {
            AV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_PARM");
         }
         sCtrlAV7WWPNotificationAppliesTo = cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPNotificationAppliesTo) > 0 )
         {
            AV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPNotificationAppliesTo), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         }
         else
         {
            AV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL");
         if ( StringUtil.Len( sCtrlAV20WWPSubscriptionEntityRecordId) > 0 )
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sCtrlAV20WWPSubscriptionEntityRecordId);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         }
         else
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM");
         }
         sCtrlAV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV14RecordAttDescription) > 0 )
         {
            AV14RecordAttDescription = cgiGet( sCtrlAV14RecordAttDescription);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         else
         {
            AV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_PARM");
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
         INITWEB( ) ;
         nDraw = 0;
         PA1Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1Q2( ) ;
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
         WS1Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_PARM", AV6WWPEntityName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WWPEntityName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_CTRL", StringUtil.RTrim( sCtrlAV6WWPEntityName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_CTRL", StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM", AV20WWPSubscriptionEntityRecordId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL", StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_PARM", AV14RecordAttDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14RecordAttDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_CTRL", StringUtil.RTrim( sCtrlAV14RecordAttDescription));
         }
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
         WE1Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309403447", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionspanel.js", "?20256309403448", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionDescr_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCR_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionDescr_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCR_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_fel_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB1Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_9_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SubscriptionItem",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablesubscriptionitem_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,context.GetMessage( "Include Notification", ""),(string)"gx-form-item AttributeCheckBoxLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
            chkavIncludenotification.Name = GXCCtl;
            chkavIncludenotification.WebTags = "";
            chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
            AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
            chkavIncludenotification.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,StringUtil.BoolToStr( AV12IncludeNotification),(string)"",context.GetMessage( "Include Notification", ""),(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(16, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,16);\""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescr_Internalname,context.GetMessage( "Notification Definition Description", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescr_Internalname,(string)A134WWPNotificationDefinitionDescr,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,context.GetMessage( "Notification Definition Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128WWPNotificationDefinitionId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationDefinitionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationDefinitionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"WorkWithPlus_Web\\WWP_Id",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,context.GetMessage( "WWPSubscription Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22WWPSubscriptionId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,29);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpsubscriptionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpsubscriptionid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            send_integrity_lvl_hashes1Q2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
         chkavIncludenotification.Name = GXCCtl;
         chkavIncludenotification.WebTags = "";
         chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
         AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
         chkavIncludenotification.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV12IncludeNotification)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A134WWPNotificationDefinitionDescr));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION";
         edtWWPNotificationDefinitionDescr_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCR";
         divTablesubscriptionitem_Internalname = sPrefix+"TABLESUBSCRIPTIONITEM";
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID";
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         edtavWwpsubscriptionid_Jsonclick = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
         subGrid_Class = "FreeStyleGrid";
         edtWWPNotificationDefinitionId_Enabled = 0;
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         subGrid_Backcolorstyle = 0;
         edtavWwpsubscriptionid_Visible = 1;
         edtWWPNotificationDefinitionId_Visible = 1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"sPrefix"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E141Q2","iparms":[{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION"},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK","""{"handler":"E111Q2","iparms":[{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION","grid":9},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_9","ctrl":"GRID","grid":9,"prop":"GridRC","grid":9},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","grid":9,"pic":"ZZZZZZZZZ9"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","grid":9,"pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV14RecordAttDescription","fld":"vRECORDATTDESCRIPTION"}]""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK",""","oparms":[{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION"},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV25Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV25Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV25Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV28Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV25Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Wwpsubscriptionid","iparms":[]}""");
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
         wcpOAV6WWPEntityName = "";
         wcpOAV20WWPSubscriptionEntityRecordId = "";
         wcpOAV14RecordAttDescription = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV25Pgmname = "";
         A112WWPUserExtendedId = "";
         AV28Udparg1 = "";
         A124WWPSubscriptionRoleId = "";
         AV23WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         A131WWPSubscriptionEntityRecordId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A172WWPNotificationDefinitionSecFu = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A134WWPNotificationDefinitionDescr = "";
         GXDecQS = "";
         H001Q2_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         H001Q2_A135WWPNotificationDefinitionAppli = new short[1] ;
         H001Q2_A125WWPEntityId = new long[1] ;
         H001Q2_A128WWPNotificationDefinitionId = new long[1] ;
         H001Q2_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         H001Q2_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         H001Q3_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         H001Q3_A135WWPNotificationDefinitionAppli = new short[1] ;
         H001Q3_A125WWPEntityId = new long[1] ;
         H001Q3_A128WWPNotificationDefinitionId = new long[1] ;
         H001Q3_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         H001Q3_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         GXt_objcol_char3 = new GxSimpleCollection<string>();
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV9GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV17TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         H001Q4_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         H001Q4_A128WWPNotificationDefinitionId = new long[1] ;
         H001Q4_A124WWPSubscriptionRoleId = new string[] {""} ;
         H001Q4_n124WWPSubscriptionRoleId = new bool[] {false} ;
         H001Q4_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         H001Q4_A112WWPUserExtendedId = new string[] {""} ;
         H001Q4_n112WWPUserExtendedId = new bool[] {false} ;
         H001Q4_A130WWPSubscriptionId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WWPEntityName = "";
         sCtrlAV7WWPNotificationAppliesTo = "";
         sCtrlAV20WWPSubscriptionEntityRecordId = "";
         sCtrlAV14RecordAttDescription = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionspanel__default(),
            new Object[][] {
                new Object[] {
               H001Q2_A136WWPNotificationDefinitionAllow, H001Q2_A135WWPNotificationDefinitionAppli, H001Q2_A125WWPEntityId, H001Q2_A128WWPNotificationDefinitionId, H001Q2_A134WWPNotificationDefinitionDescr, H001Q2_A172WWPNotificationDefinitionSecFu
               }
               , new Object[] {
               H001Q3_A136WWPNotificationDefinitionAllow, H001Q3_A135WWPNotificationDefinitionAppli, H001Q3_A125WWPEntityId, H001Q3_A128WWPNotificationDefinitionId, H001Q3_A134WWPNotificationDefinitionDescr, H001Q3_A172WWPNotificationDefinitionSecFu
               }
               , new Object[] {
               H001Q4_A131WWPSubscriptionEntityRecordId, H001Q4_A128WWPNotificationDefinitionId, H001Q4_A124WWPSubscriptionRoleId, H001Q4_n124WWPSubscriptionRoleId, H001Q4_A132WWPSubscriptionSubscribed, H001Q4_A112WWPUserExtendedId, H001Q4_n112WWPUserExtendedId, H001Q4_A130WWPSubscriptionId
               }
            }
         );
         AV25Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         /* GeneXus formulas. */
         AV25Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
      }

      private short AV7WWPNotificationAppliesTo ;
      private short wcpOAV7WWPNotificationAppliesTo ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A135WWPNotificationDefinitionAppli ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtWWPNotificationDefinitionId_Visible ;
      private int edtavWwpsubscriptionid_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGrid_Islastpage ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int nGXsfl_9_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV5WWPEntityId ;
      private long AV8WWPNotificationId ;
      private long A130WWPSubscriptionId ;
      private long AV24WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private long AV22WWPSubscriptionId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long A125WWPEntityId ;
      private long GXt_int2 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtavWwpsubscriptionid_Internalname ;
      private string AV25Pgmname ;
      private string A112WWPUserExtendedId ;
      private string AV28Udparg1 ;
      private string A124WWPSubscriptionRoleId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIncludenotification_Internalname ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string sCtrlAV6WWPEntityName ;
      private string sCtrlAV7WWPNotificationAppliesTo ;
      private string sCtrlAV20WWPSubscriptionEntityRecordId ;
      private string sCtrlAV14RecordAttDescription ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablesubscriptionitem_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtavWwpsubscriptionid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool n112WWPUserExtendedId ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n124WWPSubscriptionRoleId ;
      private bool A173WWPNotificationDefinitionIsAut ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV12IncludeNotification ;
      private bool A136WWPNotificationDefinitionAllow ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV6WWPEntityName ;
      private string AV20WWPSubscriptionEntityRecordId ;
      private string AV14RecordAttDescription ;
      private string wcpOAV6WWPEntityName ;
      private string wcpOAV20WWPSubscriptionEntityRecordId ;
      private string wcpOAV14RecordAttDescription ;
      private string A131WWPSubscriptionEntityRecordId ;
      private string A172WWPNotificationDefinitionSecFu ;
      private string A134WWPNotificationDefinitionDescr ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIncludenotification ;
      private GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] H001Q2_A136WWPNotificationDefinitionAllow ;
      private short[] H001Q2_A135WWPNotificationDefinitionAppli ;
      private long[] H001Q2_A125WWPEntityId ;
      private long[] H001Q2_A128WWPNotificationDefinitionId ;
      private string[] H001Q2_A134WWPNotificationDefinitionDescr ;
      private string[] H001Q2_A172WWPNotificationDefinitionSecFu ;
      private bool[] H001Q3_A136WWPNotificationDefinitionAllow ;
      private short[] H001Q3_A135WWPNotificationDefinitionAppli ;
      private long[] H001Q3_A125WWPEntityId ;
      private long[] H001Q3_A128WWPNotificationDefinitionId ;
      private string[] H001Q3_A134WWPNotificationDefinitionDescr ;
      private string[] H001Q3_A172WWPNotificationDefinitionSecFu ;
      private GxSimpleCollection<string> GXt_objcol_char3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV9GridState ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV17TrnContext ;
      private string[] H001Q4_A131WWPSubscriptionEntityRecordId ;
      private long[] H001Q4_A128WWPNotificationDefinitionId ;
      private string[] H001Q4_A124WWPSubscriptionRoleId ;
      private bool[] H001Q4_n124WWPSubscriptionRoleId ;
      private bool[] H001Q4_A132WWPSubscriptionSubscribed ;
      private string[] H001Q4_A112WWPUserExtendedId ;
      private bool[] H001Q4_n112WWPUserExtendedId ;
      private long[] H001Q4_A130WWPSubscriptionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_subscriptionspanel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001Q4( IGxContext context ,
                                             string A124WWPSubscriptionRoleId ,
                                             GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                             string AV20WWPSubscriptionEntityRecordId ,
                                             string A131WWPSubscriptionEntityRecordId ,
                                             string A112WWPUserExtendedId ,
                                             string AV28Udparg1 ,
                                             bool A132WWPSubscriptionSubscribed ,
                                             long AV8WWPNotificationId ,
                                             long A128WWPNotificationDefinitionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT WWPSubscriptionEntityRecordId, WWPNotificationDefinitionId, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPUserExtendedId, WWPSubscriptionId FROM WWP_Subscription";
         AddWhere(sWhereString, "(WWPNotificationDefinitionId = :AV8WWPNotificationId)");
         AddWhere(sWhereString, "(( WWPUserExtendedId = ( :AV28Udparg1) and WWPSubscriptionSubscribed) or "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23WWPSubscriptionRoleIdCollection, "WWPSubscriptionRoleId IN (", ")")+")");
         if ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, "") != 0 )
         {
            AddWhere(sWhereString, "(WWPSubscriptionEntityRecordId = ( :AV20WWPSubscriptionEntityRecordId))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPNotificationDefinitionId";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H001Q4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001Q2;
          prmH001Q2 = new Object[] {
          new ParDef("AV7WWPNotificationAppliesTo",GXType.Int16,1,0) ,
          new ParDef("AV5WWPEntityId",GXType.Int64,10,0)
          };
          Object[] prmH001Q3;
          prmH001Q3 = new Object[] {
          new ParDef("AV7WWPNotificationAppliesTo",GXType.Int16,1,0) ,
          new ParDef("AV5WWPEntityId",GXType.Int64,10,0)
          };
          Object[] prmH001Q4;
          prmH001Q4 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV28Udparg1",GXType.Char,40,0) ,
          new ParDef("AV20WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001Q2", "SELECT WWPNotificationDefinitionAllow, WWPNotificationDefinitionAppli, WWPEntityId, WWPNotificationDefinitionId, WWPNotificationDefinitionDescr, WWPNotificationDefinitionSecFu FROM WWP_NotificationDefinition WHERE (WWPNotificationDefinitionAllow = TRUE) AND (WWPNotificationDefinitionAppli = :AV7WWPNotificationAppliesTo) AND (WWPEntityId = :AV5WWPEntityId) ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Q3", "SELECT WWPNotificationDefinitionAllow, WWPNotificationDefinitionAppli, WWPEntityId, WWPNotificationDefinitionId, WWPNotificationDefinitionDescr, WWPNotificationDefinitionSecFu FROM WWP_NotificationDefinition WHERE (WWPNotificationDefinitionAllow = TRUE) AND (WWPNotificationDefinitionAppli = :AV7WWPNotificationAppliesTo) AND (WWPEntityId = :AV5WWPEntityId) ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Q4,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 40);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
