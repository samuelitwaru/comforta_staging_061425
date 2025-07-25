using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_locationconversion : GXProcedure
   {
      public trn_locationconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_locationconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_LOCATI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A631ToolBoxLastUpdateTime = TRN_LOCATI2_A631ToolBoxLastUpdateTime[0];
            n631ToolBoxLastUpdateTime = TRN_LOCATI2_n631ToolBoxLastUpdateTime[0];
            A630ToolBoxLastUpdateReceptionistI = TRN_LOCATI2_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = TRN_LOCATI2_n630ToolBoxLastUpdateReceptionistI[0];
            A598PublishedActiveAppVersionId = TRN_LOCATI2_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = TRN_LOCATI2_n598PublishedActiveAppVersionId[0];
            A584ActiveAppVersionId = TRN_LOCATI2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = TRN_LOCATI2_n584ActiveAppVersionId[0];
            A577LocationThemeId = TRN_LOCATI2_A577LocationThemeId[0];
            n577LocationThemeId = TRN_LOCATI2_n577LocationThemeId[0];
            A575ReceptionDescription = TRN_LOCATI2_A575ReceptionDescription[0];
            n575ReceptionDescription = TRN_LOCATI2_n575ReceptionDescription[0];
            A573LocationHasOwnBrand = TRN_LOCATI2_A573LocationHasOwnBrand[0];
            A572LocationHasMyLiving = TRN_LOCATI2_A572LocationHasMyLiving[0];
            A571LocationHasMyServices = TRN_LOCATI2_A571LocationHasMyServices[0];
            A570LocationHasMyCare = TRN_LOCATI2_A570LocationHasMyCare[0];
            A569LocationCtaTheme = TRN_LOCATI2_A569LocationCtaTheme[0];
            n569LocationCtaTheme = TRN_LOCATI2_n569LocationCtaTheme[0];
            A568LocationBrandTheme = TRN_LOCATI2_A568LocationBrandTheme[0];
            n568LocationBrandTheme = TRN_LOCATI2_n568LocationBrandTheme[0];
            A504ToolBoxDefaultProfileImage = TRN_LOCATI2_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = TRN_LOCATI2_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = TRN_LOCATI2_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = TRN_LOCATI2_n503ToolBoxDefaultLogo[0];
            A327LocationCountry = TRN_LOCATI2_A327LocationCountry[0];
            A356LocationPhoneNumber = TRN_LOCATI2_A356LocationPhoneNumber[0];
            A355LocationPhoneCode = TRN_LOCATI2_A355LocationPhoneCode[0];
            A331LocationAddressLine2 = TRN_LOCATI2_A331LocationAddressLine2[0];
            A330LocationAddressLine1 = TRN_LOCATI2_A330LocationAddressLine1[0];
            A329LocationZipCode = TRN_LOCATI2_A329LocationZipCode[0];
            A328LocationCity = TRN_LOCATI2_A328LocationCity[0];
            A36LocationDescription = TRN_LOCATI2_A36LocationDescription[0];
            A35LocationPhone = TRN_LOCATI2_A35LocationPhone[0];
            A34LocationEmail = TRN_LOCATI2_A34LocationEmail[0];
            A31LocationName = TRN_LOCATI2_A31LocationName[0];
            A11OrganisationId = TRN_LOCATI2_A11OrganisationId[0];
            A29LocationId = TRN_LOCATI2_A29LocationId[0];
            A40001ReceptionImage_GXI = TRN_LOCATI2_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = TRN_LOCATI2_n40001ReceptionImage_GXI[0];
            A40000LocationImage_GXI = TRN_LOCATI2_A40000LocationImage_GXI[0];
            n40000LocationImage_GXI = TRN_LOCATI2_n40000LocationImage_GXI[0];
            A574ReceptionImage = TRN_LOCATI2_A574ReceptionImage[0];
            n574ReceptionImage = TRN_LOCATI2_n574ReceptionImage[0];
            A494LocationImage = TRN_LOCATI2_A494LocationImage[0];
            n494LocationImage = TRN_LOCATI2_n494LocationImage[0];
            /*
               INSERT RECORD ON TABLE GXA0006

            */
            AV2LocationId = A29LocationId;
            AV3OrganisationId = A11OrganisationId;
            AV4LocationName = A31LocationName;
            AV5LocationEmail = A34LocationEmail;
            AV6LocationPhone = A35LocationPhone;
            AV7LocationDescription = A36LocationDescription;
            AV8LocationCity = A328LocationCity;
            AV9LocationZipCode = A329LocationZipCode;
            AV10LocationAddressLine1 = A330LocationAddressLine1;
            AV11LocationAddressLine2 = A331LocationAddressLine2;
            AV12LocationPhoneCode = A355LocationPhoneCode;
            AV13LocationPhoneNumber = A356LocationPhoneNumber;
            AV14LocationCountry = A327LocationCountry;
            if ( TRN_LOCATI2_n494LocationImage[0] )
            {
               AV15LocationImage = "";
               nV15LocationImage = false;
               nV15LocationImage = true;
            }
            else
            {
               AV15LocationImage = A494LocationImage;
               nV15LocationImage = false;
               AV16LocationImage_GXI = A40000LocationImage_GXI;
               nV16LocationImage_GXI = false;
            }
            if ( TRN_LOCATI2_n40000LocationImage_GXI[0] )
            {
               AV16LocationImage_GXI = "";
               nV16LocationImage_GXI = false;
               nV16LocationImage_GXI = true;
            }
            else
            {
               AV16LocationImage_GXI = A40000LocationImage_GXI;
               nV16LocationImage_GXI = false;
            }
            if ( TRN_LOCATI2_n503ToolBoxDefaultLogo[0] )
            {
               AV17ToolBoxDefaultLogo = "";
               nV17ToolBoxDefaultLogo = false;
               nV17ToolBoxDefaultLogo = true;
            }
            else
            {
               AV17ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
               nV17ToolBoxDefaultLogo = false;
            }
            if ( TRN_LOCATI2_n504ToolBoxDefaultProfileImage[0] )
            {
               AV18ToolBoxDefaultProfileImage = "";
               nV18ToolBoxDefaultProfileImage = false;
               nV18ToolBoxDefaultProfileImage = true;
            }
            else
            {
               AV18ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
               nV18ToolBoxDefaultProfileImage = false;
            }
            if ( TRN_LOCATI2_n568LocationBrandTheme[0] )
            {
               AV19LocationBrandTheme = "";
               nV19LocationBrandTheme = false;
               nV19LocationBrandTheme = true;
            }
            else
            {
               AV19LocationBrandTheme = A568LocationBrandTheme;
               nV19LocationBrandTheme = false;
            }
            if ( TRN_LOCATI2_n569LocationCtaTheme[0] )
            {
               AV20LocationCtaTheme = "";
               nV20LocationCtaTheme = false;
               nV20LocationCtaTheme = true;
            }
            else
            {
               AV20LocationCtaTheme = A569LocationCtaTheme;
               nV20LocationCtaTheme = false;
            }
            AV21LocationHasMyCare = A570LocationHasMyCare;
            AV22LocationHasMyServices = A571LocationHasMyServices;
            AV23LocationHasMyLiving = A572LocationHasMyLiving;
            AV24LocationHasOwnBrand = A573LocationHasOwnBrand;
            if ( TRN_LOCATI2_n574ReceptionImage[0] )
            {
               AV25ReceptionImage = "";
               nV25ReceptionImage = false;
               nV25ReceptionImage = true;
            }
            else
            {
               AV25ReceptionImage = A574ReceptionImage;
               nV25ReceptionImage = false;
               AV26ReceptionImage_GXI = A40001ReceptionImage_GXI;
               nV26ReceptionImage_GXI = false;
            }
            if ( TRN_LOCATI2_n40001ReceptionImage_GXI[0] )
            {
               AV26ReceptionImage_GXI = "";
               nV26ReceptionImage_GXI = false;
               nV26ReceptionImage_GXI = true;
            }
            else
            {
               AV26ReceptionImage_GXI = A40001ReceptionImage_GXI;
               nV26ReceptionImage_GXI = false;
            }
            if ( TRN_LOCATI2_n575ReceptionDescription[0] )
            {
               AV27ReceptionDescription = "";
               nV27ReceptionDescription = false;
               nV27ReceptionDescription = true;
            }
            else
            {
               AV27ReceptionDescription = A575ReceptionDescription;
               nV27ReceptionDescription = false;
            }
            if ( TRN_LOCATI2_n577LocationThemeId[0] )
            {
               AV28LocationThemeId = Guid.Empty;
               nV28LocationThemeId = false;
               nV28LocationThemeId = true;
            }
            else
            {
               AV28LocationThemeId = A577LocationThemeId;
               nV28LocationThemeId = false;
            }
            if ( TRN_LOCATI2_n584ActiveAppVersionId[0] )
            {
               AV29ActiveAppVersionId = Guid.Empty;
               nV29ActiveAppVersionId = false;
               nV29ActiveAppVersionId = true;
            }
            else
            {
               AV29ActiveAppVersionId = A584ActiveAppVersionId;
               nV29ActiveAppVersionId = false;
            }
            if ( TRN_LOCATI2_n598PublishedActiveAppVersionId[0] )
            {
               AV30PublishedActiveAppVersionId = Guid.Empty;
               nV30PublishedActiveAppVersionId = false;
               nV30PublishedActiveAppVersionId = true;
            }
            else
            {
               AV30PublishedActiveAppVersionId = A598PublishedActiveAppVersionId;
               nV30PublishedActiveAppVersionId = false;
            }
            if ( TRN_LOCATI2_n630ToolBoxLastUpdateReceptionistI[0] )
            {
               AV31ToolBoxLastUpdateReceptionistI = Guid.Empty;
               nV31ToolBoxLastUpdateReceptionistI = false;
               nV31ToolBoxLastUpdateReceptionistI = true;
            }
            else
            {
               AV31ToolBoxLastUpdateReceptionistI = A630ToolBoxLastUpdateReceptionistI;
               nV31ToolBoxLastUpdateReceptionistI = false;
            }
            if ( TRN_LOCATI2_n631ToolBoxLastUpdateTime[0] )
            {
               AV32ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
               nV32ToolBoxLastUpdateTime = false;
               nV32ToolBoxLastUpdateTime = true;
            }
            else
            {
               AV32ToolBoxLastUpdateTime = A631ToolBoxLastUpdateTime;
               nV32ToolBoxLastUpdateTime = false;
            }
            AV33ToolboxHasMultiLingualSupport = true;
            nV33ToolboxHasMultiLingualSupport = false;
            AV34ToolboxSupportedLanguages = context.GetMessage( context.GetMessage( "[{\"value\": \"en\",\"label\": \"English\"},{\"value\": \"nl\",\"label\": \"Nederlands\"}]", ""), "");
            nV34ToolboxSupportedLanguages = false;
            /* Using cursor TRN_LOCATI3 */
            pr_default.execute(1, new Object[] {AV2LocationId, AV3OrganisationId, AV4LocationName, AV5LocationEmail, AV6LocationPhone, AV7LocationDescription, AV8LocationCity, AV9LocationZipCode, AV10LocationAddressLine1, AV11LocationAddressLine2, AV12LocationPhoneCode, AV13LocationPhoneNumber, AV14LocationCountry, nV15LocationImage, AV15LocationImage, nV16LocationImage_GXI, AV16LocationImage_GXI, nV17ToolBoxDefaultLogo, AV17ToolBoxDefaultLogo, nV18ToolBoxDefaultProfileImage, AV18ToolBoxDefaultProfileImage, nV19LocationBrandTheme, AV19LocationBrandTheme, nV20LocationCtaTheme, AV20LocationCtaTheme, AV21LocationHasMyCare, AV22LocationHasMyServices, AV23LocationHasMyLiving, AV24LocationHasOwnBrand, nV25ReceptionImage, AV25ReceptionImage, nV26ReceptionImage_GXI, AV26ReceptionImage_GXI, nV27ReceptionDescription, AV27ReceptionDescription, nV28LocationThemeId, AV28LocationThemeId, nV29ActiveAppVersionId, AV29ActiveAppVersionId, nV30PublishedActiveAppVersionId, AV30PublishedActiveAppVersionId, nV31ToolBoxLastUpdateReceptionistI, AV31ToolBoxLastUpdateReceptionistI, nV32ToolBoxLastUpdateTime, AV32ToolBoxLastUpdateTime, nV33ToolboxHasMultiLingualSupport, AV33ToolboxHasMultiLingualSupport, nV34ToolboxSupportedLanguages, AV34ToolboxSupportedLanguages});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0006");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         TRN_LOCATI2_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         TRN_LOCATI2_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         TRN_LOCATI2_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         TRN_LOCATI2_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n598PublishedActiveAppVersionId = new bool[] {false} ;
         TRN_LOCATI2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n584ActiveAppVersionId = new bool[] {false} ;
         TRN_LOCATI2_A577LocationThemeId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n577LocationThemeId = new bool[] {false} ;
         TRN_LOCATI2_A575ReceptionDescription = new string[] {""} ;
         TRN_LOCATI2_n575ReceptionDescription = new bool[] {false} ;
         TRN_LOCATI2_A573LocationHasOwnBrand = new bool[] {false} ;
         TRN_LOCATI2_A572LocationHasMyLiving = new bool[] {false} ;
         TRN_LOCATI2_A571LocationHasMyServices = new bool[] {false} ;
         TRN_LOCATI2_A570LocationHasMyCare = new bool[] {false} ;
         TRN_LOCATI2_A569LocationCtaTheme = new string[] {""} ;
         TRN_LOCATI2_n569LocationCtaTheme = new bool[] {false} ;
         TRN_LOCATI2_A568LocationBrandTheme = new string[] {""} ;
         TRN_LOCATI2_n568LocationBrandTheme = new bool[] {false} ;
         TRN_LOCATI2_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         TRN_LOCATI2_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         TRN_LOCATI2_A503ToolBoxDefaultLogo = new string[] {""} ;
         TRN_LOCATI2_n503ToolBoxDefaultLogo = new bool[] {false} ;
         TRN_LOCATI2_A327LocationCountry = new string[] {""} ;
         TRN_LOCATI2_A356LocationPhoneNumber = new string[] {""} ;
         TRN_LOCATI2_A355LocationPhoneCode = new string[] {""} ;
         TRN_LOCATI2_A331LocationAddressLine2 = new string[] {""} ;
         TRN_LOCATI2_A330LocationAddressLine1 = new string[] {""} ;
         TRN_LOCATI2_A329LocationZipCode = new string[] {""} ;
         TRN_LOCATI2_A328LocationCity = new string[] {""} ;
         TRN_LOCATI2_A36LocationDescription = new string[] {""} ;
         TRN_LOCATI2_A35LocationPhone = new string[] {""} ;
         TRN_LOCATI2_A34LocationEmail = new string[] {""} ;
         TRN_LOCATI2_A31LocationName = new string[] {""} ;
         TRN_LOCATI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A40001ReceptionImage_GXI = new string[] {""} ;
         TRN_LOCATI2_n40001ReceptionImage_GXI = new bool[] {false} ;
         TRN_LOCATI2_A40000LocationImage_GXI = new string[] {""} ;
         TRN_LOCATI2_n40000LocationImage_GXI = new bool[] {false} ;
         TRN_LOCATI2_A574ReceptionImage = new string[] {""} ;
         TRN_LOCATI2_n574ReceptionImage = new bool[] {false} ;
         TRN_LOCATI2_A494LocationImage = new string[] {""} ;
         TRN_LOCATI2_n494LocationImage = new bool[] {false} ;
         A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A577LocationThemeId = Guid.Empty;
         A575ReceptionDescription = "";
         A569LocationCtaTheme = "";
         A568LocationBrandTheme = "";
         A504ToolBoxDefaultProfileImage = "";
         A503ToolBoxDefaultLogo = "";
         A327LocationCountry = "";
         A356LocationPhoneNumber = "";
         A355LocationPhoneCode = "";
         A331LocationAddressLine2 = "";
         A330LocationAddressLine1 = "";
         A329LocationZipCode = "";
         A328LocationCity = "";
         A36LocationDescription = "";
         A35LocationPhone = "";
         A34LocationEmail = "";
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A40001ReceptionImage_GXI = "";
         A40000LocationImage_GXI = "";
         A574ReceptionImage = "";
         A494LocationImage = "";
         AV2LocationId = Guid.Empty;
         AV3OrganisationId = Guid.Empty;
         AV4LocationName = "";
         AV5LocationEmail = "";
         AV6LocationPhone = "";
         AV7LocationDescription = "";
         AV8LocationCity = "";
         AV9LocationZipCode = "";
         AV10LocationAddressLine1 = "";
         AV11LocationAddressLine2 = "";
         AV12LocationPhoneCode = "";
         AV13LocationPhoneNumber = "";
         AV14LocationCountry = "";
         AV15LocationImage = "";
         AV16LocationImage_GXI = "";
         AV17ToolBoxDefaultLogo = "";
         AV18ToolBoxDefaultProfileImage = "";
         AV19LocationBrandTheme = "";
         AV20LocationCtaTheme = "";
         AV25ReceptionImage = "";
         AV26ReceptionImage_GXI = "";
         AV27ReceptionDescription = "";
         AV28LocationThemeId = Guid.Empty;
         AV29ActiveAppVersionId = Guid.Empty;
         AV30PublishedActiveAppVersionId = Guid.Empty;
         AV31ToolBoxLastUpdateReceptionistI = Guid.Empty;
         AV32ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         AV34ToolboxSupportedLanguages = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_LOCATI2_A631ToolBoxLastUpdateTime, TRN_LOCATI2_n631ToolBoxLastUpdateTime, TRN_LOCATI2_A630ToolBoxLastUpdateReceptionistI, TRN_LOCATI2_n630ToolBoxLastUpdateReceptionistI, TRN_LOCATI2_A598PublishedActiveAppVersionId, TRN_LOCATI2_n598PublishedActiveAppVersionId, TRN_LOCATI2_A584ActiveAppVersionId, TRN_LOCATI2_n584ActiveAppVersionId, TRN_LOCATI2_A577LocationThemeId, TRN_LOCATI2_n577LocationThemeId,
               TRN_LOCATI2_A575ReceptionDescription, TRN_LOCATI2_n575ReceptionDescription, TRN_LOCATI2_A573LocationHasOwnBrand, TRN_LOCATI2_A572LocationHasMyLiving, TRN_LOCATI2_A571LocationHasMyServices, TRN_LOCATI2_A570LocationHasMyCare, TRN_LOCATI2_A569LocationCtaTheme, TRN_LOCATI2_n569LocationCtaTheme, TRN_LOCATI2_A568LocationBrandTheme, TRN_LOCATI2_n568LocationBrandTheme,
               TRN_LOCATI2_A504ToolBoxDefaultProfileImage, TRN_LOCATI2_n504ToolBoxDefaultProfileImage, TRN_LOCATI2_A503ToolBoxDefaultLogo, TRN_LOCATI2_n503ToolBoxDefaultLogo, TRN_LOCATI2_A327LocationCountry, TRN_LOCATI2_A356LocationPhoneNumber, TRN_LOCATI2_A355LocationPhoneCode, TRN_LOCATI2_A331LocationAddressLine2, TRN_LOCATI2_A330LocationAddressLine1, TRN_LOCATI2_A329LocationZipCode,
               TRN_LOCATI2_A328LocationCity, TRN_LOCATI2_A36LocationDescription, TRN_LOCATI2_A35LocationPhone, TRN_LOCATI2_A34LocationEmail, TRN_LOCATI2_A31LocationName, TRN_LOCATI2_A11OrganisationId, TRN_LOCATI2_A29LocationId, TRN_LOCATI2_A40001ReceptionImage_GXI, TRN_LOCATI2_n40001ReceptionImage_GXI, TRN_LOCATI2_A40000LocationImage_GXI,
               TRN_LOCATI2_n40000LocationImage_GXI, TRN_LOCATI2_A574ReceptionImage, TRN_LOCATI2_n574ReceptionImage, TRN_LOCATI2_A494LocationImage, TRN_LOCATI2_n494LocationImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0006 ;
      private string A35LocationPhone ;
      private string AV6LocationPhone ;
      private string Gx_emsg ;
      private DateTime A631ToolBoxLastUpdateTime ;
      private DateTime AV32ToolBoxLastUpdateTime ;
      private bool n631ToolBoxLastUpdateTime ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n584ActiveAppVersionId ;
      private bool n577LocationThemeId ;
      private bool n575ReceptionDescription ;
      private bool A573LocationHasOwnBrand ;
      private bool A572LocationHasMyLiving ;
      private bool A571LocationHasMyServices ;
      private bool A570LocationHasMyCare ;
      private bool n569LocationCtaTheme ;
      private bool n568LocationBrandTheme ;
      private bool n504ToolBoxDefaultProfileImage ;
      private bool n503ToolBoxDefaultLogo ;
      private bool n40001ReceptionImage_GXI ;
      private bool n40000LocationImage_GXI ;
      private bool n574ReceptionImage ;
      private bool n494LocationImage ;
      private bool nV15LocationImage ;
      private bool nV16LocationImage_GXI ;
      private bool nV17ToolBoxDefaultLogo ;
      private bool nV18ToolBoxDefaultProfileImage ;
      private bool nV19LocationBrandTheme ;
      private bool nV20LocationCtaTheme ;
      private bool AV21LocationHasMyCare ;
      private bool AV22LocationHasMyServices ;
      private bool AV23LocationHasMyLiving ;
      private bool AV24LocationHasOwnBrand ;
      private bool nV25ReceptionImage ;
      private bool nV26ReceptionImage_GXI ;
      private bool nV27ReceptionDescription ;
      private bool nV28LocationThemeId ;
      private bool nV29ActiveAppVersionId ;
      private bool nV30PublishedActiveAppVersionId ;
      private bool nV31ToolBoxLastUpdateReceptionistI ;
      private bool nV32ToolBoxLastUpdateTime ;
      private bool AV33ToolboxHasMultiLingualSupport ;
      private bool nV33ToolboxHasMultiLingualSupport ;
      private bool nV34ToolboxSupportedLanguages ;
      private string A569LocationCtaTheme ;
      private string A568LocationBrandTheme ;
      private string A36LocationDescription ;
      private string AV7LocationDescription ;
      private string AV19LocationBrandTheme ;
      private string AV20LocationCtaTheme ;
      private string AV34ToolboxSupportedLanguages ;
      private string A575ReceptionDescription ;
      private string A504ToolBoxDefaultProfileImage ;
      private string A503ToolBoxDefaultLogo ;
      private string A327LocationCountry ;
      private string A356LocationPhoneNumber ;
      private string A355LocationPhoneCode ;
      private string A331LocationAddressLine2 ;
      private string A330LocationAddressLine1 ;
      private string A329LocationZipCode ;
      private string A328LocationCity ;
      private string A34LocationEmail ;
      private string A31LocationName ;
      private string A40001ReceptionImage_GXI ;
      private string A40000LocationImage_GXI ;
      private string AV4LocationName ;
      private string AV5LocationEmail ;
      private string AV8LocationCity ;
      private string AV9LocationZipCode ;
      private string AV10LocationAddressLine1 ;
      private string AV11LocationAddressLine2 ;
      private string AV12LocationPhoneCode ;
      private string AV13LocationPhoneNumber ;
      private string AV14LocationCountry ;
      private string AV16LocationImage_GXI ;
      private string AV17ToolBoxDefaultLogo ;
      private string AV18ToolBoxDefaultProfileImage ;
      private string AV26ReceptionImage_GXI ;
      private string AV27ReceptionDescription ;
      private string A574ReceptionImage ;
      private string A494LocationImage ;
      private string AV15LocationImage ;
      private string AV25ReceptionImage ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A577LocationThemeId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private Guid AV28LocationThemeId ;
      private Guid AV29ActiveAppVersionId ;
      private Guid AV30PublishedActiveAppVersionId ;
      private Guid AV31ToolBoxLastUpdateReceptionistI ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] TRN_LOCATI2_A631ToolBoxLastUpdateTime ;
      private bool[] TRN_LOCATI2_n631ToolBoxLastUpdateTime ;
      private Guid[] TRN_LOCATI2_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] TRN_LOCATI2_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] TRN_LOCATI2_A598PublishedActiveAppVersionId ;
      private bool[] TRN_LOCATI2_n598PublishedActiveAppVersionId ;
      private Guid[] TRN_LOCATI2_A584ActiveAppVersionId ;
      private bool[] TRN_LOCATI2_n584ActiveAppVersionId ;
      private Guid[] TRN_LOCATI2_A577LocationThemeId ;
      private bool[] TRN_LOCATI2_n577LocationThemeId ;
      private string[] TRN_LOCATI2_A575ReceptionDescription ;
      private bool[] TRN_LOCATI2_n575ReceptionDescription ;
      private bool[] TRN_LOCATI2_A573LocationHasOwnBrand ;
      private bool[] TRN_LOCATI2_A572LocationHasMyLiving ;
      private bool[] TRN_LOCATI2_A571LocationHasMyServices ;
      private bool[] TRN_LOCATI2_A570LocationHasMyCare ;
      private string[] TRN_LOCATI2_A569LocationCtaTheme ;
      private bool[] TRN_LOCATI2_n569LocationCtaTheme ;
      private string[] TRN_LOCATI2_A568LocationBrandTheme ;
      private bool[] TRN_LOCATI2_n568LocationBrandTheme ;
      private string[] TRN_LOCATI2_A504ToolBoxDefaultProfileImage ;
      private bool[] TRN_LOCATI2_n504ToolBoxDefaultProfileImage ;
      private string[] TRN_LOCATI2_A503ToolBoxDefaultLogo ;
      private bool[] TRN_LOCATI2_n503ToolBoxDefaultLogo ;
      private string[] TRN_LOCATI2_A327LocationCountry ;
      private string[] TRN_LOCATI2_A356LocationPhoneNumber ;
      private string[] TRN_LOCATI2_A355LocationPhoneCode ;
      private string[] TRN_LOCATI2_A331LocationAddressLine2 ;
      private string[] TRN_LOCATI2_A330LocationAddressLine1 ;
      private string[] TRN_LOCATI2_A329LocationZipCode ;
      private string[] TRN_LOCATI2_A328LocationCity ;
      private string[] TRN_LOCATI2_A36LocationDescription ;
      private string[] TRN_LOCATI2_A35LocationPhone ;
      private string[] TRN_LOCATI2_A34LocationEmail ;
      private string[] TRN_LOCATI2_A31LocationName ;
      private Guid[] TRN_LOCATI2_A11OrganisationId ;
      private Guid[] TRN_LOCATI2_A29LocationId ;
      private string[] TRN_LOCATI2_A40001ReceptionImage_GXI ;
      private bool[] TRN_LOCATI2_n40001ReceptionImage_GXI ;
      private string[] TRN_LOCATI2_A40000LocationImage_GXI ;
      private bool[] TRN_LOCATI2_n40000LocationImage_GXI ;
      private string[] TRN_LOCATI2_A574ReceptionImage ;
      private bool[] TRN_LOCATI2_n574ReceptionImage ;
      private string[] TRN_LOCATI2_A494LocationImage ;
      private bool[] TRN_LOCATI2_n494LocationImage ;
   }

   public class trn_locationconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_LOCATI2;
          prmTRN_LOCATI2 = new Object[] {
          };
          Object[] prmTRN_LOCATI3;
          prmTRN_LOCATI3 = new Object[] {
          new ParDef("AV2LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4LocationName",GXType.VarChar,100,0) ,
          new ParDef("AV5LocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV6LocationPhone",GXType.Char,20,0) ,
          new ParDef("AV7LocationDescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV8LocationCity",GXType.VarChar,100,0) ,
          new ParDef("AV9LocationZipCode",GXType.VarChar,100,0) ,
          new ParDef("AV10LocationAddressLine1",GXType.VarChar,100,0) ,
          new ParDef("AV11LocationAddressLine2",GXType.VarChar,100,0) ,
          new ParDef("AV12LocationPhoneCode",GXType.VarChar,40,0) ,
          new ParDef("AV13LocationPhoneNumber",GXType.VarChar,9,0) ,
          new ParDef("AV14LocationCountry",GXType.VarChar,100,0) ,
          new ParDef("AV15LocationImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
          new ParDef("AV16LocationImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=13, Tbl="GXA0006", Fld="LocationImage"} ,
          new ParDef("AV17ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV18ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV19LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV20LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
          new ParDef("AV21LocationHasMyCare",GXType.Boolean,4,0) ,
          new ParDef("AV22LocationHasMyServices",GXType.Boolean,4,0) ,
          new ParDef("AV23LocationHasMyLiving",GXType.Boolean,4,0) ,
          new ParDef("AV24LocationHasOwnBrand",GXType.Boolean,4,0) ,
          new ParDef("AV25ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
          new ParDef("AV26ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=23, Tbl="GXA0006", Fld="ReceptionImage"} ,
          new ParDef("AV27ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV28LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV29ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV30PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV31ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV32ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV33ToolboxHasMultiLingualSupport",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AV34ToolboxSupportedLanguages",GXType.LongVarChar,1000,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_LOCATI2", "SELECT ToolBoxLastUpdateTime, ToolBoxLastUpdateReceptionistI, PublishedActiveAppVersionId, ActiveAppVersionId, LocationThemeId, ReceptionDescription, LocationHasOwnBrand, LocationHasMyLiving, LocationHasMyServices, LocationHasMyCare, LocationCtaTheme, LocationBrandTheme, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, LocationCountry, LocationPhoneNumber, LocationPhoneCode, LocationAddressLine2, LocationAddressLine1, LocationZipCode, LocationCity, LocationDescription, LocationPhone, LocationEmail, LocationName, OrganisationId, LocationId, ReceptionImage_GXI, LocationImage_GXI, ReceptionImage, LocationImage FROM Trn_Location ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_LOCATI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_LOCATI3", "INSERT INTO GXA0006(LocationId, OrganisationId, LocationName, LocationEmail, LocationPhone, LocationDescription, LocationCity, LocationZipCode, LocationAddressLine1, LocationAddressLine2, LocationPhoneCode, LocationPhoneNumber, LocationCountry, LocationImage, LocationImage_GXI, ToolBoxDefaultLogo, ToolBoxDefaultProfileImage, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, LocationThemeId, ActiveAppVersionId, PublishedActiveAppVersionId, ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime, ToolboxHasMultiLingualSupport, ToolboxSupportedLanguages) VALUES(:AV2LocationId, :AV3OrganisationId, :AV4LocationName, :AV5LocationEmail, :AV6LocationPhone, :AV7LocationDescription, :AV8LocationCity, :AV9LocationZipCode, :AV10LocationAddressLine1, :AV11LocationAddressLine2, :AV12LocationPhoneCode, :AV13LocationPhoneNumber, :AV14LocationCountry, :AV15LocationImage, :AV16LocationImage_GXI, :AV17ToolBoxDefaultLogo, :AV18ToolBoxDefaultProfileImage, :AV19LocationBrandTheme, :AV20LocationCtaTheme, :AV21LocationHasMyCare, :AV22LocationHasMyServices, :AV23LocationHasMyLiving, :AV24LocationHasOwnBrand, :AV25ReceptionImage, :AV26ReceptionImage_GXI, :AV27ReceptionDescription, :AV28LocationThemeId, :AV29ActiveAppVersionId, :AV30PublishedActiveAppVersionId, :AV31ToolBoxLastUpdateReceptionistI, :AV32ToolBoxLastUpdateTime, :AV33ToolboxHasMultiLingualSupport, :AV34ToolboxSupportedLanguages)", GxErrorMask.GX_NOMASK,prmTRN_LOCATI3)
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.getBool(9);
                ((bool[]) buf[15])[0] = rslt.getBool(10);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((string[]) buf[20])[0] = rslt.getVarchar(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((string[]) buf[24])[0] = rslt.getVarchar(15);
                ((string[]) buf[25])[0] = rslt.getVarchar(16);
                ((string[]) buf[26])[0] = rslt.getVarchar(17);
                ((string[]) buf[27])[0] = rslt.getVarchar(18);
                ((string[]) buf[28])[0] = rslt.getVarchar(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((string[]) buf[30])[0] = rslt.getVarchar(21);
                ((string[]) buf[31])[0] = rslt.getLongVarchar(22);
                ((string[]) buf[32])[0] = rslt.getString(23, 20);
                ((string[]) buf[33])[0] = rslt.getVarchar(24);
                ((string[]) buf[34])[0] = rslt.getVarchar(25);
                ((Guid[]) buf[35])[0] = rslt.getGuid(26);
                ((Guid[]) buf[36])[0] = rslt.getGuid(27);
                ((string[]) buf[37])[0] = rslt.getMultimediaUri(28);
                ((bool[]) buf[38])[0] = rslt.wasNull(28);
                ((string[]) buf[39])[0] = rslt.getMultimediaUri(29);
                ((bool[]) buf[40])[0] = rslt.wasNull(29);
                ((string[]) buf[41])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(28));
                ((bool[]) buf[42])[0] = rslt.wasNull(30);
                ((string[]) buf[43])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(29));
                ((bool[]) buf[44])[0] = rslt.wasNull(31);
                return;
       }
    }

 }

}
