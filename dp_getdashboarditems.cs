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
   public class dp_getdashboarditems : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public dp_getdashboarditems( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_getdashboarditems( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDTItem", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDTItem", "Comforta_version21") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Locations", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-map-marker-alt";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("trn_locationww.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "d085396f-788e-4174-bb1c-d2d0832ea599", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Organisation Locations.";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         GXt_char1 = "";
         new prc_getorganisationdefinition(context ).execute(  "Receptionists", out  GXt_char1) ;
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = GXt_char1;
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "far fa-address-card";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_locationreceptionists.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "8b339ea3-0806-4fdc-b87f-6f4b66cf669e", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Receptionisits/Location Managers";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Managers", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "far fa-address-card";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("trn_managerww.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "8b339ea3-0806-4fdc-b87f-6f4b66cf669e", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Location Managers";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Organisations", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fa fal fa-sitemap";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("trn_organisationww.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Comforta Admin";
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Organisations";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Suppliers", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-shipping-fast";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_organisationgeneralsuppliers.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Suppliers";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Forms", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file-alt";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_dynamicform.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Forms";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         GXt_char1 = "";
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char1) ;
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = GXt_char1;
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-users";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "All";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_locationresidents.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Residents";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Agenda", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-calendar-days";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_calendaragenda.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Agenda";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Page Templates", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Comforta Admin";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("trn_templateww.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Page Templates";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Application Design", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-mobile-alt";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_applicationdesign.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1uhomemodulessdt.gxTpr_Optiondescription = "Application Design";
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Notifications", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-bell";
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_notificationdashboard.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "Audit", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-list-ul";
         Gxm1uhomemodulessdt.gxTpr_Rolename = "Organisation Manager";
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("trn_auditww.aspx") ;
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1uhomemodulessdt, 0);
         Gxm1uhomemodulessdt.gxTpr_Optiontitle = context.GetMessage( "My Profile", "");
         Gxm1uhomemodulessdt.gxTpr_Optioniconthemeclass = "far fa-user-circle";
         Gxm1uhomemodulessdt.gxTpr_Optiontype = 1;
         Gxm1uhomemodulessdt.gxTpr_Optionsize = 2;
         Gxm1uhomemodulessdt.gxTpr_Optionwclink = formatLink("wp_userprofile.aspx") ;
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
         Gxm1uhomemodulessdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> Gxm2rootcol ;
      private SdtUHomeModulesSDT_UHomeModulesSDTItem Gxm1uhomemodulessdt ;
      private GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> aP0_Gxm2rootcol ;
   }

}
