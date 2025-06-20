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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_loadwwpcontext : GXProcedure
   {
      public prc_loadwwpcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loadwwpcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext )
      {
         this.AV18WWPContext = aP0_WWPContext;
         initialize();
         ExecuteImpl();
         aP0_WWPContext=this.AV18WWPContext;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPContext executeUdp( )
      {
         execute(ref aP0_WWPContext);
         return AV18WWPContext ;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext )
      {
         this.AV18WWPContext = aP0_WWPContext;
         SubmitImpl();
         aP0_WWPContext=this.AV18WWPContext;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV16GAMErrors);
         AV9GAMUser.load( AV8GAMSession.gxTpr_User.gxTpr_Guid);
         AV18WWPContext.gxTpr_Gamuserguid = AV9GAMUser.gxTpr_Guid;
         AV18WWPContext.gxTpr_Gamusername = AV9GAMUser.gxTpr_Name;
         AV18WWPContext.gxTpr_Gamuserfirstname = AV9GAMUser.gxTpr_Firstname;
         AV18WWPContext.gxTpr_Gamuserlastname = AV9GAMUser.gxTpr_Lastname;
         AV18WWPContext.gxTpr_Gamuseremail = AV9GAMUser.gxTpr_Email;
         AV18WWPContext.gxTpr_Gamuserphone = AV9GAMUser.gxTpr_Phone;
         if ( AV9GAMUser.checkrole("Comforta Admin") )
         {
            AV11UserRoleName = "Comforta Admin";
            AV18WWPContext.gxTpr_Iscomfortaadmin = true;
         }
         if ( AV9GAMUser.checkrole("Resident") )
         {
            AV11UserRoleName = "Resident";
            AV18WWPContext.gxTpr_Isresident = true;
            /* Using cursor P008N2 */
            pr_default.execute(0, new Object[] {AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A71ResidentGUID = P008N2_A71ResidentGUID[0];
               A11OrganisationId = P008N2_A11OrganisationId[0];
               A29LocationId = P008N2_A29LocationId[0];
               A62ResidentId = P008N2_A62ResidentId[0];
               A40000ResidentImage_GXI = P008N2_A40000ResidentImage_GXI[0];
               n40000ResidentImage_GXI = P008N2_n40000ResidentImage_GXI[0];
               A432ResidentHomePhoneNumber = P008N2_A432ResidentHomePhoneNumber[0];
               A431ResidentHomePhoneCode = P008N2_A431ResidentHomePhoneCode[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Residentid = A62ResidentId;
               AV18WWPContext.gxTpr_Profileurl = A40000ResidentImage_GXI;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18WWPContext.gxTpr_Gamuserphone)) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A431ResidentHomePhoneCode)) && ! String.IsNullOrEmpty(StringUtil.RTrim( A432ResidentHomePhoneNumber)) )
                  {
                     AV18WWPContext.gxTpr_Gamuserphone = A431ResidentHomePhoneCode+"~"+A432ResidentHomePhoneNumber;
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV9GAMUser.checkrole("Root Admin") )
         {
            AV18WWPContext.gxTpr_Isrootadmin = true;
         }
         if ( AV9GAMUser.checkrole("Organisation Manager") )
         {
            AV11UserRoleName = "Organisation Manager";
            AV18WWPContext.gxTpr_Isorganisationmanager = true;
            /* Using cursor P008N3 */
            pr_default.execute(1, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A25ManagerEmail = P008N3_A25ManagerEmail[0];
               A28ManagerGAMGUID = P008N3_A28ManagerGAMGUID[0];
               A11OrganisationId = P008N3_A11OrganisationId[0];
               A21ManagerId = P008N3_A21ManagerId[0];
               A332ManagerIsMainManager = P008N3_A332ManagerIsMainManager[0];
               A365ManagerIsActive = P008N3_A365ManagerIsActive[0];
               A40001ManagerImage_GXI = P008N3_A40001ManagerImage_GXI[0];
               A358ManagerPhoneNumber = P008N3_A358ManagerPhoneNumber[0];
               A357ManagerPhoneCode = P008N3_A357ManagerPhoneCode[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Managerid = A21ManagerId;
               AV18WWPContext.gxTpr_Managerismainmanager = A332ManagerIsMainManager;
               AV18WWPContext.gxTpr_Managerisactive = A365ManagerIsActive;
               AV18WWPContext.gxTpr_Profileurl = A40001ManagerImage_GXI;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18WWPContext.gxTpr_Gamuserphone)) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A357ManagerPhoneCode)) && ! String.IsNullOrEmpty(StringUtil.RTrim( A358ManagerPhoneNumber)) )
                  {
                     AV18WWPContext.gxTpr_Gamuserphone = A357ManagerPhoneCode+"~"+A358ManagerPhoneNumber;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV9GAMUser.checkrole("Receptionist") )
         {
            AV11UserRoleName = "Receptionist";
            AV18WWPContext.gxTpr_Isreceptionist = true;
            /* Using cursor P008N4 */
            pr_default.execute(2, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A93ReceptionistEmail = P008N4_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P008N4_A95ReceptionistGAMGUID[0];
               A11OrganisationId = P008N4_A11OrganisationId[0];
               A29LocationId = P008N4_A29LocationId[0];
               A89ReceptionistId = P008N4_A89ReceptionistId[0];
               A40002ReceptionistImage_GXI = P008N4_A40002ReceptionistImage_GXI[0];
               A346ReceptionistPhoneNumber = P008N4_A346ReceptionistPhoneNumber[0];
               A345ReceptionistPhoneCode = P008N4_A345ReceptionistPhoneCode[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Receptionistid = A89ReceptionistId;
               AV18WWPContext.gxTpr_Profileurl = A40002ReceptionistImage_GXI;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18WWPContext.gxTpr_Gamuserphone)) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A345ReceptionistPhoneCode)) && ! String.IsNullOrEmpty(StringUtil.RTrim( A346ReceptionistPhoneNumber)) )
                  {
                     AV18WWPContext.gxTpr_Gamuserphone = A345ReceptionistPhoneCode+"~"+A346ReceptionistPhoneNumber;
                  }
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         /* Using cursor P008N5 */
         pr_default.execute(3, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11OrganisationId = P008N5_A11OrganisationId[0];
            A13OrganisationName = P008N5_A13OrganisationName[0];
            AV18WWPContext.gxTpr_Organisationid = A11OrganisationId;
            AV18WWPContext.gxTpr_Organisationname = A13OrganisationName;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         /* Using cursor P008N6 */
         pr_default.execute(4, new Object[] {AV10LocationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A29LocationId = P008N6_A29LocationId[0];
            A31LocationName = P008N6_A31LocationName[0];
            A11OrganisationId = P008N6_A11OrganisationId[0];
            AV18WWPContext.gxTpr_Locationid = A29LocationId;
            AV18WWPContext.gxTpr_Locationname = A31LocationName;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV24GXLvl93 = 0;
         /* Using cursor P008N7 */
         pr_default.execute(5, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A11OrganisationId = P008N7_A11OrganisationId[0];
            A40003OrganisationSettingLogo_GXI = P008N7_A40003OrganisationSettingLogo_GXI[0];
            A40004OrganisationSettingFavicon_GXI = P008N7_A40004OrganisationSettingFavicon_GXI[0];
            A100OrganisationSettingid = P008N7_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = P008N7_A103OrganisationSettingBaseColor[0];
            A104OrganisationSettingFontSize = P008N7_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = P008N7_A105OrganisationSettingLanguage[0];
            A510OrganisationHasMyCare = P008N7_A510OrganisationHasMyCare[0];
            A511OrganisationHasMyLiving = P008N7_A511OrganisationHasMyLiving[0];
            A512OrganisationHasMyServices = P008N7_A512OrganisationHasMyServices[0];
            A513OrganisationHasDynamicForms = P008N7_A513OrganisationHasDynamicForms[0];
            A514OrganisationBrandTheme = P008N7_A514OrganisationBrandTheme[0];
            A515OrganisationCtaTheme = P008N7_A515OrganisationCtaTheme[0];
            A101OrganisationSettingLogo = P008N7_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = P008N7_A102OrganisationSettingFavicon[0];
            AV24GXLvl93 = 1;
            AV18WWPContext.gxTpr_Organisationsettingid = A100OrganisationSettingid;
            AV18WWPContext.gxTpr_Organisationsettinglogo = A101OrganisationSettingLogo;
            AV18WWPContext.gxTpr_Organisationsettinglogo_gxi = A40003OrganisationSettingLogo_GXI;
            AV18WWPContext.gxTpr_Organisationsettingfavicon = A102OrganisationSettingFavicon;
            AV18WWPContext.gxTpr_Organisationsettingfavicon_gxi = A40004OrganisationSettingFavicon_GXI;
            AV18WWPContext.gxTpr_Organisationsettingbasecolor = A103OrganisationSettingBaseColor;
            AV18WWPContext.gxTpr_Organisationsettingfontsize = A104OrganisationSettingFontSize;
            AV18WWPContext.gxTpr_Organisationsettinglanguage = A105OrganisationSettingLanguage;
            AV18WWPContext.gxTpr_Organisationsettingtrnmode = "UPD";
            AV18WWPContext.gxTpr_Organisationhasmycare = A510OrganisationHasMyCare;
            AV18WWPContext.gxTpr_Organisationhasmyliving = A511OrganisationHasMyLiving;
            AV18WWPContext.gxTpr_Organisationhasmyservices = A512OrganisationHasMyServices;
            AV18WWPContext.gxTpr_Organisationhasdynamicforms = A513OrganisationHasDynamicForms;
            AV18WWPContext.gxTpr_Organisationbrandtheme = A514OrganisationBrandTheme;
            AV18WWPContext.gxTpr_Organisationctatheme = A515OrganisationCtaTheme;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( AV24GXLvl93 == 0 )
         {
            AV18WWPContext.gxTpr_Organisationsettingbasecolor = "Teal";
            AV18WWPContext.gxTpr_Organisationsettingfontsize = "Medium";
            AV18WWPContext.gxTpr_Organisationsettingtrnmode = "INS";
         }
         GXt_objcol_SdtUHomeModulesSDT_UHomeModulesSDTItem1 = AV13DashboardItems;
         new dp_getdashboarditems(context ).execute( out  GXt_objcol_SdtUHomeModulesSDT_UHomeModulesSDTItem1) ;
         AV13DashboardItems = GXt_objcol_SdtUHomeModulesSDT_UHomeModulesSDTItem1;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV13DashboardItems.Count )
         {
            AV12DashboardItem = ((SdtUHomeModulesSDT_UHomeModulesSDTItem)AV13DashboardItems.Item(AV25GXV1));
            if ( StringUtil.StrCmp(AV11UserRoleName, AV12DashboardItem.gxTpr_Rolename) == 0 )
            {
               AV14FilteredDashboardItems.Add(AV12DashboardItem, 0);
            }
            else
            {
               if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV12DashboardItem.gxTpr_Rolename)) || ( StringUtil.StrCmp(AV12DashboardItem.gxTpr_Rolename, "All") == 0 ) ) && ( StringUtil.StrCmp(AV11UserRoleName, "Comforta Admin") != 0 ) )
               {
                  AV14FilteredDashboardItems.Add(AV12DashboardItem, 0);
               }
            }
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         AV18WWPContext.gxTpr_Filtereddashboarditems = AV14FilteredDashboardItems;
         AV15FooterText = context.GetMessage( "Comforta Software", "");
         if ( AV18WWPContext.gxTpr_Isorganisationmanager )
         {
            AV15FooterText = AV18WWPContext.gxTpr_Organisationname;
         }
         else
         {
            if ( AV18WWPContext.gxTpr_Isreceptionist )
            {
               AV15FooterText = AV18WWPContext.gxTpr_Organisationname + " : " + AV18WWPContext.gxTpr_Locationname;
            }
         }
         AV18WWPContext.gxTpr_Footertext = AV15FooterText;
         AV18WWPContext.gxTpr_Iscontextset = true;
         new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV18WWPContext) ;
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
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV16GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11UserRoleName = "";
         P008N2_A71ResidentGUID = new string[] {""} ;
         P008N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008N2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008N2_A40000ResidentImage_GXI = new string[] {""} ;
         P008N2_n40000ResidentImage_GXI = new bool[] {false} ;
         P008N2_A432ResidentHomePhoneNumber = new string[] {""} ;
         P008N2_A431ResidentHomePhoneCode = new string[] {""} ;
         A71ResidentGUID = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A40000ResidentImage_GXI = "";
         A432ResidentHomePhoneNumber = "";
         A431ResidentHomePhoneCode = "";
         AV17OrganisationId = Guid.Empty;
         AV10LocationId = Guid.Empty;
         P008N3_A25ManagerEmail = new string[] {""} ;
         P008N3_A28ManagerGAMGUID = new string[] {""} ;
         P008N3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N3_A21ManagerId = new Guid[] {Guid.Empty} ;
         P008N3_A332ManagerIsMainManager = new bool[] {false} ;
         P008N3_A365ManagerIsActive = new bool[] {false} ;
         P008N3_A40001ManagerImage_GXI = new string[] {""} ;
         P008N3_A358ManagerPhoneNumber = new string[] {""} ;
         P008N3_A357ManagerPhoneCode = new string[] {""} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A21ManagerId = Guid.Empty;
         A40001ManagerImage_GXI = "";
         A358ManagerPhoneNumber = "";
         A357ManagerPhoneCode = "";
         P008N4_A93ReceptionistEmail = new string[] {""} ;
         P008N4_A95ReceptionistGAMGUID = new string[] {""} ;
         P008N4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N4_A29LocationId = new Guid[] {Guid.Empty} ;
         P008N4_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P008N4_A40002ReceptionistImage_GXI = new string[] {""} ;
         P008N4_A346ReceptionistPhoneNumber = new string[] {""} ;
         P008N4_A345ReceptionistPhoneCode = new string[] {""} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A89ReceptionistId = Guid.Empty;
         A40002ReceptionistImage_GXI = "";
         A346ReceptionistPhoneNumber = "";
         A345ReceptionistPhoneCode = "";
         P008N5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N5_A13OrganisationName = new string[] {""} ;
         A13OrganisationName = "";
         P008N6_A29LocationId = new Guid[] {Guid.Empty} ;
         P008N6_A31LocationName = new string[] {""} ;
         P008N6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A31LocationName = "";
         P008N7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N7_A40003OrganisationSettingLogo_GXI = new string[] {""} ;
         P008N7_A40004OrganisationSettingFavicon_GXI = new string[] {""} ;
         P008N7_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P008N7_A103OrganisationSettingBaseColor = new string[] {""} ;
         P008N7_A104OrganisationSettingFontSize = new string[] {""} ;
         P008N7_A105OrganisationSettingLanguage = new string[] {""} ;
         P008N7_A510OrganisationHasMyCare = new bool[] {false} ;
         P008N7_A511OrganisationHasMyLiving = new bool[] {false} ;
         P008N7_A512OrganisationHasMyServices = new bool[] {false} ;
         P008N7_A513OrganisationHasDynamicForms = new bool[] {false} ;
         P008N7_A514OrganisationBrandTheme = new string[] {""} ;
         P008N7_A515OrganisationCtaTheme = new string[] {""} ;
         P008N7_A101OrganisationSettingLogo = new string[] {""} ;
         P008N7_A102OrganisationSettingFavicon = new string[] {""} ;
         A40003OrganisationSettingLogo_GXI = "";
         A40004OrganisationSettingFavicon_GXI = "";
         A100OrganisationSettingid = Guid.Empty;
         A103OrganisationSettingBaseColor = "";
         A104OrganisationSettingFontSize = "";
         A105OrganisationSettingLanguage = "";
         A514OrganisationBrandTheme = "";
         A515OrganisationCtaTheme = "";
         A101OrganisationSettingLogo = "";
         A102OrganisationSettingFavicon = "";
         AV13DashboardItems = new GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDTItem", "Comforta_version2");
         GXt_objcol_SdtUHomeModulesSDT_UHomeModulesSDTItem1 = new GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDTItem", "Comforta_version2");
         AV12DashboardItem = new SdtUHomeModulesSDT_UHomeModulesSDTItem(context);
         AV14FilteredDashboardItems = new GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDTItem", "Comforta_version2");
         AV15FooterText = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_loadwwpcontext__default(),
            new Object[][] {
                new Object[] {
               P008N2_A71ResidentGUID, P008N2_A11OrganisationId, P008N2_A29LocationId, P008N2_A62ResidentId, P008N2_A40000ResidentImage_GXI, P008N2_n40000ResidentImage_GXI, P008N2_A432ResidentHomePhoneNumber, P008N2_A431ResidentHomePhoneCode
               }
               , new Object[] {
               P008N3_A25ManagerEmail, P008N3_A28ManagerGAMGUID, P008N3_A11OrganisationId, P008N3_A21ManagerId, P008N3_A332ManagerIsMainManager, P008N3_A365ManagerIsActive, P008N3_A40001ManagerImage_GXI, P008N3_A358ManagerPhoneNumber, P008N3_A357ManagerPhoneCode
               }
               , new Object[] {
               P008N4_A93ReceptionistEmail, P008N4_A95ReceptionistGAMGUID, P008N4_A11OrganisationId, P008N4_A29LocationId, P008N4_A89ReceptionistId, P008N4_A40002ReceptionistImage_GXI, P008N4_A346ReceptionistPhoneNumber, P008N4_A345ReceptionistPhoneCode
               }
               , new Object[] {
               P008N5_A11OrganisationId, P008N5_A13OrganisationName
               }
               , new Object[] {
               P008N6_A29LocationId, P008N6_A31LocationName, P008N6_A11OrganisationId
               }
               , new Object[] {
               P008N7_A11OrganisationId, P008N7_A40003OrganisationSettingLogo_GXI, P008N7_A40004OrganisationSettingFavicon_GXI, P008N7_A100OrganisationSettingid, P008N7_A103OrganisationSettingBaseColor, P008N7_A104OrganisationSettingFontSize, P008N7_A105OrganisationSettingLanguage, P008N7_A510OrganisationHasMyCare, P008N7_A511OrganisationHasMyLiving, P008N7_A512OrganisationHasMyServices,
               P008N7_A513OrganisationHasDynamicForms, P008N7_A514OrganisationBrandTheme, P008N7_A515OrganisationCtaTheme, P008N7_A101OrganisationSettingLogo, P008N7_A102OrganisationSettingFavicon
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl93 ;
      private int AV25GXV1 ;
      private bool n40000ResidentImage_GXI ;
      private bool A332ManagerIsMainManager ;
      private bool A365ManagerIsActive ;
      private bool A510OrganisationHasMyCare ;
      private bool A511OrganisationHasMyLiving ;
      private bool A512OrganisationHasMyServices ;
      private bool A513OrganisationHasDynamicForms ;
      private string A105OrganisationSettingLanguage ;
      private string A514OrganisationBrandTheme ;
      private string A515OrganisationCtaTheme ;
      private string AV11UserRoleName ;
      private string A71ResidentGUID ;
      private string A40000ResidentImage_GXI ;
      private string A432ResidentHomePhoneNumber ;
      private string A431ResidentHomePhoneCode ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A40001ManagerImage_GXI ;
      private string A358ManagerPhoneNumber ;
      private string A357ManagerPhoneCode ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private string A40002ReceptionistImage_GXI ;
      private string A346ReceptionistPhoneNumber ;
      private string A345ReceptionistPhoneCode ;
      private string A13OrganisationName ;
      private string A31LocationName ;
      private string A40003OrganisationSettingLogo_GXI ;
      private string A40004OrganisationSettingFavicon_GXI ;
      private string A103OrganisationSettingBaseColor ;
      private string A104OrganisationSettingFontSize ;
      private string AV15FooterText ;
      private string A101OrganisationSettingLogo ;
      private string A102OrganisationSettingFavicon ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid AV17OrganisationId ;
      private Guid AV10LocationId ;
      private Guid A21ManagerId ;
      private Guid A89ReceptionistId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV8GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P008N2_A71ResidentGUID ;
      private Guid[] P008N2_A11OrganisationId ;
      private Guid[] P008N2_A29LocationId ;
      private Guid[] P008N2_A62ResidentId ;
      private string[] P008N2_A40000ResidentImage_GXI ;
      private bool[] P008N2_n40000ResidentImage_GXI ;
      private string[] P008N2_A432ResidentHomePhoneNumber ;
      private string[] P008N2_A431ResidentHomePhoneCode ;
      private string[] P008N3_A25ManagerEmail ;
      private string[] P008N3_A28ManagerGAMGUID ;
      private Guid[] P008N3_A11OrganisationId ;
      private Guid[] P008N3_A21ManagerId ;
      private bool[] P008N3_A332ManagerIsMainManager ;
      private bool[] P008N3_A365ManagerIsActive ;
      private string[] P008N3_A40001ManagerImage_GXI ;
      private string[] P008N3_A358ManagerPhoneNumber ;
      private string[] P008N3_A357ManagerPhoneCode ;
      private string[] P008N4_A93ReceptionistEmail ;
      private string[] P008N4_A95ReceptionistGAMGUID ;
      private Guid[] P008N4_A11OrganisationId ;
      private Guid[] P008N4_A29LocationId ;
      private Guid[] P008N4_A89ReceptionistId ;
      private string[] P008N4_A40002ReceptionistImage_GXI ;
      private string[] P008N4_A346ReceptionistPhoneNumber ;
      private string[] P008N4_A345ReceptionistPhoneCode ;
      private Guid[] P008N5_A11OrganisationId ;
      private string[] P008N5_A13OrganisationName ;
      private Guid[] P008N6_A29LocationId ;
      private string[] P008N6_A31LocationName ;
      private Guid[] P008N6_A11OrganisationId ;
      private Guid[] P008N7_A11OrganisationId ;
      private string[] P008N7_A40003OrganisationSettingLogo_GXI ;
      private string[] P008N7_A40004OrganisationSettingFavicon_GXI ;
      private Guid[] P008N7_A100OrganisationSettingid ;
      private string[] P008N7_A103OrganisationSettingBaseColor ;
      private string[] P008N7_A104OrganisationSettingFontSize ;
      private string[] P008N7_A105OrganisationSettingLanguage ;
      private bool[] P008N7_A510OrganisationHasMyCare ;
      private bool[] P008N7_A511OrganisationHasMyLiving ;
      private bool[] P008N7_A512OrganisationHasMyServices ;
      private bool[] P008N7_A513OrganisationHasDynamicForms ;
      private string[] P008N7_A514OrganisationBrandTheme ;
      private string[] P008N7_A515OrganisationCtaTheme ;
      private string[] P008N7_A101OrganisationSettingLogo ;
      private string[] P008N7_A102OrganisationSettingFavicon ;
      private GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> AV13DashboardItems ;
      private GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> GXt_objcol_SdtUHomeModulesSDT_UHomeModulesSDTItem1 ;
      private SdtUHomeModulesSDT_UHomeModulesSDTItem AV12DashboardItem ;
      private GXBaseCollection<SdtUHomeModulesSDT_UHomeModulesSDTItem> AV14FilteredDashboardItems ;
   }

   public class prc_loadwwpcontext__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008N2;
          prmP008N2 = new Object[] {
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP008N3;
          prmP008N3 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP008N4;
          prmP008N4 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP008N5;
          prmP008N5 = new Object[] {
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008N6;
          prmP008N6 = new Object[] {
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008N7;
          prmP008N7 = new Object[] {
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008N2", "SELECT ResidentGUID, OrganisationId, LocationId, ResidentId, ResidentImage_GXI, ResidentHomePhoneNumber, ResidentHomePhoneCode FROM Trn_Resident WHERE ResidentGUID = ( :AV9GAMUser__Guid) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008N3", "SELECT ManagerEmail, ManagerGAMGUID, OrganisationId, ManagerId, ManagerIsMainManager, ManagerIsActive, ManagerImage_GXI, ManagerPhoneNumber, ManagerPhoneCode FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV9GAMUser__Email)) AND (ManagerGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008N4", "SELECT ReceptionistEmail, ReceptionistGAMGUID, OrganisationId, LocationId, ReceptionistId, ReceptionistImage_GXI, ReceptionistPhoneNumber, ReceptionistPhoneCode FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV9GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008N5", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008N6", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008N7", "SELECT OrganisationId, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationHasDynamicForms, OrganisationBrandTheme, OrganisationCtaTheme, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N7,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(2));
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(3));
                return;
       }
    }

 }

}
