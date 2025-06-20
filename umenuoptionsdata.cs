using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class umenuoptionsdata : GXProcedure
   {
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

      public umenuoptionsdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public umenuoptionsdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         GXt_char1 = AV10ResidentTitle;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char1) ;
         AV10ResidentTitle = GXt_char1;
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("uhome.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Dashboard", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "uhome_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_receptionistdashboard.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Dashboard", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_receptionistdashboard_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_notificationdashboard.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-bell";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Notifications", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_notificationdashboard_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_calendaragenda.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-calendar-days";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Agenda", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_calendaragenda_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_organisationww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-sitemap";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Organisations", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_organisationww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_managerww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon far fa-address-card";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Managers", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_managerww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_locationww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-map-marker-alt";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Locations", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_locationww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_locationreceptionists.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon far fa-address-card";
         GXt_char1 = "";
         new prc_getorganisationdefinition(context ).execute(  "Receptionists", out  GXt_char1) ;
         Gxm1dvelop_menu.gxTpr_Caption = GXt_char1;
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_locationreceptionists_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_locationresidents.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-users";
         GXt_char1 = "";
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char1) ;
         Gxm1dvelop_menu.gxTpr_Caption = GXt_char1;
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_locationresidents_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_organisationgeneralsuppliers.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-shipping-fast";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Suppliers", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_organisationgeneralsuppliers_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_memoww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-note-sticky";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Memos", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_memoww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_dynamicform.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-file";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Forms", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_dynamicform_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_auditww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-list-ul";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Audit", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_auditww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-cog";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Settings", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         GXt_guid2 = Guid.Empty;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_organisation.aspx"+GXUtil.UrlEncode(StringUtil.RTrim("DSP")) + "," + GXUtil.UrlEncode(GXt_guid2.ToString());
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_organisation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Organisation", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wp_organisationdefinitions.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Prompts", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "wp_organisationdefinitions_Execute", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_organisationtypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Organisation Types", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "trn_organisationtypeww_Execute", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_medicalindicationww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Medical Indications", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "trn_medicalindicationww_Execute", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_residenttypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = AV10ResidentTitle+" "+context.GetMessage( "Types", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "trn_residenttypeww_Execute", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_suppliergentypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Supplier Types", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "trn_suppliergentypeww_Execute", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_residentpackageww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = AV10ResidentTitle+" "+context.GetMessage( "Access", "");
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trn_memocategoryww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "Memo Categories", "");
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = context.GetMessage( "trn_memocategoryww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_templateww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-file";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Page Templates", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_templateww_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wp_applicationdesign.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-mobile-alt";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "App Builder", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "wp_applicationdesign_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         GXt_char1 = "";
         new prc_organizationsettingtrnmode(context ).execute( out  GXt_char1) ;
         GXt_guid2 = Guid.Empty;
         new prc_organizationsettingid(context ).execute( out  GXt_guid2) ;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_organisationsetting.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(GXt_char1)) + "," + GXUtil.UrlEncode(GXt_guid2.ToString());
         Gxm1dvelop_menu.gxTpr_Link = formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-eye-dropper";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "Customization", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = context.GetMessage( "trn_organisationsetting_Execute", "");
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = context.GetMessage( "WWP_GAM_SecurityOfTheApplication", "");
         Gxm1dvelop_menu.gxTpr_Link = formatLink(context.GetMessage( "gam_dashboard.aspx", "")) ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "_blank";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "WWP_GAM_GAMSecurity", "");
         Gxm1dvelop_menu.gxTpr_Authorizationkey = "is_gam_administrator";
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10ResidentTitle = "";
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         GXKey = "";
         GXEncryptionTmp = "";
         GXt_char1 = "";
         GXt_guid2 = Guid.Empty;
         /* GeneXus formulas. */
      }

      private short AV5id ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char1 ;
      private string AV10ResidentTitle ;
      private Guid GXt_guid2 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item Gxm3dvelop_menu_subitems ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
   }

}
